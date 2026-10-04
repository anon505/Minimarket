"""Membuat docs/Panduan-Instalasi-Minimarket.pdf (panduan instalasi untuk toko).

Jalankan dari folder project:
    python3 -m venv .venv && .venv/bin/pip install reportlab
    .venv/bin/python docs/buat_panduan.py

Isi panduan mengikuti installer/Minimarket.iss dan kode aplikasi; ubah di sini jika alur instalasi berubah.
Hanya pakai font bawaan PDF (Helvetica/Courier): karakter di luar Latin-1 (mis. panah, kotak centang) tampil sebagai kotak hitam.
"""
import os
import sys
from datetime import date
from reportlab.lib.pagesizes import A4
from reportlab.lib.units import mm
from reportlab.lib import colors
from reportlab.lib.styles import ParagraphStyle
from reportlab.lib.enums import TA_CENTER
from reportlab.platypus import Flowable
from reportlab.platypus import (BaseDocTemplate, PageTemplate, Frame, Paragraph, Spacer, Table,
                                TableStyle, PageBreak, KeepTogether, CondPageBreak, NextPageTemplate)

OUT = sys.argv[1] if len(sys.argv) > 1 else os.path.join(os.path.dirname(os.path.abspath(__file__)), "Panduan-Instalasi-Minimarket.pdf")

UTAMA = colors.HexColor("#00695C")
GELAP = colors.HexColor("#1F2933")
ABU = colors.HexColor("#5F6B76")
GARIS = colors.HexColor("#D5DBE0")
LATAR = colors.HexColor("#F2F6F5")
INFO = colors.HexColor("#E6F2F0")
AWAS = colors.HexColor("#FDF1E4")
AWAS_GARIS = colors.HexColor("#E08A2B")

def gaya(nama, **k):
    dasar = dict(fontName="Helvetica", fontSize=10, leading=14.5, textColor=GELAP)
    dasar.update(k)
    return ParagraphStyle(nama, **dasar)

BODY = gaya("body", spaceAfter=6)
KECIL = gaya("kecil", fontSize=8.5, leading=11.5, textColor=ABU)
H1 = gaya("h1", fontName="Helvetica-Bold", fontSize=17, leading=21, textColor=UTAMA, spaceBefore=14, spaceAfter=10)
H2 = gaya("h2", fontName="Helvetica-Bold", fontSize=12.5, leading=16, spaceBefore=12, spaceAfter=6)
SEL = gaya("sel", fontSize=9.2, leading=12.5)
SEL_B = gaya("selb", fontName="Helvetica-Bold", fontSize=9.2, leading=12.5)
SEL_H = gaya("selh", fontName="Helvetica-Bold", fontSize=9.2, leading=12.5, textColor=colors.white)
LANGKAH = gaya("langkah", leftIndent=0)
NOMOR = gaya("nomor", fontName="Helvetica-Bold", textColor=UTAMA, alignment=TA_CENTER, fontSize=11, leading=14.5)

class Centang(Flowable):
    """kotak kosong untuk dicentang manual"""
    def wrap(self, aw, ah):
        return 9, 10
    def draw(self):
        self.canv.setStrokeColor(GELAP)
        self.canv.setLineWidth(0.8)
        self.canv.rect(0, 0.5, 8.5, 8.5, stroke=1, fill=0)

def p(teks, st=BODY):
    return Paragraph(teks, st)

def kode(teks):
    return '<font name="Courier" size="9.2">%s</font>' % teks

