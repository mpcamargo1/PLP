Public Class Seguranca_Auditiva
    Private Sub Seguranca_Auditiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.TrackBar1.Minimum = 71
        Form1.wmp.settings.volume = 75
        Form1.TrackBar1.Maximum = 100
        Form1.x = 5400
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.TrackBar1.Minimum = 0
        Form1.wmp.settings.volume = 20
        Form1.TrackBar1.Maximum = 35
        Form1.x = 21000
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.TrackBar1.Minimum = 36
        Form1.wmp.settings.volume = 50
        Form1.TrackBar1.Maximum = 70
        Form1.x = 10800
        Me.Close()
    End Sub


End Class