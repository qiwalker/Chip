Imports System.IO
Imports System.Collections
Imports System.ComponentModel

Public Class Main_Form

    Public Dont_Change_Controls_Properties As Boolean = True
    Public Chip_Version As String = "Chip version : 09/8/2016 "

    Public Enum enum_Connection_Status
        Power_Up = 10
        Connect = 20
        Send_Init_Messages = 30
        Finding_TinyG = 40
        Waiting_For_Connection = 50
        Initialize_Tiny_G = 60
        Waiting_For_TinyG_Initialize = 70
        Initialize_Controller = 80
        Waiting_For_TinyG_Power_Up = 1
        Waiting_For_Lost_Connection = 2
    End Enum

#Region "Declarations"

    Public Trace_Refresh_Count As Integer = 0
    Public Trace_Refresh_Enable As Boolean = False
    Public Trace_Refresh_Pause As Boolean = False
    Public Trace_Max_Events As Integer = 1000

    Public Structure struct_Trace
        Public Routine As String
        Public Evnt As Object
    End Structure

    Public Event_Trace_List As New List(Of Class_CNC.class_Event)
    Public Status_Report_Event_Shadow As New Class_CNC.class_Event
    Public GCode_Complete_Event_Shadow As New Class_CNC.class_Event

    Public WithEvents Serial As New Class_Serial_Port

    Public dlg_Send_Command As New dlg_Commands

    Private Test_Count As Integer = 0
    Private Ignore_Key_Down As Boolean = False
    Private Message As String

    Public Priority_Message_Queue As New Queue
    Public Controller_Outgoing_Message_Queue As New Queue
    Private Controller_Buffers As Integer = 20
    Public Waiting_Gcode_Ack As Boolean = False

    Private Controller_Event_Queue As New Queue

    Public Process_Outgoing_Messages As New BackgroundWorker
    Public Process_Incoming_Messages As New BackgroundWorker

    Public Trace_Buffer As String = ""

    Private WithEvents TinyG_Detection_Timer As New Timer
    Private TinyG_Connection_State As enum_Connection_Status = enum_Connection_Status.Power_Up
    Private TinyG_Power_Up_Seconds As Integer = 0
    Private TinyG_Connected As Boolean = False
    Private TinyG_Connected_Shadow As Boolean = False

    Public Progress_Dialog As New dlg_Progress

    Private Ignore_Set_Offset As Boolean = False

    Public Initialized As Boolean = False

    Private Macro_Editor_Dialog As New dlg_Macro_Editor

#End Region

#Region "Shown, Closing"

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'Initialize_Paths()
        'Symbol.Initialize()
        'Settings.Load(Chip_Settings_File)
        'Settings.Set_Form_Size_and_Location(Me)

        'Symbol.Load_Symbol_Table(Chip_Symbols_File)
        'Chip_Icons_Folder = "C:\Chip\Icons\"
        'Dim dlg As New dlg_Macro_Editor
        'dlg.ShowDialog()
        'Settings.Save(Chip_Settings_File)
        'End


        'Translate_file()
        'End
        Me.Text = Chip_Version
        Connected_To_Network()

        Me.Cursor = Cursors.WaitCursor

        Initialize_Paths()

        Settings.Load(Chip_Settings_File)
        Settings.Set_Form_Size_and_Location(Me)

        chk_Trace_Filter_Events.Checked = Settings.Get_Control_Setting(chk_Trace_Filter_Events, "Checked", False, "Boolean")
        chk_Trace_Sent.Checked = Settings.Get_Control_Setting(chk_Trace_Sent, "Checked", True, "Boolean")
        chk_Trace_Received.Checked = Settings.Get_Control_Setting(chk_Trace_Received, "Checked", True, "Boolean")
        chk_Trace_Queue.Checked = Settings.Get_Control_Setting(chk_Trace_Queue, "Checked", False, "Boolean")
        chk_Trace_Status.Checked = Settings.Get_Control_Setting(chk_Trace_Status, "Checked", False, "Boolean")
        chk_Trace_System_Events.Checked = Settings.Get_Control_Setting(chk_Trace_System_Events, "Checked", False, "Boolean")
        chk_Trace_Macro_Events.Checked = Settings.Get_Control_Setting(chk_Trace_Macro_Events, "Checked", False, "Boolean")
        chk_Trace_Routine_Names.Checked = Settings.Get_Control_Setting(chk_Trace_Routine_Names, "Checked", False, "Boolean")
        chk_Trace_Column_1.Checked = Settings.Get_Control_Setting(chk_Trace_Column_1, "Checked", False, "Boolean")
        chk_Trace_Column_2.Checked = Settings.Get_Control_Setting(chk_Trace_Column_2, "Checked", False, "Boolean")
        chk_Trace_Column_3.Checked = Settings.Get_Control_Setting(chk_Trace_Column_3, "Checked", False, "Boolean")

        'Setup background threads for handling messages to/from TinyG
        Process_Outgoing_Messages.WorkerReportsProgress = True
        Process_Outgoing_Messages.WorkerSupportsCancellation = True
        AddHandler Process_Outgoing_Messages.DoWork, AddressOf Process_Outgoing_Messages_DoWork
        AddHandler Process_Outgoing_Messages.ProgressChanged, AddressOf Process_Outgoing_Messages_ProgressChanged
        AddHandler Process_Outgoing_Messages.RunWorkerCompleted, AddressOf Process_Outgoing_Messages_RunWorkerCompleted

        Process_Incoming_Messages.WorkerReportsProgress = True
        Process_Incoming_Messages.WorkerSupportsCancellation = True
        AddHandler Process_Incoming_Messages.DoWork, AddressOf Process_Incoming_Messages_DoWork
        AddHandler Process_Incoming_Messages.ProgressChanged, AddressOf Process_Incoming_Messages_ProgressChanged
        AddHandler Process_Incoming_Messages.RunWorkerCompleted, AddressOf Process_Incoming_Messages_RunWorkerCompleted

        btn_Connected.Focus()
        Me.Cursor = Cursors.Arrow

        'More initialization done if TinyG is detected 
        'See Detection_Timer_Tick routine
        TinyG_Detection_Timer.Interval = 10
        TinyG_Detection_Timer.Enabled = True

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Process_Outgoing_Messages.CancelAsync()
        Process_Incoming_Messages.CancelAsync()
        Process_Box.Close()

        Controller.Cycle_Stop()

        Symbol.Save_Symbol_Table(Chip_Symbols_File)

        Settings.Save_Form_Size_and_Location(Me)

        Settings.Put_Control_Setting(chk_Trace_Filter_Events, "Checked", chk_Trace_Filter_Events.Checked)
        Settings.Put_Control_Setting(chk_Trace_Sent, "Checked", chk_Trace_Sent.Checked)
        Settings.Put_Control_Setting(chk_Trace_Received, "Checked", chk_Trace_Received.Checked)
        Settings.Put_Control_Setting(chk_Trace_Queue, "Checked", chk_Trace_Queue.Checked)
        Settings.Put_Control_Setting(chk_Trace_Status, "Checked", chk_Trace_Status.Checked)
        Settings.Put_Control_Setting(chk_Trace_System_Events, "Checked", chk_Trace_System_Events.Checked)
        Settings.Put_Control_Setting(chk_Trace_Macro_Events, "Checked", chk_Trace_Macro_Events.Checked)
        Settings.Put_Control_Setting(chk_Trace_Routine_Names, "Checked", chk_Trace_Routine_Names.Checked)
        Settings.Put_Control_Setting(chk_Trace_Column_1, "Checked", chk_Trace_Column_1.Checked)
        Settings.Put_Control_Setting(chk_Trace_Column_2, "Checked", chk_Trace_Column_2.Checked)
        Settings.Put_Control_Setting(chk_Trace_Column_3, "Checked", chk_Trace_Column_3.Checked)
        Settings.Save(Chip_Settings_File)

        My.Settings.Save()

    End Sub

