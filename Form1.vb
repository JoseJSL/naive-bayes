Public Class Form1
    Dim mainDataset As New List(Of String())
    Dim externalDataset As New List(Of String())
    Dim columnCount As Integer = 0
    Dim frecuencias() As Int32
    Dim predict As New List(Of String)
    Dim mtz_conf As New List(Of Integer())
    Dim clases As New List(Of String)

    'Reemplaza una columna del dataset, por un arreglo tipo List(Of String), según un índice de un dataset, Ej:
    'replaceDatasetColumn(mainDataset, columna, 3)
    Private Sub replaceDatasetColumn(ByRef dataset As List(Of String()), ByVal column As List(Of String), ByVal index As Integer)
        For i As Integer = 0 To column.Count - 1
            dataset(i).SetValue(column(i), index)
        Next
    End Sub

    Private Sub rbSameDataset_CheckedChanged(sender As Object, e As EventArgs) Handles rbSameDataset.CheckedChanged
        gbSameDataset.Enabled = gbExternalDataset.Enabled
        gbExternalDataset.Enabled = Not gbExternalDataset.Enabled
    End Sub

    Private Sub btnLoadMainDataset_Click(sender As Object, e As EventArgs) Handles btnLoadMainDataset.Click 'Carga el dataset especificado en un cuadro de diálogo
        If (fileOpener.ShowDialog() = DialogResult.OK) Then 'Si el usuario presionó OK en el cuadro de diálogo
            If (System.IO.File.Exists(fileOpener.FileNames.GetValue(0))) Then ' y el archivo seleccionado existe, entonces
                txtMainRoute.Text = fileOpener.FileNames.GetValue(0) ' mostramos la ruta en la caja de texto
                loadDataset(mainDataset) ' y cargamos el dataset en la variable del dataset principal.
            End If
        End If
    End Sub

    Private Sub btnLoadExternalDataset_Click(sender As Object, e As EventArgs) Handles btnLoadExternalDataset.Click
        If (fileOpener.ShowDialog() = DialogResult.OK) Then
            If (System.IO.File.Exists(fileOpener.FileNames.GetValue(0))) Then
                txtExternalRoute.Text = fileOpener.FileNames.GetValue(0)
                loadDataset(externalDataset)
            End If
        End If
    End Sub

    Private Sub loadDataset(ByRef dataset As List(Of String()))
        Dim fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(fileOpener.FileNames.GetValue(0))
        Dim fileLine As String = fileReader.ReadLine()

        If (columnCount = 0) Then
            columnCount = fileLine.Split(",").Count()
        End If

        Do
            dataset.Add(fileLine.Split(","))

            If (dataset.Last().Count <> columnCount) Then
                MsgBox("Renglón #" & (dataset.Count + 1).ToString & " contiene el número incorrecto de columnas. Se esperaban " & columnCount.ToString & " columnas, pero se obtuvieron " & dataset.Last().Count() & "." & vbCrLf & "Se ha cancelado la operación", vbCritical, "Error al leer archivo")
                dataset = New List(Of String())
                columnCount = 0
                Exit Sub
            End If

            fileLine = fileReader.ReadLine()
        Loop Until fileLine Is Nothing
        fileReader.Close()
    End Sub

    Private Sub btnAnalizar_Click(sender As Object, e As EventArgs) Handles btnAnalizar.Click
        tryGetClasses()

        If (rbSameDataset.Checked) Then
            If (rbCrossVal.Checked) Then
                calcWithSameDataSet(0.5, 0.5)
            Else
                If (Not IsNumeric(txtSimplePercent.Text)) Then
                    txtSimplePercent.Focus()
                    txtSimplePercent.SelectAll()
                    MsgBox("El porcentaje solo puede contener números.", vbCritical, "Error en validación simple.")
                    Exit Sub
                End If

                Dim trainPercent As Double = CDbl(txtSimplePercent.Text) / 100
                calcWithSameDataSet(trainPercent, 1 - trainPercent)
            End If
        Else
            calcWithExternalDataset()
        End If
    End Sub

    Private Sub calcWithSameDataSet(ByVal trainPercent As Double, ByVal testPercent As Double)
        Dim listOfChances As New List(Of List(Of List(Of Double))) '-> I:Columna, J: Clase, K: Categoria
        Dim datasetColumn As List(Of String)
        Dim categoryCountPerClass As List(Of List(Of Integer))
        Dim categoryList As List(Of Double)
        Dim classIndex As Integer
        Dim start = 1, minus = 1 'Si la clase está a la izquierda, empezamos en la segunda columna y terminamos en la última

        If (cbClassAtEnd.Checked) Then 'Si la clase está a la derecha, empezamos en la primer columna y terminamos en la penúltima
            start = 0
            minus = 2
            classIndex = clases.Count - 1
        Else
            classIndex = 0
        End If

        Dim classColumn = getDatasetColumn(mainDataset, classIndex)
        For i As Integer = start To mainDataset.ElementAt(0).Count - minus
            datasetColumn = getDatasetColumn(mainDataset, i)
            If (IsNumeric(datasetColumn.ElementAt(i))) Then
                calcAnchosIguales(datasetColumn, classColumn, categoryCountPerClass, categoryList, clases, CInt(txtIntervals.Text), clases.Count)
                listOfChances.Add(calcChanceOf(classColumn, categoryCountPerClass, categoryList, clases))
            End If
        Next
    End Sub

    Private Sub calcWithExternalDataset()

    End Sub

    Private Sub tryGetClasses()
        If (Not clases.Count > 0) Then
            Dim classArray As List(Of String) = getDatasetColumn(mainDataset, 0)
            If (Not cbClassAtEnd.Checked) Then
                clases = getClassList(classArray)
            Else
                clases = getClassList(classArray)
            End If
        End If
    End Sub

End Class
