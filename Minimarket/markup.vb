Imports MySql.Data.MySqlClient

Public Class markup
    Private Sub dataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dataGridView1.CellFormatting
        'If (e.ColumnIndex = 5 Or e.ColumnIndex = 7 Or e.ColumnIndex = 9 Or e.ColumnIndex = 11 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15) AndAlso IsNumeric(e.Value) Then
        If (e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Or e.ColumnIndex = 10 Or e.ColumnIndex = 12) AndAlso IsNumeric(e.Value) Then
            e.Value = Format(e.Value, "#,0;-#,0")
        End If
    End Sub
    Private Sub loadPembelian(ByVal noFaktur As String)
        Dim pembelianCmd As MySqlCommand = New MySqlCommand("SELECT id_pembelian,no_faktur,tgl_faktur,supplier.id_suplier as id_supplier,supplier.kode_suplier as kode_supplier,supplier.nama_suplier as nama_suplier FROM `pembelian` JOIN supplier on pembelian.id_supplier=supplier.id_suplier where no_faktur='" & noFaktur & "'", konek)
        Dim pembelianReader As MySqlDataReader = pembelianCmd.ExecuteReader()
        If pembelianReader.Read Then
            textKodeSuplier.Text = pembelianReader("kode_supplier").ToString
            textNamaSuplier.Text = pembelianReader("nama_suplier").ToString
            textTanggal.Text = pembelianReader("tgl_faktur").ToString
        End If
        pembelianReader.Close()
    End Sub
    Public Sub loadTable(ByVal noFaktur As String)
        Dim mySqlAdapter = New MySqlDataAdapter("select id_pembelian,no_faktur,id_barang,barcode, nama_barang,harga_beli_netto,harga_satuan,qty2,harga_qty2,qty3,harga_qty3,qty4,harga_qty4 from ds_markup  where no_faktur=" & noFaktur, konek)
        Dim ds = New DataTable()
        mySqlAdapter.Fill(ds)

        dataGridView1.AutoGenerateColumns = True
        dataGridView1.DataSource = ds
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dataGridView1.Columns(0).ReadOnly = True
        dataGridView1.Columns(1).ReadOnly = True
        dataGridView1.Columns(2).ReadOnly = True
        dataGridView1.Columns(3).ReadOnly = True
        dataGridView1.Columns(4).ReadOnly = True
        dataGridView1.Columns(5).ReadOnly = True
        dataGridView1.Columns(6).ReadOnly = True
        dataGridView1.Columns(7).ReadOnly = True
        dataGridView1.Columns(8).ReadOnly = True
        dataGridView1.Columns(9).ReadOnly = True
        dataGridView1.Columns(10).ReadOnly = True
        dataGridView1.Columns(11).ReadOnly = True
        dataGridView1.Columns(12).ReadOnly = True

        dataGridView1.Columns(0).Visible = False
        dataGridView1.Columns(1).Visible = False
        dataGridView1.Columns(2).Visible = False

        dataGridView1.Columns(0).HeaderText = "id_pembelian_detail"
        dataGridView1.Columns(1).HeaderText = "no_faktur"
        dataGridView1.Columns(2).HeaderText = "id_barang"
        dataGridView1.Columns(3).HeaderText = "Barcode"
        dataGridView1.Columns(4).HeaderText = "Nama Barang"
        dataGridView1.Columns(5).HeaderText = "Harga Beli Netto"
        dataGridView1.Columns(6).HeaderText = "Harga Satuan"
        dataGridView1.Columns(7).HeaderText = "Q2"
        dataGridView1.Columns(8).HeaderText = "Harga Q2"
        dataGridView1.Columns(9).HeaderText = "Q3"
        dataGridView1.Columns(10).HeaderText = "Harga Q3"
        dataGridView1.Columns(11).HeaderText = "Q4"
        dataGridView1.Columns(12).HeaderText = "Harga Q4"



        dataGridView1.Columns(3).Width = 108
        dataGridView1.Columns(4).Width = 208
        dataGridView1.Columns(5).Width = 108
        dataGridView1.Columns(6).Width = 108
        dataGridView1.Columns(7).Width = 58
        dataGridView1.Columns(8).Width = 108
        dataGridView1.Columns(9).Width = 58
        dataGridView1.Columns(10).Width = 108
        dataGridView1.Columns(11).Width = 58
        dataGridView1.Columns(12).Width = 108

        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub

    Private Sub textNoFaktur_TextChanged(sender As Object, e As EventArgs) Handles textNoFaktur.TextChanged
        loadPembelian(textNoFaktur.Text)
        loadTable(textNoFaktur.Text)
    End Sub

    Private Sub pembelian_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            popup_faktur.txtcari.Text = textNoFaktur.Text
            popup_faktur.Show()
        End If
    End Sub

End Class