Imports System.IO

Public Class Class_Macro_Routines

#Region "Enums"

    Public Enum enum_Axis_Direction
        X_Plus
        X_Minus
        Y_Plus
        Y_Minus
        Z_Plus
        Z_Minus
    End Enum

#End Region

#Region "Declarations"

    Public Pendant_Mode As Integer = 0
    Public Pendant_Message_Pending As Boolean = False

    Public Wait_Callback_Stack As New Stack

    Private Right_X As Single
    Private Left_X As Single
    Private Top_Y As Single
    Private Bottom_Y As Single
    Private Right_Gap As Single
    Private Left_Gap As Single
    Private Top_Gap As Single
    Private Bottom_Gap As Single

    Private Position_Settings As New Class_Settings

    Private G_Code_Program_Name As String
    Private Process_Program_Name As String


#End Region

#Region "Reset"

    Public Sub Reset_Controller()
        Controller.Reset_Controller()
    End Sub

    Public Function Format_Number(Number As Single) As String
        Dim Num As Single = Math.Round(Number)
        Return FormatNumber(Number, 3)
    End Function

    Public Sub Controller_Reset()
        Controller.Controller_Reset()
        Controller.Initialize()

        CNC.Send_Persistant_Positions_To_TinyG()

        'This should be moved to a user macro
        Symbol.Set_Value("Sys.In_E_Stop", False)
        Symbol.Set_Value("Sys.In_Internal_E_Stop", False)
        Symbol.Set_Value("Sys.In_External_E_Stop", False)
        Symbol.Set_Value("Sys.In_Motion", False)

        Wait.Delay_Seconds(1)

        Cycle_Stop()

        Status_Changed()

        Download_Dialog.Hide()

    End Sub

#End Region

#Region "E_Stop"

    Private Sub External_E_Stop(Evnt As Class_CNC.class_Event)
        Controller.E_Stop()
        Spindle_Off()
        Coolant_Off()

        Main_Form.Process_Box.Reset()

        Symbol.Set_Value("Sys.In_E_Stop", True)
        Symbol.Set_Value("Sys.In_External_E_Stop", True)
        Symbol.Set_Value("Sys.In_Feed_Hold", True)
        Symbol.Set_Value("Sys.In_Motion", False)
        Update_Form()

    End Sub


#End Region

#Region "Initialize"

    Public Sub Initialize()
        Wait_Callback_Stack.Clear()

        Symbol.Set_Value("Sys.In_E_Stop", False)
        Symbol.Set_Value("Sys.In_Internal_E_Stop", False)
        Symbol.Set_Value("Sys.In_External_E_Stop", False)
        Symbol.Set_Value("Sys.In_Motion", False)

        Symbol.Set_Value("Sys.In_Cycle_Stop", False)
        Symbol.Set_Value("Sys.In_Feed_Hold", False)

        Symbol.Set_Value("Homed.X", False)
        Symbol.Set_Value("Homed.Y", False)
        Symbol.Set_Value("Homed.Z", False)
        Symbol.Set_Value("Homing.XYZ", False)

        Symbol.Set_Value("Homing.In_Progress", False)
        Symbol.Set_Value("Homing.XYZ", False)
        Symbol.Set_Value("Homing.X", False)
        Symbol.Set_Value("Homing.Y", False)
        Symbol.Set_Value("Homing.Z", False)

        Symbol.Set_Value("Jog_Rate.Step_Mode", False)

        Status_Changed()

        Initialize_Main_Form()

        Update_Form()

        Symbol.Set_Value("Text_Box.Probe.State", "Idle")

        Pendant_Update_Display()
    End Sub

#End Region

#Region "Macro_Handler"

    Public Sub Macro_Wait(Call_Back_Macro As String)
        Wait_Callback_Stack.Push(Call_Back_Macro)
    End Sub

    Public Sub Macro_Resume()
        If Wait_Callback_Stack.Count = 0 Then
            Show_Error("Callback stack error")
            Exit Sub
        End If
        Dim Macro As String = Wait_Callback_Stack.Pop
        Run_Macro(Macro)
    End Sub

    Public Sub Event_Handler(Evnt As Class_CNC.class_Event)
        
        Select Case Evnt.Type

            Case Class_CNC.enum_Event_Types.CNC_Initialized

            Case Class_CNC.enum_Event_Types.Initialize_Done
                Run_Macro("Initialize_Main_Form")

            Case Class_CNC.enum_Event_Types.Reset_Controller
                Run_Macro("Reset_Controller")

            Case Class_CNC.enum_Event_Types.Controller_Reset_Sent

            Case Class_CNC.enum_Event_Types.Controller_Reset
                Run_Macro("Controller_Reset")

            Case Class_CNC.enum_Event_Types.Download_Settings
                Run_Macro("Download_Settings")
            Case Class_CNC.enum_Event_Types.Verify_Settings
                Run_Macro("Verify_Settings")

            Case Class_CNC.enum_Event_Types.Settings_Downloaded
                Run_Macro("Settings_Downloaded")

            Case Class_CNC.enum_Event_Types.Verify_Done
                Run_Macro("Settings_Verified")

            Case Class_CNC.enum_Event_Types.Program_End
                Run_Macro("Program_End")

            Case Class_CNC.enum_Event_Types.Button_Down, Class_CNC.enum_Event_Types.Button_Up, _
                 Class_CNC.enum_Event_Types.Text_Box_Edit, Class_CNC.enum_Event_Types.Text_Box_Left_Click
                Dim Ctrl_Event As Class_CNC.class_Event = Evnt
                Ctrl_Event.Symbol = Ctrl_Event.Ctrl.Tag
                Run_Macro(Ctrl_Event)

            Case Class_CNC.enum_Event_Types.Hot_Key_Down, Class_CNC.enum_Event_Types.Hot_Key_Up
                Dim Ctrl_Event As Class_CNC.class_Event = Evnt
                Run_Macro(Ctrl_Event)

            Case Class_CNC.enum_Event_Types.GCode_Ack
                Main_Form.Process_Box.Block_Sent(Evnt)

            Case Class_CNC.enum_Event_Types.GCode_Update
                Main_Form.Process_Box.Notify(Evnt)

            Case Class_CNC.enum_Event_Types.System_GCode_Ack, Class_CNC.enum_Event_Types.System_GCode_Complete

            Case Class_CNC.enum_Event_Types.Offsets_Changed
                Run_Macro("Offsets_Changed")

            Case Class_CNC.enum_Event_Types.Error_Message
                Run_Macro("External_E_Stop")

            Case Class_CNC.enum_Event_Types.Info_Message

            Case Class_CNC.enum_Event_Types.Text_Message
                'Show_Error("Message from TinyG : " & Evnt.Message)

            Case Class_CNC.enum_Event_Types.Macro_Start, Class_CNC.enum_Event_Types.Macro_End

            Case Class_CNC.enum_Event_Types.Status_Report
                If Evnt.Flags.Position_Changed Then
                    Main_Form.Process_Box.Update_Block_Progress(Evnt)
                    Run_Macro("Status_Changed", Evnt)
                End If
                If Evnt.Flags.State_Changed Then Run_Macro("State_Changed", Evnt)
                If Evnt.Flags.Coordinate_System_Changed Then Run_Macro("Coordinate_System_Changed")
                If Evnt.Flags.Offsets_Changed Then Run_Macro("Offsets_Changed")


            Case Class_CNC.enum_Event_Types.Probe_Status_Update
                CNC.Probe_Status_Update(Evnt)

            Case Class_CNC.enum_Event_Types.Spindle
                Run_Macro("Spindle_Changed", Evnt)

            Case Class_CNC.enum_Event_Types.Coolant
                Run_Macro("Coolant_Changed", Evnt)

            Case Class_CNC.enum_Event_Types.Info_Message
                Show_Error("Message from TinyG : " & Evnt.Message)

        End Select

        'RWC may not need
        Main_Form.btn_Connected.Focus()

    End Sub

    Public Overloads Sub Run_Macro(Handler As String)
        Dim Evnt As New Class_CNC.class_Event
        Evnt.Type = Class_CNC.enum_Event_Types.Macro
        Evnt.Handler = Handler
        Macros.Run_Macro(Evnt)
    End Sub

    Public Overloads Sub Run_Macro(Handler As String, Evnt As Class_CNC.class_Event)
        Evnt.Handler = Handler
        Macros.Run_Macro(Evnt)
    End Sub

    Private Overloads Sub Run_Macro(Evnt As Class_CNC.class_Event)
        Dim Handler As String = ""
        Dim Inhibit_Update_Form As Boolean = False
        Dim Sym As Class_Symbols.class_Symbol = Nothing

        If Not IsNothing(Evnt.Ctrl) Then Sym = Evnt.Ctrl.Tag

        Select Case Evnt.Type

            Case Class_CNC.enum_Event_Types.Button_Down

                Select Case Sym.Type
                    Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label
                        If Not Main_Form.Initialized Then Exit Sub
                        Handler = Sym.Down_Handler

                        Select Case Sym.Type
                            Case Class_Symbols.enum_Symbol_Type.Button
                                Sym.Change_Image(Sym.Down_Image_File)
                                Symbol.Set_Value(Sym.Name, True)
                                Sym.State = True
                                Sym.Value = True

                            Case Class_Symbols.enum_Symbol_Type.Toggle
                                If Sym.State = True Then
                                    Sym.Change_Image(Sym.Up_Image_File)
                                    Sym.State = False
                                Else
                                    Sym.Change_Image(Sym.Down_Image_File)
                                    Sym.State = True
                                End If
                            Case Class_Symbols.enum_Symbol_Type.Label



                        End Select

                End Select

            Case Class_CNC.enum_Event_Types.Button_Up

                If Not Main_Form.Initialized Then Exit Sub

                If Sym.Type = Class_Symbols.enum_Symbol_Type.Button Then
                    Sym.Change_Image(Sym.Up_Image_File)
                    Sym.State = False
                End If
                Handler = Sym.Up_Handler

            Case Class_CNC.enum_Event_Types.Text_Box_Left_Click
                If Not Main_Form.Initialized Then Exit Sub

                If Sym.No_Edit Then Exit Sub
                If Sym.Read_Only Then Exit Sub
                If Sym.Down_Handler = "" Then Exit Sub
                Handler = Sym.Down_Handler

            Case Class_CNC.enum_Event_Types.Text_Box_Edit
                If Not Main_Form.Initialized Then Exit Sub

                If Sym.No_Edit Then Exit Sub
                If Sym.Read_Only Then Exit Sub
                If Sym.Down_Handler = "" Then Exit Sub
                Handler = Sym.Up_Handler

            Case Else
                Handler = Evnt.Handler

        End Select

        If Handler <> "" Then CNC.Cause_Event(Class_CNC.enum_Event_Types.Macro_Start, Handler, "Macro.Run_Macro")

        Select Case Handler

            Case ""
                'Show_Error("No handler")

            Case "Download_Settings"
                Controller.Download_Settings(False)
            Case "Verify_Settings"
                Controller.Download_Settings(True)

            Case "Settings_Downloaded"
                Controller.Settings_Downloaded()
            Case "Settings_Verified"
                Controller.Settings_Verified()

            Case "Reset_Controller"
                Reset_Controller()

            Case "Controller_Reset"
                Controller_Reset()

            Case "E_Stop_Button"
                E_Stop_Button(Evnt)

            Case "Show_Info_Message"
                Show_Info_Message(Evnt)

            Case "Internal_E_Stop"
                Internal_E_Stop()

            Case "External_E_Stop"
                External_E_Stop(Evnt)

            Case "Program_End"
                Program_End()

            Case "Initialize_Main_Form"
                Initialize_Main_Form()

            Case "Status_Changed"
                Status_Changed()

            Case "State_Changed"
                State_Changed(Evnt)

                'Offset routines
            Case "Offsets_Changed"
                Offsets_Changed(Evnt)

            Case "Fixture_Offset_Buttons"
                Fixture_Offset_Buttons(Evnt)

            Case "Tool_Measure_Button"
                Tool_Measure_Button(Evnt)

            Case "Tool_Text_Boxes"
                Tool_Text_Boxes(Evnt)

            Case "Square_Buttons"
                Square_Buttons(Evnt)

            Case "Square_Text_Boxes"
                Square_Text_Boxes(Evnt)

            Case "Fixture_Offset_Text_Boxes"
                Fixture_Offset_Text_Boxes(Evnt)

                'Button handlers
            Case "Cycle_Button"
                Cycle_Button(Evnt)

            Case "Feed_Button"
                Feed_Button(Evnt)
            Case "Feed_Hold"
                Feed_Hold()
            Case "Feed_Resume"
                Feed_Resume()

            Case "Spindle_Button"
                Spindle_Button(Evnt)
            Case "Spindle_On"
                Spindle_On()
            Case "Spindle_Off"
                Spindle_Off()
            Case "Spindle_Changed"
                Spindle_Changed(Evnt)

            Case "Coolant_Button"
                Coolant_Button(Evnt)
            Case "Coolant_On"
                Coolant_On()
            Case "Coolant_Off"
                Coolant_Off()
            Case "Coolant_Changed"
                Coolant_Changed(Evnt)

            Case "Coordinate_System_Changed"
                Coordinate_System_Changed(Evnt)

            Case "Home_Axis_Button"
                Home_Axis_Button(Evnt)
            Case "Disable_Axis_Button"
                Disable_Axis_Button(Evnt)
            Case "Set_Axis_Button"
                Set_Axis_Button(Evnt)

            Case "Jog_Select_Button"
                Jog_Select_Button(Evnt)
            Case "Jog_Button_Down"
                Jog_Button_Down(Evnt)
            Case "Jog_Button_Up"
                Jog_Button_Up(Evnt)

            Case "Move_Buttons"
                Move_Buttons(Evnt)

            Case "Move_Text_Box_Click"
                Move_Text_Box_Click(Evnt)

            Case "Load_Probe"
                Load_Probe(Evnt)

            Case "Probe_Button"
                Probe_Button(Evnt)

            Case "Probe_Text_Box_Click"
                Probe_Text_Box_Click(Evnt)

            Case "Probe_Load_Save"
                Probe_Load_Save(Evnt)

            Case "Probe_Cycle"
                Probe_Cycle()

            Case "Probe_Move_To_Button"
                Probe_Move_To_Button(Evnt)

            Case "Goto_Position_Button"
                Goto_Position_Button(Evnt)

            Case "Pendant_Handler_Down"
                Pendant_Handler_Down(Evnt)

            Case "Pendant_Handler_Up"
                Pendant_Handler_Up(Evnt)

            Case "Jog_Rate_Set"
                Jog_Rate_Set(Evnt)

            Case "Update_Form"
                'Update_Form called below

            Case Else
                Show_Error("No handler : " & Handler)
        End Select

        If Evnt.Type = Class_CNC.enum_Event_Types.Text_Box_Edit Or Evnt.Type = Class_CNC.enum_Event_Types.Text_Box_Left_Click Then
            Symbol.Save_Symbol_Table(Chip_Symbols_File)
        End If

        If Handler <> "" Then CNC.Cause_Event(Class_CNC.enum_Event_Types.Macro_End, Handler, "Macro.Run_Macro")

        If Not Inhibit_Update_Form Then Update_Form()

    End Sub

#End Region

#Region "Commands"

    Private Sub Run_Command(Command As String, Optional Parameter As Object = Nothing)

        Select Case Command

            Case "Sys.Command.Download_Settings"

            Case "Sys.Command.Reset_Controller"
                Reset_Controller()

            Case "Sys.Command.Internal_E_Stop"
                Internal_E_Stop()

            Case "Sys.Command.E_Stop_Reset"
                E_Stop_Reset()

                'Case "Sys.Command.Cycle_Start"
                '    Cycle_Start()

            Case "Sys.Command.Cycle_Stop"
                Cycle_Stop()

            Case "Sys.Command.Feed_Hold"
                Feed_Hold()

            Case "Sys.Command.Feed_Resume"
                Feed_Resume()

            Case "Sys.Command.Enable_Axis"

            Case "Sys.Command.Disable_Axis"

            Case "Sys.Command.G_Code"

        End Select

    End Sub

    Private Sub Show_Info_Message(Evnt As Class_CNC.class_Event)
        Flash_Message(Evnt.Message)
    End Sub

#End Region

