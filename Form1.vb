Public Class Form1
    Dim mainDataset As New List(Of String())
    Dim externalDataset As New List(Of String())
    Dim columnCount As Integer = 0
    Dim frecuencias() As Int32
    Dim predict As New List(Of String)
    Dim mtz_conf As New List(Of Integer())
    Dim clases As New List(Of String)

    'Regresa un arreglo tipo List(Of String), según un índice de un dataset, Ej:
    'Dim columna As List(Of String) = getDatasetColumn(mainDataset, 3)
    Private Function getDatasetColumn(ByVal dataset As List(Of String()), ByVal index As Integer) As List(Of String)
        Dim iRow As New List(Of String)

        For Each row In dataset
            iRow.Add(row.GetValue(index))
        Next
        Return iRow
    End Function

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim arreglo As List(Of Char) = anchos_iguales(getDatasetColumn(mainDataset,0))
        For Each num In arreglo
            msgBox(num)
        Next
    End Sub

    Public Function anchos_iguales(ByVal arreglo As List(Of String)) As List(Of Char)
        Dim n_intervalos As Integer
        Dim rango, max, min As Double
        Dim arreglo_numero As New List(Of Double)


        n_intervalos = CInt(txtIntervals.Value)


        For Each num In arreglo
            arreglo_numero.add(CDbl(num))
        Next

        max = arreglo_numero.Max()
        min = arreglo_numero.Min()


        rango = (max - min) / n_intervalos

        Dim categorias As New List(Of Double)
        Dim arreglo_nuevo As New List(Of Char)
        Dim cat As Double = min

        For i = 0 To n_intervalos - 1 Step 1
            cat += rango
            categorias.Add(cat)
        Next


        For Each num In arreglo_numero
            For i = 0 To n_intervalos - 1 Step 1
                If num < categorias.ElementAt(i) Then
                    arreglo_nuevo.Add(Chr(65 + i))
                    Exit For
                End If
            Next
        Next
        Return arreglo_nuevo

    End Function

    Private Sub calc_mtz_confu(ByRef original As List(Of String))

        Dim ico, ifi As New Integer

        For i = 0 To predict.Count - 1
            If predict.ElementAt(i) = original.ElementAt(i) Then
                ico = class_indi(predict.ElementAt(i))
                mtzval_up(ico, ico)

            Else
                ico = class_indi(predict.ElementAt(i))
                ifi = class_indi(original.ElementAt(i))
                mtzval_up(ico, ifi)

            End If

        Next

    End Sub


    Private Function class_indi(ByRef clase As String) As Integer

        For i = 0 To clases.Count - 1
            If clases.ElementAt(i) = clase Then
                Return i

            End If
        Next

        Return -1
    End Function

    Private Sub mtzval_up(ByRef inc As Integer, ByRef inf As Integer)
        Dim v As Integer = mtz_conf.ElementAt(inc).ElementAt(inf)

        mtz_conf.ElementAt(inc).SetValue(v + 1, inf)

    End Sub

    Private Function tp(ByRef ind As Integer) As Integer

        Return mtz_conf.ElementAt(ind).ElementAt(ind)
    End Function

    Private Function tn(ByRef ind As Integer) As Integer
        Dim trun As Integer = 0

        For Each columna In mtz_conf
            For Each fila In columna
                trun += fila
            Next
        Next

        trun -= (tp(ind) + fp(ind) + fn(ind))

        Return trun
    End Function

    Private Function fp(ByRef inf As Integer) As Integer
        Dim falp As Integer = 0

        For inc = 0 To clases.Count - 1
            falp += mtz_conf.ElementAt(inf).ElementAt(inc)
        Next
        falp -= tp(inf)

        Return falp
    End Function

    Private Function fn(ByRef inc As Integer) As Integer
        Dim faln As Integer = 0

        For inf = 0 To clases.Count - 1
            faln += mtz_conf.ElementAt(inc).ElementAt(inf)
        Next
        faln -= tp(inc)

        Return faln
    End Function

    Private Function prec(ByRef ind As Integer) As Double
        Dim preci As Double
        Dim trupo As Integer

        trupo = tp(ind)

        preci = trupo / (trupo - fp(ind))

        Return preci
    End Function

    Private Function recall(ByRef ind As Integer) As Double
        Dim rec As Double
        Dim trupo As Integer
        trupo = tp(ind)

        rec = trupo / (trupo - fn(ind))

        Return rec
    End Function

    Private Function accuracy(ByRef indi As Integer) As Double
        Dim accu As Double
        Dim totalmtz, tepes As Integer

        totalmtz = predict.Count

        For i = 0 To clases.Count - 1
            tepes += tp(i)
        Next

        accu = tepes / totalmtz

        Return accu
    End Function

    Private Function mf1(ByRef ind As Integer) As Double
        Dim medf, preci, recal As Double
        preci = prec(ind)
        recal = recall(ind)

        medf = 2 * preci * recal / (preci + recal)

        Return medf
    End Function


End Class
