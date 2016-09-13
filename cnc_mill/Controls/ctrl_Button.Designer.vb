<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Button
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
        Me.Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button
        '
        Me.Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki
        Me.Button.FlatAppearance.BorderSize = 0
        Me.Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button.Location = New System.Drawing.Point(0, 0)
        Me.Button.Name = "Button"
        Me.Button.Size = New System.Drawing.Size(150, 150)
        Me.Button.TabIndex = 0
        Me.Button.UseVisualStyleBackColor = True
        '
        'ctrl_Button
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button)
        Me.Name = "ctrl_Button"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button As System.Windows.Forms.Button

End Class
