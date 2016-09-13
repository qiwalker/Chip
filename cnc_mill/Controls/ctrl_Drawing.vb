Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ctrl_Drawing

#Region "Declarations"

    Private Const Line_Width As Integer = 1

    Public Grid_Color As New Pen(Color.Gray, 1)
    Public Grid_Hash_Color As New Pen(Color.LightGray, 2)
    Public Grid_Tick_Color As New Pen(Color.LightGray, 1)

    Public Next_Move_Color As New Pen(Color.Red, Line_Width)
    Public Highlight_Color As New Pen(Color.Fuchsia, Line_Width * 4)

    Public Rapid_Path_Color As New Pen(Color.Red, Line_Width)
    Public Rapid_Cutting_Color As New Pen(Color.Yellow, Line_Width + 2)
    Public Rapid_Cut_Color As New Pen(Color.Firebrick, Line_Width + 1)

    Public Path_Color As New Pen(Color.DarkTurquoise, Line_Width)
    Public Path_Cutting_Color As New Pen(Color.Magenta, Line_Width + 2)
    Public Path_Cut_Color As New Pen(Color.GreenYellow, Line_Width + 1)

    Public Z_Path_Color As New Pen(Color.Fuchsia, Line_Width)
    Public Z_Cutting_Color As New Pen(Color.Yellow, Line_Width + 2)
    Public Z_Cut_Color As New Pen(Color.Orchid, Line_Width + 1)

    Public Show_Rapid As Boolean = False

    Public Enum enum_Block_Type
        Grid
        Grid_Hash
        Grid_Tick
        Non_Move
        Line
        Arc_CW
        Arc_CCW
        Rapid
        Z_Move
        Z_Rapid
    End Enum

    Public Enum enum_Block_Status
        Not_Cut
        Next_Cut
        Cut
    End Enum

    Public Structure struct_Block
        Public Type As enum_Block_Type
        Public Status As enum_Block_Status
        Public Code As String
        Public X As Single
        Public Y As Single
        Public Z As Single
        Public I As Single
        Public J As Single
        Public Rapid As Boolean
    End Structure

    Public Drawing_Blocks As New List(Of struct_Block)

    Public Structure struct_Draw_Point
        Public Type As enum_Block_Type
        Public Block_Number As Integer
        Public Xo As Single
        Public Yo As Single
        Public Zo As Single
        Public Xt As Single
        Public Yt As Single
        Public Zt As Single
    End Structure

    Public Grid_Points As New List(Of struct_Draw_Point)
    Public Draw_Points As New List(Of struct_Draw_Point)
    Public Block_Points As New List(Of struct_Draw_Point)

    Private X_Max As Single
    Private Y_Max As Single
    Private Z_Max As Single

    Private Offset_X As Single = 0
    Private Offset_Y As Single = 0
    Private Offset_Z As Single = 0
    Private Use_Offsets As Boolean

    Private Rad_X As Single
    Private Rad_Y As Single
    Private Rad_Z As Single

    Private C_X As Single
    Private S_X As Single
    Private C_Y As Single
    Private S_Y As Single
    Private C_Z As Single
    Private S_Z As Single

    Private Drawing_Granularity As Single = 0.001

    Public WithEvents Part_Drawing As Class_Canvas

    Public Test_Mode As Boolean = False

    Private Last_Point_Drawn As Integer

    Private Control_Symbol As Class_Symbols.class_Symbol
    Public GCode_Control As ctrl_Gcode

    Private Cutting_Start_X_Shadow As Single
    Private Cutting_Start_Y_Shadow As Single
    Private Cutting_Start_Z_Shadow As Single

    Private Initialized As Boolean = False
    Private Setup_Done As Boolean = False


#End Region

#Region "Properties"

    Private Property Setting_Scale As Single
        Get
            Return Part_Drawing.Scale
        End Get
        Set(ByVal value As Single)
            Part_Drawing.Scale = value
            txt_Scale.Text = value
        End Set
    End Property

    Private Property Setting_X_Angle As Single
        Get
            Return Part_Drawing.X_Angle
        End Get
        Set(ByVal value As Single)
            Part_Drawing.X_Angle = value
            ud_X_Angle.Text = value
        End Set
    End Property

    Private Property Setting_Y_Angle As Single
        Get
            Return Part_Drawing.Y_Angle
        End Get
        Set(ByVal value As Single)
            Part_Drawing.Y_Angle = value
            ud_Y_Angle.Text = value
        End Set
    End Property

    Private Property Setting_Z_Angle As Single
        Get
            Return Part_Drawing.Z_Angle
        End Get
        Set(ByVal value As Single)
            Part_Drawing.Z_Angle = value
            ud_Z_Angle.Text = value
        End Set
    End Property

    Private Property Setting_Z_Scale As Single
        Get
            Return Part_Drawing.Z_Scale
        End Get
        Set(ByVal value As Single)
            Part_Drawing.Z_Scale = value
            ud_Z_Scale.Text = value
        End Set
    End Property

    Private Property Setting_Show_Rapid As Boolean
        Get
            Return Show_Rapid
        End Get
        Set(ByVal value As Boolean)
            Show_Rapid = value
            If value Then
                btn_Show_Rapid.Text = "Hide Rapid"
            Else
                btn_Show_Rapid.Text = "Show Rapid"
            End If
        End Set
    End Property

    Private Property Setting_Top As Integer
        Get
            Return Part_Drawing.Canvas_Ctl.Top
        End Get
        Set(ByVal value As Integer)
            Part_Drawing.Canvas_Ctl.Top = value
        End Set
    End Property

    Private Property Setting_Left As Integer
        Get
            Return Part_Drawing.Canvas_Ctl.Left
        End Get
        Set(ByVal value As Integer)
            Part_Drawing.Canvas_Ctl.Left = value
        End Set
    End Property

#End Region

