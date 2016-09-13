Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ctrl_Drawing_OLD

#Region "Declarations"

    Public Grid_Color As New Pen(Color.Gray, 1)

    Public Next_Move_Color As New Pen(Color.Orange, 2)

    Public Rapid_Path_Color As New Pen(Color.Red, 1)
    Public Rapid_Cutting_Color As New Pen(Color.Yellow, 2)
    Public Rapid_Cut_Color As New Pen(Color.Firebrick, 2)

    Public Path_Color As New Pen(Color.DarkTurquoise, 1)
    Public Path_Cutting_Color As New Pen(Color.Yellow, 2)
    Public Path_Cut_Color As New Pen(Color.GreenYellow, 2)

    Public Z_Path_Color As New Pen(Color.Fuchsia, 1)
    Public Z_Cutting_Color As New Pen(Color.Yellow, 2)
    Public Z_Cut_Color As New Pen(Color.Orchid, 2)

    Public Enum enum_Block_Type
        Grid
        Non_Move
        Line
        Arc_CW
        Arc_CCW
        Rapid
        Z_Move
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
        Public Radius As Single
        Public Start_Angle As Single
        Public End_Angle As Single
    End Structure

    Public Blocks As New List(Of struct_Block)

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


    Private X_Max As Single = 24
    Private Y_Max As Single = 24
    Private Z_Max As Single = 5
    Private X_Offset As Single = 1
    Private Y_Offset As Single = 1

    Private Rad_X As Single
    Private Rad_Y As Single
    Private Rad_Z As Single

    Private C_X As Single
    Private S_X As Single
    Private C_Y As Single
    Private S_Y As Single
    Private C_Z As Single
    Private S_Z As Single

    Private Lens As Single = 300
    Private Drawing_Granularity As Single = 0.1

    Public WithEvents Part_Drawing As Class_Canvas

    Public Test_Mode As Boolean = False

    Private Cut_Log As New List(Of Integer)

    Private Shared txt_Scale As New TextBox

    Private Last_Point_Drawn As Integer


#End Region

#Region "Initialize, Closing, Settings"


    Public Sub Initialze()

        pnl_Top.Controls.Add(txt_Scale)

        ud_X_Angle.Left = btn_Reset.Left + btn_Reset.Width + 25
        ud_Y_Angle.Left = ud_X_Angle.Left + ud_X_Angle.Width
        ud_Z_Angle.Left = ud_Y_Angle.Left + ud_Y_Angle.Width
        txt_Scale.Left = ud_Z_Angle.Left + ud_Z_Angle.Width

        lab_X.Left = ud_X_Angle.Left + (ud_X_Angle.Width / 2) - (lab_X.Width / 2)
        lab_Y.Left = ud_Y_Angle.Left + (ud_Y_Angle.Width / 2) - (lab_Y.Width / 2)
        lab_Z.Left = ud_Z_Angle.Left + (ud_Z_Angle.Width / 2) - (lab_Z.Width / 2)

        txt_Scale.Width = 50
        txt_Scale.TextAlign = HorizontalAlignment.Right
        lab_Scale.Left = txt_Scale.Left + (txt_Scale.Width / 2) - (lab_Scale.Width / 2)
        txt_Scale.Top = ud_X_Angle.Top
        txt_Scale.Text = 1

        Part_Drawing = New Class_Canvas(Main_Form, temp_Dwg_pnl_Canvas, temp_Dwg_pnl_Viewport, X_Max, Y_Max)
        Part_Drawing.Reset(False)
        Load_Settings()

        Draw_Cutter_Path()

    End Sub

    Public Sub Closing()
        Save_Settings()
    End Sub

    Public Sub Load_Settings()
        Dim T As String = My.Settings("Canvas_View")
        Dim S() As String = Nothing

        If T = "" Then Exit Sub
        S = T.Split("~")

        If S.Count > 0 Then
            Part_Drawing.X_Angle = CSng(S(0))
            ud_X_Angle.Value = Part_Drawing.X_Angle
        End If

        Part_Drawing.Y_Angle = CSng(S(1))
        ud_Y_Angle.Value = Part_Drawing.Y_Angle

        Part_Drawing.Z_Angle = CSng(S(2))
        ud_Z_Angle.Value = Part_Drawing.Z_Angle

        Part_Drawing.Set_Scale(CSng(S(3)))
        txt_Scale.Text = Part_Drawing.Scale

        Part_Drawing.ctl.Top = CInt(S(4))
        Part_Drawing.ctl.Left = CInt(S(5))

    End Sub

    Public Sub Save_Settings()
        If IsNothing(Part_Drawing) Then Exit Sub

        Dim S As String

        S = Part_Drawing.X_Angle & "~" & Part_Drawing.Y_Angle & "~" & Part_Drawing.Z_Angle & "~" & _
            Part_Drawing.Scale & "~" & Part_Drawing.ctl.Top & "~" & Part_Drawing.ctl.Left

        My.Settings("Canvas_View") = S
        My.Settings.Save()
    End Sub

