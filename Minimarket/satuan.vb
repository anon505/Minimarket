Imports MySql.Data.MySqlClient
Imports System.IO
Public Class satuan
    Public Sub view()
        Dim ds = newConnect.ExecuteReader("select * from satuan")
        DataGridView1.DataSource = ds
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
       
        Call view()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If (txtnama.Text = "") Then
            MsgBox("Nama Satuan masih kosong", MsgBoxStyle.OkOnly)
        Else

            Query = "INSERT INTO satuan(nama_satuan)VALUES('" + txtnama.Text + "')"
            Dim i = newConnect.ExecuteNonQuery(Query)
            If (i) Then
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
       
        Call reload()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (txtnama.Text = "") Then
            MsgBox("Data tentang barang, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  satuan SET nama_satuan='" + txtnama.Text + "' WHERE  id_satuan =" + Label4.Text + ""
            Dim i = newConnect.ExecuteNonQuery(Query)
            If (i) Then
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
            Dim rdr As Integer = newConnect.ExecuteScalar("select count(*) from barang where satuan=" + Label4.Text + "")
            If (rdr > 0) Then
                Dim buton As DialogResult = MsgBox("Satuan masih di pakai di Tabel Barang!!!. Jika anda klik Yes maka Barang juga akan terhapus.", MsgBoxStyle.YesNo)
                If buton = 6 Then

                    hapus = "delete from barang WHERE  satuan =" + Label4.Text + ""
                    Dim j = newConnect.ExecuteNonQuery(hapus)

                    Query = "delete from satuan WHERE  id_satuan =" + Label4.Text + ""
                    Dim i = newConnect.ExecuteNonQuery(Query)

                    If i And j Then
                        MsgBox("Satu Data Satuan berhasil dihapus", MsgBoxStyle.OkOnly)
                        Call view()
                    Else
                        MsgBox("Satu Data Satuan gagal dihapus", MsgBoxStyle.OkOnly)
                    End If
                End If
            Else
                Query = "delete from satuan WHERE  id_satuan =" + Label4.Text + ""
                Dim i = newConnect.ExecuteNonQuery(Query)
                If i Then
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
            Dim ds = newConnect.ExecuteReader("select * from satuan where nama_satuan like '%" + txtcari.Text + "%' order by nama_satuan asc")
            DataGridView1.DataSource = ds
        Catch
            txtcari.Text = ""
            txtcari.Focus()
        End Try
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call pencarian()
    End Sub
End Class