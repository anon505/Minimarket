# Minimarket — Project Context

Aplikasi desktop Point-of-Sale (kasir) + manajemen stok minimarket. Proyek lama (dump DB 2013, dulu "Minimarket by Um@m Corporation"), di-upgrade ke .NET Framework 4.8. Branding sekarang: nama produk **"System POS (Point Of Sale)"** (singkat "System POS": shortcut, AssemblyTitle), judul jendela utama **"System POS by BetterMoney"**, publisher/company **BetterMoney**. Nama teknis: exe `POS_BetterMoney.exe` (AssemblyName), folder `Program Files\BetterMoney` & `ProgramData\BetterMoney`, database `bettermoney_pos`, user database bawaan installer `superadmin` (terpisah dari akun login aplikasi `superadmin` di tabel `kasir`), firewall rule "BetterMoney POS Database". Solution/project/RootNamespace tetap `Minimarket` (resource `.rdlc` = `Minimarket.<nama>.rdlc`). Tidak ada migrasi dari nama lama (Minimarket) — sengaja.

## Stack

- **VB.NET WinForms**, .NET Framework 4.8, `PlatformTarget=x86`, solution `Minimarket.sln` → project `Minimarket/Minimarket.vbproj`.
- **Hanya bisa run di Windows** (Visual Studio). Di macOS bisa compile-check + tes SQL (lihat "Verifikasi di macOS").
- **MySQL** (XAMPP) via `MySql.Data` 8.3.0 (NuGet, `packages.config`, folder `packages/` di-gitignore → perlu NuGet restore).
- **Microsoft ReportViewer 10** (`.rdlc`) untuk nota & laporan.
- **Tanpa ODBC** (sejak 2026-10-04): report juga lewat `MySql.Data`. Tidak butuh MySQL ODBC driver, DSN, atau akses registry.
- Tidak ada unit test. Tidak ada layer service/repository — semua SQL langsung di code-behind form.
- code-review-graph **tidak meng-index file `.vb`** (hanya `minimarket_db.sql`). Untuk kode VB pakai Grep/Read langsung.

## Struktur file

Tiap form = `nama.vb` (logic) + `nama.Designer.vb` (UI generated, jangan edit manual kecuali perlu) + `nama.resx`.

| File | Peran |
|---|---|
| `Module1.vb` | Global state: `konek` (MySqlConnection tunggal, dibuka sekali), `id_kasir`, `hak_akses`, `pathlogo`, `namatoko` (semua `String`). `lokasifile(nama)` → path di `%ProgramData%\BetterMoney` |
| `koneksidb.vb` | Logika koneksi tanpa UI (dipakai app & nanti installer): `buatkoneksi()`, `cekkoneksi()` (TCP 3s lalu login MySQL tanpa pooling, pesan error per penyebab), `siapkanserver()` (buat DB, import dump jika kosong, user app `'%'`+`'localhost'`), `izinkanjaringan(my.ini)` |
| `logotoko.vb` | `buatlogo(namatoko, folder)` → PNG 600x300 nama toko di `%ProgramData%\BetterMoney\logotoko-<waktu>.png` (nama unik karena `Bitmap.FromFile` mengunci file lama). `logobuatan(path)`, `hapuslogolama(folder, dipakai)` |
| `main.vb` | MDI parent, startup form (`My Project/Application.myapp` → `MainForm=main`). `konekbuka()` buka koneksi, baca `config.txt`, buka form anak via MenuStrip |
| `Login.vb` | Login: cek `kasir` by `type` + nama + password, lalu cek `status='Aktif'`. Enable/disable menu sesuai role |
| `cpanel.vb` | "Konfigurasi": simpan `koneksi.txt` & `config.txt`, tombol Tes Koneksi (`Button4` → `lblstatus`), backup/restore DB via `mysql.exe`/`mysqldump.exe` |
| `barang.vb` | CRUD barang (produk) + pencarian (nama / harga jual / harga beli / stok dengan operator `< > = <= >=`) |
| `satuan.vb` | CRUD satuan (unit). Hapus satuan ikut hapus barang yang memakainya (setelah konfirmasi) |
| `supplier.vb` | CRUD supplier. Hapus supplier ikut hapus barangnya (setelah konfirmasi) |
| `kasir.vb` | CRUD user/kasir + toggle Aktif/Tidak Aktif. User baru default `Tidak Aktif` |
| `penjualan.vb` | Transaksi jual (POS): input `id_barang` + qty, Enter → masuk keranjang, hitung total/dibayar/kembalian |
| `pembelian.vb` | Transaksi beli/restock dari supplier, pola sama dengan penjualan |
| `formnota.vb` | Cetak nota penjualan (`Report1.rdlc` ← DataTable `nota`, diisi `MySqlDataAdapter`) |
| `cetak.vb` | "Laporan": laporan harian per kasir per tanggal, Penjualan (`penjualan.rdlc` ← `DataTable1`) / Pembelian (`pembelian.rdlc` ← `DataTable2`) |
| `chat.vb` | "Obrolan": chat sederhana antar user lewat tabel `obrolan`, Timer auto-refresh |
| `minimarketds.xsd` / `.Designer.vb` | Typed DataSet **hanya skema** (DataTable `nota`, `DataTable1`, `DataTable2`, tanpa TableAdapter). Query report ada di `formnota.vb`/`cetak.vb`. Kolom SELECT harus cocok dengan kolom DataTable & `<DataField>` di `.rdlc` |
| `modesetup.vb` + `My Project/ApplicationEvents.vb` | Mode command-line untuk installer: `POS_BetterMoney.exe --cek-mysql\|--setup-server\|--setup-client <file.ini>` (tanpa form). Exit code 0 sukses / 1 gagal / 2 port tertutup; pesan di `<file.ini>.hasil`; file ini (berisi password) dihapus setelah dibaca |
| `../minimarket_db.sql` | Dump schema + seed data (phpMyAdmin, MySQL 5.5). Di-import otomatis oleh setup server jika DB kosong |
| `../installer/Minimarket.iss` | Installer Inno Setup 6: pilih Server/Client. Output `dist/SystemPOS-Setup-<versi>.exe` |
| `../.github/workflows/build-installer.yml` | CI Windows: msbuild Release x86 → unduh MSI MariaDB (cek SHA256) → ISCC → artifact `dist/*.exe` |

