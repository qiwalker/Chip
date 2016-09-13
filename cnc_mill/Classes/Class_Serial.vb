Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Text.RegularExpressions

'***************************************************************************************************************************

Public Class Class_Serial_Port

#Region "Classes"

    Public Class Class_Message_Info
        Public Responding_Device As Integer
        Public Response_Command As Integer
    End Class

    Public Class Class_Status
        'Public Status_Type As enum_Status_Type
        Public Current_Block As Integer
        Public Abs_Last_Point As ctrl_Drawing.struct_Draw_Point
        Public Abs_Current_Point As ctrl_Drawing.struct_Draw_Point
        Public Wrk_Last_Point As ctrl_Drawing.struct_Draw_Point
        Public Wrk_Current_Point As ctrl_Drawing.struct_Draw_Point
        Public Status_Code As Class_Tiny_G.enum_Status_Code
        Public Tag As Object
    End Class

#End Region

#Region "Enums"

    Public Enum enum_Background_Message_Type
        Controller_Message
        Controller_Error

        Internal_Error
        Internal_Message

        Polling_Time_Update
        Sleep_Time_Update
        Loop_Time_Update

        Display_Update
    End Enum

#End Region

#Region "Declarations"

    Public Polling_Interval As Integer = 100 'Milliseconds

    Private WithEvents USB As SerialPort
    Public Default_Baud_Rate As Integer = 115200

    Private Busy_Receiving As Boolean = False
    Private Incoming_Message As String

    Private Incoming_Char As Char
    Private Incoming_Characters As String
    Private Bytes_To_Read As Integer

    Private Loop_Time_Stop_Watch As New Stopwatch
    Private Polling_Time_Stop_Watch As New Stopwatch
    Private Move_Time_Stopwatch As New Stopwatch

    Private Initialized As Boolean = False

    Public TinyG_Queue_Count As Integer = 28
    Public TinyG_Queue_Minumum As Integer = 10

    Private S() As String
    Private Param() As String
    Private Byte_Buffer(0) As Byte

    Private Cnt As Integer

    Private Block As String

    Private Last_Block_Number As Integer = -1

    Private Abs_Last_Point As ctrl_Drawing.struct_Draw_Point
    Private Abs_Current_Point As ctrl_Drawing.struct_Draw_Point
    Private Wrk_Last_Point As ctrl_Drawing.struct_Draw_Point
    Private Wrk_Current_Point As ctrl_Drawing.struct_Draw_Point

    Private Last_Status As Class_Tiny_G.enum_Status_Code

    Public Status_Queue As New List(Of Class_Status)

    Public Fault As String

    Public Ports As New List(Of String) 'String = Nothing
    Public Current_Com_Port As String = ""

    Public Lost_Connection As Boolean = False

#End Region

#Region "Queue_Immediate_Message, Queue_Error_Message, Send_Messages"

#Region "Connect, Disconnect, Port_Is_Open"

    Public Sub Get_Com_Ports()
        Ports = New List(Of String)
        Dim P() As String
        P = SerialPort.GetPortNames
        Ports = P.ToList
    End Sub

    Public Function Connect(Port_Name As String) As Boolean
        Initialized = False

        If IsNothing(USB) Then
            USB = New SerialPort
        Else
            If USB.IsOpen Then
                Return True
            End If
        End If

        'Initialize port
        USB.BaudRate = Default_Baud_Rate
        USB.Parity = Parity.None
        USB.StopBits = StopBits.One
        USB.DataBits = 8
        USB.Handshake = Handshake.XOnXOff
        USB.NewLine = vbLf

        USB.ReadTimeout = 1000 ' SerialPort.InfiniteTimeout
        USB.WriteTimeout = 100 ' SerialPort.InfiniteTimeout

        Try
            USB.PortName = Port_Name
            USB.Open()
            USB.DiscardInBuffer()
            Current_Com_Port = Port_Name
            Lost_Connection = False
        Catch ex As Exception
            Current_Com_Port = ""
            If ex.Message.Contains("denied") Then
                Show_Error("USB Channel locked up." & vbCrLf & _
                           "Power down computer to reset." & vbCrLf & _
                           "Error : " & ex.Message)
            End If
            Return False
        End Try

        Incoming_Message = ""

        'Force display to update
        Abs_Last_Point.Xo = -1
        Abs_Last_Point.Yo = -1
        Abs_Last_Point.Zo = -1

        Initialized = True

        Return True
    End Function

    Public Sub Disconnect()

        Try
            USB.Close()
            USB.Dispose()
        Catch ex As Exception
        End Try

    End Sub

    Public Function Connected() As Boolean
        If IsNothing(USB) Then Return False
        Return USB.IsOpen
    End Function

#End Region

#End Region

#Region "Send"

    Public Function Send_Message(message As String) As Boolean
        If IsNothing(USB) Then Return False
        If Not USB.IsOpen Then Return False

        Dim Retries As Integer = 0

        message &= vbCrLf

        For I = 0 To message.Length - 1
Retry:
            Try
                USB.Write(message, I, 1)
            Catch ex As Exception
                If ex.Message.Contains("denied") Then
                    Show_Error("USB Channel locked up." & vbCrLf & _
                               "Power down computer to reset." & vbCrLf & _
                               "Error : " & ex.Message)
                    Return False
                End If

                'An Xoff was received from the receiver
                'that blocked the USB.Write command
                'so this thread has to wait for an Xon 
                'Sleep a bit then try again
                Threading.Thread.Sleep(10)
                Retries += 1
                If Retries > 100 Then
                    Return False
                End If
                GoTo Retry
            End Try
        Next

        Return True

        'Threading.Thread.Sleep(100)

    End Function

    Public Sub Send_Byte(B As Byte)
        Byte_Buffer(0) = 24
        USB.Write(Byte_Buffer, 0, 1)
    End Sub

    Public Sub Send_Reset()
        If IsNothing(USB) Then Exit Sub
        If Not USB.IsOpen Then Exit Sub

        Dim Buffer(0) As Byte
        Buffer(0) = 24
        USB.Write(Buffer, 0, 1)
    End Sub

#End Region

#Region "Receive"

    Public Function Receive_Message() As String
        If IsNothing(USB) Then Return "|"
        If Not USB.IsOpen Then Return "|"

        Try

            Bytes_To_Read = USB.BytesToRead
            If Bytes_To_Read > 0 Then
                For I = 0 To Bytes_To_Read
                    Incoming_Char = Chr(USB.ReadChar)
                    If Incoming_Char = Chr(10) Then
                        Incoming_Message = Incoming_Characters
                        Incoming_Characters = ""
                        Return Incoming_Message
                    Else
                        Incoming_Characters &= Incoming_Char
                    End If
                Next
            Else
                Return ""
            End If

        Catch ex As Exception
            If ex.Message.Contains("denied") Then
                Show_Error("USB Channel locked up." & vbCrLf & _
                           "Power down computer to reset." & vbCrLf & _
                           "Error : " & ex.Message)
                Return "|"
            End If
        End Try

        Return "" 'Incoming_Message

    End Function

#End Region

End Class



