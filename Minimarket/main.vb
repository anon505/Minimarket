Imports System.IO
Imports MySql.Data.MySqlClient
Public Class main

    Public Sub konekbuka()
        Dim strdriverodbc As New String(Space(255))
        Try
            If File.Exists("koneksi.txt") = True Then
                Dim TW As New StreamReader("koneksi.txt")
                Dim koneksi As String
                koneksi = TW.ReadToEnd + ";database=" + cpanel.txtdb.Text
                TW.Close()
                konek = New MySqlConnection
                konek.ConnectionString = koneksi
                konek.Open()

            ElseIf File.Exists("koneksi.txt") = False Then
                MenuStrip1.Enabled = False
                If cpanel.Visible = True Then
                    cpanel.Close()
                End If
                MsgBox("File koneksi.txt tidak ada. Silahkan konfigurasi terlebih dahulu!!!", MsgBoxStyle.OkOnly)
                cpanel.MdiParent = Me
                cpanel.Show()
                cpanel.MaximizeBox = False
            End If

        Catch ex As Exception
            MenuStrip1.Enabled = False
            If cpanel.Visible = True Then
                cpanel.Close()
            End If
            MsgBox("Maaf, Aplikasi tidak bisa terkoneksi ke Database. Silahkan periksa pengaturan Anda!!!", MsgBoxStyle.OkOnly)
            cpanel.MdiParent = Me
            cpanel.Show()
            cpanel.MaximizeBox = False
        End Try
    End Sub
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MenuStrip1.Enabled = True
        MarkupToolStripMenuItem.Enabled = False
        LoginToolStripMenuItem.Enabled = True
        BarangToolStripMenuItem.Enabled = False
        PembelianToolStripMenuItem.Enabled = False
        PenjualanToolStripMenuItem.Enabled = False
        SatuanToolStripMenuItem.Enabled = False
        KasirToolStripMenuItem.Enabled = False
        SupplierToolStripMenuItem.Enabled = False
        ToolStripMenuItem1.Enabled = False
        LaporanHarianToolStripMenuItem.Enabled = False
        KeuntunganToolStripMenuItem.Enabled = False
        KadaluarsaToolStripMenuItem.Enabled = False

        Call konekbuka()
        Try
            If File.Exists("config.txt") = True Then
                Dim bc As New StreamReader("config.txt")
                pathlogo = (bc.ReadLine).Replace("logo=", "").Replace(";", "")
                namatoko = (bc.ReadLine).Replace("toko=", "")
                bc.Close()
            ElseIf File.Exists("config.txt") = False Then
                MsgBox("File config.txt tidak ada. Silahkan konfigurasi terlebih dahulu.", MsgBoxStyle.OkOnly)
                cpanel.MdiParent = Me
                cpanel.Show()
                cpanel.MaximizeBox = False
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.OkOnly)
        End Try

    End Sub
    Private Sub BarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangToolStripMenuItem.Click
        barang.MdiParent = Me
        barang.Show()
        barang.MaximizeBox = False
    End Sub
    Private Sub KasirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KasirToolStripMenuItem.Click
        kasir.MdiParent = Me
        kasir.Show()
        kasir.MaximizeBox = False
    End Sub
    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        supplier.MdiParent = Me
        supplier.Show()
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenjualanToolStripMenuItem.Click
        Dim newPenjualan = New penjualan
        newPenjualan.MdiParent = Me
        newPenjualan.Show()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        Login.MdiParent = Me
        Login.Show()
    End Sub

    Private Sub SatuanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SatuanToolStripMenuItem.Click
        satuan.MdiParent = Me
        satuan.Show()
        satuan.MaximizeBox = False
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembelianToolStripMenuItem.Click
        pembelian.MdiParent = Me
        pembelian.Show()
    End Sub

    Private Sub MarkupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkupToolStripMenuItem.Click
        markup.MdiParent = Me
        markup.Show()
    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        cpanel.MdiParent = Me
        cpanel.Show()
        cpanel.MaximizeBox = False
    End Sub

    Private Sub KeuntunganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeuntunganToolStripMenuItem.Click
        cetak_keuntungan.MdiParent = Me
        cetak_keuntungan.Show()
    End Sub

    Private Sub KadaluarsaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KadaluarsaToolStripMenuItem.Click
        cetak_expiry.MdiParent = Me
        cetak_expiry.Show()
    End Sub
End Class