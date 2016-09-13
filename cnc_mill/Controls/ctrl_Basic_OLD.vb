
Public Class ctrl_Basic

    Private Structure struct_Selected_Control
        Public Ctrl As Control
        Public Parent As ctrl_Basic
        Public Back_Color As Color
    End Structure

#Region "Events"

    Public Event Changed(Sender_Name As String)

#End Region

#Region "Properties"

    'Common properties
    Public Control_Type As ctrl_Form.enum_Ctrl_Type

    Public Property Prop_Name As String
        Get
            Return ctrl_Name
        End Get

        Set(ByVal value As String)
            ctrl_Name = value
        End Set
    End Property

    Public Property Prop_Back_Color As Color
        Get
            Select Case Control_Type
                Case ctrl_Form.enum_Ctrl_Type.Label
                    Return Label_Box.BackColor
                Case ctrl_Form.enum_Ctrl_Type.Button
                    Return Button.BackColor
                Case ctrl_Form.enum_Ctrl_Type.Text_Box
                    Return Text_Box.BackColor
                Case ctrl_Form.enum_Ctrl_Type.Menu
                    Return Combo_Box.BackColor
                Case ctrl_Form.enum_Ctrl_Type.Check_Box
                    Return Check_Box.BackColor
                Case ctrl_Form.enum_Ctrl_Type.Track_Bar
                    Return Slider.BackColor
            End Select
        End Get

        Set(ByVal value As Color)
            Select Case Control_Type
                Case ctrl_Form.enum_Ctrl_Type.Label
                    Label_Box.BackColor = value
                Case ctrl_Form.enum_Ctrl_Type.Button
                    Button.BackColor = value
                Case ctrl_Form.enum_Ctrl_Type.Text_Box
                    Text_Box.BackColor = value
                Case ctrl_Form.enum_Ctrl_Type.Menu
                    Combo_Box.BackColor = value
                Case ctrl_Form.enum_Ctrl_Type.Check_Box
                    Check_Box.BackColor = value
                Case ctrl_Form.enum_Ctrl_Type.Track_Bar
                    Slider.BackColor = value
            End Select
        End Set

    End Property

    Public Property Prop_Text As String

        Get
            Select Case Control_Type
                Case ctrl_Form.enum_Ctrl_Type.Label
                    Return Label_Box.Text
                Case ctrl_Form.enum_Ctrl_Type.Button
                    Return Button.Text
                Case ctrl_Form.enum_Ctrl_Type.Text_Box
                    Return Text_Box.Text
                Case ctrl_Form.enum_Ctrl_Type.Menu
                    Return Combo_Box.Text
                Case ctrl_Form.enum_Ctrl_Type.Check_Box
                    Return Check_Box.Text
            End Select
            Return ""
        End Get

        Set(ByVal value As String)
            Select Case Control_Type
                Case ctrl_Form.enum_Ctrl_Type.Label
                    Label_Box.Text = value
                Case ctrl_Form.enum_Ctrl_Type.Button
                    Button.Text = value
                Case ctrl_Form.enum_Ctrl_Type.Text_Box
                    Text_Box.Text = value
                Case ctrl_Form.enum_Ctrl_Type.Menu
                    Combo_Box.Text = value
                Case ctrl_Form.enum_Ctrl_Type.Check_Box
                    Check_Box.Text = value
                Case ctrl_Form.enum_Ctrl_Type.Track_Bar
                    Slider.Text = value
            End Select
        End Set

    End Property

    Public ReadOnly Property Prop_Up As Boolean

        Get
            Select Case Control_Type
                Case ctrl_Form.enum_Ctrl_Type.Label
                    Return Up
                Case ctrl_Form.enum_Ctrl_Type.Button
                    Return Up
                Case ctrl_Form.enum_Ctrl_Type.Image_Box
                    Return Up
            End Select
            Return Up
        End Get

    End Property

    Public ReadOnly Property Prop_Down As Boolean

        Get
            Select Case Control_Type
                Case ctrl_Form.enum_Ctrl_Type.Label
                    Return Down
                Case ctrl_Form.enum_Ctrl_Type.Button
                    Return Down
                Case ctrl_Form.enum_Ctrl_Type.Image_Box
                    Return Down
            End Select
            Return Up 'All other controls
        End Get

    End Property

    'Check box properties
    Public Property Prop_Checked As Boolean
        Get
            Return Check_Box.Checked
        End Get

        Set(ByVal value As Boolean)
            Check_Box.Checked = value
        End Set
    End Property

    'Track bar properties
    Public Property Prop_Maximum As Integer
        Get
            Return Slider.Maximum
        End Get

        Set(ByVal value As Integer)
            Slider.Maximum = value
        End Set
    End Property

    Public Property Prop_Minimum As Integer
        Get
            Return Slider.Minimum
        End Get

        Set(ByVal value As Integer)
            Slider.Minimum = value
        End Set
    End Property

    Public Property Prop_Small_Change As Integer
        Get
            Return Slider.SmallChange
        End Get

        Set(ByVal value As Integer)
            Slider.SmallChange = value
        End Set
    End Property

    Public Property Prop_Large_Change As Integer
        Get
            Return Slider.LargeChange
        End Get

        Set(ByVal value As Integer)
            Slider.LargeChange = value
        End Set
    End Property