#Region "Initialize, Setup, Reset, Close"

    Public Sub Initialize(ByRef sym As Class_Symbols.class_Symbol, X_Maximum As Single, Y_Maximum As Single, Z_Maximum As Single, _
                          Optional GCode_Ctrl As ctrl_Gcode = Nothing)
        If Not IsNothing(GCode_Ctrl) Then GCode_Control = GCode_Ctrl
        X_Max = X_Maximum
        Y_Max = Y_Maximum
        Z_Max = Z_Maximum
        Control_Symbol = sym
        Part_Drawing = New Class_Canvas(Main_Form, pnl_Canvas, pnl_Viewport, X_Max, Y_Max)

        ud_X_Angle.Left = ts_Drawing.Left + ts_Drawing.Width + 25
        ud_Y_Angle.Left = ud_X_Angle.Left + 75
        ud_Z_Angle.Left = ud_Y_Angle.Left + 75
        txt_Scale.Left = ud_Z_Angle.Left + 75

        lab_X.Left = ud_X_Angle.Left + (ud_X_Angle.Width / 2) - (lab_X.Width / 2)
        lab_Y.Left = ud_Y_Angle.Left + (ud_Y_Angle.Width / 2) - (lab_Y.Width / 2)
        lab_Z.Left = ud_Z_Angle.Left + (ud_Z_Angle.Width / 2) - (lab_Z.Width / 2)

        txt_Scale.Width = 50
        txt_Scale.TextAlign = HorizontalAlignment.Right
        lab_Scale.Left = txt_Scale.Left + (txt_Scale.Width / 2) - (lab_Scale.Width / 2)
        txt_Scale.Top = ud_X_Angle.Top
        txt_Scale.Text = "1"

        ud_Z_Scale.Left = txt_Scale.Left + txt_Scale.Width + 20
        lab_Z_Scale.Left = ud_Z_Scale.Left + (ud_Z_Scale.Width / 2) - (lab_Z_Scale.Width / 2)

        btn_Max.Left = ud_Z_Scale.Left + ud_Z_Scale.Width + 10
        btn_Min.Left = ud_Z_Scale.Left + ud_Z_Scale.Width + 10

        pnl_Top.Controls.Add(txt_Scale)

        Initialized = True

    End Sub

    Public Sub Setup()
        Setup_Done = False

        Setting_Scale = Settings.Get_Setting(Control_Symbol.Name, "Setting_Scale", 1, "Single", True)
        Setting_Show_Rapid = Settings.Get_Setting(Control_Symbol.Name, "Setting_Show_Rapid", False, "Boolean", True)
        Setting_Top = Settings.Get_Setting(Control_Symbol.Name, "Setting_Top", -1000, "Integer", True)
        Setting_Left = Settings.Get_Setting(Control_Symbol.Name, "Setting_Left", 0, "Integer", True)
        Setting_X_Angle = Settings.Get_Setting(Control_Symbol.Name, "Setting_X_Angle", 0, "Single", True)
        Setting_Y_Angle = Settings.Get_Setting(Control_Symbol.Name, "Setting_Y_Angle", 0, "Single", True)
        Setting_Y_Angle = Settings.Get_Setting(Control_Symbol.Name, "Setting_Y_Angle", 0, "Single", True)
        Setting_Z_Angle = Settings.Get_Setting(Control_Symbol.Name, "Setting_Z_Angle", 0, "Single", True)
        Setting_Z_Scale = Settings.Get_Setting(Control_Symbol.Name, "Setting_Z_Scale", 0, "Single", True)
        ts_Offsets_On.Visible = Settings.Get_Setting(Control_Symbol.Name, "Offsets_On", False, "Boolean", True)

        Load_Drawing_Points(GCode_Control)
        Draw_Cutter_Path(True)

        Setup_Done = True
    End Sub

    Public Sub Reset(Optional Controls As Boolean = False)
        If Controls Then
            Part_Drawing.Reset_View_Controls(False)
        End If
        'Load_Drawing_Points(GCode_Control) 'Link to GCode control that this control is linked to
        Draw_Cutter_Path()
    End Sub

    Public Sub Finish()
        Settings.Put_Setting(Control_Symbol.Name, "Setting_Scale", Setting_Scale, True)
        Settings.Put_Setting(Control_Symbol.Name, "Setting_Show_Rapid", Setting_Show_Rapid, True)
        Settings.Put_Setting(Control_Symbol.Name, "Setting_Top", Setting_Top, True)
        Settings.Put_Setting(Control_Symbol.Name, "Setting_Left", Setting_Left, True)
        Settings.Put_Setting(Control_Symbol.Name, "Setting_X_Angle", Setting_X_Angle, True)
        Settings.Put_Setting(Control_Symbol.Name, "Setting_Y_Angle", Setting_Y_Angle, True)
        Settings.Put_Setting(Control_Symbol.Name, "Setting_Z_Angle", Setting_Z_Angle, True)
        Settings.Put_Setting(Control_Symbol.Name, "Setting_Z_Scale", Setting_Z_Scale, True)
        Settings.Put_Setting(Control_Symbol.Name, "Offsets_On", ts_Offsets_On.Visible)
    End Sub

#End Region

#Region "Drawing Routines"

    Public Sub Clear_Drawing()
        Drawing_Blocks.Clear()
    End Sub

    Public Sub Draw_Cutter_Path(Optional Reset As Boolean = False)
        Dim G_Mode As String = ""
        Dim Draw_Pen As Pen = Pens.Black

        If Reset Then
            Dim B As struct_Block
            For I = 0 To Drawing_Blocks.Count - 1
                B = Drawing_Blocks(I)
                B.Status = enum_Block_Status.Not_Cut
                Drawing_Blocks(I) = B
            Next
        End If

        Translate_Points()

        Part_Drawing.Start_Drawing()
        Part_Drawing.Clear_Drawing()


        Dim P As Integer = 1

        Do While P < Grid_Points.Count - 1
            Select Case Grid_Points(P).Type
                Case enum_Block_Type.Grid
                    Part_Drawing.Draw_Line(Grid_Color, Grid_Points(P).Xt, Grid_Points(P).Yt, Grid_Points(P + 1).Xt, Grid_Points(P + 1).Yt)
                Case enum_Block_Type.Grid_Hash
                    Part_Drawing.Draw_Line(Grid_Hash_Color, Grid_Points(P).Xt, Grid_Points(P).Yt, Grid_Points(P + 1).Xt, Grid_Points(P + 1).Yt)
                Case enum_Block_Type.Grid_Tick
                    Part_Drawing.Draw_Line(Grid_Tick_Color, Grid_Points(P).Xt, Grid_Points(P).Yt, Grid_Points(P + 1).Xt, Grid_Points(P + 1).Yt)
            End Select
            P += 2
        Loop

        For I = 0 To Draw_Points.Count - 1
            Draw_Pen = Path_Color

            Select Case Drawing_Blocks(Draw_Points(I).Block_Number).Status

                Case enum_Block_Status.Not_Cut
                    Select Case Drawing_Blocks(Draw_Points(I).Block_Number).Type

                        Case enum_Block_Type.Grid
                            Draw_Pen = Grid_Color

                        Case enum_Block_Type.Line, enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                            Draw_Pen = Path_Color

                        Case enum_Block_Type.Rapid
                            Draw_Pen = Rapid_Path_Color

                        Case enum_Block_Type.Z_Move, enum_Block_Type.Z_Rapid
                            Draw_Pen = Z_Path_Color

                    End Select

                Case enum_Block_Status.Next_Cut
                    Draw_Pen = Next_Move_Color

                Case enum_Block_Status.Cut
                    Select Case Drawing_Blocks(Draw_Points(I).Block_Number).Type

                        Case enum_Block_Type.Grid
                            Draw_Pen = Grid_Color

                        Case enum_Block_Type.Line, enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                            Draw_Pen = Path_Cut_Color

                        Case enum_Block_Type.Rapid
                            Draw_Pen = Rapid_Cut_Color

                        Case enum_Block_Type.Z_Move, enum_Block_Type.Z_Rapid
                            Draw_Pen = Z_Cut_Color

                    End Select
            End Select

            If Test_Mode Then
                If I > 0 Then

                    Message_Box.ShowDialog("Point Index:" & I & vbCrLf & _
                                           "I : " & I & vbCrLf & _
                                           "Block : " & Draw_Points(I - 1).Block_Number & " ~ " & Draw_Points(I).Block_Number & vbCrLf & _
                                           "Xo " & Draw_Points(I - 1).Xo & ", " & "Yo " & Draw_Points(I - 1).Yo & " to " & _
                                           "Xo " & Draw_Points(I).Xo & ", " & "Yo " & Draw_Points(I).Yo & vbCrLf & _
                                           "Xt " & Draw_Points(I - 1).Xt & ", " & "Yt " & Draw_Points(I - 1).Yt & " to " & _
                                           "Xt " & Draw_Points(I).Xt & ", " & "Yt " & Draw_Points(I).Yt & vbCrLf, "", MessageBoxButtons.OKCancel)

                    Part_Drawing.Test_Refresh_Drawing()

                    If Message_Box.DialogResult <> DialogResult.OK Then
                        Test_Mode = False
                    End If

                End If

            End If

            Select Case Drawing_Blocks(Draw_Points(I).Block_Number).Type

                Case enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                    Nop()
                    'Part_Drawing.Draw_Arc(Draw_Pen, Drawing_Blocks(Draw_Points(I).Block_Number))

                Case enum_Block_Type.Rapid, enum_Block_Type.Z_Rapid
                    If Show_Rapid Then
                        If I > 0 Then
                            Part_Drawing.Draw_Line(Draw_Pen, Draw_Points(I - 1).Xt, Draw_Points(I - 1).Yt, Draw_Points(I).Xt, Draw_Points(I).Yt)
                        End If
                    End If
                Case Else
                    If I > 0 Then
                        Part_Drawing.Draw_Line(Draw_Pen, Draw_Points(I - 1).Xt, Draw_Points(I - 1).Yt, Draw_Points(I).Xt, Draw_Points(I).Yt)
                    End If
            End Select

        Next

