Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class cetak
    'id_kasir sesuai urutan item di kasirbox
    Private idkasir As New List(Of Integer)

    Private Sub cetak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim kasircmd As MySqlCommand = New MySqlCommand("select id_kasir,nama_kasir from kasir", konek)
        Dim ksr As DataSet = New DataSet
        Dim ksrda As MySqlDataAdapter = New MySqlDataAdapter
        Dim j As Integer
        ksrda.SelectCommand = kasircmd
        ksrda.Fill(ksr, "kasir")
        kasirbox.Items.Clear()
        idkasir.Clear()
        For j = 0 To ksr.Tables("kasir").Rows.Count - 1
            idkasir.Add(CInt(ksr.Tables("kasir").Rows(j).ItemArray.GetValue(0)))
            kasirbox.Items.Add(ksr.Tables("kasir").Rows(j).ItemArray.GetValue(1))
        Next
        txtdatetime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtdatetime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click 
        Dim rptDataSource As ReportDataSource
        If kasirbox.SelectedIndex < 0 Then
            MsgBox("Pilih kasir dari daftar", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        Dim tanggal As Date = DateTimePicker1.Value.Date
        Dim kasirdipilih As Integer = idkasir(kasirbox.SelectedIndex)
        If (transbox.Text = "Penjualan") Then
            Dim sql As MySqlCommand = New MySqlCommand("SELECT keuntungan.`waktu beli` AS kapan, keuntungan.id_barang, kasir.nama_kasir, keuntungan.nama_barang, keuntungan.harga_beli, keuntungan.harga_jual," & _
                " keuntungan.total, keuntungan.id_kasir, keuntungan.nama_satuan, keuntungan.tanggal" & _
                " FROM keuntungan, kasir WHERE keuntungan.id_kasir = kasir.id_kasir AND keuntungan.tanggal = @tanggal AND keuntungan.id_kasir = @id_kasir ORDER BY kapan", konek)
            sql.Parameters.AddWithValue("@tanggal", tanggal)
            sql.Parameters.AddWithValue("@id_kasir", kasirdipilih)
            Me.Minimarketds.DataTable1.Clear()
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(sql)
            da.Fill(Me.Minimarketds.DataTable1)
            If (Me.Minimarketds.DataTable1.Rows.Count = 0) Then
                MsgBox("Tidak ada transaksi penjualan yang dilakukan oleh " + kasirbox.Text + " pada tanggal " + txtdatetime.Text, MsgBoxStyle.OkOnly)
            Else
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket.penjualan.rdlc"
                Me.ReportViewer1.LocalReport.DataSources.Clear()
                rptDataSource = New ReportDataSource("DataSet1", Minimarketds.Tables("DataTable1"))
                Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
                Dim paramlist As New Generic.List(Of ReportParameter)
                paramlist.Clear()
                Me.ReportViewer1.LocalReport.EnableExternalImages = True
                paramlist.Add(New ReportParameter("tgl_lap", txtdatetime.Text))
                paramlist.Add(New ReportParameter("logoumam", "File:////" + pathlogo))
                paramlist.Add(New ReportParameter("namatoko", namatoko))
                Me.ReportViewer1.LocalReport.SetParameters(paramlist)
                Me.ReportViewer1.RefreshReport()
            End If
        ElseIf (transbox.Text = "Pembelian") Then
            Dim sql As MySqlCommand = New MySqlCommand("SELECT view_beli.id_kasir, view_beli.id_barang, view_beli.nama_barang, view_beli.waktu_beli, view_beli.harga_beli, view_beli.jumlah, view_beli.nama_satuan," & _
                " view_beli.tanggal, kasir.nama_kasir" & _
                " FROM view_beli, kasir WHERE view_beli.id_kasir = kasir.id_kasir AND view_beli.tanggal = @tanggal AND view_beli.id_kasir = @id_kasir", konek)
            sql.Parameters.AddWithValue("@tanggal", tanggal)
            sql.Parameters.AddWithValue("@id_kasir", kasirdipilih)
            Me.Minimarketds.DataTable2.Clear()
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(sql)
            da.Fill(Me.Minimarketds.DataTable2)
            If (Me.Minimarketds.DataTable2.Rows.Count = 0) Then
                MsgBox("Tidak ada transaksi pembelian yang dilakukan oleh " + kasirbox.Text + " pada tanggal " + txtdatetime.Text, MsgBoxStyle.OkOnly)
            Else
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket.pembelian.rdlc"
                Me.ReportViewer1.LocalReport.DataSources.Clear()
                rptDataSource = New ReportDataSource("DataSet1", Minimarketds.Tables("DataTable2"))
                Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
                Dim paramlist As New Generic.List(Of ReportParameter)
                paramlist.Clear()
                Me.ReportViewer1.LocalReport.EnableExternalImages = True
                paramlist.Add(New ReportParameter("tgl_lap", txtdatetime.Text))
                paramlist.Add(New ReportParameter("logoumam", "File:////" + pathlogo))
                paramlist.Add(New ReportParameter("namatoko", namatoko))
                Me.ReportViewer1.LocalReport.SetParameters(paramlist)
                Me.ReportViewer1.RefreshReport()
            End If
        End If
    End Sub

    Private Sub kasirbox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kasirbox.SelectedIndexChanged

    End Sub
End Class