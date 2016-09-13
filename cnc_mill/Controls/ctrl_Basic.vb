
Public Class ctrl_Basic

#Region "Events"

    Public Event Changed(Symbol As class_Symbol_Table_OLD.Class_Symbol)


#End Region

#Region "Declarations"

    Public Control_Type As class_Symbol_Table_OLD.enum_Ctrl_Type
    Public Images As New List(Of Bitmap)

    Public Target_Control As Control = Nothing
    Public Parent_Form_Control As ctrl_Form
    Private Parent_Control As Control

    Private Down As Boolean = False
    Private Up As Boolean = True
    Private ctrl_Name As String
    Private Image_Index As Integer
    Private Transparent_Color As New Color

    Private Symbol As class_Symbol_Table_OLD.Class_Symbol

    Private Default_Font As String = "Microsoft Sans Serif,10,Regular"

#End Region

#Region "New"

    Public Sub New()
        InitializeComponent()
        Label_Box.Visible = False
        Button.Visible = False
        Text_Box.Visible = False
        Combo_Box.Visible = False
        Check_Box.Visible = False
        Slider.Visible = False
        Image_Box.Visible = False
        List_Box.Visible = False
    End Sub

#End Region

#Region "Initialize"

    Public Sub Initialize(ByRef Symbol_Pointer As class_Symbol_Table_OLD.Class_Symbol, Control_Form As ctrl_Form, ParCon As Control, New_Control As Boolean)
        Dim Type_Text As String = ""

        Parent_Form_Control = Control_Form
        Parent_Control = ParCon

        Symbol = Symbol_Pointer
        Symbol.Symbol_Type = class_Symbol_Table_OLD.enum_Symbol_Type.Control

        Me.Name = Symbol.Name

        ctrl_Name = Symbol.Name
        Control_Type = Symbol.Control.Control_Type

        Label_Box.Visible = False
        Button.Visible = False
        Text_Box.Visible = False
        Check_Box.Visible = False
        Slider.Visible = False
        Image_Box.Visible = False
        List_Box.Visible = False

        Transparent_Color = Color.FromArgb(255, 255, 0, 255)
        Me.BackColor = Color.Transparent

        Select Case Control_Type

            Case class_Symbol_Table_OLD.enum_Ctrl_Type.Button
                Target_Control = Button
                Button.Visible = True
                Type_Text = "BUTTON"
                If Not IsNothing(Symbol.Image_File) Then
                    Dim Bmp As Bitmap = New Bitmap(CNC_Images & Symbol.Image_File)
                    Target_Control.BackgroundImageLayout = ImageLayout.Stretch
                    Target_Control.BackgroundImage = Bmp
                End If
                If New_Control Then
                    Set_Color()
                    Symbol.Width = Button.Width
                    Symbol.Height = Button.Height
                End If

            Case class_Symbol_Table_OLD.enum_Ctrl_Type.Label
                Target_Control = Label_Box
                Label_Box.Visible = True
                Type_Text = "LABEL"
                If New_Control Then
                    Set_Color()
                    Symbol.Width = Label_Box.Width
                    Symbol.Height = Label_Box.Height
                End If

            Case class_Symbol_Table_OLD.enum_Ctrl_Type.Text_Box
                Target_Control = Text_Box
                Text_Box.Visible = True
                Type_Text = "TEXT_BOX"
                If New_Control Then
                    Set_Color()
                    Symbol.Width = Text_Box.Width
                    Symbol.Height = Text_Box.Height
                End If

            Case class_Symbol_Table_OLD.enum_Ctrl_Type.Menu
                Target_Control = Combo_Box
                Combo_Box.Visible = True
                Type_Text = "MENU"
                If New_Control Then
                    Set_Color()
                    Symbol.Width = Combo_Box.Width
                    Symbol.Height = Combo_Box.Height
                End If

            Case class_Symbol_Table_OLD.enum_Ctrl_Type.Check_Box
                Target_Control = Check_Box
                Check_Box.Visible = True
                Type_Text = "CHECK_BOX"
                If New_Control Then
                    Set_Color()
                    Symbol.Width = Check_Box.Width
                    Symbol.Height = Check_Box.Height
                End If

            Case class_Symbol_Table_OLD.enum_Ctrl_Type.Track_Bar
                Target_Control = Slider
                Slider.Visible = True
                Type_Text = "TRACK_BAR"
                If New_Control Then
                    Set_Color()
                    Symbol.Width = Slider.Width
                    Symbol.Height = Slider.Height
                End If

            Case class_Symbol_Table_OLD.enum_Ctrl_Type.Image_Box
                Target_Control = Image_Box
                Image_Box.Visible = True
                Type_Text = "IMAGE_BOX"
                If Not IsNothing(Symbol.Image_File) Then
                    Dim Bmp As Bitmap = New Bitmap(CNC_Images & Symbol.Image_File)
                    Target_Control.BackgroundImageLayout = ImageLayout.Stretch
                    Target_Control.BackgroundImage = Bmp
                End If
                If New_Control Then
                    Set_Color()
                    Symbol.Width = Image_Box.Width
                    Symbol.Height = Image_Box.Height
                End If

        End Select

        Target_Control.Tag = Symbol
        Target_Control.Top = 0
        Target_Control.Left = 0

        Set_Properties()

    End Sub

    Private Sub Set_Color()
        Symbol.Back_Color = Target_Control.BackColor.ToString
        Symbol.Back_Color = Symbol.Back_Color.Replace("Color [", "")
        Symbol.Back_Color = Symbol.Back_Color.Replace("]", "")
        Symbol.Fore_Color = Target_Control.ForeColor.ToString
        Symbol.Fore_Color = Symbol.Fore_Color.Replace("Color [", "")
        Symbol.Fore_Color = Symbol.Fore_Color.Replace("]", "")
    End Sub

    Private Sub Set_Width(W As Integer)
        Symbol.Width += W
        Me.Width = Symbol.Width
        Target_Control.Width = Symbol.Width
    End Sub

    Private Sub Set_Height(H As Integer)
        Symbol.Height += H
        Me.Width = Symbol.Height
        Target_Control.Height = Symbol.Height
    End Sub


    Public Sub Set_Properties()

        Target_Control.Width = Symbol.Width
        Target_Control.Height = Symbol.Height

        Me.Top = Symbol.Top
        Me.Left = Symbol.Left
        Me.Width = Symbol.Width
        Me.Height = Symbol.Height

        Target_Control.Text = Symbol.Text
        Target_Control.BackColor = Drawing.Color.FromName(Symbol.Back_Color)
        Target_Control.ForeColor = Drawing.Color.FromName(Symbol.Fore_Color)

        'Target_Control.Font.Name
        'Target_Control.Font.Size

        If Symbol.Control.Control_Type = class_Symbol_Table_OLD.enum_Ctrl_Type.Track_Bar Then
            Symbol.Data_Type = "INTEGER"
            Slider.Value = Symbol.Value
            Slider.Minimum = Symbol.Minimum
            Slider.Maximum = Symbol.Maximum
        Else
            Symbol.Data_Type = "BOOL"
            If Symbol.Choices.Count = 0 Then
                Symbol.Choices.Add("UP")
                Symbol.Choices.Add("DOWN")
            End If
            Target_Control.Text = Symbol.Text
        End If

        'Slider.Minimum = Symbol.Minimum
        'Slider.Maximum = Symbol.Maximum
        'Slider.Value = Symbol.Value

        Me.Visible = True

    End Sub


