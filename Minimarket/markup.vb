Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Crypto.Paddings
Imports Org.BouncyCastle.Pqc.Crypto

Public Class markup
    Private Sub dataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dataGridView1.CellFormatting
        'If (e.ColumnIndex = 5 Or e.ColumnIndex = 7 Or e.ColumnIndex = 9 Or e.ColumnIndex = 11 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15) AndAlso IsNumeric(e.Value) Then
        If (e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 9 Or e.ColumnIndex = 12 Or e.ColumnIndex = 15) AndAlso IsNumeric(e.Value) Then
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
        If noFaktur = "" And dataGridView1.DataBindings IsNot Nothing Then
            dataGridView1.DataBindings.Clear()
            Return
        End If

        Dim mySqlAdapter = New MySqlDataAdapter("select id_pembelian,no_faktur,id_barang,barcode, nama_barang,harga_beli_netto,harga_satuan,profit1,qty2,harga_qty2,profit2,qty3,harga_qty3,profit3,qty4,harga_qty4,profit4 from ds_markup  where no_faktur=" & noFaktur, konek)
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
        dataGridView1.Columns(6).ReadOnly = False
        dataGridView1.Columns(7).ReadOnly = False
        dataGridView1.Columns(8).ReadOnly = False
        dataGridView1.Columns(9).ReadOnly = False
        dataGridView1.Columns(10).ReadOnly = False
        dataGridView1.Columns(11).ReadOnly = False
        dataGridView1.Columns(12).ReadOnly = False
        dataGridView1.Columns(13).ReadOnly = False
        dataGridView1.Columns(14).ReadOnly = False
        dataGridView1.Columns(15).ReadOnly = False
        dataGridView1.Columns(16).ReadOnly = False

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
        dataGridView1.Columns(7).HeaderText = "Profit1"
        dataGridView1.Columns(8).HeaderText = "Q2"
        dataGridView1.Columns(9).HeaderText = "Harga Q2"
        dataGridView1.Columns(10).HeaderText = "Profit2"
        dataGridView1.Columns(11).HeaderText = "Q3"
        dataGridView1.Columns(12).HeaderText = "Harga Q3"
        dataGridView1.Columns(13).HeaderText = "Profit3"
        dataGridView1.Columns(14).HeaderText = "Q4"
        dataGridView1.Columns(15).HeaderText = "Harga Q4"
        dataGridView1.Columns(16).HeaderText = "Profit4"



        dataGridView1.Columns(3).Width = 108
        dataGridView1.Columns(4).Width = 208
        dataGridView1.Columns(5).Width = 108
        dataGridView1.Columns(6).Width = 108
        dataGridView1.Columns(7).Width = 88
        dataGridView1.Columns(8).Width = 58
        dataGridView1.Columns(9).Width = 108
        dataGridView1.Columns(10).Width = 88
        dataGridView1.Columns(11).Width = 58
        dataGridView1.Columns(12).Width = 108
        dataGridView1.Columns(13).Width = 88
        dataGridView1.Columns(14).Width = 58
        dataGridView1.Columns(15).Width = 108
        dataGridView1.Columns(16).Width = 88


        customizeCellsInColumn(6)
        customizeCellsInColumn(7)
        customizeCellsInColumn(8)
        customizeCellsInColumn(9)
        customizeCellsInColumn(10)
        customizeCellsInColumn(11)
        customizeCellsInColumn(12)
        customizeCellsInColumn(13)
        customizeCellsInColumn(14)
        customizeCellsInColumn(15)
        customizeCellsInColumn(16)
        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub
    Private Sub Tb_TextChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim tb As TextBox = TryCast(sender, TextBox)
        Console.WriteLine(tb.Tag)
        If tb.Text = "" OrElse tb.Text = "0" Then Return
        Dim columnIndex As Integer = tb.Tag
        Console.WriteLine(tb.Text)
        If (columnIndex = 6 Or columnIndex = 8 Or columnIndex = 9 Or columnIndex = 11 Or
            columnIndex = 12 Or columnIndex = 14 Or columnIndex = 15) Then
            Dim number As Decimal
            number = Decimal.Parse(tb.Text, System.Globalization.NumberStyles.Currency)
            tb.Text = number.ToString("#,0;-#,0")

            tb.SelectionStart = tb.Text.Length
        End If


    End Sub
    Private Sub customizeCellsInColumn(ByVal columnIndex As Integer)

        Dim column As DataGridViewColumn = dataGridView1.Columns(columnIndex)
        Dim cell = New DataGridViewTextBoxCell()
        cell.Style.BackColor = Color.Wheat
        If columnIndex = 7 Or columnIndex = 10 Or columnIndex = 13 Or columnIndex = 16 Then
            cell.Style.Format = "N2"
        End If
        column.CellTemplate = cell
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
    Dim tb As TextBox
    Private Sub dataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dataGridView1.EditingControlShowing
        tb = TryCast(e.Control, TextBox)

        Console.WriteLine("EditingControlShowing" & currentCellColumnIndex.ToString)
        RemoveHandler tb.TextChanged, AddressOf Tb_TextChanged
        'If (columnIndex = 6 Or columnIndex = 8 Or columnIndex = 9 Or columnIndex = 11 Or
        'columnIndex = 12 Or columnIndex = 14 Or columnIndex = 15) Then

        'tb.Tag = columnIndex
        'Else
        'tb.Tag = columnIndex
        'End If
        AddHandler tb.TextChanged, AddressOf Tb_TextChanged
    End Sub
    Dim currentCellColumnIndex = 0
    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        If tb IsNot Nothing And dataGridView1.CurrentCell IsNot Nothing Then
            currentCellColumnIndex = dataGridView1.CurrentCell.ColumnIndex
            tb.Tag = currentCellColumnIndex
        End If

        Console.WriteLine("currentCellChanged" & currentCellColumnIndex.ToString)
    End Sub
    Private Sub calculate(columnIndex As Integer, rowIndex As Integer)
        Dim priceNetto As Integer = Integer.Parse(dataGridView1.Rows(rowIndex).Cells(5).Value.ToString)
        If columnIndex = 6 Or columnIndex = 7 Then
            If columnIndex = 6 Then
                Dim hargaSatuan As Integer = Integer.Parse(dataGridView1.Rows(rowIndex).Cells(6).Value.ToString)

                Dim profit = ((hargaSatuan - priceNetto) / priceNetto) * 100
                dataGridView1.Rows(rowIndex).Cells(7).Value = Math.Round(profit, 2, MidpointRounding.AwayFromZero)
            ElseIf columnIndex = 7 Then
                Dim profit As Double = Double.Parse(dataGridView1.Rows(rowIndex).Cells(7).Value.ToString)
                Dim hargaSatuan As Integer = priceNetto + (priceNetto * (profit / 100))
                dataGridView1.Rows(rowIndex).Cells(6).Value = hargaSatuan
            End If
        ElseIf columnIndex = 9 Or columnIndex = 10 Then
            If columnIndex = 9 Then
                Dim hargaSatuan As Integer = Integer.Parse(dataGridView1.Rows(rowIndex).Cells(9).Value.ToString)

                Dim profit = ((hargaSatuan - priceNetto) / priceNetto) * 100
                dataGridView1.Rows(rowIndex).Cells(10).Value = Math.Round(profit, 2, MidpointRounding.AwayFromZero)
            ElseIf columnIndex = 10 Then
                Dim profit As Double = Double.Parse(dataGridView1.Rows(rowIndex).Cells(10).Value.ToString)
                Dim hargaSatuan As Integer = priceNetto + (priceNetto * (profit / 100))
                dataGridView1.Rows(rowIndex).Cells(9).Value = hargaSatuan
            End If
        ElseIf columnIndex = 12 Or columnIndex = 13 Then
            If columnIndex = 12 Then
                Dim hargaSatuan As Integer = Integer.Parse(dataGridView1.Rows(rowIndex).Cells(12).Value.ToString)

                Dim profit = ((hargaSatuan - priceNetto) / priceNetto) * 100
                dataGridView1.Rows(rowIndex).Cells(13).Value = Math.Round(profit, 2, MidpointRounding.AwayFromZero)
            ElseIf columnIndex = 13 Then
                Dim profit As Double = Double.Parse(dataGridView1.Rows(rowIndex).Cells(13).Value.ToString)
                Dim hargaSatuan As Integer = priceNetto + (priceNetto * (profit / 100))
                dataGridView1.Rows(rowIndex).Cells(12).Value = hargaSatuan
            End If
        ElseIf columnIndex = 15 Or columnIndex = 16 Then
            If columnIndex = 15 Then
                Dim hargaSatuan As Integer = Integer.Parse(dataGridView1.Rows(rowIndex).Cells(15).Value.ToString)

                Dim profit = ((hargaSatuan - priceNetto) / priceNetto) * 100
                dataGridView1.Rows(rowIndex).Cells(16).Value = Math.Round(profit, 2, MidpointRounding.AwayFromZero)
            ElseIf columnIndex = 16 Then
                Dim profit As Double = Double.Parse(dataGridView1.Rows(rowIndex).Cells(16).Value.ToString)
                Dim hargaSatuan As Integer = priceNetto + (priceNetto * (profit / 100))
                dataGridView1.Rows(rowIndex).Cells(15).Value = hargaSatuan
            End If
        End If

    End Sub
    Private Sub dataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellEndEdit
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            calculate(e.ColumnIndex, e.RowIndex)
        End If
    End Sub
End Class