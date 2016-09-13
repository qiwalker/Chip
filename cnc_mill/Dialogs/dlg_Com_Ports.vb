Public Class dlg_Com_Ports

    Public Com_Port As String
    Public Prompt As String

    Private Sub dlg_Com_Ports_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txt_Prompt.Text = Prompt

        If Main_Form.Serial.Ports.Count > 0 Then
            cmb_Ports.Items.Clear()
            For I = 0 To Main_Form.Serial.Ports.Count - 1
                cmb_Ports.Items.Add(Main_Form.Serial.Ports(I))
            Next
            cmb_Ports.Text = cmb_Ports.Items(0)
        Else
            Show_Error("No COM ports detected.")
        End If

    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Com_Port = cmb_Ports.Text
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

End Class