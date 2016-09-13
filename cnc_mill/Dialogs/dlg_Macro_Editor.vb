Imports System.IO

Public Class dlg_Macro_Editor

    Private Enum enum_Columns
        Prop
        Value
        Type
        Comment
    End Enum

    Private Edited_Symbol As Class_Symbols.class_Symbol

    Private Symbols_Width As Integer
    Private Properties_Width As Integer
    Private Macros_Width As Integer

#Region "Shown, Closing"

    Private Sub dlg_Macro_Editor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Macro_Editor.Finish()
        Me.Hide()
        e.Cancel = True
        Exit Sub
    End Sub

    Private Sub dlg_Macro_Editor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Settings.Set_Form_Size_and_Location(Me)
        ctl_Symbol_Tree.Width = Settings.Get_Control_Setting(ctl_Symbol_Tree, "Width", 200, "Integer")
        grid_Properties.Width = Settings.Get_Control_Setting(grid_Properties, "Width", 200, "Integer")
        Macro_Editor.Initialize()
        ctl_Symbol_Tree.Initialize()
        Me.Refresh()
    End Sub

    Private Sub Hide_Dialog()
        Settings.Save_Form_Size_and_Location(Me)
        Settings.Put_Control_Setting(ctl_Symbol_Tree, "Width", ctl_Symbol_Tree.Width)
        Settings.Put_Control_Setting(grid_Properties, "Width", grid_Properties.Width)
        Symbol.Save_Symbol_Table(Chip_Symbols_File)
        Symbol.Load_Symbol_Table(Chip_Symbols_File)
        Me.Hide()
    End Sub

#End Region

    Public Sub Show_Symbol(Sym As Class_Symbols.class_Symbol)
        Me.Show()
        Edit_Symbol(Sym)
    End Sub

#Region "Toolbar"

    Private Sub ts_Main_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ts_Main.ItemClicked

        Select Case e.ClickedItem.Name

            Case "ts_Exit"
                Hide_Dialog()
        End Select

    End Sub

