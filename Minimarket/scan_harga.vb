Imports MySql.Data.MySqlClient

Public Class scan_harga

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub scan_harga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        textPLU.Focus()

    End Sub

    Private Sub inputUpdateBarang(ByVal barcode As String)
        Try
            ' lblBarcode.Text = barcode
            Dim barangReaders = newConnect.ExecuteReader("SELECT * from barang WHERE barcode='" & barcode & "'")
            Dim stokDisplay As Integer
            Dim stokGudang As Integer
            Dim stokTotal As Integer
            Dim hargaJual1 As Integer
            Dim hargaJual2 As Integer
            Dim hargaJual3 As Integer
            Dim hargaJual4 As Integer
            Dim qty2 As Integer
            Dim qty3 As Integer
            Dim qty4 As Integer
            Dim namaBarang As String
            If barangReaders.Rows.Count > 0 Then
                Dim barangReader = barangReaders.Rows(0)
                namaBarang = barangReader("nama_barang")
                stokDisplay = barangReader("stok_display")
                stokGudang = barangReader("stok_gudang")
                stokTotal = stokDisplay + stokGudang
                hargaJual1 = barangReader("harga_jual1")
                hargaJual2 = barangReader("harga_jual2")
                hargaJual3 = barangReader("harga_jual3")
                hargaJual4 = barangReader("harga_jual4")
                qty2 = barangReader("qty2")
                qty3 = barangReader("qty3")
                qty4 = barangReader("qty4")
                lblStok.Text = "Sisa Stok : " & stokTotal
                lblNamaBarang.Text = namaBarang
                lblCaption1.Text = "1 ="
                lblCaption2.Text = qty2 & " ="
                lblCaption3.Text = qty3 & " ="
                lblCaption4.Text = qty4 & " ="
                lblPrice1.Text = Format(hargaJual1, "#,0;-#,0")
                lblPrice2.Text = Format(hargaJual2, "#,0;-#,0")
                lblPrice3.Text = Format(hargaJual3, "#,0;-#,0")
                lblPrice4.Text = Format(hargaJual4, "#,0;-#,0")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub textPLU_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textPLU.KeyPress
        Dim ascChar As Integer = Asc(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not (ascChar = 8) And Not (ascChar = 32) And Not (ascChar = 13) Then
            e.KeyChar = ""
            e.Handled = False
            'textPLU.Focus()

        End If
        If ascChar = 13 Then
            inputUpdateBarang(textPLU.Text)
            textPLU.Text = ""
        End If
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class