Public Class ctrl_Button

#Region "Declarations"

    Public Properties As Class_Tiny_G.struct_Control_Properties

#End Region

    Private Sub ctrl_Button_Load(sender As Object, e As EventArgs) Handles Me.Load
        Properties.Control_Type = Class_Tiny_G.enum_Control_Type.Button

        If Not IsNothing(Properties.Off_Image) Then Properties.Off_Image.MakeTransparent(Color.Magenta)
        If Not IsNothing(Properties.On_Image) Then Properties.On_Image.MakeTransparent(Color.Magenta)

        Properties.State = Properties.Initial_State

        If Properties.State Then
            If Not IsNothing(Properties.On_Image) Then
                Button.BackgroundImage = Properties.On_Image
            End If
            Button.Text = Properties.On_Text
        Else
            If Not IsNothing(Properties.Off_Image) Then
                Button.BackgroundImage = Properties.Off_Image
            End If
            Button.Text = Properties.Off_Text
        End If

        Button.BackColor = Parent.BackColor
        Main_Form.Controller.Register(Me)

    End Sub


#Region "Properties"

    Public Property Control_Initial_State As Boolean
        Get
            Return Properties.Initial_State
        End Get
        Set(ByVal value As Boolean)
            Properties.Initial_State = value
        End Set
    End Property

    Public Property Control_Toggle As Boolean
        Get
            Return Properties.Toggle
        End Get
        Set(ByVal value As Boolean)
            Properties.Toggle = value
        End Set
    End Property

    Public Property Control_Text_On As String
        Get
            Return Properties.On_Text
        End Get
        Set(ByVal value As String)
            Properties.On_Text = value
            Button.Text = Properties.On_Text
        End Set
    End Property

    Public Property Control_Position As Single
        Get
            Return Properties.Position
        End Get
        Set(ByVal value As Single)
            Properties.Position = value
        End Set
    End Property

    Public Property Control_Text_Off As String
        Get
            Return Properties.Off_Text
        End Get
        Set(ByVal value As String)
            Properties.Off_Text = value
            Button.Text = Properties.Off_Text
        End Set
    End Property

    Public Property Control_Image_On As Bitmap
        Get
            Return Properties.On_Image
        End Get
        Set(ByVal value As Bitmap)
            Properties.On_Image = value
        End Set
    End Property

    Public Property Control_Image_Off As Bitmap
        Get
            Return Properties.Off_Image
        End Get
        Set(ByVal value As Bitmap)
            Properties.Off_Image = value
            If Not IsNothing(Properties.Off_Image) Then
                Properties.Off_Image.MakeTransparent(Color.Magenta)
                Button.BackgroundImage = Properties.Off_Image
            End If
        End Set
    End Property

    Public Property Control_Function_Input As Class_Tiny_G.enum_Action_Functions
        Get
            Return Properties.Input_Function
        End Get
        Set(ByVal value As Class_Tiny_G.enum_Action_Functions)
            Properties.Input_Function = value
        End Set
    End Property

    Public Property Control_Function_Output As Class_Tiny_G.enum_Control_Output_Functions
        Get
            Return Properties.Output_Function
        End Get
        Set(ByVal value As Class_Tiny_G.enum_Control_Output_Functions)
            Properties.Output_Function = value
        End Set
    End Property

    Public Property Control_On_G_Code As String
        Get
            Return Properties.On_G_Code
        End Get
        Set(ByVal value As String)
            Properties.On_G_Code = value
        End Set
    End Property

    Public Property Control_Off_G_Code As String
        Get
            Return Properties.Off_G_Code
        End Get
        Set(ByVal value As String)
            Properties.Off_G_Code = value
        End Set
    End Property

    Public Property Control_Associated_Axis As Class_Tiny_G.enum_Axis
        Get
            Return Properties.Associated_Axis
        End Get
        Set(ByVal value As Class_Tiny_G.enum_Axis)
            Properties.Associated_Axis = value
        End Set
    End Property

    Public Property Control_Direction As Class_Tiny_G.enum_Direction
        Get
            Return Properties.Direction
        End Get
        Set(ByVal value As Class_Tiny_G.enum_Direction)
            Properties.Direction = value
        End Set
    End Property

    Public Property Control_Inhibit_On_In_E_Stop As Boolean
        Get
            Return Properties.Inhibit_On_In_Estop
        End Get
        Set(value As Boolean)
            Properties.Inhibit_On_In_Estop = value
        End Set
    End Property

    Public Property Control_Inhibit_Off_In_E_Stop As Boolean
        Get
            Return Properties.Inhibit_Off_In_Estop
        End Get
        Set(value As Boolean)
            Properties.Inhibit_Off_In_Estop = value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub Button_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button.MouseDown

        If Not Properties.Inhibit_On_In_Estop Then
            If Main_Form.Controller.Current_Status.E_Stop Then
                Exit Sub
            End If
        End If

        If Control_Toggle Then
            Properties.State = Not Properties.State
            If Properties.State Then
                Button.BackgroundImage = Properties.On_Image
                Button.Text = Properties.On_Text
            Else
                Button.BackgroundImage = Properties.Off_Image
                Button.Text = Properties.Off_Text
            End If
            Properties.Event_Type = Class_Tiny_G.enum_Event_Type.Change
            Main_Form.Controller.Execute_Controller_Function(Me)
        Else
            Button.BackgroundImage = Properties.On_Image
            Button.Text = Properties.On_Text
            Properties.Event_Type = Class_Tiny_G.enum_Event_Type.Down

            Select Case Me.Control_Function_Input

                Case Class_Tiny_G.enum_Action_Functions.Set_Position
                    If e.Button = Windows.Forms.MouseButtons.Left Then
                        Properties.Position = 0
                    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                        Dim dlg As New Dlg_Input
                        Select Case Properties.Associated_Axis
                            Case Class_Tiny_G.enum_Axis.X
                                dlg.Input_Value = FormatNumber(Main_Form.Controller_Status.Wrk_Current_Point.Xo, 3)
                            Case Class_Tiny_G.enum_Axis.Y
                                dlg.Input_Value = FormatNumber(Main_Form.Controller_Status.Wrk_Current_Point.Yo, 3)
                            Case Class_Tiny_G.enum_Axis.Z
                                dlg.Input_Value = FormatNumber(Main_Form.Controller_Status.Wrk_Current_Point.Zo, 3)
                            Case Else
                                Exit Sub
                        End Select
                        dlg.ShowDialog()

                        If dlg.DialogResult <> DialogResult.OK Then Exit Sub

                        Properties.Position = dlg.Input_Value

                        Button.BackgroundImage = Properties.Off_Image
                        Button.Text = Properties.Off_Text
                        Properties.Event_Type = Class_Tiny_G.enum_Event_Type.Up
                        Main_Form.Controller.Execute_Controller_Function(Me)
                        Properties.State = False
                        Exit Sub
                    Else
                        Exit Sub
                    End If

                Case Class_Tiny_G.enum_Action_Functions.Probe

                    Main_Form.Controller.Execute_Controller_Function(Me)
                    Properties.State = False
                    Exit Sub

            End Select

            Main_Form.Controller.Execute_Controller_Function(Me)
            Properties.State = True
        End If
    End Sub

    Private Sub Button_MouseUp() Handles Button.MouseUp
        If Not Control_Toggle Then
            Button.BackgroundImage = Properties.Off_Image
            Button.Text = Properties.Off_Text
            Properties.Event_Type = Class_Tiny_G.enum_Event_Type.Up
            Main_Form.Controller.Execute_Controller_Function(Me)
            Properties.State = False
        End If
    End Sub

#End Region

    Public Sub Set_Button_State(State As Boolean)

        If Not Properties.Inhibit_Off_In_Estop Then
            If Main_Form.Controller.Current_Status.E_Stop Then
                Exit Sub
            End If
        End If

        Properties.State = State
        If Properties.State Then
            Button.BackgroundImage = Properties.On_Image
            Button.Text = Properties.On_Text
        Else
            Button.BackgroundImage = Properties.Off_Image
            Button.Text = Properties.Off_Text
        End If
        Properties.Event_Type = Class_Tiny_G.enum_Event_Type.Change
        Main_Form.Controller.Execute_Controller_Function(Me)
    End Sub


End Class