#End Region

#Region "Drawing Routines"

    Public Sub Draw_Cutter_Path()
        Dim G_Mode As String = ""
        Dim Draw_Pen As Pen = Pens.Black

        Translate_Points()

        Part_Drawing.Start_Drawing()
        Part_Drawing.Clear_Drawing()

        For I = 1 To Grid_Points.Count - 1
            Part_Drawing.Draw_Line(Grid_Color, Grid_Points(I - 1).Xt, Grid_Points(I - 1).Yt, Grid_Points(I).Xt, Grid_Points(I).Yt)
        Next

        For I = 2 To Draw_Points.Count - 1
            Draw_Pen = Path_Color

            Select Case Blocks(Draw_Points(I).Block_Number).Status

                Case enum_Block_Status.Not_Cut
                    Select Case Blocks(Draw_Points(I).Block_Number).Type

                        Case enum_Block_Type.Grid
                            Draw_Pen = Grid_Color

                        Case enum_Block_Type.Line, enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                            Draw_Pen = Path_Color

                        Case enum_Block_Type.Rapid
                            Draw_Pen = Rapid_Path_Color

                        Case enum_Block_Type.Z_Move
                            Draw_Pen = Z_Path_Color
                    End Select

                Case enum_Block_Status.Next_Cut
                    Draw_Pen = Next_Move_Color

                Case enum_Block_Status.Cut
                    Select Case Blocks(Draw_Points(I).Block_Number).Type

                        Case enum_Block_Type.Grid
                            Draw_Pen = Grid_Color

                        Case enum_Block_Type.Line, enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                            Draw_Pen = Path_Cut_Color

                        Case enum_Block_Type.Rapid
                            Draw_Pen = Rapid_Cut_Color

                        Case enum_Block_Type.Z_Move
                            Draw_Pen = Z_Cut_Color

                    End Select
            End Select

            If Test_Mode Then
                Part_Drawing.Test_Draw()
                Message_Box.ShowDialog("Point Index:" & I & vbCrLf & _
                                       "Block : " & Draw_Points(I - 1).Block_Number & " ~ " & Draw_Points(I).Block_Number & vbCrLf & _
                                       "Xo " & Draw_Points(I - 1).Xo & " ~ " & "Xo " & Draw_Points(I).Xo & vbCrLf & _
                                       "Yo " & Draw_Points(I - 1).Yo & " ~ " & "Yo " & Draw_Points(I).Yo & vbCrLf & _
                                       "Zo " & Draw_Points(I - 1).Zo & " ~ " & "Zo " & Draw_Points(I).Zo & vbCrLf & _
                                       "X " & Draw_Points(I - 1).Xt & " ~ " & "X " & Draw_Points(I).Xt & vbCrLf & _
                                       "Y " & Draw_Points(I - 1).Yt & " ~ " & "Y " & Draw_Points(I).Yt & vbCrLf & _
                                       "Z " & Draw_Points(I - 1).Zt & " ~ " & "Z " & Draw_Points(I).Zt)
            End If


            Select Case Draw_Points(I).Type
                Case enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                    'Part_Drawing.Draw_Arc(Draw_Pen, Draw_Points(I - 1).Xt, Draw_Points(I - 1).Yt, Draw_Points(I).Xt, Draw_Points(I).Yt)
                Case Else
                    Part_Drawing.Draw_Line(Draw_Pen, Draw_Points(I - 1).Xt, Draw_Points(I - 1).Yt, Draw_Points(I).Xt, Draw_Points(I).Yt)
            End Select

        Next

        Part_Drawing.Finish_Drawing()

        'Dim C(11) As String
        'Main_Form.grid_Points.Rows.Clear()
        'For I = 1 To Draw_Points.Count - 1
        '    If Draw_Points(I).Block_Number > 0 Then
        '        C(0) = Draw_Points(I).Block_Number
        '        C(1) = G_Code_Control.Get_Block(Draw_Points(I).Block_Number)
        '        C(2) = FormatNumber(Draw_Points(I - 1).Xo, 3)
        '        C(3) = FormatNumber(Draw_Points(I - 1).Yo, 3)
        '        C(4) = FormatNumber(Draw_Points(I).Zo, 3)
        '        C(5) = FormatNumber(Draw_Points(I).X, 3)
        '        C(6) = FormatNumber(Draw_Points(I).Y, 3)
        '        C(7) = FormatNumber(Draw_Points(I).Z, 3)
        '        C(8) = FormatNumber(Draw_Points(I - 1).X, 3)
        '        C(9) = FormatNumber(Draw_Points(I - 1).Y, 3)
        '        C(10) = FormatNumber(Draw_Points(I).X, 3)
        '        C(11) = FormatNumber(Draw_Points(I).Y, 3)
        '        Main_Form.grid_Points.Rows.Add(C)
        '    End If
        'Next

    End Sub

    Public Sub Draw_Cutting(Block_No As Integer, Start_Point As ctrl_Drawing.struct_Draw_Point, End_Point As ctrl_Drawing.struct_Draw_Point)
        'Exit Sub

        If Block_No > Draw_Points.Count - 1 Then Exit Sub

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

        Start_Point.Xt = Start_Point.Xo
        Start_Point.Yt = Start_Point.Yo
        Start_Point.Zt = Start_Point.Zo

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

        Start_Point.Xt = (Start_Point.Xt * Part_Drawing.X_Scale) + X_Offset
        Start_Point.Yt = Part_Drawing.Height - (Start_Point.Yt * Part_Drawing.Y_Scale) + Y_Offset

        End_Point.Xt = End_Point.Xo
        End_Point.Yt = End_Point.Yo
        End_Point.Zt = End_Point.Zo

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

        End_Point.Xt = (End_Point.Xt * Part_Drawing.X_Scale) + X_Offset
        End_Point.Yt = Part_Drawing.Height - (End_Point.Yt * Part_Drawing.Y_Scale) + Y_Offset


        Select Case Blocks(Block_No).Type

            Case enum_Block_Type.Line
                Part_Drawing.Draw_Cut_Line(Path_Cutting_Color, Start_Point.Xt, Start_Point.Yt, End_Point.Xt, End_Point.Yt)

            Case enum_Block_Type.Rapid
                Part_Drawing.Draw_Cut_Line(Rapid_Cut_Color, Start_Point.Xt, Start_Point.Yt, End_Point.Xt, End_Point.Yt)

            Case enum_Block_Type.Z_Move
                Part_Drawing.Draw_Cut_Line(Z_Cutting_Color, Start_Point.Xt, Start_Point.Yt, End_Point.Xt, End_Point.Yt)

        End Select

    End Sub

    Public Sub Show_Next_Move(Block_Number As Integer)

        If (Block_Number > 1) And (Block_Number < Block_Points.Count - 2) Then

            Dim Pt As struct_Draw_Point
            Dim Next_Pt As struct_Draw_Point
            Pt = Block_Points(Block_Number - 1)
            Next_Pt = Block_Points(Block_Number)

            Part_Drawing.Draw_Cut_Line(Next_Move_Color, Pt.Xt, Pt.Yt, Next_Pt.Xt, Next_Pt.Yt)

        End If
    End Sub

    Public Sub Mark_As_Cut(Block_Number As Integer)

        Dim Blk As struct_Block = Blocks(Block_Number)
        Dim Pt As struct_Draw_Point = Block_Points(Block_Number)
        Dim Prev_Pt As struct_Draw_Point = Block_Points(Block_Number - 1)

        If Not Cut_Log.Contains(Block_Number) Then

            Select Case Blocks(Block_Number).Type
                Case enum_Block_Type.Rapid

                    Part_Drawing.Draw_Line(Rapid_Cut_Color, Prev_Pt.Xt, Prev_Pt.Yt, Pt.Xt, Pt.Yt, True)
                    Blk.Status = enum_Block_Status.Cut

                Case enum_Block_Type.Line
                    Part_Drawing.Draw_Line(Path_Cut_Color, Prev_Pt.Xt, Prev_Pt.Yt, Pt.Xt, Pt.Yt, True)
                    Blk.Status = enum_Block_Status.Cut

                Case enum_Block_Type.Arc_CW, enum_Block_Type.Arc_CCW
                    Blk.Status = enum_Block_Status.Cut

                Case enum_Block_Type.Z_Move
                    Part_Drawing.Draw_Line(Z_Cut_Color, Prev_Pt.Xt, Prev_Pt.Yt, Pt.Xt, Pt.Yt, True)
                    Blk.Status = enum_Block_Status.Cut
            End Select

            Blocks(Block_Number) = Blk
            Cut_Log.Add(Block_Number)
        End If

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

    Public Sub Translate_Point(ByRef Pt As struct_Draw_Point)
        Dim D As Single

        Pt.Xt = Pt.Xo
        Pt.Yt = Pt.Yo
        Pt.Zt = Pt.Zo

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

        Pt.Xt = (Pt.Xt * Part_Drawing.X_Scale) + X_Offset
        Pt.Yt = Part_Drawing.Height - (Pt.Yt * Part_Drawing.Y_Scale) + Y_Offset

    End Sub

    Public Sub Translate_Points()
        Translate_Angles()

        Dim Pt As struct_Draw_Point

        For I = 1 To Grid_Points.Count - 1
            Pt = Grid_Points(I)
            Translate_Point(Pt)
            Grid_Points(I) = Pt
        Next

        For I = 1 To Block_Points.Count - 1
            Pt = Block_Points(I)
            Translate_Point(Pt)
            Block_Points(I) = Pt
        Next

        For I = 1 To Draw_Points.Count - 1
            Pt = Draw_Points(I)
            Translate_Point(Pt)
            Draw_Points(I) = Pt
        Next

    End Sub

    Public Sub Load_Drawing_Points()
        Dim S() As String
        Dim G_Mode As String = ""
        Dim Pt As struct_Draw_Point = Nothing
        Dim Block As struct_Block
        Dim Last_X As Single = 0
        Dim Last_Y As Single = 0
        Dim Last_Z As Single = 0

        Me.Cursor = Cursors.Hand

        Grid_Points.Clear()
        Block_Points.Clear()
        Draw_Points.Clear()

        Pt.Xo = 0
        Pt.Yo = 0
        Pt.Zo = 0
        Grid_Points.Add(Pt)

        Pt.Block_Number = 0

        For X = 0 To X_Max
            Pt.Xo = X
            Pt.Yo = 0
            Grid_Points.Add(Pt)

            Pt.Xo = X
            Pt.Yo = Y_Max
            Grid_Points.Add(Pt)

            Pt.Xo = X
            Pt.Yo = 0
            Grid_Points.Add(Pt)
        Next

        For Y = 0 To Y_Max
            Pt.Xo = 0
            Pt.Yo = Y
            Grid_Points.Add(Pt)

            Pt.Xo = X_Max
            Pt.Yo = Y
            Grid_Points.Add(Pt)

            Pt.Xo = 0
            Pt.Yo = Y
            Grid_Points.Add(Pt)
        Next

        Pt.Xo = 0
        Pt.Yo = 0
        Pt.Zo = 0
        Grid_Points.Add(Pt)

        G_Mode = ""

        For I = 0 To Blocks.Count - 1
            Pt.Block_Number = I

            Block = Blocks(I)
            Block.Type = enum_Block_Type.Non_Move

            Block.Code = Block.Code.Replace("S", " S")

            S = Block.Code.Split(" ")

            For J = 0 To S.Count - 1
                Select Case Mid(S(J), 1, 1)
                    Case "X"
                        Block.X = Mid(S(J), 2)
                        Pt.Xo = Block.X
                    Case "Y"
                        Block.Y = Mid(S(J), 2)
                        Pt.Yo = Block.Y
                    Case "Z"
                        Block.Z = Mid(S(J), 2)
                        Pt.Zo = Block.Z
                End Select

                Select Case S(J)
                    Case "G0", "G1", "G2", "G3"
                        G_Mode = S(J)
                End Select
            Next

            Select Case G_Mode
                Case "G0"
                    Block.Type = enum_Block_Type.Rapid
                Case "G1"
                    Block.Type = enum_Block_Type.Line
                Case "G2"
                    Block.Type = enum_Block_Type.Arc_CW
                Case "G3"
                    Block.Type = enum_Block_Type.Arc_CCW
            End Select

            If Pt.Zo <> Last_Z Then
                Block.Type = enum_Block_Type.Z_Move
            End If

            If (Math.Abs(Pt.Xo - Last_X) > Drawing_Granularity) Or (Math.Abs(Pt.Yo - Last_Y) > Drawing_Granularity) Or (Pt.Zo <> Last_Z) Then
                Main_Form.Grid_GCode_Program.Set_Block_Point_Index(I, Draw_Points.Count)
                Draw_Points.Add(Pt)
                Last_X = Pt.Xo
                Last_Y = Pt.Yo
                Last_Z = Pt.Zo
            End If

            Block_Points.Add(Pt)

            Blocks(I) = Block

        Next

        Me.Cursor = Cursors.Arrow

    End Sub

