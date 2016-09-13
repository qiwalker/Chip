Imports System.IO

Public Class Class_CNC

#Region "Enums"

    Public Enum enum_Axis
        None
        X
        Y
        Z
        All
    End Enum

    Public Enum enum_Direction
        None
        Up
        Down
        Center
        N
        S
        E
        W
        NE
        NW
        SE
        SW
        Tool_Setter_Measure_Top
        Tool_Setter_Measure_Bottom
        Tool_Setter_Measure_Material
    End Enum

    Public Enum enum_Jog_Rate
        Fast
        Slow
        Creep
        Step_Large
        Step_Small
    End Enum

    Public Enum enum_Positions
        None
        Home
        Park
        Safe_Z
        Tool_Change
        Tool_Measure
        Material_Measure
    End Enum

    Public Enum enum_Coordinate_System
        G53 = 0
        G54 = 1
        G55 = 2
        G56 = 3
        G57 = 4
        G58 = 5
        G59 = 6
    End Enum

    Public Enum enum_Event_Types
        None
        Priority_Message
        Message_Out
        Message_Reply
        Message_In

        Status_Report
        Error_Message
        Queue_Report
        USB_Handshake
        Text_Message

        CNC_Initialized
        Initialize_Done
        Reset_Controller
        Controller_Reset_Sent
        Controller_Reset
        Download_Settings
        Settings_Downloaded
        Verify_Settings
        Verify_Done

        E_Stop
        Reset_E_Stop
        Offsets_Changed

        Spindle
        Coolant

        GCode_Ack
        GCode_Update

        System_GCode_Ack
        System_GCode_Complete
        Program_End

        Probe_Status_Update

        Info_Message

        Macro
        Macro_Start
        Macro_End
        Macro_Error

        Text_Box_Edit
        Text_Box_Left_Click
        Text_Box_Right_Click

        Button_Down
        Button_Up

        Check_Changed
        Radio_Changed

        Hot_Key_Down
        Hot_Key_Up

    End Enum

    Public Enum enum_Status_Codes
        None = -1
        Controller_Initializing = 0
        Ready = 1
        Alarm = 2
        Stopped = 3
        Program_End = 4
        In_Motion = 5
        Feedhold = 6
        Probing = 7
        Cycling = 8
        Homing = 9

        CNC_Initializing = 10

    End Enum

    Public Structure struct_Change_Flags
        Public Block_Number_Changed As Boolean
        Public Program_Line_Number_Changed As Boolean
        Public Position_Changed As Boolean
        Public State_Changed As Boolean
        Public Coordinate_System_Changed As Boolean
        Public Offsets_Changed As Boolean
    End Structure

    Public Enum enum_Probe_State
        Idle
        Probe_Cycle_Started
        Waiting_For_Touch
        Touched
        Retract_Cycle_Started
        Retracting
        Done
        Probe_Error
    End Enum

    Public Enum enum_Probe_Mode
        None
        Retract_To_Start
        Retract_A_Distance
    End Enum


#End Region

#Region "Structures"

    Public Structure struct_Location
        Public X As Single
        Public Y As Single
        Public Z As Single
    End Structure

    Public Structure struct_Param
        Public Name As String
        Public Value As Object
    End Structure

#End Region

#Region "Classes"

    Public Class class_Event
        Public Type As enum_Event_Types
        Public Message As String
        Public Parameter As Object
        Public Parameter_List As List(Of struct_Param)
        Public Handler As String
        Public Ctrl As Control
        Public Symbol As Class_Symbols.class_Symbol
        Public Routine As String
        Public Comment As String
        Public Flags As struct_Change_Flags
        Public Program_Status As Class_CNC.enum_Status_Codes

        Public Function Get_Parameter_Value(Name As String)
            For I = 0 To Parameter_List.Count - 1
                If Parameter_List(I).Name = Name Then
                    Return Parameter_List(I).Value
                End If
            Next
            Return Nothing
        End Function

        Public Sub Add_Parameter(Name As String, Value As Object)
            Dim Param As New struct_Param
            Param.Name = Name
            Param.Value = Value
            If IsNothing(Parameter_List) Then Parameter_List = New List(Of struct_Param)
            Parameter_List.Add(Param)
        End Sub

    End Class

#End Region

