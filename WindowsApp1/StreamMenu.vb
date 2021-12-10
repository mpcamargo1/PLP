Imports HtmlAgilityPack
Imports MetroFramework
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports YoutubeSearch

Public Class StreamMenu
    'Constante
    ReadOnly LastFMAlbum As String
    Dim Arg As String
    Public Shared urlAlbum As String
    Dim Page As Integer
    Public Shared Album As String
    Public Shared Track(40) As String
    Public Shared Count As Int16
    Dim Resumo As String
    'Estruturas de dados utilizadas
    Public Shared ArtistaYT As String
    Dim ImgLink(40) As String
    Public Shared ImageLocation As String
    Dim Info As String
    Dim LinkAlbum(40) As String
    'Recebe Items Da Pesquis Youtube
    Public Shared items As List(Of VideoInformation) = New List(Of VideoInformation)
    Public Shared item = New VideoSearch()


    Private Sub Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Índice do vetor é resetado
        Count = 0
    End Sub

    Public Sub New(ByVal Artista As String)

        'Call to MyBase.New must be the very first in a constructor.
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        'Um truque para recuperar o valor do artista que o Form1 envia
        Arg = Artista
        ArtistaYT = Artista
        Page = 1

        'Todas informações estão sendo recuperadas desse site

        'Código padrão ao utilizar HtmlAgilityPack
        urlAlbum = "https://www.last.fm/pt/music/" & Artista.Replace(" ", "+") & "/+albums?order=most_popular"
        'Constante LastFM Album
        LastFMAlbum = urlAlbum
        StreamAlbumLoad(Artista, urlAlbum & "?order=most_popular")

        Me.Text = "Álbuns de " & Artista

        'ResumoLabel.Text = Resumo


    End Sub


    Private Sub StreamAlbumLoad(ByRef Artista As String, ByRef urlAlbum As String)

        BackgroundWorker2.RunWorkerAsync()

        'Recuperar Dados da Wikipedia

        'BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ' Código que pega o primeiro parágrafo da Wikipedia do artista
        ' Funciona, porém não está sendo utilizado no momento
        Dim urlWiki = "https://pt.wikipedia.org/wiki/" & Arg.Replace(" ", "_")
        Dim docWIki = Form1.Web.Load(urlWiki)

        Resumo = docWIki.DocumentNode.SelectSingleNode("//div[@class='mw-parser-output']//p[1]").InnerText

    End Sub
    Private Sub ReloadAlbum(ByVal ImgLink As String, ByVal Info As String)
        Dim Panel As New Panel
        Dim PictureFlowlayoutPanel1 As New PictureBox
        Dim Label As New Label

        GC.Collect()
        GC.WaitForPendingFinalizers()

        Panel.Controls.Add(Label)
        Panel.Controls.Add(PictureFlowlayoutPanel1)
        Panel.Size = New Size(150, 150)
        Panel.BackColor = Color.White
        Panel.BorderStyle = BorderStyle.FixedSingle

        PictureFlowlayoutPanel1.Size = New Size(150, 150)

        'Imagem é o ícone do álbum

        'Causa memory leak
        'PictureFlowlayoutPanel1.ImageLocation = ImgLink
        PictureFlowlayoutPanel1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureFlowlayoutPanel1.ImageLocation = ImgLink
        PictureFlowlayoutPanel1.InitialImage = My.Resources.albumicone
        PictureFlowlayoutPanel1.BorderStyle = BorderStyle.None
        PictureFlowlayoutPanel1.Name = Info
        Label.BackColor = Color.Transparent
        Label.ForeColor = Color.DodgerBlue
        Label.Dock = DockStyle.Bottom
        Label.AutoSize = False
        Label.TextAlign = ContentAlignment.BottomCenter
        'Recuperando o nome do Album pela url Info
        Label.Text = Info.Replace("/pt/music/" & ArtistaYT.Replace(" ", "+") & "/", "").Replace("+", " ").Replace("%27", "'").Replace("%2F", " && ")
        MetroToolTip1.SetToolTip(PictureFlowlayoutPanel1, Info)
        FlowLayoutPanel1.Controls.Add(Panel)

        AddHandler PictureFlowlayoutPanel1.Click, AddressOf Album_Click
    End Sub


    Private Sub Album_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        'Liberando recursos imagem
        If Not (Form1.ImagemMúsica Is Nothing Or Form1.ImagemMúsica.Image Is Nothing) Then
            Form1.ImagemMúsica.Image.Dispose()
            Form1.ImagemMúsica.Dispose()
        End If




        'Construindo a string Album que será utilizada no StreamAlbum
        Album = "https://www.last.fm" & CType(sender, PictureBox).Name.ToString
        'Recuperando a informação da imagem que será utilizado no StreamAlbum
        ImageLocation = CType(sender, PictureBox).ImageLocation
        'PictureBox Principal recebe a localização da imagem
        Form1.ImagemMúsica.Image = My.Resources.albumicone
        Form1.ImagemMúsica.SizeMode = PictureBoxSizeMode.CenterImage

        'Abre o form
        Dim Stream = New StreamAlbum()
        Stream.Show()


    End Sub


    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Count = 0

        Dim Web = New HtmlWeb()
        Dim doc = Web.Load(urlAlbum)

        'Avançando na página do LastFM para a próxima iteração
        Page += 1
        urlAlbum = LastFMAlbum & "&page = " & Page

        Try


            'Para cada nó da classe do tipo div que chama 'album-grid...'
            For Each div In doc.DocumentNode.SelectNodes("//span[contains(@class,'resource-list--release-list-item-image cover-art')]")
                '    '    'Vetor que recupera a url da imagem'
                ImgLink(Count) = div.SelectSingleNode(".//img").Attributes("src").Value

                '    'Info = div.InnerText
                '    'Info = Regex.Replace(Info, "^\s+$[\r\n]*", "", RegexOptions.Multiline)
                '    'Indice do vetor é incrementado
                Count += 1
            Next

            'Índice é resetado
            Count = 0

            For Each div In doc.DocumentNode.SelectNodes("//h3[contains(@class,'resource-list--release-list-item-name')]")
                Try
                    'Recupera o link para o album'
                    Info = div.SelectSingleNode(".//a").Attributes("href").Value.Replace("amp;", "")
                    'É necessário realizar essa checagem pois nem todos são links para o álbum
                    If Info.Contains("/music/" & ArtistaYT.Replace(" ", "+")) Then
                        LinkAlbum(Count) = Info
                        Count += 1
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            'Não foi possível carregar a página LastFM
            MetroMessageBox.Show(Me, "Algo deu errado", "PLP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try






    End Sub

    Private Sub PicMusic_Click(sender As Object, e As EventArgs)

        'Parte necessária do YoutubeSearch
        Dim Url As String
        Dim item = New VideoSearch()
        Dim items As List(Of VideoInformation) = item.SearchQuery(ArtistaYT & "" & CType(sender, PictureBox).Name, 1)

        'Recupera a url do video
        Url = items(0).Url

        'Recupera a url da thumbnail do video
        GeckoFX.PictureBox1.ImageLocation = items(0).Thumbnail
        'Código que ajusta a imagem ao PictureBox
        GeckoFX.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        GeckoFX.Label2.Text = items(0).Title

        'Letra = 0 (Video)
        Form1.Letra = 0
        'Recebe o endereço do vídeo
        Video.ID = Url

        'Caso o navegador já estiver aberto, irá atualizar a url, caso contrário será necessário abrir novamente 
        If Application.OpenForms.OfType(Of GeckoFX)().Count() = 0 Then
            GeckoFX.Show()
        Else
            GeckoFX.WebBrowser1.Load(Video.ID)
        End If

    End Sub


    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted

        'Carrega a segunda página da LastFM do artista
        If (Page.Equals(2)) Then
            Label1.Visible = False
            Label1.Dispose()
            BackgroundWorker2.RunWorkerAsync()


            'Algoritmo que recupera a url das fotos dos artistas
            'Dim Web = New HtmlWeb()
            'Dim doc = Web.Load("https://www.last.fm/pt/music/Simple+Plan/+images")
            'Dim photo As HtmlNode = doc.DocumentNode.SelectSingleNode("//li[contains(@class,'image-list-item-wrapper')]")
            'MsgBox(photo.SelectSingleNode(".//img").Attributes("src").Value)



        End If

        'Laço que desenha na tela os álbuns
        For index As Int16 = 0 To Count - 1
            ReloadAlbum(ImgLink(index), LinkAlbum(index))
        Next



    End Sub

    Private Sub StreamMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Dispose nos controls criados em run-time
        For Each Control In FlowLayoutPanel1.Controls
            If TypeOf Control Is PictureBox Then
                Control.Image = Nothing
                Control.ImageLocation = Nothing
                Control.Dispose()
            End If
            If TypeOf Control Is Panel Then
                Control.Dispose()
            End If
        Next
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
    End Sub
End Class