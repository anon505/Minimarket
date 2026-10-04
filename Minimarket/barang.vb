Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Public Class barang
    'id_suplier / id_satuan sesuai urutan item di combobox nm_suplier / satuanbox
    Private idsuplier As New List(Of String)
    Private idsatuan As New List(Of String)

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
        Call isisupplier()
        Call isisatuan()
    End Sub
    Public Sub isisupplier()
        Dim sql As MySqlCommand = New MySqlCommand("select id_suplier,nama_suplier from supplier", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        Dim i As Integer
        da.SelectCommand = sql
        da.Fill(ds, "Supplier")
        nm_suplier.Items.Clear()
        idsuplier.Clear()
        For i = 0 To ds.Tables("Supplier").Rows.Count - 1
            idsuplier.Add(ds.Tables("Supplier").Rows(i).ItemArray.GetValue(0).ToString)
            nm_suplier.Items.Add(ds.Tables("Supplier").Rows(i).ItemArray.GetValue(1))
        Next
    End Sub
    Public Sub isisatuan()
        Dim satuan As MySqlCommand = New MySqlCommand("select id_satuan,nama_satuan from satuan", konek)
        Dim dsat As DataSet = New DataSet
        Dim dasat As MySqlDataAdapter = New MySqlDataAdapter
        Dim j As Integer
        dasat.SelectCommand = satuan
        dasat.Fill(dsat, "Satuan")
        satuanbox.Items.Clear()
        idsatuan.Clear()
        For j = 0 To dsat.Tables("Satuan").Rows.Count - 1
            idsatuan.Add(dsat.Tables("Satuan").Rows(j).ItemArray.GetValue(0).ToString)
            satuanbox.Items.Add(dsat.Tables("Satuan").Rows(j).ItemArray.GetValue(1))
        Next
    End Sub
    Public Function pilihanvalid() As Boolean
        If nm_suplier.SelectedIndex < 0 Or satuanbox.SelectedIndex < 0 Then
            MsgBox("Supplier dan Satuan harus dipilih dari daftar", MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True
    End Function
    Public Sub isiparameter(ByVal cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@nama", txtnama.Text)
        cmd.Parameters.AddWithValue("@id_suplier", idsuplier(nm_suplier.SelectedIndex))
        cmd.Parameters.AddWithValue("@harga_beli", Val(txthargabeli.Tag))
        cmd.Parameters.AddWithValue("@harga_jual", Val(txthargajual.Tag))
        cmd.Parameters.AddWithValue("@stok", Val(txtstok.Text))
        cmd.Parameters.AddWithValue("@satuan", idsatuan(satuanbox.SelectedIndex))
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
        ElseIf pilihanvalid() Then
            Query = "INSERT INTO barang(nama_barang,id_suplier,harga_beli,harga_jual,stok,satuan)VALUES(@nama,@id_suplier,@harga_beli,@harga_jual,@stok,@satuan)"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Call isiparameter(cmd)
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
                nm_suplier.SelectedIndex = idsuplier.IndexOf(.Item(1, i).Value.ToString)
                txtnama.Text = .Item(2, i).Value
                txthargabeli.Tag = .Item(3, i).Value
                txthargabeli.Text = Format(Val(txthargabeli.Tag), "'Rp' #,0;'Rp' -#,0")

                txthargajual.Tag = .Item(4, i).Value
                txthargajual.Text = Format(Val(txthargajual.Tag), "'Rp' #,0;'Rp' -#,0")

                txtstok.Text = .Item(5, i).Value
                satuanbox.SelectedIndex = idsatuan.IndexOf(.Item(6, i).Value.ToString)
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
        ElseIf pilihanvalid() Then
            Query = "UPDATE  barang SET id_suplier=@id_suplier,  nama_barang=@nama,harga_beli=@harga_beli,harga_jual=@harga_jual,stok=@stok,satuan=@satuan WHERE  id_barang=@id"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Call isiparameter(cmd)
            cmd.Parameters.AddWithValue("@id", Label4.Text)
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
            Query = "delete from barang WHERE  id_barang=@id"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            cmd.Parameters.AddWithValue("@id", Label4.Text)
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
            Dim sql As MySqlCommand = New MySqlCommand("select * from barang where nama_barang like @cari order by nama_barang asc", konek)
            sql.Parameters.AddWithValue("@cari", "%" + txtcari.Text + "%")
            Dim ds As DataSet = New DataSet
            Dim da As MySqlDataAdapter = New MySqlDataAdapter
            da.SelectCommand = sql
            da.Fill(ds, "nama")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "nama"
            Call binding()
        End If
        If berdasarkan.SelectedIndex >= 1 And berdasarkan.SelectedIndex <= 3 Then
            If Not IsNumeric(txtcari.Text) Then
                txtcari.Text = ""
                txtcari.Focus()
                Exit Sub
            End If
            'nama kolom & operator tidak bisa jadi parameter, jadi hanya diambil dari daftar tetap
            Dim kolom() As String = {"", "harga_jual", "harga_beli", "stok"}
            Dim sql As MySqlCommand = New MySqlCommand("select * from barang where " + kolom(berdasarkan.SelectedIndex) + operatorcari() + "@cari", konek)
            sql.Parameters.AddWithValue("@cari", Val(txtcari.Text))
            Dim ds As DataSet = New DataSet
            Dim da As MySqlDataAdapter = New MySqlDataAdapter
            da.SelectCommand = sql
            da.Fill(ds, kolom(berdasarkan.SelectedIndex))
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = kolom(berdasarkan.SelectedIndex)
            Call binding()
        End If
    End Sub
    Public Function operatorcari() As String
        Select Case CStr(syarat.SelectedItem)
            Case "<", ">", "=", "<=", ">="
                Return CStr(syarat.SelectedItem)
        End Select
        Return "="
    End Function
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
        Call isisupplier()
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
        Call isisatuan()
    End Sub
    Private Sub txtstok_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstok.KeyPress
        Call hanyaangka(e)
    End Sub

   
End Class
