
Public Class Class_Tiny_G

    Public Class class_message
        Public Text As String
        Public Routine As String
    End Class

#Region "Enums"

    Public Enum enum_Status_Code 'From TinyG messages
        None = -1
        Initializing = 0
        Ready = 1
        Alarm = 2
        Stopped = 3
        Program_End = 4
        In_Motion = 5
        Feedhold = 6
        Probing = 7
        Cycling = 8
        Homing = 9
    End Enum

#End Region

#Region "Decarations"

    Public Default_Status_Command As String = "{sr:{line:t,posx:t,posy:t,posz:t,mpox:t,mpoy:t,mpoz:t,vel:t,stat:t,coor:t,unit:t}}"

    Public Reset_Character As Byte = 24
    Public Min_Buffer_Slots As Integer = 5
    Public Buffers_Available As Integer
    Public Waiting_For_Response As Boolean = False
    Public Program_Line_Number_Shadow As Integer = 0
    
    Private Abs_Last_Point As ctrl_Drawing.struct_Draw_Point
    Private Abs_Current_Point As ctrl_Drawing.struct_Draw_Point
    Private Wrk_Last_Point As ctrl_Drawing.struct_Draw_Point
    Private Wrk_Current_Point As ctrl_Drawing.struct_Draw_Point

    Private Status_Shadow As Class_CNC.enum_Status_Codes
    Private Verify_Settings As Boolean
    Private Reset_Dialog As New dlg_Modal_Message

    Public Block_No As Integer = 1
    Public Program_Status As Class_CNC.enum_Status_Codes = Class_CNC.enum_Status_Codes.Stopped
    Public Program_Status_Shadow As Class_CNC.enum_Status_Codes = Class_CNC.enum_Status_Codes.None

    Public Connected As Boolean = False

#End Region

    'Cycle Start    Serial.Queue_Immediate_Message("{~:n}")
    'Feed Hold      Serial.Queue_Immediate_Message("{!:n}")
    'Abort          Serial.Queue_Immediate_Message("{%:n}") Flushes TinyG queue
    'Feed hold and flush buffer can be sent at the same time   Serial.Queue_Immediate_Message("{!%:n}")

    Public Sub Initialize()
        'CNC.Load_Persistant_Info()

        Controller.Flush_Queue()
        Wait.Delay_Seconds(0.25)

        Send_Status_Report_Format() 'May not needed now that formats are persistant

        Symbol.Set_Value("Sys.In_Cycle_Stop", False)
        Symbol.Set_Value("Sys.In_Feed_Hold", False)

        'Force display to update
        Abs_Last_Point.Xo = -1
        Abs_Last_Point.Yo = -1
        Abs_Last_Point.Zo = -1

        'Ignore_Position_Status = True

    End Sub

    Public Sub Send_Status_Report_Format()
        CNC.Queue_Message(Default_Status_Command, False, "Send_Status_Report_Format")
    End Sub

    Public Sub Reset_Program_Interface()
        Program_Line_Number_Shadow = -1
        Program_Status_Shadow = Class_CNC.enum_Status_Codes.None
        Program_Status = Class_CNC.enum_Status_Codes.Stopped
    End Sub