#Region "Declarations"

    Public Status_Code As enum_Status_Codes = enum_Status_Codes.Stopped

    Public States As New Queue(Of enum_Status_Codes)

    Public Abs_X_Shadow As Single
    Public Abs_Y_Shadow As Single
    Public Abs_Z_Shadow As Single

    Public Probe_State As enum_Probe_State = enum_Probe_State.Idle
    Public Probe_Callback_Macro As String
    Public Probe_Mode As enum_Probe_Mode
    Public Probe_Axis As enum_Axis
    Public Probe_Distance As Single
    Public Probe_Diameter As Single
    Public Probe_Feedrate As Single
    Public Probe_Direction As enum_Direction
    Public Probe_Approach_Feedrate As Single
    Public Probe_Retract_Distance As Single
    Public Probe_Start_X As Single
    Public Probe_Start_Y As Single
    Public Probe_Start_Z As Single
    Public Probe_End_X As Single
    Public Probe_End_Y As Single
    Public Probe_End_Z As Single

    Public Probe_Touch_Toolsetter_Material_Top As Single
    Public Probe_Touch_Toolsetter_Material_Bottom As Single

    Public Probe_Retract_Command As String

    Public Probe_Set_Offsets As Boolean
    Public Probe_Disable_Axis As Boolean
    Public Probe_Square_Check As enum_Direction

    Public GCode_Ack As Boolean
    Public Gcode_Block_Number As Integer = 1

#End Region

#Region "Initialize"

    Public Sub Send_Persistant_Positions_To_TinyG()
        CNC.Set_Position(Class_CNC.enum_Axis.X, My.Settings.Abs_X)
        CNC.Set_Position(Class_CNC.enum_Axis.Y, My.Settings.Abs_Y)
        CNC.Set_Position(Class_CNC.enum_Axis.Z, My.Settings.Abs_Z)
        CNC.Abs_X_Shadow = My.Settings.Abs_X
        CNC.Abs_Y_Shadow = My.Settings.Abs_Y
        CNC.Abs_Z_Shadow = My.Settings.Abs_Z
        Controller.Request_Status_Report()
    End Sub

    Public Sub Save_Persistant_Positions()
        My.Settings.Abs_X = Symbol.Get_Value("Sys.Abs_X")
        My.Settings.Abs_Y = Symbol.Get_Value("Sys.Abs_Y")
        My.Settings.Abs_Z = Symbol.Get_Value("Sys.Abs_Z")
        My.Settings.Save()
    End Sub

    Public Sub Initialize()

        Queue_State(Class_CNC.enum_Status_Codes.CNC_Initializing)

        Controller.Queue_GCode("N0")

        Controller.Reset_Units()

        Controller.Get_Offsets()

        Symbol.Set_Value("Sys.Soft_Limits_Enabled", True)
        Main_Form.chk_Soft_Limits.Checked = True
        Main_Form.chk_Move_Raise_Z.Checked = True
        Main_Form.chk_Move_Set_Gap.Checked = False

        Controller.Set_Offsets("G54", 0, 0, 0)
        Controller.Enable_Offsets(False)
        Controller.Request_Status_Report()
        Status_Code = enum_Status_Codes.Stopped

        Symbol.Set_Value("Homed.XYZ", False)
        Symbol.Set_Value("Homed.X", False)
        Symbol.Set_Value("Homed.Y", False)
        Symbol.Set_Value("Homed.Z", False)

        Symbol.Set_Value("Sys.In_Motion", False)
        Symbol.Set_Value("Sys.In_Feed_Hold", False)
        Symbol.Set_Value("Sys.In_Cycle_Stop", False)

        CNC.Probe_State = enum_Probe_State.Idle

        Cause_Event(enum_Event_Types.CNC_Initialized, "Sys.Initialize")

    End Sub

#End Region

#Region "States"

    Public Sub Queue_State(Code As enum_Status_Codes)
        States.Enqueue(Code)
        If States.Count > 3 Then
            States.Dequeue()
        End If
    End Sub

    Public Function State() As enum_Status_Codes
        If States.Count > 0 Then
            Return States(States.Count - 1)
        End If
        Return enum_Status_Codes.None
    End Function

    Public Function State_Changed() As Boolean

        If States.Count > 2 Then
            If States(1) <> States(2) Then Return True
        ElseIf States.Count > 1 Then
            If States(0) <> States(1) Then Return True
        End If

        Return False
    End Function

    Public Function Current_State() As enum_Status_Codes

        Select Case States.Count
            Case 1
                Return States(0)
            Case 2
                Return States(1)
            Case 3
                Return States(2)
        End Select
        Return enum_Status_Codes.None
    End Function

    Public Function Last_State() As enum_Status_Codes

        Select Case States.Count
            Case 2
                Return States(0)
            Case 3
                Return States(1)
        End Select
        Return enum_Status_Codes.None
    End Function

    Public Function Previous_State() As enum_Status_Codes
        If States.Count = 3 Then Return States(2)
        Return enum_Status_Codes.None
    End Function

    'Public Function State_Sequence(Current As enum_Status_Codes, Last As enum_Status_Codes, _
    '                               Optional Previous As enum_Status_Codes = enum_Status_Codes.None) As Boolean
    '    If Previous <> enum_Status_Codes.None Then
    '        If States.Count > 2 Then
    '            If (States(2) = Current) And (States(1) = Last) And (States(0) = Previous) Then Return True
    '        End If
    '    Else
    '        If States.Count > 1 Then
    '            If (States(1) = Current) And (States(0) = Last) Then Return True
    '        End If
    '    End If

    '    Return False

    'End Function

