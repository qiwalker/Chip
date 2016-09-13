Public Class dlg_Hot_Key

    Public Hot_Key As String

    Private Alt As String = ""
    Private Ctrl As String = ""
    Private Shift As String = ""
    Private Key_Name As String = ""

    Private Sub ts_Exit_Click(sender As Object, e As EventArgs) Handles ts_Exit.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub ts_Cancel_Click(sender As Object, e As EventArgs) Handles ts_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Hot_Key = ""
        Close()
    End Sub

    Private Sub dlg_Hot_Key_Key_Down(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Dim Key_Text As String = e.KeyCode.ToString

        Select Case Key_Text
            Case "Menu"
                Alt = "Alt"
            Case "ControlKey"
                Ctrl = "Ctrl"
            Case "ShiftKey"
                Shift = "Shift"
            Case Else
                Key_Name = e.KeyCode.ToString
        End Select

        e.SuppressKeyPress = True

        e.Handled = True

    End Sub

    Private Sub dlg_Hot_Key_Key_Up(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then Exit Sub
        If e.Alt Then Exit Sub
        If e.Shift Then Exit Sub

        Hot_Key = ""

        If Ctrl <> "" Then Hot_Key = Ctrl & "-"
        If Alt <> "" Then Hot_Key &= Alt & "-"
        If Shift <> "" Then Hot_Key &= Shift & "-"

        If Hot_Key.Length = 0 Then
            Hot_Key = Key_Name
        Else
            Hot_Key &= Key_Name
        End If
        
        Shift = ""
        Alt = ""
        Ctrl = ""
        Key_Name = ""

        txt_Hot_Key.Text = Hot_Key

        e.SuppressKeyPress = True
        e.Handled = True

    End Sub


End Class