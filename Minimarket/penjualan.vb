Imports MySql.Data.MySqlClient
Imports System.Data

Public Class penjualan
    Public previousIdTransaksi As String


    Private Function getIdTransaksi(ByVal idKasir As String) As String
        Dim idTransaksi = newConnect.ExecuteScalar("SELECT id_transaksi from transaksi WHERE status='active' AND id_kasir='" & idKasir & "'")

        If idTransaksi Is Nothing Then
            Dim noTransaksi = DateTime.Now.ToString("yyyyMMddHHmmss") & idKasir
            newConnect.ExecuteNonQuery("INSERT INTO `transaksi` (`id_transaksi`,`no_transaksi`, `id_kasir`, `waktu`, `bayar`, `grand_total`, `kembalian`, `status`) VALUES (NULL,'" & noTransaksi & "', '" & idKasir & "', NOW(), '0', '0', '0', 'active');")
            Return getIdTransaksi(idKasir)
        Else
            Return idTransaksi.ToString
        End If
    End Function
    Dim debounceSubject As DebounceDispatcher
    Private Sub loadTable()
        Try
            Dim ds = newConnect.ExecuteReader("select id_transaksi_detail,barcode,nama_barang,harga,qty,jumlah,stok,updated_at from ds_transaksi_penjualan where id_transaksi='" & lblIdTransaksi.Text & "' order by updated_at desc")

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
            lblGrandTotal.Text = Format(grandTotal, "#,0;-#,0")
            textPLU.Text = ""
            textPLU.Select()

            textPLU.Focus()
        Catch ex As Exception

        End Try
        
    End Sub

    'typeSet = increment or setvalue
    Private Sub inputUpdateBarang(ByVal typeSet As String, ByVal barcode As String, ByVal qty As Integer)
        Try
            labelBarcode.Text = barcode
            Dim barangReaders = newConnect.ExecuteReader("SELECT * from barang WHERE barcode='" & barcode & "'")
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
            If barangReaders.Rows.Count > 0 Then
                Dim barangReader = barangReaders.Rows(0)
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

                Dim currentQty = newConnect.ExecuteScalar("SELECT qty from transaksi_detail WHERE id_barang='" & idBarang.ToString & "' AND id_transaksi=" & lblIdTransaksi.Text)
                If currentQty Is Nothing Then
                    currentQty = "1"
                End If
                If typeSet = "setvalue" Then
                    currentQty = qty
                End If
                Dim hargaJualTerpilih = 0
                If Integer.Parse(currentQty.ToString) < qty2 Or Integer.Parse(qty2) = 0 Then
                    hargaJualTerpilih = hargaJual1
                ElseIf Integer.Parse(currentQty.ToString) >= qty2 And (Integer.Parse(currentQty.ToString) < qty3 Or Integer.Parse(qty3) = 0) Then
                    hargaJualTerpilih = hargaJual2
                ElseIf Integer.Parse(currentQty.ToString) >= qty3 And (Integer.Parse(currentQty.ToString) < qty4 Or Integer.Parse(qty4) = 0) Then
                    hargaJualTerpilih = hargaJual3
                ElseIf Integer.Parse(currentQty.ToString) >= qty4 Then
                    hargaJualTerpilih = hargaJual4
                End If
                If qty <= (stokDisplay + stokGudang) Then
                   

                    Dim idTransaksiDetail = newConnect.ExecuteScalar("SELECT id_transaksi_detail from transaksi_detail WHERE id_barang='" & idBarang.ToString & "' AND id_transaksi=" & lblIdTransaksi.Text)



                    If idTransaksiDetail Is Nothing Then

                        newConnect.ExecuteNonQuery("INSERT INTO transaksi_detail (id_transaksi_detail,id_barang, id_transaksi, qty, harga_beli, harga_jual,updated_at) VALUES (NULL, '" & idBarang & "', '" & lblIdTransaksi.Text & "', '" & qty.ToString & "', '" & hargaBeliNetto.ToString & "','" & hargaJualTerpilih.ToString & "',now())")
                    Else


                        If typeSet = "increment" Then
                            newConnect.ExecuteNonQuery("UPDATE transaksi_detail Set qty = '" & (Integer.Parse(currentQty.ToString) + qty).ToString & "',harga_jual = '" & hargaJualTerpilih.ToString & "',updated_at=now() WHERE id_transaksi_detail = " & idTransaksiDetail.ToString)
                        Else
                            newConnect.ExecuteNonQuery("DELETE from transaksi_detail WHERE id_transaksi_detail = " & idTransaksiDetail.ToString)
                            'restok otomatis akan kembali ke tabel barang di kolom stok display via trigger mysql
                            newConnect.ExecuteNonQuery("INSERT INTO transaksi_detail (id_transaksi_detail,id_barang, id_transaksi, qty, harga_beli, harga_jual,updated_at) VALUES (" & idTransaksiDetail.ToString & ", '" & idBarang & "', '" & lblIdTransaksi.Text & "', '" & qty.ToString & "', '" & hargaBeliNetto.ToString & "','" & hargaJualTerpilih.ToString & "',now())")
                        End If
                    End If
                    loadTable()
                Else
                    MsgBox("Stok tidak cukup", MsgBoxStyle.OkCancel)
                    loadTable()

                End If
            End If
        Catch ex As Exception

        End Try
        
    End Sub
    Private Function getIdFromCell(ByVal isNeedDelete As Boolean) As String
        Dim idTransaksiDetail = ""
        If dataGridView1.CurrentCell IsNot Nothing Then
            Dim selectedRow As DataGridViewRow = dataGridView1.CurrentCell.OwningRow
            idTransaksiDetail = selectedRow.Cells(0).Value.ToString
            If (isNeedDelete) Then
                dataGridView1.Rows.RemoveAt(selectedRow.Index)
            End If
        End If

        Return idTransaksiDetail
    End Function
 
    Private Function getBarcodeDariTabel() As String

        Dim barcode = ""
        If dataGridView1.CurrentCell IsNot Nothing Then
            Dim selectedRow As DataGridViewRow = dataGridView1.CurrentCell.OwningRow
            barcode = selectedRow.Cells(1).Value.ToString

        End If

        Return barcode
    End Function
    Private Sub deleteTransaksiDetail()
        Dim idDariTable = getIdFromCell(True)
        If idDariTable IsNot "" Then
            newConnect.ExecuteNonQuery("DELETE from transaksi_detail WHERE id_transaksi_detail = " & idDariTable)
            loadTable()

        End If

    End Sub
    Private Sub toggleQty()
        Console.WriteLine(textQty.Visible)
        If textQty.Visible = True Then
            textQty.Text = ""
            labelQty.Visible = False
            textQty.Visible = False
            Return
        End If
        If textQty.Visible = False Then
            textQty.Text = ""
            labelQty.Visible = True
            textQty.Visible = True



            Return

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
        lblGrandTotal.Text = ""
        lblBayar.Text = ""
        lblKembalian.Text = ""
        labelBayar.Hide()
        textBayar.Hide()
        labelKembalian.Hide()
        textKembalian.Hide()
        textKembalian.Text = ""
        lblKembalian.Text = ""
        textBayar.Text = ""
        isDone = False
    End Sub

    Private Sub initializeDebounce()
        debounceSubject = New DebounceDispatcher()
        
    End Sub


    Private Sub kembalian()
        Dim grandTotal = Integer.Parse(textGrandTotal.Text.Replace(",", "").Replace(".", ""))
        If grandTotal < 0 Then
            'proses retur, kembalikan stok barang
            newConnect.ExecuteNonQuery("update barang INNER JOIN transaksi_detail on barang.id_barang=transaksi_detail.id_barang set barang.stok_gudang = barang.stok_gudang+ (transaksi_detail.qty*-1) WHERE transaksi_detail.id_transaksi=" & lblIdTransaksi.Text)
           
            textKembalian.Text = Format(0, "#,0;-#,0")
            lblKembalian.Text = textKembalian.Text
            labelTotalBig.Text = textKembalian.Text

            Dim buton As DialogResult = MsgBox("Ingin CETAK NOTA?", MsgBoxStyle.YesNo)
            If (buton = 6) Then
                returTransaksi(0)
            Else
                returTransaksi(0)
            End If
        Else
            'proses transaksi normal
            Dim nominalKembalian = Integer.Parse(textBayar.Text.Replace(",", "").Replace(".", "")) - grandTotal
            If nominalKembalian >= 0 Then
                textKembalian.Text = Format(nominalKembalian, "#,0;-#,0")
                lblKembalian.Text = textKembalian.Text
                labelTotalBig.Text = textKembalian.Text

                Dim buton As DialogResult = MsgBox("Ingin CETAK NOTA?", MsgBoxStyle.YesNo)
                If (buton = 6) Then
                    cetakTransaksi(
                        lblIdTransaksi.Text,
                        nominalKembalian,
                        Integer.Parse(textBayar.Text.Replace(",", "").Replace(".", "")),
                        grandTotal)
                End If
                doneTransaksi(nominalKembalian)
            End If
        End If
        
    End Sub

    Dim dtItem As DataTable
    Dim arrWidth() As Integer
    Dim arrFormat() As StringFormat
    Dim c As New PrintingFormat
    Private Sub loadDataNota(ByVal idTransaksi As String)
        Try
            Dim ds = newConnect.ExecuteReader("select nama_barang,qty,nama_satuan,harga from ds_transaksi_penjualan where id_transaksi='" & idTransaksi & "' order by updated_at asc")

            If dtItem Is Nothing Then
                dtItem = New DataTable
                With dtItem.Columns
                    .Add("itemname", Type.GetType("System.String"))
                    .Add("qty", Type.GetType("System.String"))
                    .Add("satuan", Type.GetType("System.String"))
                    .Add("price", Type.GetType("System.String"))
                End With
            Else
                dtItem.Rows.Clear()

            End If
            For r = 0 To ds.Rows.Count - 1
                Dim ItemRow As DataRow

                ItemRow = dtItem.NewRow()
                ItemRow("itemname") = ds.Rows(r).Item(0)
                ItemRow("qty") = ds.Rows(r).Item(1)
                ItemRow("satuan") = ds.Rows(r).Item(2)
                ItemRow("price") = ds.Rows(r).Item(3)
                dtItem.Rows.Add(ItemRow)

            Next
        Catch ex As Exception

        End Try




    End Sub
    Sub cetakTransaksi(ByVal idTransaksi As String, ByVal nominalKembalian As Integer, ByVal nominalBayar As Integer, ByVal nominalTotal As Integer)

        loadDataNota(idTransaksi)

        Printer.NewPrint()
        arrWidth = {180} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidCenter} 'array alignment 
        'Setting Font
        Printer.SetFont("Monospace", 11, FontStyle.Bold)
        Printer.Print("Wildan Barokah", arrWidth, arrFormat) 'Store Name | Nama Toko

        Printer.SetFont("Monospace", 9, FontStyle.Bold)
        Printer.Print("Retail & Grosir", arrWidth, arrFormat) 'Store Name | Nama Toko

        'Setting Font
        Printer.SetFont("Monospace", 8, FontStyle.Regular)
        Printer.Print("Lenteng Proppo Pamekasan", arrWidth, arrFormat) 'Store Address | Alamat Toko
        Printer.Print("087 800 596 667", arrWidth, arrFormat) 'Store Address | Alamat Toko

        Printer.SetFont("Monospace", 8, FontStyle.Regular)
        Printer.Print("------------------------------------------------") 'line
        Dim waktuTransaksi = newConnect.ExecuteScalar("SELECT waktu from transaksi WHERE id_transaksi = " & idTransaksi)
        Printer.Print(waktuTransaksi) ' Trans Date | Tanggal transaksi

        Dim transNo = newConnect.ExecuteScalar("select no_transaksi from transaksi where id_transaksi='" & idTransaksi & "'")
        Printer.Print(transNo & " " & "Kasir : " & Module1.id_kasir) ' Transaction No | Nomor transaksi

        Printer.SetFont("Monospace", 8, FontStyle.Regular) 'Setting Font
        Printer.Print("------------------------------------------------") 'line

        'looping item sales | loop item penjualan
        Dim jumlahItem = 0
        For r = 0 To dtItem.Rows.Count - 1
            arrWidth = {130, 50} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidLeft, c.MidRight} 'array alignment 
            Printer.SetFont("Monospace", 8, FontStyle.Regular)
            Printer.Print(dtItem.Rows(r).Item("itemname") & ";" & Integer.Parse(dtItem.Rows(r).Item("qty")).ToString("n0"), arrWidth, arrFormat)

            arrWidth = {60, 60, 60} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidLeft, c.MidRight, c.MidRight} 'array alignment 
            Printer.SetFont("Monospace", 6.5, FontStyle.Regular)
            jumlahItem = jumlahItem + Integer.Parse(dtItem.Rows(r).Item("qty"))

            Dim subtotal = Integer.Parse(dtItem.Rows(r).Item("qty")) * Integer.Parse(dtItem.Rows(r).Item("price"))
            Dim itemStr = Integer.Parse(dtItem.Rows(r).Item("qty")).ToString("n0") & " " & dtItem.Rows(r).Item("satuan") & ";" &
                          Integer.Parse(dtItem.Rows(r).Item("price")).ToString("n0") & ";" & subtotal.ToString("n0")
            Console.WriteLine(itemStr)
            Printer.Print(itemStr, arrWidth, arrFormat)
        Next


        arrWidth = {80, 100} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidLeft, c.MidRight} 'array alignment 
        Printer.SetFont("Monospace", 8, FontStyle.Regular) 'Setting Font
        Printer.Print("------------------------------------------------")
        Printer.Print("JUMLAH;" & jumlahItem.ToString("n0"), arrWidth, arrFormat)
        Printer.Print("TOTAL;" & nominalTotal.ToString("n0"), arrWidth, arrFormat)
        Printer.Print("BAYAR;" & nominalBayar.ToString("n0"), arrWidth, arrFormat)
        Printer.Print("KEMBALI;" & nominalKembalian.ToString("n0"), arrWidth, arrFormat)
        Printer.Print("------------------------------------------------")
        arrWidth = {180} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidCenter} 'array alignment 
        Printer.SetFont("Monospace", 8, FontStyle.Regular) 'Setting 
        Printer.Print("Barang yang sudah dibeli tidak dapat dikembalikan. Apabila terjadi masalah, nota harap dibawa kembali.", arrWidth, arrFormat)
        Printer.Print("Terima Kasih Atas Kunjungan Anda.", arrWidth, arrFormat)
        Printer.Print("------------------------------------------------")
        Printer.Print(" ")

        'Release the job for actual printing
        Printer.DoPrint()
    End Sub
    Private Sub voidTransaksi()
        'newConnect.ExecuteNonQuery("UPDATE transaksi Set  status = 'void' WHERE id_transaksi = " & lblIdTransaksi.Text)
        textPLU.Enabled = True
        textBayar.Enabled = True
        initializeForm()
        lblIdTransaksi.Text = getIdTransaksi(Module1.id_kasir)
        loadTable()
    End Sub
    Private Sub pendingTransaksi()
        newConnect.ExecuteNonQuery("UPDATE transaksi Set  status = 'pending' WHERE id_transaksi = " & lblIdTransaksi.Text)
        Dim newPenjualan = New penjualan
        newPenjualan.previousIdTransaksi = lblIdTransaksi.Text
        newPenjualan.MdiParent = main
        newPenjualan.Show()
    End Sub
    Dim isDone As Boolean = False
    Private Sub doneTransaksi(ByVal nominalKembalian As Integer)
        isDone = True
        textPLU.Enabled = False
        textBayar.Enabled = False
        Dim waktuTransaksi = newConnect.ExecuteScalar("SELECT waktu from transaksi WHERE id_transaksi = " & lblIdTransaksi.Text)
        Dim transaksiDetails = newConnect.ExecuteReader("select * from ds_transaksi_penjualan where id_transaksi = " & lblIdTransaksi.Text)
        For i = 0 To transaksiDetails.Rows.Count - 1
            Dim transaksiDetail = transaksiDetails.Rows(i)
            Dim qty As Integer = transaksiDetail("qty")
            Dim stokDisplay As Integer = newConnect.ExecuteScalar("select stok_display from barang where barcode='" & transaksiDetail("barcode").ToString & "'")
            Dim stokGudang As Integer = newConnect.ExecuteScalar("select stok_gudang from barang where barcode='" & transaksiDetail("barcode").ToString & "'")
            If qty <= stokDisplay Then
                newConnect.ExecuteNonQuery("UPDATE barang Set stok_display = '" & (stokDisplay - qty).ToString & "' WHERE barcode = '" & transaksiDetail("barcode") & "'")
            Else
                Dim stokYgHarusDariGudang = qty - stokDisplay
                newConnect.ExecuteNonQuery("UPDATE barang Set stok_display = '0' WHERE barcode='" & transaksiDetail("barcode").ToString & "'")
                newConnect.ExecuteNonQuery("UPDATE barang Set stok_gudang = '" & (stokGudang - stokYgHarusDariGudang).ToString & "' WHERE barcode='" & transaksiDetail("barcode") & "'")
            End If
        Next
        newConnect.ExecuteNonQuery("UPDATE transaksi Set bayar = '" & textBayar.
                                                               Text.
                                                               Replace(",", "").
                                                               Replace(".", "") &
                                                               "', grand_total = '" &
                                                               textGrandTotal.Text.Replace(",", "").Replace(".", "") &
                                                               "', kembalian = '" & nominalKembalian.ToString &
                                                               "', status = 'done' WHERE id_transaksi = " & lblIdTransaksi.Text)
        Dim idMutasi = newConnect.ExecuteScalar("SELECT id_mutasi from mutasi WHERE  type='penjualan' and id_reff='" & lblIdTransaksi.Text & "'")
        If idMutasi Is Nothing Then
            newConnect.ExecuteNonQuery("INSERT INTO mutasi(id_mutasi,id_reff,type,deskripsi,nominal,created_at) VALUES (NULL, '" &
                                                                 lblIdTransaksi.Text &
                                                                "','penjualan','PENJUALAN pada waktu: " &
                                                                waktuTransaksi & "', '" & textTotal.
                                                                Text.
                                                                Replace(",", "").
                                                                Replace(".", "") & "', now());")
        Else

            newConnect.ExecuteNonQuery("UPDATE mutasi SET deskripsi = 'update PENJUALAN pada waktu: " &
                                                                waktuTransaksi & "',nominal = '" & textTotal.
                                                                Text.
                                                                Replace(",", "").
                                                                Replace(".", "") & "',created_at = now() WHERE id_mutasi = " & idMutasi.ToString)
        End If
    End Sub

    Private Sub returTransaksi(ByVal nominalKembalian As Integer)
        Dim waktuTransaksi = newConnect.ExecuteScalar("SELECT waktu from transaksi WHERE id_transaksi = " & lblIdTransaksi.Text)
        newConnect.ExecuteNonQuery("UPDATE transaksi Set bayar = '" & textGrandTotal.Text.Replace(",", "").Replace(".", "") & "', grand_total = '" & textGrandTotal.Text.Replace(",", "").Replace(".", "") & "', kembalian = '0', status = 'retur' WHERE id_transaksi = " & lblIdTransaksi.Text)
        Dim idMutasi = newConnect.ExecuteScalar("SELECT id_mutasi from mutasi WHERE  type='penjualan' and id_reff='" & lblIdTransaksi.Text & "'")
        If idMutasi Is Nothing Then
            newConnect.ExecuteNonQuery("INSERT INTO mutasi(id_mutasi,id_reff,type,deskripsi,nominal,created_at) VALUES (NULL, '" &
                                                                 lblIdTransaksi.Text &
                                                                "','penjualan','RETUR PENJUALAN pada waktu: " &
                                                                waktuTransaksi & "', '" & textGrandTotal.Text.Replace(",", "").Replace(".", "") & "', now());")

        Else
            newConnect.ExecuteNonQuery("UPDATE mutasi SET deskripsi = 'update RETUR PENJUALAN pada waktu: " &
                                                                waktuTransaksi & "',nominal = '" & textGrandTotal.
                                                                Text.
                                                                Replace(",", "").
                                                                Replace(".", "") & "',created_at = now() WHERE id_mutasi = " & idMutasi.ToString)
        End If
        initializeForm()
        lblIdTransaksi.Text = getIdTransaksi(Module1.id_kasir)
        loadTable()

    End Sub

    Private Sub debouncedTextBayarChanged(textBayarString As String)
        If Not textBayarString = "" Then
            textBayar.Text = Format(Integer.Parse(textBayarString.Replace(",", "").Replace(".", "")), "#,0;-#,0")
            lblBayar.Text = textBayar.Text
            labelTotalBig.Text = textBayar.Text
            textBayar.SelectionStart = textBayar.Text.Length
            textBayar.SelectionLength = 0
        End If

    End Sub

    Private Sub penjualan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        newConnect.ExecuteNonQuery("UPDATE transaksi Set  status = 'void' WHERE id_transaksi = " & lblIdTransaksi.Text)
        If previousIdTransaksi IsNot Nothing Then
            newConnect.ExecuteNonQuery("UPDATE transaksi Set  status = 'active' WHERE id_transaksi = " & previousIdTransaksi)
        End If
    End Sub

    Private Sub penjualan_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        newConnect.ExecuteNonQuery("UPDATE transaksi Set  status = 'active' WHERE id_transaksi = " & lblIdTransaksi.Text)
    End Sub


    Private Sub penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initializeForm()
        initializeDebounce()
        lblIdTransaksi.Text = getIdTransaksi(Module1.id_kasir)
        loadTable()

    End Sub

    Private Sub penjualan_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Delete Then
            deleteTransaksiDetail()
        End If

        If e.KeyCode = Keys.Multiply Then
            toggleQty()
        End If
        If e.KeyCode = Keys.Escape And isDone Then
            voidTransaksi()
        End If
        If e.KeyCode = Keys.F8 Then
            pendingTransaksi()
        End If
        If e.KeyCode = Keys.F11 Then
            main.listBarangForm.frmPenjualan = Me
            main.listBarangForm.frmReturSuplier = Nothing
            main.listBarangForm.frmPembelian = Nothing
            main.listBarangForm.koreksiStok = Nothing
            main.listBarangForm.txtcari.Text = ""
            main.listBarangForm.WindowState = FormWindowState.Normal
            main.listBarangForm.Show()
            main.listBarangForm.BringToFront()

        End If
        If e.KeyCode = Keys.End Then
            labelBayar.Visible = True
            textBayar.Visible = True
            labelKembalian.Visible = True
            textKembalian.Visible = True
            labelKembalianBig.Visible = True
            textBayar.Text = ""
            lblBayar.Text = ""
            textKembalian.Text = "0"
            lblKembalian.Text = "0"
            labelTotalBig.Text = textKembalian.Text
            textBayar.Focus()
        End If
        e.Handled = False
        'End If
    End Sub


    Private Sub textQty_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles textQty.KeyDown
        If Not IsNumeric(Chr(e.KeyCode)) And Not e.KeyCode = Keys.Delete And Not e.KeyCode = Keys.Back And Not e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
        If e.KeyCode = Keys.Enter Then
            Dim idDariTabel = getIdFromCell(False)
            If idDariTabel.ToString IsNot "" Then
                inputUpdateBarang("setvalue", getBarcodeDariTabel, Integer.Parse(textQty.Text))
                toggleQty()


            End If
        End If
    End Sub
    Sub setPLU(ByVal barcode As String)
        inputUpdateBarang("increment", barcode, 1)
        textPLU.Select()
        textPLU.Focus()

    End Sub
    Private Sub textPLU_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textPLU.KeyPress
        Dim ascChar As Integer = Asc(e.KeyChar)
      
        If ascChar = 13 Then
            inputUpdateBarang("increment", textPLU.Text, 1)
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
        debounceSubject.Debounce(100, Function(p)
                                          debouncedTextBayarChanged(textBayar.Text)
                                      End Function)
    End Sub

    Private Sub dataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellEndEdit
        Dim row = dataGridView1.Rows(e.RowIndex)
        inputUpdateBarang("setvalue", row.Cells(1).Value.ToString, row.Cells(e.ColumnIndex).Value.ToString)
    End Sub


    Private Sub textQty_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textQty.VisibleChanged
        If textQty.Visible = True Then
            textQty.Select()
            textQty.Focus()
        Else
            textPLU.Select()
            textPLU.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim varListNota = New list_nota
        varListNota.frmPenjualan = Me
        varListNota.Show()

    End Sub

End Class