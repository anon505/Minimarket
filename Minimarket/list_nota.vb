Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Globalization

Public Class list_nota
    Public frmPenjualan As penjualan
    Public Sub view()
        Dim ds = newConnect.ExecuteReader("select no_transaksi,waktu from transaksi  where status='done' or status='retur'  order by waktu desc")
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ReadOnly = True
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.Columns(1).DefaultCellStyle.Format = "dd MMM yyyy HH:mm:ss"
        DataGridView1.AutoResizeColumns()

    End Sub


    Public Sub lihat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call view()
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call view()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtEndDateTime.Text = DateTimePicker1.Value.Date
        Dim startTime = DateTime.ParseExact(txtEndDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
        Dim endTime = DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
        Dim query = "select no_transaksi,waktu from transaksi where (waktu >= '" & startTime & "' AND waktu <= '" & endTime & "') and (status='done' or status='retur') order by waktu desc"
        Console.WriteLine(query)
        Dim ds = newConnect.ExecuteReader(query)
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub penjualan_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Not (frmPenjualan Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim notransaksi = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    Console.WriteLine(notransaksi)
                    Dim query = "select id_transaksi,bayar,grand_total,kembalian from transaksi where no_transaksi = '" & notransaksi & "'"
                    Console.WriteLine(query)
                    Dim transaksi = newConnect.ExecuteReader(query)
                    If transaksi.Rows.Count > 0 Then
                        Dim idTransaksi = transaksi.Rows(0).Item("id_transaksi").ToString
                        Dim bayar = Integer.Parse(transaksi.Rows(0).Item("bayar").ToString)
                        Dim grandTotal = Integer.Parse(transaksi.Rows(0).Item("grand_total").ToString)
                        Dim kembalian = Integer.Parse(transaksi.Rows(0).Item("kembalian").ToString)
                        Console.WriteLine("" & idTransaksi & "-" & bayar & "-" & grandTotal & "-" & kembalian)
                        frmPenjualan.cetakTransaksi(idTransaksi, kembalian, bayar, grandTotal)
                    End If
                End If
            End If
            Close()
        End If
        e.Handled = False
        'End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Not (frmPenjualan Is Nothing) Then
            Dim cellSelect = DataGridView1.SelectedCells
            Console.WriteLine(cellSelect.Count)
            If (cellSelect.Count > 0) Then

                Dim notransaksi = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                Dim query = "select id_transaksi,bayar,grand_total,kembalian from transaksi where no_transaksi = '" & notransaksi & "'"
                Console.WriteLine(query)
                Dim transaksi = newConnect.ExecuteReader(query)
                If transaksi.Rows.Count > 0 Then
                    Dim idTransaksi = transaksi.Rows(0).Item("id_transaksi").ToString
                    Dim bayar = Integer.Parse(transaksi.Rows(0).Item("bayar").ToString)
                    Dim grandTotal = Integer.Parse(transaksi.Rows(0).Item("grand_total").ToString)
                    Dim kembalian = Integer.Parse(transaksi.Rows(0).Item("kembalian").ToString)
                    Console.WriteLine("" & idTransaksi & "-" & bayar & "-" & grandTotal & "-" & kembalian)
                    frmPenjualan.cetakTransaksi(idTransaksi, kembalian, bayar, grandTotal)
                End If
            End If
        End If
        Close()
    End Sub
End Class