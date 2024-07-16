Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Public Class barang

    Public Sub view()
        Dim sql As MySqlCommand = New MySqlCommand("select *,(stok_display+stok_gudang) as total_stok from barang", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "Barang")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Barang"
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

       
        berdasarkan.SelectedIndex = 0
        syarat.SelectedIndex = 0
        Call binding()
    End Sub
    Public Sub binding()
        Dim sql As MySqlCommand = New MySqlCommand("select id_suplier,nama_suplier from supplier", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        Dim i As Integer
        da.SelectCommand = sql
        da.Fill(ds, "Supplier")
        nm_suplier.Items.Clear()
        For i = 0 To ds.Tables("Supplier").Rows.Count - 1
            nm_suplier.Items.Add(ds.Tables("Supplier").Rows(i).ItemArray.GetValue(1))
        Next
        Dim satuan As MySqlCommand = New MySqlCommand("select id_satuan,nama_satuan from satuan", konek)
        Dim dsat As DataSet = New DataSet
        Dim dasat As MySqlDataAdapter = New MySqlDataAdapter
        Dim j As Integer
        dasat.SelectCommand = satuan
        dasat.Fill(dsat, "Satuan")
        satuanbox.Items.Clear()
        For j = 0 To dsat.Tables("Satuan").Rows.Count - 1
            satuanbox.Items.Add(dsat.Tables("Satuan").Rows(j).ItemArray.GetValue(1))
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
            txtHargaJual4.Text = "" Or txtQty2.Text = "" Or txtQty3.Text = "" Or txtQty4.Text = "" Or
            lblIdBarang.Text = "" Then
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

            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Barang berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Barang gagal ditambahkan", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            With DataGridView1
                lblIdBarang.Text = .Item(0, i).Value
                nm_suplier.SelectedIndex = .Item(1, i).Value - 1
                satuanbox.SelectedIndex = .Item(2, i).Value - 1
                txtBarcode.Text = .Item(3, i).Value
                txtNama.Text = .Item(4, i).Value
                txtHargaBeli.Tag = .Item(5, i).Value
                txtHargaBeli.Text = Format(Val(txtHargaBeli.Tag), "'Rp' #,0;'Rp' -#,0")
                txtPajak.Text = .Item(6, i).Value
                txtDiskon.Text = .Item(7, i).Value
                txtHargaBeliNetto.Tag = .Item(8, i).Value
                txtHargaBeliNetto.Text = Format(Val(txtHargaBeli.Tag), "'Rp' #,0;'Rp' -#,0")
                txtStokDisplay.Text = .Item(9, i).Value
                txtStokGudang.Text = .Item(10, i).Value

                txtHargaJual1.Tag = .Item(11, i).Value
                txtHargaJual1.Text = Format(Val(txtHargaJual1.Tag), "'Rp' #,0;'Rp' -#,0")
                txtHargaJual2.Tag = .Item(12, i).Value
                txtHargaJual2.Text = Format(Val(txtHargaJual2.Tag), "'Rp' #,0;'Rp' -#,0")
                txtHargaJual3.Tag = .Item(13, i).Value
                txtHargaJual3.Text = Format(Val(txtHargaJual3.Tag), "'Rp' #,0;'Rp' -#,0")
                txtHargaJual4.Tag = .Item(14, i).Value
                txtHargaJual4.Text = Format(Val(txtHargaJual4.Tag), "'Rp' #,0;'Rp' -#,0")

                txtQty2.Text = .Item(15, i).Value
                txtQty3.Text = .Item(16, i).Value
                txtQty4.Text = .Item(17, i).Value

            End With
        Catch ex As Exception
            MsgBox("Data yang anda cari tidak ada", MsgBoxStyle.OkOnly)
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
            Dim cmd As MySqlCommand = New MySqlCommand("UPDATE  barang SET " &
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
                " WHERE  id_barang ='" & lblIdBarang.Text & "'", konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Data Barang berhasil diubah", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Data Barang gagal diubah", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        Dim Query As String
        If nm_suplier.Text = "" Or satuanbox.Text = "" Or txtBarcode.Text = "" Or txtNama.Text = "" Or txtHargaBeli.Text = "" Or
            txtPajak.Text = "" Or txtDiskon.Text = "" Or txtHargaBeliNetto.Text = "" Or txtStokDisplay.Text = "" Or
            txtStokGudang.Text = "" Or txtHargaJual1.Text = "" Or txtHargaJual2.Text = "" Or txtHargaJual3.Text = "" Or
            txtHargaJual4.Text = "" Or txtQty2.Text = "" Or txtQty3.Text = "" Or txtQty4.Text = "" Or
            lblIdBarang.Text = "" Then
            MsgBox("Harap pilih data yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Query = "delete from barang WHERE  id_barang ='" + lblIdBarang.Text + "'"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
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
            Dim sql As MySqlCommand = New MySqlCommand("select *,(stok_display+stok_gudang) as total_stok from barang where nama_barang like '%" + txtcari.Text + "%' order by nama_barang asc", konek)
            Dim ds As DataSet = New DataSet
            Dim da As MySqlDataAdapter = New MySqlDataAdapter
            da.SelectCommand = sql
            da.Fill(ds, "nama")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "nama"
            Call binding()
        End If
        If berdasarkan.SelectedIndex = 1 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select *,(stok_display+stok_gudang) as total_stok from barang where harga_jual" + syarat.SelectedItem + txtcari.Text + "", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "hargajual")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "hargajual"
                Call binding()
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 2 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select *,(stok_display+stok_gudang) as total_stok from barang where harga_beli" + syarat.SelectedItem + txtcari.Text + "", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "hargabeli")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "hargabeli"
                Call binding()
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 3 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select *,(stok_display+stok_gudang) as total_stok from barang where stok" + syarat.SelectedItem + txtcari.Text + "", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "stok")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "stok"
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
        Dim sql As MySqlCommand = New MySqlCommand("select id_suplier,nama_suplier from supplier", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        Dim i As Integer
        da.SelectCommand = sql
        da.Fill(ds, "Supplier")
        nm_suplier.Items.Clear()
        For i = 0 To ds.Tables("Supplier").Rows.Count - 1
            nm_suplier.Items.Add(ds.Tables("Supplier").Rows(i).ItemArray.GetValue(1))
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
    End Sub

    Private Sub satuanbox_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles satuanbox.DropDown
        Dim satuan As MySqlCommand = New MySqlCommand("select id_satuan,nama_satuan from satuan", konek)
        Dim dsat As DataSet = New DataSet
        Dim dasat As MySqlDataAdapter = New MySqlDataAdapter
        Dim j As Integer
        dasat.SelectCommand = satuan
        dasat.Fill(dsat, "Satuan")
        satuanbox.Items.Clear()
        For j = 0 To dsat.Tables("Satuan").Rows.Count - 1
            satuanbox.Items.Add(dsat.Tables("Satuan").Rows(j).ItemArray.GetValue(1))
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

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
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
End Class
