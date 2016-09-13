
Public Class Class_Tree

    Private Data_File As New Class_Data_File

    Public Sub Load_Tree(ByRef Tree As TreeView, File_Name As String)
        Dim Line As String = ""
        Dim Node = New TreeNode
        Dim Path As String = ""
        Dim Text As String = ""
        Dim S() As String = Nothing
        Dim L() As String
        Dim Tag As String = ""

        Tree.SuspendLayout()
        Tree.Nodes.Clear()
        Tree.PathSeparator = "\"

        Data_File.Open_Input_File(File_Name)

        While Not Data_File.End_Of_File
            Data_File.Read_Line(Line)

            L = Line.Split("|")
            Tag = ""
            For I = 1 To L.Count - 1
                If L(I) <> "" Then
                    Tag &= L(I) & "|"
                End If

                '    Tag &= L(I) & vbCrLf
            Next

            S = L(0).Split("\")
            Path = ""
            For I = 0 To S.Count - 2
                If I > 0 Then Path = Path & "\"
                Path &= S(I)
            Next

            If Path = "" Then
                Node = New TreeNode
                Node.Name = L(0)
                Node.Text = L(0)
                Node.Tag = Tag
                Tree.Nodes.Add(Node)
            Else
                For N = 0 To Tree.Nodes.Count - 1
                    Node = Find_Node(Tree.Nodes(N), Path)

                    If Not IsNothing(Node) Then
                        Dim Child_Node = New TreeNode
                        Child_Node.Name = L(0)
                        Child_Node.Text = S(S.Count - 1)
                        Child_Node.Tag = Tag
                        Node.Nodes.Add(Child_Node)
                        Exit For
                    End If
                Next
            End If

        End While

        Data_File.Close_Input_File()
        Tree.ResumeLayout()

    End Sub

    Private Function Find_Node(Target_Node As TreeNode, Path As String) As TreeNode
        If Target_Node.FullPath = Path Then
            Return Target_Node
        End If

        For I = 0 To Target_Node.Nodes.Count - 1
            If Target_Node.Nodes(I).FullPath = Path Then
                Return Target_Node.Nodes(I)
            Else
                If Target_Node.Nodes(I).Nodes.Count > 0 Then
                    Dim Node As TreeNode = Find_Node(Target_Node.Nodes(I), Path)
                    If Not IsNothing(Node) Then
                        Return Node
                    End If
                End If
            End If
        Next

        Return Nothing

    End Function

    Public Sub Save_Tree(ByRef Tree As TreeView, ByVal File_Name As String)
        Data_File.Open_Output_File(File_Name)

        For N = 0 To Tree.Nodes.Count - 1
            Data_File.Write_Line(Tree.Nodes(N).Text)

            For I = 0 To Tree.Nodes(N).Nodes.Count - 1
                Data_File.Write_Line(Tree.Nodes(N).Nodes(I).FullPath)
                Save_Node(Tree.Nodes(N).Nodes(I))
            Next
        Next

        Data_File.Close_Output_File()

    End Sub

    Private Sub Save_Node(Node As TreeNode)
        Dim Tag As String = ""

        For I = 0 To Node.Nodes.Count - 1
            Tag = Trim(Node.Nodes(I).Tag)
            If Tag <> "" Then
                Tag = Tag.Replace(vbCrLf, "|")
                If Mid(Tag, 1, Tag.Length - 1) = "|" Then
                    Tag = Mid(Tag, 1, Tag.Length - 1)
                End If
            End If
            Data_File.Write_Line(Node.Nodes(I).FullPath & "|" & Tag)
            If Node.Nodes(I).Nodes.Count > 0 Then
                Save_Node(Node.Nodes(I))
            End If
        Next
    End Sub

End Class
