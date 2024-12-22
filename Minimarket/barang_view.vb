Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Public Class barang_view

    Public Sub view()
        Dim ds = newConnect.ExecuteReader("select barcode,nama_barang,(stok_display+stok_gudang) as total_stok,stok_display,stok_gudang,nama_satuan,nama_suplier from barang left JOIN satuan ON satuan.id_satuan=barang.id_satuan left JOIN supplier ON supplier.id_suplier=barang.id_suplier")
        Label1.Text = "Total Barang :" + ds.Rows.Count.ToString
        DataGridView1.DataSource = ds
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        berdasarkan.SelectedIndex = 0
        syarat.SelectedIndex = 0
    End Sub
    Public Sub reload()
        Call view()
    End Sub

    Public Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call view()
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Call reload()
    End Sub


    Public Sub pencarian()
        Console.WriteLine("jancuk")
        Console.WriteLine(berdasarkan.SelectedIndex)
        If (txtcari.Text = "") Then
            Dim ds = newConnect.ExecuteReader("select barcode,nama_barang,(stok_display+stok_gudang) as total_stok,stok_display,stok_gudang,nama_satuan,nama_suplier from barang left JOIN satuan ON satuan.id_satuan=barang.id_satuan left JOIN supplier ON supplier.id_suplier=barang.id_suplier")
            DataGridView1.DataSource = ds
            Return

        End If
        If berdasarkan.SelectedIndex = 0 Then
            Dim ds = newConnect.ExecuteReader("select barcode,nama_barang,(stok_display+stok_gudang) as total_stok,stok_display,stok_gudang,nama_satuan,nama_suplier from barang left JOIN satuan ON satuan.id_satuan=barang.id_satuan left JOIN supplier ON supplier.id_suplier=barang.id_suplier where nama_barang like '%" + txtcari.Text + "%' order by nama_barang asc")

            DataGridView1.DataSource = ds
        End If
        If berdasarkan.SelectedIndex = 1 Then
            Try
                Dim query = "select barcode,nama_barang,(stok_display+stok_gudang) as total_stok,stok_display,stok_gudang,nama_satuan,nama_suplier from barang left JOIN satuan ON satuan.id_satuan=barang.id_satuan left JOIN supplier ON supplier.id_suplier=barang.id_suplier where (stok_display+stok_gudang)" + syarat.SelectedItem + txtcari.Text + ""
                Console.WriteLine(query)
                Dim ds = newConnect.ExecuteReader(query)

                DataGridView1.DataSource = ds
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
    End Sub
    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call pencarian()
    End Sub

    Private Sub syarat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles syarat.SelectedIndexChanged
        Call pencarian()
    End Sub

    Private Sub berasarkan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles berdasarkan.SelectedIndexChanged
        Call pencarian()
    End Sub


End Class
