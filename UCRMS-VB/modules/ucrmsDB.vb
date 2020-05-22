Imports System.Data
Imports System.Data.SqlClient

Module ucrmsDB

    Public Function DBConn() As SqlConnection
        Return New SqlConnection("server=umt-dev-01.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms")
    End Function

End Module
