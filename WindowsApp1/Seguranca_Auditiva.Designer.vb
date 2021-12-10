<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguranca_Auditiva
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(223, 57)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 30)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Alto"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(119, 57)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 30)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Médio"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 30)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Baixo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Ouvir em volume ..."
        '
        'Seguranca_Auditiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 110)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Seguranca_Auditiva"
        Me.Text = "Seguranca_Auditiva"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
End Class
