<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Gcode_Help
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_Gcode_Help))
        Me.ts_G_Code_Help = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton26 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txt_Help = New System.Windows.Forms.TextBox()
        Me.ts_G_Code_Help.SuspendLayout()
        Me.SuspendLayout()
        '
        'ts_G_Code_Help
        '
        Me.ts_G_Code_Help.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripButton26, Me.ToolStripSeparator2})
        Me.ts_G_Code_Help.Location = New System.Drawing.Point(0, 0)
        Me.ts_G_Code_Help.Name = "ts_G_Code_Help"
        Me.ts_G_Code_Help.Size = New System.Drawing.Size(150, 38)
        Me.ts_G_Code_Help.TabIndex = 110
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(32, 35)
        Me.ToolStripLabel2.Text = "Help"
        '
        'ToolStripButton26
        '
        Me.ToolStripButton26.Image = CType(resources.GetObject("ToolStripButton26.Image"), System.Drawing.Image)
        Me.ToolStripButton26.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton26.Name = "ToolStripButton26"
        Me.ToolStripButton26.Size = New System.Drawing.Size(36, 35)
        Me.ToolStripButton26.Text = "Help"
        Me.ToolStripButton26.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'txt_Help
        '
        Me.txt_Help.BackColor = System.Drawing.Color.White
        Me.txt_Help.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_Help.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Help.Location = New System.Drawing.Point(0, 38)
        Me.txt_Help.Multiline = True
        Me.txt_Help.Name = "txt_Help"
        Me.txt_Help.ReadOnly = True
        Me.txt_Help.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_Help.Size = New System.Drawing.Size(150, 304)
        Me.txt_Help.TabIndex = 111
        Me.txt_Help.WordWrap = False
        '
        'ctrl_Gcode_Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.txt_Help)
        Me.Controls.Add(Me.ts_G_Code_Help)
        Me.Name = "ctrl_Gcode_Help"
        Me.Size = New System.Drawing.Size(150, 342)
        Me.ts_G_Code_Help.ResumeLayout(False)
        Me.ts_G_Code_Help.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ts_G_Code_Help As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton26 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txt_Help As System.Windows.Forms.TextBox

End Class