Skip:

        Part_Drawing.Finish_Drawing()

    End Sub

    Public Sub Reset_Draw_Cutting()
        If Use_Offsets Then
            Cutting_Start_X_Shadow = Symbol.Get_Value("Sys.Abs_X")
            Cutting_Start_Y_Shadow = Symbol.Get_Value("Sys.Abs_Y")
            Cutting_Start_Z_Shadow = (Symbol.Get_Value("Sys.Abs_Z") - Offset_Z) / Setting_Z_Scale
        Else
            Cutting_Start_X_Shadow = Symbol.Get_Value("Sys.Work_X")
            Cutting_Start_Y_Shadow = Symbol.Get_Value("Sys.Work_Y")
            Cutting_Start_Z_Shadow = Symbol.Get_Value("Sys.Work_Z") / Setting_Z_Scale
        End If
    End Sub

    Public Sub Draw_Cutting(Evnt As Class_CNC.class_Event)
        Dim Start_Point As ctrl_Drawing.struct_Draw_Point
        Dim End_Point As ctrl_Drawing.struct_Draw_Point

        Start_Point.Xt = Cutting_Start_X_Shadow
        Start_Point.Yt = Cutting_Start_Y_Shadow
        Start_Point.Zt = Cutting_Start_Z_Shadow

        If GCode_Control.Offsets_On Then
            If Use_Offsets Then
                End_Point.Xt = Symbol.Get_Value("Sys.Abs_X")
                End_Point.Yt = Symbol.Get_Value("Sys.Abs_Y")
                End_Point.Zt = (Symbol.Get_Value("Sys.Abs_Z") - Offset_Z) / Setting_Z_Scale
            Else
                End_Point.Xt = Symbol.Get_Value("Sys.Work_X")
                End_Point.Yt = Symbol.Get_Value("Sys.Work_Y")
                End_Point.Zt = Symbol.Get_Value("Sys.Work_Z") / Setting_Z_Scale
            End If
        Else
            End_Point.Xt = Symbol.Get_Value("Sys.Abs_X")
            End_Point.Yt = Symbol.Get_Value("Sys.Abs_Y")
            End_Point.Zt = Symbol.Get_Value("Sys.Abs_Z") / Setting_Z_Scale
        End If

        Cutting_Start_X_Shadow = End_Point.Xt
        Cutting_Start_Y_Shadow = End_Point.Yt
        Cutting_Start_Z_Shadow = End_Point.Zt

        Dim Rad_X As Single = Part_Drawing.X_Angle * Math.PI / 180
        Dim Rad_Y As Single = Part_Drawing.Y_Angle * Math.PI / 180
        Dim Rad_Z As Single = Part_Drawing.Z_Angle * Math.PI / 180

        Dim C_X = Math.Cos(Rad_X)
        Dim S_X = Math.Sin(Rad_X)
        Dim C_Y = Math.Cos(Rad_Y)
        Dim S_Y = Math.Sin(Rad_Y)
        Dim C_Z = Math.Cos(Rad_Z)
        Dim S_Z = Math.Sin(Rad_Z)

        Dim D As Single

        'Rotate around X
        Start_Point.Zt = (Start_Point.Zt * C_X) - (Start_Point.Yt * S_X)
        Start_Point.Yt = (Start_Point.Zt * S_X) + (Start_Point.Yt * C_X)

        'Rotate around Y
        Start_Point.Zt = (Start_Point.Zt * C_Y) - (Start_Point.Xt * S_Y)
        Start_Point.Xt = (Start_Point.Zt * S_Y) + (Start_Point.Xt * C_Y)

        'Rotate around Z
        Start_Point.Xt = (Start_Point.Xt * C_Z) - (Start_Point.Yt * S_Z)
        Start_Point.Yt = (Start_Point.Xt * S_Z) + (Start_Point.Yt * C_Z)

        D = Math.Abs(Math.Pow(Start_Point.Zt + sgn(Start_Point.Zt), sgn(Start_Point.Zt)))
        Start_Point.Xt = (Start_Point.Xt * D)
        Start_Point.Yt = (Start_Point.Yt * D)

        Start_Point.Xt = (Start_Point.Xt * Part_Drawing.X_Scale)
        Start_Point.Yt = Part_Drawing.Height - (Start_Point.Yt * Part_Drawing.Y_Scale)

        'Rotate around X
        End_Point.Zt = (End_Point.Zt * C_X) - (End_Point.Yt * S_X)
        End_Point.Yt = (End_Point.Zt * S_X) + (End_Point.Yt * C_X)

        'Rotate around Y
        End_Point.Zt = (End_Point.Zt * C_Y) - (End_Point.Xt * S_Y)
        End_Point.Xt = (End_Point.Zt * S_Y) + (End_Point.Xt * C_Y)

        'Rotate around Z
        End_Point.Xt = (End_Point.Xt * C_Z) - (End_Point.Yt * S_Z)
        End_Point.Yt = (End_Point.Xt * S_Z) + (End_Point.Yt * C_Z)

        D = Math.Abs(Math.Pow(End_Point.Zt + sgn(End_Point.Zt), sgn(End_Point.Zt)))
        End_Point.Xt = (End_Point.Xt * D)
        End_Point.Yt = (End_Point.Yt * D)

        End_Point.Xt = (End_Point.Xt * Part_Drawing.X_Scale)
        End_Point.Yt = Part_Drawing.Height - (End_Point.Yt * Part_Drawing.Y_Scale) - 1

        Part_Drawing.Draw_Cut_Line(Path_Cutting_Color, Start_Point.Xt, Start_Point.Yt, End_Point.Xt, End_Point.Yt)

    End Sub

    Public Sub Show_Next_Move(Block_Number As Integer, Optional Highlight As Boolean = False)
        If Block_Number = 0 Then Exit Sub

        If (Block_Number > 1) And (Block_Number < Block_Points.Count - 2) Then

            Dim Pt As struct_Draw_Point
            Dim Next_Pt As struct_Draw_Point
            Dim C As Pen

            If Highlight Then
                C = Highlight_Color
            Else
                C = Next_Move_Color
            End If

            Pt = Block_Points(Block_Number - 1)
            Next_Pt = Block_Points(Block_Number)

            Dim Blk As struct_Block = Drawing_Blocks(Block_Number - 1)
            Blk.Status = enum_Block_Status.Next_Cut

            Select Case Drawing_Blocks(Block_Number).Type
                Case enum_Block_Type.Rapid
                    If Show_Rapid Then
                        Part_Drawing.Draw_Cut_Line(C, Pt.Xt, Pt.Yt, Next_Pt.Xt, Next_Pt.Yt)
                    End If
                Case enum_Block_Type.Z_Rapid
                    If Show_Rapid Then
                        Part_Drawing.Draw_Cut_Line(C, Pt.Xt, Pt.Yt, Next_Pt.Xt, Next_Pt.Yt)
                    End If
                Case Else
                    Part_Drawing.Draw_Cut_Line(C, Pt.Xt, Pt.Yt, Next_Pt.Xt, Next_Pt.Yt)
            End Select

        End If

    End Sub

    Public Sub Mark_As_Cut(Block_Number As Integer)
        If Block_Number <= 0 Then Exit Sub
        If Block_Number > Block_Points.Count - 1 Then Exit Sub

        Dim Blk As struct_Block = Drawing_Blocks(Block_Number)
        Dim Pt As struct_Draw_Point = Block_Points(Block_Number)
        Dim Prev_Pt As struct_Draw_Point = Block_Points(Block_Number - 1)
        Dim Prev_Blk As struct_Block = Drawing_Blocks(Block_Number - 1)

        Select Case Drawing_Blocks(Block_Number).Type

            Case enum_Block_Type.Rapid
                If Show_Rapid Then
                    Part_Drawing.Draw_Line(Rapid_Cut_Color, Prev_Pt.Xt, Prev_Pt.Yt, Pt.Xt, Pt.Yt, True)
                End If
                Blk.Status = enum_Block_Status.Cut

            Case enum_Block_Type.Line
                Part_Drawing.Draw_Line(Path_Cut_Color, Prev_Pt.Xt, Prev_Pt.Yt, Pt.Xt, Pt.Yt, True)
                Blk.Status = enum_Block_Status.Cut

            Case enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                Blk.Status = enum_Block_Status.Cut

            Case enum_Block_Type.Z_Move
                Part_Drawing.Draw_Line(Z_Cut_Color, Prev_Pt.Xt, Prev_Pt.Yt, Pt.Xt, Pt.Yt, True)
                Blk.Status = enum_Block_Status.Cut


            Case enum_Block_Type.Z_Rapid
                If Show_Rapid Then
                    Part_Drawing.Draw_Line(Z_Cut_Color, Prev_Pt.Xt, Prev_Pt.Yt, Pt.Xt, Pt.Yt, True)
                End If
                Blk.Status = enum_Block_Status.Cut

        End Select

        Drawing_Blocks(Block_Number) = Blk

    End Sub

    Public Function PointOnCircle(Radius As Single, AngleInDegrees As Single, Origin As PointF) As PointF
        ' Convert from degrees to radians via multiplication by PI/180        
        Dim Pt As PointF
        Pt.X = CSng(Radius * Math.Cos(AngleInDegrees * Math.PI / 180.0F)) + Origin.X
        Pt.Y = CSng(Radius * Math.Sin(AngleInDegrees * Math.PI / 180.0F)) + Origin.Y
        Return Pt
    End Function

    Private Function sgn(x As Single) As Single
        If x = 0 Then Return 0
        Return Math.Abs(x) / x
    End Function

    Public Sub Translate_Angles()
        Rad_X = Part_Drawing.X_Angle * Math.PI / 180
        Rad_Y = Part_Drawing.Y_Angle * Math.PI / 180
        Rad_Z = Part_Drawing.Z_Angle * Math.PI / 180

        C_X = Math.Cos(Rad_X)
        S_X = Math.Sin(Rad_X)
        C_Y = Math.Cos(Rad_Y)
        S_Y = Math.Sin(Rad_Y)
        C_Z = Math.Cos(Rad_Z)
        S_Z = Math.Sin(Rad_Z)
    End Sub

    Public Sub Translate_Point(ByRef Pt As struct_Draw_Point, Show_Offsets As Boolean)
        Dim D As Single

        Offset_X = Symbol.Get_Value("Sys.Offset_X")
        Offset_Y = Symbol.Get_Value("Sys.Offset_Y")
        Offset_Z = Symbol.Get_Value("Sys.Offset_Z")
        If Setting_Z_Scale = 0 Then Setting_Z_Scale = 1

        If GCode_Control.Offsets_On And Show_Offsets And Use_Offsets Then
            Pt.Xt = Pt.Xo + Offset_X
            Pt.Yt = Pt.Yo + Offset_Y
            Pt.Zt = Pt.Zo / Setting_Z_Scale
        Else
            Pt.Xt = Pt.Xo
            Pt.Yt = Pt.Yo
            Pt.Zt = Pt.Zo / Setting_Z_Scale
        End If

        'Rotate around X
        Pt.Zt = (Pt.Zt * C_X) - (Pt.Yt * S_X)
        Pt.Yt = (Pt.Zt * S_X) + (Pt.Yt * C_X)

        'Rotate around Y
        Pt.Zt = (Pt.Zt * C_Y) - (Pt.Xt * S_Y)
        Pt.Xt = (Pt.Zt * S_Y) + (Pt.Xt * C_Y)

        'Rotate around Z
        Pt.Xt = (Pt.Xt * C_Z) - (Pt.Yt * S_Z)
        Pt.Yt = (Pt.Xt * S_Z) + (Pt.Yt * C_Z)

        'Pt.Z = Pt.Zo * 2 'Lens 'zm=point[i].z/(float)lens;
        D = Math.Abs(Math.Pow(Pt.Zt + sgn(Pt.Zt), sgn(Pt.Zt)))

        Pt.Xt = (Pt.Xt * D)
        Pt.Yt = (Pt.Yt * D)

        Pt.Xt = (Pt.Xt * Part_Drawing.X_Scale)
        Pt.Yt = Part_Drawing.Height - (Pt.Yt * Part_Drawing.Y_Scale) - 1 'If 1 pixel not removed, bottom of drawing along Y0 is not shown

    End Sub

    Public Sub Translate_Points()
        Translate_Angles()

        Dim Pt As struct_Draw_Point

        For I = 0 To Grid_Points.Count - 1
            Pt = Grid_Points(I)
            Translate_Point(Pt, False)
            Grid_Points(I) = Pt
        Next

        For I = 0 To Block_Points.Count - 1
            Pt = Block_Points(I)
            Translate_Point(Pt, True)
            Block_Points(I) = Pt
        Next

        For I = 0 To Draw_Points.Count - 1
            Pt = Draw_Points(I)
            Translate_Point(Pt, True)
            Draw_Points(I) = Pt
        Next

    End Sub

    Public Sub Load_Drawing_Points(G_Code_Control As ctrl_Gcode)
        Dim S() As String
        Dim G_Mode As String = ""
        Dim Pt As struct_Draw_Point = Nothing
        Dim Last_X As Single = 0
        Dim Last_Y As Single = 0
        Dim Last_Z As Single = 0
        Dim Drawing_Block As struct_Block
        Static Dim Acccumulator As Single = 0

        Drawing_Blocks.Clear()

        For I = 0 To G_Code_Control.grid.RowCount - 1
            Drawing_Block = New struct_Block
            Drawing_Block.Code = G_Code_Control.grid.Rows(I).Cells(ctrl_Gcode.enum_Grid_Colums.Block).Value
            Drawing_Blocks.Add(Drawing_Block)
        Next

        Me.Cursor = Cursors.Hand

        Offset_X = Symbol.Get_Value("Sys.Offset_X")
        Offset_Y = Symbol.Get_Value("Sys.Offset_Y")
        Offset_Z = Symbol.Get_Value("Sys.Offset_Z")

        Grid_Points.Clear()
        Block_Points.Clear()
        Draw_Points.Clear()

        Pt.Xo = 0
        Pt.Yo = 0
        Pt.Zo = 0
        Grid_Points.Add(Pt)

        Pt.Block_Number = 0

        For X = 0 To X_Max

            If X Mod 10 = 0 Or X = X_Max Then
                Pt.Type = enum_Block_Type.Grid_Hash
            Else
                If X Mod 5 = 0 Then
                    Pt.Type = enum_Block_Type.Grid_Tick
                Else
                    Pt.Type = enum_Block_Type.Grid
                End If
            End If

            Pt.Xo = X
            Pt.Yo = 0
            Grid_Points.Add(Pt)

            Pt.Xo = X
            Pt.Yo = Y_Max
            Grid_Points.Add(Pt)
        Next

        For Y = 0 To Y_Max
            If Y Mod 10 = 0 Or Y = Y_Max Then
                Pt.Type = enum_Block_Type.Grid_Hash
            Else
                If Y Mod 5 = 0 Then
                    Pt.Type = enum_Block_Type.Grid_Tick
                Else
                    Pt.Type = enum_Block_Type.Grid
                End If
            End If

            Pt.Xo = 0
            Pt.Yo = Y
            Grid_Points.Add(Pt)

            Pt.Xo = X_Max
            Pt.Yo = Y
            Grid_Points.Add(Pt)
        Next

        Pt.Xo = 0
        Pt.Yo = 0
        Pt.Zo = 0
        Grid_Points.Add(Pt)

        G_Mode = ""

        For I = 0 To Drawing_Blocks.Count - 1
            Pt.Block_Number = I

            Drawing_Block = Drawing_Blocks(I)

            If (Not IsNothing(Drawing_Block.Code)) And (Mid(Drawing_Block.Code, 1, 1) <> "(") And (Mid(Drawing_Block.Code, 1, 1) <> ";") Then
                Drawing_Block.Type = enum_Block_Type.Non_Move
                Drawing_Block.Code = Drawing_Block.Code.Replace("S", " S")
                S = Drawing_Block.Code.Split(" ")

                For J = 0 To S.Count - 1
                    Select Case Mid(S(J), 1, 1)
                        Case "X"
                            Drawing_Block.X = Mid(S(J), 2)
                            Pt.Xo = Drawing_Block.X
                        Case "Y"
                            Drawing_Block.Y = Mid(S(J), 2)
                            Pt.Yo = Drawing_Block.Y
                        Case "Z"
                            Drawing_Block.Z = Mid(S(J), 2)
                            Pt.Zo = Drawing_Block.Z
                        Case "I"
                            Drawing_Block.I = Mid(S(J), 2)
                        Case "J"
                            Drawing_Block.J = Mid(S(J), 2)
                    End Select

                    Select Case S(J)
                        Case "G00", "G01", "G02", "G03"
                            G_Mode = S(J)
                    End Select
                Next

                Select Case G_Mode
                    Case "G00"
                        Drawing_Block.Type = enum_Block_Type.Rapid
                    Case "G01"
                        Drawing_Block.Type = enum_Block_Type.Line
                    Case "G02"
                        Drawing_Block.Type = enum_Block_Type.Arc_CW
                    Case "G03"
                        Drawing_Block.Type = enum_Block_Type.Arc_CCW
                End Select

                If Pt.Zo <> Last_Z Then
                    If Drawing_Block.Type = enum_Block_Type.Rapid Then
                        Drawing_Block.Type = enum_Block_Type.Z_Rapid
                    Else
                        Drawing_Block.Type = enum_Block_Type.Z_Move
                    End If
                End If

                Select Case Drawing_Block.Type
                    Case enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CW
                        'Create points on the circle

                        'sin(θ) = Opposite / Hypotenuse
                        'cos(θ) = Adjacent / Hypotenuse
                        'tan(θ) = Opposite / Adjacent

                        Acccumulator += Math.Abs(Pt.Xo - Last_X) + Math.Abs(Pt.Yo - Last_Y)
                        If Acccumulator > Drawing_Granularity Then
                            Acccumulator = 0
                            GCode_Control.Set_Grid_Point_Cell(I, Draw_Points.Count)
                            Draw_Points.Add(Pt)
                        End If

                        Last_X = Pt.Xo
                        Last_Y = Pt.Yo
                        Last_Z = Pt.Zo

                        Block_Points.Add(Pt)

                    Case Else

                        Acccumulator += Math.Abs(Pt.Xo - Last_X) + Math.Abs(Pt.Yo - Last_Y)
                        If (Acccumulator > Drawing_Granularity) Or (Pt.Zo <> Last_Z) Or (I < 2) Then
                            Acccumulator = 0
                            GCode_Control.Set_Grid_Point_Cell(I, Draw_Points.Count)
                            Draw_Points.Add(Pt)
                        End If

                        Last_X = Pt.Xo
                        Last_Y = Pt.Yo
                        Last_Z = Pt.Zo

                        'If (Math.Abs(Pt.Xo - Last_X) > Drawing_Granularity) Or (Math.Abs(Pt.Yo - Last_Y) > Drawing_Granularity) Or (Pt.Zo <> Last_Z) Then
                        '    GCode_Control.Set_Grid_Point_Cell(I, Draw_Points.Count)
                        '    Draw_Points.Add(Pt)
                        '    Last_X = Pt.Xo
                        '    Last_Y = Pt.Yo
                        '    Last_Z = Pt.Zo
                        'End If

                        Block_Points.Add(Pt)
                End Select


                Drawing_Blocks(I) = Drawing_Block

            End If 'If Not IsNothing(Drawing_Block)
        Next

        Me.Cursor = Cursors.Arrow

    End Sub


