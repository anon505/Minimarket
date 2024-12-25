Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Globalization

Public Class list_faktur
    Public frmPembelian As pembelian1
    Public Sub view()
        Dim ds = newConnect.ExecuteReader("SELECT no_faktur, tgl_faktur,id_suplier,kode_suplier,nama_suplier,nama_kasir,grand_total,pembelian.`status` AS status FROM pembelian LEFT JOIN supplier on supplier.id_suplier=pembelian.id_supplier LEFT JOIN kasir ON kasir.id_kasir=pembelian.id_kasir WHERE pembelian.`status`!='temp'  order by tgl_faktur desc")
        DataGridView1.DataSource = ds
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ReadOnly = True
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.Font = New Font("arial", 12)
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
        Dim query = "SELECT no_faktur, tgl_faktur,id_suplier,kode_suplier,nama_suplier,nama_kasir,grand_total,pembelian.`status` AS status FROM pembelian LEFT JOIN supplier on supplier.id_suplier=pembelian.id_supplier LEFT JOIN kasir ON kasir.id_kasir=pembelian.id_kasir WHERE pembelian.`status`!='temp' and (tgl_faktur >= '" & startTime & "' AND tgl_faktur <= '" & endTime & "') order by tgl_faktur desc"
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
            If Not (frmPembelian Is Nothing) Then
                Dim cellSelect = DataGridView1.SelectedCells
                Console.WriteLine(cellSelect.Count)
                If (cellSelect.Count > 0) Then

                    Dim nofaktur = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                    Dim idSupp = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(2).Value.ToString
                    Dim kodeSupp = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(3).Value.ToString
                    Dim namaSupp = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(4).Value.ToString
                    frmPembelian.showDetailFaktur(nofaktur, kodeSupp, idSupp, namaSupp)

                   
                End If
            End If
            Close()
        End If
        e.Handled = False
        'End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
         If Not (frmPembelian Is Nothing) Then
            Dim cellSelect = DataGridView1.SelectedCells
            Console.WriteLine(cellSelect.Count)
            If (cellSelect.Count > 0) Then

                Dim nofaktur = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(0).Value.ToString
                Dim idSupp = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(2).Value.ToString
                Dim kodeSupp = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(3).Value.ToString
                Dim namaSupp = DataGridView1.Rows(cellSelect(0).RowIndex).Cells(4).Value.ToString
                frmPembelian.showDetailFaktur(nofaktur, kodeSupp, idSupp, namaSupp)


            End If
        End If
        Close()
    End Sub
End Class