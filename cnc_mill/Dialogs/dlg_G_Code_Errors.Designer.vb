<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_G_Code_Errors
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
        Me.txt_Message = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_OK
        '
        Me.btn_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_OK.Location = New System.Drawing.Point(231, 439)
        Me.btn_OK.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(123, 47)
        Me.btn_OK.TabIndex = 10
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'txt_Message
        '
        Me.txt_Message.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Message.BackColor = System.Drawing.Color.Gold
        Me.txt_Message.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Message.Location = New System.Drawing.Point(13, 13)
        Me.txt_Message.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Message.Multiline = True
        Me.txt_Message.Name = "txt_Message"
        Me.txt_Message.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_Message.Size = New System.Drawing.Size(625, 418)
        Me.txt_Message.TabIndex = 8
        Me.txt_Message.TabStop = False
        '
        'dlg_G_Code_Errors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 519)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.txt_Message)
        Me.Name = "dlg_G_Code_Errors"
        Me.Text = "dlg_G_Code_Errors"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents txt_Message As System.Windows.Forms.TextBox
End Class
