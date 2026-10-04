Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient
Public Class formnota

    Private Sub formnota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        'isi nota: barang di keranjang (status 'belum') milik kasir yang login
        Dim sql As MySqlCommand = New MySqlCommand("SELECT penjualan.id_barang, barang.nama_barang, barang.harga_jual, SUM(penjualan.total) AS jumlah, penjualan.id_kasir, satuan.nama_satuan" & _
            " FROM penjualan JOIN barang ON barang.id_barang = penjualan.id_barang JOIN satuan ON satuan.id_satuan = barang.satuan" & _
            " WHERE penjualan.id_kasir = @id_kasir AND penjualan.status = 'belum'" & _
            " GROUP BY penjualan.id_barang, barang.nama_barang, barang.harga_jual, penjualan.id_kasir, satuan.nama_satuan", konek)
        sql.Parameters.AddWithValue("@id_kasir", id_kasir)
        Me.Minimarketds.nota.Clear()
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(sql)
        da.Fill(Me.Minimarketds.nota)
        Dim paramlist As New Generic.List(Of ReportParameter)
        paramlist.Clear()
         'Add the BASE64 stream to the parameters
         paramlist.Add(New ReportParameter("dibayar", penjualan.dibayar.Tag.ToString))
        paramlist.Add(New ReportParameter("logo1", "File:////" + pathlogo))
        paramlist.Add(New ReportParameter("namatoko", namatoko))
        Me.ReportViewer1.LocalReport.SetParameters(paramlist)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub
End Class