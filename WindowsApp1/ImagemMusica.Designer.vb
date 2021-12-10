<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImagemMusica
    Inherits System.Windows.Forms.Form

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
        Dim ControlRenderer1 As PLP.iTalk.ControlRenderer = New PLP.iTalk.ControlRenderer()
        Dim MsColorTable1 As PLP.iTalk.MSColorTable = New PLP.iTalk.MSColorTable()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ITalk_ContextMenuStrip1 = New PLP.iTalk.iTalk_ContextMenuStrip()
        Me.SalvarImagemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ITalk_ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ContextMenuStrip = Me.ITalk_ContextMenuStrip1
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(574, 296)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ITalk_ContextMenuStrip1
        '
        Me.ITalk_ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarImagemToolStripMenuItem})
        Me.ITalk_ContextMenuStrip1.Name = "ITalk_ContextMenuStrip1"
        ControlRenderer1.ColorTable = MsColorTable1
        ControlRenderer1.RoundedEdges = True
        Me.ITalk_ContextMenuStrip1.Renderer = ControlRenderer1
        Me.ITalk_ContextMenuStrip1.Size = New System.Drawing.Size(153, 26)
        '
        'SalvarImagemToolStripMenuItem
        '
        Me.SalvarImagemToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SalvarImagemToolStripMenuItem.Name = "SalvarImagemToolStripMenuItem"
        Me.SalvarImagemToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SalvarImagemToolStripMenuItem.Text = "Salvar Imagem"
        '
        'ImagemMusica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 296)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "ImagemMusica"
        Me.Text = "Álbum"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ITalk_ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ITalk_ContextMenuStrip1 As iTalk.iTalk_ContextMenuStrip
    Friend WithEvents SalvarImagemToolStripMenuItem As ToolStripMenuItem
End Class
