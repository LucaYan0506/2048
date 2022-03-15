Public Class Form1
    Dim time As Double
    Dim check As Boolean = False
    Dim b(16) As PictureBox
    Dim txt_B(16) As Label
    Dim Empty（16） As Boolean
    'keydown 
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If check = False Then
            Select Case e.KeyCode
                Case Keys.Right, Keys.D
                    check = True
                    time = 0
                    Right_M.Start()
                Case Keys.Left, Keys.A
                    check = True
                    time = 0
                    Left_M.Start()
                Case Keys.Down, Keys.S
                    check = True
                    time = 0
                    Down_M.Start()
                Case Keys.Up, Keys.W
                    check = True
                    time = 0
                    Up_M.Start()
            End Select
        End If
    End Sub





    '//////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////
    '//////////////////////////////////////////////////////////////////////////////////////////////////////
    'movement (right,left,up,down)
    Private Sub Right_Tick(sender As Object, e As EventArgs) Handles Right_M.Tick
        time += 21

        'move each block 
        For i = 1 To 10
            'don't move if the block doesn't exists
            If Empty(i) = True Then
                Continue For
            End If

            'don't move if the block.location equals to the limit of the grid
            If b(i).Left = 390 Then
                Continue For
            End If

            b(i).Left += 21
        Next

        'check if blocks need to be add together 
        If time = 126 Then
            check = False
            sender.stop
        End If
    End Sub
    Private Sub Left_Tick(sender As Object, e As EventArgs) Handles Left_M.Tick
        time += 21

        'move each block 
        For i = 1 To 10
            'don't move if the block doesn't exists
            If Empty(i) = True Then
                Continue For
            End If

            'don't move if the block.location equals to the limit of the grid
            If b(i).Left = 12 Then
                Continue For
            End If

            'move
            b(i).Left -= 21
        Next

        'check if blocks need to be add together 
        If time = 126 Then
            check = False
            sender.stop
        End If
    End Sub
    Private Sub Down_Tick(sender As Object, e As EventArgs) Handles Down_M.Tick
        time += 21

        'move each block 
        For i = 1 To 10
            'don't move if the block doesn't exists
            If Empty(i) = True Then
                Continue For
            End If

            'don't move if the block.location equals to the limit of the grid
            If b(i).Top = 388 Then
                Continue For
            End If

            'move
            b(i).Top += 21.05
        Next

        'check if blocks need to be add together 
        If time = 126 Then
            check = False
            sender.stop
            MsgBox(b(1).Top)
        End If
    End Sub
    Private Sub Up_Tick(sender As Object, e As EventArgs) Handles Up_M.Tick
        time += 21

        'move each block 
        For i = 1 To 10
            'don't move if the block doesn't exists
            If Empty(i) = True Then
                Continue For
            End If

            'don't move if the block.location equals to the limit of the grid
            If b(i).Top = 10 Then
                Continue For
            End If

            'move
            b(i).Top -= 21.05
        Next

        'check if blocks need to be add together 
        If time = 126 Then
            check = False
            sender.stop
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 16
            Empty(i) = True
        Next
        Empty(1) = False
        b(1) = PictureBox1
        Empty(2) = False
        b(2) = PictureBox2
    End Sub


End Class
