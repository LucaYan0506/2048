Public Class BLock
    Public pic As PictureBox
    Public Empty As Boolean = True
    Public DontMove = False
    Public Value As Integer
    Public AlreadyMerged As Boolean

    Public Sub Reallocate_location(ByVal pos(,) As CustomizePoint, ByRef result(,) As CustomizePoint)

        'clear the current block's location 
        For x = 1 To 4
            For y = 1 To 4
                If pic.Name = pos(x, y).name Then
                    result(x, y).blocks = New BLock
                    result(x, y).name = "Empty"
                    result(x, y).blocks.Empty = True
                End If
            Next
        Next

        'check and add the new location  
        For x = 1 To 4
            For y = 1 To 4
                result(x, y).p = pos(x, y).p
                If pic.Location = pos(x, y).p Then
                    result(x, y).name = pic.Name
                    result(x, y).blocks = Me
                End If
            Next
        Next

    End Sub

    Public Sub GenerateNewBlock(ByVal position As Point, ByVal index As Integer, Optional ByVal givenValue As Integer = -1)
        'tell the computer that this block isn't empty anymore
        Empty = False
        'create a new picturebox
        pic = New PictureBox

        'set random values that block can have
        Dim values() As Integer = {2, 2, 2, 2, 2, 2, 2, 4, 4, 4}

        If givenValue = -1 Then
            'give it value 
            Randomize()
            Value = values(9 * Rnd())
        Else
            Value = givenValue
        End If

        'give it basic properties   
        With pic
                .Name = "Block" & index
                .Location = position
                .Size = New Size(118, 118)
            End With
            UpdateBackGround()

            'add it in form1
            Form1.Controls.Add(pic)
            pic.BringToFront()
    End Sub

    Public Sub UpdateBackGround()
        If Value = 2 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._2
            pic.BackColor = Color.FromArgb(255, 198, 198)
        ElseIf Value = 4 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._4
            pic.BackColor = Color.FromArgb(255, 150, 150)
        ElseIf Value = 8 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._8
            pic.BackColor = Color.FromArgb(255, 89, 89)
        ElseIf Value = 16 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._16
            pic.BackColor = Color.Red
        ElseIf Value = 32 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._32
            pic.BackColor = Color.FromArgb(255, 180, 125)
        ElseIf Value = 64 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._64
            pic.BackColor = Color.FromArgb(255, 139, 53)
        ElseIf Value = 128 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._128
            pic.BackColor = Color.FromArgb(255, 250, 187)
        ElseIf Value = 256 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._256
            pic.BackColor = Color.FromArgb(243, 238, 20)
        ElseIf Value = 512 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._512
            pic.BackColor = Color.FromArgb(212, 255, 186)
        ElseIf Value = 1024 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._1024
            pic.BackColor = Color.FromArgb(132, 244, 19)
        ElseIf Value = 2048 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._2048
            pic.BackColor = Color.FromArgb(11, 163, 8)
        ElseIf Value = 4096 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._4096
            pic.BackColor = Color.FromArgb(8, 163, 135)
        ElseIf Value = 8192 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._8192
            pic.BackColor = Color.FromArgb(8, 132, 163)
        ElseIf Value = 16384 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._16384
            pic.BackColor = Color.FromArgb(8, 75, 163)
        ElseIf Value = 32768 Then 'white
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._32768
            pic.BackColor = Color.FromArgb(8, 24, 163)
        ElseIf Value = 65536 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._65536
            pic.BackColor = Color.FromArgb(4, 12, 79)
        ElseIf Value = 131072 Then
            pic.BackgroundImage = Global._2048__1._2_.My.Resources._131072
            pic.BackColor = Color.FromArgb(0, 0, 0)
        End If

        pic.BackgroundImageLayout = ImageLayout.Zoom

    End Sub


End Class
