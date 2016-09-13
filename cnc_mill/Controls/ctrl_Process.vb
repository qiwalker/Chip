Imports System.IO

Public Class ctrl_Process

#Region "Declarations"

    Private GCode_Controls As New List(Of ctrl_Gcode)
    Private GCode_Controls_Index As New List(Of String)

    Private WithEvents ctrl_GCode As ctrl_Gcode
    Private Initialized As Boolean = False

    Private Control_Symbol As Class_Symbols.class_Symbol

#End Region

#Region "Initialize, Close"

    Public Sub Clear()
        GCode_Controls.Clear()
        GCode_Controls_Index.Clear()
    End Sub


    Public Sub Reset()
        For I = 0 To GCode_Controls.Count - 1
            GCode_Controls(I).Reset()

        Next
    End Sub

    Public Sub Initialize(sym As Class_Symbols.class_Symbol)
        Control_Symbol = sym
        For I = 0 To GCode_Controls.Count - 1
            GCode_Controls(I).Setup()
            If Not IsNothing(GCode_Controls(I).Drawing_Control) Then
                GCode_Controls(I).Drawing_Control.Setup()
            End If
        Next

        Initialized = True
    End Sub

    Public Sub Close()
        For g = 0 To GCode_Controls.Count - 1
            GCode_Controls(g).Finish()
        Next
    End Sub


#End Region

#Region "Add GCode and Drawing Controls"

    Public Sub Add_GCode_Control(sym As Class_Symbols.class_Symbol)

        For I = 0 To tab_Gcode.TabPages.Count - 1
            If tab_Gcode.TabPages(I).Text = sym.Role Then 'Control already exists
                Exit Sub
            End If
        Next

        'Add tab page
        Dim tab As New TabPage
        tab.Text = sym.Role
        tab_Gcode.TabPages.Add(tab)

        'Put control on tab page
        ctrl_GCode = New ctrl_Gcode
        ctrl_GCode = sym.Ctrl

        ctrl_GCode.Tag = sym
        ctrl_GCode.Initialize(sym)
        ctrl_GCode.Dock = DockStyle.Fill
        tab.Controls.Add(ctrl_GCode)

        GCode_Controls.Add(ctrl_GCode)
        GCode_Controls_Index.Add(sym.Role)

    End Sub

    Public Sub Add_Drawing_Control(sym As Class_Symbols.class_Symbol, _
                                   Max_X As Single, Max_Y As Single, Max_Z As Single)

        For I = 0 To tab_Drawing.TabPages.Count - 1
            If tab_Drawing.TabPages(I).Text = sym.Role Then 'Control already exists
                Exit Sub
            End If
        Next

        'Add tab page
        Dim tab As New TabPage
        tab.Text = sym.Role
        tab_Drawing.TabPages.Add(tab)

        'Put control on tab page
        Dim ctrl_Draw As ctrl_Drawing = sym.Ctrl
        tab.Controls.Add(ctrl_Draw)

        'Link Drawing control to Gcode control
        Dim Idx As Integer = GCode_Controls_Index.IndexOf(sym.Role)
        Dim GCode_Symbol As Class_Symbols.class_Symbol = GCode_Controls(Idx).Tag 'Control tag holds pointer to symbol

        'Link GCode control to Drawing Control
        Dim GCode_Control As ctrl_Gcode = GCode_Symbol.Ctrl
        GCode_Control.Drawing_Control = ctrl_Draw

        'Link Drawing control to GCode control
        ctrl_Draw.GCode_Control = GCode_Control

        '**************************************************************************
        'Do not move these two lines, drawing will not work, fill must be done last
        ctrl_Draw.Initialize(sym, Max_X, Max_Y, Max_Z)
        ctrl_Draw.Dock = DockStyle.Fill
        '**************************************************************************

    End Sub

#End Region

