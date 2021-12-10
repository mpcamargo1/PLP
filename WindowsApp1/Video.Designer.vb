<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Video
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
        Dim ControlRenderer1 As PLP.iTalk.ControlRenderer = New PLP.iTalk.ControlRenderer()
        Dim MsColorTable1 As PLP.iTalk.MSColorTable = New PLP.iTalk.MSColorTable()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ITalk_ContextMenuStrip1 = New PLP.iTalk.iTalk_ContextMenuStrip()
        Me.AbrirVideoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaixarVideoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcluirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MetroToolTip1 = New MetroFramework.Components.MetroToolTip()
        Me.ITalk_ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1, 24)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(630, 406)
        Me.FlowLayoutPanel1.TabIndex = 65
        '
        'ITalk_ContextMenuStrip1
        '
        Me.ITalk_ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirVideoToolStripMenuItem, Me.BaixarVideoToolStripMenuItem, Me.ExcluirToolStripMenuItem})
        Me.ITalk_ContextMenuStrip1.Name = "ITalk_ContextMenuStrip1"
        ControlRenderer1.ColorTable = MsColorTable1
        ControlRenderer1.RoundedEdges = True
        Me.ITalk_ContextMenuStrip1.Renderer = ControlRenderer1
        Me.ITalk_ContextMenuStrip1.Size = New System.Drawing.Size(181, 70)
        '
        'AbrirVideoToolStripMenuItem
        '
        Me.AbrirVideoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.AbrirVideoToolStripMenuItem.Name = "AbrirVideoToolStripMenuItem"
        Me.AbrirVideoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AbrirVideoToolStripMenuItem.Text = "Abrir Video Embbed"
        '
        'BaixarVideoToolStripMenuItem
        '
        Me.BaixarVideoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.BaixarVideoToolStripMenuItem.Name = "BaixarVideoToolStripMenuItem"
        Me.BaixarVideoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BaixarVideoToolStripMenuItem.Text = "Baixar Video"
        '
        'ExcluirToolStripMenuItem
        '
        Me.ExcluirToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ExcluirToolStripMenuItem.Name = "ExcluirToolStripMenuItem"
        Me.ExcluirToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExcluirToolStripMenuItem.Text = "Excluir"
        '
        'BackgroundWorker1
        '
        '
        'Video
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 431)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "Video"
        Me.Text = "Video"
        Me.ITalk_ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ITalk_ContextMenuStrip1 As iTalk.iTalk_ContextMenuStrip
    Friend WithEvents AbrirVideoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BaixarVideoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ExcluirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MetroToolTip1 As MetroFramework.Components.MetroToolTip
End Class
