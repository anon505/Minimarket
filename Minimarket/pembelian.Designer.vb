<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pembelian
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.textTanggal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.textNoFaktur = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboPembayaran = New System.Windows.Forms.ComboBox()
        Me.textTempoHari = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.labelSupplier = New System.Windows.Forms.Label()
        Me.textJatuhTempo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.buttonNew = New System.Windows.Forms.Button()
        Me.textPpn = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.textDiscount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.textTotal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.buttonDelete = New System.Windows.Forms.Button()
        Me.buttonFind = New System.Windows.Forms.Button()
        Me.labelIdSuplier = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textSupplier = New System.Windows.Forms.TextBox()
        Me.btnEditFaktor = New System.Windows.Forms.Button()
        Me.textPLU = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridView1.ColumnHeadersHeight = 30
        Me.dataGridView1.Location = New System.Drawing.Point(17, 164)
        Me.dataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.dataGridView1.Name = "dataGridView1"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dataGridView1.RowHeadersWidth = 51
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dataGridView1.Size = New System.Drawing.Size(1404, 391)
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
        Me.Label4.Location = New System.Drawing.Point(1029, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 25)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Jenis Pembayaran"
        '
        'comboPembayaran
        '
        Me.comboPembayaran.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboPembayaran.FormattingEnabled = True
        Me.comboPembayaran.Items.AddRange(New Object() {"Tunai", "Kredit", "Konsinyasi"})
        Me.comboPembayaran.Location = New System.Drawing.Point(1221, 9)
        Me.comboPembayaran.Name = "comboPembayaran"
        Me.comboPembayaran.Size = New System.Drawing.Size(204, 33)
        Me.comboPembayaran.TabIndex = 63
        '
        'textTempoHari
        '
        Me.textTempoHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTempoHari.Location = New System.Drawing.Point(1221, 61)
        Me.textTempoHari.Name = "textTempoHari"
        Me.textTempoHari.Size = New System.Drawing.Size(204, 30)
        Me.textTempoHari.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1085, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 25)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Tempo(hari)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelSupplier
        '
        Me.labelSupplier.AutoSize = True
        Me.labelSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelSupplier.Location = New System.Drawing.Point(262, 112)
        Me.labelSupplier.Name = "labelSupplier"
        Me.labelSupplier.Size = New System.Drawing.Size(0, 25)
        Me.labelSupplier.TabIndex = 66
        '
        'textJatuhTempo
        '
        Me.textJatuhTempo.Enabled = False
        Me.textJatuhTempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textJatuhTempo.Location = New System.Drawing.Point(1220, 112)
        Me.textJatuhTempo.Name = "textJatuhTempo"
        Me.textJatuhTempo.ReadOnly = True
        Me.textJatuhTempo.Size = New System.Drawing.Size(205, 30)
        Me.textJatuhTempo.TabIndex = 68
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(998, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(205, 25)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Tanggal Jatuh Tempo"
        '
        'buttonNew
        '
        Me.buttonNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonNew.Location = New System.Drawing.Point(15, 682)
        Me.buttonNew.Name = "buttonNew"
        Me.buttonNew.Size = New System.Drawing.Size(348, 42)
        Me.buttonNew.TabIndex = 69
        Me.buttonNew.Text = "Faktur Baru"
        Me.buttonNew.UseVisualStyleBackColor = True
        '
        'textPpn
        '
        Me.textPpn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPpn.Location = New System.Drawing.Point(1220, 574)
        Me.textPpn.Name = "textPpn"
        Me.textPpn.Size = New System.Drawing.Size(204, 30)
        Me.textPpn.TabIndex = 71
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1124, 579)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 25)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "PPn(%)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'textDiscount
        '
        Me.textDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDiscount.Location = New System.Drawing.Point(175, 624)
        Me.textDiscount.Name = "textDiscount"
        Me.textDiscount.Size = New System.Drawing.Size(204, 30)
        Me.textDiscount.TabIndex = 73
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 629)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 25)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Discount(%)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'textTotal
        '
        Me.textTotal.Enabled = False
        Me.textTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTotal.Location = New System.Drawing.Point(1219, 624)
        Me.textTotal.Name = "textTotal"
        Me.textTotal.ReadOnly = True
        Me.textTotal.Size = New System.Drawing.Size(205, 30)
        Me.textTotal.TabIndex = 75
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1090, 627)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 25)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Grand Total"
        '
        'buttonSave
        '
        Me.buttonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(369, 682)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(348, 42)
        Me.buttonSave.TabIndex = 76
        Me.buttonSave.Text = "Simpan"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'buttonDelete
        '
        Me.buttonDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonDelete.Location = New System.Drawing.Point(722, 682)
        Me.buttonDelete.Name = "buttonDelete"
        Me.buttonDelete.Size = New System.Drawing.Size(348, 42)
        Me.buttonDelete.TabIndex = 77
        Me.buttonDelete.Text = "Hapus"
        Me.buttonDelete.UseVisualStyleBackColor = True
        '
        'buttonFind
        '
        Me.buttonFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonFind.Location = New System.Drawing.Point(1076, 682)
        Me.buttonFind.Name = "buttonFind"
        Me.buttonFind.Size = New System.Drawing.Size(348, 42)
        Me.buttonFind.TabIndex = 78
        Me.buttonFind.Text = "Cari"
        Me.buttonFind.UseVisualStyleBackColor = True
        '
        'labelIdSuplier
        '
        Me.labelIdSuplier.AutoSize = True
        Me.labelIdSuplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelIdSuplier.Location = New System.Drawing.Point(447, 112)
        Me.labelIdSuplier.Name = "labelIdSuplier"
        Me.labelIdSuplier.Size = New System.Drawing.Size(0, 25)
        Me.labelIdSuplier.TabIndex = 84
        Me.labelIdSuplier.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 25)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Supplier"
        '
        'textSupplier
        '
        Me.textSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textSupplier.Location = New System.Drawing.Point(170, 109)
        Me.textSupplier.Name = "textSupplier"
        Me.textSupplier.Size = New System.Drawing.Size(86, 30)
        Me.textSupplier.TabIndex = 61
        '
        'btnEditFaktor
        '
        Me.btnEditFaktor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditFaktor.Location = New System.Drawing.Point(372, 56)
        Me.btnEditFaktor.Name = "btnEditFaktor"
        Me.btnEditFaktor.Size = New System.Drawing.Size(120, 33)
        Me.btnEditFaktor.TabIndex = 85
        Me.btnEditFaktor.Text = "Edit Faktur"
        Me.btnEditFaktor.UseVisualStyleBackColor = True
        '
        'textPLU
        '
        Me.textPLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPLU.Location = New System.Drawing.Point(175, 574)
        Me.textPLU.Name = "textPLU"
        Me.textPLU.Size = New System.Drawing.Size(204, 30)
        Me.textPLU.TabIndex = 86
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 577)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 25)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "PLU"
        '
        'pembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1438, 741)
        Me.Controls.Add(Me.textPLU)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnEditFaktor)
        Me.Controls.Add(Me.labelIdSuplier)
        Me.Controls.Add(Me.buttonFind)
        Me.Controls.Add(Me.buttonDelete)
        Me.Controls.Add(Me.buttonSave)
        Me.Controls.Add(Me.textTotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.textDiscount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.textPpn)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.buttonNew)
        Me.Controls.Add(Me.textJatuhTempo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.labelSupplier)
        Me.Controls.Add(Me.textTempoHari)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.comboPembayaran)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.textSupplier)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textNoFaktur)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.textTanggal)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "pembelian"
        Me.Text = "pembelian"
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
    Friend WithEvents comboPembayaran As ComboBox
    Friend WithEvents textTempoHari As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents labelSupplier As Label
    Friend WithEvents textJatuhTempo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents buttonNew As Button
    Friend WithEvents textPpn As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents textDiscount As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents textTotal As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents buttonSave As Button
    Friend WithEvents buttonDelete As Button
    Friend WithEvents buttonFind As Button
    Friend WithEvents labelIdSuplier As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents textSupplier As TextBox
    Friend WithEvents btnEditFaktor As Button
    Friend WithEvents textPLU As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
