Imports MySql.Data.MySqlClient
Imports System.Data
Public Class penjualan
    Public Sub baru()
        Dim sql As MySqlCommand = New MySqlCommand("SELECT penjualan.id_barang, barang.nama_barang, barang.harga_jual, penjualan.total,satuan.nama_satuan FROM penjualan ,barang,satuan where barang.id_barang = penjualan.id_barang and penjualan.status='belum' and satuan.id_satuan=barang.satuan and penjualan.id_kasir = " + Label9.Text, konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "nota")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "nota"
        id_barang.Text = ""
    End Sub
    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid.KeyPress
        total.Text = total.Tag
        If (total.Text = total.Tag) Then
            total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")
        End If
        Call jual(e)
        dibayar.Text = dibayar.Tag
         Call kembalian()
    End Sub
    Public Sub jual(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If tombol = 13 And Not (txtharga.Text = "") And Not (qty.Text = "") Then
            total.Tag += Val(txtharga.Tag) * Val(qty.Text)
            total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")

            Dim ada As MySqlCommand = New MySqlCommand("select id_barang from penjualan where id_barang='" + txtid.Text + "' and status='belum' and id_kasir='" + Label9.Text + "'", konek)
            Dim status As String = ada.ExecuteScalar()
            If Not (status = "") Then
                Dim update As MySqlCommand = New MySqlCommand(" UPDATE  barang SET  stok =  stok-" + qty.Text + " WHERE  id_barang =" + txtid.Text + ";", konek)
                update.ExecuteNonQuery()
                Dim update1 As MySqlCommand = New MySqlCommand(" UPDATE  penjualan SET  total =  total+" + qty.Text + " WHERE  id_barang ='" + txtid.Text + "'  and status='belum' and id_kasir='" + Label9.Text + "';", konek)
                update1.ExecuteNonQuery()
                Call baru()
            Else
                Dim input As MySqlCommand = New MySqlCommand("insert into penjualan(id_barang,id_kasir,total,status,tanggal)values('" + txtid.Text + "','" + Label9.Text + "','" + qty.Text + "','belum',now())", konek)
                input.ExecuteNonQuery()
                Call baru()
            End If
        End If
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid.TextChanged
        Try
            Dim cmd As MySqlCommand = New MySqlCommand("Select harga_jual from barang where id_barang='" + txtid.Text + "'", konek)
            Dim hargajual As String = cmd.ExecuteScalar
            txtharga.Text = hargajual
            txtharga.Tag = Val(txtharga.Text)
            txtharga.Text = Format(Val(txtharga.Text), "'Rp' #,0;'Rp' -#,0")

            Dim sat As MySqlCommand = New MySqlCommand("select satuan.nama_satuan from satuan,barang  where id_barang='" + txtid.Text + "' and barang.satuan=satuan.id_satuan", konek)
            Dim satuan1 As String = sat.ExecuteScalar
            satuan.Text = satuan1
            If txtharga.Text = "" Or txtharga.Text = "Rp 0" Then
                qty.Text = ""
            Else
                qty.Text = "1"
            End If
        Catch ex As Exception
            txtharga.Text = ""
            txtid.Text = ""
            satuan.Text = ""
            MsgBox(ex.ToString, MsgBoxStyle.OkCancel)
        End Try
    End Sub



    Private Sub penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label9.Text = id_kasir
        Label7.Text = hak_akses
        Me.Text = "Penjualan dengan Kasir" + id_kasir
        Call Button3_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        formnota.Show()
    End Sub

    Private Sub dibayar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dibayar.Click
        dibayar.Text = dibayar.Tag
    End Sub

  
    Private Sub dibayar_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dibayar.KeyPress
        Dim tombol As Integer = Asc(e.KeyChar)
        Dim valid As String = " 1 2 3 4 5 6 7 8 9 0 "
        Dim x As Long = InStr(valid, e.KeyChar)
        If x = 0 And tombol <> 8 And tombol <> 32 And tombol <> 13 Then
            MsgBox("Harap masukkan angka", MsgBoxStyle.OkOnly)
            e.KeyChar = ""
            dibayar.Focus()
        End If
        If tombol = 13 Then
            Call kembalian()
        End If
    End Sub
    Public Sub kembalian()
        dibayar.Tag = Val(dibayar.Text)
        dibayar.Text = Format(Val(dibayar.Tag), "'Rp' #,0;'Rp' -#,0")
        txtid.Focus()
        sisa.Tag = Val(dibayar.Tag) - Val(total.Tag)
        sisa.Text = Format(Val(sisa.Tag), "'Rp' #,0;'Rp' -#,0")
    End Sub
   

    Private Sub DataGridView1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        With DataGridView1
            id_barang.Text = .Item(0, i).Value
        End With
    End Sub

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If id_barang.Text = "" Then
            MsgBox("Klik satu Baris Data yang akan di Hapus", MsgBoxStyle.OkOnly)
        Else
            Dim buton As DialogResult = MsgBox("Anda yakin ingin menghapus barang ini?", MsgBoxStyle.YesNo)
            If (buton = 6) Then
                Dim harga As MySqlCommand = New MySqlCommand("Select harga_jual from barang where id_barang='" + id_barang.Text + "'", konek)
                Dim hargajual As String = harga.ExecuteScalar
                Dim jumlah As MySqlCommand = New MySqlCommand("Select total from penjualan where id_barang='" + id_barang.Text + "'and status='belum' and id_kasir='" + Label9.Text + "'", konek)
                Dim a As String = jumlah.ExecuteScalar
                total.Tag = Val(total.Tag) - Val(a * hargajual)
                total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")
                Dim hapus As MySqlCommand = New MySqlCommand("delete from penjualan where id_barang='" + id_barang.Text + "' and status='belum' and id_kasir='" + Label9.Text + "'", konek)
                hapus.ExecuteNonQuery()
                Call baru()
                dibayar.Text = dibayar.Tag
                Call kembalian()
            ElseIf (buton = 7) Then
                Call baru()
            End If
        End If
    End Sub

   
    Private Sub qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles qty.KeyPress
        Dim tombol As Integer = Asc(e.KeyChar)
        Dim valid As String = " 1 2 3 4 5 6 7 8 9 0 "
        Dim x As Long = InStr(valid, e.KeyChar)
        total.Text = total.Tag
        If (total.Text = total.Tag) Then
            total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")
        End If
        If x = 0 And tombol <> 8 And tombol <> 32 And tombol <> 13 Then
            MsgBox("Harap masukkan angka", MsgBoxStyle.OkOnly)
            e.KeyChar = ""
            qty.Focus()
        End If
        Call jual(e)
        dibayar.Text = dibayar.Tag
        Call kembalian()
    End Sub

    
    Public Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim updatebaru As MySqlCommand = New MySqlCommand(" UPDATE  penjualan SET  status='cetak' WHERE status='belum' and id_kasir='" + Label9.Text + "';", konek)
        updatebaru.ExecuteNonQuery()
        Call baru()
        txtid.Text = ""
        total.Tag = 0
        total.Text = ""
        satuan.Text = ""
        dibayar.Text = ""
        dibayar.Tag = 0
        sisa.Tag = 0
        sisa.Text = ""
        txtid.Focus()
    End Sub

  
    Private Sub qty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles qty.TextChanged
        qty.Focus()
    End Sub
End Class