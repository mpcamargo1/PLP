Imports System.IO
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports YoutubeSearch
Imports HtmlAgilityPack
Imports MetroFramework
Imports AxWMPLib
Imports System.Windows.Input
Imports Microsoft.Win32
Imports System.Net
Imports System.ComponentModel
Imports CefSharp.WinForms
Imports CefSharp

Public Class Form1

    Dim i As Integer
    Dim numericCheck As Boolean
    Dim Nama As IO.StreamReader
    Dim Sumber As IO.StreamReader
    Dim Information As System.IO.FileInfo
    Dim Nomelistbox As String
    Dim TamanholbNamaWidth As String
    Dim Form1Width As String
    Dim lbNamaWidth As String
    Public Shared convert1 As String
    Public Shared ClickVideo As Int16
    Public Shared convert2 As String
    Public Shared UrlLetra_Video As String
    Public Shared Letra As Int16
    Public Shared Vezes As String
    Public Shared Vezes1 As String
    Public Shared x As String
    Public Shared PassarMúsica As String
    Public Shared segurançaauditiva As String
    Public Shared ImagemTempo As String
    Public LetraDireta As Int16
    Public listamusicas As String
    Public Wiki As Int16
    Public y As String
    Dim tosco As String
    Dim url As String
    Dim proxmusic

    Dim ImageQueue As New Queue
    'HtmlAgility
    Public Shared Web = New HtmlWeb()

    Dim FilaMusica As New Queue()


    Public WithEvents btnJanelaPausePlay As ThumbnailToolBarButton = New ThumbnailToolBarButton(New Icon(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\Pause.ico"), "Pause")
    Public WithEvents btnJanelaBack As ThumbnailToolBarButton = New ThumbnailToolBarButton(New Icon(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\Back.ico"), "Back")
    Public WithEvents btnJanelaForward As ThumbnailToolBarButton = New ThumbnailToolBarButton(New Icon(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\Forward.ico"), "Forward")
    Private Sub BibliotecaReload(Completed As Boolean)

        For Each Dir As String In Directory.GetDirectories(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib")

            Dim Panel As New Panel
            Dim PictureFlowlayoutPanel1 As New PictureBox
            Dim L As New Label
            Panel.Controls.Add(L)
            Panel.Controls.Add(PictureFlowlayoutPanel1)
            Panel.Size = New Size(150, 150)
            Panel.BackColor = Color.White
            Panel.BorderStyle = BorderStyle.FixedSingle
            PictureFlowlayoutPanel1.Size = New Size(150, 140)

            If Not Completed Then
                PictureFlowlayoutPanel1.SizeMode = PictureBoxSizeMode.CenterImage
                PictureFlowlayoutPanel1.Image = My.Resources.icone
                L.Text = Dir.ToString.Replace(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\", "")
                ImageQueue.Enqueue(L.Text)
            Else
                L.Text = Dir.ToString.Replace(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\", "")
                PictureFlowlayoutPanel1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureFlowlayoutPanel1.ImageLocation = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\image\" & L.Text & ".jpeg"
            End If


            PictureFlowlayoutPanel1.Name = Dir.ToString
            L.BackColor = Color.Transparent
            L.ForeColor = Color.DodgerBlue
            L.Dock = DockStyle.Bottom
            L.AutoSize = False
            L.TextAlign = ContentAlignment.BottomCenter


            MetroToolTip1.IsBalloon = False
            MetroToolTip1.ToolTipIcon = ToolTipIcon.Info
            MetroToolTip1.SetToolTip(PictureFlowlayoutPanel1, L.Text)

            FlowLayoutPanel4.Controls.Add(Panel)

            PictureFlowlayoutPanel1.ContextMenuStrip = CMS_Artista
            AddHandler PictureFlowlayoutPanel1.MouseClick, AddressOf PicArtist_MouseClick

        Next

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Tosco

        'Deixando Invisivel
        'MetroTabControl1.TabPages.Remove(MetroTabPage3)

        'Abrir na aba Artista
        MetroTabControl2.SelectedIndex = 0
        MetroTabControl1.TabPages.RemoveAt(2)

        Me.Text = "PLP"

        'Configurando o arquivo de configuração do CefSharp(Videos inicializam automaticamente)
        Dim settings As New CefSettings()
        settings.CefCommandLineArgs.Add("autoplay-policy", "no-user-gesture-required")
        Cef.Initialize(settings)


        'Protocolo de Segurança
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'Resetando os labels

        Artista.Text = ""
        Nome.Text = ""
        Álbum.Text = ""
        Ano.Text = ""
        Gênero.Text = ""


        ''''''''''''''' Verificando Conexão Internet

        If Not My.Computer.Network.IsAvailable Then
            MsgBox("                    *Não foi possível obter uma conexão com a Internet. 
                    *Pro Lassana Player™ não exibirá as letras. 
                    *Certifique estar conectado e reinicie o programa.")

        End If

        ''''''''''''''' Modo Decibeis Está Invisível, fazer opção de ativar em configurações

        Nomelistbox = "Tosco"
        Timer1.Start()
        Timer2.Start()
        Me.Opacity = 0.99



        ' Criando pastas  que serão utilizadas no programa
        If Not Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\bib") Then
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\Thumbnail")
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\Videos")
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib")
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\videos")
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\image")
        End If


        ' Chama o evento que carrega os artistas da biblioteca
        BibliotecaReload(False)


        Timer3.Start()
        wmp.enableContextMenu = False
        Letra = 4 'MusiXmatch
        Vezes = 0
        Vezes1 = 0
        ImagemTempo = 1500
        listamusicas = 0
        y = 0
        segurançaauditiva = 1

        ' Tenta Recuperar as informações da última vez que foi encerrado o programa
        If File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\lastone.config") Then

            'ListView1.Visible = True
            btnConfig.Visible = True
            'Panel1.Visible = True
            MetroTrackBar1.Visible = True
            Ano.Visible = True
            Gênero.Visible = True
            Artista.Visible = True
            Nome.Visible = True
            Álbum.Visible = True
            ButtonPlay.Visible = True
            ButtonRewind.Visible = True
            ButtonForward.Visible = True


            If segurançaauditiva = 1 Then  ' Abrir Modo Segurança Auditiva

                segurançaauditiva = 2
                Seguranca_Auditiva.ShowDialog()

            End If

            ImagemMúsica.SizeMode = PictureBoxSizeMode.StretchImage
            Label1.Text = "Bem-vindo"



            'Cria uma stream de leitura de arquivo
            Try
                'Lendo Arquivo Config
                Using Startup As New StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\lastone.config")
                    wmp.URL = Startup.ReadLine()
                    'Ler Próxima Linha
                    wmp.Ctlcontrols.currentPosition = Startup.ReadLine()
                End Using


                Dim mp3 As New ID3TagLibrary.MP3File(wmp.URL)

                Artista.Text = mp3.Artist
                Nome.Text = mp3.Title
                Álbum.Text = mp3.Album
                Ano.Text = mp3.Year
                Gênero.Text = mp3.Genre
                ImagemMúsica.Image = mp3.Tag2.Artwork(1)



                LetraDireta = 1

                ' Caso houver algum falha na leitura
            Catch ex As Exception

                MetroMessageBox.Show(Me, "PLP não conseguiu recuperar a última música tocada", "PLP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            End Try
        Else

            'Mensagem First Time
            MsgBox("Hey, parece que é sua primeira vez :) Para começar, selecione uma música e deixa o resto conosco.")
            MetroLabel1_Click(Me, EventArgs.Empty)

            'Criar Arquivo de config
            Dim StartUp As New IO.StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\lastone.config", False)
            StartUp.Write("0")
            StartUp.Close()


        End If

        BackgroundWorker1.RunWorkerAsync()

        'Form6.ShowDialog()


    End Sub
    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)




    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim StartUp As New IO.StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\lastone.config", False)
        StartUp.WriteLine(wmp.URL)
        StartUp.WriteLine(MetroTrackBar1.Value)
        StartUp.Close()

        If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 1 Then
            If MsgBox("O navegador está aberto. Deseja fechar mesmo assim?", MsgBoxStyle.YesNo, "PLP") = DialogResult.Yes Then
                'Chama a função de esmaecimento
                FadingForm()
            Else
                'Cancela o fechamento da aplicação
                e.Cancel = True
            End If

        End If




    End Sub

    Private Sub FadingForm()
        Dim iCount As Integer

        For iCount = 90 To 10 Step -10

            Me.Opacity = iCount / 100


            Me.Refresh()


            Threading.Thread.Sleep(50)


        Next



    End Sub

    Private Sub ExtençãoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Clipboard.SetDataObject(Information.Extension, True)
    End Sub

    Private Sub UltimaVezModificadoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Clipboard.SetDataObject(Information.LastWriteTime, True)
    End Sub

    Private Sub ÚltimaVezAcessadoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Clipboard.SetDataObject(Information.LastAccessTime, True)
    End Sub

    Private Sub NomeDoDiretórioToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Clipboard.SetDataObject(Information.Directory, True)
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs)

        wmp.Ctlcontrols.pause()

    End Sub


    Private Sub PlaylistToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If File.Exists("C:\Documents and Settings\All Users\Toscosoft\Playlist.txt") Then

            wmp.URL = ""
            lbNama.Items.Clear() 'Ter certeza que não tenha nehuma música
            lbSumber.Items.Clear() 'Ter certeza que não tenha nehuma música
            Nama = IO.File.OpenText("C:\Documents and Settings\All Users\Toscosoft\Playlist.txt") 'Encontra o diretório do arquivo
            For Each N As String In Nama.ReadToEnd.Split(vbNewLine) 'Ler o arquivo de Texto
                lbNama.Items.Add(N)
            Next

            Sumber = IO.File.OpenText("C:\Documents and Settings\All Users\Toscosoft\Playlist1.txt") 'Encontra o diretório do arquivo
            For Each M As String In Sumber.ReadToEnd.Split(vbNewLine) 'Ler o arquivo de Texto
                lbSumber.Items.Add(M)
            Next

            listamusicas = listamusicas + 1
            Timer1.Start() ' Contador inicia
            lbSumber.SelectedIndex = 0
            lbNama.SelectedIndex = lbSumber.SelectedIndex
            wmp.URL = lbSumber.SelectedItem
            Information = My.Computer.FileSystem.GetFileInfo(wmp.URL)

        End If

        If Not File.Exists("C:\Documents and Settings\All Users\Toscosoft\Playlist.txt") Then
            MsgBox("Não foi encontrado nenhuma playlist",
       vbCritical,
       "Info")
        End If

    End Sub
    Private Sub Nome_Click(sender As Object, e As EventArgs) Handles Nome.Click

        BrowserCefSharp.WebBrowser1.Load("https://www.google.com.br/search?q=" & TextBox5.Text & "&source=lnms&tbm=isch&sa=X&ved=0CAgQ_AUoAmoVChMIiJCXmZDhxgIVQ7QUCh1WAQHu&biw=1360&bih=643")

    End Sub

    Private Sub Artista_Click(sender As Object, e As EventArgs) Handles Artista.Click
        Try

            BrowserCefSharp.WebBrowser1.Load("https://www.google.com.br/search?q=" & TextBox4.Text & "&source=lnms&tbm=isch&sa=X&ved=0CAgQ_AUoAmoVChMIiJCXmZDhxgIVQ7QUCh1WAQHu&biw=1360&bih=643")

        Catch ex As Exception
        End Try
    End Sub

    Private Sub lbNama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbNama.SelectedIndexChanged

        lbSumber.SelectedIndex = lbNama.SelectedIndex
        wmp.URL = lbSumber.SelectedItem
        LetraDireta = 1

        Try

            Dim mp3LbSumber As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)

            Artista.Text = mp3LbSumber.Artist
            Nome.Text = mp3LbSumber.Title
            Álbum.Text = mp3LbSumber.Album
            Ano.Text = mp3LbSumber.Year
            Gênero.Text = mp3LbSumber.Genre


            If y = lbNama.SelectedIndex Then

            End If
            If Not y = lbNama.SelectedIndex Then
                y = lbNama.SelectedIndex
                wmp.URL = lbSumber.SelectedItem
                Information = My.Computer.FileSystem.GetFileInfo(wmp.URL)
                TextBox1.Text = Information.Name
                TextBox2.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 4)
                If Asc(TextBox2.Text) >= 48 Then
                    If Asc(TextBox2.Text) <= 57 Then
                        TextBox2.Text = TextBox2.Text.Substring(2, TextBox2.Text.Length - 2)
                    End If
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub wmp_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub lbNama_MouseMove(sender As Object, e As MouseEventArgs)

        ' Reconhecer quando o mouse passar por cima do lbNama


        ' Dim pt As New Point(e.Location)
        ' Dim CurrentItemIndex As Integer = lbNama.IndexFromPoint(pt)

        ' If CurrentItemIndex <> -1 Then
        ' Nomelistbox = lbNama.Items(CurrentItemIndex).ToString()
        ' End If
        ' If lbNama.SelectedItem = Nomelistbox Then



        'End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)


        'LabelLetra.Text = WebBrowser1.Document.GetElementById("lyr_original").InnerText


    End Sub

    ' Private Sub lbNama_MouseClick(sender As Object, e As MouseEventArgs)

    'ImagemMúsica.Visible = False
    'ImagemMúsica.Width = 50
    ' ImagemMúsica.Height = 50
    'ImagemMúsica.Visible = True
    ' Transition.run(ImagemMúsica, "Width", 183, New TransitionType_Linear(500))
    'Transition.run(ImagemMúsica, "Height", 166, New TransitionType_Linear(500))

    'End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown


        If TaskbarManager.IsPlatformSupported = True Then

            Dim btnJanela As TaskbarManager = TaskbarManager.Instance
            btnJanela.ThumbnailToolBars.AddButtons(Me.Handle, btnJanelaBack, btnJanelaPausePlay, btnJanelaForward)

        End If

    End Sub

    Private Sub btnJanelaBack_Click(sender As Object, e As ThumbnailButtonClickedEventArgs) Handles btnJanelaBack.Click

        Try

            Timer1.Stop()
            lbSumber.SelectedIndex = lbSumber.SelectedIndex - 1
            lbNama.SelectedIndex = lbSumber.SelectedIndex
            wmp.URL = lbSumber.SelectedItem

            Dim mp3LbSumber As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)

            Artista.Text = mp3LbSumber.Artist
            Nome.Text = mp3LbSumber.Title
            Álbum.Text = mp3LbSumber.Album
            Ano.Text = mp3LbSumber.Year
            Gênero.Text = mp3LbSumber.Genre




            'Dim indexprox As String
            'indexprox = lbSumber.SelectedIndex.ToString()
            'indexprox = indexprox + 1
            'proxmusic = lbSumber.Items(indexprox).ToString()
            'Dim Imagem2 As New ID3TagLibrary.MP3File(proxmusic)
            'ImagemMúsica2.Image = Imagem2.Tag2.Artwork(1)

            Timer1.Start()

        Catch ex As Exception

        End Try
        Dim Imagem As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)
        If String.IsNullOrEmpty(Imagem.Title) Then
            ImagemMúsica.Image = My.Resources.Toscosoft
            Artista.Text = "Artista/Banda: " & "Desconhecido"
            Nome.Text = "Música: " & "Desconhecido"
            Álbum.Text = "Álbum: " & "Desconhecido"
            Ano.Text = "Ano: " & "Desconhecido"
            Gênero.Text = "Gênero: " & "Desconhecido"
        Else
            Artista.Text = Imagem.Artist
            Nome.Text = Imagem.Title
            Álbum.Text = Imagem.Album
            Ano.Text = Imagem.Year
            Gênero.Text = Imagem.Genre
            ImagemMúsica.Image = Imagem.Tag2.Artwork(1)
        End If

    End Sub

    Private Sub btnJanelaPausePlay_Click(sender As Object, e As ThumbnailButtonClickedEventArgs) Handles btnJanelaPausePlay.Click


        If wmp.playState = WMPLib.WMPPlayState.wmppsPlaying Then

            wmp.Ctlcontrols.pause()

        Else
            If wmp.playState = WMPLib.WMPPlayState.wmppsPaused Then

                wmp.Ctlcontrols.play()

            End If
        End If


    End Sub

    Private Sub btnJanelaForward_Click(sender As Object, e As ThumbnailButtonClickedEventArgs) Handles btnJanelaForward.Click

        Try

            Timer1.Stop()
            lbSumber.SelectedIndex = lbSumber.SelectedIndex + 1
            lbNama.SelectedIndex = lbSumber.SelectedIndex
            wmp.URL = lbSumber.SelectedItem

            Dim mp3LbSumber As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)

            Artista.Text = mp3LbSumber.Artist
            Nome.Text = mp3LbSumber.Title
            Álbum.Text = mp3LbSumber.Album
            Ano.Text = mp3LbSumber.Year
            Gênero.Text = mp3LbSumber.Genre



            ImagemMúsica.Image = mp3LbSumber.Tag2.Artwork(1)
            'Dim indexprox As String
            'indexprox = lbSumber.SelectedIndex.ToString()
            'indexprox = indexprox + 1
            'proxmusic = lbSumber.Items(indexprox).ToString()
            'Dim Imagem2 As New ID3TagLibrary.MP3File(proxmusic)
            'ImagemMúsica2.Image = Imagem2.Tag2.Artwork(1)

            Timer1.Start()

        Catch ex As Exception
        End Try

        Dim Imagem As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)
        If String.IsNullOrEmpty(Imagem.Title) Then
            ImagemMúsica.Image = My.Resources.Toscosoft
            Artista.Text = "Artista/Banda: " & "Desconhecido"
            Nome.Text = "Música: " & "Desconhecido"
            Álbum.Text = "Álbum: " & "Desconhecido"
            Ano.Text = "Ano: " & "Desconhecido"
            Gênero.Text = "Gênero: " & "Desconhecido"
        Else
            Artista.Text = Imagem.Artist
            Nome.Text = Imagem.Title
            Álbum.Text = Imagem.Album
            Ano.Text = Imagem.Year
            Gênero.Text = Imagem.Genre
            ImagemMúsica.Image = Imagem.Tag2.Artwork(1)
        End If


    End Sub

    ' Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    'Dim Tosco As String

    'Dim R As New IO.StreamReader("C:\Toscosoft\MeuArquivoDeTexto.txt")
    ' Tosco = R.ReadToEnd
    '
    'Dim file As System.IO.StreamWriter
    'file = My.Computer.FileSystem.OpenTextFileWriter("C:\Toscosoft\MeuArquivoDeTexto1.txt", True)
    'file.WriteLine(Tosco & vbCrLf & "Tosco")
    'file.Close()

    'End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        Configs.Show()
    End Sub
    Private Sub Pic_DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        lbSumber.SelectedIndex = CType(sender, PictureBox).Name.ToString

        LetraDireta = 1
        Try
            Dim mp3 As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)

            If Not String.IsNullOrEmpty(mp3.Title) Then
                convert1 = Replace(mp3.Artist, " ", "-")
                convert2 = Replace(mp3.Title, " ", "-").Replace("'", "").Replace(",", "").Replace("?", "")
                If Letra = 1 Then
                    If LetraDireta = 1 Then
                        If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                            BrowserCefSharp.Show()
                            BrowserCefSharp.Text = "Letras"
                        End If
                        Wiki = 0 'Wikipedia Desligado
                        TextBox4.Text = convert1
                        TextBox5.Text = convert2

                        BrowserCefSharp.WebBrowser1.Load("http://www.vagalume.com.br/" & convert1 & "/" & convert2)
                        UrlLetra_Video = "http://www.vagalume.com.br/" & convert1 & "/" & convert2 & ".html"

                        LetraDireta = 0
                    End If
                ElseIf Letra = 0 Then
                    If LetraDireta = 1 Then

                        If File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\" & mp3.Artist & " " & mp3.Title & ".txt") Then
                            Using s As New StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\" & mp3.Artist & " " & mp3.Title & ".txt")
                                url = s.ReadLine()
                            End Using

                            wmp.URL = ""
                            If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                                BrowserCefSharp.Show()
                            End If
                            Wiki = 0 'Wikipedia Desligado
                            BrowserCefSharp.WebBrowser1.Load(url)
                            BrowserCefSharp.Text = "Vídeo"
                            UrlLetra_Video = url
                            LetraDireta = 0

                        Else
                            wmp.Ctlcontrols.pause()

                            reproduzirYoutube(CType(sender, PictureBox).Name.ToString, 1)

                        End If
                    End If
                ElseIf Letra = 2 Then
                    If LetraDireta = 1 Then
                        Wiki = 0 'Wikipedia Desligado
                        'Código para colocar Letra Maiúscula na primeira letra de cada palavra em uma string'  
                        'convert1 = StrConv(convert1, vbProperCase)
                        'convert1 = StrConv(convert1, vbProperCase)
                        convert1 = convert1.ToLower
                        convert2 = convert2.ToLower
                        UrlLetra_Video = "http://www.metrolyrics.com/" + TextBox5.Text & "-lyrics-" & TextBox4.Text
                        If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                            BrowserCefSharp.Show()
                        End If
                        BrowserCefSharp.WebBrowser1.Load(UrlLetra_Video)
                        LetraDireta = 0
                    End If
                ElseIf Letra = 3 Then
                    If LetraDireta = 1 Then
                        Wiki = 0 'Wikipedia Desligado
                        'Colocando a primeira Letra da String mp3.Artist em Maiúscula
                        convert1 = Char.ToUpper(TextBox4.Text.Chars(0))
                        TextBox4.Text = convert1 + TextBox4.Text.Substring(1).ToLower
                        convert1 = TextBox4.Text.ToString
                        convert2 = TextBox5.Text.ToLower
                        UrlLetra_Video = "http://genius.com/" & convert1 & "-" & convert2 & "-lyrics"
                        LetraDireta = 0
                        If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                            BrowserCefSharp.Show()
                            BrowserCefSharp.Text = "Letras"
                        Else
                            BrowserCefSharp.WebBrowser1.Load(UrlLetra_Video)
                        End If
                    End If
                ElseIf Letra = 4 Then
                    If LetraDireta = 1 Then
                        Wiki = 0 'Wikipedia Desligado
                        'Colocando a primeira Letra da String mp3.Artist em Maiúscula
                        convert1 = Char.ToUpper(TextBox4.Text.Chars(0))
                        TextBox4.Text = convert1 + TextBox4.Text.Substring(1).ToLower
                        convert1 = TextBox4.Text.ToString
                        convert2 = TextBox5.Text.ToLower
                        UrlLetra_Video = "https://www.musixmatch.com/pt-br/letras/" & convert1 & "/" & convert2
                        LetraDireta = 0
                        If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                            BrowserCefSharp.Show()
                            BrowserCefSharp.Text = "Letras"
                        Else
                            BrowserCefSharp.WebBrowser1.Load(UrlLetra_Video)
                        End If
                    End If
                End If
            Else
                Select Case MsgBox("Gostaria que o Pro Lassana Player mostrasse uma busca da música no Youtube ?", MsgBoxStyle.YesNo)
                    Case MsgBoxResult.Yes
                        Dim Musica As String
                        Musica = lbNama.SelectedItem.ToString
                        reproduzirYoutube(CType(sender, PictureBox).Name.ToString, 2)
                    Case MsgBoxResult.No
                End Select
            End If
        Catch ex As Exception

            Dim NomeMusica As String
            lbNama.SelectedIndex = CType(sender, PictureBox).Name.ToString
            NomeMusica = lbNama.SelectedItem.ToString
            Dim Artista As String
            Artista = FilaMusica.Dequeue()

            Wiki = 0 'Wikipedia Desligado
            BrowserCefSharp.Text = "Vídeo"

            Dim item = New VideoSearch()

            Dim items As List(Of VideoInformation) = item.SearchQuery(Artista & " " & NomeMusica.Replace(".plp", ""), 1)


            UrlLetra_Video = items(0).Url

            BrowserCefSharp.PictureBox1.ImageLocation = items(0).Thumbnail
            BrowserCefSharp.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            BrowserCefSharp.Label2.Text = items(0).Title

            FilaMusica.Enqueue(Artista)

            'UrlLetra = "https://www.youtube.com/results?search_query=" & YoutubeInfo.Artist & " " & YoutubeInfo.Title
            LetraDireta = 0
            Video.ID = UrlLetra_Video.Replace("https://www.youtube.com/watch?v=", "")
            If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                ClickVideo = 0
                BrowserCefSharp.Show()
            Else
                BrowserCefSharp.WebBrowser1.Load(Video.ID)
            End If

        End Try

    End Sub

    Private Sub reproduzirYoutube(ByVal sender As System.Object, Ext As Int16)
        Dim AuxIndex As String 'Salvar Posição da musica atual sendo reproduzida
        AuxIndex = lbSumber.SelectedIndex
        lbSumber.SelectedIndex = sender.Name.ToString


        If (Ext = 1) Then
            Dim YoutubeInfo As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)
            Dim item = New VideoSearch()
            Dim items As List(Of VideoInformation) = item.SearchQuery(YoutubeInfo.Artist & "" & YoutubeInfo.Title, 1)
            UrlLetra_Video = items(0).Url
            BrowserCefSharp.PictureBox1.ImageLocation = items(0).Thumbnail
            BrowserCefSharp.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            BrowserCefSharp.Label2.Text = items(0).Title
        Else
            Dim item = New VideoSearch()
            Dim items As List(Of VideoInformation) = item.SearchQuery(lbSumber.SelectedItem, 1)
            BrowserCefSharp.PictureBox1.ImageLocation = items(0).Thumbnail
            BrowserCefSharp.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            BrowserCefSharp.Label2.Text = items(0).Title
        End If

        lbSumber.SelectedIndex = AuxIndex

        Wiki = 0 'Wikipedia Desligado
        BrowserCefSharp.Text = "Vídeo"

        'UrlLetra = "https://www.youtube.com/results?search_query=" & YoutubeInfo.Artist & " " & YoutubeInfo.Title
        LetraDireta = 0
        Video.ID = UrlLetra_Video.Replace("https://www.youtube.com/watch?v=", "")
        If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
            ClickVideo = 0
            BrowserCefSharp.Show()
        Else
            BrowserCefSharp.WebBrowser1.Load(Video.ID)
        End If
    End Sub

    Private Sub Pic_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)


        LetraDireta = 1
        Dim novo As String
        Dim atual As String
        atual = wmp.URL
        lbSumber.SelectedIndex = CType(sender, PictureBox).Name.ToString
        novo = lbSumber.SelectedItem

        If TypeOf sender Is PictureBox Then
            If Not String.Compare(atual, novo, True) = 0 Then
                Try
                    Dim mp3novo As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)
                    Dim PB As PictureBox
                    PB = CType(sender, PictureBox)
                    lbSumber.SelectedIndex = CType(sender, PictureBox).Name.ToString
                    lbNama.SelectedIndex = lbSumber.SelectedIndex
                    wmp.URL = lbSumber.SelectedItem

                    If String.IsNullOrEmpty(mp3novo.Title) Then
                        ImagemMúsica.Image = My.Resources.Toscosoft
                        Artista.Text = "Artista/Banda: " & "Desconhecido"
                        Nome.Text = "Música: " & "Desconhecido"
                        Álbum.Text = "Álbum: " & "Desconhecido"
                        Ano.Text = "Ano: " & "Desconhecido"
                        Gênero.Text = "Gênero: " & "Desconhecido"
                    Else
                        Artista.Text = mp3novo.Artist
                        Nome.Text = mp3novo.Title
                        Álbum.Text = mp3novo.Album
                        Ano.Text = mp3novo.Year
                        Gênero.Text = mp3novo.Genre
                        ImagemMúsica.Image = mp3novo.Tag2.Artwork(1)
                    End If



                    ImagemMúsica.Image = mp3novo.Tag2.Artwork(1)
                    ImagemMúsica.SizeMode = PictureBoxSizeMode.StretchImage

                    'Dim indexprox As String
                    'indexprox = lbSumber.SelectedIndex.ToString()
                    'indexprox = indexprox + 1
                    'proxmusic = lbSumber.Items(indexprox).ToString()
                    'Dim Imagem2 As New ID3TagLibrary.MP3File(proxmusic)
                    'ImagemMúsica2.Image = Imagem2.Tag2.Artwork(1)


                Catch ex As Exception

                    If lbSumber.SelectedItem.Contains("PLP 0x001") Then
                        'Consertar o Streaming (App Youtube não está conseguindo recuperando o endereço URI corretamente)
                        'MetroMessageBox.Show(Me, "Não foi possível fazer o streaming", "PLP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Else
                        wmp.URL = lbSumber.SelectedItem
                    End If

                    ImagemMúsica.Image = My.Resources.albumicone
                    ImagemMúsica.SizeMode = PictureBoxSizeMode.CenterImage
                    Artista.Text = "Artista/Banda: " & "Desconhecido"
                    Nome.Text = "Música: " & "Desconhecido"
                    Álbum.Text = "Álbum: " & "Desconhecido"
                    Ano.Text = "Ano: " & "Desconhecido"
                    Gênero.Text = "Gênero: " & "Desconhecido"

                End Try
            Else
                lbSumber.SelectedIndex = lbNama.SelectedIndex
            End If

        End If
    End Sub


    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs)

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub




    Private Sub ButtonForward_Click(sender As Object, e As EventArgs) Handles ButtonForward.Click
        Try

            lbSumber.SelectedIndex = lbSumber.SelectedIndex + 1
            Try
                lbNama.SelectedIndex = lbSumber.SelectedIndex
            Catch
            End Try
            wmp.URL = lbSumber.SelectedItem
            y = lbSumber.SelectedIndex

            Dim Imagem As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)
            If String.IsNullOrEmpty(Imagem.Title) Then
                ImagemMúsica.Image = My.Resources.Toscosoft
                Artista.Text = "Artista/Banda: " & "Desconhecido"
                Nome.Text = "Música: " & "Desconhecido"
                Álbum.Text = "Álbum: " & "Desconhecido"
                Ano.Text = "Ano: " & "Desconhecido"
                Gênero.Text = "Gênero: " & "Desconhecido"
            Else
                Artista.Text = Imagem.Artist
                Nome.Text = Imagem.Title
                Álbum.Text = Imagem.Album
                Ano.Text = Imagem.Year
                Gênero.Text = Imagem.Genre
                ImagemMúsica.Image = Imagem.Tag2.Artwork(1)
            End If

            'Dim indexprox As String
            'indexprox = lbSumber.SelectedIndex.ToString()
            'indexprox = indexprox + 1
            'proxmusic = lbSumber.Items(indexprox).ToString()
            'Dim Imagem2 As New ID3TagLibrary.MP3File(proxmusic)
            'ImagemMúsica2.Image = Imagem2.Tag2.Artwork(1)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonRewind_Click(sender As Object, e As EventArgs) Handles ButtonRewind.Click
        Try

            lbSumber.SelectedIndex = lbSumber.SelectedIndex - 1
            Try
                lbNama.SelectedIndex = lbSumber.SelectedIndex
            Catch
            End Try
            wmp.URL = lbSumber.SelectedItem
            y = lbSumber.SelectedIndex

            Dim Imagem As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)

            If String.IsNullOrEmpty(Imagem.Title) Then
                ImagemMúsica.Image = My.Resources.Toscosoft
                Artista.Text = "Artista/Banda: " & "Desconhecido"
                Nome.Text = "Música: " & "Desconhecido"
                Álbum.Text = "Álbum: " & "Desconhecido"
                Ano.Text = "Ano: " & "Desconhecido"
                Gênero.Text = "Gênero: " & "Desconhecido"
            Else
                Artista.Text = Imagem.Artist
                Nome.Text = Imagem.Title
                Álbum.Text = Imagem.Album
                Ano.Text = Imagem.Year
                Gênero.Text = Imagem.Genre
                ImagemMúsica.Image = Imagem.Tag2.Artwork(1)
            End If
            'Dim indexprox As String
            'indexprox = lbSumber.SelectedIndex.ToString()
            'indexprox = indexprox + 1
            'proxmusic = lbSumber.Items(indexprox).ToString()
            'Dim Imagem2 As New ID3TagLibrary.MP3File(proxmusic)
            'ImagemMúsica2.Image = Imagem2.Tag2.Artwork(1)


        Catch ex As Exception
        End Try
    End Sub


    Private Sub Panel1_Paint_2(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ImagemMúsica2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonPlay_Click(sender As Object, e As EventArgs) Handles ButtonPlay.Click
        If wmp.playState = WMPLib.WMPPlayState.wmppsPaused Then
            wmp.Ctlcontrols.play()

        ElseIf wmp.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            wmp.Ctlcontrols.pause()

        End If

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Sub Picture_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim directory = CType(sender, PictureBox).Name.ToString
        Dim files() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(directory)
        files = dirinfo.GetFiles("*.mp3", IO.SearchOption.TopDirectoryOnly)

        ' Limpando os registros das músicas e os controls que tem a música
        lbSumber.Items.Clear()
        lbNama.Items.Clear()
        i = 0
        Dim ctls As New List(Of Control)
        ctls.AddRange(FlowLayoutPanel1.Controls.OfType(Of Panel).ToArray)
        For Each ctl As Control In ctls
            FlowLayoutPanel1.Controls.Remove(ctl)
            ctl.Dispose()
        Next
        For Each file In files

            lbNama.Items.Add(file)
            lbSumber.Items.Add(directory & "\" & file.ToString)

            Dim mp3Flowlayout As New ID3TagLibrary.MP3File(directory.ToString & "\" & file.ToString)

            Dim Panel As New Panel
            Dim PictureFlowlayoutPanel1 As New PictureBox
            Dim L As New Label
            Panel.Controls.Add(L)
            Panel.Controls.Add(PictureFlowlayoutPanel1)
            Panel.Size = New Size(125, 75)
            Panel.BackColor = Color.Transparent
            Panel.BorderStyle = BorderStyle.FixedSingle
            PictureFlowlayoutPanel1.Name = "" & i
            PictureFlowlayoutPanel1.Size = New Size(120, 70)
            PictureFlowlayoutPanel1.SizeMode = PictureBoxSizeMode.CenterImage
            PictureFlowlayoutPanel1.Image = My.Resources.icone
            L.BackColor = Color.Transparent
            L.ForeColor = Color.DodgerBlue
            L.Dock = DockStyle.Bottom
            L.AutoSize = False
            L.TextAlign = ContentAlignment.BottomCenter
            L.Text = mp3Flowlayout.Title
            i = i + 1


            AddHandler PictureFlowlayoutPanel1.MouseClick, AddressOf Pic_MouseClick
            AddHandler PictureFlowlayoutPanel1.DoubleClick, AddressOf Pic_DoubleClick

            MetroToolTip1.IsBalloon = False
            MetroToolTip1.ToolTipIcon = ToolTipIcon.Info

            If String.IsNullOrEmpty(mp3Flowlayout.Title) Then
                L.Text = file.ToString
                FlowLayoutPanel1.Controls.Add(Panel)
            Else
                L.Text = mp3Flowlayout.Title
                FlowLayoutPanel1.Controls.Add(Panel)
            End If
            MetroToolTip1.SetToolTip(PictureFlowlayoutPanel1, "Reproduzir " & L.Text & vbNewLine & "Duplo Clique para ver a letra")
        Next

        lbSumber.SelectedIndex = 0
        lbNama.SelectedIndex = lbSumber.SelectedIndex
        wmp.URL = lbSumber.SelectedItem


        Dim mp3novo As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)




        'Dim indexprox As String
        'indexprox = lbSumber.SelectedIndex.ToString()
        'indexprox = indexprox + 1
        'proxmusic = lbSumber.Items(indexprox).ToString()
        'Dim Imagem2 As New ID3TagLibrary.MP3File(proxmusic)
        'ImagemMúsica2.Image = Imagem2.Tag2.Artwork(1)


        If String.IsNullOrEmpty(mp3novo.Title) Then
            ImagemMúsica.Image = My.Resources.Toscosoft
            Artista.Text = "Artista/Banda: " & "Desconhecido"
            Nome.Text = "Música: " & "Desconhecido"
            Álbum.Text = "Álbum: " & "Desconhecido"
            Ano.Text = "Ano: " & "Desconhecido"
            Gênero.Text = "Gênero: " & "Desconhecido"
        Else
            Artista.Text = mp3novo.Artist
            Nome.Text = mp3novo.Title
            Álbum.Text = mp3novo.Album
            Ano.Text = mp3novo.Year
            Gênero.Text = mp3novo.Genre
            ImagemMúsica.Image = mp3novo.Tag2.Artwork(1)
        End If

    End Sub

    Private Sub btnVideo_Click(sender As Object, e As EventArgs)
        'Form6.Show()
    End Sub

    Private Sub MetroTrackBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles MetroTrackBar1.Scroll
        wmp.Ctlcontrols.currentPosition = MetroTrackBar1.Value
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' lbSumber.SelectedIndex = lbNama.SelectedIndex ' Codigo Novo (Tomar Cuidado)

        Try
            If wmp.playState = WMPLib.WMPPlayState.wmppsPlaying Then

                Dim duracao As Single = Math.Floor(wmp.currentMedia.duration)
                MetroTrackBar1.Maximum = duracao                            'Codigo Pegar posição música wmp com TrackBar
                MetroTrackBar1.Value = wmp.Ctlcontrols.currentPosition
                ButtonPlay.Text = "||"
            End If
            If wmp.playState = WMPLib.WMPPlayState.wmppsReady Then

                If Letra = 0 Then
                    Label1.Text = BrowserCefSharp.Status
                End If

            End If

            If wmp.playState = WMPLib.WMPPlayState.wmppsStopped Then
                lbSumber.SelectedIndex = lbSumber.SelectedIndex + 1
                lbNama.SelectedIndex = lbSumber.SelectedIndex
                wmp.URL = lbSumber.SelectedItem
                y = lbSumber.SelectedIndex

                Try
                    Dim mp3prox As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)
                    If String.IsNullOrEmpty(mp3prox.Title) Then
                        ImagemMúsica.Image = My.Resources.Toscosoft
                    Else
                        ImagemMúsica.Image = mp3prox.Tag2.Artwork(1)
                    End If
                Catch
                End Try
            End If

            If wmp.playState = WMPLib.WMPPlayState.wmppsPaused Then

                Label1.Text = "Versão 1.3" & " 2021"
                ButtonPlay.Text = ">"

            End If



        Catch
        End Try

    End Sub

    Private Sub MetroLabel1_Click(sender As Object, e As EventArgs) Handles MetroLabel1.Click
        opd.Multiselect = True
        If opd.ShowDialog() = DialogResult.OK Then

            listamusicas = listamusicas + 1

            ' Algoritmo Simples Pegar Capa do Álbum
            'ImagemMúsica.ImageLocation = opd.FileName.Replace(opd.SafeFileName, "\Folder.jpg")
            ImagemMúsica.SizeMode = PictureBoxSizeMode.StretchImage

            LetraDireta = 1
            For Each s As String In opd.FileNames

                lbSumber.Items.Add(s)


            Next
            For Each a As String In opd.SafeFileNames

                lbNama.Items.Add(a)

                Dim DiretorioCompleto As String
                DiretorioCompleto = Path.GetDirectoryName(opd.FileName) & "\" & a
                Dim mp3ListView As New ID3TagLibrary.MP3File(DiretorioCompleto)


                If Not String.IsNullOrEmpty(mp3ListView.Artist) Then
                    If Not Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\" & mp3ListView.Artist & "\" & mp3ListView.Album.Replace(":", "")) Then
                        Biblioteca(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\" & mp3ListView.Artist, System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\" & mp3ListView.Artist & "\" & mp3ListView.Album.Replace(":", ""), mp3ListView.Artist)
                    End If
                    If Not File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\" & mp3ListView.Artist & "\" & mp3ListView.Album.Replace(":", "") & "\" & mp3ListView.Title & ".plp") Then
                        Dim NomeArquivo As String = System.IO.Path.GetFileNameWithoutExtension(Path.GetDirectoryName(opd.FileName.ToString) & "\" & a)
                        CriarFile(NomeArquivo, Path.GetDirectoryName(opd.FileName.ToString) & "\" & a, System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\" & mp3ListView.Artist & "\" & mp3ListView.Album.Replace(":", ""))
                    End If
                Else
                    If Not Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\Artista Desconhecido\") Then
                        Biblioteca(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP™\logs\bib\Artista Desconhecido", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP™\logs\bib\Artista Desconhecido", a.Replace(".mp3", ""))
                    End If

                    If Not File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\Artista Desconhecido\" & a.Replace(".mp3", ".plp")) Then
                        CriarFile(a.Replace(".mp3", ".plp"), Path.GetDirectoryName(opd.FileName.ToString) & "\" & a, System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\Artista Desconhecido\")
                    End If
                End If


            Next

            For Each info In opd.FileNames

                Dim SizeMusic As New System.IO.FileInfo(info) ' Obter Tamanho(Size) Do Arquivo em bytes
                Dim mp3ListView As New ID3TagLibrary.MP3File(info) ' Criar Variável para ser obter as tag a partir da variável info
                Dim Tosco As Double
                Tosco = SizeMusic.Length / 1048576 ' Transformando Valor em MB´s
                Tosco = String.Format("{0:N2}", Tosco)

                Dim Existe As String

                If File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\" & mp3ListView.Artist & " " & mp3ListView.Title & ".txt") Then

                    Existe = "Sim"

                Else
                    Existe = "Não"

                End If

                Dim list As New ListViewItem(mp3ListView.FileInfo.Name) ' will add to column(0)
                list.SubItems.Add(mp3ListView.Artist) 'will add to column(1)
                list.SubItems.Add(mp3ListView.Album) 'will add to column(2)
                list.SubItems.Add(Tosco) 'will add to column(3)
                list.SubItems.Add(mp3ListView.FileInfo.DirectoryName) 'will add to column(4)
                list.SubItems.Add(mp3ListView.FileInfo.Extension) 'will add to column(5)
                list.SubItems.Add(Existe) 'will add to column(6)
                'ListView1.Items.Add(list)



            Next
            Timer1.Start() ' Contador inicia

            'ListView1.Visible = True
            btnConfig.Visible = True
            'Panel1.Visible = True
            MetroTrackBar1.Visible = True
            Ano.Visible = True
            Gênero.Visible = True
            Artista.Visible = True
            Nome.Visible = True
            Álbum.Visible = True
            ButtonPlay.Visible = True
            ButtonRewind.Visible = True
            ButtonForward.Visible = True


            If listamusicas = 1 Then

                lbSumber.SelectedIndex = 0
                lbNama.SelectedIndex = lbSumber.SelectedIndex
                wmp.URL = lbSumber.SelectedItem
                Information = My.Computer.FileSystem.GetFileInfo(wmp.URL)




            End If

            If segurançaauditiva = 1 Then  ' Abrir Modo Segurança Auditiva

                segurançaauditiva = 2
                Seguranca_Auditiva.ShowDialog()

            End If



        End If



        Try
            Dim Imagem As New ID3TagLibrary.MP3File(lbSumber.SelectedItem)
            ImagemMúsica.Image = Imagem.Tag2.Artwork(1)
            'Dim indexprox As String
            'indexprox = lbSumber.SelectedIndex.ToString()
            'indexprox = indexprox + 1
            'proxmusic = lbSumber.Items(indexprox).ToString()
            'Dim Imagem2 As New ID3TagLibrary.MP3File(proxmusic)
            'ImagemMúsica2.Image = Imagem2.Tag2.Artwork(1)

        Catch ex As Exception

        End Try

        'Limpa a fila
        ImageQueue.Clear()
        'Atualiza a fila de imagem a serem recarregadas (BackgroundWorker1 utiliza essa estrutura)
        For Each Dir As String In Directory.GetDirectories(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib")
            ImageQueue.Enqueue(Dir.ToString.Replace(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\", ""))
        Next


        'Thread para capturar as imagens da músicas
        BackgroundWorker1.RunWorkerAsync()

    End Sub
    Private Sub Biblioteca(ByVal EndMusicaArtista As String, ByVal EndMusicaAlbum As String, ByVal FileMusica As String)
        If Not Directory.Exists(EndMusicaArtista) Then
            Dim PanelArtist As New Panel
            Dim LArtist As New Label
            Dim PicArtist As New PictureBox
            PanelArtist.Controls.Add(LArtist)
            PanelArtist.Controls.Add(PicArtist)
            PicArtist.Name = EndMusicaArtista
            PicArtist.Image = My.Resources.albumicone
            PanelArtist.Size = New Size(150, 150)
            PicArtist.Size = New Size(150, 140)
            PicArtist.SizeMode = PictureBoxSizeMode.CenterImage
            PanelArtist.BackColor = Color.White
            PanelArtist.BorderStyle = BorderStyle.FixedSingle
            LArtist.BackColor = Color.Transparent
            LArtist.ForeColor = Color.DodgerBlue
            LArtist.Dock = DockStyle.Bottom
            LArtist.AutoSize = False
            LArtist.TextAlign = ContentAlignment.BottomCenter
            LArtist.Text = FileMusica

            PicArtist.ContextMenuStrip = CMS_Artista

            FlowLayoutPanel4.Controls.Add(PanelArtist)
            AddHandler PicArtist.MouseClick, AddressOf PicArtist_MouseClick
        End If
        Directory.CreateDirectory(EndMusicaAlbum)
    End Sub
    Private Sub CriarFile(ByVal NomeFile As String, ByVal EndMusica As String, ByVal Diretorio As String)
        Dim MusicaArtista As New IO.StreamWriter(Diretorio & "\" & NomeFile.Replace(":", "").Replace(":", "") & ".plp", False)
        MusicaArtista.WriteLine(EndMusica)
        MusicaArtista.Close()
    End Sub
    Private Sub PicArtist_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        FilaMusica.Clear()

        'Limpando o FlowLayoutPanel
        Dim ctlsArtist As New List(Of Control)
        ctlsArtist.AddRange(FlowLayoutPanel3.Controls.OfType(Of Panel).ToArray)
        For Each ctl As Control In ctlsArtist
            FlowLayoutPanel3.Controls.Remove(ctl)
            ctl.Dispose()
        Next


        Dim DocumentosPLP As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\"
        Artista.Text = CType(sender, PictureBox).Name.ToString()
        FilaMusica.Enqueue(Artista.Text.Replace(DocumentosPLP, ""))



        For Each Dir As String In Directory.GetDirectories(CType(sender, PictureBox).Name.ToString)
            Dim Panel As New Panel
            Dim PicAlbum As New PictureBox
            Dim L As New Label
            Panel.Controls.Add(L)
            Panel.Controls.Add(PicAlbum)
            Panel.Size = New Size(125, 75)
            Panel.BackColor = Color.White
            Panel.BorderStyle = BorderStyle.FixedSingle
            PicAlbum.Name = Dir.ToString
            PicAlbum.Size = New Size(120, 70)
            PicAlbum.SizeMode = PictureBoxSizeMode.CenterImage
            PicAlbum.Image = My.Resources.albumicone
            L.BackColor = Color.Transparent
            L.ForeColor = Color.DodgerBlue
            L.Dock = DockStyle.Bottom
            L.AutoSize = False
            L.TextAlign = ContentAlignment.BottomCenter
            L.Text = Dir.Replace(CType(sender, PictureBox).Name.ToString & "\", "")
            PicAlbum.ContextMenuStrip = CMS_Album
            FlowLayoutPanel3.Controls.Add(Panel)
            AddHandler PicAlbum.MouseClick, AddressOf PicAlbum_MouseClick
        Next

        MetroTabControl2.SelectedIndex = 1

    End Sub

    Private Sub PicAlbum_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        lbSumber.Items.Clear()
        lbNama.Items.Clear()
        i = 0

        'Limpando o FlowLayoutPanel
        Dim ctlsAlbum As New List(Of Control)
        ctlsAlbum.AddRange(FlowLayoutPanel1.Controls.OfType(Of Panel).ToArray)
        For Each ctl As Control In ctlsAlbum
            FlowLayoutPanel1.Controls.Remove(ctl)
            ctl.Dispose()
        Next

        GC.Collect()

        Dim Folder As New IO.DirectoryInfo(CType(sender, PictureBox).Name.ToString)
        Dim TamExt As Int16 = 5


        For Each File As IO.FileInfo In Folder.GetFiles("*.mp4", IO.SearchOption.TopDirectoryOnly).OrderBy(Function(x) x.CreationTime)
            Try
                lbNama.Items.Add(File)
                lbSumber.Items.Add(File.FullName)


                Dim P As New Panel
                Dim L As New Label
                Dim Pic As New PictureBox
                P.Controls.Add(L)
                P.Controls.Add(Pic)
                Pic.Name = "" & i
                Pic.Image = My.Resources.icone
                P.Size = New Size(125, 75)
                Pic.Size = New Size(123, 73)
                Pic.SizeMode = PictureBoxSizeMode.CenterImage
                P.BackColor = Color.White
                P.BorderStyle = BorderStyle.FixedSingle
                L.BackColor = Color.Transparent
                L.ForeColor = Color.DodgerBlue
                L.Dock = DockStyle.Bottom
                L.AutoSize = False
                L.TextAlign = ContentAlignment.BottomCenter

                Dim Diretorio = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib"


                L.Text = File.ToString.Replace(".mp4", "").Replace("-", "").Replace("_", "").Replace("-", "").Replace(Folder.Parent.ToString, "")



                i = i + 1

                MetroToolTip1.IsBalloon = False
                MetroToolTip1.ToolTipIcon = ToolTipIcon.Info
                MetroToolTip1.SetToolTip(Pic, L.Text)
                FlowLayoutPanel1.Controls.Add(P)

                AddHandler Pic.MouseClick, AddressOf Pic_MouseClick
                AddHandler Pic.DoubleClick, AddressOf Pic_DoubleClick

            Catch ex As Exception
                'Deletar o arquivo que contém o endereço´da música
                'System.IO.File.Delete(Folder.ToString & "\" & File.ToString)
            End Try
        Next

        For Each FileMP3 As IO.FileInfo In Folder.GetFiles("*.plp", IO.SearchOption.TopDirectoryOnly).OrderBy(Function(x) x.CreationTime)

            Try

                Using Buffer As New StreamReader(FileMP3.FullName)
                    Dim enderecoMP3 = Buffer.ReadLine()

                    Dim mp3 As New ID3TagLibrary.MP3File(enderecoMP3)

                    lbNama.Items.Add(mp3.Title)
                    lbSumber.Items.Add(enderecoMP3)

                    Dim P As New Panel
                    Dim L As New Label
                    Dim Pic As New PictureBox
                    P.Controls.Add(L)
                    P.Controls.Add(Pic)
                    Pic.Name = "" & i
                    Pic.Image = My.Resources.icone
                    P.Size = New Size(125, 75)
                    Pic.Size = New Size(123, 73)
                    Pic.SizeMode = PictureBoxSizeMode.CenterImage
                    P.BackColor = Color.White
                    P.BorderStyle = BorderStyle.FixedSingle
                    L.BackColor = Color.Transparent
                    L.ForeColor = Color.DodgerBlue
                    L.Dock = DockStyle.Bottom
                    L.AutoSize = False
                    L.TextAlign = ContentAlignment.BottomCenter
                    L.Text = mp3.Title

                    Pic.ContextMenuStrip = CMS_Musica

                    MetroToolTip1.IsBalloon = False
                    MetroToolTip1.ToolTipIcon = ToolTipIcon.Info
                    MetroToolTip1.SetToolTip(Pic, L.Text)

                    AddHandler Pic.MouseClick, AddressOf Pic_MouseClick
                    AddHandler Pic.DoubleClick, AddressOf Pic_DoubleClick

                    FlowLayoutPanel1.Controls.Add(P)


                    i = i + 1
                End Using
            Catch ex As Exception

            End Try
        Next

        MetroTabControl2.SelectedIndex = 2

        'Checando se a pasta está vazia
        If Directory.GetFiles(Folder.ToString).Length = 0 Then
            MsgBox("Álbum Vazio")
            'Biblioteca Volta para a tab Artista
            MetroTabControl2.SelectedIndex = 0
            'Deletar Diretório
            Directory.Delete(Folder.ToString)
        End If

    End Sub

    Private Sub MetroLabel2_Click(sender As Object, e As EventArgs) Handles MetroLabel2.Click
        If fbd.ShowDialog() = DialogResult.OK Then
            Dim Panel As New Panel
            Dim Picture As New PictureBox
            Dim L As New Label
            Panel.Controls.Add(L)
            Panel.Controls.Add(Picture)
            Panel.Size = New Size(125, 75)
            Panel.BackColor = Color.DodgerBlue
            Panel.BorderStyle = BorderStyle.FixedSingle
            Picture.Name = fbd.SelectedPath.ToString
            Picture.Size = New Size(120, 70)
            Picture.SizeMode = PictureBoxSizeMode.CenterImage
            Picture.Image = My.Resources.albumicone
            L.BackColor = Color.Transparent
            L.ForeColor = Color.Black
            L.Dock = DockStyle.Bottom
            L.AutoSize = False
            L.TextAlign = ContentAlignment.BottomCenter
            L.Text = Path.GetFileName(fbd.SelectedPath.ToString)
            FlowLayoutPanel3.Controls.Add(Panel)
            AddHandler Picture.MouseClick, AddressOf Picture_MouseClick
        End If
    End Sub

    Private Sub MetroLabel3_Click(sender As Object, e As EventArgs) Handles MetroLabel3.Click
        Video.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If (wmp.settings.volume > TrackBar1.Maximum) Then
            wmp.settings.volume = TrackBar1.Value
        End If

        If (wmp.settings.volume < TrackBar1.Minimum) Then
            wmp.settings.volume = TrackBar1.Value
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        x = x - 1
        If x = 0 Then
            Me.TrackBar1.Minimum = 0
            Me.wmp.settings.volume = 0
            Me.TrackBar1.Maximum = 0
            MsgBox("Você passou o tempo limite de escutar música. Descanse os seus ouvidos !!!")
        End If
    End Sub

    Private Sub FlowLayoutPanel1_Paint_1(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub WikipediaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WikipediaToolStripMenuItem.Click


        Wiki = 0 'Wikipedia Desligado



        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Dim Artista As String
                Artista = CType(sourceControl, PictureBox).Name.Replace(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\", "")
                UrlLetra_Video = "https:/pt.wikipedia.org/wiki/" & Artista.Replace(" ", "_")
                LetraDireta = 0

                If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                    BrowserCefSharp.Show()
                    BrowserCefSharp.WebBrowser1.Load(UrlLetra_Video)
                    BrowserCefSharp.Text = "Wikipedia"
                Else
                    BrowserCefSharp.WebBrowser1.Load(UrlLetra_Video)
                End If

            End If
        End If


    End Sub

    Private Sub BingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BingToolStripMenuItem.Click
        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Dim Artista As String
                Artista = CType(sourceControl, PictureBox).Name.Replace(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\", "")
                UrlLetra_Video = "www.bing.com/search?q=" & Artista
                LetraDireta = 0

                If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
                    BrowserCefSharp.Show()
                    BrowserCefSharp.WebBrowser1.Load(UrlLetra_Video)
                    BrowserCefSharp.Text = "Bing"
                Else
                    BrowserCefSharp.WebBrowser1.Load(UrlLetra_Video)
                End If
            End If
        End If

    End Sub

    Private Sub RemoverDaBibliotecaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoverDaBibliotecaToolStripMenuItem.Click

        Dim ctls As New List(Of Control)
        ctls.AddRange(FlowLayoutPanel4.Controls.OfType(Of Panel).ToArray)
        For Each ctl As Control In ctls
            FlowLayoutPanel4.Controls.Remove(ctl)
            ctl.Dispose()
        Next

        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Try
                    Directory.Delete(CType(sourceControl, PictureBox).Name.ToString, True)
                Finally
                End Try
            End If
        End If

        BibliotecaReload(False)

    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click


        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Try

                    'Checando se possui conexão com internet
                    If Not My.Computer.Network.IsAvailable Then
                        MsgBox("                    *Não foi possível obter uma conexão com a Internet. 
                    *Pro Lassana Player™ não entrará no modo streaming. 
                    *Certifique estar conectado e reinicie o programa.")


                    Else
                        'Caso houver conexão com internet
                        Dim Artista As String = CType(sourceControl, PictureBox).Name.Replace(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\", "")

                        Dim InfoForm = New StreamMenu(Artista)
                        InfoForm.Show()
                    End If




                Finally
                End Try
            End If
        End If




    End Sub

    Private Sub LetraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LetraToolStripMenuItem.Click


        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Try

                    lbSumber.SelectedIndex = CType(sourceControl, PictureBox).Name.ToString()
                    Dim arg As String = lbSumber.SelectedItem

                    Dim InfoForm = New LetrasPLP(arg)
                    InfoForm.Show()


                Finally
                End Try
            End If
        End If

    End Sub

    Private Sub Removerdabiblioteca_Click(sender As Object, e As EventArgs) Handles Removerdabiblioteca.Click

        'Dispose nos controls
        Dim ctls As New List(Of Control)
        ctls.AddRange(FlowLayoutPanel3.Controls.OfType(Of Panel).ToArray)
        For Each ctl As Control In ctls
            FlowLayoutPanel3.Controls.Remove(ctl)
            ctl.Dispose()
        Next

        'Cast no Control
        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Try
                    Directory.Delete(CType(sourceControl, PictureBox).Name.ToString, True)
                Finally
                End Try
            End If
        End If

        'Voltar para a aba artista
        MetroTabControl2.SelectedIndex = 0
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'Algoritmo que recupera a url das fotos dos artistas
        Dim Web = New HtmlWeb()
        For Each Artista As String In ImageQueue
            If Not File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\image\" & Artista & ".jpeg") Then
                Dim doc = Web.Load("https://www.last.fm/pt/music/" & Artista & "/+images")
                Dim photo As HtmlNode = doc.DocumentNode.SelectSingleNode("//li[contains(@class,'image-list-item-wrapper')]")
                My.Computer.Network.DownloadFile(photo.SelectSingleNode(".//img").Attributes("src").Value,
                System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\image\" & Artista & ".jpeg", "", "")
            End If
        Next

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        'Dispose nos controls
        For Each Control In FlowLayoutPanel4.Controls
            If TypeOf Control Is PictureBox Then
                Control.Image = Nothing
                Control.ImageLocation = Nothing
                Control.Dispose()
            End If
            If TypeOf Control Is Panel Then
                Control.Dispose()
            End If
        Next

        FlowLayoutPanel4.Controls.Clear()


        BibliotecaReload(True)


    End Sub

    Private Sub ImagemMúsica_Click(sender As Object, e As EventArgs) Handles ImagemMúsica.Click
        ImagemMusica.Show()
    End Sub

End Class

