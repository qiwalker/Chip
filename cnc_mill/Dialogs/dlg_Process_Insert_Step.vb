Public Class dlg_Process_Insert_Step

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btn_GCode_Block_Click(sender As Object, e As EventArgs) Handles btn_GCode_Block.Click
        If Trim(txt_GCode_Block.Text) = "" Then
            Show_Error("Block box is empty, put in GCode block first.")
            Exit Sub
        End If
        Dim Blk As New Class_GCode
        blk.block = txt_GCode_Block.Text
        Block_List.Items.Add(Blk.Formatted_Block)
    End Sub

    Private Sub txt_GCode_Block_TextChanged(sender As Object, e As EventArgs) Handles txt_GCode_Block.Validated
        Dim Blk As New Class_GCode
        Blk.Block = txt_GCode_Block.Text
        Block_List.Items.Add(Blk.Formatted_Block)
    End Sub

End Class