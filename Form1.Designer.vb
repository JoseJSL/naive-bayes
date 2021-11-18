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
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.gbSameDataset = New System.Windows.Forms.GroupBox()
        Me.txtSimplePercentge = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIntervals = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.Label1.Size = New System.Drawing.Size(90, 25)
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
        Me.txtMainRoute.Size = New System.Drawing.Size(359, 30)
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
        Me.txtExternalRoute.Size = New System.Drawing.Size(90, 30)
        Me.txtExternalRoute.TabIndex = 106
        Me.txtExternalRoute.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 25)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Dataset :"
        '
        'rbSameDataset
        '
        Me.rbSameDataset.AutoSize = True
        Me.rbSameDataset.Checked = True
        Me.rbSameDataset.Location = New System.Drawing.Point(18, 21)
        Me.rbSameDataset.Name = "rbSameDataset"
        Me.rbSameDataset.Size = New System.Drawing.Size(246, 29)
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
        Me.rbExternalDataset.Size = New System.Drawing.Size(261, 29)
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
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 47)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(200, 29)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.Text = "Validación simple :"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 21)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(203, 29)
        Me.RadioButton2.TabIndex = 4
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Validación cruzada"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'gbSameDataset
        '
        Me.gbSameDataset.Controls.Add(Me.txtSimplePercentge)
        Me.gbSameDataset.Controls.Add(Me.RadioButton2)
        Me.gbSameDataset.Controls.Add(Me.RadioButton1)
        Me.gbSameDataset.Location = New System.Drawing.Point(16, 98)
        Me.gbSameDataset.Name = "gbSameDataset"
        Me.gbSameDataset.Size = New System.Drawing.Size(252, 85)
        Me.gbSameDataset.TabIndex = 104
        Me.gbSameDataset.TabStop = False
        '
        'txtSimplePercentge
        '
        Me.txtSimplePercentge.Location = New System.Drawing.Point(145, 47)
        Me.txtSimplePercentge.Name = "txtSimplePercentge"
        Me.txtSimplePercentge.Size = New System.Drawing.Size(100, 30)
        Me.txtSimplePercentge.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(257, 25)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Intervalos de discretización :"
        '
        'txtIntervals
        '
        Me.txtIntervals.Location = New System.Drawing.Point(195, 193)
        Me.txtIntervals.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtIntervals.Name = "txtIntervals"
        Me.txtIntervals.Size = New System.Drawing.Size(51, 30)
        Me.txtIntervals.TabIndex = 108
        Me.txtIntervals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIntervals.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(401, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 24)
        Me.Button1.TabIndex = 109
        Me.Button1.Text = "Analizar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 226)
        Me.Controls.Add(Me.Button1)
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
        Me.Text = "Form1"
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
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents gbSameDataset As GroupBox
    Friend WithEvents txtSimplePercentge As TextBox
    Friend WithEvents btnLoadExternalDataset As Button
    Friend WithEvents txtExternalRoute As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIntervals As NumericUpDown
    Friend WithEvents Button1 As Button
End Class
