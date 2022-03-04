Public Class GridDB

#Region "GetData and Filter"
    'Private sConn As cls_connector_dynamic

    Sub New()
        'sConn = New cls_connector_dynamic("Connector_Client.ini")
    End Sub

    ''' <summary>
    ''' Untuk melakukan pencarian Data. Sbg. Contoh : DataTable.DefaultView.RowFilter = "Nama_Colom1 Like '% value %' Or Nama_Colom2 LIKE '% value %'",
    ''' dan jika Kolom terdapat SPASI lakukan kode sperti ini [Nama Colom1].
    ''' CREATED BY : [aN] - 2015 - ccomputing.web.id
    ''' </summary>
    ''' <param name="addQry">Masukkan query yang akan di Eksekusi.</param>
    ''' <param name="Header_Text">Lakukan penyesuaian dengan jumlah Field yang akan di munculkan (Max. 20 Field). Sebagai Contoh : "{New DataColumn("Kode"), New DataColumn("User Name")}"</param>
    ''' <remarks></remarks>
    Public Function getDataRowFilter(ByVal addQry As String, _
    ByVal Header_Text() As DataColumn, Optional ByVal pp As Object = Nothing) As DataTable

        getDataRowFilter = New DataTable

        Dim Sql_Conn As SqlClient.SqlConnection

        'Dim RW As New clsRw("Get 0:02999019{1x8828754211} End")

        Sql_Conn = New SqlClient.SqlConnection(sConn)
        Sql_Conn.Open()
        '=====[aN] - Get Header Text Param Array =======
        If Header_Text.Length <= 0 Then Exit Function
        getDataRowFilter.Columns.Clear()
        getDataRowFilter.Rows.Clear()
        getDataRowFilter.Columns.AddRange(Header_Text)
        Dim Cm As SqlClient.SqlCommand
        Dim dr1 As SqlClient.SqlDataReader
        Try
            With getDataRowFilter
                Cm = New SqlClient.SqlCommand(addQry, Sql_Conn)
                With Cm
                    dr1 = Cm.ExecuteReader()
                    Cm.Dispose()
                End With
                '===Loop Start=====
                Dim iI = 0
                Do While dr1.Read = True

                    iI += 1
                    If IsNothing(pp) = False Then pp.ReportProgress(iI)
                    Select Case Header_Text.Length
                        Case 1
                            .Rows.Add(dr1(0))
                        Case 2
                            .Rows.Add(dr1(0), dr1(1))
                        Case 3
                            .Rows.Add(dr1(0), dr1(1), dr1(2))
                        Case 4
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3))
                        Case 5
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4))
                        Case 6
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5))
                        Case 7
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6))
                        Case 8
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7))
                        Case 9
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8))
                        Case 10
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9))
                        Case 11
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9), dr1(10))
                        Case 12
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9),
                                dr1(10), dr1(11))
                        Case 13
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9),
                                dr1(10), dr1(11), dr1(12))
                        Case 14
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9), dr1(10),
                                dr1(11), dr1(12), dr1(13))
                        Case 15
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9), dr1(10),
                                dr1(11), dr1(12), dr1(13), dr1(14))
                        Case 16
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(6), dr1(5), dr1(7), dr1(8), dr1(9), dr1(10),
                                dr1(11), dr1(12), dr1(13), dr1(14), dr1(15))
                        Case 17
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9), dr1(10),
                                dr1(11), dr1(12), dr1(13), dr1(14), dr1(15), dr1(16))
                        Case 18
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9), dr1(10),
                                dr1(11), dr1(12), dr1(13), dr1(14), dr1(15), dr1(16), dr1(17))
                        Case 19
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9), dr1(10),
                                dr1(11), dr1(12), dr1(13), dr1(14), dr1(15), dr1(16), dr1(17), dr1(18))
                        Case 20
                            .Rows.Add(dr1(0), dr1(1), dr1(2), dr1(3), dr1(4), dr1(5), dr1(6), dr1(7), dr1(8), dr1(9), dr1(10),
                                dr1(11), dr1(12), dr1(13), dr1(14), dr1(15), dr1(16), dr1(17), dr1(18), dr1(19))
                    End Select
                Loop
                '===Loop End=======
                dr1.Close()
            End With
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        Finally
            Cm.Dispose()
            Sql_Conn.Close()
        End Try
    End Function
    Public Sub ENRowsColors(ByVal MyGridView As DataGridView)
        Try
            With MyGridView
                If .Rows.Count = 0 Then Exit Sub
                For i = 0 To .Rows.Count - 1
                    If i Mod 2 = 0 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Honeydew
                    Else
                        .Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If
                Next
            End With
        Catch ex As Exception

        End Try

    End Sub
#End Region

End Class
