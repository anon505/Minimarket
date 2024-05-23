Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Globalization

Public Class cetak_expiry

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim rptDataSource As ReportDataSource
        Ds_report_expiryTableAdapter1.FillByDay(Minimarket_ds.ds_report_expiry, Integer.Parse(txtCountDay.Text))
        If (Minimarket_ds.ds_report_expiry.Rows.Count = 0) Then
            MsgBox("Tidak ada barang yang KADALUARSA dalam " & txtCountDay.Text & " hari terakhir", MsgBoxStyle.OkOnly)
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket.rpt_expiry.rdlc"
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            rptDataSource = New ReportDataSource("minimarket_ds", Minimarket_ds.Tables("ds_report_expiry"))
            Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            Dim paramlist As New Generic.List(Of ReportParameter)
            paramlist.Clear()
            Me.ReportViewer1.LocalReport.EnableExternalImages = True
            paramlist.Add(New ReportParameter("expiryDay", txtCountDay.Text))
            Me.ReportViewer1.LocalReport.SetParameters(paramlist)
            Me.ReportViewer1.RefreshReport()
        End If
        'If (transbox.Text = "Penjualan") Then

        'ElseIf (transbox.Text = "Pembelian") Then
        '    Me.DataTable2TableAdapter.Fill(Me.Minimarketds.DataTable2, txtdatetime.Text, kasirbox.SelectedIndex + 1)
        '    If (Me.Minimarketds.DataTable2.Rows.Count = 0) Then
        '        MsgBox("Tidak ada transaksi pembelian yang dilakukan oleh " + kasirbox.Text + " pada tanggal " + txtdatetime.Text, MsgBoxStyle.OkOnly)
        '    Else
        '        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket.pembelian.rdlc"
        '        Me.ReportViewer1.LocalReport.DataSources.Clear()
        '        rptDataSource = New ReportDataSource("DataSet1", Minimarketds.Tables("DataTable2"))
        '        Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
        '        Dim paramlist As New Generic.List(Of ReportParameter)
        '        paramlist.Clear()
        '        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        '        paramlist.Add(New ReportParameter("tgl_lap", txtdatetime.Text))
        '        paramlist.Add(New ReportParameter("logoumam", "File:////" + pathlogo))
        '        paramlist.Add(New ReportParameter("namatoko", namatoko))
        '        Me.ReportViewer1.LocalReport.SetParameters(paramlist)
        '        Me.ReportViewer1.RefreshReport()
        '    End If
        'End If
    End Sub

    Private Sub kasirbox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class