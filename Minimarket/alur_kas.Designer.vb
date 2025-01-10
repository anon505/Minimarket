<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class alur_kas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dataGridPembelian = New System.Windows.Forms.DataGridView()
        Me.txtStartDateTime = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.txtEndDateTime = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.buttonCari = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPembelian = New System.Windows.Forms.TabPage()
        Me.tabBarangFisik = New System.Windows.Forms.TabPage()
        Me.dataGridFisik = New System.Windows.Forms.DataGridView()
        Me.tabKoreksiStok = New System.Windows.Forms.TabPage()
        Me.dataGridKoreksiStok = New System.Windows.Forms.DataGridView()
        Me.tabPenjualan = New System.Windows.Forms.TabPage()
        Me.dataGridPenjualan = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textPembelian = New System.Windows.Forms.Label()
        Me.textFisik = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.textPenjualan = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.textKoreksiMinus = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.textKoreksiPlus = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.textKoreksiJumlah = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dataGridPembelian, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabPembelian.SuspendLayout()
        Me.tabBarangFisik.SuspendLayout()
        CType(Me.dataGridFisik, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabKoreksiStok.SuspendLayout()
        CType(Me.dataGridKoreksiStok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPenjualan.SuspendLayout()
        CType(Me.dataGridPenjualan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataGridPembelian
        '
        Me.dataGridPembelian.AllowUserToAddRows = False
        Me.dataGridPembelian.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridPembelian.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dataGridPembelian.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridPembelian.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.dataGridPembelian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridPembelian.Location = New System.Drawing.Point(0, 0)
        Me.dataGridPembelian.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridPembelian.Name = "dataGridPembelian"
        Me.dataGridPembelian.RowHeadersWidth = 51
        Me.dataGridPembelian.Size = New System.Drawing.Size(1363, 487)
        Me.dataGridPembelian.TabIndex = 20
        '
        'txtStartDateTime
        '
        Me.txtStartDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartDateTime.Location = New System.Drawing.Point(866, 44)
        Me.txtStartDateTime.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStartDateTime.Name = "txtStartDateTime"
        Me.txtStartDateTime.Size = New System.Drawing.Size(164, 30)
        Me.txtStartDateTime.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(862, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 25)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Dari Tanggal :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(1032, 44)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(23, 30)
        Me.DateTimePicker2.TabIndex = 44
        '
        'txtEndDateTime
        '
        Me.txtEndDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEndDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndDateTime.Location = New System.Drawing.Point(1074, 44)
        Me.txtEndDateTime.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEndDateTime.Name = "txtEndDateTime"
        Me.txtEndDateTime.Size = New System.Drawing.Size(164, 30)
        Me.txtEndDateTime.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1070, 10)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 25)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Sampai Tanggal "
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(1240, 44)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(23, 30)
        Me.DateTimePicker1.TabIndex = 41
        '
        'buttonCari
        '
        Me.buttonCari.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCari.Location = New System.Drawing.Point(1285, 44)
        Me.buttonCari.Name = "buttonCari"
        Me.buttonCari.Size = New System.Drawing.Size(94, 30)
        Me.buttonCari.TabIndex = 52
        Me.buttonCari.Text = "Filter"
        Me.buttonCari.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabPembelian)
        Me.TabControl1.Controls.Add(Me.tabBarangFisik)
        Me.TabControl1.Controls.Add(Me.tabKoreksiStok)
        Me.TabControl1.Controls.Add(Me.tabPenjualan)
        Me.TabControl1.Location = New System.Drawing.Point(12, 94)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1371, 516)
        Me.TabControl1.TabIndex = 53
        '
        'tabPembelian
        '
        Me.tabPembelian.Controls.Add(Me.dataGridPembelian)
        Me.tabPembelian.Location = New System.Drawing.Point(4, 25)
        Me.tabPembelian.Name = "tabPembelian"
        Me.tabPembelian.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPembelian.Size = New System.Drawing.Size(1363, 487)
        Me.tabPembelian.TabIndex = 0
        Me.tabPembelian.Text = "Pembelian Barang"
        Me.tabPembelian.UseVisualStyleBackColor = True
        '
        'tabBarangFisik
        '
        Me.tabBarangFisik.Controls.Add(Me.dataGridFisik)
        Me.tabBarangFisik.Location = New System.Drawing.Point(4, 25)
        Me.tabBarangFisik.Name = "tabBarangFisik"
        Me.tabBarangFisik.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBarangFisik.Size = New System.Drawing.Size(1363, 487)
        Me.tabBarangFisik.TabIndex = 1
        Me.tabBarangFisik.Text = "Barang Fisik"
        Me.tabBarangFisik.UseVisualStyleBackColor = True
        '
        'dataGridFisik
        '
        Me.dataGridFisik.AllowUserToAddRows = False
        Me.dataGridFisik.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridFisik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dataGridFisik.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridFisik.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.dataGridFisik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridFisik.Location = New System.Drawing.Point(0, 0)
        Me.dataGridFisik.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridFisik.Name = "dataGridFisik"
        Me.dataGridFisik.RowHeadersWidth = 51
        Me.dataGridFisik.Size = New System.Drawing.Size(1363, 487)
        Me.dataGridFisik.TabIndex = 21
        '
        'tabKoreksiStok
        '
        Me.tabKoreksiStok.Controls.Add(Me.dataGridKoreksiStok)
        Me.tabKoreksiStok.Location = New System.Drawing.Point(4, 25)
        Me.tabKoreksiStok.Name = "tabKoreksiStok"
        Me.tabKoreksiStok.Size = New System.Drawing.Size(1363, 487)
        Me.tabKoreksiStok.TabIndex = 2
        Me.tabKoreksiStok.Text = "Koreksi Stok"
        Me.tabKoreksiStok.UseVisualStyleBackColor = True
        '
        'dataGridKoreksiStok
        '
        Me.dataGridKoreksiStok.AllowUserToAddRows = False
        Me.dataGridKoreksiStok.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridKoreksiStok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dataGridKoreksiStok.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridKoreksiStok.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.dataGridKoreksiStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridKoreksiStok.Location = New System.Drawing.Point(1, 0)
        Me.dataGridKoreksiStok.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridKoreksiStok.Name = "dataGridKoreksiStok"
        Me.dataGridKoreksiStok.RowHeadersWidth = 51
        Me.dataGridKoreksiStok.Size = New System.Drawing.Size(1363, 487)
        Me.dataGridKoreksiStok.TabIndex = 22
        '
        'tabPenjualan
        '
        Me.tabPenjualan.Controls.Add(Me.dataGridPenjualan)
        Me.tabPenjualan.Location = New System.Drawing.Point(4, 25)
        Me.tabPenjualan.Name = "tabPenjualan"
        Me.tabPenjualan.Size = New System.Drawing.Size(1363, 487)
        Me.tabPenjualan.TabIndex = 3
        Me.tabPenjualan.Text = "Penjualan Barang"
        Me.tabPenjualan.UseVisualStyleBackColor = True
        '
        'dataGridPenjualan
        '
        Me.dataGridPenjualan.AllowUserToAddRows = False
        Me.dataGridPenjualan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridPenjualan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dataGridPenjualan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridPenjualan.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.dataGridPenjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridPenjualan.Location = New System.Drawing.Point(1, 0)
        Me.dataGridPenjualan.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridPenjualan.Name = "dataGridPenjualan"
        Me.dataGridPenjualan.RowHeadersWidth = 51
        Me.dataGridPenjualan.Size = New System.Drawing.Size(1363, 487)
        Me.dataGridPenjualan.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 617)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 18)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Total Pembelian"
        '
        'textPembelian
        '
        Me.textPembelian.AutoSize = True
        Me.textPembelian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPembelian.Location = New System.Drawing.Point(153, 617)
        Me.textPembelian.Name = "textPembelian"
        Me.textPembelian.Size = New System.Drawing.Size(16, 18)
        Me.textPembelian.TabIndex = 55
        Me.textPembelian.Text = "0"
        '
        'textFisik
        '
        Me.textFisik.AutoSize = True
        Me.textFisik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFisik.Location = New System.Drawing.Point(153, 688)
        Me.textFisik.Name = "textFisik"
        Me.textFisik.Size = New System.Drawing.Size(16, 18)
        Me.textFisik.TabIndex = 57
        Me.textFisik.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 688)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 18)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Total Barang Fisik"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(16, 644)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(405, 16)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Total pembelian(Harga Netto*Qty) berdasarkan pembelian/faktur yg sudah di MARKUP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(16, 710)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(445, 16)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Total barang yang ada di rak dan di gudang dengan perhitungan(Total Stok * Harga " & _
            "Beli Netto)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(16, 779)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(526, 16)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Total penjualan berdasarkan perhitungan(Omset+Laba Bersih) dari transaksi penjual" & _
            "an yang telah selesai(DONE)"
        '
        'textPenjualan
        '
        Me.textPenjualan.AutoSize = True
        Me.textPenjualan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPenjualan.Location = New System.Drawing.Point(153, 757)
        Me.textPenjualan.Name = "textPenjualan"
        Me.textPenjualan.Size = New System.Drawing.Size(16, 18)
        Me.textPenjualan.TabIndex = 61
        Me.textPenjualan.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 757)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 18)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Total Penjualan"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(16, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 30)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "Koreksi Stok"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(769, 639)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(264, 16)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Total barang(Qty*Harga Jual Yang Berlaku) yang hilang"
        '
        'textKoreksiMinus
        '
        Me.textKoreksiMinus.AutoSize = True
        Me.textKoreksiMinus.Location = New System.Drawing.Point(906, 617)
        Me.textKoreksiMinus.Name = "textKoreksiMinus"
        Me.textKoreksiMinus.Size = New System.Drawing.Size(16, 17)
        Me.textKoreksiMinus.TabIndex = 65
        Me.textKoreksiMinus.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(769, 617)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 17)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "Total Minus"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(769, 710)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(348, 16)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Total barang(Qty*Harga Jual Yang Berlaku) yang tidak diambil pemiliknya"
        '
        'textKoreksiPlus
        '
        Me.textKoreksiPlus.AutoSize = True
        Me.textKoreksiPlus.Location = New System.Drawing.Point(906, 688)
        Me.textKoreksiPlus.Name = "textKoreksiPlus"
        Me.textKoreksiPlus.Size = New System.Drawing.Size(16, 17)
        Me.textKoreksiPlus.TabIndex = 68
        Me.textKoreksiPlus.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(769, 688)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 17)
        Me.Label17.TabIndex = 67
        Me.Label17.Text = "Total Plus"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(769, 779)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(434, 16)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "NB: Total Plus dan Minus otomatis berubah jadi barang, tidak akan berpengaruh ke " & _
            "total kas"
        '
        'textKoreksiJumlah
        '
        Me.textKoreksiJumlah.AutoSize = True
        Me.textKoreksiJumlah.Location = New System.Drawing.Point(906, 757)
        Me.textKoreksiJumlah.Name = "textKoreksiJumlah"
        Me.textKoreksiJumlah.Size = New System.Drawing.Size(16, 17)
        Me.textKoreksiJumlah.TabIndex = 72
        Me.textKoreksiJumlah.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(769, 757)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Minus+Plus"
        '
        'alur_kas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1396, 827)
        Me.Controls.Add(Me.textKoreksiJumlah)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.textKoreksiPlus)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.textKoreksiMinus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.textPenjualan)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.textFisik)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.textPembelian)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.buttonCari)
        Me.Controls.Add(Me.txtStartDateTime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.txtEndDateTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "alur_kas"
        Me.Text = "Alur Kas"
        CType(Me.dataGridPembelian, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabPembelian.ResumeLayout(False)
        Me.tabBarangFisik.ResumeLayout(False)
        CType(Me.dataGridFisik, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabKoreksiStok.ResumeLayout(False)
        CType(Me.dataGridKoreksiStok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPenjualan.ResumeLayout(False)
        CType(Me.dataGridPenjualan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dataGridPembelian As System.Windows.Forms.DataGridView
    Friend WithEvents txtStartDateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEndDateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents buttonCari As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPembelian As System.Windows.Forms.TabPage
    Friend WithEvents tabBarangFisik As System.Windows.Forms.TabPage
    Friend WithEvents tabKoreksiStok As System.Windows.Forms.TabPage
    Friend WithEvents tabPenjualan As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textPembelian As System.Windows.Forms.Label
    Friend WithEvents textFisik As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents textPenjualan As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents textKoreksiMinus As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents textKoreksiPlus As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dataGridFisik As System.Windows.Forms.DataGridView
    Friend WithEvents dataGridKoreksiStok As System.Windows.Forms.DataGridView
    Friend WithEvents dataGridPenjualan As System.Windows.Forms.DataGridView
    Friend WithEvents textKoreksiJumlah As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