## Database `bettermoney_pos`

Tanpa foreign key constraint (relasi hanya konvensi). Engine InnoDB, latin1.

- `barang(id_barang PK AI, id_suplier, nama_barang, harga_beli, harga_jual, stok, satuan)` — `satuan` = FK ke `satuan.id_satuan`.
- `satuan(id_satuan PK AI, nama_satuan)`
- `supplier(id_suplier PK AI, nama_suplier, alamat_suplier, contact_person)` — catatan ejaan: **`suplier`** (satu p) di nama kolom, tabel `supplier`.
- `kasir(id_kasir PK AI, nama_kasir, password plaintext, alamat, type, status)` — `type`: `1`=Administrator, `2`=Kasir. `status`: `'Aktif'` / `'Tidak Aktif'`.
- `penjualan(id_barang, id_kasir, total, status, tanggal)` — **tanpa PK, tanpa id transaksi/nota**. Kolom `total` = **jumlah qty**, bukan rupiah.
- `pembelian(id_barang, id_kasir, tgl_pembelian, jumlah, status)` — tanpa PK.
- `obrolan(pesan)`
- View `keuntungan` (penjualan status `'cetak'` + barang + satuan), view `view_beli` (pembelian status `'cetak'`).

### Trigger stok (penting)

- `penjualan` AFTER INSERT: `stok -= total`; AFTER DELETE: `stok += total`.
- `pembelian` AFTER INSERT: `stok += jumlah`; AFTER DELETE: `stok -= jumlah`.
- **Tidak ada trigger UPDATE** → saat item yang sama di-scan ulang, kode VB update `stok` manual lalu update qty baris (lihat `penjualan.jual()`, `pembelian.beli()`). Jika ubah alur, jaga konsistensi ini.

### Seed

User: `superadmin`/`password` (Administrator, satu-satunya akun). 4 supplier, 6 satuan, 5 barang.

Password bawaan = konstanta `PASSWORDBAWAAN` (`Module1.vb`). Selama password akun masih itu, `Login.ingatkanpassword()` memperingatkan setiap login (admin: form Kasir dibuka; kasir: diminta hubungi admin). `modesetup.masihpasswordbawaan()` menambahkan info login pertama di pesan akhir setup server. Ubah seed → sesuaikan keduanya.

## Alur kunci

