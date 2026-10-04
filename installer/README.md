# Membuat Installer System POS (Point Of Sale)

Panduan membuat file `SystemPOS-Setup-x.x.x.exe` di PC Windows. Installer ini bisa dipasang sebagai **Server** (komputer pusat: database MariaDB + aplikasi) atau **Client** (komputer kasir: aplikasi saja).

## Yang perlu disiapkan

| Program | Keterangan |
|---|---|
| [Visual Studio 2022 Community](https://visualstudio.microsoft.com/vs/community/) | Gratis. Saat install, centang workload **.NET desktop development** |
| [Inno Setup 6](https://jrsoftware.org/isdl.php) | Gratis. Untuk pemakaian komersial, pengembangnya *meminta* (tidak mewajibkan) pembelian lisensi |

Salin seluruh folder project ke PC Windows (atau `git clone`).

## Langkah 1 — Build aplikasi

1. Buka `Minimarket.sln` di Visual Studio.
2. Di toolbar atas, ubah **Debug** menjadi **Release**, dan pastikan platform **x86**.
3. Menu **Build → Build Solution**. Paket NuGet diunduh otomatis pada build pertama.
4. Pastikan file `Minimarket\bin\Release\POS_BetterMoney.exe` sudah ada.

## Langkah 2 — Unduh MariaDB

1. Unduh [mariadb-11.8.9-winx64.msi](https://downloads.mariadb.org/rest-api/mariadb/11.8.9/mariadb-11.8.9-winx64.msi) (±84 MB).
2. Buat folder `installer\redist\`, simpan file tadi di sana:

   ```
   installer\redist\mariadb-11.8.9-winx64.msi
   ```

3. (Opsional) Pastikan file tidak rusak. Jalankan di Command Prompt dari folder project:

   ```
   certutil -hashfile installer\redist\mariadb-11.8.9-winx64.msi SHA256
   ```

   Hasil harus: `372822572baa7f429b9068d583336a9e46b109c12bb0b24eb66dbeb6ad0a563e`

Folder `installer\redist\` tidak ikut masuk git (ada di `.gitignore`).

## Langkah 3 — Buat installer

Pilih salah satu cara.

**Cara klik:** klik dua kali `installer\Minimarket.iss` (terbuka di Inno Setup Compiler), lalu menu **Build → Compile** (Ctrl+F9).

**Cara Command Prompt** (dari folder project):

```
"C:\Program Files (x86)\Inno Setup 6\ISCC.exe" installer\Minimarket.iss
```

Untuk mengganti nomor versi:

```
"C:\Program Files (x86)\Inno Setup 6\ISCC.exe" /DAppVersion=1.0.1 installer\Minimarket.iss
```

Hasil: `dist\SystemPOS-Setup-1.0.0.exe` (±90 MB). File ini yang dibawa ke komputer toko.

## Langkah 4 — Pasang & tes

Pasang **server dulu**, baru client.

### Server (satu komputer pusat, Windows 64-bit)

1. Jalankan installer → pilih **Server**.
2. Isi port database (biarkan `3306`) dan password root database. Simpan password ini.
   - Jika di komputer ini sudah ada MySQL/MariaDB/XAMPP yang berjalan, isi password root yang sudah ada; installer akan memakainya, tidak memasang MariaDB baru.
3. Isi username & password aplikasi serta nama toko. **Catat** username & password ini untuk memasang client.
4. Selesai instalasi, muncul pesan berisi **IP komputer server**. Catat IP ini.

### Client (setiap komputer kasir)

1. Jalankan installer yang sama → pilih **Client**.
2. Isi IP server (dari langkah server no. 4), port, username & password aplikasi, nama toko.
3. Klik Next — koneksi ke server langsung dites. Jika gagal, pesan menjelaskan penyebabnya (IP salah, firewall, password salah, dll).

### Cek setelah instalasi

- [ ] Login di server: jabatan **Administrator**, `superadmin` / `password` (akun bawaan)
- [ ] Muncul peringatan ganti password + form Manajemen Kasir terbuka → ganti password `superadmin`
- [ ] Login di client dengan akun yang sama
- [ ] Transaksi penjualan di client → stok berkurang, terlihat juga di server
- [ ] Cetak nota dan Laporan (Penjualan & Pembelian)
- [ ] Menu Konfigurasi → **Tes Koneksi** berhasil
- [ ] Backup database dari komputer server

Akun bawaan `superadmin` / `password` wajib diganti passwordnya sebelum dipakai di toko. Aplikasi menampilkan peringatan setiap login selama password masih `password`. Pesan akhir instalasi server juga menyebutkan akun ini (hanya jika passwordnya belum diganti).

## Lokasi file setelah terpasang

| Lokasi | Isi |
|---|---|
| `C:\Program Files\BetterMoney\` | Aplikasi |
| `C:\ProgramData\BetterMoney\koneksi.txt` | Koneksi ke database (bisa diubah lewat menu Konfigurasi) |
| `C:\ProgramData\BetterMoney\config.txt` | Logo & nama toko |
| `C:\Program Files\MariaDB 11.8\` | Database (hanya di server) |

Uninstall aplikasi **tidak** menghapus database maupun file di `C:\ProgramData\BetterMoney\`.

## Jika ada masalah

| Gejala | Yang dicek |
|---|---|
| Error saat compile `.iss` | Kirim pesan error lengkap beserta nomor barisnya |
| `Source file ... does not exist` saat compile | Langkah 1 (build **Release**) atau Langkah 2 (MSI di `installer\redist\`) belum dilakukan |
| Installer: "System POS (Point Of Sale) membutuhkan .NET Framework 4.8" | Pasang [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48) |
| Server: "Pemasangan MariaDB gagal" | Port 3306 dipakai program lain (mis. XAMPP yang sedang jalan). Matikan, atau isi password root XAMPP agar installer memakainya |
| Client: "Server ... tidak merespon" | IP salah, komputer beda jaringan, atau firewall server memblokir port 3306 |
| Client: "Komputer ini tidak diizinkan login" | Jalankan ulang installer di server agar user aplikasi dibuat ulang |

## Update versi MariaDB

1. Cek versi terbaru & checksum: `https://downloads.mariadb.org/rest-api/mariadb/11.8/latest/`
2. Ubah `MariaDBMsi` di `installer\Minimarket.iss`.
3. Ubah `MARIADB_VERSION` dan `MARIADB_SHA256` di `.github\workflows\build-installer.yml`.

## Build otomatis (GitHub Actions)

Jika project ada di GitHub, setiap push ke branch `production` otomatis menjalankan Langkah 1–3 (`.github/workflows/build-installer.yml`). Hasilnya bisa diunduh di tab **Actions** → run terakhir → **Artifacts → SystemPOS-Setup**.
