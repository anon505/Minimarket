Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Globalization

Public Class retur_customer_report

    Public Sub view(ByVal isFilter As Boolean)
        Dim query As String

        If isFilter Then
            Dim startTime = DateTime.ParseExact(txtStartDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
            Dim endTime = DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
            Console.WriteLine(startTime & " dan " & endTime)
            query = "select no_transaksi,nama_kasir,nama_barang,harga_jual,qty,created_at from ds_retur_customer where created_at >= '" & startTime & "' AND created_at <= '" & endTime & "' order by created_at desc"
        Else
            query = "select no_transaksi,nama_kasir,nama_barang,harga_jual,qty,created_at from ds_retur_customer order by created_at desc"
        End If
        Dim ds = newConnect.ExecuteReader(query)
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()

    End Sub

    Public Sub reload()
        If buttonCari.Text = "Filter" Then
            Call view(False)
        Else
            Call view(True)
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtEndDateTime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        txtStartDateTime.Text = DateTimePicker2.Value.Date
    End Sub
    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call reload()
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