def tabel(baris, lebar, kepala=True):
    data = []
    for i, r in enumerate(baris):
        st = SEL_H if (kepala and i == 0) else SEL
        data.append([c if not isinstance(c, str) else Paragraph(c, st) for c in r])
    t = Table(data, colWidths=lebar, repeatRows=1 if kepala else 0)
    gaya_t = [
        ("VALIGN", (0, 0), (-1, -1), "TOP"),
        ("GRID", (0, 0), (-1, -1), 0.5, GARIS),
        ("TOPPADDING", (0, 0), (-1, -1), 5),
        ("BOTTOMPADDING", (0, 0), (-1, -1), 5),
        ("LEFTPADDING", (0, 0), (-1, -1), 6),
        ("RIGHTPADDING", (0, 0), (-1, -1), 6),
    ]
    if kepala:
        gaya_t += [("BACKGROUND", (0, 0), (-1, 0), UTAMA)]
        for i in range(2, len(data), 2):
            gaya_t.append(("BACKGROUND", (0, i), (-1, i), LATAR))
    t.setStyle(TableStyle(gaya_t))
    return t

def kotak(judul, isi, latar=INFO, garis=UTAMA):
    konten = [Paragraph("<b>%s</b>" % judul, SEL)] if judul else []
    konten += [Paragraph(x, SEL) for x in isi]
    t = Table([[konten]], colWidths=[170 * mm])
    t.setStyle(TableStyle([
        ("BACKGROUND", (0, 0), (-1, -1), latar),
        ("LINEBEFORE", (0, 0), (0, -1), 3, garis),
        ("TOPPADDING", (0, 0), (-1, -1), 7),
        ("BOTTOMPADDING", (0, 0), (-1, -1), 7),
        ("LEFTPADDING", (0, 0), (-1, -1), 10),
        ("RIGHTPADDING", (0, 0), (-1, -1), 10),
    ]))
    return KeepTogether([t, Spacer(1, 8)])

def peringatan(judul, isi):
    return kotak(judul, isi, AWAS, AWAS_GARIS)

def langkah(daftar):
    """daftar: list of str (paragraf HTML) -> tabel bernomor"""
    data = []
    for i, teks in enumerate(daftar, 1):
        isi = teks if isinstance(teks, list) else [teks]
        data.append([Paragraph(str(i), NOMOR), [Paragraph(x, LANGKAH) for x in isi]])
    t = Table(data, colWidths=[8 * mm, 162 * mm])
    gaya_t = [("VALIGN", (0, 0), (-1, -1), "TOP"),
              ("LEFTPADDING", (0, 0), (0, -1), 0),
              ("LEFTPADDING", (1, 0), (1, -1), 8),
              ("TOPPADDING", (0, 0), (-1, -1), 3),
              ("BOTTOMPADDING", (0, 0), (-1, -1), 5)]
    for i in range(len(data) - 1):
        gaya_t.append(("LINEBELOW", (0, i), (-1, i), 0.4, GARIS))
    t.setStyle(TableStyle(gaya_t))
    return t

# ---------- halaman ----------
def sampul(c, doc):
    w, h = A4
    c.saveState()
    c.setFillColor(UTAMA)
    c.rect(0, h - 120 * mm, w, 120 * mm, fill=1, stroke=0)
    c.setFillColor(colors.white)
    c.setFont("Helvetica", 12)
    c.drawString(20 * mm, h - 40 * mm, "System POS by BetterMoney")
    c.setFont("Helvetica-Bold", 30)
    c.drawString(20 * mm, h - 62 * mm, "Panduan Instalasi")
    c.drawString(20 * mm, h - 76 * mm, "Minimarket")
    c.setFont("Helvetica", 12.5)
    c.drawString(20 * mm, h - 94 * mm, "Kebutuhan sistem, pemasangan Server & Client, dan pengaturan awal")
    c.setFillColor(ABU)
    c.setFont("Helvetica", 9.5)
    c.drawString(20 * mm, 22 * mm, "BetterMoney  \u00b7  Versi dokumen: %s" % date.today().strftime("%d-%m-%Y"))
    c.restoreState()