#Region "Interface routines to GCode controls"

    Public Sub Send_Blocks()
        For I = 0 To GCode_Controls.Count - 1
            If GCode_Controls(I).Program_Is_Runing And (Not GCode_Controls(I).Program_Is_Stepping) Then
                GCode_Controls(I).Send_Blocks()
                Exit Sub
            End If
        Next
    End Sub

    Public Function Get_GCode_By_Name(ctrl_Name As String) As ctrl_Gcode
        Dim sym As Class_Symbols.class_Symbol

        For I = 0 To GCode_Controls.Count - 1
            sym = GCode_Controls(I).Tag

            If sym.Name = ctrl_Name Then
                Return GCode_Controls(I)
            End If
        Next
        Return Nothing
    End Function

    Public Function Start_Program_Execution() As Boolean
        Return GCode_Controls(tab_Gcode.SelectedIndex).Start_Program_Execution()
    End Function

    Public Sub Stop_Program_Execution()

        GCode_Controls(tab_Gcode.SelectedIndex).Stop_Program_Execution()

        For I = 0 To GCode_Controls.Count - 1
            GCode_Controls(I).Program_Executing = False
            'GCode_Controls(I).Program_Ready = False
        Next
    End Sub

    Public Sub Update_Block_Progress(Evnt As Class_CNC.class_Event)
        If Not Initialized Then Exit Sub
        For I = 0 To GCode_Controls.Count - 1
            If GCode_Controls(I).Program_Executing Then
                GCode_Controls(I).Update_Block_Progress(Evnt)
            End If

            'If GCode_Controls(I).Program_Ready Then
            '    GCode_Controls(I).Update_Block_Progress(Evnt)
            'End If
        Next
    End Sub

    Public Sub Block_Sent(Evnt As Class_CNC.class_Event)
        If Not Initialized Then Exit Sub
        For I = 0 To GCode_Controls.Count - 1
            If GCode_Controls(I).Program_Executing Then
                GCode_Controls(I).Block_Sent(Evnt)
            End If
        Next
    End Sub

    Public Sub Notify(Evnt As Class_CNC.class_Event)
        If Not Initialized Then Exit Sub
        For I = 0 To GCode_Controls.Count - 1
            If GCode_Controls(I).Program_Executing Then
                GCode_Controls(I).Notify(Evnt)
            End If
        Next
    End Sub

    'Public Sub Program_Ended()
    '    If Not Initialized Then Exit Sub
    '    For I = 0 To GCode_Controls.Count - 1
    '        If GCode_Controls(I).Program_Executing Then
    '            GCode_Controls(I).Program_Ended()
    '            GCode_Controls(I).Program_Executing = False
    '            'GCode_Controls(I).Program_Ready = False
    '        End If
    '    Next
    'End Sub

#End Region

#Region "Tab controls"

    Private Sub tab_Gcode_Selecting(sender As Object, e As System.Windows.Forms.TabControlCancelEventArgs) Handles tab_Gcode.Selecting

        If Not Symbol.Get_Value("Sys.In_Cycle_Stop") Then
            Flash_Message("Cannot switch to another program while in cycle.")
            e.Cancel = True
        End If
    End Sub

    Private Sub tab_Gcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_Gcode.SelectedIndexChanged
        Dim tab As TabPage = tab_Gcode.SelectedTab

        For I = 0 To tab_Drawing.TabPages.Count - 1
            If tab_Drawing.TabPages(I).Text = tab_Gcode.SelectedTab.Text Then
                tab_Drawing.SelectedIndex = I
            End If
        Next

    End Sub

    Private Sub tab_Drawing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_Drawing.SelectedIndexChanged
        Dim tab As TabPage = tab_Drawing.SelectedTab
        For I = 0 To tab_Drawing.TabPages.Count - 1
            If tab_Gcode.TabPages(I).Text = tab_Drawing.SelectedTab.Text Then
                If Symbol.Get_Value("Sys.In_Cycle_Stop") Then
                    tab_Gcode.SelectedIndex = I
                End If
            End If
        Next
    End Sub

#End Region

End Class