**Startup**: `main_Load` → `konekbuka()`:
1. Baca `lokasifile("koneksi.txt")` → `MySqlConnectionStringBuilder` (database kosong → `cpanel.txtdb.Text`, default `bettermoney_pos`).
2. `cekkoneksi()`; gagal → MsgBox pesan penyebab + buka `cpanel`. Berhasil → buka `konek`.
3. Tampilkan `Login` sebagai MDI child, MenuStrip disabled sampai login.
4. Baca `config.txt` (`logo=<path>;` baris 1, `toko=<nama>` baris 2).
Jika file tidak ada / koneksi gagal → buka `cpanel`.

**Role**: Admin akses semua menu. Kasir: menu Satuan, Kasir, Supplier, Konfigurasi disabled; di form Barang tombol tambah/edit/hapus disabled.

**Transaksi (keranjang)**: status baris `'belum'` = item di keranjang aktif milik `id_kasir`. Tombol "baru" (`Button3`) → `UPDATE ... SET status='cetak' WHERE status='belum' AND id_kasir=...` = finalisasi. Report/view hanya baca status `'cetak'`. Nota (`formnota`) membaca status `'belum'` → **harus cetak nota sebelum klik baru**. `penjualan_Load` memanggil `Button3_Click` → keranjang lama otomatis difinalisasi saat form dibuka.

Satu transaksi tidak punya nomor nota; item sama di keranjang digabung (qty ditambah).

**Format uang**: angka mentah disimpan di `.Tag` control, `.Text` berisi format `"'Rp' #,0;'Rp' -#,0"`. Saat simpan pakai `.Tag`, bukan `.Text`.

## Konvensi kode

- Bahasa identifier & UI: **Bahasa Indonesia** (`tambah`, `hapus`, `edit`, `lihat`, `pencarian`, `berdasarkan`, `syarat`, `hanyaangka`). Pesan `MsgBox` Bahasa Indonesia.
- Pola form CRUD: `view()` (load grid + reset input), `reload()` → `view()`, `DataGridView1_CellClick` isi input dari row, `Label4` menyimpan ID terpilih (hidden-ish), `pencarian()` dipanggil di `TextChanged`.
- Query: `MySqlCommand(..., konek)` + parameter `@x`, `ExecuteScalar` / `ExecuteNonQuery` / `MySqlDataAdapter.Fill(DataSet)`.
- Form diakses via default instance VB (`barang.Show()`, `penjualan.dibayar.Tag` dari form lain).
- Cek konfirmasi: `MsgBox(..., YesNo)` dibandingkan `= 6` (Yes) / `= 7` (No).
- Logo toko dimuat di tiap form: `If File.Exists(pathlogo) Then PictureBox1.Image = Bitmap.FromFile(pathlogo)`.

## Aturan query (sudah diterapkan 2026-10-04)

- Semua query `MySqlCommand` **wajib parameterized** (`@nama` + `Parameters.AddWithValue`). Jangan concat input user ke SQL.
- Nama kolom/operator yang dinamis (pencarian `barang.vb`) hanya dari daftar tetap (`kolom()`, `operatorcari()`).
- ID dari combobox diambil dari list paralel (`idsuplier`/`idsatuan` di `barang.vb`, `idkasir` di `cetak.vb`), **bukan** `SelectedIndex + 1`.
- Angka dari TextBox dikirim sebagai `Val(...)`.
- Backup/restore (`cpanel.jalankanmysql`) jalankan `mysqldump.exe`/`mysql.exe` langsung dari `C:\` atau `D:\xampp\mysql\bin`, password via env `MYSQL_PWD`, DB = `txtdb.Text`.
- Query nota: GROUP BY memuat semua kolom non-agregat (kompatibel `ONLY_FULL_GROUP_BY` MySQL 5.7+).
- Report: isi typed DataTable dengan `MySqlDataAdapter.Fill(Me.Minimarketds.<tabel>)` setelah `.Clear()`. Jangan tambah TableAdapter/ODBC lagi.

## Masalah yang masih ada (jangan anggap bug baru)

- Password plaintext (sengaja belum di-hash).
- Tidak ada DB transaction; update stok + update qty = 2 query terpisah; hapus satuan/supplier + barang juga terpisah.
- `.vbproj` punya reference ke `Minimarket` exe dirinya sendiri (sisa lama) — curigai jika build error di Visual Studio.
- Restore database (`cpanel`) butuh login root: dump berisi `DEFINER=root@localhost` untuk view/trigger, user aplikasi tidak boleh membuatnya.
- Setting `koneksi` di `My Project/Settings.settings` tidak dipakai (sisa lama).

## Installer (Inno Setup)

- **Server**: halaman port + password root, lalu user aplikasi + nama toko. Next di halaman root menjalankan `--cek-mysql` (exe diekstrak sementara ke `{tmp}`): port tertutup → pasang MariaDB 11.8 LTS MSI (`/qn SERVICENAME=MariaDB PORT= PASSWORD=`) di `PrepareToInstall`; MySQL sudah ada + root benar → pakai yang ada. Setelah file disalin: `--setup-server` (buat DB, import dump, user app `'%'`+`'localhost'`, cek my.ini, tulis koneksi/config, tampilkan IP server) + `netsh` rule firewall "BetterMoney POS Database". Kode 2 (perlu pasang MariaDB) di Windows < 10 ditolak: MSI MariaDB 10.5+ butuh Windows 10 / Server 2016.
- **Client**: halaman IP server, port, user/password app, nama toko; Next menjalankan `--cek-mysql` ke server (gagal → tetap di halaman). Setelah install `--setup-client` menulis koneksi/config.
- JANGAN kirim `ALLOWREMOTEROOTACCESS` ke msiexec (nilai apa pun mengaktifkan root dari jaringan). MSI 11.8 tidak punya properti `UTF8`.
- Password root tidak boleh mengandung `"` (dikirim ke msiexec dalam tanda kutip).
- Versi MariaDB: `MariaDBMsi` di `.iss` + `MARIADB_VERSION`/`MARIADB_SHA256` di workflow. Ambil versi/checksum dari `https://downloads.mariadb.org/rest-api/mariadb/<major>/latest/`.
- Build lokal di Windows: lihat `installer/README.md` (langkah lengkap, checklist tes, troubleshooting).

