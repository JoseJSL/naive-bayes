Module NaiveModuvle
    Dim categorias As New List(Of Double)
    Dim classCountPerCategory As New List(Of Integer)

    'Regresa un arreglo tipo List(Of String), según un índice de un dataset, Ej:
    'Dim columna As List(Of String) = getDatasetColumn(mainDataset, 3)
    Public Function getDatasetColumn(ByVal dataset As List(Of String()), ByVal index As Integer) As List(Of String)
        Dim iRow As New List(Of String)

        For Each row In dataset
            iRow.Add(row.GetValue(index))
        Next
        Return iRow
    End Function

    'Modifica categoryCountPerClass y categoryList para que:
    '   - categoryCountPerClass lleve el conteo de cuántas veces se repite una categoría por cada clase
    '   - categoryList tenga el listado de categorias
    'Esto por cada columna del Dataset, según la cantidad de intervalos especificados
    Public Sub calcAnchosIguales(ByRef datasetColumn As List(Of String), ByRef datasetClassColumn As List(Of String), ByRef categoryCountPerClass As List(Of List(Of Integer)), ByRef categoryList As List(Of Double), ByRef classList As List(Of String), ByVal intervalCount As Integer, ByVal classCount As Integer)
        Dim range, catRange, max, min As Double
        Dim numericDatasetColumn As New List(Of Double)

        For Each Num In datasetColumn
            numericDatasetColumn.Add(CDbl(Num))
        Next

        max = numericDatasetColumn.Max()
        min = numericDatasetColumn.Min()

        range = (max - min) / intervalCount

        categoryCountPerClass = New List(Of List(Of Integer))
        categoryList = New List(Of Double)

        catRange = min
        For i As Integer = 0 To intervalCount - 1
            catRange += range
            categoryList.Add(catRange)
        Next

        For i As Integer = 0 To classCount - 1
            categoryCountPerClass.Add(New List(Of Integer))
            For j As Integer = 0 To categoryList.Count - 1
                categoryCountPerClass.Item(i).Add(0)
            Next
        Next

        For i As Integer = 0 To numericDatasetColumn.Count - 1
            For j As Integer = 0 To categoryList.Count - 1
                If (numericDatasetColumn.ElementAt(i) < categoryList.ElementAt(j)) Then
                    Dim ind1 = getClassIndex(datasetClassColumn.ElementAt(i), classList)
                    categoryCountPerClass.ElementAt(ind1).Item(j) += 1
                    Exit For
                End If
            Next
        Next
    End Sub

    Public Function getClassCount(ByRef datasetClassColumn As List(Of String), ByVal oClass As String) As Integer
        Dim count = 0
        For Each c In datasetClassColumn
            If (c = oClass) Then
                count += 1
            End If
        Next

        Return count
    End Function

    Public Function calcChanceOf(ByRef datasetClassColumn As List(Of String), ByRef categoryCountPerClass As List(Of List(Of Integer)), ByRef categoryList As List(Of Double), ByRef classList As List(Of String)) As List(Of List(Of Double))
        Dim chanceOf As New List(Of List(Of Double))
        Dim chance As Double
        Dim count As Integer

        For i As Integer = 0 To classList.Count - 1
            count = getClassCount(datasetClassColumn, classList.ElementAt(i))
            chanceOf.Add(New List(Of Double))

            For j As Integer = 0 To categoryCountPerClass.ElementAt(i).Count - 1
                '+1 y +categoryList.Count para agregar evitar 0 con el método de Laplace
                chance = (categoryCountPerClass.ElementAt(i).ElementAt(j) + 1) / (count + categoryList.Count)
                chanceOf.ElementAt(i).Add(chance)
            Next
        Next

        Return chanceOf
    End Function

    Public Function anchos_iguales(ByVal arreglo As List(Of String), ByVal n_intervalos As Integer) As List(Of Char)
        Dim rango, max, min As Double
        Dim arreglo_numero As New List(Of Double)

        For Each num In arreglo
            arreglo_numero.Add(CDbl(num))
        Next

        max = arreglo_numero.Max()
        min = arreglo_numero.Min()


        rango = (max - min) / n_intervalos

        Dim arreglo_nuevo As New List(Of Char)
        Dim cat As Double = min

        'Vaciar arreglos de categorías antes de usar
        categorias.Clear()
        classCountPerCategory.Clear()

        For i = 0 To n_intervalos - 1 Step 1
            cat += rango
            categorias.Add(cat)
            classCountPerCategory.Add(0)
        Next


        For Each num In arreglo_numero
            For i = 0 To n_intervalos - 1 Step 1
                If num < categorias.ElementAt(i) Then
                    arreglo_nuevo.Add(Chr(65 + i))
                    classCountPerCategory.Item(i) += 1
                    Exit For
                End If
            Next
        Next

        Return arreglo_nuevo
    End Function

    Public Function getClassList(ByRef classArray As List(Of String)) As List(Of String)
        Dim classList As New List(Of String)

        For Each oClass In classArray
            If (classList.IndexOf(oClass) = -1) Then
                classList.Add(oClass)
            End If
        Next

        Return classList
    End Function

    Public Function calcMtzConf(ByRef clases As List(Of String), ByRef predict As List(Of String), ByRef original As List(Of String)) As List(Of List(Of Integer))
        Dim mtz_conf As New List(Of List(Of Integer))
        Dim ico, ifi As Integer

        For i As Integer = 0 To clases.Count - 1
            mtz_conf.Add(New List(Of Integer))
            For j As Integer = 0 To clases.Count - 1
                mtz_conf.ElementAt(i).Add(0)
            Next
        Next

        For i = 0 To predict.Count - 1
            'MsgBox(predict.ElementAt(i) & " == " & original.ElementAt(i))
            If predict.ElementAt(i) = original.ElementAt(i) Then
                ico = getClassIndex(predict.ElementAt(i), clases)
                mtz_conf.Item(ico).Item(ico) += 1
            Else
                ico = getClassIndex(predict.ElementAt(i), clases)
                ifi = getClassIndex(original.ElementAt(i), clases)
                mtz_conf.Item(ico).Item(ifi) += 1
            End If
        Next

        Return mtz_conf
    End Function

    Public Function getTP(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Integer
        Return mtz_conf.ElementAt(ind).ElementAt(ind)
    End Function

    Public Function getTN(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Integer
        Dim trun As Double

        For Each columna In mtz_conf
            For Each fila In columna
                trun += fila
            Next
        Next

        trun -= (getTP(mtz_conf, ind) + getFP(mtz_conf, ind) + getFN(mtz_conf, ind))

        Return trun
    End Function

    Public Function getFP(ByRef mtz_conf As List(Of List(Of Integer)), ByRef inf As Integer) As Integer
        Dim falp As Double

        For inc = 0 To mtz_conf.Count - 1
            falp += mtz_conf.ElementAt(inf).ElementAt(inc)
        Next

        falp -= getTP(mtz_conf, inf)

        Return falp
    End Function

    Public Function getFN(ByRef mtz_conf As List(Of List(Of Integer)), ByRef inc As Integer) As Integer
        Dim faln As Double

        For inf = 0 To mtz_conf.Count - 1
            faln += mtz_conf.ElementAt(inf).ElementAt(inc)
        Next

        faln -= getTP(mtz_conf, inc)

        Return faln
    End Function

    Public Function getPrecision(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Double
        Dim preci, trupo As Double

        trupo = getTP(mtz_conf, ind)
        preci = trupo / (getFP(mtz_conf, ind) + trupo)

        Return preci
    End Function

    Public Function getRecall(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Double
        Dim rec, trupo As Double

        trupo = getTP(mtz_conf, ind)
        rec = trupo / (getFN(mtz_conf, ind) + trupo)

        Return rec
    End Function

    Public Function getMF1(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Double
        Dim medf, preci, recal As Double

        preci = getPrecision(mtz_conf, ind)
        recal = getRecall(mtz_conf, ind)

        medf = 2 * preci * recal / (preci + recal)

        Return medf
    End Function

    Public Function getAccuracy(ByRef mtz_conf As List(Of List(Of Integer)), ByRef totalFilas As Integer) As Double
        Dim accu As Double
        Dim tepes As Integer

        For i = 0 To mtz_conf.Count - 1
            tepes += getTP(mtz_conf, i)
        Next

        accu = tepes / totalFilas

        Return accu
    End Function

    Public Sub divideDatasetForTesting(ByVal dataset As List(Of String()), ByRef toTrain As List(Of String()), ByRef toTest As List(Of String()), ByVal trainPercent As Double, ByVal testPercent As Double, ByVal startOfFor As Integer, ByVal minusFor As Integer)
        Dim rowCount = dataset.Count
        Dim totalToTrain = Math.Truncate(rowCount * trainPercent)
        Dim totalToTest = Math.Truncate(rowCount * testPercent)
        Dim i As Integer

        While (totalToTrain + totalToTest < rowCount)
            totalToTrain += 1
        End While

        shuffleList(dataset)
        toTest = New List(Of String())
        toTrain = New List(Of String())

        For i = 0 To totalToTrain - 1
            toTrain.Add(dataset.ElementAt(i))
        Next

        For i = i To rowCount - 1
            toTest.Add(dataset.ElementAt(i))
        Next
    End Sub

    Private Sub shuffleList(ByRef data As List(Of String()))
        Randomize()
        Dim j, count As Integer
        Dim r = New Random()
        Dim tmp As String()

        count = data.Count - 1
        For i As Integer = 0 To count
            j = r.Next(0, count)

            tmp = data.ElementAt(i)
            data.Item(i) = data.Item(j)
            data.Item(j) = tmp
        Next
    End Sub

    Public Function calcPredictions(ByRef toTest As List(Of String()), ByRef listOfChances As List(Of List(Of List(Of Double))), ByRef listOfCategorias As List(Of List(Of Double)), ByRef classList As List(Of String), ByRef toTestClassColumn As List(Of String), ByVal start As Integer, ByVal minus As Integer) As List(Of String)
        Dim prediction As New List(Of String)
        Dim clsIndex, catIndex, toTestCount As Integer
        Dim max, chance As Double
        Dim classesCount As New List(Of Integer)

        For Each oClass In classList
            classesCount.Add(getClassCount(toTestClassColumn, oClass))
        Next
        toTestCount = toTest.Count

        For n As Integer = 0 To toTestCount - 1 'Reemplazar .Count por Minus
            For i As Integer = start To toTest.ElementAt(n).Count - minus
                If (start = 1) Then
                    catIndex = getCategoryIndex(toTest.ElementAt(n).ElementAt(i), listOfCategorias.ElementAt(i - 1))
                Else
                    catIndex = getCategoryIndex(toTest.ElementAt(n).ElementAt(i), listOfCategorias.ElementAt(i))
                End If

                max = 0
                For j As Integer = 0 To classList.Count - 1
                    chance = calcChanceOfClass(listOfChances, catIndex, j) * (classesCount.ElementAt(j) / toTestCount)
                    If (max < chance) Then
                        max = chance
                        clsIndex = j
                    End If
                Next
            Next

            prediction.Add(classList.ElementAt(clsIndex))
        Next
        Return prediction
    End Function

    Private Function calcChanceOfClass(ByRef listOfChances As List(Of List(Of List(Of Double))), ByVal catIndex As Integer, ByVal clsIndex As Integer) As Double
        Dim chance As Double = listOfChances.ElementAt(0).ElementAt(clsIndex).ElementAt(catIndex)
        Dim currentChance As Double
        For i As Integer = 1 To listOfChances.Count - 1
            currentChance = listOfChances.ElementAt(i).ElementAt(clsIndex).ElementAt(catIndex)
            chance = chance * listOfChances.ElementAt(i).ElementAt(clsIndex).ElementAt(catIndex)
        Next
        Return chance
    End Function

    Public Function getCategoryIndex(ByVal elementValue As String, ByRef categoryList As List(Of Double)) As Integer
        For i As Integer = 0 To categoryList.Count - 1
            If (CDbl(elementValue) < categoryList.ElementAt(i)) Then
                Return i
            End If
        Next

        Return categoryList.Count - 1
    End Function

    Public Function getClassIndex(ByVal elementValue As String, ByRef classList As List(Of String)) As Integer
        For i As Integer = 0 To classList.Count - 1
            If (elementValue = classList.ElementAt(i)) Then
                Return i
            End If
        Next

        Return -1
    End Function

End Module