#End Region

#Region "Connection Routines"

    Private Sub TinyG_Detection_Timer_Tick() Handles TinyG_Detection_Timer.Tick
        TinyG_Detection_Timer.Enabled = False

        Progress_Dialog.Set_Value(TinyG_Connection_State)

        Select Case TinyG_Connection_State

            Case enum_Connection_Status.Power_Up
                Initialize_Trace()

                txt_Com_Port.Text = ""
                btn_Connected.BackColor = Color.Red
                btn_Connected.Text = "Disconnected"

                Progress_Dialog.Set_Value(5)
                Progress_Dialog.Show("Initializing")

                Symbol.Initialize()
                Symbol.Load_Symbol_Table(Chip_Symbols_File)

                txt_Com_Port.Text = ""

                TinyG_Detection_Timer.Interval = 10
                TinyG_Connection_State = enum_Connection_Status.Connect
                Progress_Dialog.Prompt("Opening COM Port")

            Case enum_Connection_Status.Connect

                If Connect_To_TinyG() Then 'Connected
                    TinyG_Detection_Timer.Interval = 10
                    TinyG_Connection_State = enum_Connection_Status.Send_Init_Messages
                    Progress_Dialog.Prompt("COM : " & Serial.Current_Com_Port & " -- Finding TinyG")
                Else 'Connection failed
                    Initialized = True
                    TinyG_Detection_Timer.Interval = 10
                    TinyG_Connection_State = enum_Connection_Status.Waiting_For_Connection
                    Progress_Dialog.Hide()
                End If

            Case enum_Connection_Status.Send_Init_Messages

                If Not Process_Outgoing_Messages.IsBusy = True Then
                    Application.DoEvents()
                    Process_Outgoing_Messages.RunWorkerAsync()
                End If

                If Not Process_Incoming_Messages.IsBusy = True Then
                    Application.DoEvents()
                    Process_Incoming_Messages.RunWorkerAsync()
                End If

                Controller.Queue_Outgoing_Message("{fv:n}", True)
                Controller.Queue_Outgoing_Message("{fb:n}", True)
                Controller.Queue_Outgoing_Message("{hv:n}", True)
                Controller.Queue_Outgoing_Message("{id:n}", True)

                TinyG_Detection_Timer.Interval = 500
                TinyG_Connection_State = enum_Connection_Status.Finding_TinyG

            Case enum_Connection_Status.Finding_TinyG

                If Firmware_Build = "" Then 'Not Found
                    Progress_Dialog.Hide()

                    Dim dlg As New dlg_Com_Ports
                    dlg.Prompt = "TinyG could not be detected on : " & Serial.Current_Com_Port & vbCrLf & _
                                 "Click OK to select another COM port," & vbCrLf & _
                                  "or Cancel to continue unconnected."
                    dlg.ShowDialog()

                    Initialized = True

                    Process_Outgoing_Messages.CancelAsync()
                    Process_Incoming_Messages.CancelAsync()
                    Serial.Disconnect()

                    Process_Box.Initialize(Symbol.Get_Symbol("Process_Box"))

                    If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                        My.Settings.Com_Port = dlg.Com_Port
                        TinyG_Detection_Timer.Interval = 10
                        TinyG_Connection_State = enum_Connection_Status.Power_Up
                    Else
                        TinyG_Detection_Timer.Interval = 1000
                        TinyG_Connection_State = enum_Connection_Status.Waiting_For_Connection
                    End If

                    txt_Com_Port.Text = ""
                    btn_Connected.BackColor = Color.Red
                    btn_Connected.Text = "Disconnected"

                Else 'Found

                    My.Settings.Com_Port = Serial.Current_Com_Port
                    My.Settings.Save()

                    If Not Process_Outgoing_Messages.IsBusy = True Then
                        Application.DoEvents()
                        Process_Outgoing_Messages.RunWorkerAsync()
                    End If

                    If Not Process_Incoming_Messages.IsBusy = True Then
                        Application.DoEvents()
                        Process_Incoming_Messages.RunWorkerAsync()
                    End If

                    txt_Com_Port.Text = My.Settings.Com_Port
                    btn_Connected.BackColor = Color.YellowGreen
                    btn_Connected.Text = "Connected"

                    TinyG_Detection_Timer.Interval = 10
                    TinyG_Connection_State = enum_Connection_Status.Initialize_Tiny_G
                End If

                Progress_Dialog.Prompt("Initializing TinyG")

            Case enum_Connection_Status.Initialize_Tiny_G
                Me.Text = Chip_Version & "  TinyG - Build : " & Firmware_Build & ", Version : " & FirmwareVersion & _
                          ", Version : " & Hardware_Version & ", ID : " & TinyG_ID

                'RWC will not need when new version of software is released
                Wait.Delay_Seconds(0.5)
                Controller.Queue_Outgoing_Message("{sr:{line:t,posx:t,posy:t,posz:t,mpox:t,mpoy:t,mpoz:t,vel:t,stat:t,coor:t,unit:t}", False)
                Wait.Delay_Seconds(0.5)
                TinyG_Detection_Timer.Interval = 1000
                TinyG_Connection_State = enum_Connection_Status.Waiting_For_TinyG_Initialize
                Progress_Dialog.Prompt("Waiting For TinyG to Initialize")

            Case enum_Connection_Status.Waiting_For_TinyG_Initialize
                TinyG_Detection_Timer.Interval = 10
                TinyG_Connection_State = enum_Connection_Status.Initialize_Controller
                Progress_Dialog.Prompt("Waiting Controller to initialize")

            Case enum_Connection_Status.Initialize_Controller
                TinyG_Connected = True
                TinyG_Connected_Shadow = True

                Controller.Initialize()
                CNC.Initialize()
                Logitech_G13.Init()
                Macros.Initialize()

                Progress_Dialog.Hide()

                Process_Box.Initialize(Symbol.Get_Symbol("Process_Box"))

                CNC.Send_Persistant_Positions_To_TinyG()

                btn_Connected.BackColor = Color.YellowGreen
                btn_Connected.Text = "Connected"
                btn_Connected.Refresh()

                Flash_Message("Controller Initialized")
                Initialized = True

                Startup()

                TinyG_Connection_State = enum_Connection_Status.Waiting_For_Lost_Connection

            Case enum_Connection_Status.Waiting_For_Connection
                Serial.Get_Com_Ports()
                If Serial.Ports.Contains(My.Settings.Com_Port) Then
                    TinyG_Power_Up_Seconds = 0

                    TinyG_Detection_Timer.Interval = 1000
                    TinyG_Connection_State = enum_Connection_Status.Waiting_For_TinyG_Power_Up
                    Progress_Dialog.Set_Value(10)
                    Progress_Dialog.Show("Waiting for TinyG to power up.")
                End If

            Case enum_Connection_Status.Waiting_For_TinyG_Power_Up
                TinyG_Power_Up_Seconds += 1
                Progress_Dialog.Set_Value((TinyG_Power_Up_Seconds * 10) + 10)
                Progress_Dialog.Prompt("Waiting for TinyG to power up : " & 5 - TinyG_Power_Up_Seconds)

                If TinyG_Power_Up_Seconds > 4 Then
                    TinyG_Connection_State = enum_Connection_Status.Power_Up
                End If

            Case enum_Connection_Status.Waiting_For_Lost_Connection
                'Waits here until Process_Incoming_Messages_ProgressChanged detectes a lost connection
                If TinyG_Connected_Shadow And (Not TinyG_Connected) Then 'Just lost connection
                    btn_Connected.BackColor = Color.Red
                    btn_Connected.Text = "Disconnected"
                    Symbol.Save_Symbol_Table(Chip_Symbols_File)
                    CNC.Send_Persistant_Positions_To_TinyG()
                    TinyG_Connection_State = enum_Connection_Status.Waiting_For_Connection
                End If
                TinyG_Connected_Shadow = TinyG_Connected

        End Select

        TinyG_Detection_Timer.Enabled = True

    End Sub

    Public Function Connect_To_TinyG(Optional Show_Messages As Boolean = True) As Boolean
        Dim Com_Port_Name As String = ""

        Serial.Get_Com_Ports()
        If Serial.Ports.Count < 1 Then
            If Show_Messages Then
                Dim dlg As New dlg_Message_Box
                dlg.ShowDialog("No COM ports available." & vbCrLf & "Click OK to continue unconnected.")
                'For some reason, probably a Microsoft but, the treeview on the form does not expand properly
                'unless the form has been opened and hidden, then when it is shown it works properly
                Macro_Editor.Show()
                Macro_Editor.Hide()
                Me.Cursor = Cursors.Arrow
            End If
        Else
            Com_Port_Name = My.Settings.Com_Port
            If Com_Port_Name = "" Then 'Probably first time run on new machine
                If Show_Messages Then
                    Dim dlg As New dlg_Com_Ports
                    dlg.Prompt = "TinyG Com port not configured." & vbCrLf & _
                                 "Select Com port, or Cancel to continue unconnected."
                    dlg.ShowDialog()
                    If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                        Com_Port_Name = dlg.Com_Port
                        Serial.Connect(Com_Port_Name)
                        If Serial.Current_Com_Port <> "" Then Return True
                    End If
                End If
            Else
                Serial.Connect(My.Settings.Com_Port)
                If Serial.Current_Com_Port <> "" Then Return True
            End If
        End If

        Return False
    End Function


