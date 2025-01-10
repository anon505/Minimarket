Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Globalization

Public Class alur_kas

    Private Sub alur_kas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setupGrid()
        loadData("", "")
        calculate("", "")
    End Sub
    Private Sub setupGrid()
        dataGridPembelian.AutoGenerateColumns = True
        dataGridPembelian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridPembelian.ReadOnly = True
        dataGridFisik.AutoGenerateColumns = True
        dataGridFisik.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridFisik.ReadOnly = True
        dataGridPenjualan.AutoGenerateColumns = True
        dataGridPenjualan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridPenjualan.ReadOnly = True
        dataGridKoreksiStok.AutoGenerateColumns = True
        dataGridKoreksiStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridKoreksiStok.ReadOnly = True
    End Sub
    Private Sub loadData(ByVal startDate As String, ByVal endDate As String)
        Dim sqlPembelian As String
        Dim sqlPenjualan As String
        Dim sqlKoreksi As String
        If startDate = "" Or endDate = "" Then
            sqlPembelian = "SELECT no_faktur,tgl_faktur as waktu,nama_kasir,nama_supplier,barcode,nama_barang,qty,price_netto " &
            "FROM ds_report_pembelian_detail " &
"WHERE  (status <> 'temp') " &
"ORDER BY tgl_faktur"
            sqlPenjualan = "SELECT kode_transaksi, barcode, nama_barang, qty, harga_beli, harga_jual " &
            "FROM ds_report_penjualan " &
"ORDER BY waktu ASC"
            sqlKoreksi = "SELECT waktu,nama_barang,deskripsi,`type` AS tipe,koreksi_stok.harga_beli AS harga_bei,qty FROM koreksi_stok " &
                "LEFT JOIN barang ON barang.id_barang=koreksi_stok.id_barang " &
            "ORDER BY waktu ASC"
        Else
            sqlPembelian = "SELECT no_faktur,tgl_faktur as waktu,nama_kasir,nama_supplier,barcode,nama_barang,qty,price_netto " &
            "FROM ds_report_pembelian_detail " &
"WHERE  (status <> 'temp') AND (tgl_faktur >= " & startDate & " AND tgl_faktur <= " & endDate & ") " &
"ORDER BY tgl_faktur"
            sqlPenjualan = "SELECT kode_transaksi, barcode, nama_barang, qty, harga_beli, harga_jual " &
            "FROM ds_report_penjualan " &
"WHERE  (waktu >= " & startDate & ") AND (waktu <= " & endDate & ") " &
"ORDER BY waktu ASC"
            sqlKoreksi = "SELECT waktu,nama_barang,deskripsi,`type` AS tipe,koreksi_stok.harga_beli AS harga_bei,qty FROM koreksi_stok " &
                "LEFT JOIN barang ON barang.id_barang=koreksi_stok.id_barang " &
                "WHERE  (waktu >= " & startDate & ") AND (waktu <= " & endDate & ") " &
            "ORDER BY waktu ASC"
        End If
        Dim dsPembelian = newConnect.ExecuteReader(sqlPembelian)
        dataGridPembelian.DataSource = dsPembelian

        Dim dsFisik = newConnect.ExecuteReader("select barcode,nama_barang,(stok_display+stok_gudang) as total_stok,stok_display,stok_gudang,harga_beli_netto,nama_satuan,nama_suplier from barang left JOIN satuan ON satuan.id_satuan=barang.id_satuan left JOIN supplier ON supplier.id_suplier=barang.id_suplier")
        dataGridFisik.DataSource = dsFisik

        Dim dsPenjualan = newConnect.ExecuteReader(sqlPenjualan)
        dataGridPenjualan.DataSource = dsPenjualan

        Dim dsKoreksi = newConnect.ExecuteReader(sqlKoreksi)
        dataGridKoreksiStok.DataSource = dsKoreksi
    End Sub

    Private Sub calculate(ByVal startDate As String, ByVal endDate As String)
        Dim sqlPembelian As String
        Dim sqlPenjualan As String
        Dim sqlKoreksiPlus As String
        Dim sqlKoreksiMinus As String
        Dim sqlKoreksiJumlah As String
        If startDate = "" Or endDate = "" Then
            sqlPembelian = "SELECT SUM(price_netto*qty) as transaksi " &
            "FROM ds_report_pembelian_detail " &
