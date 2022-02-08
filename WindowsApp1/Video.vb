Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports VideoLibrary
Imports System.Reflection

Public Class Video
    Dim NewForm As BrowserCefSharp
    Public Shared video
    Public Shared ID As String
    Dim url As String
    Dim directory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\Thumbnail"
    Dim filesmp4() As System.IO.FileInfo
    Dim dirinfo As New System.IO.DirectoryInfo(directory)
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles Me.Load
        showposters()
    End Sub

    Public Sub showposters()


        filesmp4 = dirinfo.GetFiles("*.jpg", IO.SearchOption.TopDirectoryOnly)


        For Each file In filesmp4

            Dim Panel As New Panel
            Dim PictureFlowlayoutPanel1 As New PictureBox
            Dim L As New Label
            Panel.Controls.Add(L)
            Panel.Controls.Add(PictureFlowlayoutPanel1)
            Panel.Size = New Size(150, 150)
            Panel.BackColor = Color.White
            Panel.BorderStyle = BorderStyle.FixedSingle
            PictureFlowlayoutPanel1.Size = New Size(148, 148)
            PictureFlowlayoutPanel1.SizeMode = PictureBoxSizeMode.CenterImage
            PictureFlowlayoutPanel1.Image = My.Resources.YT_Icon
            PictureFlowlayoutPanel1.Name = file.Name
            PictureFlowlayoutPanel1.ContextMenuStrip = ITalk_ContextMenuStrip1
            L.BackColor = Color.Transparent
            L.ForeColor = Color.DodgerBlue
            L.Dock = DockStyle.Bottom
            L.AutoSize = False
            L.TextAlign = ContentAlignment.BottomCenter
            L.Text = Replace(file.Name, ".jpg", "")

            MetroToolTip1.IsBalloon = False
            MetroToolTip1.ToolTipIcon = ToolTipIcon.Info
            MetroToolTip1.SetToolTip(PictureFlowlayoutPanel1, L.Text)
            GC.Collect()

            AddHandler PictureFlowlayoutPanel1.DoubleClick, AddressOf Pic_DoubleClick
            Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(Sub() downloadAndDisplayPoster(Panel)))
        Next

    End Sub
    Private Sub Pic_DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Form1.Letra = 0
        Form1.LetraDireta = 0
        Form1.wmp.URL = ""

        Dim url As String
        Using ler As New StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\videos\" & CType(sender, PictureBox).Name.Replace(".jpg", ".data"))
            url = ler.ReadLine()
        End Using
        BrowserCefSharp.Label2.Text = CType(sender, PictureBox).Name.Replace(".jpg", "")
        ID = url
        ID = ID.Replace("https://www.youtube.com/watch?v=", "")



        If Application.OpenForms.OfType(Of BrowserCefSharp)().Count() = 0 Then
            Form1.ClickVideo = 0
            BrowserCefSharp.Show()
        Else
            BrowserCefSharp.WebBrowser1.Load("https://www.youtube.com/watch?v=" & ID)
        End If


    End Sub

    Private Delegate Sub displayPoster(ByVal pictureControl As Panel)

    Private Sub downloadAndDisplayPoster(ByVal pictureControl As Panel)
        If Me.InvokeRequired = True Then
            Dim delegate1 As New displayPoster(AddressOf downloadAndDisplayPoster)
            Me.Invoke(delegate1, pictureControl)
        Else
            FlowLayoutPanel1.Controls.Add(pictureControl)
        End If
    End Sub

    Private Sub AbrirVideoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirVideoToolStripMenuItem.Click
        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Using ler As New StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\videos\" & CType(sourceControl, PictureBox).Name.Replace(".jpg", ".data"))
                    ID = ler.ReadLine()
                End Using
                ID = ID.Replace("https://www.youtube.com/watch?v=", "")
                ID = "https://www.youtube.com/embed/" & ID
                Form1.UrlLetra_Video = ID
                BrowserCefSharp.Show()
            End If
        End If
    End Sub

    Private Sub BaixarVideoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BaixarVideoToolStripMenuItem.Click

        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                Using ler As New StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\videos\" & CType(sourceControl, PictureBox).Name.Replace(".jpg", ".data"))
                    ID = ler.ReadLine()
                End Using
                video = YouTube.Default.GetVideo(ID)
                BackgroundWorker1.RunWorkerAsync(video)
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        File.WriteAllBytes(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "PLP\Videos\" & video.FullName, video.GetBytes())
    End Sub

    Private Sub ExcluirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirToolStripMenuItem.Click
        Dim menuItem As ToolStripItem = TryCast(sender, ToolStripItem)
        If menuItem IsNot Nothing Then
            Dim owner As ContextMenuStrip = TryCast(menuItem.Owner, ContextMenuStrip)
            If owner IsNot Nothing Then
                Dim sourceControl As Control = owner.SourceControl
                File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\Thumbnail\" & CType(sourceControl, PictureBox).Name)
                File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\PLP\logs\videos\” & CType(sourceControl, PictureBox).Name.Replace(".jpg", ".data"))

                Dim ctls As New List(Of Control)
                Dim ctls1 As New List(Of Control)
                ctls.AddRange(FlowLayoutPanel1.Controls.OfType(Of Panel).ToArray)
                ctls1.AddRange(FlowLayoutPanel1.Controls.OfType(Of PictureBox).ToArray)
                For Each ctl As PictureBox In ctls1
                    ctl.Image = Nothing
                    ctl.Dispose()
                Next
                For Each ctl As Control In ctls
                    FlowLayoutPanel1.Controls.Remove(ctl)
                    ctl.Dispose()
                Next
                showposters()
            End If
        End If
    End Sub

    Private Sub Video_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim ctls As New List(Of Control)
        ctls.AddRange(FlowLayoutPanel1.Controls.OfType(Of Panel).ToArray)
        For Each ctl As Control In ctls
            ctl.Dispose()
            FlowLayoutPanel1.Controls.Remove(ctl)
        Next
        GC.Collect()
    End Sub
End Class