<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Input
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
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.txt_Input = New System.Windows.Forms.TextBox()
        Me.btn_Default = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(52, 109)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(95, 52)
        Me.btn_OK.TabIndex = 1
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(220, 109)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(95, 52)
        Me.btn_Cancel.TabIndex = 2
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'txt_Input
        '
        Me.txt_Input.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Input.Location = New System.Drawing.Point(32, 32)
        Me.txt_Input.Name = "txt_Input"
        Me.txt_Input.Size = New System.Drawing.Size(345, 26)
        Me.txt_Input.TabIndex = 3
        '
        'btn_Default
        '
        Me.btn_Default.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Default.Location = New System.Drawing.Point(383, 27)
        Me.btn_Default.Name = "btn_Default"
        Me.btn_Default.Size = New System.Drawing.Size(136, 37)
        Me.btn_Default.TabIndex = 4
        Me.btn_Default.Text = "Default"
        Me.btn_Default.UseVisualStyleBackColor = True
        '
        'dlg_Input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 178)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Default)
        Me.Controls.Add(Me.txt_Input)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.KeyPreview = True
        Me.Name = "dlg_Input"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents txt_Input As System.Windows.Forms.TextBox
    Friend WithEvents btn_Default As System.Windows.Forms.Button
End Class
