Public Class Form1
    Public startX As Integer = 48
    Public startY As Integer = 47
    Dim MouseDownLocation As Point
    Dim newController As Label
    Dim counter As Integer = 1
    Dim cCounter As Integer = 1
    Dim canAddedGlass As Boolean = True
    Dim isGlassAdded As Boolean = False
    Dim isConAdded As Boolean = False

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
                cName = "lblG" & counter
                cWidth = 20
                cColor = Color.DodgerBlue
            ElseIf type = 1 Then
                cName = "lblSO" & counter
                If isConAdded = True Then
                    startX += 70
                Else
                    startX += 40
                End If
                cWidth = 10
                cColor = Color.DarkTurquoise
            ElseIf type = 3 Then
                cName = "lblSI" & counter
                cWidth = 10
                cColor = Color.LightCoral
                startX += 10
            ElseIf type = 4 Then
                cName = "lblC" & cCounter
                cWidth = 40
                cColor = Color.Red
                startX += 40
            End If
            newController = New Label
            newController.Name = cName
            newController.Text = ""
            newController.AutoSize = False
            newController.Height = cHeight
            newController.Width = cWidth
            newController.BackColor = cColor
            newController.Location = New Point(startX + 10.5, 47)
            newController.FlatStyle = FlatStyle.Flat
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
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblG1_MouseMove(sender As Object, e As MouseEventArgs) Handles lblG1.MouseMove
        Try
            newController = New Label
            newController = DirectCast(sender, Label)
            If (e.Button = System.Windows.Forms.MouseButtons.Left) Then
                newController.Left = e.X + newController.Left - MouseDownLocation.X
                newController.Top = e.Y + newController.Top - MouseDownLocation.Y
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblG1_MouseLeave(sender As Object, e As EventArgs) Handles lblG1.MouseLeave
        Try
            newController = New Label
            newController = DirectCast(sender, Label)
            newController.Location = New Point(newController.Location.X, 47)
            newController.BorderStyle = BorderStyle.None
        Catch ex As Exception

        End Try
    End Sub

    Sub MyFunc2(sender As Object, e As EventArgs)
        Try
            newController = New Label
            newController = DirectCast(sender, Label)
            Dim Item As String
            Dim ItemNumber As String
            Item = newController.Name
            If Item.Contains("G") Then

            End If
            MessageBox.Show("This is " & newController.Name)
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
            newController = New Label
            newController = DirectCast(sender, Label)
            newController.BorderStyle = BorderStyle.FixedSingle
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If isGlassAdded = True Then
                CreateLables(4, cCounter)
                cCounter += 1
                canAddedGlass = True
                isConAdded = True
            Else
                MessageBox.Show("Add glass first")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
