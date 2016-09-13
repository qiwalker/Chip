
Public Class dlg_Input

    Public On_Top As Boolean = False

    Public Input_Value As String
    Private Deflt_Value As String = "0"
    Private Prmt As String = "Enter Value"
    Private Is_Number As Boolean

    Public Overloads Sub ShowDialog(Prompt As String, Optional Default_Value As String = "", _
                                    Optional Button_Text As String = "Default", Optional Number As Boolean = True)
        If Prompt <> "" Then Prmt = Prompt
        If Default_Value <> "" Then Deflt_Value = Default_Value

        If Button_Text = "" Then
            btn_Default.Visible = False
        Else
            btn_Default.Text = Button_Text & " (" & Default_Value & ")"
        End If

        If On_Top Then
            Me.TopMost = True
            Me.StartPosition = FormStartPosition.CenterScreen
        End If

        Is_Number = Number
        If Is_Number Then
            txt_Input.TextAlign = HorizontalAlignment.Right
        End If

        If Me.Visible Then Exit Sub
        ShowDialog()
    End Sub

    Private Sub Dlg_Input_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = Prmt
        txt_Input.Text = Input_Value

        txt_Input.SelectionStart = txt_Input.Text.Length
        txt_Input.Focus()
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        If Is_Number Then
            If (txt_Input.Text = "") Or (Not IsNumeric(txt_Input.Text)) Then
                Show_Error("Value not a number.")
                Exit Sub
            End If
        End If

        Input_Value = txt_Input.Text
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub Dlg_Input_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Input_Value = txt_Input.Text
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub btn_Default_Click(sender As Object, e As EventArgs) Handles btn_Default.Click
        Input_Value = Deflt_Value
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

End Class