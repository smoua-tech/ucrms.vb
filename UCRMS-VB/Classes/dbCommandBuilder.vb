Imports System.Collections.Generic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports System.Windows.Forms

Public Class dbCommandBuilder
    Public Function DBConn() As SqlConnection
        Return New SqlConnection("server=umtgv-db-01-dev.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms")
    End Function
End Class