#End Region

#Region "Up Down Buttons, Mouse_Move"

    Private Sub Part_Drawing_Rescale(Delta As Integer) Handles Part_Drawing.Rescale
        Dim X_Orig_Max As struct_Draw_Point
        Dim X_New_Max As struct_Draw_Point
        Dim X_Resize_Range As Single
        Dim X_Ratio As Single
        Dim X_Offset As Single
        Dim X_Axis As Integer
        Dim X_V As Single
        Dim X_W As Single

        Dim Y_Orig_Max As struct_Draw_Point
        Dim Y_New_Max As struct_Draw_Point
        Dim Y_Resize_Range As Single
        Dim Y_Ratio As Single
        Dim Y_Offset As Single
        Dim Y_Axis As Integer
        Dim Y_V As Single
        Dim Y_W As Single

        X_Axis = Part_Drawing.Canvas_Ctl.Left
        Y_Axis = Part_Drawing.Viewport.Viewport_Ctl.Height - Part_Drawing.Canvas_Ctl.Bottom

        X_Orig_Max.Xo = X_Max
        X_Orig_Max.Yo = 0
        X_Orig_Max.Zo = 0
        Translate_Point(X_Orig_Max, False)

        Y_Orig_Max.Xo = 0
        Y_Orig_Max.Yo = Y_Max
        Y_Orig_Max.Zo = 0
        Translate_Point(Y_Orig_Max, False)

        If Delta > 0 Then
            Part_Drawing.Scale += 0.1
        Else
            Part_Drawing.Scale -= 0.1
        End If

        If Part_Drawing.Scale > 2 Then Part_Drawing.Scale = 2

        txt_Scale.Text = Part_Drawing.Scale
        Draw_Cutter_Path()

        X_New_Max.Xo = X_Max
        X_New_Max.Yo = 0
        X_New_Max.Zo = 0
        Translate_Point(X_New_Max, False)
        X_Resize_Range = Math.Abs((X_New_Max.Xt - X_Orig_Max.Xt))
        X_V = X_Axis - (Part_Drawing.Viewport.Width / 2)
        X_W = X_Orig_Max.Xt / 2
        X_Ratio = Math.Abs(X_V / X_W) / 2
        X_Offset = X_Resize_Range * X_Ratio

        If X_New_Max.Xt > X_Orig_Max.Xt Then
            Part_Drawing.Canvas_Ctl.Left -= CInt(X_Offset)
        Else
            Part_Drawing.Canvas_Ctl.Left += CInt(X_Offset)
        End If

        Y_New_Max.Xo = 0
        Y_New_Max.Yo = Y_Max
        Y_New_Max.Zo = 0
        Translate_Point(Y_New_Max, False)
        Y_Resize_Range = Math.Abs((Y_Orig_Max.Yt - Y_New_Max.Yt))
        Y_V = Y_Axis - (Part_Drawing.Viewport.Height / 2)

        Dim Orig_Max_Y As Single = Part_Drawing.Canvas_Ctl.Height - Y_Orig_Max.Yt + 1
        Y_W = Orig_Max_Y / 2
        Y_Ratio = Math.Abs(Y_V / Y_W) / 2
        Y_Offset = Y_Resize_Range * Y_Ratio

        If Y_New_Max.Yt > Y_Orig_Max.Yt Then
            Part_Drawing.Canvas_Ctl.Top -= CInt(Y_Offset)
        Else
            Part_Drawing.Canvas_Ctl.Top += CInt(Y_Offset)
        End If

    End Sub

    Sub Part_Drawing_Reset_Rotation() Handles Part_Drawing.Reset_Rotation
        Setting_X_Angle = 0
        Setting_Y_Angle = 0
        Setting_Z_Angle = 0
        Setting_Z_Scale = 25
        Draw_Cutter_Path()
    End Sub

    Private Sub ud_X_Angle_ValueChanged() Handles ud_X_Angle.ValueChanged
        If Not Initialized Then Exit Sub
        Setting_X_Angle = ud_X_Angle.Value
        Draw_Cutter_Path()
    End Sub

    Private Sub ud_Y_Angle_ValueChanged() Handles ud_Y_Angle.ValueChanged
        If Not Initialized Then Exit Sub
        Setting_Y_Angle = ud_Y_Angle.Value
        Draw_Cutter_Path()
    End Sub

    Private Sub ud_Z_Angle_ValueChanged() Handles ud_Z_Angle.ValueChanged
        If Not Initialized Then Exit Sub
        Setting_Z_Angle = ud_Z_Angle.Value
        Draw_Cutter_Path()
    End Sub

    Private Sub ud_Z_Scale_ValueChanged(sender As Object, e As EventArgs) Handles ud_Z_Scale.ValueChanged
        If Not Initialized Then Exit Sub
        If Not Setup_Done Then Exit Sub

        Setting_Z_Scale = ud_Z_Scale.Value
        Draw_Cutter_Path()
    End Sub