#Region "Macro Subroutines and Functions"

    Public Sub Cause_Button_Event(Button_Name As String, Optional Down As Boolean = True)
        Dim sym As Class_Symbols.class_Symbol
        Dim Evnt As New Class_CNC.class_Event
        sym = Symbol.Get_Symbol(Button_Name, True)
        Evnt.Ctrl = sym.Ctrl
        If Down Then
            Evnt.Type = Class_CNC.enum_Event_Types.Button_Down
        Else
            Evnt.Type = Class_CNC.enum_Event_Types.Button_Up
        End If
        Main_Form.Enqueue_Controller_Event(Evnt)
    End Sub

    Private Overloads Function Is_In_Position(X As Single, Y As Single) As Boolean
        If X <> Symbol.Get_Value("Sys.Abs_X.Round_3") Then Return False
        If Y <> Symbol.Get_Value("Sys.Abs_Y.Round_3") Then Return False
        Return True
    End Function

    Private Overloads Function Is_In_Position(X As Single, Y As Single, Z As Single) As Boolean
        If X <> Symbol.Get_Value("Sys.Abs_X.Round_3") Then Return False
        If Y <> Symbol.Get_Value("Sys.Abs_Y.Round_3") Then Return False
        If Z <> Symbol.Get_Value("Sys.Abs_Z.Round_3") Then Return False
        Return True
    End Function

    Private Overloads Function Is_In_Position(X As String, Y As String, Optional Z As String = "") As Boolean
        If X <> "" Then
            If Symbol.Get_Value(X) <> Symbol.Get_Value("Sys.Abs_X.Round_3") Then Return False
        End If
        If Y <> "" Then
            If Symbol.Get_Value(Y) <> Symbol.Get_Value("Sys.Abs_Y.Round_3") Then Return False
        End If
        If Z <> "" Then
            If Symbol.Get_Value(Z) <> Symbol.Get_Value("Sys.Abs_Z.Round_3") Then Return False
        End If
        Return True
    End Function

    Private Sub Program_End()
        Controller.Queue_System_GCode("M1002 (End of Program)")
    End Sub

    Public Sub Get_Text_Box_Edit(Default_Value As String, Text_Box As String, Prompt As String, Button_Text As String, Optional Number As Boolean = True)
        Dim Value As String = Symbol.Get_Value(Text_Box)
        Value = Get_User_Input(Value, Prompt, Default_Value, Button_Text, Number)
        If IsNothing(Value) Then Exit Sub
        Symbol.Set_Value(Text_Box, Value)
    End Sub

    Public Function Get_Current_Offset_File_Name() As String
        Dim Folder = Symbol.Get_Value("Text_Box.Fixture_Offset.Folder")
        Dim File = Symbol.Get_Value("Text_Box.Fixture_Offset.File")
        Return Folder & "\" & File
    End Function

    Public Sub Set_Current_Offset_File_Name(Offset_File_Name As String)
        Symbol.Set_Value("Text_Box.Fixture_Offset.Folder", Path.GetDirectoryName(Offset_File_Name))
        Symbol.Set_Value("Text_Box.Fixture_Offset.File", Path.GetFileName(Offset_File_Name))
    End Sub

    Public Sub Program_Changed(GCode_File_Name As String, GCode_File_Header As List(Of String))
        Dim S() As String = Nothing
        Dim P() As String = Nothing
        Dim Block_Name As String = ""

        G_Code_Program_Name = GCode_File_Name

        Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.X.Round_3", "Text_Box.Fixture_Offset.Original.X.Round_3")
        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.X.Round_3", 0)
        Controller.Set_Offset_X("G55", Symbol.Get_Value("Text_Box.Fixture_Offset.Original.X.Round_3"))

        Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.Y.Round_3", "Text_Box.Fixture_Offset.Original.Y.Round_3")
        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3", 0)
        Controller.Set_Offset_Y("G55", Symbol.Get_Value("Text_Box.Fixture_Offset.Original.Y.Round_3"))

        Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.Z.Round_3", "Text_Box.Fixture_Offset.Original.Z.Round_3")
        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", 0)
        Controller.Set_Offset_Z("G55", Symbol.Get_Value("Text_Box.Fixture_Offset.Original.Z.Round_3"))


    End Sub

#End Region

#Region "Status_Changed, State_Changed Macros"

    Public Sub Status_Changed()
        Symbol.Set_Equal("Text_Box.Abs_Pos.X.Round_3", "Sys.Abs_X")
        Symbol.Set_Equal("Text_Box.Abs_Pos.Y.Round_3", "Sys.Abs_Y")
        Symbol.Set_Equal("Text_Box.Abs_Pos.Z.Round_3", "Sys.Abs_Z")

        If Symbol.Get_Value("Sys.Coordinate_System") <= Class_CNC.enum_Coordinate_System.G54 Then
            Symbol.Set_Value("Text_Box.Work_Pos.X.Round_3", Symbol.Get_Value("Sys.Abs_X") - Symbol.Get_Value("Sys.Offset_X"))
            Symbol.Set_Value("Text_Box.Work_Pos.Y.Round_3", Symbol.Get_Value("Sys.Abs_Y") - Symbol.Get_Value("Sys.Offset_Y"))
            Symbol.Set_Value("Text_Box.Work_Pos.Z.Round_3", Symbol.Get_Value("Sys.Abs_Z") - Symbol.Get_Value("Sys.Offset_Z"))
        Else
            Symbol.Set_Equal("Text_Box.Work_Pos.X.Round_3", "Sys.Work_X")
            Symbol.Set_Equal("Text_Box.Work_Pos.Y.Round_3", "Sys.Work_Y")
            Symbol.Set_Equal("Text_Box.Work_Pos.Z.Round_3", "Sys.Work_Z")
        End If

        Pendant_Update_Display()

        Symbol.Set_Equal("Text_Box.Velocity", "Sys.Velocity")


        If Camera_Controls.Visible Then
            Camera_Controls.Update_Positions()
        End If

    End Sub

    Private Sub State_Changed(Evnt As Class_CNC.class_Event)

        Main_Form.ts_Main_State.Text = CNC.State.ToString
        Main_Form.txt_State_Current.Text = CNC.Current_State.ToString
        Main_Form.txt_State_Last.Text = CNC.Last_State.ToString
        Main_Form.txt_State_Previous.Text = CNC.Previous_State.ToString

        Select Case CNC.State

            Case Class_CNC.enum_Status_Codes.Controller_Initializing, Class_CNC.enum_Status_Codes.Ready, _
                Class_CNC.enum_Status_Codes.Feedhold, Class_CNC.enum_Status_Codes.Alarm, Class_CNC.enum_Status_Codes.Program_End
                Symbol.Set_Value("Sys.In_Motion", False)

            Case Class_CNC.enum_Status_Codes.In_Motion, Class_CNC.enum_Status_Codes.Homing, _
                Class_CNC.enum_Status_Codes.Cycling, Class_CNC.enum_Status_Codes.Probing
                Symbol.Set_Value("Sys.In_Motion", True)

            Case Class_CNC.enum_Status_Codes.Stopped
                CNC.Save_Persistant_Positions()
                Main_Form.chk_Soft_Limits.Checked = True
                Symbol.Set_Value("Sys.Soft_Limits_Enabled", True)
                Symbol.Set_Value("Sys.In_Motion", False)

                If CNC.Last_State = Class_CNC.enum_Status_Codes.Homing Then

                    If Symbol.Get_Value("Homing.In_Progress") Then
                        Symbol.Set_Value("Homing.In_Progress", False)

                        If Symbol.Get_Value("Homing.X") Then
                            Symbol.Set_Value("Homed.X", True)
                            Symbol.Set_Value("Homing.X", False)
                            CNC.Set_Position(Class_CNC.enum_Axis.X, Symbol.Get_Value("Sys.Min_X"))
                        End If

                        If Symbol.Get_Value("Homing.Y") Then
                            Symbol.Set_Value("Homed.Y", True)
                            Symbol.Set_Value("Homing.Y", False)
                            CNC.Set_Position(Class_CNC.enum_Axis.Y, Symbol.Get_Value("Sys.Min_Y"))
                        End If

                        If Symbol.Get_Value("Homing.Z") Then
                            Symbol.Set_Value("Homed.Z", True)
                            Symbol.Set_Value("Homing.Z", False)
                            CNC.Set_Position(Class_CNC.enum_Axis.Z, Symbol.Get_Value("Sys.Max_Z"))
                        End If

                        If Symbol.Get_Value("Homed.X") And _
                           Symbol.Get_Value("Homed.Y") And _
                           Symbol.Get_Value("Homed.Z") Then
                            Symbol.Set_Value("Homed.XYZ", True)
                            Symbol.Set_Value("Homing.XYZ", False)
                        End If

                        Update_Form()
                    End If
                End If

            Case Else

        End Select

    End Sub

#End Region

#Region "Form Macros"

    Private Sub Initialize_Main_Form()

        Run_Command("Sys.Command.Cycle_Stop")

        CNC.Probe_State = Class_CNC.enum_Probe_State.Idle

        Symbol.Change_Image("Button.Feed", "Feed_Hold.png")

        Symbol.Set_Value("Homed.XYZ", False)
        Symbol.Set_Value("Homed.X", False)
        Symbol.Set_Value("Homed.Y", False)
        Symbol.Set_Value("Homed.Z", False)

        Symbol.Set_Value("Text_Box.Abs_Pos.X", 0)
        Symbol.Set_Value("Text_Box.Abs_Pos.Y", 0)
        Symbol.Set_Value("Text_Box.Abs_Pos.Z", 0)

        Symbol.Set_Value("Text_Box.Work_Pos.X", 0)
        Symbol.Set_Value("Text_Box.Work_Pos.Y", 0)
        Symbol.Set_Value("Text_Box.Work_Pos.Z", 0)

        Symbol.Set_Value("Text_Box.Velocity", 0)
        Symbol.Set_Value("Text_Box.Feedrate", Format_Number(0))

        Symbol.Set_Value("Button.Jog_Rate.Big_Step", Symbol.Get_Value("Text_Box.Jog_Rate.Big_Step"))
        Symbol.Set_Value("Button.Jog_Rate.Little_Step", Symbol.Get_Value("Text_Box.Jog_Rate.Little_Step"))


        Symbol.Set_Value("Button.Jog_Rate.Fast", True)
        Symbol.Set_Value("Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Fast"))
        Symbol.Change_Image("Button.Jog_Rate.Fast", "Green_Bar_On.png")

        Symbol.Set_Value("Sys.In_Motion", False)
        Symbol.Set_Value("Sys.In_Feed_Hold", False)

        Controller.Queue_System_GCode("G54")

        If Symbol.Get_Value("Button.Fixture_Offset.Z0_Bottom") = True Then
            Symbol.Set_Value("Button.Fixture_Offset.Z0_Top", False)
            Symbol.Change_Image("Button.Fixture_Offset.Z0_Top", "Green_Bar_Off.png")
            Symbol.Set_Value("Button.Fixture_Offset.Z0_Bottom", True)
            Symbol.Change_Image("Button.Fixture_Offset.Z0_Bottom", "Green_Bar_On.png")

            Symbol.Set_Value("Button.Tool_Measure.Bottom.Enabled", True)
            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Bottom.Enabled", True)
            Symbol.Set_Value("Button.Tool_Measure.Top.Enabled", False)
            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Top.Enabled", False)
        Else
            Symbol.Set_Value("Button.Fixture_Offset.Z0_Top", True)
            Symbol.Change_Image("Button.Fixture_Offset.Z0_Top", "Green_Bar_On.png")
            Symbol.Set_Value("Button.Fixture_Offset.Z0_Bottom", False)
            Symbol.Change_Image("Button.Fixture_Offset.Z0_Bottom", "Green_Bar_Off.png")

            Symbol.Set_Value("Button.Tool_Measure.Bottom.Enabled", False)
            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Bottom.Enabled", False)
            Symbol.Set_Value("Button.Tool_Measure.Top.Enabled", True)
            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Top.Enabled", True)
        End If

    End Sub

    Private Sub Update_Form()

        If Symbol.Get_Value("Sys.In_Motion") Then
            Symbol.Set_Value("Sys.In_Cycle_Stop", False)
        Else
            Symbol.Set_Value("Sys.In_Cycle_Stop", True)
        End If

        If Symbol.Get_Value("Sys.In_E_Stop") Then
            Symbol.Change_Image("Button.E_Stop", "E_Stop_Reset.png")
        Else
            Symbol.Change_Image("Button.E_Stop", "E_Stop_Up.png")
        End If

        If Symbol.Get_Value("Sys.In_Cycle_Stop") Then
            Symbol.Change_Image("Button.Cycle", "Cycle_Start.png")
        Else
            Symbol.Change_Image("Button.Cycle", "Cycle_Stop.png")
        End If

        If Symbol.Get_Value("Sys.In_Feed_Hold") Then
            Symbol.Change_Image("Button.Feed", "Feed_Resume.png")
        Else
            Symbol.Change_Image("Button.Feed", "Feed_Hold.png")
        End If

        If Symbol.Get_Value("Sys.Spindle") Then
            Symbol.Change_Image("Button.Spindle", "Spindle_Off.png")
        Else
            Symbol.Change_Image("Button.Spindle", "Spindle_On.png")
        End If

        If Symbol.Get_Value("Sys.Coolant") Then
            Symbol.Change_Image("Button.Coolant", "Coolant_Off.png")
        Else
            Symbol.Change_Image("Button.Coolant", "Coolant_On.png")
        End If

        If Symbol.Get_Value("Probe.In_Spindle") Then
            Symbol.Change_Image("Button.Probe_Loaded", "Red_Bar_On.png")
            Symbol.Set_Value("Button.Probe_Loaded.Text", "Unload Probe")
        Else
            Symbol.Change_Image("Button.Probe_Loaded", "Green_Bar_On.png")
            Symbol.Set_Value("Button.Probe_Loaded.Text", "Load Probe")
        End If

        If Symbol.Get_Value("Homed.XYZ") Then
            Symbol.Change_Image("Button.Homed", "Green_Bar_On.png")
            Symbol.Set_Value("Button.Homed.Text", "Homed")
            Symbol.Change_Image("Button.Home_XYZ", "Button_Green_Light.png")
            Symbol.Set_Value("Button.Home_XYZ.Text", "Homed")
        Else
            If Symbol.Get_Value("Homing.XYZ") Then
                Symbol.Change_Image("Button.Homed", "Yellow_Bar_On.png")
                Symbol.Set_Value("Button.Homed.Text", "Homing")
                Symbol.Change_Image("Button.Home_XYZ", "Button_Yellow_Light.png")
                Symbol.Set_Value("Button.Home_XYZ.Text", "Homing")
            Else
                Symbol.Change_Image("Button.Homed", "Red_Bar_On.png")
                Symbol.Set_Value("Button.Homed.Text", "Home")
                Symbol.Change_Image("Button.Home_XYZ", "Button_Red_Light.png")
                Symbol.Set_Value("Button.Home_XYZ.Text", "Home")
            End If
        End If

        If Symbol.Get_Value("Homed.X") Then
            Symbol.Change_Image("Button.Home_X", "Button_Green_Light.png")
            Symbol.Set_Value("Button.Home_X.Text", "Homed")
        Else
            If Symbol.Get_Value("Homing.X") Then
                Symbol.Change_Image("Button.Home_X", "Button_Yellow_Light.png")
                Symbol.Set_Value("Button.Home_X.Text", "Homing")
            Else
                Symbol.Change_Image("Button.Home_X", "Button_Red_Light.png")
                Symbol.Set_Value("Button.Home_X.Text", "Home")
            End If
        End If

        If Symbol.Get_Value("Homed.Y") Then
            Symbol.Change_Image("Button.Home_Y", "Button_Green_Light.png")
            Symbol.Set_Value("Button.Home_Y.Text", "Homed")
        Else
            If Symbol.Get_Value("Homing.Y") Then
                Symbol.Change_Image("Button.Home_Y", "Button_Yellow_Light.png")
                Symbol.Set_Value("Button.Home_Y.Text", "Homing")
            Else
                Symbol.Change_Image("Button.Home_Y", "Button_Red_Light.png")
                Symbol.Set_Value("Button.Home_Y.Text", "Home")
            End If
        End If

        If Symbol.Get_Value("Homed.Z") Then
            Symbol.Change_Image("Button.Home_Z", "Button_Green_Light.png")
            Symbol.Set_Value("Button.Home_Z.Text", "Homed")
        Else
            If Symbol.Get_Value("Homing.Z") Then
                Symbol.Change_Image("Button.Home_Z", "Button_Yellow_Light.png")
                Symbol.Set_Value("Button.Home_Z.Text", "Homing")
            Else
                Symbol.Change_Image("Button.Home_Z", "Button_Red_Light.png")
                Symbol.Set_Value("Button.Home_Z.Text", "Home")
            End If
        End If

        If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Text_Box.Jog_Rate.Fast") Then
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected", "Fast")
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected.Back_Color", "Red")
        End If

        If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Text_Box.Jog_Rate.Slow") Then
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected", "Slow")
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected.Back_Color", "Yellow")
        End If

        If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Text_Box.Jog_Rate.Creep") Then
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected", "Creep")
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected.Back_Color", "YellowGreen")
        End If

        If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Text_Box.Jog_Rate.Big_Step") Then
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Big_Step"))
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected.Back_Color", "YellowGreen")
        End If

        If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Text_Box.Jog_Rate.Little_Step") Then
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Little_Step"))
            Symbol.Set_Value("Text_Box.Jog_Rate.Selected.Back_Color", "YellowGreen")
        End If

        If Symbol.Get_Value("Sys.Coordinate_System") <= Class_CNC.enum_Coordinate_System.G54 Then
            Symbol.Set_Value("Text_Box.Coordinate_System", "G54")
            Symbol.Set_Value("Text_Box.Coordinate_System.Back_Color", "Gainsboro")
            Symbol.Set_Value("Text_Box.Offset.X.Back_Color", "Gainsboro")
            Symbol.Set_Value("Text_Box.Offset.Y.Back_Color", "Gainsboro")
            If Symbol.Get_Value("Sys.Offset.Z_Zero_Set") = False Then
                Symbol.Set_Value("Text_Box.Offset.Z.Back_Color", "Red")
            Else
                Symbol.Set_Value("Text_Box.Offset.Z.Back_Color", "Gainsboro")
            End If

        Else
            Symbol.Set_Value("Text_Box.Coordinate_System", "G55")
            Symbol.Set_Value("Text_Box.Coordinate_System.Back_Color", "MistyRose")
            Symbol.Set_Value("Text_Box.Coordinate_System.Back_Color", "MistyRose")
            Symbol.Set_Value("Text_Box.Offset.X.Back_Color", "MistyRose")
            Symbol.Set_Value("Text_Box.Offset.Y.Back_Color", "MistyRose")
            If Symbol.Get_Value("Sys.Offset.Z_Zero_Set") = False Then
                Symbol.Set_Value("Text_Box.Offset.Z.Back_Color", "Red")
            Else
                Symbol.Set_Value("Text_Box.Offset.Z.Back_Color", "MistyRose")
            End If
        End If

        Symbol.Set_Equal("Text_Box.Offset.X.Round_3", "Sys.Offset_X")
        Symbol.Set_Equal("Text_Box.Offset.Y.Round_3", "Sys.Offset_Y")
        Symbol.Set_Equal("Text_Box.Offset.Z.Round_3", "Sys.Offset_Z")

        Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.X.Round_3", "Sys.Offset_X")
        Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.Y.Round_3", "Sys.Offset_Y")
        Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.Z.Round_3", "Sys.Offset_Z")

        Pendant_Update_Display()

    End Sub

