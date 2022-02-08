Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports CefSharp
Imports CefSharp.Handler
Imports CefSharp.WinForms
Imports Microsoft.WindowsAPICodePack.Taskbar
Public Class BrowserCefSharp
    Dim Client As New WebClient
    Dim PáginaCarregada As String
    Dim Fonte As Font
    Public Shared EntrouMenuConfig As String
    Public Shared DownloadVideo
    Public Shared Status As String
    Dim CurrentStatus As Integer
    'Public WithEvents btnAssociar As ThumbnailToolBarButton = New ThumbnailToolBarButton(New Icon("C:\Toscosoft\Pro Lassana Player™\associar.ico"), "Associar Video")
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        CurrentStatus = 0
        Gecko.GeckoPreferences.User("dom.max_script_run_time") = 0
        'btnAssociar.Visible = False
        PáginaCarregada = 0
        WebBrowser1.Visible = False
        Label2.Text = Form1.Artista.Text & " " & Form1.Nome.Text
        EntrouMenuConfig = 0
        If Form1.Letra = 0 And Form1.ClickVideo = 0 Then 'Url De Video Aberta
            WebBrowser1.Load(Video.ID)
            'WebBrowser1.Load("C:\Users\mpcam\Downloads\Ckin-Video-Player-master\video.html")
        ElseIf Form1.Letra = 0 And Form1.ClickVideo = 1 Then 'Clicado no FlowLayoutPanel do Form1
            PictureBox1.ImageLocation = "http://img.youtube.com/vi/" & Video.ID & "/hqdefault.jpg"
            WebBrowser1.Load("https://www.youtube.com/watch?v=" & Video.ID)
            'WebBrowser1.Load("C:\Users\mpcam\Downloads\Ckin-Video-Player-master\video.html")
        Else
            WebBrowser1.Load(Form1.UrlLetra_Video)             'Embed Video e Letras
        End If

        Timer1.Start()


    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'If TaskbarManager.IsPlatformSupported = True Then

        '    Dim btnJanela As TaskbarManager = TaskbarManager.Instance

        '    btnJanela.ThumbnailToolBars.AddButtons(Me.Handle, btnAssociar)

        'End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim Tosco As String
        'Tosco = "Tosco"

        'Tosco = WebBrowser1.Document.GetElementById("lyr_original").TextContent
        'Label2.Text = Tosco
        'Label2.Visible = True

    End Sub

    'Private Sub btnAssociar_Click(sender As Object, e As ThumbnailButtonClickedEventArgs) Handles btnAssociar.Click

    '    Dim MusicaArtistaString As String
    '    Dim MusicaArtista As New ID3TagLibrary.MP3File(Form1.lbSumber.SelectedItem)
    '    MusicaArtistaString = MusicaArtista.Artist & " " & MusicaArtista.Title

    '    Try
    '        If Not Directory.Exists("C:\Toscosoft\Pro Lassana Player™\logs\") Then
    '            Directory.CreateDirectory("C:\Toscosoft\Pro Lassana Player™\logs\")
    '        End If

    '        Dim Nome As New IO.StreamWriter("C:\Toscosoft\Pro Lassana Player™\logs\" & MusicaArtistaString & ".txt", False)
    '        MsgBox("C:\Toscosoft\Pro Lassana Player™\Logs\" & MusicaArtistaString & ".txt")
    '        Nome.WriteLine(WebBrowser1.Url)
    '        Nome.Close()

    '    Catch ex As Exception

    '    End Try


    'End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)

    End Sub
    Private Sub Pic_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Select Case MsgBox("Pro Lassana Player irá baixar o video selecionado. Tem Certeza ? ", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 1 Then
                    Me.Close()
                End If
                Dim ID As String
                Dim Link As String
                Dim Ext As String
                ID = CType(sender, PictureBox).Name.ToString
                Link = "https://www.youtube.com/watch?v=" & ID
                'video = YouTube.Default.GetVideo(Link)
                Ext = DownloadVideo.FullName
                Ext = Replace(Ext, ".mp4", ".jpg").Replace(".webm", ".jpg")
                BackgroundWorker1.RunWorkerAsync()
                Dim Client As New WebClient
                Client.DownloadFile("http://img.youtube.com/vi/" & ID & "/mqdefault.jpg", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "PLP\Thumbnail\" & Ext)
                Client.Dispose()
            Case MsgBoxResult.No
        End Select
    End Sub

    Private Sub WebBrowser1_DocumentTitleChanged(sender As Object, e As EventArgs)

        'Código que armazena um histórico de videos assistido
        'Funcional


        'If Form1.Letra = 0 Then
        '    If WebBrowser1.Url.ToString.Contains("https://www.youtube.com/watch?v=") Then
        '        Dim ID As String
        '        Dim titulovideo As String
        '        titulovideo = Replace(WebBrowser1.DocumentTitle.ToString, "- YouTube", "").Replace("[", "").Replace("]", "").Replace("|", "-").Replace(":", "-").Replace("(", "").Replace(")", "").Replace(".", "")
        '        Dim txtvideos As New IO.StreamWriter("C:\Toscosoft\Pro Lassana Player™\logs\videos\" & titulovideo & ".data", False)

        '        ID = Replace(WebBrowser1.Url.ToString, "https://www.youtube.com/watch?v=", "")
        '        txtvideos.WriteLine(WebBrowser1.Url.ToString)
        '        txtvideos.Close()

        '        Client.DownloadFile("http://img.youtube.com/vi/" & ID & "/mqdefault.jpg", "C:\Toscosoft\Pro Lassana Player™\Thumbnail\" & titulovideo & ".jpg")

        '    End If
        'End If


        Me.Text = WebBrowser1.Address


    End Sub

    Private Sub WebBrowser1_LoadingStateChanged(sender As Object, e As LoadingStateChangedEventArgs) Handles WebBrowser1.LoadingStateChanged


    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Variável que temporiza 3 segundos
        CurrentStatus += 1

        'Mostra a thumbnail por 3 segundos
        If (CurrentStatus.Equals(3)) Then

            If PáginaCarregada = 0 Then ' Verificar se modificou o tamanho
                Me.Size = New Size(751, 543)
                PáginaCarregada = 1 ' Atualizar o tamanho somente uma vez, quando o usuário inicia a janela pela primeira vez
                Status = "[Executando]" & WebBrowser1.Address

                Me.Text = WebBrowser1.Address

                PictureBox1.Visible = False
                PictureBox1.Image = Nothing
                WebBrowser1.Visible = True
                Label2.Visible = False
                Label1.Visible = False

            End If

            'Finalizar o timer
            Timer1.Enabled = False
            Timer1.Stop()
        End If

    End Sub
End Class