#End Region

    Private Sub ctl_Symbol_Tree_Symbol_Selected(Sym As Class_Symbols.class_Symbol) Handles ctl_Symbol_Tree.Symbol_Edit
        Edit_Symbol(Sym)
    End Sub

    Private Sub Edit_Symbol(Sym As Class_Symbols.class_Symbol)
        Dim Cols(2) As String
        Dim Prop As Class_Symbols.enum_Properties
        Dim Value As Object = Nothing

        Edited_Symbol = Sym
        grid_Properties.Rows.Clear()

        Cols(0) = Edited_Symbol.Name
        Cols(1) = Edited_Symbol.Value
        Cols(2) = Edited_Symbol.Type.ToString
        grid_Properties.Rows.Add(Cols)

        Select Case Edited_Symbol.Type

            Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label, _
                 Class_Symbols.enum_Symbol_Type.Text_Box, Class_Symbols.enum_Symbol_Type.Check_Box, Class_Symbols.enum_Symbol_Type.Radio_Button

                For Prop = Class_Symbols.enum_Properties.Locked To Class_Symbols.enum_Properties.Comment - 1
                    If Get_Property_Info(Prop, Cols(1), Cols(2)) Then
                        Cols(0) = Prop.ToString
                        Cols(0) = Cols(0).Replace("_", " ")

                        If Edited_Symbol.Type = Class_Symbols.enum_Symbol_Type.Text_Box Then
                            If Prop = Class_Symbols.enum_Properties.Down_Handler Then
                                Cols(0) = "Click Handler"
                            End If
                            If Prop = Class_Symbols.enum_Properties.Up_Handler Then
                                Cols(0) = "Edit Handler"
                            End If
                            If Prop = Class_Symbols.enum_Properties.Back_Color Then
                                Dim C As Color = Color.FromName(Sym.Back_Color)
                                grid_Properties.Rows(0).Cells(1).Style.BackColor = C
                            End If
                            If Prop = Class_Symbols.enum_Properties.Text_Color Then
                                Dim C As Color = Color.FromName(Sym.Text_Color)
                                grid_Properties.Rows(0).Cells(1).Style.ForeColor = C
                            End If
                        Else
                        End If
                        grid_Properties.Rows.Add(Cols)
                    End If
                Next

            Case Else
                For Prop = Class_Symbols.enum_Properties.Locked To Class_Symbols.enum_Properties.No_Edit
                    If Get_Property_Info(Prop, Cols(1), Cols(2)) Then
                        Cols(0) = Prop.ToString
                        Cols(0) = Cols(0).Replace("_", " ")
                        grid_Properties.Rows.Add(Cols)
                    End If
                Next

        End Select

        Cols(0) = "Comment"
        Cols(1) = Edited_Symbol.Comment
        Cols(2) = ""
        grid_Properties.Rows.Add(Cols)
        grid_Properties.Refresh()

    End Sub

    Private Function Get_Property_Info(ByRef Prop As Class_Symbols.enum_Properties, ByRef Value As String, ByRef Type As String) As Boolean

        Select Case Prop

            Case Class_Symbols.enum_Properties.Locked
                Type = "Logical"
                Value = Edited_Symbol.Locked.ToString

            Case Class_Symbols.enum_Properties.Read_Only
                Select Case Edited_Symbol.Type
                    Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label, _
                         Class_Symbols.enum_Symbol_Type.Check_Box, Class_Symbols.enum_Symbol_Type.Radio_Button
                        Return False
                    Case Else
                        Type = "Logical"
                        Value = Edited_Symbol.Read_Only.ToString
                End Select

            Case Class_Symbols.enum_Properties.No_Edit
                Select Case Edited_Symbol.Type
                    Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label, _
                         Class_Symbols.enum_Symbol_Type.Check_Box, Class_Symbols.enum_Symbol_Type.Radio_Button
                        Return False
                    Case Else
                        Type = "Logical"
                        Value = Edited_Symbol.No_Edit.ToString
                End Select

            Case Class_Symbols.enum_Properties.Down_Handler
                If IsNothing(Edited_Symbol.Down_Handler) Then Edited_Symbol.Down_Handler = ""
                Type = "Text"
                Value = Edited_Symbol.Down_Handler.ToString
            Case Class_Symbols.enum_Properties.Up_Handler
                If IsNothing(Edited_Symbol.Up_Handler) Then Edited_Symbol.Up_Handler = ""
                Type = "Text"
                Value = Edited_Symbol.Up_Handler.ToString
            Case Class_Symbols.enum_Properties.Text
                Type = "Text"
                Value = Edited_Symbol.Text.ToString
            Case Class_Symbols.enum_Properties.Up_Image_File
                If Edited_Symbol.Type = Class_Symbols.enum_Symbol_Type.Text_Box Then Return False
                Type = "Text"
                Value = Edited_Symbol.Up_Image_File.ToString
            Case Class_Symbols.enum_Properties.Down_Image_File
                If Edited_Symbol.Type = Class_Symbols.enum_Symbol_Type.Text_Box Then Return False
                Type = "Text"
                Value = Edited_Symbol.Down_Image_File.ToString
            Case Class_Symbols.enum_Properties.Parent
                Type = "Text"
                Value = Edited_Symbol.Parent.ToString
            Case Class_Symbols.enum_Properties.Top
                Type = "Whole"
                Value = Edited_Symbol.Top.ToString
            Case Class_Symbols.enum_Properties.Left
                Type = "Whole"
                Value = Edited_Symbol.Left.ToString
            Case Class_Symbols.enum_Properties.Width
                Type = "Whole"
                Value = Edited_Symbol.Width.ToString
            Case Class_Symbols.enum_Properties.Height
                Type = "Whole"
                Value = Edited_Symbol.Height.ToString
            Case Class_Symbols.enum_Properties.Back_Color
                If Edited_Symbol.Type <> Class_Symbols.enum_Symbol_Type.Text_Box Then Return False
                Type = "Text"
                Value = Edited_Symbol.Back_Color
            Case Class_Symbols.enum_Properties.Text_Color
                If Edited_Symbol.Type <> Class_Symbols.enum_Symbol_Type.Text_Box Then Return False
                Type = "Text"
                Value = Edited_Symbol.Text_Color.ToString
            Case Class_Symbols.enum_Properties.Text_Align
                Dim A As HorizontalAlignment = Edited_Symbol.Text_Align.ToString
                Type = "Text"
                Value = A.ToString
            Case Class_Symbols.enum_Properties.Font
                Type = "Text"
                Value = Edited_Symbol.Font.ToString
            Case Class_Symbols.enum_Properties.Enabled
                Type = "Logical"
                Value = Edited_Symbol.Enabled.ToString
            Case Class_Symbols.enum_Properties.Visible
                Type = "Logical"
                Value = Edited_Symbol.Visible.ToString
            Case Class_Symbols.enum_Properties.Comment
                Type = "Text"
                Value = Edited_Symbol.Comment
            Case Else
                Type = "Error"

        End Select

        Return True

    End Function

    Private Sub Set_Property_Info(ByRef Prop As Class_Symbols.enum_Properties, Value As String)

        Select Case Prop
            Case Class_Symbols.enum_Properties.Value
                Edited_Symbol.Value = Value

                Select Case Edited_Symbol.Type

                    Case Class_Symbols.enum_Symbol_Type.Radio_Button
                        Dim Ctl As RadioButton = Edited_Symbol.Ctrl
                        If Value Then
                            Ctl.Checked = True
                        Else
                            Ctl.Checked = False
                        End If

                    Case Class_Symbols.enum_Symbol_Type.Check_Box
                        Dim Ctl As CheckBox = Edited_Symbol.Ctrl
                        If Value Then
                            Ctl.Checked = True
                        Else
                            Ctl.Checked = False
                        End If

                    Case Class_Symbols.enum_Symbol_Type.Text_Box
                        Dim Ctl As TextBox = Edited_Symbol.Ctrl
                        Edited_Symbol.Value = Value
                        Ctl.Text = Value
                        For I = 0 To grid_Properties.RowCount - 1
                            If grid_Properties.Rows(I).Cells(enum_Columns.Prop).Value = "Text" Then
                                grid_Properties.Rows(I).Cells(enum_Columns.Value).Value = Value
                            End If
                        Next
                End Select

                Dim S() As String = Edited_Symbol.Tree_Node.Text.Split("=")
                Edited_Symbol.Tree_Node.Text = S(0) & "= " & Value
                ctl_Symbol_Tree.Set_Row_Value(Edited_Symbol)

            Case Class_Symbols.enum_Properties.Read_Only
                Edited_Symbol.Read_Only = Value
            Case Class_Symbols.enum_Properties.No_Edit
                Edited_Symbol.No_Edit = Value
            Case Class_Symbols.enum_Properties.Locked
                Edited_Symbol.Locked = Value
            Case Class_Symbols.enum_Properties.Down_Handler
                Edited_Symbol.Down_Handler = Value
            Case Class_Symbols.enum_Properties.Up_Handler
                Edited_Symbol.Up_Handler = Value
            Case Class_Symbols.enum_Properties.Text
                Edited_Symbol.Text = Value

                Select Case Edited_Symbol.Type
                    Case Class_Symbols.enum_Symbol_Type.Radio_Button
                        Dim Ctl As RadioButton = Edited_Symbol.Ctrl
                        Ctl.Text = Value
                    Case Class_Symbols.enum_Symbol_Type.Check_Box
                        Dim Ctl As CheckBox = Edited_Symbol.Ctrl
                        Ctl.Text = Value
                    Case Class_Symbols.enum_Symbol_Type.Text_Box
                        Dim Ctl As TextBox = Edited_Symbol.Ctrl
                        Ctl.Text = Value
                        grid_Properties.Rows(0).Cells(enum_Columns.Value).Value = Value
                End Select

            Case Class_Symbols.enum_Properties.Up_Image_File
                Edited_Symbol.Up_Image_File = Value
            Case Class_Symbols.enum_Properties.Down_Image_File
                Edited_Symbol.Down_Image_File = Value
            Case Class_Symbols.enum_Properties.Parent
                Edited_Symbol.Parent = Value
            Case Class_Symbols.enum_Properties.Top
                Edited_Symbol.Top = Value
            Case Class_Symbols.enum_Properties.Left
                Edited_Symbol.Left = Value
            Case Class_Symbols.enum_Properties.Width
                Edited_Symbol.Width = Value
            Case Class_Symbols.enum_Properties.Height
                Edited_Symbol.Height = Value
            Case Class_Symbols.enum_Properties.Back_Color
                Edited_Symbol.Change_Back_Color(Value)

            Case Class_Symbols.enum_Properties.Text_Color
                Edited_Symbol.Change_Text_Color(Value)
            Case Class_Symbols.enum_Properties.Text_Align
                Edited_Symbol.Text_Align = Value
            Case Class_Symbols.enum_Properties.Font
                Edited_Symbol.Font = Value
            Case Class_Symbols.enum_Properties.Enabled
                Edited_Symbol.Enabled = Value
            Case Class_Symbols.enum_Properties.Visible
                Edited_Symbol.Visible = Value
            Case Class_Symbols.enum_Properties.Comment
                Edited_Symbol.Comment = Value
        End Select

    End Sub

    Private Sub grid_Properties_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_Properties.CellEndEdit
        If e.RowIndex = 0 Then
            Set_Property_Info(Class_Symbols.enum_Properties.Value, grid_Properties.CurrentRow.Cells(enum_Columns.Value).Value)
        Else
            Select Case grid_Properties.CurrentRow.Cells(enum_Columns.Prop).Value
                Case "Click Handler"
                    Edited_Symbol.Down_Handler = grid_Properties.CurrentRow.Cells(enum_Columns.Value).Value
                Case "Edit Handler"
                    Edited_Symbol.Up_Handler = grid_Properties.CurrentRow.Cells(enum_Columns.Value).Value
                Case "Down Handler"
                    Edited_Symbol.Down_Handler = grid_Properties.CurrentRow.Cells(enum_Columns.Value).Value
                Case "Up Handler"
                    Edited_Symbol.Up_Handler = grid_Properties.CurrentRow.Cells(enum_Columns.Value).Value
                Case Else
                    Dim Idx = Symbol.Property_Index(grid_Properties.CurrentRow.Cells(enum_Columns.Prop).Value)
                    Set_Property_Info(Idx, grid_Properties.CurrentRow.Cells(enum_Columns.Value).Value)
            End Select

        End If

    End Sub

    Private Sub grid_Properties_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_Properties.CellClick
        Dim New_Value_Text = Edited_Symbol.Value

        If e.RowIndex = 1 Then
            Message_Box.ShowDialog("Locking is for System variables so they cannot be deleted." & vbCrLf & _
                                   "These properties are used by the system. The lock property" & vbCrLf & _
                                   "On these properties cannot be changed.")
            Exit Sub
        End If


        If e.RowIndex > 0 And grid_Properties.Rows(1).Cells(enum_Columns.Prop).Value = "Locked" And _
             grid_Properties.Rows(1).Cells(enum_Columns.Value).Value = "True" Then
            Message_Box.ShowDialog("These properties are locked by the system and cannot be changed," & vbCrLf & _
                                   "however the value property can be changed.")
            Exit Sub
        End If

        Select Case grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Type).Value

            Case "Whole", "Real", "Text", "TinyG_Setting", "GCode", "Text_Box"
                grid_Properties.BeginEdit(False)

            Case "Logical", "Button", "Toggle", "Check Box", "Radio Button", "Label"
                If grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "True" Then
                    grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "False"
                Else
                    grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "True"
                End If

                Dim P As String = grid_Properties.CurrentRow.Cells(enum_Columns.Prop).Value
                P = P.Replace(" ", "_")
                Dim Idx = Symbol.Property_Index(P)
                Set_Property_Info(Idx, grid_Properties.CurrentRow.Cells(enum_Columns.Value).Value)

            Case "Color"
                Dim dlg As New dlg_Color_Picker
                dlg.Color_Name = Edited_Symbol.Back_Color
                dlg.ShowDialog()
                If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = dlg.Color_Name
                    grid_Properties.Rows(0).Cells(enum_Columns.Value).Style.BackColor = dlg.Color
                    Set_Property_Info(Class_Symbols.enum_Properties.Value, dlg.Color_Name)
                End If

        End Select

        Select Case grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Prop).Value
            Case "Back Color"
                Dim dlg As New dlg_Color_Picker
                dlg.Color_Name = Edited_Symbol.Back_Color
                dlg.ShowDialog()
                If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = dlg.Color_Name
                    grid_Properties.Rows(0).Cells(enum_Columns.Value).Style.BackColor = dlg.Color
                    Set_Property_Info(Class_Symbols.enum_Properties.Back_Color, dlg.Color_Name)
                End If
                grid_Properties.EndEdit()

            Case "Text Color"
                Dim dlg As New dlg_Color_Picker
                dlg.Color_Name = Edited_Symbol.Text_Color
                dlg.ShowDialog()
                If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = dlg.Color_Name
                    grid_Properties.Rows(0).Cells(enum_Columns.Value).Style.ForeColor = dlg.Color
                    Set_Property_Info(Class_Symbols.enum_Properties.Text_Color, dlg.Color_Name)
                End If
                grid_Properties.EndEdit()


            Case "Up Image File", "Down Image File"
                Dim dlg As New OpenFileDialog
                If Controller.Check_For_In_Cycle("Cannot change Offsets while in cycle") Then Exit Sub
                dlg.InitialDirectory = Chip_Images_Folder
                dlg.Filter = "Image Files (*.png)|*.png|All files (*.*)|*.*"

                Select Case grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Prop).Value
                    Case "Up Image File"
                        dlg.FileName = Edited_Symbol.Up_Image_File
                    Case "Down Image File"
                        dlg.FileName = Edited_Symbol.Down_Image_File
                End Select

                If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Select Case grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Prop).Value
                        Case "Up Image File"
                            Edited_Symbol.Up_Image_File = Path.GetFileName(dlg.FileName)
                            Edited_Symbol.Load_Image_File(Edited_Symbol.Up_Image_File)
                        Case "Down Image File"
                            Edited_Symbol.Down_Image_File = Path.GetFileName(dlg.FileName)
                            Edited_Symbol.Load_Image_File(Edited_Symbol.Down_Image_File)
                    End Select
                    grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = Path.GetFileName(dlg.FileName)
                End If
                grid_Properties.EndEdit()

            Case "Top", "Left", "Height", "Width"
                Dim dlg As New dlg_Control_Size_Location
                dlg.Sym = Edited_Symbol
                dlg.ShowDialog()

                For R = 0 To grid_Properties.RowCount - 1
                    Select Case grid_Properties.Rows(R).Cells(0).Value
                        Case "Top"
                            grid_Properties.Rows(R).Cells(1).Value = dlg.Ctrl_Top
                        Case "Left"
                            grid_Properties.Rows(R).Cells(1).Value = dlg.Ctrl_Left
                        Case "Width"
                            grid_Properties.Rows(R).Cells(1).Value = dlg.Ctrl_Width
                        Case "Height"
                            grid_Properties.Rows(R).Cells(1).Value = dlg.Ctrl_Height
                    End Select
                Next

            Case "Text Align"

                Select Case Edited_Symbol.Type
                    Case Class_Symbols.enum_Symbol_Type.Text_Box
                        Select Case grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value
                            Case "Left"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "Right"
                                Edited_Symbol.Text_Align = HorizontalAlignment.Right
                            Case "Right"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "Center"
                                Edited_Symbol.Text_Align = HorizontalAlignment.Center
                            Case "Center"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "Left"
                                Edited_Symbol.Text_Align = HorizontalAlignment.Left
                        End Select

                    Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label, _
                         Class_Symbols.enum_Symbol_Type.Check_Box, Class_Symbols.enum_Symbol_Type.Radio_Button

                        Dim c As ContentAlignment
                        Select Case c
                            Case "TopLeft"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "TopCenter"
                                Edited_Symbol.Text_Align = ContentAlignment.TopCenter
                            Case "TopCenter"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "TopRight"
                                Edited_Symbol.Text_Align = ContentAlignment.TopRight
                            Case "TopRight"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "MiddleLeft"
                                Edited_Symbol.Text_Align = ContentAlignment.MiddleLeft
                            Case "MiddleLeft"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "MiddleCenter"
                                Edited_Symbol.Text_Align = ContentAlignment.MiddleCenter
                            Case "MiddleCenter"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "MiddleRight"
                                Edited_Symbol.Text_Align = ContentAlignment.MiddleRight
                            Case "MiddleRight"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "BottomLeft"
                                Edited_Symbol.Text_Align = ContentAlignment.BottomLeft
                            Case "BottomLeft"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "BottomCenter"
                                Edited_Symbol.Text_Align = ContentAlignment.BottomCenter
                            Case "BottomCenter"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "BottomRight"
                                Edited_Symbol.Text_Align = ContentAlignment.BottomRight
                            Case "BottomRight"
                                grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = "TopLeft"
                                Edited_Symbol.Text_Align = ContentAlignment.TopLeft
                        End Select
                End Select

                grid_Properties.EndEdit()

            Case "Font"
                Dim Fnt As String = grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value
                Dim S() As String = Fnt.Split(",")
                Dim dlg As New FontDialog
                Dim F As Font
                Dim Style As FontStyle

                Select Case S(2)
                    Case "Regular"
                        Style = FontStyle.Regular
                    Case "Bold"
                        Style = FontStyle.Bold
                    Case "Italit"
                        Style = FontStyle.Italic
                    Case "Underline"
                        Style = FontStyle.Underline
                    Case "Strikeout"
                        Style = FontStyle.Strikeout
                End Select
                F = New Font(S(0), CSng(S(1)), Style)
                dlg.Font = F
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Edited_Symbol.Font = dlg.Font.Name & "," & dlg.Font.Size & "," & dlg.Font.Style.ToString
                    grid_Properties.Rows(e.RowIndex).Cells(enum_Columns.Value).Value = Edited_Symbol.Font
                End If

                grid_Properties.EndEdit()
        End Select

    End Sub

   
End Class