Imports System.Windows.Input

Public Class Class_Controls

#Region "Enums"

    Public Enum enum_Type
        Toggle
        Button
        Radio
        Grid
    End Enum

    Public Enum enum_Position_State
        Up
        Down
        Working
    End Enum

    Public Enum enum_Toggle_State
        Is_On
        Is_Off
    End Enum

    Public Enum enum_Button_Click
        Left
        Right
    End Enum

    Public Enum enum_Action
        E_Stop
        Home
        Enable
        Cycle
        Feed
        Spindle
        Coolant
        Jog
        Probe
        Set_Position
        Goto_Position
    End Enum

    Public Enum enum_Display
        E_Stop
        Home
        Enable
        Cycle
        Feed
        Spindle
        Coolant
        Jog
        Probe
        State
        Work_Position
        Abs_Position
        Offset
    End Enum

    Public Enum enum_Jog_Radio_Function
        Jog_Speed_Select
    End Enum

    Public Enum enum_DRO_Function
        Position_DRO
        Jog_Speed_DRO
        Jog_Speed_Radio
    End Enum

    Public Enum enum_Grid_Function
        Offset_Grid
        MDI_Grid
        G_Code_Grid
    End Enum

#End Region

#Region "Classes"

    Public Class Class_Control_Properties
        Public Control_Instance As Control
        Public Control_Type As enum_Type
        Public Action As enum_Action
        Public Display As enum_Display
        Public Axis As Class_CNC.enum_Axis
        Public Direction As Class_CNC.enum_Direction
        Public State As enum_Position_State
        Public Up_Image As Bitmap
        Public Down_Image As Bitmap
        Public Working_Image As Bitmap
        Public Up_Text As String
        Public Down_Text As String
        Public Working_Text As String
    End Class

#End Region

#Region "Definitions"

    Private Mouse_Down As Boolean

#End Region