#End Region

#Region "E_Stop, Cycle, Feed Button Handlers"

    Private Sub E_Stop_Button(Evnt As Class_CNC.class_Event)

        If Symbol.Get_Value("Sys.In_E_Stop") Then
            E_Stop_Reset()
        Else
            Internal_E_Stop()
        End If

    End Sub

    Private Sub Cycle_Button(Evnt As Class_CNC.class_Event)

        If Symbol.Get_Value("Sys.In_Cycle_Stop") Then
            Cycle_Start()
        Else
            Cycle_Stop()
        End If

        Update_Form()

    End Sub

    Private Sub Feed_Button(Evnt As Class_CNC.class_Event)
        If Symbol.Get_Value("Sys.In_Feed_Hold") Then
            If Not Symbol.Get_Value("Sys.In_E_Stop") Then
                Run_Macro("Feed_Resume")
            End If
        Else
            Run_Macro("Feed_Hold")
        End If

        Controller.Request_Status_Report()

    End Sub

    Private Sub Internal_E_Stop()
        Controller.E_Stop()
        Spindle_Off()
        Coolant_Off()
        Main_Form.Process_Box.Reset()
        Symbol.Set_Value("Sys.In_E_Stop", True)
        Symbol.Set_Value("Sys.In_Internal_E_Stop", True)
    End Sub

    Private Sub E_Stop_Reset()
        If Symbol.Get_Value("Sys.In_External_E_Stop") Then
            Reset_Controller()
        Else
            Controller.E_Stop_Reset() 'Cycle start
        End If
        Symbol.Set_Value("Sys.In_External_E_Stop", False)
        Symbol.Set_Value("Sys.In_Internal_E_Stop", False)
    End Sub

    Private Sub Cycle_Start()
        If CNC.Inhibited Then Exit Sub

        If Not Symbol.Get_Value("Homed.XYZ") Then
            Show_Error("Axes need to be homed before Executing program.")
            Exit Sub
        End If

        If Symbol.Get_Value("Sys.In_E_Stop") Then
            Show_Error("In E Stop")
            Exit Sub
        End If

        Controller.Cycle_Start()
        Main_Form.Process_Box.Start_Program_Execution()
    End Sub

    Private Sub Cycle_Stop()
        Main_Form.Process_Box.Stop_Program_Execution()
        Controller.Cycle_Stop()
    End Sub

    Private Sub Feed_Hold()
        Controller.Feed_Hold()
    End Sub

    Private Sub Feed_Resume()
        If Not Symbol.Get_Value("Sys.In_E_Stop") Then
            Controller.Feed_Resume()
            Update_Form()
        End If
    End Sub

#End Region

#Region "Set Axis, Disable Axis Buttons"

    Private Sub Set_Axis_Button(Evnt As Class_CNC.class_Event)
        Dim Pos As String = ""
        Dim Prompt As String = ""
        Dim Default_Value As Single = 0
        Dim Value As Single = 0

        Select Case Evnt.Symbol.Name
            Case "Button.Set.X"
                Pos = Symbol.Get_Value("Sys.Abs_X.Round_3")
                Prompt = "Enter X Position or click default"
                Default_Value = 0

            Case "Button.Set.Y"
                Pos = Symbol.Get_Value("Sys.Abs_Y.Round_3")
                Prompt = "Enter Y Position or click default"
                Default_Value = 0
            Case "Button.Set.Z"
                Pos = Symbol.Get_Value("Sys.Abs_Z.Round_3")
                Prompt = "Enter Z Position or click default"
                Default_Value = 6
        End Select

        Pos = Format_Number(Pos)

        Pos = Get_User_Input(Pos, Prompt, Default_Value, "Default")

        If IsNumeric(Pos) Then
            Value = CSng(Pos)
            Select Case Evnt.Symbol.Name
                Case "Button.Set.X"
                    CNC.Set_Position(Class_CNC.enum_Axis.X, Value)
                Case "Button.Set.Y"
                    CNC.Set_Position(Class_CNC.enum_Axis.Y, Value)
                Case "Button.Set.Z"
                    CNC.Set_Position(Class_CNC.enum_Axis.Z, Value)
            End Select

        Else
            If Not IsNothing(Pos) Then Flash_Message("Value not a number")
        End If

    End Sub

    Private Sub Disable_Axis_Button(Evnt As Class_CNC.class_Event)
        If Controller.Check_For_In_Cycle("Cannot disable axis while in cycle") Then Exit Sub

        Select Case Evnt.Symbol.Name
            Case "Button.Enable_X"
                Controller.Enable_Axis(Class_CNC.enum_Axis.X, False)
            Case "Button.Enable_Y"
                Controller.Enable_Axis(Class_CNC.enum_Axis.Y, False)
            Case "Button.Enable_Z"
                Controller.Enable_Axis(Class_CNC.enum_Axis.Z, False)
        End Select

    End Sub

#End Region

#Region "Home Handlers"

    Private Sub Home_Axis_Button(Evnt As Class_CNC.class_Event)
        If CNC.Inhibited Then Exit Sub

        If Controller.Check_For_In_Cycle("Cannot home while in cycle") Then Exit Sub

        Dim sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag

        Select Case sym.Name
            Case "Button.Home_XYZ", "Button.Homed"
                Symbol.Set_Value("Homing.In_Progress", True)
                Symbol.Set_Value("Homed.X", False)
                Symbol.Set_Value("Homed.Y", False)
                Symbol.Set_Value("Homed.Z", False)
                Symbol.Set_Value("Homed.XYZ", False)
                Symbol.Set_Value("Homing.X", True)
                Symbol.Set_Value("Homing.Y", True)
                Symbol.Set_Value("Homing.Z", True)
                Symbol.Set_Value("Homing.XYZ", True)
                Controller.Queue_System_GCode("G28.2 X0 Y0 Z0", False, False)
                Controller.Enable_Axis(Class_CNC.enum_Axis.X, False)
                Controller.Enable_Axis(Class_CNC.enum_Axis.Y, False)
                Controller.Enable_Axis(Class_CNC.enum_Axis.Z, False)

            Case "Button.Home_X"
                If Not Symbol.Get_Value("Homed.Z") Then
                    Show_Error("Cannot home X until Z hommed.")
                    Exit Sub
                End If
                Symbol.Set_Value("Homed.XYZ", False)
                Symbol.Set_Value("Homing.In_Progress", True)
                Symbol.Set_Value("Homed.X", False)
                Symbol.Set_Value("Homing.X", True)
                Controller.Queue_System_GCode("G28.2 X0", False, False)
                Controller.Enable_Axis(Class_CNC.enum_Axis.X, False)

            Case "Button.Home_Y"
                If Not Symbol.Get_Value("Homed.Z") Then
                    Show_Error("Cannot home X until Z hommed.")
                    Exit Sub
                End If
                Symbol.Set_Value("Homed.XYZ", False)
                Symbol.Set_Value("Homing.In_Progress", True)
                Symbol.Set_Value("Homed.Y", False)
                Symbol.Set_Value("Homing.Y", True)
                Controller.Queue_System_GCode("G28.2 Y0", False, False)
                Controller.Enable_Axis(Class_CNC.enum_Axis.Y, False)

            Case "Button.Home_Z"
                Symbol.Set_Value("Homed.XYZ", False)
                Symbol.Set_Value("Homing.In_Progress", True)
                Symbol.Set_Value("Homed.Z", False)
                Symbol.Set_Value("Homing.Z", True)
                Controller.Queue_System_GCode("G28.2 Z0", False, False)
                Controller.Enable_Axis(Class_CNC.enum_Axis.Z, False)

        End Select

        Controller.Request_Status_Report()
        Update_Form()

    End Sub
#End Region

#Region "Jog Handlers"

    Private Sub Jog_Button_Down(Evnt As Class_CNC.class_Event)
        Dim G_Code As String = ""
        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag
        Dim Jog_Rate As Single = Symbol.Get_Value("Jog_Rate.Selected")
        Dim Step_Distance As Single = Symbol.Get_Value("Jog_Rate.Selected")
        Dim Probe_Retract As Boolean = False
        Dim Safe_Z As Single
        Dim Probe_Check As Boolean = True

        If CNC.Inhibited Then Exit Sub

        If Symbol.Get_Value("Probe.In_Spindle") Then
            Safe_Z = Symbol.Get_Value("Text_Box.Probe.Safe_Z")
        Else
            Safe_Z = Symbol.Get_Value("Text_Box.Jog.Safe_Z")
        End If

        If Sym.Name <> "Button.Jog.Z_Plus" Then

            If Not Symbol.Get_Value("Homed.Z") Then
                If Not Symbol.Get_Value("Sys.Soft_Limits_Enabled") Then
                    Show_Error("Z must be homed before jog is enabled, or uncheck Soft Limits.")
                    Exit Sub
                End If
            End If

            If Symbol.Get_Value("Sys.Abs_Z") <= Safe_Z Then
                If Jog_Rate > Symbol.Get_Value("Text_Box.Jog_Rate.Slow") Then Jog_Rate = Symbol.Get_Value("Text_Box.Jog_Rate.Slow")
            End If

        End If


        If Symbol.Get_Value("Jog_Rate.Step_Mode") Then  'Step

            Select Case Sym.Name
                Case "Button.Jog.X_Plus"
                    G_Code = "G90 G54 G01 X" & Symbol.Get_Value("Sys.Abs_X") + Step_Distance & " F15"

                Case "Button.Jog.X_Minus"
                    G_Code = "G90 G54 G01 X" & Symbol.Get_Value("Sys.Abs_X") - Step_Distance & " F15"

                Case "Button.Jog.Y_Plus"
                    G_Code = "G90 G54 G01 Y" & Symbol.Get_Value("Sys.Abs_Y") + Step_Distance & " F15"

                Case "Button.Jog.Y_Minus"
                    G_Code = "G90 G54 G01 Y" & Symbol.Get_Value("Sys.Abs_Y") - Step_Distance & " F15"

                Case "Button.Jog.Z_Plus"
                    G_Code = "G90 G54 G01 Z" & Symbol.Get_Value("Sys.Abs_Z") + Step_Distance & " F15"

                Case "Button.Jog.Z_Minus"
                    G_Code = "G90 G54 G01 Z" & Symbol.Get_Value("Sys.Abs_Z") - Step_Distance & " F15"

            End Select

        Else 'Continuous Jog


            Select Case Sym.Name
                Case "Button.Jog.X_Plus"
                    If Symbol.Get_Value("Homed.X") And Symbol.Get_Value("Sys.Soft_Limits_Enabled") Then
                        G_Code = "G90 G54 G01 X" & Symbol.Get_Value("Sys.Max_X") & " F" & Jog_Rate
                    Else
                        G_Code = "G90 G54 G01 X" & 1000 & " F" & Jog_Rate
                    End If

                Case "Button.Jog.X_Minus"
                    If Symbol.Get_Value("Homed.X") And Symbol.Get_Value("Sys.Soft_Limits_Enabled") Then
                        If Symbol.Get_Value("Sys.Abs_X") > Symbol.Get_Value("Sys.Min_X") Then
                            G_Code = "G90 G54 G01 X" & Symbol.Get_Value("Sys.Min_X") & " F" & Jog_Rate
                        End If
                    Else
                        G_Code = "G90 G54 G01 X" & -1000 & " F" & Jog_Rate
                    End If

                Case "Button.Jog.Y_Plus"
                    If Symbol.Get_Value("Homed.Y") And Symbol.Get_Value("Sys.Soft_Limits_Enabled") Then
                        G_Code = "G90 G54 G01 Y" & Symbol.Get_Value("Sys.Max_Y") & " F" & Jog_Rate
                    Else
                        G_Code = "G90 G54 G01 Y" & 1000 & " F" & Jog_Rate
                    End If

                Case "Button.Jog.Y_Minus"
                    If Symbol.Get_Value("Homed.Y") And Symbol.Get_Value("Sys.Soft_Limits_Enabled") Then
                        If Symbol.Get_Value("Sys.Abs_Y") > Symbol.Get_Value("Sys.Min_Y") Then
                            G_Code = "G90 G54 G01 Y" & Symbol.Get_Value("Sys.Min_Y") & " F" & Jog_Rate
                        End If
                    Else
                        G_Code = "G90 G54 G01 Y" & -1000 & " F" & Jog_Rate
                    End If

                Case "Button.Jog.Z_Plus"
                    Probe_Check = False
                    If Jog_Rate > 60 Then Jog_Rate = 60
                    Probe_Retract = True
                    If Symbol.Get_Value("Homed.Z") And Symbol.Get_Value("Sys.Soft_Limits_Enabled") Then
                        If Symbol.Get_Value("Sys.Abs_Z") < Symbol.Get_Value("Sys.Max_Z") Then
                            G_Code = "G90 G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & " F" & Jog_Rate
                        Else
                            G_Code = "G90 G54 G01 Z" & 1000 & " F" & Jog_Rate
                        End If
                    Else
                        G_Code = "G90 G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & " F" & Jog_Rate
                    End If

                Case "Button.Jog.Z_Minus"
                    Probe_Check = True

                    If Symbol.Get_Value("Homed.Z") Then
                        If Symbol.Get_Value("Sys.Abs_Z") > Safe_Z Then
                            G_Code = "G90 G54 G01 Z" & Safe_Z & " F" & Jog_Rate
                        Else
                            'If Jog_Rate > Symbol.Get_Value("Text_Box.Jog_Rate.Slow") Then Jog_Rate = Symbol.Get_Value("Text_Box.Jog_Rate.Slow")
                            G_Code = "G90 G54 G01 Z" & -1000 & " F" & Jog_Rate
                        End If
                    End If

            End Select

        End If

        If Not Symbol.Get_Value("Probe.In_Spindle") Then Probe_Check = False
        Controller.Queue_System_GCode(G_Code, False, Probe_Check)

    End Sub

    Private Sub Jog_Select_Button(Evnt As Class_CNC.class_Event)

        Dim sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag

        Symbol.Set_Value("Button.Jog_Rate.Fast", False)
        Symbol.Set_Value("Button.Jog_Rate.Slow", False)
        Symbol.Set_Value("Button.Jog_Rate.Creep", False)
        Symbol.Set_Value("Button.Jog_Rate.Big_Step", False)
        Symbol.Set_Value("Button.Jog_Rate.Little_Step", False)
        Symbol.Set_Value("Jog_Rate.Step_Mode", False)

        Symbol.Change_Image("Button.Jog_Rate.Fast", "Green_Bar_Off.png")
        Symbol.Change_Image("Button.Jog_Rate.Slow", "Green_Bar_Off.png")
        Symbol.Change_Image("Button.Jog_Rate.Creep", "Green_Bar_Off.png")
        Symbol.Change_Image("Button.Jog_Rate.Big_Step", "Green_Bar_Off.png")
        Symbol.Change_Image("Button.Jog_Rate.Little_Step", "Green_Bar_Off.png")

        Select Case sym.Name
            Case "Button.Jog_Rate.Fast"
                Symbol.Set_Value("Button.Jog_Rate.Fast", True)
                Symbol.Set_Value("Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Fast"))
                Symbol.Change_Image("Button.Jog_Rate.Fast", "Green_Bar_On.png")
            Case "Button.Jog_Rate.Slow"
                Symbol.Set_Value("Button.Jog_Rate.Slow", True)
                Symbol.Set_Value("Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Slow"))
                Symbol.Change_Image("Button.Jog_Rate.Slow", "Green_Bar_On.png")
            Case "Button.Jog_Rate.Creep"
                Symbol.Set_Value("Button.Jog_Rate.Creep", True)
                Symbol.Set_Value("Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Creep"))
                Symbol.Change_Image("Button.Jog_Rate.Creep", "Green_Bar_On.png")
            Case "Button.Jog_Rate.Big_Step"
                Symbol.Set_Value("Jog_Rate.Step_Mode", True)
                Symbol.Set_Value("Button.Jog_Rate.Big_Step", True)
                Symbol.Set_Value("Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Big_Step"))
                Symbol.Change_Image("Button.Jog_Rate.Big_Step", "Green_Bar_On.png")
            Case "Button.Jog_Rate.Little_Step"
                Symbol.Set_Value("Jog_Rate.Step_Mode", True)
                Symbol.Set_Value("Button.Jog_Rate.Little_Step", True)
                Symbol.Set_Value("Jog_Rate.Selected", Symbol.Get_Value("Text_Box.Jog_Rate.Little_Step"))
                Symbol.Change_Image("Button.Jog_Rate.Little_Step", "Green_Bar_On.png")
        End Select

        Symbol.Set_Value("Text_Box.Jog_Rate.Selected", (Symbol.Get_Value("Jog_Rate.Selected")))

        Macros.Update_Form()

        Pendant_Update_Display()

        Camera_Controls.Update_Positions()

    End Sub

    Private Sub Jog_Button_Up(Evnt As Class_CNC.class_Event)
        If Not Symbol.Get_Value("Jog_Rate.Step_Mode") Then Cycle_Stop()
    End Sub

    Private Sub Jog_Rate_Set(Evnt As Class_CNC.class_Event)
        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag
        Dim Prompt As String = ""
        Dim Value As String = ""
        Dim Default_Value As Single = Nothing

        Select Case Evnt.Symbol.Name
            Case "Text_Box.Jog_Rate.Fast"
                Get_Text_Box_Edit(50, "Text_Box.Jog_Rate.Fast", "Enter fast jog rate", "Default")

            Case "Text_Box.Jog_Rate.Slow"
                Get_Text_Box_Edit(5, "Text_Box.Jog_Rate.Slow", "Enter slow jog rate", "Default")

            Case "Text_Box.Jog_Rate.Creep"
                Get_Text_Box_Edit(1, "Text_Box.Jog_Rate.Creep", "Enter creep jog rate", "Default")

            Case "Text_Box.Jog_Rate.Big_Step"
                Get_Text_Box_Edit(0.005, "Text_Box.Jog_Rate.Big_Step", "Enter jog big step", "Default")

            Case "Text_Box.Jog_Rate.Little_Step"
                Get_Text_Box_Edit(0.001, "Text_Box.Jog_Rate.Little_Step", "Enter jog little step", "Default")
        End Select

        Update_Form()

    End Sub