#End Region

#Region "Tool strip"

    Private Sub ts_Drawing_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ts_Drawing.ItemClicked

        Select Case e.ClickedItem.Text
            Case "Test"
                Test_Mode = Not Test_Mode

            Case "Redraw"
                Part_Drawing.Test_Clear_Drawing()
                Draw_Cutter_Path()

            Case "Reset"
                Reset(True)

            Case "Show Rapid"
                btn_Show_Rapid.Text = "Hide Rapid"
                Setting_Show_Rapid = True
                Draw_Cutter_Path()

            Case "Hide Rapid"
                btn_Show_Rapid.Text = "Show Rapid"
                Setting_Show_Rapid = False
                Draw_Cutter_Path()

            Case "Offsets On"
                Use_Offsets = False
                ts_Offsets_Off.Visible = True
                ts_Offsets_On.Visible = False
                Translate_Points()
                Reset_Draw_Cutting()
                Draw_Cutter_Path()

            Case "Offsets Off"
                Use_Offsets = True
                ts_Offsets_On.Visible = True
                ts_Offsets_Off.Visible = False
                Translate_Points()
                Reset_Draw_Cutting()
                Draw_Cutter_Path()

        End Select

    End Sub

    Private Sub btn_Max_Click(sender As Object, e As EventArgs) Handles btn_Max.Click
        ud_Z_Scale.Value = ud_Z_Scale.Maximum
    End Sub

    Private Sub btn_Min_Click(sender As Object, e As EventArgs) Handles btn_Min.Click
        ud_Z_Scale.Value = ud_Z_Scale.Minimum
    End Sub

