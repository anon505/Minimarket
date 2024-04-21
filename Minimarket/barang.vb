Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Public Class barang

    Public Sub view()
        Dim sql As MySqlCommand = New MySqlCommand("select * from barang", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "Barang")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Barang"
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
        txthargabeli.Text = ""
        txthargajual.Text = ""
        txtnama.Text = ""
        txtstok.Text = ""
        Label4.Text = ""
        nm_suplier.Text = ""
        satuanbox.Text = ""
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
          If File.Exists(pathlogo) = True Then
                PictureBox1.Image = Bitmap.FromFile(pathlogo)
            End If
        Call view()
        Call binding()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If (satuanbox.Text = "" Or nm_suplier.Text = "" Or txtnama.Text = "" Or txthargabeli.Text = "" Or txthargajual.Text = "" Or txtstok.Text = "") Then
            MsgBox("Data tentang barang, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "INSERT INTO barang(nama_barang,id_suplier,harga_beli,harga_jual,stok,satuan)VALUES('" + txtnama.Text + "','" + (nm_suplier.SelectedIndex + 1).ToString + "','" + txthargabeli.Tag.ToString + "','" + txthargajual.Tag.ToString + "','" + txtstok.Text + "','" + (satuanbox.SelectedIndex + 1).ToString + "')"
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
                Label4.Text = .Item(0, i).Value
                nm_suplier.SelectedIndex = .Item(1, i).Value - 1
                txtnama.Text = .Item(2, i).Value
                txthargabeli.Tag = .Item(3, i).Value
                txthargabeli.Text = Format(Val(txthargabeli.Tag), "'Rp' #,0;'Rp' -#,0")

                txthargajual.Tag = .Item(4, i).Value
                txthargajual.Text = Format(Val(txthargajual.Tag), "'Rp' #,0;'Rp' -#,0")

                txtstok.Text = .Item(5, i).Value
                satuanbox.SelectedIndex = .Item(6, i).Value - 1
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
        If File.Exists(pathlogo) = True Then
            PictureBox1.Image = Bitmap.FromFile(pathlogo)
        End If
        Call reload()
        Call binding()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (Label4.Text = "") Then
            MsgBox("Harap pilih data yang akan di edit", MsgBoxStyle.OkOnly)
        ElseIf (satuanbox.Text = "" Or nm_suplier.Text = "" Or txtnama.Text = "" Or txthargabeli.Text = "" Or txthargajual.Text = "" Or txtstok.Text = "") Then
            MsgBox("Data tentang barang, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  barang SET id_suplier='" + (nm_suplier.SelectedIndex + 1).ToString + "',  nama_barang= '" + txtnama.Text + "',harga_beli ='" + txthargabeli.Tag.ToString + "',harga_jual='" + txthargajual.Tag.ToString + "',stok ='" + txtstok.Text + "',satuan='" + (satuanbox.SelectedIndex + 1).ToString + "' WHERE  id_barang ='" + Label4.Text + "'"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
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
        If (satuanbox.Text = "" Or nm_suplier.Text = "" Or txtnama.Text = "" Or txthargabeli.Text = "" Or txthargajual.Text = "" Or txtstok.Text = "") Then
            MsgBox("Harap pilih data yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Query = "delete from barang WHERE  id_barang ='" + Label4.Text + "'"
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
        txthargabeli.Text = ""
        txthargajual.Text = ""
        txtnama.Text = ""
        txtstok.Text = ""
        If berdasarkan.SelectedIndex = 0 Then
            Dim sql As MySqlCommand = New MySqlCommand("select * from barang where nama_barang like '%" + txtcari.Text + "%' order by nama_barang asc", konek)
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
                Dim sql As MySqlCommand = New MySqlCommand("select * from barang where harga_jual" + syarat.SelectedItem + txtcari.Text + "", konek)
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
                Dim sql As MySqlCommand = New MySqlCommand("select * from barang where harga_beli" + syarat.SelectedItem + txtcari.Text + "", konek)
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
                Dim sql As MySqlCommand = New MySqlCommand("select * from barang where stok" + syarat.SelectedItem + txtcari.Text + "", konek)
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

    Private Sub txthargabeli_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthargabeli.GotFocus
        If (Label4.Text = "") Then
            txthargabeli.Tag = ""
        End If
        txthargabeli.Text = txthargabeli.Tag
    End Sub
    Public Sub hanyaangka(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim valid As String = "0 1 2 3 4 5 6 7 8 9"
        Dim x As Long = InStr(valid, e.KeyChar)
        If x = 0 And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 32 Then
            MsgBox("Harap masukkan angka", MsgBoxStyle.OkOnly)
            e.KeyChar = ""
        End If
    End Sub
    Private Sub txthargabeli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthargabeli.KeyPress
        Call hanyaangka(e)
    End Sub

    Private Sub txthargabeli_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthargabeli.LostFocus
        txthargabeli.Tag = txthargabeli.Text
        txthargabeli.Text = Format(Val(txthargabeli.Tag), "'Rp' #,0;'Rp' -#,0")
    End Sub

    Private Sub txthargajual_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthargajual.GotFocus
        If (Label4.Text = "") Then
            txthargajual.Tag = ""
        End If
        txthargajual.Text = txthargajual.Tag
    End Sub

    Private Sub txthargajual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthargajual.KeyPress
        Call hanyaangka(e)
    End Sub

    Private Sub txthargajual_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthargajual.LostFocus
        txthargajual.Tag = txthargajual.Text
        txthargajual.Text = Format(Val(txthargajual.Tag), "'Rp' #,0;'Rp' -#,0")
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
    Private Sub txtstok_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstok.KeyPress
        Call hanyaangka(e)
    End Sub

   
End Class
