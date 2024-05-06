Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1
Imports System.Data
Imports System.Reactive.Linq
Imports System.Reactive.Subjects
Public Class penjualan

    Private Function getIdTransaksi(ByVal idKasir As String) As String
        Dim cekTransaksiCmd As MySqlCommand = New MySqlCommand("SELECT id_transaksi from transaksi WHERE status='active' AND id_kasir=" & idKasir, konek)
        Dim idTransaksi = cekTransaksiCmd.ExecuteScalar
        If idTransaksi Is Nothing Then
            Dim insertTransaksi As MySqlCommand = New MySqlCommand("INSERT INTO `transaksi` (`id_transaksi`, `id_kasir`, `waktu`, `bayar`, `grand_total`, `kembalian`, `status`) VALUES (NULL, '" & idKasir & "', NOW(), '0', '0', '0', 'active');", konek)
            insertTransaksi.ExecuteNonQuery()
            Return getIdTransaksi(idKasir)
        Else
            Return idTransaksi.ToString
        End If
    End Function
    Dim debounceSubject As Subject(Of String)
    Private Sub loadTable()
        Dim mySqlAdapter = New MySqlDataAdapter("select id_transaksi_detail,barcode,nama_barang,harga,qty,jumlah,stok from ds_transaksi_penjualan where id_transaksi=" & getIdTransaksi(Module1.id_kasir), konek)
        Dim ds = New DataTable()
        mySqlAdapter.Fill(ds)
        dataGridView1.AutoGenerateColumns = True
        dataGridView1.DataSource = ds
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridView1.Columns(0).ReadOnly = True
        dataGridView1.Columns(1).ReadOnly = True
        dataGridView1.Columns(2).ReadOnly = True
        dataGridView1.Columns(3).ReadOnly = True
        dataGridView1.Columns(4).ReadOnly = False
        dataGridView1.Columns(5).ReadOnly = True
        dataGridView1.Columns(6).ReadOnly = True

        dataGridView1.Columns(0).HeaderText = "id"
        dataGridView1.Columns(1).HeaderText = "Barcode"
        dataGridView1.Columns(2).HeaderText = "Nama Barang"
        dataGridView1.Columns(3).HeaderText = "Harga"
        dataGridView1.Columns(4).HeaderText = "Qty"
        dataGridView1.Columns(5).HeaderText = "Jumlah"
        dataGridView1.Columns(6).HeaderText = "Stok"
        dataGridView1.Columns(0).Visible = False
        dataGridView1.Columns(1).Width = 300
        dataGridView1.Columns(2).Width = 508
        dataGridView1.Columns(3).Width = 150
        dataGridView1.Columns(4).Width = 150
        dataGridView1.Columns(5).Width = 150
        dataGridView1.Columns(6).Width = 150

        textCountItem.Text = dataGridView1.Rows.Count.ToString
        Dim grandTotal = 0
        For i = 0 To dataGridView1.RowCount - 1
            grandTotal += Integer.Parse(dataGridView1.Rows(i).Cells(3).Value.
                                        ToString.Replace(".", "").
                                        Replace(",", "")) * Integer.
                                        Parse(dataGridView1.Rows(i).Cells(4).Value.ToString)
        Next
        If dataGridView1.RowCount > 0 Then
            textTotal.Text = Format(Integer.Parse(dataGridView1.Rows(dataGridView1.RowCount - 1).Cells(3).Value.
                                        ToString.Replace(".", "").
                                        Replace(",", "")) * Integer.
                                        Parse(dataGridView1.Rows(dataGridView1.RowCount - 1).Cells(4).Value.ToString), "#,0;-#,0")
        Else
            textTotal.Text = ""
        End If
        labelTotalBig.Text = Format(grandTotal, "#,0;-#,0")
        textGrandTotal.Text = Format(grandTotal, "#,0;-#,0")
        textPLU.Focus()
    End Sub

    'typeSet = increment or setvalue
    Private Sub inputUpdateBarang(ByVal typeSet As String, ByVal barcode As String, ByVal qty As Integer)
        labelBarcode.Text = barcode
        Dim barangCmd As MySqlCommand = New MySqlCommand("SELECT * from barang WHERE barcode='" & barcode & "'", konek)
        Dim barangReader As MySqlDataReader = barangCmd.ExecuteReader()
        Dim idBarang As Integer
        Dim namaBarang As String
        Dim stokDisplay As Integer
        Dim stokGudang As String
        Dim stokTotal As Integer
        Dim hargaBeliNetto As Integer
        Dim hargaJual1 As Integer
        Dim hargaJual2 As Integer
        Dim hargaJual3 As Integer
        Dim hargaJual4 As Integer
        Dim qty2 As Integer
        Dim qty3 As Integer
        Dim qty4 As Integer
        If barangReader.Read Then
            idBarang = barangReader("id_barang")
            namaBarang = barangReader("nama_barang")
            stokDisplay = barangReader("stok_display")
            stokGudang = barangReader("stok_gudang")
            stokTotal = stokDisplay + stokGudang
            hargaBeliNetto = barangReader("harga_beli_netto")
            hargaJual1 = barangReader("harga_jual1")
            hargaJual2 = barangReader("harga_jual2")
            hargaJual3 = barangReader("harga_jual3")
            hargaJual4 = barangReader("harga_jual4")
            qty2 = barangReader("qty2")
            qty3 = barangReader("qty3")
            qty4 = barangReader("qty4")

            barangReader.Close()

            Dim currentQtyCmd As MySqlCommand = New MySqlCommand("SELECT qty from transaksi_detail WHERE id_barang='" & idBarang.ToString & "' AND id_transaksi=" & getIdTransaksi(Module1.id_kasir), konek)
            Dim currentQty = currentQtyCmd.ExecuteScalar
            If currentQty Is Nothing Then
                currentQty = "1"
            End If
            If typeSet = "setvalue" Then
                currentQty = qty
            End If
            Dim hargaJualTerpilih = 0
            If Integer.Parse(currentQty.ToString) < qty2 Then
                hargaJualTerpilih = hargaJual1
            ElseIf Integer.Parse(currentQty.ToString) >= qty2 And Integer.Parse(currentQty.ToString) < qty3 Then
                hargaJualTerpilih = hargaJual2
            ElseIf Integer.Parse(currentQty.ToString) >= qty3 And Integer.Parse(currentQty.ToString) < qty4 Then
                hargaJualTerpilih = hargaJual3
            ElseIf Integer.Parse(currentQty.ToString) >= qty4 Then
                hargaJualTerpilih = hargaJual4
            End If
            If qty <= (stokDisplay + stokGudang) Then
                If qty <= stokDisplay Then
                    Dim updateStokDisplay As MySqlCommand = New MySqlCommand("UPDATE barang Set stok_display = '" & (stokDisplay - qty).ToString & "' WHERE id_barang = " & idBarang.ToString, konek)
                    updateStokDisplay.ExecuteNonQuery()
                Else
                    Dim stokYgHarusDariGudang = qty - stokDisplay
                    Dim updateStokDisplay As MySqlCommand = New MySqlCommand("UPDATE barang Set stok_display = '0' WHERE id_barang = " & idBarang.ToString, konek)
                    updateStokDisplay.ExecuteNonQuery()
                    Dim updateStokGudang As MySqlCommand = New MySqlCommand("UPDATE barang Set stok_gudang = '" & (stokGudang - stokYgHarusDariGudang).ToString & "' WHERE id_barang = " & idBarang.ToString, konek)
                    updateStokGudang.ExecuteNonQuery()
                End If

                Dim cekBarangCmd As MySqlCommand = New MySqlCommand("SELECT id_transaksi_detail from transaksi_detail WHERE id_barang='" & idBarang.ToString & "' AND id_transaksi=" & getIdTransaksi(Module1.id_kasir), konek)
                Dim idTransaksiDetail = cekBarangCmd.ExecuteScalar



                If idTransaksiDetail Is Nothing Then
                    Dim insertTransaksiDetail As MySqlCommand = New MySqlCommand("INSERT INTO transaksi_detail (
id_transaksi_detail,id_barang, id_transaksi, qty, harga_beli, harga_jual)
VALUES (NULL, '" & idBarang & "', '" & getIdTransaksi(Module1.id_kasir) & "', '" & qty.ToString & "', '" & hargaBeliNetto.ToString & "',
'" & hargaJualTerpilih.ToString & "')", konek)
                    insertTransaksiDetail.ExecuteNonQuery()
                Else


                    If typeSet = "increment" Then

                        Dim updateTransaksiDetail As MySqlCommand = New MySqlCommand("UPDATE transaksi_detail Set 
qty = '" & (Integer.Parse(currentQty.ToString) + qty).ToString & "',
harga_jual = '" & hargaJualTerpilih.ToString & "'
WHERE id_transaksi_detail = " & idTransaksiDetail.ToString, konek)
                        updateTransaksiDetail.ExecuteNonQuery()
                    Else
                        Dim deleteTransaksiDetail As MySqlCommand = New MySqlCommand("DELETE from transaksi_detail 
WHERE id_transaksi_detail = " & idTransaksiDetail.ToString, konek)
                        deleteTransaksiDetail.ExecuteNonQuery()
                        'restok otomatis akan kembali ke tabel barang di kolom stok display via trigger mysql

                        Dim insertTransaksiDetail As MySqlCommand = New MySqlCommand("INSERT INTO transaksi_detail (
id_transaksi_detail,id_barang, id_transaksi, qty, harga_beli, harga_jual)
VALUES (" & idTransaksiDetail.ToString & ", '" & idBarang & "', '" & getIdTransaksi(Module1.id_kasir) & "', '" & qty.ToString & "', '" & hargaBeliNetto.ToString & "',
'" & hargaJualTerpilih.ToString & "')", konek)
                        insertTransaksiDetail.ExecuteNonQuery()
                    End If
                End If
                loadTable()
            Else
                MsgBox("Stok sudah habis", MsgBoxStyle.OkCancel)
            End If
        End If
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
    Private Function getBarcodeDariTabel() As String
        Dim barcodeTransaksiDetail = ""
        If dataGridView1.SelectedRows.Count > 0 Then
            barcodeTransaksiDetail = dataGridView1.SelectedRows(0).Cells(1).Value.ToString
        Else
            Dim lastRow = dataGridView1.Rows.Count - 1
            If lastRow >= 0 Then
                barcodeTransaksiDetail = dataGridView1.Rows(lastRow).Cells(1).Value.ToString
            End If

        End If
        Return barcodeTransaksiDetail
    End Function
    Private Sub deleteTransaksiDetail()
        Console.WriteLine(dataGridView1.SelectedRows.Count)

        If getIdDariTabel() IsNot "" Then
            Dim deleteTransaksiDetail As MySqlCommand = New MySqlCommand("DELETE from transaksi_detail 
WHERE id_transaksi_detail = " & getIdDariTabel(), konek)
            deleteTransaksiDetail.ExecuteNonQuery()
            loadTable()
        End If

    End Sub
    Private Sub toggleQty()
        If textQty.Visible = True Then
            textQty.Text = ""
            labelQty.Visible = False
            textQty.Visible = False
            textPLU.Focus()
        Else
            labelQty.Visible = True
            textQty.Visible = True
            textQty.Focus()
            textQty.Text = ""
        End If
    End Sub
    Private Sub initializeForm()
        labelKembalianBig.Hide()
        labelTotalBig.Text = 0
        textPLU.Focus()
        labelQty.Hide()
        textQty.Hide()
        textQty.Text = ""
        textPLU.Text = ""
        textTotal.Text = ""
        textGrandTotal.Text = ""
        labelBayar.Hide()
        textBayar.Hide()
        textBayar.Text = ""
        labelKembalian.Hide()
        textKembalian.Hide()
        textKembalian.Text = ""
        textBayar.Text = ""

    End Sub

    Private Sub initializeDebounce()
        debounceSubject = New Subject(Of String)()
        debounceSubject.Throttle(TimeSpan.FromMilliseconds(100))
        debounceSubject.Subscribe(AddressOf debouncedTextBayarChanged)
    End Sub


    Private Sub kembalian()
        Dim nominalKembalian = Integer.Parse(textBayar.Text.Replace(",", "").Replace(".", "")) - Integer.Parse(textGrandTotal.Text.Replace(",", "").Replace(".", ""))
        If nominalKembalian > 0 Then
            textKembalian.Text = Format(nominalKembalian, "#,0;-#,0")
            labelTotalBig.Text = textKembalian.Text
            Dim buton As DialogResult = MsgBox("Ingin CETAK NOTA?", MsgBoxStyle.YesNo)
            If (buton = 6) Then

            End If
        End If
    End Sub

    Private Sub debouncedTextBayarChanged(textBayarString As String)
        Console.WriteLine("debounce " & textBayarString)
        If Not textBayarString = "" Then
            textBayar.Text = Format(Integer.Parse(textBayarString.Replace(",", "").Replace(".", "")), "#,0;-#,0")
            textBayar.SelectionStart = textBayar.Text.Length
            textBayar.SelectionLength = 0
        End If

    End Sub

    Private Sub penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initializeForm()
        initializeDebounce()
        getIdTransaksi(Module1.id_kasir)
        loadTable()

    End Sub

    Private Sub buttonScanBarang1_Click(sender As Object, e As EventArgs) Handles buttonScanBarang1.Click
        inputUpdateBarang("increment", "11", 1)
    End Sub

    Private Sub buttonScanBarang2_Click(sender As Object, e As EventArgs) Handles buttonScanBarang2.Click
        inputUpdateBarang("increment", "22", 1)
    End Sub

    Private Sub buttonScanBarang3_Click(sender As Object, e As EventArgs) Handles buttonScanBarang3.Click
        inputUpdateBarang("increment", "33", 1)
    End Sub

    Private Sub buttonScanBarang4_Click(sender As Object, e As EventArgs) Handles buttonScanBarang4.Click
        inputUpdateBarang("increment", "44", 1)
    End Sub

    Private Sub buttonScanBarang5_Click(sender As Object, e As EventArgs) Handles buttonScanBarang5.Click
        inputUpdateBarang("increment", "55", 1)
    End Sub

    Private Sub penjualan_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Delete Then
            deleteTransaksiDetail()
        End If

        If e.KeyCode = Keys.Multiply Then
            toggleQty()
        End If
        If e.KeyCode = Keys.Escape Then
            labelBayar.Visible = True
            textBayar.Visible = True
            labelKembalian.Visible = True
            textKembalian.Visible = True
            labelKembalianBig.Visible = True
            textBayar.Text = ""
            textKembalian.Text = "0"
            labelTotalBig.Text = textKembalian.Text
            textBayar.Focus()
        End If
        e.Handled = False
        'End If
    End Sub


    Private Sub textQty_KeyDown(sender As Object, e As KeyEventArgs) Handles textQty.KeyDown
        If Not IsNumeric(Chr(e.KeyCode)) And Not e.KeyCode = Keys.Delete And Not e.KeyCode = Keys.Back And Not e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
        If e.KeyCode = Keys.Enter Then
            If getIdDariTabel() IsNot "" Then
                inputUpdateBarang("setvalue", getBarcodeDariTabel, Integer.Parse(textQty.Text))
                toggleQty()
            End If
        End If
    End Sub

    Private Sub textPLU_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textPLU.KeyPress
        Dim ascChar As Integer = Asc(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not (ascChar = 8) And Not (ascChar = 32) And Not (ascChar = 13) Then
            e.KeyChar = ""
            e.Handled = False
        End If
    End Sub



    Private Sub dataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dataGridView1.CellFormatting
        If (e.ColumnIndex = 3 Or e.ColumnIndex = 5) AndAlso IsNumeric(e.Value) Then
            e.Value = Format(e.Value, "#,0;-#,0")
        End If
    End Sub

    Private Sub textBayar_KeyUp(sender As Object, e As KeyEventArgs) Handles textBayar.KeyUp
        If Not IsNumeric(Chr(e.KeyCode)) And Not e.KeyCode = Keys.Delete And Not e.KeyCode = Keys.Back And Not e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
        If e.KeyCode = Keys.Enter Then
            kembalian()
        End If
    End Sub

    Private Sub textBayar_TextChanged(sender As Object, e As EventArgs) Handles textBayar.TextChanged
        debounceSubject.OnNext(textBayar.Text)
    End Sub

    Private Sub dataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellEndEdit
        Dim row = dataGridView1.Rows(e.RowIndex)
        inputUpdateBarang("setvalue", row.Cells(1).Value.ToString, row.Cells(e.ColumnIndex).Value.ToString)
    End Sub

End Class