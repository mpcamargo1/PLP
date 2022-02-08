<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configs
    Inherits MetroFramework.Forms.MetroForm

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configs))
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile2 = New MetroFramework.Controls.MetroTile()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTile3 = New MetroFramework.Controls.MetroTile()
        Me.MetroToolTip1 = New MetroFramework.Components.MetroToolTip()
        Me.SuspendLayout()
        '
        'MetroTile1
        '
        Me.MetroTile1.Location = New System.Drawing.Point(23, 95)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(140, 110)
        Me.MetroTile1.TabIndex = 0
        Me.MetroTile1.TileImage = CType(resources.GetObject("MetroTile1.TileImage"), System.Drawing.Image)
        Me.MetroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroToolTip1.SetToolTip(Me.MetroTile1, "Youtube")
        Me.MetroTile1.UseTileImage = True
        '
        'MetroTile2
        '
        Me.MetroTile2.Location = New System.Drawing.Point(23, 236)
        Me.MetroTile2.Name = "MetroTile2"
        Me.MetroTile2.Size = New System.Drawing.Size(140, 131)
        Me.MetroTile2.TabIndex = 1
        Me.MetroTile2.TileImage = CType(resources.GetObject("MetroTile2.TileImage"), System.Drawing.Image)
        Me.MetroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroToolTip1.SetToolTip(Me.MetroTile2, "Genius")
        Me.MetroTile2.UseTileImage = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(23, 60)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(48, 19)
        Me.MetroLabel1.TabIndex = 2
        Me.MetroLabel1.Text = "Videos"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(23, 212)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(43, 19)
        Me.MetroLabel2.TabIndex = 3
        Me.MetroLabel2.Text = "Letras"
        '
        'MetroTile3
        '
        Me.MetroTile3.Location = New System.Drawing.Point(225, 236)
        Me.MetroTile3.Name = "MetroTile3"
        Me.MetroTile3.Size = New System.Drawing.Size(140, 132)
        Me.MetroTile3.TabIndex = 4
        Me.MetroTile3.TileImage = CType(resources.GetObject("MetroTile3.TileImage"), System.Drawing.Image)
        Me.MetroTile3.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroToolTip1.SetToolTip(Me.MetroTile3, "MusiXmatch")
        Me.MetroTile3.UseTileImage = True
        '
        'Configs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 441)
        Me.Controls.Add(Me.MetroTile3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroTile2)
        Me.Controls.Add(Me.MetroTile1)
        Me.Name = "Configs"
        Me.Text = "Configs"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile2 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroToolTip1 As MetroFramework.Components.MetroToolTip
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTile3 As MetroFramework.Controls.MetroTile
End Class
