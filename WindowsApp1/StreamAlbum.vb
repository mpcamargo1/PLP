Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports YoutubeSearch
Imports VideoLibrary
Imports System.IO

Public Class StreamAlbum
    'Vetor que armazena informações recuperadas do site lastfm sobre o álbum
    Dim InfoAlbum(8) As String
    'Índice para InfoAlbum
    Dim IndexInfo As Int16
    'Ensaio geral para utilizar o YoutubeSearch
    Dim Url As String
    'Diretorio Do PLP
    Dim DiretorioPLP As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\"
    'Variável de controle
    Dim NotFound As Boolean
    ReadOnly YTReplace As String = "https://www.youtube.com/watch?v="
    'Usado para saber se o backgroundworker2 acabou a operação
    Dim Completed As Boolean
    'Criando a fila. Utilizada para colocar os elementos na label
    Dim Filalb As New Queue()
    Dim StatusDownloading As String


    Public Sub New()


        'Call to MyBase.New must be the very first in a constructor.
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        StreamMenu.Count = 0



    End Sub

    Private Sub StreamAlbum_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Configurando os textos dos controls quando o usuário abre o form
        Artista.Text = "Carregando"
        Album.ResetText()
        Faixas.ResetText()
        Data.ResetText()
        Ouvintes.ResetText()


        Form1.Letra = 0
        Form1.ClickVideo = 1


        'Inicia uma Thread para recuperar as músicas do album
        BackgroundWorker1.RunWorkerAsync()


    End Sub

    Private Sub Add()

        Form1.lbSumber.Items.Clear()

        For Each element In Filalb
            Form1.lbSumber.Items.Add(element)
        Next


    End Sub
    Private Sub ReloadMusica(ByVal Music As String, ByVal index As String)

        Dim Panel As New Panel
        Dim PicMusic As New PictureBox
        Dim L As New Label
        Panel.Controls.Add(L)
        Panel.Controls.Add(PicMusic)
        Panel.Size = New Size(125, 75)
        Panel.BackColor = Color.White
        Panel.BorderStyle = BorderStyle.FixedSingle
        PicMusic.Size = New Size(120, 70)
        PicMusic.SizeMode = PictureBoxSizeMode.CenterImage
        PicMusic.Image = My.Resources.albumicone
        PicMusic.Name = index
        L.BackColor = Color.Transparent
        L.ForeColor = Color.DodgerBlue
        L.Dock = DockStyle.Bottom
        L.AutoSize = False
        L.TextAlign = ContentAlignment.BottomCenter
        L.Text = Music
        MetroToolTip1.SetToolTip(PicMusic, Music)
        FlowLayoutPanel1.Controls.Add(Panel)

        'Liga o evento criado a este control
        AddHandler PicMusic.Click, AddressOf PicList
    End Sub

    Private Sub PicMusic_Click(sender As Object, e As EventArgs)

        'Recupera uma Query que será armazenada na lista items
        StreamMenu.items = StreamMenu.item.SearchQuery(StreamMenu.ArtistaYT & "" & CType(sender, PictureBox).Name, 1)

        'Recupera a url
        Url = StreamMenu.items(0).Url

        'Url da imagem do video, que será mostrado quando estará carregando o GeckoFX 
        GeckoFX.PictureBox1.ImageLocation = StreamMenu.items(0).Thumbnail
        'Código que ajusta a imagem ao PictureBox
        GeckoFX.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        GeckoFX.Label2.Text = StreamMenu.items(0).Title

        'Letra = 0 (Video) // A classe GeckoFX carregará como um vídeo, ou seja, primeiro irá
        ' .. mostrar a thumbnail enquanto carrega a página do Youtube

        Form1.Letra = 0

        'Recebe o endereço do vídeo
        Video.ID = Url

        'Executar Diretamente pelo Windows Media Player
        Form1.wmp.URL = MsgBox(Url)

        'Caso o navegador já estiver aberto, irá atualizar a url, caso contrário será necessário abrir novamente 
        If Application.OpenForms.OfType(Of GeckoFX)().Count() = 0 Then
            'Abre a janela do GeckoFX e ele mesmo se encarregará de ler a variável ID da classe Video, pois ele leu
            ' que Letra = 0 (Video)
            '    GeckoFX.Show()

        Else
            'Abre direto o vídeo se a janela estiver aberto
            GeckoFX.WebBrowser1.Load(Video.ID)
        End If

    End Sub

    Private Sub PicList(sender As Object, e As EventArgs)

        If Completed = False Then
            MsgBox("Carregando as músicas")
        Else


            Form1.lbSumber.SelectedIndex = CType(sender, PictureBox).Name
            Url = Form1.lbSumber.SelectedItem
            If Not Url.Equals("PLP 0x001") Then
                Video.ID = Url.Replace(YTReplace, "")
                If Application.OpenForms.OfType(Of GeckoFX)().Count() = 0 Then
                    GeckoFX.Show()
                Else
                    GeckoFX.WebBrowser1.Load(YTReplace & Video.ID)
                End If

            Else
                MessageBox.Show("PLP não pode abrir essa música")
            End If

        End If



    End Sub


    Private Sub StreamAlbum_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

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

        ''Retirando a referência do Form1
        'Form1.Artista.Text = ""
        'Form1.Nome.Text = ""
        'Form1.Álbum.Text = ""
        'Form1.Ano.Text = ""
        'Form1.Gênero.Text = ""

        ''Liberando recursos
        'Data.Dispose()
        'Album.Dispose()
        'Artista.Dispose()
        'Ouvintes.Dispose()


    End Sub


    Private Sub BackgroundWorker2_DoWorkAsync(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim Index = 0

        'Ensaio geral para utilizar HtmlAgilityPack
        Dim doc = Form1.Web.Load(StreamMenu.Album)

        For Each div1 In doc.DocumentNode.SelectNodes("//td[contains(@class,'chartlist-play')]")
            NotFound = False
            Try
                Url = div1.SelectSingleNode(".//a").Attributes("href").Value.Replace("&#39;", "'").Replace("&#34;", """").Replace("amp;", "&")
                'Adiciona o item
            Catch
                'LastFM não possui a url
                NotFound = True
            End Try
            If NotFound = False Then
                Try

                    Filalb.Enqueue(Url)

                Catch
                    Filalb.Enqueue("PLP 0x001")
                End Try
            Else
                Try
                    'Recuperar o endereço pela API do VideoLibrary(Youtube)
                    'Consome mais memória
                    'Recupera uma Query que será armazenada na lista items
                    'StreamMenu.items = StreamMenu.item.SearchQuery(StreamMenu.ArtistaYT & "" & StreamMenu.Track(Index), 1)
                    'Recupera a url
                    'Url = StreamMenu.items(0).Url
                    'Colocar na fila o endereço
                    Url = "PLP 0x001"
                    Filalb.Enqueue(Url)
                Catch
                    Filalb.Enqueue("PLP 0x001")
                End Try

            End If
            Index += 1

        Next


    End Sub
    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted

        'Sinaliza que acabou a operação de recuperar as músicas
        Completed = True
        Add()

        'Info Album
        BackgroundWorker3.RunWorkerAsync()

    End Sub
    Private Sub BackgroundWorker3_RunWorkerAsync(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Try
            'Ensaio geral para utilizar HtmlAgilityPack
            Dim doc = Form1.Web.Load(StreamMenu.Album)
            ''Recupera o artista a partir do site
            InfoAlbum(0) = doc.DocumentNode.SelectSingleNode("//a[contains(@class,'header-new-crumb')]").InnerText
            ''Nome da janela
            Me.Text = "PLP"
            ''Tratamento especial para retirar espaços desnecessários
            InfoAlbum(0) = Regex.Replace(InfoAlbum(0), "(\s){2,}", " ")
            ''Recupera o álbum a partir do site
            InfoAlbum(1) = doc.DocumentNode.SelectSingleNode("//h1[contains(@class,'header-new-title')]").InnerText.Replace("&#39;", "'").Replace("&#34;", "").Replace("amp;", "&")
            ''Tratamento especial para retirar espaços desnecessários
            InfoAlbum(1) = Regex.Replace(InfoAlbum(1), "(\s){2,}", " ")
            InfoAlbum(1) = InfoAlbum(1).Replace("#39;", "'")

            'Recuperando data de lançamento do álbum 
            InfoAlbum(2) = doc.DocumentNode.SelectSingleNode("//*[@id=""mantle_skin""]/div[2]/div/div/div[2]/div[1]/div[2]/div[1]/dl/dd[2]").InnerText
            'Recuperando quantidade de faixas
            InfoAlbum(3) = doc.DocumentNode.SelectSingleNode("//*[@id=""mantle_skin""]/div[2]/div/div/div[2]/div[1]/div[2]/div[1]/dl/dd[1]").InnerText
            'Tratamento especial para retirar espaços desnecessários
            InfoAlbum(3) = Regex.Replace(InfoAlbum(3), "(\s){2,}", " ")
            'Recuperando ouvintes
            InfoAlbum(4) = doc.DocumentNode.SelectSingleNode("//abbr[contains(@class,'intabbr js-abbreviated-counter')]").InnerText

        Catch ex As Exception
        End Try

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'Ensaio geral para utilizar HtmlAgilityPack
        Dim doc = Form1.Web.Load(StreamMenu.Album)

        'Recupera as músicas do álbum e seu valor é colocado no vetor Track
        For Each div In doc.DocumentNode.SelectNodes("//td[contains(@class,'chartlist-name')]")
            StreamMenu.Track(StreamMenu.Count) = div.SelectSingleNode(".//a").Attributes("title").Value.Replace("&#39;", "'").Replace("&#34;", """").Replace("amp;", "&")
            'Função que irá obter o endereço da música
            'Incrementando o contador Count da classe StreamMenu
            StreamMenu.Count = StreamMenu.Count + 1
        Next


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted


        'Limpar itens da lista
        If StreamMenu.items.Count > 0 Then
            StreamMenu.items.Clear()
        End If


        'Acessa de um em um para realizar o desenho no flowpanellayout
        For index As Int16 = 0 To StreamMenu.Count - 1
            'Chama a rotina que cuida do desenho do flowlayoutpanel
            ReloadMusica(StreamMenu.Track(index), index)
        Next

        'PictureBox recebe a foto do control que foi clicado
        'PictureBox1.ImageLocation = StreamMenu.ImageLocation
        PictureBox1.Image = My.Resources.albumicone
        'Ajustando o tamanho da foto do álbum ao PictureBox
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage

        'Limpando os labels
        Form1.lbNama.Items.Clear()
        Form1.lbSumber.Items.Clear()

        'Obtem info do álbum
        'GetAlbumInfo()

        'Chamando BackGroundWorker para criar uma thread para recuperar os endereços da música
        BackgroundWorker2.RunWorkerAsync()

    End Sub

    Private Sub TimerStatus_Tick(sender As Object, e As EventArgs) Handles TimerStatus.Tick
        'Modifica o texto de status
        Status.Text = "Obtendo: " & StatusDownloading
    End Sub

    Private Sub BackgroundWorker4_RunWorkerAsync(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        'Verifica se o usuário irá clicar em Sim ou Não
        If MsgBox("Deseja que o PLP baixe as músicas contidas em " & Album.Text & "?", MsgBoxStyle.YesNo, "PLP") = Windows.Forms.DialogResult.Yes Then
            'Inicia um processo para realizar o download das músicas
            For Each element In Filalb
                If element.contains(YTReplace) Then
                    'Lógica principal para realizar o download das músicas
                    'Video Library
                    Dim video = YouTube.Default.GetVideo(element)
                    StatusDownloading = video.Title
                    'Escreve no arquivo de saída
                    File.WriteAllBytes(DiretorioPLP & Artista.Text & "\" & Album.Text & "\" & video.FullName, video.GetBytes())
                End If
            Next
            'Deleta todos os itens pertencentes a fila
            Filalb.Clear()
        End If
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted

        Artista.Text = InfoAlbum(0)
        Album.Text = InfoAlbum(1)
        Data.Text = InfoAlbum(2)
        Faixas.Text = InfoAlbum(3)
        Ouvintes.Text = InfoAlbum(4)

        'Criar Diretorio para as músicas
        Album.Text = Album.Text.Replace(":", "").Replace("?", "")
        If Not Directory.Exists(DiretorioPLP & Artista.Text & "\" & Album.Text) Then
            Directory.CreateDirectory(DiretorioPLP & Artista.Text & "\" & Album.Text)
        End If

        'Inicia o timer de atualização do texto status
        TimerStatus.Start()
        Status.Visible = True

        'Download das músicas
        BackgroundWorker4.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker4_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
        'Para o timer
        TimerStatus.Stop()
        'Label Invisível
        Status.Visible = False
    End Sub
End Class