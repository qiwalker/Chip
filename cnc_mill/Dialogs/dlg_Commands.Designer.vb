<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Commands
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
        Me.cmb_Commands = New System.Windows.Forms.ComboBox()
        Me.txt_Param = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmb_Commands
        '
        Me.cmb_Commands.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Commands.FormattingEnabled = True
        Me.cmb_Commands.Items.AddRange(New Object() {"$SYS    System Status", "$H      Help", "$SR     Request status report", "$EJ=1   Enable JSON mode             0=text mode, 1=JSON mode", "$QV     Queue report verbosity       0=off, 1=filtered, 2=verbose", "", "JSON", "{help:null}  Help", "{jv:0}   Verbocity none", "{jv:1}   Verocity", "{jv:2}   Verocity", "{jv:3}   Verocity", "{jv:4}   Verocity", "{jv:5}   Verocity most", "", "{sv:0}   Status report verbocity = None", "{sv:1}   Status report verbocity = Changes", "{sv:2}   Status report verbocity = All", "", "{sr:null}", "{sys:""""}"})
        Me.cmb_Commands.Location = New System.Drawing.Point(37, 34)
        Me.cmb_Commands.Name = "cmb_Commands"
        Me.cmb_Commands.Size = New System.Drawing.Size(693, 24)
        Me.cmb_Commands.TabIndex = 0
        '
        'txt_Param
        '
        Me.txt_Param.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Param.Location = New System.Drawing.Point(37, 94)
        Me.txt_Param.Name = "txt_Param"
        Me.txt_Param.Size = New System.Drawing.Size(693, 26)
        Me.txt_Param.TabIndex = 1
        '
        'dlg_Commands
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 149)
        Me.Controls.Add(Me.txt_Param)
        Me.Controls.Add(Me.cmb_Commands)
        Me.KeyPreview = True
        Me.Name = "dlg_Commands"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlg_Commands"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_Commands As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Param As System.Windows.Forms.TextBox
End Class
