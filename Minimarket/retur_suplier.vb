Imports MySql.Data.MySqlClient
Imports System.Data

Public Class retur_suplier
    Dim dt As DataTable

    Private Sub retur_suplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt = New DataTable("tblInput")
        dt.Columns.Add("id")
        dt.Columns.Add("Barcode")
        dt.Columns.Add("Suplier")
        dt.Columns.Add("Nama Barang")
        dt.Columns.Add("Total Stok")
        dt.Columns.Add("Retur")
        dataGridView1.DataSource = dt
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridView1.Columns(0).ReadOnly = True
        dataGridView1.Columns(1).ReadOnly = True
        dataGridView1.Columns(2).ReadOnly = True
        dataGridView1.Columns(3).ReadOnly = True
        dataGridView1.Columns(4).ReadOnly = True
        dataGridView1.Columns(5).ReadOnly = False

        dataGridView1.Columns(0).HeaderText = "id"
        dataGridView1.Columns(1).HeaderText = "Barcode"
        dataGridView1.Columns(2).HeaderText = "Suplier"
        dataGridView1.Columns(3).HeaderText = "Nama Barang"
        dataGridView1.Columns(4).HeaderText = "Total Stok"
        dataGridView1.Columns(5).HeaderText = "Retur"
        dataGridView1.Columns(0).Width = 100
        dataGridView1.Columns(1).Width = 200
        dataGridView1.Columns(2).Width = 170
        dataGridView1.Columns(3).Width = 400
        dataGridView1.Columns(4).Width = 170
        dataGridView1.Columns(5).Width = 200

        Dim column As DataGridViewColumn = dataGridView1.Columns(5)
        Dim cell = New DataGridViewTextBoxCell()
        cell.Style.BackColor = Color.Wheat


        cell.Style.Format = "N2"

        cell.Style.ForeColor = Color.DarkRed
        column.CellTemplate = cell
        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter

        textPLU.Text = ""
        textPLU.Select()

        textPLU.Focus()
    End Sub

    Private Sub hitung()
        Dim dgRows = dt.Rows
        Dim hitung = 0
        For index As Integer = 0 To dgRows.Count - 1
            Try
                hitung += Integer.Parse(dgRows(index).Item("Retur"))
            Catch ex As Exception

            End Try

        Next
        labelTotalBig.Text = hitung
    End Sub

    Private Sub dataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.CellValueChanged

        Try

            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                If e.ColumnIndex = 5 Then
                    hitung()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub textPLU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textPLU.KeyPress
        Dim ascChar As Integer = Asc(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not (ascChar = 8) And Not (ascChar = 32) And Not (ascChar = 13) Then
            e.KeyChar = ""
            e.Handled = False
            'textPLU.Focus()

        End If
        If ascChar = 13 Then
            inputReturBarang(textPLU.Text, 1)
        End If
    End Sub

    Sub setPLU(ByVal barcode As String)
        inputReturBarang(barcode, 1)
        textPLU.Select()
        textPLU.Focus()

    End Sub

    Private Sub penjualan_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F11 Then
            
            main.listBarangForm.frmReturSuplier = Me
            main.listBarangForm.frmPenjualan = Nothing
            main.listBarangForm.frmPembelian = Nothing
            main.listBarangForm.koreksiStok = Nothing
            main.listBarangForm.txtcari.Text = ""
            main.listBarangForm.WindowState = FormWindowState.Normal
            main.listBarangForm.Show()
            main.listBarangForm.BringToFront()
        End If
    End Sub
    Private Sub inputReturBarang(ByVal barcode As String, ByVal qty As Integer)
        Try
            labelBarcode.Text = barcode
            Dim barangReaders = newConnect.ExecuteReader("SELECT barang.id_barang,barang.barcode, supplier.nama_suplier,barang.nama_barang,(barang.stok_display+barang.stok_gudang) AS total from barang left join supplier ON supplier.id_suplier =barang.id_suplier  WHERE barcode='" & barcode & "'")


            Dim idBarang As Integer
            Dim namaSuplier As String
            Dim namaBarang As String
            Dim totalStok As Integer
            If barangReaders.Rows.Count > 0 Then
                Dim barangReader = barangReaders.Rows(0)
                idBarang = barangReader("id_barang")
                namaSuplier = barangReader("nama_suplier")
                namaBarang = barangReader("nama_barang")
                totalStok = barangReader("total")
                Dim R As DataRow = dt.NewRow
                R("id") = idBarang
                R("Barcode") = barcode
                R("Suplier") = namaSuplier
                R("Nama Barang") = namaBarang
                R("Total Stok") = totalStok
                Dim dgRows = dt.Rows
                Dim cekIndex = -1
                For index As Integer = 0 To dgRows.Count - 1
                    If (barcode = dgRows(index).Item("Barcode").ToString) Then
                        cekIndex = index
                        Exit For
                    End If
                    Console.WriteLine(dgRows(index).Item("id") & "-" & dgRows(index).Item("Barcode"))
                Next

                If cekIndex >= 0 Then
                    Dim oldRow = dt.Rows(cekIndex).Item("Retur")
                    Dim retur = Integer.Parse(oldRow) + 1
                    dt.Rows(cekIndex).Item("Retur") = retur

                Else
                    R("Retur") = 1
                    dt.Rows.InsertAt(R, 0)
                End If
            End If
            textPLU.Text = ""
            hitung()

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

    End Sub

    Private Sub textSupplier_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textSupplier.TextChanged
        If textSupplier.Text IsNot "" And popup_supplier.Visible = False Then
            popup_supplier.frmReturSuplier = Me
            popup_supplier.txtcari.Text = textSupplier.Text
            popup_supplier.Show()

        End If
    End Sub

    Private Sub dataGridView1_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dataGridView1.RowsRemoved
        hitung()
    End Sub
    Private Sub returTransaksi()
        For Each row As DataRow In dt.Rows
            Dim qtyRetur = row.Item(5).ToString.Replace(".", "").
                                        Replace(",", "")
            Dim idBarang = row.Item(0).ToString.Replace(".", "").
                                      Replace(",", "")
            Dim idSuplier = "NULL,"
            If Not (labelIdSuplier.Text = "") Then
                idSuplier = "'" & labelIdSuplier.Text & "',"
            End If
            If Not (qtyRetur = "") Then
                Dim stokDisplay As Integer = newConnect.ExecuteScalar("select stok_display from barang where id_barang='" & idBarang & "'")
                Dim stokGudang As Integer = newConnect.ExecuteScalar("select stok_gudang from barang where id_barang='" & idBarang & "'")
                If Integer.Parse(qtyRetur) <= stokDisplay Then
                    newConnect.ExecuteNonQuery("UPDATE barang Set stok_display = '" & (stokDisplay - Integer.Parse(qtyRetur)).ToString & "' WHERE id_barang='" & idBarang & "'")
                Else
                    Dim stokYgHarusDariGudang = Integer.Parse(qtyRetur) - stokDisplay
                    newConnect.ExecuteNonQuery("UPDATE barang Set stok_display = '0' WHERE  id_barang='" & idBarang & "'")
                    newConnect.ExecuteNonQuery("UPDATE barang Set stok_gudang = '" & (stokGudang - stokYgHarusDariGudang).ToString & "' WHERE  id_barang='" & idBarang & "'")
                End If

            End If
            Dim sql = "INSERT INTO retur_suplier(id_retur_suplier,id_suplier,id_kasir,id_barang,qty,faktur_retur,created_at) " &
                                      "VALUES (NULL," &
                                       idSuplier &
                                      "'" & Module1.id_kasir & "'," &
                                       "'" & idBarang & "'," &
                                       "'" & qtyRetur & "'," &
                                       "'" & textFaktur.Text & "'," &
                                       "now());"
            Console.WriteLine(sql)
            newConnect.ExecuteNonQuery(sql)
        Next
        dt.Rows.Clear()
        textFaktur.Text = ""
        labelIdSuplier.Text = ""
        textPLU.Text = ""
        textSupplier.Text = ""

        labelTotalBig.Text = "0"
        textPLU.Select()

        textPLU.Focus()
        MsgBox("Retur barang ke suplier behasil disimpan")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (dataGridView1.Rows.Count <= 0) Then
            MsgBox("Belum ada barang untuk diretur")
            Return

        End If
        Dim result As DialogResult = MessageBox.Show("PASTIKAN DATA SUDAH BENAR, apakah anda yakin ingin menyimpannya?",
                                "Konfirmasi",
                                MessageBoxButtons.YesNo)

        If (result = DialogResult.Yes) Then
            returTransaksi()
        End If
    End Sub
End Class