#End Region

#Region "Declarations"

    Private Down As Boolean = False
    Private Up As Boolean = True
    Private Images As New List(Of Bitmap)
    Private ctrl_Name As String
    Private Image_Index As Integer
    Private Transparent_Color As New Color

    Private Symbol As class_Symbol_Table.Class_Symbol

    Private WithEvents Parent_Panel As Panel

    Private Shared Selected_Controls As New List(Of struct_Selected_Control)

    Private Default_Font As String = "Microsoft Sans Serif,10,Regular"
    'Private Shared Parent_Selected_Control As Control
    'Private Shared Selected_Control As Control
    'Private Shared Selected_Control_Backcolor As Color

    '    Private Canvas_Rectangle As New Rectangle

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

    Public Sub Initialize(ByRef Symbol_Pointer As class_Symbol_Table.Class_Symbol)
        Dim Type_Text As String = ""

        Symbol = Symbol_Pointer
        Parent_Panel = Symbol.Control_Panel

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

        Dim Target_Control As Control = Nothing

        Select Case Control_Type

            Case ctrl_Form.enum_Ctrl_Type.Button
                Target_Control = Button
                Button.Visible = True
                Type_Text = "BUTTON"

            Case ctrl_Form.enum_Ctrl_Type.Label
                Target_Control = Label_Box
                Label_Box.Visible = True
                Type_Text = "LABEL"

            Case ctrl_Form.enum_Ctrl_Type.Text_Box
                Target_Control = Text_Box
                Text_Box.Visible = True
                Type_Text = "TEXT_BOX"

            Case ctrl_Form.enum_Ctrl_Type.Menu
                Target_Control = Combo_Box
                Combo_Box.Visible = True
                Type_Text = "MENU"

            Case ctrl_Form.enum_Ctrl_Type.Check_Box
                Target_Control = Check_Box
                Check_Box.Visible = True
                Type_Text = "CHECK_BOX"

            Case ctrl_Form.enum_Ctrl_Type.Track_Bar
                Target_Control = Slider
                Slider.Visible = True
                Type_Text = "TRACK_BAR"

            Case ctrl_Form.enum_Ctrl_Type.Image_Box
                Target_Control = Image_Box
                Image_Box.Visible = True
                Type_Text = "IMAGE_BOX"

            Case ctrl_Form.enum_Ctrl_Type.List_Box
                Target_Control = List_Box
                List_Box.Visible = True
                Type_Text = "LIST_BOX"

        End Select

        Target_Control.Top = 0
        Target_Control.Left = 0

        If Symbol.Control.Control_Type = ctrl_Form.enum_Ctrl_Type.Track_Bar Then
            Add_Property(".Data_Type", "INTEGER")
            Add_Property(".Value", "0")
            Add_Property(".Min", "0")
            Add_Property(".Max", "100")
        Else
            Add_Property(".Symbol_Type", Type_Text)
            Add_Property(".Data_Type", "BOOL")
            Add_Property(".Choices", "UP,DOWN")
            Add_Property(".Text", "")
        End If

        Add_Property(".Top", 0)
        Add_Property(".Left", 0)
        Add_Property(".Height", Target_Control.Height)
        Add_Property(".Width", Target_Control.Width)
        Add_Property(".Back Color", Target_Control.BackColor.Name)
        Add_Property(".Fore Color", Target_Control.ForeColor.Name)
        Add_Property(".Font", Default_Font)
        Add_Property(".Location", "")

        Set_Properties()

        Me.Visible = True

    End Sub

    Public Sub Set_Properties()

        Dim Target_Control As Control = Nothing

        Select Case Control_Type
            Case ctrl_Form.enum_Ctrl_Type.Button
                Target_Control = Button
            Case ctrl_Form.enum_Ctrl_Type.Label
                Target_Control = Label_Box
            Case ctrl_Form.enum_Ctrl_Type.Text_Box
                Target_Control = Text_Box
            Case ctrl_Form.enum_Ctrl_Type.Menu
                Target_Control = Combo_Box
            Case ctrl_Form.enum_Ctrl_Type.Check_Box
                Target_Control = Check_Box
            Case ctrl_Form.enum_Ctrl_Type.Track_Bar
                Target_Control = Slider
            Case ctrl_Form.enum_Ctrl_Type.Image_Box
                Target_Control = Image_Box
            Case ctrl_Form.enum_Ctrl_Type.List_Box
                Target_Control = List_Box
        End Select

        For I = 0 To Symbol.Properties.Count - 1
            Select Case Symbol.Properties(I).Name

                Case ".Text"
                    Target_Control.Text = Symbol.Properties(I).Value
                    If Target_Control.Text = "" Then Target_Control.Text = "    "

                Case ".Value" 'Used on slider
                    Slider.Value = Symbol.Properties(I).Value

                Case ".Minimum" 'Used on slider
                    Slider.Minimum = Symbol.Properties(I).Value

                Case ".Minaximum" 'Used on slider
                    Slider.Maximum = Symbol.Properties(I).Value

                Case ".Top"
                    Me.Top = CInt(Symbol.Properties(I).Value)

                Case ".Left"
                    Me.Left = CInt(Symbol.Properties(I).Value)

                Case ".Width"
                    Target_Control.Width = CInt(Symbol.Properties(I).Value)
                    Me.Width = Target_Control.Width

                Case ".Height"
                    Target_Control.Height = CInt(Symbol.Properties(I).Value)
                    Me.Height = Target_Control.Height

                Case ".Back Color"
                    Target_Control.BackColor = Color.FromName(Symbol.Properties(I).Value)

                Case ".Fore Color"
                    Target_Control.ForeColor = Color.FromName(Symbol.Properties(I).Value)

                    'Case ".Font"
                    '    Dim S As String = Symbol.Properties(I).Value
                    '    Dim T() As String = S.Split(",")
                    '    Dim Fnt As Font

                    '    Select Case T(2)
                    '        Case "Bold"
                    '            Fnt = New Font(T(0), CSng(T(1)), FontStyle.Bold)
                    '        Case "Italic"
                    '            Fnt = New Font(T(0), CSng(T(1)), FontStyle.Italic)
                    '        Case Else
                    '            Fnt = New Font(T(0), CSng(T(1)), FontStyle.Regular)
                    '    End Select
                    '    Target_Control.Font = Fnt

            End Select
        Next


    End Sub

    Public Sub Add_Property(Name As String, Value As String)
        Dim Prop As New class_Symbol_Table.Class_Property
        Prop.Name = Name
        Prop.Value = Value
        Symbol.Properties.Add(Prop)

    End Sub

