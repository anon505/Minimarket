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
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        txtcari.Select()
        txtcari.Focus()
        txtcari.SelectionStart = txtcari.TextLength
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian Set id_supplier = '" & DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString & "' WHERE id_pembelian='" & frmPembelian.getIdPembelian(Module1.id_kasir) & "'", konek)
        updateTabel.ExecuteNonQuery()
        frmPembelian.textSupplier.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        frmPembelian.labelSupplier.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        frmPembelian.labelIdSuplier.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString

        frmPembelian.textPLU.Focus()
        Close()
    End Sub
End Class