#End Region

#Region "Tool Strips"

    Private Sub ts_Main_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ts_Main.ItemClicked
        If Not (Initialized) Then Exit Sub

        Select Case e.ClickedItem.Text
            Case "Exit"
                Close()

            Case "Download Settings"
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Download_Settings, "Main_Form")

            Case "Verify Settings"
                CNC.Cause_Event(Class_CNC.enum_Event_Types.Verify_Settings, "Main_Form")

            Case "Macros"
                If Controller.Check_For_In_Cycle("Cannot start wizards while in cycle") Then Exit Sub
                Macro_Editor.Show()

            Case "Reset"
                Macros.Reset_Controller()

            Case "Camera"
                Me.Hide()
                Camera.Show()
                Camera_Controls.Show()

            Case "Help"
                Dim Mess As String = "TinyG Version Information'" & vbCrLf
                If FirmwareVersion = "" Then
                    Mess = "Reset TinyG to get version information"
                Else
                    Mess &= "Firmware Version : " & FirmwareVersion & vbCrLf
                    Mess &= "Firmware Build : " & Firmware_Build & vbCrLf
                    Mess &= "Hardware Version : " & Hardware_Version & vbCrLf
                    Mess &= "ID : " & TinyG_ID
                End If
                Message_Box.ShowDialog(Mess)

        End Select

    End Sub

    Private Sub tab_Main_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Tab_Main.SelectedIndexChanged
        If Tab_Main.SelectedTab.Text = "Trace" Then
            Show_Trace_Information()
        End If
        btn_Connected.Focus()
    End Sub


#End Region

#Region "Buttons"


    Private Sub Ignore_Input_Keys(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs)
        e.IsInputKey = True
    End Sub


#End Region

