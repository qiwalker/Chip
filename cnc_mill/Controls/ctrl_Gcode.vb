Imports System.IO

Public Class ctrl_Gcode

#Region "enums"

    Public Enum enum_Grid_Colums
        Enable
        Status
        Line_Number
        Block
        Comment
        Point
    End Enum

    Public Enum enum_State
        Idle
        Stopped
        Stepping
        Running
        Done
    End Enum

    Public Enum enum_Backup_Command
        No_Backup
        Backup
        Backup_To_Subdirectory
    End Enum


#End Region

#Region "Structures"

    Private Structure struct_Pause
        Public In_Progress As Boolean
        Public Pause_Start_Time As Long
        Public Pause_Elapsed_Time As Long
    End Structure

#End Region

#Region "Declarations"

    Public State As enum_State
    Public Program_Executing As Boolean = False
    Public All_Blocks_Sent As Boolean = False

    Public Offsets_On As Boolean
    Public GCode_Enabled As Boolean
    Public Current_Row As Integer = 0

    Private Queued_Block As String
    Private Executed_Block As New Class_GCode

    Private Drawing_X_Angle As Single
    Private Drawing_Y_Angle As Single
    Private Drawing_Z_Angle As Single
    Private Drawing_Scale As Single

    Private Value_Before_Edit As String
    Private Edits_Made As Boolean = False

    Private Step_Mode As Boolean

    Private Ignore_Cell_Event As Boolean = True
    Private Ignore_Grid_Event As Boolean = False

    Private Pause As struct_Pause

    Private Control_Symbol As Class_Symbols.class_Symbol
    Public Drawing_Control As ctrl_Drawing

    Private Recover_X_Block As Integer
    Private Recover_Y_Block As Integer
    Private Recover_Last_X_Block As Integer
    Private Recover_Last_Y_Block As Integer
    Private Recover_Block As Integer

    Private Z_Parameter As New List(Of Single)

    Private Property_File_Name As String = ""
    Private Program_Fixture_Offset_File_Name As String = ""

    Public GCode_File_Header As New List(Of String)


    Private Initialized As Boolean = False

    Private Sent_Blocks As Integer = 0

    Private Stop_Watch As New Stopwatch
    Private Time_Shadow As Integer = 0

    Private Turn_On_Spindle As Boolean = False

#End Region

#Region "Properties"

    Public Property GCode_File_Name As String
        Get
            Return Property_File_Name
        End Get

        Set(ByVal value As String)
            Property_File_Name = value
            If Property_File_Name <> "" Then
                txt_Folder.Text = Path.GetDirectoryName(GCode_File_Name)
                txt_File_Name.Text = Path.GetFileName(GCode_File_Name)
            Else
                txt_Folder.Text = ""
                txt_File_Name.Text = ""
            End If
        End Set
    End Property

#End Region

#Region "Initialize, Close"

    Public Sub Initialize(ByRef sym As Class_Symbols.class_Symbol, Optional Drawing_Ctrl As ctrl_Drawing = Nothing, _
                          Optional Wizard_Sym As Class_Symbols.class_Symbol = Nothing)
        Control_Symbol = sym
        Drawing_Control = Drawing_Ctrl
        CNC.Gcode_Block_Number = 1

        Ignore_Cell_Event = True
        grid.Font = GCode_Grid_Font
        Controller.Queue_GCode("N0")
        Controller.Request_Status_Report()
        Initialized = True

    End Sub

    Public Sub Setup()
        State = enum_State.Stopped
        ts_Enabled.Text = "Enabled"
        ts_Enabled.Image = ts_Offsets_On.Image

        Ignore_Cell_Event = True
        Enable_Controls()
        Step_Mode = False

        Offsets_On = Settings.Get_Setting(Control_Symbol.Name, "Offsets_On", 1, "Boolean", True)
        GCode_File_Name = Settings.Get_Setting(Control_Symbol.Name, "File_Name", "", "String", True)

        If Offsets_On Then
            ts_Offsets_On.Visible = True
            ts_Offsets_Off.Visible = False
            ts_Run.Visible = True
            ts_Step.Visible = False
        Else
            ts_Offsets_On.Visible = False
            ts_Offsets_Off.Visible = True
            ts_Run.Visible = True
            ts_Step.Visible = False
        End If

        Select Case Control_Symbol.Role
            Case "Process"
                ts_Offsets_On.Visible = False
                ts_Offsets_Off.Visible = False
                Offsets_On = False
                ts_Run.Text = "Start"
                ts_Run.Visible = True
                ts_Step.Visible = True
        End Select

        If GCode_File_Name <> "" Then
            If Not File.Exists(GCode_File_Name) Then
                Show_Error("File not found : " & GCode_File_Name)
            Else
                Load_G_Code()
            End If
        End If

        txt_Folder.Left = ts_Enable.Left + ts_Enable.Width
        Ignore_Cell_Event = True
        Move_Cursor(0)
        Ignore_Cell_Event = False
    End Sub

    Public Sub Configure_For_Dialog()
        ts_Enable.Visible = False
        ts_G_Code.Visible = False
    End Sub

    Public Sub Finish()

        Settings.Put_Setting(Control_Symbol.Name, "Offsets_On", Offsets_On, True)
        Settings.Put_Setting(Control_Symbol.Name, "File_Name", GCode_File_Name, True)

        If Not IsNothing(Drawing_Control) Then Drawing_Control.Finish()

        grid.EndEdit()

        If Edits_Made Then
            Dim S() As String = Control_Symbol.Name.Split(".")

            Message_Box.ShowDialog("G Code changed : " & S(S.Count - 1) & vbCrLf & _
                                    GCode_File_Name & vbCrLf & "Save file?", "", MessageBoxButtons.YesNo)
            If Message_Box.DialogResult = DialogResult.Yes Then
                Save_G_Code(enum_Backup_Command.Backup_To_Subdirectory)
            End If
        End If

    End Sub

#End Region

