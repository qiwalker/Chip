<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Basic
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
        Me.Check_Box = New System.Windows.Forms.CheckBox()
        Me.Text_Box = New System.Windows.Forms.TextBox()
        Me.Slider = New System.Windows.Forms.TrackBar()
        Me.Combo_Box = New System.Windows.Forms.ComboBox()
        Me.Label_Box = New System.Windows.Forms.Label()
        Me.Image_Box = New System.Windows.Forms.PictureBox()
        Me.List_Box = New System.Windows.Forms.ListBox()
        CType(Me.Slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image_Box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button
        '
        Me.Button.BackColor = System.Drawing.SystemColors.Control
        Me.Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button.ForeColor = System.Drawing.Color.Black
        Me.Button.Location = New System.Drawing.Point(160, 62)
        Me.Button.Name = "Button"
        Me.Button.Size = New System.Drawing.Size(120, 47)
        Me.Button.TabIndex = 0
        Me.Button.Text = "Button"
        Me.Button.UseVisualStyleBackColor = False
        '
        'Check_Box
        '
        Me.Check_Box.AutoSize = True
        Me.Check_Box.BackColor = System.Drawing.Color.Silver
        Me.Check_Box.ForeColor = System.Drawing.Color.Black
        Me.Check_Box.Location = New System.Drawing.Point(160, 11)
        Me.Check_Box.Name = "Check_Box"
        Me.Check_Box.Size = New System.Drawing.Size(75, 17)
        Me.Check_Box.TabIndex = 1
        Me.Check_Box.Text = "CheckBox"
        Me.Check_Box.UseVisualStyleBackColor = False
        '
        'Text_Box
        '
        Me.Text_Box.BackColor = System.Drawing.Color.White
        Me.Text_Box.ForeColor = System.Drawing.Color.Black
        Me.Text_Box.Location = New System.Drawing.Point(21, 36)
        Me.Text_Box.Multiline = True
        Me.Text_Box.Name = "Text_Box"
        Me.Text_Box.Size = New System.Drawing.Size(100, 20)
        Me.Text_Box.TabIndex = 2
        '
        'Slider
        '
        Me.Slider.Location = New System.Drawing.Point(160, 117)
        Me.Slider.Name = "Slider"
        Me.Slider.Size = New System.Drawing.Size(104, 45)
        Me.Slider.TabIndex = 3
        '
        'Combo_Box
        '
        Me.Combo_Box.BackColor = System.Drawing.Color.White
        Me.Combo_Box.ForeColor = System.Drawing.Color.Black
        Me.Combo_Box.FormattingEnabled = True
        Me.Combo_Box.Location = New System.Drawing.Point(21, 62)
        Me.Combo_Box.Name = "Combo_Box"
        Me.Combo_Box.Size = New System.Drawing.Size(100, 21)
        Me.Combo_Box.TabIndex = 4
        '
        'Label_Box
        '
        Me.Label_Box.AutoSize = True
        Me.Label_Box.BackColor = System.Drawing.Color.White
        Me.Label_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Box.ForeColor = System.Drawing.Color.Black
        Me.Label_Box.Location = New System.Drawing.Point(25, 3)
        Me.Label_Box.Name = "Label_Box"
        Me.Label_Box.Size = New System.Drawing.Size(65, 25)
        Me.Label_Box.TabIndex = 5
        Me.Label_Box.Text = "Label"
        '
        'Image_Box
        '
        Me.Image_Box.BackColor = System.Drawing.Color.Silver
        Me.Image_Box.Location = New System.Drawing.Point(21, 89)
        Me.Image_Box.Name = "Image_Box"
        Me.Image_Box.Size = New System.Drawing.Size(100, 73)
        Me.Image_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Image_Box.TabIndex = 6
        Me.Image_Box.TabStop = False
        '
        'List_Box
        '
        Me.List_Box.BackColor = System.Drawing.Color.White
        Me.List_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List_Box.FormattingEnabled = True
        Me.List_Box.ItemHeight = 16
        Me.List_Box.Location = New System.Drawing.Point(160, 36)
        Me.List_Box.Name = "List_Box"
        Me.List_Box.Size = New System.Drawing.Size(120, 20)
        Me.List_Box.TabIndex = 7
        '
        'ctrl_Basic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.List_Box)
        Me.Controls.Add(Me.Image_Box)
        Me.Controls.Add(Me.Label_Box)
        Me.Controls.Add(Me.Combo_Box)
        Me.Controls.Add(Me.Slider)
        Me.Controls.Add(Me.Text_Box)
        Me.Controls.Add(Me.Check_Box)
        Me.Controls.Add(Me.Button)
        Me.Name = "ctrl_Basic"
        Me.Size = New System.Drawing.Size(305, 174)
        CType(Me.Slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image_Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button As System.Windows.Forms.Button
    Friend WithEvents Check_Box As System.Windows.Forms.CheckBox
    Friend WithEvents Text_Box As System.Windows.Forms.TextBox
    Friend WithEvents Slider As System.Windows.Forms.TrackBar
    Friend WithEvents Combo_Box As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Box As System.Windows.Forms.Label
    Friend WithEvents Image_Box As System.Windows.Forms.PictureBox
    Friend WithEvents List_Box As System.Windows.Forms.ListBox

End Class
