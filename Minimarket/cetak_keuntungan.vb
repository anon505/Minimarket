Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Globalization

Public Class cetak_keuntungan
    Dim kasirIds As List(Of Integer)
    Private Sub cetak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim kasircmd As MySqlCommand = New MySqlCommand("select id_kasir,nama_kasir from kasir", konek)
        Dim ksr As DataSet = New DataSet
        Dim ksrda As MySqlDataAdapter = New MySqlDataAdapter
        Dim j As Integer
        ksrda.SelectCommand = kasircmd
        ksrda.Fill(ksr, "kasir")
        kasirbox.Items.Clear()
        kasirIds = New List(Of Integer)
        kasirIds.Clear()

        For j = 0 To ksr.Tables("kasir").Rows.Count - 1
            kasirIds.Add(ksr.Tables("kasir").Rows(j).ItemArray.GetValue(0))
            kasirbox.Items.Add(ksr.Tables("kasir").Rows(j).ItemArray.GetValue(1))
        Next
        txtEndDateTime.Text = DateTimePicker1.Value.Date
        txtStartDateTime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtEndDateTime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        txtStartDateTime.Text = DateTimePicker2.Value.Date
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim rptDataSource As ReportDataSource
        Ds_report_penjualanTableAdapter1.FillByKasir(Minimarket_ds.ds_report_penjualan, kasirIds(kasirbox.SelectedIndex), DateTime.ParseExact(txtStartDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture), DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture))
        If (Minimarket_ds.ds_report_penjualan.Rows.Count = 0) Then
            MsgBox("Tidak ada transaksi penjualan yang dilakukan oleh " & kasirbox.Text & " dari tanggal " & txtStartDateTime.Text & " sampai tanggal " & txtEndDateTime.Text, MsgBoxStyle.OkOnly)
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket.rpt_penjualan.rdlc"
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            rptDataSource = New ReportDataSource("minimarket_ds", Minimarket_ds.Tables("ds_report_penjualan"))
            Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            Dim paramlist As New Generic.List(Of ReportParameter)
            paramlist.Clear()
            Me.ReportViewer1.LocalReport.EnableExternalImages = True
            paramlist.Add(New ReportParameter("startDatePenjualan", DateTime.ParseExact(txtStartDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToLongDateString))
            paramlist.Add(New ReportParameter("endDatePenjualan", DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToLongDateString))
            Me.ReportViewer1.LocalReport.SetParameters(paramlist)
            Me.ReportViewer1.RefreshReport()
        End If
    End Sub

End Class