#Region "Interface to main program"

    Public Sub Reset()
        Program_Executing = False
        Current_Row = 0
        'Current_Block_Number = 1
        State = enum_State.Stopped
    End Sub

    Public Function Program_Is_Runing() As Boolean
        Return Program_Executing
    End Function

    Public Function Program_Is_Stepping() As Boolean
        Return Step_Mode
    End Function

    Private Function Get_Block_Number(Block As String) As Integer
        Block = Block.Replace("N", "")
        Return CInt(Block)
    End Function

    Public Sub Send_Blocks()
        If Not Program_Executing Then Exit Sub
        If All_Blocks_Sent Then Exit Sub

        Sent_Blocks = 0
        While Controller.Buffers_Available > Controller.Min_Buffer_Slots

            Controller.Buffers_Available -= 1
            Sent_Blocks += 1

            If Current_Row < grid.RowCount - 1 Then
                If Main_Form.OK_To_Send Then
                    Select Case grid.Rows(Current_Row).Cells(enum_Grid_Colums.Enable).Value
                        Case "X" 'Skip block
                            Current_Row += 1
                        Case "#" 'Pause
                            Current_Row += 1
                            Program_Executing = False
                            Exit Sub
                        Case Else
                            Queued_Block = grid.Rows(Current_Row).Cells(enum_Grid_Colums.Line_Number).Value & " " & grid.Rows(Current_Row).Cells(enum_Grid_Colums.Block).Value
                            Controller.Queue_GCode(Queued_Block)
                            Current_Row += 1
                    End Select
                    If Step_Mode Then
                        Exit Sub
                    End If
                End If

            Else 'No more blocks
                All_Blocks_Sent = True
                Exit Sub
            End If

            Main_Form.txt_Test.Text = Sent_Blocks

        End While

    End Sub

    Public Function Start_Program_Execution() As Boolean
        Recover_X_Block = 0
        Recover_Y_Block = 0
        Recover_X_Block = 0
        Recover_Y_Block = 0
        Recover_Block = 0

        If grid.RowCount < 2 Then
            Show_Error("No blocks to execute.")
            Symbol.Set_Value("Sys.In_Cycle_Stop", True)
            Macros.Run_Macro("Update_Form")
            Program_Executing = False
            Return False
        End If

        If Symbol.Get_Value("Sys.Offset.Z_Zero_Set") = False Then
            Message_Box.ShowDialog("Z Offset not set. Continue?", "", MessageBoxButtons.YesNo)
            If Message_Box.DialogResult <> DialogResult.Yes Then
                Return False
            Else
                Symbol.Set_Value("Sys.Offset.Z_Zero_Set", True)
            End If
        End If

        If ts_Offsets_Off.Visible Then
            Message_Box.ShowDialog("Offsets turned off, continue?", "", MessageBoxButtons.YesNo)
            If Message_Box.DialogResult = DialogResult.No Then Return False
        End If

        If Symbol.Get_Value("Probe.In_Spindle") Then
            Dim Blk As String
            Dim lst As List(Of Integer)
            For I = 0 To grid.RowCount - 1
                Blk = UCase(grid.Rows(I).Cells(enum_Grid_Colums.Block).Value)
                lst = CNC.Get_Integer_Codes(Blk, "M")
                If Not IsNothing(lst) Then
                    If lst.Contains(3) Then
                        Show_Error("The probe is loaded and this program will turn on the spinlde, aborting.")
                        Return False
                    End If
                End If
            Next
        End If

        CNC.Status_Code = Class_CNC.enum_Status_Codes.Stopped

        Select Case Control_Symbol.Role

            Case "Process"

            Case "MDI"
                If Offsets_On Then
                    Message_Box.ShowDialog("Offsets are turned ON for MDI." & vbCrLf & _
                                           "Do you want to continue?", , MessageBoxButtons.YesNo)
                    If Message_Box.DialogResult = DialogResult.Yes Then
                        Controller.Enable_Offsets(True)
                        All_Blocks_Sent = False
                        Program_Executing = True

                        Controller.Reset_Program_Interface()
                    Else
                        Return False
                    End If
                Else
                    Controller.Enable_Offsets(False)
                    All_Blocks_Sent = False
                    Program_Executing = True
                    If Step_Mode Then
                        Send_Blocks()
                    End If
                End If

            Case "Program"
                If Not Offsets_On Then
                    Message_Box.ShowDialog("Offsets are turned OFF for Program." & vbCrLf & _
                                           "Do you want to continue?", , MessageBoxButtons.YesNo)
                    If Message_Box.DialogResult = DialogResult.Yes Then
                        Offsets_On = False
                        Controller.Enable_Offsets(False)
                    Else
                        Return False
                    End If
                Else
                    If Symbol.Get_Value("Sys.Coordinate_System") <> Class_CNC.enum_Coordinate_System.G55 Then
                        Offsets_On = True
                        Controller.Enable_Offsets(True)
                    End If
                End If

                Stop_Watch.Reset()
                Stop_Watch.Start()
                Time_Shadow = 0

                All_Blocks_Sent = False
                Program_Executing = True
                Controller.Reset_Program_Interface()

                If Turn_On_Spindle Then
                    Controller.Queue_System_GCode("M03")
                    Controller.Queue_System_GCode("M08")
                End If

                Turn_On_Spindle = False

                Send_Blocks()

        End Select

        Return True

    End Function

    Public Sub Stop_Program_Execution()
        If Symbol.Get_Value("Sys.In_Cycle_Stop") Then
            If Not IsNothing(grid.CurrentRow) Then
                grid.CurrentRow.Cells(enum_Grid_Colums.Status).Value = "<"
            End If
        End If
        Program_Executing = False
    End Sub

    Public Sub Block_Sent(Evnt As Class_CNC.class_Event)
        Executed_Block.Block = Evnt.Parameter
        If Executed_Block.N = 0 Then Exit Sub
        grid.Rows(Executed_Block.N).Cells(enum_Grid_Colums.Status).Value = "*"
        If Executed_Block.N > grid.RowCount - 1 Then Exit Sub
    End Sub

    Public Sub Notify(Evnt As Class_CNC.class_Event)
        Dim Block_Number As Integer = Evnt.Parameter
        If Block_Number > grid.RowCount - 1 Then Exit Sub
        Dim Blk As String = ""
        Dim Codes As List(Of Integer)
        Dim Gcode As String

        If Step_Mode Then

            If Block_Number > 0 Then grid.Rows(Block_Number - 1).Cells(enum_Grid_Colums.Status).Value = "|"
            grid.Rows(Block_Number).Cells(enum_Grid_Colums.Status).Value = ">"
            Move_Cursor(Block_Number)

            If Block_Number > 0 Then Blk = grid.Rows(Block_Number - 1).Cells(enum_Grid_Colums.Block).Value
            Codes = CNC.Get_Integer_Codes(Blk, "G")

            If Not IsNothing(Codes) Then
                If Codes.Contains(0) Or Codes.Contains(1) Or Codes.Contains(2) Or Codes.Contains(3) Then
                    If Evnt.Program_Status = Class_CNC.enum_Status_Codes.Stopped Then
                        Program_Executing = False
                        Symbol.Set_Value("Sys.In_Cycle_Stop", True)
                        Symbol.Set_Value("Sys.In_Cycle_Stop", True)
                        Macros.Run_Macro("Update_Form")
                        If Not IsNothing(Drawing_Control) Then Drawing_Control.Mark_As_Cut(Block_Number - 1)
                        If Not IsNothing(Drawing_Control) Then Drawing_Control.Show_Next_Move(Block_Number)
                    End If
                Else
                End If
            End If

            If Block_Number = grid.RowCount - 1 Then
                Program_Executing = False
                'Controller.Cycle_Stop()
                Macros.Run_Macro("Update_Form")
                Move_Cursor(Block_Number)
            End If

        Else
            If Block_Number = 0 Then Exit Sub

            If Evnt.Flags.Program_Line_Number_Changed Then

                For I = CNC.Gcode_Block_Number To Block_Number
                    If I > 1 Then grid.Rows(I - 2).Cells(enum_Grid_Colums.Status).Value = "|"
                    If Not IsNothing(Drawing_Control) Then Drawing_Control.Mark_As_Cut(I - 2)
                    If Not IsNothing(Drawing_Control) Then Drawing_Control.Show_Next_Move(I - 1)
                Next

                grid.Rows(Block_Number - 1).Cells(enum_Grid_Colums.Status).Value = ">"
                Move_Cursor(Block_Number - 1)


                'Recovery information
                Gcode = grid.Rows(Block_Number - 1).Cells(enum_Grid_Colums.Block).Value
                Blk = grid.Rows(Block_Number - 1).Cells(enum_Grid_Colums.Line_Number).Value
                If Gcode.Contains("X") Then
                    Recover_X_Block = Get_Block_Number(Blk)
                End If
                If Gcode.Contains("Y") Then
                    Recover_Y_Block = Get_Block_Number(Blk)
                End If

                If Gcode.Contains("Z") Then
                    Recover_X_Block = Recover_X_Block
                    Recover_Y_Block = Recover_Y_Block
                    Recover_Last_X_Block = Recover_X_Block
                    Recover_Last_Y_Block = Recover_Y_Block
                    If Recover_Last_X_Block < Recover_Y_Block Then
                        Recover_Block = Recover_Last_X_Block
                    Else
                        Recover_Block = Recover_Last_Y_Block
                    End If
                End If

            End If

            If Block_Number = grid.RowCount - 1 Then
                Program_Executing = False
                Macros.Run_Macro("Update_Form")
                Move_Cursor(Block_Number)
            End If
        End If

        'Show status of spindle and coolant
        For I = CNC.Gcode_Block_Number To Block_Number
            If I > 0 Then
                Blk = grid.Rows(I - 1).Cells(enum_Grid_Colums.Block).Value
                If Not IsNothing(Blk) Then
                    Codes = CNC.Get_Integer_Codes(Blk, "M")
                    If Not IsNothing(Codes) Then
                        For M = 0 To Codes.Count - 1
                            Select Case Int(Codes(M))
                                Case 2, 30 'Program End
                                    Stop_Watch.Stop()
                                    Rewind()
                                    Block_Number = 0

                                    Dim ts As TimeSpan = Stop_Watch.Elapsed
                                    Update_Time_File(ts)

                                    'Dim Buff() As String
                                    'Dim Lst As New List(Of String)

                                    'If File.Exists(txt_Folder.Text & "\Time_Log.txt") Then
                                    '    Buff = File.ReadAllLines(txt_Folder.Text & "\Time_Log.txt")
                                    '    Lst = Buff.ToList
                                    'End If
                                    'Lst.Add(txt_File_Name.Text & " --- " & String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds))
                                    'File.WriteAllLines(txt_Folder.Text & "\Time_Log.txt", Lst)

                                Case 3, 4 'Spinlde om
                                    Symbol.Set_Value("Sys.Spindle", True)
                                Case 5 'Spindle off
                                    Symbol.Set_Value("Sys.Spindle", False)
                                Case 8 'Coolant on
                                    Symbol.Set_Value("Sys.Coolant", True)
                                Case 9 'Coolant off
                                    Symbol.Set_Value("Sys.Coolant", False)
                            End Select
                        Next
                        Macros.Run_Macro("Update_Form")
                    End If
                End If
            End If
        Next

        CNC.Gcode_Block_Number = Block_Number

        If Stop_Watch.ElapsedMilliseconds > Time_Shadow + 1000 Then
            Time_Shadow = Stop_Watch.ElapsedMilliseconds
            Dim ts As TimeSpan = Stop_Watch.Elapsed
            ts_Info.Text = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds)
        End If

    End Sub

    Public Sub Update_Block_Progress(Evnt As Class_CNC.class_Event)
        Static Dim count As Integer = 0

        If Not IsNothing(Drawing_Control) Then
            Drawing_Control.Draw_Cutting(Evnt)
            count += 1
        End If
    End Sub

