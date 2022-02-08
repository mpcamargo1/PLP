<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StreamMenu
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.MetroToolTip1 = New MetroFramework.Components.MetroToolTip()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New PLP.iTalk.iTalk_Label()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 24)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(763, 390)
        Me.FlowLayoutPanel1.TabIndex = 3
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(142, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Carregando..."
        '
        'StreamMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 447)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "StreamMenu"
        Me.Text = "Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents MetroToolTip1 As MetroFramework.Components.MetroToolTip
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As iTalk.iTalk_Label
End Class
