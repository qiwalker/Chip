<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Gcode
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_Gcode))
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Statuw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Point_Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ts_G_Code = New System.Windows.Forms.ToolStrip()
        Me.ts_Offsets_On = New System.Windows.Forms.ToolStripButton()
        Me.ts_Offsets_Off = New System.Windows.Forms.ToolStripButton()
        Me.ts_Run = New System.Windows.Forms.ToolStripButton()
        Me.ts_Step = New System.Windows.Forms.ToolStripButton()
        Me.ts_Rewind = New System.Windows.Forms.ToolStripButton()
        Me.ts_Start_Here = New System.Windows.Forms.ToolStripButton()
        Me.ts_Recover = New System.Windows.Forms.ToolStripButton()
        Me.ts_Insert = New System.Windows.Forms.ToolStripButton()
        Me.ts_Insert_Position = New System.Windows.Forms.ToolStripButton()
        Me.ts_Delete = New System.Windows.Forms.ToolStripButton()
        Me.ts_Stops_On = New System.Windows.Forms.ToolStripButton()
        Me.ts_Stops_Off = New System.Windows.Forms.ToolStripButton()
        Me.ts_Enable = New System.Windows.Forms.ToolStrip()
        Me.ts_Enabled = New System.Windows.Forms.ToolStripButton()
        Me.ts_Load = New System.Windows.Forms.ToolStripButton()
        Me.ts_Save = New System.Windows.Forms.ToolStripButton()
        Me.ts_Save_As = New System.Windows.Forms.ToolStripButton()
        Me.ts_Wizards = New System.Windows.Forms.ToolStripButton()
        Me.ts_Info = New System.Windows.Forms.ToolStripTextBox()
        Me.ts_Line_Count = New System.Windows.Forms.ToolStripLabel()
        Me.txt_Folder = New System.Windows.Forms.TextBox()
        Me.txt_File_Name = New System.Windows.Forms.TextBox()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ts_G_Code.SuspendLayout()
        Me.ts_Enable.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.ColumnHeadersHeight = 30
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Statuw, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.col_Point_Index})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.DefaultCellStyle = DataGridViewCellStyle5
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grid.Location = New System.Drawing.Point(0, 124)
        Me.grid.Name = "grid"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grid.Size = New System.Drawing.Size(666, 263)
        Me.grid.TabIndex = 114
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Text = ""
        Me.Column1.Width = 25
        '
        'Statuw
        '
        Me.Statuw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Statuw.DefaultCellStyle = DataGridViewCellStyle2
        Me.Statuw.HeaderText = ""
        Me.Statuw.Name = "Statuw"
        Me.Statuw.ReadOnly = True
        Me.Statuw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Statuw.Width = 25
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn17.HeaderText = "Line"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn17.Width = 75
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn18.HeaderText = "Block"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn18.Width = 350
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn19.HeaderText = "Comment"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn19.Width = 24
        '
        'col_Point_Index
        '
        Me.col_Point_Index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.col_Point_Index.HeaderText = "Point"
        Me.col_Point_Index.Name = "col_Point_Index"
        Me.col_Point_Index.ReadOnly = True
        Me.col_Point_Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ts_G_Code
        '
        Me.ts_G_Code.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Offsets_On, Me.ts_Offsets_Off, Me.ts_Run, Me.ts_Step, Me.ts_Rewind, Me.ts_Start_Here, Me.ts_Recover, Me.ts_Insert, Me.ts_Insert_Position, Me.ts_Delete, Me.ts_Stops_On, Me.ts_Stops_Off})
        Me.ts_G_Code.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ts_G_Code.Location = New System.Drawing.Point(0, 86)
        Me.ts_G_Code.Name = "ts_G_Code"
        Me.ts_G_Code.Size = New System.Drawing.Size(666, 38)
        Me.ts_G_Code.TabIndex = 113
        Me.ts_G_Code.Text = "ts_Gcode"
        '
        'ts_Offsets_On
        '
        Me.ts_Offsets_On.Image = CType(resources.GetObject("ts_Offsets_On.Image"), System.Drawing.Image)
        Me.ts_Offsets_On.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Offsets_On.Name = "ts_Offsets_On"
        Me.ts_Offsets_On.Size = New System.Drawing.Size(67, 35)
        Me.ts_Offsets_On.Text = "Offsets On"
        Me.ts_Offsets_On.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Offsets_Off
        '
        Me.ts_Offsets_Off.Image = CType(resources.GetObject("ts_Offsets_Off.Image"), System.Drawing.Image)
        Me.ts_Offsets_Off.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Offsets_Off.Name = "ts_Offsets_Off"
        Me.ts_Offsets_Off.Size = New System.Drawing.Size(68, 35)
        Me.ts_Offsets_Off.Text = "Offsets Off"
        Me.ts_Offsets_Off.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Run
        '
        Me.ts_Run.Image = CType(resources.GetObject("ts_Run.Image"), System.Drawing.Image)
        Me.ts_Run.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Run.Name = "ts_Run"
        Me.ts_Run.Size = New System.Drawing.Size(32, 35)
        Me.ts_Run.Text = "Run"
        Me.ts_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Step
        '
        Me.ts_Step.Image = CType(resources.GetObject("ts_Step.Image"), System.Drawing.Image)
        Me.ts_Step.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Step.Name = "ts_Step"
        Me.ts_Step.Size = New System.Drawing.Size(34, 35)
        Me.ts_Step.Text = "Step"
        Me.ts_Step.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Rewind
        '
        Me.ts_Rewind.Image = CType(resources.GetObject("ts_Rewind.Image"), System.Drawing.Image)
        Me.ts_Rewind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Rewind.Name = "ts_Rewind"
        Me.ts_Rewind.Size = New System.Drawing.Size(50, 35)
        Me.ts_Rewind.Text = "Rewind"
        Me.ts_Rewind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Start_Here
        '
        Me.ts_Start_Here.Image = CType(resources.GetObject("ts_Start_Here.Image"), System.Drawing.Image)
        Me.ts_Start_Here.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Start_Here.Name = "ts_Start_Here"
        Me.ts_Start_Here.Size = New System.Drawing.Size(63, 35)
        Me.ts_Start_Here.Text = "Start Here"
        Me.ts_Start_Here.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Recover
        '
        Me.ts_Recover.Image = CType(resources.GetObject("ts_Recover.Image"), System.Drawing.Image)
        Me.ts_Recover.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Recover.Name = "ts_Recover"
        Me.ts_Recover.Size = New System.Drawing.Size(53, 35)
        Me.ts_Recover.Text = "Recover"
        Me.ts_Recover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Insert
        '
        Me.ts_Insert.Image = CType(resources.GetObject("ts_Insert.Image"), System.Drawing.Image)
        Me.ts_Insert.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Insert.Name = "ts_Insert"
        Me.ts_Insert.Size = New System.Drawing.Size(40, 35)
        Me.ts_Insert.Text = "Insert"
        Me.ts_Insert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Insert_Position
        '
        Me.ts_Insert_Position.Image = CType(resources.GetObject("ts_Insert_Position.Image"), System.Drawing.Image)
        Me.ts_Insert_Position.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Insert_Position.Name = "ts_Insert_Position"
        Me.ts_Insert_Position.Size = New System.Drawing.Size(32, 35)
        Me.ts_Insert_Position.Text = "XYZ"
        Me.ts_Insert_Position.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Delete
        '
        Me.ts_Delete.Image = CType(resources.GetObject("ts_Delete.Image"), System.Drawing.Image)
        Me.ts_Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Delete.Name = "ts_Delete"
        Me.ts_Delete.Size = New System.Drawing.Size(44, 35)
        Me.ts_Delete.Text = "Delete"
        Me.ts_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Stops_On
        '
        Me.ts_Stops_On.Image = CType(resources.GetObject("ts_Stops_On.Image"), System.Drawing.Image)
        Me.ts_Stops_On.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Stops_On.Name = "ts_Stops_On"
        Me.ts_Stops_On.Size = New System.Drawing.Size(59, 35)
        Me.ts_Stops_On.Text = "Stops On"
        Me.ts_Stops_On.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Stops_Off
        '
        Me.ts_Stops_Off.Image = CType(resources.GetObject("ts_Stops_Off.Image"), System.Drawing.Image)
        Me.ts_Stops_Off.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Stops_Off.Name = "ts_Stops_Off"
        Me.ts_Stops_Off.Size = New System.Drawing.Size(60, 35)
        Me.ts_Stops_Off.Text = "Stops Off"
        Me.ts_Stops_Off.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Enable
        '
        Me.ts_Enable.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Enabled, Me.ts_Load, Me.ts_Save, Me.ts_Save_As, Me.ts_Wizards, Me.ts_Info, Me.ts_Line_Count})
        Me.ts_Enable.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ts_Enable.Location = New System.Drawing.Point(0, 48)
        Me.ts_Enable.Name = "ts_Enable"
        Me.ts_Enable.Size = New System.Drawing.Size(666, 38)
        Me.ts_Enable.TabIndex = 115
        Me.ts_Enable.Text = "ts_Enable"
        '
        'ts_Enabled
        '
        Me.ts_Enabled.Image = CType(resources.GetObject("ts_Enabled.Image"), System.Drawing.Image)
        Me.ts_Enabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Enabled.Name = "ts_Enabled"
        Me.ts_Enabled.Size = New System.Drawing.Size(53, 35)
        Me.ts_Enabled.Text = "Enabled"
        Me.ts_Enabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Load
        '
        Me.ts_Load.Image = CType(resources.GetObject("ts_Load.Image"), System.Drawing.Image)
        Me.ts_Load.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Load.Name = "ts_Load"
        Me.ts_Load.Size = New System.Drawing.Size(37, 35)
        Me.ts_Load.Text = "Load"
        Me.ts_Load.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Save
        '
        Me.ts_Save.Image = CType(resources.GetObject("ts_Save.Image"), System.Drawing.Image)
        Me.ts_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Save.Name = "ts_Save"
        Me.ts_Save.Size = New System.Drawing.Size(35, 35)
        Me.ts_Save.Text = "Save"
        Me.ts_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Save_As
        '
        Me.ts_Save_As.Image = CType(resources.GetObject("ts_Save_As.Image"), System.Drawing.Image)
        Me.ts_Save_As.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Save_As.Name = "ts_Save_As"
        Me.ts_Save_As.Size = New System.Drawing.Size(51, 35)
        Me.ts_Save_As.Text = "Save As"
        Me.ts_Save_As.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Wizards
        '
        Me.ts_Wizards.Image = CType(resources.GetObject("ts_Wizards.Image"), System.Drawing.Image)
        Me.ts_Wizards.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Wizards.Name = "ts_Wizards"
        Me.ts_Wizards.Size = New System.Drawing.Size(52, 35)
        Me.ts_Wizards.Text = "Wizards"
        Me.ts_Wizards.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Info
        '
        Me.ts_Info.BackColor = System.Drawing.Color.Yellow
        Me.ts_Info.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ts_Info.Name = "ts_Info"
        Me.ts_Info.Size = New System.Drawing.Size(50, 38)
        '
        'ts_Line_Count
        '
        Me.ts_Line_Count.Name = "ts_Line_Count"
        Me.ts_Line_Count.Size = New System.Drawing.Size(13, 35)
        Me.ts_Line_Count.Text = "0"
        '
        'txt_Folder
        '
        Me.txt_Folder.BackColor = System.Drawing.Color.White
        Me.txt_Folder.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Folder.Location = New System.Drawing.Point(0, 0)
        Me.txt_Folder.Name = "txt_Folder"
        Me.txt_Folder.ReadOnly = True
        Me.txt_Folder.Size = New System.Drawing.Size(666, 24)
        Me.txt_Folder.TabIndex = 116
        '
        'txt_File_Name
        '
        Me.txt_File_Name.BackColor = System.Drawing.Color.White
        Me.txt_File_Name.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_File_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_File_Name.Location = New System.Drawing.Point(0, 24)
        Me.txt_File_Name.Name = "txt_File_Name"
        Me.txt_File_Name.ReadOnly = True
        Me.txt_File_Name.Size = New System.Drawing.Size(666, 24)
        Me.txt_File_Name.TabIndex = 117
        '
        'ctrl_Gcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.ts_G_Code)
        Me.Controls.Add(Me.ts_Enable)
        Me.Controls.Add(Me.txt_File_Name)
        Me.Controls.Add(Me.txt_Folder)
        Me.Name = "ctrl_Gcode"
        Me.Size = New System.Drawing.Size(666, 387)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ts_G_Code.ResumeLayout(False)
        Me.ts_G_Code.PerformLayout()
        Me.ts_Enable.ResumeLayout(False)
        Me.ts_Enable.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents ts_G_Code As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Run As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Step As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Rewind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Insert As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Start_Here As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Offsets_On As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Enable As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Enabled As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Load As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Offsets_Off As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Save_As As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Wizards As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Info As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txt_Folder As System.Windows.Forms.TextBox
    Friend WithEvents ts_Insert_Position As System.Windows.Forms.ToolStripButton
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Statuw As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Point_Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ts_Stops_On As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Stops_Off As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Recover As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_File_Name As System.Windows.Forms.TextBox
    Friend WithEvents ts_Line_Count As System.Windows.Forms.ToolStripLabel

End Class
