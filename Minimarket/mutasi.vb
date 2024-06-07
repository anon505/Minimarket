Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Globalization

Public Class mutasi
    Dim debounceSubject As DebounceDispatcher
    Private Sub initializeDebounce()
        debounceSubject = New DebounceDispatcher()

    End Sub
    Private Sub textNominal_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textNominal.TextChanged
        debounceSubject.Debounce(100, Function(p)
                                          debouncedTextNominalChanged(textNominal.Text)
                                      End Function)
    End Sub
    Private Sub debouncedTextNominalChanged(ByVal textBayarString As String)
        If Not textBayarString = "" Then
            textNominal.Text = Format(Integer.Parse(textBayarString.Replace(",", "").Replace(".", "")), "#,0;-#,0")
            textNominal.SelectionStart = textNominal.Text.Length
            textNominal.SelectionLength = 0
        End If

    End Sub
    Public Sub view()
        Dim startTime = DateTime.ParseExact(txtStartDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
        Dim endTime = DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
        Console.WriteLine(startTime & " dan " & endTime)

        Dim sql As MySqlCommand = New MySqlCommand("select * from mutasi where created_at >= '" & startTime & "' AND created_at <= '" & endTime & "' order by created_at desc", konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "Mutasi")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Mutasi"
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
        clearInput()
    End Sub
    Public Sub reload()
        Call view()
    End Sub

    Public Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lihat.Click
        Call view()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If (textIdReff.Text = "" Or
            comboStatus.Text = "" Or
            comboTipe.Text = "" Or
            textNominal.Text = "" Or
        textDeskripsi.Text = "") Then
            MsgBox("Data tentang mutasi, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "INSERT INTO mutasi(id_reff,type,deskripsi, status, nominal)VALUES('" +
                textIdReff.Text + "','" + comboTipe.Text + "','" + textDeskripsi.Text + ",'" + comboStatus.Text + ",'" + textNominal.Text.Replace(",", "").Replace(".", "") + "')"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Mutasi baru berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Mutasi baru gagal ditambahkan", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtEndDateTime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        txtStartDateTime.Text = DateTimePicker2.Value.Date
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            With DataGridView1

                Label4.Text = .Item(0, i).Value
                textIdReff.Text = .Item(1, i).Value
                comboTipe.Text = .Item(2, i).Value
                textDeskripsi.Text = .Item(3, i).Value
                comboStatus.Text = .Item(4, i).Value
                textNominal.Text = .Item(5, i).Value
            End With
        Catch ex As Exception
            MsgBox("Mutasi yang anda cari tidak ada", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initializeDebounce()
        txtEndDateTime.Text = DateTimePicker1.Value.Date
        txtStartDateTime.Text = DateTimePicker1.Value.Date
        Call reload()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (textIdReff.Text = "" Or
            comboStatus.Text = "" Or
            comboTipe.Text = "" Or
            textNominal.Text = "" Or
        textDeskripsi.Text = "") Then
            MsgBox("Data tentang mutasi, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  mutasi SET id_reff= '" + textIdReff.Text + "',type ='" + comboTipe.Text +
                "',deskripsi ='" + textDeskripsi.Text + "',status ='" + comboStatus.Text + "',nominal ='" + textNominal.Text.Replace(",", "").Replace(".", "") + "' WHERE  id_mutasi ='" + Label4.Text + "'"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Data Mutasi berhasil diubah", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Data Mutasi gagal diubah", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        If (textIdReff.Text = "" Or
            comboStatus.Text = "" Or
            comboTipe.Text = "" Or
            textNominal.Text = "" Or
        textDeskripsi.Text = "") Then
            MsgBox("Harap pilih mutasi yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Dim cmd As MySqlCommand = New MySqlCommand("delete from mutasi WHERE  id_mutasi ='" + Label4.Text + "'", konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Satu Data Mutasi berhasil dihapus", MsgBoxStyle.OkOnly)
                Call view()
            Else
                MsgBox("Satu Data Mutasi gagal dihapus", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub clearInput()
        textIdReff.Text = ""
        comboStatus.Text = ""
        comboTipe.Text = ""
        textNominal.Text = ""
        textDeskripsi.Text = ""
        Label4.Text = ""
    End Sub

    Private Sub textNominal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textNominal.KeyPress
        If Char.IsControl(e.KeyChar) Then
        ElseIf Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ","c Then
            If textNominal.TextLength = 12 And textNominal.Text.Contains(",") = False Then
                textNominal.AppendText(",")
            ElseIf e.KeyChar = "," And textNominal.Text.IndexOf(",") <> -1 Then
                e.Handled = True
            ElseIf Char.IsDigit(e.KeyChar) Then
                If textNominal.Text.IndexOf(",") <> -1 Then
                    If textNominal.Text.Length >= textNominal.Text.IndexOf(",") + 3 Then
                        e.Handled = True
                    End If
                End If
            End If

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub buttonCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonCari.Click
        view()
    End Sub
End Class