#End Region

#Region "Move Handlers"

    Private Sub Move_Buttons(Evnt As Class_CNC.class_Event)
        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag
        Dim Slow_Jog_Rate As Single = Symbol.Get_Value("Text_Box.Jog_Rate.Slow")
        Dim Fast_Jog_Rate As Single = Symbol.Get_Value("Text_Box.Jog_Rate.Fast")
        Dim Z_Fast_Jog_Rate As Single = 30
        Dim Move_Z As Boolean = False

        If Not Symbol.Get_Value("Homed.XYZ") Then
            If Not Symbol.Get_Value("Homed.Z") Then
                Show_Error("All axes must be homed before moving is enabled.")
                Exit Sub
            End If
        End If

        If Symbol.Get_Value("Sys.Move_Raise_Z") Then
            If Symbol.Get_Value("Sys.Abs_Z") < Symbol.Get_Value("Text_Box.Move.Z_Up") Then Move_Z = True
        End If

        Select Case Sym.Name
            Case "Button.Move.X_Plus"
                If Move_Z Then Controller.Queue_System_GCode("G90 G54 G01 Z" & Symbol.Get_Value("Text_Box.Move.Z_Up") & " F" & Z_Fast_Jog_Rate)
                Controller.Queue_System_GCode("G90 G54 G01 X" & Symbol.Get_Value("Text_Box.Move.X_Plus") & " F" & Fast_Jog_Rate)

            Case "Button.Move.X_Minus"
                If Move_Z Then Controller.Queue_System_GCode("G90 G54 G01 Z" & Symbol.Get_Value("Text_Box.Move.Z_Up") & " F" & Z_Fast_Jog_Rate)
                Controller.Queue_System_GCode("G90 G54 G01 X" & Symbol.Get_Value("Text_Box.Move.X_Minus") & " F" & Fast_Jog_Rate)

            Case "Button.Move.Y_Plus"
                If Move_Z Then Controller.Queue_System_GCode("G90 G54 G01 Z" & Symbol.Get_Value("Text_Box.Move.Z_Up") & " F" & Z_Fast_Jog_Rate)
                Controller.Queue_System_GCode("G90 G54 G01 Y" & Symbol.Get_Value("Text_Box.Move.Y_Plus") & " F" & Fast_Jog_Rate)

            Case "Button.Move.Y_Minus"
                If Move_Z Then Controller.Queue_System_GCode("G90 G54 G01 Z" & Symbol.Get_Value("Text_Box.Move.Z_Up") & " F" & Z_Fast_Jog_Rate)
                Controller.Queue_System_GCode("G90 G54 G01 Y" & Symbol.Get_Value("Text_Box.Move.Y_Minus") & " F" & Fast_Jog_Rate)

            Case "Button.Move.Z_Plus"
                Controller.Queue_System_GCode("G90 G54 G01 Z" & Symbol.Get_Value("Text_Box.Move.Z_Up") & " F" & Z_Fast_Jog_Rate)

            Case "Button.Move.Z_Minus"
                Controller.Queue_System_GCode("G90 G54 G01 Z" & Symbol.Get_Value("Text_Box.Move.Z_Down") & " F" & Slow_Jog_Rate)
        End Select

    End Sub

    Private Sub Move_Text_Box_Click(Evnt As Class_CNC.class_Event)
        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag

        Select Case Evnt.Symbol.Name

            Case "Text_Box.Jog.Safe_Z"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z.Round_3"), "Text_Box.Jog.Safe_Z", _
                                  "Enter Z Position or click current Z button", "Current Z")

            Case "Text_Box.Move.X_Plus"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_X.Round_3"), "Text_Box.Move.X_Plus", _
                                  "Enter X Position or click current X button", "Current X")

            Case "Text_Box.Move.X_Minus"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_X.Round_3"), "Text_Box.Move.X_Minus", _
                                 "Enter X Position or click current X button", "Current X")

            Case "Text_Box.Move.Y_Plus"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y.Round_3"), "Text_Box.Move.Y_Plus", _
                                 "Enter Y Position or click current Y button", "Current Y")

            Case "Text_Box.Move.Y_Minus"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y.Round_3"), "Text_Box.Move.Y_Minus", _
                                 "Enter Y Position or click current Y button", "Current Y")

            Case "Text_Box.Move.Z_Up"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z.Round_3"), "Text_Box.Move.Z_Up", _
                                 "Enter Z Position or click current Z button", "Current Z")

            Case "Text_Box.Move.Z_Down"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z.Round_3"), "Text_Box.Move.Z_Down", _
                                 "Enter Z Position or click current Z button", "Current Z")
            Case Else
                Exit Sub
        End Select

    End Sub

#End Region

#Region "Spindle & Coolant Macros"

    Private Sub Spindle_Button(Evnt As Class_CNC.class_Event)

        If Symbol.Get_Value("Sys.Spindle") Then
            If Controller.Check_For_In_Cycle("Cannot turn spindle on while in cycle.") Then Exit Sub
        Else
            If Controller.Check_For_In_Cycle("Cannot turn spindle off while in cycle.") Then Exit Sub
        End If

        If Symbol.Get_Value("Probe.In_Spindle") Then
            Flash_Message("Cannot turn spindle on with probe in spindle.")
            Exit Sub
        End If

        If Symbol.Get_Value("Sys.Spindle") Then
            Run_Macro("Spindle_Off")
        Else
            Run_Macro("Spindle_On")
        End If
    End Sub

    Private Sub Spindle_On()
        If Not Symbol.Get_Value("Sys.In_E_Stop") Then
            Controller.Queue_System_GCode("M03")
            Symbol.Set_Value("Sys.Spindle", True)
        Else
            Flash_Message("Cannot turn spindle on in E_Stop")
        End If
    End Sub

    Private Sub Spindle_Off()
        Controller.Queue_System_GCode("M05")
        Symbol.Set_Value("Sys.Spindle", False)
    End Sub

    Private Sub Spindle_Changed(Evnt As Class_CNC.class_Event)
        Dim P As String = Evnt.Parameter

        If P.Contains("3") Or P.Contains("4") Then
            Symbol.Set_Value("Sys.Spindle", True)
        Else
            Symbol.Set_Value("Sys.Spindle", False)
        End If
    End Sub

    Private Sub Coolant_Button(Evnt As Class_CNC.class_Event)
        If Symbol.Get_Value("Sys.Coolant") Then
            Run_Macro("Coolant_Off")
        Else
            Run_Macro("Coolant_On")
        End If
    End Sub

    Private Sub Coolant_On()
        Symbol.Set_Value("Sys.Coolant", True)
        Controller.Queue_System_GCode("M08")
    End Sub

    Private Sub Coolant_Off()
        Symbol.Set_Value("Sys.Coolant", False)
        Controller.Queue_System_GCode("M09")
    End Sub

    Private Sub Coolant_Changed(Evnt As Class_CNC.class_Event)
        Dim P As String = Evnt.Parameter
        If P.Contains("8") Then
            Symbol.Set_Value("Sys.Coolant", True)
        Else
            Symbol.Set_Value("Sys.Coolant", False)
        End If
    End Sub

#End Region

#Region "Goto Position Handlers"

    Private Sub Goto_Position_Button(Evnt As Class_CNC.class_Event)
        Goto_Position(Evnt.Symbol.Name)
    End Sub

    Private Sub Goto_Position(Symbol_Name As String)
        If CNC.Inhibited Then
            Flash_Message("In Motion", 0.5)
            Exit Sub
        End If

        Dim X As Single = 0
        Dim Y As Single = 0
        Dim Z As Single = 6

        Select Case Symbol_Name

            Case "Button.Goto.Home"
                Controller.Queue_GCode("G00 G54 Z" & Symbol.Get_Value("Sys.Max_Z"))
                Controller.Queue_GCode("G00 G54 X0 Y0")

            Case "Button.Goto.Tool_Change"
                Symbol.Set_Value("Sys.Offset.Z_Zero_Set", False)
                Controller.Queue_GCode("G00 G54 Z" & Symbol.Get_Value("Sys.Max_Z"))
                Controller.Queue_GCode("G00 G54 X" & Symbol.Get_Value("Text_Box.Tool.Change.X.Round_3") & _
                                              " Y" & Symbol.Get_Value("Text_Box.Tool.Change.Y.Round_3"))
                Controller.Queue_GCode("G01 G54 Z" & Symbol.Get_Value("Text_Box.Tool.Change.Z.Round_3") & " F15")

            Case "Button.Goto.Tool_Seat"
                Symbol.Set_Value("Sys.Offset.Z_Zero_Set", False)
                If Not Is_In_Position(CSng(Symbol.Get_Value("Text_Box.Tool.Seat.X.Round_3")), _
                                      CSng(Symbol.Get_Value("Text_Box.Tool.Seat.Y.Round_3"))) Then
                    Controller.Queue_GCode("G00 G54 Z" & Symbol.Get_Value("Sys.Max_Z"))
                    Controller.Queue_GCode("G00 G54 X" & Symbol.Get_Value("Text_Box.Tool.Seat.X.Round_3") & _
                                                  " Y" & Symbol.Get_Value("Text_Box.Tool.Seat.Y.Round_3"))
                End If
                Controller.Queue_GCode("G01 G54 Z" & Symbol.Get_Value("Text_Box.Tool.Seat.Z.Round_3") & " F15")

            Case "Button.Goto.Tool_Measure"
                Symbol.Set_Value("Sys.Offset.Z_Zero_Set", False)
                If Not Is_In_Position(CSng(Symbol.Get_Value("Text_Box.Tool.Measure.X.Round_3")), _
                                      CSng(Symbol.Get_Value("Text_Box.Tool.Measure.Y.Round_3"))) Then
                    Controller.Queue_GCode("G00 G54 Z" & Symbol.Get_Value("Sys.Max_Z"))
                    Controller.Queue_GCode("G00 G54 X" & Symbol.Get_Value("Text_Box.Tool.Measure.X.Round_3") & _
                                                  " Y" & Symbol.Get_Value("Text_Box.Tool.Measure.Y.Round_3"))
                End If
                Controller.Queue_GCode("G01 G54 Z" & Symbol.Get_Value("Text_Box.Tool.Measure.Z.Round_3") & " F15")

            Case "Button.Goto.Park"
                Controller.Queue_GCode("G00 G54 Z" & Symbol.Get_Value("Sys.Max_Z"))
                Controller.Queue_GCode("G00 G54 X" & Symbol.Get_Value("Text_Box.Tool.Park.X.Round_3") & _
                                              " Y" & Symbol.Get_Value("Text_Box.Tool.Park.Y.Round_3"))
                Controller.Queue_GCode("G01 G54 Z" & Symbol.Get_Value("Text_Box.Tool.Park.Z.Round_3") & " F15")

        End Select

    End Sub

#End Region