#End Region

    Public Function Get_Integer_Codes(Block As String, Code_Letter As String) As List(Of Integer)
        Dim Codes As New List(Of Integer)
        Dim S() As String
        Dim Code As String = ""
        Dim Special As String() = {".", "-", "+"}
        Dim Comment As String
        Dim Num As String = ""
        Dim Ch As String

        Block = Block.Replace("%", "")

        S = Block.Split(";")
        If S.Count > 1 Then
            Comment = ";" & S(1)
        Else
            S = Block.Split("(")
            If S.Count > 1 Then
                Comment = "(" & S(1)
            End If
        End If
        Block = S(0)
        Num = ""

        '        Code_Letter = "M"
        '        Block = "G01 G02 X1.002 Y2.002 Z3.003 M01 M02"

        Block = Block.Replace(" ", "")
        Block &= " "
        For I = 1 To Block.Length
            Ch = Mid(Block, I, 1)
            If Ch = Code_Letter Then
                If Code <> "" And Num <> "" Then
                    If Code = Code_Letter Then
                        Codes.Add(Num)
                    End If
                End If
                Code = Ch
                Num = ""
            Else
                If IsNumeric(Ch) Or Special.Contains(Ch) Then
                    Num &= Ch
                Else
                    If Code <> "" And Num <> "" Then
                        If Code = Code_Letter Then
                            Codes.Add(Num)
                            Code_Letter = ""
                            Num = ""
                        End If
                    End If
                End If
            End If
        Next

        Return Codes

    End Function

    Public Sub Queue_Message(Message As String, Priority As Boolean, Optional Routine As String = "")
        Controller.Queue_Outgoing_Message(Message, Priority, Routine)
    End Sub

#Region "Cause Event"

    Public Overloads Sub Cause_Event(Type As enum_Event_Types, Parameter As Object, Routine As String, Optional Comment As String = "")
        Dim Ev As New class_Event
        Ev.Type = Type
        Ev.Parameter = Parameter
        Ev.Routine = Routine
        Ev.Comment = Comment
        Main_Form.Enqueue_Controller_Event(Ev)
    End Sub

    Public Overloads Sub Cause_Event(Type As enum_Event_Types, Form_Control As Control, Routine As String)
        Dim Ev As New class_Event
        Ev.Type = Type
        Ev.Ctrl = Form_Control
        Ev.Routine = Routine
        Main_Form.Enqueue_Controller_Event(Ev)
    End Sub

    Public Overloads Sub Cause_Event(Type As enum_Event_Types, Sym As Class_Symbols.class_Symbol, Routine As String)
        Dim Ev As New class_Event
        Dim H As String
        Ev.Type = Type
        Ev.Symbol = Sym
        Ev.Routine = Routine
        If Type = enum_Event_Types.Hot_Key_Down Then
            H = Sym.Down_Handler
        Else
            H = Sym.Up_Handler
        End If

        Ev.Handler = H.Replace("Macro.", "")

        Main_Form.Enqueue_Controller_Event(Ev)
    End Sub

    Public Overloads Sub Cause_Event(Type As enum_Event_Types, Routine As String)
        Dim Ev As New class_Event
        Ev.Type = Type
        Ev.Routine = Routine
        Main_Form.Enqueue_Controller_Event(Ev)
    End Sub

