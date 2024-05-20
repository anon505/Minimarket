<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formnota
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        'Me.Minimarketds = New Minimarket.minimarketds()
        'Me.NotaTableAdapter = New Minimarket.minimarketdsTableAdapters.notaTableAdapter()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.NotaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        'CType(Me.Minimarketds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Minimarketds
        '
        'Me.Minimarketds.DataSetName = "minimarketds"
        'Me.Minimarketds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.BackColor = System.Drawing.SystemColors.Control
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.NotaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(396, 371)
        Me.ReportViewer1.TabIndex = 0
        '
        'NotaTableAdapter
        '
        'Me.NotaTableAdapter.ClearBeforeFill = True
        '
        'NotaBindingSource
        '
        Me.NotaBindingSource.DataMember = "nota"
        'Me.NotaBindingSource.DataSource = Me.Minimarketds
        '
        'formnota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 394)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "formnota"
        Me.Text = "formnota"
        'CType(Me.Minimarketds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    'Friend WithEvents Minimarketds As Minimarket.minimarketds
    'Friend WithEvents NotaTableAdapter As Minimarket.minimarketdsTableAdapters.notaTableAdapter
    Friend WithEvents NotaBindingSource As System.Windows.Forms.BindingSource
End Class