#End Region

#Region "Events"

    Private Sub Part_Drawing_Redraw() Handles Part_Drawing.Redraw
        Draw_Cutter_Path()
    End Sub

    Sub Part_Drawing_Reset_Rotation() Handles Part_Drawing.Reset_Rotation
        ud_X_Angle.Value = 0
        ud_Y_Angle.Value = 0
        ud_Z_Angle.Value = 0
    End Sub

    Private Sub btn_Reset_Click() Handles btn_Reset.Click
        Part_Drawing.Reset(True)
    End Sub

    Private Sub ud_X_Angle_ValueChanged() Handles ud_X_Angle.ValueChanged
        Part_Drawing.X_Angle = ud_X_Angle.Value
        Draw_Cutter_Path()
    End Sub

    Private Sub ud_Y_Angle_ValueChanged() Handles ud_Y_Angle.ValueChanged
        Part_Drawing.Y_Angle = ud_Y_Angle.Value
        Draw_Cutter_Path()
    End Sub

    Private Sub ud_Z_Angle_ValueChanged() Handles ud_Z_Angle.ValueChanged
        Part_Drawing.Z_Angle = ud_Z_Angle.Value
        Draw_Cutter_Path()
    End Sub

    Private Sub lab_X_Click(sender As Object, e As EventArgs) Handles lab_X.Click
        ud_X_Angle.Value = 0
        Part_Drawing.X_Angle = 0
        Draw_Cutter_Path()
    End Sub

    Private Sub lab_Y_Click(sender As Object, e As EventArgs) Handles lab_Y.Click
        ud_Y_Angle.Value = 0
        Part_Drawing.Y_Angle = 0
        Draw_Cutter_Path()
    End Sub

    Private Sub lab_Z_Click(sender As Object, e As EventArgs) Handles lab_Z.Click
        ud_Z_Angle.Value = 0
        Part_Drawing.Z_Angle = 0
        Draw_Cutter_Path()
    End Sub

    Private Sub lab_Scale_Click(sender As Object, e As EventArgs) Handles lab_Scale.Click
        Part_Drawing.Set_Scale(1)
    End Sub

