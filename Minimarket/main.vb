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
                If konek.State = ConnectionState.Fetching Or konek.State = ConnectionState.Open Then
                    
                    If cpanel.checkMySQLDriver(strdriverodbc) = False Then
                        MsgBox("MySQL ODBC 5.1 Driver tidak di install." + vbCrLf + " Silahkan Instal  MySQl ODBC 5.1 Driver.", MsgBoxStyle.Information, "Buat Mysql DSN")
                        cpanel.MdiParent = Me
                        cpanel.Show()
                        cpanel.MaximizeBox = False
                    Else
                        cpanel.MdiParent = Me
                        cpanel.Show()
                        cpanel.MaximizeBox = False
                        cpanel.MakeMySQLDSN(Trim(cpanel.txtdb.Text), Trim(cpanel.txtdsn.Text), Trim(cpanel.txtdesc.Text), strdriverodbc, Trim(cpanel.txtuser.Text), Trim(cpanel.txtpass.Text), Trim(cpanel.txthost.Text), Trim(cpanel.txtport.Text), 3, "")
                        strdriverodbc = "C:\WINDOWS\System32\odbc32.dll"
                        If cpanel.Visible = True Then
                            cpanel.Close()
                        End If
                        Login.MdiParent = Me
                        Login.Show()
                        MenuStrip1.Enabled = False
                    End If
                End If
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