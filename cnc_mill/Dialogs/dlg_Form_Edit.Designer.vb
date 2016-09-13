<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Form_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlg_Form_Edit))
        Me.ts_Main = New System.Windows.Forms.ToolStrip()
        Me.ts_Exit = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.pnl_Bottom = New System.Windows.Forms.Panel()
        Me.split_Top = New System.Windows.Forms.Splitter()
        Me.split_Bottom = New System.Windows.Forms.Splitter()
        Me.pnl_Left = New System.Windows.Forms.Panel()
        Me.split_Left = New System.Windows.Forms.Splitter()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.split_Right = New System.Windows.Forms.Splitter()
        Me.tab_Main = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ts_Main.SuspendLayout()
        Me.tab_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'ts_Main
        '
        Me.ts_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Exit})
        Me.ts_Main.Location = New System.Drawing.Point(0, 0)
        Me.ts_Main.Name = "ts_Main"
        Me.ts_Main.Size = New System.Drawing.Size(576, 38)
        Me.ts_Main.TabIndex = 4
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
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 498)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(576, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pnl_Top
        '
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 38)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(576, 75)
        Me.pnl_Top.TabIndex = 8
        '
        'pnl_Bottom
        '
        Me.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Bottom.Location = New System.Drawing.Point(0, 434)
        Me.pnl_Bottom.Name = "pnl_Bottom"
        Me.pnl_Bottom.Size = New System.Drawing.Size(576, 64)
        Me.pnl_Bottom.TabIndex = 9
        '
        'split_Top
        '
        Me.split_Top.BackColor = System.Drawing.Color.Firebrick
        Me.split_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.split_Top.Location = New System.Drawing.Point(0, 113)
        Me.split_Top.Name = "split_Top"
        Me.split_Top.Size = New System.Drawing.Size(576, 3)
        Me.split_Top.TabIndex = 10
        Me.split_Top.TabStop = False
        '
        'split_Bottom
        '
        Me.split_Bottom.BackColor = System.Drawing.Color.Firebrick
        Me.split_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.split_Bottom.Location = New System.Drawing.Point(0, 431)
        Me.split_Bottom.Name = "split_Bottom"
        Me.split_Bottom.Size = New System.Drawing.Size(576, 3)
        Me.split_Bottom.TabIndex = 11
        Me.split_Bottom.TabStop = False
        '
        'pnl_Left
        '
        Me.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_Left.Location = New System.Drawing.Point(0, 116)
        Me.pnl_Left.Name = "pnl_Left"
        Me.pnl_Left.Size = New System.Drawing.Size(92, 315)
        Me.pnl_Left.TabIndex = 12
        '
        'split_Left
        '
        Me.split_Left.BackColor = System.Drawing.Color.Firebrick
        Me.split_Left.Location = New System.Drawing.Point(92, 116)
        Me.split_Left.Name = "split_Left"
        Me.split_Left.Size = New System.Drawing.Size(3, 315)
        Me.split_Left.TabIndex = 13
        Me.split_Left.TabStop = False
        '
        'pnl_Right
        '
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(465, 116)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(111, 315)
        Me.pnl_Right.TabIndex = 14
        '
        'split_Right
        '
        Me.split_Right.BackColor = System.Drawing.Color.Firebrick
        Me.split_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.split_Right.Location = New System.Drawing.Point(462, 116)
        Me.split_Right.Name = "split_Right"
        Me.split_Right.Size = New System.Drawing.Size(3, 315)
        Me.split_Right.TabIndex = 15
        Me.split_Right.TabStop = False
        '
        'tab_Main
        '
        Me.tab_Main.Controls.Add(Me.TabPage1)
        Me.tab_Main.Controls.Add(Me.TabPage2)
        Me.tab_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_Main.Location = New System.Drawing.Point(95, 116)
        Me.tab_Main.Name = "tab_Main"
        Me.tab_Main.SelectedIndex = 0
        Me.tab_Main.Size = New System.Drawing.Size(367, 315)
        Me.tab_Main.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(359, 289)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(359, 289)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dlg_Form_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(576, 520)
        Me.Controls.Add(Me.tab_Main)
        Me.Controls.Add(Me.split_Right)
        Me.Controls.Add(Me.pnl_Right)
        Me.Controls.Add(Me.split_Left)
        Me.Controls.Add(Me.pnl_Left)
        Me.Controls.Add(Me.split_Bottom)
        Me.Controls.Add(Me.split_Top)
        Me.Controls.Add(Me.pnl_Bottom)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ts_Main)
        Me.Name = "dlg_Form_Edit"
        Me.Text = "Form Edit"
        Me.ts_Main.ResumeLayout(False)
        Me.ts_Main.PerformLayout()
        Me.tab_Main.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ts_Main As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents pnl_Bottom As System.Windows.Forms.Panel
    Friend WithEvents split_Top As System.Windows.Forms.Splitter
    Friend WithEvents split_Bottom As System.Windows.Forms.Splitter
    Friend WithEvents pnl_Left As System.Windows.Forms.Panel
    Friend WithEvents split_Left As System.Windows.Forms.Splitter
    Friend WithEvents pnl_Right As System.Windows.Forms.Panel
    Friend WithEvents split_Right As System.Windows.Forms.Splitter
    Friend WithEvents tab_Main As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
End Class
