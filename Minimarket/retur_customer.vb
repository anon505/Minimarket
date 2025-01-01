Imports MySql.Data.MySqlClient
Imports System.Data

Public Class retur_customer
    Dim ds As DataTable

    Private Sub loadTable()
        Try
            ds = newConnect.ExecuteReader("select id_transaksi_detail,barcode,nama_barang,harga,qty,jumlah from ds_transaksi_penjualan where no_transaksi='" & lblNoTransaksi.Text & "' and barcode like '%" + textPLU.Text + "%' order by updated_at desc")
            dataGridView1.AutoGenerateColumns = True
            dataGridView1.DataSource = ds
            ds.Columns.Add("Retur")
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dataGridView1.Columns(0).ReadOnly = True
            dataGridView1.Columns(1).ReadOnly = True
            dataGridView1.Columns(2).ReadOnly = True
            dataGridView1.Columns(3).ReadOnly = True
            dataGridView1.Columns(4).ReadOnly = True
            dataGridView1.Columns(5).ReadOnly = True
            dataGridView1.Columns(6).ReadOnly = False

            dataGridView1.Columns(0).HeaderText = "id"
            dataGridView1.Columns(1).HeaderText = "Barcode"
            dataGridView1.Columns(2).HeaderText = "Nama Barang"
            dataGridView1.Columns(3).HeaderText = "Harga"
            dataGridView1.Columns(4).HeaderText = "Qty"
            dataGridView1.Columns(5).HeaderText = "Jumlah"
            dataGridView1.Columns(6).HeaderText = "Retur"
            dataGridView1.Columns(0).Width = 100
            dataGridView1.Columns(1).Width = 200
            dataGridView1.Columns(2).Width = 508
            dataGridView1.Columns(3).Width = 170
            dataGridView1.Columns(4).Width = 170
            dataGridView1.Columns(5).Width = 200
            dataGridView1.Columns(6).Width = 200

            Dim column As DataGridViewColumn = dataGridView1.Columns(6)
            Dim cell = New DataGridViewTextBoxCell()
            cell.Style.BackColor = Color.Wheat


            cell.Style.Format = "N2"

            cell.Style.ForeColor = Color.DarkRed
            column.CellTemplate = cell
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
            textCountItem.Text = dataGridView1.Rows.Count.ToString

            textPLU.Text = ""
            textPLU.Select()

            textPLU.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub countTotalRetur()
        Console.WriteLine("countTOtalRetur")
        Dim grandTotal = 0
        For Each row As DataRow In ds.Rows
            Dim qtyRetur = row.Item(6).ToString.Replace(".", "").
                                        Replace(",", "")
            Dim price = row.Item(3).ToString.Replace(".", "").
                                        Replace(",", "")
            If Not (qtyRetur = "") Then
                grandTotal += Integer.Parse(qtyRetur) * Integer.Parse(price)
            End If
            Console.WriteLine("qty retur" & "-" & qtyRetur)
        Next row

       
        labelTotalBig.Text = Format(grandTotal, "#,0;-#,0")
    End Sub

    Private Sub initializeForm()
        labelTotalBig.Text = 0
        textPLU.Focus()
        textPLU.Text = ""

    End Sub



    Private Sub returTransaksi()

        Dim waktuTransaksi = newConnect.ExecuteScalar("SELECT waktu from transaksi WHERE no_transaksi = " & lblNoTransaksi.Text)
        Dim idTransaksi = newConnect.ExecuteScalar("SELECT id_transaksi from transaksi WHERE no_transaksi = " & lblNoTransaksi.Text)

        For Each row As DataRow In ds.Rows
            Dim qty = row.Item(4).ToString.Replace(".", "").
                                        Replace(",", "")
            Dim qtyRetur = row.Item(6).ToString.Replace(".", "").
                                        Replace(",", "")
            Dim idTransaksiDetail = row.Item(0).ToString.Replace(".", "").
                                       Replace(",", "")
            Dim barcode = row.Item(1).ToString.Replace(".", "").
                                      Replace(",", "")
            Dim hargaJual = row.Item(3).ToString.Replace(".", "").
                                      Replace(",", "")
            Dim idBarang = newConnect.ExecuteScalar("SELECT id_barang from barang WHERE barcode = '" & barcode & "'")
            If Not (qtyRetur = "") Then
                If qty = qtyRetur Then
                    newConnect.ExecuteNonQuery("DELETE from transaksi_detail WHERE id_transaksi_detail = " & idTransaksiDetail.ToString)
                Else
                    newConnect.ExecuteNonQuery("UPDATE transaksi_detail Set qty = '" & Integer.Parse(qty) - Integer.Parse(qtyRetur) & "' WHERE id_transaksi_detail = " & idTransaksiDetail.ToString)
                End If
                Dim stokGudang As Integer = newConnect.ExecuteScalar("select stok_gudang from barang where barcode='" & barcode & "'")
                newConnect.ExecuteNonQuery("UPDATE barang Set stok_gudang = '" & (stokGudang + Integer.Parse(qtyRetur)).ToString & "' WHERE barcode='" & barcode & "'")
            End If
            Dim returInsert = "INSERT INTO retur_customer(id_retur_customer,id_kasir,id_transaksi,id_barang,harga_jual,qty,created_at) " &
                                       "VALUES (NULL," &
                                       "'" & Module1.id_kasir & "'," &
                                        "'" & idTransaksi & "'," &
                                        "'" & idBarang & "'," &
                                        "'" & hargaJual & "'," &
                                        "'" & qtyRetur & "'," &
                                        "now());"
            Console.WriteLine(returInsert)
            newConnect.ExecuteNonQuery(returInsert)
        Next row

        If Not (labelTotalBig.Text = "0") Then
            newConnect.ExecuteNonQuery("UPDATE transaksi Set grand_total = '" & labelTotalBig.Text.Replace(",", "").Replace(".", "") & "', status = 'retur' WHERE id_transaksi = " & idTransaksi)
            Dim idMutasi = newConnect.ExecuteScalar("SELECT id_mutasi from mutasi WHERE  type='penjualan' and id_reff='" & idTransaksi & "'")
            If idMutasi Is Nothing Then
                newConnect.ExecuteNonQuery("INSERT INTO mutasi(id_mutasi,id_reff,type,deskripsi,nominal,created_at) VALUES (NULL, '" &
                                                                     idTransaksi &
                                                                    "','penjualan','RETUR PENJUALAN pada waktu: " &
                                                                    waktuTransaksi & "', '" & labelTotalBig.Text.Replace(",", "").Replace(".", "") & "', now());")

            Else
                newConnect.ExecuteNonQuery("UPDATE mutasi SET deskripsi = 'update RETUR PENJUALAN pada waktu: " &
                                                                    waktuTransaksi & "',nominal = '" & labelTotalBig.
                                                                    Text.
                                                                    Replace(",", "").
                                                                    Replace(".", "") & "',created_at = now() WHERE id_mutasi = " & idMutasi.ToString)
            End If
            loadTable()
            labelTotalBig.Text = "0"
            MsgBox("Retur barang dari customer behasil disimpan")
        End If
        
    End Sub


    Private Sub penjualan_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        initializeForm()
        loadTable()
    End Sub

    Private Sub penjualan_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.End Then
            Button1.PerformClick()

        End If
        e.Handled = False

    End Sub

    Private Sub textPLU_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textPLU.KeyPress
        Dim ascChar As Integer = Asc(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not (ascChar = 8) And Not (ascChar = 32) And Not (ascChar = 13) Then
            e.KeyChar = ""
            e.Handled = False
        End If
        If ascChar = 13 Then
            ' TODO: Cari item berdasarkan barcode
            If textPLU.Text = "" Then
                dataGridView1.DataSource = ds
            Else
                Dim dv As New DataView(ds)
                dv.RowFilter = "barcode = " & textPLU.Text
                dataGridView1.DataSource = dv
            End If
           
        End If
    End Sub



    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dataGridView1.CellFormatting
        If (e.ColumnIndex = 3 Or e.ColumnIndex = 5) AndAlso IsNumeric(e.Value) Then
            e.Value = Format(e.Value, "#,0;-#,0")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (dataGridView1.Rows.Count <= 0) Then
            MsgBox("Belum ada barang untuk diretur")
            Return

        End If
        ' TODO: Submit retur transaksi penjualan
        Dim result As DialogResult = MessageBox.Show("PASTIKAN DATA SUDAH BENAR, apakah anda yakin ingin menyimpannya?",
                        "Konfirmasi",
                        MessageBoxButtons.YesNo)

        If (result = DialogResult.Yes) Then
            returTransaksi()
        End If

    End Sub

    Private Sub dataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellEndEdit

        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim price As Integer = Integer.Parse(dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString)
                Dim qty As Integer = Integer.Parse(dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString)
                Dim qtyRetur As Integer = Integer.Parse(dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString)
                If qtyRetur > qty Then
                    MsgBox("Qty RETUR MELEBIHI Qty PENJUALAN")
                    dataGridView1.Rows(e.RowIndex).Cells(6).Value = ""
                    ds.Rows(e.RowIndex).Item(6) = ""

                Else
                    ds.Rows(e.RowIndex).Item(6) = "" & qtyRetur
                    countTotalRetur()
                End If
            End If

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try



    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class