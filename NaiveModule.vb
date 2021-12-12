Module NaiveModule
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
    Public Sub calcAnchosIguales(ByVal datasetColumn As List(Of String), ByVal datasetClassColumn As List(Of String), ByRef categoryCountPerClass As List(Of List(Of Integer)), ByRef categoryList As List(Of Double), ByRef classList As List(Of String), ByVal intervalCount As Integer, ByVal classCount As Integer)
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
                    Dim ind1 = classList.IndexOf(datasetClassColumn.ElementAt(i))
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
        Dim count As Integer
        For i As Integer = 0 To classList.Count - 1
            count = getClassCount(datasetClassColumn, classList.ElementAt(i))
            chanceOf.Add(New List(Of Double))

            For j As Integer = 0 To categoryCountPerClass.ElementAt(i).Count - 1
                '+1 y +categoryList.Count para agregar evitar 0 con el método de Laplace
                chanceOf.ElementAt(i).Add((categoryCountPerClass.ElementAt(i).ElementAt(j) + 1) / (count + categoryList.Count))
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

    'Debe ser llamado inmediatamente después de haber llamado a la función de anchos iguales
    Public Function getClassCountForCategory() As List(Of Integer)
        Return classCountPerCategory
    End Function

    Public Function calcMtzConf(ByRef clases As List(Of String), ByRef predict As List(Of String), ByRef original As List(Of String)) As List(Of List(Of Integer))
        Dim mtz_conf As New List(Of List(Of Integer))
        Dim ico, ifi As New Integer

        For i As Integer = 0 To clases.Count - 1
            mtz_conf.Add(New List(Of Integer))
            For j As Integer = 0 To clases.Count - 1
                mtz_conf.ElementAt(i).Add(0)
            Next
        Next

        For i = 0 To predict.Count - 1
            If predict.ElementAt(i) = original.ElementAt(i) Then
                ico = class_indi(clases, predict.ElementAt(i))
                mtz_conf.Item(ico).Item(ico) += 1
            Else
                ico = class_indi(clases, predict.ElementAt(i))
                ifi = class_indi(clases, original.ElementAt(i))
                mtz_conf.Item(ico).Item(ifi) += 1
            End If
        Next

        Return mtz_conf
    End Function

    Public Function class_indi(ByRef clases As List(Of String), ByRef clase As String) As Integer
        For i = 0 To clases.Count - 1
            If clases.ElementAt(i) = clase Then
                Return i
            End If
        Next

        Return -1
    End Function

    Public Function getTP(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Integer
        Return mtz_conf.ElementAt(ind).ElementAt(ind)
    End Function

    Public Function getTN(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Integer
        Dim trun As Integer = 0

        For Each columna In mtz_conf
            For Each fila In columna
                trun += fila
            Next
        Next

        trun -= (getTP(mtz_conf, ind) + getFP(mtz_conf, ind) + getFN(mtz_conf, ind))

        Return trun
    End Function

    Public Function getFP(ByRef mtz_conf As List(Of List(Of Integer)), ByRef inf As Integer) As Integer
        Dim falp As Integer = 0

        For inc = 0 To mtz_conf.Count - 1
            falp += mtz_conf.ElementAt(inf).ElementAt(inc)
        Next

        falp -= getTP(mtz_conf, inf)

        Return falp
    End Function

    Public Function getFN(ByRef mtz_conf As List(Of List(Of Integer)), ByRef inc As Integer) As Integer
        Dim faln As Integer = 0

        For inf = 0 To mtz_conf.Count - 1
            faln += mtz_conf.ElementAt(inc).ElementAt(inf)
        Next

        faln -= getFP(mtz_conf, inc)

        Return faln
    End Function

    Public Function getPrecision(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Double
        Dim preci As Double
        Dim trupo As Integer

        trupo = getTP(mtz_conf, ind)
        preci = trupo / (trupo - getFP(mtz_conf, ind))

        Return preci
    End Function

    Public Function getRecall(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Double
        Dim rec As Double
        Dim trupo As Integer

        trupo = getTP(mtz_conf, ind)
        rec = trupo / (trupo - getFN(mtz_conf, ind))

        Return rec
    End Function

    Private Function getMF1(ByRef mtz_conf As List(Of List(Of Integer)), ByRef ind As Integer) As Double
        Dim medf, preci, recal As Double

        preci = getPrecision(mtz_conf, ind)
        recal = getRecall(mtz_conf, ind)

        medf = 2 * preci * recal / (preci + recal)

        Return medf
    End Function

    Private Function getAccuracy(ByRef mtz_conf As List(Of List(Of Integer)), ByRef totalFilas As Integer) As Double
        Dim accu As Double
        Dim tepes As Integer

        For i = 0 To mtz_conf.Count - 1
            tepes += getTP(mtz_conf, i)
        Next

        accu = tepes / totalFilas

        Return accu
    End Function
End Module
