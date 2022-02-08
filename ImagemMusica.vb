Public Class ImagemMusica
    Private Sub ImagemMusica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Form1.Álbum.Text
        PictureBox1.Image = Form1.ImagemMúsica.Image
    End Sub

    Private Sub SalvarImagemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarImagemToolStripMenuItem.Click
        Dim local As String
        Try
            Dim img = New Bitmap(PictureBox1.Image)
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "Imagem Jpeg|*.jpg|Imagem bitmap|*.bmp|Imagem Gif|*.gif"
            saveFileDialog1.Title = "Salvar a imagem do álbum"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.FileName <> "" Then
                local = saveFileDialog1.FileName
                img.Save(local, System.Drawing.Imaging.ImageFormat.Jpeg)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class