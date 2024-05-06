Imports System.Threading.Tasks
Imports MySql.Data.MySqlClient
Imports Mysqlx.Crud
Public Class pembelian

    Private Function getIdPembelian(ByVal idKasir As String) As String
        Dim cekPembelianCmd As MySqlCommand = New MySqlCommand("SELECT id_pembelian from pembelian WHERE status='temp' AND id_kasir=" & idKasir, konek)
        Dim idPembelian = cekPembelianCmd.ExecuteScalar
        If idPembelian Is Nothing Then
            Dim insertPembelian As MySqlCommand = New MySqlCommand("INSERT INTO `pembelian` (`id_pembelian`, `no_faktur`, `tgl_faktur`, `id_supplier`, `id_kasir`, `grand_total`, `metode_pembayaran`, `lama_jatuh_tempo`, `status`) VALUES (NULL, '', NOW(), '0', '" & idKasir & "', '0', '', '0', 'temp');", konek)
            insertPembelian.ExecuteNonQuery()
            Return getIdPembelian(idKasir)
        Else
            Return idPembelian.ToString
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
        Dim mySqlAdapter = New MySqlDataAdapter("select id_pembelian_detail,no_faktur,id_barang,barcode, nama_barang,qty,stok, harga,harga_lama,ppn,ppn_lama,discount,discount_lama,harga_netto,harga_netto_lama,total from ds_transaksi_pembelian  where id_pembelian=" & getIdPembelian(Module1.id_kasir), konek)
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
        textTempoHari.Text = ""
        textTempoHari.Enabled = False
        textSupplier.Select()

        loadTable()
    End Sub


    Private Sub textSupplier_TextChanged(sender As Object, e As EventArgs) Handles textSupplier.TextChanged
        If textSupplier.Text IsNot "" And popup_supplier.Visible = False Then
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
            End If

            loadTable()
        End If

    End Sub
    Private Sub savePembelian()
        Dim mySqlAdapter = New MySqlDataAdapter("SELECT * from pembelian_detail WHERE id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'", konek)
        Dim ds = New DataTable()
        mySqlAdapter.Fill(ds)
        For i = 0 To ds.Rows.Count - 1
            Dim idBarang = ds.Rows(i).Item("id_barang").ToString
            Dim qty = ds.Rows(i).Item("qty").ToString
            Dim ppn = ds.Rows(i).Item("ppn").ToString.Replace(",", ".")
            Dim discount = ds.Rows(i).Item("discount").ToString.Replace(",", ".")
            Dim price = ds.Rows(i).Item("price").ToString
            Dim priceNetto = ds.Rows(i).Item("price_netto").ToString
            Dim updateItemPembelian As MySqlCommand = New MySqlCommand("Update barang Set ppn = '" & ppn & "',discount = '" & discount & "',
                stok_gudang = stok_gudang+" & qty & ",harga_beli='" & price & "',harga_beli_netto='" & priceNetto & "' WHERE id_barang = " & idBarang, konek)
            updateItemPembelian.ExecuteNonQuery()
        Next

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


    'Public Sub baru()
    '    Dim sql As MySqlCommand = New MySqlCommand("SELECT pembelian.id_barang, barang.nama_barang, barang.harga_beli, pembelian.jumlah,satuan.nama_satuan FROM pembelian ,barang,satuan where barang.id_barang = pembelian.id_barang and pembelian.status='belum' and satuan.id_satuan=barang.satuan and pembelian.id_kasir = " + Label9.Text, konek)
    '    Dim ds As DataSet = New DataSet
    '    Dim da As MySqlDataAdapter = New MySqlDataAdapter
    '    da.SelectCommand = sql
    '    da.Fill(ds, "notabeli")
    '    DataGridView1.DataSource = ds
    '    DataGridView1.DataMember = "notabeli"
    '    id_barang.Text = ""
    'End Sub

    'Private Sub pembelian_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Label9.Text = id_kasir
    '    Label7.Text = hak_akses
    '    Me.Text = "Pembelian dengan Kasir" + id_kasir
    '    Call baru()
    'End Sub

    'Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Call beli(e)
    'End Sub
    'Public Sub beli(ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim tombol As Integer = Asc(e.KeyChar)
    '    If tombol = 13 And Not (txtharga.Text = "") Then
    '        total.Tag += Val(txtharga.Tag) * Val(jumlah.Text)
    '        total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")

    '        Dim ada As MySqlCommand = New MySqlCommand("select id_barang from pembelian where id_barang='" + txtid.Text + "' and status='belum' and id_kasir='" + Label9.Text + "'", konek)
    '        Dim status As String = ada.ExecuteScalar()
    '        If Not (status = "") Then
    '            Dim update As MySqlCommand = New MySqlCommand(" UPDATE  barang SET  stok =  stok+" + jumlah.Text + " WHERE  id_barang =" + txtid.Text + ";", konek)
    '            update.ExecuteNonQuery()
    '            Dim update1 As MySqlCommand = New MySqlCommand(" UPDATE  pembelian SET  jumlah =  jumlah+" + jumlah.Text + " WHERE  id_barang ='" + txtid.Text + "'  and status='belum' and id_kasir='" + Label9.Text + "';", konek)
    '            update1.ExecuteNonQuery()
    '            Call baru()
    '        Else
    '            Dim input As MySqlCommand = New MySqlCommand("insert into pembelian(id_barang,id_kasir,tgl_pembelian,jumlah,status)values('" + txtid.Text + "','" + Label9.Text + "',now(),'" + jumlah.Text + "','belum')", konek)
    '            input.ExecuteNonQuery()
    '            Call baru()
    '        End If
    '    End If
    'End Sub

    'Private Sub txtid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim cmd As MySqlCommand = New MySqlCommand("Select harga_beli from barang where id_barang='" + txtid.Text + "'", konek)
    '        Dim hargabeli As String = cmd.ExecuteScalar
    '        txtharga.Text = hargabeli
    '        txtharga.Tag = Val(txtharga.Text)
    '        txtharga.Text = Format(Val(txtharga.Text), "'Rp' #,0;'Rp' -#,0")

    '        Dim sat As MySqlCommand = New MySqlCommand("select satuan.nama_satuan from satuan,barang  where id_barang='" + txtid.Text + "' and barang.satuan=satuan.id_satuan", konek)
    '        Dim satuan1 As String = sat.ExecuteScalar
    '        satuan.Text = satuan1
    '        Dim nam As MySqlCommand = New MySqlCommand("select nama_barang from barang  where id_barang='" + txtid.Text + "'", konek)
    '        Dim nama1 As String = nam.ExecuteScalar
    '        nama.Text = nama1
    '        If txtharga.Text = "" Or txtharga.Text = "Rp 0" Then
    '            jumlah.Text = ""
    '        Else
    '            jumlah.Text = "1"
    '        End If
    '    Catch ex As Exception
    '        txtharga.Text = ""
    '        txtid.Text = ""
    '        satuan.Text = ""
    '        MsgBox(ex.ToString, MsgBoxStyle.OkCancel)
    '    End Try
    'End Sub

    'Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Dim i As Integer
    '    i = DataGridView1.CurrentRow.Index
    '    With DataGridView1
    '        id_barang.Text = .Item(0, i).Value
    '    End With
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim buton As DialogResult = MsgBox("Anda yakin ingin menghapus barang ini?", MsgBoxStyle.YesNo)
    '    If (buton = 6) Then
    '        Dim harga As MySqlCommand = New MySqlCommand("Select harga_beli from barang where id_barang='" + id_barang.Text + "'", konek)
    '        Dim hargabeli As String = harga.ExecuteScalar
    '        Dim jumlah As MySqlCommand = New MySqlCommand("Select jumlah from pembelian where id_barang='" + id_barang.Text + "'and status='belum' and id_kasir='" + Label9.Text + "'", konek)
    '        Dim a As String = jumlah.ExecuteScalar
    '        total.Tag = Val(total.Tag) - Val(a * hargabeli)
    '        total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")

    '        Dim hapus As MySqlCommand = New MySqlCommand("delete from pembelian where id_barang='" + id_barang.Text + "' and status='belum' and id_kasir='" + Label9.Text + "'", konek)
    '        hapus.ExecuteNonQuery()
    '        Call baru()
    '    ElseIf (buton = 7) Then
    '        Call baru()
    '    End If
    'End Sub

    'Private Sub jumlah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Call beli(e)
    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim updatebaru As MySqlCommand = New MySqlCommand(" UPDATE  pembelian SET  status='cetak' WHERE status='belum' and id_kasir='" + Label9.Text + "';", konek)
    '    updatebaru.ExecuteNonQuery()
    '    Call baru()
    '    txtid.Text = ""
    '    total.Text = "0"
    '    total.Tag = 0
    '    satuan.Text = ""
    '    txtid.Focus()
    'End Sub

    'Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    'End Sub
End Class