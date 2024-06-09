<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarangSubMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SatuanSubMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KasirSubMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierSubMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MutasiSubMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembelianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanHarianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeuntunganToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KadaluarsaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterMenuItem, Me.MarkupToolStripMenuItem, Me.PembelianToolStripMenuItem, Me.PenjualanToolStripMenuItem, Me.LaporanHarianToolStripMenuItem, Me.ToolStripMenuItem1, Me.LoginToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1341, 31)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterMenuItem
        '
        Me.MasterMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.MasterMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarangSubMenuItem, Me.SatuanSubMenuItem, Me.KasirSubMenuItem, Me.SupplierSubMenuItem, Me.MutasiSubMenuItem})
        Me.MasterMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MasterMenuItem.Image = CType(resources.GetObject("MasterMenuItem.Image"), System.Drawing.Image)
        Me.MasterMenuItem.Name = "MasterMenuItem"
        Me.MasterMenuItem.Size = New System.Drawing.Size(152, 27)
        Me.MasterMenuItem.Text = "Master Data"
        '
        'BarangSubMenuItem
        '
        Me.BarangSubMenuItem.Name = "BarangSubMenuItem"
        Me.BarangSubMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.BarangSubMenuItem.Text = "Barang"
        '
        'SatuanSubMenuItem
        '
        Me.SatuanSubMenuItem.Name = "SatuanSubMenuItem"
        Me.SatuanSubMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.SatuanSubMenuItem.Text = "Satuan"
        '
        'KasirSubMenuItem
        '
        Me.KasirSubMenuItem.Name = "KasirSubMenuItem"
        Me.KasirSubMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.KasirSubMenuItem.Text = "Kasir"
        '
        'SupplierSubMenuItem
        '
        Me.SupplierSubMenuItem.Name = "SupplierSubMenuItem"
        Me.SupplierSubMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.SupplierSubMenuItem.Text = "Supplier"
        '
        'MutasiSubMenuItem
        '
        Me.MutasiSubMenuItem.Name = "MutasiSubMenuItem"
        Me.MutasiSubMenuItem.Size = New System.Drawing.Size(151, 28)
        Me.MutasiSubMenuItem.Text = "Mutasi"
        '
        'MarkupToolStripMenuItem
        '
        Me.MarkupToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarkupToolStripMenuItem.Image = CType(resources.GetObject("MarkupToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MarkupToolStripMenuItem.Name = "MarkupToolStripMenuItem"
        Me.MarkupToolStripMenuItem.Size = New System.Drawing.Size(167, 27)
        Me.MarkupToolStripMenuItem.Text = "Markup Harga"
        '
        'PembelianToolStripMenuItem
        '
        Me.PembelianToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.PembelianToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PembelianToolStripMenuItem.Image = CType(resources.GetObject("PembelianToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PembelianToolStripMenuItem.Name = "PembelianToolStripMenuItem"
        Me.PembelianToolStripMenuItem.Size = New System.Drawing.Size(133, 27)
        Me.PembelianToolStripMenuItem.Text = "Pembelian"
        '
        'PenjualanToolStripMenuItem
        '
        Me.PenjualanToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.PenjualanToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PenjualanToolStripMenuItem.Image = CType(resources.GetObject("PenjualanToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        Me.PenjualanToolStripMenuItem.Size = New System.Drawing.Size(126, 27)
        Me.PenjualanToolStripMenuItem.Text = "Penjualan"
        '
        'LaporanHarianToolStripMenuItem
        '
        Me.LaporanHarianToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.LaporanHarianToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeuntunganToolStripMenuItem, Me.KadaluarsaToolStripMenuItem})
        Me.LaporanHarianToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaporanHarianToolStripMenuItem.Image = CType(resources.GetObject("LaporanHarianToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LaporanHarianToolStripMenuItem.Name = "LaporanHarianToolStripMenuItem"
        Me.LaporanHarianToolStripMenuItem.Size = New System.Drawing.Size(114, 27)
        Me.LaporanHarianToolStripMenuItem.Text = "Laporan"
        '
        'KeuntunganToolStripMenuItem
        '
        Me.KeuntunganToolStripMenuItem.Name = "KeuntunganToolStripMenuItem"
        Me.KeuntunganToolStripMenuItem.Size = New System.Drawing.Size(182, 28)
        Me.KeuntunganToolStripMenuItem.Text = "Keuntungan"
        '
        'KadaluarsaToolStripMenuItem
        '
        Me.KadaluarsaToolStripMenuItem.Name = "KadaluarsaToolStripMenuItem"
        Me.KadaluarsaToolStripMenuItem.Size = New System.Drawing.Size(182, 28)
        Me.KadaluarsaToolStripMenuItem.Text = "Kadaluarsa"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(139, 27)
        Me.ToolStripMenuItem1.Text = "Konfigurasi"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.LoginToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginToolStripMenuItem.Image = CType(resources.GetObject("LoginToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(89, 27)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(136, 27)
        Me.ToolStripMenuItem2.Text = "Cek Harga"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1341, 380)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "main"
        Me.Text = "Minimarket"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MasterMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PembelianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanHarianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeuntunganToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KadaluarsaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarangSubMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SatuanSubMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KasirSubMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierSubMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MutasiSubMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class
