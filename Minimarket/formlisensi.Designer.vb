<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formlisensi
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
        Me.txtidmesin = New System.Windows.Forms.TextBox()
        Me.btnsalin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtkey = New System.Windows.Forms.TextBox()
        Me.lblpetunjuk = New System.Windows.Forms.Label()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.btntutup = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID mesin komputer ini"
        '
        'txtidmesin
        '
        Me.txtidmesin.BackColor = System.Drawing.Color.White
        Me.txtidmesin.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtidmesin.Location = New System.Drawing.Point(19, 36)
        Me.txtidmesin.Name = "txtidmesin"
        Me.txtidmesin.ReadOnly = True
        Me.txtidmesin.Size = New System.Drawing.Size(300, 26)
        Me.txtidmesin.TabIndex = 1
        '
        'btnsalin
        '
        Me.btnsalin.Location = New System.Drawing.Point(325, 36)
        Me.btnsalin.Name = "btnsalin"
        Me.btnsalin.Size = New System.Drawing.Size(90, 26)
        Me.btnsalin.TabIndex = 2
        Me.btnsalin.Text = "Salin ID"
        Me.btnsalin.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Status lisensi"
        '
        'lblstatus
        '
        Me.lblstatus.Location = New System.Drawing.Point(16, 94)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(520, 34)
        Me.lblstatus.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "License key baru"
        '
        'txtkey
        '
        Me.txtkey.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkey.Location = New System.Drawing.Point(19, 152)
        Me.txtkey.Multiline = True
        Me.txtkey.Name = "txtkey"
        Me.txtkey.Size = New System.Drawing.Size(517, 70)
        Me.txtkey.TabIndex = 6
        '
        'lblpetunjuk
        '
        Me.lblpetunjuk.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblpetunjuk.Location = New System.Drawing.Point(16, 228)
        Me.lblpetunjuk.Name = "lblpetunjuk"
        Me.lblpetunjuk.Size = New System.Drawing.Size(520, 30)
        Me.lblpetunjuk.TabIndex = 7
        Me.lblpetunjuk.Text = "Kirim ID mesin di atas ke BetterMoney untuk mendapatkan license key, lalu tempel key di kotak ini dan klik Simpan."
        '
        'btnsimpan
        '
        Me.btnsimpan.Location = New System.Drawing.Point(355, 266)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(90, 28)
        Me.btnsimpan.TabIndex = 8
        Me.btnsimpan.Text = "Simpan"
        Me.btnsimpan.UseVisualStyleBackColor = True
        '
        'btntutup
        '
        Me.btntutup.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btntutup.Location = New System.Drawing.Point(446, 266)
        Me.btntutup.Name = "btntutup"
        Me.btntutup.Size = New System.Drawing.Size(90, 28)
        Me.btntutup.TabIndex = 9
        Me.btntutup.Text = "Tutup"
        Me.btntutup.UseVisualStyleBackColor = True
        '
        'formlisensi
        '
        Me.AcceptButton = Me.btnsimpan
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btntutup
        Me.ClientSize = New System.Drawing.Size(554, 308)
        Me.Controls.Add(Me.btntutup)
        Me.Controls.Add(Me.btnsimpan)
        Me.Controls.Add(Me.lblpetunjuk)
        Me.Controls.Add(Me.txtkey)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblstatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnsalin)
        Me.Controls.Add(Me.txtidmesin)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formlisensi"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisensi System POS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtidmesin As System.Windows.Forms.TextBox
    Friend WithEvents btnsalin As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtkey As System.Windows.Forms.TextBox
    Friend WithEvents lblpetunjuk As System.Windows.Forms.Label
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents btntutup As System.Windows.Forms.Button
End Class
