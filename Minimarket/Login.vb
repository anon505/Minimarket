Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim login As MySqlCommand = New MySqlCommand("SELECT id_kasir FROM KASIR where type='" + (jabatan.SelectedIndex + 1).ToString + "' and nama_kasir='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", konek)
        Dim i As String = login.ExecuteScalar
        If (i = "") Then
            MsgBox("Username atau Password anda salah", MsgBoxStyle.OkOnly)
        Else
            Dim cek As MySqlCommand = New MySqlCommand("SELECT status FROM kasir where id_kasir='" + i + "'", konek)
            Dim status As String = cek.ExecuteScalar
            If (status = "Aktif") Then
                Dim tipe As MySqlCommand = New MySqlCommand("SELECT type FROM kasir where id_kasir='" + i + "'", konek)
                Dim cektipe As String = tipe.ExecuteScalar
                id_kasir = i
                hak_akses = cektipe
                If (cektipe = "1") Then
                    MsgBox("Login Sukses. Anda login sebagai SUPER ADMINISTRATOR", MsgBoxStyle.OkOnly)
                    
                    main.MenuStrip1.Enabled = True
                    main.MarkupToolStripMenuItem.Enabled = True
                    main.LoginToolStripMenuItem.Enabled = True
                    main.BarangToolStripMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem.Enabled = True
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.SatuanToolStripMenuItem.Enabled = True
                    main.KasirToolStripMenuItem.Enabled = True
                    main.SupplierToolStripMenuItem.Enabled = True
                    main.ToolStripMenuItem1.Enabled = True
                    main.LaporanHarianToolStripMenuItem.Enabled = True
                    main.KeuntunganToolStripMenuItem.Enabled = True
                    main.KadaluarsaToolStripMenuItem.Enabled = True
                    Me.Close()
                ElseIf (cektipe = "2") Then
                    MsgBox("Login Sukses. Anda login sebagai ADMINISTRATOR", MsgBoxStyle.OkOnly)

                    main.MenuStrip1.Enabled = True
                    main.MarkupToolStripMenuItem.Enabled = True
                    main.LoginToolStripMenuItem.Enabled = True
                    main.BarangToolStripMenuItem.Enabled = False
                    main.PembelianToolStripMenuItem.Enabled = True
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.SatuanToolStripMenuItem.Enabled = True
                    main.KasirToolStripMenuItem.Enabled = True
                    main.SupplierToolStripMenuItem.Enabled = True
                    main.ToolStripMenuItem1.Enabled = False
                    main.LaporanHarianToolStripMenuItem.Enabled = True
                    main.KeuntunganToolStripMenuItem.Enabled = False
                    main.KadaluarsaToolStripMenuItem.Enabled = True
                    Me.Close()
                Else
                    MsgBox("Login Sukses. Anda login sebagai KASIR", MsgBoxStyle.OkOnly)
                    main.MenuStrip1.Enabled = True
                    main.MarkupToolStripMenuItem.Enabled = False
                    main.LoginToolStripMenuItem.Enabled = True
                    main.BarangToolStripMenuItem.Enabled = False
                    main.PembelianToolStripMenuItem.Enabled = True
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.SatuanToolStripMenuItem.Enabled = False
                    main.KasirToolStripMenuItem.Enabled = False
                    main.SupplierToolStripMenuItem.Enabled = False
                    main.ToolStripMenuItem1.Enabled = False
                    main.LaporanHarianToolStripMenuItem.Enabled = False
                    main.KeuntunganToolStripMenuItem.Enabled = False
                    main.KadaluarsaToolStripMenuItem.Enabled = False
                    Me.Close()
                End If
            Else
                MsgBox("Akun anda untuk sementara TIDAK AKTIF, silahkan hubungi Administrator", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
