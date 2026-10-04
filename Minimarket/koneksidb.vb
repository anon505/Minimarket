Imports System.IO
Imports System.Net.Sockets
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
'Fungsi koneksi & persiapan server MySQL. Dipakai aplikasi (cpanel, main) dan installer.
Module koneksidb

    Public Function buatkoneksi(ByVal host As String, ByVal port As String, ByVal user As String, ByVal password As String, ByVal database As String) As MySqlConnectionStringBuilder
        Dim koneksi As New MySqlConnectionStringBuilder()
        koneksi.Server = Trim(host)
        koneksi.Port = CUInt(Val(port))
        koneksi.UserID = Trim(user)
        koneksi.Password = password
        koneksi.Database = Trim(database)
        koneksi.ConnectionTimeout = 5
        Return koneksi
    End Function

    'Cek server bisa dipakai: port TCP terbuka, lalu login MySQL & database ada.
    'Hasil: "" jika berhasil, pesan error (Bahasa Indonesia) jika gagal.
    Public Function cekkoneksi(ByVal koneksi As MySqlConnectionStringBuilder) As String
        Dim gagaltcp As String = cektcp(koneksi.Server, CInt(koneksi.Port))
        If gagaltcp <> "" Then
            Return gagaltcp
        End If

        Try
            'tanpa pooling: koneksi lama di pool bisa membuat password yang sudah salah tetap lolos
            Dim tes As New MySqlConnectionStringBuilder(koneksi.ConnectionString)
            tes.Pooling = False
            Using uji As New MySqlConnection(tes.ConnectionString)
                uji.Open()
            End Using
        Catch ex As MySqlException
            Select Case ex.Number
                Case 1045
                    Return "Username atau password MySQL salah."
                Case 1049
                    Return "Database '" + koneksi.Database + "' belum ada di server."
                Case 1130
                    Return "Komputer ini tidak diizinkan login ke MySQL server dengan user '" + koneksi.UserID + "'. Jalankan setup server untuk membuat user client."
            End Select
            Return "Gagal login ke MySQL: " + ex.Message
        End Try
        Return ""
    End Function

    'Cek port TCP server terbuka (timeout 3 detik). Hasil: "" jika terbuka, pesan error jika tidak.
    Public Function cektcp(ByVal host As String, ByVal port As Integer) As String
        Dim alamat As String = host + ":" + port.ToString
        Using tcp As New TcpClient()
            Try
                Dim proses As IAsyncResult = tcp.BeginConnect(host, port, Nothing, Nothing)
                If Not proses.AsyncWaitHandle.WaitOne(3000) Then
                    Return "Server " + alamat + " tidak merespon. Periksa IP server, kabel/WiFi, dan firewall di komputer server."
                End If
                tcp.EndConnect(proses)
            Catch ex As SocketException
                Return "Server " + alamat + " menolak koneksi. Pastikan MySQL di komputer server sudah berjalan dan port benar."
            End Try
        End Using
        Return ""
    End Function

    'Nama database / user hanya huruf, angka, underscore (dipakai sebagai identifier SQL)
    Public Function namavalid(ByVal nama As String) As Boolean
        Return Regex.IsMatch(nama, "^[A-Za-z0-9_]{1,32}$")
    End Function

    'Siapkan MySQL di komputer server:
    '1. buat database jika belum ada, import filesql jika database masih kosong
    '2. buat/ubah user aplikasi yang boleh login dari komputer lain ('user'@'%')
    'koneksiroot: login root/admin MySQL tanpa database. Hasil: "" jika berhasil, pesan error jika gagal.
    Public Function siapkanserver(ByVal koneksiroot As MySqlConnectionStringBuilder, ByVal database As String, ByVal userapp As String, ByVal passwordapp As String, ByVal filesql As String) As String
        If Not namavalid(database) Then
            Return "Nama database hanya boleh huruf, angka, dan underscore."
        End If
        If Not namavalid(userapp) Then
            Return "Username aplikasi hanya boleh huruf, angka, dan underscore."
        End If
        If passwordapp = "" Then
            Return "Password user aplikasi tidak boleh kosong karena user ini bisa login dari komputer lain."
        End If
        Try
            Using root As New MySqlConnection(koneksiroot.ConnectionString)
                root.Open()
                Call New MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + database + "`", root).ExecuteNonQuery()

                Dim cek As New MySqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema=@db", root)
                cek.Parameters.AddWithValue("@db", database)
                If CInt(cek.ExecuteScalar()) = 0 Then
                    If Not File.Exists(filesql) Then
                        Return "File database " + filesql + " tidak ditemukan."
                    End If
                    root.ChangeDatabase(database)
                    Dim skrip As New MySqlScript(root, File.ReadAllText(filesql))
                    skrip.Execute()
                End If

                'user '%' untuk komputer client, user 'localhost' untuk aplikasi di komputer server
                '(tanpa 'localhost', anonymous user ''@'localhost' bawaan MySQL bisa membuat login ditolak)
                Dim pass As String = "'" + MySqlHelper.EscapeString(passwordapp) + "'"
                For Each host As String In New String() {"%", "localhost"}
                    Dim user As String = "'" + userapp + "'@'" + host + "'"
                    Call New MySqlCommand("CREATE USER IF NOT EXISTS " + user + " IDENTIFIED BY " + pass, root).ExecuteNonQuery()
                    Call New MySqlCommand("ALTER USER " + user + " IDENTIFIED BY " + pass, root).ExecuteNonQuery()
                    Call New MySqlCommand("GRANT ALL PRIVILEGES ON `" + database + "`.* TO " + user, root).ExecuteNonQuery()
                Next
            End Using
        Catch ex As MySqlException
            If ex.Number = 1045 Then
                Return "Username atau password root MySQL salah."
            End If
            Return "Gagal menyiapkan database: " + ex.Message
        End Try
        Return ""
    End Function

    'Agar MySQL menerima koneksi dari komputer lain: nonaktifkan bind-address localhost & skip-networking di my.ini.
    'Hasil: True jika my.ini diubah (MySQL perlu di-restart).
    Public Function izinkanjaringan(ByVal myini As String) As Boolean
        Dim baris As New List(Of String)(File.ReadAllLines(myini))
        Dim diubah As Boolean = False
        Dim bagian As String = ""
        For i As Integer = 0 To baris.Count - 1
            Dim isi As String = baris(i).Trim()
            If isi.StartsWith("[") Then
                bagian = isi.ToLower()
            ElseIf bagian = "[mysqld]" Or bagian = "[server]" Or bagian = "[mariadb]" Then
                If Regex.IsMatch(isi, "^bind[-_]address\s*=\s*""?(127\.0\.0\.1|localhost|::1)""?\s*$", RegexOptions.IgnoreCase) _
                    Or Regex.IsMatch(isi, "^skip[-_]networking\b", RegexOptions.IgnoreCase) Then
                    baris(i) = "# " + baris(i) + "   # dinonaktifkan oleh setup BetterMoney POS"
                    diubah = True
                End If
            End If
        Next
        If diubah Then
            File.Copy(myini, myini + ".bak", True)
            File.WriteAllLines(myini, baris)
        End If
        Return diubah
    End Function

End Module
