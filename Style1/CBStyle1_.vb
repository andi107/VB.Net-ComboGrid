Imports System.ComponentModel
Public Class CBStyle1_
    Inherits UserControl
    Private bw As BackgroundWorker
    Private WithEvents popupHelper As New vbAccelerator.Components.Controls.PopupWindowHelper
    Shadows Event Click(sender As Object, e As EventArgs)
    Shadows Event TextChanged(sender As Object, e As EventArgs)
    Public s_SetFilterNames() As String
    Public Size_widht As Integer
    Public Size_Height As Integer
    Public Overrides Property Text As String
        Get
            Return txtHeaderVal.Text
        End Get
        Set(value As String)
            txtHeaderVal.Text = value
        End Set
    End Property
    Public WriteOnly Property MaxColumn As Integer
        Set(value As Integer)
            _maxColumn = value
        End Set
    End Property
    Public Function GetAllSelected() As Object
        Return _getSelectedArray
    End Function
    Public Function GetId() As String
        Return _id
    End Function
    Public Property ConnectionString As String
        Get
            Return sConn
        End Get
        Set(value As String)
            sConn = value
        End Set
    End Property

    Private Sub popupHelper_PopupCancel(ByVal sender As Object, ByVal e As vbAccelerator.Components.Controls.PopupCancelEventArgs) Handles popupHelper.PopupCancel
        btOpen.Enabled = True
    End Sub

    Private Sub popupHelper_PopupClosed(ByVal sender As Object, ByVal e As vbAccelerator.Components.Controls.PopupClosedEventArgs) Handles popupHelper.PopupClosed
        If _txtSendToHeader <> "" Then
            txtHeaderVal.Text = _txtSendToHeader
        End If
        _txtSendToHeader = ""
        Set_DataColumn = Nothing
        _DataTable = Nothing
        If bw.WorkerSupportsCancellation = True Then
            bw.CancelAsync()
        End If
        Dim popup As f_CBStyle1
        popup = e.Popup
        btOpen.Enabled = True
        s_SetFilterNames = Nothing
        s_SetFilterName = Nothing
    End Sub
    Private F As Form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btOpen.Click
        F = New Form
        _WtextBox = txtHeaderVal.Width
        _Lbutton1 = btOpen.Left
        _Lbutton2 = btOpen.Top
        RaiseEvent Click(sender, e)
        _widht = Size_widht
        If Size_Height = 0 Then
            _Height = Size_Height
        End If
        bw = New BackgroundWorker
        If IsNothing(Set_DataColumn) Then
            MsgBox("set_DataColumn is Null.", MsgBoxStyle.Critical, "Error")
            Return
        ElseIf set_Query = "" Then
            MsgBox("set_Query is Null.", MsgBoxStyle.Critical, "Error")
            Return
        End If

        bw.WorkerReportsProgress = True
        bw.WorkerSupportsCancellation = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

        If Not bw.IsBusy = True Then
            bw.RunWorkerAsync()
        End If

        'Dim Lokasi As Point = Me.PointToScreen(New Point(TextBox1.Left, TextBox1.Bottom))

        btOpen.Enabled = False
    End Sub

#Region "BackWorking"
    Public set_Query As String

    Public Set_DataColumn() As DataColumn
    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim _Load As New GridDB
        s_SetFilterName = s_SetFilterNames
        _DataTable = New DataTable
        _DataTable = _Load.getDataRowFilter(set_Query, Set_DataColumn)
        Return
    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim Lokasi As Point = Me.PointToScreen(New Point(0, 0))
        popupHelper.ShowPopup(F, f_CBStyle1, Lokasi)
        
    End Sub
    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)

    End Sub
#End Region

    Private Sub CBStyle1__Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Width = 140
        Height = 22
    End Sub

    Private Sub txtHeaderVal_Click(sender As Object, e As EventArgs) Handles txtHeaderVal.Click

    End Sub

    Private Sub txtHeaderVal_TextChanged(sender As Object, e As EventArgs) Handles txtHeaderVal.TextChanged
        RaiseEvent TextChanged(sender, e)
    End Sub

    Property ReadOnlyText As Boolean
        Get
            Return txtHeaderVal.ReadOnly
        End Get
        Set(value As Boolean)
            txtHeaderVal.ReadOnly = value
        End Set
    End Property

    

End Class
