Imports System.IO

Public Class dlg_Offset_Check

    Public Program_Offset_File As String
    Public Fixture_Offset_File As String
    Public Load_Offset_File As Boolean = False

    Public Function Check_Offsets() As Boolean
        If (Program_Offset_File = "") And (Fixture_Offset_File = "") Then Return False
        If (Program_Offset_File = "") And (Fixture_Offset_File <> "") Then Return False
        If (Program_Offset_File <> "") And (Fixture_Offset_File = "") Then Return False
        If Program_Offset_File <> Fixture_Offset_File Then Return False
        Return True
    End Function

    Private Sub dlg_Offset_Check_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        btn_Set_Program.Enabled = True
        btn_Set_Offset.Enabled = True

        If Program_Offset_File <> "" Then
            txt_Program_Folder.Text = Path.GetDirectoryName(Program_Offset_File)
            txt_Program_File.Text = Path.GetFileName(Program_Offset_File)

            If Not File.Exists(Program_Offset_File) Then
                Show_Error("Program Offset File not found.")
                btn_Set_Offset.Enabled = False
            End If
        End If

        If Fixture_Offset_File <> "" Then
            txt_Offset_Folder.Text = Path.GetDirectoryName(Fixture_Offset_File)
            txt_Offset_File.Text = Path.GetFileName(Fixture_Offset_File)

            If Not File.Exists(Fixture_Offset_File) Then
                Show_Error("Fixture Offset File not found.")
                btn_Set_Program.Enabled = False
            End If
        End If

        If (Program_Offset_File = "") And (Fixture_Offset_File = "") Then
            txt_Message.Text = "Neither the program nor the current offsets have been assigned an offset file."
            btn_Set_Program.Enabled = False
            btn_Set_Offset.Enabled = False

        ElseIf (Program_Offset_File = "") And (Fixture_Offset_File <> "") Then
            txt_Message.Text = "The program offsets have not been assigned."
            btn_Set_Offset.Enabled = False

        ElseIf (Program_Offset_File <> "") And (Fixture_Offset_File = "") Then
            txt_Message.Text = "Current offsets have not been assigned."
            btn_Set_Program.Enabled = False
        ElseIf Program_Offset_File <> Fixture_Offset_File Then
            txt_Message.Text = "The program offset file does not match the current offset file."
        End If

    End Sub

    Private Sub btn_Set_Program_Click(sender As Object, e As EventArgs) Handles btn_Set_Program.Click
        Program_Offset_File = Fixture_Offset_File
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Set_Offset_Click(sender As Object, e As EventArgs) Handles btn_Set_Offset.Click
        Fixture_Offset_File = Program_Offset_File
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Set_Both_Click(sender As Object, e As EventArgs) Handles btn_Set_Both.Click
        Load_Offset_File = True
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

  
End Class