#End Region

    Private Sub Redraw() Handles Part_Drawing.Redraw
        Part_Drawing.Test_Clear_Drawing()
        Draw_Cutter_Path()
    End Sub

#Region "Classes Viewport, Canvas"

    Public Class Class_Viewport
        Public Center As Point
        Public Height As Integer
        Public Width As Integer

        Public WithEvents Viewport_Ctl As Panel

        Public Sub New(Viewport_Control As Panel)
            Viewport_Ctl = Viewport_Control
            Width = Viewport_Ctl.Width
            Height = Viewport_Ctl.Height
            Center.X = Viewport_Ctl.Width / 2
            Center.Y = Viewport_Ctl.Height / 2
        End Sub

        Private Sub Resize(sender As Object, e As System.EventArgs) Handles Viewport_Ctl.Resize
            Width = Viewport_Ctl.Width
            Height = Viewport_Ctl.Height
            Center.X = Viewport_Ctl.Width / 2
            Center.Y = Viewport_Ctl.Height / 2
        End Sub


    End Class


    Public Class Class_Canvas

#Region "Structures"

        Public Structure struct_Inch_Point
            Public X As Single
            Public Y As Single
        End Structure

#End Region

#Region "Declarations"
        Public Top As Integer
        Public Left As Integer
        Public Height As Integer
        Public Width As Integer

        Public Height_In As Single
        Public Width_In As Single

        Private Drawing_Scale As Single
        Public X_Scale As Single = 1 * X_Dpi
        Public Y_Scale As Single = 1 * Y_Dpi
        Public X_Dpi As Single
        Public Y_Dpi As Single

        Public Bit_Map_Scale As Single = 2

        Private Pen_Scale As Single

        Public X_Angle As Single = 0
        Public Y_Angle As Single = 0
        Public Z_Angle As Single = 0
        Public Z_Scale As Single = 0

        Private Max_X As Integer
        Private Max_Y As Integer

        Private X_Pen As Pen
        Private Y_Pen As Pen

        Public Viewport As Class_Viewport

        Public WithEvents Canvas_Ctl As PictureBox
        Private Viewport_Ctl As Panel

        Private Parent As Form
        Public Bit_Map As Bitmap
        Private g As Graphics