#End Region

#Region "Classes Viewport, Canvas"

    Public Class Class_Viewport
        Public Center As Point
        Public Height As Integer
        Public Width As Integer

        Public WithEvents ctl As Panel

        Public Sub New(Viewport_Control As Panel)
            ctl = Viewport_Control
            Width = ctl.Width
            Height = ctl.Height
            Center.X = ctl.Width / 2
            Center.Y = ctl.Height / 2
        End Sub

        Public Function Canvas_Location_At_Viewpoint_Center(Canvas As Class_Canvas, X As Integer, Y As Integer) As Point
            Dim Pt As Point
            Pt.X = Canvas.Left + ctl.Width / 2
            Pt.Y = Canvas.Bottom + ctl.Height / 2
            Return Pt
        End Function

        Private Sub Resize(sender As Object, e As System.EventArgs) Handles ctl.Resize
            Width = ctl.Width
            Height = ctl.Height
            Center.X = ctl.Width / 2
            Center.Y = ctl.Height / 2
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

        Public X_Offset As Integer
        Public Y_Offset As Integer

        Public Height_In As Single
        Public Width_In As Single
        Public X_Offset_In As Integer
        Public Y_Offset_In As Integer

        Public Scale As Single
        Public X_Scale As Single = 1 * X_Dpi
        Public Y_Scale As Single = 1 * Y_Dpi
        Private X_Dpi As Single
        Private Y_Dpi As Single

        Private Pen_Scale As Single

        Public X_Angle As Single = 0
        Public Y_Angle As Single = 0
        Public Z_Angle As Single = 0

        Private Max_X As Integer
        Private Max_Y As Integer

        Private X_Pen As Pen
        Private Y_Pen As Pen

        Public Viewport As Class_Viewport

        Public WithEvents ctl As PictureBox
        Private Viewport_Ctl As Panel

        Private Parent As Form
        Public Bit_Map As Bitmap
        Private g As Graphics