def halaman(c, doc):
    w, h = A4
    c.saveState()
    c.setStrokeColor(GARIS)
    c.setLineWidth(0.6)
    c.line(20 * mm, h - 14 * mm, w - 20 * mm, h - 14 * mm)
    c.setFont("Helvetica", 8.5)
    c.setFillColor(ABU)
    c.drawString(20 * mm, h - 11.5 * mm, "Panduan Instalasi Minimarket")
    c.drawRightString(w - 20 * mm, h - 11.5 * mm, "System POS by BetterMoney")
    c.drawRightString(w - 20 * mm, 11 * mm, "Halaman %d" % (doc.page - 1))
    c.restoreState()

doc = BaseDocTemplate(OUT, pagesize=A4, leftMargin=20 * mm, rightMargin=20 * mm, topMargin=20 * mm,
                      bottomMargin=18 * mm, title="Panduan Instalasi Minimarket", author="BetterMoney",
                      subject="Kebutuhan sistem dan cara instalasi Server & Client")
frame = Frame(doc.leftMargin, doc.bottomMargin, doc.width, doc.height, id="isi")
doc.addPageTemplates([PageTemplate(id="sampul", frames=[frame], onPage=sampul),
                      PageTemplate(id="isi", frames=[frame], onPage=halaman)])

s = []
s += [NextPageTemplate("isi"), Spacer(1, 128 * mm)]
s += [p("<b>Isi panduan</b>", gaya("x", fontSize=11, spaceAfter=6))]
for i, judul in enumerate(["Gambaran sistem", "Kebutuhan komputer", "Persiapan sebelum instalasi",
                           "Instalasi komputer Server", "Instalasi komputer Kasir (Client)",
                           "Pengaturan awal setelah instalasi", "Pemeliharaan: backup, update, uninstall",
                           "Mengatasi masalah", "Lembar catatan instalasi"], 1):
    s.append(p("%d.&nbsp;&nbsp;%s" % (i, judul), gaya("toc%d" % i, leftIndent=4, spaceAfter=2)))
s.append(PageBreak())

# 1
s.append(p("1. Gambaran sistem", H1))
s.append(p("Minimarket adalah aplikasi kasir (Point-of-Sale) dan manajemen stok untuk Windows. "
           "Semua data (barang, stok, transaksi, akun kasir) disimpan di <b>satu database pusat</b> "
           "di komputer <b>Server</b>. Komputer kasir (<b>Client</b>) terhubung ke database itu lewat "
           "jaringan lokal (LAN/WiFi), sehingga stok dan laporan selalu sama di semua komputer."))
s.append(tabel([
    ["Peran", "Jumlah", "Yang dipasang"],
    ["<b>Server</b>", "1 komputer", "Database MariaDB + aplikasi Minimarket. Komputer ini boleh sekaligus dipakai untuk kasir."],
    ["<b>Client</b>", "0 atau lebih", "Aplikasi Minimarket saja, terhubung ke database di Server."],
], [28 * mm, 28 * mm, 114 * mm]))
s.append(Spacer(1, 8))
s.append(kotak("Satu file installer untuk semua komputer", [
    "File <b>MinimarketSetup-x.x.x.exe</b> (sekitar 90 MB) dipakai untuk Server maupun Client. "
    "Jenisnya dipilih di awal instalasi. Pasang <b>Server lebih dulu</b>, baru Client.",
    "Kalau toko hanya punya satu komputer, cukup pasang sebagai Server."]))

