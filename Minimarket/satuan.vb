Imports MySql.Data.MySqlClient
Imports System.IO
Public Class satuan
    Public Sub view()
        Dim sql As MySqlCommand = New MySqlCommand("select * from satuan", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "satuan")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "satuan"
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
        txtcari.Text = ""
        txtnama.Text = ""
    End Sub
    Public Sub reload()
        Call view()
    End Sub

    Private Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lihat.Click
        If File.Exists(pathlogo) = True Then
            PictureBox1.Image = Bitmap.FromFile(pathlogo)
        End If
        Call view()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If (txtnama.Text = "") Then
            MsgBox("Nama Satuan masih kosong", MsgBoxStyle.OkOnly)
        Else

            Query = "INSERT INTO satuan(nama_satuan)VALUES(@nama)"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            cmd.Parameters.AddWithValue("@nama", txtnama.Text)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Satuan Baru berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Satuan Baru gagal ditambahkan", MsgBoxStyle.OkOnly)
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
               End With
        Catch ex As Exception
            MsgBox("Satuan yang anda cari tidak ada", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub satuan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If File.Exists(pathlogo) = True Then
            PictureBox1.Image = Bitmap.FromFile(pathlogo)
        End If
        Call reload()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (txtnama.Text = "") Then
            MsgBox("Data tentang barang, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  satuan SET nama_satuan=@nama WHERE  id_satuan=@id"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            cmd.Parameters.AddWithValue("@nama", txtnama.Text)
            cmd.Parameters.AddWithValue("@id", Label4.Text)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Data Satuan berhasil diubah", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Data Satuan gagal diubah", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hapus.Click
        Dim Query, hapus As String
        If (txtnama.Text = "") Then
            MsgBox("Harap pilih satuan yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Dim coba As MySqlCommand = New MySqlCommand("select count(*) from barang where satuan=@id", konek)
            coba.Parameters.AddWithValue("@id", Label4.Text)
            Dim rdr As Integer = coba.ExecuteScalar
            If (rdr > 0) Then
                Dim buton As DialogResult = MsgBox("Satuan masih di pakai di Tabel Barang!!!. Jika anda klik Yes maka Barang juga akan terhapus.", MsgBoxStyle.YesNo)
                If buton = 6 Then

                    hapus = "delete from barang WHERE  satuan=@id"
                    Dim del As MySqlCommand = New MySqlCommand(hapus, konek)
                    del.Parameters.AddWithValue("@id", Label4.Text)
                    Dim j As Integer = del.ExecuteNonQuery()

                    Query = "delete from satuan WHERE  id_satuan=@id"
                    Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
                    cmd.Parameters.AddWithValue("@id", Label4.Text)
                    Dim i As Integer = cmd.ExecuteNonQuery()

                    If (i > 0) And (j > 0) Then
                        MsgBox("Satu Data Satuan berhasil dihapus", MsgBoxStyle.OkOnly)
                        Call view()
                    Else
                        MsgBox("Satu Data Satuan gagal dihapus", MsgBoxStyle.OkOnly)
                    End If
                End If
            Else
                Query = "delete from satuan WHERE  id_satuan=@id"
                Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
                cmd.Parameters.AddWithValue("@id", Label4.Text)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MsgBox("Satu Data Satuan berhasil dihapus", MsgBoxStyle.OkOnly)
                    Call view()
                Else
                    MsgBox("Satu Data Satuan gagal dihapus", MsgBoxStyle.OkOnly)
                End If
            End If
        End If
    End Sub
    Public Sub pencarian()
       txtnama.Text = ""
        Try
            Dim sql As MySqlCommand = New MySqlCommand("select * from satuan where nama_satuan like @cari order by nama_satuan asc", konek)
            sql.Parameters.AddWithValue("@cari", "%" + txtcari.Text + "%")
            Dim ds As DataSet = New DataSet
            Dim da As MySqlDataAdapter = New MySqlDataAdapter
            da.SelectCommand = sql
            da.Fill(ds, "namasatuan")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "namasatuan"
        Catch
            txtcari.Text = ""
            txtcari.Focus()
        End Try
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call pencarian()
    End Sub
End Class