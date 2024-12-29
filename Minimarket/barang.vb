Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Public Class barang

    Public Sub view()
        Dim ds = newConnect.ExecuteReader("select *,(stok_display+stok_gudang) as total_stok from barang")

        DataGridView1.DataSource = ds
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()

        nm_suplier.Text = ""
        satuanbox.Text = ""
        txtBarcode.Text = ""
        txtNama.Text = ""
        txtHargaBeli.Text = ""
        txtPajak.Text = ""
        txtDiskon.Text = ""
        txtHargaBeliNetto.Text = ""
        txtStokDisplay.Text = ""
        txtStokGudang.Text = ""
        txtHargaJual1.Text = ""
        txtHargaJual2.Text = ""
        txtHargaJual3.Text = ""
        txtHargaJual4.Text = ""
        txtQty2.Text = ""
        txtQty3.Text = ""
        txtQty4.Text = ""
        lblIdBarang.Text = ""
        lblLastDo.Text = ""
        lblProfit1.Text = ""
        lblProfit2.Text = ""
        lblProfit3.Text = ""
        lblProfit4.Text = ""
        lblNoFaktur.Text = ""
        lblIdSupplierFaktur.Text = ""
        lblKodeSupplierFaktur.Text = ""
        lblNamaSupplierFaktur.Text = ""
       
        berdasarkan.SelectedIndex = 0
        syarat.SelectedIndex = 0
        Call binding()
    End Sub
    Public Sub binding()
        Dim ds = newConnect.ExecuteReader("select id_suplier,nama_suplier from supplier")
        nm_suplier.Items.Clear()
        For i = 0 To ds.Rows.Count - 1
            nm_suplier.Items.Add(ds.Rows(i).ItemArray.GetValue(1))
        Next
        Dim dsat = newConnect.ExecuteReader("select id_satuan,nama_satuan from satuan")

        satuanbox.Items.Clear()
        For j = 0 To dsat.Rows.Count - 1
            satuanbox.Items.Add(dsat.Rows(j).ItemArray.GetValue(1))
        Next
    End Sub
    Public Sub reload()
        Call view()
    End Sub

    Public Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lihat.Click
        Call view()
        Call binding()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If nm_suplier.Text = "" Or satuanbox.Text = "" Or txtBarcode.Text = "" Or txtNama.Text = "" Or txtHargaBeli.Text = "" Or
            txtPajak.Text = "" Or txtDiskon.Text = "" Or txtHargaBeliNetto.Text = "" Or txtStokDisplay.Text = "" Or
            txtStokGudang.Text = "" Or txtHargaJual1.Text = "" Or txtHargaJual2.Text = "" Or txtHargaJual3.Text = "" Or
            txtHargaJual4.Text = "" Or txtQty2.Text = "" Or txtQty3.Text = "" Or txtQty4.Text = ""  Then
            MsgBox("Data tentang barang, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "INSERT INTO barang(id_suplier,id_satuan,barcode,nama_barang,harga_beli,ppn,discount,harga_beli_netto," +
                "stok_display,stok_gudang,harga_jual1,harga_jual2,harga_jual3,harga_jual4,qty2,qty3,qty4)" +
                "VALUES(" +
                "'" + (nm_suplier.SelectedIndex + 1).ToString + "'," +
                "'" + (satuanbox.SelectedIndex + 1).ToString + "'," +
                "'" + txtBarcode.Text.ToString + "'," +
                "'" + txtNama.Text.ToString + "'," +
                "'" + txtHargaBeli.Tag.ToString + "'," +
                "'" + txtPajak.Text.ToString + "'," +
                "'" + txtDiskon.Text.ToString + "'," +
                "'" + txtHargaBeliNetto.Tag.ToString + "'," +
                "'" + txtStokDisplay.Text.ToString + "'," +
                "'" + txtStokGudang.Text.ToString + "'," +
                "'" + txtHargaJual1.Tag.ToString + "'," +
                "'" + txtHargaJual2.Tag.ToString + "'," +
                "'" + txtHargaJual3.Tag.ToString + "'," +
                "'" + txtHargaJual4.Tag.ToString + "'," +
                "'" + txtQty2.Text.ToString + "'," +
                "'" + txtQty3.Text.ToString + "'," +
                "'" + txtQty4.Text.ToString + "'" +
                ")"
            If ( newConnect.ExecuteNonQuery(Query)) Then
                MsgBox("Barang berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Barang gagal ditambahkan", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    Private Sub calculateProfit()
        lblProfit1.Text = Math.Round(((Val(txtHargaJual1.Tag) - Val(txtHargaBeliNetto.Tag)) / Val(txtHargaBeliNetto.Tag)) * 100, 2).ToString & "%"
        lblProfit2.Text = Math.Round(((Val(txtHargaJual2.Tag) - Val(txtHargaBeliNetto.Tag)) / Val(txtHargaBeliNetto.Tag)) * 100, 2).ToString & "%"
        lblProfit3.Text = Math.Round(((Val(txtHargaJual3.Tag) - Val(txtHargaBeliNetto.Tag)) / Val(txtHargaBeliNetto.Tag)) * 100, 2).ToString & "%"
        lblProfit4.Text = Math.Round(((Val(txtHargaJual4.Tag) - Val(txtHargaBeliNetto.Tag)) / Val(txtHargaBeliNetto.Tag)) * 100, 2).ToString & "%"
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            With DataGridView1
                lblIdBarang.Text = .Item(0, i).Value
                Try
                    nm_suplier.SelectedIndex = .Item(1, i).Value - 1
                Catch ex As Exception

                End Try
                Try
                    satuanbox.SelectedIndex = .Item(2, i).Value - 1
                Catch ex As Exception

                End Try
                txtBarcode.Text = .Item(3, i).Value
                txtNama.Text = .Item(4, i).Value
                txtHargaBeli.Tag = If(Not (IsDBNull(.Item(5, i).Value)), .Item(5, i).Value, "0")
                txtHargaBeli.Text = Format(Val(txtHargaBeli.Tag), "'Rp' #,0;'Rp' -#,0")
                txtPajak.Text = .Item(6, i).Value
                txtDiskon.Text = .Item(7, i).Value
                txtHargaBeliNetto.Tag = If(Not (IsDBNull(.Item(8, i).Value)), .Item(8, i).Value, "0")
                txtHargaBeliNetto.Text = Format(Val(txtHargaBeliNetto.Tag), "'Rp' #,0;'Rp' -#,0")
                txtStokDisplay.Text = .Item(9, i).Value
                txtStokGudang.Text = .Item(10, i).Value

                txtHargaJual1.Tag = If(Not (IsDBNull(.Item(11, i).Value)), .Item(11, i).Value, "0")
                txtHargaJual1.Text = Format(Val(txtHargaJual1.Tag), "'Rp' #,0;'Rp' -#,0")
                txtHargaJual2.Tag = If(Not (IsDBNull(.Item(12, i).Value)), .Item(12, i).Value, "0")
                txtHargaJual2.Text = Format(Val(txtHargaJual2.Tag), "'Rp' #,0;'Rp' -#,0")
                txtHargaJual3.Tag = If(Not (IsDBNull(.Item(13, i).Value)), .Item(13, i).Value, "0")
                txtHargaJual3.Text = Format(Val(txtHargaJual3.Tag), "'Rp' #,0;'Rp' -#,0")
                txtHargaJual4.Tag = If(Not (IsDBNull(.Item(14, i).Value)), .Item(14, i).Value, "0")
                txtHargaJual4.Text = Format(Val(txtHargaJual4.Tag), "'Rp' #,0;'Rp' -#,0")

                txtQty2.Text = .Item(15, i).Value
                txtQty3.Text = .Item(16, i).Value
                txtQty4.Text = .Item(17, i).Value

                Dim lastDOQuery = newConnect.ExecuteReader("SELECT pembelian.no_faktur,pembelian.tgl_faktur,pembelian.id_supplier," &
                                                           "supplier.kode_suplier,supplier.nama_suplier " &
                                                           "from(pembelian_detail) " &
                                                           "LEFT JOIN pembelian ON pembelian.id_pembelian=pembelian_detail.id_pembelian " &
                                                           "LEFT JOIN supplier on supplier.id_suplier=pembelian.id_supplier WHERE pembelian_detail.id_barang=" & lblIdBarang.Text & " ORDER BY pembelian.tgl_faktur DESC LIMIT 0,1")
                If lastDOQuery.Rows.Count > 0 Then
                    lblLastDo.Text = lastDOQuery.Rows(0).Item(1).ToString
                    calculateProfit()
                    lblNoFaktur.Text = lastDOQuery.Rows(0).Item(0).ToString
                    lblIdSupplierFaktur.Text = lastDOQuery.Rows(0).Item(2).ToString
                    lblKodeSupplierFaktur.Text = lastDOQuery.Rows(0).Item(3).ToString
                    lblNamaSupplierFaktur.Text = lastDOQuery.Rows(0).Item(4).ToString
                    '                    Dim profitLastQueryString = "select `pembelian_detail`.`id_pembelian`," &
                    '"round((((`barang`.`harga_jual1` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit1`," &
                    '"round((((`barang`.`harga_jual2` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit2`," &
                    '"round((((`barang`.`harga_jual3` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit3`," &
                    '"round((((`barang`.`harga_jual4` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto`) * 100),2) AS `profit4`," &
                    '"`pembelian`.`status` AS `status_pembelian` " &
                    '"from ((`pembelian` join `pembelian_detail` on((`pembelian`.`id_pembelian` = `pembelian_detail`.`id_pembelian`))) " &
                    '"join `barang` on((`pembelian_detail`.`id_barang` = `barang`.`id_barang`))) where pembelian.no_faktur='" & lastDOQuery.Rows(0).Item(0).ToString & "' and pembelian_detail.id_barang=" & lblIdBarang.Text & ""
                    '                    Console.WriteLine(profitLastQueryString)
                    '                    Dim profitLastQuery = newConnect.ExecuteReader(profitLastQueryString)
                    '                    If profitLastQuery.Rows.Count > 0 Then
                    '                        lblProfit1.Text = If(Not (IsDBNull(profitLastQuery.Rows(0).Item(1))), profitLastQuery.Rows(0).Item(1), "0")
                    '                        lblProfit2.Text = If(Not (IsDBNull(profitLastQuery.Rows(0).Item(2))), profitLastQuery.Rows(0).Item(2), "0")
                    '                        lblProfit3.Text = If(Not (IsDBNull(profitLastQuery.Rows(0).Item(3))), profitLastQuery.Rows(0).Item(3), "0")
                    '                        lblProfit4.Text = If(Not (IsDBNull(profitLastQuery.Rows(0).Item(4))), profitLastQuery.Rows(0).Item(4), "0")
                    '                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox("Data yang anda cari tidak ada" & ex.Message, MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not hak_akses = "1" Then
            hapus.Enabled = False
            tambah.Enabled = False
            edit.Enabled = False
        End If
        Call reload()
        Call binding()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (lblIdBarang.Text = "") Then
            MsgBox("Harap pilih data yang akan di edit", MsgBoxStyle.OkOnly)
        ElseIf nm_suplier.Text = "" Or satuanbox.Text = "" Or txtBarcode.Text = "" Or txtNama.Text = "" Or txtHargaBeli.Text = "" Or
            txtPajak.Text = "" Or txtDiskon.Text = "" Or txtHargaBeliNetto.Text = "" Or txtStokDisplay.Text = "" Or
            txtStokGudang.Text = "" Or txtHargaJual1.Text = "" Or txtHargaJual2.Text = "" Or txtHargaJual3.Text = "" Or
            txtHargaJual4.Text = "" Or txtQty2.Text = "" Or txtQty3.Text = "" Or txtQty4.Text = "" Or
            lblIdBarang.Text = "" Then
            MsgBox("Data tentang barang, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Dim isExecute = newConnect.ExecuteNonQuery("UPDATE  barang SET " &
            "id_suplier='" & (nm_suplier.SelectedIndex + 1).ToString & "'," &
            "id_satuan='" & (satuanbox.SelectedIndex + 1).ToString & "'," &
            "barcode='" & txtBarcode.Text.ToString & "'," &
                "nama_barang='" & txtNama.Text.ToString & "'," &
                "harga_beli='" & txtHargaBeli.Tag.ToString & "'," &
                "ppn='" & txtPajak.Text.ToString & "'," &
                "discount='" & txtDiskon.Text.ToString & "'," &
                "harga_beli_netto='" & txtHargaBeliNetto.Tag.ToString & "'," &
                "stok_display='" & txtStokDisplay.Text.ToString & "'," &
                "stok_gudang='" & txtStokGudang.Text.ToString & "'," &
                "harga_jual1='" & txtHargaJual1.Tag.ToString & "'," &
                "harga_jual2='" & txtHargaJual2.Tag.ToString & "'," &
                "harga_jual3='" & txtHargaJual3.Tag.ToString & "'," &
                "harga_jual4='" & txtHargaJual4.Tag.ToString & "'," &
                "qty2='" & txtQty2.Text.ToString & "'," &
                "qty3='" & txtQty3.Text.ToString & "'," &
                "qty4='" & txtQty4.Text.ToString & "'" &
                " WHERE  id_barang ='" & lblIdBarang.Text & "'")
            If (isExecute) Then
                MsgBox("Data Barang berhasil diubah", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Data Barang gagal diubah", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        Dim Query As String
        If lblIdBarang.Text = "" Then
            MsgBox("Harap pilih data yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Query = "delete from barang WHERE  id_barang ='" + lblIdBarang.Text + "'"
            If ( newConnect.ExecuteNonQuery(Query)) Then
                MsgBox("Satu Data Barang berhasil dihapus", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Satu Data Barang gagal dihapus", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub pencarian()
        satuanbox.Text = ""
        nm_suplier.Text = ""
        txtHargaBeli.Text = ""
        txtHargaJual1.Text = ""
        txtNama.Text = ""
        txtStokGudang.Text = ""
        If berdasarkan.SelectedIndex = 0 Then
            Dim ds = newConnect.ExecuteReader("select *,(stok_display+stok_gudang) as total_stok from barang where nama_barang like '%" + txtcari.Text + "%' order by nama_barang asc")
           
            DataGridView1.DataSource = ds
            Call binding()
        End If
        If berdasarkan.SelectedIndex = 1 Then
            Try
                Dim ds = newConnect.ExecuteReader("select *,(stok_display+stok_gudang) as total_stok from barang where harga_jual" + syarat.SelectedItem + txtcari.Text + "")
                
                DataGridView1.DataSource = ds
                Call binding()
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 2 Then
            Try
                Dim ds = newConnect.ExecuteReader("select *,(stok_display+stok_gudang) as total_stok from barang where harga_beli" + syarat.SelectedItem + txtcari.Text + "")
              
                DataGridView1.DataSource = ds
                Call binding()
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 3 Then
            Try
                Dim ds = newConnect.ExecuteReader("select *,(stok_display+stok_gudang) as total_stok from barang where stok" + syarat.SelectedItem + txtcari.Text + "")

                DataGridView1.DataSource = ds
                Call binding()
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
    End Sub
    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call pencarian()
    End Sub

    Private Sub syarat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles syarat.SelectedIndexChanged
        Call pencarian()
    End Sub

    Private Sub berasarkan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles berdasarkan.SelectedIndexChanged
        Call pencarian()
    End Sub

    Private Sub nm_suplier_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles nm_suplier.DropDown
        Dim ds = newConnect.ExecuteReader("select id_suplier,nama_suplier from supplier")
        Dim i As Integer
        nm_suplier.Items.Clear()
        For i = 0 To ds.Rows.Count - 1
            nm_suplier.Items.Add(ds.Rows(i).ItemArray.GetValue(1))
        Next
    End Sub

    
    Public Sub hanyaangka(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim valid As String = "0 1 2 3 4 5 6 7 8 9"
        Dim x As Long = InStr(valid, e.KeyChar)
        If x = 0 And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 32 Then
            MsgBox("Harap masukkan angka", MsgBoxStyle.OkOnly)
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txthargabeli_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaBeli.GotFocus
        If (lblIdBarang.Text = "") Then
            txtHargaBeli.Tag = ""
        End If
        txtHargaBeli.Text = txtHargaBeli.Tag
    End Sub
    Private Sub txthargabeli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaBeli.KeyPress
        Call hanyaangka(e)
    End Sub
    Private Sub txthargabeli_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaBeli.LostFocus
        txtHargaBeli.Tag = txtHargaBeli.Text
        txtHargaBeli.Text = Format(Val(txtHargaBeli.Tag), "'Rp' #,0;'Rp' -#,0")
    End Sub

    Private Sub txthargabelinetto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaBeliNetto.GotFocus
        If (lblIdBarang.Text = "") Then
            txtHargaBeliNetto.Tag = ""
        End If
        txtHargaBeliNetto.Text = txtHargaBeliNetto.Tag
    End Sub
    Private Sub txthargabelinetto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaBeliNetto.KeyPress
        Call hanyaangka(e)
    End Sub
    Private Sub txthargabelinetto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaBeliNetto.LostFocus
        txtHargaBeliNetto.Tag = txtHargaBeliNetto.Text
        txtHargaBeliNetto.Text = Format(Val(txtHargaBeliNetto.Tag), "'Rp' #,0;'Rp' -#,0")
        calculateProfit()
    End Sub

    Private Sub txtHargaJual1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual1.GotFocus
        If (lblIdBarang.Text = "") Then
            txtHargaJual1.Tag = ""
        End If
        txtHargaJual1.Text = txtHargaJual1.Tag
    End Sub
    Private Sub txtHargaJual1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaJual1.KeyPress
        Call hanyaangka(e)
    End Sub
    Private Sub txtHargaJual1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual1.LostFocus
        txtHargaJual1.Tag = txtHargaJual1.Text
        txtHargaJual1.Text = Format(Val(txtHargaJual1.Tag), "'Rp' #,0;'Rp' -#,0")
        calculateProfit()
    End Sub

    Private Sub txtHargaJual2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual2.GotFocus
        If (lblIdBarang.Text = "") Then
            txtHargaJual2.Tag = ""
        End If
        txtHargaJual2.Text = txtHargaJual2.Tag
    End Sub
    Private Sub txtHargaJual2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaJual2.KeyPress
        Call hanyaangka(e)
    End Sub
    Private Sub txtHargaJual2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual2.LostFocus
        txtHargaJual2.Tag = txtHargaJual2.Text
        txtHargaJual2.Text = Format(Val(txtHargaJual2.Tag), "'Rp' #,0;'Rp' -#,0")
        calculateProfit()
    End Sub

    Private Sub txtHargaJual3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual3.GotFocus
        If (lblIdBarang.Text = "") Then
            txtHargaJual3.Tag = ""
        End If
        txtHargaJual3.Text = txtHargaJual3.Tag
    End Sub
    Private Sub txtHargaJual3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaJual3.KeyPress
        Call hanyaangka(e)
    End Sub
    Private Sub txtHargaJual3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual3.LostFocus
        txtHargaJual3.Tag = txtHargaJual3.Text
        txtHargaJual3.Text = Format(Val(txtHargaJual3.Tag), "'Rp' #,0;'Rp' -#,0")
        calculateProfit()
    End Sub

    Private Sub txtHargaJual4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual4.GotFocus
        If (lblIdBarang.Text = "") Then
            txtHargaJual4.Tag = ""
        End If
        txtHargaJual4.Text = txtHargaJual4.Tag
    End Sub
    Private Sub txtHargaJual4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaJual4.KeyPress
        Call hanyaangka(e)
    End Sub
    Private Sub txtHargaJual4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual4.LostFocus
        txtHargaJual4.Tag = txtHargaJual4.Text
        txtHargaJual4.Text = Format(Val(txtHargaJual4.Tag), "'Rp' #,0;'Rp' -#,0")
        calculateProfit()
    End Sub

    Private Sub satuanbox_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles satuanbox.DropDown
        Dim dsat = newConnect.ExecuteReader("select id_satuan,nama_satuan from satuan")

        Dim j As Integer
        satuanbox.Items.Clear()
        For j = 0 To dsat.Rows.Count - 1
            satuanbox.Items.Add(dsat.Rows(j).ItemArray.GetValue(1))
        Next
    End Sub
    Private Sub txtStokGudang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStokGudang.KeyPress
        Call hanyaangka(e)
    End Sub

    Private Sub txtStokDisplay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStokDisplay.KeyPress
        Call hanyaangka(e)
    End Sub

    Private Sub txtPajak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPajak.KeyPress
        Call hanyaangka(e)
    End Sub


    Private Sub txtQty2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty2.KeyPress
        Call hanyaangka(e)
    End Sub

    Private Sub txtQty3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty3.KeyPress
        Call hanyaangka(e)
    End Sub

    Private Sub txtQty4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty4.KeyPress
        Call hanyaangka(e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (lblNoFaktur.Text = "") Then
            MsgBox("Belum ada faktur pembelian")
        Else
            main.showDetailPembelian(lblNoFaktur.Text, lblKodeSupplierFaktur.Text, lblIdSupplierFaktur.Text, lblNamaSupplierFaktur.Text)
        End If

    End Sub
End Class