# 2
s.append(p("2. Kebutuhan komputer", H1))
s.append(p("Sistem operasi & perangkat", H2))
s.append(tabel([
    ["", "Server", "Client (kasir)"],
    ["<b>Windows</b>", "Windows 10 atau 11 <b>64-bit</b> (wajib 64-bit). Windows Server 2016 atau lebih baru juga bisa.",
     "Windows 10 atau 11, 32-bit atau 64-bit."],
    ["<b>Prosesor</b>", "2 core atau lebih", "2 core"],
    ["<b>RAM</b>", "4 GB atau lebih", "2 GB atau lebih"],
    ["<b>Ruang disk</b>", "Minimal 2 GB kosong (aplikasi, database, backup)", "Minimal 500 MB kosong"],
    ["<b>Hak akses</b>", "Akun Windows Administrator saat instalasi", "Akun Windows Administrator saat instalasi"],
    ["<b>Printer</b>", "Opsional, untuk nota & laporan", "Opsional, untuk nota"],
], [30 * mm, 70 * mm, 70 * mm]))
s.append(p("Angka prosesor, RAM, dan disk adalah rekomendasi, bukan batas yang diperiksa installer. "
           "Yang diperiksa installer: Windows 64-bit untuk Server dan .NET Framework 4.8 untuk semua komputer.", KECIL))

s.append(p("Program & library", H2))
s.append(tabel([
    ["Komponen", "Server", "Client", "Keterangan"],
    ["<b>.NET Framework 4.8</b>", "Wajib", "Wajib",
     "Sudah bawaan Windows 10 (versi 1903 ke atas) dan Windows 11. Jika belum ada, installer berhenti dan "
     "menampilkan alamat unduhannya: dotnet.microsoft.com/download/dotnet-framework/net48"],
    ["<b>MariaDB 11.8 LTS</b> (database)", "Otomatis", "Tidak perlu",
     "Ikut di dalam installer dan dipasang otomatis. Jika MySQL/MariaDB/XAMPP sudah berjalan di komputer Server, "
     "installer memakai yang sudah ada."],
    ["<b>MySQL Connector (MySql.Data 8.3)</b>", "Otomatis", "Otomatis", "Ikut di folder aplikasi, tidak dipasang terpisah."],
    ["<b>Microsoft ReportViewer 10</b> (nota & laporan)", "Otomatis", "Otomatis", "Ikut di folder aplikasi, tidak dipasang terpisah."],
    ["<b>Visual Basic PowerPacks</b>", "Otomatis", "Otomatis", "Ikut di folder aplikasi."],
    ["<b>XAMPP, ODBC driver, DSN</b>", "Tidak perlu", "Tidak perlu", "Versi aplikasi ini tidak memakainya lagi."],
], [44 * mm, 20 * mm, 20 * mm, 86 * mm]))
s.append(Spacer(1, 4))
s.append(p("Jaringan", H2))
s.append(tabel([
    ["Kebutuhan", "Keterangan"],
    ["Satu jaringan lokal", "Server dan semua Client terhubung ke router/switch/WiFi yang sama."],
    ["Port TCP 3306", "Port database di Server. Installer Server otomatis membuka port ini di Windows Firewall "
                      "(aturan bernama <i>Minimarket Database</i>). Jika memakai antivirus dengan firewall sendiri, buka port ini di sana."],
    ["IP Server tetap", "Sangat disarankan. Jika IP Server berubah, semua Client tidak bisa terhubung (lihat bagian 3)."],
    ["Internet", "Tidak diperlukan untuk instalasi maupun pemakaian sehari-hari."],
], [40 * mm, 130 * mm]))