#End Region

#Region "Pause and Dwell"

    Public Sub Start_Pause()
        'Dwell was implemented this way because it is thread save and acurate
        Dim centuryBegin As Date = #1/1/2001#
        Dim currentDate As Date = Date.Now
        Dim elapsedTicks As Long = currentDate.Ticks - centuryBegin.Ticks
        Dim elapsedSpan As New TimeSpan(elapsedTicks)
        Pause.Pause_Start_Time = elapsedSpan.TotalSeconds
        ts_Info.BackColor = Color.MistyRose
        Pause.In_Progress = True
    End Sub

    Public Sub End_Pause()
        Pause.In_Progress = False
        ts_Info.Text = ""
        ts_Info.BackColor = Color.White
    End Sub

    Public Sub Report_Pause_Progress()
        'Pause (Dwell) was implemented this way because it is thread save and acurate
        If Not Pause.In_Progress Then Exit Sub

        Dim centuryBegin As Date = #1/1/2001#
        Dim currentDate As Date = Date.Now
        Dim elapsedTicks As Long = currentDate.Ticks - centuryBegin.Ticks
        Dim elapsedSpan As New TimeSpan(elapsedTicks)
        ts_Info.Text = FormatNumber(elapsedSpan.TotalSeconds - Pause.Pause_Start_Time, 1)
    End Sub

