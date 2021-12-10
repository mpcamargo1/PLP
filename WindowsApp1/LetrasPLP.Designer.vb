<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LetrasPLP
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
        Me.ITalk_RichTextBox1 = New PLP.iTalk.iTalk_RichTextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'ITalk_RichTextBox1
        '
        Me.ITalk_RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ITalk_RichTextBox1.AutoWordSelection = False
        Me.ITalk_RichTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.ITalk_RichTextBox1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ITalk_RichTextBox1.ForeColor = System.Drawing.Color.DimGray
        Me.ITalk_RichTextBox1.Location = New System.Drawing.Point(3, 28)
        Me.ITalk_RichTextBox1.Name = "ITalk_RichTextBox1"
        Me.ITalk_RichTextBox1.ReadOnly = False
        Me.ITalk_RichTextBox1.Size = New System.Drawing.Size(470, 312)
        Me.ITalk_RichTextBox1.TabIndex = 0
        Me.ITalk_RichTextBox1.Text = "Carregando..."
        Me.ITalk_RichTextBox1.WordWrap = True
        '
        'BackgroundWorker1
        '
        '
        'LetrasPLP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 363)
        Me.Controls.Add(Me.ITalk_RichTextBox1)
        Me.Name = "LetrasPLP"
        Me.Text = "LetrasPLP"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ITalk_RichTextBox1 As iTalk.iTalk_RichTextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
