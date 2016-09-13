
Public Class dlg_G_Code_Errors

    Public Overloads Sub ShowDialog(Message)
        txt_Message.Text = Message
        ShowDialog()
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Close()
    End Sub

End Class