#End Region

#Region "Properties"

        Public Property Drawing_Scale As Single

            Get
                Return Scale
            End Get

            Set(ByVal value As Single)
                If value > 0.1 Then
                    Scale = value
                    X_Scale = value * X_Dpi
                    Y_Scale = value * Y_Dpi
                End If

            End Set

        End Property

        Public Property Bottom As Integer
            Get
                Return ctl.Top + ctl.Height - Viewport.Height
            End Get

            Set(ByVal value As Integer)
                ctl.Top = Viewport.Height - ctl.Height - value
            End Set

        End Property

#End Region

#Region "Events"

        Public Event Redraw()
        Public Event Status_Change()
        Public Event Reset_Rotation()

#End Region

#Region "New"

        Public Sub New(Parent_Form As Form, Canvas_Control As PictureBox, View_Port_Control As Panel, _
                       Width_Inches As Single, Height_Inches As Single)

            ctl = Canvas_Control
            Parent = Parent_Form
            Viewport = New Class_Viewport(View_Port_Control)

            Scale = 1
            Width_In = Width_Inches
            Height_In = Height_Inches

            g = ctl.CreateGraphics()
            X_Dpi = g.DpiX
            Y_Dpi = g.DpiY

            Width = Width_In * X_Dpi * Scale
            Height = Height_In * Y_Dpi * Scale
            ctl.Width = Width
            ctl.Height = Height


            Bit_Map = New Bitmap(Width, Height, g)

            g.Dispose()

            Drawing_Scale = 1
            Pen_Scale = (1 / X_Dpi) / Scale

            RemoveHandler Parent.MouseWheel, AddressOf Parent_Mouse_Wheel_Handler
            AddHandler Parent.MouseWheel, AddressOf Parent_Mouse_Wheel_Handler

            RemoveHandler ctl.MouseDown, AddressOf Mouse_Down_Handler
            AddHandler ctl.MouseDown, AddressOf Mouse_Down_Handler

            RemoveHandler ctl.MouseMove, AddressOf Mouse_Move_Handler
            AddHandler ctl.MouseMove, AddressOf Mouse_Move_Handler

            RemoveHandler ctl.MouseUp, AddressOf Mouse_Up_Handler
            AddHandler ctl.MouseUp, AddressOf Mouse_Up_Handler
        End Sub