# 3
s.append(CondPageBreak(90 * mm))
s.append(p("3. Persiapan sebelum instalasi", H1))
s.append(langkah([
    "<b>Siapkan file installer</b> <font name='Courier'>MinimarketSetup-x.x.x.exe</font> di flashdisk atau folder bersama.",
    "<b>Tentukan komputer Server.</b> Pilih komputer yang paling sering menyala selama jam buka toko. "
    "Client hanya bisa bertransaksi jika komputer Server menyala.",
    ["<b>Buat IP Server tetap.</b> Pilih salah satu:",
     "&bull; Di pengaturan router: buat <i>DHCP reservation</i> / <i>IP binding</i> untuk komputer Server (cara paling aman).",
     "&bull; Di Windows komputer Server: Settings &gt; Network &amp; Internet &gt; (Ethernet/WiFi) &gt; IP assignment &gt; Edit &gt; "
     "Manual, isi IP di luar rentang DHCP router, misalnya 192.168.1.10."],
    "<b>Tutup program database lain</b> yang tidak dipakai (misalnya XAMPP) supaya port 3306 kosong. "
    "Jika database itu memang ingin dipakai, siapkan password root-nya.",
    "<b>Siapkan dua password</b> dan catat di Lembar Catatan (bagian 9): password <b>root</b> database "
    "(untuk administrator, hanya dipakai di Server) dan password <b>akun aplikasi</b> (dipakai semua komputer).",
]))
s.append(Spacer(1, 6))
s.append(peringatan("Ketentuan password", [
    "Password root tidak boleh kosong dan tidak boleh mengandung tanda kutip ganda (\").",
    "Username aplikasi hanya boleh huruf, angka, dan garis bawah (_), maksimal 32 karakter.",
    "Password aplikasi tidak boleh kosong, karena akun ini bisa login dari komputer lain di jaringan."]))
s.append(kotak("Peringatan Windows SmartScreen", [
    "Jika muncul layar biru <i>Windows protected your PC</i> saat menjalankan installer, klik <b>More info</b> "
    "lalu <b>Run anyway</b>. Pastikan file installer berasal dari BetterMoney."]))

# 4
s.append(p("4. Instalasi komputer Server", H1))
s.append(langkah([
    "Klik kanan file installer &gt; <b>Run as administrator</b>. Klik <b>Next</b> di halaman pembuka.",
    "<b>Jenis Instalasi:</b> pilih <b>Server - komputer pusat</b>, klik Next.",
    ["<b>Database Server:</b> isi <b>Port database</b> (biarkan 3306), <b>Password root</b>, dan ulangi password. Klik Next.",
     "Installer memeriksa komputer ini:",
     "&bull; Belum ada database di port itu &gt; MariaDB akan dipasang dengan password tadi.",
     "&bull; Sudah ada MySQL/MariaDB dan password root benar &gt; muncul pesan bahwa database yang ada akan dipakai.",
     "&bull; Sudah ada MySQL/MariaDB tetapi password salah &gt; isi password root yang benar (lihat bagian 8)."],
    ["<b>Akun Aplikasi:</b> isi <b>Username aplikasi</b> (bawaan: minimarket), <b>Password aplikasi</b>, "
     "ulangi password, dan <b>Nama toko</b>. Klik Next.",
     "Username dan password ini nanti diisi di setiap komputer kasir. <b>Catat.</b>"],
    "Pilih folder instalasi (bawaan <font name='Courier'>C:\\Program Files\\Minimarket</font>) dan centang "
    "<i>Buat shortcut di Desktop</i> bila perlu. Klik <b>Install</b>.",
    "Tunggu proses <b>Memasang Database</b>. Bisa memakan beberapa menit.",
    ["Di akhir instalasi muncul pesan <b>Server siap dipakai</b> berisi:",
     "&bull; <b>IP komputer server ini</b> &gt; <b>catat</b>, dipakai saat memasang Client.",
     "&bull; Akun login pertama: <b>superadmin / password</b>.",
     "&bull; Kadang ada catatan untuk <b>restart MySQL/MariaDB</b> (hanya jika memakai MySQL lama yang pengaturannya diubah). "
     "Jika ada, restart komputer Server sebelum memasang Client."],
    "Klik <b>Finish</b>. Aplikasi bisa langsung dijalankan.",
]))
s.append(Spacer(1, 6))
s.append(kotak("Yang dikerjakan installer Server secara otomatis", [
    "&bull; Memasang MariaDB 11.8 sebagai service Windows bernama <i>MariaDB</i> (jalan otomatis saat komputer menyala).",
    "&bull; Membuat database <b>minimarket</b> berisi data awal (contoh supplier, satuan, barang, dan akun superadmin).",
    "&bull; Membuat akun aplikasi yang boleh login dari komputer lain di jaringan. Akun root hanya bisa login dari komputer Server.",
    "&bull; Membuka port database di Windows Firewall.",
    "&bull; Menyimpan pengaturan koneksi, nama toko, dan logo (dibuat otomatis dari nama toko)."]))