#End Region

#Region "Toolstrip"

    Private Sub ts_G_Code_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ts_G_Code.ItemClicked, ts_Enable.ItemClicked

        If Controller.Check_For_In_Cycle("Cannot do this operation while in cycle") Then Exit Sub

        Select Case e.ClickedItem.Text
            Case "Load"
                Load_G_Code_Dialog()

            Case "Save"
                Save_G_Code(enum_Backup_Command.Backup_To_Subdirectory)

            Case "Save As"
                Dim dlg As New SaveFileDialog
                If GCode_File_Name = "" Then
                    dlg.InitialDirectory = Chip_Wizard_G_Code_Folder
                Else
                    dlg.InitialDirectory = Path.GetDirectoryName(GCode_File_Name)
                    dlg.FileName = Path.GetFileName(GCode_File_Name)
                End If

                dlg.Filter = "Chip Files (*.chp)|*.chp|Other (*.ngc)|*.ngc|G Code Files (*.chp;*.ngs)|*.chp;*.ngc|All files (*.*)|*.*"
                If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    GCode_File_Name = dlg.FileName
                    Save_G_Code(enum_Backup_Command.No_Backup)
                    If Not IsNothing(Drawing_Control) Then
                        Drawing_Control.Reset()
                    End If
                End If

            Case "Wizards"
                If Controller.Check_For_In_Cycle("Cannot start wizards while in cycle") Then Exit Sub

                Dim dlg As New dlg_Wizards
                dlg.Wizard_GCode_File_Name = GCode_File_Name
                dlg.ShowDialog()
                If dlg.DialogResult = DialogResult.OK Then
                    GCode_File_Name = dlg.Wizard_GCode_File_Name
                    If GCode_File_Name <> "" Then
                        Load_G_Code()
                        Rewind()
                    End If
                End If

            Case "Resume"
                Controller.Feed_Resume()
                ts_Run.Visible = False

            Case "Run"
                If Control_Symbol.Role <> "Process" Then
                    ts_Run.Visible = False
                    ts_Step.Visible = True
                    Step_Mode = True
                End If

            Case "Step"
                If Control_Symbol.Role <> "Process" Then
                    ts_Run.Visible = True
                    ts_Step.Visible = False
                    Step_Mode = False
                End If

            Case "Rewind"
                Rewind()

            Case "Start Here"
                Message_Box.ShowDialog("Are you sure? This could cause a crash.", "Warning", MessageBoxButtons.YesNo)
                If Message_Box.DialogResult <> DialogResult.Yes Then Exit Sub

                Turn_On_Spindle = True
                CNC.Queue_Message("N0", False)
                Current_Row = grid.CurrentRow.Index
                For I = 0 To grid.RowCount - 1
                    If I < Current_Row Then grid.Rows(I).Cells(enum_Grid_Colums.Status).Value = "|"
                    If I = Current_Row Then grid.Rows(I).Cells(enum_Grid_Colums.Status).Value = ">"
                    If I > Current_Row Then grid.Rows(I).Cells(enum_Grid_Colums.Status).Value = ""
                Next

            Case "Recover"
                Message_Box.ShowDialog("Are you sure? This could cause a crash.", "Warning", MessageBoxButtons.YesNo)
                If Message_Box.DialogResult <> DialogResult.Yes Then Exit Sub

                Controller.Queue_System_GCode("G90 G54 G01 Z" & Symbol.Get_Value("Sys.Max_Z") & "F30")

                Rewind()
                Current_Row = Recover_Block - 1
                For I = 0 To grid.RowCount - 1
                    If I < Current_Row Then grid.Rows(I).Cells(enum_Grid_Colums.Status).Value = "|"
                    If I = Current_Row Then grid.Rows(I).Cells(enum_Grid_Colums.Status).Value = ">"
                    If I > Current_Row Then grid.Rows(I).Cells(enum_Grid_Colums.Status).Value = ""
                Next

            Case "Insert", "XYZ"
                Dim P(3) As String
                P(2) = ""

                If e.ClickedItem.Text = "XYZ" Then
                    Dim Feedrate As Single = Symbol.Get_Value("Jog_Rate.Selected")
                    If Feedrate < 0 Then Feedrate = 1
                    P(enum_Grid_Colums.Block) = "G01 X" & Symbol.Get_Value("Sys.Abs_X") & " Y" & Symbol.Get_Value("Sys.Abs_Y") & _
                           " Z" & Symbol.Get_Value("Sys.Abs_Z") & " F" & FormatNumber(Feedrate, 0)
                    If IsNothing(grid.CurrentRow) Then
                        grid.Rows.Add(P)
                    Else
                        grid.Rows.Insert(grid.CurrentRow.Index, P)
                    End If
                Else
                    If Control_Symbol.Role = "Process" Then
                        Dim dlg As New dlg_Process_Insert_Step
                        dlg.ShowDialog()
                        If dlg.DialogResult = DialogResult.OK Then
                            For B = 0 To dlg.Block_List.Items.Count - 1
                                P(enum_Grid_Colums.Block) = dlg.Block_List.Items(B)
                                grid.Rows.Add(P)
                            Next
                        End If
                    Else
                        grid.Rows.Insert(grid.CurrentRow.Index, P)
                    End If
                End If
                Renumber()

            Case "Delete"
                If Not IsNothing(grid.CurrentRow) Then
                    grid.Rows.RemoveAt(grid.CurrentRow.Index)
                End If
                Renumber()

            Case "Enabled"
                GCode_Enabled = False
                ts_Enabled.Image = ts_Offsets_Off.Image
                ts_Enabled.Text = "Disabled"
                Enable_Controls()

            Case "Disabled"
                GCode_Enabled = True
                ts_Enabled.Image = ts_Offsets_On.Image
                ts_Enabled.Text = "Enabled"
                Enable_Controls()

            Case "Offsets On"
                If State = enum_State.Running Then
                    Show_Error("Cannot turn on offsets while program is running")
                    Exit Sub
                End If
                Offsets_On = False
                ts_Offsets_On.Visible = False
                ts_Offsets_Off.Visible = True

            Case "Offsets Off"
                If State = enum_State.Running Then
                    Show_Error("Cannot turn off offsets while program is running")
                    Exit Sub
                End If
                Offsets_On = True
                ts_Offsets_On.Visible = True
                ts_Offsets_Off.Visible = False

            Case "Stops On"
                ts_Stops_On.Visible = False
                ts_Stops_Off.Visible = True

            Case "Stops Off"
                ts_Stops_On.Visible = True
                ts_Stops_Off.Visible = False

        End Select

    End Sub

    Private Sub Enable_Controls()
        If ts_Enabled.Text = "Enabled" Then
            ts_Run.Enabled = True
            ts_Step.Enabled = True
            ts_Rewind.Enabled = True
            ts_Start_Here.Enabled = True
        Else
            ts_Run.Enabled = False
            ts_Step.Enabled = False
            ts_Rewind.Enabled = False
            ts_Start_Here.Enabled = False
        End If
    End Sub

    Private Sub Rewind()

        Program_Executing = False
        Current_Row = 0
        'Current_Block_Number = 1
        State = enum_State.Stopped

        Controller.Cycle_Stop()

        Symbol.Set_Value("Sys.In_Feed_Hold", False)

        Macros.Run_Macro("Spindle_Off")
        Macros.Run_Macro("Coolant_Off")

        CNC.Queue_Message("N0", False)

        If Not IsNothing(Drawing_Control) Then
            Drawing_Control.Load_Drawing_Points(Me)
            Drawing_Control.Draw_Cutter_Path()
        End If

        CNC.Gcode_Block_Number = 1


        For R = 0 To grid.RowCount - 1
            grid.Rows(R).Cells(enum_Grid_Colums.Status).Value = ""
        Next
        Move_Cursor(0)
        grid.Rows(0).Cells(enum_Grid_Colums.Status).Value = ">"

    End Sub

