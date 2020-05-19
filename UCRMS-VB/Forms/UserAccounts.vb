Imports System.Data.SqlClient

Public Class UserAccounts
    Inherits MetroFramework.Forms.MetroForm
    Dim StatementSQL As New StatementsSQL
    Dim publicvariables As New publicvariables
    Dim newsqlconn As SqlConnection = DBConn()

    Private Sub Manageaccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox_ListsOfUsers.Visible = True
        GroupBox_UserInformationDetails.Visible = False
        GroupBox_ListsOfUsers.Visible = False
        BtnCreateNewManageAccounts.Visible = False
        BtnSaveManageAccounts.Visible = False
        BtnManageAccounts.Visible = False
        BtnLoadManageAccounts.Visible = False
        GroupBox_ManageAccounts.Dock = DockStyle.Fill
        GroupBox_ManageAccounts.Show()
    End Sub

#Region "ACTION BUTTONS"
    Private Sub BtnLoadManageAccounts_Click(sender As Object, e As EventArgs) Handles BtnLoadManageAccounts.Click
        StatementSQL.UserAccountsLoad()
    End Sub
    Public Sub BtnSaveManageAccounts_Click(sender As Object, e As EventArgs) Handles BtnCreateNewManageAccounts.Click

        StatementSQL.InsertNewAccount()
        Dim a As Control

        For Each a In Me.GroupBox_UserInformationDetails.Controls
            If TypeOf a Is TextBox Then
                a.Text = Nothing
            End If
        Next

        'If cboUserTypeManageAccounts.Text = "" Then
        '    MsgBox("Please choose a user type.")
        'Else

        '    Dim result As DialogResult = MessageBox.Show("A new user account or change will be made.", "Warning", MessageBoxButtons.YesNo)
        '    If result = DialogResult.Yes Then

        '        Using cmdupdate As New SqlCommand()
        '            cmdupdate.Connection = newsqlconn
        '            With cmdupdate
        '                newsqlconn.Open()

        '                .CommandText = "UPDATE useraccounts " &
        '                       " SET usertype=@usertype " &
        '                       " WHERE ID=@ID"

        '                .CommandType = Data.CommandType.Text
        '                .Parameters.AddWithValue("@ID", lblIDManageAccounts.Text)
        '                .Parameters.AddWithValue("@usertype", cboUserTypeManageAccounts.Text)

        '            End With

        '            Try
        '                cmdupdate.ExecuteNonQuery()
        '                'iReturn = True
        '                MsgBox("User account updated Successfully")
        '            Catch ex As SqlException
        '                MsgBox(ex.Message, MsgBoxStyle.Information)
        '                'iReturn = False
        '            End Try
        '        End Using
        '    End If
        'End If

        'UserAccountsLoad()
        'cboUserTypeManageAccounts.ResetText()
        'newsqlconn.Close()

    End Sub

#End Region

#Region "DATAGRIDVIEW ACTION"
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow
                row = DataGridView2.Rows(e.RowIndex)
                lblIDManageAccounts.Text = row.Cells("id").Value.ToString
                txtFirstNameManageAccounts.Text = row.Cells("first_name").Value.ToString
                txtLastNameManageAccounts.Text = row.Cells("last_name").Value.ToString
                txtUserEmailManageAccounts.Text = row.Cells("user_email").Value.ToString
                cboUserTypeManageAccounts.Text = row.Cells("user_type").Value.ToString
                txtUserEmailManageAccounts.Text = row.Cells("user_type").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show("Error Cell Content Click :" & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        StatementSQL.UserAccountsLoad()
    End Sub

    Private Sub BtnEditUserAccounts_Click(sender As Object, e As EventArgs) Handles BtnEditUserAccounts.Click
        GroupBox_UserInformationDetails.Dock = DockStyle.Fill
        GroupBox_UserInformationDetails.Visible = True
        GroupBox_ListsOfUsers.Visible = True
        GroupBox_ManageAccounts.Hide()
        StatementSQL.UserAccountsLoad()
        BtnSaveManageAccounts.Visible = True
        BtnCreateNewManageAccounts.Visible = False
        BtnManageAccounts.Visible = True


    End Sub

    Private Sub BtnCreateNewUser_Click(sender As Object, e As EventArgs) Handles BtnCreateNewUser.Click
        StatementSQL.UserAccountsLoad()
        GroupBox_UserInformationDetails.Dock = DockStyle.Fill
        GroupBox_UserInformationDetails.Visible = True
        GroupBox_ListsOfUsers.Visible = True
        GroupBox_ManageAccounts.Hide()
        BtnSaveManageAccounts.Visible = False
        BtnCreateNewManageAccounts.Visible = True
        BtnManageAccounts.Visible = True

    End Sub

    Private Sub BtnCloseManageAccounts_Click(sender As Object, e As EventArgs) Handles BtnCloseManageAccounts.Click
        Dispose()
    End Sub

    Private Sub BtnManageAccounts_Click(sender As Object, e As EventArgs) Handles BtnManageAccounts.Click
        GroupBox_ListsOfUsers.Visible = True
        GroupBox_UserInformationDetails.Visible = False
        GroupBox_ListsOfUsers.Visible = False
        BtnLoadManageAccounts.Visible = False
        BtnCreateNewManageAccounts.Visible = False
        BtnSaveManageAccounts.Visible = False
        GroupBox_ManageAccounts.Dock = DockStyle.Fill
        GroupBox_ManageAccounts.Show()
        BtnManageAccounts.Visible = False
    End Sub

    Private Sub BtnSaveManageAccounts_Click_1(sender As Object, e As EventArgs) Handles BtnSaveManageAccounts.Click

    End Sub

#End Region
End Class