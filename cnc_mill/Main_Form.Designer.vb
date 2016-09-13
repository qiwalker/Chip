<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Form))
        Me.Tab_Main = New System.Windows.Forms.TabControl()
        Me.Tab_Gcode = New System.Windows.Forms.TabPage()
        Me.Process_Box = New Chip.ctrl_Process()
        Me.Tab_Jog_Probe = New System.Windows.Forms.TabPage()
        Me.Text_Box_Probe_File = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Folder = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Set_Gap = New System.Windows.Forms.TextBox()
        Me.chk_Move_Set_Gap = New System.Windows.Forms.CheckBox()
        Me.Button_Probe_Load = New System.Windows.Forms.Button()
        Me.Button_Probe_Save = New System.Windows.Forms.Button()
        Me.Text_Box_Probe_Safe_Z = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.chk_Move_Raise_Z = New System.Windows.Forms.CheckBox()
        Me.Text_Box_Jog_Safe_Z = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.chk_Soft_Limits = New System.Windows.Forms.CheckBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Text_Box_Jog_Rate_Little_Step = New System.Windows.Forms.TextBox()
        Me.Text_Box_Jog_Rate_Big_Step = New System.Windows.Forms.TextBox()
        Me.Text_Box_Jog_Rate_Creep = New System.Windows.Forms.TextBox()
        Me.Text_Box_Jog_Rate_Slow = New System.Windows.Forms.TextBox()
        Me.Text_Box_Jog_Rate_Fast = New System.Windows.Forms.TextBox()
        Me.Button_Jog_Rate_Little_Step = New System.Windows.Forms.Button()
        Me.Button_Jog_Rate_Big_Step = New System.Windows.Forms.Button()
        Me.Button_Jog_Rate_Creep = New System.Windows.Forms.Button()
        Me.Button_Jog_Rate_Slow = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button_Jog_Rate_Fast = New System.Windows.Forms.Button()
        Me.Button_Jog_Z_Plus = New System.Windows.Forms.Button()
        Me.Button_Jog_Z_Minus = New System.Windows.Forms.Button()
        Me.Button_Jog_X_Minus = New System.Windows.Forms.Button()
        Me.Button_Jog_X_Plus = New System.Windows.Forms.Button()
        Me.Button_Jog_Y_Minus = New System.Windows.Forms.Button()
        Me.Button_Jog_Y_Plus = New System.Windows.Forms.Button()
        Me.Text_Box_Move_X_Plus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Move_Y_Plus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Move_Y_Minus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Move_X_Minus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Move_Z_Down = New System.Windows.Forms.TextBox()
        Me.Text_Box_Move_Z_Up = New System.Windows.Forms.TextBox()
        Me.Button_Move_Z_Plus = New System.Windows.Forms.Button()
        Me.Button_Move_Z_Minus = New System.Windows.Forms.Button()
        Me.Button_Move_X_Minus = New System.Windows.Forms.Button()
        Me.Button_Move_X_Plus = New System.Windows.Forms.Button()
        Me.Button_Move_Y_Minus = New System.Windows.Forms.Button()
        Me.Button_Move_Y_Plus = New System.Windows.Forms.Button()
        Me.Button_Probe_Center = New System.Windows.Forms.Button()
        Me.Button_Probe_Corner_SE = New System.Windows.Forms.Button()
        Me.Button_Probe_Corner_NE = New System.Windows.Forms.Button()
        Me.Button_Probe_Corner_NW = New System.Windows.Forms.Button()
        Me.Button_Probe_Corner_SW = New System.Windows.Forms.Button()
        Me.Button_Probe_Center_Move_To_Center = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Center_Delta_X = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Center_Delta_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Center_XY = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Center_Gap_Y_Minus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Center_Gap_Y_Plus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Center_Gap_X_Plus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Center_Gap_X_Minus = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Feedrate = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_State = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Diameter = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Gap_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Surface_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_End_Z = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Start_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Gap_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Surface_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_End_Y = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Start_Y = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Gap_X = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Surface_X = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_End_X = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Button_Probe_X_Minus = New System.Windows.Forms.Button()
        Me.Button_Probe_X_Plus = New System.Windows.Forms.Button()
        Me.Button_Probe_Z_Minus = New System.Windows.Forms.Button()
        Me.Button_Probe_Y_Minus = New System.Windows.Forms.Button()
        Me.Button_Probe_Y_Plus = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Text_Box_Probe_Start_X = New System.Windows.Forms.TextBox()
        Me.Text_Box_Probe_Distance = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Tab_Fixture_Offsets = New System.Windows.Forms.TabPage()
        Me.Text_Box_Tool_Park_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Tool_Park_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Tool_Park_X = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Text_Box_Tool_Measure_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Tool_Measure_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Tool_Measure_X = New System.Windows.Forms.TextBox()
        Me.Text_Box_Tool_Seat_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Tool_Seat_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Tool_Seat_X = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Text_Box_Tool_Change_Z = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Text_Box_Tool_Change_Y = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Text_Box_Tool_Change_X = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Button_Tool_Measure_Top = New System.Windows.Forms.Button()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Button_Material_Measure = New System.Windows.Forms.Button()
        Me.Text_Box_Fixture_Offset_Material_Thickness = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Button_Tool_Measure_Bottom = New System.Windows.Forms.Button()
        Me.Text_Box_Fixture_Offset_Material_Bottom = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Text_Box_Fixture_Offset_Material_Top = New System.Windows.Forms.TextBox()
        Me.Button_Fixture_Offset_Z0_Top = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Z0_Bottom = New System.Windows.Forms.Button()
        Me.Text_Box_Fixture_Offset_File = New System.Windows.Forms.TextBox()
        Me.Text_Box_Fixture_Offset_Folder = New System.Windows.Forms.TextBox()
        Me.Button_Fixture_Offset_Set = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Goto = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Load = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Save = New System.Windows.Forms.Button()
        Me.Text_Box_Fixture_Offset_Total_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Fixture_Offset_Delta_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Fixture_Offset_Original_Z = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Button_Fixture_Offset_Reset_Y = New System.Windows.Forms.Button()
        Me.Text_Box_Fixture_Offset_Total_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Fixture_Offset_Delta_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Fixture_Offset_Original_Y = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Button_Fixture_Offset_Reset_X = New System.Windows.Forms.Button()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Text_Box_Fixture_Offset_Total_X = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Text_Box_Fixture_Offset_Delta_X = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Text_Box_Fixture_Offset_Original_X = New System.Windows.Forms.TextBox()
        Me.Button_Fixture_Offset_Adjust_Plus_Z = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Adjust_Minus_Z = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Adjust_Minus_X = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Adjust_Plus_X = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Adjust_Minus_Y = New System.Windows.Forms.Button()
        Me.Button_Fixture_Offset_Adjust_Plus_Y = New System.Windows.Forms.Button()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Text_Box_Fixture_Offset_Increment = New System.Windows.Forms.TextBox()
        Me.Button_Fixture_Offset_Reset_Z = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Tab_Home = New System.Windows.Forms.TabPage()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Text_Box_Square_Gap_X_Minus = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Text_Box_Square_Gap_X_Plus = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Text_Box_Square_Gap_Y_Plus = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Text_Box_Square_Gap_Y_Minus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Square_Z = New System.Windows.Forms.TextBox()
        Me.Button_Square_Goto_Z = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Text_Box_Square_Y_Plus = New System.Windows.Forms.TextBox()
        Me.Text_Box_Square_Y_Minus = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Text_Box_Square_Error_X = New System.Windows.Forms.TextBox()
        Me.Button_Square_Probe_X_Minus = New System.Windows.Forms.Button()
        Me.Button_Square_Probe_X_Plus = New System.Windows.Forms.Button()
        Me.Button_Square_Probe_Y_Plus = New System.Windows.Forms.Button()
        Me.Text_Box_Square_X_Minus = New System.Windows.Forms.TextBox()
        Me.Button_Square_Goto_X_Minus = New System.Windows.Forms.Button()
        Me.Button_Square_Goto_Y_Minus = New System.Windows.Forms.Button()
        Me.Button_Square_Goto_Y_Plus = New System.Windows.Forms.Button()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Text_Box_Square_Error_Y = New System.Windows.Forms.TextBox()
        Me.Button_Square_Goto_X_Plus = New System.Windows.Forms.Button()
        Me.Button_Square_Probe_Y_Minus = New System.Windows.Forms.Button()
        Me.Text_Box_Square_X_Plus = New System.Windows.Forms.TextBox()
        Me.Button_Home_XYZ = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Button_Enable_Z = New System.Windows.Forms.Button()
        Me.Button_Enable_Y = New System.Windows.Forms.Button()
        Me.Button_Enable_X = New System.Windows.Forms.Button()
        Me.Button_Home_Z = New System.Windows.Forms.Button()
        Me.Button_Home_Y = New System.Windows.Forms.Button()
        Me.Button_Home_X = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tab_Trace = New System.Windows.Forms.TabPage()
        Me.chk_Trace_Column_3 = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Column_2 = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Column_1 = New System.Windows.Forms.CheckBox()
        Me.txt_Trace = New System.Windows.Forms.TextBox()
        Me.chk_Trace_Filter_Events = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Routine_Names = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Macro_Events = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_System_Events = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Queue = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Status = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Received = New System.Windows.Forms.CheckBox()
        Me.chk_Trace_Sent = New System.Windows.Forms.CheckBox()
        Me.ts_Trace = New System.Windows.Forms.ToolStrip()
        Me.ts_Trace_Clear = New System.Windows.Forms.ToolStripButton()
        Me.ts_Trace_Refresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tab_Test = New System.Windows.Forms.TabPage()
        Me.Tab_Diagnostics = New System.Windows.Forms.TabPage()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txt_State_Previous = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txt_State_Last = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txt_State_Current = New System.Windows.Forms.TextBox()
        Me.Button_Probe_Loaded = New System.Windows.Forms.Button()
        Me.Status_Strip = New System.Windows.Forms.StatusStrip()
        Me.stat_Fault = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts_Main = New System.Windows.Forms.ToolStrip()
        Me.ts_Main_Exit = New System.Windows.Forms.ToolStripButton()
        Me.ts_Main_State = New System.Windows.Forms.ToolStripTextBox()
        Me.ts_Reset_Controller = New System.Windows.Forms.ToolStripButton()
        Me.ts_Macros = New System.Windows.Forms.ToolStripButton()
        Me.ts_Camera = New System.Windows.Forms.ToolStripButton()
        Me.ts_Download_Settings = New System.Windows.Forms.ToolStripButton()
        Me.ts_Verify_Settings = New System.Windows.Forms.ToolStripButton()
        Me.ts_Help = New System.Windows.Forms.ToolStripButton()
        Me.panel_Bottom = New System.Windows.Forms.Panel()
        Me.top_Splitter = New System.Windows.Forms.Splitter()
        Me.txt_Test = New System.Windows.Forms.TextBox()
        Me.btn_Test = New System.Windows.Forms.Button()
        Me.btn_Test_2 = New System.Windows.Forms.Button()
        Me.lab_X = New System.Windows.Forms.Label()
        Me.lab_Y = New System.Windows.Forms.Label()
        Me.lab_Z = New System.Windows.Forms.Label()
        Me.Text_Box_Work_Pos_X = New System.Windows.Forms.TextBox()
        Me.Text_Box_Work_Pos_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Work_Pos_Z = New System.Windows.Forms.TextBox()
        Me.Text_Box_Feedrate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Text_Box_Abs_Pos_X = New System.Windows.Forms.TextBox()
        Me.Text_Box_Abs_Pos_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Abs_Pos_Z = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Text_Box_Jog_Rate_Selected = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Text_Box_Velocity = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Text_Box_Offset_X = New System.Windows.Forms.TextBox()
        Me.Text_Box_Offset_Y = New System.Windows.Forms.TextBox()
        Me.Text_Box_Offset_Z = New System.Windows.Forms.TextBox()
        Me.Button_E_Stop = New System.Windows.Forms.Button()
        Me.Button_Set_X = New System.Windows.Forms.Button()
        Me.Button_Set_Y = New System.Windows.Forms.Button()
        Me.Button_Set_Z = New System.Windows.Forms.Button()
        Me.Button_Coolant = New System.Windows.Forms.Button()
        Me.Button_Spindle = New System.Windows.Forms.Button()
        Me.Button_Feed = New System.Windows.Forms.Button()
        Me.Button_Cycle = New System.Windows.Forms.Button()
        Me.Button_Goto_Home = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Button_Goto_Park = New System.Windows.Forms.Button()
        Me.Button_Goto_Tool_Change = New System.Windows.Forms.Button()
        Me.Button_GoTo_Tool_Seat = New System.Windows.Forms.Button()
        Me.Button_Homed = New System.Windows.Forms.Button()
        Me.Text_Box_Coordinate_System = New System.Windows.Forms.TextBox()
        Me.Panel_Top = New System.Windows.Forms.Panel()
        Me.Button_GoTo_Tool_Measure = New System.Windows.Forms.Button()
        Me.btn_Connected = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_Com_Port = New System.Windows.Forms.TextBox()
        Me.Tab_Main.SuspendLayout()
        Me.Tab_Gcode.SuspendLayout()
        Me.Tab_Jog_Probe.SuspendLayout()
        Me.Tab_Fixture_Offsets.SuspendLayout()
        Me.Tab_Home.SuspendLayout()
        Me.Tab_Trace.SuspendLayout()
        Me.ts_Trace.SuspendLayout()
        Me.Tab_Diagnostics.SuspendLayout()
        Me.Status_Strip.SuspendLayout()
        Me.ts_Main.SuspendLayout()
        Me.panel_Bottom.SuspendLayout()
        Me.Panel_Top.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab_Main
        '
        Me.Tab_Main.Controls.Add(Me.Tab_Gcode)
        Me.Tab_Main.Controls.Add(Me.Tab_Jog_Probe)
        Me.Tab_Main.Controls.Add(Me.Tab_Fixture_Offsets)
        Me.Tab_Main.Controls.Add(Me.Tab_Home)
        Me.Tab_Main.Controls.Add(Me.Tab_Trace)
        Me.Tab_Main.Controls.Add(Me.Tab_Test)
        Me.Tab_Main.Controls.Add(Me.Tab_Diagnostics)
        Me.Tab_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab_Main.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Main.Location = New System.Drawing.Point(0, 0)
        Me.Tab_Main.Name = "Tab_Main"
        Me.Tab_Main.SelectedIndex = 0
        Me.Tab_Main.Size = New System.Drawing.Size(1540, 640)
        Me.Tab_Main.TabIndex = 14
        '
        'Tab_Gcode
        '
        Me.Tab_Gcode.Controls.Add(Me.Process_Box)
        Me.Tab_Gcode.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Gcode.Name = "Tab_Gcode"
        Me.Tab_Gcode.Size = New System.Drawing.Size(1532, 607)
        Me.Tab_Gcode.TabIndex = 2
        Me.Tab_Gcode.Text = "G Code"
        Me.Tab_Gcode.UseVisualStyleBackColor = True
        '
        'Process_Box
        '
        Me.Process_Box.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Process_Box.Location = New System.Drawing.Point(0, 0)
        Me.Process_Box.Margin = New System.Windows.Forms.Padding(5)
        Me.Process_Box.Name = "Process_Box"
        Me.Process_Box.Size = New System.Drawing.Size(1532, 607)
        Me.Process_Box.TabIndex = 0
        '
        'Tab_Jog_Probe
        '
        Me.Tab_Jog_Probe.BackColor = System.Drawing.Color.DarkKhaki
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_File)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Folder)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Set_Gap)
        Me.Tab_Jog_Probe.Controls.Add(Me.chk_Move_Set_Gap)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Load)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Save)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Safe_Z)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label81)
        Me.Tab_Jog_Probe.Controls.Add(Me.chk_Move_Raise_Z)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Jog_Safe_Z)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label50)
        Me.Tab_Jog_Probe.Controls.Add(Me.chk_Soft_Limits)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label48)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label22)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label20)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Jog_Rate_Little_Step)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Jog_Rate_Big_Step)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Jog_Rate_Creep)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Jog_Rate_Slow)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Jog_Rate_Fast)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Rate_Little_Step)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Rate_Big_Step)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Rate_Creep)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Rate_Slow)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label7)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Rate_Fast)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Z_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Z_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_X_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_X_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Y_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Jog_Y_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Move_X_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Move_Y_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Move_Y_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Move_X_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Move_Z_Down)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Move_Z_Up)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Move_Z_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Move_Z_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Move_X_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Move_X_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Move_Y_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Move_Y_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Center)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Corner_SE)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Corner_NE)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Corner_NW)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Corner_SW)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Center_Move_To_Center)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label38)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Center_Delta_X)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label30)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Center_Delta_Y)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Center_XY)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Center_Gap_Y_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Center_Gap_Y_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Center_Gap_X_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Center_Gap_X_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label24)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Feedrate)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label25)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_State)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label3)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Diameter)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Gap_Z)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Surface_Z)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_End_Z)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label57)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Start_Z)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Gap_Y)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Surface_Y)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_End_Y)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label56)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Start_Y)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label55)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Gap_X)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label54)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Surface_X)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label53)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_End_X)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label52)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_X_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_X_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Z_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Y_Minus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Button_Probe_Y_Plus)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label23)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Start_X)
        Me.Tab_Jog_Probe.Controls.Add(Me.Text_Box_Probe_Distance)
        Me.Tab_Jog_Probe.Controls.Add(Me.Label19)
        Me.Tab_Jog_Probe.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Jog_Probe.Name = "Tab_Jog_Probe"
        Me.Tab_Jog_Probe.Size = New System.Drawing.Size(1532, 607)
        Me.Tab_Jog_Probe.TabIndex = 8
        Me.Tab_Jog_Probe.Text = "Jog & Probe"
        '
        'Text_Box_Probe_File
        '
        Me.Text_Box_Probe_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_File.Location = New System.Drawing.Point(127, 118)
        Me.Text_Box_Probe_File.Multiline = True
        Me.Text_Box_Probe_File.Name = "Text_Box_Probe_File"
        Me.Text_Box_Probe_File.Size = New System.Drawing.Size(486, 31)
        Me.Text_Box_Probe_File.TabIndex = 378
        Me.Text_Box_Probe_File.TabStop = False
        '
        'Text_Box_Probe_Folder
        '
        Me.Text_Box_Probe_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Folder.Location = New System.Drawing.Point(127, 76)
        Me.Text_Box_Probe_Folder.Multiline = True
        Me.Text_Box_Probe_Folder.Name = "Text_Box_Probe_Folder"
        Me.Text_Box_Probe_Folder.Size = New System.Drawing.Size(486, 31)
        Me.Text_Box_Probe_Folder.TabIndex = 377
        Me.Text_Box_Probe_Folder.TabStop = False
        '
        'Text_Box_Probe_Set_Gap
        '
        Me.Text_Box_Probe_Set_Gap.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Set_Gap.Location = New System.Drawing.Point(1420, 258)
        Me.Text_Box_Probe_Set_Gap.Multiline = True
        Me.Text_Box_Probe_Set_Gap.Name = "Text_Box_Probe_Set_Gap"
        Me.Text_Box_Probe_Set_Gap.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Probe_Set_Gap.TabIndex = 298
        Me.Text_Box_Probe_Set_Gap.TabStop = False
        Me.Text_Box_Probe_Set_Gap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chk_Move_Set_Gap
        '
        Me.chk_Move_Set_Gap.AutoSize = True
        Me.chk_Move_Set_Gap.Location = New System.Drawing.Point(1420, 228)
        Me.chk_Move_Set_Gap.Name = "chk_Move_Set_Gap"
        Me.chk_Move_Set_Gap.Size = New System.Drawing.Size(95, 24)
        Me.chk_Move_Set_Gap.TabIndex = 297
        Me.chk_Move_Set_Gap.Text = "Set Gap"
        Me.chk_Move_Set_Gap.UseVisualStyleBackColor = True
        '
        'Button_Probe_Load
        '
        Me.Button_Probe_Load.BackgroundImage = CType(resources.GetObject("Button_Probe_Load.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Load.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Load.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Load.Location = New System.Drawing.Point(12, 74)
        Me.Button_Probe_Load.Name = "Button_Probe_Load"
        Me.Button_Probe_Load.Size = New System.Drawing.Size(100, 39)
        Me.Button_Probe_Load.TabIndex = 296
        Me.Button_Probe_Load.TabStop = False
        Me.Button_Probe_Load.Text = "Load"
        Me.Button_Probe_Load.UseVisualStyleBackColor = True
        '
        'Button_Probe_Save
        '
        Me.Button_Probe_Save.BackgroundImage = CType(resources.GetObject("Button_Probe_Save.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Save.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Save.Location = New System.Drawing.Point(12, 118)
        Me.Button_Probe_Save.Name = "Button_Probe_Save"
        Me.Button_Probe_Save.Size = New System.Drawing.Size(100, 39)
        Me.Button_Probe_Save.TabIndex = 295
        Me.Button_Probe_Save.TabStop = False
        Me.Button_Probe_Save.Text = "Save"
        Me.Button_Probe_Save.UseVisualStyleBackColor = True
        '
        'Text_Box_Probe_Safe_Z
        '
        Me.Text_Box_Probe_Safe_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Safe_Z.Location = New System.Drawing.Point(1420, 153)
        Me.Text_Box_Probe_Safe_Z.Multiline = True
        Me.Text_Box_Probe_Safe_Z.Name = "Text_Box_Probe_Safe_Z"
        Me.Text_Box_Probe_Safe_Z.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Probe_Safe_Z.TabIndex = 292
        Me.Text_Box_Probe_Safe_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.Location = New System.Drawing.Point(1413, 120)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(81, 25)
        Me.Label81.TabIndex = 291
        Me.Label81.Text = "Safe Z"
        '
        'chk_Move_Raise_Z
        '
        Me.chk_Move_Raise_Z.AutoSize = True
        Me.chk_Move_Raise_Z.Location = New System.Drawing.Point(1419, 423)
        Me.chk_Move_Raise_Z.Name = "chk_Move_Raise_Z"
        Me.chk_Move_Raise_Z.Size = New System.Drawing.Size(90, 24)
        Me.chk_Move_Raise_Z.TabIndex = 290
        Me.chk_Move_Raise_Z.Text = "Raise Z"
        Me.chk_Move_Raise_Z.UseVisualStyleBackColor = True
        '
        'Text_Box_Jog_Safe_Z
        '
        Me.Text_Box_Jog_Safe_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Jog_Safe_Z.Location = New System.Drawing.Point(648, 439)
        Me.Text_Box_Jog_Safe_Z.Multiline = True
        Me.Text_Box_Jog_Safe_Z.Name = "Text_Box_Jog_Safe_Z"
        Me.Text_Box_Jog_Safe_Z.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Jog_Safe_Z.TabIndex = 287
        Me.Text_Box_Jog_Safe_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(641, 406)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(81, 25)
        Me.Label50.TabIndex = 286
        Me.Label50.Text = "Safe Z"
        '
        'chk_Soft_Limits
        '
        Me.chk_Soft_Limits.AutoSize = True
        Me.chk_Soft_Limits.Location = New System.Drawing.Point(424, 319)
        Me.chk_Soft_Limits.Name = "chk_Soft_Limits"
        Me.chk_Soft_Limits.Size = New System.Drawing.Size(119, 24)
        Me.chk_Soft_Limits.TabIndex = 285
        Me.chk_Soft_Limits.Text = "Soft_Limits"
        Me.chk_Soft_Limits.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(1400, 17)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(74, 25)
        Me.Label48.TabIndex = 283
        Me.Label48.Text = "Probe"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(1413, 383)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(69, 25)
        Me.Label22.TabIndex = 282
        Me.Label22.Text = "Move"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(337, 319)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 25)
        Me.Label20.TabIndex = 281
        Me.Label20.Text = "Jog"
        '
        'Text_Box_Jog_Rate_Little_Step
        '
        Me.Text_Box_Jog_Rate_Little_Step.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Jog_Rate_Little_Step.Location = New System.Drawing.Point(26, 494)
        Me.Text_Box_Jog_Rate_Little_Step.Multiline = True
        Me.Text_Box_Jog_Rate_Little_Step.Name = "Text_Box_Jog_Rate_Little_Step"
        Me.Text_Box_Jog_Rate_Little_Step.Size = New System.Drawing.Size(64, 31)
        Me.Text_Box_Jog_Rate_Little_Step.TabIndex = 280
        Me.Text_Box_Jog_Rate_Little_Step.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Jog_Rate_Big_Step
        '
        Me.Text_Box_Jog_Rate_Big_Step.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Jog_Rate_Big_Step.Location = New System.Drawing.Point(26, 459)
        Me.Text_Box_Jog_Rate_Big_Step.Multiline = True
        Me.Text_Box_Jog_Rate_Big_Step.Name = "Text_Box_Jog_Rate_Big_Step"
        Me.Text_Box_Jog_Rate_Big_Step.Size = New System.Drawing.Size(64, 31)
        Me.Text_Box_Jog_Rate_Big_Step.TabIndex = 279
        Me.Text_Box_Jog_Rate_Big_Step.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Jog_Rate_Creep
        '
        Me.Text_Box_Jog_Rate_Creep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Jog_Rate_Creep.Location = New System.Drawing.Point(26, 424)
        Me.Text_Box_Jog_Rate_Creep.Multiline = True
        Me.Text_Box_Jog_Rate_Creep.Name = "Text_Box_Jog_Rate_Creep"
        Me.Text_Box_Jog_Rate_Creep.Size = New System.Drawing.Size(64, 31)
        Me.Text_Box_Jog_Rate_Creep.TabIndex = 278
        Me.Text_Box_Jog_Rate_Creep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Jog_Rate_Slow
        '
        Me.Text_Box_Jog_Rate_Slow.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Jog_Rate_Slow.Location = New System.Drawing.Point(25, 389)
        Me.Text_Box_Jog_Rate_Slow.Multiline = True
        Me.Text_Box_Jog_Rate_Slow.Name = "Text_Box_Jog_Rate_Slow"
        Me.Text_Box_Jog_Rate_Slow.Size = New System.Drawing.Size(64, 31)
        Me.Text_Box_Jog_Rate_Slow.TabIndex = 277
        Me.Text_Box_Jog_Rate_Slow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Jog_Rate_Fast
        '
        Me.Text_Box_Jog_Rate_Fast.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Jog_Rate_Fast.Location = New System.Drawing.Point(26, 354)
        Me.Text_Box_Jog_Rate_Fast.Multiline = True
        Me.Text_Box_Jog_Rate_Fast.Name = "Text_Box_Jog_Rate_Fast"
        Me.Text_Box_Jog_Rate_Fast.Size = New System.Drawing.Size(64, 31)
        Me.Text_Box_Jog_Rate_Fast.TabIndex = 276
        Me.Text_Box_Jog_Rate_Fast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Jog_Rate_Little_Step
        '
        Me.Button_Jog_Rate_Little_Step.BackgroundImage = CType(resources.GetObject("Button_Jog_Rate_Little_Step.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Rate_Little_Step.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Rate_Little_Step.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Rate_Little_Step.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Rate_Little_Step.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Rate_Little_Step.Location = New System.Drawing.Point(96, 494)
        Me.Button_Jog_Rate_Little_Step.Name = "Button_Jog_Rate_Little_Step"
        Me.Button_Jog_Rate_Little_Step.Size = New System.Drawing.Size(97, 29)
        Me.Button_Jog_Rate_Little_Step.TabIndex = 275
        Me.Button_Jog_Rate_Little_Step.Text = "Little"
        Me.Button_Jog_Rate_Little_Step.UseVisualStyleBackColor = True
        '
        'Button_Jog_Rate_Big_Step
        '
        Me.Button_Jog_Rate_Big_Step.BackgroundImage = CType(resources.GetObject("Button_Jog_Rate_Big_Step.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Rate_Big_Step.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Rate_Big_Step.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Rate_Big_Step.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Rate_Big_Step.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Rate_Big_Step.Location = New System.Drawing.Point(95, 459)
        Me.Button_Jog_Rate_Big_Step.Name = "Button_Jog_Rate_Big_Step"
        Me.Button_Jog_Rate_Big_Step.Size = New System.Drawing.Size(97, 29)
        Me.Button_Jog_Rate_Big_Step.TabIndex = 274
        Me.Button_Jog_Rate_Big_Step.Text = "Big"
        Me.Button_Jog_Rate_Big_Step.UseVisualStyleBackColor = True
        '
        'Button_Jog_Rate_Creep
        '
        Me.Button_Jog_Rate_Creep.BackgroundImage = CType(resources.GetObject("Button_Jog_Rate_Creep.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Rate_Creep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Rate_Creep.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Rate_Creep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Rate_Creep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Rate_Creep.Location = New System.Drawing.Point(96, 424)
        Me.Button_Jog_Rate_Creep.Name = "Button_Jog_Rate_Creep"
        Me.Button_Jog_Rate_Creep.Size = New System.Drawing.Size(97, 29)
        Me.Button_Jog_Rate_Creep.TabIndex = 273
        Me.Button_Jog_Rate_Creep.Text = "Creep"
        Me.Button_Jog_Rate_Creep.UseVisualStyleBackColor = True
        '
        'Button_Jog_Rate_Slow
        '
        Me.Button_Jog_Rate_Slow.BackgroundImage = CType(resources.GetObject("Button_Jog_Rate_Slow.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Rate_Slow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Rate_Slow.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Rate_Slow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Rate_Slow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Rate_Slow.Location = New System.Drawing.Point(95, 389)
        Me.Button_Jog_Rate_Slow.Name = "Button_Jog_Rate_Slow"
        Me.Button_Jog_Rate_Slow.Size = New System.Drawing.Size(97, 29)
        Me.Button_Jog_Rate_Slow.TabIndex = 272
        Me.Button_Jog_Rate_Slow.Text = "Slow"
        Me.Button_Jog_Rate_Slow.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(48, 325)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 25)
        Me.Label7.TabIndex = 271
        Me.Label7.Text = "Jog Rate"
        '
        'Button_Jog_Rate_Fast
        '
        Me.Button_Jog_Rate_Fast.BackgroundImage = CType(resources.GetObject("Button_Jog_Rate_Fast.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Rate_Fast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Rate_Fast.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Rate_Fast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Rate_Fast.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Rate_Fast.Location = New System.Drawing.Point(96, 354)
        Me.Button_Jog_Rate_Fast.Name = "Button_Jog_Rate_Fast"
        Me.Button_Jog_Rate_Fast.Size = New System.Drawing.Size(97, 29)
        Me.Button_Jog_Rate_Fast.TabIndex = 269
        Me.Button_Jog_Rate_Fast.Text = "Fast"
        Me.Button_Jog_Rate_Fast.UseVisualStyleBackColor = True
        '
        'Button_Jog_Z_Plus
        '
        Me.Button_Jog_Z_Plus.BackgroundImage = CType(resources.GetObject("Button_Jog_Z_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Z_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Z_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Z_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Z_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Z_Plus.Location = New System.Drawing.Point(530, 352)
        Me.Button_Jog_Z_Plus.Name = "Button_Jog_Z_Plus"
        Me.Button_Jog_Z_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Jog_Z_Plus.TabIndex = 270
        Me.Button_Jog_Z_Plus.TabStop = False
        Me.Button_Jog_Z_Plus.Text = "Z"
        Me.Button_Jog_Z_Plus.UseVisualStyleBackColor = True
        '
        'Button_Jog_Z_Minus
        '
        Me.Button_Jog_Z_Minus.BackgroundImage = CType(resources.GetObject("Button_Jog_Z_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Z_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Z_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Z_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Z_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Z_Minus.Location = New System.Drawing.Point(530, 457)
        Me.Button_Jog_Z_Minus.Name = "Button_Jog_Z_Minus"
        Me.Button_Jog_Z_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Jog_Z_Minus.TabIndex = 268
        Me.Button_Jog_Z_Minus.TabStop = False
        Me.Button_Jog_Z_Minus.Text = "Z"
        Me.Button_Jog_Z_Minus.UseVisualStyleBackColor = True
        '
        'Button_Jog_X_Minus
        '
        Me.Button_Jog_X_Minus.BackgroundImage = CType(resources.GetObject("Button_Jog_X_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_X_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_X_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Jog_X_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_X_Minus.Location = New System.Drawing.Point(212, 401)
        Me.Button_Jog_X_Minus.Name = "Button_Jog_X_Minus"
        Me.Button_Jog_X_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Jog_X_Minus.TabIndex = 267
        Me.Button_Jog_X_Minus.TabStop = False
        Me.Button_Jog_X_Minus.Text = "X"
        Me.Button_Jog_X_Minus.UseVisualStyleBackColor = True
        '
        'Button_Jog_X_Plus
        '
        Me.Button_Jog_X_Plus.BackgroundImage = CType(resources.GetObject("Button_Jog_X_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_X_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_X_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Jog_X_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_X_Plus.Location = New System.Drawing.Point(424, 401)
        Me.Button_Jog_X_Plus.Name = "Button_Jog_X_Plus"
        Me.Button_Jog_X_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Jog_X_Plus.TabIndex = 266
        Me.Button_Jog_X_Plus.TabStop = False
        Me.Button_Jog_X_Plus.Text = "X"
        Me.Button_Jog_X_Plus.UseVisualStyleBackColor = True
        '
        'Button_Jog_Y_Minus
        '
        Me.Button_Jog_Y_Minus.BackgroundImage = CType(resources.GetObject("Button_Jog_Y_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Y_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Y_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Y_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Y_Minus.Location = New System.Drawing.Point(318, 453)
        Me.Button_Jog_Y_Minus.Name = "Button_Jog_Y_Minus"
        Me.Button_Jog_Y_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Jog_Y_Minus.TabIndex = 265
        Me.Button_Jog_Y_Minus.TabStop = False
        Me.Button_Jog_Y_Minus.Text = "Y"
        Me.Button_Jog_Y_Minus.UseVisualStyleBackColor = True
        '
        'Button_Jog_Y_Plus
        '
        Me.Button_Jog_Y_Plus.BackgroundImage = CType(resources.GetObject("Button_Jog_Y_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Jog_Y_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Jog_Y_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Jog_Y_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Jog_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Jog_Y_Plus.Location = New System.Drawing.Point(317, 348)
        Me.Button_Jog_Y_Plus.Name = "Button_Jog_Y_Plus"
        Me.Button_Jog_Y_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Jog_Y_Plus.TabIndex = 264
        Me.Button_Jog_Y_Plus.TabStop = False
        Me.Button_Jog_Y_Plus.Text = "Y"
        Me.Button_Jog_Y_Plus.UseVisualStyleBackColor = True
        '
        'Text_Box_Move_X_Plus
        '
        Me.Text_Box_Move_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Move_X_Plus.Location = New System.Drawing.Point(1297, 380)
        Me.Text_Box_Move_X_Plus.Multiline = True
        Me.Text_Box_Move_X_Plus.Name = "Text_Box_Move_X_Plus"
        Me.Text_Box_Move_X_Plus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Move_X_Plus.TabIndex = 263
        Me.Text_Box_Move_X_Plus.TabStop = False
        Me.Text_Box_Move_X_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Move_Y_Plus
        '
        Me.Text_Box_Move_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Move_Y_Plus.Location = New System.Drawing.Point(1190, 328)
        Me.Text_Box_Move_Y_Plus.Multiline = True
        Me.Text_Box_Move_Y_Plus.Name = "Text_Box_Move_Y_Plus"
        Me.Text_Box_Move_Y_Plus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Move_Y_Plus.TabIndex = 262
        Me.Text_Box_Move_Y_Plus.TabStop = False
        Me.Text_Box_Move_Y_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Move_Y_Minus
        '
        Me.Text_Box_Move_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Move_Y_Minus.Location = New System.Drawing.Point(1190, 569)
        Me.Text_Box_Move_Y_Minus.Multiline = True
        Me.Text_Box_Move_Y_Minus.Name = "Text_Box_Move_Y_Minus"
        Me.Text_Box_Move_Y_Minus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Move_Y_Minus.TabIndex = 261
        Me.Text_Box_Move_Y_Minus.TabStop = False
        Me.Text_Box_Move_Y_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Move_X_Minus
        '
        Me.Text_Box_Move_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Move_X_Minus.Location = New System.Drawing.Point(1085, 381)
        Me.Text_Box_Move_X_Minus.Multiline = True
        Me.Text_Box_Move_X_Minus.Name = "Text_Box_Move_X_Minus"
        Me.Text_Box_Move_X_Minus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Move_X_Minus.TabIndex = 214
        Me.Text_Box_Move_X_Minus.TabStop = False
        Me.Text_Box_Move_X_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Move_Z_Down
        '
        Me.Text_Box_Move_Z_Down.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Move_Z_Down.Location = New System.Drawing.Point(890, 535)
        Me.Text_Box_Move_Z_Down.Multiline = True
        Me.Text_Box_Move_Z_Down.Name = "Text_Box_Move_Z_Down"
        Me.Text_Box_Move_Z_Down.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Move_Z_Down.TabIndex = 260
        Me.Text_Box_Move_Z_Down.TabStop = False
        Me.Text_Box_Move_Z_Down.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Move_Z_Up
        '
        Me.Text_Box_Move_Z_Up.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Move_Z_Up.Location = New System.Drawing.Point(890, 361)
        Me.Text_Box_Move_Z_Up.Multiline = True
        Me.Text_Box_Move_Z_Up.Name = "Text_Box_Move_Z_Up"
        Me.Text_Box_Move_Z_Up.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Move_Z_Up.TabIndex = 258
        Me.Text_Box_Move_Z_Up.TabStop = False
        Me.Text_Box_Move_Z_Up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Move_Z_Plus
        '
        Me.Button_Move_Z_Plus.BackgroundImage = CType(resources.GetObject("Button_Move_Z_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Move_Z_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Move_Z_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Move_Z_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Move_Z_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Move_Z_Plus.Location = New System.Drawing.Point(979, 361)
        Me.Button_Move_Z_Plus.Name = "Button_Move_Z_Plus"
        Me.Button_Move_Z_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Move_Z_Plus.TabIndex = 257
        Me.Button_Move_Z_Plus.Text = "Z"
        Me.Button_Move_Z_Plus.UseVisualStyleBackColor = True
        '
        'Button_Move_Z_Minus
        '
        Me.Button_Move_Z_Minus.BackgroundImage = CType(resources.GetObject("Button_Move_Z_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Move_Z_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Move_Z_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Move_Z_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Move_Z_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Move_Z_Minus.Location = New System.Drawing.Point(979, 466)
        Me.Button_Move_Z_Minus.Name = "Button_Move_Z_Minus"
        Me.Button_Move_Z_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Move_Z_Minus.TabIndex = 256
        Me.Button_Move_Z_Minus.Text = "Z"
        Me.Button_Move_Z_Minus.UseVisualStyleBackColor = True
        '
        'Button_Move_X_Minus
        '
        Me.Button_Move_X_Minus.BackgroundImage = CType(resources.GetObject("Button_Move_X_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Move_X_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Move_X_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Move_X_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Move_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Move_X_Minus.Location = New System.Drawing.Point(1085, 414)
        Me.Button_Move_X_Minus.Name = "Button_Move_X_Minus"
        Me.Button_Move_X_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Move_X_Minus.TabIndex = 255
        Me.Button_Move_X_Minus.Text = "X"
        Me.Button_Move_X_Minus.UseVisualStyleBackColor = True
        '
        'Button_Move_X_Plus
        '
        Me.Button_Move_X_Plus.BackgroundImage = CType(resources.GetObject("Button_Move_X_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Move_X_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Move_X_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Move_X_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Move_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Move_X_Plus.Location = New System.Drawing.Point(1297, 414)
        Me.Button_Move_X_Plus.Name = "Button_Move_X_Plus"
        Me.Button_Move_X_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Move_X_Plus.TabIndex = 254
        Me.Button_Move_X_Plus.Text = "X"
        Me.Button_Move_X_Plus.UseVisualStyleBackColor = True
        '
        'Button_Move_Y_Minus
        '
        Me.Button_Move_Y_Minus.BackgroundImage = CType(resources.GetObject("Button_Move_Y_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Move_Y_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Move_Y_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Move_Y_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Move_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Move_Y_Minus.Location = New System.Drawing.Point(1190, 466)
        Me.Button_Move_Y_Minus.Name = "Button_Move_Y_Minus"
        Me.Button_Move_Y_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Move_Y_Minus.TabIndex = 253
        Me.Button_Move_Y_Minus.Text = "Y"
        Me.Button_Move_Y_Minus.UseVisualStyleBackColor = True
        '
        'Button_Move_Y_Plus
        '
        Me.Button_Move_Y_Plus.BackgroundImage = CType(resources.GetObject("Button_Move_Y_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Move_Y_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Move_Y_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Move_Y_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Move_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Move_Y_Plus.Location = New System.Drawing.Point(1190, 361)
        Me.Button_Move_Y_Plus.Name = "Button_Move_Y_Plus"
        Me.Button_Move_Y_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Move_Y_Plus.TabIndex = 252
        Me.Button_Move_Y_Plus.Text = "Y"
        Me.Button_Move_Y_Plus.UseVisualStyleBackColor = True
        '
        'Button_Probe_Center
        '
        Me.Button_Probe_Center.BackgroundImage = CType(resources.GetObject("Button_Probe_Center.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Center.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Center.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Center.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Center.Location = New System.Drawing.Point(727, 9)
        Me.Button_Probe_Center.Name = "Button_Probe_Center"
        Me.Button_Probe_Center.Size = New System.Drawing.Size(171, 39)
        Me.Button_Probe_Center.TabIndex = 251
        Me.Button_Probe_Center.TabStop = False
        Me.Button_Probe_Center.Text = "Find Center"
        Me.Button_Probe_Center.UseVisualStyleBackColor = True
        '
        'Button_Probe_Corner_SE
        '
        Me.Button_Probe_Corner_SE.BackgroundImage = CType(resources.GetObject("Button_Probe_Corner_SE.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Corner_SE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Corner_SE.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Corner_SE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Corner_SE.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Corner_SE.ForeColor = System.Drawing.Color.OrangeRed
        Me.Button_Probe_Corner_SE.Location = New System.Drawing.Point(1296, 224)
        Me.Button_Probe_Corner_SE.Name = "Button_Probe_Corner_SE"
        Me.Button_Probe_Corner_SE.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_Corner_SE.TabIndex = 250
        Me.Button_Probe_Corner_SE.UseVisualStyleBackColor = True
        '
        'Button_Probe_Corner_NE
        '
        Me.Button_Probe_Corner_NE.BackgroundImage = CType(resources.GetObject("Button_Probe_Corner_NE.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Corner_NE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Corner_NE.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Corner_NE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Corner_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Corner_NE.Location = New System.Drawing.Point(1296, 13)
        Me.Button_Probe_Corner_NE.Name = "Button_Probe_Corner_NE"
        Me.Button_Probe_Corner_NE.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_Corner_NE.TabIndex = 249
        Me.Button_Probe_Corner_NE.UseVisualStyleBackColor = True
        '
        'Button_Probe_Corner_NW
        '
        Me.Button_Probe_Corner_NW.BackgroundImage = CType(resources.GetObject("Button_Probe_Corner_NW.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Corner_NW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Corner_NW.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Corner_NW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Corner_NW.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Corner_NW.Location = New System.Drawing.Point(1084, 12)
        Me.Button_Probe_Corner_NW.Name = "Button_Probe_Corner_NW"
        Me.Button_Probe_Corner_NW.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_Corner_NW.TabIndex = 248
        Me.Button_Probe_Corner_NW.UseVisualStyleBackColor = True
        '
        'Button_Probe_Corner_SW
        '
        Me.Button_Probe_Corner_SW.BackgroundImage = CType(resources.GetObject("Button_Probe_Corner_SW.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Corner_SW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Corner_SW.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Corner_SW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Corner_SW.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Corner_SW.Location = New System.Drawing.Point(1084, 223)
        Me.Button_Probe_Corner_SW.Name = "Button_Probe_Corner_SW"
        Me.Button_Probe_Corner_SW.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_Corner_SW.TabIndex = 247
        Me.Button_Probe_Corner_SW.UseVisualStyleBackColor = True
        '
        'Button_Probe_Center_Move_To_Center
        '
        Me.Button_Probe_Center_Move_To_Center.BackgroundImage = CType(resources.GetObject("Button_Probe_Center_Move_To_Center.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Center_Move_To_Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Center_Move_To_Center.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Center_Move_To_Center.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Center_Move_To_Center.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Center_Move_To_Center.Location = New System.Drawing.Point(727, 206)
        Me.Button_Probe_Center_Move_To_Center.Name = "Button_Probe_Center_Move_To_Center"
        Me.Button_Probe_Center_Move_To_Center.Size = New System.Drawing.Size(171, 39)
        Me.Button_Probe_Center_Move_To_Center.TabIndex = 239
        Me.Button_Probe_Center_Move_To_Center.TabStop = False
        Me.Button_Probe_Center_Move_To_Center.Text = "Move to Center"
        Me.Button_Probe_Center_Move_To_Center.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(982, 60)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(67, 25)
        Me.Label38.TabIndex = 238
        Me.Label38.Text = "Delta"
        '
        'Text_Box_Probe_Center_Delta_X
        '
        Me.Text_Box_Probe_Center_Delta_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Center_Delta_X.Location = New System.Drawing.Point(982, 94)
        Me.Text_Box_Probe_Center_Delta_X.Multiline = True
        Me.Text_Box_Probe_Center_Delta_X.Name = "Text_Box_Probe_Center_Delta_X"
        Me.Text_Box_Probe_Center_Delta_X.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Probe_Center_Delta_X.TabIndex = 237
        Me.Text_Box_Probe_Center_Delta_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(873, 165)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(67, 25)
        Me.Label30.TabIndex = 236
        Me.Label30.Text = "Delta"
        '
        'Text_Box_Probe_Center_Delta_Y
        '
        Me.Text_Box_Probe_Center_Delta_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Center_Delta_Y.Location = New System.Drawing.Point(771, 168)
        Me.Text_Box_Probe_Center_Delta_Y.Multiline = True
        Me.Text_Box_Probe_Center_Delta_Y.Name = "Text_Box_Probe_Center_Delta_Y"
        Me.Text_Box_Probe_Center_Delta_Y.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Probe_Center_Delta_Y.TabIndex = 235
        Me.Text_Box_Probe_Center_Delta_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Center_XY
        '
        Me.Text_Box_Probe_Center_XY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Center_XY.Location = New System.Drawing.Point(737, 94)
        Me.Text_Box_Probe_Center_XY.Multiline = True
        Me.Text_Box_Probe_Center_XY.Name = "Text_Box_Probe_Center_XY"
        Me.Text_Box_Probe_Center_XY.Size = New System.Drawing.Size(151, 31)
        Me.Text_Box_Probe_Center_XY.TabIndex = 233
        Me.Text_Box_Probe_Center_XY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Center_Gap_Y_Minus
        '
        Me.Text_Box_Probe_Center_Gap_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Center_Gap_Y_Minus.Location = New System.Drawing.Point(771, 131)
        Me.Text_Box_Probe_Center_Gap_Y_Minus.Multiline = True
        Me.Text_Box_Probe_Center_Gap_Y_Minus.Name = "Text_Box_Probe_Center_Gap_Y_Minus"
        Me.Text_Box_Probe_Center_Gap_Y_Minus.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Probe_Center_Gap_Y_Minus.TabIndex = 232
        Me.Text_Box_Probe_Center_Gap_Y_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Center_Gap_Y_Plus
        '
        Me.Text_Box_Probe_Center_Gap_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Center_Gap_Y_Plus.Location = New System.Drawing.Point(771, 57)
        Me.Text_Box_Probe_Center_Gap_Y_Plus.Multiline = True
        Me.Text_Box_Probe_Center_Gap_Y_Plus.Name = "Text_Box_Probe_Center_Gap_Y_Plus"
        Me.Text_Box_Probe_Center_Gap_Y_Plus.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Probe_Center_Gap_Y_Plus.TabIndex = 231
        Me.Text_Box_Probe_Center_Gap_Y_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Center_Gap_X_Plus
        '
        Me.Text_Box_Probe_Center_Gap_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Center_Gap_X_Plus.Location = New System.Drawing.Point(891, 94)
        Me.Text_Box_Probe_Center_Gap_X_Plus.Multiline = True
        Me.Text_Box_Probe_Center_Gap_X_Plus.Name = "Text_Box_Probe_Center_Gap_X_Plus"
        Me.Text_Box_Probe_Center_Gap_X_Plus.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Probe_Center_Gap_X_Plus.TabIndex = 230
        Me.Text_Box_Probe_Center_Gap_X_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Center_Gap_X_Minus
        '
        Me.Text_Box_Probe_Center_Gap_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Center_Gap_X_Minus.Location = New System.Drawing.Point(647, 94)
        Me.Text_Box_Probe_Center_Gap_X_Minus.Multiline = True
        Me.Text_Box_Probe_Center_Gap_X_Minus.Name = "Text_Box_Probe_Center_Gap_X_Minus"
        Me.Text_Box_Probe_Center_Gap_X_Minus.Size = New System.Drawing.Size(87, 31)
        Me.Text_Box_Probe_Center_Gap_X_Minus.TabIndex = 229
        Me.Text_Box_Probe_Center_Gap_X_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(514, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(106, 25)
        Me.Label24.TabIndex = 224
        Me.Label24.Text = "Diameter"
        '
        'Text_Box_Probe_Feedrate
        '
        Me.Text_Box_Probe_Feedrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Feedrate.Location = New System.Drawing.Point(419, 37)
        Me.Text_Box_Probe_Feedrate.Multiline = True
        Me.Text_Box_Probe_Feedrate.Name = "Text_Box_Probe_Feedrate"
        Me.Text_Box_Probe_Feedrate.Size = New System.Drawing.Size(92, 31)
        Me.Text_Box_Probe_Feedrate.TabIndex = 222
        Me.Text_Box_Probe_Feedrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(433, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 25)
        Me.Label25.TabIndex = 223
        Me.Label25.Text = "Feed"
        '
        'Text_Box_Probe_State
        '
        Me.Text_Box_Probe_State.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_State.Location = New System.Drawing.Point(8, 37)
        Me.Text_Box_Probe_State.Multiline = True
        Me.Text_Box_Probe_State.Name = "Text_Box_Probe_State"
        Me.Text_Box_Probe_State.Size = New System.Drawing.Size(300, 31)
        Me.Text_Box_Probe_State.TabIndex = 218
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 25)
        Me.Label3.TabIndex = 217
        Me.Label3.Text = "State"
        '
        'Text_Box_Probe_Diameter
        '
        Me.Text_Box_Probe_Diameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Diameter.Location = New System.Drawing.Point(521, 37)
        Me.Text_Box_Probe_Diameter.Multiline = True
        Me.Text_Box_Probe_Diameter.Name = "Text_Box_Probe_Diameter"
        Me.Text_Box_Probe_Diameter.Size = New System.Drawing.Size(92, 31)
        Me.Text_Box_Probe_Diameter.TabIndex = 216
        Me.Text_Box_Probe_Diameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Gap_Z
        '
        Me.Text_Box_Probe_Gap_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Gap_Z.Location = New System.Drawing.Point(235, 280)
        Me.Text_Box_Probe_Gap_Z.Multiline = True
        Me.Text_Box_Probe_Gap_Z.Name = "Text_Box_Probe_Gap_Z"
        Me.Text_Box_Probe_Gap_Z.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Gap_Z.TabIndex = 214
        Me.Text_Box_Probe_Gap_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Surface_Z
        '
        Me.Text_Box_Probe_Surface_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Surface_Z.Location = New System.Drawing.Point(324, 280)
        Me.Text_Box_Probe_Surface_Z.Multiline = True
        Me.Text_Box_Probe_Surface_Z.Name = "Text_Box_Probe_Surface_Z"
        Me.Text_Box_Probe_Surface_Z.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Surface_Z.TabIndex = 213
        Me.Text_Box_Probe_Surface_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_End_Z
        '
        Me.Text_Box_Probe_End_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_End_Z.Location = New System.Drawing.Point(146, 280)
        Me.Text_Box_Probe_End_Z.Multiline = True
        Me.Text_Box_Probe_End_Z.Name = "Text_Box_Probe_End_Z"
        Me.Text_Box_Probe_End_Z.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_End_Z.TabIndex = 212
        Me.Text_Box_Probe_End_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(18, 280)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(32, 31)
        Me.Label57.TabIndex = 211
        Me.Label57.Text = "Z"
        '
        'Text_Box_Probe_Start_Z
        '
        Me.Text_Box_Probe_Start_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Start_Z.Location = New System.Drawing.Point(57, 280)
        Me.Text_Box_Probe_Start_Z.Multiline = True
        Me.Text_Box_Probe_Start_Z.Name = "Text_Box_Probe_Start_Z"
        Me.Text_Box_Probe_Start_Z.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Start_Z.TabIndex = 210
        Me.Text_Box_Probe_Start_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Gap_Y
        '
        Me.Text_Box_Probe_Gap_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Gap_Y.Location = New System.Drawing.Point(235, 237)
        Me.Text_Box_Probe_Gap_Y.Multiline = True
        Me.Text_Box_Probe_Gap_Y.Name = "Text_Box_Probe_Gap_Y"
        Me.Text_Box_Probe_Gap_Y.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Gap_Y.TabIndex = 209
        Me.Text_Box_Probe_Gap_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Surface_Y
        '
        Me.Text_Box_Probe_Surface_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Surface_Y.Location = New System.Drawing.Point(324, 237)
        Me.Text_Box_Probe_Surface_Y.Multiline = True
        Me.Text_Box_Probe_Surface_Y.Name = "Text_Box_Probe_Surface_Y"
        Me.Text_Box_Probe_Surface_Y.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Surface_Y.TabIndex = 208
        Me.Text_Box_Probe_Surface_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_End_Y
        '
        Me.Text_Box_Probe_End_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_End_Y.Location = New System.Drawing.Point(146, 237)
        Me.Text_Box_Probe_End_Y.Multiline = True
        Me.Text_Box_Probe_End_Y.Name = "Text_Box_Probe_End_Y"
        Me.Text_Box_Probe_End_Y.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_End_Y.TabIndex = 207
        Me.Text_Box_Probe_End_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(18, 237)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(33, 31)
        Me.Label56.TabIndex = 206
        Me.Label56.Text = "Y"
        '
        'Text_Box_Probe_Start_Y
        '
        Me.Text_Box_Probe_Start_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Start_Y.Location = New System.Drawing.Point(57, 237)
        Me.Text_Box_Probe_Start_Y.Multiline = True
        Me.Text_Box_Probe_Start_Y.Name = "Text_Box_Probe_Start_Y"
        Me.Text_Box_Probe_Start_Y.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Start_Y.TabIndex = 205
        Me.Text_Box_Probe_Start_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(242, 160)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(55, 25)
        Me.Label55.TabIndex = 204
        Me.Label55.Text = "Gap"
        '
        'Text_Box_Probe_Gap_X
        '
        Me.Text_Box_Probe_Gap_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Gap_X.Location = New System.Drawing.Point(235, 194)
        Me.Text_Box_Probe_Gap_X.Multiline = True
        Me.Text_Box_Probe_Gap_X.Name = "Text_Box_Probe_Gap_X"
        Me.Text_Box_Probe_Gap_X.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Gap_X.TabIndex = 203
        Me.Text_Box_Probe_Gap_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(308, 160)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(93, 25)
        Me.Label54.TabIndex = 202
        Me.Label54.Text = "Surface"
        '
        'Text_Box_Probe_Surface_X
        '
        Me.Text_Box_Probe_Surface_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Surface_X.Location = New System.Drawing.Point(324, 194)
        Me.Text_Box_Probe_Surface_X.Multiline = True
        Me.Text_Box_Probe_Surface_X.Name = "Text_Box_Probe_Surface_X"
        Me.Text_Box_Probe_Surface_X.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Surface_X.TabIndex = 201
        Me.Text_Box_Probe_Surface_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(155, 160)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(53, 25)
        Me.Label53.TabIndex = 200
        Me.Label53.Text = "End"
        '
        'Text_Box_Probe_End_X
        '
        Me.Text_Box_Probe_End_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_End_X.Location = New System.Drawing.Point(146, 194)
        Me.Text_Box_Probe_End_X.Multiline = True
        Me.Text_Box_Probe_End_X.Name = "Text_Box_Probe_End_X"
        Me.Text_Box_Probe_End_X.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_End_X.TabIndex = 199
        Me.Text_Box_Probe_End_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(60, 160)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(62, 25)
        Me.Label52.TabIndex = 198
        Me.Label52.Text = "Start"
        '
        'Button_Probe_X_Minus
        '
        Me.Button_Probe_X_Minus.BackgroundImage = CType(resources.GetObject("Button_Probe_X_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_X_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_X_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Probe_X_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_X_Minus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Probe_X_Minus.Location = New System.Drawing.Point(1084, 118)
        Me.Button_Probe_X_Minus.Name = "Button_Probe_X_Minus"
        Me.Button_Probe_X_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_X_Minus.TabIndex = 186
        Me.Button_Probe_X_Minus.Text = "X"
        Me.Button_Probe_X_Minus.UseVisualStyleBackColor = True
        '
        'Button_Probe_X_Plus
        '
        Me.Button_Probe_X_Plus.BackgroundImage = CType(resources.GetObject("Button_Probe_X_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_X_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_X_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Probe_X_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_X_Plus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Probe_X_Plus.Location = New System.Drawing.Point(1296, 118)
        Me.Button_Probe_X_Plus.Name = "Button_Probe_X_Plus"
        Me.Button_Probe_X_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_X_Plus.TabIndex = 185
        Me.Button_Probe_X_Plus.Text = "X"
        Me.Button_Probe_X_Plus.UseVisualStyleBackColor = True
        '
        'Button_Probe_Z_Minus
        '
        Me.Button_Probe_Z_Minus.BackgroundImage = CType(resources.GetObject("Button_Probe_Z_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Z_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Z_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Z_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Z_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Z_Minus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Probe_Z_Minus.Location = New System.Drawing.Point(1190, 117)
        Me.Button_Probe_Z_Minus.Name = "Button_Probe_Z_Minus"
        Me.Button_Probe_Z_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_Z_Minus.TabIndex = 173
        Me.Button_Probe_Z_Minus.Text = "Z"
        Me.Button_Probe_Z_Minus.UseVisualStyleBackColor = True
        '
        'Button_Probe_Y_Minus
        '
        Me.Button_Probe_Y_Minus.BackgroundImage = CType(resources.GetObject("Button_Probe_Y_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Y_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Y_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Y_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Y_Minus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Probe_Y_Minus.Location = New System.Drawing.Point(1190, 223)
        Me.Button_Probe_Y_Minus.Name = "Button_Probe_Y_Minus"
        Me.Button_Probe_Y_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_Y_Minus.TabIndex = 170
        Me.Button_Probe_Y_Minus.Text = "Y"
        Me.Button_Probe_Y_Minus.UseVisualStyleBackColor = True
        '
        'Button_Probe_Y_Plus
        '
        Me.Button_Probe_Y_Plus.BackgroundImage = CType(resources.GetObject("Button_Probe_Y_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Y_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Y_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Y_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Y_Plus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Probe_Y_Plus.Location = New System.Drawing.Point(1190, 13)
        Me.Button_Probe_Y_Plus.Name = "Button_Probe_Y_Plus"
        Me.Button_Probe_Y_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Probe_Y_Plus.TabIndex = 169
        Me.Button_Probe_Y_Plus.Text = "Y"
        Me.Button_Probe_Y_Plus.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(18, 194)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 31)
        Me.Label23.TabIndex = 165
        Me.Label23.Text = "X"
        '
        'Text_Box_Probe_Start_X
        '
        Me.Text_Box_Probe_Start_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Start_X.Location = New System.Drawing.Point(57, 194)
        Me.Text_Box_Probe_Start_X.Multiline = True
        Me.Text_Box_Probe_Start_X.Name = "Text_Box_Probe_Start_X"
        Me.Text_Box_Probe_Start_X.Size = New System.Drawing.Size(83, 31)
        Me.Text_Box_Probe_Start_X.TabIndex = 161
        Me.Text_Box_Probe_Start_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Probe_Distance
        '
        Me.Text_Box_Probe_Distance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Probe_Distance.Location = New System.Drawing.Point(318, 37)
        Me.Text_Box_Probe_Distance.Multiline = True
        Me.Text_Box_Probe_Distance.Name = "Text_Box_Probe_Distance"
        Me.Text_Box_Probe_Distance.Size = New System.Drawing.Size(92, 31)
        Me.Text_Box_Probe_Distance.TabIndex = 158
        Me.Text_Box_Probe_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(312, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 25)
        Me.Label19.TabIndex = 159
        Me.Label19.Text = "Distance"
        '
        'Tab_Fixture_Offsets
        '
        Me.Tab_Fixture_Offsets.BackColor = System.Drawing.Color.DarkKhaki
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Park_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Park_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Park_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label82)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Measure_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Measure_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Measure_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Seat_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Seat_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Seat_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label79)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label78)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label47)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Change_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label43)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Change_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label14)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Tool_Change_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label42)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Tool_Measure_Top)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label40)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Material_Measure)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Material_Thickness)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label45)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Tool_Measure_Bottom)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Material_Bottom)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label44)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Material_Top)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Z0_Top)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Z0_Bottom)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_File)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Folder)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Set)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Goto)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Load)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Save)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Total_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Delta_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Original_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label64)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Reset_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Total_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Delta_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Original_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label63)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Reset_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label62)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Total_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label61)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Delta_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label60)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Original_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Adjust_Plus_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Adjust_Minus_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Adjust_Minus_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Adjust_Plus_X)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Adjust_Minus_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Adjust_Plus_Y)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label59)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Text_Box_Fixture_Offset_Increment)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Button_Fixture_Offset_Reset_Z)
        Me.Tab_Fixture_Offsets.Controls.Add(Me.Label34)
        Me.Tab_Fixture_Offsets.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Fixture_Offsets.Name = "Tab_Fixture_Offsets"
        Me.Tab_Fixture_Offsets.Size = New System.Drawing.Size(1532, 607)
        Me.Tab_Fixture_Offsets.TabIndex = 11
        Me.Tab_Fixture_Offsets.Text = "Fixture Offsets"
        '
        'Text_Box_Tool_Park_Z
        '
        Me.Text_Box_Tool_Park_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Park_Z.Location = New System.Drawing.Point(1111, 524)
        Me.Text_Box_Tool_Park_Z.Multiline = True
        Me.Text_Box_Tool_Park_Z.Name = "Text_Box_Tool_Park_Z"
        Me.Text_Box_Tool_Park_Z.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Park_Z.TabIndex = 467
        Me.Text_Box_Tool_Park_Z.TabStop = False
        Me.Text_Box_Tool_Park_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Tool_Park_Y
        '
        Me.Text_Box_Tool_Park_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Park_Y.Location = New System.Drawing.Point(1005, 524)
        Me.Text_Box_Tool_Park_Y.Multiline = True
        Me.Text_Box_Tool_Park_Y.Name = "Text_Box_Tool_Park_Y"
        Me.Text_Box_Tool_Park_Y.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Park_Y.TabIndex = 466
        Me.Text_Box_Tool_Park_Y.TabStop = False
        Me.Text_Box_Tool_Park_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Tool_Park_X
        '
        Me.Text_Box_Tool_Park_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Park_X.Location = New System.Drawing.Point(895, 524)
        Me.Text_Box_Tool_Park_X.Multiline = True
        Me.Text_Box_Tool_Park_X.Name = "Text_Box_Tool_Park_X"
        Me.Text_Box_Tool_Park_X.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Park_X.TabIndex = 465
        Me.Text_Box_Tool_Park_X.TabStop = False
        Me.Text_Box_Tool_Park_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.Location = New System.Drawing.Point(726, 527)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(60, 25)
        Me.Label82.TabIndex = 464
        Me.Label82.Text = "Park"
        '
        'Text_Box_Tool_Measure_Z
        '
        Me.Text_Box_Tool_Measure_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Measure_Z.Location = New System.Drawing.Point(1111, 484)
        Me.Text_Box_Tool_Measure_Z.Multiline = True
        Me.Text_Box_Tool_Measure_Z.Name = "Text_Box_Tool_Measure_Z"
        Me.Text_Box_Tool_Measure_Z.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Measure_Z.TabIndex = 463
        Me.Text_Box_Tool_Measure_Z.TabStop = False
        Me.Text_Box_Tool_Measure_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Tool_Measure_Y
        '
        Me.Text_Box_Tool_Measure_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Measure_Y.Location = New System.Drawing.Point(1005, 484)
        Me.Text_Box_Tool_Measure_Y.Multiline = True
        Me.Text_Box_Tool_Measure_Y.Name = "Text_Box_Tool_Measure_Y"
        Me.Text_Box_Tool_Measure_Y.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Measure_Y.TabIndex = 462
        Me.Text_Box_Tool_Measure_Y.TabStop = False
        Me.Text_Box_Tool_Measure_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Tool_Measure_X
        '
        Me.Text_Box_Tool_Measure_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Measure_X.Location = New System.Drawing.Point(895, 484)
        Me.Text_Box_Tool_Measure_X.Multiline = True
        Me.Text_Box_Tool_Measure_X.Name = "Text_Box_Tool_Measure_X"
        Me.Text_Box_Tool_Measure_X.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Measure_X.TabIndex = 461
        Me.Text_Box_Tool_Measure_X.TabStop = False
        Me.Text_Box_Tool_Measure_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Tool_Seat_Z
        '
        Me.Text_Box_Tool_Seat_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Seat_Z.Location = New System.Drawing.Point(1111, 444)
        Me.Text_Box_Tool_Seat_Z.Multiline = True
        Me.Text_Box_Tool_Seat_Z.Name = "Text_Box_Tool_Seat_Z"
        Me.Text_Box_Tool_Seat_Z.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Seat_Z.TabIndex = 460
        Me.Text_Box_Tool_Seat_Z.TabStop = False
        Me.Text_Box_Tool_Seat_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Tool_Seat_Y
        '
        Me.Text_Box_Tool_Seat_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Seat_Y.Location = New System.Drawing.Point(1005, 444)
        Me.Text_Box_Tool_Seat_Y.Multiline = True
        Me.Text_Box_Tool_Seat_Y.Name = "Text_Box_Tool_Seat_Y"
        Me.Text_Box_Tool_Seat_Y.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Seat_Y.TabIndex = 459
        Me.Text_Box_Tool_Seat_Y.TabStop = False
        Me.Text_Box_Tool_Seat_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Tool_Seat_X
        '
        Me.Text_Box_Tool_Seat_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Seat_X.Location = New System.Drawing.Point(895, 444)
        Me.Text_Box_Tool_Seat_X.Multiline = True
        Me.Text_Box_Tool_Seat_X.Name = "Text_Box_Tool_Seat_X"
        Me.Text_Box_Tool_Seat_X.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Seat_X.TabIndex = 458
        Me.Text_Box_Tool_Seat_X.TabStop = False
        Me.Text_Box_Tool_Seat_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(726, 487)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(156, 25)
        Me.Label79.TabIndex = 457
        Me.Label79.Text = "Tool Measure"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.Location = New System.Drawing.Point(726, 447)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(113, 25)
        Me.Label78.TabIndex = 456
        Me.Label78.Text = "Tool Seat"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(726, 407)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(146, 25)
        Me.Label47.TabIndex = 455
        Me.Label47.Text = "Tool Change"
        '
        'Text_Box_Tool_Change_Z
        '
        Me.Text_Box_Tool_Change_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Change_Z.Location = New System.Drawing.Point(1111, 404)
        Me.Text_Box_Tool_Change_Z.Multiline = True
        Me.Text_Box_Tool_Change_Z.Name = "Text_Box_Tool_Change_Z"
        Me.Text_Box_Tool_Change_Z.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Change_Z.TabIndex = 452
        Me.Text_Box_Tool_Change_Z.TabStop = False
        Me.Text_Box_Tool_Change_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(1136, 373)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(26, 25)
        Me.Label43.TabIndex = 451
        Me.Label43.Text = "Z"
        '
        'Text_Box_Tool_Change_Y
        '
        Me.Text_Box_Tool_Change_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Change_Y.Location = New System.Drawing.Point(1005, 404)
        Me.Text_Box_Tool_Change_Y.Multiline = True
        Me.Text_Box_Tool_Change_Y.Name = "Text_Box_Tool_Change_Y"
        Me.Text_Box_Tool_Change_Y.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Change_Y.TabIndex = 450
        Me.Text_Box_Tool_Change_Y.TabStop = False
        Me.Text_Box_Tool_Change_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1029, 373)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 25)
        Me.Label14.TabIndex = 449
        Me.Label14.Text = "Y"
        '
        'Text_Box_Tool_Change_X
        '
        Me.Text_Box_Tool_Change_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Tool_Change_X.Location = New System.Drawing.Point(895, 404)
        Me.Text_Box_Tool_Change_X.Multiline = True
        Me.Text_Box_Tool_Change_X.Name = "Text_Box_Tool_Change_X"
        Me.Text_Box_Tool_Change_X.Size = New System.Drawing.Size(99, 31)
        Me.Text_Box_Tool_Change_X.TabIndex = 448
        Me.Text_Box_Tool_Change_X.TabStop = False
        Me.Text_Box_Tool_Change_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(920, 373)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(27, 25)
        Me.Label42.TabIndex = 447
        Me.Label42.Text = "X"
        '
        'Button_Tool_Measure_Top
        '
        Me.Button_Tool_Measure_Top.BackgroundImage = CType(resources.GetObject("Button_Tool_Measure_Top.BackgroundImage"), System.Drawing.Image)
        Me.Button_Tool_Measure_Top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Tool_Measure_Top.FlatAppearance.BorderSize = 0
        Me.Button_Tool_Measure_Top.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Tool_Measure_Top.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Tool_Measure_Top.Location = New System.Drawing.Point(379, 396)
        Me.Button_Tool_Measure_Top.Name = "Button_Tool_Measure_Top"
        Me.Button_Tool_Measure_Top.Size = New System.Drawing.Size(133, 36)
        Me.Button_Tool_Measure_Top.TabIndex = 446
        Me.Button_Tool_Measure_Top.TabStop = False
        Me.Button_Tool_Measure_Top.Text = "Measure Tool"
        Me.Button_Tool_Measure_Top.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(40, 482)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(211, 25)
        Me.Label40.TabIndex = 445
        Me.Label40.Text = "Material Thickness"
        '
        'Button_Material_Measure
        '
        Me.Button_Material_Measure.BackgroundImage = CType(resources.GetObject("Button_Material_Measure.BackgroundImage"), System.Drawing.Image)
        Me.Button_Material_Measure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Material_Measure.FlatAppearance.BorderSize = 0
        Me.Button_Material_Measure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Material_Measure.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Material_Measure.Location = New System.Drawing.Point(379, 476)
        Me.Button_Material_Measure.Name = "Button_Material_Measure"
        Me.Button_Material_Measure.Size = New System.Drawing.Size(133, 36)
        Me.Button_Material_Measure.TabIndex = 444
        Me.Button_Material_Measure.TabStop = False
        Me.Button_Material_Measure.Text = "Measure"
        Me.Button_Material_Measure.UseVisualStyleBackColor = True
        '
        'Text_Box_Fixture_Offset_Material_Thickness
        '
        Me.Text_Box_Fixture_Offset_Material_Thickness.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Material_Thickness.Location = New System.Drawing.Point(264, 479)
        Me.Text_Box_Fixture_Offset_Material_Thickness.Multiline = True
        Me.Text_Box_Fixture_Offset_Material_Thickness.Name = "Text_Box_Fixture_Offset_Material_Thickness"
        Me.Text_Box_Fixture_Offset_Material_Thickness.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Material_Thickness.TabIndex = 443
        Me.Text_Box_Fixture_Offset_Material_Thickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(48, 442)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(203, 25)
        Me.Label45.TabIndex = 442
        Me.Label45.Text = "Bottom of material"
        '
        'Button_Tool_Measure_Bottom
        '
        Me.Button_Tool_Measure_Bottom.BackgroundImage = CType(resources.GetObject("Button_Tool_Measure_Bottom.BackgroundImage"), System.Drawing.Image)
        Me.Button_Tool_Measure_Bottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Tool_Measure_Bottom.FlatAppearance.BorderSize = 0
        Me.Button_Tool_Measure_Bottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Tool_Measure_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Tool_Measure_Bottom.Location = New System.Drawing.Point(379, 436)
        Me.Button_Tool_Measure_Bottom.Name = "Button_Tool_Measure_Bottom"
        Me.Button_Tool_Measure_Bottom.Size = New System.Drawing.Size(133, 36)
        Me.Button_Tool_Measure_Bottom.TabIndex = 438
        Me.Button_Tool_Measure_Bottom.TabStop = False
        Me.Button_Tool_Measure_Bottom.Text = "Measure Tool"
        Me.Button_Tool_Measure_Bottom.UseVisualStyleBackColor = True
        '
        'Text_Box_Fixture_Offset_Material_Bottom
        '
        Me.Text_Box_Fixture_Offset_Material_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Material_Bottom.Location = New System.Drawing.Point(264, 439)
        Me.Text_Box_Fixture_Offset_Material_Bottom.Multiline = True
        Me.Text_Box_Fixture_Offset_Material_Bottom.Name = "Text_Box_Fixture_Offset_Material_Bottom"
        Me.Text_Box_Fixture_Offset_Material_Bottom.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Material_Bottom.TabIndex = 441
        Me.Text_Box_Fixture_Offset_Material_Bottom.TabStop = False
        Me.Text_Box_Fixture_Offset_Material_Bottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(81, 402)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(170, 25)
        Me.Label44.TabIndex = 440
        Me.Label44.Text = "Top of material"
        '
        'Text_Box_Fixture_Offset_Material_Top
        '
        Me.Text_Box_Fixture_Offset_Material_Top.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Material_Top.Location = New System.Drawing.Point(264, 399)
        Me.Text_Box_Fixture_Offset_Material_Top.Multiline = True
        Me.Text_Box_Fixture_Offset_Material_Top.Name = "Text_Box_Fixture_Offset_Material_Top"
        Me.Text_Box_Fixture_Offset_Material_Top.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Material_Top.TabIndex = 439
        Me.Text_Box_Fixture_Offset_Material_Top.TabStop = False
        Me.Text_Box_Fixture_Offset_Material_Top.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Fixture_Offset_Z0_Top
        '
        Me.Button_Fixture_Offset_Z0_Top.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Z0_Top.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Z0_Top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Z0_Top.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Z0_Top.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Z0_Top.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Z0_Top.Location = New System.Drawing.Point(994, 16)
        Me.Button_Fixture_Offset_Z0_Top.Name = "Button_Fixture_Offset_Z0_Top"
        Me.Button_Fixture_Offset_Z0_Top.Size = New System.Drawing.Size(176, 39)
        Me.Button_Fixture_Offset_Z0_Top.TabIndex = 378
        Me.Button_Fixture_Offset_Z0_Top.TabStop = False
        Me.Button_Fixture_Offset_Z0_Top.Text = "Z0 on Top"
        Me.Button_Fixture_Offset_Z0_Top.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Z0_Bottom
        '
        Me.Button_Fixture_Offset_Z0_Bottom.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Z0_Bottom.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Z0_Bottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Z0_Bottom.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Z0_Bottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Z0_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Z0_Bottom.Location = New System.Drawing.Point(994, 58)
        Me.Button_Fixture_Offset_Z0_Bottom.Name = "Button_Fixture_Offset_Z0_Bottom"
        Me.Button_Fixture_Offset_Z0_Bottom.Size = New System.Drawing.Size(176, 39)
        Me.Button_Fixture_Offset_Z0_Bottom.TabIndex = 377
        Me.Button_Fixture_Offset_Z0_Bottom.TabStop = False
        Me.Button_Fixture_Offset_Z0_Bottom.Text = "Z0 on Bottom"
        Me.Button_Fixture_Offset_Z0_Bottom.UseVisualStyleBackColor = True
        '
        'Text_Box_Fixture_Offset_File
        '
        Me.Text_Box_Fixture_Offset_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_File.Location = New System.Drawing.Point(131, 62)
        Me.Text_Box_Fixture_Offset_File.Multiline = True
        Me.Text_Box_Fixture_Offset_File.Name = "Text_Box_Fixture_Offset_File"
        Me.Text_Box_Fixture_Offset_File.Size = New System.Drawing.Size(843, 31)
        Me.Text_Box_Fixture_Offset_File.TabIndex = 376
        Me.Text_Box_Fixture_Offset_File.TabStop = False
        '
        'Text_Box_Fixture_Offset_Folder
        '
        Me.Text_Box_Fixture_Offset_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Folder.Location = New System.Drawing.Point(131, 20)
        Me.Text_Box_Fixture_Offset_Folder.Multiline = True
        Me.Text_Box_Fixture_Offset_Folder.Name = "Text_Box_Fixture_Offset_Folder"
        Me.Text_Box_Fixture_Offset_Folder.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Text_Box_Fixture_Offset_Folder.Size = New System.Drawing.Size(843, 31)
        Me.Text_Box_Fixture_Offset_Folder.TabIndex = 375
        Me.Text_Box_Fixture_Offset_Folder.TabStop = False
        '
        'Button_Fixture_Offset_Set
        '
        Me.Button_Fixture_Offset_Set.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Set.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Set.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Set.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Set.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Set.Location = New System.Drawing.Point(23, 180)
        Me.Button_Fixture_Offset_Set.Name = "Button_Fixture_Offset_Set"
        Me.Button_Fixture_Offset_Set.Size = New System.Drawing.Size(100, 39)
        Me.Button_Fixture_Offset_Set.TabIndex = 374
        Me.Button_Fixture_Offset_Set.TabStop = False
        Me.Button_Fixture_Offset_Set.Text = "Set"
        Me.Button_Fixture_Offset_Set.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Goto
        '
        Me.Button_Fixture_Offset_Goto.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Goto.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Goto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Goto.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Goto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Goto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Goto.Location = New System.Drawing.Point(23, 239)
        Me.Button_Fixture_Offset_Goto.Name = "Button_Fixture_Offset_Goto"
        Me.Button_Fixture_Offset_Goto.Size = New System.Drawing.Size(100, 39)
        Me.Button_Fixture_Offset_Goto.TabIndex = 368
        Me.Button_Fixture_Offset_Goto.TabStop = False
        Me.Button_Fixture_Offset_Goto.Text = "Goto"
        Me.Button_Fixture_Offset_Goto.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Load
        '
        Me.Button_Fixture_Offset_Load.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Load.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Load.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Load.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Load.Location = New System.Drawing.Point(23, 17)
        Me.Button_Fixture_Offset_Load.Name = "Button_Fixture_Offset_Load"
        Me.Button_Fixture_Offset_Load.Size = New System.Drawing.Size(100, 39)
        Me.Button_Fixture_Offset_Load.TabIndex = 367
        Me.Button_Fixture_Offset_Load.TabStop = False
        Me.Button_Fixture_Offset_Load.Text = "Load"
        Me.Button_Fixture_Offset_Load.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Save
        '
        Me.Button_Fixture_Offset_Save.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Save.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Save.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Save.Location = New System.Drawing.Point(23, 60)
        Me.Button_Fixture_Offset_Save.Name = "Button_Fixture_Offset_Save"
        Me.Button_Fixture_Offset_Save.Size = New System.Drawing.Size(100, 39)
        Me.Button_Fixture_Offset_Save.TabIndex = 366
        Me.Button_Fixture_Offset_Save.TabStop = False
        Me.Button_Fixture_Offset_Save.Text = "Save"
        Me.Button_Fixture_Offset_Save.UseVisualStyleBackColor = True
        '
        'Text_Box_Fixture_Offset_Total_Z
        '
        Me.Text_Box_Fixture_Offset_Total_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Total_Z.Location = New System.Drawing.Point(408, 258)
        Me.Text_Box_Fixture_Offset_Total_Z.Multiline = True
        Me.Text_Box_Fixture_Offset_Total_Z.Name = "Text_Box_Fixture_Offset_Total_Z"
        Me.Text_Box_Fixture_Offset_Total_Z.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Total_Z.TabIndex = 357
        Me.Text_Box_Fixture_Offset_Total_Z.TabStop = False
        Me.Text_Box_Fixture_Offset_Total_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Fixture_Offset_Delta_Z
        '
        Me.Text_Box_Fixture_Offset_Delta_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Delta_Z.Location = New System.Drawing.Point(298, 258)
        Me.Text_Box_Fixture_Offset_Delta_Z.Multiline = True
        Me.Text_Box_Fixture_Offset_Delta_Z.Name = "Text_Box_Fixture_Offset_Delta_Z"
        Me.Text_Box_Fixture_Offset_Delta_Z.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Delta_Z.TabIndex = 356
        Me.Text_Box_Fixture_Offset_Delta_Z.TabStop = False
        Me.Text_Box_Fixture_Offset_Delta_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Fixture_Offset_Original_Z
        '
        Me.Text_Box_Fixture_Offset_Original_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Original_Z.Location = New System.Drawing.Point(188, 258)
        Me.Text_Box_Fixture_Offset_Original_Z.Multiline = True
        Me.Text_Box_Fixture_Offset_Original_Z.Name = "Text_Box_Fixture_Offset_Original_Z"
        Me.Text_Box_Fixture_Offset_Original_Z.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Original_Z.TabIndex = 355
        Me.Text_Box_Fixture_Offset_Original_Z.TabStop = False
        Me.Text_Box_Fixture_Offset_Original_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(155, 261)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(26, 25)
        Me.Label64.TabIndex = 354
        Me.Label64.Text = "Z"
        '
        'Button_Fixture_Offset_Reset_Y
        '
        Me.Button_Fixture_Offset_Reset_Y.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Reset_Y.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Reset_Y.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Reset_Y.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Reset_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Reset_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Reset_Y.Location = New System.Drawing.Point(518, 214)
        Me.Button_Fixture_Offset_Reset_Y.Name = "Button_Fixture_Offset_Reset_Y"
        Me.Button_Fixture_Offset_Reset_Y.Size = New System.Drawing.Size(90, 27)
        Me.Button_Fixture_Offset_Reset_Y.TabIndex = 353
        Me.Button_Fixture_Offset_Reset_Y.TabStop = False
        Me.Button_Fixture_Offset_Reset_Y.Text = "Reset"
        Me.Button_Fixture_Offset_Reset_Y.UseVisualStyleBackColor = True
        '
        'Text_Box_Fixture_Offset_Total_Y
        '
        Me.Text_Box_Fixture_Offset_Total_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Total_Y.Location = New System.Drawing.Point(408, 212)
        Me.Text_Box_Fixture_Offset_Total_Y.Multiline = True
        Me.Text_Box_Fixture_Offset_Total_Y.Name = "Text_Box_Fixture_Offset_Total_Y"
        Me.Text_Box_Fixture_Offset_Total_Y.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Total_Y.TabIndex = 352
        Me.Text_Box_Fixture_Offset_Total_Y.TabStop = False
        Me.Text_Box_Fixture_Offset_Total_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Fixture_Offset_Delta_Y
        '
        Me.Text_Box_Fixture_Offset_Delta_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Delta_Y.Location = New System.Drawing.Point(298, 212)
        Me.Text_Box_Fixture_Offset_Delta_Y.Multiline = True
        Me.Text_Box_Fixture_Offset_Delta_Y.Name = "Text_Box_Fixture_Offset_Delta_Y"
        Me.Text_Box_Fixture_Offset_Delta_Y.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Delta_Y.TabIndex = 351
        Me.Text_Box_Fixture_Offset_Delta_Y.TabStop = False
        Me.Text_Box_Fixture_Offset_Delta_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Fixture_Offset_Original_Y
        '
        Me.Text_Box_Fixture_Offset_Original_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Original_Y.Location = New System.Drawing.Point(188, 212)
        Me.Text_Box_Fixture_Offset_Original_Y.Multiline = True
        Me.Text_Box_Fixture_Offset_Original_Y.Name = "Text_Box_Fixture_Offset_Original_Y"
        Me.Text_Box_Fixture_Offset_Original_Y.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Original_Y.TabIndex = 350
        Me.Text_Box_Fixture_Offset_Original_Y.TabStop = False
        Me.Text_Box_Fixture_Offset_Original_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(155, 215)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(28, 25)
        Me.Label63.TabIndex = 349
        Me.Label63.Text = "Y"
        '
        'Button_Fixture_Offset_Reset_X
        '
        Me.Button_Fixture_Offset_Reset_X.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Reset_X.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Reset_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Reset_X.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Reset_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Reset_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Reset_X.Location = New System.Drawing.Point(518, 168)
        Me.Button_Fixture_Offset_Reset_X.Name = "Button_Fixture_Offset_Reset_X"
        Me.Button_Fixture_Offset_Reset_X.Size = New System.Drawing.Size(90, 27)
        Me.Button_Fixture_Offset_Reset_X.TabIndex = 348
        Me.Button_Fixture_Offset_Reset_X.TabStop = False
        Me.Button_Fixture_Offset_Reset_X.Text = "Reset"
        Me.Button_Fixture_Offset_Reset_X.UseVisualStyleBackColor = True
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(408, 139)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(65, 25)
        Me.Label62.TabIndex = 347
        Me.Label62.Text = "Total"
        '
        'Text_Box_Fixture_Offset_Total_X
        '
        Me.Text_Box_Fixture_Offset_Total_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Total_X.Location = New System.Drawing.Point(408, 166)
        Me.Text_Box_Fixture_Offset_Total_X.Multiline = True
        Me.Text_Box_Fixture_Offset_Total_X.Name = "Text_Box_Fixture_Offset_Total_X"
        Me.Text_Box_Fixture_Offset_Total_X.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Total_X.TabIndex = 346
        Me.Text_Box_Fixture_Offset_Total_X.TabStop = False
        Me.Text_Box_Fixture_Offset_Total_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(298, 139)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(67, 25)
        Me.Label61.TabIndex = 345
        Me.Label61.Text = "Delta"
        '
        'Text_Box_Fixture_Offset_Delta_X
        '
        Me.Text_Box_Fixture_Offset_Delta_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Delta_X.Location = New System.Drawing.Point(298, 166)
        Me.Text_Box_Fixture_Offset_Delta_X.Multiline = True
        Me.Text_Box_Fixture_Offset_Delta_X.Name = "Text_Box_Fixture_Offset_Delta_X"
        Me.Text_Box_Fixture_Offset_Delta_X.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Delta_X.TabIndex = 344
        Me.Text_Box_Fixture_Offset_Delta_X.TabStop = False
        Me.Text_Box_Fixture_Offset_Delta_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(188, 138)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(94, 25)
        Me.Label60.TabIndex = 343
        Me.Label60.Text = "Original"
        '
        'Text_Box_Fixture_Offset_Original_X
        '
        Me.Text_Box_Fixture_Offset_Original_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Original_X.Location = New System.Drawing.Point(188, 166)
        Me.Text_Box_Fixture_Offset_Original_X.Multiline = True
        Me.Text_Box_Fixture_Offset_Original_X.Name = "Text_Box_Fixture_Offset_Original_X"
        Me.Text_Box_Fixture_Offset_Original_X.Size = New System.Drawing.Size(104, 31)
        Me.Text_Box_Fixture_Offset_Original_X.TabIndex = 342
        Me.Text_Box_Fixture_Offset_Original_X.TabStop = False
        Me.Text_Box_Fixture_Offset_Original_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Fixture_Offset_Adjust_Plus_Z
        '
        Me.Button_Fixture_Offset_Adjust_Plus_Z.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Adjust_Plus_Z.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Adjust_Plus_Z.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Adjust_Plus_Z.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Adjust_Plus_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Adjust_Plus_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Adjust_Plus_Z.Location = New System.Drawing.Point(890, 152)
        Me.Button_Fixture_Offset_Adjust_Plus_Z.Name = "Button_Fixture_Offset_Adjust_Plus_Z"
        Me.Button_Fixture_Offset_Adjust_Plus_Z.Size = New System.Drawing.Size(75, 75)
        Me.Button_Fixture_Offset_Adjust_Plus_Z.TabIndex = 341
        Me.Button_Fixture_Offset_Adjust_Plus_Z.Text = "Z"
        Me.Button_Fixture_Offset_Adjust_Plus_Z.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Adjust_Minus_Z
        '
        Me.Button_Fixture_Offset_Adjust_Minus_Z.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Adjust_Minus_Z.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Adjust_Minus_Z.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Adjust_Minus_Z.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Adjust_Minus_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Adjust_Minus_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Adjust_Minus_Z.Location = New System.Drawing.Point(890, 230)
        Me.Button_Fixture_Offset_Adjust_Minus_Z.Name = "Button_Fixture_Offset_Adjust_Minus_Z"
        Me.Button_Fixture_Offset_Adjust_Minus_Z.Size = New System.Drawing.Size(75, 75)
        Me.Button_Fixture_Offset_Adjust_Minus_Z.TabIndex = 340
        Me.Button_Fixture_Offset_Adjust_Minus_Z.Text = "Z"
        Me.Button_Fixture_Offset_Adjust_Minus_Z.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Adjust_Minus_X
        '
        Me.Button_Fixture_Offset_Adjust_Minus_X.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Adjust_Minus_X.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Adjust_Minus_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Adjust_Minus_X.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Adjust_Minus_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Adjust_Minus_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Adjust_Minus_X.Location = New System.Drawing.Point(650, 191)
        Me.Button_Fixture_Offset_Adjust_Minus_X.Name = "Button_Fixture_Offset_Adjust_Minus_X"
        Me.Button_Fixture_Offset_Adjust_Minus_X.Size = New System.Drawing.Size(75, 75)
        Me.Button_Fixture_Offset_Adjust_Minus_X.TabIndex = 339
        Me.Button_Fixture_Offset_Adjust_Minus_X.Text = "X"
        Me.Button_Fixture_Offset_Adjust_Minus_X.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Adjust_Plus_X
        '
        Me.Button_Fixture_Offset_Adjust_Plus_X.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Adjust_Plus_X.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Adjust_Plus_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Adjust_Plus_X.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Adjust_Plus_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Adjust_Plus_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Adjust_Plus_X.Location = New System.Drawing.Point(800, 192)
        Me.Button_Fixture_Offset_Adjust_Plus_X.Name = "Button_Fixture_Offset_Adjust_Plus_X"
        Me.Button_Fixture_Offset_Adjust_Plus_X.Size = New System.Drawing.Size(75, 75)
        Me.Button_Fixture_Offset_Adjust_Plus_X.TabIndex = 338
        Me.Button_Fixture_Offset_Adjust_Plus_X.Text = "X"
        Me.Button_Fixture_Offset_Adjust_Plus_X.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Adjust_Minus_Y
        '
        Me.Button_Fixture_Offset_Adjust_Minus_Y.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Adjust_Minus_Y.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Adjust_Minus_Y.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Adjust_Minus_Y.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Adjust_Minus_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Adjust_Minus_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Adjust_Minus_Y.Location = New System.Drawing.Point(725, 266)
        Me.Button_Fixture_Offset_Adjust_Minus_Y.Name = "Button_Fixture_Offset_Adjust_Minus_Y"
        Me.Button_Fixture_Offset_Adjust_Minus_Y.Size = New System.Drawing.Size(75, 75)
        Me.Button_Fixture_Offset_Adjust_Minus_Y.TabIndex = 337
        Me.Button_Fixture_Offset_Adjust_Minus_Y.Text = "Y"
        Me.Button_Fixture_Offset_Adjust_Minus_Y.UseVisualStyleBackColor = True
        '
        'Button_Fixture_Offset_Adjust_Plus_Y
        '
        Me.Button_Fixture_Offset_Adjust_Plus_Y.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Adjust_Plus_Y.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Adjust_Plus_Y.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Adjust_Plus_Y.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Adjust_Plus_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Adjust_Plus_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Adjust_Plus_Y.Location = New System.Drawing.Point(725, 117)
        Me.Button_Fixture_Offset_Adjust_Plus_Y.Name = "Button_Fixture_Offset_Adjust_Plus_Y"
        Me.Button_Fixture_Offset_Adjust_Plus_Y.Size = New System.Drawing.Size(75, 75)
        Me.Button_Fixture_Offset_Adjust_Plus_Y.TabIndex = 336
        Me.Button_Fixture_Offset_Adjust_Plus_Y.Text = "Y"
        Me.Button_Fixture_Offset_Adjust_Plus_Y.UseVisualStyleBackColor = True
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(155, 169)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(27, 25)
        Me.Label59.TabIndex = 335
        Me.Label59.Text = "X"
        '
        'Text_Box_Fixture_Offset_Increment
        '
        Me.Text_Box_Fixture_Offset_Increment.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Fixture_Offset_Increment.Location = New System.Drawing.Point(729, 212)
        Me.Text_Box_Fixture_Offset_Increment.Multiline = True
        Me.Text_Box_Fixture_Offset_Increment.Name = "Text_Box_Fixture_Offset_Increment"
        Me.Text_Box_Fixture_Offset_Increment.Size = New System.Drawing.Size(66, 31)
        Me.Text_Box_Fixture_Offset_Increment.TabIndex = 334
        Me.Text_Box_Fixture_Offset_Increment.TabStop = False
        Me.Text_Box_Fixture_Offset_Increment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Fixture_Offset_Reset_Z
        '
        Me.Button_Fixture_Offset_Reset_Z.BackgroundImage = CType(resources.GetObject("Button_Fixture_Offset_Reset_Z.BackgroundImage"), System.Drawing.Image)
        Me.Button_Fixture_Offset_Reset_Z.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Fixture_Offset_Reset_Z.FlatAppearance.BorderSize = 0
        Me.Button_Fixture_Offset_Reset_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Fixture_Offset_Reset_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Fixture_Offset_Reset_Z.Location = New System.Drawing.Point(518, 260)
        Me.Button_Fixture_Offset_Reset_Z.Name = "Button_Fixture_Offset_Reset_Z"
        Me.Button_Fixture_Offset_Reset_Z.Size = New System.Drawing.Size(97, 27)
        Me.Button_Fixture_Offset_Reset_Z.TabIndex = 333
        Me.Button_Fixture_Offset_Reset_Z.TabStop = False
        Me.Button_Fixture_Offset_Reset_Z.Text = "Reset"
        Me.Button_Fixture_Offset_Reset_Z.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(188, 109)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(211, 25)
        Me.Label34.TabIndex = 332
        Me.Label34.Text = "Offset Adjustments"
        '
        'Tab_Home
        '
        Me.Tab_Home.BackColor = System.Drawing.Color.DarkKhaki
        Me.Tab_Home.Controls.Add(Me.Label39)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Gap_X_Minus)
        Me.Tab_Home.Controls.Add(Me.Label33)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Gap_X_Plus)
        Me.Tab_Home.Controls.Add(Me.Label27)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Gap_Y_Plus)
        Me.Tab_Home.Controls.Add(Me.Label16)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Gap_Y_Minus)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Z)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Goto_Z)
        Me.Tab_Home.Controls.Add(Me.Label15)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Y_Plus)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Y_Minus)
        Me.Tab_Home.Controls.Add(Me.Label13)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Error_X)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Probe_X_Minus)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Probe_X_Plus)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Probe_Y_Plus)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_X_Minus)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Goto_X_Minus)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Goto_Y_Minus)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Goto_Y_Plus)
        Me.Tab_Home.Controls.Add(Me.Label88)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_Error_Y)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Goto_X_Plus)
        Me.Tab_Home.Controls.Add(Me.Button_Square_Probe_Y_Minus)
        Me.Tab_Home.Controls.Add(Me.Text_Box_Square_X_Plus)
        Me.Tab_Home.Controls.Add(Me.Button_Home_XYZ)
        Me.Tab_Home.Controls.Add(Me.Label37)
        Me.Tab_Home.Controls.Add(Me.Button_Enable_Z)
        Me.Tab_Home.Controls.Add(Me.Button_Enable_Y)
        Me.Tab_Home.Controls.Add(Me.Button_Enable_X)
        Me.Tab_Home.Controls.Add(Me.Button_Home_Z)
        Me.Tab_Home.Controls.Add(Me.Button_Home_Y)
        Me.Tab_Home.Controls.Add(Me.Button_Home_X)
        Me.Tab_Home.Controls.Add(Me.Label4)
        Me.Tab_Home.Controls.Add(Me.Label5)
        Me.Tab_Home.Controls.Add(Me.Label6)
        Me.Tab_Home.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Home.Name = "Tab_Home"
        Me.Tab_Home.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Home.Size = New System.Drawing.Size(1532, 607)
        Me.Tab_Home.TabIndex = 0
        Me.Tab_Home.Text = "Home"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(613, 326)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(55, 25)
        Me.Label39.TabIndex = 390
        Me.Label39.Text = "Gap"
        '
        'Text_Box_Square_Gap_X_Minus
        '
        Me.Text_Box_Square_Gap_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Gap_X_Minus.Location = New System.Drawing.Point(507, 323)
        Me.Text_Box_Square_Gap_X_Minus.Multiline = True
        Me.Text_Box_Square_Gap_X_Minus.Name = "Text_Box_Square_Gap_X_Minus"
        Me.Text_Box_Square_Gap_X_Minus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Gap_X_Minus.TabIndex = 389
        Me.Text_Box_Square_Gap_X_Minus.TabStop = False
        Me.Text_Box_Square_Gap_X_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(613, 211)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(55, 25)
        Me.Label33.TabIndex = 388
        Me.Label33.Text = "Gap"
        '
        'Text_Box_Square_Gap_X_Plus
        '
        Me.Text_Box_Square_Gap_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Gap_X_Plus.Location = New System.Drawing.Point(507, 208)
        Me.Text_Box_Square_Gap_X_Plus.Multiline = True
        Me.Text_Box_Square_Gap_X_Plus.Name = "Text_Box_Square_Gap_X_Plus"
        Me.Text_Box_Square_Gap_X_Plus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Gap_X_Plus.TabIndex = 387
        Me.Text_Box_Square_Gap_X_Plus.TabStop = False
        Me.Text_Box_Square_Gap_X_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(1047, 165)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 25)
        Me.Label27.TabIndex = 386
        Me.Label27.Text = "Gap"
        '
        'Text_Box_Square_Gap_Y_Plus
        '
        Me.Text_Box_Square_Gap_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Gap_Y_Plus.Location = New System.Drawing.Point(1032, 196)
        Me.Text_Box_Square_Gap_Y_Plus.Multiline = True
        Me.Text_Box_Square_Gap_Y_Plus.Name = "Text_Box_Square_Gap_Y_Plus"
        Me.Text_Box_Square_Gap_Y_Plus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Gap_Y_Plus.TabIndex = 385
        Me.Text_Box_Square_Gap_Y_Plus.TabStop = False
        Me.Text_Box_Square_Gap_Y_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(835, 165)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 25)
        Me.Label16.TabIndex = 384
        Me.Label16.Text = "Gap"
        '
        'Text_Box_Square_Gap_Y_Minus
        '
        Me.Text_Box_Square_Gap_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Gap_Y_Minus.Location = New System.Drawing.Point(820, 196)
        Me.Text_Box_Square_Gap_Y_Minus.Multiline = True
        Me.Text_Box_Square_Gap_Y_Minus.Name = "Text_Box_Square_Gap_Y_Minus"
        Me.Text_Box_Square_Gap_Y_Minus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Gap_Y_Minus.TabIndex = 383
        Me.Text_Box_Square_Gap_Y_Minus.TabStop = False
        Me.Text_Box_Square_Gap_Y_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Square_Z
        '
        Me.Text_Box_Square_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Z.Location = New System.Drawing.Point(926, 445)
        Me.Text_Box_Square_Z.Multiline = True
        Me.Text_Box_Square_Z.Name = "Text_Box_Square_Z"
        Me.Text_Box_Square_Z.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Z.TabIndex = 382
        Me.Text_Box_Square_Z.TabStop = False
        Me.Text_Box_Square_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Square_Goto_Z
        '
        Me.Button_Square_Goto_Z.BackgroundImage = CType(resources.GetObject("Button_Square_Goto_Z.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Goto_Z.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Goto_Z.FlatAppearance.BorderSize = 0
        Me.Button_Square_Goto_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Goto_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Goto_Z.Location = New System.Drawing.Point(926, 339)
        Me.Button_Square_Goto_Z.Name = "Button_Square_Goto_Z"
        Me.Button_Square_Goto_Z.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Goto_Z.TabIndex = 381
        Me.Button_Square_Goto_Z.TabStop = False
        Me.Button_Square_Goto_Z.Text = "Z"
        Me.Button_Square_Goto_Z.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(688, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(146, 25)
        Me.Label15.TabIndex = 380
        Me.Label15.Text = "Square Axes"
        '
        'Text_Box_Square_Y_Plus
        '
        Me.Text_Box_Square_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Y_Plus.Location = New System.Drawing.Point(401, 38)
        Me.Text_Box_Square_Y_Plus.Multiline = True
        Me.Text_Box_Square_Y_Plus.Name = "Text_Box_Square_Y_Plus"
        Me.Text_Box_Square_Y_Plus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Y_Plus.TabIndex = 379
        Me.Text_Box_Square_Y_Plus.TabStop = False
        Me.Text_Box_Square_Y_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Square_Y_Minus
        '
        Me.Text_Box_Square_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Y_Minus.Location = New System.Drawing.Point(401, 496)
        Me.Text_Box_Square_Y_Minus.Multiline = True
        Me.Text_Box_Square_Y_Minus.Name = "Text_Box_Square_Y_Minus"
        Me.Text_Box_Square_Y_Minus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Y_Minus.TabIndex = 378
        Me.Text_Box_Square_Y_Minus.TabStop = False
        Me.Text_Box_Square_Y_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(613, 267)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 25)
        Me.Label13.TabIndex = 377
        Me.Label13.Text = "Error"
        '
        'Text_Box_Square_Error_X
        '
        Me.Text_Box_Square_Error_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Error_X.Location = New System.Drawing.Point(507, 264)
        Me.Text_Box_Square_Error_X.Multiline = True
        Me.Text_Box_Square_Error_X.Name = "Text_Box_Square_Error_X"
        Me.Text_Box_Square_Error_X.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Error_X.TabIndex = 376
        Me.Text_Box_Square_Error_X.TabStop = False
        Me.Text_Box_Square_Error_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Square_Probe_X_Minus
        '
        Me.Button_Square_Probe_X_Minus.BackgroundImage = CType(resources.GetObject("Button_Square_Probe_X_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Probe_X_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Probe_X_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Probe_X_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Probe_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Probe_X_Minus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Square_Probe_X_Minus.Location = New System.Drawing.Point(401, 288)
        Me.Button_Square_Probe_X_Minus.Name = "Button_Square_Probe_X_Minus"
        Me.Button_Square_Probe_X_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Probe_X_Minus.TabIndex = 375
        Me.Button_Square_Probe_X_Minus.Text = "X"
        Me.Button_Square_Probe_X_Minus.UseVisualStyleBackColor = True
        '
        'Button_Square_Probe_X_Plus
        '
        Me.Button_Square_Probe_X_Plus.BackgroundImage = CType(resources.GetObject("Button_Square_Probe_X_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Probe_X_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Probe_X_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Probe_X_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Probe_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Probe_X_Plus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Square_Probe_X_Plus.Location = New System.Drawing.Point(401, 173)
        Me.Button_Square_Probe_X_Plus.Name = "Button_Square_Probe_X_Plus"
        Me.Button_Square_Probe_X_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Probe_X_Plus.TabIndex = 374
        Me.Button_Square_Probe_X_Plus.Text = "X"
        Me.Button_Square_Probe_X_Plus.UseVisualStyleBackColor = True
        '
        'Button_Square_Probe_Y_Plus
        '
        Me.Button_Square_Probe_Y_Plus.BackgroundImage = CType(resources.GetObject("Button_Square_Probe_Y_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Probe_Y_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Probe_Y_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Probe_Y_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Probe_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Probe_Y_Plus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Square_Probe_Y_Plus.Location = New System.Drawing.Point(1032, 233)
        Me.Button_Square_Probe_Y_Plus.Name = "Button_Square_Probe_Y_Plus"
        Me.Button_Square_Probe_Y_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Probe_Y_Plus.TabIndex = 373
        Me.Button_Square_Probe_Y_Plus.Text = "Y"
        Me.Button_Square_Probe_Y_Plus.UseVisualStyleBackColor = True
        '
        'Text_Box_Square_X_Minus
        '
        Me.Text_Box_Square_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_X_Minus.Location = New System.Drawing.Point(707, 335)
        Me.Text_Box_Square_X_Minus.Multiline = True
        Me.Text_Box_Square_X_Minus.Name = "Text_Box_Square_X_Minus"
        Me.Text_Box_Square_X_Minus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_X_Minus.TabIndex = 372
        Me.Text_Box_Square_X_Minus.TabStop = False
        Me.Text_Box_Square_X_Minus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Square_Goto_X_Minus
        '
        Me.Button_Square_Goto_X_Minus.BackgroundImage = CType(resources.GetObject("Button_Square_Goto_X_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Goto_X_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Goto_X_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Goto_X_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Goto_X_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Goto_X_Minus.Location = New System.Drawing.Point(707, 233)
        Me.Button_Square_Goto_X_Minus.Name = "Button_Square_Goto_X_Minus"
        Me.Button_Square_Goto_X_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Goto_X_Minus.TabIndex = 371
        Me.Button_Square_Goto_X_Minus.Text = "X"
        Me.Button_Square_Goto_X_Minus.UseVisualStyleBackColor = True
        '
        'Button_Square_Goto_Y_Minus
        '
        Me.Button_Square_Goto_Y_Minus.BackgroundImage = CType(resources.GetObject("Button_Square_Goto_Y_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Goto_Y_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Goto_Y_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Goto_Y_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Goto_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Goto_Y_Minus.Location = New System.Drawing.Point(401, 394)
        Me.Button_Square_Goto_Y_Minus.Name = "Button_Square_Goto_Y_Minus"
        Me.Button_Square_Goto_Y_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Goto_Y_Minus.TabIndex = 370
        Me.Button_Square_Goto_Y_Minus.Text = "Y"
        Me.Button_Square_Goto_Y_Minus.UseVisualStyleBackColor = True
        '
        'Button_Square_Goto_Y_Plus
        '
        Me.Button_Square_Goto_Y_Plus.BackgroundImage = CType(resources.GetObject("Button_Square_Goto_Y_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Goto_Y_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Goto_Y_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Goto_Y_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Goto_Y_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Goto_Y_Plus.Location = New System.Drawing.Point(401, 71)
        Me.Button_Square_Goto_Y_Plus.Name = "Button_Square_Goto_Y_Plus"
        Me.Button_Square_Goto_Y_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Goto_Y_Plus.TabIndex = 369
        Me.Button_Square_Goto_Y_Plus.Text = "Y"
        Me.Button_Square_Goto_Y_Plus.UseVisualStyleBackColor = True
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(941, 165)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(64, 25)
        Me.Label88.TabIndex = 368
        Me.Label88.Text = "Error"
        '
        'Text_Box_Square_Error_Y
        '
        Me.Text_Box_Square_Error_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_Error_Y.Location = New System.Drawing.Point(926, 196)
        Me.Text_Box_Square_Error_Y.Multiline = True
        Me.Text_Box_Square_Error_Y.Name = "Text_Box_Square_Error_Y"
        Me.Text_Box_Square_Error_Y.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_Error_Y.TabIndex = 367
        Me.Text_Box_Square_Error_Y.TabStop = False
        Me.Text_Box_Square_Error_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Square_Goto_X_Plus
        '
        Me.Button_Square_Goto_X_Plus.BackgroundImage = CType(resources.GetObject("Button_Square_Goto_X_Plus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Goto_X_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Goto_X_Plus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Goto_X_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Goto_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Goto_X_Plus.Location = New System.Drawing.Point(1138, 233)
        Me.Button_Square_Goto_X_Plus.Name = "Button_Square_Goto_X_Plus"
        Me.Button_Square_Goto_X_Plus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Goto_X_Plus.TabIndex = 366
        Me.Button_Square_Goto_X_Plus.Text = "X"
        Me.Button_Square_Goto_X_Plus.UseVisualStyleBackColor = True
        '
        'Button_Square_Probe_Y_Minus
        '
        Me.Button_Square_Probe_Y_Minus.BackgroundImage = CType(resources.GetObject("Button_Square_Probe_Y_Minus.BackgroundImage"), System.Drawing.Image)
        Me.Button_Square_Probe_Y_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Square_Probe_Y_Minus.FlatAppearance.BorderSize = 0
        Me.Button_Square_Probe_Y_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Square_Probe_Y_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Square_Probe_Y_Minus.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button_Square_Probe_Y_Minus.Location = New System.Drawing.Point(820, 233)
        Me.Button_Square_Probe_Y_Minus.Name = "Button_Square_Probe_Y_Minus"
        Me.Button_Square_Probe_Y_Minus.Size = New System.Drawing.Size(100, 100)
        Me.Button_Square_Probe_Y_Minus.TabIndex = 365
        Me.Button_Square_Probe_Y_Minus.Text = "Y"
        Me.Button_Square_Probe_Y_Minus.UseVisualStyleBackColor = True
        '
        'Text_Box_Square_X_Plus
        '
        Me.Text_Box_Square_X_Plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Square_X_Plus.Location = New System.Drawing.Point(1138, 335)
        Me.Text_Box_Square_X_Plus.Multiline = True
        Me.Text_Box_Square_X_Plus.Name = "Text_Box_Square_X_Plus"
        Me.Text_Box_Square_X_Plus.Size = New System.Drawing.Size(100, 31)
        Me.Text_Box_Square_X_Plus.TabIndex = 364
        Me.Text_Box_Square_X_Plus.TabStop = False
        Me.Text_Box_Square_X_Plus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_Home_XYZ
        '
        Me.Button_Home_XYZ.BackgroundImage = CType(resources.GetObject("Button_Home_XYZ.BackgroundImage"), System.Drawing.Image)
        Me.Button_Home_XYZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Home_XYZ.FlatAppearance.BorderSize = 0
        Me.Button_Home_XYZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Home_XYZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Home_XYZ.Location = New System.Drawing.Point(92, 15)
        Me.Button_Home_XYZ.Name = "Button_Home_XYZ"
        Me.Button_Home_XYZ.Size = New System.Drawing.Size(100, 100)
        Me.Button_Home_XYZ.TabIndex = 164
        Me.Button_Home_XYZ.Text = "Home"
        Me.Button_Home_XYZ.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(6, 47)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(83, 37)
        Me.Label37.TabIndex = 163
        Me.Label37.Text = "XYZ"
        '
        'Button_Enable_Z
        '
        Me.Button_Enable_Z.BackgroundImage = CType(resources.GetObject("Button_Enable_Z.BackgroundImage"), System.Drawing.Image)
        Me.Button_Enable_Z.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Enable_Z.FlatAppearance.BorderSize = 0
        Me.Button_Enable_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Enable_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Enable_Z.Location = New System.Drawing.Point(208, 333)
        Me.Button_Enable_Z.Name = "Button_Enable_Z"
        Me.Button_Enable_Z.Size = New System.Drawing.Size(100, 100)
        Me.Button_Enable_Z.TabIndex = 135
        Me.Button_Enable_Z.Text = "Disable"
        Me.Button_Enable_Z.UseVisualStyleBackColor = True
        '
        'Button_Enable_Y
        '
        Me.Button_Enable_Y.BackgroundImage = CType(resources.GetObject("Button_Enable_Y.BackgroundImage"), System.Drawing.Image)
        Me.Button_Enable_Y.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Enable_Y.FlatAppearance.BorderSize = 0
        Me.Button_Enable_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Enable_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Enable_Y.Location = New System.Drawing.Point(208, 226)
        Me.Button_Enable_Y.Name = "Button_Enable_Y"
        Me.Button_Enable_Y.Size = New System.Drawing.Size(100, 100)
        Me.Button_Enable_Y.TabIndex = 134
        Me.Button_Enable_Y.Text = "Disable"
        Me.Button_Enable_Y.UseVisualStyleBackColor = True
        '
        'Button_Enable_X
        '
        Me.Button_Enable_X.BackgroundImage = CType(resources.GetObject("Button_Enable_X.BackgroundImage"), System.Drawing.Image)
        Me.Button_Enable_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Enable_X.FlatAppearance.BorderSize = 0
        Me.Button_Enable_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Enable_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Enable_X.Location = New System.Drawing.Point(208, 120)
        Me.Button_Enable_X.Name = "Button_Enable_X"
        Me.Button_Enable_X.Size = New System.Drawing.Size(100, 100)
        Me.Button_Enable_X.TabIndex = 133
        Me.Button_Enable_X.Text = "Disable"
        Me.Button_Enable_X.UseVisualStyleBackColor = True
        '
        'Button_Home_Z
        '
        Me.Button_Home_Z.BackgroundImage = CType(resources.GetObject("Button_Home_Z.BackgroundImage"), System.Drawing.Image)
        Me.Button_Home_Z.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Home_Z.FlatAppearance.BorderSize = 0
        Me.Button_Home_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Home_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Home_Z.Location = New System.Drawing.Point(92, 333)
        Me.Button_Home_Z.Name = "Button_Home_Z"
        Me.Button_Home_Z.Size = New System.Drawing.Size(100, 100)
        Me.Button_Home_Z.TabIndex = 132
        Me.Button_Home_Z.Text = "Home"
        Me.Button_Home_Z.UseVisualStyleBackColor = True
        '
        'Button_Home_Y
        '
        Me.Button_Home_Y.BackgroundImage = CType(resources.GetObject("Button_Home_Y.BackgroundImage"), System.Drawing.Image)
        Me.Button_Home_Y.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Home_Y.FlatAppearance.BorderSize = 0
        Me.Button_Home_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Home_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Home_Y.Location = New System.Drawing.Point(92, 226)
        Me.Button_Home_Y.Name = "Button_Home_Y"
        Me.Button_Home_Y.Size = New System.Drawing.Size(100, 100)
        Me.Button_Home_Y.TabIndex = 131
        Me.Button_Home_Y.Text = "Home"
        Me.Button_Home_Y.UseVisualStyleBackColor = True
        '
        'Button_Home_X
        '
        Me.Button_Home_X.BackgroundImage = CType(resources.GetObject("Button_Home_X.BackgroundImage"), System.Drawing.Image)
        Me.Button_Home_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Home_X.FlatAppearance.BorderSize = 0
        Me.Button_Home_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Home_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Home_X.Location = New System.Drawing.Point(92, 120)
        Me.Button_Home_X.Name = "Button_Home_X"
        Me.Button_Home_X.Size = New System.Drawing.Size(100, 100)
        Me.Button_Home_X.TabIndex = 130
        Me.Button_Home_X.Text = "Home"
        Me.Button_Home_X.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 365)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 37)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Z"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 37)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Y"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 37)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "X"
        '
        'Tab_Trace
        '
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Column_3)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Column_2)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Column_1)
        Me.Tab_Trace.Controls.Add(Me.txt_Trace)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Filter_Events)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Routine_Names)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Macro_Events)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_System_Events)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Queue)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Status)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Received)
        Me.Tab_Trace.Controls.Add(Me.chk_Trace_Sent)
        Me.Tab_Trace.Controls.Add(Me.ts_Trace)
        Me.Tab_Trace.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Trace.Name = "Tab_Trace"
        Me.Tab_Trace.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Trace.Size = New System.Drawing.Size(1532, 607)
        Me.Tab_Trace.TabIndex = 1
        Me.Tab_Trace.Text = "Trace"
        Me.Tab_Trace.UseVisualStyleBackColor = True
        '
        'chk_Trace_Column_3
        '
        Me.chk_Trace_Column_3.AutoSize = True
        Me.chk_Trace_Column_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Column_3.Location = New System.Drawing.Point(1165, 10)
        Me.chk_Trace_Column_3.Name = "chk_Trace_Column_3"
        Me.chk_Trace_Column_3.Size = New System.Drawing.Size(91, 22)
        Me.chk_Trace_Column_3.TabIndex = 28
        Me.chk_Trace_Column_3.Text = "Column 3"
        Me.chk_Trace_Column_3.UseVisualStyleBackColor = True
        '
        'chk_Trace_Column_2
        '
        Me.chk_Trace_Column_2.AutoSize = True
        Me.chk_Trace_Column_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Column_2.Location = New System.Drawing.Point(1067, 10)
        Me.chk_Trace_Column_2.Name = "chk_Trace_Column_2"
        Me.chk_Trace_Column_2.Size = New System.Drawing.Size(91, 22)
        Me.chk_Trace_Column_2.TabIndex = 27
        Me.chk_Trace_Column_2.Text = "Column 2"
        Me.chk_Trace_Column_2.UseVisualStyleBackColor = True
        '
        'chk_Trace_Column_1
        '
        Me.chk_Trace_Column_1.AutoSize = True
        Me.chk_Trace_Column_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Column_1.Location = New System.Drawing.Point(969, 10)
        Me.chk_Trace_Column_1.Name = "chk_Trace_Column_1"
        Me.chk_Trace_Column_1.Size = New System.Drawing.Size(91, 22)
        Me.chk_Trace_Column_1.TabIndex = 26
        Me.chk_Trace_Column_1.Text = "Column 1"
        Me.chk_Trace_Column_1.UseVisualStyleBackColor = True
        '
        'txt_Trace
        '
        Me.txt_Trace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_Trace.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Trace.Location = New System.Drawing.Point(3, 41)
        Me.txt_Trace.Multiline = True
        Me.txt_Trace.Name = "txt_Trace"
        Me.txt_Trace.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_Trace.Size = New System.Drawing.Size(1526, 563)
        Me.txt_Trace.TabIndex = 8
        Me.txt_Trace.WordWrap = False
        '
        'chk_Trace_Filter_Events
        '
        Me.chk_Trace_Filter_Events.AutoSize = True
        Me.chk_Trace_Filter_Events.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Filter_Events.Location = New System.Drawing.Point(107, 10)
        Me.chk_Trace_Filter_Events.Name = "chk_Trace_Filter_Events"
        Me.chk_Trace_Filter_Events.Size = New System.Drawing.Size(156, 22)
        Me.chk_Trace_Filter_Events.TabIndex = 24
        Me.chk_Trace_Filter_Events.Text = "Filter Event Logging"
        Me.chk_Trace_Filter_Events.UseVisualStyleBackColor = True
        '
        'chk_Trace_Routine_Names
        '
        Me.chk_Trace_Routine_Names.AutoSize = True
        Me.chk_Trace_Routine_Names.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Routine_Names.Location = New System.Drawing.Point(832, 10)
        Me.chk_Trace_Routine_Names.Name = "chk_Trace_Routine_Names"
        Me.chk_Trace_Routine_Names.Size = New System.Drawing.Size(130, 22)
        Me.chk_Trace_Routine_Names.TabIndex = 23
        Me.chk_Trace_Routine_Names.Text = "Routine Names"
        Me.chk_Trace_Routine_Names.UseVisualStyleBackColor = True
        '
        'chk_Trace_Macro_Events
        '
        Me.chk_Trace_Macro_Events.AutoSize = True
        Me.chk_Trace_Macro_Events.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Macro_Events.Location = New System.Drawing.Point(706, 10)
        Me.chk_Trace_Macro_Events.Name = "chk_Trace_Macro_Events"
        Me.chk_Trace_Macro_Events.Size = New System.Drawing.Size(119, 22)
        Me.chk_Trace_Macro_Events.TabIndex = 22
        Me.chk_Trace_Macro_Events.Text = "Macro Events"
        Me.chk_Trace_Macro_Events.UseVisualStyleBackColor = True
        '
        'chk_Trace_System_Events
        '
        Me.chk_Trace_System_Events.AutoSize = True
        Me.chk_Trace_System_Events.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_System_Events.Location = New System.Drawing.Point(573, 10)
        Me.chk_Trace_System_Events.Name = "chk_Trace_System_Events"
        Me.chk_Trace_System_Events.Size = New System.Drawing.Size(126, 22)
        Me.chk_Trace_System_Events.TabIndex = 21
        Me.chk_Trace_System_Events.Text = "System Events"
        Me.chk_Trace_System_Events.UseVisualStyleBackColor = True
        '
        'chk_Trace_Queue
        '
        Me.chk_Trace_Queue.AutoSize = True
        Me.chk_Trace_Queue.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Queue.Location = New System.Drawing.Point(429, 10)
        Me.chk_Trace_Queue.Name = "chk_Trace_Queue"
        Me.chk_Trace_Queue.Size = New System.Drawing.Size(71, 22)
        Me.chk_Trace_Queue.TabIndex = 20
        Me.chk_Trace_Queue.Text = "Queue"
        Me.chk_Trace_Queue.UseVisualStyleBackColor = True
        '
        'chk_Trace_Status
        '
        Me.chk_Trace_Status.AutoSize = True
        Me.chk_Trace_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Status.Location = New System.Drawing.Point(507, 10)
        Me.chk_Trace_Status.Name = "chk_Trace_Status"
        Me.chk_Trace_Status.Size = New System.Drawing.Size(69, 22)
        Me.chk_Trace_Status.TabIndex = 19
        Me.chk_Trace_Status.Text = "Status"
        Me.chk_Trace_Status.UseVisualStyleBackColor = True
        '
        'chk_Trace_Received
        '
        Me.chk_Trace_Received.AutoSize = True
        Me.chk_Trace_Received.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Received.Location = New System.Drawing.Point(334, 10)
        Me.chk_Trace_Received.Name = "chk_Trace_Received"
        Me.chk_Trace_Received.Size = New System.Drawing.Size(88, 22)
        Me.chk_Trace_Received.TabIndex = 18
        Me.chk_Trace_Received.Text = "Received"
        Me.chk_Trace_Received.UseVisualStyleBackColor = True
        '
        'chk_Trace_Sent
        '
        Me.chk_Trace_Sent.AutoSize = True
        Me.chk_Trace_Sent.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Trace_Sent.Location = New System.Drawing.Point(270, 10)
        Me.chk_Trace_Sent.Name = "chk_Trace_Sent"
        Me.chk_Trace_Sent.Size = New System.Drawing.Size(57, 22)
        Me.chk_Trace_Sent.TabIndex = 17
        Me.chk_Trace_Sent.Text = "Sent"
        Me.chk_Trace_Sent.UseVisualStyleBackColor = True
        '
        'ts_Trace
        '
        Me.ts_Trace.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Trace_Clear, Me.ts_Trace_Refresh, Me.ToolStripSeparator4})
        Me.ts_Trace.Location = New System.Drawing.Point(3, 3)
        Me.ts_Trace.Name = "ts_Trace"
        Me.ts_Trace.Size = New System.Drawing.Size(1526, 38)
        Me.ts_Trace.TabIndex = 9
        Me.ts_Trace.Text = "ToolStrip1"
        '
        'ts_Trace_Clear
        '
        Me.ts_Trace_Clear.Image = CType(resources.GetObject("ts_Trace_Clear.Image"), System.Drawing.Image)
        Me.ts_Trace_Clear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Trace_Clear.Name = "ts_Trace_Clear"
        Me.ts_Trace_Clear.Size = New System.Drawing.Size(38, 35)
        Me.ts_Trace_Clear.Text = "Clear"
        Me.ts_Trace_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Trace_Refresh
        '
        Me.ts_Trace_Refresh.Image = CType(resources.GetObject("ts_Trace_Refresh.Image"), System.Drawing.Image)
        Me.ts_Trace_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Trace_Refresh.Name = "ts_Trace_Refresh"
        Me.ts_Trace_Refresh.Size = New System.Drawing.Size(50, 35)
        Me.ts_Trace_Refresh.Text = "Refresh"
        Me.ts_Trace_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 38)
        '
        'Tab_Test
        '
        Me.Tab_Test.BackColor = System.Drawing.Color.DarkKhaki
        Me.Tab_Test.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Test.Name = "Tab_Test"
        Me.Tab_Test.Size = New System.Drawing.Size(1532, 607)
        Me.Tab_Test.TabIndex = 3
        Me.Tab_Test.Text = "Test"
        '
        'Tab_Diagnostics
        '
        Me.Tab_Diagnostics.BackColor = System.Drawing.Color.DarkKhaki
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox12)
        Me.Tab_Diagnostics.Controls.Add(Me.Label80)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox13)
        Me.Tab_Diagnostics.Controls.Add(Me.Label77)
        Me.Tab_Diagnostics.Controls.Add(Me.Label76)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox11)
        Me.Tab_Diagnostics.Controls.Add(Me.Label75)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox10)
        Me.Tab_Diagnostics.Controls.Add(Me.Label73)
        Me.Tab_Diagnostics.Controls.Add(Me.Label74)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox9)
        Me.Tab_Diagnostics.Controls.Add(Me.Label69)
        Me.Tab_Diagnostics.Controls.Add(Me.Label72)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox7)
        Me.Tab_Diagnostics.Controls.Add(Me.Label71)
        Me.Tab_Diagnostics.Controls.Add(Me.Label70)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox8)
        Me.Tab_Diagnostics.Controls.Add(Me.Label68)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox5)
        Me.Tab_Diagnostics.Controls.Add(Me.Label67)
        Me.Tab_Diagnostics.Controls.Add(Me.Label66)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox4)
        Me.Tab_Diagnostics.Controls.Add(Me.Label65)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox3)
        Me.Tab_Diagnostics.Controls.Add(Me.Label2)
        Me.Tab_Diagnostics.Controls.Add(Me.TextBox2)
        Me.Tab_Diagnostics.Controls.Add(Me.Label1)
        Me.Tab_Diagnostics.Controls.Add(Me.Label36)
        Me.Tab_Diagnostics.Controls.Add(Me.txt_State_Previous)
        Me.Tab_Diagnostics.Controls.Add(Me.Label35)
        Me.Tab_Diagnostics.Controls.Add(Me.txt_State_Last)
        Me.Tab_Diagnostics.Controls.Add(Me.Label29)
        Me.Tab_Diagnostics.Controls.Add(Me.Label28)
        Me.Tab_Diagnostics.Controls.Add(Me.txt_State_Current)
        Me.Tab_Diagnostics.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Diagnostics.Name = "Tab_Diagnostics"
        Me.Tab_Diagnostics.Size = New System.Drawing.Size(1532, 607)
        Me.Tab_Diagnostics.TabIndex = 10
        Me.Tab_Diagnostics.Text = "Diagnostics"
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(471, 267)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(77, 31)
        Me.TextBox12.TabIndex = 85
        Me.TextBox12.TabStop = False
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.Location = New System.Drawing.Point(558, 269)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(252, 25)
        Me.Label80.TabIndex = 84
        Me.Label80.Text = "(V1 - (V 2 + V3) / 2) / 3"
        '
        'TextBox13
        '
        Me.TextBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(362, 266)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(77, 31)
        Me.TextBox13.TabIndex = 83
        Me.TextBox13.TabStop = False
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.Location = New System.Drawing.Point(475, 159)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(72, 25)
        Me.Label77.TabIndex = 82
        Me.Label77.Text = "Turns"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(362, 158)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(67, 25)
        Me.Label76.TabIndex = 81
        Me.Label76.Text = "Delta"
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(471, 187)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(77, 31)
        Me.TextBox11.TabIndex = 80
        Me.TextBox11.TabStop = False
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(558, 189)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(261, 25)
        Me.Label75.TabIndex = 79
        Me.Label75.Text = "(V1 Front - V1 Back) / 2"
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(362, 186)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(77, 31)
        Me.TextBox10.TabIndex = 78
        Me.TextBox10.TabStop = False
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(362, 67)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(48, 25)
        Me.Label73.TabIndex = 77
        Me.Label73.Text = "Per"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(362, 89)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(100, 25)
        Me.Label74.TabIndex = 76
        Me.Label74.Text = "1/4 Turn"
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(362, 117)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(77, 31)
        Me.TextBox9.TabIndex = 75
        Me.TextBox9.TabStop = False
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(247, 67)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(62, 25)
        Me.Label69.TabIndex = 74
        Me.Label69.Text = "After"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(247, 89)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(100, 25)
        Me.Label72.TabIndex = 73
        Me.Label72.Text = "1/4 Turn"
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(247, 117)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(77, 31)
        Me.TextBox7.TabIndex = 72
        Me.TextBox7.TabStop = False
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(134, 67)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(81, 25)
        Me.Label71.TabIndex = 71
        Me.Label71.Text = "Before"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(134, 89)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(100, 25)
        Me.Label70.TabIndex = 68
        Me.Label70.Text = "1/4 Turn"
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(134, 117)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(77, 31)
        Me.TextBox8.TabIndex = 67
        Me.TextBox8.TabStop = False
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(247, 158)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(64, 25)
        Me.Label68.TabIndex = 66
        Me.Label68.Text = "Back"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(247, 186)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(77, 31)
        Me.TextBox5.TabIndex = 65
        Me.TextBox5.TabStop = False
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(134, 160)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(67, 25)
        Me.Label67.TabIndex = 64
        Me.Label67.Text = "Front"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(27, 266)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(90, 25)
        Me.Label66.TabIndex = 63
        Me.Label66.Text = "V3 Gap"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(134, 262)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(77, 31)
        Me.TextBox4.TabIndex = 62
        Me.TextBox4.TabStop = False
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(27, 229)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(90, 25)
        Me.Label65.TabIndex = 61
        Me.Label65.Text = "V2 Gap"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(134, 225)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(77, 31)
        Me.TextBox3.TabIndex = 60
        Me.TextBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 192)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 25)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "V1 Gap"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(134, 188)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(77, 31)
        Me.TextBox2.TabIndex = 58
        Me.TextBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(129, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 25)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Probe Adjustment"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(966, 135)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(104, 25)
        Me.Label36.TabIndex = 56
        Me.Label36.Text = "Previous"
        '
        'txt_State_Previous
        '
        Me.txt_State_Previous.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_State_Previous.Location = New System.Drawing.Point(1073, 131)
        Me.txt_State_Previous.Name = "txt_State_Previous"
        Me.txt_State_Previous.Size = New System.Drawing.Size(145, 31)
        Me.txt_State_Previous.TabIndex = 55
        Me.txt_State_Previous.TabStop = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(966, 98)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(57, 25)
        Me.Label35.TabIndex = 54
        Me.Label35.Text = "Last"
        '
        'txt_State_Last
        '
        Me.txt_State_Last.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_State_Last.Location = New System.Drawing.Point(1073, 94)
        Me.txt_State_Last.Name = "txt_State_Last"
        Me.txt_State_Last.Size = New System.Drawing.Size(145, 31)
        Me.txt_State_Last.TabIndex = 53
        Me.txt_State_Last.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(1073, 29)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(79, 25)
        Me.Label29.TabIndex = 52
        Me.Label29.Text = "States"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(966, 61)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(90, 25)
        Me.Label28.TabIndex = 51
        Me.Label28.Text = "Current"
        '
        'txt_State_Current
        '
        Me.txt_State_Current.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_State_Current.Location = New System.Drawing.Point(1073, 57)
        Me.txt_State_Current.Name = "txt_State_Current"
        Me.txt_State_Current.Size = New System.Drawing.Size(145, 31)
        Me.txt_State_Current.TabIndex = 50
        Me.txt_State_Current.TabStop = False
        '
        'Button_Probe_Loaded
        '
        Me.Button_Probe_Loaded.BackgroundImage = CType(resources.GetObject("Button_Probe_Loaded.BackgroundImage"), System.Drawing.Image)
        Me.Button_Probe_Loaded.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Probe_Loaded.FlatAppearance.BorderSize = 0
        Me.Button_Probe_Loaded.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Probe_Loaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Probe_Loaded.Location = New System.Drawing.Point(950, 143)
        Me.Button_Probe_Loaded.Name = "Button_Probe_Loaded"
        Me.Button_Probe_Loaded.Size = New System.Drawing.Size(133, 36)
        Me.Button_Probe_Loaded.TabIndex = 129
        Me.Button_Probe_Loaded.TabStop = False
        Me.Button_Probe_Loaded.Text = "Load Probe"
        Me.Button_Probe_Loaded.UseVisualStyleBackColor = True
        '
        'Status_Strip
        '
        Me.Status_Strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stat_Fault})
        Me.Status_Strip.Location = New System.Drawing.Point(0, 866)
        Me.Status_Strip.Name = "Status_Strip"
        Me.Status_Strip.Size = New System.Drawing.Size(1540, 26)
        Me.Status_Strip.TabIndex = 15
        Me.Status_Strip.Text = "StatusStrip1"
        '
        'stat_Fault
        '
        Me.stat_Fault.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stat_Fault.Name = "stat_Fault"
        Me.stat_Fault.Size = New System.Drawing.Size(43, 21)
        Me.stat_Fault.Text = "Fault"
        '
        'ts_Main
        '
        Me.ts_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Main_Exit, Me.ts_Main_State, Me.ts_Reset_Controller, Me.ts_Macros, Me.ts_Camera, Me.ts_Download_Settings, Me.ts_Verify_Settings, Me.ts_Help})
        Me.ts_Main.Location = New System.Drawing.Point(0, 0)
        Me.ts_Main.Name = "ts_Main"
        Me.ts_Main.Size = New System.Drawing.Size(1540, 38)
        Me.ts_Main.TabIndex = 16
        Me.ts_Main.Text = "ts_Main"
        '
        'ts_Main_Exit
        '
        Me.ts_Main_Exit.Image = CType(resources.GetObject("ts_Main_Exit.Image"), System.Drawing.Image)
        Me.ts_Main_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Main_Exit.Name = "ts_Main_Exit"
        Me.ts_Main_Exit.Size = New System.Drawing.Size(29, 35)
        Me.ts_Main_Exit.Text = "Exit"
        Me.ts_Main_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Main_State
        '
        Me.ts_Main_State.BackColor = System.Drawing.Color.White
        Me.ts_Main_State.Name = "ts_Main_State"
        Me.ts_Main_State.ReadOnly = True
        Me.ts_Main_State.Size = New System.Drawing.Size(200, 38)
        '
        'ts_Reset_Controller
        '
        Me.ts_Reset_Controller.Image = CType(resources.GetObject("ts_Reset_Controller.Image"), System.Drawing.Image)
        Me.ts_Reset_Controller.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Reset_Controller.Name = "ts_Reset_Controller"
        Me.ts_Reset_Controller.Size = New System.Drawing.Size(39, 35)
        Me.ts_Reset_Controller.Text = "Reset"
        Me.ts_Reset_Controller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Macros
        '
        Me.ts_Macros.Image = CType(resources.GetObject("ts_Macros.Image"), System.Drawing.Image)
        Me.ts_Macros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Macros.Name = "ts_Macros"
        Me.ts_Macros.Size = New System.Drawing.Size(50, 35)
        Me.ts_Macros.Text = "Macros"
        Me.ts_Macros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Camera
        '
        Me.ts_Camera.Image = CType(resources.GetObject("ts_Camera.Image"), System.Drawing.Image)
        Me.ts_Camera.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Camera.Name = "ts_Camera"
        Me.ts_Camera.Size = New System.Drawing.Size(52, 35)
        Me.ts_Camera.Text = "Camera"
        Me.ts_Camera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Download_Settings
        '
        Me.ts_Download_Settings.Image = CType(resources.GetObject("ts_Download_Settings.Image"), System.Drawing.Image)
        Me.ts_Download_Settings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Download_Settings.Name = "ts_Download_Settings"
        Me.ts_Download_Settings.Size = New System.Drawing.Size(110, 35)
        Me.ts_Download_Settings.Text = "Download Settings"
        Me.ts_Download_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Verify_Settings
        '
        Me.ts_Verify_Settings.Image = CType(resources.GetObject("ts_Verify_Settings.Image"), System.Drawing.Image)
        Me.ts_Verify_Settings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Verify_Settings.Name = "ts_Verify_Settings"
        Me.ts_Verify_Settings.Size = New System.Drawing.Size(85, 35)
        Me.ts_Verify_Settings.Text = "Verify Settings"
        Me.ts_Verify_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_Help
        '
        Me.ts_Help.Image = CType(resources.GetObject("ts_Help.Image"), System.Drawing.Image)
        Me.ts_Help.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Help.Name = "ts_Help"
        Me.ts_Help.Size = New System.Drawing.Size(36, 35)
        Me.ts_Help.Text = "Help"
        Me.ts_Help.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'panel_Bottom
        '
        Me.panel_Bottom.Controls.Add(Me.top_Splitter)
        Me.panel_Bottom.Controls.Add(Me.Tab_Main)
        Me.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_Bottom.Location = New System.Drawing.Point(0, 226)
        Me.panel_Bottom.Name = "panel_Bottom"
        Me.panel_Bottom.Size = New System.Drawing.Size(1540, 640)
        Me.panel_Bottom.TabIndex = 18
        '
        'top_Splitter
        '
        Me.top_Splitter.BackColor = System.Drawing.Color.Firebrick
        Me.top_Splitter.Dock = System.Windows.Forms.DockStyle.Top
        Me.top_Splitter.Location = New System.Drawing.Point(0, 0)
        Me.top_Splitter.Name = "top_Splitter"
        Me.top_Splitter.Size = New System.Drawing.Size(1540, 3)
        Me.top_Splitter.TabIndex = 15
        Me.top_Splitter.TabStop = False
        '
        'txt_Test
        '
        Me.txt_Test.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Test.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Test.Location = New System.Drawing.Point(1194, 7)
        Me.txt_Test.Name = "txt_Test"
        Me.txt_Test.Size = New System.Drawing.Size(241, 26)
        Me.txt_Test.TabIndex = 129
        Me.txt_Test.TabStop = False
        '
        'btn_Test
        '
        Me.btn_Test.BackgroundImage = CType(resources.GetObject("btn_Test.BackgroundImage"), System.Drawing.Image)
        Me.btn_Test.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Test.FlatAppearance.BorderSize = 0
        Me.btn_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Test.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Test.Location = New System.Drawing.Point(972, 1)
        Me.btn_Test.Name = "btn_Test"
        Me.btn_Test.Size = New System.Drawing.Size(105, 36)
        Me.btn_Test.TabIndex = 132
        Me.btn_Test.TabStop = False
        Me.btn_Test.Text = "Test"
        Me.btn_Test.UseVisualStyleBackColor = True
        Me.btn_Test.Visible = False
        '
        'btn_Test_2
        '
        Me.btn_Test_2.BackgroundImage = CType(resources.GetObject("btn_Test_2.BackgroundImage"), System.Drawing.Image)
        Me.btn_Test_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Test_2.FlatAppearance.BorderSize = 0
        Me.btn_Test_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Test_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Test_2.Location = New System.Drawing.Point(1083, 2)
        Me.btn_Test_2.Name = "btn_Test_2"
        Me.btn_Test_2.Size = New System.Drawing.Size(105, 36)
        Me.btn_Test_2.TabIndex = 133
        Me.btn_Test_2.TabStop = False
        Me.btn_Test_2.Text = "Test"
        Me.btn_Test_2.UseVisualStyleBackColor = True
        Me.btn_Test_2.Visible = False
        '
        'lab_X
        '
        Me.lab_X.AutoSize = True
        Me.lab_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lab_X.Location = New System.Drawing.Point(82, 41)
        Me.lab_X.Name = "lab_X"
        Me.lab_X.Size = New System.Drawing.Size(27, 25)
        Me.lab_X.TabIndex = 0
        Me.lab_X.Text = "X"
        '
        'lab_Y
        '
        Me.lab_Y.AutoSize = True
        Me.lab_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lab_Y.Location = New System.Drawing.Point(81, 76)
        Me.lab_Y.Name = "lab_Y"
        Me.lab_Y.Size = New System.Drawing.Size(28, 25)
        Me.lab_Y.TabIndex = 1
        Me.lab_Y.Text = "Y"
        '
        'lab_Z
        '
        Me.lab_Z.AutoSize = True
        Me.lab_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lab_Z.Location = New System.Drawing.Point(82, 111)
        Me.lab_Z.Name = "lab_Z"
        Me.lab_Z.Size = New System.Drawing.Size(26, 25)
        Me.lab_Z.TabIndex = 2
        Me.lab_Z.Text = "Z"
        '
        'Text_Box_Work_Pos_X
        '
        Me.Text_Box_Work_Pos_X.BackColor = System.Drawing.SystemColors.Window
        Me.Text_Box_Work_Pos_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Work_Pos_X.Location = New System.Drawing.Point(220, 38)
        Me.Text_Box_Work_Pos_X.Multiline = True
        Me.Text_Box_Work_Pos_X.Name = "Text_Box_Work_Pos_X"
        Me.Text_Box_Work_Pos_X.Size = New System.Drawing.Size(92, 28)
        Me.Text_Box_Work_Pos_X.TabIndex = 3
        Me.Text_Box_Work_Pos_X.TabStop = False
        Me.Text_Box_Work_Pos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Work_Pos_Y
        '
        Me.Text_Box_Work_Pos_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Work_Pos_Y.Location = New System.Drawing.Point(220, 73)
        Me.Text_Box_Work_Pos_Y.Multiline = True
        Me.Text_Box_Work_Pos_Y.Name = "Text_Box_Work_Pos_Y"
        Me.Text_Box_Work_Pos_Y.Size = New System.Drawing.Size(92, 28)
        Me.Text_Box_Work_Pos_Y.TabIndex = 4
        Me.Text_Box_Work_Pos_Y.TabStop = False
        Me.Text_Box_Work_Pos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Work_Pos_Z
        '
        Me.Text_Box_Work_Pos_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Work_Pos_Z.Location = New System.Drawing.Point(220, 108)
        Me.Text_Box_Work_Pos_Z.Multiline = True
        Me.Text_Box_Work_Pos_Z.Name = "Text_Box_Work_Pos_Z"
        Me.Text_Box_Work_Pos_Z.Size = New System.Drawing.Size(92, 28)
        Me.Text_Box_Work_Pos_Z.TabIndex = 8
        Me.Text_Box_Work_Pos_Z.TabStop = False
        Me.Text_Box_Work_Pos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Feedrate
        '
        Me.Text_Box_Feedrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Feedrate.Location = New System.Drawing.Point(549, 38)
        Me.Text_Box_Feedrate.Multiline = True
        Me.Text_Box_Feedrate.Name = "Text_Box_Feedrate"
        Me.Text_Box_Feedrate.Size = New System.Drawing.Size(83, 28)
        Me.Text_Box_Feedrate.TabIndex = 43
        Me.Text_Box_Feedrate.TabStop = False
        Me.Text_Box_Feedrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(422, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 25)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Feed Rate"
        '
        'Text_Box_Abs_Pos_X
        '
        Me.Text_Box_Abs_Pos_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Abs_Pos_X.Location = New System.Drawing.Point(117, 38)
        Me.Text_Box_Abs_Pos_X.Multiline = True
        Me.Text_Box_Abs_Pos_X.Name = "Text_Box_Abs_Pos_X"
        Me.Text_Box_Abs_Pos_X.Size = New System.Drawing.Size(97, 28)
        Me.Text_Box_Abs_Pos_X.TabIndex = 46
        Me.Text_Box_Abs_Pos_X.TabStop = False
        Me.Text_Box_Abs_Pos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Abs_Pos_Y
        '
        Me.Text_Box_Abs_Pos_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Abs_Pos_Y.Location = New System.Drawing.Point(117, 73)
        Me.Text_Box_Abs_Pos_Y.Multiline = True
        Me.Text_Box_Abs_Pos_Y.Name = "Text_Box_Abs_Pos_Y"
        Me.Text_Box_Abs_Pos_Y.Size = New System.Drawing.Size(97, 28)
        Me.Text_Box_Abs_Pos_Y.TabIndex = 47
        Me.Text_Box_Abs_Pos_Y.TabStop = False
        Me.Text_Box_Abs_Pos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Abs_Pos_Z
        '
        Me.Text_Box_Abs_Pos_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Abs_Pos_Z.Location = New System.Drawing.Point(117, 108)
        Me.Text_Box_Abs_Pos_Z.Multiline = True
        Me.Text_Box_Abs_Pos_Z.Name = "Text_Box_Abs_Pos_Z"
        Me.Text_Box_Abs_Pos_Z.Size = New System.Drawing.Size(97, 28)
        Me.Text_Box_Abs_Pos_Z.TabIndex = 48
        Me.Text_Box_Abs_Pos_Z.TabStop = False
        Me.Text_Box_Abs_Pos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(220, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 25)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Work"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(113, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 25)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Machine"
        '
        'Text_Box_Jog_Rate_Selected
        '
        Me.Text_Box_Jog_Rate_Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Jog_Rate_Selected.Location = New System.Drawing.Point(549, 108)
        Me.Text_Box_Jog_Rate_Selected.Multiline = True
        Me.Text_Box_Jog_Rate_Selected.Name = "Text_Box_Jog_Rate_Selected"
        Me.Text_Box_Jog_Rate_Selected.Size = New System.Drawing.Size(83, 28)
        Me.Text_Box_Jog_Rate_Selected.TabIndex = 55
        Me.Text_Box_Jog_Rate_Selected.TabStop = False
        Me.Text_Box_Jog_Rate_Selected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(422, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 25)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Jog Rate"
        '
        'Text_Box_Velocity
        '
        Me.Text_Box_Velocity.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Velocity.Location = New System.Drawing.Point(549, 73)
        Me.Text_Box_Velocity.Multiline = True
        Me.Text_Box_Velocity.Name = "Text_Box_Velocity"
        Me.Text_Box_Velocity.Size = New System.Drawing.Size(83, 28)
        Me.Text_Box_Velocity.TabIndex = 57
        Me.Text_Box_Velocity.TabStop = False
        Me.Text_Box_Velocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(422, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 25)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Velocity"
        '
        'Text_Box_Offset_X
        '
        Me.Text_Box_Offset_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Offset_X.Location = New System.Drawing.Point(318, 38)
        Me.Text_Box_Offset_X.Multiline = True
        Me.Text_Box_Offset_X.Name = "Text_Box_Offset_X"
        Me.Text_Box_Offset_X.Size = New System.Drawing.Size(97, 28)
        Me.Text_Box_Offset_X.TabIndex = 59
        Me.Text_Box_Offset_X.TabStop = False
        Me.Text_Box_Offset_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Offset_Y
        '
        Me.Text_Box_Offset_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Offset_Y.Location = New System.Drawing.Point(318, 73)
        Me.Text_Box_Offset_Y.Multiline = True
        Me.Text_Box_Offset_Y.Name = "Text_Box_Offset_Y"
        Me.Text_Box_Offset_Y.Size = New System.Drawing.Size(97, 28)
        Me.Text_Box_Offset_Y.TabIndex = 60
        Me.Text_Box_Offset_Y.TabStop = False
        Me.Text_Box_Offset_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Text_Box_Offset_Z
        '
        Me.Text_Box_Offset_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Offset_Z.Location = New System.Drawing.Point(318, 108)
        Me.Text_Box_Offset_Z.Multiline = True
        Me.Text_Box_Offset_Z.Name = "Text_Box_Offset_Z"
        Me.Text_Box_Offset_Z.Size = New System.Drawing.Size(97, 28)
        Me.Text_Box_Offset_Z.TabIndex = 61
        Me.Text_Box_Offset_Z.TabStop = False
        Me.Text_Box_Offset_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button_E_Stop
        '
        Me.Button_E_Stop.BackgroundImage = CType(resources.GetObject("Button_E_Stop.BackgroundImage"), System.Drawing.Image)
        Me.Button_E_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_E_Stop.FlatAppearance.BorderSize = 0
        Me.Button_E_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_E_Stop.Location = New System.Drawing.Point(1238, 3)
        Me.Button_E_Stop.Name = "Button_E_Stop"
        Me.Button_E_Stop.Size = New System.Drawing.Size(150, 150)
        Me.Button_E_Stop.TabIndex = 115
        Me.Button_E_Stop.UseVisualStyleBackColor = True
        '
        'Button_Set_X
        '
        Me.Button_Set_X.BackgroundImage = CType(resources.GetObject("Button_Set_X.BackgroundImage"), System.Drawing.Image)
        Me.Button_Set_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Set_X.FlatAppearance.BorderSize = 0
        Me.Button_Set_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Set_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Set_X.Location = New System.Drawing.Point(5, 40)
        Me.Button_Set_X.Name = "Button_Set_X"
        Me.Button_Set_X.Size = New System.Drawing.Size(71, 27)
        Me.Button_Set_X.TabIndex = 116
        Me.Button_Set_X.TabStop = False
        Me.Button_Set_X.Text = "Set"
        Me.Button_Set_X.UseVisualStyleBackColor = True
        '
        'Button_Set_Y
        '
        Me.Button_Set_Y.BackgroundImage = CType(resources.GetObject("Button_Set_Y.BackgroundImage"), System.Drawing.Image)
        Me.Button_Set_Y.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Set_Y.FlatAppearance.BorderSize = 0
        Me.Button_Set_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Set_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Set_Y.Location = New System.Drawing.Point(5, 75)
        Me.Button_Set_Y.Name = "Button_Set_Y"
        Me.Button_Set_Y.Size = New System.Drawing.Size(71, 27)
        Me.Button_Set_Y.TabIndex = 117
        Me.Button_Set_Y.TabStop = False
        Me.Button_Set_Y.Text = "Set"
        Me.Button_Set_Y.UseVisualStyleBackColor = True
        '
        'Button_Set_Z
        '
        Me.Button_Set_Z.BackgroundImage = CType(resources.GetObject("Button_Set_Z.BackgroundImage"), System.Drawing.Image)
        Me.Button_Set_Z.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Set_Z.FlatAppearance.BorderSize = 0
        Me.Button_Set_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Set_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Set_Z.Location = New System.Drawing.Point(5, 110)
        Me.Button_Set_Z.Name = "Button_Set_Z"
        Me.Button_Set_Z.Size = New System.Drawing.Size(71, 27)
        Me.Button_Set_Z.TabIndex = 118
        Me.Button_Set_Z.TabStop = False
        Me.Button_Set_Z.Text = "Set"
        Me.Button_Set_Z.UseVisualStyleBackColor = True
        '
        'Button_Coolant
        '
        Me.Button_Coolant.BackgroundImage = CType(resources.GetObject("Button_Coolant.BackgroundImage"), System.Drawing.Image)
        Me.Button_Coolant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Coolant.FlatAppearance.BorderSize = 0
        Me.Button_Coolant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Coolant.Location = New System.Drawing.Point(790, 9)
        Me.Button_Coolant.Name = "Button_Coolant"
        Me.Button_Coolant.Size = New System.Drawing.Size(125, 125)
        Me.Button_Coolant.TabIndex = 119
        Me.Button_Coolant.TabStop = False
        Me.Button_Coolant.UseVisualStyleBackColor = True
        '
        'Button_Spindle
        '
        Me.Button_Spindle.BackgroundImage = CType(resources.GetObject("Button_Spindle.BackgroundImage"), System.Drawing.Image)
        Me.Button_Spindle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Spindle.FlatAppearance.BorderSize = 0
        Me.Button_Spindle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Spindle.Location = New System.Drawing.Point(652, 9)
        Me.Button_Spindle.Name = "Button_Spindle"
        Me.Button_Spindle.Size = New System.Drawing.Size(125, 125)
        Me.Button_Spindle.TabIndex = 120
        Me.Button_Spindle.TabStop = False
        Me.Button_Spindle.UseVisualStyleBackColor = True
        '
        'Button_Feed
        '
        Me.Button_Feed.BackgroundImage = CType(resources.GetObject("Button_Feed.BackgroundImage"), System.Drawing.Image)
        Me.Button_Feed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Feed.FlatAppearance.BorderSize = 0
        Me.Button_Feed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Feed.Location = New System.Drawing.Point(952, 8)
        Me.Button_Feed.Name = "Button_Feed"
        Me.Button_Feed.Size = New System.Drawing.Size(125, 125)
        Me.Button_Feed.TabIndex = 121
        Me.Button_Feed.TabStop = False
        Me.Button_Feed.UseVisualStyleBackColor = True
        '
        'Button_Cycle
        '
        Me.Button_Cycle.BackgroundImage = CType(resources.GetObject("Button_Cycle.BackgroundImage"), System.Drawing.Image)
        Me.Button_Cycle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Cycle.FlatAppearance.BorderSize = 0
        Me.Button_Cycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Cycle.Location = New System.Drawing.Point(1087, 8)
        Me.Button_Cycle.Name = "Button_Cycle"
        Me.Button_Cycle.Size = New System.Drawing.Size(125, 125)
        Me.Button_Cycle.TabIndex = 122
        Me.Button_Cycle.TabStop = False
        Me.Button_Cycle.UseVisualStyleBackColor = True
        '
        'Button_Goto_Home
        '
        Me.Button_Goto_Home.BackgroundImage = CType(resources.GetObject("Button_Goto_Home.BackgroundImage"), System.Drawing.Image)
        Me.Button_Goto_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Goto_Home.FlatAppearance.BorderSize = 0
        Me.Button_Goto_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Goto_Home.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Goto_Home.Location = New System.Drawing.Point(117, 148)
        Me.Button_Goto_Home.Name = "Button_Goto_Home"
        Me.Button_Goto_Home.Size = New System.Drawing.Size(71, 36)
        Me.Button_Goto_Home.TabIndex = 123
        Me.Button_Goto_Home.TabStop = False
        Me.Button_Goto_Home.Text = "Home"
        Me.Button_Goto_Home.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(11, 154)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(76, 25)
        Me.Label26.TabIndex = 124
        Me.Label26.Text = "Go To"
        '
        'Button_Goto_Park
        '
        Me.Button_Goto_Park.BackgroundImage = CType(resources.GetObject("Button_Goto_Park.BackgroundImage"), System.Drawing.Image)
        Me.Button_Goto_Park.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Goto_Park.FlatAppearance.BorderSize = 0
        Me.Button_Goto_Park.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Goto_Park.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Goto_Park.Location = New System.Drawing.Point(192, 148)
        Me.Button_Goto_Park.Name = "Button_Goto_Park"
        Me.Button_Goto_Park.Size = New System.Drawing.Size(93, 36)
        Me.Button_Goto_Park.TabIndex = 125
        Me.Button_Goto_Park.TabStop = False
        Me.Button_Goto_Park.Text = "Park"
        Me.Button_Goto_Park.UseVisualStyleBackColor = True
        '
        'Button_Goto_Tool_Change
        '
        Me.Button_Goto_Tool_Change.BackgroundImage = CType(resources.GetObject("Button_Goto_Tool_Change.BackgroundImage"), System.Drawing.Image)
        Me.Button_Goto_Tool_Change.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Goto_Tool_Change.FlatAppearance.BorderSize = 0
        Me.Button_Goto_Tool_Change.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Goto_Tool_Change.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Goto_Tool_Change.Location = New System.Drawing.Point(292, 148)
        Me.Button_Goto_Tool_Change.Name = "Button_Goto_Tool_Change"
        Me.Button_Goto_Tool_Change.Size = New System.Drawing.Size(125, 36)
        Me.Button_Goto_Tool_Change.TabIndex = 126
        Me.Button_Goto_Tool_Change.TabStop = False
        Me.Button_Goto_Tool_Change.Text = "Tool Change"
        Me.Button_Goto_Tool_Change.UseVisualStyleBackColor = True
        '
        'Button_GoTo_Tool_Seat
        '
        Me.Button_GoTo_Tool_Seat.BackgroundImage = CType(resources.GetObject("Button_GoTo_Tool_Seat.BackgroundImage"), System.Drawing.Image)
        Me.Button_GoTo_Tool_Seat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_GoTo_Tool_Seat.FlatAppearance.BorderSize = 0
        Me.Button_GoTo_Tool_Seat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_GoTo_Tool_Seat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_GoTo_Tool_Seat.Location = New System.Drawing.Point(424, 148)
        Me.Button_GoTo_Tool_Seat.Name = "Button_GoTo_Tool_Seat"
        Me.Button_GoTo_Tool_Seat.Size = New System.Drawing.Size(119, 36)
        Me.Button_GoTo_Tool_Seat.TabIndex = 127
        Me.Button_GoTo_Tool_Seat.TabStop = False
        Me.Button_GoTo_Tool_Seat.Text = "Tool Seat"
        Me.Button_GoTo_Tool_Seat.UseVisualStyleBackColor = True
        '
        'Button_Homed
        '
        Me.Button_Homed.BackgroundImage = CType(resources.GetObject("Button_Homed.BackgroundImage"), System.Drawing.Image)
        Me.Button_Homed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Homed.FlatAppearance.BorderSize = 0
        Me.Button_Homed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Homed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Homed.Location = New System.Drawing.Point(5, 4)
        Me.Button_Homed.Name = "Button_Homed"
        Me.Button_Homed.Size = New System.Drawing.Size(102, 31)
        Me.Button_Homed.TabIndex = 130
        Me.Button_Homed.TabStop = False
        Me.Button_Homed.Text = "Homed"
        Me.Button_Homed.UseVisualStyleBackColor = True
        '
        'Text_Box_Coordinate_System
        '
        Me.Text_Box_Coordinate_System.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Box_Coordinate_System.Location = New System.Drawing.Point(318, 3)
        Me.Text_Box_Coordinate_System.Multiline = True
        Me.Text_Box_Coordinate_System.Name = "Text_Box_Coordinate_System"
        Me.Text_Box_Coordinate_System.Size = New System.Drawing.Size(97, 28)
        Me.Text_Box_Coordinate_System.TabIndex = 131
        Me.Text_Box_Coordinate_System.TabStop = False
        '
        'Panel_Top
        '
        Me.Panel_Top.BackColor = System.Drawing.Color.Beige
        Me.Panel_Top.Controls.Add(Me.Button_GoTo_Tool_Measure)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Coordinate_System)
        Me.Panel_Top.Controls.Add(Me.Button_Probe_Loaded)
        Me.Panel_Top.Controls.Add(Me.Button_Homed)
        Me.Panel_Top.Controls.Add(Me.Button_GoTo_Tool_Seat)
        Me.Panel_Top.Controls.Add(Me.Button_Goto_Tool_Change)
        Me.Panel_Top.Controls.Add(Me.Button_Goto_Park)
        Me.Panel_Top.Controls.Add(Me.Label26)
        Me.Panel_Top.Controls.Add(Me.Button_Goto_Home)
        Me.Panel_Top.Controls.Add(Me.Button_Cycle)
        Me.Panel_Top.Controls.Add(Me.Button_Feed)
        Me.Panel_Top.Controls.Add(Me.Button_Spindle)
        Me.Panel_Top.Controls.Add(Me.Button_Coolant)
        Me.Panel_Top.Controls.Add(Me.Button_Set_Z)
        Me.Panel_Top.Controls.Add(Me.Button_Set_Y)
        Me.Panel_Top.Controls.Add(Me.Button_Set_X)
        Me.Panel_Top.Controls.Add(Me.Button_E_Stop)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Offset_Z)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Offset_Y)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Offset_X)
        Me.Panel_Top.Controls.Add(Me.Label17)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Velocity)
        Me.Panel_Top.Controls.Add(Me.Label8)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Jog_Rate_Selected)
        Me.Panel_Top.Controls.Add(Me.Label12)
        Me.Panel_Top.Controls.Add(Me.Label11)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Abs_Pos_Z)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Abs_Pos_Y)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Abs_Pos_X)
        Me.Panel_Top.Controls.Add(Me.Label10)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Feedrate)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Work_Pos_Z)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Work_Pos_Y)
        Me.Panel_Top.Controls.Add(Me.Text_Box_Work_Pos_X)
        Me.Panel_Top.Controls.Add(Me.lab_Z)
        Me.Panel_Top.Controls.Add(Me.lab_Y)
        Me.Panel_Top.Controls.Add(Me.lab_X)
        Me.Panel_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top.Location = New System.Drawing.Point(0, 38)
        Me.Panel_Top.Name = "Panel_Top"
        Me.Panel_Top.Size = New System.Drawing.Size(1540, 188)
        Me.Panel_Top.TabIndex = 13
        '
        'Button_GoTo_Tool_Measure
        '
        Me.Button_GoTo_Tool_Measure.BackgroundImage = CType(resources.GetObject("Button_GoTo_Tool_Measure.BackgroundImage"), System.Drawing.Image)
        Me.Button_GoTo_Tool_Measure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_GoTo_Tool_Measure.FlatAppearance.BorderSize = 0
        Me.Button_GoTo_Tool_Measure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_GoTo_Tool_Measure.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_GoTo_Tool_Measure.Location = New System.Drawing.Point(550, 148)
        Me.Button_GoTo_Tool_Measure.Name = "Button_GoTo_Tool_Measure"
        Me.Button_GoTo_Tool_Measure.Size = New System.Drawing.Size(148, 36)
        Me.Button_GoTo_Tool_Measure.TabIndex = 132
        Me.Button_GoTo_Tool_Measure.TabStop = False
        Me.Button_GoTo_Tool_Measure.Text = "Tool Measure"
        Me.Button_GoTo_Tool_Measure.UseVisualStyleBackColor = True
        '
        'btn_Connected
        '
        Me.btn_Connected.BackColor = System.Drawing.Color.Red
        Me.btn_Connected.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Connected.Location = New System.Drawing.Point(639, 0)
        Me.btn_Connected.Name = "btn_Connected"
        Me.btn_Connected.Size = New System.Drawing.Size(155, 37)
        Me.btn_Connected.TabIndex = 134
        Me.btn_Connected.Text = "Disconnected"
        Me.btn_Connected.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(800, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 20)
        Me.Label9.TabIndex = 136
        Me.Label9.Text = "Port"
        '
        'txt_Com_Port
        '
        Me.txt_Com_Port.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Com_Port.Location = New System.Drawing.Point(844, 7)
        Me.txt_Com_Port.Name = "txt_Com_Port"
        Me.txt_Com_Port.Size = New System.Drawing.Size(68, 26)
        Me.txt_Com_Port.TabIndex = 137
        '
        'Main_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1540, 892)
        Me.Controls.Add(Me.txt_Com_Port)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btn_Connected)
        Me.Controls.Add(Me.panel_Bottom)
        Me.Controls.Add(Me.Panel_Top)
        Me.Controls.Add(Me.btn_Test_2)
        Me.Controls.Add(Me.btn_Test)
        Me.Controls.Add(Me.txt_Test)
        Me.Controls.Add(Me.ts_Main)
        Me.Controls.Add(Me.Status_Strip)
        Me.KeyPreview = True
        Me.Name = "Main_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Main_Form"
        Me.Tab_Main.ResumeLayout(False)
        Me.Tab_Gcode.ResumeLayout(False)
        Me.Tab_Jog_Probe.ResumeLayout(False)
        Me.Tab_Jog_Probe.PerformLayout()
        Me.Tab_Fixture_Offsets.ResumeLayout(False)
        Me.Tab_Fixture_Offsets.PerformLayout()
        Me.Tab_Home.ResumeLayout(False)
        Me.Tab_Home.PerformLayout()
        Me.Tab_Trace.ResumeLayout(False)
        Me.Tab_Trace.PerformLayout()
        Me.ts_Trace.ResumeLayout(False)
        Me.ts_Trace.PerformLayout()
        Me.Tab_Diagnostics.ResumeLayout(False)
        Me.Tab_Diagnostics.PerformLayout()
        Me.Status_Strip.ResumeLayout(False)
        Me.Status_Strip.PerformLayout()
        Me.ts_Main.ResumeLayout(False)
        Me.ts_Main.PerformLayout()
        Me.panel_Bottom.ResumeLayout(False)
        Me.Panel_Top.ResumeLayout(False)
        Me.Panel_Top.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tab_Main As System.Windows.Forms.TabControl
    Friend WithEvents Tab_Home As System.Windows.Forms.TabPage
    Friend WithEvents Tab_Trace As System.Windows.Forms.TabPage
    Friend WithEvents txt_Trace As System.Windows.Forms.TextBox
    Friend WithEvents Status_Strip As System.Windows.Forms.StatusStrip
    Friend WithEvents ts_Main As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Main_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents panel_Bottom As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ts_Download_Settings As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Macros As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Reset_Controller As System.Windows.Forms.ToolStripButton
    Friend WithEvents stat_Fault As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Tab_Test As System.Windows.Forms.TabPage
    Friend WithEvents Button_Enable_X As System.Windows.Forms.Button
    Friend WithEvents Button_Home_Z As System.Windows.Forms.Button
    Friend WithEvents Button_Home_Y As System.Windows.Forms.Button
    Friend WithEvents Button_Home_X As System.Windows.Forms.Button
    Friend WithEvents Button_Enable_Z As System.Windows.Forms.Button
    Friend WithEvents Button_Enable_Y As System.Windows.Forms.Button
    Friend WithEvents ts_Main_State As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txt_Test As System.Windows.Forms.TextBox
    Friend WithEvents Tab_Jog_Probe As System.Windows.Forms.TabPage
    Friend WithEvents Button_Probe_Z_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Y_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Y_Plus As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Start_X As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Distance As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Button_Probe_X_Plus As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_X_Minus As System.Windows.Forms.Button
    Friend WithEvents ts_Trace As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Trace_Clear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Trace_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tab_Diagnostics As System.Windows.Forms.TabPage
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txt_State_Previous As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txt_State_Last As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_State_Current As System.Windows.Forms.TextBox
    Friend WithEvents Tab_Gcode As System.Windows.Forms.TabPage
    Friend WithEvents Process_Box As Chip.ctrl_Process
    Friend WithEvents Button_Home_XYZ As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Gap_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Surface_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_End_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Start_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Gap_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Surface_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_End_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Start_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Gap_X As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Surface_X As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_End_X As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Diameter As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_State As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ts_Camera As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Test As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Feedrate As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Center_XY As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Center_Gap_Y_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Center_Gap_Y_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Center_Gap_X_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Center_Gap_X_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Center_Delta_X As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Probe_Center_Delta_Y As System.Windows.Forms.TextBox
    Friend WithEvents ts_Help As System.Windows.Forms.ToolStripButton
    Friend WithEvents chk_Trace_Filter_Events As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Routine_Names As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Macro_Events As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_System_Events As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Queue As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Status As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Received As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Sent As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Column_3 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Column_2 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Trace_Column_1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button_Probe_Corner_SW As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Corner_SE As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Corner_NE As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Corner_NW As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Center As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Move_X_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Move_Z_Down As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Move_Z_Up As System.Windows.Forms.TextBox
    Friend WithEvents Button_Move_Z_Plus As System.Windows.Forms.Button
    Friend WithEvents Button_Move_Z_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Move_X_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Move_X_Plus As System.Windows.Forms.Button
    Friend WithEvents Button_Move_Y_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Move_Y_Plus As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Move_X_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Move_Y_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Move_Y_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Jog_Rate_Little_Step As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Jog_Rate_Big_Step As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Jog_Rate_Creep As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Jog_Rate_Slow As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Jog_Rate_Fast As System.Windows.Forms.TextBox
    Friend WithEvents Button_Jog_Rate_Little_Step As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_Rate_Big_Step As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_Rate_Creep As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_Rate_Slow As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button_Jog_Rate_Fast As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_Z_Plus As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_Z_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_X_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_X_Plus As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_Y_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Jog_Y_Plus As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chk_Soft_Limits As System.Windows.Forms.CheckBox
    Friend WithEvents ts_Verify_Settings As System.Windows.Forms.ToolStripButton
    Friend WithEvents Text_Box_Jog_Safe_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents chk_Move_Raise_Z As System.Windows.Forms.CheckBox
    Friend WithEvents Text_Box_Probe_Safe_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Button_Probe_Load As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Save As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Center_Move_To_Center As System.Windows.Forms.Button
    Friend WithEvents btn_Test_2 As System.Windows.Forms.Button
    Friend WithEvents top_Splitter As System.Windows.Forms.Splitter
    Friend WithEvents lab_X As System.Windows.Forms.Label
    Friend WithEvents lab_Y As System.Windows.Forms.Label
    Friend WithEvents lab_Z As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Work_Pos_X As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Work_Pos_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Work_Pos_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Feedrate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Abs_Pos_X As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Abs_Pos_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Abs_Pos_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Jog_Rate_Selected As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Velocity As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Offset_X As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Offset_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Offset_Z As System.Windows.Forms.TextBox
    Friend WithEvents Button_E_Stop As System.Windows.Forms.Button
    Friend WithEvents Button_Set_X As System.Windows.Forms.Button
    Friend WithEvents Button_Set_Y As System.Windows.Forms.Button
    Friend WithEvents Button_Set_Z As System.Windows.Forms.Button
    Friend WithEvents Button_Coolant As System.Windows.Forms.Button
    Friend WithEvents Button_Spindle As System.Windows.Forms.Button
    Friend WithEvents Button_Feed As System.Windows.Forms.Button
    Friend WithEvents Button_Cycle As System.Windows.Forms.Button
    Friend WithEvents Button_Goto_Home As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Button_Goto_Park As System.Windows.Forms.Button
    Friend WithEvents Button_Goto_Tool_Change As System.Windows.Forms.Button
    Friend WithEvents Button_GoTo_Tool_Seat As System.Windows.Forms.Button
    Friend WithEvents Button_Probe_Loaded As System.Windows.Forms.Button
    Friend WithEvents Button_Homed As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Coordinate_System As System.Windows.Forms.TextBox
    Friend WithEvents Panel_Top As System.Windows.Forms.Panel
    Friend WithEvents btn_Connected As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_Com_Port As System.Windows.Forms.TextBox
    Friend WithEvents Tab_Fixture_Offsets As System.Windows.Forms.TabPage
    Friend WithEvents Text_Box_Fixture_Offset_Total_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Fixture_Offset_Delta_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Fixture_Offset_Original_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Button_Fixture_Offset_Reset_Y As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Fixture_Offset_Total_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Fixture_Offset_Delta_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Fixture_Offset_Original_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Button_Fixture_Offset_Reset_X As System.Windows.Forms.Button
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Fixture_Offset_Total_X As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Fixture_Offset_Delta_X As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Fixture_Offset_Original_X As System.Windows.Forms.TextBox
    Friend WithEvents Button_Fixture_Offset_Adjust_Plus_Z As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Adjust_Minus_Z As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Adjust_Minus_X As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Adjust_Plus_X As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Adjust_Minus_Y As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Adjust_Plus_Y As System.Windows.Forms.Button
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Fixture_Offset_Increment As System.Windows.Forms.TextBox
    Friend WithEvents Button_Fixture_Offset_Reset_Z As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Square_Error_Y As System.Windows.Forms.TextBox
    Friend WithEvents Button_Square_Probe_Y_Minus As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Square_X_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Button_Square_Goto_X_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Square_Goto_Y_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Square_Goto_Y_Plus As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Square_Y_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Square_Y_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Square_Error_X As System.Windows.Forms.TextBox
    Friend WithEvents Button_Square_Probe_X_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Square_Probe_X_Plus As System.Windows.Forms.Button
    Friend WithEvents Button_Square_Probe_Y_Plus As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Square_X_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Button_Square_Goto_X_Plus As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Probe_Set_Gap As System.Windows.Forms.TextBox
    Friend WithEvents chk_Move_Set_Gap As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button_Square_Goto_Z As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Square_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Square_Gap_X_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Square_Gap_X_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Square_Gap_Y_Plus As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Square_Gap_Y_Minus As System.Windows.Forms.TextBox
    Friend WithEvents Button_Fixture_Offset_Goto As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Load As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Save As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Set As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Fixture_Offset_Folder As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Fixture_Offset_File As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_File As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Probe_Folder As System.Windows.Forms.TextBox
    Friend WithEvents Button_Fixture_Offset_Z0_Top As System.Windows.Forms.Button
    Friend WithEvents Button_Fixture_Offset_Z0_Bottom As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Tool_Park_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Tool_Park_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Tool_Park_X As System.Windows.Forms.TextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Tool_Measure_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Tool_Measure_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Tool_Measure_X As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Tool_Seat_Z As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Tool_Seat_Y As System.Windows.Forms.TextBox
    Friend WithEvents Text_Box_Tool_Seat_X As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Tool_Change_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Tool_Change_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Tool_Change_X As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Button_Tool_Measure_Top As System.Windows.Forms.Button
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Button_Material_Measure As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Fixture_Offset_Material_Thickness As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Button_Tool_Measure_Bottom As System.Windows.Forms.Button
    Friend WithEvents Text_Box_Fixture_Offset_Material_Bottom As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Text_Box_Fixture_Offset_Material_Top As System.Windows.Forms.TextBox
    Friend WithEvents Button_GoTo_Tool_Measure As System.Windows.Forms.Button
End Class
