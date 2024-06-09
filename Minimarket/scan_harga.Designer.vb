<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scan_harga
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.lblNamaBarang = New System.Windows.Forms.Label()
        Me.lblStok = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCaption1 = New System.Windows.Forms.Label()
        Me.lblCaption2 = New System.Windows.Forms.Label()
        Me.lblCaption3 = New System.Windows.Forms.Label()
        Me.lblCaption4 = New System.Windows.Forms.Label()
        Me.lblPrice1 = New System.Windows.Forms.Label()
        Me.lblPrice2 = New System.Windows.Forms.Label()
        Me.lblPrice3 = New System.Windows.Forms.Label()
        Me.lblPrice4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(127, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1127, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selamat Berbelanja...,, Di Wildan Barokah"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblBarcode, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNamaBarang, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStok, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(-3, 659)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1399, 91)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblBarcode
        '
        Me.lblBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarcode.Location = New System.Drawing.Point(3, 0)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(343, 91)
        Me.lblBarcode.TabIndex = 0
        Me.lblBarcode.Text = "###"
        Me.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNamaBarang
        '
        Me.lblNamaBarang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNamaBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaBarang.Location = New System.Drawing.Point(352, 0)
        Me.lblNamaBarang.Name = "lblNamaBarang"
        Me.lblNamaBarang.Size = New System.Drawing.Size(693, 91)
        Me.lblNamaBarang.TabIndex = 1
        Me.lblNamaBarang.Text = "###"
        Me.lblNamaBarang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStok
        '
        Me.lblStok.AutoSize = True
        Me.lblStok.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStok.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStok.Location = New System.Drawing.Point(1051, 0)
        Me.lblStok.Name = "lblStok"
        Me.lblStok.Size = New System.Drawing.Size(345, 91)
        Me.lblStok.TabIndex = 2
        Me.lblStok.Text = "###"
        Me.lblStok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblCaption1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCaption2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCaption3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCaption4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPrice1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPrice2, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPrice3, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPrice4, 1, 3)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 77)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1390, 560)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'lblCaption1
        '
        Me.lblCaption1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption1.Location = New System.Drawing.Point(3, 0)
        Me.lblCaption1.Name = "lblCaption1"
        Me.lblCaption1.Size = New System.Drawing.Size(550, 140)
        Me.lblCaption1.TabIndex = 0
        Me.lblCaption1.Text = "## ="
        Me.lblCaption1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaption2
        '
        Me.lblCaption2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCaption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption2.Location = New System.Drawing.Point(3, 140)
        Me.lblCaption2.Name = "lblCaption2"
        Me.lblCaption2.Size = New System.Drawing.Size(550, 140)
        Me.lblCaption2.TabIndex = 1
        Me.lblCaption2.Text = "## ="
        Me.lblCaption2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaption3
        '
        Me.lblCaption3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCaption3.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption3.Location = New System.Drawing.Point(3, 280)
        Me.lblCaption3.Name = "lblCaption3"
        Me.lblCaption3.Size = New System.Drawing.Size(550, 140)
        Me.lblCaption3.TabIndex = 2
        Me.lblCaption3.Text = "## ="
        Me.lblCaption3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaption4
        '
        Me.lblCaption4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCaption4.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption4.Location = New System.Drawing.Point(3, 420)
        Me.lblCaption4.Name = "lblCaption4"
        Me.lblCaption4.Size = New System.Drawing.Size(550, 140)
        Me.lblCaption4.TabIndex = 3
        Me.lblCaption4.Text = "## ="
        Me.lblCaption4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrice1
        '
        Me.lblPrice1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPrice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice1.Location = New System.Drawing.Point(559, 0)
        Me.lblPrice1.Name = "lblPrice1"
        Me.lblPrice1.Size = New System.Drawing.Size(828, 140)
        Me.lblPrice1.TabIndex = 4
        Me.lblPrice1.Text = "###"
        Me.lblPrice1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrice2
        '
        Me.lblPrice2.AutoSize = True
        Me.lblPrice2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPrice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice2.Location = New System.Drawing.Point(559, 140)
        Me.lblPrice2.Name = "lblPrice2"
        Me.lblPrice2.Size = New System.Drawing.Size(828, 140)
        Me.lblPrice2.TabIndex = 5
        Me.lblPrice2.Text = "###"
        Me.lblPrice2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrice3
        '
        Me.lblPrice3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPrice3.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice3.Location = New System.Drawing.Point(559, 280)
        Me.lblPrice3.Name = "lblPrice3"
        Me.lblPrice3.Size = New System.Drawing.Size(828, 140)
        Me.lblPrice3.TabIndex = 6
        Me.lblPrice3.Text = "###"
        Me.lblPrice3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrice4
        '
        Me.lblPrice4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPrice4.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice4.Location = New System.Drawing.Point(559, 420)
        Me.lblPrice4.Name = "lblPrice4"
        Me.lblPrice4.Size = New System.Drawing.Size(828, 140)
        Me.lblPrice4.TabIndex = 7
        Me.lblPrice4.Text = "###"
        Me.lblPrice4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Aqua
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBox1.ForeColor = System.Drawing.Color.Aqua
        Me.TextBox1.Location = New System.Drawing.Point(878, -5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 15)
        Me.TextBox1.TabIndex = 1
        '
        'scan_harga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cyan
        Me.ClientSize = New System.Drawing.Size(1396, 745)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "scan_harga"
        Me.Text = "Cek Harga"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBarcode As System.Windows.Forms.Label
    Friend WithEvents lblNamaBarang As System.Windows.Forms.Label
    Friend WithEvents lblStok As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCaption1 As System.Windows.Forms.Label
    Friend WithEvents lblCaption2 As System.Windows.Forms.Label
    Friend WithEvents lblCaption3 As System.Windows.Forms.Label
    Friend WithEvents lblCaption4 As System.Windows.Forms.Label
    Friend WithEvents lblPrice1 As System.Windows.Forms.Label
    Friend WithEvents lblPrice2 As System.Windows.Forms.Label
    Friend WithEvents lblPrice3 As System.Windows.Forms.Label
    Friend WithEvents lblPrice4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
