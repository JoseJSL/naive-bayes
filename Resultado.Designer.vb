<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Resultado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvMtzConf = New System.Windows.Forms.DataGridView()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.dgvMetrics = New System.Windows.Forms.DataGridView()
        CType(Me.dgvMtzConf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMetrics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMtzConf
        '
        Me.dgvMtzConf.AllowUserToAddRows = False
        Me.dgvMtzConf.AllowUserToDeleteRows = False
        Me.dgvMtzConf.AllowUserToResizeColumns = False
        Me.dgvMtzConf.AllowUserToResizeRows = False
        Me.dgvMtzConf.BackgroundColor = System.Drawing.Color.White
        Me.dgvMtzConf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMtzConf.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvMtzConf.Location = New System.Drawing.Point(12, 12)
        Me.dgvMtzConf.Name = "dgvMtzConf"
        Me.dgvMtzConf.RowHeadersWidth = 62
        Me.dgvMtzConf.RowTemplate.Height = 28
        Me.dgvMtzConf.Size = New System.Drawing.Size(185, 127)
        Me.dgvMtzConf.TabIndex = 0
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(8, 277)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(185, 37)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Regresar"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'dgvMetrics
        '
        Me.dgvMetrics.AllowUserToAddRows = False
        Me.dgvMetrics.AllowUserToDeleteRows = False
        Me.dgvMetrics.AllowUserToResizeColumns = False
        Me.dgvMetrics.AllowUserToResizeRows = False
        Me.dgvMetrics.BackgroundColor = System.Drawing.Color.White
        Me.dgvMetrics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMetrics.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvMetrics.Location = New System.Drawing.Point(12, 145)
        Me.dgvMetrics.Name = "dgvMetrics"
        Me.dgvMetrics.RowHeadersWidth = 62
        Me.dgvMetrics.RowTemplate.Height = 28
        Me.dgvMetrics.Size = New System.Drawing.Size(185, 126)
        Me.dgvMetrics.TabIndex = 2
        '
        'Resultado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 463)
        Me.Controls.Add(Me.dgvMetrics)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dgvMtzConf)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Resultado"
        Me.Text = "Resultado"
        CType(Me.dgvMtzConf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMetrics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvMtzConf As DataGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents dgvMetrics As DataGridView
End Class