#Region "Keyboard"


    Private Sub Main_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Menu Then Exit Sub 'Keys.Menu is Alt key code
        If e.KeyCode = Keys.ControlKey Then Exit Sub 'Keys.ControlKey us Ctrl key code

        If e.Alt Or e.Control Then
            If Ignore_Key_Down Then
                Exit Sub
            End If
            Ignore_Key_Down = True

            If Form_Controls.Hot_Key_Handler(e, True) Then
                e.SuppressKeyPress = True
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Me_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Ignore_Key_Down = False

        If Form_Controls.Hot_Key_Handler(e, False) Then
            e.SuppressKeyPress = True
            e.Handled = True
        End If

    End Sub

#End Region

#Region "Process_Outgoing_Messages"

    Public Function OK_To_Send() As Boolean
        If Controller_Outgoing_Message_Queue.Count > 10 Then Return False
        Return True
    End Function

    Public Sub Process_Outgoing_Messages_DoWork(sender As Object, e As DoWorkEventArgs)
        'Do not reference main form controls in this routine
        'Use Process_Outgoing_Messages_ProgressChanged
        Dim Controller_Outgoing_Message As Class_Tiny_G.class_message = Nothing
        Dim Controller_Message_Sent As Boolean
        Dim Priority_Message_Sent As Boolean
        Dim G_Code_Block As String = ""
        Dim CNC_Event As Class_CNC.class_Event

        While True

            If Process_Outgoing_Messages.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            Controller_Message_Sent = False
            Priority_Message_Sent = False

            If Priority_Message_Queue.Count > 0 Then
                Controller_Outgoing_Message = New Class_Tiny_G.class_message

                SyncLock Priority_Message_Queue
                    Controller_Outgoing_Message = Priority_Message_Queue.Dequeue
                    If Controller_Outgoing_Message.Text.Contains("%") Then Controller_Outgoing_Message_Queue.Clear()
                End SyncLock

                If Serial.Send_Message(Controller_Outgoing_Message.Text) Then
                    Priority_Message_Sent = True
                    Controller_Message_Sent = True
                Else
                    Process_Outgoing_Messages.ReportProgress(0)
                End If

            End If

            If (Not Controller.Waiting_For_Response) And (Not Priority_Message_Sent) Then

                If Not Controller.Message_Buffer_Full Then

                    If Controller_Outgoing_Message_Queue.Count > 0 Then
                        Controller_Outgoing_Message = New Class_Tiny_G.class_message
                        SyncLock Priority_Message_Queue
                            Controller_Outgoing_Message = Controller_Outgoing_Message_Queue.Dequeue
                        End SyncLock

                        If Serial.Send_Message(Controller_Outgoing_Message.Text) Then
                            Controller.Waiting_For_Response = True
                            Controller_Message_Sent = True
                        Else
                            Process_Outgoing_Messages.ReportProgress(0)
                        End If

                    End If

                End If

            End If

            If Controller_Message_Sent Then
                CNC_Event = New Class_CNC.class_Event
                If Priority_Message_Sent Then
                    CNC_Event.Type = Class_CNC.enum_Event_Types.Priority_Message
                Else
                    CNC_Event.Type = Class_CNC.enum_Event_Types.Message_Out
                End If
                CNC_Event.Routine = Controller_Outgoing_Message.Routine
                CNC_Event.Message = Controller_Outgoing_Message.Text

                SyncLock Event_Trace_List
                    Add_Trace_Event(CNC_Event)
                End SyncLock

                Process_Outgoing_Messages.ReportProgress(1)
            End If

            Threading.Thread.Sleep(10)

        End While


    End Sub

    Public Sub Process_Outgoing_Messages_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        'Put main form updates to controls here

        Select Case e.ProgressPercentage
            Case 0

            Case 1

            Case 2
                Waiting_Gcode_Ack = True
        End Select

    End Sub

    Public Sub Process_Outgoing_Messages_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        'If e.Cancelled Then
        '    txt_Message.Text &= "You cancled" & vbCrLf
        'ElseIf e.Error IsNot Nothing Then
        '    txt_Message.Text &= "Worker exception : " & e.Error.ToString & vbCrLf
        'Else
        '    txt_Message.Text &= "Complete : " & e.Result & vbCrLf
        'End If
    End Sub

#End Region

