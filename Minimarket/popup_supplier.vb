Imports MySql.Data.MySqlClient

Public Class popup_supplier
    Public frmPembelian As pembelian1
    Public frmReturSuplier As retur_suplier
    Private Sub popup_supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcari.Select(txtcari.Text.Length, 0)
        txtcari.Select(0, 0)
        bacaData(txtcari.Text)
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        bacaData(txtcari.Text)
    End Sub

    Private Sub bacaData(ByVal keyword As String)
        Dim ds = newConnect.ExecuteReader("SELECT *  FROM supplier WHERE kode_suplier LIKE '%" & keyword & "%' or nama_suplier LIKE '%" & keyword & "%'")
        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = ds
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.ReadOnly = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        txtcari.Select()
        txtcari.Focus()
        txtcari.SelectionStart = txtcari.TextLength
    End Sub
    Private Sub penjualan_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Not (frmPembelian Is Nothing) Then
                Dim cellsSelect = DataGridView1.SelectedCells
                If (cellsSelect.Count > 0) Then
                    frmPembelian.textSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(1).Value.ToString
                    frmPembelian.labelSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(2).Value.ToString
                    frmPembelian.labelIdSuplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(0).Value.ToString

                    frmPembelian.textPLU.Focus()
                End If

            End If

            If Not (frmReturSuplier Is Nothing) Then
                Dim cellsSelect = DataGridView1.SelectedCells
                If (cellsSelect.Count > 0) Then
                    frmReturSuplier.textSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(1).Value.ToString
                    frmReturSuplier.labelSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(2).Value.ToString
                    frmReturSuplier.labelIdSuplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(0).Value.ToString

                    frmReturSuplier.textPLU.Focus()
                End If
            End If

            Close()
        End If
        e.Handled = False
        'End If
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Not (frmPembelian Is Nothing) Then
            Dim cellsSelect = DataGridView1.SelectedCells
            If (cellsSelect.Count > 0) Then
                frmPembelian.textSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(1).Value.ToString
                frmPembelian.labelSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(2).Value.ToString
                frmPembelian.labelIdSuplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(0).Value.ToString

                frmPembelian.textPLU.Focus()
            End If

        End If

        If Not (frmReturSuplier Is Nothing) Then
            Dim cellsSelect = DataGridView1.SelectedCells
            If (cellsSelect.Count > 0) Then
                frmReturSuplier.textSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(1).Value.ToString
                frmReturSuplier.labelSupplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(2).Value.ToString
                frmReturSuplier.labelIdSuplier.Text = DataGridView1.Rows(cellsSelect(0).RowIndex).Cells(0).Value.ToString

                frmReturSuplier.textPLU.Focus()
            End If
        End If

        Close()
    End Sub
End Class