
Public Class ctrl_Properties


    Private Sub ToolStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked
        Select Case e.ClickedItem.Text
            Case "Narrower"
                Me.Width -= 10
            Case "Wider"
                Me.Width += 10

        End Select
    End Sub

    Private Sub grid_Properties_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_Properties.CellClick

        Select Case Trim(grid_Properties.Rows(e.RowIndex).Cells(0).Value)
            Case ".Backcolor"
                Dim dlg As New dlg_Color_Picker
                dlg.Color_Name = grid_Properties.Rows(e.RowIndex).Cells(1).Value
                dlg.ShowDialog()
                grid_Properties.Rows(e.RowIndex).Cells(1).Value = dlg.Color.Name


            Case ".Image.File_Name"
                Dim dlg As New OpenFileDialog

                dlg.InitialDirectory = Chip_Macro_Program_Folder
                dlg.FileName = grid_Properties.Rows(e.RowIndex).Cells(1).Value
                dlg.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*"
                If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    grid_Properties.Rows(e.RowIndex).Cells(1).Value = dlg.FileName
                End If

        End Select

    End Sub
End Class