#End Region

        Public Function Convert_Y(Y) As Integer
            Return ctl.Height - Y
        End Function

        Public Sub Reset_Drawing()
            Drawing_Scale = 1
            X_Angle = 0
            Y_Angle = 0
            Z_Angle = 0
            Move_Canvas_Origin_To(0, 0)
            RaiseEvent Redraw()
        End Sub

        Public Overloads Sub Reset(Draw As Boolean)
            Drawing_Scale = 1
            txt_Scale.Text = 1
            X_Angle = 0
            Y_Angle = 0
            Z_Angle = 0
            Move_Canvas_Origin_To(0, 0)
            RaiseEvent Reset_Rotation()
            If Draw Then RaiseEvent Redraw()
        End Sub

        Public Sub Change_Scale(Increment As Single)
            Scale += Increment
            If Scale <= 0 Then Scale = 0.1
            txt_Scale.Text = Scale
            X_Scale = Scale * X_Dpi
            Y_Scale = Scale * Y_Dpi
            RaiseEvent Redraw()
        End Sub

        Public Sub Set_Scale(Value As Single)
            Scale = Value
            If Scale <= 0 Then Scale = 0.1
            txt_Scale.Text = Scale
            X_Scale = Scale * X_Dpi
            Y_Scale = Scale * Y_Dpi
            RaiseEvent Redraw()
        End Sub

