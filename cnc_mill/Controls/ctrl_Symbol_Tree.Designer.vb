<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Symbol_Tree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_Symbol_Tree))
        Me.Tree_Type_View = New System.Windows.Forms.TreeView()
        Me.tab_Symbols = New System.Windows.Forms.TabControl()
        Me.tab_Symbol_Table = New System.Windows.Forms.TabPage()
        Me.list_Symbols = New System.Windows.Forms.ListView()
        Me.col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_Value = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_Type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_Comment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ts_Symbols = New System.Windows.Forms.ToolStrip()
        Me.ts_Insert = New System.Windows.Forms.ToolStripButton()
        Me.ts_Delete = New System.Windows.Forms.ToolStripButton()
        Me.ts_Copy = New System.Windows.Forms.ToolStripButton()
        Me.ts_Up = New System.Windows.Forms.ToolStripButton()
        Me.ts_Down = New System.Windows.Forms.ToolStripButton()
        Me.ts_Collapse = New System.Windows.Forms.ToolStripButton()
        Me.ts_Expand = New System.Windows.Forms.ToolStripButton()
        Me.ts_Sort = New System.Windows.Forms.ToolStripButton()
        Me.tab_View_By_Name = New System.Windows.Forms.TabPage()
        Me.Tree_Name_View = New System.Windows.Forms.TreeView()
        Me.tab_View_By_Type = New System.Windows.Forms.TabPage()
        Me.tab_Symbols.SuspendLayout()
        Me.tab_Symbol_Table.SuspendLayout()
        Me.ts_Symbols.SuspendLayout()
        Me.tab_View_By_Name.SuspendLayout()
        Me.tab_View_By_Type.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tree_Type_View
        '
        Me.Tree_Type_View.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree_Type_View.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tree_Type_View.Location = New System.Drawing.Point(3, 3)
        Me.Tree_Type_View.Name = "Tree_Type_View"
        Me.Tree_Type_View.Size = New System.Drawing.Size(527, 346)
        Me.Tree_Type_View.TabIndex = 105
        '
        'tab_Symbols
        '
        Me.tab_Symbols.Controls.Add(Me.tab_View_By_Name)
        Me.tab_Symbols.Controls.Add(Me.tab_View_By_Type)
        Me.tab_Symbols.Controls.Add(Me.tab_Symbol_Table)
        Me.tab_Symbols.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_Symbols.Location = New System.Drawing.Point(0, 0)
        Me.tab_Symbols.Name = "tab_Symbols"
        Me.tab_Symbols.SelectedIndex = 0
        Me.tab_Symbols.Size = New System.Drawing.Size(541, 378)
        Me.tab_Symbols.TabIndex = 107
        '
        'tab_Symbol_Table
        '
        Me.tab_Symbol_Table.Controls.Add(Me.list_Symbols)
        Me.tab_Symbol_Table.Controls.Add(Me.ts_Symbols)
        Me.tab_Symbol_Table.Location = New System.Drawing.Point(4, 22)
        Me.tab_Symbol_Table.Name = "tab_Symbol_Table"
        Me.tab_Symbol_Table.Size = New System.Drawing.Size(533, 352)
        Me.tab_Symbol_Table.TabIndex = 2
        Me.tab_Symbol_Table.Text = "Symbol Table"
        Me.tab_Symbol_Table.UseVisualStyleBackColor = True
        '
        'list_Symbols
        '
        Me.list_Symbols.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_Name, Me.col_Value, Me.col_Type, Me.col_Comment})
        Me.list_Symbols.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list_Symbols.FullRowSelect = True
        Me.list_Symbols.GridLines = True
        Me.list_Symbols.Location = New System.Drawing.Point(0, 38)
        Me.list_Symbols.Name = "list_Symbols"
        Me.list_Symbols.Size = New System.Drawing.Size(533, 314)
        Me.list_Symbols.TabIndex = 108
        Me.list_Symbols.UseCompatibleStateImageBehavior = False
        Me.list_Symbols.View = System.Windows.Forms.View.Details
        '
        'col_Name
        '
        Me.col_Name.Text = "Name"
        Me.col_Name.Width = 152
        '
        'col_Value
        '
        Me.col_Value.Text = "Value"
        Me.col_Value.Width = 168
        '
        'col_Type
        '
        Me.col_Type.Text = "Type"
        '
        'col_Comment
        '
        Me.col_Comment.Text = "Comment"
        Me.col_Comment.Width = 122
        '
        'ts_Symbols
        '
        Me.ts_Symbols.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Insert, Me.ts_Delete, Me.ts_Copy, Me.ts_Up, Me.ts_Down, Me.ts_Collapse, Me.ts_Expand, Me.ts_Sort})
        Me.ts_Symbols.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ts_Symbols.Location = New System.Drawing.Point(0, 0)
        Me.ts_Symbols.Name = "ts_Symbols"
        Me.ts_Symbols.Size = New System.Drawing.Size(533, 38)
        Me.ts_Symbols.TabIndex = 107
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
        'ts_Delete
        '
        Me.ts_Delete.Image = CType(resources.GetObject("ts_Delete.Image"), System.Drawing.Image)
        Me.ts_Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Delete.Name = "ts_Delete"
        Me.ts_Delete.Size = New System.Drawing.Size(44, 35)
        Me.ts_Delete.Text = "Delete"
        Me.ts_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Copy
        '
        Me.ts_Copy.Image = CType(resources.GetObject("ts_Copy.Image"), System.Drawing.Image)
        Me.ts_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Copy.Name = "ts_Copy"
        Me.ts_Copy.Size = New System.Drawing.Size(39, 35)
        Me.ts_Copy.Text = "Copy"
        Me.ts_Copy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Up
        '
        Me.ts_Up.Image = CType(resources.GetObject("ts_Up.Image"), System.Drawing.Image)
        Me.ts_Up.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Up.Name = "ts_Up"
        Me.ts_Up.Size = New System.Drawing.Size(26, 35)
        Me.ts_Up.Text = "Up"
        Me.ts_Up.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Down
        '
        Me.ts_Down.Image = CType(resources.GetObject("ts_Down.Image"), System.Drawing.Image)
        Me.ts_Down.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Down.Name = "ts_Down"
        Me.ts_Down.Size = New System.Drawing.Size(42, 35)
        Me.ts_Down.Text = "Down"
        Me.ts_Down.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Collapse
        '
        Me.ts_Collapse.Image = CType(resources.GetObject("ts_Collapse.Image"), System.Drawing.Image)
        Me.ts_Collapse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Collapse.Name = "ts_Collapse"
        Me.ts_Collapse.Size = New System.Drawing.Size(56, 35)
        Me.ts_Collapse.Text = "Collapse"
        Me.ts_Collapse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Expand
        '
        Me.ts_Expand.Image = CType(resources.GetObject("ts_Expand.Image"), System.Drawing.Image)
        Me.ts_Expand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Expand.Name = "ts_Expand"
        Me.ts_Expand.Size = New System.Drawing.Size(49, 35)
        Me.ts_Expand.Text = "Expand"
        Me.ts_Expand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Sort
        '
        Me.ts_Sort.Image = CType(resources.GetObject("ts_Sort.Image"), System.Drawing.Image)
        Me.ts_Sort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Sort.Name = "ts_Sort"
        Me.ts_Sort.Size = New System.Drawing.Size(45, 35)
        Me.ts_Sort.Text = "Sorted"
        Me.ts_Sort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tab_View_By_Name
        '
        Me.tab_View_By_Name.Controls.Add(Me.Tree_Name_View)
        Me.tab_View_By_Name.Location = New System.Drawing.Point(4, 22)
        Me.tab_View_By_Name.Name = "tab_View_By_Name"
        Me.tab_View_By_Name.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_View_By_Name.Size = New System.Drawing.Size(533, 352)
        Me.tab_View_By_Name.TabIndex = 1
        Me.tab_View_By_Name.Text = "View by Name"
        Me.tab_View_By_Name.UseVisualStyleBackColor = True
        '
        'Tree_Name_View
        '
        Me.Tree_Name_View.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree_Name_View.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tree_Name_View.Location = New System.Drawing.Point(3, 3)
        Me.Tree_Name_View.Name = "Tree_Name_View"
        Me.Tree_Name_View.Size = New System.Drawing.Size(527, 346)
        Me.Tree_Name_View.TabIndex = 106
        '
        'tab_View_By_Type
        '
        Me.tab_View_By_Type.Controls.Add(Me.Tree_Type_View)
        Me.tab_View_By_Type.Location = New System.Drawing.Point(4, 22)
        Me.tab_View_By_Type.Name = "tab_View_By_Type"
        Me.tab_View_By_Type.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_View_By_Type.Size = New System.Drawing.Size(533, 352)
        Me.tab_View_By_Type.TabIndex = 0
        Me.tab_View_By_Type.Text = "View by Type"
        Me.tab_View_By_Type.UseVisualStyleBackColor = True
        '
        'ctrl_Symbol_Tree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.tab_Symbols)
        Me.Name = "ctrl_Symbol_Tree"
        Me.Size = New System.Drawing.Size(541, 378)
        Me.tab_Symbols.ResumeLayout(False)
        Me.tab_Symbol_Table.ResumeLayout(False)
        Me.tab_Symbol_Table.PerformLayout()
        Me.ts_Symbols.ResumeLayout(False)
        Me.ts_Symbols.PerformLayout()
        Me.tab_View_By_Name.ResumeLayout(False)
        Me.tab_View_By_Type.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tree_Type_View As System.Windows.Forms.TreeView
    Friend WithEvents tab_Symbols As System.Windows.Forms.TabControl
    Friend WithEvents tab_View_By_Type As System.Windows.Forms.TabPage
    Friend WithEvents tab_View_By_Name As System.Windows.Forms.TabPage
    Friend WithEvents tab_Symbol_Table As System.Windows.Forms.TabPage
    Friend WithEvents ts_Symbols As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Insert As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Up As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Down As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Collapse As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Expand As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Copy As System.Windows.Forms.ToolStripButton
    Friend WithEvents list_Symbols As System.Windows.Forms.ListView
    Friend WithEvents col_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_Value As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_Type As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_Comment As System.Windows.Forms.ColumnHeader
    Friend WithEvents ts_Sort As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tree_Name_View As System.Windows.Forms.TreeView

End Class
