Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim i As String = newConnect.ExecuteScalar("SELECT id_kasir FROM KASIR where type='" + (jabatan.SelectedIndex + 1).ToString + "' and nama_kasir='" + txtusername.Text + "' and password='" + txtpassword.Text + "'")
        If (i = "") Then
            MsgBox("Username atau Password anda salah", MsgBoxStyle.OkOnly)
        Else
            Dim status As String = newConnect.ExecuteScalar("SELECT status FROM kasir where id_kasir='" + i + "'")
            If (status = "Aktif") Then
                Dim cektipe As String = newConnect.ExecuteScalar("SELECT type FROM kasir where id_kasir='" + i + "'")
                id_kasir = i
                hak_akses = cektipe
                If (cektipe = "1") Then
                    MsgBox("Login Sukses. Anda login sebagai SUPER ADMINISTRATOR", MsgBoxStyle.OkOnly)

                    main.MenuStrip1.Enabled = True
                    main.MarkupToolStripMenuItem.Enabled = True
                    main.LoginToolStripMenuItem.Enabled = True
                    main.MasterMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem.Enabled = True
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem1.Enabled = True

                    main.BarangSubMenuItem.Enabled = True
                    main.SatuanSubMenuItem.Enabled = True
                    main.KasirSubMenuItem.Enabled = True
                    main.SupplierSubMenuItem.Enabled = True
                    main.AlurKasSubMenuItem.Enabled = True

                    main.ToolStripMenuItem1.Enabled = True
                    main.LaporanHarianToolStripMenuItem.Enabled = True
                    main.KeuntunganToolStripMenuItem.Enabled = True
                    main.KadaluarsaToolStripMenuItem.Enabled = True
                    main.ReturMenuItem.Enabled = True
                    Me.Close()
                ElseIf (cektipe = "2") Then
                    MsgBox("Login Sukses. Anda login sebagai ADMINISTRATOR", MsgBoxStyle.OkOnly)

                    main.MenuStrip1.Enabled = True
                    main.MarkupToolStripMenuItem.Enabled = True
                    main.LoginToolStripMenuItem.Enabled = True
                    main.MasterMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem.Enabled = True
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem1.Enabled = True
                    main.BarangSubMenuItem.Enabled = False
                    main.SatuanSubMenuItem.Enabled = True
                    main.KasirSubMenuItem.Enabled = False
                    main.SupplierSubMenuItem.Enabled = True
                    main.AlurKasSubMenuItem.Enabled = False


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
                    main.MasterMenuItem.Enabled = False
                    main.PembelianToolStripMenuItem.Enabled = False
                    main.PenjualanToolStripMenuItem.Enabled = True
                    main.PembelianToolStripMenuItem1.Enabled = False
                    main.BarangSubMenuItem.Enabled = False
                    main.SatuanSubMenuItem.Enabled = False
                    main.KasirSubMenuItem.Enabled = False
                    main.SupplierSubMenuItem.Enabled = False
                    main.AlurKasSubMenuItem.Enabled = False
                    main.ToolStripMenuItem1.Enabled = False
                    main.LaporanHarianToolStripMenuItem.Enabled = False
                    main.KeuntunganToolStripMenuItem.Enabled = False
                    main.KadaluarsaToolStripMenuItem.Enabled = False
                    Me.Close()
                End If
                main.listBarangForm.MdiParent = main
                main.listBarangForm.WindowState = FormWindowState.Minimized  ' Make sure it's not minimized
                main.listBarangForm.Show()
            Else
                MsgBox("Akun anda untuk sementara TIDAK AKTIF, silahkan hubungi Administrator", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
