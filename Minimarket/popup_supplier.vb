Imports MySql.Data.MySqlClient

Public Class popup_supplier
    Public frmPembelian As pembelian
    Private Sub popup_supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcari.Select(txtcari.Text.Length, 0)
        txtcari.Select(0, 0)
        bacaData(txtcari.Text)
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        bacaData(txtcari.Text)
    End Sub

    Private Sub bacaData(ByVal keyword As String)
        Dim mySqlAdapter = New MySqlDataAdapter("SELECT *  FROM supplier WHERE kode_suplier LIKE '%" & keyword & "%' or nama_suplier LIKE '%" & keyword & "%'", konek)
        Dim ds = New DataTable()
        mySqlAdapter.Fill(ds)
        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        frmPembelian.textSupplier.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        frmPembelian.labelSupplier.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        frmPembelian.labelIdSuplier.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        Close()
    End Sub
End Class