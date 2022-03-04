Public Class f_CBStyle1

    Private Sub f_CBStyle1_Click(sender As Object, e As EventArgs) Handles Me.Click
        btClose_Click(sender, e)
    End Sub

    Private Sub f_CBStyle1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        GridViews.Columns.Clear()
        GridViews.DataSource = Nothing
    End Sub

    Private Sub SetVal()
        If GridViews.Rows.Count <> 0 Then
            Try
                _getSelectedArray = Nothing
                For a = 0 To _maxColumn
                    _getSelectedArray = AppendArray(_getSelectedArray, GridViews.CurrentRow.Cells(a).Value.ToString)
                Next
                _txtSendToHeader = GridViews.CurrentRow.Cells(1).Value
                _id = GridViews.CurrentRow.Cells(0).Value
            Catch ex As Exception
                MsgBox(".MaxColumn out of range.", MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Function AppendArray(Of T)(ByVal thisArray() As T, ByVal itemToAppend As T) As T()
        If thisArray Is Nothing Then thisArray = New T() {}
        Dim tempList As List(Of T) = thisArray.ToList
        tempList.Add(itemToAppend)
        Return tempList.ToArray
    End Function

    Private Sub f_CBStyle1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If ENsrcKey(Keys.Escape, e) = True Then
            Me.Close()
        End If
    End Sub

    Private Sub f_CBStyle1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If _widht <> 0 Then
        '    Width = _widht
        'End If
        txtSearch.Width = _WtextBox
        btClose.Left = _Lbutton1
        btClose.Top = _Lbutton2
        GridViews.DataSource = _DataTable
        GridViews.Columns(0).Visible = False
        SetResizeGrid()

        'If _Height = 0 Then
        '    If GridViews.Height > 150 Then
        '        Height = 150
        '    Else
        '        Height = GridViews.Height
        '    End If
        'Else
        '    GridViews.Height = _Height
        '    Height = _Height
        'End If
    End Sub

    Private Sub SetResizeGrid()
        If _widht = 0 Then
            Dim widhtGrid As Integer
            widhtGrid = 0
            For i = 0 To GridViews.ColumnCount - 1
                widhtGrid = widhtGrid + GridViews.Columns(i).Width
            Next

            Width = widhtGrid + 20
        Else
            Me.Width = _widht
        End If
        
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub GridViews_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridViews.CellClick
        SetVal()
        Me.Close()
    End Sub
    Private s_SLike As String
    Private Sub GetSearch(ByVal objTxtBox As TextBox, ByVal ParamArray sAddFilter() As String)
        If sAddFilter.Length <= 0 Then Exit Sub

        For iT As Integer = 0 To UBound(sAddFilter, 1)
            If iT >= 1 Then
                s_SLike = s_SLike & " OR " & sAddFilter(iT) & " LIKE '" & objTxtBox.Text & "%' "
            Else
                s_SLike = sAddFilter(iT) & " LIKE '" & objTxtBox.Text & "%' "
            End If
        Next
        _DataTable.DefaultView.RowFilter = s_SLike
        s_SLike = ""
    End Sub
    Shadows Event Change(sender As Object, e As EventArgs)

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SetVal()
            Me.Close()
        End If
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            GetSearch(txtSearch, s_SetFilterName)
        Catch ex As Exception
            'MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
            Me.Close()
        End Try
    End Sub

    Private Sub GridViews_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridViews.CellContentClick

    End Sub

    Private Sub GridViews_Click(sender As Object, e As EventArgs) Handles GridViews.Click

    End Sub

    Private Sub GridViews_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles GridViews.ColumnWidthChanged
        'MsgBox("Test")
        'SetResizeGrid()
    End Sub

    Private Sub f_CBStyle1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SetResizeGrid()
    End Sub

    Private Function ENsrcKey(ByVal Ky As Keys, ByVal E As System.Windows.Forms.KeyEventArgs) As Boolean
        If E.KeyCode = Ky Then
            ENsrcKey = True
            E.SuppressKeyPress = True
        Else
            ENsrcKey = False
            E.SuppressKeyPress = False
        End If
    End Function

End Class