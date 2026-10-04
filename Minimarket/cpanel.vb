Imports System.IO
Imports MySql.Data.MySqlClient
Public Class cpanel

    Private Function koneksiform() As MySqlConnectionStringBuilder
        Return buatkoneksi(txthost.Text, txtport.Text, txtuser.Text, txtpass.Text, txtdb.Text)
    End Function

    Private Function isianvalid() As Boolean
        If IsValidIP(Trim(txthost.Text)) = False Then
            MsgBox("IP Address tidak valid", MsgBoxStyle.OkOnly)
            txthost.Focus()
        ElseIf txtuser.Text = "" Then
            MsgBox("Kolom text user masih kosong", MsgBoxStyle.OkOnly)
            txtuser.Focus()
        ElseIf Not IsNumeric(txtport.Text) Then
            MsgBox("Kolom text port harus angka", MsgBoxStyle.OkOnly)
            txtport.Focus()
        Else
            Return True
        End If
        Return False
    End Function

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If isianvalid() Then
            File.WriteAllText(lokasifile("koneksi.txt"), koneksiform().ConnectionString)
            Call main.konekbuka()
        End If
    End Sub
    Function IsValidIP(ByVal ipAddress As String) As Boolean
        Return ipAddress = "localhost" Or System.Text.RegularExpressions.Regex.IsMatch(ipAddress, _
            "^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$")
    End Function
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthost.TextChanged

    End Sub

    Private Sub cpanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim filekoneksi As String = lokasifile("koneksi.txt")
            If File.Exists(filekoneksi) = True Then
                Dim koneksi As New MySqlConnectionStringBuilder(File.ReadAllText(filekoneksi))
                txthost.Text = koneksi.Server
                txtport.Text = koneksi.Port.ToString
                txtuser.Text = koneksi.UserID
                txtpass.Text = koneksi.Password
                If koneksi.Database <> "" Then
                    txtdb.Text = koneksi.Database
                End If
            End If
        Catch ex As Exception
            txthost.Text = ""
            txtport.Text = ""
            txtuser.Text = ""
            txtpass.Text = ""
        End Try
        Try
            Dim fileconfig As String = lokasifile("config.txt")
            If File.Exists(fileconfig) = True Then
                Dim baca As New StreamReader(fileconfig)
                txtpath.Text = baca.ReadLine.Replace("logo=", "").Replace(";", "")
                PictureBox1.Image = Bitmap.FromFile(txtpath.Text)
                txtnamatoko.Text = baca.ReadLine.Replace("toko=", "")
                baca.Close()
            End If
        Catch ex As Exception
            txtpath.Text = ""
            If PictureBox1.Image IsNot Nothing Then
                PictureBox1.Image.Dispose()
            End If
            txtnamatoko.Text = ""
        End Try
    End Sub

    'Cek koneksi ke server MySQL tanpa menyimpan konfigurasi
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If isianvalid() Then
            Me.Cursor = Cursors.WaitCursor
            lblstatus.ForeColor = Color.Black
            lblstatus.Text = "Menghubungi " + Trim(txthost.Text) + ":" + Trim(txtport.Text) + " ..."
            lblstatus.Refresh()
            Dim gagal As String = cekkoneksi(koneksiform())
            Me.Cursor = Cursors.Default
            If gagal = "" Then
                lblstatus.ForeColor = Color.Green
                lblstatus.Text = "Koneksi ke " + Trim(txthost.Text) + ":" + Trim(txtport.Text) + " berhasil. Klik Simpan untuk memakai pengaturan ini."
            Else
                lblstatus.ForeColor = Color.Red
                lblstatus.Text = gagal
            End If
        End If
    End Sub

    'Folder bin MySQL untuk backup/restore: MariaDB/MySQL di Program Files (dipasang installer) atau XAMPP
    Private Function foldermysql() As String
        Dim kandidat As New List(Of String)
        'aplikasi x86: ProgramW6432 = "C:\Program Files" 64-bit, tempat MariaDB terpasang
        For Each programfiles As String In New String() {Environment.GetEnvironmentVariable("ProgramW6432"), Environment.GetEnvironmentVariable("ProgramFiles")}
            If programfiles <> "" AndAlso Directory.Exists(programfiles) Then
                For Each folder As String In Directory.GetDirectories(programfiles, "MariaDB*")
                    kandidat.Add(Path.Combine(folder, "bin"))
                Next
                If Directory.Exists(Path.Combine(programfiles, "MySQL")) Then
                    For Each folder As String In Directory.GetDirectories(Path.Combine(programfiles, "MySQL"), "MySQL Server*")
                        kandidat.Add(Path.Combine(folder, "bin"))
                    Next
                End If
            End If
        Next
        kandidat.Add("C:\xampp\mysql\bin")
        kandidat.Add("D:\xampp\mysql\bin")
        For Each folder As String In kandidat
            If File.Exists(Path.Combine(folder, "mysqldump.exe")) Then
                Return folder
            End If
        Next
        Return ""
    End Function

    'Menjalankan mysql.exe / mysqldump.exe. Password lewat MYSQL_PWD agar tidak muncul prompt.
    'Hasil: "" jika sukses, pesan error jika gagal.
    Private Function jalankanmysql(ByVal program As String, ByVal argumen As String, ByVal filemasukan As String) As String
        Dim proses As New Process()
        proses.StartInfo.FileName = Path.Combine(foldermysql(), program)
        proses.StartInfo.Arguments = "-h " + Trim(txthost.Text) + " -P " + Trim(txtport.Text) + " -u """ + Trim(txtuser.Text) + """ " + argumen
        proses.StartInfo.UseShellExecute = False
        proses.StartInfo.CreateNoWindow = True
        proses.StartInfo.RedirectStandardError = True
        proses.StartInfo.RedirectStandardInput = (filemasukan <> "")
        proses.StartInfo.EnvironmentVariables("MYSQL_PWD") = txtpass.Text
        proses.Start()
        Dim pesanerror = proses.StandardError.ReadToEndAsync()
        If filemasukan <> "" Then
            Using isi As FileStream = File.OpenRead(filemasukan)
                isi.CopyTo(proses.StandardInput.BaseStream)
            End Using
            proses.StandardInput.Close()
        End If
        proses.WaitForExit()
        If proses.ExitCode = 0 Then
            Return ""
        End If
        Return pesanerror.Result
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With Me.SaveFileDialog1
            .Filter = "SQL|*.sql"
            .CheckPathExists = True
            .CreatePrompt = False
            .OverwritePrompt = True
            .ValidateNames = True
            .FileName = "backup_" + (DateAndTime.Now.ToString).Replace("/", "_").Replace(":", "_") + ".sql"
            .DefaultExt = ".sql"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                If foldermysql() = "" Then
                    MsgBox("mysqldump.exe tidak ditemukan. Backup harus dijalankan di komputer server (MariaDB/MySQL/XAMPP terpasang).", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                Dim gagal As String = jalankanmysql("mysqldump.exe", "--routines --triggers --no-tablespaces """ + Trim(txtdb.Text) + """ -r """ + .FileName + """", "")
                If gagal = "" Then
                    MsgBox("Backup database berhasil disimpan di " + .FileName, MsgBoxStyle.OkOnly)
                Else
                    MsgBox("Backup database gagal: " + gagal, MsgBoxStyle.OkOnly)
                End If
            End If
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        With Me.OpenFileDialog1
            .Filter = "SQL|*.sql"
            .Multiselect = False
            .DefaultExt = ".sql"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                If foldermysql() = "" Then
                    MsgBox("mysql.exe tidak ditemukan. Restore harus dijalankan di komputer server (MariaDB/MySQL/XAMPP terpasang).", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                Dim buton As DialogResult = MsgBox("Database " + Trim(txtdb.Text) + " akan DIHAPUS dan diganti isi file backup. Lanjutkan?", MsgBoxStyle.YesNo)
                If buton <> 6 Then
                    Exit Sub
                End If
                Dim db As String = Trim(txtdb.Text).Replace("`", "")
                Dim gagal As String = jalankanmysql("mysql.exe", "-e ""DROP DATABASE IF EXISTS `" + db + "`; CREATE DATABASE `" + db + "`;""", "")
                If gagal = "" Then
                    gagal = jalankanmysql("mysql.exe", """" + db + """", .FileName)
                End If
                If gagal = "" Then
                    MsgBox("Restore database berhasil", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("Restore database gagal: " + gagal, MsgBoxStyle.OkOnly)
                End If
            End If
        End With
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If txtnamatoko.Text = "" Then
            MsgBox("Nama perusahaan anda masih kosong", MsgBoxStyle.OkOnly)
            txtnamatoko.Focus()
        ElseIf txtpath.Text <> "" And Not logobuatan(txtpath.Text) And File.Exists(txtpath.Text) = False Then
            MsgBox("File yang anda maksud tidak ada", MsgBoxStyle.OkOnly)
            txtnamatoko.Focus()
        Else
            'belum ada logo / logo buatan: buat ulang agar sesuai nama toko terbaru
            If txtpath.Text = "" Or logobuatan(txtpath.Text) Then
                If Not tampilkanlogobuatan() Then
                    Exit Sub
                End If
            End If
            Dim tulis As New StreamWriter(lokasifile("config.txt"))
            tulis.WriteLine("logo=" + Me.txtpath.Text + ";")
            tulis.WriteLine("toko=" + Me.txtnamatoko.Text)
            tulis.Close()
            pathlogo = txtpath.Text
            namatoko = txtnamatoko.Text
            hapuslogolama(folderdata(), txtpath.Text)
            MsgBox("Konfigurasi berhasil disimpan", MsgBoxStyle.OkOnly)
        End If
    End Sub

    'Buat logo dari nama toko dan tampilkan. Hasil: False jika gagal.
    Private Function tampilkanlogobuatan() As Boolean
        Try
            txtpath.Text = buatlogo(txtnamatoko.Text, folderdata())
            If PictureBox1.Image IsNot Nothing Then
                PictureBox1.Image.Dispose()
            End If
            PictureBox1.Image = Bitmap.FromFile(txtpath.Text)
            Return True
        Catch ex As Exception
            MsgBox("Gagal membuat logo: " + ex.Message, MsgBoxStyle.OkOnly)
            Return False
        End Try
    End Function

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If txtnamatoko.Text = "" Then
            MsgBox("Isi nama toko dulu, logo dibuat dari nama toko", MsgBoxStyle.OkOnly)
            txtnamatoko.Focus()
        Else
            tampilkanlogobuatan()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim filename As String
        With Me.OpenFileDialog2
            .Filter = "Gambar|*.jpg;*.jpeg;*.png;*.bmp"
            .Multiselect = False
            .DefaultExt = "jpg"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                filename = .FileName
                txtpath.Text = filename
                PictureBox1.Image = Bitmap.FromFile(filename)
            End If
        End With
    End Sub
End Class