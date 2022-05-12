
Public Class Form1
    Dim position(4, 4) As CustomizePoint
    Dim b(16) As BLock
    Dim sec As Integer = 0
    Dim Move_finished As Boolean = True
    Public BlockToMove, BLockToAchive As BLock
    Public GapX, GapY As Double
    Dim previousLocation(16) As Point


    'key down
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Move_finished = True Then

            'get the location of all blocks before moving 
            For i = 1 To 16
                If b(i).Empty = False Then
                    previousLocation(i) = b(i).pic.Location
                End If
            Next




            Dim CorrectKey As Boolean = False

            'check if the user click the correct key 
            Select Case e.KeyCode
                Case Keys.W, Keys.Up

                    'start timer
                    sec = 6
                    Up_M.Start()
                    CorrectKey = True

                Case Keys.S, Keys.Down

                    'start timer
                    sec = 6
                    Down_M.Start()
                    CorrectKey = True

                Case Keys.A, Keys.Left

                    'start timer
                    sec = 6
                    Left_M.Start()
                    CorrectKey = True

                Case Keys.D, Keys.Right

                    'start timer
                    sec = 6
                    Right_M.Start()
                    CorrectKey = True

            End Select

            'check if the key clicked is WASD or UP,DOWN,LEFT,RIGHT
            If CorrectKey = True Then


                'Reallocate_location blocks and reset dontmove function 
                For i = 1 To 16

                    If b(i).Empty = False Then
                        b(i).DontMove = False
                        b(i).AlreadyMerged = False
                        b(i).Reallocate_location(position, position)
                    End If

                Next

                Move_finished = False
            End If
        End If
    End Sub


    'form load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initialize Position
        For x = 1 To 4
            For y = 1 To 4
                position(x, y) = New CustomizePoint
            Next
        Next

        'give value
        '1st level
        position(1, 1).NewPos(12, 38)
        position(1, 2).NewPos(138, 38)
        position(1, 3).NewPos(264, 38)
        position(1, 4).NewPos(390, 38)
        '2nd level
        position(2, 1).NewPos(12, 164)
        position(2, 2).NewPos(138, 164)
        position(2, 3).NewPos(264, 164)
        position(2, 4).NewPos(390, 164)
        '3rd level
        position(3, 1).NewPos(12, 290)
        position(3, 2).NewPos(138, 290)
        position(3, 3).NewPos(264, 290)
        position(3, 4).NewPos(390, 290)
        '4th level
        position(4, 1).NewPos(12, 416)
        position(4, 2).NewPos(138, 416)
        position(4, 3).NewPos(264, 416)
        position(4, 4).NewPos(390, 416)

        'initialize blocks
        For i = 1 To 16
            b(i) = New BLock
        Next

        'initialize position.blocks
        For x = 1 To 4
            For y = 1 To 4
                position(x, y).blocks = New BLock
                position(x, y).blocks.Empty = True
            Next
        Next

        'generate first 2 blocks
        Dim x2, y2 As Integer
        'generate new block
        For i = 1 To 16
            If b(i).Empty = True Then
                Random_Empty_XY_in_Position(position, x2, y2)
                b(i).GenerateNewBlock(position(x2, y2).p, i)
                b(i).Reallocate_location(position, position)
                Exit For
            End If
        Next
        'generate new block
        For i = 1 To 16
            If b(i).Empty = True Then
                Random_Empty_XY_in_Position(position, x2, y2)
                b(i).GenerateNewBlock(position(x2, y2).p, i)
                b(i).Reallocate_location(position, position)
                Exit For
            End If
        Next
    End Sub

    Private Sub Go_to_the_blocks_Tick(sender As Object, e As EventArgs) Handles Go_to_the_blocks.Tick

        If BlockToMove.pic.Location.X <> BLockToAchive.pic.Location.X Then
            BlockToMove.pic.Location = New Point(BlockToMove.pic.Location.X + GapX, BlockToMove.pic.Location.Y)
        End If

        If BlockToMove.pic.Location.Y <> BLockToAchive.pic.Location.Y Then
            BlockToMove.pic.Location = New Point(BlockToMove.pic.Location.X, BlockToMove.pic.Location.Y + GapY)
        End If

        If BlockToMove.pic.Location.Y = BLockToAchive.pic.Location.Y And BlockToMove.pic.Location.X = BLockToAchive.pic.Location.X Then

            sender.stop
        End If
    End Sub

    'second/last check if the user lost the game
    Function LastCheckIfLost(ByVal pos(,) As CustomizePoint, Optional ByVal x As Integer = 1, Optional ByVal y As Integer = 1) As Boolean

        'check the right side
        If y + 1 < 5 Then
            If pos(x, y).blocks.Value = pos(x, y + 1).blocks.Value Then
                Return False
            Else
                If LastCheckIfLost(pos, x, y + 1) = False Then
                    Return False
                End If
            End If
        End If

        'check the bot  side
        If x + 1 < 5 Then
            If pos(x + 1, y).blocks.Value = pos(x, y).blocks.Value Then
                Return False
            Else
                If LastCheckIfLost(pos, x + 1, y) = False Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub DeleteAllBLocks(ByVal blocks() As BLock)
        For i = 1 To blocks.Length - 1
            If blocks(i).Empty = False Then
                Me.Controls.Remove(blocks(i).pic)
                blocks(i).Empty = True
            End If
        Next
    End Sub

    'function to stop a block is beside there is another block
    Private Sub Check_if_there_is_a_block_beside_if_so_stop_it(ByVal direction As String, ByVal pos(,) As CustomizePoint, ByVal x As Integer, ByVal y As Integer)
        Dim currentP As CustomizePoint = pos(x, y)
        Select Case direction
            Case "Right"
                'since x and y are the current position of the block we minus by 1 Y, so we get the position of the left side of the current block
                y -= 1
            Case "Left"
                'same as the right direction, but instead to check on the left of the block in this case we have to check the right side
                y += 1
            Case "Down"
                'same as the right direction, but instead to check on the left of the block in this case we have to check the top side
                x -= 1
            Case "Up"
                'same as the right direction, but instead to check on the left of the block in this case we have to check the bot side
                x += 1
        End Select

        If x = 5 Or x = 0 Or y = 5 Or y = 0 Then
            Exit Sub
        End If

        'if there is a block beside stop it
        If pos(x, y).blocks.Empty = False Then

            'if they have the same value and check if the block is already merged 
            If currentP.blocks.Value = pos(x, y).blocks.Value And currentP.blocks.AlreadyMerged = False And pos(x, y).blocks.AlreadyMerged = False Then

                currentP.blocks.AlreadyMerged = True
                'add them together 
                currentP.blocks.Value += pos(x, y).blocks.Value

                'add animation of 2 blocks that are merging 
                BlockToMove = pos(x, y).blocks
                BLockToAchive = currentP.blocks
                ' GapX = (BLockToAchive.pic.Location.X - BlockToMove.pic.Location.X) / 4
                ' GapY = (BLockToAchive.pic.Location.Y - BlockToMove.pic.Location.Y) / 4
                '  Go_to_the_blocks.Start()



                'udate background
                currentP.blocks.UpdateBackGround()

                'delete it 
                Me.Controls.Remove(BlockToMove.pic)


                pos(x, y).blocks.Empty = True


            Else
                'if they DONT habe the same value 
                pos(x, y).blocks.DontMove = True

                'because we discover that there is a block beside, we have to check again if on the beside on the block found there is another one
                Check_if_there_is_a_block_beside_if_so_stop_it(direction, pos, x, y)
            End If
        End If
    End Sub

    'move blocks (up,down,left,right)
    Private Sub Up_M_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Up_M.Tick
        'do a check after 6 "sec" (sec is the variable not second) (6 because a complete move of block is done when sec = 6) 
        If sec = 6 Then

            For x = 1 To 4
                For y = 1 To 4

                    'skip position with empty blocks
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'Reallcate block's location
                    position(x, y).blocks.Reallocate_location(position, position)
                Next
            Next


            sec = 0
            For x = 1 To 4
                For y = 1 To 4

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'check each block if it's arrived to the limit of the grid (left)
                    If x = 1 Then
                        position(x, y).blocks.DontMove = True

                        'check if there is a block behind (on the bot)
                        Check_if_there_is_a_block_beside_if_so_stop_it("Up", position, x, y)

                    End If

                Next
            Next

            Dim check As Boolean = True

            'check if all blocks dont need to be move
            For x = 1 To 4
                For y = 1 To 4

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    If position(x, y).blocks.DontMove = False Then
                        check = False
                        Exit For
                    End If

                Next
            Next

            If check = True Then
                Move_finished = True
                sender.Stop()

                Dim x, y As Integer
                'generate new block
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Random_Empty_XY_in_Position(position, x, y)
                        b(i).GenerateNewBlock(position(x, y).p, i)
                        b(i).Reallocate_location(position, position)
                        Exit For
                    End If
                Next

                'check if the user lose 
                Dim Lose As Boolean = True

                'first check
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Lose = False
                        Exit For
                    End If
                Next

                'if lost is still lose it is a potential lost,so do the last check
                If Lose = True Then

                    If LastCheckIfLost(position) = True Then
                        'after the check and the user lost disable all blocks + msgbox
                        MsgBox("You lose")
                    End If
                End If


                Exit Sub
            End If


        End If


        sec += 1
        For x = 1 To 4
            For y = 1 To 4

                'skip blocks that dont exist
                If position(x, y).blocks.Empty = True Then
                    Continue For
                End If

                'skip if dontmove = true 
                If position(x, y).blocks.DontMove = False Then
                    'move forward left
                    position(x, y).blocks.pic.Top -= 21.05
                End If

            Next
        Next
    End Sub
    Private Sub Down_M_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Down_M.Tick
        'do a check after 6 "sec" (sec is the variable not second) (6 because a complete move of block is done when sec = 6) 
        If sec = 6 Then

            For x = 4 To 1 Step -1
                For y = 1 To 4

                    'skip position with empty blocks
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'Reallcate block's location
                    position(x, y).blocks.Reallocate_location(position, position)
                Next
            Next


            sec = 0
            For x = 4 To 1 Step -1
                For y = 1 To 4

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'check each block if it's arrived to the limit of the grid (down)
                    If x = 4 Then
                        position(x, y).blocks.DontMove = True

                        'check if there is a block behind
                        Check_if_there_is_a_block_beside_if_so_stop_it("Down", position, x, y)

                    End If

                Next
            Next

            Dim check As Boolean = True

            'check if all blocks dont need to be move
            For x = 4 To 1 Step -1
                For y = 1 To 4

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    If position(x, y).blocks.DontMove = False Then
                        check = False
                        Exit For
                    End If

                Next
            Next

            If check = True Then
                Move_finished = True
                sender.Stop()

                Dim x, y As Integer
                'generate new block
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Random_Empty_XY_in_Position(position, x, y)
                        b(i).GenerateNewBlock(position(x, y).p, i)
                        b(i).Reallocate_location(position, position)
                        Exit For
                    End If
                Next

                'check if the user lose 
                Dim Lose As Boolean = True

                'first check
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Lose = False
                        Exit For
                    End If
                Next

                'if lost is still lose it is a potential lost,so do the last check
                If Lose = True Then
                    If LastCheckIfLost(position) = True Then
                        'after the check and the user lost disable all blocks + msgbox
                        MsgBox("You lose")
                    End If
                End If


                Exit Sub
            End If


        End If


        sec += 1
        For x = 4 To 1 Step -1
            For y = 1 To 4

                'skip blocks that dont exist
                If position(x, y).blocks.Empty = True Then
                    Continue For
                End If

                'skip if dontmove = true 
                If position(x, y).blocks.DontMove = False Then
                    'move forward left
                    position(x, y).blocks.pic.Top += 21.05
                End If

            Next
        Next

    End Sub
    Private Sub Left_M_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Left_M.Tick
        'do a check after 6 "sec" (sec is the variable not second) (6 because a complete move of block is done when sec = 6) 
        If sec = 6 Then

            For y = 1 To 4
                For x = 1 To 4

                    'skip position with empty blocks
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'Reallcate block's location
                    position(x, y).blocks.Reallocate_location(position, position)
                Next
            Next


            sec = 0
            For y = 1 To 4
                For x = 1 To 4

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'check each block if it's arrived to the limit of the grid (left)
                    If y = 1 Then
                        position(x, y).blocks.DontMove = True

                        'check if there is a block behind
                        Check_if_there_is_a_block_beside_if_so_stop_it("Left", position, x, y)

                    End If

                Next
            Next

            Dim check As Boolean = True

            'check if all blocks dont need to be move
            For y = 1 To 4
                For x = 1 To 4

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    If position(x, y).blocks.DontMove = False Then
                        check = False
                        Exit For
                    End If

                Next
            Next

            If check = True Then
                Move_finished = True
                sender.Stop()

                Dim x, y As Integer
                'generate new block
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Random_Empty_XY_in_Position(position, x, y)
                        b(i).GenerateNewBlock(position(x, y).p, i)
                        b(i).Reallocate_location(position, position)
                        Exit For
                    End If
                Next

                'check if the user lose 
                Dim Lose As Boolean = True

                'first check
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Lose = False
                        Exit For
                    End If
                Next

                'if lost is still lose it is a potential lost,so do the last check
                If Lose = True Then
                    If LastCheckIfLost(position) = True Then
                        'after the check and the user lost disable all blocks + msgbox
                        MsgBox("You lose")
                    End If
                End If

                Exit Sub
            End If


        End If


        sec += 1
        For y = 1 To 4
            For x = 1 To 4

                'skip blocks that dont exist
                If position(x, y).blocks.Empty = True Then
                    Continue For
                End If

                'skip if dontmove = true 
                If position(x, y).blocks.DontMove = False Then
                    'move forward left
                    position(x, y).blocks.pic.Left -= 21
                End If

            Next
        Next


    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        DeleteAllBLocks(b)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        DeleteAllBLocks(b)

        'generate first 2 blocks
        Dim x2, y2 As Integer
        'generate new block
        For i = 1 To 16
            If b(i).Empty = True Then
                Random_Empty_XY_in_Position(position, x2, y2)
                b(i).GenerateNewBlock(position(x2, y2).p, i)
                b(i).Reallocate_location(position, position)
                Exit For
            End If
        Next

        'generate new block
        For i = 1 To 16
            If b(i).Empty = True Then
                Random_Empty_XY_in_Position(position, x2, y2)
                b(i).GenerateNewBlock(position(x2, y2).p, i)
                b(i).Reallocate_location(position, position)
                Exit For
            End If
        Next
    End Sub

    Private Sub ExitToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem2.Click
        Me.Close()
    End Sub

    Private Sub Right_M_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Right_M.Tick
        'do a check after 6 "sec" (sec is the variable not second) (6 because a complete move of block is done when sec = 6) 
        If sec = 6 Then

            For y = 4 To 1 Step -1
                For x = 4 To 1 Step -1

                    'skip position with empty blocks
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'Reallcate block's location
                    position(x, y).blocks.Reallocate_location(position, position)
                Next
            Next

            Dim check As Boolean = True
            sec = 0
            For y = 4 To 1 Step -1
                For x = 4 To 1 Step -1

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    'check each block if it's arrived to the limit of the grid (right)
                    If y = 4 Then
                        position(x, y).blocks.DontMove = True


                        'check if there is a block behind, if so stop it 
                        Check_if_there_is_a_block_beside_if_so_stop_it("Right", position, x, y)

                    End If

                Next
            Next


            'check if all blocks dont need to be move
            For y = 4 To 1 Step -1
                For x = 4 To 1 Step -1

                    'skip blocks that dont exist
                    If position(x, y).blocks.Empty = True Then
                        Continue For
                    End If

                    If position(x, y).blocks.DontMove = False Then
                        check = False
                        Exit For
                    End If

                Next
            Next

            If check = True Then
                Move_finished = True
                sender.Stop()

                Dim x, y As Integer
                'generate new block
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Random_Empty_XY_in_Position(position, x, y)
                        b(i).GenerateNewBlock(position(x, y).p, i)
                        b(i).Reallocate_location(position, position)
                        Exit For
                    End If
                Next

                'check if the user lose 
                Dim Lose As Boolean = True

                'first check
                For i = 1 To 16
                    If b(i).Empty = True Then
                        Lose = False
                        Exit For
                    End If
                Next

                'if lost is still lose it is a potential lost,so do the last check
                If Lose = True Then
                    If LastCheckIfLost(position) = True Then
                        MsgBox("You lose")
                    End If
                End If

                Exit Sub
            End If


        End If


        sec += 1
        For y = 4 To 1 Step -1
            For x = 4 To 1 Step -1

                'skip blocks that dont exist
                If position(x, y).blocks.Empty = True Then
                    Continue For
                End If

                'skip if dontmove = true 
                If position(x, y).blocks.DontMove = False Then
                    'move forward left
                    position(x, y).blocks.pic.Left += 21
                End If

            Next
        Next



    End Sub

    'get random empty position
    Private Sub Random_Empty_XY_in_Position(ByVal pos(,) As CustomizePoint, ByRef x As Integer, ByRef y As Integer)
        Dim HighestNumber As Integer = pos.GetLength(0) - 1
        Dim LowestNumber As Integer = 1
        Randomize()
        x = (HighestNumber - LowestNumber) * Rnd() + LowestNumber
        Randomize()
        y = (HighestNumber - LowestNumber) * Rnd() + LowestNumber
        If pos(x, y).blocks.Empty = False Then
            Random_Empty_XY_in_Position(pos, x, y)
        End If
    End Sub




End Class