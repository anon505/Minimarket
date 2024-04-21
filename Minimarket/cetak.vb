Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class cetak

    Private Sub cetak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim kasircmd As MySqlCommand = New MySqlCommand("select id_kasir,nama_kasir from kasir", konek)
        Dim ksr As DataSet = New DataSet
        Dim ksrda As MySqlDataAdapter = New MySqlDataAdapter
        Dim j As Integer
        ksrda.SelectCommand = kasircmd
        ksrda.Fill(ksr, "kasir")
        kasirbox.Items.Clear()
        For j = 0 To ksr.Tables("kasir").Rows.Count - 1
            kasirbox.Items.Add(ksr.Tables("kasir").Rows(j).ItemArray.GetValue(1))
        Next
        txtdatetime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtdatetime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click 
        Dim rptDataSource As ReportDataSource
        If (transbox.Text = "Penjualan") Then
            Me.DataTable1TableAdapter.Fill(Me.Minimarketds.DataTable1, txtdatetime.Text, kasirbox.SelectedIndex + 1)
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
            Me.DataTable2TableAdapter.Fill(Me.Minimarketds.DataTable2, txtdatetime.Text, kasirbox.SelectedIndex + 1)
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