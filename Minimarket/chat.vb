Imports MySql.Data.MySqlClient
Public Class chat
    Public Sub reload()
        Dim sql As MySqlCommand = New MySqlCommand("select pesan from obrolan", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        Dim i As Integer
        da.SelectCommand = sql
        da.Fill(ds, "obrolan")
        ListBox1.Items.Clear()
        For i = 0 To ds.Tables("obrolan").Rows.Count - 1
            ListBox1.Items.Add(ds.Tables("obrolan").Rows(i).ItemArray.GetValue(0))
        Next
    End Sub
    Public Sub reset()
        Dim sql As MySqlCommand = New MySqlCommand("select pesan from obrolan", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "obrolan")
        If ds.Tables("obrolan").Rows.Count = 21 Then
            Dim hapus As MySqlCommand = New MySqlCommand("delete * from obrolan", konek)
            hapus.ExecuteNonQuery()
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call reload()
    End Sub

    Private Sub chat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call reset()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim tombol As Integer = Asc(e.KeyChar)
        If tombol = 13 Then
            If hak_akses = "1" Then
                Dim kirim As MySqlCommand = New MySqlCommand("insert into obrolan(pesan) values('Administator" + id_kasir + ": " + TextBox1.Text + "')", konek)
                kirim.ExecuteNonQuery()
                TextBox1.Text = ""
                TextBox1.Focus()
                Call reload()
            Else
                Dim kirim As MySqlCommand = New MySqlCommand("insert into obrolan(pesan) values('Kasir" + id_kasir + ": " + TextBox1.Text + "')", konek)
                kirim.ExecuteNonQuery()
                TextBox1.Text = ""
                TextBox1.Focus()
                Call reload()
            End If
        End If
    End Sub
  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Aktifkan Autorefresh" Then
            Timer1.Enabled = True
            Button1.Text = "Nonaktifkan Autorefresh"
        ElseIf Button1.Text = "Nonaktifkan Autorefresh" Then
            Timer1.Enabled = False
            Button1.Text = "Aktifkan Autorefresh"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call reload()
    End Sub
End Class