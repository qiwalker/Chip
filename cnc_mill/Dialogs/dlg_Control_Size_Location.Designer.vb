<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Control_Size_Location
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlg_Control_Size_Location))
        Me.ts_Main = New System.Windows.Forms.ToolStrip()
        Me.ts_Exit = New System.Windows.Forms.ToolStripButton()
        Me.ts_Cancel = New System.Windows.Forms.ToolStripButton()
        Me.track_Top = New System.Windows.Forms.TrackBar()
        Me.track_Width = New System.Windows.Forms.TrackBar()
        Me.track_Left = New System.Windows.Forms.TrackBar()
        Me.track_Height = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lab_Height = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lab_Top = New System.Windows.Forms.Label()
        Me.ts_Main.SuspendLayout()
        CType(Me.track_Top, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.track_Width, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.track_Left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.track_Height, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ts_Main
        '
        Me.ts_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Exit, Me.ts_Cancel})
        Me.ts_Main.Location = New System.Drawing.Point(0, 0)
        Me.ts_Main.Name = "ts_Main"
        Me.ts_Main.Size = New System.Drawing.Size(454, 38)
        Me.ts_Main.TabIndex = 6
        Me.ts_Main.Text = "ToolStrip1"
        '
        'ts_Exit
        '
        Me.ts_Exit.Image = CType(resources.GetObject("ts_Exit.Image"), System.Drawing.Image)
        Me.ts_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Exit.Name = "ts_Exit"
        Me.ts_Exit.Size = New System.Drawing.Size(29, 35)
        Me.ts_Exit.Text = "Exit"
        Me.ts_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Cancel
        '
        Me.ts_Cancel.Image = CType(resources.GetObject("ts_Cancel.Image"), System.Drawing.Image)
        Me.ts_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Cancel.Name = "ts_Cancel"
        Me.ts_Cancel.Size = New System.Drawing.Size(47, 35)
        Me.ts_Cancel.Text = "Cancel"
        Me.ts_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'track_Top
        '
        Me.track_Top.LargeChange = 1
        Me.track_Top.Location = New System.Drawing.Point(0, 88)
        Me.track_Top.Name = "track_Top"
        Me.track_Top.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.track_Top.Size = New System.Drawing.Size(45, 315)
        Me.track_Top.TabIndex = 7
        Me.track_Top.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'track_Width
        '
        Me.track_Width.LargeChange = 1
        Me.track_Width.Location = New System.Drawing.Point(168, 126)
        Me.track_Width.Name = "track_Width"
        Me.track_Width.Size = New System.Drawing.Size(139, 45)
        Me.track_Width.TabIndex = 8
        '
        'track_Left
        '
        Me.track_Left.LargeChange = 1
        Me.track_Left.Location = New System.Drawing.Point(14, 37)
        Me.track_Left.Name = "track_Left"
        Me.track_Left.Size = New System.Drawing.Size(440, 45)
        Me.track_Left.TabIndex = 9
        '
        'track_Height
        '
        Me.track_Height.LargeChange = 1
        Me.track_Height.Location = New System.Drawing.Point(157, 145)
        Me.track_Height.Name = "track_Height"
        Me.track_Height.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.track_Height.Size = New System.Drawing.Size(45, 110)
        Me.track_Height.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(223, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Width"
        '
        'lab_Height
        '
        Me.lab_Height.AutoSize = True
        Me.lab_Height.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lab_Height.Location = New System.Drawing.Point(190, 195)
        Me.lab_Height.Name = "lab_Height"
        Me.lab_Height.Size = New System.Drawing.Size(47, 16)
        Me.lab_Height.TabIndex = 12
        Me.lab_Height.Text = "Height"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(132, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Left/Right"
        '
        'lab_Top
        '
        Me.lab_Top.AutoSize = True
        Me.lab_Top.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lab_Top.Location = New System.Drawing.Point(39, 239)
        Me.lab_Top.Name = "lab_Top"
        Me.lab_Top.Size = New System.Drawing.Size(64, 16)
        Me.lab_Top.TabIndex = 13
        Me.lab_Top.Text = "Up/Down"
        '
        'dlg_Control_Size_Location
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 418)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lab_Top)
        Me.Controls.Add(Me.lab_Height)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.track_Height)
        Me.Controls.Add(Me.track_Left)
        Me.Controls.Add(Me.track_Width)
        Me.Controls.Add(Me.track_Top)
        Me.Controls.Add(Me.ts_Main)
        Me.Name = "dlg_Control_Size_Location"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Control Size & Location"
        Me.TopMost = True
        Me.ts_Main.ResumeLayout(False)
        Me.ts_Main.PerformLayout()
        CType(Me.track_Top, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.track_Width, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.track_Left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.track_Height, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ts_Main As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents track_Top As System.Windows.Forms.TrackBar
    Friend WithEvents track_Width As System.Windows.Forms.TrackBar
    Friend WithEvents track_Left As System.Windows.Forms.TrackBar
    Friend WithEvents track_Height As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lab_Height As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lab_Top As System.Windows.Forms.Label
End Class
