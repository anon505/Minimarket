Imports MySql.Data.MySqlClient
Imports System.IO
Public Class supplier
    Public Sub view()
        Dim sql As MySqlCommand = New MySqlCommand("select * from supplier", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "Supplier")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Supplier"
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
        txtharga.Text = ""
        txtnama.Text = ""
        txtstok.Text = ""
        Label4.Text = ""
        berdasarkan.SelectedIndex = 0
    End Sub
   
    Public Sub reload()
        Call view()
    End Sub

    Public Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lihat.Click
        If File.Exists(pathlogo) = True Then
            PictureBox1.Image = Bitmap.FromFile(pathlogo)
        End If
        Call view()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If (txtnama.Text = "" Or txtharga.Text = "" Or txtstok.Text = "") Then
            MsgBox("Data tentang supplier, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "INSERT INTO supplier(nama_suplier,alamat_suplier,contact_person)VALUES('" + txtnama.Text + "','" + txtharga.Text + "','" + txtstok.Text + "')"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Supplier baru berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Supplier baru gagal ditambahkan", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            With DataGridView1
                Label4.Text = .Item(0, i).Value
                txtnama.Text = .Item(1, i).Value
                txtharga.Text = .Item(2, i).Value
                txtstok.Text = .Item(3, i).Value
            End With
        Catch ex As Exception
            MsgBox("Supplier yang anda cari tidak ada", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(pathlogo) = True Then
            PictureBox1.Image = Bitmap.FromFile(pathlogo)
        End If
        Call reload()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (txtnama.Text = "" Or txtharga.Text = "" Or txtstok.Text = "") Then
            MsgBox("Data tentang supplier, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  supplier SET nama_suplier= '" + txtnama.Text + "',alamat_suplier ='" + txtharga.Text + "',contact_person ='" + txtstok.Text + "' WHERE  id_suplier ='" + Label4.Text + "'"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Data Suplier berhasil diubah", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Data Suplier gagal diubah", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        Dim Query, hapus As String
        If (txtnama.Text = "" Or txtharga.Text = "" Or txtstok.Text = "") Then
            MsgBox("Harap pilih supplier yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Dim coba As MySqlCommand = New MySqlCommand("select count(*) from barang where id_suplier='" + Label4.Text + "'", konek)
            Dim rdr As Integer = coba.ExecuteScalar
            If (rdr > 0) Then
                Dim buton As DialogResult = MsgBox("Supplier masih di pakai di Tabel Barang!!!. Jika anda klik Yes maka Barang juga akan terhapus.", MsgBoxStyle.YesNo)
                If buton = 6 Then

                    hapus = "delete from barang WHERE  id_suplier ='" + Label4.Text + "'"
                    Dim del As MySqlCommand = New MySqlCommand(hapus, konek)
                    Dim j As Integer = del.ExecuteNonQuery()

                    Query = "delete from supplier WHERE  id_suplier ='" + Label4.Text + "'"
                    Dim status As MySqlCommand = New MySqlCommand(Query, konek)
                    Dim i As Integer = status.ExecuteNonQuery()

                    If (i > 0) And j > 0 Then
                        MsgBox("Satu Data Supplier berhasil dihapus", MsgBoxStyle.OkOnly)
                        Call view()
                    Else
                        MsgBox("Satu Data Supplier gagal dihapus", MsgBoxStyle.OkOnly)
                    End If
                End If
            ElseIf Not (rdr > 0) Then
                Query = "delete from supplier WHERE  id_suplier ='" + Label4.Text + "'"
                Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MsgBox("Satu Data Supplier berhasil dihapus", MsgBoxStyle.OkOnly)
                    Call view()
                Else
                    MsgBox("Satu Data Supplier gagal dihapus", MsgBoxStyle.OkOnly)
                End If
            End If
        End If
    End Sub

    Public Sub pencarian()

        txtharga.Text = ""
        txtnama.Text = ""
        txtstok.Text = ""
        If berdasarkan.SelectedIndex = 0 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select * from supplier where id_suplier=" + txtcari.Text + " order by id_suplier asc", konek)
            Dim ds As DataSet = New DataSet
            Dim da As MySqlDataAdapter = New MySqlDataAdapter
            da.SelectCommand = sql
            da.Fill(ds, "id")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "id"
            Catch ex As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 1 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select * from supplier where nama_suplier like '%" + txtcari.Text + "%'", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "harga")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "harga"

            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 2 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select * from supplier where alamat_suplier like '%" + txtcari.Text + "%'", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "stok")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "stok"

            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
    End Sub
    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call pencarian()
    End Sub

    Private Sub syarat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call pencarian()
    End Sub

    Private Sub berasarkan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles berdasarkan.SelectedIndexChanged
        Call pencarian()
    End Sub
End Class