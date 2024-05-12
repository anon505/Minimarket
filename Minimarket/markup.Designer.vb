<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class markup
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.textTanggal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.textNoFaktur = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textNamaSuplier = New System.Windows.Forms.TextBox()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.buttonDelete = New System.Windows.Forms.Button()
        Me.buttonFind = New System.Windows.Forms.Button()
        Me.textKodeSuplier = New System.Windows.Forms.TextBox()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'textTanggal
        '
        Me.textTanggal.Enabled = False
        Me.textTanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTanggal.Location = New System.Drawing.Point(170, 9)
        Me.textTanggal.Name = "textTanggal"
        Me.textTanggal.ReadOnly = True
        Me.textTanggal.Size = New System.Drawing.Size(195, 30)
        Me.textTanggal.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 25)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Tanggal Faktur"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dataGridView1.ColumnHeadersHeight = 30
        Me.dataGridView1.Location = New System.Drawing.Point(17, 112)
        Me.dataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridView1.Name = "dataGridView1"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dataGridView1.RowHeadersWidth = 51
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dataGridView1.Size = New System.Drawing.Size(1404, 554)
        Me.dataGridView1.TabIndex = 57
        '
        'textNoFaktur
        '
        Me.textNoFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNoFaktur.Location = New System.Drawing.Point(170, 58)
        Me.textNoFaktur.Name = "textNoFaktur"
        Me.textNoFaktur.Size = New System.Drawing.Size(195, 30)
        Me.textNoFaktur.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 25)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Nomor Faktur"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(935, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 25)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Kode Suplier"
        '
        'textNamaSuplier
        '
        Me.textNamaSuplier.Enabled = False
        Me.textNamaSuplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNamaSuplier.Location = New System.Drawing.Point(1216, 12)
        Me.textNamaSuplier.Name = "textNamaSuplier"
        Me.textNamaSuplier.ReadOnly = True
        Me.textNamaSuplier.Size = New System.Drawing.Size(205, 30)
        Me.textNamaSuplier.TabIndex = 68
        '
        'buttonSave
        '
        Me.buttonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(18, 682)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(454, 42)
        Me.buttonSave.TabIndex = 76
        Me.buttonSave.Text = "Simpan"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'buttonDelete
        '
        Me.buttonDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonDelete.Location = New System.Drawing.Point(494, 682)
        Me.buttonDelete.Name = "buttonDelete"
        Me.buttonDelete.Size = New System.Drawing.Size(454, 42)
        Me.buttonDelete.TabIndex = 77
        Me.buttonDelete.Text = "Hapus"
        Me.buttonDelete.UseVisualStyleBackColor = True
        '
        'buttonFind
        '
        Me.buttonFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonFind.Location = New System.Drawing.Point(970, 682)
        Me.buttonFind.Name = "buttonFind"
        Me.buttonFind.Size = New System.Drawing.Size(454, 42)
        Me.buttonFind.TabIndex = 78
        Me.buttonFind.Text = "Cari"
        Me.buttonFind.UseVisualStyleBackColor = True
        '
        'textKodeSuplier
        '
        Me.textKodeSuplier.Enabled = False
        Me.textKodeSuplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textKodeSuplier.Location = New System.Drawing.Point(1066, 14)
        Me.textKodeSuplier.Name = "textKodeSuplier"
        Me.textKodeSuplier.ReadOnly = True
        Me.textKodeSuplier.Size = New System.Drawing.Size(137, 30)
        Me.textKodeSuplier.TabIndex = 79
        '
        'markup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1438, 741)
        Me.Controls.Add(Me.textKodeSuplier)
        Me.Controls.Add(Me.buttonFind)
        Me.Controls.Add(Me.buttonDelete)
        Me.Controls.Add(Me.buttonSave)
        Me.Controls.Add(Me.textNamaSuplier)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.textNoFaktur)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.textTanggal)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "markup"
        Me.Text = "markup"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textTanggal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dataGridView1 As DataGridView
    Friend WithEvents textNoFaktur As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents textNamaSuplier As TextBox
    Friend WithEvents buttonSave As Button
    Friend WithEvents buttonDelete As Button
    Friend WithEvents buttonFind As Button
    Friend WithEvents textKodeSuplier As TextBox
End Class