#Region "Location Routines"

        Public Function Canvas_Location_At_Viewpoint_Center() As Point
            Dim Pt As Point
            Pt.X = Left + Viewport.Center.X
            Pt.Y = Bottom + Viewport.Center.Y
            Return Pt
        End Function

        Private Sub Location_Changed(sender As Object, e As System.EventArgs) Handles ctl.LocationChanged
            Left = ctl.Left
        End Sub

        Public Sub Move_Canvas(X_Increment As Integer, Y_Increment As Integer)
            ctl.Left += X_Increment
            ctl.Top += Y_Increment
        End Sub

        Public Sub Move_Canvas_Origin_To(X As Integer, Y As Integer)
            Bottom = Y
            ctl.Left = X
        End Sub

        Public Sub Move_Canvas_Center_To(X As Integer, Y As Integer)
            ctl.Top = Y - ctl.Height + Viewport.Height
            ctl.Left = X
        End Sub

        Public Sub Move_Canvas_Pt_To_Viewport_Center(X As Integer, Y As Integer)
            Left = X - Viewport.Center.X
            Bottom = Y - Viewport.Center.Y
            Move_Canvas_Origin_To(Left, Bottom)
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

            'g = ctl.CreateGraphics
            'Dim blackpen As New Drawing.Pen(Color.Black)
            'g.DrawLine(blackpen, 0, 0, 100, 2000)

        End Sub

        Public Sub Test_Draw()
            ctl.Image = Bit_Map
        End Sub

        Public Sub Finish_Drawing()
            'Bit_Map.RotateFlip(RotateFlipType.RotateNoneFlipY)
            ctl.Image = Bit_Map
            'g.Dispose()
        End Sub

        Public Sub Clear_Drawing()
            g.Clear(ctl.BackColor)
        End Sub

        Public Sub Draw_Line(Pen_Color As Pen, X1 As Single, Y1 As Single, X2 As Single, Y2 As Single, Optional Refresh As Boolean = False)
            g.DrawLine(Pen_Color, X1, Y1, X2, Y2)
            If Refresh Then ctl.Image = Bit_Map
        End Sub

        Public Sub Draw_Arc(Pen_Color As Pen, Pt As struct_Draw_Point)
            Dim X_Start As Single
            Dim Y_Start As Single
            Dim Width As Single
            Dim Height As Single
            Dim Deg_Start As Single
            Dim Deg_End As Single

            g.DrawArc(Pen_Color, -X_Start, Y_Start, Width, Height, Deg_Start, Deg_End)
        End Sub

        Public Sub Draw_Cut_Line(Pen_Color As Pen, X1 As Single, Y1 As Single, X2 As Single, Y2 As Single)
            g.DrawLine(Pen_Color, X1, Y1, X2, Y2)
            ctl.Image = Bit_Map
        End Sub

        Public Sub Draw_Dashed_Line(Pen_Color As Pen, X1 As Double, Y1 As Double, X2 As Double, Y2 As Double)
            Dim dashValues As Single() = {5, 10} ', 5, 10}
            Dim blackPen As New Pen(Color.Black, 2)
            blackPen.DashPattern = dashValues
            g.DrawLine(blackPen, CInt(X1 * X_Scale), CInt(Y1 * Y_Scale), CInt(X2 * X_Scale), CInt(Y2 * X_Scale))
        End Sub

        Public Sub Draw_Arc(Pen_Color As Pen, X_Start As Single, Y_Start As Single, Width As Single, Height As Single, Deg_Start As Single, Deg_End As Single)
            Dim Deg_Sweep As Single = Deg_End - Deg_Start
            g.DrawArc(Pen_Color, -X_Start, Y_Start, Width, Height, Deg_Start, Deg_End)
        End Sub

        Public Sub Draw_String(Text As String, X As Single, Y As Single)
            g.DrawString(Text, New Font("Arial", 10), Brushes.Red, New PointF(X, Y))
        End Sub

