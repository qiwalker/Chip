<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Offset_Check
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
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.txt_Program_Folder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Program_File = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Offset_File = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Offset_Folder = New System.Windows.Forms.TextBox()
        Me.btn_Set_Program = New System.Windows.Forms.Button()
        Me.btn_Set_Offset = New System.Windows.Forms.Button()
        Me.txt_Message = New System.Windows.Forms.TextBox()
        Me.btn_Set_Both = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.Location = New System.Drawing.Point(17, 319)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(123, 47)
        Me.btn_Cancel.TabIndex = 11
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'txt_Program_Folder
        '
        Me.txt_Program_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Program_Folder.Location = New System.Drawing.Point(329, 28)
        Me.txt_Program_Folder.Name = "txt_Program_Folder"
        Me.txt_Program_Folder.Size = New System.Drawing.Size(629, 26)
        Me.txt_Program_Folder.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Program Offset Folder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Program Offset File"
        '
        'txt_Program_File
        '
        Me.txt_Program_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Program_File.Location = New System.Drawing.Point(329, 60)
        Me.txt_Program_File.Name = "txt_Program_File"
        Me.txt_Program_File.Size = New System.Drawing.Size(629, 26)
        Me.txt_Program_File.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(157, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Current Offset File"
        '
        'txt_Offset_File
        '
        Me.txt_Offset_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Offset_File.Location = New System.Drawing.Point(329, 161)
        Me.txt_Offset_File.Name = "txt_Offset_File"
        Me.txt_Offset_File.Size = New System.Drawing.Size(629, 26)
        Me.txt_Offset_File.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(157, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 20)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Current Offset Folder"
        '
        'txt_Offset_Folder
        '
        Me.txt_Offset_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Offset_Folder.Location = New System.Drawing.Point(329, 129)
        Me.txt_Offset_Folder.Name = "txt_Offset_Folder"
        Me.txt_Offset_Folder.Size = New System.Drawing.Size(629, 26)
        Me.txt_Offset_Folder.TabIndex = 16
        '
        'btn_Set_Program
        '
        Me.btn_Set_Program.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Set_Program.Location = New System.Drawing.Point(17, 17)
        Me.btn_Set_Program.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Set_Program.Name = "btn_Set_Program"
        Me.btn_Set_Program.Size = New System.Drawing.Size(123, 74)
        Me.btn_Set_Program.TabIndex = 20
        Me.btn_Set_Program.Text = "Set Program To Current Offset"
        Me.btn_Set_Program.UseVisualStyleBackColor = True
        '
        'btn_Set_Offset
        '
        Me.btn_Set_Offset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Set_Offset.Location = New System.Drawing.Point(17, 118)
        Me.btn_Set_Offset.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Set_Offset.Name = "btn_Set_Offset"
        Me.btn_Set_Offset.Size = New System.Drawing.Size(123, 76)
        Me.btn_Set_Offset.TabIndex = 21
        Me.btn_Set_Offset.Text = "Set Current Offset To Program"
        Me.btn_Set_Offset.UseVisualStyleBackColor = True
        '
        'txt_Message
        '
        Me.txt_Message.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Message.Location = New System.Drawing.Point(329, 215)
        Me.txt_Message.Multiline = True
        Me.txt_Message.Name = "txt_Message"
        Me.txt_Message.Size = New System.Drawing.Size(629, 142)
        Me.txt_Message.TabIndex = 22
        '
        'btn_Set_Both
        '
        Me.btn_Set_Both.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Set_Both.Location = New System.Drawing.Point(17, 215)
        Me.btn_Set_Both.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Set_Both.Name = "btn_Set_Both"
        Me.btn_Set_Both.Size = New System.Drawing.Size(123, 76)
        Me.btn_Set_Both.TabIndex = 23
        Me.btn_Set_Both.Text = "Select Offset file for both."
        Me.btn_Set_Both.UseVisualStyleBackColor = True
        '
        'dlg_Offset_Check
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 382)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Set_Both)
        Me.Controls.Add(Me.txt_Message)
        Me.Controls.Add(Me.btn_Set_Offset)
        Me.Controls.Add(Me.btn_Set_Program)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Offset_File)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_Offset_Folder)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_Program_File)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Program_Folder)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Name = "dlg_Offset_Check"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Offset Check"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents txt_Program_Folder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Program_File As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Offset_File As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Offset_Folder As System.Windows.Forms.TextBox
    Friend WithEvents btn_Set_Program As System.Windows.Forms.Button
    Friend WithEvents btn_Set_Offset As System.Windows.Forms.Button
    Friend WithEvents txt_Message As System.Windows.Forms.TextBox
    Friend WithEvents btn_Set_Both As System.Windows.Forms.Button
End Class