# 5
s.append(CondPageBreak(120 * mm))
s.append(p("5. Instalasi komputer Kasir (Client)", H1))
s.append(p("Pastikan komputer Server <b>menyala</b> dan berada di jaringan yang sama sebelum mulai."))
s.append(langkah([
    "Klik kanan file installer yang sama &gt; <b>Run as administrator</b>. Klik Next.",
    "<b>Jenis Instalasi:</b> pilih <b>Client - komputer kasir</b>, klik Next.",
    ["<b>Koneksi ke Server:</b> isi",
     "&bull; <b>IP server</b>: IP dari pesan akhir instalasi Server, misalnya 192.168.1.10",
     "&bull; <b>Port database</b>: 3306 (sama dengan Server)",
     "&bull; <b>Username</b> dan <b>Password aplikasi</b>: yang dibuat saat instalasi Server",
     "&bull; <b>Nama toko</b>: ditampilkan di nota dan laporan komputer ini"],
    "Klik <b>Next</b>. Koneksi ke Server langsung dites. Jika gagal, pesan menjelaskan penyebabnya "
    "(lihat bagian 8) dan halaman tidak berpindah sampai data benar.",
    "Lanjutkan <b>Install</b> lalu <b>Finish</b>.",
    "Ulangi langkah ini di setiap komputer kasir.",
]))

# 6
s.append(PageBreak())
s.append(p("6. Pengaturan awal setelah instalasi", H1))
s.append(p("Login pertama", H2))
s.append(langkah([
    "Jalankan <b>Minimarket</b> dari Desktop atau Start Menu.",
    "Di jendela Login pilih Jabatan <b>Administrator</b>, User name <b>superadmin</b>, Password <b>password</b>.",
    "Karena password masih bawaan, aplikasi menampilkan peringatan dan membuka form <b>Kasir</b>. "
    "Ganti password superadmin di sana.",
]))
s.append(Spacer(1, 4))
s.append(peringatan("Wajib ganti password superadmin", [
    "Password bawaan <b>password</b> diketahui semua orang yang membaca panduan ini. Selama belum diganti, "
    "peringatan akan muncul setiap login."]))
s.append(p("Membuat akun kasir", H2))
s.append(langkah([
    "Login sebagai Administrator, buka menu <b>Kasir</b>.",
    "Tambah user baru dengan jabatan <b>Kasir</b>. User baru berstatus <b>Tidak Aktif</b>.",
    "Ubah statusnya menjadi <b>Aktif</b> supaya user itu bisa login.",
]))
s.append(p("Akun Kasir hanya bisa membuka menu transaksi dan melihat data. Menu Satuan, Kasir, Supplier, dan "
           "Konfigurasi hanya untuk Administrator.", KECIL))
s.append(p("Logo dan nama toko", H2))
s.append(p("Menu <b>Konfigurasi</b> (Administrator) di setiap komputer:"))
s.append(tabel([
    ["Tombol", "Fungsi"],
    ["<b>Buat Logo</b>", "Membuat logo dari nama toko (teks putih di latar berwarna)."],
    ["<b>Upload</b>", "Memakai gambar logo sendiri (JPG, PNG, atau BMP)."],
    ["<b>Simpan Konfigurasi</b>", "Menyimpan logo dan nama toko. Logo buatan otomatis ikut diperbarui jika nama toko diganti."],
    ["<b>Tes Koneksi</b> / <b>Tes dan Simpan Koneksi</b>", "Memeriksa dan menyimpan koneksi ke database (IP server, port, user, password)."],
], [55 * mm, 115 * mm]))
s.append(Spacer(1, 6))
s.append(p("Daftar periksa", H2))
cek = ["Login superadmin di Server berhasil dan password sudah diganti",
       "Login dengan akun yang sama di setiap Client berhasil",
       "Transaksi Penjualan di Client mengurangi stok, dan perubahan stok terlihat di Server",
       "Cetak nota penjualan berhasil",
       "Menu Laporan (Penjualan dan Pembelian) tampil",
       "Menu Konfigurasi &gt; Tes Koneksi berhasil di setiap komputer",
       "Backup database dari komputer Server berhasil"]