#End Region

    Public Function Translate_Status_Code(Code As Class_Tiny_G.enum_Status_Code) As enum_Status_Codes
        'This isolates the CNC status codes from the Tiny_G status codes
        Dim Stat As enum_Status_Codes = enum_Status_Codes.None

        Select Case Code
            Case Class_Tiny_G.enum_Status_Code.None
                Stat = enum_Status_Codes.None
            Case Class_Tiny_G.enum_Status_Code.Initializing
                Stat = enum_Status_Codes.Controller_Initializing
            Case Class_Tiny_G.enum_Status_Code.Ready
                Stat = enum_Status_Codes.Ready
            Case Class_Tiny_G.enum_Status_Code.Alarm
                Stat = enum_Status_Codes.Alarm
            Case Class_Tiny_G.enum_Status_Code.Stopped
                Stat = enum_Status_Codes.Stopped
            Case Class_Tiny_G.enum_Status_Code.Program_End
                Stat = enum_Status_Codes.Program_End
            Case Class_Tiny_G.enum_Status_Code.In_Motion
                Stat = enum_Status_Codes.In_Motion
            Case Class_Tiny_G.enum_Status_Code.Feedhold
                Stat = enum_Status_Codes.Feedhold
            Case Class_Tiny_G.enum_Status_Code.Probing
                Stat = enum_Status_Codes.Probing
            Case Class_Tiny_G.enum_Status_Code.Cycling
                Stat = enum_Status_Codes.Cycling
            Case Class_Tiny_G.enum_Status_Code.Homing
                Stat = enum_Status_Codes.Homing
        End Select

        'Initializing = 0
        'Ready = 1 'TinyG reset
        'Alarm = 2 'TinyG Alarm
        'Stopped = 3 'TinyG Stop
        'Program_End = 4 'TinyG end
        'In_Motion = 5 'TinyG run
        'Feedhold = 6 'TinyG hold
        'Probing = 7 'TinyG probe
        'Cycling = 8
        'Homing = 9 'TinyG homing

        Return Stat

    End Function

    Public Function Inhibited() As Boolean

        If Symbol.Get_Value("Sys.In_E_Stop") Then
            Flash_Message("E_Stop")
            Return True
        End If

        If Symbol.Get_Value("Sys.In_Feed_Hold") Then
            Flash_Message("Feed Hold")
            Return True
        End If

        Return False

    End Function

    Public Sub Set_Position(Axis As Class_CNC.enum_Axis, Position As Single)
        Select Case Axis
            Case Class_CNC.enum_Axis.X
                Controller.Queue_System_GCode("G28.3 X" & Trim(Position))
            Case Class_CNC.enum_Axis.Y
                Controller.Queue_System_GCode("G28.3 Y" & Trim(Position))
            Case Class_CNC.enum_Axis.Z
                Controller.Queue_System_GCode("G28.3 Z" & Trim(Position))
            Case Class_CNC.enum_Axis.All
                Controller.Queue_System_GCode("G28.3 X" & Trim(Position) & " Y" & Trim(Position) & " Z" & Trim(Position))
        End Select
        Controller.Request_Status_Report()
    End Sub


