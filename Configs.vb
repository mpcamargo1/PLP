Public Class Configs
    Private Sub Configs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        Form1.Letra = 0
    End Sub

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        Form1.Letra = 4
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        Form1.Letra = 3
    End Sub
End Class