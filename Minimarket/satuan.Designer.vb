<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class satuan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(satuan))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtnama = New System.Windows.Forms.TextBox()
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
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(279, 20)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Ketikkan Nama Satuan yang anda cari"
        '
        'txtcari
        '
        Me.txtcari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcari.Location = New System.Drawing.Point(297, 6)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(220, 26)
        Me.txtcari.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(118, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'txtnama
        '
        Me.txtnama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnama.Location = New System.Drawing.Point(122, 296)
        Me.txtnama.Name = "txtnama"
        Me.txtnama.Size = New System.Drawing.Size(169, 26)
        Me.txtnama.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Nama Satuan"
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 44)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(505, 246)
        Me.DataGridView1.TabIndex = 19
        '
        'lihat
        '
        Me.lihat.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lihat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lihat.Image = CType(resources.GetObject("lihat.Image"), System.Drawing.Image)
        Me.lihat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lihat.Location = New System.Drawing.Point(166, 392)
        Me.lihat.Name = "lihat"
        Me.lihat.Size = New System.Drawing.Size(125, 48)
        Me.lihat.TabIndex = 33
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
        Me.edit.Location = New System.Drawing.Point(166, 335)
        Me.edit.Name = "edit"
        Me.edit.Size = New System.Drawing.Size(125, 48)
        Me.edit.TabIndex = 32
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
        Me.hapus.Location = New System.Drawing.Point(12, 392)
        Me.hapus.Name = "hapus"
        Me.hapus.Size = New System.Drawing.Size(115, 48)
        Me.hapus.TabIndex = 31
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
        Me.tambah.Location = New System.Drawing.Point(12, 335)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(117, 48)
        Me.tambah.TabIndex = 30
        Me.tambah.Text = "Tambah"
        Me.tambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tambah.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(308, 298)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(209, 140)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'satuan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 448)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lihat)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.hapus)
        Me.Controls.Add(Me.tambah)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtcari)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtnama)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "satuan"
        Me.Text = "satuan"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtnama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lihat As System.Windows.Forms.Button
    Friend WithEvents edit As System.Windows.Forms.Button
    Friend WithEvents hapus As System.Windows.Forms.Button
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
