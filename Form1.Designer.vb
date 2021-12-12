<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fileOpener = New System.Windows.Forms.OpenFileDialog()
        Me.txtMainRoute = New System.Windows.Forms.TextBox()
        Me.btnLoadMainDataset = New System.Windows.Forms.Button()
        Me.gbExternalDataset = New System.Windows.Forms.GroupBox()
        Me.btnLoadExternalDataset = New System.Windows.Forms.Button()
        Me.txtExternalRoute = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbSameDataset = New System.Windows.Forms.RadioButton()
        Me.rbExternalDataset = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSimpleVal = New System.Windows.Forms.RadioButton()
        Me.rbCrossVal = New System.Windows.Forms.RadioButton()
        Me.gbSameDataset = New System.Windows.Forms.GroupBox()
        Me.txtSimplePercent = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIntervals = New System.Windows.Forms.NumericUpDown()
        Me.btnAnalizar = New System.Windows.Forms.Button()
        Me.cbClassAtEnd = New System.Windows.Forms.CheckBox()
        Me.gbExternalDataset.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbSameDataset.SuspendLayout()
        CType(Me.txtIntervals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dataset :"
        '
        'fileOpener
        '
        Me.fileOpener.FileName = "dataset"
        '
        'txtMainRoute
        '
        Me.txtMainRoute.BackColor = System.Drawing.Color.White
        Me.txtMainRoute.Location = New System.Drawing.Point(81, 16)
        Me.txtMainRoute.Name = "txtMainRoute"
        Me.txtMainRoute.ReadOnly = True
        Me.txtMainRoute.Size = New System.Drawing.Size(359, 22)
        Me.txtMainRoute.TabIndex = 101
        Me.txtMainRoute.TabStop = False
        '
        'btnLoadMainDataset
        '
        Me.btnLoadMainDataset.Location = New System.Drawing.Point(452, 15)
        Me.btnLoadMainDataset.Name = "btnLoadMainDataset"
        Me.btnLoadMainDataset.Size = New System.Drawing.Size(75, 24)
        Me.btnLoadMainDataset.TabIndex = 1
        Me.btnLoadMainDataset.Text = "Abrir..."
        Me.btnLoadMainDataset.UseVisualStyleBackColor = True
        '
        'gbExternalDataset
        '
        Me.gbExternalDataset.Controls.Add(Me.btnLoadExternalDataset)
        Me.gbExternalDataset.Controls.Add(Me.txtExternalRoute)
        Me.gbExternalDataset.Controls.Add(Me.Label2)
        Me.gbExternalDataset.Location = New System.Drawing.Point(271, 98)
        Me.gbExternalDataset.Name = "gbExternalDataset"
        Me.gbExternalDataset.Size = New System.Drawing.Size(252, 85)
        Me.gbExternalDataset.TabIndex = 105
        Me.gbExternalDataset.TabStop = False
        '
        'btnLoadExternalDataset
        '
        Me.btnLoadExternalDataset.Location = New System.Drawing.Point(171, 35)
        Me.btnLoadExternalDataset.Name = "btnLoadExternalDataset"
        Me.btnLoadExternalDataset.Size = New System.Drawing.Size(75, 24)
        Me.btnLoadExternalDataset.TabIndex = 7
        Me.btnLoadExternalDataset.Text = "Abrir..."
        Me.btnLoadExternalDataset.UseVisualStyleBackColor = True
        '
        'txtExternalRoute
        '
        Me.txtExternalRoute.BackColor = System.Drawing.Color.White
        Me.txtExternalRoute.Location = New System.Drawing.Point(75, 36)
        Me.txtExternalRoute.Name = "txtExternalRoute"
        Me.txtExternalRoute.ReadOnly = True
        Me.txtExternalRoute.Size = New System.Drawing.Size(90, 22)
        Me.txtExternalRoute.TabIndex = 106
        Me.txtExternalRoute.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Dataset :"
        '
        'rbSameDataset
        '
        Me.rbSameDataset.AutoSize = True
        Me.rbSameDataset.Checked = True
        Me.rbSameDataset.Location = New System.Drawing.Point(18, 21)
        Me.rbSameDataset.Name = "rbSameDataset"
        Me.rbSameDataset.Size = New System.Drawing.Size(171, 20)
        Me.rbSameDataset.TabIndex = 2
        Me.rbSameDataset.TabStop = True
        Me.rbSameDataset.Text = "Utilizar el mismo dataset"
        Me.rbSameDataset.UseVisualStyleBackColor = True
        '
        'rbExternalDataset
        '
        Me.rbExternalDataset.AutoSize = True
        Me.rbExternalDataset.Location = New System.Drawing.Point(323, 22)
        Me.rbExternalDataset.Name = "rbExternalDataset"
        Me.rbExternalDataset.Size = New System.Drawing.Size(178, 20)
        Me.rbExternalDataset.TabIndex = 3
        Me.rbExternalDataset.Text = "Utilizar un dataset externo"
        Me.rbExternalDataset.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbExternalDataset)
        Me.GroupBox1.Controls.Add(Me.rbSameDataset)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 48)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pruebas"
        '
        'rbSimpleVal
        '
        Me.rbSimpleVal.AutoSize = True
        Me.rbSimpleVal.Location = New System.Drawing.Point(6, 47)
        Me.rbSimpleVal.Name = "rbSimpleVal"
        Me.rbSimpleVal.Size = New System.Drawing.Size(139, 20)
        Me.rbSimpleVal.TabIndex = 5
        Me.rbSimpleVal.Text = "Validación simple :"
        Me.rbSimpleVal.UseVisualStyleBackColor = True
        '
        'rbCrossVal
        '
        Me.rbCrossVal.AutoSize = True
        Me.rbCrossVal.Checked = True
        Me.rbCrossVal.Location = New System.Drawing.Point(6, 21)
        Me.rbCrossVal.Name = "rbCrossVal"
        Me.rbCrossVal.Size = New System.Drawing.Size(141, 20)
        Me.rbCrossVal.TabIndex = 4
        Me.rbCrossVal.TabStop = True
        Me.rbCrossVal.Text = "Validación cruzada"
        Me.rbCrossVal.UseVisualStyleBackColor = True
        '
        'gbSameDataset
        '
        Me.gbSameDataset.Controls.Add(Me.txtSimplePercent)
        Me.gbSameDataset.Controls.Add(Me.rbCrossVal)
        Me.gbSameDataset.Controls.Add(Me.rbSimpleVal)
        Me.gbSameDataset.Location = New System.Drawing.Point(16, 98)
        Me.gbSameDataset.Name = "gbSameDataset"
        Me.gbSameDataset.Size = New System.Drawing.Size(252, 85)
        Me.gbSameDataset.TabIndex = 104
        Me.gbSameDataset.TabStop = False
        '
        'txtSimplePercent
        '
        Me.txtSimplePercent.Location = New System.Drawing.Point(145, 47)
        Me.txtSimplePercent.Name = "txtSimplePercent"
        Me.txtSimplePercent.Size = New System.Drawing.Size(100, 22)
        Me.txtSimplePercent.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 16)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Intervalos de discretización :"
        '
        'txtIntervals
        '
        Me.txtIntervals.Location = New System.Drawing.Point(195, 193)
        Me.txtIntervals.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtIntervals.Name = "txtIntervals"
        Me.txtIntervals.Size = New System.Drawing.Size(51, 22)
        Me.txtIntervals.TabIndex = 108
        Me.txtIntervals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIntervals.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnAnalizar
        '
        Me.btnAnalizar.Location = New System.Drawing.Point(401, 191)
        Me.btnAnalizar.Name = "btnAnalizar"
        Me.btnAnalizar.Size = New System.Drawing.Size(126, 24)
        Me.btnAnalizar.TabIndex = 109
        Me.btnAnalizar.Text = "Analizar"
        Me.btnAnalizar.UseVisualStyleBackColor = True
        '
        'cbClassAtEnd
        '
        Me.cbClassAtEnd.AutoSize = True
        Me.cbClassAtEnd.Location = New System.Drawing.Point(252, 194)
        Me.cbClassAtEnd.Name = "cbClassAtEnd"
        Me.cbClassAtEnd.Size = New System.Drawing.Size(147, 20)
        Me.cbClassAtEnd.TabIndex = 110
        Me.cbClassAtEnd.Text = "Clases a la derecha"
        Me.cbClassAtEnd.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 226)
        Me.Controls.Add(Me.cbClassAtEnd)
        Me.Controls.Add(Me.btnAnalizar)
        Me.Controls.Add(Me.txtIntervals)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbExternalDataset)
        Me.Controls.Add(Me.gbSameDataset)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoadMainDataset)
        Me.Controls.Add(Me.txtMainRoute)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Naive Bayes"
        Me.gbExternalDataset.ResumeLayout(False)
        Me.gbExternalDataset.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSameDataset.ResumeLayout(False)
        Me.gbSameDataset.PerformLayout()
        CType(Me.txtIntervals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents fileOpener As OpenFileDialog
    Friend WithEvents txtMainRoute As TextBox
    Friend WithEvents btnLoadMainDataset As Button
    Friend WithEvents gbExternalDataset As GroupBox
    Friend WithEvents rbSameDataset As RadioButton
    Friend WithEvents rbExternalDataset As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbSimpleVal As RadioButton
    Friend WithEvents rbCrossVal As RadioButton
    Friend WithEvents gbSameDataset As GroupBox
    Friend WithEvents txtSimplePercent As TextBox
    Friend WithEvents btnLoadExternalDataset As Button
    Friend WithEvents txtExternalRoute As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIntervals As NumericUpDown
    Friend WithEvents btnAnalizar As Button
    Friend WithEvents cbClassAtEnd As CheckBox
End Class
