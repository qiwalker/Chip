Imports System.IO

Module Mod_Global

    Public Firmware_Build As String = ""
    Public FirmwareVersion As String = ""
    Public Hardware_Version As String = ""
    Public TinyG_ID As String = ""

    Public Test_Cnt As Integer = 0

    Public Enum enum_Program_Mode
        Simulate
        Real_Machine
    End Enum

    Public mm_to_inch As Single = 1 / 25.4

    Public Logitech_G13 As New Class_Logitech_G13
  
    Public Calc As New Class_Calc

    Public G_Code As New Class_Macro_Interpreter

    Public Controller As New Class_Tiny_G

    Public Macros As New Class_Macro_Routines

    Public Program_Mode As enum_Program_Mode
    Private Status_Shadow As String

    Public Settings_Path As String

    Public Chip_Symbol_File_Name As String = "Chip_Symbols.txt"
    Public Chip_Settings_File_Name As String = "Chip_Settings.txt"
    Public Chip_Wizard_Settings_File_Name As String = "Chip_Wizard_Settings.txt"
    Public Chip_Time_File_Name As String = "Chip_Times.txt"

    Public Chip_Icons_Folder As String
    Public Chip_Images_Folder As String
    Public Chip_Macro_Program_Folder As String

    Public Chip_Symbols_File As String
    Public Chip_Settings_File As String
    Public Chip_Wizards_File As String
    Public Chip_Times_File As String

    Public Chip_Help_Path As String = "Help\"
    Public Chip_Wizard_G_Code_Folder As String

    Public Settings As New Class_Settings

    Public Grid_Font = New Font("Microsoft Sans Serif", 9)
    Public GCode_Grid_Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

    Public Form_Controls As New Class_Controls
    Public CNC As New Class_CNC

    Public Wait As New Class_Delay


    Public Param As New Class_Parameters

    Public Fixture As New Class_Fixture
    Public Jobs As New Class_Jobs

    Public Symbol As New Class_Symbols

    Public Equation As New Class_Equation_Parser
    Public RPN As New Class_Reverse_Polish_Notation

    Public Send_Keys As New Class_Process
    Public Viewer As New Class_Process


    Public Camera As New dlg_Camera
    Public Camera_Controls As New dlg_Camera_Controls

    Public Message_Box As New dlg_Message_Box
    Private Message_Flash As New dlg_Flash_Message
    Private Err_Dialog As New dlg_Message_Box
    Private Input_Dialog As New dlg_Input
    Public Download_Dialog As New dlg_Modal_Message
    Public Offset_Check_Dialog As New dlg_Offset_Check

    Public Macro_Editor As New dlg_Macro_Editor

    Public Debug_Environment As Boolean = False

    Public Sub Initialize_Paths()
        Dim Application_Path As String

        Application_Path = Application.StartupPath

        'Application_Path = "C:\Chip"

        Settings_Path = Application_Path

        Dim s As String = Mid(Application_Path, Application_Path.Length, 1)

        If Application_Path.Contains("bin\Debug") Then
            Application_Path = Application_Path.Replace("CNC_Mill\bin\Debug", "")
            Settings_Path = "C:\Chip\Settings"
            Chip_Macro_Program_Folder = "C:\Chip\Macros\"
            Chip_Wizard_G_Code_Folder = "C:\Chip\G_Code\"
            Chip_Images_Folder = "C:\Chip\Images\"
            Chip_Icons_Folder = "C:\Chip\Icons\"
            Debug_Environment = True
        Else
            Settings_Path &= "\Settings"
            Chip_Macro_Program_Folder &= Application_Path & "\Macros\"
            Chip_Wizard_G_Code_Folder &= Application_Path & "\G_Code\"
            Chip_Images_Folder &= Application_Path & "\Images\"
            Chip_Icons_Folder &= Application_Path & "\Icons\"
        End If

        Chip_Symbols_File = Settings_Path & "\" & Chip_Symbol_File_Name
        Chip_Settings_File = Settings_Path & "\" & Chip_Settings_File_Name
        Chip_Wizards_File = Settings_Path & "\" & Chip_Wizard_Settings_File_Name
        Chip_Times_File = Settings_Path & "\" & Chip_Time_File_Name

    End Sub

    Public Sub Flash_Message(ByVal Message As String, Optional Seconds As Single = 1.5)
        Message_Flash.ShowMessage(Message, Main_Form, Seconds)
    End Sub

    Public Sub Show_Error(ByVal Message As String)
        If Message_Box.Visible Then Exit Sub
        Message_Box.ShowDialog(Message, "Error")
    End Sub

    Public Function Get_User_Input(ByVal Value As String, Prompt As String, Default_Value As String, Button_Text As String, Optional Number As Boolean = True) As String
        Input_Dialog.Input_Value = Value
        Input_Dialog.ShowDialog(Prompt, Default_Value, Button_Text, Number)

        If Input_Dialog.DialogResult = DialogResult.OK Then
            Return Input_Dialog.Input_Value
        Else
            Return Nothing
        End If
    End Function

    Public Function C_Int(N As String) As Integer
        If IsNumeric(N) Then
            Return CInt(N)
        Else
            Return 0
        End If
    End Function

    Public Function C_dbl(N As String) As Integer
        If IsNumeric(N) Then
            Return CSng(N)
        Else
            Return 0
        End If
    End Function


    Public Sub Load_Grid(Grid As DataGridView, File_Name As String, Optional Filter_1 As String = "", Optional Filter_2 As String = "")
        Dim Buff() As String
        Dim Cells() As String

        Buff = File.ReadAllLines(File_Name)

        For R = 0 To Buff.Count - 1
            Cells = Buff(R).Split("~")
            If Filter_1 <> "" Then
                If Cells(0) = Filter_1 Then
                    If Filter_2 <> "" Then
                        If Cells(1) = Filter_2 Then
                            Grid.Rows.Add(Cells)
                        End If
                    Else
                        Grid.Rows.Add(Cells)
                    End If
                End If
            Else
                Grid.Rows.Add(Cells)
            End If
        Next

    End Sub

    Public Sub Save_Grid(Grid As DataGridView, File_Name As String)
        Dim Buff As New List(Of String)
        Dim S As String

        Grid.EndEdit()
        For R = 0 To Grid.RowCount - 2
            S = ""
            For c = 0 To Grid.Rows(R).Cells.Count - 1
                S &= Grid.Rows(R).Cells(c).Value
                If c < Grid.Rows(R).Cells.Count - 1 Then S &= "~"
            Next
            Buff.Add(S)
        Next
        File.WriteAllLines(File_Name, Buff)

    End Sub


    'Used for debug
    Public Sub Nop()
    End Sub

End Module
