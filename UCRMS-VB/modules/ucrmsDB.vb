Imports System.Data
Imports System.Data.SqlClient

Module ucrmsDB

    Public Function DBConn() As SqlConnection
        Return New SqlConnection("server=umtgv-db-01-dev.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms")
    End Function

End Module
