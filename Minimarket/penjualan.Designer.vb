
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class penjualan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.labelIdBarang = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textCountItem = New System.Windows.Forms.TextBox()
        Me.labelBarcode = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.buttonScanBarang1 = New System.Windows.Forms.Button()
        Me.buttonScanBarang2 = New System.Windows.Forms.Button()
        Me.buttonScanBarang3 = New System.Windows.Forms.Button()
        Me.buttonScanBarang4 = New System.Windows.Forms.Button()
        Me.buttonScanBarang5 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.textQty = New System.Windows.Forms.TextBox()
        Me.labelQty = New System.Windows.Forms.Label()
        Me.textKembalian = New System.Windows.Forms.TextBox()
        Me.labelKembalian = New System.Windows.Forms.Label()
        Me.textBayar = New System.Windows.Forms.TextBox()
        Me.labelBayar = New System.Windows.Forms.Label()
        Me.textGrandTotal = New System.Windows.Forms.TextBox()
        Me.textTotal = New System.Windows.Forms.TextBox()
        Me.textPLU = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.labelTotalBig = New System.Windows.Forms.Label()
        Me.labelKembalianBig = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(143, 68)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tipe"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(188, 68)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Label7"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(143, 45)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "ID"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(188, 45)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Label9"
        Me.Label9.Visible = False
        '
        'labelIdBarang
        '
        Me.labelIdBarang.AutoSize = True
        Me.labelIdBarang.BackColor = System.Drawing.Color.Transparent
        Me.labelIdBarang.Location = New System.Drawing.Point(781, 509)
        Me.labelIdBarang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelIdBarang.Name = "labelIdBarang"
        Me.labelIdBarang.Size = New System.Drawing.Size(48, 16)
        Me.labelIdBarang.TabIndex = 27
        Me.labelIdBarang.Text = "Label5"
        Me.labelIdBarang.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.textCountItem)
        Me.Panel1.Controls.Add(Me.labelBarcode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1408, 42)
        Me.Panel1.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1232, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Jumlah Item"
        '
        'textCountItem
        '
        Me.textCountItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textCountItem.BackColor = System.Drawing.Color.Black
        Me.textCountItem.ForeColor = System.Drawing.Color.White
        Me.textCountItem.Location = New System.Drawing.Point(1318, 9)
        Me.textCountItem.MinimumSize = New System.Drawing.Size(50, 22)
        Me.textCountItem.Name = "textCountItem"
        Me.textCountItem.Size = New System.Drawing.Size(81, 22)
        Me.textCountItem.TabIndex = 4
        Me.textCountItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelBarcode
        '
        Me.labelBarcode.AutoSize = True
        Me.labelBarcode.BackColor = System.Drawing.Color.Transparent
        Me.labelBarcode.ForeColor = System.Drawing.Color.Lime
        Me.labelBarcode.Location = New System.Drawing.Point(13, 15)
        Me.labelBarcode.Name = "labelBarcode"
        Me.labelBarcode.Size = New System.Drawing.Size(59, 16)
        Me.labelBarcode.TabIndex = 0
        Me.labelBarcode.Text = "Barcode"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.buttonScanBarang1)
        Me.Panel2.Controls.Add(Me.buttonScanBarang2)
        Me.Panel2.Controls.Add(Me.buttonScanBarang3)
        Me.Panel2.Controls.Add(Me.buttonScanBarang4)
        Me.Panel2.Controls.Add(Me.buttonScanBarang5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1408, 50)
        Me.Panel2.TabIndex = 48
        '
        'buttonScanBarang1
        '
        Me.buttonScanBarang1.Location = New System.Drawing.Point(718, 10)
        Me.buttonScanBarang1.Name = "buttonScanBarang1"
        Me.buttonScanBarang1.Size = New System.Drawing.Size(122, 30)
        Me.buttonScanBarang1.TabIndex = 4
        Me.buttonScanBarang1.Text = "Scan Barang 1"
        Me.buttonScanBarang1.UseVisualStyleBackColor = True
        '
        'buttonScanBarang2
        '
        Me.buttonScanBarang2.Location = New System.Drawing.Point(866, 10)
        Me.buttonScanBarang2.Name = "buttonScanBarang2"
        Me.buttonScanBarang2.Size = New System.Drawing.Size(122, 30)
        Me.buttonScanBarang2.TabIndex = 3
        Me.buttonScanBarang2.Text = "Scan Barang 2"
        Me.buttonScanBarang2.UseVisualStyleBackColor = True
        '
        'buttonScanBarang3
        '
        Me.buttonScanBarang3.Location = New System.Drawing.Point(1003, 10)
        Me.buttonScanBarang3.Name = "buttonScanBarang3"
        Me.buttonScanBarang3.Size = New System.Drawing.Size(122, 30)
        Me.buttonScanBarang3.TabIndex = 2
        Me.buttonScanBarang3.Text = "Scan Barang 3"
        Me.buttonScanBarang3.UseVisualStyleBackColor = True
        '
        'buttonScanBarang4
        '
        Me.buttonScanBarang4.Location = New System.Drawing.Point(1140, 10)
        Me.buttonScanBarang4.Name = "buttonScanBarang4"
        Me.buttonScanBarang4.Size = New System.Drawing.Size(122, 30)
        Me.buttonScanBarang4.TabIndex = 1
        Me.buttonScanBarang4.Text = "Scan Barang 4"
        Me.buttonScanBarang4.UseVisualStyleBackColor = True
        '
        'buttonScanBarang5
        '
        Me.buttonScanBarang5.Location = New System.Drawing.Point(1277, 10)
        Me.buttonScanBarang5.Name = "buttonScanBarang5"
        Me.buttonScanBarang5.Size = New System.Drawing.Size(122, 30)
        Me.buttonScanBarang5.TabIndex = 0
        Me.buttonScanBarang5.Text = "Scan Barang 5"
        Me.buttonScanBarang5.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 196)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1408, 329)
        Me.Panel3.TabIndex = 49
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dataGridView1.ColumnHeadersHeight = 30
        Me.dataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.dataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridView1.Name = "dataGridView1"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dataGridView1.RowHeadersWidth = 51
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dataGridView1.Size = New System.Drawing.Size(1408, 325)
        Me.dataGridView1.TabIndex = 29
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.textQty)
        Me.Panel4.Controls.Add(Me.labelQty)
        Me.Panel4.Controls.Add(Me.textKembalian)
        Me.Panel4.Controls.Add(Me.labelKembalian)
        Me.Panel4.Controls.Add(Me.textBayar)
        Me.Panel4.Controls.Add(Me.labelBayar)
        Me.Panel4.Controls.Add(Me.textGrandTotal)
        Me.Panel4.Controls.Add(Me.textTotal)
        Me.Panel4.Controls.Add(Me.textPLU)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 524)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1408, 233)
        Me.Panel4.TabIndex = 50
        '
        'textQty
        '
        Me.textQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textQty.Location = New System.Drawing.Point(401, 8)
        Me.textQty.Name = "textQty"
        Me.textQty.Size = New System.Drawing.Size(195, 30)
        Me.textQty.TabIndex = 2
        '
        'labelQty
        '
        Me.labelQty.AutoSize = True
        Me.labelQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelQty.Location = New System.Drawing.Point(334, 10)
        Me.labelQty.Name = "labelQty"
        Me.labelQty.Size = New System.Drawing.Size(54, 25)
        Me.labelQty.TabIndex = 61
        Me.labelQty.Text = "Qty :"
        '
        'textKembalian
        '
        Me.textKembalian.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textKembalian.Location = New System.Drawing.Point(589, 139)
        Me.textKembalian.Name = "textKembalian"
        Me.textKembalian.ReadOnly = True
        Me.textKembalian.Size = New System.Drawing.Size(260, 30)
        Me.textKembalian.TabIndex = 60
        '
        'labelKembalian
        '
        Me.labelKembalian.AutoSize = True
        Me.labelKembalian.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelKembalian.Location = New System.Drawing.Point(584, 107)
        Me.labelKembalian.Name = "labelKembalian"
        Me.labelKembalian.Size = New System.Drawing.Size(116, 25)
        Me.labelKembalian.TabIndex = 59
        Me.labelKembalian.Text = "Kembalian :"
        '
        'textBayar
        '
        Me.textBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBayar.Location = New System.Drawing.Point(310, 139)
        Me.textBayar.Name = "textBayar"
        Me.textBayar.Size = New System.Drawing.Size(260, 30)
        Me.textBayar.TabIndex = 3
        '
        'labelBayar
        '
        Me.labelBayar.AutoSize = True
        Me.labelBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelBayar.Location = New System.Drawing.Point(305, 107)
        Me.labelBayar.Name = "labelBayar"
        Me.labelBayar.Size = New System.Drawing.Size(74, 25)
        Me.labelBayar.TabIndex = 57
        Me.labelBayar.Text = "Bayar :"
        '
        'textGrandTotal
        '
        Me.textGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textGrandTotal.Location = New System.Drawing.Point(32, 139)
        Me.textGrandTotal.Name = "textGrandTotal"
        Me.textGrandTotal.ReadOnly = True
        Me.textGrandTotal.Size = New System.Drawing.Size(260, 30)
        Me.textGrandTotal.TabIndex = 56
        '
        'textTotal
        '
        Me.textTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTotal.Location = New System.Drawing.Point(98, 56)
        Me.textTotal.Name = "textTotal"
        Me.textTotal.ReadOnly = True
        Me.textTotal.Size = New System.Drawing.Size(195, 30)
        Me.textTotal.TabIndex = 55
        '
        'textPLU
        '
        Me.textPLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPLU.Location = New System.Drawing.Point(97, 8)
        Me.textPLU.Name = "textPLU"
        Me.textPLU.Size = New System.Drawing.Size(195, 30)
        Me.textPLU.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 25)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Grand Total :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 25)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Total :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 25)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "PLU :"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button1.Location = New System.Drawing.Point(16, 182)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(430, 43)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Cetak Nota"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'labelTotalBig
        '
        Me.labelTotalBig.BackColor = System.Drawing.Color.Black
        Me.labelTotalBig.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelTotalBig.Font = New System.Drawing.Font("Arial", 50.25!)
        Me.labelTotalBig.ForeColor = System.Drawing.Color.SpringGreen
        Me.labelTotalBig.Location = New System.Drawing.Point(0, 0)
        Me.labelTotalBig.Margin = New System.Windows.Forms.Padding(4)
        Me.labelTotalBig.Name = "labelTotalBig"
        Me.labelTotalBig.Size = New System.Drawing.Size(1408, 104)
        Me.labelTotalBig.TabIndex = 21
        Me.labelTotalBig.Text = "0"
        Me.labelTotalBig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelKembalianBig
        '
        Me.labelKembalianBig.AutoSize = True
        Me.labelKembalianBig.BackColor = System.Drawing.Color.Black
        Me.labelKembalianBig.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelKembalianBig.ForeColor = System.Drawing.Color.Gold
        Me.labelKembalianBig.Location = New System.Drawing.Point(24, 24)
        Me.labelKembalianBig.Name = "labelKembalianBig"
        Me.labelKembalianBig.Size = New System.Drawing.Size(243, 54)
        Me.labelKembalianBig.TabIndex = 37
        Me.labelKembalianBig.Text = "Kembalian"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Location = New System.Drawing.Point(0, 101)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1408, 2)
        Me.Panel5.TabIndex = 30
        '
        'penjualan
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1408, 757)
        Me.Controls.Add(Me.labelKembalianBig)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.labelIdBarang)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.labelTotalBig)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "penjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penjualan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents labelIdBarang As System.Windows.Forms.Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents labelBarcode As Label
    Friend WithEvents textCountItem As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents buttonScanBarang5 As Button
    Friend WithEvents buttonScanBarang1 As Button
    Friend WithEvents buttonScanBarang2 As Button
    Friend WithEvents buttonScanBarang3 As Button
    Friend WithEvents buttonScanBarang4 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dataGridView1 As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents textQty As TextBox
    Friend WithEvents labelQty As Label
    Friend WithEvents textKembalian As TextBox
    Friend WithEvents labelKembalian As Label
    Friend WithEvents labelBayar As Label
    Friend WithEvents textGrandTotal As TextBox
    Friend WithEvents textTotal As TextBox
    Friend WithEvents textPLU As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents labelTotalBig As Label
    Friend WithEvents labelKembalianBig As Label
    Friend WithEvents textBayar As TextBox
    Friend WithEvents Panel5 As Panel
End Class