#Region "Process_Incoming_Messages"

    Public Sub Enqueue_Controller_Event(Evnt As Class_CNC.class_Event)
        SyncLock Controller_Event_Queue
            Controller_Event_Queue.Enqueue(Evnt)
        End SyncLock
    End Sub

    Private Function Dequeue_Controller_Event() As Class_CNC.class_Event
        SyncLock Controller_Event_Queue
            If Controller_Event_Queue.Count > 0 Then
                Dim Evnt = New Class_CNC.class_Event
                Evnt = Controller_Event_Queue.Dequeue
                Return Evnt
            Else
                Return Nothing
            End If
        End SyncLock
    End Function

    Public Sub Process_Incoming_Messages_DoWork(sender As Object, e As DoWorkEventArgs)
        Dim Incoming_Message As String
        Dim Evnt As Class_CNC.class_Event

        While True

            If Process_Incoming_Messages.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            'Keep other threads from interrupting
            SyncLock Serial
                Incoming_Message = Serial.Receive_Message
            End SyncLock

            Select Case Incoming_Message
                Case "" 'No message
                    Process_Incoming_Messages.ReportProgress(1)
                Case "|" 'Disconnected
                    Process_Incoming_Messages.ReportProgress(0)
                Case Else
                    Evnt = New Class_CNC.class_Event
                    Evnt.Type = Class_CNC.enum_Event_Types.Message_In
                    Evnt.Message = Incoming_Message
                    Enqueue_Controller_Event(Evnt)
                    Try 'Ignore
                        Process_Incoming_Messages.ReportProgress(1)
                    Catch ex As Exception
                    End Try
            End Select

            Threading.Thread.Sleep(10)

        End While

    End Sub

    Public Sub Process_Incoming_Messages_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        'Put main form updates to controls here
        Dim CNC_Event As Class_CNC.class_Event = Nothing
        Dim Decode_Events As List(Of Class_CNC.class_Event)
        Dim Evnt As Class_CNC.class_Event
        Dim Done As Boolean
        Dim Available_Slots As Integer = 0

        If Not Serial.Connected Then
            Priority_Message_Queue.Clear()
            Controller_Outgoing_Message_Queue.Clear()
            Waiting_Gcode_Ack = False
            TinyG_Connected = False
            Exit Sub
        End If

        Done = False
        While Not Done

            If Not Controller.Message_Buffer_Full Then
                Process_Box.Send_Blocks()
            End If

            CNC_Event = Dequeue_Controller_Event()

            If Not IsNothing(CNC_Event) Then

                If CNC_Event.Type = Class_CNC.enum_Event_Types.Message_In Then
                    Decode_Events = New List(Of Class_CNC.class_Event)
                    Decode_Events = Controller.Decode_Message(CNC_Event.Message)

                    If Not IsNothing(Decode_Events) Then
                        For I = 0 To Decode_Events.Count - 1
                            Evnt = Decode_Events(I)
                            If Evnt.Type = Class_CNC.enum_Event_Types.Queue_Report Then
                                Available_Slots = Evnt.Parameter
                            End If
                            Add_Trace_Event(Evnt)
                            Enqueue_Controller_Event(Evnt)
                        Next
                    End If

                End If

                If Trace_Refresh_Enable = False Then Trace_Refresh_Enable = True
                Trace_Refresh_Count = 0

            Else 'No event in queue
                If Trace_Refresh_Enable And Not (Trace_Refresh_Pause) Then
                    If Trace_Refresh_Count > 10 Then
                        Trace_Refresh_Pause = True
                        If Tab_Main.SelectedTab.Text = "Trace" Then
                            Show_Trace_Information()
                        End If
                        Trace_Refresh_Pause = False
                        Trace_Refresh_Count = 0
                        Trace_Refresh_Enable = False
                    Else
                        Trace_Refresh_Count += 1
                    End If
                End If

                Done = True
                Exit While

            End If

            If CNC_Event.Type = Class_CNC.enum_Event_Types.Status_Report Then
                Status_Report_Event_Shadow = New Class_CNC.class_Event
                Status_Report_Event_Shadow = CNC_Event
            End If

            If CNC_Event.Type = Class_CNC.enum_Event_Types.GCode_Update Then
                GCode_Complete_Event_Shadow = New Class_CNC.class_Event
                GCode_Complete_Event_Shadow = CNC_Event
            End If

            If CNC_Event.Type <> Class_CNC.enum_Event_Types.Message_In Then
                If TinyG_Connected Then Macros.Event_Handler(CNC_Event)
            End If

            Select Case CNC_Event.Type
                Case Class_CNC.enum_Event_Types.Message_Reply
                    Controller.Waiting_For_Response = False
            End Select

            If CNC.GCode_Ack Then Waiting_Gcode_Ack = False

        End While

    End Sub

    Public Sub Process_Incoming_Messages_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

        'If e.Cancelled Then
        '    txt_Message.Text &= "You cancled" & vbCrLf
        'ElseIf e.Error IsNot Nothing Then
        '    txt_Message.Text &= "Worker exception : " & e.Error.ToString & vbCrLf
        'Else
        '    txt_Message.Text &= "Complete : " & e.Result & vbCrLf
        'End If

    End Sub

#End Region

