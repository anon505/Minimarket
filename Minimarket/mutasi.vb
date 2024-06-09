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
    Public Sub view(ByVal isFilter As Boolean)
        Dim query As String
        Dim queryCashOnHand As String
        Dim queryModalBarang As String
        Dim queryTotalHutang As String
        Dim queryPengeluaran As String

        If isFilter Then
            Dim startTime = DateTime.ParseExact(txtStartDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
            Dim endTime = DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
            Console.WriteLine(startTime & " dan " & endTime)
            query = "select * from mutasi where created_at >= '" & startTime & "' AND created_at <= '" & endTime & "' order by created_at desc"
            queryCashOnHand = "SELECT sum(nominal) as cash_on_hand FROM `mutasi` where type='penjualan' and created_at >= '" & startTime & "' AND created_at <= '" & endTime & "'"
            queryModalBarang = "SELECT sum(if((nominal<0),abs(nominal),nominal)) as modal_barang FROM `mutasi` where type='pembelian' and created_at >= '" & startTime & "' AND created_at <= '" & endTime & "'"
            queryTotalHutang = "SELECT sum(nominal) as total_hutang FROM `mutasi` where ((type='pembelian' and nominal<0) or type='bayar_hutang') and created_at >= '" & startTime & "' AND created_at <= '" & endTime & "'"
            queryPengeluaran = "SELECT sum(nominal) as pengeluaran FROM `mutasi` where type='pengeluaran' and created_at >= '" & startTime & "' AND created_at <= '" & endTime & "'"
        Else
            query = "select * from mutasi order by created_at desc"
            queryCashOnHand = "SELECT sum(nominal) as cash_on_hand FROM `mutasi` where type='penjualan'"
            queryModalBarang = "SELECT sum(if((nominal<0),abs(nominal),nominal)) as modal_barang FROM `mutasi` where type='pembelian'"
            queryTotalHutang = "SELECT sum(nominal) as total_hutang FROM `mutasi` where ((type='pembelian' and nominal<0) or type='bayar_hutang')"
            queryPengeluaran = "SELECT sum(nominal) as pengeluaran FROM `mutasi` where type='pengeluaran'"
        End If
        Dim sql As MySqlCommand = New MySqlCommand(query, konek)
        Dim ds As DataSet = New DataSet
        Dim da As MySqlDataAdapter = New MySqlDataAdapter
        da.SelectCommand = sql
        da.Fill(ds, "Mutasi")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Mutasi"
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()

        Dim cashOnHandCmd As MySqlCommand = New MySqlCommand(queryCashOnHand, konek)
        Dim cashOnHand = cashOnHandCmd.ExecuteScalar
        If IsDBNull(cashOnHand) Then
            cashOnHand = 0
        End If
        lblCashOnHand.Text = Format(cashOnHand, "#,0;-#,0")

        Dim modalBarangCmd As MySqlCommand = New MySqlCommand(queryModalBarang, konek)
        Dim modalBarang = modalBarangCmd.ExecuteScalar
        If IsDBNull(modalBarang) Then
            modalBarang = 0
        End If
        lblModalBarang.Text = Format(modalBarang, "#,0;-#,0")

        Dim totalHutangCmd As MySqlCommand = New MySqlCommand(queryTotalHutang, konek)
        Dim totalHutang = totalHutangCmd.ExecuteScalar
        If IsDBNull(totalHutang) Then
            totalHutang = 0
        End If
        lblTotalHutang.Text = Format(totalHutang, "#,0;-#,0")

        Dim pengeluaranCmd As MySqlCommand = New MySqlCommand(queryPengeluaran, konek)
        Dim pengeluaran = pengeluaranCmd.ExecuteScalar
        If IsDBNull(pengeluaran) Then
            pengeluaran = 0
        End If
        lblPengeluaran.Text = Format(pengeluaran, "#,0;-#,0")

        Dim modalAkhir = (Integer.Parse(modalBarang) - Integer.Parse(cashOnHand)) - Integer.Parse(pengeluaran)
        lblModalAkhir.Text = Format(modalAkhir, "#,0;-#,0")
        clearInput()
    End Sub

    Public Sub reload()
        If buttonCari.Text = "Filter" Then
            Call view(False)
        Else
            Call view(True)
        End If
    End Sub

    Public Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lihat.Click
        Call reload()
    End Sub

    Private Sub tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tambah.Click
        Dim Query As String
        If (textIdReff.Text = "" Or
            comboTipe.Text = "" Or
            textNominal.Text = "" Or
        textDeskripsi.Text = "") Then
            MsgBox("Data tentang mutasi, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "INSERT INTO mutasi(id_reff,type,deskripsi,nominal,created_at)VALUES('" +
                textIdReff.Text + "','" + comboTipe.Text + "','" + textDeskripsi.Text + "','" + textNominal.Text.Replace(",", "").Replace(".", "") + "',now())"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Mutasi baru berhasil ditambahkan", MsgBoxStyle.OkOnly)
                Call reload()
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
                textNominal.Text = .Item(4, i).Value
            End With
        Catch ex As Exception
            MsgBox("Mutasi yang anda cari tidak ada", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initializeDebounce()
        Call reload()
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Dim Query As String
        If (textIdReff.Text = "" Or
            comboTipe.Text = "" Or
            textNominal.Text = "" Or
        textDeskripsi.Text = "") Then
            MsgBox("Data tentang mutasi, ada yang kosong", MsgBoxStyle.OkOnly)
        Else
            Query = "UPDATE  mutasi SET id_reff= '" + textIdReff.Text + "',type ='" + comboTipe.Text +
                "',deskripsi ='" + textDeskripsi.Text + "',nominal ='" + textNominal.Text.Replace(",", "").Replace(".", "") + "' WHERE  id_mutasi ='" + Label4.Text + "'"
            Dim cmd As MySqlCommand = New MySqlCommand(Query, konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Data Mutasi berhasil diubah", MsgBoxStyle.OkOnly)
                Call reload()
            Else
                MsgBox("Data Mutasi gagal diubah", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        If (textIdReff.Text = "" Or
            comboTipe.Text = "" Or
            textNominal.Text = "" Or
        textDeskripsi.Text = "") Then
            MsgBox("Harap pilih mutasi yang akan dihapus", MsgBoxStyle.OkOnly)
        Else
            Dim cmd As MySqlCommand = New MySqlCommand("delete from mutasi WHERE  id_mutasi ='" + Label4.Text + "'", konek)
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MsgBox("Satu Data Mutasi berhasil dihapus", MsgBoxStyle.OkOnly)
                Call reload()
            Else
                MsgBox("Satu Data Mutasi gagal dihapus", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub clearInput()
        textIdReff.Text = ""
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
        If buttonCari.Text = "Filter" Then
            buttonCari.Text = "Reset"
            view(True)
        Else
            txtStartDateTime.Text = ""
            txtEndDateTime.Text = ""
            buttonCari.Text = "Filter"
            view(False)
        End If

    End Sub
End Class