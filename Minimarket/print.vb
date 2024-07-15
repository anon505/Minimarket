Imports System.Drawing.Printing
Public Class print
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        Data_Load()

        Printer.NewPrint()
        arrWidth = {180} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidCenter} 'array alignment 
        'Setting Font
        Printer.SetFont("Monospace", 11, FontStyle.Bold)
        Printer.Print("Wildan Barokah", arrWidth, arrFormat) 'Store Name | Nama Toko

        Printer.SetFont("Monospace", 9, FontStyle.Bold)
        Printer.Print("Retail & Grosir", arrWidth, arrFormat) 'Store Name | Nama Toko

        'Setting Font
        Printer.SetFont("Monospace", 8, FontStyle.Regular)
        Printer.Print("Lenteng Proppo Pamekasan", arrWidth, arrFormat) 'Store Address | Alamat Toko
        Printer.Print("087 800 596 667", arrWidth, arrFormat) 'Store Address | Alamat Toko

        Printer.SetFont("Monospace", 8, FontStyle.Regular)
        Printer.Print("------------------------------------------------") 'line
        Printer.Print("2024-07-03 07:46:10") ' Trans Date | Tanggal transaksi
        Printer.Print(TransNo & " " & "Kasir : " & "1") ' Transaction No | Nomor transaksi

        Printer.SetFont("Monospace", 8, FontStyle.Regular) 'Setting Font
        Printer.Print("------------------------------------------------") 'line

        dblSubtotal = 0
        dblQty = 0
        'looping item sales | loop item penjualan
        For r = 0 To dtItem.Rows.Count - 1
            arrWidth = {130, 50} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidLeft, c.MidRight} 'array alignment 
            Printer.SetFont("Monospace", 8, FontStyle.Regular)
            Printer.Print(dtItem.Rows(r).Item("itemname") & ";0", arrWidth, arrFormat)
            dblQty = dblQty + CSng(dtItem.Rows(r).Item("qty"))

            arrWidth = {60, 60, 60} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidLeft, c.MidRight, c.MidRight} 'array alignment 
            Printer.SetFont("Monospace", 6.5, FontStyle.Regular)
            Printer.Print("1200 bj / 10 dos;" &
                          "100.000;" &
                          "500.000", arrWidth, arrFormat)
            dblQty = dblQty + CSng(dtItem.Rows(r).Item("qty"))
            dblSubtotal = dblSubtotal + (dtItem.Rows(r).Item("qty") * dtItem.Rows(r).Item("price"))
        Next


        arrWidth = {80, 100} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidLeft, c.MidRight} 'array alignment 
        Printer.SetFont("Monospace", 8, FontStyle.Regular) 'Setting Font
        Printer.Print("------------------------------------------------")
        Printer.Print("Total;" & dblSubtotal, arrWidth, arrFormat)
        Printer.Print("Payment;" & dblPayment, arrWidth, arrFormat)
        Printer.Print("Change;" & dblPayment - dblSubtotal, arrWidth, arrFormat)
        Printer.Print("------------------------------------------------")
        arrWidth = {180} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidCenter} 'array alignment 
        Printer.SetFont("Monospace", 8, FontStyle.Regular) 'Setting 
        Printer.Print("Barang yang sudah dibeli tidak dapat dikembalikan. Apabila terjadi masalah, nota harap dibawa kembali.", arrWidth, arrFormat)
        Printer.Print("Terima Kasih Atas Kunjungan Anda.", arrWidth, arrFormat)
        Printer.Print("------------------------------------------------")
        Printer.Print(" ")

        'Release the job for actual printing
        Printer.DoPrint()
    End Sub


    Dim StoreName As String = "SERBA ADA STORE"
    Dim StoreAddress As String = "Jl. Kehidupan No. 100"
    Dim TransNo As String = "TCN10-20191204-001"
    Dim TransDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

    'for item sales | untuk item penjualan
    Dim dtItem As DataTable
    Dim arrWidth() As Integer
    Dim arrFormat() As StringFormat

    'declaring printing format class
    Dim c As New PrintingFormat

    'for subtotal & qty total
    Dim dblSubtotal As Double = 0
    Dim dblQty As Double = 0
    Dim dblPayment As Double = 50000

    Sub Data_Load()
        dtItem = New DataTable
        With dtItem.Columns
            .Add("itemname", Type.GetType("System.String"))
            .Add("qty", Type.GetType("System.String"))
            .Add("price", Type.GetType("System.String"))
        End With

        Dim ItemRow As DataRow

        ItemRow = dtItem.NewRow()
        ItemRow("itemname") = "Taro Snack"
        ItemRow("qty") = "1"
        ItemRow("price") = "5000"
        dtItem.Rows.Add(ItemRow)

        ItemRow = dtItem.NewRow()
        ItemRow("itemname") = "Taro Snack"
        ItemRow("qty") = "1"
        ItemRow("price") = "5000"
        dtItem.Rows.Add(ItemRow)


    End Sub
End Class