"WHERE  (status <> 'temp') " &
"ORDER BY tgl_faktur"
            sqlPenjualan = "SELECT sum(qty * harga_jual) as transaksi " &
            "FROM ds_report_penjualan " &
"ORDER BY waktu ASC"
            sqlKoreksiMinus = "select sum(qty*harga_beli) as transaksi from koreksi_stok where type='minus'"
            sqlKoreksiPlus = "select sum(qty*harga_beli) as transaksi from koreksi_stok where type='plus'"
            sqlKoreksiJumlah = "select sum(qty*harga_beli) as transaksi from koreksi_stok"
        Else
            sqlPembelian = "SELECT SUM(price_netto*qty) as transaksi " &
            "FROM ds_report_pembelian_detail " &
"WHERE  (status <> 'temp') AND (tgl_faktur >= " & startDate & " AND tgl_faktur <= " & endDate & ") " &
"ORDER BY tgl_faktur"
            sqlPenjualan = "SELECT sum(qty * harga_jual) as transaksi " &
           "FROM ds_report_penjualan " &
"WHERE  (waktu >= " & startDate & ") AND (waktu <= " & endDate & ") " &
"ORDER BY waktu ASC"
            sqlKoreksiMinus = "select sum(qty*harga_beli) as transaksi from koreksi_stok where type='minus' and (waktu >= " & startDate & ") AND (waktu <= " & endDate & ")"

            sqlKoreksiPlus = "select sum(qty*harga_beli) as transaksi from koreksi_stok where type='plus' and (waktu >= " & startDate & ") AND (waktu <= " & endDate & ")"
            sqlKoreksiJumlah = "select sum(qty*harga_beli) as transaksi from koreksi_stok where  (waktu >= " & startDate & ") AND (waktu <= " & endDate & ")"
        End If
        Dim dsPembelian = newConnect.ExecuteScalar(sqlPembelian)
        textPembelian.Text = Format(dsPembelian, "#,0;-#,0")
        Dim dsFisik = newConnect.ExecuteScalar("select sum((stok_display+stok_gudang) * harga_beli_netto) as fisik from barang left JOIN satuan ON satuan.id_satuan=barang.id_satuan left JOIN supplier ON supplier.id_suplier=barang.id_suplier")
        textFisik.Text = Format(dsFisik, "#,0;-#,0")
        Dim dsPenjualan = newConnect.ExecuteScalar(sqlPenjualan)
        textPenjualan.Text = Format(dsPenjualan, "#,0;-#,0")
        Dim dsKoreksiMinus = newConnect.ExecuteScalar(sqlKoreksiMinus)
        textKoreksiMinus.Text = Format(dsKoreksiMinus, "#,0;-#,0")
        Dim dsKoreksiPlus = newConnect.ExecuteScalar(sqlKoreksiPlus)
        textKoreksiPlus.Text = Format(dsKoreksiPlus, "#,0;-#,0")

        Dim dsKoreksiJumlah = newConnect.ExecuteScalar(sqlKoreksiJumlah)
        textKoreksiJumlah.Text = Format(dsKoreksiJumlah, "#,0;-#,0")


    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        txtEndDateTime.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        txtStartDateTime.Text = DateTimePicker2.Value.Date
    End Sub
    Private Sub buttonCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonCari.Click
        If txtEndDateTime.Text = "" Or txtEndDateTime.Text = "" Then
            loadData("", "")
            calculate("", "")
        Else
            Dim startTime = DateTime.ParseExact(txtStartDateTime.Text & " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
            Dim endTime = DateTime.ParseExact(txtEndDateTime.Text & " 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss")
            loadData(startTime, endTime)
            calculate(startTime, endTime)
        End If
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        koreksi_stok.Show()

    End Sub
End Class