Public Class Form1
    Public mtz_conf As New List(Of List(Of Integer))
    Public clases As New List(Of String)
    Public mainDataset As New List(Of String())
    Public externalDataset As New List(Of String())
    Dim predict As New List(Of String)

    'Reemplaza una columna del dataset, por un arreglo tipo List(Of String), según un índice de un dataset, Ej:
    'replaceDatasetColumn(mainDataset, columna, 3)
    Private Sub replaceDatasetColumn(ByRef dataset As List(Of String()), ByVal column As List(Of String), ByVal index As Integer)
        For i As Integer = 0 To column.Count - 1
            dataset(i).SetValue(column(i), index)
        Next
    End Sub

    'Habilita y deshabilita las entradas de dataset externo / pruebas con el mismo dataset
    Private Sub rbSameDataset_CheckedChanged(sender As Object, e As EventArgs) Handles rbSameDataset.CheckedChanged
        gbSameDataset.Enabled = gbExternalDataset.Enabled
        gbExternalDataset.Enabled = Not gbExternalDataset.Enabled
    End Sub

    'Carga el dataset principal con la ruta dada
    Private Sub btnLoadMainDataset_Click(sender As Object, e As EventArgs) Handles btnLoadMainDataset.Click 'Carga el dataset especificado en un cuadro de diálogo
        If (fileOpener.ShowDialog() = DialogResult.OK) Then 'Si el usuario presionó OK en el cuadro de diálogo
            If (System.IO.File.Exists(fileOpener.FileNames.GetValue(0))) Then ' y el archivo seleccionado existe, entonces
                txtMainRoute.Text = fileOpener.FileNames.GetValue(0) ' mostramos la ruta en la caja de texto
                loadDataset(mainDataset) ' y cargamos el dataset en la variable del dataset principal.
            End If
        End If
    End Sub

    'Carga el dataset externo y se asegura que tenga el mismo número de columnas que el dataset principal
    Private Sub btnLoadExternalDataset_Click(sender As Object, e As EventArgs) Handles btnLoadExternalDataset.Click
        If (fileOpener.ShowDialog() = DialogResult.OK) Then
            If (System.IO.File.Exists(fileOpener.FileNames.GetValue(0))) Then
                txtExternalRoute.Text = fileOpener.FileNames.GetValue(0)
                loadDataset(externalDataset)
            End If

            If (mainDataset.Count > 0) Then
                If (mainDataset.ElementAt(0).Count <> externalDataset.ElementAt(0).Count) Then
                    MsgBox("La cantidad de columnas del dataset cargado es distinto al del dataset principal: operacion cancelada.", vbCritical, "Error de datasets incompatibles")
                    externalDataset = New List(Of String())
                End If
            End If
        End If
    End Sub

    'Lee un archivo de texto linea por linea, y le asigna los valores a un dataser
    Private Sub loadDataset(ByRef dataset As List(Of String()))
        Dim fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(fileOpener.FileNames.GetValue(0))
        Dim fileLine As String = fileReader.ReadLine()
        Dim fSplit As String()
        Dim columnCount = fileLine.Split(",").Count()
        dataset = New List(Of String())

        Do
            fSplit = fileLine.Split(",")

            If (Not (String.IsNullOrEmpty(fileLine) Or String.IsNullOrWhiteSpace(fileLine))) Then
                If (fSplit.Count() <> columnCount) Then
                    MsgBox("Renglón #" & (dataset.Count).ToString & " contiene el número incorrecto de columnas. Se esperaban " & columnCount.ToString & " columnas, pero se obtuvieron " & fSplit.Count() & "." & vbCrLf & "Se ha cancelado la operación", vbCritical, "Error al leer archivo")
                    dataset = New List(Of String())
                    columnCount = 0
                    fileReader.Close()
                    Exit Sub
                Else
                    dataset.Add(fSplit)
                End If
            End If

            fileLine = fileReader.ReadLine()
        Loop Until fileLine Is Nothing
        fileReader.Close()
    End Sub

    'Determina si se puede realizar la acción de analizar (predecir) y manda mensajes de error según correspondan
    Private Function canAnalize() As Boolean
        If (Not mainDataset.Count > 1) Then 'Si no hay dataset principal
            MsgBox("No se ha cargado el dataset principal.", vbCritical, "Error en dataset vacio")
            Return False
        Else
            If (rbSimpleVal.Checked) Then
                If (Not IsNumeric(txtSimplePercent.Text)) Then 'Si no hay porcentaje de entrenamiento
                    txtSimplePercent.Focus()
                    txtSimplePercent.SelectAll()
                    MsgBox("El porcentaje solo puede contener números.", vbCritical, "Error en validación simple.")
                    Return False
                End If
            ElseIf (rbExternalDataset.Checked) Then
                If (Not externalDataset.Count > 1) Then 'Si no hay dataser externo
                    MsgBox("No se ha cargado el dataset externo.", vbCritical, "Error en dataset vacio")
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    'Carga crea un listado de clases con el dataset principal, además pide confirmación al usuario sobre
    'la posición de la columna de clases (en caso de encontrar que la columna dada contenga numeros)
    Private Function loadClases() As Boolean
        Dim classIndex = 0
        Dim classPosition = "primer"
        Dim alternatePosition = "ultima"

        If (cbClassAtEnd.Checked) Then
            classIndex = mainDataset.ElementAt(0).Count - 1
            classPosition = "ultima"
            alternatePosition = "primer"
        End If

        If (IsNumeric(mainDataset.ElementAt(0).ElementAt(classIndex))) Then
            Dim q = MsgBox($"Se ha detectado un numero en el indice de la clase ({classPosition} columna).{vbCrLf}¿Quiere cambiar la posición de la clase a la {alternatePosition} columna?", vbYesNo, "Error en dataset vacio")
            If (q = MsgBoxResult.Yes) Then
                If (classIndex = 0) Then
                    classIndex = mainDataset.ElementAt(0).Count - 1
                    cbClassAtEnd.Checked = True
                Else
                    classIndex = 0
                    cbClassAtEnd.Checked = False
                End If
            End If
        End If

        clases = getClassList(getDatasetColumn(mainDataset, classIndex))
        clases.Sort()

        Return True
    End Function

    'Manda a llamar a los métodos de cálculos según sea haya establecido el usuario (externo, cruzado, simple)
    Private Sub btnAnalizar_Click(sender As Object, e As EventArgs) Handles btnAnalizar.Click
        If (Not canAnalize()) Then
            Exit Sub
        End If

        loadClases()

        If (rbSameDataset.Checked) Then
            If (rbCrossVal.Checked) Then
                calcWithSameDataSet(0.5, 0.5)
            Else
                Dim trainPercent As Double = CDbl(txtSimplePercent.Text) / 100
                calcWithSameDataSet(trainPercent, 1 - trainPercent)
            End If
        Else
            calcWithExternalDataset()
        End If
    End Sub

    'Divide el dataset principal en dos datasets, uno de entrenamiento y otro de pruebas, según el porcentaje
    'establecido por el usuario, y luego llama al calculo final con esos datasets de referencia
    Private Sub calcWithSameDataSet(ByVal trainPercent As Double, ByVal testPercent As Double)
        Dim toTrain As List(Of String())
        Dim toTest As List(Of String())
        Dim start = 1, minus = 1 'Si la clase está a la izquierda, empezamos en la segunda columna y terminamos en la última

        If (cbClassAtEnd.Checked) Then 'Si la clase está a la derecha, empezamos en la primer columna y terminamos en la penúltima
            start = 0
            minus = 2
        End If

        'Division del dataset principal en uno para entrenamiento y otro para pruebas
        divideDatasetForTesting(mainDataset, toTrain, toTest, trainPercent, testPercent, start, minus)
        calcularFinal(toTest, toTrain)
    End Sub

    'Manda a llamar el calculo final con los dataset externo y principal como dataset de prueba y de
    'entrenamiento respectivamente
    Private Sub calcWithExternalDataset()
        calcularFinal(externalDataset, mainDataset)
    End Sub

    'Ensambla el cubo de OLAP de posibilidades y el listado de categorias para luego llamar al calculo de predicción
    Private Sub calcularFinal(ByRef toTest As List(Of String()), ByRef toTrain As List(Of String()))
        Dim listOfChances As New List(Of List(Of List(Of Double))) '-> I:Columna, J: Clase, K: Categoria
        Dim listOfCategories As New List(Of List(Of Double))
        Dim datasetColumn As List(Of String)
        Dim categoryCountPerClass As List(Of List(Of Integer))
        Dim categoryList As List(Of Double)
        Dim start = 1, minus = 1, classIndex = 0 'Si la clase está a la izquierda, empezamos en la segunda columna y terminamos en la última

        If (cbClassAtEnd.Checked) Then 'Si la clase está a la derecha, empezamos en la primer columna y terminamos en la penúltima
            start = 0
            minus = 2
            classIndex = mainDataset.ElementAt(0).Count - 1
        End If

        Dim toTrainClassColumn = getDatasetColumn(toTrain, classIndex)
        For i As Integer = start To toTrain.ElementAt(0).Count - minus
            datasetColumn = getDatasetColumn(toTrain, i)
            If (IsNumeric(datasetColumn.ElementAt(0))) Then
                calcAnchosIguales(datasetColumn, toTrainClassColumn, categoryCountPerClass, categoryList, clases, CInt(txtIntervals.Text), clases.Count)
            Else
                calcDiscretizedColumn(datasetColumn, toTrainClassColumn, categoryCountPerClass, categoryList, clases, clases.Count)
            End If

            listOfCategories.Add(categoryList)
            listOfChances.Add(calcChanceOf(toTrainClassColumn, categoryCountPerClass, categoryList, clases))
        Next

        Dim toTestClassColumn = getDatasetColumn(toTest, classIndex)
        Dim predictions = calcPredictions(toTest, listOfChances, listOfCategories, clases, toTestClassColumn, start, minus)
        mtz_conf = calcMtzConf(clases, predictions, toTestClassColumn)
        MsgBox("Accuracy: " & FormatPercent(getAccuracy(mtz_conf, toTest.Count)))
        Resultado.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub txtSimplePercent_GotFocus(sender As Object, e As EventArgs) Handles txtSimplePercent.GotFocus
        If (txtSimplePercent.Text = "Porc. entr.") Then
            txtSimplePercent.Clear()
        End If
    End Sub

    Private Sub txtSimplePercent_LostFocus(sender As Object, e As EventArgs) Handles txtSimplePercent.LostFocus
        If (String.IsNullOrWhiteSpace(txtSimplePercent.Text) Or String.IsNullOrEmpty(txtSimplePercent.Text)) Then
            txtSimplePercent.Text = "Porc. entr."
        End If
    End Sub
End Class
