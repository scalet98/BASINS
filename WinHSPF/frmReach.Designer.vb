<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReach
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.grdReach = New atcControls.atcGrid
        Me.AtcGridBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HspfFtableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FTables = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        CType(Me.AtcGridBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HspfFtableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdReach
        '
        Me.grdReach.AllowHorizontalScrolling = True
        Me.grdReach.AllowNewValidValues = False
        Me.grdReach.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdReach.CellBackColor = System.Drawing.Color.Empty
        Me.grdReach.Fixed3D = False
        Me.grdReach.LineColor = System.Drawing.Color.Empty
        Me.grdReach.LineWidth = 0.0!
        Me.grdReach.Location = New System.Drawing.Point(6, 3)
        Me.grdReach.Margin = New System.Windows.Forms.Padding(2)
        Me.grdReach.Name = "grdReach"
        Me.grdReach.Size = New System.Drawing.Size(561, 230)
        Me.grdReach.Source = Nothing
        Me.grdReach.TabIndex = 0
        '
        'AtcGridBindingSource
        '
        Me.AtcGridBindingSource.DataSource = GetType(atcControls.atcGrid)
        '
        'HspfFtableBindingSource
        '
        Me.HspfFtableBindingSource.DataSource = GetType(atcUCI.HspfFtable)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Tag"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tag"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'FTables
        '
        Me.FTables.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FTables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FTables.Location = New System.Drawing.Point(462, 248)
        Me.FTables.Name = "FTables"
        Me.FTables.Size = New System.Drawing.Size(101, 26)
        Me.FTables.TabIndex = 3
        Me.FTables.Text = "FTables"
        Me.FTables.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(290, 248)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(101, 26)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Location = New System.Drawing.Point(181, 248)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(101, 26)
        Me.cmdOK.TabIndex = 19
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmReach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 292)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.FTables)
        Me.Controls.Add(Me.grdReach)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmReach"
        Me.Text = "WinHSPF - Reach Editor"
        CType(Me.AtcGridBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HspfFtableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdReach As atcControls.atcGrid
    Friend WithEvents AtcGridBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HspfFtableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FTables As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