#End Region

#Region "Keyboard Handler"

    Public Shared Sub Key_Preview(Key_Args As KeyEventArgs)
        If Selected_Controls.Count = 0 Then Exit Sub
        Dim Inc As Integer = 1
        If Key_Args.Shift Then Inc = 10

        For C = 0 To Selected_Controls.Count - 1

            Select Case Key_Args.KeyValue

                Case Keys.Up

                    If Key_Args.Control Then

                        If Selected_Controls(C).Ctrl.Height - Inc > 10 Then
                            Selected_Controls(C).Ctrl.Height -= Inc
                        End If

                        'Select Case Selected_Controls(C).Parent.Ctrl_Type

                        '    Case ctrl_Form.enum_Ctrl_Type.Label
                        '        If Key_Args.Control Then
                        '            Dim Fnt As Font
                        '            Fnt = Selected_Controls(C).Ctrl.Font
                        '            Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size + Inc)
                        '        End If

                        '    Case Else

                        'End Select

                    ElseIf Key_Args.Alt Then

                        Dim Fnt As Font
                        Fnt = Selected_Controls(C).Ctrl.Font
                        Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size + Inc)

                    Else
                        If Selected_Controls(C).Parent.Top > 0 Then
                            Selected_Controls(C).Parent.Top -= Inc
                        End If
                    End If

                Case Keys.Down

                    If Key_Args.Control Then
                        Selected_Controls(C).Ctrl.Height += Inc

                        'Select Case Selected_Controls(C).Parent.Ctrl_Type

                        '    Case ctrl_Form.enum_Ctrl_Type.Label ', ctrl_Form.enum_Ctrl_Type.Text_Box, ctrl_Form.enum_Ctrl_Type.Check_Box, ctrl_Form.enum_Ctrl_Type.Combo_Box
                        '        If Key_Args.Control Then
                        '            Dim Fnt As Font
                        '            Fnt = Selected_Controls(C).Ctrl.Font
                        '            If Fnt.Size > 8 Then
                        '                Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size - Inc)
                        '            End If
                        '        End If

                        '    Case Else
                        '        Selected_Controls(C).Ctrl.Height += Inc
                        'End Select

                    ElseIf Key_Args.Alt Then
                        Dim Fnt As Font
                        Fnt = Selected_Controls(C).Ctrl.Font
                        If Fnt.Size > 8 Then
                            Selected_Controls(C).Ctrl.Font = New Font(Fnt.FontFamily, Fnt.Size - Inc)
                        End If
                    Else
                        Selected_Controls(C).Parent.Top += Inc
                    End If

                Case Keys.Left
                    If Key_Args.Control Then
                        If Selected_Controls(C).Ctrl.Width - Inc > 10 Then
                            Selected_Controls(C).Ctrl.Width -= Inc
                        End If
                    Else
                        If Selected_Controls(C).Parent.Left > 0 Then
                            Selected_Controls(C).Parent.Left -= Inc
                        End If
                    End If

                Case Keys.Right
                    If Key_Args.Control Then
                        Selected_Controls(C).Ctrl.Width += Inc
                    Else
                        Selected_Controls(C).Parent.Left += Inc
                    End If


            End Select

            Selected_Controls(C).Parent.Height = Selected_Controls(C).Ctrl.Height
            Selected_Controls(C).Parent.Width = Selected_Controls(C).Ctrl.Width
        Next

    End Sub

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


    Private Sub Parent_Panel_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Parent_Panel.MouseDown

        For I = 0 To Selected_Controls.Count - 1
            Selected_Controls(I).Ctrl.BackColor = Selected_Controls(I).Back_Color
            'Canvas_Rectangle.X = Selected_Controls(I).Ctrl.Left
            'Canvas_Rectangle.Y = Selected_Controls(I).Ctrl.Top
            'Canvas_Rectangle.Width = Selected_Controls(I).Ctrl.Width
            'Canvas_Rectangle.Height = Selected_Controls(I).Ctrl.Height


            'ControlPaint.DrawReversibleFrame(Canvas_Rectangle, sender.BackColor, FrameStyle.Dashed)

            Selected_Controls(I).Ctrl.Refresh()
        Next

        Selected_Controls.Clear()
    End Sub

    Private Sub Add_Selected_Control(Ctrl As Control)

        For I = 0 To Selected_Controls.Count - 1
            If Selected_Controls(I).Ctrl Is Ctrl Then
                Selected_Controls(I).Ctrl.BackColor = Selected_Controls(I).Back_Color
                Selected_Controls(I).Ctrl.Refresh()
                Selected_Controls.Remove(Selected_Controls(I))
                Exit Sub
            End If
        Next

        Dim Sel As New struct_Selected_Control
        Sel.Parent = Ctrl.Parent
        Sel.Ctrl = Ctrl
        Sel.Back_Color = Sel.Ctrl.BackColor
        Ctrl.BackColor = Color.Magenta
        Selected_Controls.Add(Sel)
    End Sub

    Public Sub Mouse_Down_Events(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles _
                                 Label_Box.MouseDown, Button.MouseDown, Text_Box.MouseDown, Combo_Box.MouseDown, _
                                 Check_Box.MouseDown, Slider.MouseDown, Image_Box.MouseDown, List_Box.MouseDown

        If Symbol.Control_Parent_Control.Edit_Mode Then

            Add_Selected_Control(sender)

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
            RaiseEvent Changed(ctrl_Name)
        End If

    End Sub

    Public Sub Mouse_Up_Events(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles _
                               Label_Box.MouseUp, Button.MouseUp, Text_Box.MouseUp, Combo_Box.MouseUp, _
                               Check_Box.MouseUp, Slider.MouseUp, Image_Box.MouseUp, List_Box.MouseUp

        If Symbol.Control_Parent_Control.Edit_Mode Then
            If (e.Button = MouseButtons.Left) Then
                Dragging = False
            End If

            If (e.Button = MouseButtons.Right) Then
                Windowing = False
            End If
        Else
            Down = False
            Up = True
            RaiseEvent Changed(ctrl_Name)
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
        If Symbol.Control_Parent_Control.Edit_Mode Then Exit Sub
        RaiseEvent Changed(ctrl_Name)
    End Sub

    Public Sub Track_Bar_Events(sender As Object, e As System.EventArgs) Handles Slider.ValueChanged
        If Symbol.Control_Parent_Control.Edit_Mode Then Exit Sub

        RaiseEvent Changed(ctrl_Name)
    End Sub

    Public Sub ComboBox_Events(sender As Object, e As System.EventArgs) Handles Combo_Box.SelectedIndexChanged
        If Symbol.Control_Parent_Control.Edit_Mode Then Exit Sub
        RaiseEvent Changed(ctrl_Name)
    End Sub

#End Region

End Class
