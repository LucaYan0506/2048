Public Class Form1
    Dim blocks(16) As BLock
    Dim position(4, 4) As CustomizePoint


    'class Block
    Class BLock
        Public pic As PictureBox
        Public Empty As Boolean = True
        Public DontMove = False
        Private check As Boolean = True
        Private WithEvents Go_Right, Go_left As Timer
        Private sec As Integer

        'move blocks like a slowmotion animation
        Sub Go_RightTick(ByVal sender As Object, ByVal e As EventArgs) Handles Go_Right.Tick
            sec += 1
            pic.Left += 21
            If pic.Left >= 390 Then
                DontMove = True
            End If
            If sec = 6 Then
                sec = 0
                If DontMove = True Then
                    check = True
                    sender.stop()
                End If
            End If
        End Sub
        'move blocks like a slowmotion animation
        Sub Go_leftTick(ByVal sender As Object, ByVal e As EventArgs) Handles Go_left.Tick
            sec += 1
            pic.Left -= 21
            If sec = 6 Then
                check = True
                sender.stop()
            End If
        End Sub




        Public Sub GetPicture(ByVal n As PictureBox)
            pic = n
            Empty = False
        End Sub

        Public Sub Move_Right()
            'don't move if the block.location equals to the limit of the grid
            If pic.Left <> 390 Then
                If check = True Then
                    check = False
                    Go_Right = New Timer
                    Go_Right.Interval = 25
                    sec = 0
                    Go_Right.Start()
                    DontMove = False
                End If
            Else
                DontMove = True
            End If
        End Sub

        Public Sub Move_Left()

            'don't move if the block.location equals to the limit of the grid
            If pic.Left <> 12 Then
                If check = True Then
                    check = False
                    Go_left = New Timer
                    Go_left.Interval = 25
                    sec = 0
                    Go_left.Start()
                    DontMove = False
                End If
            Else
                DontMove = True
            End If

        End Sub

        Public Sub Move_Down(ByVal pos(,) As CustomizePoint)



            'don't move if the block.location equals to the limit of the grid
            If pic.Top <> 388 Then

                Dim x, y As Integer
                GetCurrentPosition(pos, x, y)
                y += 1
                'if there isn't anything ahead then move
                If pos(x, y).name = "Empty" Then
                    pic.Top += 21.05
                Else
                    DontMove = True
                End If

            Else
                DontMove = True
            End If
        End Sub

        Public Sub Move_Up()


            'don't move if the block.location equals to the limit of the grid
            If pic.Top <> 10 Then
                pic.Top -= 21.05
                DontMove = False
            Else
                DontMove = True
            End If
        End Sub



        Public Sub Reallocate_location(ByVal pos(,) As CustomizePoint, ByRef result(,) As CustomizePoint)



            For x = 1 To 4
                For y = 1 To 4
                    result(x, y).p = pos(x, y).p
                    result(x, y).name = "Empty"
                    If pic.Location = pos(x, y).p Then
                        result(x, y).name = pic.Name
                    End If
                Next
            Next

        End Sub

        Public Sub GetCurrentPosition(ByVal pos(,) As CustomizePoint, ByRef Axis_x As Integer, ByRef Axis_y As Integer)
            For x = 1 To 4
                For y = 1 To 4
                    If pos(x, y).p = pic.Location Then
                        Axis_x = x
                        Axis_y = y
                        Exit Sub
                    End If
                Next
            Next
        End Sub
    End Class

    'class customize  point
    Class CustomizePoint
        Public p As Point
        Public name As String = "Empty"
        Public Sub NewPos(ByVal x As Integer, ByVal y As Integer)
            p = New Point(x, y)
        End Sub

    End Class



    'key down
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown, Button1.KeyDown

        'move each block 
        For i = 1 To 16
                'don't move if the block doesn't exists
                If blocks(i).Empty = True Then
                    Continue For
                End If

                If blocks(i).DontMove = True Then
                    Continue For
                End If

            Select Case e.KeyCode
                Case Keys.Right, Keys.D
                    blocks(i).Move_Right()
                Case Keys.Left, Keys.A
                    blocks(i).Move_Left()
                Case Keys.Down, Keys.S
                    blocks(i).Move_Down(position)
                Case Keys.Up, Keys.W
                    blocks(i).Move_Up()
            End Select

            'reallocate all blocks location 
            blocks(i).Reallocate_location(position, position)
            Next

        


        For i = 1 To 16
            blocks(i).DontMove = False
        Next

    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initialize blocks
        For i = 1 To 16
            blocks(i) = New BLock
        Next

        'initialize Position
        For x = 1 To 4
            For y = 1 To 4
                position(x, y) = New CustomizePoint
            Next
        Next

        'give value
        '1st level
        position(1, 1).NewPos(12, 10)
        position(1, 2).NewPos(138, 10)
        position(1, 3).NewPos(264, 10)
        position(1, 4).NewPos(390, 10)
        '2nd level
        position(2, 1).NewPos(12, 136)
        position(2, 2).NewPos(138, 136)
        position(2, 3).NewPos(264, 136)
        position(2, 4).NewPos(390, 136)
        '3rd level
        position(3, 1).NewPos(12, 262)
        position(3, 2).NewPos(138, 262)
        position(3, 3).NewPos(264, 262)
        position(3, 4).NewPos(390, 262)
        '4th level
        position(4, 1).NewPos(12, 388)
        position(4, 2).NewPos(138, 388)
        position(4, 3).NewPos(264, 388)
        position(4, 4).NewPos(390, 388)



        'get first 2 pictures
        blocks(1).GetPicture(PictureBox1)
        blocks(2).GetPicture(PictureBox2)
        For i = 1 To 2
            blocks(i).Reallocate_location(position, position)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(position(1, 1).p.X)
    End Sub

 

End Class
