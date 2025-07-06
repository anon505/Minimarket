Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Globalization

Public Class list_barang

    Public frmPenjualan As penjualan
    Public frmPembelian As pembelian1
    Public frmReturSuplier As retur_suplier
    Public koreksiStok As koreksi_stok
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
            If Not (frmReturSuplier Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    frmReturSuplier.setPLU(barcode)
                End If
                closePage()
            End If
            If Not (frmPenjualan Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    frmPenjualan.setPLU(barcode)
                End If
                closePage()
            End If

            If Not (frmPembelian Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    frmPembelian.setPLU(barcode)
                End If
                closePage()
            End If

            If Not (koreksiStok Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    koreksiStok.setPLU(barcode)
                End If
                closePage()
            End If
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

        If Not (koreksiStok Is Nothing) Then
            Dim cellSelect = DataGridView1.SelectedCells
            Console.WriteLine(cellSelect.Count)
            If (cellSelect.Count > 0) Then

                Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                koreksiStok.setPLU(barcode)
            End If
        End If

        If Not (frmReturSuplier Is Nothing) Then
            Dim cellSelect = DataGridView1.SelectedCells
            Console.WriteLine(cellSelect.Count)
            If (cellSelect.Count > 0) Then

                Dim barcode = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                frmReturSuplier.setPLU(barcode)
            End If
        End If

        closePage()
    End Sub
    Private Sub closePage()
        main.listBarangForm.frmPenjualan = Nothing
        main.listBarangForm.frmReturSuplier = Nothing
        main.listBarangForm.frmPembelian = Nothing
        main.listBarangForm.koreksiStok = Nothing
        main.listBarangForm.txtcari.Text = ""
        main.listBarangForm.WindowState = FormWindowState.Minimized    ' Make sure it's not minimized
    End Sub
End Class