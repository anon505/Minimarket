Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Public Class kasir
    Public Sub view()
        Dim sql As MySqlCommand = New MySqlCommand("select * from kasir", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "Kasir")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Kasir"
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
        txtnama.Text = ""
        txtpassword.Text = ""
        txtalamat.Text = ""
        Label4.Text = ""
        hak_akses.Text = ""
        berdasarkan.SelectedIndex = 0
        hak_akses.Items.Clear()
        hak_akses.Items.Add("1. Administrator")
        hak_akses.Items.Add("2. Kasir")
        Button1.Text = "Aktifkan Kasir"
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
        If (hak_akses.Text = "" Or txtnama.Text = "" Or txtalamat.Text = "" Or txtpassword.Text = "") Then
            MsgBox("Data tentang Kasir, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "INSERT INTO kasir(nama_kasir,password,alamat,type,status)VALUES('" + txtnama.Text + "','" + txtpassword.Text + "','" + txtalamat.Text + "','" + (hak_akses.SelectedIndex + 1).ToString + "','Tidak Aktif')"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Kasir baru berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Kasir gagal ditambahkan", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            With DataGridView1
                Label4.Text = .Item(0, i).Value
                hak_akses.SelectedIndex = .Item(4, i).Value - 1
                txtnama.Text = .Item(1, i).Value
                txtpassword.Text = .Item(2, i).Value
                txtalamat.Text = .Item(3, i).Value
                If (.Item(5, i).Value.ToString = "Aktif") Then
                    Button1.Text = "Nonaktifkan Kasir"
                Else
                    Button1.Text = "Aktifkan Kasir"
                End If
            End With
        Catch ex As Exception
            MsgBox("Data yang anda cari tidak ada", MsgBoxStyle.OkOnly)
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
        If (hak_akses.Text = "" Or txtnama.Text = "" Or txtalamat.Text = "") Then
            MsgBox("Data tentang kasir, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  kasir SET type='" + (hak_akses.SelectedIndex + 1).ToString + "',  nama_kasir= '" + txtnama.Text + "',  password= '" + txtpassword.Text + "',alamat ='" + txtalamat.Text + "' WHERE  id_kasir ='" + Label4.Text + "'"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Data Kasir berhasil diubah", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Data Kasir gagal diubah", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        Dim Query As String
        If (hak_akses.Text = "" Or txtnama.Text = "" Or txtalamat.Text = "") Then
            MsgBox("Harap pilih data yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Query = "delete from kasir WHERE  id_kasir ='" + Label4.Text + "'"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Satu Kasir berhasil dihapus", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Satu Kasir gagal dihapus", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub pencarian()
        hak_akses.Text = ""
        txtnama.Text = ""
        txtalamat.Text = ""
        If berdasarkan.SelectedIndex = 0 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select * from kasir where id_kasir=" + txtcari.Text + "'", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "id")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "id"
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 1 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select * from kasir where nama_kasir  like '%" + txtcari.Text + "%'", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "nama")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "nama"
            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
        If berdasarkan.SelectedIndex = 2 Then
            Try
                Dim sql As MySqlCommand = New MySqlCommand("select * from kasir where alamat like '%" + txtcari.Text + "%'", konek)
                Dim ds As DataSet = New DataSet
                Dim da As MySqlDataAdapter = New MySqlDataAdapter
                da.SelectCommand = sql
                da.Fill(ds, "alamat")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "alamat"

            Catch e As Exception
                txtcari.Text = ""
                txtcari.Focus()
            End Try
        End If
    End Sub
    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call pencarian()
    End Sub
    Private Sub berasarkan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles berdasarkan.SelectedIndexChanged
        Call pencarian()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If (Label4.Text = "") Then
            MsgBox("Kasir belum dipilih", MsgBoxStyle.OkOnly)
        ElseIf (Button1.Text = "Aktifkan Kasir") Then
           
            Dim status As MySqlCommand = New MySqlCommand("update kasir set status='Aktif' where id_kasir='" + Label4.Text + "'", konek)
            status.ExecuteNonQuery()
            MsgBox("Kasir No" + Label4.Text + " telah Aktif", MsgBoxStyle.OkOnly)
            Call view()
        ElseIf (Button1.Text = "Nonaktifkan Kasir") Then
           
            Dim status As MySqlCommand = New MySqlCommand("update kasir set status='Tidak Aktif' where id_kasir='" + Label4.Text + "'", konek)
            status.ExecuteNonQuery()
            MsgBox("Kasir No" + Label4.Text + " di Nonaktifkan", MsgBoxStyle.OkOnly)
            Call view()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
