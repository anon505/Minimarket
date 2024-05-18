Imports System.Globalization
Imports System.Threading.Tasks
Imports Microsoft.VisualBasic.Logging
Imports MySql.Data.MySqlClient
Imports Mysqlx.Crud
Imports Org.BouncyCastle.Utilities.IO
Public Class pembelian
    Dim noFaktorEdit As String
    Dim statusFaktorEdit As String

    Private Function getIdPembelian(ByVal idKasir As String) As String
        If noFaktorEdit IsNot Nothing Then
            Dim cekPembelianCmd As MySqlCommand = New MySqlCommand("SELECT id_pembelian from pembelian WHERE no_faktur=" & noFaktorEdit, konek)
            Dim idPembelian = cekPembelianCmd.ExecuteScalar
            Return idPembelian.ToString
        Else
            Dim cekPembelianCmd As MySqlCommand = New MySqlCommand("SELECT id_pembelian from pembelian WHERE status='temp' AND id_kasir=" & idKasir, konek)
            Dim idPembelian = cekPembelianCmd.ExecuteScalar
            If idPembelian Is Nothing Then
                Dim insertPembelian As MySqlCommand = New MySqlCommand("INSERT INTO `pembelian` (`id_pembelian`, `no_faktur`, `tgl_faktur`, `id_supplier`, `id_kasir`, `grand_total`, `metode_pembayaran`, `lama_jatuh_tempo`, `status`) VALUES (NULL, '', NOW(), '0', '" & idKasir & "', '0', '', '0', 'temp');", konek)
                insertPembelian.ExecuteNonQuery()
                Return getIdPembelian(idKasir)
            Else
                Return idPembelian.ToString
            End If
        End If

    End Function

    Private Sub inputUpdateBarang(ByVal barcode As String)

        Dim barangCmd As MySqlCommand = New MySqlCommand("SELECT * from barang WHERE barcode='" & barcode & "'", konek)
        Dim barangReader As MySqlDataReader = barangCmd.ExecuteReader()
        Dim idBarang As Integer
        Dim hargaBeli As Integer
        Dim ppn As Double
        Dim discount As Double
        Dim hargaBeliNetto As Integer
        If barangReader.Read Then
            idBarang = barangReader("id_barang")
            hargaBeli = barangReader("harga_beli")
            ppn = barangReader("ppn")
            discount = barangReader("discount")
            hargaBeliNetto = barangReader("harga_beli_netto")
            barangReader.Close()

            Dim currentQtyCmd As MySqlCommand = New MySqlCommand("SELECT qty from pembelian_detail WHERE id_barang='" & idBarang.ToString & "' AND id_pembelian=" & getIdPembelian(Module1.id_kasir), konek)
            Dim currentQty = currentQtyCmd.ExecuteScalar
            If currentQty Is Nothing Then
                currentQty = "1"
                Dim insertPembelianDetail As MySqlCommand = New MySqlCommand("INSERT INTO pembelian_detail (
id_pembelian_detail,id_pembelian,id_barang,qty,price,ppn,discount,price_netto)
VALUES (NULL,'" & getIdPembelian(Module1.id_kasir) & "', '" & idBarang & "', '" & currentQty.ToString & "', '" & hargaBeli.ToString & "', '" & ppn.ToString.Replace(",", ".") & "', '" & discount.ToString.Replace(",", ".") & "', '" & hargaBeliNetto.ToString & "')", konek)
                insertPembelianDetail.ExecuteNonQuery()
            Else
                currentQty = (Integer.Parse(currentQty.ToString) + 1).ToString
                Dim updateStokGudang As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set qty = '" & currentQty.ToString & "' WHERE id_barang = '" & idBarang.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
                updateStokGudang.ExecuteNonQuery()
            End If
            loadTable()
        End If
    End Sub

    Private Sub updateTable(ByVal idBarang As String, ByVal namaKolom As String, ByVal valueKolom As String)
        Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set " & namaKolom & " = '" & valueKolom.ToString & "' WHERE id_barang = '" & idBarang.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
        updateTabel.ExecuteNonQuery()
        loadTable()
    End Sub

    Private Sub dataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dataGridView1.CellFormatting
        'If (e.ColumnIndex = 5 Or e.ColumnIndex = 7 Or e.ColumnIndex = 9 Or e.ColumnIndex = 11 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15) AndAlso IsNumeric(e.Value) Then
        If (e.ColumnIndex = 5 Or e.ColumnIndex = 7 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15) AndAlso IsNumeric(e.Value) Then
            e.Value = Format(e.Value, "#,0;-#,0")
        End If
    End Sub
    Private Sub customizeCellsInColumn(ByVal columnIndex As Integer)

        Dim column As DataGridViewColumn = dataGridView1.Columns(columnIndex)
        Dim cell = New DataGridViewTextBoxCell()
        cell.Style.BackColor = Color.Wheat
        If columnIndex = 9 Or columnIndex = 11 Then
            cell.Style.Format = "N2"
        End If
        column.CellTemplate = cell
    End Sub
    Private Sub loadTable()
        Dim mySqlAdapter = New MySqlDataAdapter("select id_pembelian_detail,no_faktur,id_barang,barcode, nama_barang,qty,stok, harga,harga_lama,ppn,ppn_lama,discount,discount_lama,harga_netto,harga_netto_lama,total,expiry from ds_transaksi_pembelian  where id_pembelian=" & getIdPembelian(Module1.id_kasir), konek)
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
        dataGridView1.Columns(5).ReadOnly = False
        dataGridView1.Columns(6).ReadOnly = True
        dataGridView1.Columns(7).ReadOnly = False
        dataGridView1.Columns(8).ReadOnly = True
        dataGridView1.Columns(9).ReadOnly = False
        dataGridView1.Columns(10).ReadOnly = True
        dataGridView1.Columns(11).ReadOnly = False
        dataGridView1.Columns(12).ReadOnly = True
        dataGridView1.Columns(13).ReadOnly = True
        dataGridView1.Columns(14).ReadOnly = True
        dataGridView1.Columns(15).ReadOnly = True
        dataGridView1.Columns(16).ReadOnly = True

        dataGridView1.Columns(0).Visible = False
        dataGridView1.Columns(1).Visible = False
        dataGridView1.Columns(2).Visible = False

        dataGridView1.Columns(0).HeaderText = "id_pembelian_detail"
        dataGridView1.Columns(1).HeaderText = "no_faktur"
        dataGridView1.Columns(2).HeaderText = "id_barang"
        dataGridView1.Columns(3).HeaderText = "Barcode"
        dataGridView1.Columns(4).HeaderText = "Nama Barang"
        dataGridView1.Columns(5).HeaderText = "Qty"
        dataGridView1.Columns(6).HeaderText = "Stok"
        dataGridView1.Columns(7).HeaderText = "Harga"
        dataGridView1.Columns(8).HeaderText = "Harga Lama"
        dataGridView1.Columns(9).HeaderText = "PPn(%)"
        dataGridView1.Columns(10).HeaderText = "PPn Lama(%)"
        dataGridView1.Columns(10).DefaultCellStyle.Format = "N2"
        dataGridView1.Columns(11).HeaderText = "Discount(%)"
        dataGridView1.Columns(12).HeaderText = "Discount Lama(%)"
        dataGridView1.Columns(12).DefaultCellStyle.Format = "N2"
        dataGridView1.Columns(13).HeaderText = "Harga Netto"
        dataGridView1.Columns(14).HeaderText = "Harga Netto Lama"
        dataGridView1.Columns(15).HeaderText = "Total"
        dataGridView1.Columns(16).HeaderText = "Expired"
        dataGridView1.Columns(16).ValueType = GetType(Date)
        dataGridView1.Columns(16).DefaultCellStyle.Format = "dd/MM/yyyy"



        dataGridView1.Columns(3).Width = 108
        dataGridView1.Columns(4).Width = 208
        dataGridView1.Columns(5).Width = 108
        dataGridView1.Columns(6).Width = 108
        dataGridView1.Columns(7).Width = 108
        dataGridView1.Columns(8).Width = 108
        dataGridView1.Columns(9).Width = 108
        dataGridView1.Columns(10).Width = 108
        dataGridView1.Columns(11).Width = 108
        dataGridView1.Columns(12).Width = 138
        dataGridView1.Columns(13).Width = 108
        dataGridView1.Columns(14).Width = 158
        dataGridView1.Columns(15).Width = 158
        dataGridView1.Columns(16).Width = 158
        customizeCellsInColumn(5)
        customizeCellsInColumn(7)
        customizeCellsInColumn(9)
        customizeCellsInColumn(11)
        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
        Dim grandTotal = 0
        For i = 0 To dataGridView1.RowCount - 1
            grandTotal += Integer.Parse(dataGridView1.Rows(i).Cells(5).Value.
                                        ToString.Replace(".", "").
                                        Replace(",", "")) * Integer.
                                        Parse(dataGridView1.Rows(i).Cells(13).Value.ToString)
        Next
        textTotal.Text = Format(grandTotal, "#,0;-#,0")
    End Sub
    Private Sub textDiscount_KeyUp(sender As Object, e As KeyEventArgs) Handles textDiscount.KeyUp
        If e.KeyCode = Keys.Enter Then
            For i = 0 To dataGridView1.RowCount - 1
                dataGridView1.Rows(i).Cells(11).Value = textDiscount.Text.ToString

                Dim pembelianDetailCmd As MySqlCommand = New MySqlCommand("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(i).Cells(0).Value.ToString & "'", konek)
                Dim pembelianDetailReader As MySqlDataReader = pembelianDetailCmd.ExecuteReader()
                Dim price As Integer
                Dim ppn As Double
                Dim discount As Double = Double.Parse(dataGridView1.Rows(i).Cells(11).Value.ToString)
                Dim priceNetto As Integer
                If pembelianDetailReader.Read Then
                    price = pembelianDetailReader("price")
                    ppn = pembelianDetailReader("ppn")
                    Dim priceAfterPpn = (price + ((ppn / 100) * price))
                    priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    pembelianDetailReader.Close()
                End If
                dataGridView1.Rows(i).Cells(13).Value = priceNetto.ToString
                dataGridView1.Rows(i).Cells(15).Value = (Integer.Parse(dataGridView1.Rows(i).Cells(5).Value.
                                        ToString.Replace(".", "").
                                        Replace(",", "")) * priceNetto).ToString

                Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set discount = '" & discount.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(i).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
                updateTabel.ExecuteNonQuery()
            Next
            Dim grandTotal = 0
            For i = 0 To dataGridView1.RowCount - 1
                Dim subTotal = Integer.Parse(dataGridView1.Rows(i).Cells(15).Value.
                                    ToString.Replace(".", "").
                                    Replace(",", ""))
                grandTotal += subTotal
            Next
            textTotal.Text = Format(grandTotal, "#,0;-#,0")

        End If
    End Sub

    Private Sub textPpn_KeyUp(sender As Object, e As KeyEventArgs) Handles textPpn.KeyUp
        If e.KeyCode = Keys.Enter Then
            For i = 0 To dataGridView1.RowCount - 1
                dataGridView1.Rows(i).Cells(9).Value = textPpn.Text.ToString

                Dim pembelianDetailCmd As MySqlCommand = New MySqlCommand("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(i).Cells(0).Value.ToString & "'", konek)
                Dim pembelianDetailReader As MySqlDataReader = pembelianDetailCmd.ExecuteReader()
                Dim price As Integer
                Dim ppn As Double = Double.Parse(dataGridView1.Rows(i).Cells(9).Value.ToString)
                Dim discount As Double
                Dim priceNetto As Integer
                If pembelianDetailReader.Read Then
                    price = pembelianDetailReader("price")
                    discount = pembelianDetailReader("discount")
                    Dim priceAfterPpn = (price + ((ppn / 100) * price))
                    priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    pembelianDetailReader.Close()
                End If
                dataGridView1.Rows(i).Cells(13).Value = priceNetto.ToString
                dataGridView1.Rows(i).Cells(15).Value = (Integer.Parse(dataGridView1.Rows(i).Cells(5).Value.
                                        ToString.Replace(".", "").
                                        Replace(",", "")) * priceNetto).ToString

                Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set ppn = '" & ppn.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(i).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
                updateTabel.ExecuteNonQuery()
            Next
            Dim grandTotal = 0
            For i = 0 To dataGridView1.RowCount - 1
                Dim subTotal = Integer.Parse(dataGridView1.Rows(i).Cells(15).Value.
                                    ToString.Replace(".", "").
                                    Replace(",", ""))
                grandTotal += subTotal
            Next
            textTotal.Text = Format(grandTotal, "#,0;-#,0")
        End If
    End Sub
    Private Sub textPpn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textPpn.KeyPress
        If Char.IsControl(e.KeyChar) Then
        ElseIf Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ","c Then
            If textPpn.TextLength = 12 And textPpn.Text.Contains(",") = False Then
                textPpn.AppendText(",")
            ElseIf e.KeyChar = "," And textPpn.Text.IndexOf(",") <> -1 Then
                e.Handled = True
            ElseIf Char.IsDigit(e.KeyChar) Then
                If textPpn.Text.IndexOf(",") <> -1 Then
                    If textPpn.Text.Length >= textPpn.Text.IndexOf(",") + 3 Then
                        e.Handled = True
                    End If
                End If
            End If

        Else
            e.Handled = True
        End If
    End Sub
    Private Sub textDiscount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textDiscount.KeyPress
        If Char.IsControl(e.KeyChar) Then
        ElseIf Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ","c Then
            If textDiscount.TextLength = 12 And textDiscount.Text.Contains(",") = False Then
                textDiscount.AppendText(",")
            ElseIf e.KeyChar = "," And textDiscount.Text.IndexOf(",") <> -1 Then
                e.Handled = True
            ElseIf Char.IsDigit(e.KeyChar) Then
                If textDiscount.Text.IndexOf(",") <> -1 Then
                    If textDiscount.Text.Length >= textDiscount.Text.IndexOf(",") + 3 Then
                        e.Handled = True
                    End If
                End If
            End If

        Else
            e.Handled = True
        End If
    End Sub
    Private Sub pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        textTanggal.Text = DateTime.Now.ToString("dd MMMM yyyy")

        If noFaktorEdit IsNot Nothing Then
            textSupplier.Enabled = False
            textNoFaktur.Enabled = False
            btnEditFaktor.Text = "Kembali"
            buttonNew.Enabled = False
            If statusFaktorEdit = "mark_up" Then
                buttonSave.Enabled = False
                comboPembayaran.Enabled = False
                textTempoHari.Enabled = False
                buttonDelete.Enabled = False
                textPpn.Enabled = False
                textDiscount.Enabled = False
            End If
        Else
            textTempoHari.Text = ""
            textTempoHari.Enabled = False
            textSupplier.Select()
        End If
        loadTable()
    End Sub


    Private Sub textSupplier_TextChanged(sender As Object, e As EventArgs) Handles textSupplier.TextChanged
        If textSupplier.Text IsNot "" And popup_supplier.Visible = False And noFaktorEdit Is Nothing Then
            popup_supplier.frmPembelian = Me
            popup_supplier.txtcari.Text = textSupplier.Text
            popup_supplier.Show()
        End If
    End Sub

    Private Sub comboPembayaran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPembayaran.SelectedIndexChanged
        Dim selectPembayaran = comboPembayaran.SelectedItem
        If selectPembayaran IsNot Nothing Then
            If selectPembayaran.ToLower = "tunai" Then
                textTempoHari.Text = ""
                textJatuhTempo.Text = ""
                textTempoHari.Enabled = False
            Else
                textTempoHari.Enabled = True
            End If
        End If

    End Sub

    Private Sub textTempoHari_TextChanged(sender As Object, e As EventArgs) Handles textTempoHari.TextChanged
        If Integer.TryParse(textTempoHari.Text.ToString, Nothing) Then
            textJatuhTempo.Text = DateTime.Now.AddDays(Integer.Parse(textTempoHari.Text)).ToString("dd MMMM yyyy")
        End If

    End Sub

    Private Sub buttonScan1_Click(sender As Object, e As EventArgs) Handles buttonScan1.Click
        inputUpdateBarang("11")

    End Sub

    Private Sub buttonScan2_Click(sender As Object, e As EventArgs) Handles buttonScan2.Click
        inputUpdateBarang("22")
    End Sub

    Private Sub buttonScan3_Click(sender As Object, e As EventArgs) Handles buttonScan3.Click
        inputUpdateBarang("33")
    End Sub

    Private Sub buttonScan4_Click(sender As Object, e As EventArgs) Handles buttonScan4.Click
        inputUpdateBarang("44")
    End Sub

    Private Sub buttonScan5_Click(sender As Object, e As EventArgs) Handles buttonScan5.Click
        inputUpdateBarang("55")
    End Sub
    Private Sub Tb_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)

        If tb.Text = "" OrElse tb.Text = "0" Then Return
        Dim number As Decimal
        number = Decimal.Parse(tb.Text, System.Globalization.NumberStyles.Currency)
        tb.Text = number.ToString("#,#")
        tb.SelectionStart = tb.Text.Length

    End Sub

    Private Sub dataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dataGridView1.EditingControlShowing
        If TypeOf e.Control Is TextBox And (dataGridView1.CurrentCell.ColumnIndex = 5 Or dataGridView1.CurrentCell.ColumnIndex = 7) Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)

            RemoveHandler tb.TextChanged, AddressOf Tb_TextChanged
            AddHandler tb.TextChanged, AddressOf Tb_TextChanged
        End If
    End Sub

    Private Sub dataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellValueChanged
        '5(qty), 7(harga), 9(ppn), 11(discount)
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            If e.ColumnIndex = 5 Then
                Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set qty = '" & dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
                updateTabel.ExecuteNonQuery()
                loadTable()
            ElseIf e.ColumnIndex = 7 Then
                Dim pembelianDetailCmd As MySqlCommand = New MySqlCommand("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString & "'", konek)
                Dim pembelianDetailReader As MySqlDataReader = pembelianDetailCmd.ExecuteReader()
                Dim price As Integer = Integer.Parse(dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
                Dim ppn As Double
                Dim discount As Double
                Dim priceNetto As Integer
                If pembelianDetailReader.Read Then
                    ppn = pembelianDetailReader("ppn")
                    discount = pembelianDetailReader("discount")
                    Dim priceAfterPpn = (price + ((ppn / 100) * price))
                    priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    pembelianDetailReader.Close()
                End If
                Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set price = '" & price.ToString & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
                updateTabel.ExecuteNonQuery()
                loadTable()
            ElseIf e.ColumnIndex = 9 Then
                Dim pembelianDetailCmd As MySqlCommand = New MySqlCommand("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString & "'", konek)
                Dim pembelianDetailReader As MySqlDataReader = pembelianDetailCmd.ExecuteReader()
                Dim price As Integer
                Dim ppn As Double = Double.Parse(dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
                Dim discount As Double
                Dim priceNetto As Integer
                If pembelianDetailReader.Read Then
                    price = pembelianDetailReader("price")
                    discount = pembelianDetailReader("discount")
                    Dim priceAfterPpn = (price + ((ppn / 100) * price))
                    priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    pembelianDetailReader.Close()
                End If
                Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set ppn = '" & ppn.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
                updateTabel.ExecuteNonQuery()
                loadTable()
            ElseIf e.ColumnIndex = 11 Then
                Dim pembelianDetailCmd As MySqlCommand = New MySqlCommand("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString & "'", konek)
                Dim pembelianDetailReader As MySqlDataReader = pembelianDetailCmd.ExecuteReader()
                Dim price As Integer
                Dim ppn As Double
                Dim discount As Double = Double.Parse(dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
                Dim priceNetto As Integer
                If pembelianDetailReader.Read Then
                    price = pembelianDetailReader("price")
                    ppn = pembelianDetailReader("ppn")
                    Dim priceAfterPpn = (price + ((ppn / 100) * price))
                    priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    pembelianDetailReader.Close()
                End If
                Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set discount = '" & discount.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
                updateTabel.ExecuteNonQuery()
                loadTable()
            End If


        End If

    End Sub
    Private Sub savePembelian()
        'Dim mySqlAdapter = New MySqlDataAdapter("SELECT * from pembelian_detail WHERE id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
        'Dim ds = New DataTable()
        'mySqlAdapter.Fill(ds)
        'For i = 0 To ds.Rows.Count - 1
        '    Dim idBarang = ds.Rows(i).Item("id_barang").ToString
        '    Dim qty = ds.Rows(i).Item("qty").ToString
        '    Dim ppn = ds.Rows(i).Item("ppn").ToString.Replace(",", ".")
        '    Dim discount = ds.Rows(i).Item("discount").ToString.Replace(",", ".")
        '    Dim price = ds.Rows(i).Item("price").ToString
        '    Dim priceNetto = ds.Rows(i).Item("price_netto").ToString
        '    Dim updateItemPembelian As MySqlCommand = New MySqlCommand("Update barang Set ppn = '" & ppn & "',discount = '" & discount & "',
        '        stok_gudang = stok_gudang+" & qty & ",harga_beli='" & price & "',harga_beli_netto='" & priceNetto & "' WHERE id_barang = " & idBarang, konek)
        '    updateItemPembelian.ExecuteNonQuery()
        'Next

        Dim metodePembayaran = ""
        If comboPembayaran.SelectedIndex = 0 Then
            metodePembayaran = "tunai"
        End If
        If comboPembayaran.SelectedIndex = 1 Then
            metodePembayaran = "kredit"
        End If
        If comboPembayaran.SelectedIndex = 2 Then
            metodePembayaran = "konsinyasi"
        End If
        Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian SET no_faktur = '" & textNoFaktur.Text & "',grand_total = '" & textTotal.Text.Replace(",", "").Replace(".", "") & "', 
metode_pembayaran = '" & metodePembayaran & "',id_supplier='" & labelIdSuplier.Text & "', lama_jatuh_tempo = '" & textTempoHari.Text & "',status = 'saved' WHERE id_pembelian = " & getIdPembelian(Module1.id_kasir), konek)
        updateTabel.ExecuteNonQuery()
        If noFaktorEdit IsNot Nothing Then
            MsgBox("Faktur pembelian berhasil diedit", MsgBoxStyle.OkOnly)
        Else
            loadTable()

            textNoFaktur.Text = ""
            textSupplier.Text = ""
            labelSupplier.Text = ""
            labelIdSuplier.Text = ""
            comboPembayaran.SelectedIndex = -1
            textTempoHari.Text = ""
            textJatuhTempo.Text = ""
            textDiscount.Text = ""
            textPpn.Text = ""
            textTotal.Text = ""
            MsgBox("Faktur pembelian berhasil disimpan", MsgBoxStyle.OkOnly)
        End If


    End Sub
    Private Sub fakturBaru()
        Dim deletePembelianDetailCmd = New MySqlCommand("DELETE from pembelian_detail WHERE id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
        deletePembelianDetailCmd.ExecuteNonQuery()
        Dim deletePembelianCmd = New MySqlCommand("DELETE from pembelian WHERE id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
        deletePembelianCmd.ExecuteNonQuery()

        loadTable()
        textNoFaktur.Text = ""
        textSupplier.Text = ""
        labelSupplier.Text = ""
        labelIdSuplier.Text = ""
        comboPembayaran.SelectedIndex = -1
        textTempoHari.Text = ""
        textJatuhTempo.Text = ""
        textDiscount.Text = ""
        textPpn.Text = ""
        textTotal.Text = ""
    End Sub
    Private Function getIdDariTabel() As String
        Dim idTransaksiDetail = ""
        If dataGridView1.SelectedRows.Count > 0 Then
            idTransaksiDetail = dataGridView1.SelectedRows(0).Cells(0).Value.ToString
        Else
            Dim lastRow = dataGridView1.Rows.Count - 1
            If lastRow >= 0 Then
                idTransaksiDetail = dataGridView1.Rows(lastRow).Cells(0).Value.ToString
            End If

        End If
        Return idTransaksiDetail
    End Function
    Private Sub pembelian_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Delete Then
            deleteTransaksiDetail()
        End If
    End Sub
    Private Sub deleteTransaksiDetail()
        Console.WriteLine(dataGridView1.SelectedRows.Count)

        If getIdDariTabel() IsNot "" Then
            Dim deleteTransaksiDetail As MySqlCommand = New MySqlCommand("DELETE from pembelian_detail 
WHERE id_pembelian_detail = " & getIdDariTabel(), konek)
            deleteTransaksiDetail.ExecuteNonQuery()
            loadTable()
        End If

    End Sub
    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        If labelIdSuplier.Text = "" Then
            MsgBox("Silahkan pilih supplier", MsgBoxStyle.OkOnly)
        ElseIf textNoFaktur.Text = "" Then
            MsgBox("Silahkan masukkan nomor faktur", MsgBoxStyle.OkOnly)
        ElseIf comboPembayaran.SelectedIndex < 0 Then
            MsgBox("Silahkan pilih pembayaran", MsgBoxStyle.OkOnly)
        ElseIf comboPembayaran.SelectedIndex > 0 And textTempoHari.Text = "" Then
            MsgBox("Silahkan masukkan lama tempo dalam hari", MsgBoxStyle.OkOnly)
        ElseIf dataGridView1.Rows.Count = 0 Then
            MsgBox("Silahkan masukkan produknya", MsgBoxStyle.OkOnly)
        Else

            Dim result As DialogResult = MessageBox.Show("PASTIKAN DATA SUDAH BENAR, apakah anda yakin ingin menyimpannya?",
                              "Konfirmasi",
                              MessageBoxButtons.YesNo)

            If (result = DialogResult.Yes) Then
                savePembelian()
            End If
        End If
    End Sub

    Private Sub buttonNew_Click(sender As Object, e As EventArgs) Handles buttonNew.Click
        If dataGridView1.RowCount > 0 Then
            Dim result As DialogResult = MessageBox.Show("DATA BELUM DISIMPAN, apakah anda yakin ingin menyimpannya?",
                              "Konfirmasi",
                              MessageBoxButtons.YesNo)

            If (result = DialogResult.Yes) Then
                If labelIdSuplier.Text = "" Then
                    MsgBox("Silahkan pilih supplier", MsgBoxStyle.OkOnly)
                ElseIf textNoFaktur.Text = "" Then
                    MsgBox("Silahkan masukkan nomor faktur", MsgBoxStyle.OkOnly)
                ElseIf comboPembayaran.SelectedIndex < 0 Then
                    MsgBox("Silahkan pilih pembayaran", MsgBoxStyle.OkOnly)
                ElseIf comboPembayaran.SelectedIndex > 0 And textTempoHari.Text = "" Then
                    MsgBox("Silahkan masukkan lama tempo dalam hari", MsgBoxStyle.OkOnly)
                ElseIf dataGridView1.Rows.Count = 0 Then
                    MsgBox("Silahkan masukkan produknya", MsgBoxStyle.OkOnly)
                Else
                    savePembelian()
                End If
            ElseIf (result = DialogResult.No) Then
                fakturBaru()
            End If
        Else
            fakturBaru()


        End If
    End Sub

    Private Sub buttonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
        deleteTransaksiDetail()
    End Sub

    Private Sub btnEditFaktor_Click(sender As Object, e As EventArgs) Handles btnEditFaktor.Click
        If btnEditFaktor.Text.ToLower = "kembali" Then
            Dim newPembelian = New pembelian

            newPembelian.MdiParent = main
            newPembelian.Show()
            Me.Close()
        Else
            If textNoFaktur.Text = "" Then
                MsgBox("Masukkan NO FAKTUR terlebih dahulu")
            ElseIf textSupplier.Text = "" Or labelIdSuplier.Text = "" Or labelSupplier.Text = "" Then
                MsgBox("Harap PILIH suplier terlebih dahulu")
            Else
                Dim cekFakturCmd As MySqlCommand = New MySqlCommand("SELECT id_pembelian from pembelian WHERE  no_faktur='" & textNoFaktur.Text & "' and id_supplier='" & labelIdSuplier.Text & "'", konek)
                Dim idPembelian = cekFakturCmd.ExecuteScalar
                If idPembelian Is Nothing Then
                    MsgBox("Faktur tidak ditemukan")
                Else
                    Dim cekPembelianCmd As MySqlCommand = New MySqlCommand("SELECT * from pembelian WHERE  no_faktur='" & textNoFaktur.Text & "' and id_supplier='" & labelIdSuplier.Text & "'", konek)
                    Dim pembelianReader As MySqlDataReader = cekPembelianCmd.ExecuteReader()
                    If pembelianReader.Read Then
                        Dim newPembelian = New pembelian
                        If pembelianReader("metode_pembayaran") IsNot Nothing And pembelianReader("metode_pembayaran") IsNot "" Then
                            If pembelianReader("metode_pembayaran").ToString = "tunai" Then
                                newPembelian.comboPembayaran.SelectedIndex = 0
                            End If
                            If pembelianReader("metode_pembayaran").ToString = "kredit" Then
                                newPembelian.comboPembayaran.SelectedIndex = 1
                                newPembelian.textTempoHari.Text = pembelianReader("lama_jatuh_tempo").ToString
                                If Integer.TryParse(newPembelian.textTempoHari.Text.ToString, Nothing) Then
                                    newPembelian.textJatuhTempo.Text = DateTime.Now.AddDays(Integer.Parse(newPembelian.textTempoHari.Text)).ToString("dd MMMM yyyy")
                                End If
                            End If
                            If pembelianReader("metode_pembayaran").ToString = "konsinyasi" Then
                                newPembelian.comboPembayaran.SelectedIndex = 2
                                newPembelian.textTempoHari.Text = pembelianReader("lama_jatuh_tempo").ToString
                                If Integer.TryParse(newPembelian.textTempoHari.Text.ToString, Nothing) Then
                                    newPembelian.textJatuhTempo.Text = DateTime.Now.AddDays(Integer.Parse(newPembelian.textTempoHari.Text)).ToString("dd MMMM yyyy")
                                End If
                            End If
                        End If
                        pembelianReader.Close()
                        Dim cekFakturSTatusCmd As MySqlCommand = New MySqlCommand("SELECT status from pembelian WHERE  no_faktur='" & textNoFaktur.Text & "' and id_supplier='" & labelIdSuplier.Text & "'", konek)
                        newPembelian.statusFaktorEdit = cekFakturSTatusCmd.ExecuteScalar
                        newPembelian.noFaktorEdit = Me.textNoFaktur.Text
                        newPembelian.textNoFaktur.Text = Me.textNoFaktur.Text
                        newPembelian.textSupplier.Text = Me.textSupplier.Text
                        newPembelian.labelSupplier.Text = Me.labelSupplier.Text
                        newPembelian.labelIdSuplier.Text = Me.labelIdSuplier.Text
                        newPembelian.Text = "pembelian - edit faktur"
                        newPembelian.MdiParent = main
                        newPembelian.Show()
                        Me.Close()
                    End If

                End If

            End If
        End If



    End Sub
    Dim oDateTimePicker As DateTimePicker
    Private Sub dataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        If e.ColumnIndex = 16 Then


            oDateTimePicker = New DateTimePicker()
            dataGridView1.Controls.Add(oDateTimePicker)
            oDateTimePicker.Format = DateTimePickerFormat.Short
            Dim orectangle As Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            oDateTimePicker.Size = New Size(orectangle.Width, orectangle.Height)
            oDateTimePicker.Location = New Point(orectangle.X, orectangle.Y)
            AddHandler oDateTimePicker.CloseUp, AddressOf oDateTimePicker_CloseUp
            AddHandler oDateTimePicker.TextChanged, AddressOf dateTimePicker_OnTextChange
            oDateTimePicker.Visible = True
        End If
    End Sub

    Private Sub dateTimePicker_OnTextChange(ByVal sender As Object, ByVal e As EventArgs)
        Dim cell = dataGridView1.CurrentCell
        Dim newDate As Date = Date.ParseExact(oDateTimePicker.Text.ToString(), "dd/MM/yyyy",
        System.Globalization.DateTimeFormatInfo.InvariantInfo)
        dataGridView1.Rows(cell.RowIndex).Cells(16).Value = newDate

        Dim updateTabel As MySqlCommand = New MySqlCommand("UPDATE pembelian_detail Set expiry = '" & newDate.ToString("yyyy-MM-dd") & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(cell.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
        updateTabel.ExecuteNonQuery()
    End Sub
    Private Sub oDateTimePicker_CloseUp(ByVal sender As Object, ByVal e As EventArgs)
        oDateTimePicker.Visible = False
    End Sub
End Class