#Region "Tiny G Messages"

    Public Function Decode_Message(Message As String) As List(Of Class_CNC.class_Event)
        Dim P() As String
        Dim T() As String
        Dim Org As String = Message
        Dim Param As Class_CNC.struct_Param
        Dim Stat As Class_CNC.enum_Status_Codes
        Dim Block_Number As Integer = 0
        Dim Block_Number_Shadow As Integer = 0

        If Message.IndexOf(":") < 0 Then Return Nothing

        Dim Message_Event As New Class_CNC.class_Event
        Dim Event_List As New List(Of Class_CNC.class_Event)

        Message_Event.Type = Class_CNC.enum_Event_Types.None
        Message_Event.Message = Message
        Message_Event.Parameter_List = New List(Of Class_CNC.struct_Param)

        Event_List.Add(Message_Event)

        Message = Message.Replace("""", "")
        Message = Message.Replace("{", "~")
        Message = Message.Replace("}", "~")
        Message = Message.Replace("[", "~")
        Message = Message.Replace("]", "~")
        Message = Message.Replace(",", "~")

        P = Message.Split("~")

        For I = 0 To P.Count - 1
            If P(I) <> "" Then
                T = P(I).Split(":")
                If T.Count > 0 Then
                    Param = New Class_CNC.struct_Param
                    Param.Name = T(0)
                    If T.Count > 1 Then
                        Param.Value = T(1)
                    End If
                    Message_Event.Parameter_List.Add(Param)
                End If
            End If
        Next

        Select Case Message_Event.Parameter_List(0).Name

            Case "sr"
                '{sr:{"line":0,"posx":0.000,"posy":0.000,"posz":0.000,"mpox":0.000,"mpoy":0.000,"mpoz":0.000,"vel":0.00,"stat":3,"coor":1,"unit":0}}
                Message_Event.Type = Class_CNC.enum_Event_Types.Status_Report
                Message_Event.Routine = "Decode_Message"

                For I = 1 To Message_Event.Parameter_List.Count - 1

                    Select Case Message_Event.Parameter_List(I).Name

                        Case "line"
                            Dim Ev As Class_CNC.class_Event
                            Ev = New Class_CNC.class_Event
                            Block_Number = Message_Event.Parameter_List(I).Value

                            If Block_Number_Shadow <> Block_Number Then
                                Message_Event.Flags.Block_Number_Changed = True
                            End If

                            If Block_Number = 0 Then
                                Ev.Type = Class_CNC.enum_Event_Types.System_GCode_Complete
                                Ev.Parameter = "N" & Message_Event.Parameter_List(I).Value
                                Ev.Flags.Block_Number_Changed = True
                                Ev.Routine = "Decode_Message"
                                Event_List.Add(Ev)
                            End If

                        Case "mpox"
                            Symbol.Set_Value("Sys.Abs_X", Math.Round(CSng(Message_Event.Parameter_List(I).Value) * mm_to_inch, 3))
                            If CNC.Abs_X_Shadow <> Symbol.Get_Value("Sys.Abs_X") Then 'May not be needed if using filtered status reports
                                Message_Event.Flags.Position_Changed = True
                            End If
                            CNC.Abs_X_Shadow = Symbol.Get_Value("Sys.Abs_X")

                        Case "mpoy"
                            Symbol.Set_Value("Sys.Abs_Y", Math.Round(CSng(Message_Event.Parameter_List(I).Value) * mm_to_inch, 3))
                            If CNC.Abs_Y_Shadow <> Symbol.Get_Value("Sys.Abs_Y") Then 'May not be needed if using filtered status reports
                                Message_Event.Flags.Position_Changed = True
                            End If
                            CNC.Abs_Y_Shadow = Symbol.Get_Value("Sys.Abs_Y")

                        Case "mpoz"
                            Symbol.Set_Value("Sys.Abs_Z", Math.Round(CSng(Message_Event.Parameter_List(I).Value) * mm_to_inch, 3))
                            If CNC.Abs_Z_Shadow <> Symbol.Get_Value("Sys.Abs_Z") Then 'May not be needed if using filtered status reports
                                Message_Event.Flags.Position_Changed = True
                            End If
                            CNC.Abs_Z_Shadow = Symbol.Get_Value("Sys.Abs_Z")

                        Case "posx"
                            Symbol.Set_Value("Sys.Work_X", CSng(Message_Event.Parameter_List(I).Value))
                        Case "posy"
                            Symbol.Set_Value("Sys.Work_Y", CSng(Message_Event.Parameter_List(I).Value))
                        Case "posz"
                            Symbol.Set_Value("Sys.Work_Z", CSng(Message_Event.Parameter_List(I).Value))
                        Case "vel"
                            Symbol.Set_Value("Sys.Velocity", CSng(Message_Event.Parameter_List(I).Value))
                        Case "stat"
                            Stat = CNC.Translate_Status_Code(Int(Message_Event.Parameter_List(I).Value))
                            CNC.Queue_State(Stat)
                            CNC.Status_Code = Stat
                            Message_Event.Parameter = Stat
                            If Stat <> Status_Shadow Then
                                Message_Event.Flags.State_Changed = True
                            End If

                            If CNC.Probe_State <> Class_CNC.enum_Probe_State.Idle Then
                                If CNC.Last_State <> CNC.Current_State Then
                                    Dim Ev As New Class_CNC.class_Event
                                    Ev.Type = Class_CNC.enum_Event_Types.Probe_Status_Update
                                    Ev.Parameter = CNC.Current_State.ToString
                                    Ev.Parameter_List = Message_Event.Parameter_List
                                    Ev.Routine = "Decode_Message"
                                    Event_List.Add(Ev)
                                End If
                            End If
                            Status_Shadow = Stat

                        Case "coor"
                            If Symbol.Get_Value("Sys.Coordinate_System") <> CInt(Message_Event.Parameter_List(I).Value) Then
                                Symbol.Set_Value("Sys.Coordinate_System", CInt(Message_Event.Parameter_List(I).Value))
                                Message_Event.Flags.Coordinate_System_Changed = True
                            End If

                        Case "unit"

                        Case "f" 'footer, ignore

                        Case Else

                    End Select

                Next

            Case "er"
                '{er:{fb:440.20,st:204,msg:"Limit switch hit - Shutdown occurred"}}
                If Not Message_Event.Message.Contains("File not open") Then
                    Message_Event.Type = Class_CNC.enum_Event_Types.Error_Message
                    'Message_Event.Parameter = Message_Event.Parameter_List(3).Value
                    Message_Event.Routine = "Decode_Message"
                    Event_List.Add(Message_Event)
                End If

            Case "qr"
                '{qr:27, "qi":1, "qo":0} 
                Message_Event.Type = Class_CNC.enum_Event_Types.Queue_Report
                Message_Event.Routine = "Decode_Message"
                Buffers_Available = Message_Event.Parameter_List(0).Value
                Message_Event.Parameter = Buffers_Available
                Event_List.Add(Message_Event)

            Case "r"
                Message_Event.Type = Class_CNC.enum_Event_Types.Message_Reply
                Message_Event.Routine = "Decode_Message"

                If Verify_Settings Then
                    If Message_Event.Parameter_List(1).Name <> "sr" Then
                        Verify_Setting(Message_Event.Parameter_List(1).Name, Message_Event.Parameter_List(1).Value)
                    End If
                End If

                Select Case Message_Event.Parameter_List(1).Name
                    Case "fv"
                        FirmwareVersion = Message_Event.Parameter_List(1).Value.Replace("{r:{fv:", "")
                        If Message_Event.Parameter_List(6).Value = "SYSTEM READY" Then
                            '{r:{fv:0.970,fb:440.19,hp:1,hv:8,id:"3X3566-KBR",msg:"SYSTEM READY"},f:[1,0,0,2212]}
                            Dim Ev As New Class_CNC.class_Event
                            Ev.Message = Message_Event.Message
                            Ev.Type = Class_CNC.enum_Event_Types.Controller_Reset
                            Ev.Routine = "Decode_Message"
                            Event_List.Add(Ev)
                        End If
                    Case "fb"
                        Firmware_Build = Message_Event.Parameter_List(1).Value.Replace("fb:", "")
                    Case "hv"
                        Hardware_Version = Message_Event.Parameter_List(1).Value.Replace("hv:", "")
                    Case "id"
                        TinyG_ID = Message_Event.Parameter_List(1).Value.Replace("id:", "")
                        TinyG_ID = TinyG_ID.Replace("""", "")

                    Case "msg"
                        Dim Ev As New Class_CNC.class_Event
                        If Mid(Message_Event.Parameter_List(1).Value, 1, 13) = "Probing error" Then
                            Ev.Parameter = "Probe_Error"
                            Ev.Parameter_List = Message_Event.Parameter_List
                            Ev.Type = Class_CNC.enum_Event_Types.Probe_Status_Update
                        Else
                            Ev.Type = Class_CNC.enum_Event_Types.Info_Message
                            Ev.Parameter = Message_Event.Parameter_List(1)
                        End If
                        Ev.Routine = "Decode_Message"
                        Event_List.Add(Ev)


                    Case "gc"
                        '{"r":{"gc":"N2G0Z0.8000","n":2},"f":[1,0,14,9047]}
                        '{r:{gc:"G20"}
                        Dim Ev As New Class_CNC.class_Event
                        Dim V As String = Message_Event.Parameter_List(1).Value
                        If V.Contains("M1000") Then
                            Ev.Type = Class_CNC.enum_Event_Types.Initialize_Done
                        ElseIf V.Contains("M1001") Then
                            Ev.Type = Class_CNC.enum_Event_Types.Settings_Downloaded
                        ElseIf V.Contains("M1002") Then
                            Ev.Type = Class_CNC.enum_Event_Types.Verify_Done
                        Else
                            If Mid(V, 1, 1) = "N" Then
                                Ev.Type = Class_CNC.enum_Event_Types.GCode_Ack
                            Else
                                Ev.Type = Class_CNC.enum_Event_Types.System_GCode_Ack
                            End If
                        End If
                        Ev.Parameter = Message_Event.Parameter_List(1).Value
                        Ev.Routine = "Decode_Message"
                        Event_List.Add(Ev)

                    Case "g55"
                        Dim Ev As New Class_CNC.class_Event
                        Ev.Type = Class_CNC.enum_Event_Types.Offsets_Changed
                        Ev.Message = Message_Event.Message
                        Event_List.Add(Ev)
                        Message_Event.Flags.Offsets_Changed = True
                        Symbol.Set_Value("Sys.Offset_X", Message_Event.Parameter_List(2).Value)
                        Symbol.Set_Value("Sys.Offset_Y", Message_Event.Parameter_List(3).Value)
                        Symbol.Set_Value("Sys.Offset_Z", Message_Event.Parameter_List(4).Value)

                    Case "g55x"
                        Dim Ev As New Class_CNC.class_Event
                        Ev.Type = Class_CNC.enum_Event_Types.Offsets_Changed
                        Ev.Message = Message_Event.Message
                        Event_List.Add(Ev)
                        Message_Event.Flags.Offsets_Changed = True
                        Symbol.Set_Value("Sys.Offset_X", Message_Event.Parameter_List(1).Value)

                    Case "g55y"
                        Dim Ev As New Class_CNC.class_Event
                        Ev.Type = Class_CNC.enum_Event_Types.Offsets_Changed
                        Ev.Message = Message_Event.Message
                        Event_List.Add(Ev)
                        Message_Event.Flags.Offsets_Changed = True
                        Symbol.Set_Value("Sys.Offset_Y", Message_Event.Parameter_List(1).Value)

                    Case "g55z"
                        Dim Ev As New Class_CNC.class_Event
                        Ev.Type = Class_CNC.enum_Event_Types.Offsets_Changed
                        Ev.Message = Message_Event.Message
                        Event_List.Add(Ev)
                        Message_Event.Flags.Offsets_Changed = True
                        Symbol.Set_Value("Sys.Offset_Z", Message_Event.Parameter_List(1).Value)

                    Case "prb"
                        '{r:{prb:{e:1,x:249.528,y:-0.140,z:0.000,a:0.000,b:0.000,c:0.000}},f:[1,0,0,2121]}
                        Dim Ev As New Class_CNC.class_Event
                        Ev.Type = Class_CNC.enum_Event_Types.Probe_Status_Update
                        Ev.Parameter_List = Message_Event.Parameter_List
                        If Message_Event.Parameter_List(2).Value = 1 Then
                            Ev.Parameter = "Probe_Done"
                        Else
                            Ev.Parameter = "Probe_Error"
                        End If
                        Ev.Routine = "Decode_Message"
                        Event_List.Add(Ev)

                End Select

            Case "rx"
                Dim Ev As New Class_CNC.class_Event
                Ev.Type = Class_CNC.enum_Event_Types.USB_Handshake
                Ev.Message = Message_Event.Message
                Ev.Routine = "Decode_Message"
                Event_List.Add(Ev)

        End Select

        If Message_Event.Flags.Block_Number_Changed Or Message_Event.Flags.State_Changed Then
            Dim Ev As Class_CNC.class_Event
            Ev = New Class_CNC.class_Event
            Ev.Type = Class_CNC.enum_Event_Types.GCode_Update
            Ev.Parameter = Trim(Str(Block_Number))
            Ev.Routine = "Decode_Message"

            If Program_Line_Number_Shadow <> Block_Number Then
                If Block_Number = 0 Then
                    Program_Line_Number_Shadow = 0
                Else
                    Program_Line_Number_Shadow = Block_Number
                    Ev.Parameter = Trim(Str(Block_Number))
                    Ev.Flags.Program_Line_Number_Changed = True
                End If
            End If

            If Message_Event.Flags.State_Changed Then
                Ev.Parameter = Trim(Str(Program_Line_Number_Shadow))
                Ev.Flags.State_Changed = True
                Ev.Program_Status = Message_Event.Parameter
            End If

            Event_List.Add(Ev)
        End If

        Return Event_List

    End Function

    Public Sub Queue_Outgoing_Message(Message As String, Priority As Boolean, Optional Routine As String = "")
        If Message = "" Or IsNothing(Message) Then
            Flash_Message("Blank Message")
            Exit Sub
        End If
        Dim Mess As New class_message
        Mess.Text = Message
        Mess.Routine = Routine

        Dim lockThis As New Object

        'SyncLock keeps other threads from interrupting
        SyncLock lockThis ' Main_Form.Controller_Outgoing_Message_Queue
            If Priority Then
                Main_Form.Priority_Message_Queue.Enqueue(Mess)
            Else
                Main_Form.Controller_Outgoing_Message_Queue.Enqueue(Mess)
            End If
        End SyncLock

    End Sub

    Public Function Queue_GCode(Code As String) As String
        Code = "{""gc"":" & """" & Code & """" & "}"
        Queue_Outgoing_Message(Code, False, "Controller.Queue_GCode")
        Return Code
    End Function

    Public Function Queue_System_GCode(Block As String, Optional Priority As Boolean = False, Optional Probe_Check As Boolean = True) As String

        If Mid(Block, 1, 1) = "N" Then
            Show_Error("System GCode has block number")
        End If

        'When probe is loaded only allow probe moves, 
        'this makes the machine stop if the probe hits something. For saftey
        If Probe_Check Then
            If Symbol.Get_Value("Sys.Soft_Limits_Enabled") Then
                If Symbol.Get_Value("Probe.In_Spindle") Then
                    Dim Codes As List(Of Integer)
                    Codes = CNC.Get_Integer_Codes(Block, "G")
                    If Not IsNothing(Codes) Then
                        For I = 0 To Codes.Count - 1
                            Select Case Codes(I)
                                Case 0
                                    Block = Block.Replace("G00", "G38.2 ")
                                Case 1
                                    Block = Block.Replace("G01", "G38.2 ")
                            End Select
                        Next
                    End If
                End If
            End If
        End If

        Block = "{""gc"":" & """" & Block & """" & "}"

        Queue_Outgoing_Message(Block, Priority, "Controller.Queue_Queue_System_GCode")

        Return Block

    End Function

    Public Function Message_Buffer_Full() As Boolean
        If Buffers_Available < Min_Buffer_Slots Then Return True Else Return False
    End Function

