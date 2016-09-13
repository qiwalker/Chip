<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Drawing
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
        Me.temp_Dwg_pnl_Main = New System.Windows.Forms.Panel()
        Me.temp_Dwg_pnl_Viewport = New System.Windows.Forms.Panel()
        Me.temp_Dwg_pnl_Canvas = New System.Windows.Forms.PictureBox()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.lab_Scale = New System.Windows.Forms.Label()
        Me.lab_Z = New System.Windows.Forms.Label()
        Me.ud_Z_Angle = New System.Windows.Forms.NumericUpDown()
        Me.lab_Y = New System.Windows.Forms.Label()
        Me.ud_Y_Angle = New System.Windows.Forms.NumericUpDown()
        Me.lab_X = New System.Windows.Forms.Label()
        Me.ud_X_Angle = New System.Windows.Forms.NumericUpDown()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Stat_X_Pos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Stat_X = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Stat_Y = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Stat_Z = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btn_Reset = New System.Windows.Forms.Button()
        Me.temp_Dwg_pnl_Main.SuspendLayout()
        Me.temp_Dwg_pnl_Viewport.SuspendLayout()
        CType(Me.temp_Dwg_pnl_Canvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Top.SuspendLayout()
        CType(Me.ud_Z_Angle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ud_Y_Angle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ud_X_Angle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'temp_Dwg_pnl_Main
        '
        Me.temp_Dwg_pnl_Main.BackColor = System.Drawing.Color.WhiteSmoke
        Me.temp_Dwg_pnl_Main.Controls.Add(Me.temp_Dwg_pnl_Viewport)
        Me.temp_Dwg_pnl_Main.Controls.Add(Me.pnl_Top)
        Me.temp_Dwg_pnl_Main.Controls.Add(Me.StatusStrip1)
        Me.temp_Dwg_pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.temp_Dwg_pnl_Main.Location = New System.Drawing.Point(0, 0)
        Me.temp_Dwg_pnl_Main.Name = "temp_Dwg_pnl_Main"
        Me.temp_Dwg_pnl_Main.Size = New System.Drawing.Size(654, 380)
        Me.temp_Dwg_pnl_Main.TabIndex = 156
        '
        'temp_Dwg_pnl_Viewport
        '
        Me.temp_Dwg_pnl_Viewport.BackColor = System.Drawing.Color.DarkSlateGray
        Me.temp_Dwg_pnl_Viewport.Controls.Add(Me.temp_Dwg_pnl_Canvas)
        Me.temp_Dwg_pnl_Viewport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.temp_Dwg_pnl_Viewport.Location = New System.Drawing.Point(0, 36)
        Me.temp_Dwg_pnl_Viewport.Name = "temp_Dwg_pnl_Viewport"
        Me.temp_Dwg_pnl_Viewport.Size = New System.Drawing.Size(654, 322)
        Me.temp_Dwg_pnl_Viewport.TabIndex = 156
        '
        'temp_Dwg_pnl_Canvas
        '
        Me.temp_Dwg_pnl_Canvas.BackColor = System.Drawing.Color.DarkSlateGray
        Me.temp_Dwg_pnl_Canvas.Location = New System.Drawing.Point(0, 0)
        Me.temp_Dwg_pnl_Canvas.Name = "temp_Dwg_pnl_Canvas"
        Me.temp_Dwg_pnl_Canvas.Size = New System.Drawing.Size(91, 100)
        Me.temp_Dwg_pnl_Canvas.TabIndex = 103
        Me.temp_Dwg_pnl_Canvas.TabStop = False
        '
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.btn_Reset)
        Me.pnl_Top.Controls.Add(Me.lab_Scale)
        Me.pnl_Top.Controls.Add(Me.lab_Z)
        Me.pnl_Top.Controls.Add(Me.ud_Z_Angle)
        Me.pnl_Top.Controls.Add(Me.lab_Y)
        Me.pnl_Top.Controls.Add(Me.ud_Y_Angle)
        Me.pnl_Top.Controls.Add(Me.lab_X)
        Me.pnl_Top.Controls.Add(Me.ud_X_Angle)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(654, 36)
        Me.pnl_Top.TabIndex = 157
        '
        'lab_Scale
        '
        Me.lab_Scale.AutoSize = True
        Me.lab_Scale.Location = New System.Drawing.Point(286, 1)
        Me.lab_Scale.Name = "lab_Scale"
        Me.lab_Scale.Size = New System.Drawing.Size(34, 13)
        Me.lab_Scale.TabIndex = 112
        Me.lab_Scale.Text = "Scale"
        '
        'lab_Z
        '
        Me.lab_Z.AutoSize = True
        Me.lab_Z.Location = New System.Drawing.Point(242, 0)
        Me.lab_Z.Name = "lab_Z"
        Me.lab_Z.Size = New System.Drawing.Size(14, 13)
        Me.lab_Z.TabIndex = 110
        Me.lab_Z.Text = "Z"
        '
        'ud_Z_Angle
        '
        Me.ud_Z_Angle.Location = New System.Drawing.Point(224, 15)
        Me.ud_Z_Angle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.ud_Z_Angle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
        Me.ud_Z_Angle.Name = "ud_Z_Angle"
        Me.ud_Z_Angle.Size = New System.Drawing.Size(30, 20)
        Me.ud_Z_Angle.TabIndex = 109
        Me.ud_Z_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lab_Y
        '
        Me.lab_Y.AutoSize = True
        Me.lab_Y.Location = New System.Drawing.Point(186, 0)
        Me.lab_Y.Name = "lab_Y"
        Me.lab_Y.Size = New System.Drawing.Size(14, 13)
        Me.lab_Y.TabIndex = 108
        Me.lab_Y.Text = "Y"
        '
        'ud_Y_Angle
        '
        Me.ud_Y_Angle.Location = New System.Drawing.Point(168, 15)
        Me.ud_Y_Angle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.ud_Y_Angle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
        Me.ud_Y_Angle.Name = "ud_Y_Angle"
        Me.ud_Y_Angle.Size = New System.Drawing.Size(30, 20)
        Me.ud_Y_Angle.TabIndex = 107
        Me.ud_Y_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lab_X
        '
        Me.lab_X.AutoSize = True
        Me.lab_X.Location = New System.Drawing.Point(134, 0)
        Me.lab_X.Name = "lab_X"
        Me.lab_X.Size = New System.Drawing.Size(14, 13)
        Me.lab_X.TabIndex = 106
        Me.lab_X.Text = "X"
        '
        'ud_X_Angle
        '
        Me.ud_X_Angle.Location = New System.Drawing.Point(116, 15)
        Me.ud_X_Angle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.ud_X_Angle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
        Me.ud_X_Angle.Name = "ud_X_Angle"
        Me.ud_X_Angle.Size = New System.Drawing.Size(30, 20)
        Me.ud_X_Angle.TabIndex = 105
        Me.ud_X_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Stat_X_Pos, Me.Stat_X, Me.ToolStripStatusLabel8, Me.Stat_Y, Me.ToolStripStatusLabel6, Me.Stat_Z})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 358)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(654, 22)
        Me.StatusStrip1.TabIndex = 104
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Stat_X_Pos
        '
        Me.Stat_X_Pos.BackColor = System.Drawing.SystemColors.Control
        Me.Stat_X_Pos.Name = "Stat_X_Pos"
        Me.Stat_X_Pos.Size = New System.Drawing.Size(14, 17)
        Me.Stat_X_Pos.Text = "X"
        '
        'Stat_X
        '
        Me.Stat_X.BackColor = System.Drawing.SystemColors.Control
        Me.Stat_X.Name = "Stat_X"
        Me.Stat_X.Size = New System.Drawing.Size(38, 17)
        Me.Stat_X.Text = "X_Pos"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(14, 17)
        Me.ToolStripStatusLabel8.Text = "Y"
        '
        'Stat_Y
        '
        Me.Stat_Y.BackColor = System.Drawing.SystemColors.Control
        Me.Stat_Y.Name = "Stat_Y"
        Me.Stat_Y.Size = New System.Drawing.Size(38, 17)
        Me.Stat_Y.Text = "Y_Pos"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(14, 17)
        Me.ToolStripStatusLabel6.Text = "Z"
        '
        'Stat_Z
        '
        Me.Stat_Z.BackColor = System.Drawing.SystemColors.Control
        Me.Stat_Z.Name = "Stat_Z"
        Me.Stat_Z.Size = New System.Drawing.Size(38, 17)
        Me.Stat_Z.Text = "Z_Pos"
        '
        'btn_Reset
        '
        Me.btn_Reset.Location = New System.Drawing.Point(0, 0)
        Me.btn_Reset.Name = "btn_Reset"
        Me.btn_Reset.Size = New System.Drawing.Size(59, 36)
        Me.btn_Reset.TabIndex = 113
        Me.btn_Reset.Text = "Reset"
        Me.btn_Reset.UseVisualStyleBackColor = True
        '
        'ctrl_Drawing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.temp_Dwg_pnl_Main)
        Me.Name = "ctrl_Drawing"
        Me.Size = New System.Drawing.Size(654, 380)
        Me.temp_Dwg_pnl_Main.ResumeLayout(False)
        Me.temp_Dwg_pnl_Main.PerformLayout()
        Me.temp_Dwg_pnl_Viewport.ResumeLayout(False)
        CType(Me.temp_Dwg_pnl_Canvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Top.PerformLayout()
        CType(Me.ud_Z_Angle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ud_Y_Angle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ud_X_Angle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents temp_Dwg_pnl_Main As System.Windows.Forms.Panel
    Friend WithEvents temp_Dwg_pnl_Viewport As System.Windows.Forms.Panel
    Friend WithEvents temp_Dwg_pnl_Canvas As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Stat_X_Pos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Stat_X As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Stat_Y As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Stat_Z As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents ud_X_Angle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lab_Z As System.Windows.Forms.Label
    Friend WithEvents ud_Z_Angle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lab_Y As System.Windows.Forms.Label
    Friend WithEvents ud_Y_Angle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lab_X As System.Windows.Forms.Label
    Friend WithEvents lab_Scale As System.Windows.Forms.Label
    Friend WithEvents btn_Reset As System.Windows.Forms.Button

End Class
