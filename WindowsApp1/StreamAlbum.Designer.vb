<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StreamAlbum
    Inherits MetroFramework.Forms.MetroForm

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MetroToolTip1 = New MetroFramework.Components.MetroToolTip()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.Status = New PLP.iTalk.iTalk_Label()
        Me.Ouvintes = New PLP.iTalk.iTalk_Label()
        Me.Faixas = New PLP.iTalk.iTalk_Label()
        Me.Data = New PLP.iTalk.iTalk_Label()
        Me.Album = New PLP.iTalk.iTalk_Label()
        Me.Artista = New PLP.iTalk.iTalk_Label()
        Me.TimerStatus = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker4 = New System.ComponentModel.BackgroundWorker()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(23, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(151, 132)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(24, 174)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(635, 190)
        Me.FlowLayoutPanel1.TabIndex = 4
        '
        'BackgroundWorker1
        '
        '
        'MetroToolTip1
        '
        Me.MetroToolTip1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroToolTip1.StyleManager = Nothing
        Me.MetroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'BackgroundWorker2
        '
        '
        'BackgroundWorker3
        '
        '
        'Status
        '
        Me.Status.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Status.AutoSize = True
        Me.Status.BackColor = System.Drawing.Color.Transparent
        Me.Status.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Status.Location = New System.Drawing.Point(23, 367)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(60, 13)
        Me.Status.TabIndex = 8
        Me.Status.Text = "Obtendo :"
        Me.Status.Visible = False
        '
        'Ouvintes
        '
        Me.Ouvintes.AutoSize = True
        Me.Ouvintes.BackColor = System.Drawing.Color.Transparent
        Me.Ouvintes.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Ouvintes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Ouvintes.Location = New System.Drawing.Point(210, 130)
        Me.Ouvintes.Name = "Ouvintes"
        Me.Ouvintes.Size = New System.Drawing.Size(53, 13)
        Me.Ouvintes.TabIndex = 7
        Me.Ouvintes.Text = "Ouvintes"
        '
        'Faixas
        '
        Me.Faixas.AutoSize = True
        Me.Faixas.BackColor = System.Drawing.Color.Transparent
        Me.Faixas.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Faixas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Faixas.Location = New System.Drawing.Point(211, 81)
        Me.Faixas.Name = "Faixas"
        Me.Faixas.Size = New System.Drawing.Size(38, 13)
        Me.Faixas.TabIndex = 6
        Me.Faixas.Text = "Faixas"
        '
        'Data
        '
        Me.Data.AutoSize = True
        Me.Data.BackColor = System.Drawing.Color.Transparent
        Me.Data.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Data.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Data.Location = New System.Drawing.Point(211, 106)
        Me.Data.Name = "Data"
        Me.Data.Size = New System.Drawing.Size(31, 13)
        Me.Data.TabIndex = 5
        Me.Data.Text = "Data"
        '
        'Album
        '
        Me.Album.AutoSize = True
        Me.Album.BackColor = System.Drawing.Color.Transparent
        Me.Album.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Album.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Album.Location = New System.Drawing.Point(214, 55)
        Me.Album.Name = "Album"
        Me.Album.Size = New System.Drawing.Size(40, 13)
        Me.Album.TabIndex = 3
        Me.Album.Text = "Album"
        '
        'Artista
        '
        Me.Artista.AutoSize = True
        Me.Artista.BackColor = System.Drawing.Color.Transparent
        Me.Artista.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Artista.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Artista.Location = New System.Drawing.Point(215, 31)
        Me.Artista.Name = "Artista"
        Me.Artista.Size = New System.Drawing.Size(40, 13)
        Me.Artista.TabIndex = 1
        Me.Artista.Text = "Artista"
        '
        'TimerStatus
        '
        Me.TimerStatus.Interval = 1000
        '
        'BackgroundWorker4
        '
        '
        'StreamAlbum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 387)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Ouvintes)
        Me.Controls.Add(Me.Faixas)
        Me.Controls.Add(Me.Data)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Album)
        Me.Controls.Add(Me.Artista)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "StreamAlbum"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Artista As iTalk.iTalk_Label
    Friend WithEvents Album As iTalk.iTalk_Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Data As iTalk.iTalk_Label
    Friend WithEvents Faixas As iTalk.iTalk_Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Ouvintes As iTalk.iTalk_Label
    Friend WithEvents MetroToolTip1 As MetroFramework.Components.MetroToolTip
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Status As iTalk.iTalk_Label
    Friend WithEvents TimerStatus As Timer
    Friend WithEvents BackgroundWorker4 As System.ComponentModel.BackgroundWorker
End Class
