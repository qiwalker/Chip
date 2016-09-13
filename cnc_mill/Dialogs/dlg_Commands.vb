Public Class dlg_Commands

    Private Last_Command As String


    Private Sub dlg_Commands_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txt_Param.Focus()
        txt_Param.Text = Last_Command
    End Sub

    Private Sub cmb_Commands_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Commands.SelectedIndexChanged
        Dim Message As String
        Dim S() As String

        S = cmb_Commands.Text.Split(" ")
        Message = S(0)

        CNC.Queue_Message(Message, False)
        Close()

    End Sub

    Private Sub Me_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            CNC.Queue_Message(txt_Param.Text, False)
            Last_Command = txt_Param.Text
            Close()
        End If

    End Sub

End Class