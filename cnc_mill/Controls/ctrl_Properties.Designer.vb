<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrl_Properties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_Properties))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ts_Insert = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts_Delete = New System.Windows.Forms.ToolStripButton()
        Me.ts_Narrower = New System.Windows.Forms.ToolStripButton()
        Me.ts_Wider = New System.Windows.Forms.ToolStripButton()
        Me.grid_Properties = New System.Windows.Forms.DataGridView()
        Me.col_Property = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip.SuspendLayout()
        CType(Me.grid_Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Insert, Me.ts_Delete, Me.ts_Narrower, Me.ts_Wider})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(216, 38)
        Me.ToolStrip.TabIndex = 107
        '
        'ts_Insert
        '
        Me.ts_Insert.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ts_Insert.Image = CType(resources.GetObject("ts_Insert.Image"), System.Drawing.Image)
        Me.ts_Insert.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Insert.Name = "ts_Insert"
        Me.ts_Insert.Size = New System.Drawing.Size(49, 35)
        Me.ts_Insert.Text = "Insert"
        Me.ts_Insert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem1.Text = "Type"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem2.Text = "Child"
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
        'ts_Narrower
        '
        Me.ts_Narrower.Image = CType(resources.GetObject("ts_Narrower.Image"), System.Drawing.Image)
        Me.ts_Narrower.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Narrower.Name = "ts_Narrower"
        Me.ts_Narrower.Size = New System.Drawing.Size(60, 35)
        Me.ts_Narrower.Text = "Narrower"
        Me.ts_Narrower.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Wider
        '
        Me.ts_Wider.Image = CType(resources.GetObject("ts_Wider.Image"), System.Drawing.Image)
        Me.ts_Wider.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Wider.Name = "ts_Wider"
        Me.ts_Wider.Size = New System.Drawing.Size(42, 35)
        Me.ts_Wider.Text = "Wider"
        Me.ts_Wider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'grid_Properties
        '
        Me.grid_Properties.AllowUserToAddRows = False
        Me.grid_Properties.AllowUserToDeleteRows = False
        Me.grid_Properties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Properties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_Property, Me.col_Value})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid_Properties.DefaultCellStyle = DataGridViewCellStyle1
        Me.grid_Properties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_Properties.Location = New System.Drawing.Point(0, 38)
        Me.grid_Properties.Name = "grid_Properties"
        Me.grid_Properties.Size = New System.Drawing.Size(216, 254)
        Me.grid_Properties.TabIndex = 108
        '
        'col_Property
        '
        Me.col_Property.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_Property.HeaderText = "Property"
        Me.col_Property.Name = "col_Property"
        Me.col_Property.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_Property.Width = 52
        '
        'col_Value
        '
        Me.col_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_Value.HeaderText = "Value"
        Me.col_Value.Name = "col_Value"
        Me.col_Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_Value.Width = 40
        '
        'ctrl_Properties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grid_Properties)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "ctrl_Properties"
        Me.Size = New System.Drawing.Size(216, 292)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.grid_Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Insert As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts_Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents grid_Properties As System.Windows.Forms.DataGridView
    Friend WithEvents col_Property As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ts_Narrower As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Wider As System.Windows.Forms.ToolStripButton

End Class