#Region "Fixture Offset Macros"

    Private Sub Offsets_Changed(Evnt As Class_CNC.class_Event)
        Status_Changed()
        Update_Form()
    End Sub

    Private Sub Coordinate_System_Changed(Evnt As Class_CNC.class_Event)
        Update_Form()
    End Sub

    Private Sub Fixture_Offset_Buttons(Evnt As Class_CNC.class_Event)

        If Controller.Check_For_In_Cycle("Cannot change Offsets while in cycle") Then Exit Sub

        Dim Inc As Single = Symbol.Get_Value("Text_Box.Fixture_Offset.Increment.Round_3")

        Select Case Evnt.Symbol.Name

            Case "Button.Fixture_Offset.Z0_Top"
                Symbol.Set_Value("Button.Fixture_Offset.Z0_Top", True)
                Symbol.Change_Image("Button.Fixture_Offset.Z0_Top", "Green_Bar_On.png")
                Symbol.Set_Value("Button.Fixture_Offset.Z0_Bottom", False)
                Symbol.Change_Image("Button.Fixture_Offset.Z0_Bottom", "Green_Bar_Off.png")

                Symbol.Set_Value("Button.Tool_Measure.Bottom.Enabled", False)
                Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Bottom.Enabled", False)
                Symbol.Set_Value("Button.Tool_Measure.Top.Enabled", True)
                Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Top.Enabled", True)

            Case "Button.Fixture_Offset.Z0_Bottom"
                Symbol.Set_Value("Button.Fixture_Offset.Z0_Top", False)
                Symbol.Change_Image("Button.Fixture_Offset.Z0_Top", "Green_Bar_Off.png")
                Symbol.Set_Value("Button.Fixture_Offset.Z0_Bottom", True)
                Symbol.Change_Image("Button.Fixture_Offset.Z0_Bottom", "Green_Bar_On.png")

                Symbol.Set_Value("Button.Tool_Measure.Bottom.Enabled", True)
                Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Bottom.Enabled", True)
                Symbol.Set_Value("Button.Tool_Measure.Top.Enabled", False)
                Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Top.Enabled", False)

            Case "Button.Fixture_Offset.Set"
                Dim dlg As New dlg_Set_Offfset
                dlg.X_Offset = Symbol.Get_Value("Sys.Offset_X")
                dlg.X_Probe = Symbol.Get_Value("Text_Box.Probe.Surface.X")
                dlg.X_Position = Symbol.Get_Value("Sys.Abs_X")
                dlg.Y_Offset = Symbol.Get_Value("Sys.Offset_Y")
                dlg.Y_Probe = Symbol.Get_Value("Text_Box.Probe.Surface.Y")
                dlg.Y_Position = Symbol.Get_Value("Sys.Abs_Y")
                dlg.Z_Offset = Symbol.Get_Value("Sys.Offset_Z")
                dlg.Z_Probe = Symbol.Get_Value("Text_Box.Probe.Surface.Z")
                dlg.Z_Position = Symbol.Get_Value("Sys.Abs_Z")
                dlg.ShowDialog()

                If dlg.DialogResult = DialogResult.OK Then
                    Symbol.Set_Value("Text_Box.Fixture_Offset.Original.X.Round_3", dlg.X_Offset)
                    Symbol.Set_Value("Text_Box.Fixture_Offset.Total.X.Round_3", dlg.X_Offset)
                    Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.X.Round_3", 0)

                    Symbol.Set_Value("Text_Box.Fixture_Offset.Original.Y.Round_3", dlg.Y_Offset)
                    Symbol.Set_Value("Text_Box.Fixture_Offset.Total.Y.Round_3", dlg.Y_Offset)
                    Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3", 0)

                    Symbol.Set_Value("Text_Box.Fixture_Offset.Original.Z.Round_3", dlg.Z_Offset)
                    Symbol.Set_Value("Text_Box.Fixture_Offset.Total.Z.Round_3", dlg.Z_Offset)
                    Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", 0)

                    If dlg.X_Offset <> Symbol.Get_Value("Sys.Offset_X") Then
                        Controller.Set_Offset_X("G55", dlg.X_Offset)
                    End If

                    If dlg.Y_Offset <> Symbol.Get_Value("Sys.Offset_Y") Then
                        Controller.Set_Offset_Y("G55", dlg.Y_Offset)
                    End If

                    If dlg.Z_Offset <> Symbol.Get_Value("Sys.Offset_Z") Then
                        Controller.Set_Offset_Z("G55", dlg.Z_Offset)
                    End If

                End If

            Case "Button.Fixture_Offset.Load"
                Load_Offsets()

            Case "Button.Fixture_Offset.Save"
                Save_Offsets()

            Case "Button.Fixture_Offset.Goto"
                Controller.Queue_System_GCode("G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & " F50", False, False)
                Controller.Queue_System_GCode("G54 G01 X" & Symbol.Get_Value("Sys.Offset_X") & " Y" & Symbol.Get_Value("Sys.Offset_Y") & " F50")

            Case "Button.Fixture_Offset.Reset_X"
                Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.X.Round_3", "Text_Box.Fixture_Offset.Original.X.Round_3")
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.X.Round_3", 0)
                Controller.Set_Offset_X("G55", Symbol.Get_Value("Text_Box.Fixture_Offset.Original.X.Round_3"))

            Case "Button.Fixture_Offset.Reset_Y"
                Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.Y.Round_3", "Text_Box.Fixture_Offset.Original.Y.Round_3")
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3", 0)
                Controller.Set_Offset_Y("G55", Symbol.Get_Value("Text_Box.Fixture_Offset.Original.Y.Round_3"))

            Case "Button.Fixture_Offset.Reset_Z"
                Symbol.Set_Equal("Text_Box.Fixture_Offset.Total.Z.Round_3", "Text_Box.Fixture_Offset.Original.Z.Round_3")
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", 0)
                Controller.Set_Offset_Z("G55", Symbol.Get_Value("Text_Box.Fixture_Offset.Original.Z"))

            Case "Button.Fixture_Offset.Adjust.Plus_X"
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.X.Round_3", Symbol.Get_Value("Text_Box.Fixture_Offset.Delta.X.Round_3") + Inc)
                Controller.Set_Offset_X("G55", Symbol.Get_Value("Sys.Offset_X") + Inc)

            Case "Button.Fixture_Offset.Adjust.Plus_Y"
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3", Symbol.Get_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3") + Inc)
                Controller.Set_Offset_Y("G55", Symbol.Get_Value("Sys.Offset_Y") + Inc)

            Case "Button.Fixture_Offset.Adjust.Plus_Z"
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", Symbol.Get_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3") + Inc)
                Controller.Set_Offset_Z("G55", Symbol.Get_Value("Sys.Offset_Z") + Inc)

            Case "Button.Fixture_Offset.Adjust.Minus_X"
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.X.Round_3", Symbol.Get_Value("Text_Box.Fixture_Offset.Delta.X.Round_3") - Inc)
                Controller.Set_Offset_X("G55", Symbol.Get_Value("Sys.Offset_X") - Inc)

            Case "Button.Fixture_Offset.Adjust.Minus_Y"
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3", Symbol.Get_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3") - Inc)
                Controller.Set_Offset_Y("G55", Symbol.Get_Value("Sys.Offset_Y") - Inc)

            Case "Button.Fixture_Offset.Adjust.Minus_Z"
                Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", Symbol.Get_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3") - Inc)
                Controller.Set_Offset_Z("G55", Symbol.Get_Value("Sys.Offset_Z") - Inc)

        End Select

        Update_Form()

    End Sub

    Private Sub Fixture_Offset_Text_Boxes(Evnt As Class_CNC.class_Event)
        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag

        Select Case Evnt.Symbol.Name

            Case "Text_Box.Fixture_Offset.Material.Top"
                Get_Text_Box_Edit(2, "Text_Box.Fixture_Offset.Material.Top.Round_3", _
                                  "Enter Tool Setter Height", "")

            Case "Text_Box.Fixture_Offset.Material.Bottom"
                Get_Text_Box_Edit(2, "Text_Box.Fixture_Offset.Material.Bottom.Round_3", _
                                  "Enter Height from Tool Setter Bottom to Bottom of material", "")

            Case "Text_Box.Fixture_Offset.Material.Thickness"
                Get_Text_Box_Edit(0.75, "Text_Box.Fixture_Offset.Material.Thickness.Round_3", _
                                  "Enter thickness of material", "")

            Case "Text_Box.Fixture_Offset.Increment"
                Get_Text_Box_Edit(0.01, "Text_Box.Fixture_Offset.Increment.Round_3", _
                                 "Enter Offset Increment or click default button", "Default")
        End Select

    End Sub

    Sub Tool_Measure_Button(Evnt As Class_CNC.class_Event)
        Tool_Measure(Evnt.Symbol.Name)
    End Sub

    Sub Tool_Measure(Symbol_Name As String)

        If Symbol.Get_Value("Probe.In_Spindle") Then
            Show_Error("Probe in spindle.")
            Exit Sub
        End If

        CNC.Probe_Mode = Class_CNC.enum_Probe_Mode.Retract_To_Start
        CNC.Probe_Distance = 0.5
        CNC.Probe_Feedrate = Symbol.Get_Value("Text_Box.Probe.Feedrate")
        CNC.Probe_Diameter = Symbol.Get_Value("Text_Box.Probe.Diameter")
        CNC.Probe_Set_Offsets = False
        CNC.Probe_Disable_Axis = False
        CNC.Probe_Square_Check = Class_CNC.enum_Direction.None

        'If button pushed while in cycle, exit
        Select Case CNC.Probe_State
            Case Class_CNC.enum_Probe_State.Waiting_For_Touch
                CNC.Stop_Probe_Cycle()
                Cycle_Stop()
                Flash_Message("Wait For Probe Touch", 0.5)
                Exit Sub
            Case Class_CNC.enum_Probe_State.Retract_Cycle_Started, Class_CNC.enum_Probe_State.Retracting
                CNC.Stop_Probe_Cycle()
                Cycle_Stop()
                Flash_Message("Wait For Probe to Retract", 0.5)
                Exit Sub
            Case Else
                If CNC.Probe_State <> Class_CNC.enum_Probe_State.Idle Then
                    Exit Sub
                End If
        End Select

        Select Case Symbol_Name

            Case "Button.Tool_Measure.Top"
                If Not Is_In_Position(CSng(Symbol.Get_Value("Text_Box.Tool.Measure.X.Round_3")), _
                                      CSng(Symbol.Get_Value("Text_Box.Tool.Measure.Y.Round_3")), _
                                      CSng(Symbol.Get_Value("Text_Box.Tool.Measure.Z.Round_3"))) Then
                    Message_Box.ShowDialog("Not at tool measure position, measure anyway?", , MessageBoxButtons.OKCancel)
                    If Message_Box.DialogResult <> DialogResult.OK Then
                        Exit Sub
                    End If
                End If
                Probe_Cycle(Class_CNC.enum_Direction.Tool_Setter_Measure_Top)

            Case "Button.Tool_Measure.Bottom"
                If Not Is_In_Position(CSng(Symbol.Get_Value("Text_Box.Tool.Measure.X.Round_3")), _
                                      CSng(Symbol.Get_Value("Text_Box.Tool.Measure.Y.Round_3")), _
                                      CSng(Symbol.Get_Value("Text_Box.Tool.Measure.Z.Round_3"))) Then
                    Message_Box.ShowDialog("Not at tool measure position, measure anyway?", , MessageBoxButtons.OKCancel)
                    If Message_Box.DialogResult <> DialogResult.OK Then
                        Exit Sub
                    End If
                End If
                Probe_Cycle(Class_CNC.enum_Direction.Tool_Setter_Measure_Bottom)

            Case "Button.Material_Measure"
                Probe_Cycle(Class_CNC.enum_Direction.Tool_Setter_Measure_Material)
        End Select

        Symbol.Set_Value("Sys.Offset.Z_Zero_Set", True)

    End Sub

    Sub Tool_Text_Boxes(Evnt As Class_CNC.class_Event)

        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag

        Select Case Evnt.Symbol.Name

            Case "Text_Box.Tool.Change.X"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_X"), "Text_Box.Tool.Change.X.Round_3", "Enter Tool Change X Position", "Current X")
            Case "Text_Box.Tool.Change.Y"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y"), "Text_Box.Tool.Change.Y.Round_3", "Enter Tool Change Y Position", "Current Y")
            Case "Text_Box.Tool.Change.Z"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z"), "Text_Box.Tool.Change.Z.Round_3", "Enter Tool Change Z Position", "Current Z")

            Case "Text_Box.Tool.Seat.X"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_X"), "Text_Box.Tool.Seat.X.Round_3", "Enter Tool Seat X Position", "Current X")
            Case "Text_Box.Tool.Seat.Y"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y"), "Text_Box.Tool.Seat.Y.Round_3", "Enter Tool Seat Y Position", "Current Y")
            Case "Text_Box.Tool.Seat.Z"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z"), "Text_Box.Tool.Seat.Z.Round_3", "Enter Tool Seat Z Position", "Current Z")

            Case "Text_Box.Tool.Measure.X"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_X"), "Text_Box.Tool.Measure.X.Round_3", "Enter Tool Measure X Position", "Current X")
            Case "Text_Box.Tool.Measure.Y"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y"), "Text_Box.Tool.Measure.Y.Round_3", "Enter Tool Measure Y Position", "Current Y")
            Case "Text_Box.Tool.Measure.Z"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z"), "Text_Box.Tool.Measure.Z.Round_3", "Enter Tool Measure Z Position", "Current Z")

            Case "Text_Box.Tool.Park.X"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_X"), "Text_Box.Tool.Park.X.Round_3", "Enter Tool Park X Position", "Current X")
            Case "Text_Box.Tool.Park.Y"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y"), "Text_Box.Tool.Park.Y.Round_3", "Enter Tool Park Y Position", "Current Y")
            Case "Text_Box.Tool.Park.Z"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z"), "Text_Box.Tool.Park.Z.Round_3", "Enter Tool Park Z Position", "Current Z")

            Case Else

                Exit Sub
        End Select

        Update_Form()

    End Sub

    Public Sub Load_Offsets(Optional Offset_File_Name As String = "", Optional Open_File_Dialog As Boolean = True)
        If Controller.Check_For_In_Cycle("Cannot change Offsets while in cycle") Then Exit Sub
        Dim File_Name As String = Offset_File_Name

        If Open_File_Dialog Then
            Dim dlg As New OpenFileDialog
            If Offset_File_Name <> "" Then
                dlg.InitialDirectory = Path.GetDirectoryName(Offset_File_Name)
                dlg.FileName = Path.GetFileName(Offset_File_Name)
            Else
                dlg.InitialDirectory = Symbol.Get_Value("Text_Box.Fixture_Offset.Folder")
                dlg.FileName = Symbol.Get_Value("Text_Box.Fixture_Offset.File")
            End If

            dlg.Filter = "Offset Files (*.off)|*.off|All files (*.*)|*.*"
            If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            If Not File.Exists(dlg.FileName) Then Exit Sub
            File_Name = dlg.FileName
        End If

        If Not File.Exists(File_Name) Then
            Message_Box.ShowDialog("Offset File does not exist : " & File_Name)
            Exit Sub
        End If
        Symbol.Set_Value("Text_Box.Fixture_Offset.Folder", Path.GetDirectoryName(File_Name))
        Symbol.Set_Value("Text_Box.Fixture_Offset.File", Path.GetFileName(File_Name))

        Dim S() As String = Nothing
        Dim T() As String = Nothing
        Dim Buff() As String

        Buff = File.ReadAllLines(File_Name)

        For I = 0 To Buff.Count - 1
            If Buff(I) <> "" Then
                S = Buff(I).Split("~")

                Select Case S(0)
                    Case "Offset_X"
                        Symbol.Set_Value("Sys.Offset_X", S(1))
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Original.X.Round_3", S(1))
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Total.X.Round_3", S(1))
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.X.Round_3", 0)
                        Controller.Set_Offset_X("G55", Symbol.Get_Value("Sys.Offset_X.Round_3"))
                    Case "Offset_Y"
                        Symbol.Set_Value("Sys.Offset_Y", S(1))
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Original.Y.Round_3", S(1))
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Total.Y.Round_3", S(1))
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3", 0)
                        Controller.Set_Offset_Y("G55", Symbol.Get_Value("Sys.Offset_Y.Round_3"))

                    Case "Offset_Z0"
                        If S(1) = "Bottom" Then
                            Symbol.Set_Value("Button.Fixture_Offset.Z0_Top", False)
                            Symbol.Change_Image("Button.Fixture_Offset.Z0_Top", "Green_Bar_Off.png")
                            Symbol.Set_Value("Button.Fixture_Offset.Z0_Bottom", True)
                            Symbol.Change_Image("Button.Fixture_Offset.Z0_Bottom", "Green_Bar_On.png")

                            Symbol.Set_Value("Button.Tool_Measure.Bottom.Enabled", True)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Bottom.Enabled", True)
                            Symbol.Set_Value("Button.Tool_Measure.Top.Enabled", False)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Top.Enabled", False)
                        Else
                            Symbol.Set_Value("Button.Fixture_Offset.Z0_Top", True)
                            Symbol.Change_Image("Button.Fixture_Offset.Z0_Top", "Green_Bar_On.png")
                            Symbol.Set_Value("Button.Fixture_Offset.Z0_Bottom", False)
                            Symbol.Change_Image("Button.Fixture_Offset.Z0_Bottom", "Green_Bar_Off.png")

                            Symbol.Set_Value("Button.Tool_Measure.Bottom.Enabled", False)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Bottom.Enabled", False)
                            Symbol.Set_Value("Button.Tool_Measure.Top.Enabled", True)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Top.Enabled", True)
                        End If

                    Case "Material_Top"
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Top.Round_3", S(1))
                    Case "Material_Bottom"
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Bottom.Round_3", S(1))
                    Case "Material_Thickness"
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Material.Thickness.Round_3", S(1))

                    Case "Tool_Change.X"
                        Symbol.Set_Value("Text_Box.Tool.Change.X", S(1))
                    Case "Tool_Change.Y"
                        Symbol.Set_Value("Text_Box.Tool.Change.Y", S(1))
                    Case "Tool_Change.Z"
                        Symbol.Set_Value("Text_Box.Tool.Change.Z", S(1))

                    Case "Tool_Seat.X"
                        Symbol.Set_Value("Text_Box.Tool.Seat.X", S(1))
                    Case "Tool_Seat.Y"
                        Symbol.Set_Value("Text_Box.Tool.Seat.Y", S(1))
                    Case "Tool_Seat.Z"
                        Symbol.Set_Value("Text_Box.Tool.Seat.Z", S(1))

                    Case "Tool_Measure.X"
                        Symbol.Set_Value("Text_Box.Tool.Measure.X", S(1))
                    Case "Tool_Measure.Y"
                        Symbol.Set_Value("Text_Box.Tool.Measure.Y", S(1))
                    Case "Tool_Measure.Z"
                        Symbol.Set_Value("Text_Box.Tool.Measure.Z", S(1))

                    Case "Tool_Change.X"
                        Symbol.Set_Value("Text_Box.Tool.Change.X", S(1))
                    Case "Tool_Change.Y"
                        Symbol.Set_Value("Text_Box.Tool.Change.Y", S(1))
                    Case "Tool_Change.Z"
                        Symbol.Set_Value("Text_Box.Tool.Change.Z", S(1))

                End Select
            End If
        Next

        Update_Form()

    End Sub

    Public Sub Save_Offsets()
        Dim dlg As New SaveFileDialog
        Dim Buff As New List(Of String)

        dlg.InitialDirectory = Symbol.Get_Value("Text_Box.Fixture_Offset.Folder")
        dlg.FileName = Symbol.Get_Value("Text_Box.Fixture_Offset.File")
        dlg.Filter = "Offset Files (*.off)|*.off|All files (*.*)|*.*"

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Symbol.Set_Value("Text_Box.Fixture_Offset.Folder", Path.GetDirectoryName(dlg.FileName))
            Symbol.Set_Value("Text_Box.Fixture_Offset.File", Path.GetFileName(dlg.FileName))

            If File.Exists(dlg.FileName) Then
                Dim DF As New Class_Data_File
                DF.Backup_File(dlg.FileName, True)
            End If

            Buff.Clear()
            Buff.Add("Offset_X~" & Symbol.Get_Value("Sys.Offset_X"))
            Buff.Add("Offset_Y~" & Symbol.Get_Value("Sys.Offset_Y"))
            If Symbol.Get_Value("Button.Fixture_Offset.Z0_Top") = True Then
                Buff.Add("Offset_Z0~Top")
            Else
                Buff.Add("Offset_Z0~Bottom")
            End If
            Buff.Add("Material_Top~" & Symbol.Get_Value("Text_Box.Fixture_Offset.Material.Top.Round_3"))
            Buff.Add("Material_Bottom~" & Symbol.Get_Value("Text_Box.Fixture_Offset.Material.Bottom.Round_3"))
            Buff.Add("Material_Thickness~" & Symbol.Get_Value("Text_Box.Fixture_Offset.Material.Thickness.Round_3"))
            Buff.Add("Tool_Change.X~" & Symbol.Get_Value("Text_Box.Tool.Change.X"))
            Buff.Add("Tool_Change.Y~" & Symbol.Get_Value("Text_Box.Tool.Change.Y"))
            Buff.Add("Tool_Change.Z~" & Symbol.Get_Value("Text_Box.Tool.Change.Z"))
            Buff.Add("Tool_Seat.X~" & Symbol.Get_Value("Text_Box.Tool.Seat.X"))
            Buff.Add("Tool_Seat.Y~" & Symbol.Get_Value("Text_Box.Tool.Seat.Y"))
            Buff.Add("Tool_Seat.Z~" & Symbol.Get_Value("Text_Box.Tool.Seat.Z"))
            Buff.Add("Tool_Measure.X~" & Symbol.Get_Value("Text_Box.Tool.Measure.X"))
            Buff.Add("Tool_Measure.Y~" & Symbol.Get_Value("Text_Box.Tool.Measure.Y"))
            Buff.Add("Tool_Measure.Z~" & Symbol.Get_Value("Text_Box.Tool.Measure.Z"))
            Buff.Add("Tool_Park.X~" & Symbol.Get_Value("Text_Box.Tool.Park.X"))
            Buff.Add("Tool_Park.Y~" & Symbol.Get_Value("Text_Box.Tool.Park.Y"))
            Buff.Add("Tool_Park.Z~" & Symbol.Get_Value("Text_Box.Tool.Park.Z"))
            File.WriteAllLines(dlg.FileName, Buff)
        End If

    End Sub


    Private Sub Change_Coordinate_System(Coor_System As String)
        Controller.Queue_GCode(Coor_System)
    End Sub

#End Region