s.append(tabel([[Centang(), c] for c in cek], [8 * mm, 162 * mm], kepala=False))

# 7
s.append(p("7. Pemeliharaan: backup, update, uninstall", H1))
s.append(tabel([
    ["Kegiatan", "Cara"],
    ["<b>Backup database</b>", "Di komputer <b>Server</b>: menu Konfigurasi &gt; <b>Back Up Database</b>, simpan file .sql. "
                               "Lakukan rutin (misalnya tiap hari tutup toko) dan simpan salinannya di flashdisk atau penyimpanan lain. "
                               "Backup hanya bisa dari komputer Server, karena program backup MariaDB ada di sana."],
    ["<b>Restore database</b>", "Di komputer Server: menu Konfigurasi, isi USERNAME <b>root</b> dan password root, lalu "
                                "<b>Re/Store Database</b> dan pilih file .sql. Restore menimpa data yang ada. "
                                "Setelah selesai, kembalikan isian ke akun aplikasi; jangan simpan koneksi dengan akun root."],
    ["<b>Update aplikasi</b>", "Jalankan installer versi baru di setiap komputer dengan jenis yang sama (Server/Client). "
                               "Data, pengaturan koneksi, dan logo pilihan sendiri tetap dipakai."],
    ["<b>Uninstall</b>", "Settings &gt; Apps &gt; Minimarket &gt; Uninstall. Database MariaDB dan folder "
                         "<font name='Courier'>C:\\ProgramData\\Minimarket</font> <b>tidak</b> ikut terhapus."],
], [36 * mm, 134 * mm]))
s.append(Spacer(1, 6))
s.append(p("Lokasi file", H2))
s.append(tabel([
    ["Lokasi", "Isi"],
    [kode("C:\\Program Files\\Minimarket\\"), "Aplikasi"],
    [kode("C:\\ProgramData\\Minimarket\\koneksi.txt"), "Pengaturan koneksi database (diubah lewat menu Konfigurasi)"],
    [kode("C:\\ProgramData\\Minimarket\\config.txt"), "Lokasi logo dan nama toko"],
    [kode("C:\\ProgramData\\Minimarket\\logotoko-*.png"), "Logo buatan dari nama toko"],
    [kode("C:\\Program Files\\MariaDB 11.8\\"), "Program database (hanya di Server)"],
], [95 * mm, 75 * mm]))

