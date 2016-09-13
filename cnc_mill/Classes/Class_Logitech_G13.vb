Imports System.Text

Public Class Class_Logitech_G13

    Declare Function LogiLcdInit Lib "C:\Dot_Net_Dev\Chip_Application\LogitechLcdEnginesWrapper_64" (Text As Byte(), Type As Integer) As Boolean
    Declare Function LogiLcdMonoSetText Lib "C:\Dot_Net_Dev\Chip_Application\LogitechLcdEnginesWrapper_64" (Line_Number As Integer, Text As Byte()) As Boolean
    Declare Function LogiLcdUpdate Lib "C:\Dot_Net_Dev\Chip_Application\LogitechLcdEnginesWrapper_64" () As Boolean

    Declare Function LogiLedInit Lib "C:\Dot_Net_Dev\Chip_Application\LogitechLedEnginesWrapper_64" () As Boolean
    Declare Function LogiLedSetTargetDevice Lib "C:\Dot_Net_Dev\Chip_Application\LogitechLedEnginesWrapper_64" (Device As Integer) As Boolean
    Declare Function LogiLedSetLighting Lib "C:\Dot_Net_Dev\Chip_Application\LogitechLedEnginesWrapper_64" (RedPct As Integer, GreenPct As Integer, BluePct As Integer) As Boolean

    Public Enabled As Boolean = False

    Public Sub Init()
        Dim ascii As Encoding = Encoding.ASCII
        Dim unicode As Encoding = Encoding.Unicode
        Dim Txt As String = "Chip" ' "Default"
        Dim Bt(Txt.Length) As Byte
        Dim Disp_Type As Integer = 1  ' 1 is monochrome display

        For I = 0 To Txt.Length - 1
            Bt(I) = Convert.ToByte(Txt(I))
        Next

        Dim unicodeBytes As Byte() = Encoding.Convert(ascii, unicode, Bt)

        Try
            LogiLcdInit(unicodeBytes, Disp_Type) ' 1 is monochrome display
            Enabled = True
        Catch ex As Exception
            Flash_Message("Pendant not enabled, in x32 mode")
            Enabled = False
            Exit Sub
        End Try

        Wait.Delay_Seconds(0.25)
        LogiLedInit()
        LogiLedSetTargetDevice(7)
        Wait.Delay_Seconds(0.25)

    End Sub

    Public Sub Set_Color(Red_Pct As Integer, Green_Pct As Integer, Blue_Pct As Integer)
        If Not Enabled Then Exit Sub
        Try
            LogiLedSetLighting(Red_Pct, Green_Pct, Blue_Pct)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Set_Text(Line_Number As Integer, ByRef Text As String)
        If Not Enabled Then Exit Sub

        ' Create two different encodings.
        Dim ascii As Encoding = Encoding.ASCII
        Dim unicode As Encoding = Encoding.Unicode
        Dim Bt(Text.Length) As Byte

        For I = 0 To Text.Length - 1
            Bt(I) = Convert.ToByte(Text(I))
        Next

        Dim unicodeBytes As Byte() = Encoding.Convert(ascii, unicode, Bt)

        LogiLcdMonoSetText(Line_Number, unicodeBytes)

    End Sub

    Public Sub Display_Message(Line_0 As String, Optional Line_1 As String = "", Optional Line_2 As String = "", Optional Line_3 As String = "")
        If Not Enabled Then Exit Sub
        Set_Text(0, Line_0)
        Set_Text(1, Line_1)
        Set_Text(2, Line_2)
        Set_Text(3, Line_3)
        LogiLcdUpdate()
    End Sub

    Public Sub Update_Display()
        If Not Enabled Then Exit Sub
        LogiLcdUpdate()
    End Sub


End Class
