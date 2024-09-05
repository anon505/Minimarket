Imports MySql.Data.MySqlClient
Imports System.IO
Public Class supplier
    Public Sub view()
        txtharga.Text = ""
        txtnama.Text = ""
        txtstok.Text = ""
        Label4.Text = ""
        berdasarkan.SelectedIndex = 0
        Dim ds = newConnect.ExecuteReader("select * from suplier")
        DataGridView1.DataSource = ds
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()

    End Sub
   

    Public Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lihat.Click
       
        Call view()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If (txtnama.Text = "" Or txtharga.Text = "" Or txtstok.Text = "") Then
            MsgBox("Data tentang suplier, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "INSERT INTO suplier(nama_suplier,alamat_suplier,contact_person)VALUES('" + txtnama.Text + "','" + txtharga.Text + "','" + txtstok.Text + "')"

            Dim i = newConnect.ExecuteNonQuery(Query)
            If i Then
                MsgBox("Suplier baru berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Suplier baru gagal ditambahkan", MsgBoxStyle.OkOnly)
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
       
        Call view()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (txtnama.Text = "" Or txtharga.Text = "" Or txtstok.Text = "") Then
            MsgBox("Data tentang suplier, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  suplier SET nama_suplier= '" + txtnama.Text + "',alamat_suplier ='" + txtharga.Text + "',contact_person ='" + txtstok.Text + "' WHERE  id_suplier =" + Label4.Text + ""

            Dim i = newConnect.ExecuteNonQuery(Query)
            If (i) Then
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
            MsgBox("Harap pilih suplier yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Dim rdr As Integer = newConnect.ExecuteScalar("select count(*) from barang where id_suplier=" + Label4.Text + "")
            If (rdr > 0) Then
                Dim buton As DialogResult = MsgBox("Supplier masih di pakai di Tabel Barang!!!. Jika anda klik Yes maka Barang juga akan terhapus.", MsgBoxStyle.YesNo)
                If buton = 6 Then

                    hapus = "delete from barang WHERE  id_suplier =" + Label4.Text + ""
                    Dim j = newConnect.ExecuteNonQuery(hapus)

                    Query = "delete from suplier WHERE  id_suplier =" + Label4.Text + ""
                    Dim i As Integer = newConnect.ExecuteNonQuery(Query)

                    If i And j Then
                        MsgBox("Satu Data Suplier berhasil dihapus", MsgBoxStyle.OkOnly)
                        Call view()
                    Else
                        MsgBox("Satu Data Suplier gagal dihapus", MsgBoxStyle.OkOnly)
                    End If
                End If
            ElseIf Not (rdr > 0) Then
                Query = "delete from suplier WHERE  id_suplier =" + Label4.Text + ""
                Dim i = newConnect.ExecuteNonQuery(Query)
                If i Then
                    MsgBox("Satu Data Suplier berhasil dihapus", MsgBoxStyle.OkOnly)
                    Call view()
                Else
                    MsgBox("Satu Data Suplier gagal dihapus", MsgBoxStyle.OkOnly)
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
                Dim ds = newConnect.ExecuteReader("select * from suplier where id_suplier=" + txtcari.Text + " order by id_suplier asc")
          
            DataGridView1.DataSource = ds
            Catch ex As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 1 Then
            Try
                Dim ds = newConnect.ExecuteReader("select * from suplier where nama_suplier like '%" + txtcari.Text + "%'")
            
                DataGridView1.DataSource = ds

            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 2 Then
            Try
                Dim ds = newConnect.ExecuteReader("select * from suplier where alamat_suplier like '%" + txtcari.Text + "%'")
             
                DataGridView1.DataSource = ds

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