#End Region

#Region "Properties"

        Public Property Scale As Single

            Get
                Return Drawing_Scale
            End Get

            Set(ByVal value As Single)
                If value > 0.1 Then
                    Drawing_Scale = value
                    X_Scale = value * X_Dpi
                    Y_Scale = value * Y_Dpi
                End If

            End Set

        End Property

        Public Property Bottom_Edge As Integer
            Get
                Return Canvas_Ctl.Top + Canvas_Ctl.Height - Viewport.Height
            End Get

            Set(ByVal value As Integer)
                Canvas_Ctl.Top = Viewport.Height - Canvas_Ctl.Height - value
            End Set

        End Property

#End Region

#Region "Events"

        Public Event Redraw()
        Public Event Status_Change()
        Public Event Reset_Rotation()

        Public Event Rescale(Delta As Integer)
        Public Event Position_Canvas(ByRef Pt As struct_Draw_Point)

#End Region

#Region "New"

        Public Sub New(Parent_Form As Form, Canvas_Control As PictureBox, View_Port_Control As Panel, _
                       Width_Inches As Single, Height_Inches As Single)

            Canvas_Ctl = Canvas_Control
            Parent = Parent_Form
            Viewport = New Class_Viewport(View_Port_Control)

            Scale = 1
            Width_In = Width_Inches
            Height_In = Height_Inches

            g = Canvas_Ctl.CreateGraphics()
            X_Dpi = g.DpiX
            Y_Dpi = g.DpiY

            Width = Width_In * X_Dpi * Scale
            Height = Height_In * Y_Dpi * Scale

            Width = Width * Bit_Map_Scale
            Height = Height * Bit_Map_Scale

            Canvas_Ctl.Width = Width
            Canvas_Ctl.Height = Height

            Bit_Map = New Bitmap(Width, Height, g)

            g.Dispose()

            Scale = 1
            Pen_Scale = (1 / X_Dpi) / Scale

            RemoveHandler Canvas_Ctl.MouseWheel, AddressOf Mouse_Wheel_Handler
            AddHandler Canvas_Ctl.MouseWheel, AddressOf Mouse_Wheel_Handler

            RemoveHandler Canvas_Ctl.MouseDown, AddressOf Mouse_Down_Handler
            AddHandler Canvas_Ctl.MouseDown, AddressOf Mouse_Down_Handler

            RemoveHandler Canvas_Ctl.MouseMove, AddressOf Mouse_Move_Handler
            AddHandler Canvas_Ctl.MouseMove, AddressOf Mouse_Move_Handler

            RemoveHandler Canvas_Ctl.MouseUp, AddressOf Mouse_Up_Handler
            AddHandler Canvas_Ctl.MouseUp, AddressOf Mouse_Up_Handler

        End Sub

#End Region

        Public Function Convert_Y(Y) As Integer
            Return Canvas_Ctl.Height - Y
        End Function

        Public Sub Set_Parameters(Scale As Integer, X As Single, Y As Single, Z As Single)
            Scale = Scale
            X_Angle = 0
            Y_Angle = 0
            Z_Angle = 0
            Z_Scale = 1
        End Sub

        Public Sub Reset_Drawing()
            Scale = 1
            X_Angle = 0
            Y_Angle = 0
            Z_Angle = 0
            Z_Scale = 25
            Move_Canvas_Origin_To(0, 0)
            RaiseEvent Redraw()
        End Sub

        Public Sub Reset_View_Controls(Draw As Boolean)
            Scale = 1

            X_Angle = 0
            Y_Angle = 0
            Z_Angle = 0
            Z_Scale = 25

            Move_Canvas_Origin_To(0, 0)
            RaiseEvent Reset_Rotation()
            If Draw Then RaiseEvent Redraw()
        End Sub