#Region "Trace"

    Private Sub Initialize_Trace()

    End Sub

    Private Sub Show_Trace_Information()
        Dim Evnt As Class_CNC.class_Event = Nothing
        Dim Mess As String = ""
        Dim Param As String = ""
        Dim Comment As String = ""

        Trace_Buffer = ""

        For I = 0 To Event_Trace_List.Count - 1
            Evnt = Event_Trace_List(I)
            Mess = ""
            Param = ""
            Comment = ""

            Select Case Evnt.Type

                Case Class_CNC.enum_Event_Types.CNC_Initialized
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.Initialize_Done
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.Controller_Reset
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.Controller_Reset_Sent
                    Mess = "--Reset-->"
                    Comment = Evnt.Message

                Case Class_CNC.enum_Event_Types.Text_Message
                    Mess = "**Text**"

                Case Class_CNC.enum_Event_Types.Priority_Message
                    If chk_Trace_Sent.Checked Then
                        Mess = ">>>>>>>>>>"
                        If Evnt.Message.Contains("!") Then
                            Param = "Feed Hold"
                            If Evnt.Message.Contains("%") Then
                                Param &= ", Flush Queue"
                            End If
                        End If

                        If Evnt.Message.Contains("~") Then
                            Param = "Cycle Start"
                        End If

                        Comment = Evnt.Message
                    End If

                Case Class_CNC.enum_Event_Types.Message_Out
                    If chk_Trace_Sent.Checked Then
                        Mess = "--------->"
                        Comment = Evnt.Message
                    End If

                Case Class_CNC.enum_Event_Types.Message_Reply
                    If chk_Trace_Received.Checked Then
                        Mess = "<---------"
                        Comment = Evnt.Message
                    End If

                Case Class_CNC.enum_Event_Types.Queue_Report
                    If chk_Trace_Queue.Checked Then
                        Mess = "<---qr---"
                        Comment = Evnt.Message
                    End If

                Case Class_CNC.enum_Event_Types.USB_Handshake
                    If chk_Trace_Queue.Checked Then
                        Mess = "<--usb---"
                        Comment = Evnt.Message
                    End If

                Case Class_CNC.enum_Event_Types.Macro_Start
                    If chk_Trace_Macro_Events.Checked Then Mess = "*macro*"

                Case Class_CNC.enum_Event_Types.Macro_End
                    If chk_Trace_Macro_Events.Checked Then Mess = "*macro*"

                Case Class_CNC.enum_Event_Types.Button_Down, Class_CNC.enum_Event_Types.Button_Up
                    If chk_Trace_System_Events.Checked Then
                        Mess = "***se***"
                        Comment = Evnt.Ctrl.Name
                    End If

                Case Class_CNC.enum_Event_Types.Status_Report
                    'If chk_Trace_Received.Checked Then
                    If chk_Trace_Status.Checked Then
                        Mess = "<---sr---"
                        Comment = Evnt.Message
                    End If
                    'End If

                Case Class_CNC.enum_Event_Types.Probe_Status_Update
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.Error_Message
                    Mess = "**Error**"
                    Comment = Evnt.Message

                    ''If Not Evnt.Message.Contains("File not open") Then
                    'If chk_Trace_System_Events.Checked Then
                    '    'Event_Trace_List.Clear()
                    '    Message_Box.ShowDialog("Error : " & Evnt.Parameter & "  {" & Evnt.Routine & "}" & vbCrLf & _
                    '                           "Reset Controller?", , MessageBoxButtons.YesNo)
                    '    If Message_Box.DialogResult = Windows.Forms.DialogResult.Yes Then
                    '        Macros.Run_Macro("Reset_Controller")
                    '    End If
                    '    Exit For
                    'Else
                    '    Mess = "***se***"
                    'End If
                    'End If

                Case Class_CNC.enum_Event_Types.Text_Box_Edit
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.GCode_Ack
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.GCode_Update
                    If chk_Trace_System_Events.Checked Then
                        Mess = "***se***"
                        Comment = "N" & Evnt.Parameter
                    End If

                Case Class_CNC.enum_Event_Types.System_GCode_Ack, Class_CNC.enum_Event_Types.System_GCode_Complete
                    If chk_Trace_System_Events.Checked Then Mess = "***sy***"

                Case Class_CNC.enum_Event_Types.Download_Settings, Class_CNC.enum_Event_Types.Settings_Downloaded
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.Program_End
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.Spindle, Class_CNC.enum_Event_Types.Coolant
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.Offsets_Changed
                    If chk_Trace_System_Events.Checked Then Mess = "***se***"

                Case Class_CNC.enum_Event_Types.None, Class_CNC.enum_Event_Types.Message_In, Class_CNC.enum_Event_Types.GCode_Update


                Case Else
                    Dim Msg As String = ("??? " & "Error, Event Type : " & Evnt.Type.GetType.Name & "  {" & Evnt.Routine & "}")
                    If Not IsNothing(Evnt.Parameter) Then
                        Msg = vbCrLf & Evnt.Parameter
                    End If
                    If Not IsNothing(Evnt.Parameter_List) Then
                        For p = 0 To Evnt.Parameter_List.Count - 1
                            Msg = vbCrLf & Evnt.Parameter_List(p).Name & ", " & Evnt.Parameter_List(p).Value
                        Next
                    End If

                    Show_Error(Msg)

                    txt_Trace.Text &= "??? " & Msg

            End Select


            If Not IsNothing(Evnt.Parameter) Then

                Select Case Evnt.Parameter.GetType.Name

                    Case "String"
                        Param = Evnt.Parameter

                    Case "List`1" 'List of string
                        For P = 0 To Evnt.Parameter.Count - 1
                            If P > 0 Then Param = ", " & Param
                            Param &= Evnt.Parameter(P)
                        Next

                    Case "enum_Status_Codes"
                        Dim Stat As Class_CNC.enum_Status_Codes
                        Stat = Evnt.Parameter
                        Param = Stat.ToString

                    Case "enum_Coordinate_System"
                        Param = Evnt.Parameter.ToString

                    Case Else
                        Param = Evnt.Parameter.GetType.Name

                End Select

            End If

            If Mess <> "" Then
                If chk_Trace_Column_1.Checked Then
                    Mess = Mess.PadRight(11)
                Else
                    Mess = ""
                End If

                If chk_Trace_Column_2.Checked Then
                    Mess &= Evnt.Type.ToString.PadRight(18)
                End If

                If chk_Trace_Column_3.Checked Then
                    If Param <> "" Then
                        Param = "[" & Param & "]"
                    End If
                    Mess &= Param.PadRight(25)
                End If

                Comment = Comment.PadRight(40)
                Mess &= Comment

                If chk_Trace_Routine_Names.Checked Then Mess = Mess & "  {" & Evnt.Routine & "}"
                Trace_Buffer &= Mess & vbCrLf

            End If
Skip:
        Next

        If Tab_Main.SelectedTab.Text = "Trace" Then
            txt_Test.SuspendLayout()
            txt_Trace.Text = Trace_Buffer
            txt_Trace.ResumeLayout()
        End If

    End Sub

    Private Sub chk_Filter_Events_CheckedChanged(sender As Object, e As EventArgs) Handles _
      chk_Trace_Sent.CheckedChanged, chk_Trace_Received.CheckedChanged, chk_Trace_Queue.CheckedChanged, chk_Trace_Status.CheckedChanged, _
       chk_Trace_System_Events.CheckedChanged, chk_Trace_Macro_Events.CheckedChanged, chk_Trace_Routine_Names.CheckedChanged, _
       chk_Trace_Column_1.CheckedChanged, chk_Trace_Column_2.CheckedChanged, chk_Trace_Column_3.CheckedChanged

        Show_Trace_Information()
    End Sub

    Private Sub ts_Trace_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ts_Trace.ItemClicked
        If Not Initialized Then Exit Sub

        Select Case e.ClickedItem.Text
            Case "Clear"
                Event_Trace_List.Clear()
            Case "Refresh"
                Controller.Queue_Outgoing_Message("{sr:n}", False)
        End Select

        Show_Trace_Information()

    End Sub

    Public Sub Add_Trace_Event(Evnt As Class_CNC.class_Event)

        If chk_Trace_Filter_Events.Checked Then

            If Evnt.Type = Class_CNC.enum_Event_Types.Status_Report Then
                If Evnt.Flags.State_Changed Then GoTo Skip_Filter
                If Evnt.Flags.Block_Number_Changed Then GoTo Skip_Filter
                If Evnt.Flags.Program_Line_Number_Changed Then GoTo Skip_Filter
                If Evnt.Flags.Coordinate_System_Changed Then GoTo Skip_Filter
                If Evnt.Flags.Offsets_Changed Then GoTo Skip_Filter

                If Evnt.Flags.Position_Changed Then
                    Exit Sub
                End If
            End If

        End If


Skip_Filter:

        SyncLock Event_Trace_List
            Event_Trace_List.Add(Evnt)
            If Event_Trace_List.Count > Trace_Max_Events Then Event_Trace_List.RemoveAt(0)
        End SyncLock

    End Sub

#End Region

#Region "Pendant"


    Private Sub btn_Pendant_Click(sender As Object, e As EventArgs)


    End Sub


    'Private Sub btn_Pendant_GotFocus(sender As Object, e As EventArgs) Handles btn_Pendant.GotFocus
    '    btn_Pendant.BackgroundImage = Symbol.Get_Value("Image.Button.Green_Bar.On", Class_Symbols.enum_Properties.Image)
    'End Sub

    'Private Sub btn_Pendant_LostFocus(sender As Object, e As EventArgs) Handles btn_Pendant.LostFocus
    '    btn_Pendant.BackgroundImage = Symbol.Get_Value("Image.Button.Green_Bar.Off", Class_Symbols.enum_Properties.Image)
    'End Sub