#Region "Square Axes"

    Private Sub Square_Buttons(Evnt As Class_CNC.class_Event)

        If Controller.Check_For_In_Cycle("Cannot square axes while in cycle") Then Exit Sub

        If Not Symbol.Get_Value("Probe.In_Spindle") Then
            Show_Error("Probe not loaded in spindle.")
            Exit Sub
        End If

        CNC.Probe_Mode = Class_CNC.enum_Probe_Mode.Retract_To_Start
        CNC.Probe_Set_Offsets = False
        CNC.Probe_Disable_Axis = False
        CNC.Probe_Square_Check = Class_CNC.enum_Direction.None
        CNC.Probe_Distance = Symbol.Get_Value("Text_Box.Probe.Distance")
        CNC.Probe_Diameter = Symbol.Get_Value("Text_Box.Probe.Diameter")
        CNC.Probe_Feedrate = Symbol.Get_Value("Text_Box.Probe.Feedrate")

        Select Case Evnt.Symbol.Name

            Case "Button.Square.Goto.X_Minus"
                If Symbol.Get_Value("Sys.Abs_Y.Round_3") <> Symbol.Get_Value("Text_Box.Square.Y_Minus.Round_3") Then
                    Controller.Queue_System_GCode("G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & " F50", False, False)
                End If
                Controller.Queue_System_GCode("G54 G01 X" & Symbol.Get_Value("Text_Box.Square.X_Minus") & " F50")

            Case "Button.Square.Goto.X_Plus"
                If Symbol.Get_Value("Sys.Abs_Y.Round_3") <> Symbol.Get_Value("Text_Box.Square.Y_Minus.Round_3") Then
                    Controller.Queue_System_GCode("G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & " F50", False, False)
                End If
                Controller.Queue_System_GCode("G54 G01 X" & Symbol.Get_Value("Text_Box.Square.X_Plus") & " F50")

            Case "Button.Square.Goto.Y_Minus"
                If Symbol.Get_Value("Sys.Abs_X.Round_3") <> Symbol.Get_Value("Text_Box.Square.X_Minus.Round_3") Then
                    Controller.Queue_System_GCode("G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & " F50", False, False)
                End If
                Controller.Queue_System_GCode("G54 G01 Y" & Symbol.Get_Value("Text_Box.Square.Y_Minus") & " F50")

            Case "Button.Square.Goto.Y_Plus"
                If Symbol.Get_Value("Sys.Abs_X.Round_3") <> Symbol.Get_Value("Text_Box.Square.X_Minus.Round_3") Then
                    Controller.Queue_System_GCode("G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & " F50", False, False)
                End If
                Controller.Queue_System_GCode("G54 G01 Y" & Symbol.Get_Value("Text_Box.Square.Y_Plus") & " F50")

            Case "Button.Square.Goto.Z"
                If (Symbol.Get_Value("Sys.Abs_X.Round_3") <> Symbol.Get_Value("Text_Box.Square.X_Minus.Round_3")) Then
                    Show_Error("Not at X Minus Position")
                    Exit Sub
                End If

                If (Symbol.Get_Value("Sys.Abs_Y.Round_3") <> Symbol.Get_Value("Text_Box.Square.Y_Minus.Round_3")) Then
                    Show_Error("Not at Y Minus Position")
                    Exit Sub
                End If
                Controller.Queue_System_GCode("G54 G01 Z" & Symbol.Get_Value("Text_Box.Square.Z") & " F10", False, False)


            Case "Button.Square.Probe.X_Minus"
                If Is_In_Position("Text_Box.Square.X_Minus.Round_3", "Text_Box.Square.Y_Minus.Round_3", "Text_Box.Square.Z.Round_3") Then
                    CNC.Probe_Square_Check = Class_CNC.enum_Direction.S
                    Probe_Cycle(Class_CNC.enum_Direction.W)
                Else
                    Show_Error("Not at X Minus, Y Minus, Z Minus Position")
                    Exit Sub
                End If

            Case "Button.Square.Probe.X_Plus"
                If Is_In_Position("Text_Box.Square.X_Minus.Round_3", "Text_Box.Square.Y_Plus.Round_3", "Text_Box.Square.Z.Round_3") Then
                    CNC.Probe_Square_Check = Class_CNC.enum_Direction.N
                    CNC.Probe_Disable_Axis = True
                    Probe_Cycle(Class_CNC.enum_Direction.W)
                Else
                    Show_Error("Not at X Minus, Y Plus, Z Minus Position")
                    Exit Sub
                End If

            Case "Button.Square.Probe.Y_Minus"
                If Is_In_Position("Text_Box.Square.X_Minus.Round_3", "Text_Box.Square.Y_Minus.Round_3", "Text_Box.Square.Z.Round_3") Then
                    CNC.Probe_Square_Check = Class_CNC.enum_Direction.W
                    Probe_Cycle(Class_CNC.enum_Direction.S)
                Else
                    Show_Error("Not at X Minus, Y Minus, Z Minus Position")
                    Exit Sub
                End If

            Case "Button.Square.Probe.Y_Plus"
                If Is_In_Position("Text_Box.Square.X_Plus.Round_3", "Text_Box.Square.Y_Minus.Round_3", "Text_Box.Square.Z.Round_3") Then
                    CNC.Probe_Square_Check = Class_CNC.enum_Direction.E
                    CNC.Probe_Disable_Axis = True
                    Probe_Cycle(Class_CNC.enum_Direction.N)
                Else
                    Show_Error("Not at X Plus, Y Minus, Z Minus Position")
                    Exit Sub
                End If


        End Select

    End Sub


    Private Sub Square_Text_Boxes(Evnt As Class_CNC.class_Event)
        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag

        Select Case Evnt.Symbol.Name

            Case "Text_Box.Square.X_Plus"
                Get_Text_Box_Edit(Symbol.Get_Value("SXs.Abs_X.Round_3"), "Text_Box.Square.X_Plus", _
                                  "Enter X Offset or click current X button", "Current X")

            Case "Text_Box.Square.X_Minus"
                Get_Text_Box_Edit(Symbol.Get_Value("SXs.Abs_X.Round_3"), "Text_Box.Square.X_Minus", _
                                  "Enter X Offset or click current X button", "Current X")

            Case "Text_Box.Square.Y_Plus"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y.Round_3"), "Text_Box.Square.Y_Plus", _
                                  "Enter Y Offset or click current Y button", "Current Y")

            Case "Text_Box.Square.Y_Minus"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Y.Round_3"), "Text_Box.Square.Y_Minus", _
                                  "Enter Y Offset or click current Y button", "Current Y")

            Case "Text_Box.Square.Z"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z.Round_3"), "Text_Box.Square.Z.Round_3", _
                                  "Enter Z Offset or click current Z button", "Current Z")

        End Select

    End Sub


#End Region

#Region "Probe Macros"

    Private Sub Load_Probe(Evnt As Class_CNC.class_Event)
        If Evnt.Type = Class_CNC.enum_Event_Types.Button_Down Then
            Run_Macro("Spindle_Off")

            If Symbol.Get_Value("Probe.In_Spindle") Then
                Show_Error("Unload probe, switch router on.")
                Symbol.Set_Value("Probe.In_Spindle", False)
            Else
                Show_Error("Load probe, switch router off.")
                Symbol.Set_Value("Probe.In_Spindle", True)
            End If
        End If

    End Sub

    Private Function Probe_OK_To_Start() As Boolean

        If Not Symbol.Get_Value("Homed.XYZ") Then
            If Not Symbol.Get_Value("Homed.Z") Then
                Show_Error("All axes must be homed before probing is enabled.")
                Return False
            End If
        End If

        Select Case CNC.Probe_State
            Case Class_CNC.enum_Probe_State.Idle
                If Symbol.Get_Value("Probe.In_Spindle") = False Then
                    Flash_Message("Probe not loaded in spindle", 1)
                    Return False
                End If
                If Not IsNumeric(Symbol.Get_Value("Text_Box.Probe.Distance")) Then
                    Flash_Message("Distance must be a number")
                    Return False
                End If
                If Not IsNumeric(Symbol.Get_Value("Text_Box.Probe.Feedrate")) Then
                    Flash_Message("Rate must be a feedrate number")
                    Return False
                End If
                If Not IsNumeric(Symbol.Get_Value("Text_Box.Probe.Diameter")) Then
                    Flash_Message("Probe Diameter must be a number")
                    Return False
                End If
            Case Class_CNC.enum_Probe_State.Waiting_For_Touch
                CNC.Stop_Probe_Cycle()
                Cycle_Stop()
                Flash_Message("Wait For Probe Touch", 0.5)
                Return False
            Case Class_CNC.enum_Probe_State.Retract_Cycle_Started, Class_CNC.enum_Probe_State.Retracting
                CNC.Stop_Probe_Cycle()
                Cycle_Stop()
                Flash_Message("Wait For Probe to Retract", 0.5)
                Return False
            Case Else
                If CNC.Probe_State <> Class_CNC.enum_Probe_State.Idle Then
                    Return False
                End If
        End Select

        Return True

    End Function

    Private Sub Probe_Button(Evnt As Class_CNC.class_Event)

        If Not Probe_OK_To_Start() Then Exit Sub

        If Main_Form.chk_Move_Set_Gap.Checked Then
            CNC.Probe_Mode = Class_CNC.enum_Probe_Mode.Retract_A_Distance
            Main_Form.chk_Move_Set_Gap.Checked = False
        Else
            CNC.Probe_Mode = Class_CNC.enum_Probe_Mode.Retract_To_Start
        End If

        CNC.Probe_Set_Offsets = False
        CNC.Probe_Disable_Axis = False
        CNC.Probe_Square_Check = Class_CNC.enum_Direction.None

        CNC.Probe_Distance = Symbol.Get_Value("Text_Box.Probe.Distance")
        CNC.Probe_Feedrate = Symbol.Get_Value("Text_Box.Probe.Feedrate")
        CNC.Probe_Diameter = Symbol.Get_Value("Text_Box.Probe.Diameter")

        'If button pushed while in cycle, exit
        Select Case CNC.Probe_State
            Case Class_CNC.enum_Probe_State.Waiting_For_Touch
                CNC.Stop_Probe_Cycle()
                Cycle_Stop()
                Flash_Message("Wait For Probe Touch", 0.5)
                Exit Sub
            Case Class_CNC.enum_Probe_State.Retract_Cycle_Started, Class_CNC.enum_Probe_State.Retracting
                CNC.Stop_Probe_Cycle()
                Cycle_Stop()
                Flash_Message("Wait For Probe to Retract", 0.5)
                Exit Sub
            Case Else
                If CNC.Probe_State <> Class_CNC.enum_Probe_State.Idle Then
                    Exit Sub
                End If
        End Select

        Select Case Evnt.Symbol.Name
            Case "Button.Probe.X_Plus"
                Probe_Cycle(Class_CNC.enum_Direction.E)
            Case "Button.Probe.X_Minus"
                Probe_Cycle(Class_CNC.enum_Direction.W)
            Case "Button.Probe.Y_Plus"
                Probe_Cycle(Class_CNC.enum_Direction.N)
            Case "Button.Probe.Y_Minus"
                Probe_Cycle(Class_CNC.enum_Direction.S)
            Case "Button.Probe.Z_Minus"
                Probe_Cycle(Class_CNC.enum_Direction.Down)
            Case "Button.Probe.Corner_NE"
                Probe_Cycle(Class_CNC.enum_Direction.NE)
            Case "Button.Probe.Corner_NW"
                Probe_Cycle(Class_CNC.enum_Direction.NW)
            Case "Button.Probe.Corner_SE"
                Probe_Cycle(Class_CNC.enum_Direction.SE)
            Case "Button.Probe.Corner_SW"
                Probe_Cycle(Class_CNC.enum_Direction.SW)
            Case "Button.Probe.Center"
                Probe_Cycle(Class_CNC.enum_Direction.Center)
        End Select

    End Sub

    Private Sub Probe_Text_Box_Click(Evnt As Class_CNC.class_Event)
        Dim Sym As Class_Symbols.class_Symbol = Evnt.Ctrl.Tag

        Select Case Evnt.Symbol.Name

            Case "Text_Box.Probe.Distance"
                Get_Text_Box_Edit(0.25, "Text_Box.Probe.Distance.Round_3", "Enter distance to probe", "Default")

            Case "Text_Box.Probe.Feedrate"
                Get_Text_Box_Edit(Symbol.Get_Value("Text_Box.Jog_Rate.Slow.Round_1"), "Text_Box.Probe.Feedrate.Round_1", _
                                                   "Enter feedrate to probe", "Default")

            Case "Text_Box.Probe.Diameter"
                Get_Text_Box_Edit(0.1, "Text_Box.Probe.Diameter.Round_3", "Enter diameter of probe tip", "Default")

            Case "Text_Box.Probe.Safe_Z"
                Get_Text_Box_Edit(Symbol.Get_Value("Sys.Abs_Z.Round_3"), "Text_Box.Probe.Safe_Z.Round_3", _
                                  "Enter Z Position or click current Z button", "Current Z")

            Case "Text_Box.Probe.Set_Gap"
                Get_Text_Box_Edit(0.1, Symbol.Get_Value("Text_Box_Probe_Set_Gap.Round_3"), _
                                  "Enter Gap or click Default button", "Gap")
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub Probe_Information_Update(Direction As Class_CNC.enum_Direction, Optional Cmd As String = "")

        Select Case Cmd
            Case ""
                'Symbol.Set_Value("Text_Box.Probe.State", "Idle")

            Case "I"
                Select Case Direction
                    Case Class_CNC.enum_Direction.E
                        Symbol.Set_Value("Text_Box.Probe.Start.X", "")
                        Symbol.Set_Value("Text_Box.Probe.End.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.X", "")

                    Case Class_CNC.enum_Direction.W
                        Symbol.Set_Value("Text_Box.Probe.Start.X", "")
                        Symbol.Set_Value("Text_Box.Probe.End.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.X", "")

                    Case Class_CNC.enum_Direction.N
                        Symbol.Set_Value("Text_Box.Probe.Start.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.End.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.Y", "")

                    Case Class_CNC.enum_Direction.S
                        Symbol.Set_Value("Text_Box.Probe.Start.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.End.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.Y", "")

                    Case Class_CNC.enum_Direction.Down
                        Symbol.Set_Value("Text_Box.Probe.Start.Z", "")
                        Symbol.Set_Value("Text_Box.Probe.End.Z", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.Z", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.Z", "")

                    Case Class_CNC.enum_Direction.NE, Class_CNC.enum_Direction.NW
                        Symbol.Set_Value("Text_Box.Probe.Start.X", "")
                        Symbol.Set_Value("Text_Box.Probe.End.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Start.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.End.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.Y", "")

                    Case Class_CNC.enum_Direction.SE, Class_CNC.enum_Direction.SW
                        Symbol.Set_Value("Text_Box.Probe.Start.X", "")
                        Symbol.Set_Value("Text_Box.Probe.End.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Start.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.End.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.Y", "")

                    Case Class_CNC.enum_Direction.Center
                        Symbol.Set_Value("Text_Box.Probe.Start.X", "")
                        Symbol.Set_Value("Text_Box.Probe.End.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Start.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.End.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Gap.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Surface.Y", "")
                        Symbol.Set_Value("Text_Box.Probe.Center.Gap.X_Plus", "Probing")
                        Symbol.Set_Value("Text_Box.Probe.Center.Gap.X_Minus", "")
                        Symbol.Set_Value("Text_Box.Probe.Center.Gap.Y_Plus", "")
                        Symbol.Set_Value("Text_Box.Probe.Center.Gap.Y_Minus", "")
                        Symbol.Set_Value("Text_Box.Probe.Center.XY", "")
                        Symbol.Set_Value("Text_Box.Probe.Center.Delta.X", "")
                        Symbol.Set_Value("Text_Box.Probe.Center.Delta.Y", "")

                End Select

            Case "R"
                Symbol.Set_Value("Text_Box.Probe.Center.Gap.X_Minus", "Probing")
                Symbol.Set_Value("Text_Box.Probe.Center.Gap.X_Plus", Format_Number(Right_Gap))
            Case "L"
                Symbol.Set_Value("Text_Box.Probe.Center.Gap.Y_Plus", "Probing")
                Symbol.Set_Value("Text_Box.Probe.Center.Gap.X_Minus", Format_Number(Left_Gap))
            Case "T"
                Symbol.Set_Value("Text_Box.Probe.Center.Gap.Y_Minus", "Probing")
                Symbol.Set_Value("Text_Box.Probe.Center.Gap.Y_Plus", Format_Number(Top_Gap))
            Case "B"
                Symbol.Set_Value("Text_Box.Probe.Center.Gap.Y_Minus", Format_Number(Bottom_Gap))
                Dim Center_X As Single
                Dim Center_Y As Single
                Center_X = Left_X + (Right_X - Left_X) / 2
                Center_Y = Bottom_Y + (Top_Y - Bottom_Y) / 2
                Symbol.Set_Value("Text_Box.Probe.Center.XY", Format_Number(Center_X) & ", " & Format_Number(Center_Y))
                Symbol.Set_Value("Text_Box.Probe.Center.Delta.X", Format_Number(Math.Abs(Right_Gap - Left_Gap)))
                Symbol.Set_Value("Text_Box.Probe.Center.Delta.Y", Format_Number(Math.Abs(Top_Gap - Bottom_Gap)))

        End Select

        'If Cmd <> "" Then Exit Sub


        Select Case CNC.Probe_State

            Case Class_CNC.enum_Probe_State.Idle
                Symbol.Set_Value("Text_Box.Probe.State", "Idle")

            Case Class_CNC.enum_Probe_State.Probe_Cycle_Started

                Select Case CNC.Probe_Direction
                    Case Class_CNC.enum_Direction.E
                        Symbol.Set_Value("Text_Box.Probe.Start.X", CNC.Probe_Start_X)
                        Symbol.Set_Value("Text_Box.Probe.State", "Probing X Plus")
                    Case Class_CNC.enum_Direction.W
                        Symbol.Set_Value("Text_Box.Probe.Start.X", CNC.Probe_Start_X)
                        Symbol.Set_Value("Text_Box.Probe.State", "Probing X Minus")
                    Case Class_CNC.enum_Direction.N
                        Symbol.Set_Value("Text_Box.Probe.Start.Y", CNC.Probe_Start_Y)
                        Symbol.Set_Value("Text_Box.Probe.State", "Probing Y Plus")
                    Case Class_CNC.enum_Direction.S
                        Symbol.Set_Value("Text_Box.Probe.Start.Y", CNC.Probe_Start_Y)
                        Symbol.Set_Value("Text_Box.Probe.State", "Probing Y Minus")
                    Case Class_CNC.enum_Direction.Down
                        Symbol.Set_Value("Text_Box.Probe.Start.Z", CNC.Probe_Start_Z)
                        Symbol.Set_Value("Text_Box.Probe.State", "Probing Z Minus")
                End Select

            Case Class_CNC.enum_Probe_State.Waiting_For_Touch

            Case Class_CNC.enum_Probe_State.Touched

                Select Case CNC.Probe_Direction
                    Case Class_CNC.enum_Direction.E
                        CNC.Probe_End_X += Symbol.Get_Value("Probe.Comp.X_Plus")
                        Symbol.Set_Value("Text_Box.Probe.End.X", Format_Number(CNC.Probe_End_X))
                        Symbol.Set_Value("Text_Box.Probe.Gap.X", Format_Number(Math.Abs(CNC.Probe_Start_X - CNC.Probe_End_X)))
                        Symbol.Set_Value("Text_Box.Probe.Surface.X", Format_Number(CNC.Probe_End_X + (CNC.Probe_Diameter / 2)))
                    Case Class_CNC.enum_Direction.W
                        CNC.Probe_End_X += Symbol.Get_Value("Probe.Comp.X_Minus")
                        Symbol.Set_Value("Text_Box.Probe.End.X", Format_Number(CNC.Probe_End_X))
                        Symbol.Set_Value("Text_Box.Probe.Gap.X", Format_Number(Math.Abs(CNC.Probe_Start_X - CNC.Probe_End_X)))
                        Symbol.Set_Value("Text_Box.Probe.Surface.X", Format_Number(CNC.Probe_End_X - (CNC.Probe_Diameter / 2)))
                    Case Class_CNC.enum_Direction.N
                        CNC.Probe_End_Y += Symbol.Get_Value("Probe.Comp.Y_Plus")
                        Symbol.Set_Value("Text_Box.Probe.End.Y", Format_Number(CNC.Probe_End_Y))
                        Symbol.Set_Value("Text_Box.Probe.Gap.Y", Format_Number(Math.Abs(CNC.Probe_Start_Y - CNC.Probe_End_Y)))
                        Symbol.Set_Value("Text_Box.Probe.Surface.Y", Format_Number(CNC.Probe_End_Y + (CNC.Probe_Diameter / 2)))
                    Case Class_CNC.enum_Direction.S
                        CNC.Probe_End_Y += Symbol.Get_Value("Probe.Comp.Y_Minus")
                        Symbol.Set_Value("Text_Box.Probe.End.Y", Format_Number(CNC.Probe_End_Y))
                        Symbol.Set_Value("Text_Box.Probe.Gap.Y", Format_Number(Math.Abs(CNC.Probe_Start_Y - CNC.Probe_End_Y)))
                        Symbol.Set_Value("Text_Box.Probe.Surface.Y", Format_Number(CNC.Probe_End_Y - (CNC.Probe_Diameter / 2)))
                    Case Class_CNC.enum_Direction.Down
                        Symbol.Set_Value("Text_Box.Probe.End.Z", Format_Number(CNC.Probe_End_Z))
                        Symbol.Set_Value("Text_Box.Probe.Gap.Z", Format_Number(Math.Abs(CNC.Probe_Start_Z - CNC.Probe_End_Z)))
                        Symbol.Set_Value("Text_Box.Probe.Surface.Z", Format_Number(CNC.Probe_End_Z - (CNC.Probe_Diameter / 2)))

                    Case Class_CNC.enum_Direction.Tool_Setter_Measure_Top
                        Dim Z As Single
                        Z = CNC.Probe_End_Z - Symbol.Get_Value("Text_Box.Fixture_Offset.Material.Top.Round_3")
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Original.Z.Round_3", Z)
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", 0)
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Total.Z.Round_3", Z)
                        Controller.Set_Offset_Z("G55", Z)

                    Case Class_CNC.enum_Direction.Tool_Setter_Measure_Bottom
                        Dim Z As Single
                        Z = CNC.Probe_End_Z - Symbol.Get_Value("Text_Box.Fixture_Offset.Material.Bottom.Round_3")
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Original.Z.Round_3", Z)
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", 0)
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Total.Z.Round_3", Z)
                        Controller.Set_Offset_Z("G55", Z)

                    Case Class_CNC.enum_Direction.Tool_Setter_Measure_Material
                        Dim Z As Single
                        Z = CNC.Probe_End_Z - Symbol.Get_Value("Text_Box.Fixture_Offset.Material.Top.Round_3")
                        Symbol.Set_Value("Text_Box.Offset.Material.Thickness.Round_3", Z)
                End Select

            Case Class_CNC.enum_Probe_State.Retract_Cycle_Started

                Select Case CNC.Probe_Mode
                    Case Class_CNC.enum_Probe_Mode.None

                    Case Class_CNC.enum_Probe_Mode.Retract_To_Start

                        Select Case CNC.Probe_Direction
                            Case Class_CNC.enum_Direction.E, Class_CNC.enum_Direction.W
                                Symbol.Set_Value("Text_Box.Probe.State", "Retracting X to start")
                            Case Class_CNC.enum_Direction.N, Class_CNC.enum_Direction.S
                                Symbol.Set_Value("Text_Box.Probe.State", "Retracting Y to start")
                            Case Class_CNC.enum_Direction.Down
                                Symbol.Set_Value("Text_Box.Probe.State", "Retracting Z to start")
                        End Select

                End Select

            Case Class_CNC.enum_Probe_State.Done

                Select Case CNC.Probe_Direction
                    Case Class_CNC.enum_Direction.E, Class_CNC.enum_Direction.W
                        Symbol.Set_Value("Text_Box.Probe.State", "X Probe Done")
                        If CNC.Probe_Set_Offsets Then
                            Dim X As Single = Symbol.Get_Value("Text_Box.Probe.Surface.X")
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Original.X", X)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.X.Round_3", 0)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Total.X", X)
                            Controller.Set_Offset_X("G55", X)
                        End If
                        If CNC.Probe_Disable_Axis Then
                            Controller.Enable_Axis(Class_CNC.enum_Axis.X, False)
                        End If

                    Case Class_CNC.enum_Direction.N, Class_CNC.enum_Direction.S
                        Symbol.Set_Value("Text_Box.Probe.State", "Y Probe Done")
                        If CNC.Probe_Set_Offsets Then
                            Dim Y As Single = Symbol.Get_Value("Text_Box.Probe.Surface.Y")
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Original.Y", Y)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Y.Round_3", 0)
                            Symbol.Set_Value("Text_Box.Fixture_Offset.Total.Y", Y)
                            Controller.Set_Offset_Y("G55", Y)
                        End If

                        If CNC.Probe_Disable_Axis Then
                            Controller.Enable_Axis(Class_CNC.enum_Axis.Y, False)
                        End If

                    Case Class_CNC.enum_Direction.Down
                        Symbol.Set_Value("Text_Box.Probe.State", "Z Probe Done")
                        Dim Z As Single = Symbol.Get_Value("Text_Box.Probe.Surface.Z")
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Original.Z", Z)
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Delta.Z.Round_3", 0)
                        Symbol.Set_Value("Text_Box.Fixture_Offset.Total.Z", Z)
                        Controller.Set_Offset_Z("G55", Z)
                        If CNC.Probe_Disable_Axis Then
                            Controller.Enable_Axis(Class_CNC.enum_Axis.Z, False)
                        End If

                    Case Class_CNC.enum_Direction.Tool_Setter_Measure_Bottom, Class_CNC.enum_Direction.Tool_Setter_Measure_Top
                        Controller.Queue_System_GCode("G00 Z" & Symbol.Get_Value("Sys.Max_Z"))

                End Select

                Select Case CNC.Probe_Square_Check
                    Case Class_CNC.enum_Direction.S
                        Symbol.Set_Equal("Text_Box.Square.Gap.X_Minus.Round_3", "Text_Box.Probe.Gap.X.Round_3")

                    Case Class_CNC.enum_Direction.N
                        Symbol.Set_Equal("Text_Box.Square.Gap.X_Plus.Round_3", "Text_Box.Probe.Gap.X.Round_3")
                        Symbol.Set_Value("Text_Box.Square.Error_X", _
                                         Symbol.Get_Value("Text_Box.Square.Gap.X_Plus.Round_3") - _
                                         Symbol.Get_Value("Text_Box.Square.Gap.X_Minus.Round_3"))

                        If CNC.Probe_Disable_Axis Then
                            Controller.Enable_Axis(Class_CNC.enum_Axis.X, False)
                        End If

                    Case Class_CNC.enum_Direction.W
                        Symbol.Set_Equal("Text_Box.Square.Gap.Y_Minus.Round_3", "Text_Box.Probe.Gap.Y.Round_3")

                    Case Class_CNC.enum_Direction.E
                        Symbol.Set_Equal("Text_Box.Square.Gap.Y_Plus.Round_3", "Text_Box.Probe.Gap.Y.Round_3")
                        Symbol.Set_Value("Text_Box.Square.Error_Y", _
                                         Symbol.Get_Value("Text_Box.Square.Gap.Y_Plus.Round_3") - _
                                         Symbol.Get_Value("Text_Box.Square.Gap.Y_Minus.Round_3"))

                        If CNC.Probe_Disable_Axis Then
                            Controller.Enable_Axis(Class_CNC.enum_Axis.Y, False)
                        End If

                End Select

            Case Class_CNC.enum_Probe_State.Probe_Error

                Select Case CNC.Probe_Direction
                    Case Class_CNC.enum_Direction.E, Class_CNC.enum_Direction.W
                        Symbol.Set_Value("Text_Box.Probe.State", "X Probe Error")
                    Case Class_CNC.enum_Direction.N, Class_CNC.enum_Direction.S
                        Symbol.Set_Value("Text_Box.Probe.State", "Y Probe Error")
                    Case Class_CNC.enum_Direction.Down
                        Symbol.Set_Value("Text_Box.Probe.State", "Z Probe Error")
                End Select

        End Select

    End Sub

    Private Sub Probe_Cycle(Optional Direction As Class_CNC.enum_Direction = Class_CNC.enum_Direction.None)
        Static Dir As Class_CNC.enum_Direction
        Static Cycle_Step As Integer
        Dim Update_Command As String = ""

        'Callback has a direction of none, otherwise a cycle is being started
        If Direction <> Class_CNC.enum_Direction.None Then
            Dir = Direction
            Cycle_Step = 0
        End If

        Select Case Cycle_Step

            Case 0
                Cycle_Step = 1
                Update_Command = "I"

                Select Case Dir
                    Case Class_CNC.enum_Direction.E
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.E)
                    Case Class_CNC.enum_Direction.W
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.W)
                    Case Class_CNC.enum_Direction.N
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.N)
                    Case Class_CNC.enum_Direction.S
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.S)
                    Case Class_CNC.enum_Direction.Down
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.Down)
                    Case Class_CNC.enum_Direction.Tool_Setter_Measure_Top
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.Tool_Setter_Measure_Top)
                    Case Class_CNC.enum_Direction.Tool_Setter_Measure_Bottom
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.Tool_Setter_Measure_Bottom)
                    Case Class_CNC.enum_Direction.Tool_Setter_Measure_Material
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.Tool_Setter_Measure_Material)
                    Case Class_CNC.enum_Direction.NE
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.E)
                    Case Class_CNC.enum_Direction.NW
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.W)
                    Case Class_CNC.enum_Direction.SE
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.E)
                    Case Class_CNC.enum_Direction.SW
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.W)
                    Case Class_CNC.enum_Direction.Center
                        CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.E)
                End Select

            Case 1, 2
                Select Case CNC.Probe_State

                    Case Class_CNC.enum_Probe_State.Idle
                        Cycle_Step = 3
                        Select Case Dir
                            Case Class_CNC.enum_Direction.NE
                                CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.N)
                            Case Class_CNC.enum_Direction.NW
                                CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.N)
                            Case Class_CNC.enum_Direction.SE
                                CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.S)
                            Case Class_CNC.enum_Direction.SW
                                CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.S)
                            Case Class_CNC.enum_Direction.Center
                                Right_X = CNC.Probe_End_X
                                Right_Gap = Math.Abs(CNC.Probe_Start_X - CNC.Probe_End_X)
                                Update_Command = "R"
                                CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.W)
                        End Select
                    Case Class_CNC.enum_Probe_State.Done

                    Case Class_CNC.enum_Probe_State.Probe_Error
                        Nop()


                End Select

            Case 3, 4
                Select Case CNC.Probe_State
                    Case Class_CNC.enum_Probe_State.Idle
                        Cycle_Step = 5
                        If Dir = Class_CNC.enum_Direction.Center Then
                            Left_X = CNC.Probe_End_X
                            Left_Gap = Math.Abs(CNC.Probe_Start_X - CNC.Probe_End_X)
                            Update_Command = "L"
                            CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.N)
                        End If
                    Case Class_CNC.enum_Probe_State.Done
                        Cycle_Step = 4
                    Case Class_CNC.enum_Probe_State.Probe_Error
                        Nop()
                End Select


            Case 5, 6
                Select Case CNC.Probe_State
                    Case Class_CNC.enum_Probe_State.Idle
                        Cycle_Step = 7
                        If Dir = Class_CNC.enum_Direction.Center Then
                            Top_Y = CNC.Probe_End_Y
                            Top_Gap = Math.Abs(CNC.Probe_Start_Y - CNC.Probe_End_Y)
                            Update_Command = "T"
                            CNC.Start_Probe_Cycle("Probe_Cycle", Class_CNC.enum_Direction.S)
                        End If
                    Case Class_CNC.enum_Probe_State.Done
                        Cycle_Step = 6
                    Case Class_CNC.enum_Probe_State.Probe_Error
                        Nop()
                End Select

            Case 7
                Select Case CNC.Probe_State
                    Case Class_CNC.enum_Probe_State.Idle
                    Case Class_CNC.enum_Probe_State.Done
                        If Dir = Class_CNC.enum_Direction.Center Then
                            Bottom_Y = CNC.Probe_End_Y
                            Bottom_Gap = Math.Abs(CNC.Probe_Start_Y - CNC.Probe_End_Y)
                            Update_Command = "B"
                        End If
                    Case Class_CNC.enum_Probe_State.Probe_Error
                        Nop()
                End Select

        End Select

