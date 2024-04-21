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
        Me.txtnama = New System.Windows.Forms.TextBox()
        Me.txthargabeli = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtstok = New System.Windows.Forms.TextBox()
        Me.tambah = New System.Windows.Forms.Button()
        Me.hapus = New System.Windows.Forms.Button()
        Me.edit = New System.Windows.Forms.Button()
        Me.lihat = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.berdasarkan = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nm_suplier = New System.Windows.Forms.ComboBox()
        Me.syarat = New System.Windows.Forms.ComboBox()
        Me.txthargajual = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.satuanbox = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(838, 240)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 350)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nama Barang"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 394)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Harga Beli"
        '
        'txtnama
        '
        Me.txtnama.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtnama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnama.Location = New System.Drawing.Point(117, 344)
        Me.txtnama.Name = "txtnama"
        Me.txtnama.Size = New System.Drawing.Size(207, 26)
        Me.txtnama.TabIndex = 3
        '
        'txthargabeli
        '
        Me.txthargabeli.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txthargabeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthargabeli.Location = New System.Drawing.Point(117, 388)
        Me.txthargabeli.Name = "txthargabeli"
        Me.txthargabeli.Size = New System.Drawing.Size(207, 26)
        Me.txthargabeli.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 480)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Stok Barang"
        '
        'txtstok
        '
        Me.txtstok.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtstok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstok.Location = New System.Drawing.Point(117, 474)
        Me.txtstok.Name = "txtstok"
        Me.txtstok.Size = New System.Drawing.Size(207, 26)
        Me.txtstok.TabIndex = 6
        '
        'tambah
        '
        Me.tambah.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tambah.Image = CType(resources.GetObject("tambah.Image"), System.Drawing.Image)
        Me.tambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tambah.Location = New System.Drawing.Point(344, 498)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(117, 48)
        Me.tambah.TabIndex = 7
        Me.tambah.Text = "Tambah"
        Me.tambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tambah.UseVisualStyleBackColor = True
        '
        'hapus
        '
        Me.hapus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.hapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hapus.Image = CType(resources.GetObject("hapus.Image"), System.Drawing.Image)
        Me.hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hapus.Location = New System.Drawing.Point(601, 498)
        Me.hapus.Name = "hapus"
        Me.hapus.Size = New System.Drawing.Size(115, 48)
        Me.hapus.TabIndex = 8
        Me.hapus.Text = "Hapus"
        Me.hapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.hapus.UseVisualStyleBackColor = True
        '
        'edit
        '
        Me.edit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.Image = CType(resources.GetObject("edit.Image"), System.Drawing.Image)
        Me.edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit.Location = New System.Drawing.Point(474, 498)
        Me.edit.Name = "edit"
        Me.edit.Size = New System.Drawing.Size(115, 48)
        Me.edit.TabIndex = 9
        Me.edit.Text = "Update"
        Me.edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.edit.UseVisualStyleBackColor = True
        '
        'lihat
        '
        Me.lihat.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lihat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lihat.Image = CType(resources.GetObject("lihat.Image"), System.Drawing.Image)
        Me.lihat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lihat.Location = New System.Drawing.Point(726, 498)
        Me.lihat.Name = "lihat"
        Me.lihat.Size = New System.Drawing.Size(123, 48)
        Me.lihat.TabIndex = 10
        Me.lihat.Text = "Refresh"
        Me.lihat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lihat.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(224, 326)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 303)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Nama Suplier"
        '
        'txtcari
        '
        Me.txtcari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcari.Location = New System.Drawing.Point(418, 9)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(433, 26)
        Me.txtcari.TabIndex = 15
        '
        'berdasarkan
        '
        Me.berdasarkan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.berdasarkan.FormattingEnabled = True
        Me.berdasarkan.Items.AddRange(New Object() {"Nama Barang", "Harga Jual", "Harga Beli", "Stok Barang"})
        Me.berdasarkan.Location = New System.Drawing.Point(247, 8)
        Me.berdasarkan.Name = "berdasarkan"
        Me.berdasarkan.Size = New System.Drawing.Size(123, 28)
        Me.berdasarkan.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(229, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Pencarian Barang berdasarkan"
        '
        'nm_suplier
        '
        Me.nm_suplier.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.nm_suplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.nm_suplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm_suplier.FormattingEnabled = True
        Me.nm_suplier.Location = New System.Drawing.Point(117, 295)
        Me.nm_suplier.Name = "nm_suplier"
        Me.nm_suplier.Size = New System.Drawing.Size(207, 28)
        Me.nm_suplier.TabIndex = 18
        '
        'syarat
        '
        Me.syarat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.syarat.FormattingEnabled = True
        Me.syarat.Items.AddRange(New Object() {"<", ">", "=", "<=", ">="})
        Me.syarat.Location = New System.Drawing.Point(376, 7)
        Me.syarat.Name = "syarat"
        Me.syarat.Size = New System.Drawing.Size(36, 28)
        Me.syarat.TabIndex = 19
        '
        'txthargajual
        '
        Me.txthargajual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txthargajual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthargajual.Location = New System.Drawing.Point(117, 431)
        Me.txthargajual.Name = "txthargajual"
        Me.txthargajual.Size = New System.Drawing.Size(207, 26)
        Me.txthargajual.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 437)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Harga Jual"
        '
        'satuanbox
        '
        Me.satuanbox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.satuanbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.satuanbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.satuanbox.FormattingEnabled = True
        Me.satuanbox.Location = New System.Drawing.Point(117, 518)
        Me.satuanbox.Name = "satuanbox"
        Me.satuanbox.Size = New System.Drawing.Size(207, 28)
        Me.satuanbox.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 526)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Satuan"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(344, 296)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(505, 183)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'barang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 561)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.satuanbox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txthargajual)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.syarat)
        Me.Controls.Add(Me.nm_suplier)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.berdasarkan)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lihat)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.hapus)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.txtstok)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txthargabeli)
        Me.Controls.Add(Me.txtnama)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "barang"
        Me.Text = "Manajemen Barang"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnama As System.Windows.Forms.TextBox
    Friend WithEvents txthargabeli As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtstok As System.Windows.Forms.TextBox
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents hapus As System.Windows.Forms.Button
    Friend WithEvents edit As System.Windows.Forms.Button
    Friend WithEvents lihat As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents berdasarkan As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nm_suplier As System.Windows.Forms.ComboBox
    Friend WithEvents syarat As System.Windows.Forms.ComboBox
    Friend WithEvents txthargajual As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents satuanbox As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
