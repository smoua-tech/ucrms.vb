Imports System.Data
Imports System.Data.SqlClient

Module save
    Dim result As Integer
    Dim sqlcmd As New SqlCommand
    Dim SQLAdapter As SqlDataAdapter
    Dim newsqlconn As SqlConnection = DBConn()

    Public Sub SysGetItem(ByVal sqlstring As String)
        Try
            newsqlconn.Open()
            With sqlcmd
                .Connection = newsqlconn
                .CommandText = sqlstring
                result = sqlcmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("Error, cannot start adding items for this requisition order!")
                    'Else
                    'MsgBox("PurchSysUpdate Line")
                End If
            End With
        Catch ex As Exception
            MsgBox("Error in the SysGetItem method, Save module :" & ex.Message, MsgBoxStyle.Information)
        End Try
        newsqlconn.Close()
    End Sub

End Module
