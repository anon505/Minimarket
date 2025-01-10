Public Class koreksi_stok

    Private Sub penjualan_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F11 Then
            list_barang.koreksiStok = Me
            list_barang.frmReturSuplier = Nothing
            list_barang.frmPenjualan = Nothing
            list_barang.frmPembelian = Nothing
            list_barang.txtcari.Text = ""
            list_barang.Show()
            'newConnect.ExecuteNonQuery("update transaksi_detail set qty=CASE WHEN qty > 0 THEN 0 - qty ELSE qty END where id_transaksi=" & lblIdTransaksi.Text)
            'loadTable()

        End If
    End Sub
    Private Sub showNamaBarang(ByVal barcode As String)
        Try

            Dim nama = newConnect.ExecuteScalar("select nama_barang from barang where barcode='" & barcode & "'")
            textNama.Text = nama.ToString
            Dim harga = newConnect.ExecuteScalar("select harga_beli_netto from barang where barcode='" & barcode & "'")
            textHargaBeli.Text = Format(Integer.Parse(harga.ToString), "#,0;-#,0")
            Dim stokDisplay = newConnect.ExecuteScalar("select stok_display from barang where barcode='" & barcode & "'")
            textHargaBeli.Text = Format(Integer.Parse(harga.ToString), "#,0;-#,0")
            textStokDisplay.Text = newConnect.ExecuteScalar("select stok_display from barang where barcode='" & barcode & "'")
            textStokGudang.Text = newConnect.ExecuteScalar("select stok_gudang from barang where barcode='" & barcode & "'")
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            textNama.Text = ""
            textHargaBeli.Text = ""
            textStokDisplay.Text = ""
            textStokGudang.Text = ""

        End Try
       

    End Sub
    Sub setPLU(ByVal barcode As String)
        textPLU.Text = barcode
        showNamaBarang(barcode)
        textPLU.Select()
        textPLU.Focus()

    End Sub
    Private Sub textPLU_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textPLU.KeyPress
        Dim ascChar As Integer = Asc(e.KeyChar)

        If ascChar = 13 Then
            showNamaBarang(textPLU.Text)
        End If
    End Sub
    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If (textPLU.Text = "") Or textHargaBeli.Text = "" Or textQty.Text = "" Or comboTipe.Text = "" Or comboJenis.Text = "" Or textDeskripsi.Text = "" Then
            MsgBox("Silahkan lengkapi form")
        Else
            Dim qty = ""
            If (comboTipe.Text = "plus") Then
                qty = textQty.Text
            Else
                qty = "-" & textQty.Text
            End If
            Dim stokDisplay = newConnect.ExecuteScalar("select stok_display from barang where barcode='" & textPLU.Text & "'")
            Dim stokGudang = newConnect.ExecuteScalar("select stok_gudang from barang where barcode='" & textPLU.Text & "'")

            If (comboJenis.Text = "stok_display") Then
                If (Integer.Parse(textQty.Text) > stokDisplay And comboTipe.Text = "minus") Then
                    MsgBox("Qty lebih besar dari stok display. STOK DISPLAY TIDAK BOLEH MINUS")
                    Return
                Else
                    Dim total As Integer
                    If (comboTipe.Text = "plus") Then
                        total = (stokDisplay + Integer.Parse(textQty.Text))
                    Else
                        total = (stokDisplay - Integer.Parse(textQty.Text))
                    End If
                    newConnect.ExecuteNonQuery("UPDATE barang Set stok_display = '" & total.ToString & "' WHERE barcode = '" & textPLU.Text & "'")
                End If
            End If
            If (comboJenis.Text = "stok_gudang") Then
                If (Integer.Parse(textQty.Text) > stokGudang And comboTipe.Text = "minus") Then
                    MsgBox("Qty lebih besar dari stok gudang. STOK GUDANG TIDAK BOLEH MINUS")
                    Return
                Else
                    Dim total As Integer
                    If (comboTipe.Text = "plus") Then
                        total = (stokGudang + Integer.Parse(textQty.Text))
                    Else
                        total = (stokGudang - Integer.Parse(textQty.Text))
                    End If
                    newConnect.ExecuteNonQuery("UPDATE barang Set stok_gudang = '" & total.ToString & "' WHERE barcode = '" & textPLU.Text & "'")
                End If
            End If

            Dim idBarang = newConnect.ExecuteScalar("select id_barang from barang where barcode='" & textPLU.Text & "'")
            Dim sqlInsertKoreksiStok = "INSERT INTO koreksi_stok (id_koreksi,id_barang, waktu, deskripsi, type, harga_beli,qty) " &
                                       "VALUES (NULL, '" & idBarang & "',now(), '" & textDeskripsi.Text & "', '" & comboTipe.Text & "', " &
                                       "'" & textHargaBeli.Text.Replace(".", "").Replace(",", "") & "','" & qty & "')"
            Console.WriteLine(sqlInsertKoreksiStok)
            newConnect.ExecuteNonQuery(sqlInsertKoreksiStok)
            showNamaBarang(textPLU.Text)
            textQty.Text = ""
            comboJenis.Text = ""
            comboTipe.Text = ""
            textDeskripsi.Text = ""
            MsgBox("Stok barang berhasil dikoreksi")
        End If
    End Sub

End Class