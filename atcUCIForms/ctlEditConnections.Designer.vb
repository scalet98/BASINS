<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlEditConnections
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtDefine = New System.Windows.Forms.TextBox
        Me.grdEdit = New atcControls.atcGrid
        Me.SuspendLayout()
        '
        'txtDefine
        '
        Me.txtDefine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDefine.BackColor = System.Drawing.SystemColors.Control
        Me.txtDefine.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDefine.Location = New System.Drawing.Point(11, 257)
        Me.txtDefine.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDefine.Multiline = True
        Me.txtDefine.Name = "txtDefine"
        Me.txtDefine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDefine.Size = New System.Drawing.Size(702, 96)
        Me.txtDefine.TabIndex = 1
        '
        'grdEdit
        '
        Me.grdEdit.AllowHorizontalScrolling = True
        Me.grdEdit.AllowNewValidValues = False
        Me.grdEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEdit.CellBackColor = System.Drawing.Color.Empty
        Me.grdEdit.Fixed3D = False
        Me.grdEdit.LineColor = System.Drawing.Color.Empty
        Me.grdEdit.LineWidth = 0.0!
        Me.grdEdit.Location = New System.Drawing.Point(12, 2)
        Me.grdEdit.Margin = New System.Windows.Forms.Padding(5)
        Me.grdEdit.Name = "grdEdit"
        Me.grdEdit.Size = New System.Drawing.Size(700, 238)
        Me.grdEdit.Source = Nothing
        Me.grdEdit.TabIndex = 0
        '
        'ctlEditConnections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtDefine)
        Me.Controls.Add(Me.grdEdit)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ctlEditConnections"
        Me.Size = New System.Drawing.Size(725, 358)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdEdit As atcControls.atcGrid
    Friend WithEvents txtDefine As System.Windows.Forms.TextBox

End Class