# 8
s.append(PageBreak())
s.append(p("8. Mengatasi masalah", H1))
s.append(tabel([
    ["Pesan / gejala", "Penyebab", "Yang dilakukan"],
    ["Minimarket membutuhkan .NET Framework 4.8", "Windows belum punya .NET 4.8",
     "Pasang dari dotnet.microsoft.com/download/dotnet-framework/net48, lalu jalankan installer lagi."],
    ["Server membutuhkan Windows 64-bit", "Komputer memakai Windows 32-bit", "Pilih komputer lain sebagai Server. Komputer ini tetap bisa jadi Client."],
    ["Sudah ada MySQL/MariaDB di port 3306, tetapi login root gagal", "Ada database lain berjalan (misalnya XAMPP, MySQL80, atau MariaDB dari instalasi sebelumnya)",
     "Isi password root database itu, atau hentikan/uninstall database itu lalu klik Next lagi. "
     "Cek pemakai port: " + kode("netstat -ano | findstr :3306")],
    ["Service MariaDB sudah terpasang tetapi tidak berjalan", "Service MariaDB berhenti",
     "Buka services.msc, jalankan service MariaDB, lalu klik Next lagi."],
    ["Pemasangan MariaDB gagal", "Port dipakai program lain, atau instalasi diblokir antivirus", "Kosongkan port 3306, nonaktifkan sementara antivirus, jalankan installer lagi."],
    ["Client: Server ... tidak merespon", "IP salah, beda jaringan, Server mati, atau firewall memblokir",
     "Cek IP Server (" + kode("ipconfig") + " di Server), pastikan Server menyala dan satu jaringan, buka port 3306 di firewall/antivirus Server."],
    ["Client: Server ... menolak koneksi", "Database di Server tidak berjalan atau port salah", "Jalankan service MariaDB di Server, samakan port."],
    ["Username atau password MySQL salah", "Akun aplikasi salah ketik", "Isi username dan password aplikasi yang dibuat saat instalasi Server."],
    ["Komputer ini tidak diizinkan login ke MySQL server", "Akun aplikasi belum dibuat untuk jaringan",
     "Jalankan ulang installer Server di komputer Server dengan akun aplikasi yang sama."],
    ["Semua Client tiba-tiba tidak bisa terhubung", "IP Server berubah",
     "Buat IP Server tetap (bagian 3), lalu di setiap Client ubah SERVER di menu Konfigurasi &gt; Tes dan Simpan Koneksi."],
    ["Aplikasi menampilkan form Konfigurasi saat dibuka", "Koneksi ke database gagal", "Baca pesan yang muncul, perbaiki data koneksi, klik Tes Koneksi lalu Simpan."],
], [48 * mm, 50 * mm, 72 * mm]))

# 9
s.append(PageBreak())
s.append(p("9. Lembar catatan instalasi", H1))
s.append(p("Isi lalu simpan lembar ini di tempat aman. Jangan ditempel di dekat komputer kasir.", KECIL))
s.append(Spacer(1, 4))
isian = [["Nama toko", ""], ["Tanggal instalasi", ""], ["Nama / lokasi komputer Server", ""],
         ["IP Server", ""], ["Port database", "3306"], ["Password root database", ""],
         ["Username aplikasi", "minimarket"], ["Password aplikasi", ""],
         ["Password superadmin (baru)", ""], ["Lokasi penyimpanan backup", ""]]
t = Table([[Paragraph(a, SEL_B), Paragraph(b, SEL)] for a, b in isian], colWidths=[65 * mm, 105 * mm],
          rowHeights=[11 * mm] * len(isian))
t.setStyle(TableStyle([("GRID", (0, 0), (-1, -1), 0.5, GARIS), ("VALIGN", (0, 0), (-1, -1), "MIDDLE"),
                       ("BACKGROUND", (0, 0), (0, -1), LATAR), ("LEFTPADDING", (0, 0), (-1, -1), 8)]))
s.append(t)
s.append(Spacer(1, 10))
s.append(p("Komputer Client", H2))
klien = [["No", "Nama / lokasi komputer", "Tanggal pasang", "Tes koneksi"]] + [[str(i), "", "", Centang()] for i in range(1, 7)]
t = Table([[Paragraph(c, SEL_H if r == 0 else SEL) if isinstance(c, str) else c for c in row] for r, row in enumerate(klien)],
          colWidths=[12 * mm, 88 * mm, 40 * mm, 30 * mm], rowHeights=[None] + [10 * mm] * 6)
t.setStyle(TableStyle([("GRID", (0, 0), (-1, -1), 0.5, GARIS), ("BACKGROUND", (0, 0), (-1, 0), UTAMA),
                       ("VALIGN", (0, 0), (-1, -1), "MIDDLE")]))
s.append(t)

doc.build(s)
print("ok", OUT)