#End Region

#Region "Control functions"

    Public Sub Send_Initialization_Done()
        Queue_System_GCode("M1000 (Initialization Done)")
    End Sub

    Public Sub Send_Settings_Download_Done()
        Queue_System_GCode("M1001 (Settings Download Done)")
    End Sub

    Public Sub Send_Settings_Verify_Done()
        Queue_System_GCode("M1002 (Settings verify Done)")
    End Sub

    Public Sub Reset_Units()
        Queue_System_GCode("G20")
    End Sub

    Public Sub Clear_Alarm()
        Queue_Outgoing_Message("{clear:n}", True, "Controller.Clear_Alarm")
    End Sub

    Public Sub Get_Offsets()
        CNC.Queue_Message("{G54:n}", False)
        CNC.Queue_Message("{G55:n}", False)
    End Sub

    Public Sub Enable_Offsets(Enable As Boolean)
        If Enable Then

            Controller.Queue_System_GCode("G55")
        Else
            Controller.Queue_System_GCode("G54")
        End If
        Controller.Request_Status_Report()
    End Sub

    Public Sub Set_Offsets(Coord_System As String, Offset_X As Single, Offset_Y As Single, Offset_Z As Single)
        CNC.Queue_Message("{" & Coord_System & ":{X:" & Offset_X & ",Y:" & Offset_Y & ",Z:" & Offset_Z & "}}", False, "")
    End Sub

    Public Sub Set_Offset_X(Coord_System As String, Offset As Single)
        CNC.Queue_Message("{" & Coord_System & "X:" & Offset & "}", False)
    End Sub

    Public Sub Set_Offset_Y(Coord_System As String, Offset As Single)
        CNC.Queue_Message("{" & Coord_System & "Y:" & Offset & "}", False)
    End Sub

    Public Sub Set_Offset_Z(Coord_System As String, Offset As Single)
        CNC.Queue_Message("{" & Coord_System & "Z:" & Offset & "}", False)
    End Sub

    'This is the GCode equivilant of the above
    Public Sub Set_Offset(Index As Integer, X As Single, Y As Single, Z As Single)
        Queue_System_GCode("G10 L2 P" & Str(Trim(Index)) & " X" & X & " Y" & Y & " Z" & Z)
    End Sub

