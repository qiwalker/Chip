<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Process
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
        Me.Split = New System.Windows.Forms.Splitter()
        Me.tab_Drawing = New System.Windows.Forms.TabControl()
        Me.tab_Gcode = New System.Windows.Forms.TabControl()
        Me.SuspendLayout()
        '
        'Split
        '
        Me.Split.BackColor = System.Drawing.Color.Firebrick
        Me.Split.Location = New System.Drawing.Point(278, 0)
        Me.Split.Name = "Split"
        Me.Split.Size = New System.Drawing.Size(3, 561)
        Me.Split.TabIndex = 1
        Me.Split.TabStop = False
        '
        'tab_Drawing
        '
        Me.tab_Drawing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_Drawing.Location = New System.Drawing.Point(281, 0)
        Me.tab_Drawing.Name = "tab_Drawing"
        Me.tab_Drawing.SelectedIndex = 0
        Me.tab_Drawing.Size = New System.Drawing.Size(792, 561)
        Me.tab_Drawing.TabIndex = 3
        '
        'tab_Gcode
        '
        Me.tab_Gcode.Dock = System.Windows.Forms.DockStyle.Left
        Me.tab_Gcode.Location = New System.Drawing.Point(0, 0)
        Me.tab_Gcode.Name = "tab_Gcode"
        Me.tab_Gcode.SelectedIndex = 0
        Me.tab_Gcode.Size = New System.Drawing.Size(278, 561)
        Me.tab_Gcode.TabIndex = 0
        '
        'ctrl_Process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tab_Drawing)
        Me.Controls.Add(Me.Split)
        Me.Controls.Add(Me.tab_Gcode)
        Me.Name = "ctrl_Process"
        Me.Size = New System.Drawing.Size(1073, 561)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Split As System.Windows.Forms.Splitter
    Friend WithEvents tab_Drawing As System.Windows.Forms.TabControl
    Friend WithEvents tab_Gcode As System.Windows.Forms.TabControl

End Class
