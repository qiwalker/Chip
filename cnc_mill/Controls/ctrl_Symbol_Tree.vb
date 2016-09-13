Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class ctrl_Symbol_Tree

    Class ListViewItemComparer
        Implements IComparer

        Private col As Integer

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End Function

    End Class

    Public Enum enum_Views
        Details
        List
        Sorted
        Unsorted
        Grouped
    End Enum

    Public Enum enum_Node_Type
        Symbol
        Text
        Off_Image
        On_Image
        Current_Image
        Back_Color
        Read_Only
        No_Edit
        Locked
    End Enum

    Public Event Symbol_Edit(Sym As Class_Symbols.class_Symbol)

    Private Clip_Board_Node As TreeNode
    Private Tree_Manager As New Class_Tree
    Private Tree_File_Name As String = ""
    Private Data_File As New Class_Data_File
    Private Level_Padding As New List(Of Integer)

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub Initialize()
        ts_Sort.Text = "Sort"
        Load_Tree(Tree_Type_View, False)
        Load_Tree(Tree_Name_View, True)
        Load_List()
    End Sub

    Private Sub list_Symbols_ItemSelectionChanged(sender As Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles list_Symbols.ItemSelectionChanged
        RaiseEvent Symbol_Edit(e.Item.Tag)
    End Sub

    Private Sub Tree_View_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) _
        Handles Tree_Type_View.AfterSelect, Tree_Name_View.AfterSelect

        Dim S As Class_Symbols.class_Symbol = e.Node.Tag

        If e.Node.Text.Contains("=") Then
            RaiseEvent Symbol_Edit(e.Node.Tag)
        End If

    End Sub

    Private Sub ts_View_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ts_Symbols.ItemClicked

        Select Case e.ClickedItem.Text
            Case "Insert"

            Case "Delete"

            Case "Collapse"
                If Not IsNothing(Tree_Type_View.SelectedNode) Then
                    Tree_Type_View.SelectedNode.Collapse()
                End If

            Case "Expand"
                If IsNothing(Tree_Type_View.SelectedNode) Then
                    Tree_Type_View.ExpandAll()
                Else
                    Tree_Type_View.SelectedNode.ExpandAll()
                End If

            Case "Copy"

            Case "Up"

            Case "Down"

            Case "Unsort"
                Cursor = Cursors.WaitCursor
                Load_List()
                ts_Sort.Text = "Sort"
                Cursor = Cursors.Arrow

            Case "Sort"
                Cursor = Cursors.WaitCursor
                list_Symbols.ListViewItemSorter = New ListViewItemComparer(0)
                ts_Sort.Text = "Unsort"
                Cursor = Cursors.Arrow

        End Select

    End Sub

    Private Sub Tree_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles _
                    Tree_Type_View.PreviewKeyDown, Tree_Name_View.PreviewKeyDown
        If e.KeyCode < Keys.D0 Or e.KeyCode > Keys.Z Then Exit Sub

        Dim dlg As New dlg_Tree_Node
        dlg.txt_Name.Text = Tree_Type_View.SelectedNode.Text
        dlg.ShowDialog()
        Tree_Type_View.SelectedNode.Text = dlg.txt_Name.Text
    End Sub

    Public Sub Load_List()

        list_Symbols.Items.Clear()
        list_Symbols.ListViewItemSorter = Nothing

        Dim Sym As Class_Symbols.class_Symbol
        Dim Image_Count As Integer = -1

        For I = 0 To Symbol.Symbol_Table.Count - 1
            Sym = Symbol.Symbol_Table(I)
            Sym.Symbol_Table_Row = I

            Dim Item = New ListViewItem(Sym.Name)

            Item.Tag = Sym
            Item.SubItems.Add(Sym.Value.ToString)
            Item.SubItems.Add(Sym.Type.ToString)
            Item.SubItems.Add(Sym.Comment.ToString)
            list_Symbols.Items.Add(Item)
        Next

        list_Symbols.Invalidate()

    End Sub

    Public Sub Load_Tree(Tree_View As TreeView, By_Name As Boolean)
        Dim Target_Node As TreeNode = Nothing
        Dim Parent_Node As TreeNode = Nothing
        Dim Child_Node As TreeNode = Nothing
        Dim Sym As Class_Symbols.class_Symbol
        Dim Keys() As String
        Dim Key As String
        Dim Level As Integer = 0
        Dim Node_Added As Boolean
        Dim Image_List As ImageList
        Dim Image_Count As Integer

        Image_List = New ImageList
        Image_List.ImageSize = New Size(24, 24)
        Dim bm As New Bitmap(Chip_Icons_Folder & "Point.png") '0
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Label.png") '1
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Whole_Number.png") '2
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Real_Number.png") '3
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Logical.png") '4
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Text_Box.png") '5
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Button.png") '6
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Hot_Key.png") '7
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Color.png") '8
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "GCode.png") '9
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Process.png") '10
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "GCode_Dialog.png") '11
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Drawing.png") '12
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "Dialog.png") '13
        Image_List.Images.Add(bm)
        bm = New Bitmap(Chip_Icons_Folder & "TinyG.png") '14
        Image_List.Images.Add(bm)

        Image_Count = 15

        Me.Cursor = Cursors.WaitCursor
        Tree_View.BeginUpdate()
        Tree_View.SuspendLayout()

        Tree_View.Nodes.Clear()
        Tree_View.PathSeparator = "."

        While Level >= 0
            Node_Added = False

            For I = 0 To Symbol.Symbol_Table.Count - 1
                Sym = Symbol.Symbol_Table(I)

                If By_Name Then
                    Key = Sym.Name
                Else
                    Key = Sym.Type.ToString & "." & Sym.Name
                End If

                Keys = Key.Split(".")
                Key = ""

                For K = 0 To Level

                    If Keys.Count > Level Then
                        If K > 0 Then Key = Key & "."
                        Key &= Keys(K)
                        Target_Node = Find_Node(Tree_View, Key)

                        If IsNothing(Target_Node) Then
                            Child_Node = New TreeNode
                            Child_Node.Name = Key
                            Child_Node.BackColor = Color.White

                            If K = Level Then
                                Child_Node.Tag = Sym
                                Sym.Tree_Node = Child_Node
                            End If

                            If Level = 0 Then
                                If By_Name Then
                                    Child_Node.Text = Key
                                Else
                                    Child_Node.Text = Sym.Type.ToString
                                End If
                                Tree_View.Nodes.Add(Child_Node)
                                Node_Added = True
                            Else
                                If By_Name Then
                                    Child_Node.Text = Key
                                Else
                                    Child_Node.Text = Sym.Type.ToString
                                End If
                                Parent_Node.Nodes.Add(Child_Node)
                                Node_Added = True
                            End If


                            If Level <= 1 Then

                                Select Case Sym.Type
                                    Case Class_Symbols.enum_Symbol_Type.Whole
                                        Child_Node.ImageIndex = 2
                                    Case Class_Symbols.enum_Symbol_Type.Real
                                        Child_Node.ImageIndex = 3
                                    Case Class_Symbols.enum_Symbol_Type.Logical
                                        Child_Node.ImageIndex = 4
                                    Case Class_Symbols.enum_Symbol_Type.Text
                                        Child_Node.ImageIndex = 1
                                    Case Class_Symbols.enum_Symbol_Type.Text_Box
                                        Child_Node.ImageIndex = 5
                                    Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label
                                        Child_Node.ImageIndex = 6
                                    Case Class_Symbols.enum_Symbol_Type.Hot_Key
                                        Child_Node.ImageIndex = 7
                                    Case Class_Symbols.enum_Symbol_Type.Color
                                        Child_Node.ImageIndex = 8
                                    Case Class_Symbols.enum_Symbol_Type.GCode
                                        Child_Node.ImageIndex = 9
                                    Case Class_Symbols.enum_Symbol_Type.Process
                                        Child_Node.ImageIndex = 10
                                    Case Class_Symbols.enum_Symbol_Type.Dialog_GCode
                                        Child_Node.ImageIndex = 11
                                    Case Class_Symbols.enum_Symbol_Type.Dialog_Drawing
                                        Child_Node.ImageIndex = 12
                                    Case Class_Symbols.enum_Symbol_Type.Dialog_Box
                                        Child_Node.ImageIndex = 13
                                    Case Class_Symbols.enum_Symbol_Type.TinyG_Setting
                                        Child_Node.ImageIndex = 14

                                End Select

                                Child_Node.SelectedImageIndex = Child_Node.ImageIndex

                            ElseIf Level = K Then
                                Select Case Sym.Type
                                    Case Class_Symbols.enum_Symbol_Type.Button, Class_Symbols.enum_Symbol_Type.Toggle, Class_Symbols.enum_Symbol_Type.Label
                                        Image_List.Images.Add(Sym.Ctrl.BackgroundImage)
                                        Child_Node.ImageIndex = Image_Count
                                        Image_Count += 1
                                    Case Class_Symbols.enum_Symbol_Type.Whole
                                        Child_Node.ImageIndex = 2
                                    Case Class_Symbols.enum_Symbol_Type.Real
                                        Child_Node.ImageIndex = 3
                                    Case Class_Symbols.enum_Symbol_Type.Logical
                                        Child_Node.ImageIndex = 4
                                    Case Class_Symbols.enum_Symbol_Type.Text
                                        Child_Node.ImageIndex = 1
                                    Case Class_Symbols.enum_Symbol_Type.Text_Box
                                        Child_Node.ImageIndex = 5
                                    Case Class_Symbols.enum_Symbol_Type.Hot_Key
                                        Child_Node.ImageIndex = 7
                                    Case Class_Symbols.enum_Symbol_Type.Color
                                        Child_Node.ImageIndex = 8
                                    Case Class_Symbols.enum_Symbol_Type.GCode
                                        Child_Node.ImageIndex = 9
                                    Case Class_Symbols.enum_Symbol_Type.Process
                                        Child_Node.ImageIndex = 10
                                    Case Class_Symbols.enum_Symbol_Type.Dialog_GCode
                                        Child_Node.ImageIndex = 11
                                    Case Class_Symbols.enum_Symbol_Type.Dialog_Drawing
                                        Child_Node.ImageIndex = 12
                                    Case Class_Symbols.enum_Symbol_Type.Dialog_Box
                                        Child_Node.ImageIndex = 13
                                    Case Class_Symbols.enum_Symbol_Type.TinyG_Setting
                                        Child_Node.ImageIndex = 14
                                End Select
                                Child_Node.SelectedImageIndex = Child_Node.ImageIndex
                            Else
                                Child_Node.ImageIndex = 0
                            End If

                        Else
                            Parent_Node = Target_Node
                        End If
                    End If

                Next K

            Next 'Symbol
