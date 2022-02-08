Imports System.ComponentModel
Imports HtmlAgilityPack

Public Class LetrasPLP
    Public Shared Arg As String
    Dim Metodo As Int16
    Dim Artista As String
    Dim Musica As String
    Dim DiretorioPLP As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\bib\"


    Private Sub LetrasPLP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New(ByVal url As String)

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        Arg = url
        Dim mp3 As New ID3TagLibrary.MP3File(Arg)

        If Not (String.IsNullOrEmpty(mp3.Artist)) Then
            Me.Text = "Letras de " & mp3.Title & " de " & mp3.Artist
            Metodo = 1 'Método para encontrar letras a partir do arquivo mp3
        Else
            Metodo = 2 'Outro método para encontrar letras a partir do arquivo .webm
        End If


        BackgroundWorker1.RunWorkerAsync()

    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        If (Metodo.Equals(1)) Then

            Dim mp3 As New ID3TagLibrary.MP3File(Arg)
            Dim url = "https://genius.com/" & mp3.Artist.Replace(" ", "-") & "-" & mp3.Title.Replace(" ", "-").Replace("'", "") & "-lyrics"
            Dim Web = New HtmlWeb()
            Dim doc = Web.Load(url)

            Try
                ITalk_RichTextBox1.Text = doc.DocumentNode.SelectSingleNode("//div[@class='lyrics']").InnerText
            Catch ex As Exception
                ITalk_RichTextBox1.Text = "PLP não conseguiu encontrar a letra (: "
            End Try

        Else
            Arg = Arg.Replace(DiretorioPLP, "").Replace(".webm", "")
            Arg = Arg.Substring(Arg.IndexOf("\") + 1)
            Arg = Arg.Substring(Arg.IndexOf("\") + 1)
            Artista = Arg.Substring(0, Arg.IndexOf("-") - 1)
            Musica = Arg.Substring(Arg.IndexOf("-") + 1)

            'Detectar espaço inicial
            If (Musica.Substring(0, 1).Equals(" ")) Then
                Musica = Musica.Remove(0, 1)
            End If

            MsgBox(Artista)
            MsgBox(Musica)

            Dim url = "https://genius.com/" & Artista.Replace(" ", "-") & "-" & Musica.Replace(" ", "-").Replace("'", "") & "-lyrics"
            Dim Web = New HtmlWeb()
            Dim doc = Web.Load(url)

            MsgBox(url)

            Try
                ITalk_RichTextBox1.Text = doc.DocumentNode.SelectSingleNode("//div[@class='lyrics']").InnerText
            Catch ex As Exception
                ITalk_RichTextBox1.Text = "PLP não conseguiu encontrar a letra (: "
            End Try



        End If

    End Sub
End Class