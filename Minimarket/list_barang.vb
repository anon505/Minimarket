Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Globalization

Public Class list_barang

    Public frmPenjualan As penjualan
    Public frmPembelian As pembelian1
    Public Sub view()
        Dim ds = newConnect.ExecuteReader("select barcode,nama_barang,(stok_display+stok_gudang) as stok from barang order by nama_barang asc")
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ReadOnly = True
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
        txtcari.Select()
        txtcari.Focus()
        txtcari.SelectionStart = txtcari.TextLength
    End Sub

    Private Sub barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call view()
    End Sub
    Private Sub txtcari_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtcari.TextChanged
        Dim ds = newConnect.ExecuteReader("select barcode,nama_barang,(stok_display+stok_gudang) as stok from barang where nama_barang like '%" & txtcari.Text & "%' order by nama_barang asc")
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ReadOnly = True
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
        DataGridView1.AutoResizeColumns()
        txtcari.Select()
        txtcari.Focus()
        txtcari.SelectionStart = txtcari.TextLength
    End Sub

    Private Sub penjualan_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Not (frmPenjualan Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    frmPenjualan.setPLU(barcode)
                End If
            End If
            Close()
            If Not (frmPembelian Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    frmPembelian.setPLU(barcode)
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

                Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                frmPenjualan.setPLU(barcode)
            End If
        End If
        If Not (frmPembelian Is Nothing) Then
            Dim cellSelect = DataGridView1.SelectedCells
            Console.WriteLine(cellSelect.Count)
            If (cellSelect.Count > 0) Then

                Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                frmPembelian.setPLU(barcode)
            End If
        End If

        Close()
    End Sub
End Class