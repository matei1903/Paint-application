Public Class Form1

    Dim myBitmap As Bitmap
    Dim myGraphics As Graphics
    Dim myPen As Pen
    Dim x, y As Integer
    Dim x1, x2, y1, y2 As Integer

    Private Sub DrawLine()
        myGraphics.DrawLine(myPen, x1, y1, x2, y2)
        PictureBox1.Image = myBitmap
    End Sub

    Private Sub DrawRectangle()
        myGraphics.DrawRectangle(myPen, x1, y1, 100, 50)
        PictureBox1.Image = myBitmap
    End Sub

    Private Sub DrawElipse()
        myGraphics.DrawEllipse(myPen, x1, y1, 100, 50)
        PictureBox1.Image = myBitmap
    End Sub

    Private Sub DrawPixel()
        myGraphics.DrawLine(myPen, x1, y1, x1, y1)
        PictureBox1.Image = myBitmap
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        Dim open As New OpenFileDialog
        open.Filter = "JPG Files (*.jpg)|*.jpg|Bitmaps (*.bmp)|*.bmp|Gif (*.gif)|*.gif|AllFiles|*.*"
        open.FilterIndex = 1
        If open.ShowDialog = DialogResult.OK Then
            myBitmap = Image.FromFile(open.FileName)
            myGraphics = Graphics.FromImage(myBitmap)
            PictureBox1.Image = myBitmap
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Dim save As New SaveFileDialog
        save.InitialDirectory = "c:\"
        save.Filter = "JPG Files (*.jpg)|*.jpg|Bitmaps (*.bmp)|*.bmp|Gif (*.gif)|*.gif"
        save.FilterIndex = 1
        If save.ShowDialog = DialogResult.OK Then
            myBitmap.Save(save.FileName)
        End If


    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        Dim colordialog1 As New ColorDialog

        colordialog1.ShowDialog()
        myPen.Color = ColorDialog1.Color

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

        Dim colordialog1 As New ColorDialog

        colordialog1.ShowDialog()
        myGraphics.Clear(ColorDialog1.Color)
        PictureBox1.Image = myBitmap

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        tip_desen = "linie"

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click

        tip_desen = "dreptunghi"

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click

        tip_desen = "elipsa"

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click

        tip_desen = "creion"

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click

        myGraphics.Clear(Color.White)
        PictureBox1.Image = myBitmap

    End Sub

    Dim lastPoint As Point
    Dim down = False
    Dim tip_desen
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        myBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        myGraphics = Graphics.FromImage(myBitmap)
        myPen = New Pen(Color.Black, 2)
        PictureBox1.BackColor = Color.White



    End Sub


    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        If Not down Then Exit Sub
        Select Case tip_desen
            Case "creion"
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    myGraphics.DrawLine(myPen, lastPoint, e.Location)
                    PictureBox1.Image = myBitmap
                    lastPoint = e.Location
                    Me.Refresh()
                End If
        End Select

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

        down = True
        x1 = e.X
        x2 = e.X
        y1 = e.Y
        y2 = e.Y
        lastPoint = e.Location

    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp

        down = False
        'Save the new point
        x2 = e.X
        y2 = e.Y
        Select Case tip_desen
            Case "linie"
                DrawLine()
            Case "dreptunghi"
                DrawRectangle()
            Case "punct"
                DrawPixel()
            Case "elipsa"
                DrawElipse()
            Case "creion"
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    myGraphics.DrawLine(myPen, lastPoint, e.Location)
                    PictureBox1.Image = myBitmap
                    lastPoint = e.Location
                    Me.Refresh()
                End If
        End Select

    End Sub
End Class
