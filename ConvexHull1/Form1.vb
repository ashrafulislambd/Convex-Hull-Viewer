Public Class Form1
    Dim Points As New List(Of Point)
    Dim ConvexHull As New List(Of Point)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Sub DrawPoints(ByVal g As Graphics)
        For Each p As Point In Points
            If ConvexHull.Contains(p) Then
                g.FillEllipse(Brushes.Blue, p.X - 5, p.Y - 5, 10, 10)
            Else
                g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10, 10)
            End If
        Next
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Points.Add(New Point(e.X, e.Y))
        CalculateConvexHull()
        Me.Refresh()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        DrawPoints(e.Graphics)
        DrawConvexHullLine(e.Graphics)
    End Sub

    Private Sub CalculateConvexHull()
        If Points.Count < 3 Then Exit Sub
        Dim SortedPoints = From p In Points
                     Order By p.X, p.Y
                     Select p

        Dim UpperHull, LowerHull As New List(Of Point)
        UpperHull.Add(SortedPoints(0))
        UpperHull.Add(SortedPoints(1))
        For I As Integer = 2 To SortedPoints.Count - 1
            UpperHull.Add(SortedPoints(I))

            Dim k As Integer = UpperHull.Count - 1
            While UpperHull.Count >= 3
                If Not TurnsRight(UpperHull(k - 2), UpperHull(k - 1), UpperHull(k)) Then
                    UpperHull.Remove(UpperHull(k - 1))
                    k = UpperHull.Count - 1
                Else
                    Exit While
                End If
            End While
        Next

        Dim ll = SortedPoints.Count - 1
        LowerHull.Add(SortedPoints(ll))
        LowerHull.Add(SortedPoints(ll - 1))
        For I As Integer = ll - 2 To 0 Step -1
            LowerHull.Add(SortedPoints(I))

            Dim k As Integer = LowerHull.Count - 1
            While LowerHull.Count >= 3
                If Not TurnsRight(LowerHull(k - 2), LowerHull(k - 1), LowerHull(k)) Then
                    LowerHull.Remove(LowerHull(k - 1))
                    k = LowerHull.Count - 1
                Else
                    Exit While
                End If
            End While
        Next

        LowerHull = LowerHull.GetRange(0, LowerHull.Count - 1)
        UpperHull = UpperHull.GetRange(0, UpperHull.Count - 1)
        LowerHull.AddRange(UpperHull)
        ConvexHull = LowerHull
    End Sub

    Private Sub btnConvexHull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvexHull.Click
        CalculateConvexHull()
        Refresh()
    End Sub

    Private Function TurnsRight(ByVal LeftPoint As Point, ByVal MiddlePoint As Point, ByVal RightPoint As Point) As Boolean
        Dim Slope1 As Double = (MiddlePoint.Y - LeftPoint.Y) / (MiddlePoint.X - LeftPoint.X)
        Dim Slope2 As Double = (RightPoint.Y - MiddlePoint.Y) / (RightPoint.X - MiddlePoint.X)

        TurnsRight = Slope1 < Slope2
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(TurnsRight(Points(0), Points(1), Points(2)))
    End Sub

    Private Sub DrawConvexHullLine(ByVal g As Graphics)
        If ConvexHull.Count >= 3 Then
            For I = 1 To ConvexHull.Count - 1
                g.DrawLine(Pens.Black, ConvexHull(I), ConvexHull(I - 1))
            Next
            g.DrawLine(Pens.Black, ConvexHull(0), ConvexHull(ConvexHull.Count - 1))
        End If
    End Sub

End Class
