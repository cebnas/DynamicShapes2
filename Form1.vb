Public Class Form1
    Public startX As Integer = 48
    Public startY As Integer = 47
    Dim MouseDownLocation As Point
    Dim newController As Panel
    Dim counter As Integer = 1
    Dim cCounter As Integer = 1
    Dim canAddedGlass As Boolean = True
    Dim isGlassAdded As Boolean = False
    Dim isConAdded As Boolean = False
    Dim removedItem As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If canAddedGlass = True Then
                For o = 1 To 3
                    CreateLables(o, counter)
                Next
                counter += 1
                canAddedGlass = False
                isGlassAdded = True
            Else
                MessageBox.Show("Add consumable first")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Function CreateLables(ByRef type As Integer, counter As Integer)
        Try
            Dim cName As String = "lbl99"
            Dim cHeight As Integer = 300
            Dim cWidth As Integer = 1
            Dim cColor As Color = Color.Red
            If type = 2 Then
                cName = "lblG_" & counter
                cWidth = 40
                cColor = Color.DodgerBlue
            ElseIf type = 1 Then
                cName = "lblSO_" & counter
                If isConAdded = True Then
                    startX += 30
                Else
                    startX += 20
                End If
                cWidth = 10
                cColor = Color.DarkTurquoise
            ElseIf type = 3 Then
                cName = "lblSI_" & counter
                cWidth = 10
                cColor = Color.LightCoral
                startX += 30
            ElseIf type = 4 Then
                cName = "lblC_" & counter
                cWidth = 20
                cColor = Color.Red
                startX += 20
            End If
            newController = New Panel
            newController.Name = cName
            newController.Text = ""
            newController.AutoSize = False
            newController.Height = cHeight
            newController.Width = cWidth
            newController.BackColor = cColor
            newController.Location = New Point(startX + 10.5, 47)
            'newController.FlatStyle = FlatStyle.Flat
            AddHandler newController.MouseClick, AddressOf LblG1_MouseDown
            AddHandler newController.MouseMove, AddressOf LblG1_MouseMove
            AddHandler newController.MouseLeave, AddressOf LblG1_MouseLeave
            AddHandler newController.Click, AddressOf MyFunc2
            AddHandler newController.MouseEnter, AddressOf showItem
            newController.BringToFront()
            Panel1.Controls.Add(newController)
            startX = newController.Left
        Catch ex As Exception

        End Try
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            startX = lblIS1.Left
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblG1_MouseDown(sender As Object, e As MouseEventArgs) Handles lblG1.MouseDown
        Try
            If e.Button = System.Windows.Forms.MouseButtons.Left Then
                MouseDownLocation = e.Location
                newController = New Panel
                newController = DirectCast(sender, Panel)
                TextBox1.Text = newController.Name
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblG1_MouseMove(sender As Object, e As MouseEventArgs) Handles lblG1.MouseMove
        Try
            newController = New Panel
            newController = DirectCast(sender, Panel)
            If (e.Button = System.Windows.Forms.MouseButtons.Left) Then
                newController.Left = e.X + newController.Left - MouseDownLocation.X
                newController.Top = e.Y + newController.Top - MouseDownLocation.Y
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblG1_MouseLeave(sender As Object, e As EventArgs) Handles lblG1.MouseLeave
        Try
            newController = New Panel
            newController = DirectCast(sender, Panel)
            newController.Location = New Point(newController.Location.X, 47)
            newController.BorderStyle = BorderStyle.None
        Catch ex As Exception

        End Try
    End Sub

    Sub MyFunc2(sender As Object, e As EventArgs)
        Try
            newController = New Panel
            newController = DirectCast(sender, Panel)
            Dim Item As String
            Dim ItemArray() As String
            Dim ItemNumber As String
            ItemArray = newController.Name.Split("_")
            ItemNumber = ItemArray(ItemArray.Length - 1)
            If newController.Name.Contains("G") Then
                Item = "Glass"
            ElseIf newController.Name.Contains("SO") Then
                Item = "Outer service"
            ElseIf newController.Name.Contains("SI") Then
                Item = "Inner service"
            ElseIf newController.Name.Contains("C") Then
                Item = "Consumable"
            End If
            'MessageBox.Show("This is " & Item & " no:" & ItemNumber & newController.Name)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Controls.Clear()
        canAddedGlass = True
        startX = 48
        counter = 1
        cCounter = 1
        isGlassAdded = False
        isConAdded = False
    End Sub

    Private Sub showItem(sender As Object, e As EventArgs)
        Try
            newController = New Panel
            newController = DirectCast(sender, Panel)
            newController.BorderStyle = BorderStyle.FixedSingle
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If isGlassAdded = True Then
                CreateLables(4, counter)
                counter += 1
                canAddedGlass = True
                isConAdded = True
            Else
                MessageBox.Show("Add glass first")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            'newController.Dispose()
            'newController = New Panel
            'newController.Name = TextBox1.Text
            Dim ITEMSlIST As String
            Dim removeExtra As Integer
            Dim preControler As New Control
            Dim preActiveControler As New Control
            Dim moveItem As Boolean = False
            Dim moveItemNew As Boolean = False
            Dim isAGlass As Boolean = False
            Dim deleteArray() As String
            Dim ItemList As String = TextBox1.Text
            Dim itemArray() As String
            Dim newCounter As Integer
            If TextBox1.Text.Contains("G") Or TextBox1.Text.Contains("SO") Or TextBox1.Text.Contains("SI") Then
                isAGlass = True
                itemArray = TextBox1.Text.Split("_")
                newCounter = itemArray(itemArray.Length - 1)
                ItemList = "lblG_" & newCounter & ";" & "lblSI_" & newCounter & ";" & "lblSO_" & newCounter
            End If
            deleteArray = ItemList.Split(";")
StartPosition:
            For Each subController As Control In Panel1.Controls
                If deleteArray.Contains(subController.Name) Then
                    RemoveHandler subController.MouseClick, AddressOf LblG1_MouseDown
                    'RemoveHandler subController.MouseMove, AddressOf LblG1_MouseMove
                    RemoveHandler subController.MouseLeave, AddressOf LblG1_MouseLeave
                    RemoveHandler subController.Click, AddressOf MyFunc2
                    RemoveHandler subController.MouseEnter, AddressOf showItem
                    removeExtra = subController.Location.X
                    removedItem = subController.Name
                    preActiveControler = preControler
                    Panel1.Controls.Remove(subController)
                    GoTo StartPosition
                End If

                If moveItemNew = True Then
                    removeExtra = preControler.Location.X + preControler.Width
                    If removedItem.Contains("G") Then
                        removeExtra = 60
                        'ElseIf Then
                        '    removeExtra += "Outer service"
                        'ElseIf removedItem.Contains("SI") Then
                        '    removeExtra += "Inner service"
                    ElseIf removedItem.Contains("C") Then
                        removeExtra = 20
                    End If
                    moveItemNew = False
                    moveItem = True
                End If

                If moveItem = True Then
                    subController.Left = subController.Location.X - removeExtra
                End If
                If preActiveControler.Name = subController.Name Then
                    'moveItem = True
                    moveItemNew = True
                End If
                preControler = subController

            Next

        Catch ex As Exception

        End Try
    End Sub

End Class
