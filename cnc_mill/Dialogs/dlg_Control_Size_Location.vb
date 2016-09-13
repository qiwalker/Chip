
Public Class dlg_Control_Size_Location

    Public Ctrl_Top As Integer
    Public Ctrl_Left As Integer
    Public Ctrl_Width As Integer
    Public Ctrl_Height As Integer
    Public Sym As Class_Symbols.class_Symbol

    Private Sub dlg_Control_Size_Location_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Ctrl_Top = Sym.Top
        Ctrl_Left = Sym.Left
        Ctrl_Width = Sym.Width
        Ctrl_Height = Sym.Height

        If Ctrl_Top < 0 Then Ctrl_Top = 0
        If Ctrl_Top > Sym.Ctrl.Parent.Height - Ctrl_Height Then Ctrl_Top = Sym.Ctrl.Parent.Height
        track_Top.Minimum = Ctrl_Height
        track_Top.Maximum = Sym.Ctrl.Parent.Height
        track_Top.Value = Sym.Ctrl.Parent.Height - Ctrl_Top

        If Ctrl_Left < 0 Then Ctrl_Left = 0
        If Ctrl_Left > Sym.Ctrl.Parent.Width - Ctrl_Width Then Ctrl_Left = Sym.Ctrl.Parent.Width - Ctrl_Width
        track_Left.Minimum = 0
        track_Left.Maximum = Sym.Ctrl.Parent.Width - Ctrl_Width
        track_Left.Value = Ctrl_Left

        If Ctrl_Width < 4 Then Ctrl_Width = 4
        If Ctrl_Width > Sym.Ctrl.Parent.Width - Ctrl_Width Then Ctrl_Width = Sym.Ctrl.Parent.Width - Ctrl_Width
        track_Width.Minimum = 4
        track_Width.Maximum = Sym.Ctrl.Parent.Width
        track_Width.Value = Ctrl_Width

        If Ctrl_Height < 4 Then Ctrl_Height = 4
        If Ctrl_Height > Sym.Ctrl.Parent.Height Then Ctrl_Height = Sym.Ctrl.Parent.Height
        track_Height.Minimum = 4
        track_Height.Maximum = Sym.Ctrl.Parent.Height
        track_Height.Value = Ctrl_Height

    End Sub

    Private Sub track_Top_Scroll(sender As Object, e As EventArgs) Handles track_Top.Scroll
        Sym.Top = Sym.Ctrl.Parent.Height - track_Top.Value
    End Sub

    Private Sub track_Left_Scroll(sender As Object, e As EventArgs) Handles track_Left.Scroll
        Sym.Left = track_Left.Value
    End Sub

    Private Sub Track_Width_Scroll(sender As Object, e As EventArgs) Handles track_Width.Scroll
        Sym.Width = track_Width.Value
    End Sub

    Private Sub track_Height_Scroll(sender As Object, e As EventArgs) Handles track_Height.Scroll
        Sym.Height = track_Height.Value
    End Sub

    Private Sub ts_Exit_Click(sender As Object, e As EventArgs) Handles ts_Exit.Click
        Ctrl_Top = Sym.Top
        Ctrl_Left = Sym.Left
        Ctrl_Width = Sym.Width
        Ctrl_Height = Sym.Height
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub ts_Cancel_Click(sender As Object, e As EventArgs) Handles ts_Cancel.Click
        Sym.Top = Ctrl_Top
        Sym.Left = Ctrl_Left
        Sym.Width = Ctrl_Width
        Sym.Height = Ctrl_Height
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

End Class