#End Region

#Region "Keyboard Handler"

    'Public Shared Sub Key_Preview(Key_Args As KeyEventArgs)

    '    If Selected_Controls.Count = 0 Then Exit Sub
    '    Dim Inc As Integer = 1
    '    If Key_Args.Shift Then Inc = 10

    '    For C = 0 To Selected_Controls.Count - 1

    '        Select Case Key_Args.KeyValue

    '            Case Keys.Up

    '                If Key_Args.Control Then

    '                    If Selected_Controls(C).Ctrl.Height - Inc > 10 Then
    '                        Selected_Controls(C).Ctrl.Height -= Inc
    '                    End If

    '                    'Select Case Selected_Controls(C).Parent.Ctrl_Type

    '                    '    Case ctrl_Form.enum_Ctrl_Type.Label
    '                    '        If Key_Args.Control Then
    '                    '            Dim Fnt As Font
    '                    '            Fnt = Selected_Controls(C).Ctrl.Font
    '                    '            Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size + Inc)
    '                    '        End If

    '                    '    Case Else

    '                    'End Select

    '                ElseIf Key_Args.Alt Then

    '                    Dim Fnt As Font
    '                    Fnt = Selected_Controls(C).Ctrl.Font
    '                    Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size + Inc)

    '                Else
    '                    If Selected_Controls(C).Parent.Top > 0 Then
    '                        Selected_Controls(C).Parent.Top -= Inc
    '                    End If
    '                End If

    '            Case Keys.Down

    '                If Key_Args.Control Then
    '                    Selected_Controls(C).Ctrl.Height += Inc

    '                    'Select Case Selected_Controls(C).Parent.Ctrl_Type

    '                    '    Case ctrl_Form.enum_Ctrl_Type.Label ', ctrl_Form.enum_Ctrl_Type.Text_Box, ctrl_Form.enum_Ctrl_Type.Check_Box, ctrl_Form.enum_Ctrl_Type.Combo_Box
    '                    '        If Key_Args.Control Then
    '                    '            Dim Fnt As Font
    '                    '            Fnt = Selected_Controls(C).Ctrl.Font
    '                    '            If Fnt.Size > 8 Then
    '                    '                Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size - Inc)
    '                    '            End If
    '                    '        End If

    '                    '    Case Else
    '                    '        Selected_Controls(C).Ctrl.Height += Inc
    '                    'End Select

    '                ElseIf Key_Args.Alt Then
    '                    Dim Fnt As Font
    '                    Fnt = Selected_Controls(C).Ctrl.Font
    '                    If Fnt.Size > 8 Then
    '                        Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size - Inc)
    '                    End If
    '                Else
    '                    Selected_Controls(C).Parent.Top += Inc
    '                End If

    '            Case Keys.Left
    '                If Key_Args.Control Then
    '                    If Selected_Controls(C).Ctrl.Width - Inc > 10 Then
    '                        Selected_Controls(C).Ctrl.Width -= Inc
    '                    End If
    '                Else
    '                    If Selected_Controls(C).Parent.Left > 0 Then
    '                        Selected_Controls(C).Parent.Left -= Inc
    '                    End If
    '                End If

    '            Case Keys.Right
    '                If Key_Args.Control Then
    '                    Selected_Controls(C).Ctrl.Width += Inc
    '                Else
    '                    Selected_Controls(C).Parent.Left += Inc
    '                End If


    '        End Select

    '        Selected_Controls(C).Parent.Height = Selected_Controls(C).Ctrl.Height
    '        Selected_Controls(C).Parent.Width = Selected_Controls(C).Ctrl.Width
    '    Next

    'End Sub