#Region "Buttons"

    Public Sub Init_Control(Sym As Class_Symbols.class_Symbol)

        Select Case Sym.Type

            Case Class_Symbols.enum_Symbol_Type.Process_GCode
                Dim T() As String = Sym.Name.Split(".")
                Dim Process_Sym As Class_Symbols.class_Symbol
                Dim Process_ctrl As ctrl_Process
                Process_Sym = Symbol.Get_Symbol(T(0))
                If Not IsNothing(Process_Sym) Then
                    Process_ctrl = Process_Sym.Ctrl
                    Sym.Ctrl.Tag = Sym
                    Process_ctrl.Add_GCode_Control(Sym)
                End If

            Case Class_Symbols.enum_Symbol_Type.Process_Drawing
                Dim T() As String = Sym.Name.Split(".")
                Dim Process_Sym As Class_Symbols.class_Symbol
                Dim Process_ctrl As ctrl_Process
                Process_Sym = Symbol.Get_Symbol(T(0))
                If Not IsNothing(Process_Sym) Then
                    Process_ctrl = Process_Sym.Ctrl
                    Sym.Ctrl.Tag = Sym
                    Process_ctrl.Add_Drawing_Control(Sym, Symbol.Get_Value("Sys.Max_X"), Symbol.Get_Value("Sys.Max_Y"), Symbol.Get_Value("Sys.Max_Z"))
                End If

            Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label
                Sym.Load_Image_File(Sym.Down_Image_File)
                Sym.Load_Image_File(Sym.Up_Image_File)

                Dim ctl As Button = Sym.Ctrl
                ctl.BackgroundImageLayout = ImageLayout.Stretch
                ctl.BackgroundImageLayout = ImageLayout.Stretch
                ctl.FlatStyle = FlatStyle.Flat
                ctl.FlatAppearance.BorderSize = 0
                ctl.FlatAppearance.BorderColor = Color.FromName(Sym.Back_Color)
                ctl.FlatAppearance.MouseOverBackColor = Color.FromName(Sym.Back_Color)
                ctl.FlatAppearance.MouseDownBackColor = Color.FromName(Sym.Back_Color)
                ctl.TabStop = False
                ctl.Tag = Sym

                RemoveHandler ctl.MouseDown, AddressOf Control_Mouse_Down_Handler
                AddHandler ctl.MouseDown, AddressOf Control_Mouse_Down_Handler

                RemoveHandler ctl.MouseUp, AddressOf Control_Mouse_Up_Handler
                AddHandler ctl.MouseUp, AddressOf Control_Mouse_Up_Handler

                RemoveHandler ctl.MouseLeave, AddressOf Control_Mouse_Leave_Handler
                AddHandler ctl.MouseLeave, AddressOf Control_Mouse_Leave_Handler

            Case Class_Symbols.enum_Symbol_Type.Text_Box
                Dim Dummy As New ContextMenuStrip
                Dim ctl As TextBox = Sym.Ctrl
                ctl.TabStop = False
                ctl.Tag = Sym
                ctl.ContextMenuStrip = Dummy
                ctl.ReadOnly = Sym.No_Edit

                RemoveHandler ctl.MouseDown, AddressOf Text_Box_Mouse_Down_Handler
                AddHandler ctl.MouseDown, AddressOf Text_Box_Mouse_Down_Handler

                RemoveHandler ctl.Validated, AddressOf Text_Box_Validated_Handler
                AddHandler ctl.Validated, AddressOf Text_Box_Validated_Handler

                '                RemoveHandler ctl.PreviewKeyDown, AddressOf Text_Box_Preview_Key_Down
                '               AddHandler ctl.PreviewKeyDown, AddressOf Text_Box_Preview_Key_Down


            Case Class_Symbols.enum_Symbol_Type.Check_Box
                Dim ctl As CheckBox = Sym.Ctrl
                ctl.TabStop = False
                ctl.Tag = Sym

                RemoveHandler ctl.CheckedChanged, AddressOf Control_Check_Changed
                AddHandler ctl.CheckedChanged, AddressOf Control_Check_Changed

            Case Class_Symbols.enum_Symbol_Type.Radio_Button
                Dim ctl As RadioButton = Sym.Ctrl
                ctl.TabStop = False
                ctl.Tag = Sym

                RemoveHandler ctl.CheckedChanged, AddressOf Control_Check_Changed
                AddHandler ctl.CheckedChanged, AddressOf Control_Check_Changed

        End Select

    End Sub

    Private Sub Control_Check_Changed(ByVal sender As Object, e As EventArgs)
        Mouse_Down = True
        Dim Ctrl As Control = sender
        CNC.Cause_Event(Class_CNC.enum_Event_Types.Check_Changed, Ctrl, "Check_Changed_Handler")
    End Sub

    Private Sub Radio_Changed(ByVal sender As Object, e As EventArgs)
        Mouse_Down = True
        Dim Ctrl As Control = sender
        CNC.Cause_Event(Class_CNC.enum_Event_Types.Radio_Changed, Ctrl, "Radio_Changed_Handler")
    End Sub

    Private Sub Text_Box_Mouse_Down_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim Ctrl As Control = sender
        If e.Button = MouseButtons.Left Then CNC.Cause_Event(Class_CNC.enum_Event_Types.Text_Box_Left_Click, Ctrl, "Text_Mouse_Down_Handler")

        If e.Button = MouseButtons.Right Then
            If Controller.Check_For_In_Cycle("Cannot start wizards while in cycle") Then Exit Sub
            Macro_Editor.Show_Symbol(sender.tag)
        End If
    End Sub

    Private Sub Control_Mouse_Down_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Mouse_Down = True
        Dim Ctrl As Control = sender
        If e.Button = MouseButtons.Left Then CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Ctrl, "Control_Mouse_Down_Handler")

        If e.Button = MouseButtons.Right Then
            If Controller.Check_For_In_Cycle("Cannot start wizards while in cycle") Then Exit Sub
            Macro_Editor.Show_Symbol(sender.tag)
        End If

    End Sub

    Private Sub Control_Mouse_Up_Handler(ByVal sender As Object, e As System.EventArgs)
        Mouse_Down = False
        Dim Ctrl As Control = sender
        CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Ctrl, "Control_Mouse_Up_Handler")
    End Sub

    Private Overloads Sub Control_Mouse_Leave_Handler(ByVal sender As Object, e As System.EventArgs)
        Dim Ctrl As Control = sender
        'This forces the button up handler if the mouse left the button with the button pressed
        If Mouse_Down Then
            Mouse_Down = False
            CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Ctrl, "Mouse_Leave_Handler")
        End If

    End Sub

    Private Sub Text_Box_Validated_Handler(sender As Object, e As System.EventArgs)
        Dim Ctrl As Control = sender
        CNC.Cause_Event(Class_CNC.enum_Event_Types.Text_Box_Edit, Ctrl, "Text_Box_Validated_Handler")
    End Sub

    Private Sub Text_Box_Preview_Key_Down(sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            sender.Text = Calc.Format_Number(sender.Text)
            My.Computer.Keyboard.SendKeys(vbTab, True)
        End If
    End Sub

#End Region

#Region "Hot Keys"

    Public Function Hot_Key_Handler(e As System.Windows.Forms.KeyEventArgs, Key_Down As Boolean) As Boolean
        Dim K As String = ""
        Static Dim Key_Down_Symbol As Class_Symbols.class_Symbol = Nothing

        If e.Control Then K = "Ctrl"
        If e.Alt Then
            If K <> "" Then K &= "_"
            K &= "Alt"
        End If
        If e.Shift Then
            If K <> "" Then K &= "_"
            K &= "Shift"
        End If
        If K <> "" Then K &= "_"
        K &= e.KeyCode.ToString
        K = "Hot_Key." & K

        Dim Sym As Class_Symbols.class_Symbol

        Sym = Symbol.Get_Symbol(K, False)

        If IsNothing(Sym) Then
            Return False
        Else
            If Key_Down Then
                Key_Down_Symbol = Sym
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Hot_Key_Down, Sym, "Handle_Hot_Key")
            Else
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Hot_Key_Up, Sym, "Handle_Hot_Key")
            End If
        End If

        Return True

    End Function

