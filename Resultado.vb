Public Class Resultado
    Private Sub loadMtzConf()
        Dim row As String
        Dim count = Form1.clases.Count

        dgvMtzConf.ColumnCount = count
        dgvMtzConf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvMtzConf.AutoSize = True

        For i As Integer = 0 To count - 1
            dgvMtzConf.Columns(i).Name = "col" & Form1.clases.ElementAt(i)
            dgvMtzConf.Columns(i).HeaderText = Form1.clases.ElementAt(i)
            dgvMtzConf.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            row = ""
            For Each num In Form1.mtz_conf.ElementAt(i)
                row += num.ToString() & ","
            Next
            dgvMtzConf.Rows.Insert(i, row.Remove(row.Count - 1).Split(","))
            dgvMtzConf.Rows(i).HeaderCell.Value = Form1.clases.ElementAt(i)
        Next
    End Sub

    Private Sub loadMetrics()
        Dim precision, recall, mf1, totalPrecision, totalRecall, totalMF1 As Double
        Dim row As String
        Dim classCount = Form1.clases.Count
        Dim i As Integer

        dgvMetrics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvMetrics.AutoSize = True

        dgvMetrics.ColumnCount = 3
        dgvMetrics.Columns(0).HeaderText = "Precision"
        dgvMetrics.Columns(1).HeaderText = "Recall"
        dgvMetrics.Columns(2).HeaderText = "Medida F1"

        For i = 0 To classCount - 1
            precision = getPrecision(Form1.mtz_conf, i)
            recall = getRecall(Form1.mtz_conf, i)
            mf1 = getMF1(Form1.mtz_conf, i)

            totalPrecision += precision
            totalRecall += recall
            totalMF1 += mf1
            row = FormatPercent(precision) & "," & FormatPercent(recall) & "," & FormatPercent(mf1)

            dgvMetrics.Rows.Insert(i, row.Split(","))
            dgvMetrics.Rows(i).HeaderCell.Value = Form1.clases.ElementAt(i)
            dgvMetrics.Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        row = FormatPercent(totalPrecision / Form1.clases.Count) & "," & FormatPercent(totalRecall / Form1.clases.Count) & "," & FormatPercent(totalMF1 / Form1.clases.Count)

        dgvMetrics.Rows.Insert(i, row.Split(","))
        dgvMetrics.Rows(i).HeaderCell.Value = "Promedio"
        dgvMetrics.Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub Resultado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadMtzConf()
        loadMetrics()

        If (dgvMetrics.Width > dgvMtzConf.Width) Then
            Me.Width = dgvMetrics.Width
        Else
            Me.Width = dgvMtzConf.Width
        End If


        dgvMtzConf.AutoSize = False
        dgvMtzConf.Width = Me.Width - 16
        dgvMtzConf.Height = dgvMetrics.Height
        dgvMtzConf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


        dgvMetrics.AutoSize = False
        dgvMetrics.Width = Me.Width - 16
        dgvMetrics.Height = dgvMtzConf.Height
        dgvMetrics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMetrics.Location = New Point(dgvMtzConf.Location.X, dgvMtzConf.Location.Y + dgvMtzConf.Height + 16)

        btnBack.Location = New Point(dgvMetrics.Location.X, dgvMetrics.Location.Y + dgvMetrics.Height + 16)
        btnBack.Width = Me.Width - 16

        Me.Height = dgvMtzConf.Height + dgvMetrics.Height + btnBack.Height + 48

        Me.CenterToScreen()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
End Class