#End Region

#Region "Grid"

    Private Sub grid_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid.CellMouseDown
        If e.ColumnIndex = enum_Grid_Colums.Enable Then
            If Control_Symbol.Role = "Program" Then
                Select Case grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    Case ""
                        grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "#"
                    Case "#"
                        grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                End Select
            Else
                Select Case grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    Case ""
                        grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "X"
                    Case "X"
                        grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "#"
                    Case "#"
                        grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
                End Select
            End If
        End If

        If e.RowIndex >= 0 Then
            Dim B As String = grid.Rows(e.RowIndex).Cells(enum_Grid_Colums.Line_Number).Value
            If Not IsNothing(B) Then
                B = B.Replace("N", "")
                Drawing_Control.Show_Next_Move(B, True)
            End If
        End If

    End Sub

    Private Sub grid_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellEnter
        If Not Initialized Then Exit Sub
        If Ignore_Cell_Event Then Exit Sub
        If e.ColumnIndex = enum_Grid_Colums.Block Then
            Value_Before_Edit = grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End If
    End Sub

    Private Sub grid_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellValidated
        If Ignore_Cell_Event Then Exit Sub
        If Not Initialized Then Exit Sub
        If e.ColumnIndex = enum_Grid_Colums.Block Then
            Dim Blk As New Class_GCode
            Blk.Block = grid.CurrentCell.Value

            If grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> Value_Before_Edit Then
                Edits_Made = True
            End If

            grid.CurrentCell.Value = Blk.Formatted_Block
            Renumber()
            Refresh_Drawing()
        End If

    End Sub

    Private Sub grid_Rows_Added(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grid.RowsAdded
        If Ignore_Grid_Event Then Exit Sub
        If Not Initialized Then Exit Sub
        Refresh_Drawing()
    End Sub

    Private Sub grid_Rows_Removed(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grid.RowsRemoved
        If Ignore_Grid_Event Then Exit Sub
        If Not Initialized Then Exit Sub
        Refresh_Drawing()
    End Sub

    Public Sub Clear_Rows()
        Ignore_Grid_Event = True
        grid.Rows.Clear()
        Refresh_Drawing()
        Ignore_Grid_Event = False
    End Sub

    Public Sub Append_Rows(Blocks As List(Of String))
        Dim Cells(3) As String
        Dim GC As New Class_GCode
        Ignore_Grid_Event = True

        If grid.RowCount = 0 Then
            Cells(1) = ""
            Cells(2) = "(" & GCode_File_Name & ")"
            Cells(1) = ""
            grid.Rows.Add(Cells)
        End If

        For I = 0 To Blocks.Count - 1
            GC.Block = Blocks(I)
            Add_Row(GC)
        Next

        Renumber()

        Refresh_Drawing()
        Ignore_Grid_Event = False
    End Sub

    Public Sub Insert_Rows(Blocks As List(Of String))
        Dim Cells(3) As String
        Dim GC As New Class_GCode

        Ignore_Grid_Event = True

        If grid.RowCount = 0 Then
            Cells(1) = ""
            Cells(2) = "(" & GCode_File_Name & ")"
            Cells(1) = ""
            grid.Rows.Add(Cells)
        End If

        For I = 0 To Blocks.Count - 1
            GC.Block = Blocks(I)
            Add_Row(GC, True)
        Next

        Renumber()
        Refresh_Drawing()
        Ignore_Grid_Event = False
    End Sub

    Public Sub Insert_Row(Optional Block As String = "")
        Ignore_Grid_Event = True
        Dim Cells(4) As String
        Cells(1) = ""
        Cells(2) = ""
        Cells(3) = Block
        Cells(4) = ""
        If IsNothing(grid.CurrentRow) Then
            grid.Rows.Add(Cells)
            Exit Sub
        End If
        Dim Idx As Integer = grid.CurrentRow.Index
        grid.Rows.Insert(Idx, Cells)
        Renumber()
        Refresh_Drawing()
        Ignore_Grid_Event = False
    End Sub

    Public Sub Delete_Row()
        Ignore_Grid_Event = True
        Dim Idx As Integer = grid.CurrentRow.Index
        grid.Rows.RemoveAt(Idx)
        Renumber()
        Refresh_Drawing()
        Ignore_Grid_Event = False
    End Sub

    Public Sub Collapse()
        Dim Block As String
        For I = 0 To grid.RowCount - 1
            Block = grid.Rows(I).Cells(enum_Grid_Colums.Block).Value
            If Not IsNothing(Block) Then
                If Not Mid(Block, 1, 1) = "(" Then
                    grid.Rows(I).Visible = False
                End If
            End If
        Next
    End Sub

    Public Sub Expand()
        For I = 0 To grid.RowCount - 1
            grid.Rows(I).Visible = True
        Next
    End Sub

#End Region

    Public Function Check_GCode() As Boolean
        Dim Block As String
        Dim M03_Found As Boolean = False

        For I = 0 To grid.RowCount - 1
            Block = grid.Rows(I).Cells(enum_Grid_Colums.Block).Value
            If Not IsNothing(Block) Then
                If Block.Contains("M03") Then
                    M03_Found = True
                End If
            End If
        Next

        If Not M03_Found Then
            Message_Box.ShowDialog("M03 (Spindle on) was not detected." & vbCrLf & "Do you still want to exit?", "Warning", MessageBoxButtons.YesNo)
            If Message_Box.DialogResult = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        End If

        Return True

    End Function

    Public Sub Refresh_Drawing()
        If Not IsNothing(Drawing_Control) Then
            Drawing_Control.Load_Drawing_Points(Me)
            Drawing_Control.Draw_Cutter_Path()
        End If
    End Sub

    Public Sub Set_Grid_Point_Cell(ByRef Row As Integer, Point_Index As Integer)
        Ignore_Cell_Event = True
        grid.Rows(Row).Cells(enum_Grid_Colums.Point).Value = Point_Index
        Ignore_Cell_Event = False
    End Sub

    Public Sub Move_Cursor(Row As Integer)
        If grid.RowCount < 0 Then Exit Sub
        Ignore_Cell_Event = True
        If Row < grid.RowCount Then
            grid.CurrentCell = grid.Rows(Row).Cells(0)
        End If
        Ignore_Cell_Event = False
    End Sub

    Private Sub Renumber()
        Dim S As String
        Ignore_Cell_Event = True
        For R = 0 To grid.Rows.Count - 2
            grid.Rows(R).Cells(enum_Grid_Colums.Line_Number).Value = "N" & Trim(Str(R + 1))
            S = grid.Rows(R).Cells(enum_Grid_Colums.Block).Value
            If S.Contains("Z") Then grid.Rows(R).Cells(enum_Grid_Colums.Block).Style.BackColor = Color.MistyRose
        Next
        Ignore_Cell_Event = False
    End Sub

#Region "Load/Save file"

    Private Sub Add_Row(Block As Class_GCode, Optional Insert As Boolean = False)
        Dim Cells(4) As String
        Dim T() As String = Nothing

        For I = 0 To Cells.Count - 1
            Cells(I) = ""
        Next

        If Block.Original_Block.Contains("%") Then Exit Sub 'Filter out % blocks

        If Block.Comment = "END" Then
            Block.Comment = "(END)"
        End If

        Cells(enum_Grid_Colums.Line_Number) = "N" & Trim(grid.RowCount)
        Cells(enum_Grid_Colums.Block) = Block.Formatted_Block
        Cells(enum_Grid_Colums.Comment) = Block.Comment

        If Insert Then
            If Not IsNothing(grid.CurrentRow) Then
                Dim Idx As Integer = grid.CurrentRow.Index
                grid.Rows.Insert(Idx, Cells)
            Else
                Show_Error("No row selected, click on grid")
            End If
        End If

        grid.Rows.Add(Cells)

    End Sub

    Public Function Load_G_Code_Dialog() As String
        State = enum_State.Stopped

        Dim dlg As New OpenFileDialog
        Dim Load_OK As Boolean = False

        If GCode_File_Name = "" Then
            dlg.InitialDirectory = Chip_Wizard_G_Code_Folder
        Else
            dlg.InitialDirectory = Path.GetDirectoryName(GCode_File_Name)
            dlg.FileName = Path.GetFileName(GCode_File_Name)
        End If

        dlg.Filter = "Chip Files (*.chp)|*.chp|Other (*.ngc)|*.ngc|G Code Files (*.chp;*.ngs)|*.chp;*.ngc|All files (*.*)|*.*"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            GCode_File_Name = dlg.FileName
            Load_OK = Load_G_Code()
            If Load_OK Then
                If Not IsNothing(Drawing_Control) Then
                    Drawing_Control.Reset(True)
                End If
            End If
            Return dlg.FileName
        Else
            Return ""
        End If

    End Function

    Public Function Check_M_Codes() As String
        Dim Buff As New List(Of String)
        Dim Block As String
        Dim Spindle_On As Boolean = False
        Dim Spindle_Off As Boolean = False
        Dim Coolant_On As Boolean = False
        Dim Coolant_Off As Boolean = False
        Dim Program_End As Boolean = False
        Dim MCodes As List(Of Integer)
        Dim Message As String = ""

        grid.EndEdit()
        For R = 0 To grid.RowCount - 1
            Block = grid.Rows(R).Cells(enum_Grid_Colums.Block).Value
            If Not IsNothing(Block) Then
                MCodes = CNC.Get_Integer_Codes(Block, "M")
                If MCodes.Count > 0 Then
                    If MCodes.Contains(3) Then Spindle_On = True
                    If MCodes.Contains(8) Then Coolant_On = True
                    If MCodes.Contains(5) Then Spindle_Off = True
                    If MCodes.Contains(9) Then Coolant_Off = True
                    If MCodes.Contains(2) Then Program_End = True
                    If MCodes.Contains(30) Then Program_End = True
                End If
            End If

        Next

        If Not Spindle_On Then Message &= "M03 (Spindle On) not detected." & vbCrLf
        If Not Coolant_On Then Message &= "M08 (Coolant On) not detected." & vbCrLf
        If Not Spindle_Off Then Message &= "M05 (Spindle Off) not detected." & vbCrLf
        If Not Coolant_Off Then Message &= "M09 (Coolant Off) not detected." & vbCrLf
        If Not Program_End Then Message &= "M02 or M30 (Program End) not detected." & vbCrLf

        Return Message

    End Function

    Public Function Save_G_Code_Dialog(Backup_Command As enum_Backup_Command) As String
        State = enum_State.Stopped

        Dim dlg As New SaveFileDialog
        If GCode_File_Name = "" Then
            dlg.InitialDirectory = Chip_Wizard_G_Code_Folder
            dlg.FileName = ""
        Else
            dlg.InitialDirectory = Path.GetDirectoryName(GCode_File_Name)
            dlg.FileName = Path.GetFileName(GCode_File_Name)
        End If

        dlg.Filter = "Chip Files (*.chp)|*.chp|Other (*.ngc)|*.ngc|G Code Files (*.chp;*.ngs)|*.chp;*.ngc|All files (*.*)|*.*"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            GCode_File_Name = dlg.FileName
            Save_G_Code(Backup_Command)
            Return dlg.FileName
        Else
            Return ""
        End If

    End Function

    Public Function Load_G_Code() As Boolean
        Dim Buff() As String
        Dim Cells(3) As String
        Dim G_Code_Block As Class_GCode
        Dim PCodes As List(Of Integer)
        Dim Ignore_Warning As Boolean = False
        Dim Load_OK As Boolean = True
        Dim Save As Boolean = False
        Dim Header_Count As Integer = 0

        Ignore_Cell_Event = True
        Ignore_Grid_Event = True
        Edits_Made = False

        If GCode_File_Name = "" Then
            Return False
        End If

        If Not File.Exists(GCode_File_Name) Then
            Show_Error("File not found : " & GCode_File_Name)
            GCode_File_Name = ""
            Return False
        End If

        Symbol.Set_Value("Sys.Offset.Z_Zero_Set", False)
        Symbol.Set_Value(Control_Symbol.Name, GCode_File_Name)

        Buff = File.ReadAllLines(GCode_File_Name)

        Dim S() As String

        'Get Header Information
        Program_Fixture_Offset_File_Name = ""
        GCode_File_Header.Clear()

        For R = 0 To Buff.Count - 1
            If Mid(Buff(R), 1, 1) = "'" Then
                S = Buff(R).Split("=")
                If S(0) = "'Fixture_Offset_File" Then Program_Fixture_Offset_File_Name = S(1)
                GCode_File_Header.Add(Buff(R))
                Header_Count += 1
            Else
                Exit For
            End If
        Next

        Dim dlg As New dlg_Progress
        dlg.bar.Minimum = 0
        dlg.bar.Maximum = Buff.Count
        dlg.bar.Step = 1
        dlg.Show("Loading : " & Path.GetFileName(GCode_File_Name))

        grid.Rows.Clear()

        If Not IsNothing(Drawing_Control) Then Drawing_Control.Clear_Drawing()


        For R = Header_Count To Buff.Count - 1
            dlg.Update_Progress()

            G_Code_Block = New Class_GCode
            G_Code_Block.Block = Buff(R)

            For I = 0 To G_Code_Block.G.Count - 1
                Select Case CInt(G_Code_Block.G(I))
                    Case 2, 3 'Arc
                        'If Not Ignore_Warning Then
                        '    Message_Box.ShowDialog("Program contains G2 or G3 arc." & vbCrLf & "Continue", "Warning", MessageBoxButtons.YesNo)
                        '    If Message_Box.DialogResult = DialogResult.No Then
                        '        Load_OK = False
                        '        GoTo Early_Exit
                        '    End If
                        '    Ignore_Warning = True
                        'End If

                    Case 4 'Dwell
                        PCodes = CNC.Get_Integer_Codes(G_Code_Block.Block, "P")
                        For J = 0 To PCodes.Count - 1
                            If PCodes(J) = 0 Then
                                Show_Error("Program contains G4 P0, pause of zero.")
                            End If
                        Next
                End Select
            Next

            If R = Buff.Count - 1 Then
                If G_Code_Block.Block <> "" Then
                    Add_Row(G_Code_Block)
                End If
            Else
                Add_Row(G_Code_Block)
            End If
Skip:
        Next

        Renumber()

        Current_Row = 0
        Controller.Block_No = 0

        Ignore_Cell_Event = True
        If grid.Rows.Count > 0 Then
            grid.CurrentCell = grid.Rows(0).Cells(enum_Grid_Colums.Line_Number)
            Current_Row = 0
            Controller.Block_No = 1
        End If

        Ignore_Cell_Event = True
        If Not IsNothing(Drawing_Control) Then
            Drawing_Control.Load_Drawing_Points(Me)
        End If


        If Save Then Save_G_Code(enum_Backup_Command.Backup_To_Subdirectory)
        'Early_Exit:

        dlg.Close()

        Offset_Check_Dialog.Fixture_Offset_File = Macros.Get_Current_Offset_File_Name
        Offset_Check_Dialog.Program_Offset_File = Program_Fixture_Offset_File_Name
        If Not Offset_Check_Dialog.Check_Offsets() Then
            Offset_Check_Dialog.ShowDialog()
            If Offset_Check_Dialog.DialogResult = DialogResult.OK Then
                Macros.Set_Current_Offset_File_Name(Offset_Check_Dialog.Fixture_Offset_File)
                If Offset_Check_Dialog.Load_Offset_File Then Macros.Load_Offsets(Offset_Check_Dialog.Fixture_Offset_File)
                Save_G_Code(enum_Backup_Command.Backup_To_Subdirectory)
            End If

        Else
            Macros.Load_Offsets(Program_Fixture_Offset_File_Name, False)
        End If

        Macros.Program_Changed(GCode_File_Name, GCode_File_Header)

        Ignore_Cell_Event = False
        Ignore_Grid_Event = False

        grid.Rows(0).Cells(enum_Grid_Colums.Status).Value = ">"

        ts_Line_Count.Text = grid.RowCount - 1 & " Blocks"

        Me.Cursor = Cursors.Arrow

        Return Load_OK

    End Function

    Public Sub Save_G_Code(Backup_Command As enum_Backup_Command)

        If GCode_File_Name = "" Then
            Dim ext As String = Symbol.Get_Value("Sys.GCode_File_Extension")
            If ext = "" Then ext = ".Txt"
            Dim dlg As New SaveFileDialog
            dlg.InitialDirectory = Chip_Macro_Program_Folder
            dlg.FileName = Path.GetFileName(GCode_File_Name)
            dlg.Filter = "GCode Files (*." & ext & ")|*." & ext & "|All files (*.*)|*.*"
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                GCode_File_Name = dlg.FileName
                Symbol.Set_Value(Control_Symbol.Name, GCode_File_Name)
            Else
                Exit Sub
            End If
        Else
            Select Case Backup_Command
                Case enum_Backup_Command.No_Backup
                Case enum_Backup_Command.Backup
                    Dim Folder As String = Path.GetDirectoryName(GCode_File_Name)
                    Dim DF As New Class_Data_File
                    DF.Backup_File(GCode_File_Name)
                Case enum_Backup_Command.Backup_To_Subdirectory
                    Dim Folder As String = Path.GetDirectoryName(GCode_File_Name)
                    Dim DF As New Class_Data_File
                    DF.Backup_File(GCode_File_Name, True)
            End Select
        End If

        Dim Buff As New List(Of String)

        'Update file header with current fixture offset file
        Dim T() As String
        Dim Found As Boolean = False
        Program_Fixture_Offset_File_Name = Macros.Get_Current_Offset_File_Name

        For I = 0 To GCode_File_Header.Count - 1
            T = GCode_File_Header(I).Split("=")
            If T(0) = "'Fixture_Offset_File" Then
                GCode_File_Header(I) = "'Fixture_Offset_File=" & Program_Fixture_Offset_File_Name
                Found = True
            End If
        Next
        If Not Found Then Buff.Add("'Fixture_Offset_File=" & Program_Fixture_Offset_File_Name)

        If Not IsNothing(GCode_File_Header) Then
            For I = 0 To GCode_File_Header.Count - 1
                Buff.Add(GCode_File_Header(I))
            Next
        End If

        grid.EndEdit()

        Dim S As String
        For R = 0 To grid.RowCount - 1
            S = grid.Rows(R).Cells(enum_Grid_Colums.Block).Value
            If grid.Rows(R).Cells(enum_Grid_Colums.Comment).Value <> "" Then
                S &= ";" & grid.Rows(R).Cells(enum_Grid_Colums.Comment).Value
            End If
            If (Not IsNothing(S)) And S <> "" Then Buff.Add(S)
        Next

        File.WriteAllLines(GCode_File_Name, Buff)

        Edits_Made = False
    End Sub

#End Region

    Public Sub Update_Time_File(ts As TimeSpan)
        Dim B() As String
        Dim Buff As New List(Of String)
        Dim P() As String
        Dim T As String = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds)
        Dim Fn As String = txt_Folder.Text & "\" & txt_File_Name.Text
        Dim Found As Boolean = False

        If File.Exists(Chip_Times_File) Then
            B = File.ReadAllLines(Chip_Times_File)
            Buff = B.ToList
            For I = 0 To Buff.Count - 1
                P = Buff(I).Split("~")
                If P(0) = Fn Then
                    Found = True
                    Buff(I) = Fn & "~" & T
                End If
            Next
        End If

        If Not Found Then Buff.Add(Fn & "~" & T)

        Dim Cmp As New TimeComparer
        Buff.Sort(Cmp)

        File.WriteAllLines(Chip_Times_File, Buff)

    End Sub

    Public Class TimeComparer
        Implements IComparer(Of String)

        Public Function Compare(ByVal x As String, _
            ByVal y As String) As Integer Implements IComparer(Of String).Compare

            If x Is Nothing Then
                If y Is Nothing Then
                    Return 0
                Else
                    Return -1
                End If
            Else
                If y Is Nothing Then
                    Return 1
                Else
                    Dim retval As Integer = x.Length.CompareTo(y.Length)

                    If retval <> 0 Then
                        Return retval
                    Else
                        Return x.CompareTo(y)
                    End If
                End If
            End If
        End Function
    End Class

End Class
