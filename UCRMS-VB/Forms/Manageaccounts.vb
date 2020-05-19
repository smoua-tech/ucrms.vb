Imports System.Data.SqlClient

Public Class Manageaccounts
    Inherits MetroFramework.Forms.MetroForm

    Dim newsqlconn As SqlConnection = DBConn()
    Dim StatementSQL As New StatementsSQL()

    Private Sub Manageaccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#Region "ACTION BUTTONS"


#End Region

#Region "DATAGRIDVIEW ACTION"


    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreateNewUser.Click, BtnEditUserAccounts.Click
        Dim bt As Button = CType(sender, Button)

        Select Case bt.Name
            Case BtnCreateNewUser.Name
                UserAccounts.ShowDialog()
                UserAccounts.BtnSaveManageAccounts.Visible = False
                UserAccounts.BtnCreateNewManageAccounts.Visible = True
            Case BtnEditUserAccounts.Name
                UserAccounts.ShowDialog()
                UserAccounts.BtnSaveManageAccounts.Visible = True
                UserAccounts.BtnCreateNewManageAccounts.Visible = False
        End Select

        UserAccounts.Dispose()
    End Sub

    Private Sub BtnEditUserAccounts_Click(sender As Object, e As EventArgs) Handles BtnEditUserAccounts.Click

    End Sub

#End Region

End Class