#End Region

    Private Sub chk_Soft_Limits_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Soft_Limits.CheckedChanged
        Symbol.Set_Value("Sys.Soft_Limits_Enabled", chk_Soft_Limits.Checked)
    End Sub

    Private Sub chk_Move_Raise_Z_Checked(sender As Object, e As EventArgs) Handles chk_Move_Raise_Z.CheckedChanged
        Symbol.Set_Value("Sys.Move_Raise_Z", chk_Move_Raise_Z.Checked)
    End Sub

    Private Sub chk_Move_Set_Gap_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Move_Set_Gap.CheckedChanged
        Symbol.Set_Value("Sys.Move_Set_Gap", chk_Move_Raise_Z.Checked)
    End Sub

    Private Function Connected_To_Network() As Boolean
        Dim n As String = My.Computer.Name

        If My.Computer.Name = "RICK-HP" Then
            Return False
        Else
            If Directory.Exists("\\RICK-HP\Ricks CNC") Then
                Flash_Message("Connected to network.", 2)
                'Message_Box.ShowDialog("Connected to network." & vbCrLf & "Continue?", , MessageBoxButtons.YesNo)
                'If DialogResult = Windows.Forms.DialogResult.No Then
                '    End
                'End If
            End If
        End If

        Return False

    End Function

    Private Sub Startup()
        'For some reason, probably a Microsoft but, the treeview on the form does not expand properly
        'unless the form has been opened and hidden, then when it is shown it works properly
        Macro_Editor.Show()
        Macro_Editor.Hide()
        Me.Cursor = Cursors.Arrow

        If My.Computer.Name = "RICK-HP" Then
            btn_Test.Visible = True
            btn_Test_2.Visible = True
            Symbol.Set_Value("Homed.X", True)
            Symbol.Set_Value("Homed.Y", True)
            Symbol.Set_Value("Homed.Z", True)
            Symbol.Set_Value("Homed.XYZ", True)
            Macros.Run_Macro("Update_Form")
        Else
            Dim dlg As New dlg_Startup
            dlg.ShowDialog()
            If dlg.DialogResult <> Windows.Forms.DialogResult.OK Then Exit Sub

            Select Case dlg.Result
                Case dlg_Startup.enum_Results.Current
                    Symbol.Set_Value("Homed.X", True)
                    Symbol.Set_Value("Homed.Y", True)
                    Symbol.Set_Value("Homed.Z", True)
                    Symbol.Set_Value("Homed.XYZ", True)
                    Macros.Run_Macro("Update_Form")
                Case dlg_Startup.enum_Results.Home_All
                    Macros.Cause_Button_Event("Button.Home_XYZ")
                Case dlg_Startup.enum_Results.Home_Z
                    Macros.Cause_Button_Event("Button.Home_Z")
            End Select

            Macros.Status_Changed()
            Controller.Request_Status_Report()
        End If

    End Sub

    Private Sub btn_Test_Click(sender As Object, e As EventArgs) Handles btn_Test.Click
        Dim b As Boolean = Symbol.Get_Value("Button.Fixture_Offset.Z0_Bottom")
        Nop()

        'Controller.Queue_Outgoing_Message("{zjm:n}", False)

        '{zjm
        'Controller.Queue_Outgoing_Message("{xvm:n}", False)
        'Controller.Queue_Outgoing_Message("{xfr:n}", False)

        'G01 X12.730 Y1.260
        'G01 X13.110
        'G03 X13.140 Y1.310 I0.000 J0.030
        'pts = Calc.Interpolate_Arc("G03 X13.140 Y1.310 I0.000 J0.030", X, Y)




        'Dim pts As List(Of Class_Calc.struct_Coordinate)
        'G01 X13.148 Y1.230
        'G01 X13.140
        'G03 X13.170 Y1.340 I-0.030 J0.070
        'pts = Calc.Interpolate_Arc("G03 X13.140 Y1.230 I0.000 J0.030", X, Y)




        'Logitech_G13.Init()
        'Logitech_G13.Set_Text(0, "Rick")
        'Logitech_G13.Set_Text(1, "Caddell")
        'Logitech_G13.Update_Display()

        'Controller.Queue_Outgoing_Message("{sr:{line:t,posx:t,posy:t,posz:t,mpox:t,mpoy:t,mpoz:t,vel:t,stat:t,coor:t,unit:t}", False)

        'Controller.Queue_GCode("G00 X0.000 Y0.000 S12000 M03 M08")

        'Controller.Queue_GCode("N113 G00 X0.000 Y0.000")
        'Controller.Queue_GCode("N113001 G00 X0.05 Y0.05")
        'Controller.Queue_GCode("N20 G00 X0.1 Y.1")
    End Sub

    Private Sub btn_Test_2_Click(sender As Object, e As EventArgs) Handles btn_Test_2.Click

    End Sub

    Private Sub btn_Macro_editor_Click(sender As Object, e As EventArgs)
        Macro_Editor_Dialog.ShowDialog()
    End Sub

    Public Sub Translate_file()
        Dim Lines() As String
        Dim Buff As List(Of String)


        '        Base_Path = Application.StartupPath

        Lines = File.ReadAllLines("C:\Dot_Net_Dev\Chip_Application\CNC_Settings\Chip_Symbols_OLD_VERSION.txt")
        Buff = Lines.ToList

        Dim Type As Class_Symbols.enum_Symbol_Type
        Dim P() As String = Nothing
        Dim Params As New List(Of String)
        Dim Line As String = ""
        Dim Locks As String = ""
        Dim T As String
        Dim But As Button
        Dim Txt As TextBox
        Dim Image_Name As New List(Of String)
        Dim Image_File As New List(Of String)
        Dim Idx As Integer

        For R = 0 To Buff.Count - 1
            If Buff(R) <> "" Then
                Line = ""
                Locks = ""

                If Mid(Buff(R), 3, 1) = "R" Then 'Sym.Read_Only = True
                    Locks = "True~"
                Else
                    Locks = "False~"
                End If

                If Mid(Buff(R), 3, 1) = "N" Then 'Sym.No_Edit
                    Locks &= "True~"
                Else
                    Locks &= "False~"
                End If

                If Mid(Buff(R), 4, 1) = "L" Then 'Sym.Locked = True
                    Locks &= "True~"
                Else
                    Locks &= "False~"
                End If

                T = Mid(Buff(R), 1, 2)
                Buff(R) = Mid(Buff(R), 6)
                Buff(R) = Buff(R).Replace("[", "~")
                Buff(R) = Buff(R).Replace("]", "")
                Buff(R) = Buff(R).Replace(",", "~")
                P = Buff(R).Split("~")
                Params = P.ToList

                Select Case T
                    Case "VN"
                        Type = Class_Symbols.enum_Symbol_Type.Whole
                    Case "VS"
                        Type = Class_Symbols.enum_Symbol_Type.Text
                    Case "VB"
                        Type = Class_Symbols.enum_Symbol_Type.Logical
                    Case "VC"
                        Type = Class_Symbols.enum_Symbol_Type.Color
                    Case "EV"
                        Type = Class_Symbols.enum_Symbol_Type.Evnt
                    Case "IM"
                        Type = Class_Symbols.enum_Symbol_Type.Image
                        Image_Name.Add(Params(0))
                        Image_File.Add(Params(1))
                    Case "CM"
                        Type = Class_Symbols.enum_Symbol_Type.Command
                    Case "GC"
                        Type = Class_Symbols.enum_Symbol_Type.GCode
                    Case "BM"
                        Type = Class_Symbols.enum_Symbol_Type.Button
                    Case "BT"
                        Type = Class_Symbols.enum_Symbol_Type.Toggle
                    Case "BL"
                        Type = Class_Symbols.enum_Symbol_Type.Label
                    Case "TB"
                        Type = Class_Symbols.enum_Symbol_Type.Text_Box
                    Case "PR"
                        Type = Class_Symbols.enum_Symbol_Type.Process
                    Case "PG"
                        Type = Class_Symbols.enum_Symbol_Type.Process_GCode
                    Case "PD"
                        Type = Class_Symbols.enum_Symbol_Type.Process_Drawing
                    Case "DB"
                        Type = Class_Symbols.enum_Symbol_Type.Dialog_Box
                    Case "DG"
                        Type = Class_Symbols.enum_Symbol_Type.Dialog_GCode
                    Case "DD"
                        Type = Class_Symbols.enum_Symbol_Type.Process_Drawing
                    Case "HK"
                        Type = Class_Symbols.enum_Symbol_Type.Hot_Key
                    Case "MC"
                        Type = Class_Symbols.enum_Symbol_Type.Macro
                    Case "ST"
                        Type = Class_Symbols.enum_Symbol_Type.TinyG_Setting
                End Select
            End If

            If Params.Count > 1 Then
                Line = Params(0) & "~" & Type.ToString & "~" & Params(1) & "~" & Locks
            Else
                Line = Params(0) & "~" & Type.ToString & "~~" & Locks
            End If

            Select Case Type

                Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, _
                     Class_Symbols.enum_Symbol_Type.Label, Class_Symbols.enum_Symbol_Type.Check_Box, _
                     Class_Symbols.enum_Symbol_Type.Radio_Button

                    Line &= Params(5) & "~" & Params(6) & "~" 'Handlers
                    Line &= Params(2) & "~" 'Text

                    Idx = Image_Name.IndexOf(Params(3))
                    If Idx >= 0 Then
                        Line &= Image_File(Idx) & "~" 'Down_Image
                    End If

                    Idx = Image_Name.IndexOf(Params(4))

                    If Idx >= 0 Then
                        Line &= Image_File(Idx) & "~" 'Up_Image
                    End If

                    'Line &= Params(3) & "~" 'Down_Image
                    'Line &= Params(4) & "~" 'Up_Image

                    But = Symbol.Get_Control_From_Main_Form(Params(0))

                    Line &= But.Parent.Name & "~"
                    Line &= But.Top & "~"
                    Line &= But.Left & "~"
                    Line &= But.Width & "~"
                    Line &= But.Height & "~"
                    Line &= But.BackColor.ToKnownColor & "~"
                    Line &= But.ForeColor.ToKnownColor & "~"
                    Line &= But.TextAlign & "~"
                    Line &= But.Font.Name & ","
                    Line &= But.Font.Size & ","
                    Line &= But.Font.Style.ToString & "~"
                    Line &= But.Enabled & "~"
                    Line &= "True~" 'Visible

                Case Class_Symbols.enum_Symbol_Type.Text_Box
                    Line &= Params(2) & "~" & Params(3) & "~" 'Handlers
                    Line &= Params(1) & "~" 'Text
                    Line &= "~~" 'Dummy Images, not used on text boxes

                    Txt = Symbol.Get_Control_From_Main_Form(Params(0))
                    Line &= Txt.Parent.Name & "~"
                    Line &= Txt.Top & "~"
                    Line &= Txt.Left & "~"
                    Line &= Txt.Width & "~"
                    Line &= Txt.Height & "~"
                    Line &= Txt.BackColor.Name & "~"
                    Line &= Txt.ForeColor.Name & "~"
                    Line &= Txt.TextAlign & "~"
                    Line &= Txt.Font.Name & ","
                    Line &= Txt.Font.Size & ","
                    Line &= Txt.Font.Style.ToString & "~"
                    Line &= Txt.Enabled & "~"
                    Line &= "True~" 'Visible

                Case Class_Symbols.enum_Symbol_Type.Hot_Key
                    Dim V() As String = Params(0).Split(".")

                    Line = Params(0) & "~" & Type.ToString & "~" & V(V.Count - 1) & "~" & Locks & Params(1) & "~" & Params(2) & "~"

                Case Class_Symbols.enum_Symbol_Type.Process, Class_Symbols.enum_Symbol_Type.Process_GCode, _
                     Class_Symbols.enum_Symbol_Type.Process_Drawing, Class_Symbols.enum_Symbol_Type.Dialog_Box, _
                     Class_Symbols.enum_Symbol_Type.Dialog_GCode, Class_Symbols.enum_Symbol_Type.Process_Drawing

                Case Else

                    For I = 2 To Params.Count - 1
                        Line &= Params(I) & "~"
                    Next

            End Select

            Buff(R) = Line

        Next

        File.WriteAllLines("C:\Dot_Net_Dev\Chip_Application\CNC_Settings\CNC_Symbols_NEW_VERSION.txt", Buff)

    End Sub

End Class