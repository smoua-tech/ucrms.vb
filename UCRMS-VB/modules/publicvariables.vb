Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Module publicvariables
    Public sqlConn As SqlConnection = RailsConn()

#Region "Hide all gb"
    Private Sub hidegb()

        'gbSetting.Hide()
        'gbActivitylog.Hide()
        'gbAddstock.Hide()
        'gbHelp.Hide()
        'gbViewActionItems.Hide()
        'gbManageusers.Hide()
        'gbReport.Hide()
        'gbViewsales.Hide()
        'gbViewstock.Hide()
    End Sub
#End Region


End Module
