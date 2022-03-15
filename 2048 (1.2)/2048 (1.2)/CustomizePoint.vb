Public Class CustomizePoint
    Public p As Point
    Public name As String = "Empty"
    Public blocks As BLock


    Public Sub NewPos(ByVal x As Integer, ByVal y As Integer)
        p = New Point(x, y)
    End Sub
End Class
