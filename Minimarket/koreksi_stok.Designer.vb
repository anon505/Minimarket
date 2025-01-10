<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class koreksi_stok
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
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.textQty = New System.Windows.Forms.TextBox()
        Me.labelQty = New System.Windows.Forms.Label()
        Me.textNama = New System.Windows.Forms.TextBox()
        Me.textPLU = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textHargaBeli = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboTipe = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textDeskripsi = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comboJenis = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.textStokDisplay = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.textStokGudang = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSimpan
        '
        Me.btnSimpan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSimpan.Location = New System.Drawing.Point(12, 543)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(391, 35)
        Me.btnSimpan.TabIndex = 0
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'textQty
        '
        Me.textQty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textQty.Location = New System.Drawing.Point(148, 68)
        Me.textQty.Name = "textQty"
        Me.textQty.Size = New System.Drawing.Size(255, 30)
        Me.textQty.TabIndex = 63
        '
        'labelQty
        '
        Me.labelQty.AutoSize = True
        Me.labelQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelQty.Location = New System.Drawing.Point(7, 68)
        Me.labelQty.Name = "labelQty"
        Me.labelQty.Size = New System.Drawing.Size(43, 25)
        Me.labelQty.TabIndex = 67
        Me.labelQty.Text = "Qty"
        '
        'textNama
        '
        Me.textNama.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNama.Location = New System.Drawing.Point(148, 120)
        Me.textNama.Name = "textNama"
        Me.textNama.ReadOnly = True
        Me.textNama.Size = New System.Drawing.Size(255, 30)
        Me.textNama.TabIndex = 66
        '
        'textPLU
        '
        Me.textPLU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textPLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPLU.Location = New System.Drawing.Point(148, 20)
        Me.textPLU.Name = "textPLU"
        Me.textPLU.Size = New System.Drawing.Size(255, 30)
        Me.textPLU.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 25)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Nama Barang"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 25)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "PLU"
        '
        'textHargaBeli
        '
        Me.textHargaBeli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textHargaBeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textHargaBeli.Location = New System.Drawing.Point(148, 174)
        Me.textHargaBeli.Name = "textHargaBeli"
        Me.textHargaBeli.ReadOnly = True
        Me.textHargaBeli.Size = New System.Drawing.Size(255, 30)
        Me.textHargaBeli.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 25)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Harga Beli"
        '
        'comboTipe
        '
        Me.comboTipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboTipe.FormattingEnabled = True
        Me.comboTipe.Items.AddRange(New Object() {"plus", "minus"})
        Me.comboTipe.Location = New System.Drawing.Point(150, 348)
        Me.comboTipe.Name = "comboTipe"
        Me.comboTipe.Size = New System.Drawing.Size(255, 33)
        Me.comboTipe.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 356)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 25)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Tipe"
        '
        'textDeskripsi
        '
        Me.textDeskripsi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textDeskripsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDeskripsi.Location = New System.Drawing.Point(150, 403)
        Me.textDeskripsi.Margin = New System.Windows.Forms.Padding(4)
        Me.textDeskripsi.Multiline = True
        Me.textDeskripsi.Name = "textDeskripsi"
        Me.textDeskripsi.Size = New System.Drawing.Size(254, 60)
        Me.textDeskripsi.TabIndex = 73
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 403)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 25)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Deskripsi"
        '
        'comboJenis
        '
        Me.comboJenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboJenis.FormattingEnabled = True
        Me.comboJenis.Items.AddRange(New Object() {"stok_display", "stok_gudang"})
        Me.comboJenis.Location = New System.Drawing.Point(150, 484)
        Me.comboJenis.Name = "comboJenis"
        Me.comboJenis.Size = New System.Drawing.Size(255, 33)
        Me.comboJenis.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 492)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 25)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Jenis"
        '
        'textStokDisplay
        '
        Me.textStokDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textStokDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textStokDisplay.Location = New System.Drawing.Point(148, 226)
        Me.textStokDisplay.Name = "textStokDisplay"
        Me.textStokDisplay.ReadOnly = True
        Me.textStokDisplay.Size = New System.Drawing.Size(255, 30)
        Me.textStokDisplay.TabIndex = 77
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 25)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Stok Display"
        '
        'textStokGudang
        '
        Me.textStokGudang.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textStokGudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textStokGudang.Location = New System.Drawing.Point(149, 282)
        Me.textStokGudang.Name = "textStokGudang"
        Me.textStokGudang.ReadOnly = True
        Me.textStokGudang.Size = New System.Drawing.Size(255, 30)
        Me.textStokGudang.TabIndex = 79
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 287)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 25)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Stok Gudang"
        '
        'koreksi_stok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 590)
        Me.Controls.Add(Me.textStokGudang)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.textStokDisplay)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.comboJenis)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.textDeskripsi)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.comboTipe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textHargaBeli)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textQty)
        Me.Controls.Add(Me.labelQty)
        Me.Controls.Add(Me.textNama)
        Me.Controls.Add(Me.textPLU)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSimpan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "koreksi_stok"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "koreksi_stok"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents textQty As System.Windows.Forms.TextBox
    Friend WithEvents labelQty As System.Windows.Forms.Label
    Friend WithEvents textNama As System.Windows.Forms.TextBox
    Friend WithEvents textPLU As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents textHargaBeli As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents comboTipe As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents textDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents comboJenis As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents textStokDisplay As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents textStokGudang As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