#Region "Probe"

    Public Sub Probe_Status_Update(Evnt As Class_CNC.class_Event)
        Dim Current_State As enum_Probe_State = CNC.Probe_State

        Select Case Current_State

            Case enum_Probe_State.Idle
             
            Case enum_Probe_State.Probe_Cycle_Started
                CNC.Probe_State = Class_CNC.enum_Probe_State.Waiting_For_Touch
                Macros.Run_Macro(CNC.Probe_Callback_Macro)

            Case enum_Probe_State.Waiting_For_Touch

                Select Case Evnt.Parameter

                    Case "Probing"

                    Case "Probe_Done"
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Touched

                        For I = 1 To Evnt.Parameter_List.Count - 1
                            Select Case UCase(Evnt.Parameter_List(I).Name)
                                Case "X"
                                    CNC.Probe_End_X = Calc.Round(CSng(Evnt.Parameter_List(I).Value) * mm_to_inch)
                                Case "Y"
                                    CNC.Probe_End_Y = Calc.Round(CSng(Evnt.Parameter_List(I).Value) * mm_to_inch)
                                Case "Z"
                                    CNC.Probe_End_Z = Calc.Round(CSng(Evnt.Parameter_List(I).Value) * mm_to_inch)
                                    Exit For
                            End Select

                        Next

                        'Wait.Delay_Seconds(0.25)

                        Controller.Queue_System_GCode("G90") 'Probe uses incremental mode, and doesn't get it set back quick enough.

                        Macros.Run_Macro(CNC.Probe_Callback_Macro)

                        Dim Block As String = ""

                        Select Case CNC.Probe_Mode

                            Case enum_Probe_Mode.None
                                CNC.Probe_State = Class_CNC.enum_Probe_State.Done
                                Macros.Run_Macro(CNC.Probe_Callback_Macro)

                            Case enum_Probe_Mode.Retract_To_Start
                                Block = "G01 X" & Calc.Format_Number(CNC.Probe_Start_X) & " Y" & Calc.Format_Number(CNC.Probe_Start_Y) & _
                                           " Z" & Calc.Format_Number(CNC.Probe_Start_Z) & " F" & CNC.Probe_Feedrate

                                CNC.Probe_State = Class_CNC.enum_Probe_State.Retract_Cycle_Started
                                Macros.Run_Macro(CNC.Probe_Callback_Macro)
                                Controller.Queue_System_GCode(Block, False, False)

                            Case enum_Probe_Mode.Retract_A_Distance

                                Select Case CNC.Probe_Direction

                                    Case enum_Direction.E
                                        Block = "G38.2 X" & (CNC.Probe_End_X + CNC.Probe_Retract_Distance) & " F" & CNC.Probe_Feedrate
                                    Case enum_Direction.W
                                        Block = "G38.2 X" & (CNC.Probe_End_X - CNC.Probe_Retract_Distance) & " F" & CNC.Probe_Feedrate
                                    Case enum_Direction.N
                                        Block = "G38.2 Y" & (CNC.Probe_End_Y + CNC.Probe_Retract_Distance) & " F" & CNC.Probe_Feedrate
                                    Case enum_Direction.S
                                        Block = "G38.2 Y" & (CNC.Probe_End_Y - CNC.Probe_Retract_Distance) & " F" & CNC.Probe_Feedrate
                                End Select

                                CNC.Probe_State = Class_CNC.enum_Probe_State.Retract_Cycle_Started
                                Macros.Run_Macro(CNC.Probe_Callback_Macro)
                                Controller.Queue_System_GCode(Block, False, False)

                        End Select

                    Case "Probe_Error"
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Probe_Error
                        Macros.Run_Macro(CNC.Probe_Callback_Macro)
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Idle
                End Select

            Case enum_Probe_State.Retract_Cycle_Started

                Select Case Evnt.Parameter
                    Case "In_Motion"
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Retracting
                        Macros.Run_Macro(CNC.Probe_Callback_Macro)

                    Case "Probe_Error"
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Probe_Error
                        Macros.Run_Macro(CNC.Probe_Callback_Macro)
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Idle

                End Select

            Case enum_Probe_State.Retracting

                Select Case Evnt.Parameter
                    Case "Stopped"
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Done
                        Macros.Run_Macro(CNC.Probe_Callback_Macro)
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Idle
                        Macros.Run_Macro(CNC.Probe_Callback_Macro)

                    Case "Probe_Error"
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Probe_Error
                        Controller.Cycle_Stop()
                        Macros.Run_Macro(CNC.Probe_Callback_Macro)
                        CNC.Probe_State = Class_CNC.enum_Probe_State.Idle

                End Select

        End Select

    End Sub

    Public Sub Start_Probe_Cycle(Macro_Name As String, Direction As enum_Direction)
        CNC.Probe_Callback_Macro = Macro_Name
        CNC.Probe_Start_X = Symbol.Get_Value("Sys.Abs_X")
        CNC.Probe_Start_Y = Symbol.Get_Value("Sys.Abs_Y")
        CNC.Probe_Start_Z = Symbol.Get_Value("Sys.Abs_Z")
        CNC.Probe_Direction = Direction

        Dim Block As String = ""

        Select Case Direction
            Case enum_Direction.E
                Block = "G38.2 X" & (Symbol.Get_Value("Sys.Abs_X") + CNC.Probe_Distance) & " F" & CNC.Probe_Feedrate
            Case enum_Direction.W
                Block = "G38.2 X" & (Symbol.Get_Value("Sys.Abs_X") - CNC.Probe_Distance) & " F" & CNC.Probe_Feedrate
            Case enum_Direction.N
                Block = "G38.2 Y" & (Symbol.Get_Value("Sys.Abs_Y") + CNC.Probe_Distance) & " F" & CNC.Probe_Feedrate
            Case enum_Direction.S
                Block = "G38.2 Y" & (Symbol.Get_Value("Sys.Abs_Y") - CNC.Probe_Distance) & " F" & CNC.Probe_Feedrate
            Case enum_Direction.Down, enum_Direction.Tool_Setter_Measure_Top, enum_Direction.Tool_Setter_Measure_Bottom, enum_Direction.Tool_Setter_Measure_Material
                Block = "G38.2 Z" & (Symbol.Get_Value("Sys.Abs_Z") - CNC.Probe_Distance) & " F" & CNC.Probe_Feedrate
        End Select

        CNC.Probe_State = Class_CNC.enum_Probe_State.Probe_Cycle_Started
        Macros.Run_Macro(CNC.Probe_Callback_Macro)
        Controller.Queue_System_GCode(Block)

    End Sub

    Public Sub Stop_Probe_Cycle()
        CNC.Probe_State = enum_Probe_State.Idle
    End Sub

#End Region


End Class
