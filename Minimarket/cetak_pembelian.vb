Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Globalization

Public Class cetak_pembelian

    Dim kasirIds As List(Of Integer)
    Private Sub cetak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ksr = newConnect.ExecuteReader("select id_kasir,nama_kasir from kasir")

        kasirbox.Items.Clear()
        kasirIds = New List(Of Integer)
        kasirIds.Clear()

        For j = 0 To ksr.Rows.Count - 1
            kasirIds.Add(ksr.Rows(j).ItemArray.GetValue(0))
            kasirbox.Items.Add(ksr.Rows(j).ItemArray.GetValue(1))
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
        If (kasirbox.SelectedIndex < 0) Then
            MsgBox("Pilih kasir terlebih dahulu")
            Return
        End If

        Dim rptDataSource As ReportDataSource
        Dim startDate = DateTime.ParseExact(txtStartDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", New Global.System.Globalization.CultureInfo("id-ID"))
        Console.WriteLine(startDate)
        Ds_report_pembelianTableAdapter1.FillByKasir(Minimarket_ds.ds_report_pembelian, kasirIds(kasirbox.SelectedIndex), startDate, DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", New Global.System.Globalization.CultureInfo("id-ID")))
        If (Minimarket_ds.ds_report_pembelian.Rows.Count = 0) Then
            MsgBox("Tidak ada transaksi pembelian yang dilakukan oleh " & kasirbox.Text & " dari tanggal " & txtStartDateTime.Text & " sampai tanggal " & txtEndDateTime.Text, MsgBoxStyle.OkOnly)
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket.rpt_pembelian.rdlc"
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            rptDataSource = New ReportDataSource("minimarket_ds", Minimarket_ds.Tables("ds_report_pembelian"))
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