## Verifikasi di macOS (tanpa Windows)

- **Compile check**: .NET SDK di `~/.dotnet`. Buat project SDK-style sementara (di luar repo) `TargetFramework=net48`, `MyType=WindowsForms`, `OptionStrict=Off`, `EnableDefaultCompileItems=false` + `<Compile Include="<repo>/Minimarket/**/*.vb" />`, PackageReference `Microsoft.NETFramework.ReferenceAssemblies.net48`, `MySql.Data 8.3.0`, `Microsoft.ReportViewer.WinForms/Common 10.0.40219.1`, `VisualBasic.PowerPacks.Vs 1.0.0`, Reference `System.Windows.Forms/Drawing/Data/Configuration/Deployment/Xml/Management`, project Imports sama dengan `.vbproj`. `.resx` di-skip. Baseline sekarang: 0 error, 0 warning.
- **SQL check**: MariaDB brew. `mariadb-install-db --datadir=<scratch>` lalu `mariadbd --port=33099 --socket=./m.sock` (path socket absolut > 103 char gagal), load `minimarket_db.sql`, jalankan query lewat console net8 + `MySql.Data`.
- **Report check**: console net8 meng-compile `minimarketds.Designer.vb` + `koneksidb.vb` asli, isi DataTable dengan query dari `formnota.vb`/`cetak.vb`; cocokkan `<DataField>` `.rdlc` dengan kolom xsd.
- **Setup mode check**: console net8 meng-compile `koneksidb.vb` + `modesetup.vb`, panggil `jalankanmode()` dengan file ini sungguhan. Uji di MariaDB versi yang sama dengan installer: `brew install mariadb@11.8` (keg-only, `/opt/homebrew/opt/mariadb@11.8/bin`).
- Tidak bisa diverifikasi di Mac: UI WinForms (layout), render ReportViewer, path XAMPP Windows, firewall, compile & jalankan `.iss` (Inno Setup hanya Windows → lewat GitHub Actions).

## File runtime (tidak di repo)

`koneksi.txt` dan `config.txt` ada di `C:\ProgramData\BetterMoney\` (via `lokasifile`). File lama di folder exe otomatis disalin ke sana saat pertama dibaca. Installer perlu memberi hak tulis folder ini ke group Users.

- `koneksi.txt`: satu baris connection string dari `MySqlConnectionStringBuilder` (`server=..;port=..;user id=..;password=..;database=..`). Format lama 4 baris tanpa `database` tetap terbaca.
- `config.txt`: `logo=<path>;` baris 1, `toko=<nama>` baris 2.
- Logo: setup server/client (`tuliskonfigurasi`) mempertahankan logo pilihan user; selain itu (belum ada / logo buatan / `logoku.jpg` bawaan) dibuat dari nama toko. `logoku.jpg` hanya cadangan jika gagal. Di `cpanel`, tombol "Buat Logo" (`Button6`); Simpan membuat ulang logo buatan agar sesuai nama toko.