#End Region

#Region "Mouse Handlers"

        Private Enum enum_Mouse_Mode
            Idle
            Dragging
            Windowing
            Rotating
        End Enum

        Private Canvas_Rectangle As New Rectangle
        Private Start_Point As Point
        Private Last_Delta As Point
        Private Last_Move_Pt As Point
        Private Mouse_Mode As enum_Mouse_Mode


        Private Sub Parent_Mouse_Wheel_Handler(sender As Object, e As MouseEventArgs)

            If e.Delta > 0 Then
                Scale += 0.1
            Else
                Scale -= 0.1
            End If
            If Scale <= 0 Then Scale = 0.1

            X_Scale = Scale * X_Dpi
            Y_Scale = Scale * Y_Dpi

            txt_Scale.Text = Scale

            RaiseEvent Redraw()
        End Sub

        Private Sub Mouse_Down_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If (e.Button = MouseButtons.Left) Then Mouse_Mode = enum_Mouse_Mode.Dragging
            If (e.Button = MouseButtons.Right) Then Mouse_Mode = enum_Mouse_Mode.Windowing

            Dim control As Control = CType(sender, Control)
            Start_Point = control.PointToScreen(New Point(e.X, e.Y))

            Select Case Mouse_Mode
                Case enum_Mouse_Mode.Dragging
                    Last_Move_Pt.X = e.X
                    Last_Move_Pt.Y = e.Y
                    Last_Delta.X = 0
                    Last_Delta.Y = 0
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

            Select Case Mouse_Mode
                Case enum_Mouse_Mode.Dragging
                    Last_Delta.X = e.X - Last_Move_Pt.X
                    Last_Delta.Y = e.Y - Last_Move_Pt.Y

                    ctl.Left += Last_Delta.X
                    ctl.Top += Last_Delta.Y

                    Last_Move_Pt.X = e.X - Last_Delta.X
                    Last_Move_Pt.Y = e.Y - Last_Delta.Y

                Case enum_Mouse_Mode.Windowing

            End Select

        End Sub

        Private Sub Mouse_Up_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

            If (e.Button = MouseButtons.Right) Then
                ControlPaint.DrawReversibleFrame(Canvas_Rectangle, ctl.BackColor, FrameStyle.Dashed)
            End If

            Mouse_Mode = enum_Mouse_Mode.Idle

            ' Draw the rectangle to be evaluated. Set a dashed frame style  
            ' using the FrameStyle enumeration.

            ' Find out which controls intersect the rectangle and change their color. 
            ' The method uses the RectangleToScreen method to convert the  
            ' Control's client coordinates to screen coordinates. 
            'Dim i As Integer
            'Dim controlRectangle As Rectangle
            'For i = 0 To Controls.Count - 1
            '    controlRectangle = Controls(i).RectangleToScreen(Controls(i).ClientRectangle)
            '    If controlRectangle.IntersectsWith(theRectangle) Then
            '        Controls(i).BackColor = Color.BurlyWood
            '    End If
            'Next

            ' Reset the rectangle.
            Canvas_Rectangle = New Rectangle(0, 0, 0, 0)

        End Sub

#End Region

    End Class

#End Region

End Class