#End Region

#Region "Action Functions"

    Public Function Check_For_In_Cycle(Message As String) As Boolean
        If Not Symbol.Get_Value("Sys.In_Cycle_Stop") Then
            Flash_Message(Message)
            Return True
        End If
        Return False
    End Function


    Public Sub Reset_Controller()
        If Not Main_Form.Serial.Connected Then Exit Sub

        'X_Persist = Symbol.Get_Value("Sys.Abs_X")
        'Y_Persist = Symbol.Get_Value("Sys.Abs_Y")
        'Z_Persist = Symbol.Get_Value("Sys.Abs_Z")

        Reset_Dialog = New dlg_Modal_Message
        Reset_Dialog.Show("Resetting Controller")
        Main_Form.ts_Main_State.BackColor = Color.MistyRose
        Main_Form.ts_Main_State.Text = "Resetting"
        Main_Form.Serial.Send_Reset()

        Dim Evnt As New Class_CNC.class_Event
        Evnt.Type = Class_CNC.enum_Event_Types.Controller_Reset_Sent
        Evnt.Message = "^"

        Main_Form.stat_Fault.Text = ""
        Main_Form.stat_Fault.BackColor = Color.White

        SyncLock Main_Form.Event_Trace_List
            Main_Form.Add_Trace_Event(Evnt)
        End SyncLock

    End Sub

    Public Sub Controller_Reset()
        Main_Form.ts_Main_State.BackColor = Color.White
        Main_Form.ts_Main_State.Text = "Controller Reset"
        Main_Form.stat_Fault.Text = ""
        Main_Form.stat_Fault.BackColor = Color.White
        If Not IsNothing(Reset_Dialog) Then
            Reset_Dialog.Close()
        End If
    End Sub

    Public Sub Enable_Axis(Axis As Class_CNC.enum_Axis, Enable As Boolean)
        Dim Mess As String = ""
        If Enable Then
            Mess = "{me:}"
        Else
            Mess = "{md:}"
        End If

        Select Case Axis
            Case Class_CNC.enum_Axis.All
                Mess &= "n}"
            Case Class_CNC.enum_Axis.X
                Mess &= "1}"
            Case Class_CNC.enum_Axis.Y
                Mess &= "2}"
            Case Class_CNC.enum_Axis.Z
                Mess &= "3}"
            Case Class_CNC.enum_Axis.None
                Exit Sub
        End Select

        CNC.Queue_Message(Mess, False)

    End Sub

    Public Sub Flush_Queue()
        Queue_Outgoing_Message("%", True, "Controller.Flush_Queue")
        Waiting_For_Response = False
        Buffers_Available = 32

        'A delay is necessary because TinyG must ignore messagages while flushing the queue
        Wait.Delay_Seconds(0.1)

    End Sub

    Public Sub E_Stop()
        Queue_Outgoing_Message("!%", True, "Controller.E_Stop") 'Feed Hold & Cycle stop
        Waiting_For_Response = False

        'A delay is necessary because TinyG must ignore messagages while flushing the queue
        Wait.Delay_Seconds(0.1)
        Symbol.Set_Value("Sys.In_E_Stop", True)
    End Sub

    Public Sub E_Stop_Reset()
        Cycle_Start()
        Symbol.Set_Value("Sys.In_E_Stop", False)
    End Sub

    Public Sub Cycle_Start()
        Queue_Outgoing_Message("~", True, "Controller.Cycle_Start")
        Symbol.Set_Value("Sys.In_Cycle_Stop", False)
    End Sub

    Public Sub Cycle_Stop()
        Queue_Outgoing_Message("!", True, "Controller.Cycle_Stop")
        Wait.Delay_Seconds(0.5)
        Flush_Queue()
        Symbol.Set_Value("Sys.In_Cycle_Stop", True)
        Symbol.Set_Value("Sys.In_Cycle_Stop", True)
    End Sub

    Public Sub Feed_Hold()
        Queue_Outgoing_Message("!", True, "Controller.Feed_Hold")
        Symbol.Set_Value("Sys.In_Feed_Hold", True)
    End Sub

    Public Sub Feed_Resume()
        Queue_Outgoing_Message("~", True, "Controller.Feed_Resume")
        Symbol.Set_Value("Sys.In_Feed_Hold", False)
    End Sub

    'Public Sub Cycle_Start()
    '    Queue_Outgoing_Message("~", False, "Controller.Cycle_Start")
    'End Sub


