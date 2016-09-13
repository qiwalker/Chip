<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Macro_Editor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlg_Macro_Editor))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ts_Main = New System.Windows.Forms.ToolStrip()
        Me.ts_Exit = New System.Windows.Forms.ToolStripButton()
        Me.tab_Main = New System.Windows.Forms.TabControl()
        Me.tab_Page_Editor = New System.Windows.Forms.TabPage()
        Me.Macro_Editor = New Chip.ctr_Macro_Editor()
        Me.split_Middle = New System.Windows.Forms.Splitter()
        Me.grid_Properties = New System.Windows.Forms.DataGridView()
        Me.split_Left = New System.Windows.Forms.Splitter()
        Me.ctl_Symbol_Tree = New Chip.ctrl_Symbol_Tree()
        Me.tab_Page_Watch = New System.Windows.Forms.TabPage()
        Me.grid_Watch = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Property = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ts_Main.SuspendLayout()
        Me.tab_Main.SuspendLayout()
        Me.tab_Page_Editor.SuspendLayout()
        CType(Me.grid_Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_Page_Watch.SuspendLayout()
        CType(Me.grid_Watch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ts_Main
        '
        Me.ts_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Exit})
        Me.ts_Main.Location = New System.Drawing.Point(0, 0)
        Me.ts_Main.Name = "ts_Main"
        Me.ts_Main.Size = New System.Drawing.Size(1248, 38)
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
        'tab_Main
        '
        Me.tab_Main.Controls.Add(Me.tab_Page_Editor)
        Me.tab_Main.Controls.Add(Me.tab_Page_Watch)
        Me.tab_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_Main.Location = New System.Drawing.Point(0, 38)
        Me.tab_Main.Name = "tab_Main"
        Me.tab_Main.SelectedIndex = 0
        Me.tab_Main.Size = New System.Drawing.Size(1248, 580)
        Me.tab_Main.TabIndex = 8
        '
        'tab_Page_Editor
        '
        Me.tab_Page_Editor.Controls.Add(Me.Macro_Editor)
        Me.tab_Page_Editor.Controls.Add(Me.split_Middle)
        Me.tab_Page_Editor.Controls.Add(Me.grid_Properties)
        Me.tab_Page_Editor.Controls.Add(Me.split_Left)
        Me.tab_Page_Editor.Controls.Add(Me.ctl_Symbol_Tree)
        Me.tab_Page_Editor.Location = New System.Drawing.Point(4, 22)
        Me.tab_Page_Editor.Name = "tab_Page_Editor"
        Me.tab_Page_Editor.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_Page_Editor.Size = New System.Drawing.Size(1240, 554)
        Me.tab_Page_Editor.TabIndex = 0
        Me.tab_Page_Editor.Text = "Editor"
        Me.tab_Page_Editor.UseVisualStyleBackColor = True
        '
        'Macro_Editor
        '
        Me.Macro_Editor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Macro_Editor.Location = New System.Drawing.Point(660, 3)
        Me.Macro_Editor.Name = "Macro_Editor"
        Me.Macro_Editor.Size = New System.Drawing.Size(577, 548)
        Me.Macro_Editor.TabIndex = 9
        '
        'split_Middle
        '
        Me.split_Middle.BackColor = System.Drawing.Color.Firebrick
        Me.split_Middle.Location = New System.Drawing.Point(657, 3)
        Me.split_Middle.Name = "split_Middle"
        Me.split_Middle.Size = New System.Drawing.Size(3, 548)
        Me.split_Middle.TabIndex = 8
        Me.split_Middle.TabStop = False
        '
        'grid_Properties
        '
        Me.grid_Properties.AllowUserToAddRows = False
        Me.grid_Properties.AllowUserToDeleteRows = False
        Me.grid_Properties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Properties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_Property, Me.col_Value, Me.col_Type})
        Me.grid_Properties.Dock = System.Windows.Forms.DockStyle.Left
        Me.grid_Properties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grid_Properties.Location = New System.Drawing.Point(340, 3)
        Me.grid_Properties.Name = "grid_Properties"
        Me.grid_Properties.Size = New System.Drawing.Size(317, 548)
        Me.grid_Properties.TabIndex = 2
        '
        'split_Left
        '
        Me.split_Left.BackColor = System.Drawing.Color.Firebrick
        Me.split_Left.Location = New System.Drawing.Point(337, 3)
        Me.split_Left.Name = "split_Left"
        Me.split_Left.Size = New System.Drawing.Size(3, 548)
        Me.split_Left.TabIndex = 1
        Me.split_Left.TabStop = False
        '
        'ctl_Symbol_Tree
        '
        Me.ctl_Symbol_Tree.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ctl_Symbol_Tree.Dock = System.Windows.Forms.DockStyle.Left
        Me.ctl_Symbol_Tree.Location = New System.Drawing.Point(3, 3)
        Me.ctl_Symbol_Tree.Name = "ctl_Symbol_Tree"
        Me.ctl_Symbol_Tree.Size = New System.Drawing.Size(334, 548)
        Me.ctl_Symbol_Tree.TabIndex = 0
        '
        'tab_Page_Watch
        '
        Me.tab_Page_Watch.Controls.Add(Me.grid_Watch)
        Me.tab_Page_Watch.Location = New System.Drawing.Point(4, 22)
        Me.tab_Page_Watch.Name = "tab_Page_Watch"
        Me.tab_Page_Watch.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_Page_Watch.Size = New System.Drawing.Size(1240, 554)
        Me.tab_Page_Watch.TabIndex = 1
        Me.tab_Page_Watch.Text = "Watch"
        Me.tab_Page_Watch.UseVisualStyleBackColor = True
        '
        'grid_Watch
        '
        Me.grid_Watch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Watch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.grid_Watch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_Watch.Location = New System.Drawing.Point(3, 3)
        Me.grid_Watch.Name = "grid_Watch"
        Me.grid_Watch.Size = New System.Drawing.Size(1234, 548)
        Me.grid_Watch.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Property"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 71
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 59
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 56
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn4.HeaderText = "Comment"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 76
        '
        'col_Property
        '
        Me.col_Property.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.col_Property.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_Property.HeaderText = "Property"
        Me.col_Property.Name = "col_Property"
        Me.col_Property.ReadOnly = True
        Me.col_Property.Width = 71
        '
        'col_Value
        '
        Me.col_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.col_Value.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_Value.HeaderText = "Value"
        Me.col_Value.Name = "col_Value"
        Me.col_Value.Width = 59
        '
        'col_Type
        '
        Me.col_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.col_Type.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_Type.HeaderText = "Type"
        Me.col_Type.Name = "col_Type"
        Me.col_Type.ReadOnly = True
        Me.col_Type.Width = 56
        '
        'dlg_Macro_Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 618)
        Me.Controls.Add(Me.tab_Main)
        Me.Controls.Add(Me.ts_Main)
        Me.Name = "dlg_Macro_Editor"
        Me.Text = "Macro Editor"
        Me.TopMost = True
        Me.ts_Main.ResumeLayout(False)
        Me.ts_Main.PerformLayout()
        Me.tab_Main.ResumeLayout(False)
        Me.tab_Page_Editor.ResumeLayout(False)
        CType(Me.grid_Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_Page_Watch.ResumeLayout(False)
        CType(Me.grid_Watch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ts_Main As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tab_Main As System.Windows.Forms.TabControl
    Friend WithEvents tab_Page_Editor As System.Windows.Forms.TabPage
    Friend WithEvents tab_Page_Watch As System.Windows.Forms.TabPage
    Friend WithEvents grid_Properties As System.Windows.Forms.DataGridView
    Friend WithEvents split_Left As System.Windows.Forms.Splitter
    Friend WithEvents ctl_Symbol_Tree As Chip.ctrl_Symbol_Tree
    Friend WithEvents split_Middle As System.Windows.Forms.Splitter
    Friend WithEvents grid_Watch As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Macro_Editor As Chip.ctr_Macro_Editor
    Friend WithEvents col_Property As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Type As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
