<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Process_Insert_Step
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
        Me.btn_GCode_Block = New System.Windows.Forms.Button()
        Me.btn_Tool_Change = New System.Windows.Forms.Button()
        Me.btn_Go_To_Position = New System.Windows.Forms.Button()
        Me.btn_Load_Program = New System.Windows.Forms.Button()
        Me.btn_Optional_Stop = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.txt_GCode_Block = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Pause = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Block_List = New System.Windows.Forms.ListBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btn_GCode_Block
        '
        Me.btn_GCode_Block.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GCode_Block.Location = New System.Drawing.Point(12, 197)
        Me.btn_GCode_Block.Name = "btn_GCode_Block"
        Me.btn_GCode_Block.Size = New System.Drawing.Size(113, 27)
        Me.btn_GCode_Block.TabIndex = 0
        Me.btn_GCode_Block.Text = "G Code Block"
        Me.btn_GCode_Block.UseVisualStyleBackColor = True
        '
        'btn_Tool_Change
        '
        Me.btn_Tool_Change.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Tool_Change.Location = New System.Drawing.Point(12, 62)
        Me.btn_Tool_Change.Name = "btn_Tool_Change"
        Me.btn_Tool_Change.Size = New System.Drawing.Size(113, 27)
        Me.btn_Tool_Change.TabIndex = 1
        Me.btn_Tool_Change.Text = "Tool Change"
        Me.btn_Tool_Change.UseVisualStyleBackColor = True
        '
        'btn_Go_To_Position
        '
        Me.btn_Go_To_Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Go_To_Position.Location = New System.Drawing.Point(12, 107)
        Me.btn_Go_To_Position.Name = "btn_Go_To_Position"
        Me.btn_Go_To_Position.Size = New System.Drawing.Size(113, 27)
        Me.btn_Go_To_Position.TabIndex = 2
        Me.btn_Go_To_Position.Text = "Go To Position"
        Me.btn_Go_To_Position.UseVisualStyleBackColor = True
        '
        'btn_Load_Program
        '
        Me.btn_Load_Program.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Load_Program.Location = New System.Drawing.Point(12, 152)
        Me.btn_Load_Program.Name = "btn_Load_Program"
        Me.btn_Load_Program.Size = New System.Drawing.Size(113, 27)
        Me.btn_Load_Program.TabIndex = 3
        Me.btn_Load_Program.Text = "Load Program"
        Me.btn_Load_Program.UseVisualStyleBackColor = True
        '
        'btn_Optional_Stop
        '
        Me.btn_Optional_Stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Optional_Stop.Location = New System.Drawing.Point(12, 242)
        Me.btn_Optional_Stop.Name = "btn_Optional_Stop"
        Me.btn_Optional_Stop.Size = New System.Drawing.Size(113, 27)
        Me.btn_Optional_Stop.TabIndex = 4
        Me.btn_Optional_Stop.Text = "Optional Stop"
        Me.btn_Optional_Stop.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(143, 65)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(261, 26)
        Me.ComboBox1.TabIndex = 5
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(143, 110)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(261, 26)
        Me.ComboBox2.TabIndex = 6
        '
        'txt_GCode_Block
        '
        Me.txt_GCode_Block.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GCode_Block.Location = New System.Drawing.Point(143, 200)
        Me.txt_GCode_Block.Name = "txt_GCode_Block"
        Me.txt_GCode_Block.Size = New System.Drawing.Size(261, 24)
        Me.txt_GCode_Block.TabIndex = 8
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(12, 381)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(135, 27)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "Set Offset X"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(151, 381)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(135, 27)
        Me.Button7.TabIndex = 10
        Me.Button7.Text = "Set Offset Y"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(290, 381)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(135, 27)
        Me.Button8.TabIndex = 11
        Me.Button8.Text = "Set OffsetZ"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_OK.Location = New System.Drawing.Point(76, 462)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(113, 54)
        Me.btn_OK.TabIndex = 12
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.Location = New System.Drawing.Point(237, 462)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(113, 54)
        Me.btn_Cancel.TabIndex = 13
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Pause
        '
        Me.btn_Pause.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Pause.Location = New System.Drawing.Point(12, 283)
        Me.btn_Pause.Name = "btn_Pause"
        Me.btn_Pause.Size = New System.Drawing.Size(113, 27)
        Me.btn_Pause.TabIndex = 14
        Me.btn_Pause.Text = "Pause"
        Me.btn_Pause.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(143, 243)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(261, 24)
        Me.TextBox3.TabIndex = 15
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(143, 284)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(261, 24)
        Me.TextBox4.TabIndex = 16
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(143, 25)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(261, 26)
        Me.ComboBox3.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 27)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Setup Instructions"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Block_List
        '
        Me.Block_List.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Block_List.FormattingEnabled = True
        Me.Block_List.ItemHeight = 18
        Me.Block_List.Location = New System.Drawing.Point(438, 26)
        Me.Block_List.Name = "Block_List"
        Me.Block_List.Size = New System.Drawing.Size(356, 490)
        Me.Block_List.TabIndex = 19
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(39, 417)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(81, 24)
        Me.TextBox2.TabIndex = 20
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(178, 417)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(81, 24)
        Me.TextBox5.TabIndex = 21
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(317, 417)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(81, 24)
        Me.TextBox6.TabIndex = 22
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 343)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 27)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Current XYZ"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(151, 343)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(135, 27)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Current Offsets"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(290, 343)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(135, 27)
        Me.Button4.TabIndex = 25
        Me.Button4.Text = "Clear"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(143, 153)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(261, 26)
        Me.ComboBox4.TabIndex = 26
        '
        'dlg_Process_Insert_Step
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 534)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Block_List)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.btn_Pause)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.txt_GCode_Block)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btn_Optional_Stop)
        Me.Controls.Add(Me.btn_Load_Program)
        Me.Controls.Add(Me.btn_Go_To_Position)
        Me.Controls.Add(Me.btn_Tool_Change)
        Me.Controls.Add(Me.btn_GCode_Block)
        Me.Name = "dlg_Process_Insert_Step"
        Me.Text = "Insert Process Step"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_GCode_Block As System.Windows.Forms.Button
    Friend WithEvents btn_Tool_Change As System.Windows.Forms.Button
    Friend WithEvents btn_Go_To_Position As System.Windows.Forms.Button
    Friend WithEvents btn_Load_Program As System.Windows.Forms.Button
    Friend WithEvents btn_Optional_Stop As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_GCode_Block As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Pause As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Block_List As System.Windows.Forms.ListBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
End Class
