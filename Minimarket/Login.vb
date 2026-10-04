Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim login As MySqlCommand = New MySqlCommand("SELECT id_kasir FROM kasir where type=@type and nama_kasir=@nama and password=@password", konek)
        login.Parameters.AddWithValue("@type", jabatan.SelectedIndex + 1)
        login.Parameters.AddWithValue("@nama", txtusername.Text)
        login.Parameters.AddWithValue("@password", txtpassword.Text)
        Dim i As String = login.ExecuteScalar
        If (i = "") Then
            MsgBox("Username atau Password anda salah", MsgBoxStyle.OkOnly)
        Else
            Dim cek As MySqlCommand = New MySqlCommand("SELECT status FROM kasir where id_kasir=@id", konek)
            cek.Parameters.AddWithValue("@id", i)
            Dim status As String = cek.ExecuteScalar
            If (status = "Aktif") Then
                Dim tipe As MySqlCommand = New MySqlCommand("SELECT type FROM kasir where id_kasir=@id", konek)
                tipe.Parameters.AddWithValue("@id", i)
                Dim cektipe As String = tipe.ExecuteScalar
                If (cektipe = "1") Then
                    MsgBox("Login Sukses. Anda login sebagai ADMINISTRATOR", MsgBoxStyle.OkOnly)   
                    id_kasir = i
                    hak_akses = cektipe
                    main.MenuStrip1.Enabled = True
                    main.ObrolanToolStripMenuItem.Enabled = True
                    main.LoginToolStripMenuItem.Enabled = True
                    main.BarangToolStripMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem.Enabled = True
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.SatuanToolStripMenuItem.Enabled = True
                    main.KasirToolStripMenuItem.Enabled = True
                    main.SupplierToolStripMenuItem.Enabled = True
                    main.ToolStripMenuItem1.Enabled = True
                    Call ingatkanpassword(cektipe)
                    Me.Close()
                Else
                    MsgBox("Login Sukses. Anda login sebagai KASIR", MsgBoxStyle.OkOnly)
                    id_kasir = i
                    hak_akses = cektipe
                    main.MenuStrip1.Enabled = True
                    main.ObrolanToolStripMenuItem.Enabled = True
                    main.LoginToolStripMenuItem.Enabled = True
                    main.BarangToolStripMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem.Enabled = True
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.SatuanToolStripMenuItem.Enabled = False
                    main.KasirToolStripMenuItem.Enabled = False
                    main.SupplierToolStripMenuItem.Enabled = False
                    main.ToolStripMenuItem1.Enabled = False
                    Call ingatkanpassword(cektipe)
                    Me.Close()
                End If
            Else
                MsgBox("Akun anda untuk sementara TIDAK AKTIF, silahkan hubungi Administrator", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    'Selama akun masih memakai password bawaan, ingatkan setiap login
    Private Sub ingatkanpassword(ByVal tipe As String)
        If txtpassword.Text <> PASSWORDBAWAAN Then
            Exit Sub
        End If
        If tipe = "1" Then
            MsgBox("Akun Anda masih memakai password bawaan '" + PASSWORDBAWAAN + "'." + vbCrLf + vbCrLf + _
                   "Demi keamanan, segera ganti password:" + vbCrLf + _
                   "1. Klik akun Anda di tabel Manajemen Kasir" + vbCrLf + _
                   "2. Isi Password baru" + vbCrLf + _
                   "3. Klik Update", MsgBoxStyle.Exclamation, "Ganti Password")
            kasir.MdiParent = main
            kasir.Show()
            kasir.MaximizeBox = False
        Else
            MsgBox("Akun Anda masih memakai password bawaan." + vbCrLf + _
                   "Minta Administrator mengganti password akun Anda.", MsgBoxStyle.Exclamation, "Ganti Password")
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class