#Region "Location Routines"

        Private Sub Location_Changed(sender As Object, e As System.EventArgs) Handles Canvas_Ctl.LocationChanged
            Top = Canvas_Ctl.Top
            Left = Canvas_Ctl.Left
        End Sub

        Public Sub Move_Canvas(X_Increment As Integer, Y_Increment As Integer)
            Canvas_Ctl.Left += X_Increment
            Canvas_Ctl.Top += Y_Increment
        End Sub

        Public Sub Move_Canvas_Origin_To(X As Integer, Y As Integer)
            Canvas_Ctl.Top = Viewport.Height - Canvas_Ctl.Height - Y
            Canvas_Ctl.Left = X
        End Sub

        Public Sub Move_Canvas_Center_To(X As Integer, Y As Integer)
            Canvas_Ctl.Top = Y - Canvas_Ctl.Height + Viewport.Height
            Canvas_Ctl.Left = X
        End Sub


        Public Function Location_Inches(Pt As Point) As struct_Inch_Point
            Dim P As struct_Inch_Point
            P.X = Pt.X / Scale / X_Dpi
            P.Y = Pt.Y / Scale / Y_Dpi
            Return P
        End Function

#End Region

#Region "Drawing Routines"


        Public Sub Start_Drawing()
            g = Graphics.FromImage(Bit_Map)
        End Sub

        Public Sub Finish_Drawing()
            Canvas_Ctl.Image = Bit_Map
            Canvas_Ctl.Refresh()
        End Sub

        Public Sub Clear_Drawing()
            g.Clear(Canvas_Ctl.BackColor)
        End Sub

        Public Sub Test_Clear_Drawing()

            g.Clear(Canvas_Ctl.BackColor)
            Canvas_Ctl.Image = Bit_Map
            Canvas_Ctl.Refresh()
        End Sub

        Public Sub Test_Refresh_Drawing()
            Canvas_Ctl.Image = Bit_Map
            Canvas_Ctl.Refresh()
        End Sub

        Public Sub Draw_Line(Pen_Color As Pen, X1 As Single, Y1 As Single, X2 As Single, Y2 As Single, Optional Refresh As Boolean = False)
            'One has to be added to X and subtracted from Y so lines show up at Zero
            g.DrawLine(Pen_Color, X1 + 1, Y1 - 1, X2 + 1, Y2 - 1)
            If Refresh Then Canvas_Ctl.Image = Bit_Map
        End Sub

        Public Sub Draw_Cut_Line(Pen_Color As Pen, X1 As Single, Y1 As Single, X2 As Single, Y2 As Single)
            'One has to be added to X and subtracted from Y so lines show up at Zero
            g.DrawLine(Pen_Color, X1 + 1, Y1 - 1, X2 + 1, Y2 - 1)
            Canvas_Ctl.Image = Bit_Map
        End Sub

        Public Sub Draw_Dashed_Line(Pen_Color As Pen, X1 As Single, Y1 As Single, X2 As Single, Y2 As Single)
            Dim dashValues As Single() = {5, 10} ', 5, 10}
            Dim blackPen As New Pen(Color.Black, 2)
            blackPen.DashPattern = dashValues
            g.DrawLine(blackPen, CInt(X1 * X_Scale), CInt(Y1 * Y_Scale), CInt(X2 * X_Scale), CInt(Y2 * X_Scale))
        End Sub

        Public Sub Draw_Arc(Pen_Color As Pen, X_Start As Single, Y_Start As Single, Width As Single, Height As Single, Deg_Start As Single, Deg_End As Single)
            Dim Deg_Sweep As Single = Deg_End - Deg_Start
            'g.DrawArc(Pen_Color, -X_Start, Y_Start, Width, Height, Deg_Start, Deg_End)

            'g.DrawCurve(Pen_Color, pts)

        End Sub

        Public Sub Draw_String(Text As String, X As Single, Y As Single)
            g.DrawString(Text, New Font("Arial", 10), Brushes.Red, New PointF(X, Y))
        End Sub

#End Region

#Region "Mouse Handlers"

        Private Canvas_Rectangle As New Rectangle
        Private Start_Point As Point
        Private Last_Delta As Point
        Private Last_Move_Pt As Point
        Private Dragging As Boolean


        Private Sub Mouse_Wheel_Handler(sender As Object, e As MouseEventArgs)
            RaiseEvent Rescale(e.Delta)
        End Sub

        Private Sub Mouse_Down_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    Dim control As Control = CType(sender, Control)
                    Start_Point = control.PointToScreen(New Point(e.X, e.Y))
                    Last_Move_Pt.X = e.X
                    Last_Move_Pt.Y = e.Y
                    Last_Delta.X = 0
                    Last_Delta.Y = 0
                    Dragging = True
                Case Windows.Forms.MouseButtons.Right
                    RaiseEvent Redraw()
                    Dragging = False
            End Select

        End Sub

        Private Sub Mouse_Move_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Static Dim cnt As Integer = 0

            Select Case e.Button

                Case Windows.Forms.MouseButtons.Middle
                    cnt += 1
                    Last_Delta.X = e.X - Last_Move_Pt.X
                    Last_Delta.Y = e.Y - Last_Move_Pt.Y

                    Last_Move_Pt.X = e.X - Last_Delta.X
                    Last_Move_Pt.Y = e.Y - Last_Delta.Y

                    If Last_Delta.X > 0 Then
                        X_Angle -= 1
                    ElseIf Last_Delta.X < 0 Then
                        X_Angle += 1
                    End If

                    If Last_Delta.Y > 0 Then
                        Y_Angle -= 1
                    ElseIf Last_Delta.Y < 0 Then
                        Y_Angle += 1
                    End If

                    RaiseEvent Status_Change()

                    RaiseEvent Redraw()

                    Exit Sub
            End Select

            If Dragging Then
                Last_Delta.X = e.X - Last_Move_Pt.X
                Last_Delta.Y = e.Y - Last_Move_Pt.Y

                Last_Move_Pt.X = e.X - Last_Delta.X
                Last_Move_Pt.Y = e.Y - Last_Delta.Y

                Canvas_Ctl.Left += Last_Delta.X
                Canvas_Ctl.Top += Last_Delta.Y
            End If

        End Sub

        Private Sub Mouse_Up_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

            If (e.Button = MouseButtons.Right) Then
                ControlPaint.DrawReversibleFrame(Canvas_Rectangle, Canvas_Ctl.BackColor, FrameStyle.Dashed)
            End If

            Dragging = False

        End Sub

#End Region

    End Class

#End Region

End Class
