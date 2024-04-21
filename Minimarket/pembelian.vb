Imports MySql.Data.MySqlClient
Public Class pembelian
    Public Sub baru()
        Dim sql As MySqlCommand = New MySqlCommand("SELECT pembelian.id_barang, barang.nama_barang, barang.harga_beli, pembelian.jumlah,satuan.nama_satuan FROM pembelian ,barang,satuan where barang.id_barang = pembelian.id_barang and pembelian.status='belum' and satuan.id_satuan=barang.satuan and pembelian.id_kasir = " + Label9.Text, konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "notabeli")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "notabeli"
        id_barang.Text = ""
    End Sub

    Private Sub pembelian_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label9.Text = id_kasir
        Label7.Text = hak_akses
        Me.Text = "Pembelian dengan Kasir" + id_kasir
        Call baru()
    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid.KeyPress
        Call beli(e)
    End Sub
    Public Sub beli(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If tombol = 13 And Not (txtharga.Text = "") Then
              total.Tag += Val(txtharga.Tag) * Val(jumlah.Text)
            total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")

            Dim ada As MySqlCommand = New MySqlCommand("select id_barang from pembelian where id_barang='" + txtid.Text + "' and status='belum' and id_kasir='" + Label9.Text + "'", konek)
            Dim status As String = ada.ExecuteScalar()
            If Not (status = "") Then
                Dim update As MySqlCommand = New MySqlCommand(" UPDATE  barang SET  stok =  stok+" + jumlah.Text + " WHERE  id_barang =" + txtid.Text + ";", konek)
                update.ExecuteNonQuery()
                Dim update1 As MySqlCommand = New MySqlCommand(" UPDATE  pembelian SET  jumlah =  jumlah+" + jumlah.Text + " WHERE  id_barang ='" + txtid.Text + "'  and status='belum' and id_kasir='" + Label9.Text + "';", konek)
                update1.ExecuteNonQuery()
                Call baru()
            Else
                Dim input As MySqlCommand = New MySqlCommand("insert into pembelian(id_barang,id_kasir,tgl_pembelian,jumlah,status)values('" + txtid.Text + "','" + Label9.Text + "',now(),'" + jumlah.Text + "','belum')", konek)
                input.ExecuteNonQuery()
                Call baru()
            End If
        End If
    End Sub

    Private Sub txtid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtid.TextChanged
        Try
            Dim cmd As MySqlCommand = New MySqlCommand("Select harga_beli from barang where id_barang='" + txtid.Text + "'", konek)
            Dim hargabeli As String = cmd.ExecuteScalar
            txtharga.Text = hargabeli
            txtharga.Tag = Val(txtharga.Text)
            txtharga.Text = Format(Val(txtharga.Text), "'Rp' #,0;'Rp' -#,0")

            Dim sat As MySqlCommand = New MySqlCommand("select satuan.nama_satuan from satuan,barang  where id_barang='" + txtid.Text + "' and barang.satuan=satuan.id_satuan", konek)
            Dim satuan1 As String = sat.ExecuteScalar
            satuan.Text = satuan1
            Dim nam As MySqlCommand = New MySqlCommand("select nama_barang from barang  where id_barang='" + txtid.Text + "'", konek)
            Dim nama1 As String = nam.ExecuteScalar
            nama.Text = nama1
            If txtharga.Text = "" Or txtharga.Text = "Rp 0" Then
                jumlah.Text = ""
            Else
                jumlah.Text = "1"
            End If
        Catch ex As Exception
            txtharga.Text = ""
            txtid.Text = ""
            satuan.Text = ""
            MsgBox(ex.ToString, MsgBoxStyle.OkCancel)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        With DataGridView1
            id_barang.Text = .Item(0, i).Value
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim buton As DialogResult = MsgBox("Anda yakin ingin menghapus barang ini?", MsgBoxStyle.YesNo)
        If (buton = 6) Then
            Dim harga As MySqlCommand = New MySqlCommand("Select harga_beli from barang where id_barang='" + id_barang.Text + "'", konek)
            Dim hargabeli As String = harga.ExecuteScalar
            Dim jumlah As MySqlCommand = New MySqlCommand("Select jumlah from pembelian where id_barang='" + id_barang.Text + "'and status='belum' and id_kasir='" + Label9.Text + "'", konek)
            Dim a As String = jumlah.ExecuteScalar
            total.Tag = Val(total.Tag) - Val(a * hargabeli)
            total.Text = Format(Val(total.Tag), "'Rp' #,0;'Rp' -#,0")

            Dim hapus As MySqlCommand = New MySqlCommand("delete from pembelian where id_barang='" + id_barang.Text + "' and status='belum' and id_kasir='" + Label9.Text + "'", konek)
            hapus.ExecuteNonQuery()
            Call baru()
        ElseIf (buton = 7) Then
            Call baru()
        End If
    End Sub

    Private Sub jumlah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles jumlah.KeyPress
        Call beli(e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim updatebaru As MySqlCommand = New MySqlCommand(" UPDATE  pembelian SET  status='cetak' WHERE status='belum' and id_kasir='" + Label9.Text + "';", konek)
        updatebaru.ExecuteNonQuery()
        Call baru()
        txtid.Text = ""
        total.Text = "0"
        total.Tag = 0
        satuan.Text = ""
        txtid.Focus()
    End Sub
End Class