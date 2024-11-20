Imports System.Globalization
Imports System.Threading.Tasks
Imports Microsoft.VisualBasic.Logging
Imports MySql.Data.MySqlClient
Public Class pembelian1
    Dim noFaktorEdit As String
    Dim statusFaktorEdit As String

    Public Function getIdPembelian(ByVal idKasir As String) As String
        If noFaktorEdit IsNot Nothing Then
            Dim idPembelian = newConnect.ExecuteScalar("SELECT id_pembelian from pembelian WHERE no_faktur='" & noFaktorEdit & "'")
            Console.WriteLine("id pembelian noFaktorEdit" & idPembelian)
            Return idPembelian.ToString
        Else
            Dim idPembelian = newConnect.ExecuteScalar("SELECT id_pembelian from pembelian WHERE status='temp' AND id_kasir='" & idKasir & "'")
            If idPembelian Is Nothing Then
                Dim tes = newConnect.ExecuteNonQuery("INSERT INTO pembelian(id_pembelian, no_faktur, tgl_faktur, id_supplier, id_kasir, grand_total, metode_pembayaran, lama_jatuh_tempo, status) VALUES (NULL, '', NOW(), '0', '" & idKasir & "', '0', 'tunai', '0', 'temp');")
                Dim idPembelian1 = newConnect.ExecuteScalar("SELECT id_pembelian from pembelian WHERE status='temp' AND id_kasir='" & idKasir & "'")
                Console.WriteLine("id pembelian1" & idPembelian)
                Return idPembelian1.ToString
            Else
                Console.WriteLine("id pembelian" & idPembelian)
                Return idPembelian.ToString
            End If
        End If

    End Function
    Private Sub textPLU_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textPLU.KeyPress
        Dim ascChar As Integer = Asc(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not (ascChar = 8) And Not (ascChar = 32) And Not (ascChar = 13) Then
            e.KeyChar = ""
            e.Handled = False
        End If
        If ascChar = 13 Then
            Console.WriteLine("tes")
            inputUpdateBarang(textPLU.Text)
        End If
    End Sub
    Private Sub inputUpdateBarang(ByVal barcode As String)

        Dim barangReaders = newConnect.ExecuteReader("SELECT * from barang WHERE barcode='" & barcode & "'")
        Dim idBarang As Integer
        Dim hargaBeli As Integer
        Dim ppn As Double
        Dim discount As Double
        Dim hargaBeliNetto As Integer
        Console.WriteLine(barangReaders.Rows.Count)
        If barangReaders.Rows.Count > 0 Then
            Dim barangReader = barangReaders.Rows(0)
            idBarang = barangReader("id_barang")
            hargaBeli = barangReader("harga_beli")
            ppn = barangReader("ppn")
            discount = barangReader("discount")
            hargaBeliNetto = barangReader("harga_beli_netto")
            Console.WriteLine("" & idBarang & "-" & hargaBeli & "-" & ppn & "-" & discount)

            Dim currentQty = newConnect.ExecuteScalar("SELECT qty from pembelian_detail WHERE id_barang='" & idBarang.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
            If currentQty Is Nothing Then
                currentQty = "1"
                Dim query = "INSERT INTO pembelian_detail (id_pembelian_detail,id_pembelian,id_barang,qty,price,ppn,discount,price_netto) VALUES (NULL,'" & getIdPembelian(Module1.id_kasir) & "', '" & idBarang & "', '" & currentQty.ToString & "', '" & hargaBeli.ToString & "', '" & ppn.ToString.Replace(",", ".") & "', '" & discount.ToString.Replace(",", ".") & "', '" & hargaBeliNetto.ToString & "')"
                Console.WriteLine(query)
                newConnect.ExecuteNonQuery(query)
            Else
                currentQty = (Integer.Parse(currentQty.ToString) + 1).ToString
                Dim query = "UPDATE pembelian_detail Set qty = '" & currentQty.ToString & "' WHERE id_barang = '" & idBarang.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'"

                newConnect.ExecuteNonQuery(query)
            End If
            loadTable()
            textPLU.Text = ""
            textPLU.Focus()
        Else
            newConnect.ExecuteNonQuery("INSERT INTO barang (barcode,is_new) VALUES ('" & barcode & "','1')")
            textPLU.Text = ""
            textPLU.Focus()
            inputUpdateBarang(barcode)
        End If
        

    End Sub


    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dataGridView1.CellFormatting
        'If (e.ColumnIndex = 5 Or e.ColumnIndex = 7 Or e.ColumnIndex = 9 Or e.ColumnIndex = 11 Or e.ColumnIndex = 13 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15) AndAlso IsNumeric(e.Value) Then
        If (e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or
            e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 14 Or e.ColumnIndex = 15 Or e.ColumnIndex = 16) AndAlso IsNumeric(e.Value) Then
            e.Value = Format(e.Value, "#,0;-#,0")
        End If
    End Sub
    Private Sub customizeCellsInColumn(ByVal columnIndex As Integer)

        Dim column As DataGridViewColumn = dataGridView1.Columns(columnIndex)
        Dim cell = New DataGridViewTextBoxCell()
        cell.Style.BackColor = Color.Wheat

        If columnIndex = 10 Or columnIndex = 12 Then
            cell.Style.Format = "N2"
      
        End If
        column.CellTemplate = cell
    End Sub
    Private Sub loadTable()
        Try
            Dim ds = newConnect.ExecuteReader("select id_pembelian_detail,no_faktur,id_barang,barcode, nama_barang," &
                                              "qty,stok_display,stok_gudang, harga,harga_lama,ppn," &
                                              "ppn_lama,discount,discount_lama,harga_netto,harga_netto_lama," &
                                              "total,expiry from ds_transaksi_pembelian  where id_pembelian=" & getIdPembelian(Module1.id_kasir))

            dataGridView1.AutoGenerateColumns = True
            dataGridView1.DataSource = ds
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            dataGridView1.Columns("id_pembelian_detail").ReadOnly = True
            dataGridView1.Columns("no_faktur").ReadOnly = True
            dataGridView1.Columns("id_barang").ReadOnly = True
            dataGridView1.Columns("barcode").ReadOnly = True
            dataGridView1.Columns("nama_barang").ReadOnly = False
            dataGridView1.Columns("qty").ReadOnly = False
            dataGridView1.Columns("stok_display").ReadOnly = True
            dataGridView1.Columns("stok_gudang").ReadOnly = True
            dataGridView1.Columns(8).ReadOnly = False 'harga
            dataGridView1.Columns(9).ReadOnly = True
            dataGridView1.Columns(10).ReadOnly = False 'ppn
            dataGridView1.Columns(11).ReadOnly = True
            dataGridView1.Columns(12).ReadOnly = False 'discount
            dataGridView1.Columns(13).ReadOnly = True
            dataGridView1.Columns(14).ReadOnly = True
            dataGridView1.Columns(15).ReadOnly = True
            dataGridView1.Columns(16).ReadOnly = True
            dataGridView1.Columns(17).ReadOnly = True

            dataGridView1.Columns(0).Visible = False
            dataGridView1.Columns(1).Visible = False
            dataGridView1.Columns(2).Visible = False

            dataGridView1.Columns(0).HeaderText = "id_pembelian_detail"
            dataGridView1.Columns(1).HeaderText = "no_faktur"
            dataGridView1.Columns(2).HeaderText = "id_barang"
            dataGridView1.Columns(3).HeaderText = "Barcode"
            dataGridView1.Columns(4).HeaderText = "Nama Barang"
            dataGridView1.Columns(5).HeaderText = "Qty"
            dataGridView1.Columns(6).HeaderText = "Stok Display"
            dataGridView1.Columns(7).HeaderText = "Stok Gudang"
            dataGridView1.Columns(8).HeaderText = "Harga"
            dataGridView1.Columns(9).HeaderText = "Harga Lama"
            dataGridView1.Columns(10).HeaderText = "PPn(%)"
            dataGridView1.Columns(11).HeaderText = "PPn Lama(%)"
            dataGridView1.Columns(11).DefaultCellStyle.Format = "N2"
            dataGridView1.Columns(12).HeaderText = "Discount(%)"
            dataGridView1.Columns(13).HeaderText = "Discount Lama(%)"
            dataGridView1.Columns(13).DefaultCellStyle.Format = "N2"
            dataGridView1.Columns(14).HeaderText = "Harga Netto"
            dataGridView1.Columns(15).HeaderText = "Harga Netto Lama"
            dataGridView1.Columns(16).HeaderText = "Total"
            dataGridView1.Columns(17).HeaderText = "Expired"
            dataGridView1.Columns(17).ValueType = GetType(Date)
            dataGridView1.Columns(17).DefaultCellStyle.Format = "dd/MM/yyyy"



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
            dataGridView1.Columns(17).Width = 158

            customizeCellsInColumn(4)
            customizeCellsInColumn(5)
         
            customizeCellsInColumn(8)
            customizeCellsInColumn(10)
            customizeCellsInColumn(12)
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
            Dim grandTotal = 0
            For i = 0 To dataGridView1.RowCount - 1
                grandTotal += Integer.Parse(dataGridView1.Rows(i).Cells(5).Value.
                                            ToString.Replace(".", "").
                                            Replace(",", "")) * Integer.
                                            Parse(dataGridView1.Rows(i).Cells(14).Value.ToString)
            Next
            textTotal.Text = Format(grandTotal, "#,0;-#,0")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub textDiscount_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles textDiscount.KeyUp
        If e.KeyCode = Keys.Enter Then
            For i = 0 To dataGridView1.RowCount - 1
                dataGridView1.Rows(i).Cells(12).Value = textDiscount.Text.ToString

                Dim pembelianDetailReaders = newConnect.ExecuteReader("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(i).Cells(0).Value.ToString & "'")
                Dim price As Integer
                Dim ppn As Double
                Dim discount As Double = Double.Parse(dataGridView1.Rows(i).Cells(12).Value.ToString)
                Dim priceNetto As Integer
                If pembelianDetailReaders.Rows.Count > 0 Then
                    Dim pembelianDetailReader = pembelianDetailReaders.Rows(0)
                    price = pembelianDetailReader("price")
                    ppn = pembelianDetailReader("ppn")
                    Dim priceAfterPpn = (price + ((ppn / 100) * price))
                    priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                End If
                dataGridView1.Rows(i).Cells(14).Value = priceNetto.ToString
                dataGridView1.Rows(i).Cells(16).Value = (Integer.Parse(dataGridView1.Rows(i).Cells(5).Value.
                                        ToString.Replace(".", "").
                                        Replace(",", "")) * priceNetto).ToString

                newConnect.ExecuteNonQuery("UPDATE pembelian_detail Set discount = '" & discount.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(i).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
            Next
            Dim grandTotal = 0
            For i = 0 To dataGridView1.RowCount - 1
                Dim subTotal = Integer.Parse(dataGridView1.Rows(i).Cells(16).Value.
                                    ToString.Replace(".", "").
                                    Replace(",", ""))
                grandTotal += subTotal
            Next
            textTotal.Text = Format(grandTotal, "#,0;-#,0")
            textPLU.Text = ""
            textPLU.Focus()

        End If
    End Sub

    Private Sub textPpn_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles textPpn.KeyUp
        If e.KeyCode = Keys.Enter Then
            For i = 0 To dataGridView1.RowCount - 1
                dataGridView1.Rows(i).Cells(10).Value = textPpn.Text.ToString

                Dim pembelianDetailReaders = newConnect.ExecuteReader("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(i).Cells(0).Value.ToString & "'")
                Dim price As Integer
                Dim ppn As Double = Double.Parse(dataGridView1.Rows(i).Cells(10).Value.ToString)
                Dim discount As Double
                Dim priceNetto As Integer
                If pembelianDetailReaders.Rows.Count > 0 Then
                    Dim pembelianDetailReader = pembelianDetailReaders.Rows(0)
                    price = pembelianDetailReader("price")
                    discount = pembelianDetailReader("discount")
                    Dim priceAfterPpn = (price + ((ppn / 100) * price))
                    priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                End If
                dataGridView1.Rows(i).Cells(14).Value = priceNetto.ToString
                dataGridView1.Rows(i).Cells(16).Value = (Integer.Parse(dataGridView1.Rows(i).Cells(5).Value.
                                        ToString.Replace(".", "").
                                        Replace(",", "")) * priceNetto).ToString

                newConnect.ExecuteNonQuery("UPDATE pembelian_detail Set ppn = '" & ppn.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(i).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
            Next
            Dim grandTotal = 0
            For i = 0 To dataGridView1.RowCount - 1
                Dim subTotal = Integer.Parse(dataGridView1.Rows(i).Cells(16).Value.
                                    ToString.Replace(".", "").
                                    Replace(",", ""))
                grandTotal += subTotal
            Next
            textTotal.Text = Format(grandTotal, "#,0;-#,0")
            textPLU.Text = ""
            textPLU.Focus()
        End If
    End Sub
    Private Sub textPpn_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textPpn.KeyPress
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
    Private Sub textDiscount_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textDiscount.KeyPress
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
    Private Sub pembelian_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

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
            loadTable()
        Else
            textTempoHari.Text = ""
            textTempoHari.Enabled = False
            textSupplier.Select()

            loadTable()
            Dim pembelianReaders = newConnect.ExecuteReader("Select * from pembelian where id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
            If pembelianReaders.Rows.Count > 0 Then
                Dim pembelianReader = pembelianReaders.Rows(0)
                textNoFaktur.Text = pembelianReader("no_faktur")
                If pembelianReader("id_supplier").ToString = "0" Or pembelianReader("id_supplier") Is Nothing Then
                    labelIdSuplier.Text = ""
                Else
                    labelIdSuplier.Text = pembelianReader("id_supplier")
                    Dim kodeSupplier = newConnect.ExecuteScalar("select kode_suplier from supplier where id_suplier='" & labelIdSuplier.Text & "'").ToString
                    textSupplier.Text = kodeSupplier
                End If
                Dim textInfo = New CultureInfo("id-ID", False).TextInfo
                textTanggal.Text = DateTime.Parse(pembelianReader("tgl_faktur")).ToString("dd MMMM yyyy")
                comboPembayaran.SelectedItem = textInfo.ToTitleCase(pembelianReader("metode_pembayaran").ToString)
                If comboPembayaran.SelectedItem = "Tunai" Then
                    textTempoHari.Text = ""
                    textJatuhTempo.Text = ""
                Else
                    textTempoHari.Text = pembelianReader("lama_jatuh_tempo").ToString
                    If Integer.TryParse(textTempoHari.Text.ToString, Nothing) Then
                        textJatuhTempo.Text = DateTime.Now.AddDays(Integer.Parse(textTempoHari.Text)).ToString("dd MMMM yyyy")
                    End If
                End If
            End If
        End If


    End Sub


    Private Sub textSupplier_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textSupplier.TextChanged
        If textSupplier.Text IsNot "" And popup_supplier.Visible = False And noFaktorEdit Is Nothing Then
            popup_supplier.frmPembelian = Me
            popup_supplier.txtcari.Text = textSupplier.Text
            popup_supplier.Show()
            
        End If
    End Sub

    Private Sub comboPembayaran_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboPembayaran.SelectedIndexChanged
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

    Private Sub textTempoHari_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textTempoHari.TextChanged
        If Integer.TryParse(textTempoHari.Text.ToString, Nothing) Then
            textJatuhTempo.Text = DateTime.Now.AddDays(Integer.Parse(textTempoHari.Text)).ToString("dd MMMM yyyy")
        End If

    End Sub

    Private Sub Tb_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim tb As TextBox = TryCast(sender, TextBox)

            If tb.Text = "" OrElse tb.Text = "0" Then Return
            Dim number As Decimal
            number = Decimal.Parse(tb.Text, System.Globalization.NumberStyles.Currency)
            tb.Text = number.ToString("#,#")
            tb.SelectionStart = tb.Text.Length
        Catch ex As Exception

        End Try
       

    End Sub

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dataGridView1.EditingControlShowing
        If TypeOf e.Control Is TextBox And (dataGridView1.CurrentCell.ColumnIndex = 5 Or dataGridView1.CurrentCell.ColumnIndex = 8) Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)

            RemoveHandler tb.TextChanged, AddressOf Tb_TextChanged
            AddHandler tb.TextChanged, AddressOf Tb_TextChanged
        End If
    End Sub

    Private Sub dataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.CellValueChanged
        '5(qty), 8(harga), 10(ppn), 12(discount)
        Try
            
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                If e.ColumnIndex = 4 Then
                    newConnect.ExecuteNonQuery("UPDATE barang Set nama_barang = '" & dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString & "' WHERE id_barang = '" &
                                                                       dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "'")
                    loadTable()
                ElseIf e.ColumnIndex = 5 Then
                    Dim qty = dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                   
                    newConnect.ExecuteNonQuery("UPDATE pembelian_detail Set qty = '" & qty & "' WHERE id_barang = '" &
                                                                       dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
                    loadTable()
                ElseIf e.ColumnIndex = 8 Then
                    Dim pembelianDetailReaders = newConnect.ExecuteReader("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString & "'")

                    Dim price As Integer = Integer.Parse(dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
                    Dim ppn As Double
                    Dim discount As Double
                    Dim priceNetto As Integer
                    If pembelianDetailReaders.Rows.Count > 0 Then
                        Dim pembelianDetailReader = pembelianDetailReaders.Rows(0)
                        ppn = pembelianDetailReader("ppn")
                        discount = pembelianDetailReader("discount")
                        Dim priceAfterPpn = (price + ((ppn / 100) * price))
                        priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    End If
                    newConnect.ExecuteNonQuery("UPDATE pembelian_detail Set price = '" & price.ToString & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                       dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
                    loadTable()
                ElseIf e.ColumnIndex = 10 Then
                    Dim pembelianDetailReaders = newConnect.ExecuteReader("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString & "'")
                    Dim price As Integer
                    Dim ppn As Double = Double.Parse(dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
                    Dim discount As Double
                    Dim priceNetto As Integer
                    If pembelianDetailReaders.Rows.Count > 0 Then
                        Dim pembelianDetailReader = pembelianDetailReaders.Rows(0)
                        price = pembelianDetailReader("price")
                        discount = pembelianDetailReader("discount")
                        Dim priceAfterPpn = (price + ((ppn / 100) * price))
                        priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    End If
                    newConnect.ExecuteNonQuery("UPDATE pembelian_detail Set ppn = '" & ppn.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                       dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
                    loadTable()
                ElseIf e.ColumnIndex = 12 Then
                    Dim pembelianDetailReaders = newConnect.ExecuteReader("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString & "'")
                    Dim price As Integer
                    Dim ppn As Double
                    Dim discount As Double = Double.Parse(dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
                    Dim priceNetto As Integer
                    If pembelianDetailReaders.Rows.Count > 0 Then
                        Dim pembelianDetailReader = pembelianDetailReaders.Rows(0)
                        price = pembelianDetailReader("price")
                        ppn = pembelianDetailReader("ppn")
                        Dim priceAfterPpn = (price + ((ppn / 100) * price))
                        priceNetto = priceAfterPpn - ((discount / 100) * priceAfterPpn)
                    End If
                    newConnect.ExecuteNonQuery("UPDATE pembelian_detail Set discount = '" & discount.ToString.Replace(",", ".") & "',price_netto = '" & priceNetto.ToString & "' WHERE id_barang = '" &
                                                                       dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
                    loadTable()
                End If
                textPLU.Text = ""
                textPLU.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub savePembelian()


        Dim metodePembayaran = ""
        Dim minus = ""
        Dim jatuhTempo = "0"
        If comboPembayaran.SelectedIndex = 0 Then
            metodePembayaran = "tunai"
            minus = ""
        End If
        If comboPembayaran.SelectedIndex = 1 Then
            metodePembayaran = "kredit"
            minus = "-"
            jatuhTempo = textTempoHari.Text
        End If
        If comboPembayaran.SelectedIndex = 2 Then
            metodePembayaran = "konsinyasi"
            minus = "-"
            jatuhTempo = textTempoHari.Text
        End If
        Dim query = "UPDATE pembelian SET no_faktur = '" & textNoFaktur.Text & "',grand_total = '" & textTotal.Text.Replace(",", "").Replace(".", "") & "', metode_pembayaran = '" & metodePembayaran & "',id_supplier='" & labelIdSuplier.Text & "', lama_jatuh_tempo = '" & jatuhTempo & "',status = 'saved' WHERE id_pembelian = " & getIdPembelian(Module1.id_kasir)
        Console.WriteLine(query)
        newConnect.ExecuteNonQuery(query)

        For i = 0 To dataGridView1.RowCount - 1
            Dim qty = dataGridView1.Rows(i).Cells(5).Value.ToString
            Dim hargaBeli = dataGridView1.Rows(i).Cells(8).Value.ToString.Replace(",", "").Replace(".", "")
            Dim isNew = newConnect.ExecuteScalar("select is_new from barang WHERE id_barang = '" &
                                                                       dataGridView1.Rows(i).Cells(2).Value.ToString & "'")
            If isNew = "1" Then
                newConnect.ExecuteNonQuery("UPDATE barang Set is_new = '0',stok_gudang='" & qty & "',id_suplier='" & labelIdSuplier.Text & "',harga_beli='" & hargaBeli & "' WHERE id_barang = '" &
                                                               dataGridView1.Rows(i).Cells(2).Value.ToString & "'")
            Else
                Dim pembelianDetailReaders = newConnect.ExecuteReader("SELECT * from pembelian_detail WHERE id_pembelian_detail='" & dataGridView1.Rows(i).Cells(0).Value.ToString & "'")
                If pembelianDetailReaders.Rows.Count > 0 Then
                    Dim pembelianDetailReader = pembelianDetailReaders.Rows(0)
                    Dim idBarang = pembelianDetailReader("id_barang")
                    Dim barangReaders = newConnect.ExecuteReader("SELECT * from barang WHERE id_barang='" & idBarang & "'")
                    If barangReaders.Rows.Count > 0 Then
                        Dim barangReader = barangReaders.Rows(0)
                        Dim stokGudang = Integer.Parse(barangReader("stok_gudang").ToString)
                        stokGudang = stokGudang + qty
                        newConnect.ExecuteNonQuery("UPDATE barang Set stok_gudang = '" & stokGudang.ToString & "' WHERE id_barang = '" & idBarang & "'")

                    End If
                End If
            End If
        Next
        

        Dim idMutasi = newConnect.ExecuteScalar("SELECT id_mutasi from mutasi WHERE  type='pembelian' and id_reff='" & getIdPembelian(Module1.id_kasir) & "'")
        If idMutasi Is Nothing Then
            newConnect.ExecuteNonQuery("INSERT INTO mutasi(id_mutasi,id_reff,type,deskripsi,nominal,created_at) VALUES (NULL, '" &
                                                                getIdPembelian(Module1.id_kasir) &
                                                                "','pembelian','PEMBELIAN secara " & metodePembayaran.ToUpper & " dengan faktur: " &
                                                                textNoFaktur.Text & "', '" & minus & "" & textTotal.
                                                                Text.
                                                                Replace(",", "").
                                                                Replace(".", "") & "', now());")
        Else
            newConnect.ExecuteNonQuery("UPDATE mutasi SET deskripsi = 'update PEMBELIAN secara " & metodePembayaran.ToUpper & " dengan faktur: " &
                                                                textNoFaktur.Text & "',nominal = '" & minus & "" &
                                                                textTotal.
                                                                Text.
                                                                Replace(",", "").
                                                                Replace(".", "") & "',created_at = now() WHERE id_mutasi = " & idMutasi.ToString)
        End If
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
        newConnect.ExecuteNonQuery("DELETE from pembelian_detail WHERE id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
        newConnect.ExecuteNonQuery("DELETE from pembelian WHERE id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")

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
    Private Sub pembelian_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Delete Then
            deleteTransaksiDetail()
        End If
    End Sub
    Private Sub deleteTransaksiDetail()
        Console.WriteLine(dataGridView1.SelectedRows.Count)

        If getIdDariTabel() IsNot "" Then
            newConnect.ExecuteNonQuery("DELETE from pembelian_detail WHERE id_pembelian_detail = " & getIdDariTabel())
            loadTable()
        End If

    End Sub
    Private Sub buttonSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonSave.Click
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

    Private Sub buttonNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonNew.Click
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

    Private Sub buttonDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDelete.Click
        deleteTransaksiDetail()
    End Sub

    Private Sub btnEditFaktor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditFaktor.Click
        If btnEditFaktor.Text.ToLower = "kembali" Then
            Dim newPembelian = New pembelian1

            newPembelian.MdiParent = main
            newPembelian.Show()
            Me.Close()
        Else
            If textNoFaktur.Text = "" Then
                MsgBox("Masukkan NO FAKTUR terlebih dahulu")
            ElseIf textSupplier.Text = "" Or labelIdSuplier.Text = "" Or labelSupplier.Text = "" Then
                MsgBox("Harap PILIH suplier terlebih dahulu")
            Else
                Dim idPembelian = newConnect.ExecuteScalar("SELECT id_pembelian from pembelian WHERE  no_faktur='" & textNoFaktur.Text & "' and id_supplier='" & labelIdSuplier.Text & "'")
                If idPembelian Is Nothing Then
                    MsgBox("Faktur tidak ditemukan")
                Else
                    Dim pembelianReaders = newConnect.ExecuteReader("SELECT * from pembelian WHERE  no_faktur='" & textNoFaktur.Text & "' and id_supplier='" & labelIdSuplier.Text & "'")
                    If pembelianReaders.Rows.Count > 0 Then
                        Dim pembelianReader = pembelianReaders.Rows(0)
                        Dim newPembelian = New pembelian1
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
                        newPembelian.statusFaktorEdit = newConnect.ExecuteScalar("SELECT status from pembelian WHERE  no_faktur='" & textNoFaktur.Text & "' and id_supplier='" & labelIdSuplier.Text & "'")
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
    Private Sub dataGridView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        If e.ColumnIndex = 17 Then


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

        newConnect.ExecuteNonQuery("UPDATE pembelian_detail Set expiry = '" & newDate.ToString("yyyy-MM-dd") & "' WHERE id_barang = '" &
                                                                   dataGridView1.Rows(cell.RowIndex).Cells(2).Value.ToString & "' AND id_pembelian='" & getIdPembelian(Module1.id_kasir) & "'")
    End Sub
    Private Sub oDateTimePicker_CloseUp(ByVal sender As Object, ByVal e As EventArgs)
        oDateTimePicker.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        supplier.Show()
    End Sub

 
End Class