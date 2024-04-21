Imports System.IO
Imports MySql.Data.MySqlClient
Imports Microsoft.Win32
Public Class cpanel

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        Dim tr As New StreamWriter("koneksi.txt")
        tr.WriteLine("server=" + Me.txthost.Text + ";")
        tr.WriteLine("port=" + Me.txtport.Text + ";")
        tr.WriteLine("user id=" + Me.txtuser.Text + ";")
        tr.WriteLine("password=" + Me.txtpass.Text + "")
        tr.Close()
       

        'check that the dsnname is already exist ?
        'If MySQLDSNWanted(Trim(txtdsn.Text)) = True Then
        'MsgBox("DSN sudah ada.", MsgBoxStyle.OkOnly)
        'txtdsn.Focus()
        'Exit Sub
        'Else
        If IsValidIP(txthost.Text) = False Then
            MsgBox("IP Address tidak valid", MsgBoxStyle.OkOnly)
            txthost.Focus()
        ElseIf txtuser.Text = "" Then
            MsgBox("Kolom text user masih kosong", MsgBoxStyle.OkOnly)
            txtuser.Focus()
        ElseIf txtport.Text = "" Then
            MsgBox("Kolom text port masih kosong", MsgBoxStyle.OkOnly)
            txtport.Focus()
        Else
            Call main.konekbuka()
        End If
    End Sub
    Function IsValidIP(ByVal ipAddress As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(ipAddress, _
            "^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$")
    End Function
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthost.TextChanged

    End Sub

    Private Sub cpanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If File.Exists("koneksi.txt") = True Then
                Dim tr As New StreamReader("koneksi.txt")
                txthost.Text = tr.ReadLine.Replace("server=", "").Replace(";", "")
                txtport.Text = tr.ReadLine.Replace("port=", "").Replace(";", "")
                txtuser.Text = tr.ReadLine.Replace("user id=", "").Replace(";", "")
                txtpass.Text = tr.ReadLine.Replace("password=", "")
                tr.Close()
            End If
        Catch ex As Exception
            txthost.Text = ""
            txtport.Text = ""
            txtuser.Text = ""
            txtpass.Text = ""
        End Try
        Try
            If File.Exists("config.txt") = True Then
                Dim baca As New StreamReader("config.txt")
                txtpath.Text = baca.ReadLine.Replace("logo=", "").Replace(";", "")
                PictureBox1.Image = Bitmap.FromFile(txtpath.Text)
                txtnamatoko.Text = baca.ReadLine.Replace("toko=", "")
                baca.Close()
            End If
        Catch ex As Exception
            txtpath.Text = ""
            PictureBox1.Image.Dispose()
            txtnamatoko.Text = ""
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myProcess As New Process()
        With Me.SaveFileDialog1
            .Filter = "SQL|*.sql"
            .CheckPathExists = True
            .CreatePrompt = False
            .OverwritePrompt = True
            .ValidateNames = True
            .FileName = "backup_" + (DateAndTime.Now.ToString).Replace("/", "_").Replace(":", "_") + ".sql"
            .DefaultExt = ".sql"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                myProcess.StartInfo.FileName = "cmd.exe"
                myProcess.StartInfo.UseShellExecute = False
                myProcess.StartInfo.WorkingDirectory = "D:\xampp\mysql\bin"
                myProcess.StartInfo.RedirectStandardInput = True
                myProcess.StartInfo.RedirectStandardOutput = True
                myProcess.Start()
                Dim myStreamWriter As StreamWriter = myProcess.StandardInput
                Dim mystreamreader As StreamReader = myProcess.StandardOutput
                myStreamWriter.WriteLine("mysql.exe -u " + txtuser.Text + " -p minimarket < D:\Minimarket\minimarket_db.sql")
                myStreamWriter.Close()
                myProcess.WaitForExit()
                myProcess.Close()
                'Process.Start("C:\xampp\mysql\bin\mysql.exe", "-u root -p  --database=minimarket > -r ""D:\minimarket.sql""")
                Process.Start("D:\xampp\mysql\bin\mysqldump.exe", " -u " + txtuser.Text + " -p minimarket -r """ + .FileName + "")
            End If
        End With
      
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim myProcess As New Process()
        With Me.OpenFileDialog1
            .Filter = "SQL|*.sql"
            .Multiselect = False
            .DefaultExt = ".sql"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim per As String = "mysql  \. " + .FileName.ToString
                myProcess.StartInfo.FileName = "cmd.exe"
                myProcess.StartInfo.UseShellExecute = False
                myProcess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                myProcess.StartInfo.RedirectStandardInput = True
                myProcess.StartInfo.RedirectStandardOutput = True
                myProcess.Start()
                Dim myStreamWriter As StreamWriter = myProcess.StandardInput
                Dim mystreamreader As StreamReader = myProcess.StandardOutput
                myStreamWriter.WriteLine("mysql -u " + txtuser.Text + " -p ")
                myStreamWriter.WriteLine("drop database if exists minimarket ;")
                myStreamWriter.WriteLine("create database minimarket ;")
                myStreamWriter.WriteLine("use minimarket ;")
                myStreamWriter.WriteLine(per)
                myStreamWriter.WriteLine()
                myStreamWriter.Close()
                myProcess.WaitForExit()
                myProcess.Close()
            End If
        End With
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call Shell("rundll32.exe shell32.dll,Control_RunDLL ODBCCP32.cpl @2, 5")
    End Sub

    Public Function MakeMySQLDSN(ByVal DB_Name As String, _
                               ByVal DSN As String, _
                               ByVal Description As String, _
                               ByVal Driver_Name As String, _
                               ByVal userid As String, _
                               ByVal password As String, _
                               ByVal Server_Name As String, _
                               ByVal port As String, _
                               ByVal stroption As String, _
                               ByVal stmt As String _
                               ) As Boolean

        Dim lResult As Long
        Dim hKeyHandle As Long
        Dim msg1 As String

        Dim regHandle As RegistryKey ' Stores the Handle to Registry in which values need to be set

        Dim reg As RegistryKey = Registry.LocalMachine
        Dim conRegKey1 As String = "SOFTWARE\ODBC\ODBC.INI\" & DSN
        Dim conRegKey2 As String = "SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources"

        Try
            regHandle = reg.CreateSubKey(conRegKey1)
            regHandle.SetValue("Database", DB_Name)
            regHandle.SetValue("Description", Description)
            regHandle.SetValue("Driver", Driver_Name)
            regHandle.SetValue("Option", stroption)
            regHandle.SetValue("Password", password)
            regHandle.SetValue("Port", port)
            regHandle.SetValue("Server", Server_Name)
            regHandle.SetValue("Stmt", stmt)
            regHandle.SetValue("User", userid)
            regHandle.Close()
            reg.Close()

            regHandle = reg.CreateSubKey(conRegKey2)
            regHandle.SetValue(DSN, "MySQL ODBC 5.1 Driver")
            regHandle.Close()
            reg.Close()
            Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Function
    Public Function checkMySQLDriver(ByRef DriverODBC As String) As Boolean
        Try
            Dim odbcDrivers = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).
                OpenSubKey("SOFTWARE").
                OpenSubKey("WOW6432Node").
                OpenSubKey("ODBC").OpenSubKey("ODBCINST.INI").OpenSubKey("ODBC Drivers")


            If odbcDrivers.GetValue("MySQL ODBC 5.1 Driver", Nothing) IsNot Nothing Then
                DriverODBC = odbcDrivers.GetValue("MySQL ODBC 5.1 Driver")
                checkMySQLDriver = True
            Else
                checkMySQLDriver = False
            End If
        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Function
    Private Function MySQLDSNWanted(ByVal strdsnName As String) As Boolean
        Dim reghandle As RegistryKey
        Dim reg As RegistryKey = Registry.LocalMachine
        Dim conRegKey1 As String = "SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources\"
        Dim tmpdsnvalue As String
        Try
            reghandle = reg.OpenSubKey(conRegKey1)
            If reghandle.ValueCount > 0 Then
                tmpdsnvalue = reghandle.GetValue(strdsnName)
                If tmpdsnvalue = "" Then
                    MySQLDSNWanted = False
                Else
                    MySQLDSNWanted = True
                End If
            Else
                MySQLDSNWanted = False
            End If
        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If txtpath.Text = "" Then
            MsgBox("Lokasi logo anda masih kosong", MsgBoxStyle.OkOnly)
            txtpath.Focus()
        ElseIf txtnamatoko.Text = "" Then
            MsgBox("Nama perusahaan anda masih kosong", MsgBoxStyle.OkOnly)
            txtnamatoko.Focus()
        ElseIf File.Exists(txtpath.Text) = False Then
            MsgBox("File yang anda maksud tidak ada", MsgBoxStyle.OkOnly)
            txtnamatoko.Focus()
        Else
            Dim tulis As New StreamWriter("config.txt")
            tulis.WriteLine("logo=" + Me.txtpath.Text + ";")
            tulis.WriteLine("toko=" + Me.txtnamatoko.Text)
            tulis.Close()
            pathlogo = txtpath.Text
            namatoko = txtnamatoko.Text
            MsgBox("Konfigurasi berhasil disimpan", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim filename As String
        With Me.OpenFileDialog2
            .Filter = "JPG|*.jpg|BMP|*.bmp"
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