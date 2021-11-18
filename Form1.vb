Public Class Form1
    Dim mainDataset As New List(Of String())
    Dim externalDataset As New List(Of String())
    Dim columnCount As UInt16 = 0

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

End Class