Skip:

            Level += 1
            If Not Node_Added Then Exit While

        End While

        For I = 0 To Symbol.Symbol_Table.Count - 1
            Sym = Symbol.Symbol_Table(I)
            If Not IsNothing(Sym.Tree_Node) Then
                If Not IsNothing(Sym.Tree_Node.Tag) Then
                    Sym.Tree_Node.Text = Sym.Name & " = " & CStr(Sym.Value)
                    If Sym.Comment <> "" Then Sym.Tree_Node.Text &= " '" & Sym.Comment
                End If
            End If
        Next

        Tree_View.ImageList = Image_List
        Tree_View.EndUpdate()
        Tree_View.ResumeLayout()
        Tree_View.Refresh()
        Tree_View.Focus()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Function Find_Node(Tree_View As TreeView, Key As String) As TreeNode

        If Tree_View.Nodes.Count = 0 Then Return Nothing

        For N = 0 To Tree_View.Nodes.Count - 1
            If Tree_View.Nodes(N).Name = Key Then
                Return Tree_View.Nodes(N)
            End If
        Next

        Dim Node As TreeNode
        For N = 0 To Tree_View.Nodes.Count - 1
            Node = Find_Child(Tree_View, Tree_View.Nodes(N), Key)
            If Not IsNothing(Node) Then Return Node
        Next

        Return Nothing

    End Function

    Private Function Find_Child(Tree_View As TreeView, Target_Node As TreeNode, Key As String) As TreeNode

        If Target_Node.Name = Key Then
            Return Target_Node
        End If

        For I = 0 To Target_Node.Nodes.Count - 1
            If Target_Node.Nodes(I).Name = Key Then
                Return Target_Node.Nodes(I)
            Else
                If Target_Node.Nodes(I).Nodes.Count > 0 Then
                    Dim Node As TreeNode = Find_Child(Tree_View, Target_Node.Nodes(I), Key)
                    If Not IsNothing(Node) Then
                        Return Node
                    End If
                End If
            End If
        Next

        Return Nothing

    End Function

    Public Sub Set_Row_Value(Sym As Class_Symbols.class_Symbol)
        Dim I As ListViewItem
        I = list_Symbols.Items(Sym.Symbol_Table_Row)
        I.SubItems(1).Text = Sym.Value
    End Sub

End Class

