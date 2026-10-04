Imports System.IO
Imports MySql.Data.MySqlClient
Public Class main
    Public Sub konekbuka()
        Try
            Dim filekoneksi As String = lokasifile("koneksi.txt")
            If File.Exists(filekoneksi) = True Then
                Dim koneksi As New MySqlConnectionStringBuilder(File.ReadAllText(filekoneksi))
                'koneksi.txt versi lama tidak menyimpan nama database
                If koneksi.Database = "" Then
                    koneksi.Database = cpanel.txtdb.Text
                End If
                koneksi.ConnectionTimeout = 5
                Dim gagal As String = cekkoneksi(koneksi)
                If gagal <> "" Then
                    MenuStrip1.Enabled = False
                    MsgBox("Aplikasi tidak bisa terkoneksi ke Database." + vbCrLf + gagal, MsgBoxStyle.OkOnly)
                    cpanel.MdiParent = Me
                    cpanel.Show()
                    cpanel.MaximizeBox = False
                    Exit Sub
                End If
                If konek IsNot Nothing Then
                    konek.Close()
                End If
                konek = New MySqlConnection(koneksi.ConnectionString)
                konek.Open()
                If cpanel.Visible = True Then
                    cpanel.Close()
                End If
                Login.MdiParent = Me
                Login.Show()
                MenuStrip1.Enabled = False
            Else
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
            MsgBox("Maaf, Aplikasi tidak bisa terkoneksi ke Database. Silahkan periksa pengaturan Anda!!!" + vbCrLf + ex.Message, MsgBoxStyle.OkOnly)
            cpanel.MdiParent = Me
            cpanel.Show()
            cpanel.MaximizeBox = False
        End Try
    End Sub
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call konekbuka()
        Try
            Dim fileconfig As String = lokasifile("config.txt")
            If File.Exists(fileconfig) = True Then
                Dim bc As New StreamReader(fileconfig)
                pathlogo = (bc.ReadLine).Replace("logo=", "").Replace(";", "")
                namatoko = (bc.ReadLine).Replace("toko=", "")
                bc.Close()
            Else
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
        penjualan.MdiParent = Me
        penjualan.Show()
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

    Private Sub ObrolanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObrolanToolStripMenuItem.Click
        chat.MdiParent = Me
        chat.Show()
    End Sub

    Private Sub LaporanHarianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanHarianToolStripMenuItem.Click
        cetak.MdiParent = Me
        cetak.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        cpanel.MdiParent = Me
        cpanel.Show()
        cpanel.MaximizeBox = False
    End Sub
End Class