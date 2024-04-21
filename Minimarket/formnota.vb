Imports Microsoft.Reporting.WinForms
Public Class formnota

    Private Sub formnota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Minimarketds.kasir' table. You can move, or remove it, as needed.
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Me.NotaTableAdapter.Fill(Me.Minimarketds.nota, id_kasir)
        'TODO: This line of code loads data into the 'minimarketDataSet1.nota' table. You can move, or remove it, as needed.
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