EarlyExit:

        Probe_Information_Update(Dir, Update_Command)
        Pendant_Update_Display()
    End Sub

    Private Sub Probe_Move_To_Button(Evnt As Class_CNC.class_Event)

        If Symbol.Get_Value("Probe.In_Spindle") = False Then
            Flash_Message("Probe not loaded in spindle", 1)
            Exit Sub
        End If

        Select Case Evnt.Symbol.Name

            Case "Button.Probe.Center_Move_To_Center"
                Dim Center As String = Symbol.Get_Value("Text_Box.Probe.Center.XY")
                Dim S() As String = Center.Split(",")
                Dim Block As String = "G01 X" & S(0) & " Y" & S(1) & " F" & CNC.Probe_Feedrate
                Controller.Queue_System_GCode(Block)

            Case "Button.Probe.Center_Raise_Z"
                Controller.Queue_System_GCode("G01 Z" & Symbol.Get_Value("Text_Box.Probe.Center.Z_Raised") & _
                                              " F" & Symbol.Get_Value("Sys.Rapid_Feedrate"))

            Case "Button.Probe.Center_Lower_Z"
                Controller.Queue_System_GCode("G01 Z" & Symbol.Get_Value("Text_Box.Probe.Center.Z_Lowered") & " F" & CNC.Probe_Feedrate)
        End Select

    End Sub

    Private Sub Probe_Load_Save(Evnt As Class_CNC.class_Event)
        Select Case Evnt.Symbol.Name
            Case "Button.Probe.Load"
                Load_Probe_Positions()
            Case "Button.Probe.Save"
                Save_Probe_Positons()
        End Select
    End Sub

    Public Sub Load_Probe_Positions()
        If Controller.Check_For_In_Cycle("Cannot change Offsets while in cycle") Then Exit Sub

        Dim dlg As New OpenFileDialog
        Dim Load_OK As Boolean = False
        Dim Buff() As String
        Dim S() As String

        dlg.InitialDirectory = Symbol.Get_Value("Text_Box.Probe.Folder")
        dlg.FileName = Symbol.Get_Value("Text_Box.Probe.File")

        dlg.Filter = "Offset Files (*.txt)|*.txt|All files (*.*)|*.*"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Symbol.Set_Value("Text_Box.Probe.Folder", Path.GetDirectoryName(dlg.FileName))
            Symbol.Set_Value("Text_Box.Probe.File", Path.GetFileName(dlg.FileName))

            Buff = File.ReadAllLines(dlg.FileName)

            For I = 0 To Buff.Count - 1
                S = Buff(I).Split("~")
                Select Case S(0)
                    Case "Safe_Z"
                        Symbol.Set_Value("Text_Box.Probe.Safe_Z.Round_3", S(1))
                    Case "Z_Up"
                        Symbol.Set_Value("Text_Box.Move.Z_Up.Round_3", S(1))
                    Case "Z_Down"
                        Symbol.Set_Value("Text_Box.Move.Z_Down.Round_3", S(1))
                    Case "X_Minus"
                        Symbol.Set_Value("Text_Box.Move.X_Minus.Round_3", S(1))
                    Case "X_Plus"
                        Symbol.Set_Value("Text_Box.Move.X_Plus.Round_3", S(1))
                    Case "Y_Minus"
                        Symbol.Set_Value("Text_Box.Move.Y_Minus.Round_3", S(1))
                    Case "Y_Plus"
                        Symbol.Set_Value("Text_Box.Move.Y_Plus.Round_3", S(1))
                    Case "Move_Raise_Z"
                        If S(1) = "True" Then
                            Main_Form.chk_Move_Raise_Z.Checked = True
                        Else
                            Main_Form.chk_Move_Raise_Z.Checked = False
                        End If
                End Select

            Next

        End If

        Controller.Get_Offsets()
    End Sub

    Public Sub Save_Probe_Positons()
        Dim dlg As New SaveFileDialog
        Dim Buff As New List(Of String)

        dlg.InitialDirectory = Symbol.Get_Value("Text_Box.Probe.Folder")
        dlg.FileName = Symbol.Get_Value("Text_Box.Probe.File")
        dlg.Filter = "Offset Files (*.txt)|*.txt|All files (*.*)|*.*"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Symbol.Set_Value("Text_Box.Probe.Folder", Path.GetDirectoryName(dlg.FileName))
            Symbol.Set_Value("Text_Box.Probe.File", Path.GetFileName(dlg.FileName))

            If File.Exists(dlg.FileName) Then
                Dim DF As New Class_Data_File
                DF.Backup_File(dlg.FileName, True)
            End If

            Buff.Add("Safe_Z~" & Symbol.Get_Value("Text_Box.Probe.Safe_Z"))
            Buff.Add("Z_Up~" & Symbol.Get_Value("Text_Box.Move.Z_Up"))
            Buff.Add("Z_Down~" & Symbol.Get_Value("Text_Box.Move.Z_Down"))
            Buff.Add("X_Minus~" & Symbol.Get_Value("Text_Box.Move.X_Minus"))
            Buff.Add("X_Plus~" & Symbol.Get_Value("Text_Box.Move.X_Plus"))
            Buff.Add("Y_Minus~" & Symbol.Get_Value("Text_Box.Move.Y_Minus"))
            Buff.Add("Y_Plus~" & Symbol.Get_Value("Text_Box.Move.Y_Plus"))
            If Main_Form.chk_Move_Raise_Z.Checked Then
                Buff.Add("Move_Raise_Z~True")
            Else
                Buff.Add("Move_Raise_Z~False")
            End If

            File.WriteAllLines(dlg.FileName, Buff)
        End If

    End Sub