#End Region

#Region "Methods"

    'Combo box methods
    Public Sub Add_Menu_Item(Text As String)
        Combo_Box.Items.Add(Text)
    End Sub

    Public Sub Select_Button_Image(Index As Integer)
        If Images.Count > 0 Then
            Image_Index = Index
            Button.BackgroundImage = Images(Image_Index)
        End If
    End Sub

    'Image box methods
    Public Sub Add_Image(File_Name As String)
        Dim BM As Bitmap = New Bitmap(File_Name)
        BM.MakeTransparent(Transparent_Color)
        Images.Add(BM)
    End Sub

    Public Sub Select_Image(Index As Integer)
        Label_Box.BackColor = Color.Transparent
        If Images.Count > 0 Then
            Image_Index = Index
            Image_Box.Image = Images(Image_Index)
        End If
    End Sub

    Public Function Current_Image() As Integer
        If Images.Count > 0 Then
            Return Image_Index
        End If
        Return -1
    End Function

#End Region

#Region "Edit Mode Event Handlers"

    Private Dragging As Boolean = False
    Private Windowing As Boolean = False
    Private Start_Point As Point
    Private Last_Delta As Point
    Private Last_Move_Pt As Point

    Public Sub Mouse_Wheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button.MouseWheel

        If Parent_Form_Control.Design_Mode Then

            If e.Delta < 0 Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Set_Width(-1)
                End If
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Set_Height(-1)
                End If
            End If

            If e.Delta > 0 Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Set_Width(+1)
                End If
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Set_Height(1)
                End If
            End If

        End If

        'If IsNothing(Selected_Control) Then Exit Sub

        'Select Case e.Button
        '    Case Windows.Forms.MouseButtons.None
        '        If e.Delta > 0 Then
        '            Selected_Control.Height += 1
        '        Else
        '            If Selected_Control.Height > 10 Then
        '                Selected_Control.Height -= 1
        '            End If
        '        End If
        '        Parent_Selected_Control.Height = Selected_Control.Height

        '    Case Windows.Forms.MouseButtons.Right
        '        If e.Delta > 0 Then
        '            Selected_Control.Width += 1
        '        Else
        '            If Selected_Control.Width > 10 Then
        '                Selected_Control.Width -= 1
        '            End If
        '        End If
        '        Parent_Selected_Control.Width = Selected_Control.Width

        'End Select

    End Sub

    'Public Sub Mouse_Enter(sender As Object, e As System.EventArgs) Handles Label.MouseEnter, Button.MouseEnter, ComboBox.MouseEnter, CheckBox.MouseEnter, TrackBar.MouseEnter, PictureBox.MouseEnter
    '    Parent_Selected_Control = sender.parent
    '    Selected_Control = sender
    '    Selected_Control_Backcolor = sender.BackColor
    '    sender.Backcolor = Color.Magenta
    'End Sub

    'Public Sub Mouse_Leave(sender As Object, e As System.EventArgs) Handles Label.MouseLeave, Button.MouseLeave, ComboBox.MouseLeave, CheckBox.MouseLeave, TrackBar.MouseLeave, PictureBox.MouseLeave
    '    sender.BackColor = Selected_Control_Backcolor
    '    Selected_Control = Nothing
    '    Parent_Selected_Control = Nothing
    'End Sub


    'Private Sub Parent_Panel_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Parent_Panel.MouseDown

    '    For I = 0 To Selected_Controls.Count - 1
    '        Selected_Controls(I).Ctrl.BackColor = Selected_Controls(I).Back_Color
    '        Canvas_Rectangle.X = Selected_Controls(I).Ctrl.Left
    '        Canvas_Rectangle.Y = Selected_Controls(I).Ctrl.Top
    '        Canvas_Rectangle.Width = Selected_Controls(I).Ctrl.Width
    '        Canvas_Rectangle.Height = Selected_Controls(I).Ctrl.Height


    '        ControlPaint.DrawReversibleFrame(Canvas_Rectangle, sender.BackColor, FrameStyle.Dashed)

    '        Selected_Controls(I).Ctrl.Refresh()
    '    Next

    '    Selected_Controls.Clear()
    'End Sub

    'Private Sub Add_Selected_Control(Ctrl As Control)

    '    For I = 0 To Selected_Controls.Count - 1
    '        If Selected_Controls(I).Ctrl Is Ctrl Then
    '            Selected_Controls(I).Ctrl.BackColor = Selected_Controls(I).Back_Color
    '            Selected_Controls(I).Ctrl.Refresh()
    '            Selected_Controls.Remove(Selected_Controls(I))
    '            Exit Sub
    '        End If
    '    Next

    '    Dim Sel As New struct_Selected_Control
    '    Sel.Parent = Ctrl.Parent
    '    Sel.Ctrl = Ctrl
    '    Sel.Back_Color = Sel.Ctrl.BackColor
    '    Ctrl.BackColor = Color.Magenta
    '    Selected_Controls.Add(Sel)
    'End Sub

    Public Sub Mouse_Down_Events(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles _
                                 Label_Box.MouseDown, Button.MouseDown, Text_Box.MouseDown, Combo_Box.MouseDown, _
                                 Check_Box.MouseDown, Slider.MouseDown, Image_Box.MouseDown, List_Box.MouseDown

        If Parent_Form_Control.Design_Mode Then

            Parent_Form_Control.Add_Selected_Control(sender)

            If (e.Button = MouseButtons.Left) Then Dragging = True
            If (e.Button = MouseButtons.Right) Then Windowing = True

            If Dragging And Windowing Then
                Dragging = False
                Windowing = False
                Exit Sub
            End If

            Dim control As Control = CType(sender, Control)
            Start_Point = control.PointToScreen(New Point(e.X, e.Y))

            If Dragging Then
                Last_Move_Pt.X = e.X
                Last_Move_Pt.Y = e.Y
                Last_Delta.X = 0
                Last_Delta.Y = 0
            End If

        Else
            Down = True
            Up = False
            RaiseEvent Changed(Symbol)
        End If

    End Sub

    Public Sub Mouse_Up_Events(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles _
                               Label_Box.MouseUp, Button.MouseUp, Text_Box.MouseUp, Combo_Box.MouseUp, _
                               Check_Box.MouseUp, Slider.MouseUp, Image_Box.MouseUp, List_Box.MouseUp

        If Parent_Form_Control.Design_Mode Then
            If (e.Button = MouseButtons.Left) Then
                Dim Sym As class_Symbol_Table_OLD.Class_Symbol
                Sym = sender.tag
                Sym.Top = Sym.Control.Top
                Sym.Left = Sym.Control.Left
                Dragging = False
            End If

            If (e.Button = MouseButtons.Right) Then
                Windowing = False
            End If
        Else
            Down = False
            Up = True
            RaiseEvent Changed(Symbol)
        End If

    End Sub

    Private Sub Mouse_Move_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _
                                   Label_Box.MouseMove, Button.MouseMove, Text_Box.MouseMove, Combo_Box.MouseMove, _
                                   Check_Box.MouseMove, Slider.MouseMove, Image_Box.MouseMove, List_Box.MouseMove

        If (Dragging) Then
            Last_Delta.X = e.X - Last_Move_Pt.X
            Last_Delta.Y = e.Y - Last_Move_Pt.Y

            Me.Left += Last_Delta.X
            Me.Top += Last_Delta.Y

            Symbol.Left = Me.Left
            Symbol.Top = Me.Top

            Last_Move_Pt.X = e.X - Last_Delta.X
            Last_Move_Pt.Y = e.Y - Last_Delta.Y
        End If

        If Windowing Then
            '' Hide the previous rectangle by calling the DrawReversibleFrame  
            '' method with the same parameters.
            'ControlPaint.DrawReversibleFrame(Canvas_Rectangle, sender.BackColor, FrameStyle.Dashed)

            ' Calculate the endpoint and dimensions for the new rectangle,  
            ' again using the PointToScreen method. 
            Dim endPoint As Point = CType(sender, Control).PointToScreen(New Point(e.X, e.Y))
            Dim width As Integer = endPoint.X - Start_Point.X
            Dim height As Integer = endPoint.Y - Start_Point.Y

            'Canvas_Rectangle = New Rectangle(Start_Point.X, Start_Point.Y, width, height)

            '' Draw the new rectangle by calling DrawReversibleFrame again.  
            'ControlPaint.DrawReversibleFrame(Canvas_Rectangle, sender.BackColor, FrameStyle.Dashed)
        End If

    End Sub


#End Region

#Region "Control Event Handlers"

    Public Sub Text_Box_Events(sender As Object, e As System.EventArgs) Handles Text_Box.Validated
        If Symbol.Parent_Form_Control.Design_Mode Then Exit Sub
        RaiseEvent Changed(Symbol)
    End Sub

    Public Sub Track_Bar_Events(sender As Object, e As System.EventArgs) Handles Slider.ValueChanged
        If Symbol.Parent_Form_Control.Design_Mode Then Exit Sub

        RaiseEvent Changed(Symbol)
    End Sub

    Public Sub ComboBox_Events(sender As Object, e As System.EventArgs) Handles Combo_Box.SelectedIndexChanged
        If Symbol.Parent_Form_Control.Design_Mode Then Exit Sub
        RaiseEvent Changed(Symbol)
    End Sub

#End Region

End Class
