Imports MySql.Data.MySqlClient
Public Class chat
    Public Sub reload()
        Dim ds = newConnect.ExecuteReader("select pesan from obrolan")
        ListBox1.Items.Clear()
        For i = 0 To ds.Rows.Count - 1
            ListBox1.Items.Add(ds.Rows(i).ItemArray.GetValue(0))
        Next
    End Sub
    Public Sub reset()
        Dim ds = newConnect.ExecuteReader("select pesan from obrolan")
        If ds.Rows.Count = 21 Then
            newConnect.ExecuteNonQuery("delete * from obrolan")
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
                newConnect.ExecuteNonQuery("insert into obrolan(pesan) values('Administator" + id_kasir + ": " + TextBox1.Text + "')")
                TextBox1.Text = ""
                TextBox1.Focus()
                Call reload()
            Else
                newConnect.ExecuteNonQuery("insert into obrolan(pesan) values('Kasir" + id_kasir + ": " + TextBox1.Text + "')")
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