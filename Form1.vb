Public Class Form1
    Dim mainDataset As New List(Of String())
    Dim externalDataset As New List(Of String())
    Dim columnCount As Integer = 0
    Dim frecuencias() As Int32

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
        Dim arreglo() As String

        anchos_iguales(arreglo)
        frecuencias_iguales(arreglo, anchos_iguales(arreglo))


    End Sub

    Public Function anchos_iguales(ByVal arreglo() As String) As String()
        Dim max, min, n_intervalos, largo As Int32
        Dim rango, numero As Double


        n_intervalos = txtIntervals.Value
        largo = UBound(arreglo)
        max = 0
        min = arreglo(0)

        For i = 0 To largo Step 1
            If (arreglo(i) > max) Then
                max = arreglo(i)
            End If
        Next

        For i = 0 To largo Step 1
            If (arreglo(i) < min) Then
                min = arreglo(i)
            End If
        Next

        rango = (max - min) / n_intervalos

        Dim categorias(n_intervalos) As String
        Dim arreglo_nuevo(largo) As String

        categorias(0) = min + rango

        For i = 1 To n_intervalos - 1 Step 1
            categorias(i) = categorias(i - 1) + rango
        Next

        For i = 0 To largo Step 1
            numero = arreglo(i)

            Select Case numero
                Case (numero < categorias(0))
                    arreglo_nuevo(i) = "A"
                Case (numero >= categorias(0) And numero < categorias(1))
                    arreglo_nuevo(i) = "B"
                Case (numero >= categorias(1) And numero < categorias(2))
                    arreglo_nuevo(i) = "C"
                Case (numero >= categorias(2) And numero < categorias(3))
                    arreglo_nuevo(i) = "D"
                Case (numero >= categorias(3) And numero < categorias(4))
                    arreglo_nuevo(i) = "E"
                Case (numero >= categorias(4) And numero < categorias(5))
                    arreglo_nuevo(i) = "F"
                Case (numero >= categorias(5) And numero < categorias(6))
                    arreglo_nuevo(i) = "G"
                Case (numero >= categorias(6))
                    arreglo_nuevo(i) = "H"
            End Select
        Next

        For i = 0 To largo Step 1

            Select Case arreglo_nuevo(i)
                Case arreglo_nuevo(i) = "A"
                    frecuencias(0) = frecuencias(0) + 1
                Case arreglo_nuevo(i) = "B"
                    frecuencias(1) = frecuencias(1) + 1
                Case arreglo_nuevo(i) = "C"
                    frecuencias(2) = frecuencias(2) + 1
                Case arreglo_nuevo(i) = "D"
                    frecuencias(3) = frecuencias(3) + 1
                Case arreglo_nuevo(i) = "E"
                    frecuencias(4) = frecuencias(4) + 1
                Case arreglo_nuevo(i) = "F"
                    frecuencias(5) = frecuencias(5) + 1
                Case arreglo_nuevo(i) = "G"
                    frecuencias(6) = frecuencias(6) + 1
                Case arreglo_nuevo(i) = "H"
                    frecuencias(7) = frecuencias(7) + 1
            End Select

        Next


        Return arreglo_nuevo

    End Function

    Public Function frecuencias_iguales(ByRef arreglo() As String, ByRef arreglo1() As String) As Integer()
        Dim arreglo_nuevo()()
        Dim arreglo_ordenado()()
        Dim largo, n_categorias, rangos, n, f, aux, aux2, cat As Int32
        largo = UBound(arreglo)
        Dim array As New List(Of String())
        Dim categorias() as Integer
        Dim x As Integer


        n_categorias = txtIntervals.Value
        rangos = largo / n_categorias

        For i As Integer = 0 To largo
            arreglo_nuevo(i)(0) = arreglo(i)
            arreglo_nuevo(i)(1) = arreglo1(i)
        Next

        n = -1
        While n < largo - 1
            n = n + 1
            f = -1
            While f < n
                f = f + 1
                If arreglo_nuevo(n)(0) < arreglo_nuevo(f)(0) Then
                    aux = arreglo_nuevo(n)(0)
                    aux2 = arreglo_nuevo(n)(1)
                    arreglo_nuevo(n)(0) = arreglo_nuevo(f)(0)
                    arreglo_nuevo(n)(1) = arreglo_nuevo(f)(1)
                    arreglo_nuevo(f)(0) = aux
                    arreglo_nuevo(f)(1) = aux2
                End If
            End While
        End While

        n = -1
        While n < f -1
            n = n + 1
            arreglo_ordenado(n)(0) = arreglo_nuevo(n)(0)
            arreglo_ordenado(n)(1) = arreglo_nuevo(n)(1)
        End While

        n = 0
        For i As Integer = 0 To largo
            x = arreglo_ordenado(i)(1)
            If (x <> arreglo_ordenado(i+1)(1))
                cat = (arreglo_ordenado(i)(0)+arreglo_ordenado(i+1)(0))/2
                categorias(n) = cat
                n = n + 1
            End If
        Next

        Return categorias
    End Function
End Class