#End Region

#Region "Pendant Macros"

    Public Function Pad_Left(Symbol_Name As String) As String
        Dim X As String = Symbol.Get_Value(Symbol_Name)

        If IsNumeric(X) Then
            X = Format_Number(Symbol.Get_Value(Symbol_Name))
        Else
            X = " "
        End If

        Return X.PadLeft(8)

    End Function

    Public Function Pad_Left_Add(Symbol_Name As String, Symbol_Name2 As String) As String
        Dim X As String = Format_Number(Symbol.Get_Value(Symbol_Name) + Symbol.Get_Value(Symbol_Name2))
        Return X.PadLeft(8)
    End Function

    Public Sub Pendant_Update_Display()
        Static Dim Jog_Rate As String = ""

        If Not Logitech_G13.Enabled Then Exit Sub
        If Pendant_Message_Pending Then Exit Sub

        If Symbol.Get_Value("Button.Jog_Rate.Fast") = True Then Jog_Rate = "F"
        If Symbol.Get_Value("Button.Jog_Rate.Slow") = True Then Jog_Rate = "S"
        If Symbol.Get_Value("Button.Jog_Rate.Creep") = True Then Jog_Rate = "C"
        If Symbol.Get_Value("Button.Jog_Rate.Big_Step") = True Then Jog_Rate = "B"
        If Symbol.Get_Value("Button.Jog_Rate.Little_Step") = True Then Jog_Rate = "L"

        Select Case Pendant_Mode
            Case 0 'Jog
                Logitech_G13.Set_Color(75, 0, 0)

                Logitech_G13.Set_Text(0, Jog_Rate & " Absolute Work    Offset")
                If Symbol.Get_Value("Sys.Coordinate_System") <= Class_CNC.enum_Coordinate_System.G54 Then
                    Logitech_G13.Set_Text(1, "X" & Pad_Left("Sys.Abs_X") & Pad_Left_Add("Sys.Abs_X", "Sys.Offset_X") & Pad_Left("Sys.Offset_X"))
                    Logitech_G13.Set_Text(2, "Y" & Pad_Left("Sys.Abs_Y") & Pad_Left_Add("Sys.Abs_Y", "Sys.Offset_Y") & Pad_Left("Sys.Offset_Y"))
                    Logitech_G13.Set_Text(3, "Z" & Pad_Left("Sys.Abs_Z") & Pad_Left_Add("Sys.Abs_Z", "Sys.Offset_Z") & Pad_Left("Sys.Offset_Z"))

                    Logitech_G13.Set_Text(1, "X" & Pad_Left("Sys.Abs_X") & Pad_Left_Add("Sys.Abs_X", "Sys.Offset_X") & Pad_Left("Sys.Offset_X"))
                    Logitech_G13.Set_Text(2, "Y" & Pad_Left("Sys.Abs_Y") & Pad_Left_Add("Sys.Abs_Y", "Sys.Offset_Y") & Pad_Left("Sys.Offset_Y"))
                    Logitech_G13.Set_Text(3, "Z" & Pad_Left("Sys.Abs_Z") & Pad_Left_Add("Sys.Abs_Z", "Sys.Offset_Z") & Pad_Left("Sys.Offset_Z"))
                Else
                    Logitech_G13.Set_Text(1, "X" & Pad_Left("Sys.Abs_X") & Pad_Left("Sys.Work_X") & Pad_Left("Sys.Offset_X"))
                    Logitech_G13.Set_Text(2, "Y" & Pad_Left("Sys.Abs_Y") & Pad_Left("Sys.Work_Y") & Pad_Left("Sys.Offset_Y"))
                    Logitech_G13.Set_Text(3, "Z" & Pad_Left("Sys.Abs_Z") & Pad_Left("Sys.Work_Z") & Pad_Left("Sys.Offset_Z"))
                End If
                Logitech_G13.Update_Display()

            Case 1 'Probe

                Logitech_G13.Set_Color(0, 50, 0)

                Dim X_Surf As Single = Symbol.Get_Value("Text_Box.Probe.Surface.X.Round_3")
                Dim Y_Surf As Single = Symbol.Get_Value("Text_Box.Probe.Surface.Y.Round_3")
                Dim Z_Surf As Single = Symbol.Get_Value("Text_Box.Probe.Surface.Z.Round_3")

                Dim X_Gap As Single = Symbol.Get_Value("Text_Box.Probe.Gap.X.Round_3")
                Dim Y_Gap As Single = Symbol.Get_Value("Text_Box.Probe.Gap.Y.Round_3")
                Dim Z_Gap As Single = Symbol.Get_Value("Text_Box.Probe.Gap.Z.Round_3")

                Dim State As String = Symbol.Get_Value("Text_Box.Probe.State")

                If State = "Idle" Then
                    Logitech_G13.Set_Text(0, Jog_Rate & "    Gap   Surface Offset")
                Else
                    Logitech_G13.Set_Text(0, State)
                End If

                Logitech_G13.Set_Text(1, "X" & Pad_Left("Text_Box.Probe.Gap.X") & Pad_Left("Text_Box.Probe.Surface.X") & Pad_Left("Sys.Offset_X"))
                Logitech_G13.Set_Text(2, "Y" & Pad_Left("Text_Box.Probe.Gap.Y") & Pad_Left("Text_Box.Probe.Surface.Y") & Pad_Left("Sys.Offset_Y"))
                Logitech_G13.Set_Text(3, "Z" & Pad_Left("Text_Box.Probe.Gap.Z") & Pad_Left("Text_Box.Probe.Surface.Z") & Pad_Left("Sys.Offset_Z"))
                Logitech_G13.Update_Display()

            Case 2 'Offsets
                Logitech_G13.Set_Color(50, 50, 0)

                Logitech_G13.Set_Text(0, Jog_Rate & " Absolute Offsets")
                Logitech_G13.Set_Text(1, "X" & Pad_Left("Sys.Abs_X") & Pad_Left("Sys.Offset_X"))
                Logitech_G13.Set_Text(2, "Y" & Pad_Left("Sys.Abs_Y") & Pad_Left("Sys.Offset_Y"))
                Logitech_G13.Set_Text(3, "Z" & Pad_Left("Sys.Abs_Z") & Pad_Left("Sys.Offset_Z"))
                Logitech_G13.Update_Display()

        End Select

    End Sub

    'Private Sub Pendant_Update_Header(Optional Update_Display As Boolean = True)
    '    'If Pendant_Message_Displayed Then Exit Sub
    '    Dim Head As String

    '    Select Case Pendant_Mode
    '        Case 0 'Jog
    '            Logitech_G13.Set_Color(75, 0, 0)
    '            Head = " Absolute Work   Offset"
    '        Case 1 'Probe
    '            Head = "Probe Gap    Surface Offset"
    '            Logitech_G13.Set_Color(0, 50, 0)

    '        Case 2 'Offsets
    '            Head = " Offsets"
    '            Logitech_G13.Set_Color(50, 50, 0)

    '        Case Else
    '            Exit Sub

    '    End Select

    '    If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Jog_Rate.Fast") Then Head = "F" & Head
    '    If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Jog_Rate.Slow") Then Head = "S" & Head
    '    If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Jog_Rate.Creep") Then Head = "C" & Head
    '    If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Jog_Rate.Big_Step") Then Head = "B" & Head
    '    If Symbol.Get_Value("Jog_Rate.Selected") = Symbol.Get_Value("Jog_Rate.Little_Step") Then Head = "L" & Head
    '    Logitech_G13.Set_Text(0, Head)

    '    If Update_Display Then Pendant_Update_Display()

    'End Sub

    Private Sub Pendant_Handler_Up(Evnt As Class_CNC.class_Event)
        Dim Key_Symbol As Class_Symbols.class_Symbol = Nothing

        Select Case Evnt.Symbol.Key

            Case "HOT_KEY.CTRL_ALT_RIGHT"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.X_Plus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_LEFT"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.X_Minus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_UP"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Y_Plus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_DOWN"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Y_Minus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_PAGEUP"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Z_Plus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_NEXT"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Z_Minus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Up, Key_Symbol.Ctrl, "Pendant_Handler")
        End Select
    End Sub

    Private Sub Pendant_Handler_Down(Evnt As Class_CNC.class_Event)
        Static Dim Key_Symbol As Class_Symbols.class_Symbol = Nothing
        Static Dim Waiting_For_Response_Symbol As Class_Symbols.class_Symbol = Nothing

        If Not Symbol.Get_Value("Sys.In_Cycle_Stop") Then
            If (Evnt.Symbol.Key <> "HOT_KEY.CTRL_ALT_C") And (Evnt.Symbol.Key <> "HOT_KEY.CTRL_ALT_Z") Then 'Cycle stop or feed hold
                Exit Sub
            End If
        End If

        'Check for waiting for operator input
        If Not IsNothing(Waiting_For_Response_Symbol) Then
            If Evnt.Symbol.Key = "HOT_KEY.CTRL_ALT_D7" Then
                If Not IsNothing(Waiting_For_Response_Symbol) Then
                    CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Waiting_For_Response_Symbol.Ctrl, "Pendant_Handler")
                End If
            End If
            Pendant_Message_Pending = False
            Waiting_For_Response_Symbol = Nothing
            Pendant_Update_Display()
            Exit Sub
        End If

        If Pendant_Message_Pending Then
            Pendant_Message_Pending = False
            Pendant_Update_Display()
            If Evnt.Symbol.Key = "HOT_KEY.CTRL_ALT_U" Then Exit Sub
            If Evnt.Symbol.Key = "HOT_KEY.CTRL_ALT_D7" Then Exit Sub
        End If

        Key_Symbol = Nothing

        Select Case Evnt.Symbol.Key

            Case "HOT_KEY.CTRL_ALT_RIGHT"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.X_Plus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_LEFT"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.X_Minus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_UP"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Y_Plus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_DOWN"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Y_Minus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_PAGEUP"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Z_Plus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_NEXT"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog.Z_Minus", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_D7"  'Mode
                If Pendant_Message_Pending Then
                    Pendant_Message_Pending = False
                Else
                    Pendant_Mode += 1
                    If Pendant_Mode > 2 Then
                        Pendant_Mode = 0
                    End If
                End If
                Pendant_Update_Display()

            Case "HOT_KEY.CTRL_ALT_U" 'Help

                Pendant_Message_Pending = Not Pendant_Message_Pending

                If Pendant_Message_Pending Then

                    Select Case Pendant_Mode

                        Case 0 'Jog
                            '                             1   2   3   4   5   6   7
                            '                             Q   W   E   M   T   Y   U
                            '                                 A   D   F   G   H
                            '                                     Z   X   C
                            '                             123456789012345678901234567
                            Logitech_G13.Display_Message("F   S   C   -   -   -  Mode", _
                                                         "B   L   -   -   -   -  Help", _
                                                         "    HM  PK  GS  GT  MT", _
                                                         "  Feed    Cycle   Stop")
                        Case 1 'Probe
                            '                             123456789012345678901234567
                            Logitech_G13.Display_Message("F   S   C   ^   -   -  Mode", _
                                                         "B   L   <   Z   >   -  Help", _
                                                         "    OX  OY  v   -   -  ", _
                                                         "  Feed    Cycle   Stop")
                        Case 2 'Offsets
                            Logitech_G13.Display_Message("F   S   C   -    -  -  Mode", _
                                                         "B   L   - Set Z  -  -  Help", _
                                                         "    -   -   -    -  -  ", _
                                                         "  Feed    Cycle   Stop")
                        Case Else
                            Exit Sub

                    End Select
                    Logitech_G13.Update_Display()

                Else
                    Pendant_Update_Display()
                End If

            Case "HOT_KEY.CTRL_ALT_C" 'Cycle Stop
                Controller.Cycle_Stop()

            Case "HOT_KEY.CTRL_ALT_Z" 'Feed
                If Symbol.Get_Value("Sys.In_Feed_Hold") Then
                    Controller.Feed_Resume()
                Else
                    Controller.Feed_Hold()
                End If

            Case "HOT_KEY.CTRL_ALT_D1"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog_Rate.Fast", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_D2"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog_Rate.Slow", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_D3"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog_Rate.Creep", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_Q"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog_Rate.Big_Step", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")

            Case "HOT_KEY.CTRL_ALT_W"
                Key_Symbol = Symbol.Get_Symbol("Button.Jog_Rate.Little_Step", False)
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")


            Case Else

                Select Case Pendant_Mode

                    Case 0 'Jog

                        Select Case Evnt.Symbol.Key

                            Case "HOT_KEY.CTRL_ALT_X"
                                Logitech_G13.Display_Message("OK to Cycle Start?      CAN   OK", "", "", "")
                                Waiting_For_Response_Symbol = Symbol.Get_Symbol("Button.Cycle", False)
                                Pendant_Message_Pending = True

                            Case "HOT_KEY.CTRL_ALT_A"
                                Goto_Position("Button.Goto.Home")

                            Case "HOT_KEY.CTRL_ALT_D"
                                Goto_Position("Button.Goto.Park")

                            Case "HOT_KEY.CTRL_ALT_F"
                                Goto_Position("Button.Goto.Tool_Seat")

                            Case "HOT_KEY.CTRL_ALT_G"
                                Goto_Position("Button.Goto.Tool_Measure")

                            Case "HOT_KEY.CTRL_ALT_H"
                                'Tool_Measure_Button(Evnt)
                                If Not Is_In_Position(CSng(Symbol.Get_Value("Text_Box.Tool.Measure.X.Round_3")), _
                                                      CSng(Symbol.Get_Value("Text_Box.Tool.Measure.Y.Round_3")), _
                                                      CSng(Symbol.Get_Value("Text_Box.Tool.Measure.Z.Round_3"))) Then
                                    Message_Box.ShowDialog("Not at tool measure position, measure anyway?", , MessageBoxButtons.OKCancel)
                                    If Message_Box.DialogResult <> DialogResult.OK Then
                                        Exit Sub
                                    End If
                                End If


                                If Symbol.Get_Value("Button.Tool_Measure.Top.Enabled") Then
                                    Tool_Measure("Button.Tool_Measure.Top")
                                End If

                                If Symbol.Get_Value("Button.Tool_Measure.Bottom.Enabled") Then
                                    Tool_Measure("Button.Tool_Measure.Bottom")
                                End If

                        End Select

                        If IsNothing(Waiting_For_Response_Symbol) Then
                            If Not IsNothing(Key_Symbol) Then
                                CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, Key_Symbol.Ctrl, "Pendant_Handler")
                            End If
                        End If

                    Case 1 'Probe

                        If Not Symbol.Get_Value("Homed.XYZ") Then
                            '                             123456789012345678901234567
                            Logitech_G13.Display_Message("Axes not homed.          OK", "All axis must be homed", "before probing.", "")
                            Pendant_Message_Pending = True
                            Exit Sub
                        End If

                        If Symbol.Get_Value("Probe.In_Spindle") = False Then
                            '                             123456789012345678901234567
                            Logitech_G13.Display_Message("Probe not loaded.        OK", "", "", "")
                            Pendant_Message_Pending = True
                            Exit Sub
                        End If

                        Select Case Evnt.Symbol.Key

                            Case "HOT_KEY.CTRL_ALT_A"
                                Key_Symbol = Symbol.Get_Symbol("Button.Set_Offset_Probe.X", False)

                            Case "HOT_KEY.CTRL_ALT_D"
                                Key_Symbol = Symbol.Get_Symbol("Button.Set_Offset_Probe.Y", False)

                            Case "HOT_KEY.CTRL_ALT_T"
                                Key_Symbol = Symbol.Get_Symbol("Button.Probe.X_Plus", False)

                            Case "HOT_KEY.CTRL_ALT_E"
                                Key_Symbol = Symbol.Get_Symbol("Button.Probe.X_Minus", False)

                            Case "HOT_KEY.CTRL_ALT_D4"
                                Key_Symbol = Symbol.Get_Symbol("Button.Probe.Y_Plus", False)

                            Case "HOT_KEY.CTRL_ALT_F"
                                Key_Symbol = Symbol.Get_Symbol("Button.Probe.Y_Minus", False)

                            Case "HOT_KEY.CTRL_ALT_M"
                                Key_Symbol = Symbol.Get_Symbol("Button.Probe.Z_Minus", False)

                        End Select

                        If Not IsNothing(Key_Symbol) Then
                            CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, _
                                            Key_Symbol.Ctrl, "Pendant_Handler")
                        End If

                    Case 2 'Offsets

                        Select Case Evnt.Symbol.Key

                            Case "HOT_KEY.CTRL_ALT_M"
                                Key_Symbol = Symbol.Get_Symbol("Button.Set_Offset.Z", False)

                        End Select

                        If Not IsNothing(Key_Symbol) Then
                            CNC.Cause_Event(Class_CNC.enum_Event_Types.Button_Down, _
                                            Key_Symbol.Ctrl, "Pendant_Handler")
                        End If

                    Case Else
                        Exit Sub

                End Select 'Pendant_Mode


        End Select 'Evnt.Symbol.Key

    End Sub

#End Region

End Class
