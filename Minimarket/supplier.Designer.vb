<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class supplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(supplier))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.berdasarkan = New System.Windows.Forms.ComboBox()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtstok = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.txtnama = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lihat = New System.Windows.Forms.Button()
        Me.edit = New System.Windows.Forms.Button()
        Me.hapus = New System.Windows.Forms.Button()
        Me.tambah = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(235, 20)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Pencarian Supplier berdasarkan"
        '
        'berdasarkan
        '
        Me.berdasarkan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.berdasarkan.FormattingEnabled = True
        Me.berdasarkan.Items.AddRange(New Object() {"ID Supplier", "Nama Supplier", "Alamat Supplier"})
        Me.berdasarkan.Location = New System.Drawing.Point(253, 6)
        Me.berdasarkan.Name = "berdasarkan"
        Me.berdasarkan.Size = New System.Drawing.Size(134, 28)
        Me.berdasarkan.TabIndex = 34
        '
        'txtcari
        '
        Me.txtcari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcari.Location = New System.Drawing.Point(393, 6)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(177, 26)
        Me.txtcari.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 417)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'txtstok
        '
        Me.txtstok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstok.Location = New System.Drawing.Point(132, 386)
        Me.txtstok.Name = "txtstok"
        Me.txtstok.Size = New System.Drawing.Size(168, 26)
        Me.txtstok.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 392)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 20)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Contact Person"
        '
        'txtharga
        '
        Me.txtharga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtharga.Location = New System.Drawing.Point(132, 337)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(168, 26)
        Me.txtharga.TabIndex = 24
        '
        'txtnama
        '
        Me.txtnama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnama.Location = New System.Drawing.Point(132, 287)
        Me.txtnama.Name = "txtnama"
        Me.txtnama.Size = New System.Drawing.Size(168, 26)
        Me.txtnama.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 341)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Alamat Supplier"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 293)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Nama Supplier"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 43)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(558, 233)
        Me.DataGridView1.TabIndex = 20
        '
        'lihat
        '
        Me.lihat.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lihat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lihat.Image = CType(resources.GetObject("lihat.Image"), System.Drawing.Image)
        Me.lihat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lihat.Location = New System.Drawing.Point(447, 433)
        Me.lihat.Name = "lihat"
        Me.lihat.Size = New System.Drawing.Size(123, 48)
        Me.lihat.TabIndex = 39
        Me.lihat.Text = "Refresh"
        Me.lihat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lihat.UseVisualStyleBackColor = True
        '
        'edit
        '
        Me.edit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.Image = CType(resources.GetObject("edit.Image"), System.Drawing.Image)
        Me.edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit.Location = New System.Drawing.Point(157, 433)
        Me.edit.Name = "edit"
        Me.edit.Size = New System.Drawing.Size(115, 48)
        Me.edit.TabIndex = 38
        Me.edit.Text = "Update"
        Me.edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.edit.UseVisualStyleBackColor = True
        '
        'hapus
        '
        Me.hapus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.hapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hapus.Image = CType(resources.GetObject("hapus.Image"), System.Drawing.Image)
        Me.hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.hapus.Location = New System.Drawing.Point(302, 433)
        Me.hapus.Name = "hapus"
        Me.hapus.Size = New System.Drawing.Size(115, 48)
        Me.hapus.TabIndex = 37
        Me.hapus.Text = "Hapus"
        Me.hapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.hapus.UseVisualStyleBackColor = True
        '
        'tambah
        '
        Me.tambah.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tambah.Image = CType(resources.GetObject("tambah.Image"), System.Drawing.Image)
        Me.tambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tambah.Location = New System.Drawing.Point(10, 433)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(117, 48)
        Me.tambah.TabIndex = 36
        Me.tambah.Text = "Tambah"
        Me.tambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tambah.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(306, 287)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(264, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'supplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 488)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lihat)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.hapus)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.berdasarkan)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtstok)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtharga)
        Me.Controls.Add(Me.txtnama)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "supplier"
        Me.Text = "Manajemen Supplier"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents berdasarkan As System.Windows.Forms.ComboBox
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtstok As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents txtnama As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lihat As System.Windows.Forms.Button
    Friend WithEvents edit As System.Windows.Forms.Button
    Friend WithEvents hapus As System.Windows.Forms.Button
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
