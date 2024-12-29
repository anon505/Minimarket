<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class barang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(barang))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.txtHargaBeli = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStokGudang = New System.Windows.Forms.TextBox()
        Me.tambah = New System.Windows.Forms.Button()
        Me.hapus = New System.Windows.Forms.Button()
        Me.edit = New System.Windows.Forms.Button()
        Me.lihat = New System.Windows.Forms.Button()
        Me.lblIdBarang = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.berdasarkan = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nm_suplier = New System.Windows.Forms.ComboBox()
        Me.syarat = New System.Windows.Forms.ComboBox()
        Me.txtHargaJual1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.satuanbox = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDiskon = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPajak = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtHargaJual2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHargaJual4 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHargaJual3 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtStokDisplay = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtQty4 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtQty3 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtQty2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtHargaBeliNetto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblLastDo = New System.Windows.Forms.Label()
        Me.lblProfit4 = New System.Windows.Forms.Label()
        Me.lblProfit3 = New System.Windows.Forms.Label()
        Me.lblProfit2 = New System.Windows.Forms.Label()
        Me.lblProfit1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblNoFaktur = New System.Windows.Forms.Label()
        Me.lblIdSupplierFaktur = New System.Windows.Forms.Label()
        Me.lblKodeSupplierFaktur = New System.Windows.Forms.Label()
        Me.lblNamaSupplierFaktur = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 50)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1421, 295)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 484)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nama Barang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 546)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Harga Beli"
        '
        'txtNama
        '
        Me.txtNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(177, 481)
        Me.txtNama.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(183, 30)
        Me.txtNama.TabIndex = 3
        '
        'txtHargaBeli
        '
        Me.txtHargaBeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHargaBeli.Location = New System.Drawing.Point(177, 541)
        Me.txtHargaBeli.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHargaBeli.Name = "txtHargaBeli"
        Me.txtHargaBeli.Size = New System.Drawing.Size(183, 30)
        Me.txtHargaBeli.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(751, 538)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Stok Gudang"
        '
        'txtStokGudang
        '
        Me.txtStokGudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStokGudang.Location = New System.Drawing.Point(893, 535)
        Me.txtStokGudang.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStokGudang.Name = "txtStokGudang"
        Me.txtStokGudang.Size = New System.Drawing.Size(191, 30)
        Me.txtStokGudang.TabIndex = 6
        '
        'tambah
        '
        Me.tambah.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tambah.Image = CType(resources.GetObject("tambah.Image"), System.Drawing.Image)
        Me.tambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tambah.Location = New System.Drawing.Point(764, 712)
        Me.tambah.Margin = New System.Windows.Forms.Padding(4)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(156, 65)
        Me.tambah.TabIndex = 7
        Me.tambah.Text = "Tambah"
        Me.tambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tambah.UseVisualStyleBackColor = True
        '
        'hapus
        '
        Me.hapus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hapus.Image = CType(resources.GetObject("hapus.Image"), System.Drawing.Image)
        Me.hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hapus.Location = New System.Drawing.Point(1106, 712)
        Me.hapus.Margin = New System.Windows.Forms.Padding(4)
        Me.hapus.Name = "hapus"
        Me.hapus.Size = New System.Drawing.Size(153, 65)
        Me.hapus.TabIndex = 8
        Me.hapus.Text = "Hapus"
        Me.hapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.hapus.UseVisualStyleBackColor = True
        '
        'edit
        '
        Me.edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.Image = CType(resources.GetObject("edit.Image"), System.Drawing.Image)
        Me.edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit.Location = New System.Drawing.Point(937, 712)
        Me.edit.Margin = New System.Windows.Forms.Padding(4)
        Me.edit.Name = "edit"
        Me.edit.Size = New System.Drawing.Size(153, 65)
        Me.edit.TabIndex = 9
        Me.edit.Text = "Update"
        Me.edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.edit.UseVisualStyleBackColor = True
        '
        'lihat
        '
        Me.lihat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lihat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lihat.Image = CType(resources.GetObject("lihat.Image"), System.Drawing.Image)
        Me.lihat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lihat.Location = New System.Drawing.Point(1273, 712)
        Me.lihat.Margin = New System.Windows.Forms.Padding(4)
        Me.lihat.Name = "lihat"
        Me.lihat.Size = New System.Drawing.Size(164, 65)
        Me.lihat.TabIndex = 10
        Me.lihat.Text = "Refresh"
        Me.lihat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lihat.UseVisualStyleBackColor = True
        '
        'lblIdBarang
        '
        Me.lblIdBarang.AutoSize = True
        Me.lblIdBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdBarang.Location = New System.Drawing.Point(172, 659)
        Me.lblIdBarang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdBarang.Name = "lblIdBarang"
        Me.lblIdBarang.Size = New System.Drawing.Size(19, 25)
        Me.lblIdBarang.TabIndex = 11
        Me.lblIdBarang.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 369)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 25)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Nama Suplier"
        '
        'txtcari
        '
        Me.txtcari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcari.Location = New System.Drawing.Point(557, 11)
        Me.txtcari.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(880, 30)
        Me.txtcari.TabIndex = 15
        '
        'berdasarkan
        '
        Me.berdasarkan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.berdasarkan.FormattingEnabled = True
        Me.berdasarkan.Items.AddRange(New Object() {"Nama Barang", "Harga Jual", "Harga Beli", "Stok Barang"})
        Me.berdasarkan.Location = New System.Drawing.Point(329, 10)
        Me.berdasarkan.Margin = New System.Windows.Forms.Padding(4)
        Me.berdasarkan.Name = "berdasarkan"
        Me.berdasarkan.Size = New System.Drawing.Size(163, 33)
        Me.berdasarkan.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 14)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(282, 25)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Pencarian Barang berdasarkan"
        '
        'nm_suplier
        '
        Me.nm_suplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.nm_suplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm_suplier.FormattingEnabled = True
        Me.nm_suplier.Location = New System.Drawing.Point(177, 364)
        Me.nm_suplier.Margin = New System.Windows.Forms.Padding(4)
        Me.nm_suplier.Name = "nm_suplier"
        Me.nm_suplier.Size = New System.Drawing.Size(183, 33)
        Me.nm_suplier.TabIndex = 1
        '
        'syarat
        '
        Me.syarat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.syarat.FormattingEnabled = True
        Me.syarat.Items.AddRange(New Object() {"<", ">", "=", "<=", ">="})
        Me.syarat.Location = New System.Drawing.Point(501, 9)
        Me.syarat.Margin = New System.Windows.Forms.Padding(4)
        Me.syarat.Name = "syarat"
        Me.syarat.Size = New System.Drawing.Size(47, 33)
        Me.syarat.TabIndex = 19
        '
        'txtHargaJual1
        '
        Me.txtHargaJual1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHargaJual1.Location = New System.Drawing.Point(536, 427)
        Me.txtHargaJual1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHargaJual1.Name = "txtHargaJual1"
        Me.txtHargaJual1.Size = New System.Drawing.Size(183, 30)
        Me.txtHargaJual1.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(386, 430)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 25)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Harga Satuan"
        '
        'satuanbox
        '
        Me.satuanbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.satuanbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.satuanbox.FormattingEnabled = True
        Me.satuanbox.Location = New System.Drawing.Point(535, 364)
        Me.satuanbox.Margin = New System.Windows.Forms.Padding(4)
        Me.satuanbox.Name = "satuanbox"
        Me.satuanbox.Size = New System.Drawing.Size(183, 33)
        Me.satuanbox.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(389, 369)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 25)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Satuan"
        '
        'txtDiskon
        '
        Me.txtDiskon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiskon.Location = New System.Drawing.Point(893, 660)
        Me.txtDiskon.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiskon.Name = "txtDiskon"
        Me.txtDiskon.Size = New System.Drawing.Size(189, 30)
        Me.txtDiskon.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(753, 663)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 25)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Diskon"
        '
        'txtPajak
        '
        Me.txtPajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPajak.Location = New System.Drawing.Point(536, 661)
        Me.txtPajak.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPajak.Name = "txtPajak"
        Me.txtPajak.Size = New System.Drawing.Size(189, 30)
        Me.txtPajak.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(384, 666)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 25)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Pajak"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(177, 427)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(183, 30)
        Me.txtBarcode.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 430)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 25)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Barcode"
        '
        'txtHargaJual2
        '
        Me.txtHargaJual2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHargaJual2.Location = New System.Drawing.Point(536, 481)
        Me.txtHargaJual2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHargaJual2.Name = "txtHargaJual2"
        Me.txtHargaJual2.Size = New System.Drawing.Size(185, 30)
        Me.txtHargaJual2.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(386, 484)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 25)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Harga Jual 2"
        '
        'txtHargaJual4
        '
        Me.txtHargaJual4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHargaJual4.Location = New System.Drawing.Point(535, 597)
        Me.txtHargaJual4.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHargaJual4.Name = "txtHargaJual4"
        Me.txtHargaJual4.Size = New System.Drawing.Size(184, 30)
        Me.txtHargaJual4.TabIndex = 35
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(384, 599)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(123, 25)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Harga Jual 4"
        '
        'txtHargaJual3
        '
        Me.txtHargaJual3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHargaJual3.Location = New System.Drawing.Point(536, 540)
        Me.txtHargaJual3.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHargaJual3.Name = "txtHargaJual3"
        Me.txtHargaJual3.Size = New System.Drawing.Size(183, 30)
        Me.txtHargaJual3.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(384, 541)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(123, 25)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Harga Jual 3"
        '
        'txtStokDisplay
        '
        Me.txtStokDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStokDisplay.Location = New System.Drawing.Point(893, 592)
        Me.txtStokDisplay.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStokDisplay.Name = "txtStokDisplay"
        Me.txtStokDisplay.Size = New System.Drawing.Size(189, 30)
        Me.txtStokDisplay.TabIndex = 37
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(753, 595)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 25)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Stok Display"
        '
        'txtQty4
        '
        Me.txtQty4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty4.Location = New System.Drawing.Point(893, 480)
        Me.txtQty4.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQty4.Name = "txtQty4"
        Me.txtQty4.Size = New System.Drawing.Size(189, 30)
        Me.txtQty4.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(753, 485)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 25)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Qty 4"
        '
        'txtQty3
        '
        Me.txtQty3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty3.Location = New System.Drawing.Point(893, 424)
        Me.txtQty3.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQty3.Name = "txtQty3"
        Me.txtQty3.Size = New System.Drawing.Size(189, 30)
        Me.txtQty3.TabIndex = 43
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(753, 427)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 25)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "Qty 3"
        '
        'txtQty2
        '
        Me.txtQty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty2.Location = New System.Drawing.Point(893, 366)
        Me.txtQty2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQty2.Name = "txtQty2"
        Me.txtQty2.Size = New System.Drawing.Size(189, 30)
        Me.txtQty2.TabIndex = 41
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(753, 371)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 25)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Qty 2"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 661)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 25)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "ID Barang"
        '
        'txtHargaBeliNetto
        '
        Me.txtHargaBeliNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHargaBeliNetto.Location = New System.Drawing.Point(177, 595)
        Me.txtHargaBeliNetto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHargaBeliNetto.Name = "txtHargaBeliNetto"
        Me.txtHargaBeliNetto.Size = New System.Drawing.Size(183, 30)
        Me.txtHargaBeliNetto.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 598)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 25)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Harga Beli Netto"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(1117, 372)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 25)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Profit1"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(1117, 427)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 25)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Profit2"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(1117, 483)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 25)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "Profit3"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(1117, 541)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 25)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Profit4"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(1117, 621)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(119, 25)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "DO Terakhir"
        '
        'lblLastDo
        '
        Me.lblLastDo.AutoSize = True
        Me.lblLastDo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastDo.ForeColor = System.Drawing.Color.Blue
        Me.lblLastDo.Location = New System.Drawing.Point(1251, 621)
        Me.lblLastDo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastDo.Name = "lblLastDo"
        Me.lblLastDo.Size = New System.Drawing.Size(0, 25)
        Me.lblLastDo.TabIndex = 57
        '
        'lblProfit4
        '
        Me.lblProfit4.AutoSize = True
        Me.lblProfit4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfit4.ForeColor = System.Drawing.Color.Red
        Me.lblProfit4.Location = New System.Drawing.Point(1251, 541)
        Me.lblProfit4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProfit4.Name = "lblProfit4"
        Me.lblProfit4.Size = New System.Drawing.Size(0, 25)
        Me.lblProfit4.TabIndex = 56
        '
        'lblProfit3
        '
        Me.lblProfit3.AutoSize = True
        Me.lblProfit3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfit3.ForeColor = System.Drawing.Color.Red
        Me.lblProfit3.Location = New System.Drawing.Point(1251, 483)
        Me.lblProfit3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProfit3.Name = "lblProfit3"
        Me.lblProfit3.Size = New System.Drawing.Size(0, 25)
        Me.lblProfit3.TabIndex = 55
        '
        'lblProfit2
        '
        Me.lblProfit2.AutoSize = True
        Me.lblProfit2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfit2.ForeColor = System.Drawing.Color.Red
        Me.lblProfit2.Location = New System.Drawing.Point(1251, 427)
        Me.lblProfit2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProfit2.Name = "lblProfit2"
        Me.lblProfit2.Size = New System.Drawing.Size(0, 25)
        Me.lblProfit2.TabIndex = 54
        '
        'lblProfit1
        '
        Me.lblProfit1.AutoSize = True
        Me.lblProfit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfit1.ForeColor = System.Drawing.Color.Red
        Me.lblProfit1.Location = New System.Drawing.Point(1251, 372)
        Me.lblProfit1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProfit1.Name = "lblProfit1"
        Me.lblProfit1.Size = New System.Drawing.Size(0, 25)
        Me.lblProfit1.TabIndex = 53
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1122, 659)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 30)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "Lihat Faktur"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblNoFaktur
        '
        Me.lblNoFaktur.AutoSize = True
        Me.lblNoFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoFaktur.Location = New System.Drawing.Point(158, 732)
        Me.lblNoFaktur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNoFaktur.Name = "lblNoFaktur"
        Me.lblNoFaktur.Size = New System.Drawing.Size(0, 25)
        Me.lblNoFaktur.TabIndex = 59
        Me.lblNoFaktur.Visible = False
        '
        'lblIdSupplierFaktur
        '
        Me.lblIdSupplierFaktur.AutoSize = True
        Me.lblIdSupplierFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSupplierFaktur.Location = New System.Drawing.Point(239, 732)
        Me.lblIdSupplierFaktur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdSupplierFaktur.Name = "lblIdSupplierFaktur"
        Me.lblIdSupplierFaktur.Size = New System.Drawing.Size(0, 25)
        Me.lblIdSupplierFaktur.TabIndex = 60
        Me.lblIdSupplierFaktur.Visible = False
        '
        'lblKodeSupplierFaktur
        '
        Me.lblKodeSupplierFaktur.AutoSize = True
        Me.lblKodeSupplierFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodeSupplierFaktur.Location = New System.Drawing.Point(341, 732)
        Me.lblKodeSupplierFaktur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKodeSupplierFaktur.Name = "lblKodeSupplierFaktur"
        Me.lblKodeSupplierFaktur.Size = New System.Drawing.Size(0, 25)
        Me.lblKodeSupplierFaktur.TabIndex = 61
        Me.lblKodeSupplierFaktur.Visible = False
        '
        'lblNamaSupplierFaktur
        '
        Me.lblNamaSupplierFaktur.AutoSize = True
        Me.lblNamaSupplierFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaSupplierFaktur.Location = New System.Drawing.Point(488, 732)
        Me.lblNamaSupplierFaktur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNamaSupplierFaktur.Name = "lblNamaSupplierFaktur"
        Me.lblNamaSupplierFaktur.Size = New System.Drawing.Size(0, 25)
        Me.lblNamaSupplierFaktur.TabIndex = 62
        Me.lblNamaSupplierFaktur.Visible = False
        '
        'barang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1452, 790)
        Me.Controls.Add(Me.lblNamaSupplierFaktur)
        Me.Controls.Add(Me.lblKodeSupplierFaktur)
        Me.Controls.Add(Me.lblIdSupplierFaktur)
        Me.Controls.Add(Me.lblNoFaktur)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblLastDo)
        Me.Controls.Add(Me.lblProfit4)
        Me.Controls.Add(Me.lblProfit3)
        Me.Controls.Add(Me.lblProfit2)
        Me.Controls.Add(Me.lblProfit1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtHargaBeliNetto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtQty4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtQty3)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtQty2)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtStokDisplay)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtHargaJual4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtHargaJual3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtHargaJual2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPajak)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDiskon)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.satuanbox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtHargaJual1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.syarat)
        Me.Controls.Add(Me.nm_suplier)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.berdasarkan)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblIdBarang)
        Me.Controls.Add(Me.lihat)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.hapus)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.txtStokGudang)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtHargaBeli)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "barang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Manajemen Barang"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents txtHargaBeli As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStokGudang As System.Windows.Forms.TextBox
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents hapus As System.Windows.Forms.Button
    Friend WithEvents edit As System.Windows.Forms.Button
    Friend WithEvents lihat As System.Windows.Forms.Button
    Friend WithEvents lblIdBarang As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents berdasarkan As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nm_suplier As System.Windows.Forms.ComboBox
    Friend WithEvents syarat As System.Windows.Forms.ComboBox
    Friend WithEvents txtHargaJual1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents satuanbox As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDiskon As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPajak As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtHargaJual2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHargaJual4 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtHargaJual3 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtStokDisplay As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtQty4 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtQty3 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtQty2 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtHargaBeliNetto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblLastDo As System.Windows.Forms.Label
    Friend WithEvents lblProfit4 As System.Windows.Forms.Label
    Friend WithEvents lblProfit3 As System.Windows.Forms.Label
    Friend WithEvents lblProfit2 As System.Windows.Forms.Label
    Friend WithEvents lblProfit1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblNoFaktur As System.Windows.Forms.Label
    Friend WithEvents lblIdSupplierFaktur As System.Windows.Forms.Label
    Friend WithEvents lblKodeSupplierFaktur As System.Windows.Forms.Label
    Friend WithEvents lblNamaSupplierFaktur As System.Windows.Forms.Label

End Class