#End Region

#Region "Download Settings"

    Public Sub Download_Settings(Verify As Boolean)
        Download_Dialog = New dlg_Modal_Message

        If Controller.Check_For_In_Cycle("Cannot download or verify settings while in cycle") Then Exit Sub

        If Verify Then
            Verify_Settings = True
        Else
            Message_Box.ShowDialog("This will change all the TinyG settings." & vbCrLf & "Continue ?", "", MessageBoxButtons.YesNo)
        End If

        If (Message_Box.DialogResult = DialogResult.Yes) Or Verify Then
            Dim S As String

            Main_Form.ts_Main_State.BackColor = Color.Red
            If Verify Then
                Main_Form.ts_Main_State.Text = "Verifing Settings"
                Download_Dialog.Show("Verifing Settings")
            Else
                Main_Form.ts_Main_State.Text = "Downloading Settings"
                Download_Dialog.Show("Downloading Settings")
            End If

            S = Symbol.Get_First_Setting()

            While S <> ""
                If Verify Then
                    CNC.Queue_Message(S, False, "Verify Settings")
                Else
                    CNC.Queue_Message(S, False, "Download Settings")
                End If
                S = Symbol.Get_Next_Setting
            End While

            If Verify Then
                Controller.Send_Settings_Verify_Done()
            Else
                Controller.Send_Settings_Download_Done()
            End If

        End If


    End Sub

    Public Sub Settings_Downloaded()
        Main_Form.ts_Main_State.Text = "Settings Downloaded"
        Main_Form.ts_Main_State.BackColor = Color.White
        Download_Dialog.Close()
        Reset_Controller()
    End Sub

    Public Sub Settings_Verified()
        Main_Form.ts_Main_State.Text = "Settings Verified"
        Main_Form.ts_Main_State.BackColor = Color.White
        Download_Dialog.Close()
    End Sub

    Public Sub Verify_Setting(Name As String, Value As String)
        Dim Fault As Boolean = False
        Dim Setting_Value As String

        If Name = "gc" And Value = "M1002" Then
            Verify_Settings = False
            Message_Box.ShowDialog("Settings Verified")
            Exit Sub
        End If

        Setting_Value = Symbol.Get_Setting_Value(Name)

        If Setting_Value = "" Then
            Show_Error("Setting not found :  " & Name)
        Else
            If IsNumeric(Setting_Value) Then
                If IsNumeric(Value) Then
                    If CSng(Value) <> CSng(Setting_Value) Then
                        Fault = True
                    End If
                Else
                    Fault = True
                End If
            Else
                If Value <> Setting_Value Then
                    Fault = True
                End If
            End If

            If Fault Then
                Show_Error("Setting verification failed. " & vbCrLf & _
                           "Setting : " & Name & vbCrLf & _
                           "Setting Sent : " & Setting_Value & vbCrLf & _
                           "Setting Read : " & Value)
            End If

        End If

    End Sub


#End Region

    Public Sub Recall_Default_Report_Format()
        CNC.Queue_Message("{sr:t}", False, "Recall_Default_Report_Format")
    End Sub

    Public Sub Request_Status_Report()
        CNC.Abs_X_Shadow = -10000
        CNC.Abs_Y_Shadow = -10000
        CNC.Abs_Z_Shadow = -10000
        CNC.Queue_Message("{sr:n}", False, "Send_Request_Status_Message")
    End Sub

    Public Sub Request_Queue_Report()
        CNC.Queue_Message("{qr:n}", False, "Send_Request_Status_Message")
    End Sub

End Class
