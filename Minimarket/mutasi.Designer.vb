<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mutasi
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textDeskripsi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textIdReff = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lihat = New System.Windows.Forms.Button()
        Me.edit = New System.Windows.Forms.Button()
        Me.hapus = New System.Windows.Forms.Button()
        Me.tambah = New System.Windows.Forms.Button()
        Me.txtStartDateTime = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.txtEndDateTime = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.comboTipe = New System.Windows.Forms.ComboBox()
        Me.textNominal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.buttonCari = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCashOnHand = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblModalBarang = New System.Windows.Forms.Label()
        Me.lblTotalHutang = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblModalAkhir = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblPengeluaran = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 555)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'textDeskripsi
        '
        Me.textDeskripsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDeskripsi.Location = New System.Drawing.Point(172, 499)
        Me.textDeskripsi.Margin = New System.Windows.Forms.Padding(4)
        Me.textDeskripsi.Multiline = True
        Me.textDeskripsi.Name = "textDeskripsi"
        Me.textDeskripsi.Size = New System.Drawing.Size(413, 60)
        Me.textDeskripsi.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 499)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 25)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Deskripsi"
        '
        'textIdReff
        '
        Me.textIdReff.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textIdReff.Location = New System.Drawing.Point(172, 452)
        Me.textIdReff.Margin = New System.Windows.Forms.Padding(4)
        Me.textIdReff.Name = "textIdReff"
        Me.textIdReff.Size = New System.Drawing.Size(191, 30)
        Me.textIdReff.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 583)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 25)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Tipe Transaksi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 455)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 25)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "ID Referensi"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 96)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1175, 334)
        Me.DataGridView1.TabIndex = 20
        '
        'lihat
        '
        Me.lihat.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lihat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lihat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lihat.Location = New System.Drawing.Point(518, 680)
        Me.lihat.Margin = New System.Windows.Forms.Padding(4)
        Me.lihat.Name = "lihat"
        Me.lihat.Size = New System.Drawing.Size(170, 39)
        Me.lihat.TabIndex = 39
        Me.lihat.Text = "Refresh"
        Me.lihat.UseVisualStyleBackColor = True
        '
        'edit
        '
        Me.edit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit.Location = New System.Drawing.Point(184, 680)
        Me.edit.Margin = New System.Windows.Forms.Padding(4)
        Me.edit.Name = "edit"
        Me.edit.Size = New System.Drawing.Size(159, 39)
        Me.edit.TabIndex = 38
        Me.edit.Text = "Update"
        Me.edit.UseVisualStyleBackColor = True
        '
        'hapus
        '
        Me.hapus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.hapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hapus.Location = New System.Drawing.Point(351, 680)
        Me.hapus.Margin = New System.Windows.Forms.Padding(4)
        Me.hapus.Name = "hapus"
        Me.hapus.Size = New System.Drawing.Size(159, 39)
        Me.hapus.TabIndex = 37
        Me.hapus.Text = "Hapus"
        Me.hapus.UseVisualStyleBackColor = True
        '
        'tambah
        '
        Me.tambah.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tambah.Location = New System.Drawing.Point(14, 680)
        Me.tambah.Margin = New System.Windows.Forms.Padding(4)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(162, 39)
        Me.tambah.TabIndex = 36
        Me.tambah.Text = "Tambah"
        Me.tambah.UseVisualStyleBackColor = True
        '
        'txtStartDateTime
        '
        Me.txtStartDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartDateTime.Location = New System.Drawing.Point(674, 44)
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
        Me.Label5.Location = New System.Drawing.Point(670, 10)
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
        Me.DateTimePicker2.Location = New System.Drawing.Point(840, 44)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(23, 30)
        Me.DateTimePicker2.TabIndex = 44
        '
        'txtEndDateTime
        '
        Me.txtEndDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEndDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndDateTime.Location = New System.Drawing.Point(882, 44)
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
        Me.Label6.Location = New System.Drawing.Point(878, 10)
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
        Me.DateTimePicker1.Location = New System.Drawing.Point(1048, 44)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(23, 30)
        Me.DateTimePicker1.TabIndex = 41
        '
        'comboTipe
        '
        Me.comboTipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboTipe.FormattingEnabled = True
        Me.comboTipe.Items.AddRange(New Object() {"penjualan", "pembelian", "bayar_hutang", "pengeluaran"})
        Me.comboTipe.Location = New System.Drawing.Point(176, 575)
        Me.comboTipe.Name = "comboTipe"
        Me.comboTipe.Size = New System.Drawing.Size(187, 33)
        Me.comboTipe.TabIndex = 47
        '
        'textNominal
        '
        Me.textNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNominal.Location = New System.Drawing.Point(176, 625)
        Me.textNominal.Margin = New System.Windows.Forms.Padding(4)
        Me.textNominal.Name = "textNominal"
        Me.textNominal.Size = New System.Drawing.Size(191, 30)
        Me.textNominal.TabIndex = 51
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 628)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 25)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Nominal"
        '
        'buttonCari
        '
        Me.buttonCari.Location = New System.Drawing.Point(1097, 44)
        Me.buttonCari.Name = "buttonCari"
        Me.buttonCari.Size = New System.Drawing.Size(94, 30)
        Me.buttonCari.TabIndex = 52
        Me.buttonCari.Text = "Filter"
        Me.buttonCari.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(836, 465)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 20)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Cash On Hand"
        '
        'lblCashOnHand
        '
        Me.lblCashOnHand.AutoSize = True
        Me.lblCashOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashOnHand.Location = New System.Drawing.Point(990, 463)
        Me.lblCashOnHand.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCashOnHand.Name = "lblCashOnHand"
        Me.lblCashOnHand.Size = New System.Drawing.Size(23, 25)
        Me.lblCashOnHand.TabIndex = 54
        Me.lblCashOnHand.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(836, 507)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 20)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "Modal Barang"
        '
        'lblModalBarang
        '
        Me.lblModalBarang.AutoSize = True
        Me.lblModalBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModalBarang.Location = New System.Drawing.Point(990, 505)
        Me.lblModalBarang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblModalBarang.Name = "lblModalBarang"
        Me.lblModalBarang.Size = New System.Drawing.Size(23, 25)
        Me.lblModalBarang.TabIndex = 56
        Me.lblModalBarang.Text = "0"
        '
        'lblTotalHutang
        '
        Me.lblTotalHutang.AutoSize = True
        Me.lblTotalHutang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHutang.Location = New System.Drawing.Point(990, 543)
        Me.lblTotalHutang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalHutang.Name = "lblTotalHutang"
        Me.lblTotalHutang.Size = New System.Drawing.Size(23, 25)
        Me.lblTotalHutang.TabIndex = 60
        Me.lblTotalHutang.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(836, 545)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 20)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Total Hutang"
        '
        'lblModalAkhir
        '
        Me.lblModalAkhir.AutoSize = True
        Me.lblModalAkhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModalAkhir.Location = New System.Drawing.Point(990, 621)
        Me.lblModalAkhir.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblModalAkhir.Name = "lblModalAkhir"
        Me.lblModalAkhir.Size = New System.Drawing.Size(23, 25)
        Me.lblModalAkhir.TabIndex = 62
        Me.lblModalAkhir.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(836, 625)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 20)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "Modal Akhir"
        '
        'lblPengeluaran
        '
        Me.lblPengeluaran.AutoSize = True
        Me.lblPengeluaran.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPengeluaran.Location = New System.Drawing.Point(990, 583)
        Me.lblPengeluaran.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPengeluaran.Name = "lblPengeluaran"
        Me.lblPengeluaran.Size = New System.Drawing.Size(23, 25)
        Me.lblPengeluaran.TabIndex = 64
        Me.lblPengeluaran.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(836, 586)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 20)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Pengeluaran"
        '
        'mutasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1204, 732)
        Me.Controls.Add(Me.lblPengeluaran)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblModalAkhir)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblTotalHutang)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblModalBarang)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblCashOnHand)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.buttonCari)
        Me.Controls.Add(Me.textNominal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.comboTipe)
        Me.Controls.Add(Me.txtStartDateTime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.txtEndDateTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lihat)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.hapus)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.textDeskripsi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.textIdReff)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "mutasi"
        Me.Text = "Mutasi"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents textDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents textIdReff As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lihat As System.Windows.Forms.Button
    Friend WithEvents edit As System.Windows.Forms.Button
    Friend WithEvents hapus As System.Windows.Forms.Button
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents txtStartDateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEndDateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents comboTipe As System.Windows.Forms.ComboBox
    Friend WithEvents textNominal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents buttonCari As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCashOnHand As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblModalBarang As System.Windows.Forms.Label
    Friend WithEvents lblTotalHutang As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblModalAkhir As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblPengeluaran As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