#End Region


    'Public Sub Make_Button_Background_Transparent(btn As Button, clr As Color)
    '    Dim Bm As Bitmap
    '    btn.BackColor = btn.Parent.BackColor
    '    Bm = btn.BackgroundImage
    '    If Not IsNothing(Bm) Then
    '        Bm.MakeTransparent(clr)
    '    End If

    'End Sub

    Public Sub Make_Form_Buttons_Transparent(frm As Form, Transparent_Color As Color)
        Dim ctrl As Control

        For C = 0 To frm.Controls.Count - 1
            ctrl = frm.Controls(C)
            Make_Control_Buttons_Transparent(ctrl, Transparent_Color)
        Next
    End Sub

    Private Sub Make_Control_Buttons_Transparent(Contrl As Control, Transparent_Color As Color)
        If Contrl.Controls.Count = 0 Then Exit Sub
        Dim Bm As Bitmap
        Dim btn As Button
        Dim rad As RadioButton

        For C = 0 To Contrl.Controls.Count - 1
            Select Case Contrl.Controls(C).GetType.Name
                Case "Button"
                    btn = Contrl.Controls(C)
                    btn.BackColor = btn.Parent.BackColor
                    btn.BackgroundImageLayout = ImageLayout.Stretch
                    Bm = btn.BackgroundImage
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    If Not IsNothing(Bm) Then Bm.MakeTransparent(Transparent_Color)
                Case "RadioButton"
                    rad = Contrl.Controls(C)
                    rad.BackColor = rad.Parent.BackColor
                    rad.BackgroundImageLayout = ImageLayout.Stretch
                    Bm = rad.BackgroundImage
                    rad.FlatStyle = FlatStyle.Flat
                    rad.FlatAppearance.BorderSize = 0
                    If Not IsNothing(Bm) Then Bm.MakeTransparent(Transparent_Color)
                Case Else
                    Make_Control_Buttons_Transparent(Contrl.Controls(C), Transparent_Color) 'Recursive call
            End Select
        Next
    End Sub


End Class
