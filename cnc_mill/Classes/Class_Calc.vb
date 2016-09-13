Public Class Class_Calc

    Public Structure struct_Coordinate
        Dim X As Single
        Dim Y As Single
        Dim Z As Single
    End Structure

    Public Enum enum_Direction
        CW
        CCW
    End Enum

    Public Function Format_Number(Number As Single)
        Dim Num As Single = Round(Number)
        Return FormatNumber(Number, 3)
    End Function

    Public Function Round(Number As Single, Optional Digits As Integer = 3) As Single
        Return Math.Round(Number, Digits, MidpointRounding.AwayFromZero)
    End Function

    Public Function Hypotenuse(X As Single, Y As Single) As Single
        Return Math.Sqrt((X ^ 2) + (Y ^ 2))
    End Function

    Public Sub Polar_To_Cartesian(Radius As Single, Angle_Degree As Single, ByRef X As Single, ByRef Y As Single)
        Dim AngleRadian As Single = Angle_Degree * 2 * Math.PI / 360
        X = Radius * Math.Cos(AngleRadian)
        Y = Radius * Math.Sin(AngleRadian)
    End Sub

    Public Overloads Sub Cartesian_To_Polar(X_Center As Single, Y_Center As Single, _
                                            X As Single, Y As Single, _
                                            ByRef Distance As Single, ByRef Angle_Degree As Single)
        Dim Angle_Radian As Single
        Distance = Hypotenuse((X_Center - X), (Y_Center - Y))
        Angle_Radian = Math.Atan2((Y - Y_Center), (X - X_Center))
        Angle_Degree = (Angle_Radian * 360) / (2 * Math.PI)
        If Angle_Degree < 0 Then Angle_Degree += 360

    End Sub

    Public Function Create_Arc_Block(Center_X As Single, Center_Y As Single, Start_X As Single, Start_Y As Single, _
                                     End_X As Single, End_Y As Single, Direction As enum_Direction) As String
        Dim Block As String
        Dim I As Single
        Dim J As Single

        If Direction = enum_Direction.CW Then
            Block = "G02"
        Else
            Block = "G03"
        End If

        I = Center_X - Start_X
        J = Center_Y - Start_Y

        Block &= " X" & Start_X & " Y" & Start_X & " I" & I & " J" & J

        Return Block
    End Function

    Public Function Interpolate_Arc(Block As String, Start_X As Single, Start_Y As Single, Cord_Length As Single) As List(Of struct_Coordinate)
        Dim End_X As Single
        Dim End_Y As Single
        Dim Center_X As Single
        Dim Center_Y As Single
        Dim Start_Angle As Single
        Dim End_Angle As Single
        Dim Angle As Single
        Dim Angle_Step As Single
        Dim Chord_Angle As Single
        Dim Circumference As Single
        Dim Radius As Single
        Dim I As Single
        Dim J As Single
        Dim Pt As struct_Coordinate
        Dim Points As New List(Of struct_Coordinate)
        Dim Chords As Single
        Dim CW As Boolean = False
        Dim Done As Boolean = False
        Dim cnt As Integer = 0
        Dim GC As New Class_GCode

        Block = Block.Trim

        If Cord_Length = 0 Then Cord_Length = 0.05

        GC.Block = Block

        End_X = GC.X
        End_Y = GC.Y
        I = GC.I
        J = GC.J

        Center_X = Start_X + I
        Center_Y = Start_Y + J

        Cartesian_To_Polar(Center_X, Center_Y, Start_X, Start_Y, Radius, Start_Angle)
        Cartesian_To_Polar(Center_X, Center_Y, End_X, End_Y, Radius, End_Angle)

        'Adjust Angle_Step to size of circle, small circles will not have many chords
        Circumference = Math.PI * Radius * 2
        Chords = Circumference / Cord_Length

        If Mid(Block, 1, 3) = "G02" Then 'Clockwise, angle always counts down
            CW = True
            If End_Angle > Start_Angle Then 'Arc goes through zero
                Angle = 360 - End_Angle + Start_Angle
            Else
                Angle = Start_Angle - End_Angle
            End If
            If Start_Angle = 0 Then Start_Angle = 360

        ElseIf Mid(Block, 1, 3) = "G03" Then 'Counter Clockwise, angle always counts up
            CW = False
            If End_Angle < Start_Angle Then 'Arc goes through zero
                Angle = 360 - Start_Angle + End_Angle
            Else
                Angle = End_Angle - Start_Angle
            End If
            If End_Angle = 0 Then End_Angle = 360
        Else
            Show_Error("Interpolate block called with non arc GCoce block.")
        End If

        'Angle_Step = Angle / Chords
        'If 360 / Angle_Step < 36 Then Angle_Step = Angle / 10
        'If 360 / Angle_Step > 360 Then Angle_Step = Angle / 360

        Angle_Step = Angle / Chords
        If Angle / Angle_Step < 36 Then Angle_Step = Angle / 10
        If Angle / Angle_Step > 360 Then Angle_Step = Angle / 360

        Angle = Start_Angle

        While Not Done

            cnt += 1
            If cnt > 361 Then
                Show_Error("Long loop in Interpolate_Arc")
                Return Nothing
            End If

            If CW Then
                Angle -= Angle_Step
                If Angle < End_Angle Then
                    Angle = End_Angle
                End If
                Chord_Angle = Angle
                If Angle < 0 Then Chord_Angle = -Angle

            Else 'CCW
                Angle += Angle_Step
                If Angle > End_Angle Then
                    Angle = End_Angle
                    Done = True
                End If
                Chord_Angle = Angle
                If Angle >= 360 Then Chord_Angle = Angle - 360

            End If

            Pt = New struct_Coordinate
            Calc.Polar_To_Cartesian(Radius, Chord_Angle, Pt.X, Pt.Y)
            Pt.X += Center_X
            Pt.Y += Center_Y
            Pt.X = Math.Round(Pt.X, 3)
            Pt.Y = Math.Round(Pt.Y, 3)
            Points.Add(Pt)

            If Angle = End_Angle Then Done = True

        End While

        Return Points

    End Function


    'Public Function Interpolate_Arc(Block As Class_GCode, Start_X As Single, Start_Y As Single) As List(Of struct_Coordinate)
    '    Dim End_X As Single
    '    Dim End_Y As Single
    '    Dim Center_X As Single
    '    Dim Center_Y As Single
    '    Dim Start_Angle As Single
    '    Dim End_Angle As Single
    '    Dim Angle As Single
    '    Dim Angle_Step As Single
    '    Dim Chord_Angle As Single
    '    Dim Circumference As Single
    '    Dim Radius As Single
    '    Dim I As Single
    '    Dim J As Single
    '    Dim Pt As struct_Coordinate
    '    Dim Points As New List(Of struct_Coordinate)
    '    Dim Chords As Single
    '    Dim CW As Boolean = False
    '    Dim Done As Boolean = False
    '    Dim cnt As Integer = 0

    '    If (IsNothing(Block.G)) Or (Block.G(0) <> "02" And Block.G(0) <> "03") Or _
    '       (Block.X = "") Or (Block.Y = "") Or (Block.I = "") Or (Block.I = "") Or (Block.J = "") Then
    '        Show_Error("Block not an arc (G2 or G3) : " & Block.Original_Block)
    '        Return Nothing
    '    End If

    '    End_X = Block.X
    '    End_Y = Block.Y
    '    I = Block.I
    '    J = Block.J

    '    Center_X = Start_X + I
    '    Center_Y = Start_Y + J

    '    Cartesian_To_Polar(Center_X, Center_Y, Start_X, Start_Y, Radius, Start_Angle)
    '    Cartesian_To_Polar(Center_X, Center_Y, End_X, End_Y, Radius, End_Angle)

    '    'Adjust Angle_Step to size of circle, small circles will not have many chords
    '    Circumference = Math.PI * Radius * 2
    '    Chords = Circumference / 0.05 'Number of .05 inch chords

    '    If Block.G.Contains("02") Then
    '        CW = True
    '        If End_Angle > Start_Angle Then 'Arc goes through zero
    '            Angle = 360 - End_Angle + Start_Angle
    '        Else
    '            Angle = Start_Angle - End_Angle
    '        End If
    '        If Start_Angle = 0 Then Start_Angle = 360
    '    ElseIf Block.G.Contains("03") Then
    '        CW = False
    '        If End_Angle < Start_Angle Then 'Arc goes through zero
    '            Angle = 360 - Start_Angle + End_Angle
    '        Else
    '            Angle = End_Angle - Start_Angle
    '        End If
    '        If End_Angle = 0 Then End_Angle = 360
    '    Else
    '        Show_Error("Interpolate block called with non arc GCoce block.")
    '    End If

    '    Angle_Step = Angle / Chords
    '    If 360 / Angle_Step < 36 Then Angle_Step = Angle / 10
    '    If 360 / Angle_Step > 360 Then Angle_Step = Angle / 360

    '    Angle = Start_Angle

    '    While Not Done

    '        cnt += 1
    '        If cnt > 361 Then
    '            Show_Error("Long loop in Interpolate_Arc")
    '            Return Nothing
    '        End If

    '        If CW Then
    '            Angle -= Angle_Step
    '            If Angle < End_Angle Then
    '                Angle = End_Angle
    '            End If
    '            Chord_Angle = Angle
    '            If Angle < 0 Then Chord_Angle = -Angle

    '        Else 'CCW
    '            Angle += Angle_Step
    '            If Angle > End_Angle Then
    '                Angle = End_Angle
    '                Done = True
    '            End If
    '            Chord_Angle = Angle
    '            If Angle >= 360 Then Chord_Angle = Angle - 360

    '        End If

    '        Pt = New struct_Coordinate
    '        Calc.Polar_To_Cartesian(Radius, Chord_Angle, Pt.X, Pt.Y)
    '        Pt.X += Center_X
    '        Pt.Y += Center_Y
    '        Pt.X = Math.Round(Pt.X, 3)
    '        Pt.Y = Math.Round(Pt.Y, 3)
    '        Points.Add(Pt)

    '        If Angle = End_Angle Then Done = True

    '    End While

    '    Return Points

    'End Function

End Class
