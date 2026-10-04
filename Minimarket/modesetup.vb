Imports System.IO
Imports MySql.Data.MySqlClient
'Mode setup yang dipanggil installer: Minimarket.exe <mode> <file.ini>
'file.ini berisi baris key=value (termasuk password), langsung dihapus setelah dibaca.
'Pesan hasil ditulis ke <file.ini>.hasil, kode hasil = exit code proses.
Module modesetup
    Public Const SUKSES As Integer = 0
    Public Const GAGAL As Integer = 1
    Public Const TIDAKADASERVER As Integer = 2

    Public Function bacaini(ByVal fileini As String) As Dictionary(Of String, String)
        Dim nilai As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        For Each baris As String In File.ReadAllLines(fileini)
            Dim posisi As Integer = baris.IndexOf("="c)
            If posisi > 0 Then
                nilai(baris.Substring(0, posisi).Trim()) = baris.Substring(posisi + 1)
            End If
        Next
        Return nilai
    End Function

    Private Function ambil(ByVal nilai As Dictionary(Of String, String), ByVal kunci As String, Optional ByVal bawaan As String = "") As String
        If nilai.ContainsKey(kunci) Then
            Return nilai(kunci)
        End If
        Return bawaan
    End Function

    Public Function jalankanmode(ByVal mode As String, ByVal fileini As String, ByVal folderdata As String) As Integer
        Dim pesan As String = ""
        Dim kode As Integer = GAGAL
        Try
            Dim nilai As Dictionary(Of String, String) = bacaini(fileini)
            File.Delete(fileini)
            Select Case mode.ToLower()
                Case "--cek-mysql"
                    kode = cekmysql(nilai, pesan)
                Case "--setup-server"
                    kode = setupserver(nilai, folderdata, pesan)
                Case "--setup-client"
                    kode = setupclient(nilai, folderdata, pesan)
                Case Else
                    pesan = "Mode tidak dikenal: " + mode
            End Select
        Catch ex As Exception
            kode = GAGAL
            pesan = ex.Message
        End Try
        File.WriteAllText(fileini + ".hasil", pesan)
        Return kode
    End Function

    'key: host, port, user, password, database (boleh kosong)
    'SUKSES = login berhasil, TIDAKADASERVER = port tertutup (belum ada MySQL), GAGAL = MySQL ada tapi login gagal
    Public Function cekmysql(ByVal nilai As Dictionary(Of String, String), ByRef pesan As String) As Integer
        Dim koneksi As MySqlConnectionStringBuilder = buatkoneksi(ambil(nilai, "host", "localhost"), ambil(nilai, "port", "3306"), ambil(nilai, "user"), ambil(nilai, "password"), ambil(nilai, "database"))
        pesan = cektcp(koneksi.Server, CInt(koneksi.Port))
        If pesan <> "" Then
            Return TIDAKADASERVER
        End If
        pesan = cekkoneksi(koneksi)
        Return If(pesan = "", SUKSES, GAGAL)
    End Function

    'key: port, rootpassword, database, appuser, apppassword, namatoko, sqlfile, logo
    Public Function setupserver(ByVal nilai As Dictionary(Of String, String), ByVal folderdata As String, ByRef pesan As String) As Integer
        Dim port As String = ambil(nilai, "port", "3306")
        Dim database As String = ambil(nilai, "database", "minimarket")
        Dim appuser As String = ambil(nilai, "appuser")
        Dim apppassword As String = ambil(nilai, "apppassword")
        Dim root As MySqlConnectionStringBuilder = buatkoneksi("localhost", port, "root", ambil(nilai, "rootpassword"), "")

        'service MariaDB yang baru dipasang bisa butuh beberapa detik sampai siap
        Dim batas As Date = Now.AddSeconds(60)
        While cektcp("localhost", CInt(Val(port))) <> "" And Now < batas
            Threading.Thread.Sleep(2000)
        End While

        pesan = siapkanserver(root, database, appuser, apppassword, ambil(nilai, "sqlfile"))
        If pesan <> "" Then
            Return GAGAL
        End If
        Dim catatan As String = aturjaringan(root)
        Call tuliskonfigurasi(folderdata, buatkoneksi("localhost", port, appuser, apppassword, database), ambil(nilai, "namatoko"), ambil(nilai, "logo"))
        pesan = "IP komputer server ini: " + ipkomputer() + vbCrLf + "Isi IP ini saat memasang aplikasi di komputer kasir (client)."
        If catatan <> "" Then
            pesan = pesan + vbCrLf + vbCrLf + catatan
        End If
        Return SUKSES
    End Function

    'Alamat IPv4 jaringan lokal komputer ini (untuk diisi di client)
    Public Function ipkomputer() As String
        Dim daftar As New List(Of String)
        For Each alamat As Net.IPAddress In Net.Dns.GetHostAddresses(Net.Dns.GetHostName())
            If alamat.AddressFamily = Net.Sockets.AddressFamily.InterNetwork AndAlso Not Net.IPAddress.IsLoopback(alamat) Then
                daftar.Add(alamat.ToString())
            End If
        Next
        If daftar.Count = 0 Then
            Return "(tidak terdeteksi, cek dengan perintah ipconfig)"
        End If
        Return String.Join(" / ", daftar)
    End Function

    'key: host, port, database, appuser, apppassword, namatoko, logo
    Public Function setupclient(ByVal nilai As Dictionary(Of String, String), ByVal folderdata As String, ByRef pesan As String) As Integer
        Dim koneksi As MySqlConnectionStringBuilder = buatkoneksi(ambil(nilai, "host"), ambil(nilai, "port", "3306"), ambil(nilai, "appuser"), ambil(nilai, "apppassword"), ambil(nilai, "database", "minimarket"))
        pesan = cekkoneksi(koneksi)
        If pesan <> "" Then
            Return GAGAL
        End If
        Call tuliskonfigurasi(folderdata, koneksi, ambil(nilai, "namatoko"), ambil(nilai, "logo"))
        Return SUKSES
    End Function

    'Tulis koneksi.txt & config.txt (format sama dengan cpanel). Logo yang sudah diatur sebelumnya dipertahankan.
    Public Sub tuliskonfigurasi(ByVal folderdata As String, ByVal koneksi As MySqlConnectionStringBuilder, ByVal namatoko As String, ByVal logo As String)
        Directory.CreateDirectory(folderdata)
        File.WriteAllText(Path.Combine(folderdata, "koneksi.txt"), koneksi.ConnectionString)
        Dim fileconfig As String = Path.Combine(folderdata, "config.txt")
        If File.Exists(fileconfig) Then
            Dim baris() As String = File.ReadAllLines(fileconfig)
            If baris.Length > 0 Then
                Dim logolama As String = baris(0).Replace("logo=", "").Replace(";", "")
                If File.Exists(logolama) Then
                    logo = logolama
                End If
            End If
        End If
        File.WriteAllLines(fileconfig, New String() {"logo=" + logo + ";", "toko=" + namatoko})
    End Sub

    'MySQL yang sudah terpasang sebelumnya (mis. XAMPP) bisa dibatasi hanya untuk localhost lewat my.ini.
    'Hasil: catatan untuk user, "" jika tidak ada yang perlu dilakukan.
    Public Function aturjaringan(ByVal root As MySqlConnectionStringBuilder) As String
        Dim datadir As String = ""
        Dim basedir As String = ""
        Using koneksi As New MySqlConnection(root.ConnectionString)
            koneksi.Open()
            Using baca As MySqlDataReader = New MySqlCommand("SELECT @@datadir, @@basedir", koneksi).ExecuteReader()
                baca.Read()
                datadir = baca.GetString(0)
                basedir = baca.GetString(1)
            End Using
        End Using
        For Each myini As String In New String() {Path.Combine(datadir, "my.ini"), Path.Combine(basedir, "my.ini"), Path.Combine(basedir, "bin", "my.ini")}
            If File.Exists(myini) AndAlso izinkanjaringan(myini) Then
                Return "Pengaturan " + myini + " diubah agar database bisa diakses komputer kasir. Restart MySQL/MariaDB (atau restart komputer) sebelum memakai komputer client."
            End If
        Next
        Return ""
    End Function
End Module
