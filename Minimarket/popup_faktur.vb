Imports MySql.Data.MySqlClient

Public Class popup_faktur
    Private Sub popup_faktur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcari.Select(txtcari.Text.Length, 0)
        txtcari.Select(0, 0)
        bacaData(txtcari.Text)
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        bacaData(txtcari.Text)
    End Sub

    Private Sub bacaData(ByVal keyword As String)
        Dim mySqlAdapter = New MySqlDataAdapter("SELECT id_pembelian,no_faktur,tgl_faktur,supplier.id_suplier as id_supplier,supplier.kode_suplier as kode_supplier,supplier.nama_suplier as nama_suplier FROM `pembelian` JOIN supplier on pembelian.id_supplier=supplier.id_suplier where no_faktur like '%" & keyword & "%' or nama_suplier LIKE '%" & keyword & "%'", konek)
        Dim ds = New DataTable()
        mySqlAdapter.Fill(ds)
        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        markup.textKodeSuplier.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
        markup.textNamaSuplier.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
        markup.textTanggal.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        markup.textNoFaktur.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        markup.loadTable(markup.textNoFaktur.Text)
        Close()
    End Sub
End Class