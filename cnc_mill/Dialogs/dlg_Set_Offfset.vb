Public Class dlg_Set_Offfset

    Public X_Offset As Single
    Public Y_Offset As Single
    Public Z_Offset As Single

    Public X_Probe As Single
    Public Y_Probe As Single
    Public Z_Probe As Single

    Public X_Position As Single
    Public Y_Position As Single
    Public Z_Position As Single


    Private Sub dlg_Set_Offfset_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txt_X_Offset.Text = X_Offset
        txt_Probe_X.Text = X_Probe
        txt_Current_X.Text = X_Position

        txt_Y_Offset.Text = Y_Offset
        txt_Probe_Y.Text = Y_Probe
        txt_Current_Y.Text = Y_Position

        txt_Z_Offset.Text = Z_Offset
        txt_Probe_Z.Text = Z_Probe
        txt_Current_Z.Text = Z_Position
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        If (txt_X_Offset.Text = "") Or (Not IsNumeric(txt_X_Offset.Text)) Then
            Show_Error("X Value not a number")
            Exit Sub
        End If
        If (txt_Y_Offset.Text = "") Or (Not IsNumeric(txt_Y_Offset.Text)) Then
            Show_Error("Y Value not a number")
            Exit Sub
        End If
        If (txt_Z_Offset.Text = "") Or (Not IsNumeric(txt_Z_Offset.Text)) Then
            Show_Error("Z Value not a number")
            Exit Sub
        End If

        X_Offset = txt_X_Offset.Text
        Y_Offset = txt_Y_Offset.Text
        Z_Offset = txt_Z_Offset.Text
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btn_Set_Probe_X_Click(sender As Object, e As EventArgs) Handles btn_Set_Probe_X.Click
        txt_X_Offset.Text = X_Probe
    End Sub

    Private Sub btn_Set_Probe_Y_Click(sender As Object, e As EventArgs) Handles btn_Set_Probe_Y.Click
        txt_Y_Offset.Text = Y_Probe
    End Sub

    Private Sub btn_Set_Probe_Z_Click(sender As Object, e As EventArgs) Handles btn_Set_Probe_Z.Click
        txt_Z_Offset.Text = Z_Probe
    End Sub

    Private Sub btn_Set_Position_X_Click(sender As Object, e As EventArgs) Handles btn_Set_Position_X.Click
        txt_X_Offset.Text = txt_Current_X.Text
    End Sub

    Private Sub btn_Set_Position_Y_Click(sender As Object, e As EventArgs) Handles btn_Set_Position_Y.Click
        txt_Y_Offset.Text = txt_Current_Y.Text
    End Sub

    Private Sub btn_Set_Position_Z_Click(sender As Object, e As EventArgs) Handles btn_Set_Position_Z.Click
        txt_Z_Offset.Text = txt_Current_Z.Text
    End Sub

End Class