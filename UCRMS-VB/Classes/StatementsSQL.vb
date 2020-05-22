Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Deployment.Application
Imports System.Globalization

Public Class StatementsSQL
    Dim publicvariables As New Publicvariables
    Public sqlcmd As New SqlCommand
    Public sqlda As New SqlDataAdapter
    Dim da As OleDbDataAdapter
    Public sqlquery As String
    Public myitemid As String
    Dim result As Integer
    Dim connstring As String = "server=umt-dev-01.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms"

    Public Sub LogInToMainForm()
        ManagerForm.Show()
    End Sub

#Region "LOADS ECR ITEMS INTO DATDGRIDVIEW"
    'Loads ALL action items to view
    Public Sub LoadAllECRItemsList()

        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM ChangeRequestItemsDet " &
                " WHERE Status <> 'Finished' ORDER BY ID DESC"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView1

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("RequestorEmail").Visible = False
                .Columns("EngineerEmail").Visible = False
                .Columns("DateFinished").Visible = False

                .Columns("Status").HeaderText = "Status"
                .Columns("Status").Width = 30
                .Columns("Status").DisplayIndex = 0

                .Columns("EcrConfNum").HeaderText = "ECR #"
                .Columns("EcrConfNum").Width = 35
                .Columns("EcrConfNum").DisplayIndex = 1

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 50
                .Columns("DateCreated").DisplayIndex = 2

                .Columns("Site").HeaderText = "Site"
                .Columns("Site").Width = 40
                .Columns("Site").DisplayIndex = 3

                .Columns("ChangeType").HeaderText = "Change Type"
                .Columns("ChangeType").Width = 50
                .Columns("ChangeType").DisplayIndex = 4

                .Columns("DocumentNum").HeaderText = "Document#"
                .Columns("DocumentNum").Width = 80
                .Columns("DocumentNum").DisplayIndex = 5

                .Columns("DocumentRev").HeaderText = "Doc Rev"
                .Columns("DocumentRev").Width = 40
                .Columns("DocumentRev").DisplayIndex = 6

                .Columns("Requestor").HeaderText = "Requestor"
                .Columns("Requestor").Width = 80
                .Columns("Requestor").DisplayIndex = 7

                .Columns("Engineer").HeaderText = "Engineer"
                .Columns("Engineer").Width = 80
                .Columns("Engineer").DisplayIndex = 8

            End With
        Catch ex As Exception
            MsgBox("Cannot load ALL ECR Items from: (LoadECRItemsList) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    Public Sub LoadToGroupBoxViewECRPage()


    End Sub

    'Loads ECR Items that are assigned only to the logged in user
    Public Sub LoadMyItems()
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM ChangeRequestItemsDet " &
                " WHERE Engineer = '" & userFullName & "' AND Status <> 'Finished' ORDER BY ID DESC "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView1

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("RequestorEmail").Visible = False
                .Columns("EngineerEmail").Visible = False
                .Columns("DateFinished").Visible = False

                .Columns("Status").HeaderText = "Status"
                .Columns("Status").Width = 30
                .Columns("Status").DisplayIndex = 0

                .Columns("EcrConfNum").HeaderText = "ECR #"
                .Columns("EcrConfNum").Width = 35
                .Columns("EcrConfNum").DisplayIndex = 1

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 50
                .Columns("DateCreated").DisplayIndex = 2

                .Columns("Site").HeaderText = "Site"
                .Columns("Site").Width = 40
                .Columns("Site").DisplayIndex = 3

                .Columns("ChangeType").HeaderText = "Change Type"
                .Columns("ChangeType").Width = 50
                .Columns("ChangeType").DisplayIndex = 4

                .Columns("DocumentNum").HeaderText = "Document#"
                .Columns("DocumentNum").Width = 80
                .Columns("DocumentNum").DisplayIndex = 5

                .Columns("DocumentRev").HeaderText = "Doc Rev"
                .Columns("DocumentRev").Width = 40
                .Columns("DocumentRev").DisplayIndex = 6

                .Columns("Requestor").HeaderText = "Requestor"
                .Columns("Requestor").Width = 80
                .Columns("Requestor").DisplayIndex = 7

                .Columns("Engineer").HeaderText = "Engineer"
                .Columns("Engineer").Width = 80
                .Columns("Engineer").DisplayIndex = 8

            End With
        Catch ex As Exception
            MsgBox("Cannot load ALL ECR Items from: (LoadECRItemsList) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    'Loads ECR Items that had been requested by the logged in user
    Public Sub LoadMyRequestedECRItems()

        Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM ChangeRequestItemsDet " &
               " WHERE Requestor = '" & userFullName & "' AND Status <> 'Finished' ORDER BY ID DESC"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView1

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("RequestorEmail").Visible = False
                .Columns("EngineerEmail").Visible = False
                .Columns("DateFinished").Visible = False

                .Columns("Status").HeaderText = "Status"
                .Columns("Status").Width = 30
                .Columns("Status").DisplayIndex = 0

                .Columns("EcrConfNum").HeaderText = "ECR #"
                .Columns("EcrConfNum").Width = 35
                .Columns("EcrConfNum").DisplayIndex = 1

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 50
                .Columns("DateCreated").DisplayIndex = 2

                .Columns("Site").HeaderText = "Site"
                .Columns("Site").Width = 40
                .Columns("Site").DisplayIndex = 3

                .Columns("ChangeType").HeaderText = "Change Type"
                .Columns("ChangeType").Width = 50
                .Columns("ChangeType").DisplayIndex = 4

                .Columns("DocumentNum").HeaderText = "Document#"
                .Columns("DocumentNum").Width = 80
                .Columns("DocumentNum").DisplayIndex = 5

                .Columns("DocumentRev").HeaderText = "Doc Rev"
                .Columns("DocumentRev").Width = 40
                .Columns("DocumentRev").DisplayIndex = 6

                .Columns("Requestor").HeaderText = "Requestor"
                .Columns("Requestor").Width = 80
                .Columns("Requestor").DisplayIndex = 7

                .Columns("Engineer").HeaderText = "Engineer"
                .Columns("Engineer").Width = 80
                .Columns("Engineer").DisplayIndex = 8

            End With
        Catch ex As Exception
            MsgBox("Cannot load My Requested ECR Items from: (LoadMyRequestedECRItems) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()



    End Sub

    'Loads Action Items that is used in search bar
    Public Sub SearchECRItems()
        Dim searchText As String = ManagerForm.txtSearchECRBar.Text
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM ChangeRequestItemsDet " &
                " WHERE EcrConfNum Like '%" & searchText & "%' " &
                " OR Status LIKE '%" & searchText & "%'  " &
                " OR DateCreated LIKE '%" & searchText & "%' " &
                " OR DateModified LIKE '%" & searchText & "%' " &
                " OR Site LIKE '%" & searchText & "%' " &
                " OR ChangeType LIKE '%" & searchText & "%'  " &
                " OR DateModified LIKE '%" & searchText & "%' " &
                " OR DocumentNum LIKE '%" & searchText & "%' " &
                " OR DocumentRev LIKE '%" & searchText & "%' " &
                " OR Requestor LIKE '%" & searchText & "%' " &
                " OR Engineer LIKE '%" & searchText & "%' " &
                " ORDER BY ID DESC"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView1

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("RequestorEmail").Visible = False
                .Columns("EngineerEmail").Visible = False
                .Columns("DateFinished").Visible = False

                .Columns("Status").HeaderText = "Status"
                .Columns("Status").Width = 30
                .Columns("Status").DisplayIndex = 0

                .Columns("EcrConfNum").HeaderText = "ECR #"
                .Columns("EcrConfNum").Width = 35
                .Columns("EcrConfNum").DisplayIndex = 1

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 50
                .Columns("DateCreated").DisplayIndex = 2

                .Columns("Site").HeaderText = "Site"
                .Columns("Site").Width = 40
                .Columns("Site").DisplayIndex = 3

                .Columns("ChangeType").HeaderText = "Change Type"
                .Columns("ChangeType").Width = 50
                .Columns("ChangeType").DisplayIndex = 4

                .Columns("DocumentNum").HeaderText = "Document#"
                .Columns("DocumentNum").Width = 80
                .Columns("DocumentNum").DisplayIndex = 5

                .Columns("DocumentRev").HeaderText = "Doc Rev"
                .Columns("DocumentRev").Width = 40
                .Columns("DocumentRev").DisplayIndex = 6

                .Columns("Requestor").HeaderText = "Requestor"
                .Columns("Requestor").Width = 80
                .Columns("Requestor").DisplayIndex = 7

                .Columns("Engineer").HeaderText = "Engineer"
                .Columns("Engineer").Width = 80
                .Columns("Engineer").DisplayIndex = 8

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
    End Sub

    'Loads all finished ECR from the logged in Engineer
    Public Sub LoadFinishedItems()
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM ChangeRequestItemsDet " &
                " WHERE Engineer = '" & userFullName & "' AND Status = 'Finished' ORDER BY DateFinished DESC"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView1

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("RequestorEmail").Visible = False
                .Columns("EngineerEmail").Visible = False
                .Columns("DateFinished").Visible = False

                .Columns("Status").HeaderText = "Status"
                .Columns("Status").Width = 30
                .Columns("Status").DisplayIndex = 0

                .Columns("EcrConfNum").HeaderText = "ECR #"
                .Columns("EcrConfNum").Width = 35
                .Columns("EcrConfNum").DisplayIndex = 1

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 50
                .Columns("DateCreated").DisplayIndex = 2

                .Columns("Site").HeaderText = "Site"
                .Columns("Site").Width = 40
                .Columns("Site").DisplayIndex = 3

                .Columns("ChangeType").HeaderText = "Change Type"
                .Columns("ChangeType").Width = 50
                .Columns("ChangeType").DisplayIndex = 4

                .Columns("DocumentNum").HeaderText = "Document#"
                .Columns("DocumentNum").Width = 80
                .Columns("DocumentNum").DisplayIndex = 5

                .Columns("DocumentRev").HeaderText = "Doc Rev"
                .Columns("DocumentRev").Width = 40
                .Columns("DocumentRev").DisplayIndex = 6

                .Columns("Requestor").HeaderText = "Requestor"
                .Columns("Requestor").Width = 80
                .Columns("Requestor").DisplayIndex = 7

                .Columns("Engineer").HeaderText = "Engineer"
                .Columns("Engineer").Width = 80
                .Columns("Engineer").DisplayIndex = 8

            End With
        Catch ex As Exception
            MsgBox("Cannot load ALL ECR Items from: (LoadECRItemsList) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    'Loads all finished ECR from the logged in requested User
    Public Sub LoadMyRequestedFinishedItems()

        Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM ChangeRequestItemsDet " &
                 " WHERE Requestor = '" & userFullName & "' AND Status = 'Finished' ORDER BY DateFinished DESC"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView1

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("RequestorEmail").Visible = False
                .Columns("EngineerEmail").Visible = False
                .Columns("DateFinished").Visible = False

                .Columns("Status").HeaderText = "Status"
                .Columns("Status").Width = 30
                .Columns("Status").DisplayIndex = 0

                .Columns("EcrConfNum").HeaderText = "ECR #"
                .Columns("EcrConfNum").Width = 35
                .Columns("EcrConfNum").DisplayIndex = 1

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 50
                .Columns("DateCreated").DisplayIndex = 2

                .Columns("Site").HeaderText = "Site"
                .Columns("Site").Width = 40
                .Columns("Site").DisplayIndex = 3

                .Columns("ChangeType").HeaderText = "Change Type"
                .Columns("ChangeType").Width = 50
                .Columns("ChangeType").DisplayIndex = 4

                .Columns("DocumentNum").HeaderText = "Document#"
                .Columns("DocumentNum").Width = 80
                .Columns("DocumentNum").DisplayIndex = 5

                .Columns("DocumentRev").HeaderText = "Doc Rev"
                .Columns("DocumentRev").Width = 40
                .Columns("DocumentRev").DisplayIndex = 6

                .Columns("Requestor").HeaderText = "Requestor"
                .Columns("Requestor").Width = 80
                .Columns("Requestor").DisplayIndex = 7

                .Columns("Engineer").HeaderText = "Engineer"
                .Columns("Engineer").Width = 80
                .Columns("Engineer").DisplayIndex = 8

            End With
        Catch ex As Exception
            MsgBox("Cannot load My Requested ECR Items from: (LoadMyRequestedFinishedItems) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()



    End Sub

    'Loads Rails Items that are selected
    Public Sub GoToActionItemSelected()
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim clickon As String = ManagerForm.DataGridView4.CurrentRow.Cells(2).Value.ToString
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT ID, EcrConfNum, DateCreated, DateModified, DateAssigned, Status, ECRSubject, ReferenceDocLoc,  " &
                " Creator, CreatorEmail, ItemOwner, OwnerEmail, DateFinished FROM ucrms.ChangeRequestItemsDet " &
                " WHERE EcrConfNum = '" & clickon & "' "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView1
                newsqlconn.Open()
                .AutoGenerateColumns = True
            End With
            newsqlconn.Close()
        Catch ex As Exception
            MsgBox("Error loading comments: (GoToActionItemSelected) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub GoToRequestChangeSelected()
        Try
            Dim dt As New DataTable
            Dim bs As New BindingSource
            Dim clickon As String = ManagerForm.DataGridView4.CurrentRow.Cells(2).Value.ToString
            Dim newsqlconn As New SqlConnection(connstring)
            If newsqlconn.State = ConnectionState.Closed Then
                newsqlconn.Open()
            ElseIf newsqlconn.State = ConnectionState.Open Then
            End If

            sqlquery = "SELECT ID, EcrConfNum, plan_id, operation, category, Creator, CreatorEmail, DateCreated, DateModified, DateAssigned, " &
                " date_finished, description, Status, ItemOwner,OwnerEmail FROM ucrms.ChangeRequest " &
                " WHERE EcrConfNum = '" & clickon & "' "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView8.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView8
                newsqlconn.Open()
                .AutoGenerateColumns = True
                '.Columns("id").Visible = False
                '.Columns("comments").Visible = False
            End With
            newsqlconn.Close()
        Catch ex As Exception
            MsgBox("Error loading comments: (GoToRequestChangeSelected) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

#Region "LOADS ACTION ITEMS "

    Public Sub LoadAllActionItems()
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT *  FROM ActionItemsDet " &
                " WHERE ActionItemStatus NOT LIKE 'Finished' ORDER BY ID DESC "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView8.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView8

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("CreatorEmail").Visible = False
                .Columns("OwnerEmail").Visible = False
                .Columns("DateFinished").Visible = False


                .Columns("ActionItemStatus").HeaderText = "Status"
                .Columns("ActionItemStatus").Width = 15
                .Columns("ActionItemStatus").DisplayIndex = 0

                .Columns("ActionItemNum").HeaderText = "Action Item"
                .Columns("ActionItemNum").Width = 15
                .Columns("ActionItemNum").DisplayIndex = 1

                .Columns("DateDue").HeaderText = "Date Due"
                .Columns("DateDue").Width = 18
                .Columns("DateDue").DisplayIndex = 2

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 18
                .Columns("DateCreated").DisplayIndex = 3

                .Columns("Task").HeaderText = "Task"
                .Columns("Task").Width = 50
                .Columns("Task").DisplayIndex = 4

                .Columns("Reference").HeaderText = "Reference"
                .Columns("Reference").Width = 40
                .Columns("Reference").DisplayIndex = 5

                .Columns("State").HeaderText = "State"
                .Columns("State").Width = 18
                .Columns("State").DisplayIndex = 6

                .Columns("Creator").HeaderText = "Created By"
                .Columns("Creator").Width = 30
                .Columns("Creator").DisplayIndex = 7

                .Columns("Owner").HeaderText = "Owner"
                .Columns("Owner").Width = 80
                .Columns("Owner").DisplayIndex = 8

                For i As Integer = 0 To ManagerForm.DataGridView8.Rows.Count - 1
                    If ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "High" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Red
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Medium" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Blue
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Low" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Green
                    End If

                    If ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value Is DBNull.Value Then
                        ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value = ""
                    Else

                        Dim DueDate As Date = CType(ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value, Date)
                        Dim NowDate As Date = DateTime.Today.AddDays(10)
                        Dim TodayDate As Date = Now

                        If DueDate < TodayDate Then
                            ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Style.BackColor = Color.Red
                        ElseIf DueDate < NowDate Then
                            ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Style.BackColor = Color.Yellow
                        Else

                        End If

                    End If

                Next

                '***The below changes the whole row color***
                'For i As Integer = 0 To ManagerForm.DataGridView8.Rows.Count - 1
                '    If Trim(ManagerForm.DataGridView8.Rows(i).Cells("State").Value) = "High" Then
                '        ManagerForm.DataGridView8.Rows(i).DefaultCellStyle.BackColor = Color.Red
                '        ManagerForm.DataGridView8.Rows(i).DefaultCellStyle.ForeColor = Color.Yellow
                '    ElseIf Trim(ManagerForm.DataGridView8.Rows(i).Cells("State").Value) = "Medium" Then
                '        ManagerForm.DataGridView8.Rows(i).DefaultCellStyle.BackColor = Color.Blue
                '        ManagerForm.DataGridView8.Rows(i).DefaultCellStyle.ForeColor = Color.White
                '    ElseIf Trim(ManagerForm.DataGridView8.Rows(i).Cells("State").Value) = "Low" Then
                '        ManagerForm.DataGridView8.Rows(i).DefaultCellStyle.BackColor = Color.Green
                '        ManagerForm.DataGridView8.Rows(i).DefaultCellStyle.ForeColor = Color.White
                '    End If
                'Next

            End With
        Catch ex As Exception
            MsgBox("Cannot load ALL Action Items from: (LoadAllActionItems) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    Public Sub LoadMyAssignedActionItems()
        Dim ownerFullName As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT *  FROM ActionItemsDet " &
                " WHERE Owner  = '" & ownerFullName & "' AND ActionItemStatus NOT LIKE 'Finished' ORDER BY ID DESC "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView8.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView8

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("CreatorEmail").Visible = False
                .Columns("OwnerEmail").Visible = False
                .Columns("DateFinished").Visible = False


                .Columns("ActionItemStatus").HeaderText = "Status"
                .Columns("ActionItemStatus").Width = 15
                .Columns("ActionItemStatus").DisplayIndex = 0

                .Columns("ActionItemNum").HeaderText = "Action Item"
                .Columns("ActionItemNum").Width = 15
                .Columns("ActionItemNum").DisplayIndex = 1

                .Columns("DateDue").HeaderText = "Date Due"
                .Columns("DateDue").Width = 18
                .Columns("DateDue").DisplayIndex = 2

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 18
                .Columns("DateCreated").DisplayIndex = 3

                .Columns("Task").HeaderText = "Task"
                .Columns("Task").Width = 50
                .Columns("Task").DisplayIndex = 4

                .Columns("Reference").HeaderText = "Reference"
                .Columns("Reference").Width = 40
                .Columns("Reference").DisplayIndex = 5

                .Columns("State").HeaderText = "State"
                .Columns("State").Width = 18
                .Columns("State").DisplayIndex = 6

                .Columns("Creator").HeaderText = "Created By"
                .Columns("Creator").Width = 30
                .Columns("Creator").DisplayIndex = 7

                .Columns("Owner").HeaderText = "Owner"
                .Columns("Owner").Width = 80
                .Columns("Owner").DisplayIndex = 8

                For i As Integer = 0 To ManagerForm.DataGridView8.Rows.Count - 1
                    If ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "High" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Red
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Medium" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Blue
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Low" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Green
                    End If

                    If ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value Is DBNull.Value Then
                        ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value = ""
                    Else

                        Dim DueDate As Date = CType(ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value, Date)
                        Dim NowDate As Date = DateTime.Today.AddDays(10)
                        Dim TodayDate As Date = Now

                        If DueDate < TodayDate Then
                            ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Style.BackColor = Color.Red
                        ElseIf DueDate < NowDate Then
                            ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Style.BackColor = Color.Yellow
                        Else

                        End If

                    End If

                Next

            End With
        Catch ex As Exception
            MsgBox("Cannot load ALL Action Items from: (LoadAllActionItems) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
    End Sub

    Public Sub LoadMyFinishedActionItems()
        Dim ownerFullName As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT *  FROM ActionItemsDet " &
                " WHERE Owner  = '" & ownerFullName & "' AND ActionItemStatus = 'Finished' ORDER BY ID DESC "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView8.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView8

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("CreatorEmail").Visible = False
                .Columns("OwnerEmail").Visible = False
                .Columns("DateFinished").Visible = False


                .Columns("ActionItemStatus").HeaderText = "Status"
                .Columns("ActionItemStatus").Width = 15
                .Columns("ActionItemStatus").DisplayIndex = 0

                .Columns("ActionItemNum").HeaderText = "Action Item"
                .Columns("ActionItemNum").Width = 15
                .Columns("ActionItemNum").DisplayIndex = 1

                .Columns("DateDue").HeaderText = "Date Due"
                .Columns("DateDue").Width = 18
                .Columns("DateDue").DisplayIndex = 2

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 18
                .Columns("DateCreated").DisplayIndex = 3

                .Columns("Task").HeaderText = "Task"
                .Columns("Task").Width = 50
                .Columns("Task").DisplayIndex = 4

                .Columns("Reference").HeaderText = "Reference"
                .Columns("Reference").Width = 40
                .Columns("Reference").DisplayIndex = 5

                .Columns("State").HeaderText = "State"
                .Columns("State").Width = 18
                .Columns("State").DisplayIndex = 6

                .Columns("Creator").HeaderText = "Created By"
                .Columns("Creator").Width = 30
                .Columns("Creator").DisplayIndex = 7

                .Columns("Owner").HeaderText = "Owner"
                .Columns("Owner").Width = 80
                .Columns("Owner").DisplayIndex = 8

                For i As Integer = 0 To ManagerForm.DataGridView8.Rows.Count - 1
                    If ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "High" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Red
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Medium" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Blue
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Low" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Green
                    End If

                    If ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value Is DBNull.Value Then
                        ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value = ""
                    Else

                        Dim DueDate As Date = CType(ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Value, Date)
                        Dim NowDate As Date = DateTime.Today.AddDays(10)
                        Dim TodayDate As Date = Now

                        If DueDate < TodayDate Then
                            ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Style.BackColor = Color.Red
                        ElseIf DueDate < NowDate Then
                            ManagerForm.DataGridView8.Rows(i).Cells("DateDue").Style.BackColor = Color.Yellow
                        Else

                        End If

                    End If

                Next

            End With
        Catch ex As Exception
            MsgBox("Cannot load ALL Action Items from: (LoadAllActionItems) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
    End Sub
    'Items in the search bar will be queried 
    Public Sub SearchActionItems()
        Dim searchText As String = ManagerForm.searchBarActionItems.Text
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim bs As New BindingSource

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT *  FROM ActionItemsDet " &
                " WHERE ActionItemStatus LIKE '%" & searchText & "%'  " &
                " OR ActionItemNum LIKE '%" & searchText & "%' " &
                " OR DateCreated LIKE '%" & searchText & "%' " &
                " OR Task LIKE '%" & searchText & "%' " &
                " OR DateCreated LIKE '%" & searchText & "%'  " &
                " OR DateModified LIKE '%" & searchText & "%' " &
                " OR Reference LIKE '%" & searchText & "%' " &
                " OR State LIKE '%" & searchText & "%' " &
                " OR Creator LIKE '%" & searchText & "%' " &
                " OR Owner LIKE '%" & searchText & "%' " &
                " ORDER BY ID DESC"


            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView8.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView8

                .AutoGenerateColumns = True

                .Columns("ID").Visible = False
                .Columns("DateModified").Visible = False
                .Columns("DateAssigned").Visible = False
                .Columns("CreatorEmail").Visible = False
                .Columns("OwnerEmail").Visible = False
                .Columns("DateFinished").Visible = False

                .Columns("ActionItemStatus").HeaderText = "Status"
                .Columns("ActionItemStatus").Width = 30
                .Columns("ActionItemStatus").DisplayIndex = 0

                .Columns("ActionItemNum").HeaderText = "Action Item"
                .Columns("ActionItemNum").Width = 25
                .Columns("ActionItemNum").DisplayIndex = 1

                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 50
                .Columns("DateCreated").DisplayIndex = 2

                .Columns("Task").HeaderText = "Task"
                .Columns("Task").Width = 50
                .Columns("Task").DisplayIndex = 3

                .Columns("Reference").HeaderText = "Reference"
                .Columns("Reference").Width = 50
                .Columns("Reference").DisplayIndex = 4

                .Columns("State").HeaderText = "State"
                .Columns("State").Width = 30
                .Columns("State").DisplayIndex = 5

                .Columns("Creator").HeaderText = "Created By"
                .Columns("Creator").Width = 40
                .Columns("Creator").DisplayIndex = 6

                .Columns("Owner").HeaderText = "Owner"
                .Columns("Owner").Width = 80
                .Columns("Owner").DisplayIndex = 7


                For i As Integer = 0 To ManagerForm.DataGridView8.Rows.Count - 1
                    If ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "High" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Red
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Medium" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Blue
                    ElseIf ManagerForm.DataGridView8.Rows(i).Cells("State").Value = "Low" Then
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.ForeColor = Color.White
                        ManagerForm.DataGridView8.Rows(i).Cells("State").Style.BackColor = Color.Green
                    End If
                Next

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
    End Sub

#End Region

#Region "LOADING FLOW DATA"

    Public Sub searchFlowData()
        'Dim da As OleDbDataAdapter
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim sqlquery As String

        Dim dv As DataView = New DataView()

        Dim serialNumber As String = FlowData.cboFlowDataSerialNum.Text
        Dim workOrder As String = FlowData.cboFlowDataWorkOrder.Text
        Dim emplID As String = FlowData.cboOperator.Text
        Dim partNumber As String = FlowData.cboFlowDataPartNum.Text
        Dim operationDescr As String = FlowData.cboFlowDataOperationDescr.Text
        Dim passfail As String = FlowData.cboFlowDataPassFail.Text.ToString
        Dim testSearch As String = FlowData.txtSearchBar.Text
        'Dim startDate As String = FlowData.DateTimePickerStartDate.Text
        'Dim stopDate As String = FlowData.DateTimePickerStopDate.Text
        Dim startDate As Date = Date.Parse(FlowData.DateTimePickerStartDate.Text).ToString("MM'/'dd'/'yyyy")
        Dim stopDate As Date = Date.Parse(FlowData.DateTimePickerStopDate.Text).ToString("MM'/'dd'/'yyyy")

        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim date1 As Date
        'Dim date2 As Date
        'Dim date3 As Date
        Try

            If FlowData.cboFlowMachineName.Text = "6148-RLFS-LIQFL-WS02" Then

                Dim accesstring6148Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6148Liq)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults " '&
                '" WHERE OperatorID LIKE '%" & emplID & "%' " &
                '" AND DateString BETWEEN '%" & startDate & "%' AND '%" & stopDate & "%' "
                '" AND PartNumber LIKE '%" & partNumber & "%' " &
                '" AND OperationDescription LIKE '%" & operationDescr & "%' " &
                '" AND SerialNumber LIKE '%" & serialNumber & "%' " &
                '" AND PassFail LIKE '%" & passfail & "%' " &
                '" AND DateString BETWEEN #" & startDate & "# AND #" & stopDate & "# "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6609-RLFS-AIRFL-WS01" Then

                Dim accesstring6609Air As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6609-RLFS-AIRFL-WS01\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6609Air)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6610-GVFS-AIRFL-WS23" Then

                Dim accesstring6610Air As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6610-GVFS-AIRFL-WS23\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6610Air)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6800-GVFS-LIQFL-WS28" Then

                Dim accesstring6880Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6800-GVFS-LIQFL-WS28\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6880Liq)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6892-GVFS-AIRFL-WS27" Then

                Dim accesstring6892Air As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6892-GVFS-AIRFL-WS27\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6892Air)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            End If

            FlowData.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With FlowData.DataGridView1

                .AutoGenerateColumns = True

                .Columns(0).HeaderText = "Empl ID"
                .Columns(1).HeaderText = "Part #"
                .Columns(2).HeaderText = "OP Description"
                .Columns(3).HeaderText = "Serial #"
                .Columns(4).HeaderText = "Test Measure Value"
                .Columns(5).HeaderText = "Actual Set Point"
                .Columns(6).HeaderText = "Pass / Fail"

                Try
                    For i As Integer = 0 To FlowData.DataGridView1.Rows.Count - 1

                        If FlowData.DataGridView1.Rows(i).Cells("DateString").Value Is DBNull.Value Then
                            FlowData.DataGridView1.Rows(i).Cells("DateString").Value = ""
                        Else
                            .Columns("DateString").HeaderText = "Date"
                            Dim convertedDate As Date = FlowData.DataGridView1.Rows(i).Cells("DateString").Value
                            Dim newdate = DateTime.Parse(convertedDate)
                            date1 = CDate(newdate) ' prints 03/03/2019
                            FlowData.DataGridView1.Rows(i).Cells("DateString").Value = date1
                            .Columns("TimeString").HeaderText = "Time"
                        End If
                    Next

                Catch ex As Exception
                    MsgBox("Cannot load FlowData's crappy Date from access: " & ex.Message, MsgBoxStyle.Exclamation)
                End Try
                'newsqlconn.Close()

            End With
        Catch ex As Exception
            MsgBox("Cannot load FlowData: (LoadFlowData) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Sub LoadFlowData()
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim sqlquery As String

        Dim dv As DataView = New DataView()

        Dim serialNumber As String = FlowData.cboFlowDataSerialNum.Text
        Dim workOrder As String = FlowData.cboFlowDataWorkOrder.Text
        Dim emplID As String = FlowData.cboOperator.Text
        Dim partNumber As String = FlowData.cboFlowDataPartNum.Text
        Dim operationDescr As String = FlowData.cboFlowDataOperationDescr.Text
        Dim passfail As String = FlowData.cboFlowDataPassFail.Text
        'Dim startDate As String = FlowData.DateTimePickerStartDate.Text
        'Dim stopDate As String = FlowData.DateTimePickerStopDate.Text
        Dim startDate As Date = Date.Parse(FlowData.DateTimePickerStartDate.Text).ToString("MM'/'dd'/'yyyy")
        Dim stopDate As Date = Date.Parse(FlowData.DateTimePickerStopDate.Text).ToString("MM'/'dd'/'yyyy")

        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim date1 As Date
        'Dim date2 As Date
        'Dim date3 As Date
        Try

            If FlowData.cboFlowMachineName.Text = "6148-RLFS-LIQFL-WS02" Then

                Dim accesstring6148Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6148Liq)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults " '&
                '" WHERE OperatorID LIKE '%" & emplID & "%' " &
                '" AND DateString BETWEEN '%" & startDate & "%' AND '%" & stopDate & "%' "
                '" AND PartNumber LIKE '%" & partNumber & "%' " &
                '" AND OperationDescription LIKE '%" & operationDescr & "%' " &
                '" AND SerialNumber LIKE '%" & serialNumber & "%' " &
                '" AND PassFail LIKE '%" & passfail & "%' " &
                '" AND DateString BETWEEN #" & startDate & "# AND #" & stopDate & "# "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6609-RLFS-AIRFL-WS01" Then

                Dim accesstring6609Air As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6609-RLFS-AIRFL-WS01\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6609Air)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6610-GVFS-AIRFL-WS23" Then

                Dim accesstring6610Air As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6610-GVFS-AIRFL-WS23\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6610Air)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6800-GVFS-LIQFL-WS28" Then

                Dim accesstring6880Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6800-GVFS-LIQFL-WS28\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6880Liq)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            ElseIf FlowData.cboFlowMachineName.Text = "6892-GVFS-AIRFL-WS27" Then

                Dim accesstring6892Air As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6892-GVFS-AIRFL-WS27\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
                Dim newsqlconn As New OleDbConnection(accesstring6892Air)
                If newsqlconn.State = ConnectionState.Closed Then
                    newsqlconn.Open()
                ElseIf newsqlconn.State = ConnectionState.Open Then
                End If

                sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults "
                Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                bs.DataSource = dt

            End If

            FlowData.DataGridView1.DataSource = bs
            sqlda.Update(dt)
            With FlowData.DataGridView1

                .AutoGenerateColumns = True

                .Columns(0).HeaderText = "Empl ID"
                .Columns(1).HeaderText = "Part #"
                .Columns(2).HeaderText = "OP Description"
                .Columns(3).HeaderText = "Serial #"
                .Columns(4).HeaderText = "Test Measure Value"
                .Columns(5).HeaderText = "Actual Set Point"
                .Columns(6).HeaderText = "Pass / Fail"

                Try
                    For i As Integer = 0 To FlowData.DataGridView1.Rows.Count - 1

                        If FlowData.DataGridView1.Rows(i).Cells("DateString").Value Is DBNull.Value Then
                            FlowData.DataGridView1.Rows(i).Cells("DateString").Value = ""
                        Else
                            .Columns("DateString").HeaderText = "Date"
                            Dim convertedDate As Date = FlowData.DataGridView1.Rows(i).Cells("DateString").Value
                            Dim newdate = DateTime.Parse(convertedDate)
                            date1 = CDate(newdate) ' prints 03/03/2019
                            FlowData.DataGridView1.Rows(i).Cells("DateString").Value = date1
                            .Columns("TimeString").HeaderText = "Time"
                        End If
                    Next

                Catch ex As Exception
                    MsgBox("Cannot load FlowData's crappy Date from access: " & ex.Message, MsgBoxStyle.Exclamation)
                End Try
                'newsqlconn.Close()

            End With
        Catch ex As Exception
            MsgBox("Cannot load FlowData: (LoadFlowData) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

#End Region

#Region "LOADS COMMENTS IN THE COMMENTS SECTION"
    Public Sub LoadComments()
        Dim newsqlconn As New SqlConnection(connstring)
        Dim ecrNumber As String = ManagerForm.lblEcrNumberViewECRPage.Text
        Dim actionItemsNumber As String = ManagerForm.lblActionItemsWorkPage.Text

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        If ManagerForm.GroupBoxActionItemsWorkPage.Visible = True Then
            Try
                Dim dt As New DataTable
                Dim bs As New BindingSource

                sqlquery = "SELECT DateCreated, Notes FROM ActionItemsNotes " &
                    " WHERE ActionItemNum = '" & actionItemsNumber & "' ORDER BY DateCreated desc"

                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                sqlda.SelectCommand = sqlcmd

                sqlda.Fill(dt)
                bs.DataSource = dt
                ManagerForm.DataGridView5.DataSource = bs
                sqlda.Update(dt)
                With ManagerForm.DataGridView2
                    .AutoGenerateColumns = True
                    ManagerForm.DataGridView5.Columns("DateCreated").HeaderText = "Date Created"
                    ManagerForm.DataGridView5.Columns("DateCreated").Width = 125
                    ManagerForm.DataGridView5.Columns("Notes").HeaderText = "Notes"
                    '.Columns("ID").Visible = False
                    '.Columns("EcrConfNum").Visible = False
                    '.Columns("Date").Visible = True
                    '.Columns("Comments").Visible = True
                End With
            Catch ex As Exception
                MsgBox("Error: Notes Action Items (LoadComments) - " & ex.Message, MsgBoxStyle.Exclamation)
            End Try
            newsqlconn.Close()

        ElseIf ManagerForm.GroupBoxEditECRItems.Visible = True Then
            Try
                Dim dt As New DataTable
                Dim bs As New BindingSource

                sqlquery = "SELECT DateCreated, Description FROM tblComments " &
                    " WHERE EcrConfNum = '" & ecrNumber & "' ORDER BY DateCreated desc"

                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                sqlda.SelectCommand = sqlcmd

                sqlda.Fill(dt)
                bs.DataSource = dt
                ManagerForm.DataGridView2.DataSource = bs
                sqlda.Update(dt)
                With ManagerForm.DataGridView2
                    .AutoGenerateColumns = True
                    ManagerForm.DataGridView2.Columns("DateCreated").HeaderText = "Date Created"
                    ManagerForm.DataGridView2.Columns("DateCreated").Width = 125
                    ManagerForm.DataGridView2.Columns("Description").HeaderText = "Detailed Information"
                    '.Columns("ID").Visible = False
                    '.Columns("EcrConfNum").Visible = False
                    '.Columns("Date").Visible = True
                    '.Columns("Comments").Visible = True
                End With
            Catch ex As Exception
                MsgBox("Error: ECRs (LoadComments) - " & ex.Message, MsgBoxStyle.Exclamation)
            End Try
            newsqlconn.Close()


        Else

        End If



    End Sub

    Public Sub LoadComments_EditPage()
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim ecrNumber As String = ManagerForm.lblEcrNumberViewECRPage.Text
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT DateCreated, Description FROM tblComments " &
                " WHERE EcrConfNum = '" & ecrNumber & "' ORDER BY DateCreated desc"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView3.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView3
                .AutoGenerateColumns = True
                With ManagerForm.DataGridView3
                    .Columns("DateCreated").HeaderText = "Date Created"
                    .Columns("DateCreated").Width = 125
                    .Columns("Description").HeaderText = "Detailed Information"
                End With
            End With
        Catch ex As Exception
            MsgBox("Error: (LoadComments_EditPage) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    Public Sub LoadComments_RequestOPChangePage()
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Try
            Dim mydt As New DataTable
            Dim bs As New BindingSource

            sqlquery = "SELECT DateCreated, Description FROM tblComments " &
                " WHERE `EcrConfNum` = '" & ManagerForm.lblActionItemsWorkPage.Text & "' ORDER BY DateCreated desc"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(mydt)
            bs.DataSource = mydt
            ManagerForm.DataGridView5.DataSource = bs
            sqlda.Update(mydt)
            With ManagerForm.DataGridView5
                newsqlconn.Open()
                .AutoGenerateColumns = True
                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 125
                .Columns("Description").HeaderText = "Description"
                '.Columns("ID").Visible = False
                '.Columns("EcrConfNum").Visible = False
                '.Columns("Date").Visible = True
                '.Columns("Comments").Visible = True
            End With
            newsqlconn.Close()
        Catch ex As Exception
            MsgBox("Error loadin Comments: (LoadComments_RequestOPChangePage) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Public Sub LoadMyComments_RequestOPChangePage()
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Try
            Dim mydt As New DataTable
            Dim bs As New BindingSource

            sqlquery = "SELECT DateCreated, Description FROM tblComments " &
                " WHERE `EcrConfNum` = '" & ManagerForm.lblitemnum_viewopsheetchange.Text & "' ORDER BY DateCreated desc"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(mydt)
            bs.DataSource = mydt
            ManagerForm.DataGridView6.DataSource = bs
            sqlda.Update(mydt)
            With ManagerForm.DataGridView6
                newsqlconn.Open()
                .AutoGenerateColumns = True
                .Columns("DateCreated").HeaderText = "Date Created"
                .Columns("DateCreated").Width = 125
                .Columns("Description").HeaderText = "Description"
                '.Columns("ID").Visible = False
                '.Columns("EcrConfNum").Visible = False
                '.Columns("Date").Visible = True
                '.Columns("Comments").Visible = True
            End With
            newsqlconn.Close()
        Catch ex As Exception
            MsgBox("Error loadin Comments: (LoadMyComments_RequestOPChangePage) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

#End Region

#Region "LOADING COMBO BOXES"

    'Loads the list of the drop down Status in the combo box and diaplayed what the current status is
    Public Sub LoadCboStatusDropDown_EditPage()
        Dim newsqlconn As New SqlConnection(connstring)
        Dim dt As New DataTable
        Dim ecrStatus As String = ManagerForm.lblStatusViewEcrPage.Text

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Try

            ManagerForm.cboStatusECREditItemsPage.Text = ecrStatus
            sqlquery = "SELECT Status FROM tblStatus"
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)

            If dt.Rows.Count > 0 Then
                ManagerForm.cboStatusECREditItemsPage.DataSource = dt
                ManagerForm.cboStatusECREditItemsPage.DisplayMember = "Status"
                ManagerForm.cboStatusECREditItemsPage.ValueMember = "Status"
                ManagerForm.cboStatusECREditItemsPage.Text = ecrStatus
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading Status in the drop down box: (LoadCboStatusDropDown_EditPage) - " & ex.Message)
        End Try
        newsqlconn.Close()

    End Sub

    'Calls method to pull what the Status is of the items when selected.
    Public Sub LoadsStatusCBO_EditPage()
        Dim sqlquery As String
        Dim newSQLAdapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim ecrStatus As String = ManagerForm.lblStatusViewEcrPage.Text
        Dim ecrConfirmNum As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            If ecrStatus <> "" Then

                sqlquery = "SELECT EcrConfNum, Status FROM ChangeRequestItemsDet WHERE EcrConfNum = '" & ecrConfirmNum & "' "
                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                newSQLAdapter.SelectCommand = sqlcmd
                newSQLAdapter.Fill(dt)
                'newSQLAdapter = New SqlDataAdapter(sqlquery, newsqlconn)
                'newsqlconn.Open()
                newSQLAdapter.Fill(ds, "ucrms")

                If dt.Rows.Count > 0 Then
                    With ManagerForm
                        .lblStatusViewEcrPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
                        .cboStatusECREditItemsPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
                    End With
                Else
                End If

            Else
                LoadCboStatusDropDown_EditPage()
            End If

        Catch ex As Exception
            MsgBox("Cannot load combo box [Status]: (LoadCurrentStatusForCBO_EditPage) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub


    'Loads Status according to what the user had input in
    Public Sub LoadCurrentCboStatus_EditPage()
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            Dim sqlQuery As String
            'Dim newSQLAdapter As New SqlDataAdapter
            Dim ds As New DataSet
            'Dim ecfConfirmNum As String = ManagerForm.lblEcrNumViewPage.Text
            Dim ecfConfirmNum As String = ManagerForm.lblEcrNumECREditItemsPage.Text


            sqlQuery = "SELECT EcrConfNum, Status FROM ChangeRequestItemsDet WHERE EcrConfNum = ' " & ecfConfirmNum & " ' "
            'sqlda = New SqlDataAdapter(sqlQuery, newsqlconn)
            'newsqlconn.Open()
            sqlda.Fill(ds, "ucrms")

            With ManagerForm
                .cboStatusECREditItemsPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
            End With

            'MsgBox(ManagerForm.lblStatusViewEcrPage.Text)
        Catch ex As Exception
            MsgBox("Cannot load combo box [Status], Please contact the Administrator: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    Public Sub LoadOwnerNameDropdown_EditPage()
        Dim sqlQuery As String
        Dim newSQLAdapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim ecrConFirmNumb As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim dt As New DataTable
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlQuery = "SELECT EcrConfNum, ItemOwner FROM ChangeRequestItemsDet WHERE EcrConfNum = '" & ecrConFirmNumb & "' ORDER BY ItemOwner asc"
            sqlcmd = New SqlCommand(sqlQuery, newsqlconn)
            newSQLAdapter.SelectCommand = sqlcmd
            newSQLAdapter.Fill(dt)

            'newSQLAdapter = New SqlDataAdapter(sqlQuery, newsqlconn)

            'newsqlconn.Open()
            newSQLAdapter.Fill(ds, "ucrms")
            If dt.Rows.Count > 0 Then

                With ManagerForm
                    .cboEngineerECREditItemsPage.Text = ds.Tables("ucrms").Rows(0).Item(1).Value.ToString
                End With
            Else

            End If

        Catch ex As Exception
            MsgBox("Cannot load Item Owner: (LoadOwnerNameDropdown_EditPage) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    'Loads the list of names to choose from in the combo box 
    Public Sub LoadAssignedToUsersCbo_EditPage()
        Dim dt As New DataTable
        Dim ecrOwner As String = ManagerForm.lblEngineerViewEcrPage.Text

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        If ManagerForm.GroupBoxActionItemsWorkPage.Visible = True Then
            Try
                sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email  " &
                    " FROM useraccounts " &
                    " WHERE usertype = 'Engineer' " &
                    " ORDER BY Users asc"
                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dt)

                If dt.Rows.Count > 0 Then
                    With ManagerForm
                        .cboOwnerActionItemPage.DataSource = dt
                        .cboOwnerActionItemPage.DisplayMember = "Users"
                        .cboOwnerActionItemPage.ValueMember = "Users"
                        .cboOwnerActionItemPage.SelectedIndex = -1
                        .cboOwnerActionItemPage.Text = ManagerForm.DataGridView8.CurrentRow.Cells(11).Value.ToString
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading users into the dropdown box while editing items: (LoadUsersCbo_EditPage) - " & ex.Message)
            End Try
            newsqlconn.Close()

        ElseIf ManagerForm.GroupBoxEditECRItems.Visible = True Then
            Try
                sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email  " &
                    " FROM useraccounts " &
                    " WHERE usertype = 'Engineer' " &
                    " ORDER BY Users asc"
                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dt)

                If dt.Rows.Count > 0 Then
                    With ManagerForm
                        .cboEngineerECREditItemsPage.DataSource = dt
                        .cboEngineerECREditItemsPage.DisplayMember = "Users"
                        .cboEngineerECREditItemsPage.ValueMember = "Users"
                        .cboEngineerECREditItemsPage.SelectedIndex = -1
                        .cboEngineerECREditItemsPage.Text = ecrOwner
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading users into the dropdown box while editing items: (LoadUsersCbo_EditPage) - " & ex.Message)
            End Try
            newsqlconn.Close()


        Else

        End If



    End Sub

    'Public Sub LoadInfoToEcr_EditPage()
    '    Dim dt As New DataTable
    '    Dim sqlAdapter As New SqlDataAdapter

    '    Dim ECRNumber As String = ManagerForm.lblEcrNumberViewECRPage.Text

    '    Dim dateCreated As String = ManagerForm.lblDateCreatedViewECRPage.Text
    '    Dim dateModifed As String = ManagerForm.lblDateModifiedViewECRPage.Text
    '    Dim dateAssigned As String = ManagerForm.lblDateAssignedViewECRPage.Text
    '    Dim dateFinished As String = ManagerForm.lblDateFinishedViewECRPage.Text

    '    Dim requestorFullName As String = ManagerForm.lblRequestorViewECRPage.Text
    '    'Dim requestorEmail As String = ManagerForm.lblCreatedByEmailMainPage.Text
    '    Dim engineer As String = ManagerForm.lblEngineerViewEcrPage.Text
    '    'Dim engineerEmail As String = ManagerForm.lblAssignedToEmailMainPage.Text

    '    Dim statusECR As String = ManagerForm.lblStatusViewEcrPage.Text
    '    Dim siteECR As String = ManagerForm.lblSiteViewEcrPage.Text
    '    Dim changeTypeECR As String = ManagerForm.lblChangeTypeViewEcrPage.Text
    '    Dim docNumECR As String = ManagerForm.lblDocNumViewEcrPage.Text
    '    Dim docRevECR As String = ManagerForm.lblDocRevViewEcrPage.Text



    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    Try

    '        sqlquery = "Select * FROM ChangeRequestItemsDet Where EcrConfNum = '" & ECRNumber & "' "
    '        ' sqlquery = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECR_Number FROM tblauto WHERE ID = 2"

    '        sqlcmd = New SqlCommand(sqlquery, newsqlconn)
    '        Dim sqlReader As SqlDataReader = sqlcmd.ExecuteReader()

    '        While sqlReader.Read
    '            'MsgBox(sqlReader.GetString(2))
    '            'ManagerForm.lblEcrNumECREditItemsPage.Text = sqlReader.GetString(1)
    '            ManagerForm.lblDateCreatedECREditItemsPage.Text = sqlReader.GetDateTime(2)
    '            'ManagerForm.lblDateModifiedECREditItemsPage.Text = sqlReader.GetOrdinal(3) '.ToString("MM dd yyyy")
    '            'ManagerForm.lblDateFinishedECREditItemsPage.Text = sqlReader.GetValue(12) IsNot DBNull.Value
    '            'ManagerForm.lblDateAssignedECREditItemsPage.Text = sqlReader.GetValue(4) IsNot DBNull.Value
    '            ManagerForm.lblRequestorECREditItemsPage.Text = sqlReader.GetString(8)
    '            ManagerForm.cboStatusECREditItemsPage.Text = sqlReader.GetString(5)
    '            ManagerForm.txtECRSubjectECREditItemsPage.Text = sqlReader.GetString(6)
    '            ManagerForm.txtDocNumECREditItemsPage.Text = sqlReader.GetString(7)
    '            ManagerForm.cboEngineerECREditItemsPage.Text = sqlReader.GetString(10) IsNot DBNull.Value
    '        End While
    '        newsqlconn.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("Error loading ECR item to the edit page: (LoadInfoToEcr_EditPage) - " & ex.Message)
    '    End Try

    'End Sub

    Public Sub LoadCboStatusDropDown_RequestOPChangePage()
        Dim dt As New DataTable
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT `Status` FROM ucrms.tblStatus"
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)

            If dt.Rows.Count > 0 Then
                With ManagerForm
                    .cboStateActionItemPage.DataSource = dt
                    .cboStateActionItemPage.DisplayMember = "Status"
                    .cboStateActionItemPage.ValueMember = "Status"
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading Status in the drop down box : (LoadCboStatusDropDown_RequestOPChangePage) - " & ex.Message)
            newsqlconn.Close()

        End Try
    End Sub

    ' Loads the current Status on the item back into the view
    Public Sub LoadCurrentCboStatusDropDown_RequestOPChangePage()
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Try
            Dim sqlstr As String
            'Dim sqlda As New SqlDataAdapter
            Dim ds As New DataSet

            sqlstr = "SELECT EcrConfNum, Status FROM ChangeRequest " &
                " WHERE EcrConfNum = '" & ManagerForm.lblActionItemsWorkPage.Text & "' "
            'sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
            sqlda.Fill(ds, "ucrms")

            With ManagerForm
                .cboStateActionItemPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
            End With

        Catch ex As Exception
            MsgBox("Cannot load combo box, Please contact the Administrator" & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()

    End Sub

    Public Sub LoadCboIssueType_NewRequestOPChangePage()
        Dim dt As New DataTable
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT issue_type FROM IssueType"
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)

            If dt.Rows.Count > 0 Then
                With ManagerForm
                    .cboAddStateActionItemsPage.DataSource = dt
                    .cboAddStateActionItemsPage.DisplayMember = "issue_type"
                    .cboAddStateActionItemsPage.ValueMember = "issue_type"
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading Status in the issue type drop down box :" & ex.Message)
            newsqlconn.Close()

        End Try
        ManagerForm.cboAddStateActionItemsPage.SelectedIndex = -1

    End Sub

    Public Sub LoadCboIssueType_RequestOPChangePage()
        Dim dt As New DataTable
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT issue_type FROM IssueType"
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)

            If dt.Rows.Count > 0 Then
                With ManagerForm
                    .cboStatusActionItemPage.DataSource = dt
                    .cboStatusActionItemPage.DisplayMember = "issue_type"
                    .cboStatusActionItemPage.ValueMember = "issue_type"
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading Status in the issue type drop down box :" & ex.Message)
            newsqlconn.Close()

        End Try


    End Sub

    ' Loads the current Issue Type back into view when selected from datagridview8
    Public Sub LoadsCurrentIssueType_RequestOPChangePage()
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Try
            Dim sqlstr As String
            Dim sqlda As New SqlDataAdapter
            Dim ds As New DataSet

            sqlstr = "SELECT `EcrConfNum`, `category` FROM ucrms.tblchange_request " &
                " WHERE `EcrConfNum` = '" & ManagerForm.lblActionItemsWorkPage.Text & "' "
            'sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
            sqlda.Fill(ds, "ucrms")

            With ManagerForm
                .cboStatusActionItemPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
            End With

        Catch ex As Exception
            MsgBox("Cannot load combo box issue type, Please contact the Administrator" & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
    End Sub

    Public Sub LoadUsersCbo_RequestOPChangePage()

        Dim dt As New DataTable
        Dim sqladapter As New SqlDataAdapter
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try

            sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email, usertype AS type  " &
                " FROM ucrms.useraccounts ORDER BY Users asc"
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)

            If dt.Rows.Count > 0 Then
                With ManagerForm
                    .cboOwnerActionItemPage.DataSource = dt
                    .cboOwnerActionItemPage.DisplayMember = "Users"
                    .cboOwnerActionItemPage.ValueMember = "Users"
                    .cboOwnerActionItemPage.SelectedIndex = -1
                End With

            End If
            newsqlconn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading users into the dropdown box while editing items: " & ex.Message)
        End Try

    End Sub

    ' Loads the current user/ItemOwner into view when selected
    Public Sub LoadCurrentUsersCbo_RequestOPChangePage()

        Dim sqlstr As String
        Dim sqlda As New SqlDataAdapter
        Dim ds As New DataSet

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Try

            sqlstr = "SELECT `EcrConfNum`, `ItemOwner` FROM ucrms.tblchange_request " &
                    " WHERE `EcrConfNum` = '" & ManagerForm.lblActionItemsWorkPage.Text & "' ORDER BY ItemOwner asc"
            'sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
            sqlda.Fill(ds, "ucrms")

            With ManagerForm
                .cboOwnerActionItemPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
            End With


        Catch ex As Exception
            'MsgBox("Cannot load ItemOwner for the request OP sheet changes, please contact the Administrator, " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
    End Sub

    Public Sub CboloadCategory_RequestOPChangePage()

        Dim dt As New DataTable
        Dim sqladapter As New SqlDataAdapter
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try

            sqlquery = "SELECT ID AS ID, issue_type AS Category " &
                " FROM ucrms.IssueType"
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)

            If dt.Rows.Count > 0 Then
                With ManagerForm
                    .cboAddStateActionItemsPage.DataSource = dt
                    .cboAddStateActionItemsPage.DisplayMember = "Category"
                    .cboAddStateActionItemsPage.ValueMember = "Category"
                    .cboAddStateActionItemsPage.SelectedIndex = -1
                End With

            End If
            newsqlconn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading category into the dropdown box in the add items page: " & ex.Message)
        End Try

    End Sub

    Public Sub LoadUsersCbo_AddECRPage() ' Loads the combo box with the users

        Dim dt As New DataTable
        Dim sqlda As New SqlDataAdapter
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If


        If ManagerForm.GroupBox_ActionItemsPage.Visible = True Then
            Try
                sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email, usertype AS type  " &
                    " FROM useraccounts ORDER BY Users asc"
                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dt)

                If dt.Rows.Count > 0 Then
                    With ManagerForm
                        .cboAddOwnerNewECRPage.DisplayMember = "Users"
                        .cboAddOwnerNewECRPage.DataSource = dt
                        .cboAddOwnerNewECRPage.ValueMember = "Users"
                        .cboAddOwnerNewECRPage.SelectedIndex = -1
                        'MessageBox.Show(.cboAddOwner.DisplayMember)
                    End With

                End If
                newsqlconn.Close()

            Catch ex As Exception
                MessageBox.Show("Error loading users into the dropdown box in the add new ECR page: (LoadUsersCbo_AddPage) - " & ex.Message)
            End Try

        ElseIf ManagerForm.GroupBoxAddNewECR.Visible = True Then
            Try
                sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email, usertype AS type  " &
                    " FROM useraccounts ORDER BY Users asc"
                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dt)

                If dt.Rows.Count > 0 Then
                    With ManagerForm
                        .cboAddOwnerNewECRPage.DisplayMember = "Users"
                        .cboAddOwnerNewECRPage.DataSource = dt
                        .cboAddOwnerNewECRPage.ValueMember = "Users"
                        .cboAddOwnerNewECRPage.SelectedIndex = -1
                        'MessageBox.Show(.cboAddOwner.DisplayMember)
                    End With

                End If
                newsqlconn.Close()

            Catch ex As Exception
                MessageBox.Show("Error loading users into the dropdown box in the add new ECR page: (LoadUsersCbo_AddPage) - " & ex.Message)
            End Try

        Else

        End If




    End Sub

    Public Sub LoadOwnerECREditPage()

        Dim dt As New DataTable
        Dim sqladapter As New SqlDataAdapter
        Dim myReader As SqlDataReader
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM (SELECT ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype FROM useraccounts) base " &
                " WHERE FullName = '" & ManagerForm.cboEngineerECREditItemsPage.Text & "' "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            myReader = sqlcmd.ExecuteReader

            While myReader.Read
                ManagerForm.lblowner_id_edit.Text = myReader.GetInt32(0)
                ManagerForm.lblAssignedToFullNameMainPage.Text = myReader.GetString(3)
                ManagerForm.lblItemOwnersEmailMainPage.Text = myReader.GetString(4)
                ManagerForm.lblUserTypeMainPage.Text = myReader.GetString(5)
                'lblcreators_email.Text = myReader.GetString("CreatorEmail")
            End While
            newsqlconn.Close()

        Catch ex As Exception
            MessageBox.Show("Error in this section: (LoadOwnerECREditPage) - " & ex.Message)
        End Try
    End Sub

    Public Sub LoadOwnerInfoNewEcrPage()

        Dim dt As New DataTable
        Dim sqladapter As New SqlDataAdapter
        Dim myReader As SqlDataReader
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM (SELECT id, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype FROM useraccounts) base " &
                " WHERE FullName = '" & ManagerForm.cboAddOwnerNewECRPage.Text & "' "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            myReader = sqlcmd.ExecuteReader

            While myReader.Read
                ManagerForm.lblowner_id_edit.Text = myReader.GetInt32(0)
                ManagerForm.lblAssignedToFullNameMainPage.Text = myReader.GetString(3)
                ManagerForm.lblItemOwnersEmailMainPage.Text = myReader.GetString(4)
                ManagerForm.lblUserTypeMainPage.Text = myReader.GetString(5)
                'lblcreators_email.Text = myReader.GetString("CreatorEmail")
            End While
            newsqlconn.Close()

        Catch ex As Exception
            MessageBox.Show("Error in this section: LoadOwnerInfoNewEcrPage " & ex.Message)
        End Try
    End Sub

#End Region

#Region "ADDING NEW ITEMS INTO ECR"

    Public Sub AddNewEcrItems()
        Dim confNumECR As String = ManagerForm.lblECRNumNewECRPage.Text
        Dim siteECR As String = ManagerForm.cboAddEcrSiteNewECRPage.Text
        Dim changeTypeECR As String = ManagerForm.cboAddChangeTypeNewECRPage.Text
        Dim docNumECR As String = ManagerForm.txtAddEcrDocNumNewECRPage.Text
        Dim docRevECR As String = ManagerForm.txtAddEcrDocRevNewECRPage.Text
        Dim requestorECR As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim requestorEmailECR As String = ManagerForm.lblUserEmailMainForm.Text

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            Using (newsqlconn)
                Dim sqlcmd As New SqlCommand()
                With sqlcmd
                    .Connection = newsqlconn
                    .CommandText = "sp_InsertNewEcrRecords"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@EcrConfNum", confNumECR)
                    .Parameters.AddWithValue("@Site", siteECR)
                    .Parameters.AddWithValue("@DateCreated", Now)
                    .Parameters.AddWithValue("@Status", "New")
                    .Parameters.AddWithValue("@ChangeType", changeTypeECR)
                    .Parameters.AddWithValue("@DocumentNum", docNumECR)
                    .Parameters.AddWithValue("@DocumentRev", docRevECR)
                    .Parameters.AddWithValue("@Requestor", requestorECR)
                    .Parameters.AddWithValue("@RequestorEmail", requestorEmailECR)
                    .ExecuteNonQuery()
                End With
            End Using
            'Inserts the Descriptions into SQL
            InsertNewDescriptionsNotes()
            MsgBox("Thank you, your request has been sent to Engineering.")
        Catch ex As Exception
            MessageBox.Show("Cannot create a New ECR - (AddNewEcrItems) :   " & ex.Message)
        End Try
        newsqlconn.Close()

    End Sub

#End Region

#Region "ADDING NEW ACTION ITEMS"
    Public Sub AddNewActionItems()
        Dim actionItemNum As String = ManagerForm.lblActionItemsNewPage.Text
        Dim taskItem As String = ManagerForm.txtAddTaskActionItemsPage.Text
        Dim referenceItem As String = ManagerForm.txtAddReferenceActionItemsPage.Text
        Dim stateItem As String = ManagerForm.cboAddStateActionItemsPage.Text
        Dim descriptionItem As String = ManagerForm.txtAddNotesActionItemsPage.Text
        Dim creatorOfItem As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim creatorEmail As String = ManagerForm.lblUserEmailMainForm.Text
        Dim dateDue As String = ManagerForm.DateTimePicker1.Value
        Dim newsqlconn As New SqlConnection(connstring)

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            Using (newsqlconn)
                Dim sqlcmd As New SqlCommand()
                With sqlcmd
                    .Connection = newsqlconn
                    .CommandText = "sp_InsertNewActionItems"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                    .Parameters.AddWithValue("@Task", taskItem)
                    .Parameters.AddWithValue("@Reference", referenceItem)
                    .Parameters.AddWithValue("@State", stateItem)
                    .Parameters.AddWithValue("@DateCreated", Now)
                    .Parameters.AddWithValue("@Creator", creatorOfItem)
                    .Parameters.AddWithValue("@CreatorEmail", creatorEmail)
                    .Parameters.AddWithValue("@ActionItemStatus", "New")
                    .Parameters.AddWithValue("@DateDue", dateDue)
                    .ExecuteNonQuery()
                End With
            End Using
            'Inserts the Descriptions into SQL
            InsertNewDescriptionsNotes()

            MsgBox("Action Item has been created. ")
        Catch ex As Exception
            MessageBox.Show("Cannot create a New Action Item - (AddNewActionItems) :   " & ex.Message)
        End Try
        newsqlconn.Close()

    End Sub

#End Region

#Region "EDITING/UPDATE ECR ITEMS"
    Public Sub UpdateECRItems()

        Dim sqlda As New SqlDataAdapter
        Dim mydatatable As New DataTable
        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text ' The current logged in user
        Dim numberECR As String = ManagerForm.lblEcrNumECREditItemsPage.Text ' ECR Confirmation Number
        Dim statusECR As String = ManagerForm.cboStatusECREditItemsPage.Text ' Current Status of the ECR
        Dim siteECR As String = ManagerForm.cboSiteECREditItemsPage.Text ' Site / location for the ECR
        Dim changeTypeECR As String = ManagerForm.cboChangeTypeECREditItemsPage.Text ' ECR's Change Type
        Dim docNumECR As String = ManagerForm.txtDocNumECREditItemsPage.Text 'Document Number
        Dim docRevECR As String = ManagerForm.txtDocRevECREditItemsPage.Text ' Document Revision
        Dim RequestorFullName As String = ManagerForm.lblRequestorECREditItemsPage.Text 'Requestor's Full Name
        Dim requestorEmail As String = ManagerForm.lblRequestorEmailMainPage.Text 'Requestor's Email
        Dim engineer As String = ManagerForm.cboEngineerECREditItemsPage.Text 'Engineer that is assigned to this ECR
        Dim engineerEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text 'Engineer's Email
        Dim descriptionECR As String = ManagerForm.txtDescriptionECREditItemsPage.Text ' The description of the ECR

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        'If statement starts here collects the information depending on how the user enters the data
        If changeTypeECR = "" Then
            MsgBox("An ECR Item has To be filled out first before continuing.")
        ElseIf statusECR = "Finished" Then

            Try
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(mydatatable)

                If engineer <> RequestorFullName And engineer <> currentLoggedInUser Then
                    Using cmdSaveVend As New SqlCommand()
                        cmdSaveVend.Connection = newsqlconn
                        With cmdSaveVend
                            .CommandText = "UPDATE ChangeRequestItemsDet " &
                            " SET DateFinished=@DateFinished, " &
                            " Status=@Status, " &
                            " Site=@Site, " &
                            " ChangeType=@ChangeType, " &
                            " DocumentNum=@DocumentNum, " &
                            " DocumentRev=@DocumentRev, " &
                            " Engineer=@Engineer, " &
                            " EngineerEmail=@EngineerEmail " &
                            " WHERE EcrConfNum = '" & numberECR & "';"

                            .CommandType = Data.CommandType.Text
                            .Parameters.AddWithValue("@DateFinished", Now)
                            .Parameters.AddWithValue("@Status", statusECR)
                            .Parameters.AddWithValue("@Site", siteECR)
                            .Parameters.AddWithValue("@ChangeType", changeTypeECR)
                            .Parameters.AddWithValue("@DocumentNum", docNumECR)
                            .Parameters.AddWithValue("@DocumentRev", docRevECR)
                            .Parameters.AddWithValue("@Engineer", engineer)
                            .Parameters.AddWithValue("@EngineerEmail", engineerEmail)

                        End With
                        cmdSaveVend.ExecuteNonQuery()
                    End Using
                    newsqlconn.Close()
                    'Calls the function to write all the comments on a seperate table to track the history of it
                    UpdateDescriptionsECRItems()

                    publicvariables.SendeMail_FinishedECRFromAnotherEngineer()
                    'publicvariables.SendeMail_FinishedECR()
                    'Logging Finished Items into history for tracking purposes 
                    LogAllFinishedActions()
                    'MsgBox("Engineer IS NOT the Requestor")

                ElseIf engineer = currentLoggedInUser Then

                    Using cmdSaveVend As New SqlCommand()
                        cmdSaveVend.Connection = newsqlconn
                        With cmdSaveVend
                            .CommandText = "UPDATE ChangeRequestItemsDet " &
                        " SET DateFinished=@DateFinished, " &
                        " Status=@Status, " &
                        " Site=@Site, " &
                        " ChangeType=@ChangeType, " &
                        " DocumentNum=@DocumentNum, " &
                        " DocumentRev=@DocumentRev, " &
                        " Engineer=@Engineer, " &
                        " EngineerEmail=@EngineerEmail " &
                        " WHERE EcrConfNum = '" & numberECR & "';"

                            .CommandType = Data.CommandType.Text
                            .Parameters.AddWithValue("@DateFinished", Now)
                            .Parameters.AddWithValue("@Status", statusECR)
                            .Parameters.AddWithValue("@Site", siteECR)
                            .Parameters.AddWithValue("@ChangeType", changeTypeECR)
                            .Parameters.AddWithValue("@DocumentNum", docNumECR)
                            .Parameters.AddWithValue("@DocumentRev", docRevECR)
                            .Parameters.AddWithValue("@Engineer", engineer)
                            .Parameters.AddWithValue("@EngineerEmail", engineerEmail)
                        End With
                        cmdSaveVend.ExecuteNonQuery()
                    End Using
                    newsqlconn.Close()
                    'Calls the function to write all the comments on a seperate table to track the history of it
                    UpdateDescriptionsECRItems()
                    publicvariables.SendeMail_FinishedECR()
                    'publicvariables.SendeMail_FinishedECRFromAnotherEngineer()
                    'Logging Finished Items into history for tracking purposes 
                    LogAllFinishedActions()
                    'MsgBox("Engineer IS the Requestor")
                End If

                MsgBox("ECR Item: " & " '" & numberECR & "' " & " has been marked as finished.")

            Catch ex As SqlException
                MsgBox("Error cannot exceute finished, (second if statement) -  " & ex.Message, MsgBoxStyle.Information)
            End Try

        ElseIf statusECR <> "Finished" Then

            Try
                If currentLoggedInUser <> engineer Then
                    Try
                        Dim dt As New DataTable
                        Dim da As New SqlDataAdapter
                        Dim bs As New BindingSource
                        Dim reader As SqlDataReader
                        Dim engineerName As String

                        Try
                            sqlquery = "SELECT Engineer FROM ChangeRequestItemsDet WHERE EcrConfNum = @numberECR "
                            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                            sqlcmd.Parameters.AddWithValue("@numberECR", numberECR)
                            reader = sqlcmd.ExecuteReader


                            If reader.Read AndAlso Not reader.IsDBNull(0) Then
                                'This command will run IF the reader finds an assigned Engineer ONLY.
                                engineerName = reader.GetString(0)
                                'MsgBox("Engineer is: " & reader.GetString(0))

                                If ManagerForm.lblUserFullNameMainForm.Text <> engineerName Then
                                    'MsgBox("This belongs to: " & engineerName)
                                    '
                                    Dim conn As New SqlConnection(connstring)
                                    If conn.State = ConnectionState.Closed Then
                                        conn.Open()
                                    ElseIf conn.State = ConnectionState.Open Then
                                    End If
                                    Using cmdSaveVend As New SqlCommand()
                                        cmdSaveVend.Connection = conn
                                        With cmdSaveVend
                                            .CommandText = "UPDATE ChangeRequestItemsDet " &
                                                " SET DateModified=@DateModified, " &
                                                " Status=@Status, " &
                                                " Site=@Site, " &
                                                " ChangeType=@ChangeType, " &
                                                " DocumentNum=@DocumentNum, " &
                                                " DocumentRev=@DocumentRev, " &
                                                " Engineer=@Engineer, " &
                                                " EngineerEmail=@EngineerEmail " &
                                                " WHERE EcrConfNum = '" & numberECR & "';"

                                            .CommandType = Data.CommandType.Text
                                            .Parameters.AddWithValue("@DateModified", Now)
                                            .Parameters.AddWithValue("@Status", statusECR)
                                            .Parameters.AddWithValue("@Site", siteECR)
                                            .Parameters.AddWithValue("@ChangeType", changeTypeECR)
                                            .Parameters.AddWithValue("@DocumentNum", docNumECR)
                                            .Parameters.AddWithValue("@DocumentRev", docRevECR)
                                            .Parameters.AddWithValue("@Engineer", engineer)
                                            .Parameters.AddWithValue("@EngineerEmail", engineerEmail)
                                        End With
                                        cmdSaveVend.ExecuteNonQuery()
                                        newsqlconn.Close()
                                    End Using
                                    'newsqlconn.Close()
                                    'Send Email
                                    publicvariables.SendEmailECRStatusToAssignedEngineer()

                                ElseIf ManagerForm.lblUserFullNameMainForm.Text = engineerName Then
                                    'MsgBox("This belongs to You!")

                                    Dim conn As New SqlConnection(connstring)
                                    If conn.State = ConnectionState.Closed Then
                                        conn.Open()
                                    ElseIf conn.State = ConnectionState.Open Then
                                    End If
                                    'MsgBox("No Assigned Engineer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    Using cmdSaveVend As New SqlCommand()
                                        cmdSaveVend.Connection = conn
                                        With cmdSaveVend
                                            .CommandText = "UPDATE ChangeRequestItemsDet " &
                                                " SET DateModified=@DateModified, " &
                                                " Status=@Status, " &
                                                " Site=@Site, " &
                                                " ChangeType=@ChangeType, " &
                                                " DocumentNum=@DocumentNum, " &
                                                " DocumentRev=@DocumentRev, " &
                                                " Engineer=@Engineer, " &
                                                " EngineerEmail=@EngineerEmail " &
                                                " WHERE EcrConfNum = '" & numberECR & "';"

                                            .CommandType = Data.CommandType.Text
                                            .Parameters.AddWithValue("@DateModified", Now)
                                            .Parameters.AddWithValue("@Status", statusECR)
                                            .Parameters.AddWithValue("@Site", siteECR)
                                            .Parameters.AddWithValue("@ChangeType", changeTypeECR)
                                            .Parameters.AddWithValue("@DocumentNum", docNumECR)
                                            .Parameters.AddWithValue("@DocumentRev", docRevECR)
                                            .Parameters.AddWithValue("@Engineer", engineer)
                                            .Parameters.AddWithValue("@EngineerEmail", engineerEmail)
                                        End With
                                        cmdSaveVend.ExecuteNonQuery()
                                        'newsqlconn.Close()
                                    End Using
                                    newsqlconn.Close()
                                    publicvariables.SendEmailECRStatus()

                                End If

                            ElseIf reader.IsDBNull(0) Then
                                ' Runs these commands if there are no assigned Engineers of the item.

                                Dim conn As New SqlConnection(connstring)
                                If conn.State = ConnectionState.Closed Then
                                    conn.Open()
                                ElseIf conn.State = ConnectionState.Open Then
                                End If

                                Using cmdSaveVend As New SqlCommand()
                                    cmdSaveVend.Connection = conn
                                    With cmdSaveVend
                                        .CommandText = "UPDATE ChangeRequestItemsDet " &
                                                " SET DateModified=@DateModified, " &
                                                " DateAssigned=@DateAssigned, " &
                                                " Status=@Status, " &
                                                " Site=@Site, " &
                                                " ChangeType=@ChangeType, " &
                                                " DocumentNum=@DocumentNum, " &
                                                " DocumentRev=@DocumentRev, " &
                                                " Engineer=@Engineer, " &
                                                " EngineerEmail=@EngineerEmail " &
                                                " WHERE EcrConfNum = '" & numberECR & "';"

                                        .CommandType = Data.CommandType.Text
                                        .Parameters.AddWithValue("@DateModified", Now)
                                        .Parameters.AddWithValue("@DateAssigned", Now)
                                        .Parameters.AddWithValue("@Status", statusECR)
                                        .Parameters.AddWithValue("@Site", siteECR)
                                        .Parameters.AddWithValue("@ChangeType", changeTypeECR)
                                        .Parameters.AddWithValue("@DocumentNum", docNumECR)
                                        .Parameters.AddWithValue("@DocumentRev", docRevECR)
                                        .Parameters.AddWithValue("@Engineer", engineer)
                                        .Parameters.AddWithValue("@EngineerEmail", engineerEmail)
                                    End With
                                    cmdSaveVend.ExecuteNonQuery()
                                    'newsqlconn.Close()
                                End Using
                                newsqlconn.Close()
                                'send email of resassignment
                                publicvariables.SendEmailECRReassignment()
                            Else
                            End If '<--- Reader Closed
                            reader.Close()

                        Catch ex As Exception
                            MsgBox("Error " & ex.Message, MsgBoxStyle.Information)
                        End Try
                        MsgBox("Thank you.")

                        'Calls the function to write all the comments on a seperate table to track the history of it
                        UpdateDescriptionsECRItems()
                        'Logging into history for tracking purposes 
                        LogAllFinishedActions()
                        'End If
                        'MsgBox("You are saving another Engineer's work")
                    Catch ex As Exception
                        MsgBox("Error cannot exceute saving ECR item, (third if statement) - " & ex.Message, MsgBoxStyle.Information)
                    End Try

                ElseIf engineer = currentLoggedInUser Then
                    Using cmdSaveVend As New SqlCommand()
                        cmdSaveVend.Connection = newsqlconn
                        With cmdSaveVend
                            .CommandText = "UPDATE ChangeRequestItemsDet " &
                            " SET DateModified=@DateModified, " &
                            " Status=@Status, " &
                            " Site=@Site, " &
                            " ChangeType=@ChangeType, " &
                            " DocumentNum=@DocumentNum, " &
                            " DocumentRev=@DocumentRev, " &
                            " Engineer=@Engineer, " &
                            " EngineerEmail=@EngineerEmail " &
                            " WHERE EcrConfNum = '" & numberECR & "';"

                            .CommandType = Data.CommandType.Text
                            .Parameters.AddWithValue("@DateModified", Now)
                            .Parameters.AddWithValue("@Status", statusECR)
                            .Parameters.AddWithValue("@Site", siteECR)
                            .Parameters.AddWithValue("@ChangeType", changeTypeECR)
                            .Parameters.AddWithValue("@DocumentNum", docNumECR)
                            .Parameters.AddWithValue("@DocumentRev", docRevECR)
                            .Parameters.AddWithValue("@Engineer", engineer)
                            .Parameters.AddWithValue("@EngineerEmail", engineerEmail)

                        End With
                        cmdSaveVend.ExecuteNonQuery()
                        newsqlconn.Close()
                    End Using
                    'Calls the function to write all the comments on a seperate table to track the history of it
                    UpdateDescriptionsECRItems()
                    publicvariables.SendEmailECRStatus()
                    'Logging into history for tracking purposes 
                    LogAllFinishedActions()
                    'MsgBox("Assigned Engineer IS saving this")
                End If

            Catch ex As SqlException
                MsgBox("Error cannot exceute saving ECR item, (fourth if statement) - " & ex.Message, MsgBoxStyle.Information)
            End Try

        Else

        End If

        'MsgBox("Action Item: " & " '" & ManagerForm.lblitemnum_editactionitempage.Text & "' " & " has been saved.")
        Clearfields()
        ClearTextBoxes()
        ManagerForm.cboStatusECREditItemsPage.SelectedIndex = -1
        ManagerForm.cboEngineerECREditItemsPage.SelectedIndex = -1
        ManagerForm.cboSiteECREditItemsPage.SelectedIndex = -1
        ManagerForm.cboChangeTypeECREditItemsPage.SelectedIndex = -1

    End Sub

#End Region

#Region "EDITING/UPDATE ACTION ITEMS"

    Public Sub UpdateActionItems()

        Dim sqlda As New SqlDataAdapter
        Dim mydatatable As New DataTable
        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim creatorFullName As String = ManagerForm.lblCreatedByActionItemsPage.Text
        Dim creatorEmail As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim ownerOfItem As String = ManagerForm.cboOwnerActionItemPage.Text
        Dim ownersEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        Dim dateModified As String = ManagerForm.lblDateModifiedActionItemPage.Text
        Dim dateAssigned As String = ManagerForm.lblDateAssignedActionItemPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedActionItemPage.Text
        Dim stateOfItem As String = ManagerForm.cboStateActionItemPage.Text
        Dim statusOfItem As String = ManagerForm.cboStatusActionItemPage.Text
        Dim notesActionItem As String = ManagerForm.txtNotesActionItemPage.Text
        Dim showCurrentItemOwner As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim bs As New BindingSource
        Dim reader As SqlDataReader

        'If statement starts here collects the information depending on how the user enters the data
        If stateOfItem = "" Then
            MsgBox("Please choose the state of the Action Item.")
        ElseIf statusOfItem = "" Then
            MsgBox("Please choose the status of the Action Item.")
        ElseIf statusOfItem = "Finished" Then
            'When the item has been Finished do this...

            Dim newsqlconn As New SqlConnection(connstring)
            If newsqlconn.State = ConnectionState.Closed Then
                newsqlconn.Open()
            ElseIf newsqlconn.State = ConnectionState.Open Then
            End If
            sqlquery = "SELECT Owner FROM ActionItemsDet WHERE ActionItemNum = @ActionItemNum "
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlcmd.Parameters.AddWithValue("@ActionItemNum", actionItemNum)
            reader = sqlcmd.ExecuteReader

            If reader.Read AndAlso Not reader.IsDBNull(0) Then
                'If there is an owner, then this method kicks in.
                showCurrentItemOwner = reader.GetString(0)
                'MsgBox("This action Item has an owner! It is: " & reader.GetString(0))

                If currentLoggedInUser <> showCurrentItemOwner Then
                    SaveUpdateActionItems()
                    'Insert Notes
                    UpdateActionItemsNotes()
                    'Insert logging
                    LogAllActivityActionItems()
                    'Send Email to both parties
                    publicvariables.SendeMail_FinishedActionItems()

                ElseIf currentLoggedInUser = showCurrentItemOwner Then
                    SaveUpdateActionItems()
                    'Insert Notes
                    UpdateActionItemsNotes()
                    'Insert logging
                    LogAllActivityActionItems()
                    'Send email to yourself /the logged in user
                    publicvariables.SendeMail_FinishedActionItems()

                End If

            ElseIf reader.IsDBNull(0) Then
                'If there is no owner, then this method kicks in.
                'MsgBox("The search found no assigned owners to this action item.")
                SaveUpdateActionItems()

                'Insert Notes
                UpdateActionItemsNotes()
                'Insert logging
                LogAllActivityActionItems()
                'Send email to new owner of item even though the action item is finished

                publicvariables.SendeMail_FinishedActionItems()


            Else
            End If '<--- Reader Closed
            reader.Close()

            'If the logged in user is finishing hie/her own action item then do this.
            If currentLoggedInUser <> showCurrentItemOwner Then

                'If the current logged in user is editing another owner's action item, do this...
            ElseIf currentLoggedInUser = showCurrentItemOwner Then

            End If

        ElseIf statusOfItem <> "Finished" Then
            'When item is not finished but updating it only, do this...
            SaveUpdateActionItems()

            'Insert Notes
            UpdateActionItemsNotes()
            'Insert logging
            LogAllActivityActionItems()

            publicvariables.SendeMail_UpdateActionItem()
        Else

        End If

        'MsgBox("Action Item: " & " '" & ManagerForm.lblitemnum_editactionitempage.Text & "' " & " has been saved.")
        Clearfields()
        ClearTextBoxes()
        ManagerForm.cboStateActionItemPage.SelectedIndex = -1
        ManagerForm.cboStatusActionItemPage.SelectedIndex = -1
        ManagerForm.cboOwnerActionItemPage.SelectedIndex = -1
        ManagerForm.cboChangeTypeECREditItemsPage.SelectedIndex = -1

    End Sub

    Public Sub SaveUpdateActionItems()
        Dim sqlstr As String
        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim creatorFullName As String = ManagerForm.lblCreatedByActionItemsPage.Text
        Dim creatorEmail As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim ownerOfItem As String = ManagerForm.cboOwnerActionItemPage.Text
        Dim ownersEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        Dim dateModified As String = ManagerForm.lblDateModifiedActionItemPage.Text
        Dim dateAssigned As String = ManagerForm.lblDateAssignedActionItemPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedActionItemPage.Text
        Dim stateOfItem As String = ManagerForm.cboStateActionItemPage.Text
        Dim statusOfItem As String = ManagerForm.cboStatusActionItemPage.Text
        Dim notesActionItem As String = ManagerForm.txtNotesActionItemPage.Text
        Dim dateDue As Date = ManagerForm.DateTimePicker2.Value
        Dim emailOFAsssignedOwner As String
        Dim conn As New SqlConnection(connstring)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        ElseIf conn.State = ConnectionState.Open Then
        End If

        Dim newDataSet As New DataSet
        'Grabbing the newly assigned owner's email from here
        sqlstr = "SELECT * FROM (SELECT id as ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype as Type, emplid AS EmployeeID" &
            " FROM useraccounts) base WHERE FullName = '" & ownerOfItem & "'"
        sqlda = New SqlDataAdapter(sqlstr, conn)
        sqlda.Fill(newDataSet, "ucrms")
        emailOFAsssignedOwner = newDataSet.Tables("ucrms").Rows(0).Item(4)
        'MsgBox(newOwnerEmailActionItem)


        If statusOfItem = "Finished" Then

            If currentLoggedInUser = ownerOfItem Then
                Using cmdSaveVend As New SqlCommand()
                    cmdSaveVend.Connection = conn
                    With cmdSaveVend
                        .CommandText = "UPDATE ActionItemsDet " &
                            " SET DateFinished=@DateFinished, " &
                            " State=@State, " &
                            " Owner=@Owner, " &
                            " OwnerEmail=@OwnerEmail, " &
                            " ActionItemStatus=@ActionItemStatus, " &
                            " DateDue=@DateDue" &
                            " WHERE ActionItemNum =@actionItemNum "
                        .CommandType = Data.CommandType.Text
                        .Parameters.AddWithValue("@DateFinished", Now)
                        .Parameters.AddWithValue("@State", stateOfItem)
                        .Parameters.AddWithValue("@ActionItemStatus", statusOfItem)
                        .Parameters.AddWithValue("@Owner", ownerOfItem)
                        .Parameters.AddWithValue("@OwnerEmail", emailOFAsssignedOwner)
                        .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                        .Parameters.AddWithValue("@DateDue", dateDue)

                    End With
                    cmdSaveVend.ExecuteNonQuery()
                    conn.Close()
                End Using

            ElseIf currentLoggedInUser <> ownerOfItem Then
                Using cmdSaveVend As New SqlCommand()
                    cmdSaveVend.Connection = conn
                    With cmdSaveVend
                        .CommandText = "UPDATE ActionItemsDet " &
                            " SET DateFinished=@DateFinished, " &
                            " DateAssigned=@DateAssigned, " &
                            " State=@State, " &
                            " Owner=@Owner, " &
                            " OwnerEmail=@OwnerEmail, " &
                            " ActionItemStatus=@ActionItemStatus, " &
                            " DateDue=@DateDue" &
                            " WHERE ActionItemNum =@actionItemNum "
                        .CommandType = Data.CommandType.Text
                        .Parameters.AddWithValue("@DateFinished", Now)
                        .Parameters.AddWithValue("@DateAssigned", Now)
                        .Parameters.AddWithValue("@State", stateOfItem)
                        .Parameters.AddWithValue("@ActionItemStatus", statusOfItem)
                        .Parameters.AddWithValue("@Owner", ownerOfItem)
                        .Parameters.AddWithValue("@OwnerEmail", emailOFAsssignedOwner)
                        .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                        .Parameters.AddWithValue("@DateDue", dateDue)
                    End With
                    cmdSaveVend.ExecuteNonQuery()
                    conn.Close()
                End Using

            End If

        ElseIf statusOfItem <> "Finished" Then

            If currentLoggedInUser = ownerOfItem Then
                Using cmdSaveVend As New SqlCommand()
                    cmdSaveVend.Connection = conn
                    With cmdSaveVend
                        .CommandText = "UPDATE ActionItemsDet " &
                            " SET DateModified=@DateModified, " &
                            " State=@State, " &
                            " Owner=@Owner, " &
                            " OwnerEmail=@OwnerEmail, " &
                            " ActionItemStatus=@ActionItemStatus, " &
                            " DateDue=@DateDue" &
                            " WHERE ActionItemNum =@actionItemNum "
                        .CommandType = Data.CommandType.Text
                        .Parameters.AddWithValue("@DateModified", Now)
                        .Parameters.AddWithValue("@State", stateOfItem)
                        .Parameters.AddWithValue("@ActionItemStatus", statusOfItem)
                        .Parameters.AddWithValue("@Owner", ownerOfItem)
                        .Parameters.AddWithValue("@OwnerEmail", emailOFAsssignedOwner)
                        .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                        .Parameters.AddWithValue("@DateDue", dateDue)
                    End With
                    cmdSaveVend.ExecuteNonQuery()
                    conn.Close()
                End Using

            ElseIf currentLoggedInUser <> ownerOfItem Then

                Using cmdSaveVend As New SqlCommand()
                    cmdSaveVend.Connection = conn
                    With cmdSaveVend
                        .CommandText = "UPDATE ActionItemsDet " &
                            " SET DateAssigned=@DateAssigned, " &
                            " State=@State, " &
                            " Owner=@Owner, " &
                            " OwnerEmail=@OwnerEmail, " &
                            " ActionItemStatus=@ActionItemStatus, " &
                            " DateDue=@DateDue" &
                            " WHERE ActionItemNum =@actionItemNum "
                        .CommandType = Data.CommandType.Text
                        .Parameters.AddWithValue("@DateAssigned", Now)
                        .Parameters.AddWithValue("@State", stateOfItem)
                        .Parameters.AddWithValue("@ActionItemStatus", statusOfItem)
                        .Parameters.AddWithValue("@Owner", ownerOfItem)
                        .Parameters.AddWithValue("@OwnerEmail", emailOFAsssignedOwner)
                        .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                        .Parameters.AddWithValue("@DateDue", dateDue)
                    End With
                    cmdSaveVend.ExecuteNonQuery()
                    conn.Close()
                End Using
            End If

        End If
        'Insert Notes


    End Sub

    Public Sub UpdateActionItemsNotes()
        'Dim sqlstr As String
        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim creatorFullName As String = ManagerForm.lblCreatedByActionItemsPage.Text
        Dim creatorEmail As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim ownerOfItem As String = ManagerForm.cboOwnerActionItemPage.Text
        Dim ownersEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        Dim dateModified As String = ManagerForm.lblDateModifiedActionItemPage.Text
        Dim dateAssigned As String = ManagerForm.lblDateAssignedActionItemPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedActionItemPage.Text
        Dim stateOfItem As String = ManagerForm.cboStateActionItemPage.Text
        Dim statusOfItem As String = ManagerForm.cboStatusActionItemPage.Text
        Dim notesActionItem As String = ManagerForm.txtNotesActionItemPage.Text
        Dim conn As New SqlConnection(connstring)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        ElseIf conn.State = ConnectionState.Open Then
        End If

        If notesActionItem = "" Then
        Else

            Try
                If currentLoggedInUser <> ownerOfItem Then
                    Using (conn)
                        Dim sqlcmd = New SqlCommand()
                        With sqlcmd
                            .Connection = conn
                            .CommandText = "sp_InsertNewActionItemsNotes"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                            .Parameters.AddWithValue("@DateCreated", Now)
                            .Parameters.AddWithValue("@Notes", (currentLoggedInUser + " commented: " + notesActionItem))
                            .ExecuteNonQuery()
                        End With
                    End Using

                ElseIf currentLoggedInUser = ownerOfItem Then
                    Using (conn)
                        Dim sqlcmd = New SqlCommand()
                        With sqlcmd
                            .Connection = conn
                            .CommandText = "sp_InsertNewActionItemsNotes"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                            .Parameters.AddWithValue("@DateCreated", Now)
                            .Parameters.AddWithValue("@Notes", notesActionItem)
                            .ExecuteNonQuery()
                        End With
                    End Using
                End If
                conn.Close()

            Catch ex As Exception
                MessageBox.Show("Cannot save notes in Action Items - UpdateActionItemsNotes: " & ex.Message)
            End Try

        End If


    End Sub


    'Public Sub UpdateReqOpSheetChanges_NoEmail()
    '    Dim sqlda As New SqlDataAdapter
    '    Dim mydatatable As New DataTable
    '    Dim CreatorFullName As String
    '    CreatorFullName = ManagerForm.lblRequestorfullname.Text

    '    'Checks for the connection
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    If ManagerForm.txtplanid_RequestOPChangePage.Text = "" Then
    '        MsgBox("There must be an Plan ID before continuing.")

    '        'ElseIf Item is finished"
    '    ElseIf ManagerForm.cboOwnerActionItemPage.Text = "Finished" Then

    '        sqlda.SelectCommand = sqlcmd
    '        sqlda.Fill(mydatatable)


    '        'Calls subroutine -Sends email upon finishing
    '        ' SendFinishedItemNotifyToBoth_RequestedOpSheetChange()

    '        'Calls subroutine- Logged into activity history
    '        LogAllFinishedActions()
    '        'Calls subroutine to save the comments, if there is none it ignores it
    '        SaveCommentsAndOrNotes()
    '        'Calls subroutine to save everything when finished
    '        SaveItemIntoDbFinished_RequestOpSheetChange()

    '        'ElseIf Item is NOT Finished"
    '    ElseIf ManagerForm.cboOwnerActionItemPage.Text <> "Finished" Then

    '        sqlda.SelectCommand = sqlcmd
    '        sqlda.Fill(mydatatable)

    '        If ManagerForm.cboOwnerActionItemPage.Text = CreatorFullName Then
    '            ' MessageBox.Show("Not Finished And Creator is ItemOwner")
    '            'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
    '            ' sendEmail_ToBoth_RequestedOpSheetChange()
    '            'Calls subroutine- Logged into activity history
    '            LogAllFinishedActions()
    '            'Calls subroutine to save the comments, if there is none it ignores it
    '            SaveCommentsAndOrNotes()
    '            'Calls subroutine - save when item is NOT Finished and Creator is not the ItemOwner of the item
    '            SaveItemIntodb_RequestOPChangePage()

    '        ElseIf ManagerForm.cboOwnerActionItemPage.Text <> CreatorFullName Then

    '            'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
    '            ' sendEmail_ToBoth_RequestedOpSheetChange()
    '            'Calls subroutine- Logged into activity history
    '            LogAllFinishedActions()
    '            'Calls subroutine to save the comments, if there is none it ignores it
    '            SaveCommentsAndOrNotes()
    '            'Calls subroutine - saves when item is finished
    '            SaveItemIntodb_RequestOPChangePage()

    '        End If

    '        ClearTextBoxes()
    '        ManagerForm.cboStateActionItemPage.SelectedIndex = -1
    '        ManagerForm.cboOwnerActionItemPage.SelectedIndex = -1
    '        ManagerForm.cboStatusActionItemPage.SelectedIndex = -1
    '        ManagerForm.lblActionItemsWorkPage.Text = ""
    '    End If

    'End Sub

    'Public Sub UpdateReqOpSheetChanges()
    '    Dim sqlda As New SqlDataAdapter
    '    Dim mydatatable As New DataTable

    '    'Checks for the connection
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    If ManagerForm.txtplanid_RequestOPChangePage.Text = "" Then
    '        MsgBox("There must be an Plan ID before continuing.")

    '        'ElseIf Item is finished"
    '    ElseIf ManagerForm.cboStateActionItemPage.Text = "Finished" Then

    '        sqlda.SelectCommand = sqlcmd
    '        sqlda.Fill(mydatatable)

    '        'Calls subroutine -Sends email upon finishing
    '        publicvariables.SendEmail_ToBoth_RequestedOpSheetChangeFinished()

    '        'Calls subroutine- Logged into activity history
    '        LogAllFinishedActions()
    '        'Calls subroutine to save the comments, if there is none it ignores it
    '        SaveCommentsAndOrNotes()
    '        'Calls subroutine to save everything when finished
    '        SaveItemIntoDbFinished_RequestOpSheetChange()


    '        'ElseIf Item is NOT Finished"
    '    ElseIf ManagerForm.cboStateActionItemPage.Text <> "Finished" Then
    '        Dim CreatorFullName As String
    '        CreatorFullName = ManagerForm.lblCreatedByActionItemsPage.Text

    '        sqlda.SelectCommand = sqlcmd
    '        sqlda.Fill(mydatatable)

    '        If ManagerForm.cboOwnerActionItemPage.Text = CreatorFullName Then
    '            ' MessageBox.Show("Not Finished And Creator is ItemOwner")
    '            'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
    '            publicvariables.SendEmail_ToBoth_RequestedOpSheetChange()
    '            'Calls subroutine- Logged into activity history
    '            LogAllFinishedActions()
    '            'Calls subroutine to save the comments, if there is none it ignores it
    '            SaveCommentsAndOrNotes()
    '            'Calls subroutine - save when item is NOT Finished and Creator is not the ItemOwner of the item
    '            SaveItemIntodb_RequestOPChangePage()
    '            newsqlconn.Close()
    '        ElseIf ManagerForm.cboOwnerActionItemPage.Text <> CreatorFullName Then

    '            'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
    '            publicvariables.SendEmail_ToBoth_RequestedOpSheetChange()
    '            'Calls subroutine- Logged into activity history
    '            LogAllFinishedActions()
    '            'Calls subroutine to save the comments, if there is none it ignores it
    '            SaveCommentsAndOrNotes()
    '            'Calls subroutine - saves when item is finished
    '            SaveItemIntodb_RequestOPChangePage()
    '            newsqlconn.Close()
    '        End If


    '        ClearTextBoxes()
    '        ManagerForm.cboStateActionItemPage.SelectedIndex = -1
    '        ManagerForm.cboOwnerActionItemPage.SelectedIndex = -1
    '        ManagerForm.cboStatusActionItemPage.SelectedIndex = -1
    '        ManagerForm.lblActionItemsWorkPage.Text = ""
    '    End If

    'End Sub

    'Public Sub SaveItemIntodb_RequestOPChangePage()
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    Using cmdSaveVend As New SqlCommand()
    '        cmdSaveVend.Connection = newsqlconn
    '        With cmdSaveVend
    '            newsqlconn.Open()
    '            .CommandText = "UPDATE ChangeRequest " &
    '                " SET DateModified=@DateModified, " &
    '                " DateAssigned=@DateAssigned, " &
    '                " Status=@Status, " &
    '                " plan_id=@plan_id, " &
    '                " operation=@operation, " &
    '                " category=@category, " &
    '                " ItemOwner=@ItemOwner, " &
    '                " OwnerEmail=@OwnerEmail " &
    '                " WHERE EcrConfNum= '" & ManagerForm.lblActionItemsWorkPage.Text & "';"

    '            .CommandType = Data.CommandType.Text

    '            With .Parameters
    '                .AddWithValue("@DateModified", Now)
    '                .AddWithValue("@DateAssigned", Now)
    '                .AddWithValue("@Status", ManagerForm.cboStateActionItemPage.Text)
    '                .AddWithValue("@plan_id", ManagerForm.txtplanid_RequestOPChangePage.Text)
    '                .AddWithValue("@operation", ManagerForm.txtReferenceActionItemPage.Text)
    '                .AddWithValue("@category", ManagerForm.cboStatusActionItemPage.Text)
    '                .AddWithValue("@ItemOwner", ManagerForm.cboOwnerActionItemPage.Text)
    '                .AddWithValue("@OwnerEmail", ManagerForm.lblItemOwnersEmailMainPage.Text)
    '            End With

    '        End With
    '        Try
    '            'System.Threading.Thread.Sleep(1000)
    '            cmdSaveVend.ExecuteNonQuery()
    '            MsgBox("Updated Successfully")
    '            Clearfields()
    '        Catch ex As SqlException
    '            MsgBox("Error cannot save, " & ManagerForm.lblActionItemsWorkPage.Text & " " & ex.Message, MsgBoxStyle.Information)
    '        End Try
    '        newsqlconn.Close()
    '    End Using
    'End Sub

    'Public Sub SaveItemIntoDbFinished_RequestOpSheetChange()
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    Using cmdSaveVend As New SqlCommand()
    '        cmdSaveVend.Connection = newsqlconn
    '        With cmdSaveVend
    '            newsqlconn.Open()

    '            .CommandText = "UPDATE ChangeRequest " &
    '                    " SET DateModified=@DateModified, " &
    '                    " date_finished=@date_finished, " &
    '                    " plan_id=@plan_id, " &
    '                    " operation=@operation, " &
    '                    " category=@category, " &
    '                    " Status=@Status, " &
    '                    " ItemOwner=@ItemOwner, " &
    '                    " OwnerEmail=@OwnerEmail " &
    '                    " WHERE EcrConfNum= '" & ManagerForm.lblActionItemsWorkPage.Text & "';"

    '            .CommandType = Data.CommandType.Text
    '            With .Parameters
    '                .AddWithValue("@DateModified", Now)
    '                .AddWithValue("@date_finished", Now)
    '                .AddWithValue("@plan_id", ManagerForm.txtplanid_RequestOPChangePage.Text)
    '                .AddWithValue("@operation", ManagerForm.txtReferenceActionItemPage.Text)
    '                .AddWithValue("@category", ManagerForm.cboStatusActionItemPage.Text)
    '                .AddWithValue("@Status", ManagerForm.cboStateActionItemPage.Text)
    '                .AddWithValue("@ItemOwner", ManagerForm.cboOwnerActionItemPage.Text)
    '                .AddWithValue("@OwnerEmail", ManagerForm.lblItemOwnersEmailMainPage.Text)
    '            End With

    '        End With
    '        Try
    '            'System.Threading.Thread.Sleep(1000)
    '            cmdSaveVend.ExecuteNonQuery()
    '            MsgBox("Updated Successfully")
    '            Clearfields()
    '        Catch ex As SqlException
    '            MsgBox("Error cannot update after finishing request for OP Sheet Change, " & ex.Message, MsgBoxStyle.Information)
    '        End Try
    '        newsqlconn.Close()
    '    End Using

    'End Sub

    'Public Sub AddCommentsOpSheetChangeRequestPage()
    '    Dim sqlda As New SqlDataAdapter
    '    Dim mydatatable As New DataTable
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    sqlda.SelectCommand = sqlcmd
    '    sqlda.Fill(mydatatable)
    '    'Calls subroutine to save the comments, if there is none it ignores it
    '    SaveCommentsAndOrNotes()
    '    'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
    '    publicvariables.SendEmail_RequestorCommentResponse()
    '    'Calls subroutine- Logged into activity history
    '    LogAllFinishedActions()
    '    Clearfields()

    '    newsqlconn.Close()

    'End Sub

#End Region

#Region "INSERT COMMENTS/NOTES/DESCRIPTIONS"

    Public Sub WriteAllCommentsNotes()
        Dim sqlstr As String
        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text

        Dim ecrNum As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim ecrDescription As String = ManagerForm.txtDescriptionECREditItemsPage.Text

        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        Dim actionItemNotes As String = ManagerForm.txtNotesActionItemPage.Text

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            'Dim comments As String
            If ManagerForm.GroupBoxEditECRItems.Visible = True Then
                Using (newsqlconn)
                    Dim sqlcmd = New SqlCommand()
                    With sqlcmd
                        .Connection = newsqlconn
                        .CommandText = "sp_InsertNewComments"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@EcrConfNum", ecrNum)
                        .Parameters.AddWithValue("@DateCreated", Now)
                        .Parameters.AddWithValue("@Description", (currentLoggedInUser + " commented: " + ecrDescription))
                        .ExecuteNonQuery()
                    End With
                End Using
                'Log the Activity
                LogActivitiesNewECRCreated()

            ElseIf ManagerForm.GroupBoxActionItemsWorkPage.Visible = True Then
                Using (newsqlconn)
                    Dim sqlcmd = New SqlCommand()
                    With sqlcmd
                        .Connection = newsqlconn
                        .CommandText = "sp_InsertNewActionItemsNotes"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                        .Parameters.AddWithValue("@DateCreated", Now)
                        .Parameters.AddWithValue("@Notes", (currentLoggedInUser + " commented: " + actionItemNotes))
                        .ExecuteNonQuery()
                    End With
                End Using
                'Log the Activity
                LogActivitiesNewECRCreated()
                newsqlconn.Close()
            End If

            newsqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Cannot insert comments: (WriteAllCommentsNotes) - " & ex.Message)
        End Try

    End Sub

    Public Sub InsertNewDescriptionsNotes()

        Dim newECRNum As String = ManagerForm.lblECRNumNewECRPage.Text
        Dim newDescriptionRequest As String = ManagerForm.txtAddCommentsNewECRPage.Text
        Dim newActionItemNum As String = ManagerForm.lblActionItemsNewPage.Text
        Dim newActionItemNotes As String = ManagerForm.txtAddNotesActionItemsPage.Text
        Dim newsqlconn As New SqlConnection(connstring)

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        If ManagerForm.GroupBox_ActionItemsPage.Visible = True Then
            Try
                Using (newsqlconn)
                    Dim sqlcmd = New SqlCommand()
                    With sqlcmd
                        .Connection = newsqlconn
                        .CommandText = "sp_InsertNewActionItemsNotes"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@ActionItemNum", newActionItemNum)
                        .Parameters.AddWithValue("@DateCreated", Now)
                        .Parameters.AddWithValue("@Notes", newActionItemNotes)
                        .ExecuteNonQuery()
                    End With
                End Using
                'Log the Activity
                LogActivitiesNewECRCreated()

            Catch ex As Exception
                MessageBox.Show("Cannot insert new comments (InsertCommentsNewECRPage): " & ex.Message)
            End Try
            newsqlconn.Close()

        ElseIf ManagerForm.GroupBoxAddNewECR.Visible = True Then
            Try
                Using (newsqlconn)
                    Dim sqlcmd = New SqlCommand()
                    With sqlcmd
                        .Connection = newsqlconn
                        .CommandText = "sp_InsertNewComments"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@EcrConfNum", newECRNum)
                        .Parameters.AddWithValue("@DateCreated", Now)
                        .Parameters.AddWithValue("@Description", newDescriptionRequest)
                        .ExecuteNonQuery()
                    End With
                End Using
                'Log the Activity
                LogActivitiesNewECRCreated()

            Catch ex As Exception
                MessageBox.Show("Cannot insert new comments (InsertCommentsNewECRPage): " & ex.Message)
            End Try
            newsqlconn.Close()


        Else

        End If


    End Sub

    Public Sub UpdateDescriptionsECRItems()
        Dim sqlstr As String
        Dim currECRNum As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim description As String = ManagerForm.txtDescriptionECREditItemsPage.Text
        Dim assignedEngineeer As String = ManagerForm.cboEngineerECREditItemsPage.Text
        Dim creatorFullName As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        If description = "" Then
            'MsgBox("This works")
        ElseIf description <> "" Then

            If assignedEngineeer <> currentLoggedInUser Then
                Try
                    sqlstr = "INSERT INTO tblComments " &
                        "( EcrConfNum, " &
                        " DateCreated, " &
                        " Description) " &
                        " VALUES (@EcrConfNum," &
                        " @DateCreated," &
                        " @Description); " &
                        " SELECT MAX(ID) AS LASTID FROM tblComments"
                    Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
                        With sqlcmd
                            .Parameters.AddWithValue("@EcrConfNum", currECRNum)
                            .Parameters.AddWithValue("@DateCreated", Now)
                            .Parameters.AddWithValue("@Description", (currentLoggedInUser + " commented: " + description))
                            .ExecuteNonQuery()
                        End With
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Cannot insert comments: (first if) - " & ex.Message)
                End Try

            Else

                Try
                    sqlstr = "INSERT INTO tblComments " &
                    " (EcrConfNum, " &
                    " DateCreated, " &
                    " Description) " &
                    " VALUES (@EcrConfNum," &
                    " @DateCreated," &
                    " @Description); " &
                    " SELECT MAX(ID) AS LASTID FROM tblComments"
                    Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
                        With sqlcmd
                            .Parameters.AddWithValue("@EcrConfNum", currECRNum)
                            .Parameters.AddWithValue("@DateCreated", Now)
                            .Parameters.AddWithValue("@Description", description)
                            .ExecuteNonQuery()
                        End With
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Cannot insert comments: (seocnd if) - " & ex.Message)
                End Try

            End If

        End If
        newsqlconn.Close()

    End Sub

    'Public Sub SaveCommentsAndOrNotes()

    '    If ManagerForm.GroupBoxActionItemsWorkPage.Visible = True Then

    '        If ManagerForm.txtNotesActionItemPage.Text = "" Then
    '            ' MessageBox.Show("There are no comments in the Text box")

    '        ElseIf ManagerForm.txtNotesActionItemPage.Text <> "" Then
    '            'writeNewCommentsActionItems()
    '            WriteAllCommentsNotes()
    '        End If

    '    ElseIf ManagerForm.GroupBoxEditECRItems.Visible = True Then

    '        If ManagerForm.txtDescriptionECREditItemsPage.Text = "" Then
    '            'MessageBox.Show("There are no comments in the Text box")
    '        ElseIf ManagerForm.txtDescriptionECREditItemsPage.Text.Trim.Length > 0 Then
    '            'writeNewCommentsActionItems()
    '            WriteAllCommentsNotes()
    '        End If

    '    ElseIf ManagerForm.GroupBox_ViewOnlyRequestOp.Visible = True Then

    '        If ManagerForm.txtaddcomments_viewoppage.Text = "" Then
    '            'MessageBox.Show("There are no comments in the Text box")
    '        ElseIf ManagerForm.txtaddcomments_viewoppage.Text.Trim.Length > 0 Then
    '            'writeNewCommentsActionItems()
    '            WriteAllCommentsNotes()
    '        End If
    '    End If

    'End Sub

    'Public Sub WriteNewComments_RequestOPChangePage()
    '    Dim sqlstr As String
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    If ManagerForm.txtNotesActionItemPage.Text = "" Then
    '        'MsgBox("This works")
    '    ElseIf ManagerForm.txtNotesActionItemPage.Text <> "" Then

    '        Try
    '            sqlstr = "INSERT INTO tblComments " &
    '                " (EcrConfNum, " &
    '                " DateCreated, " &
    '                " Description) " &
    '                " VALUES (@EcrConfNum," &
    '                " @DateCreated," &
    '                " @Description); " &
    '                " SELECT MAX(ID) AS LASTID FROM tblComments"
    '            Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
    '                With sqlcmd
    '                    newsqlconn.Open()
    '                    .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblActionItemsWorkPage.Text)
    '                    .Parameters.AddWithValue("@DateCreated", Now)
    '                    .Parameters.AddWithValue("@Description", ManagerForm.txtNotesActionItemPage.Text)
    '                    .ExecuteNonQuery()
    '                End With
    '                newsqlconn.Close()

    '            End Using
    '        Catch ex As Exception
    '            MessageBox.Show("Cannot insert comments: " & ex.Message)
    '        End Try
    '    End If

    'End Sub

    'Public Sub WriteNewDescription_RequestOPChangePage()
    '    Dim sqlstr As String
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If

    '    Try
    '        sqlstr = "INSERT INTO tblComments " &
    '            " (EcrConfNum, " &
    '            " DateCreated, " &
    '            " Description) " &
    '            " VALUES (@EcrConfNum," &
    '            " @DateCreated," &
    '            " @description); " &
    '            " SELECT MAX(ID) AS LASTID FROM tblComments"
    '        Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
    '            With sqlcmd
    '                newsqlconn.Open()
    '                .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblActionItemsNewPage.Text)
    '                .Parameters.AddWithValue("@date", Now)
    '                .Parameters.AddWithValue("@Description", ManagerForm.txtAddDescriptionActionItemsPage.Text)
    '                .ExecuteNonQuery()
    '            End With

    '        End Using
    '        newsqlconn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("Cannot insert: " & ex.Message)
    '    End Try
    'End Sub

    'Public Sub WriteNotes_RequestOpSheetChangePage()
    '    Dim sqlstr As String
    '    Dim newsqlconn As New SqlConnection(connstring)
    '    If newsqlconn.State = ConnectionState.Closed Then
    '        newsqlconn.Open()
    '    ElseIf newsqlconn.State = ConnectionState.Open Then
    '    End If


    '    If ManagerForm.txtDescriptionECREditItemsPage.Text = "" Then
    '        'MsgBox("This works")
    '    ElseIf ManagerForm.txtDescriptionECREditItemsPage.Text <> "" Then

    '        Try
    '            sqlstr = "INSERT INTO tblComments " &
    '                " (EcrConfNum, " &
    '                " DateCreated, " &
    '                " Description) " &
    '                " VALUES (@EcrConfNum," &
    '                " @DateCreated," &
    '                " @Description); " &
    '                " SELECT MAX(ID) AS LASTID FROM tblComments"
    '            Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
    '                With sqlcmd
    '                    newsqlconn.Open()
    '                    .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblEcrNumECREditItemsPage.Text)
    '                    .Parameters.AddWithValue("@DateCreated", Now)
    '                    .Parameters.AddWithValue("@Description", ManagerForm.txtDescriptionECREditItemsPage.Text)
    '                    .ExecuteNonQuery()
    '                End With
    '                newsqlconn.Close()

    '            End Using
    '        Catch ex As Exception
    '            MessageBox.Show("Cannot insert comments: " & ex.Message)
    '        End Try
    '    End If

    'End Sub

#End Region

#Region "INCREMENTS THE ECR ITEM NUMBER"
    Public Sub GetActionItemNumber()
        'Dim sqlstr As String
        'Dim ds As New DataSet
        'Dim newsqlconn As New SqlConnection

        Dim ECRConfNum As String = ManagerForm.lblECRNumNewECRPage.Text

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim bs As New BindingSource
        Dim reader As SqlDataReader

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If


        If ManagerForm.GroupBox_ActionItemsPage.Visible = True Then
            Try
                sqlquery = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS AINUm FROM tblauto WHERE ID = 2"

                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                reader = sqlcmd.ExecuteReader

                While reader.Read
                    ManagerForm.lblActionItemsNewPage.Text = reader.GetString(2)
                End While '<--- Reader Closed

                If reader.HasRows Then
                    reader.Close()
                    Dim newsqlquery As String
                    newsqlquery = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 2"
                    Using newsqlcmd = New SqlCommand(newsqlquery, newsqlconn)
                        newsqlcmd.ExecuteNonQuery()
                    End Using
                End If
                'Inserts the New Action Item number into SQL
                AddNewActionItems()


            Catch ex As Exception
                MsgBox("Cannot load Item Confirmation #, Please contact the Administrator")
            End Try
            newsqlconn.Close()

        ElseIf ManagerForm.GroupBoxAddNewECR.Visible = True Then
            Try
                sqlquery = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECRNum FROM tblauto WHERE ID = 1"

                sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                reader = sqlcmd.ExecuteReader

                While reader.Read
                    ManagerForm.lblECRNumNewECRPage.Text = reader.GetString(2)
                End While '<--- Reader Closed

                If reader.HasRows Then
                    reader.Close()
                    Dim newsqlquery As String
                    newsqlquery = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 1"
                    Using newsqlcmd = New SqlCommand(newsqlquery, newsqlconn)
                        newsqlcmd.ExecuteNonQuery()
                    End Using
                End If
                'Inserts the New ECR into SQL
                AddNewEcrItems()

            Catch ex As Exception
                MsgBox("Cannot load Item Confirmation #, Please contact the Administrator")
            End Try
            newsqlconn.Close()


        Else

        End If



    End Sub

    Public Sub UpdateECRIncrementValues()
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        '**** UpdateECRIncrementValues()
        Try
            da.SelectCommand = sqlcmd
            da.Fill(dt)
            Using newsqlcmd As New SqlCommand()
                newsqlcmd.Connection = newsqlconn
                With newsqlcmd
                    .CommandText = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 1"
                    .CommandType = CommandType.Text
                End With
                newsqlcmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Cannot update: (UpdateECRIncrementValues) " & ex.Message, MsgBoxStyle.Information)
        End Try
        newsqlconn.Close()

    End Sub


    Public Sub ExecuteScalarTest()

        Dim table As New DataTable
        Dim id As Integer
        Dim autoend, ECRNum As String
        'user = Main.FullNameToolStripMenu.Text
        'id = Main.UserIDToolStripMenu.Text

        sqlda.SelectCommand = sqlcmd
        sqlda.Fill(table)

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        If table.Rows.Count > 0 Then
            id = table.Rows(0).Item(0)
            autoend = table.Rows(0).Item(1)
            ECRNum = table.Rows(0).Item(2)
            If ECRNum = ManagerForm.lblECRNumNewECRPage.Text Then
                sqlquery = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 1"

                Using sqlcmd = New SqlCommand(sqlquery, newsqlconn)
                    newsqlconn.Open()
                    Dim theenterID = Convert.ToInt32(sqlcmd.ExecuteScalar())
                    'System.Threading.Thread.Sleep(1000)
                End Using

                ManagerForm.Label45.Text = "Log In"
            Else
                MsgBox("User ID does not match")
            End If
        Else
            MsgBox("Db error")
        End If

        newsqlconn.Close()

    End Sub

    Public Sub GetGetActionItemNumberOLD()
        Dim sqlstr As String
        Dim txtEcrConfirmationNum As String
        Dim sqlda As New SqlDataAdapter
        Dim ds As New DataSet
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlstr = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECR_Number FROM tblauto WHERE ID = 1"
            'sqlda = New SqlDataAdapter(sqlstr, newsqlconn)

            sqlda.Fill(ds, "ucrms")
            txtEcrConfirmationNum = ds.Tables("ucrms").Rows(0).Item(2)
            ManagerForm.lblECRNumNewECRPage.Text = txtEcrConfirmationNum

            Dim iReturn As Boolean
            Using cmdupdate As New SqlCommand()
                cmdupdate.Connection = newsqlconn
                With cmdupdate
                    .CommandText = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 1"
                    .CommandType = Data.CommandType.Text
                End With
                cmdupdate.ExecuteNonQuery()
                iReturn = True
                'Try
                'Catch ex As SqlException
                '    MsgBox(ex.Message, MsgBoxStyle.Information)
                '    iReturn = False
                'End Try
            End Using

        Catch ex As Exception
            MsgBox("Cannot load Item Confirmation #, Please contact the Administrator")
        End Try
        newsqlconn.Close()

    End Sub

#End Region

#Region "INCREMENTS THE REQUEST OP SHEET CHANGE ITEMS"
    Public Sub GetRequestOpSheetChangeItemNum()
        Dim sqlstr As String
        Dim reqItemNumber As String
        'Dim sqlda As New SqlDataAdapter
        Dim ds As New DataSet
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlstr = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECR_Number FROM tblauto WHERE ID = 2"
            'sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
            'newsqlconn.Open()
            sqlda.Fill(ds, "ucrms")
            reqItemNumber = ds.Tables("ucrms").Rows(0).Item(2)
            ManagerForm.lblActionItemsNewPage.Text = reqItemNumber
            'MsgBox(txtmsgnew)

            Dim iReturn As Boolean
            Using cmdupdate As New SqlCommand()
                cmdupdate.Connection = newsqlconn
                With cmdupdate
                    If newsqlconn.State = ConnectionState.Open Then
                    ElseIf newsqlconn.State = ConnectionState.Closed Then
                        newsqlconn.Open()
                    End If

                    .CommandText = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 2"
                    .CommandType = Data.CommandType.Text

                End With
                Try
                    cmdupdate.ExecuteNonQuery()
                    iReturn = True
                Catch ex As SqlException
                    MsgBox(ex.Message, MsgBoxStyle.Information)
                    iReturn = False
                End Try
                'newsqlconn.Close()
            End Using

        Catch ex As Exception
            MsgBox("Cannot load Item Confirmation #, Please contact the Administrator")
        End Try
        newsqlconn.Close()
    End Sub

#End Region

#Region "TESTING PARAMETERS"
    Public Sub UpdateActionItemsTest()

        Dim sqlda As New SqlDataAdapter
        Dim mydatatable As New DataTable
        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim creatorFullName As String = ManagerForm.lblCreatedByActionItemsPage.Text
        Dim creatorEmail As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim ownerOfItem As String = ManagerForm.cboOwnerActionItemPage.Text
        Dim ownersEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        Dim dateModified As String = ManagerForm.lblDateModifiedActionItemPage.Text
        Dim dateAssigned As String = ManagerForm.lblDateAssignedActionItemPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedActionItemPage.Text
        Dim stateOfItem As String = ManagerForm.cboStateActionItemPage.Text
        Dim statusOfItem As String = ManagerForm.cboStatusActionItemPage.Text
        Dim notesActionItem As String = ManagerForm.txtNotesActionItemPage.Text
        Dim showCurrentItemOwner As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim bs As New BindingSource
        Dim reader As SqlDataReader

        'If statement starts here collects the information depending on how the user enters the data
        If stateOfItem = "" Then
            MsgBox("Please choose the state of the Action Item.")
        ElseIf statusOfItem = "" Then
            MsgBox("Please choose the status of the Action Item.")
        ElseIf statusOfItem = "Finished" Then
            'When the item has been Finished do this...

            Dim newsqlconn As New SqlConnection(connstring)
            If newsqlconn.State = ConnectionState.Closed Then
                newsqlconn.Open()
            ElseIf newsqlconn.State = ConnectionState.Open Then
            End If
            sqlquery = "SELECT Owner FROM ActionItemsDet WHERE ActionItemNum = @ActionItemNum "
            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlcmd.Parameters.AddWithValue("@ActionItemNum", actionItemNum)
            reader = sqlcmd.ExecuteReader

            MsgBox("Owned by: " & reader.GetString(0))

            If reader.Read AndAlso Not reader.IsDBNull(0) Then
                'If there is an owner, then this method kicks in.
                showCurrentItemOwner = reader.GetString(0)
                MsgBox("This action Item has an owner! It is: " & reader.GetString(0))

                If currentLoggedInUser <> showCurrentItemOwner Then

                    Dim result As DialogResult = MessageBox.Show("1st Are you sure? You are editing an Action Item that belongs to: " & reader.GetString(0), "caption", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        MessageBox.Show("The owner of the action item will be notified of the changes.")

                        'SaveUpdateActionItems()

                        'Insert Notes

                        'Insert logging

                        'Send Email to both parties

                    ElseIf result = DialogResult.No Then

                    End If

                ElseIf currentLoggedInUser = showCurrentItemOwner Then

                    'MsgBox("You have finished your own action item, Mr. ")
                    Dim result As DialogResult = MessageBox.Show("Are you sure?", "caption", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then

                        'SaveUpdateActionItems()

                        'Insert Notes

                        'Insert logging

                        'Send email to yourself /the logged in user

                    ElseIf result = DialogResult.No Then

                    End If

                End If

            ElseIf reader.IsDBNull(0) Then
                'If there is no owner, then this method kicks in.
                'MsgBox("The search found no assigned owners to this action item.")
                'SaveUpdateActionItems()

                'Insert Notes

                'Insert logging

                'Send email to new owner of item even though the action item is finished

            Else
            End If '<--- Reader Closed
            reader.Close()

            'If the logged in user is finishing hie/her own action item then do this.
            If currentLoggedInUser <> showCurrentItemOwner Then

                'If the current logged in user is editing another owner's action item, do this...
            ElseIf currentLoggedInUser = showCurrentItemOwner Then

            End If


        ElseIf statusOfItem <> "Finished" Then
            'When item is not finished but updating it only, do this...
            MsgBox("Saving the items that are not finished and not owned by you")

            'Insert Notes

            'Insert logging

        Else

        End If

        'MsgBox("Action Item: " & " '" & ManagerForm.lblitemnum_editactionitempage.Text & "' " & " has been saved.")
        Clearfields()
        ClearTextBoxes()
        ManagerForm.cboStatusECREditItemsPage.SelectedIndex = -1
        ManagerForm.cboEngineerECREditItemsPage.SelectedIndex = -1
        ManagerForm.cboSiteECREditItemsPage.SelectedIndex = -1
        ManagerForm.cboChangeTypeECREditItemsPage.SelectedIndex = -1

    End Sub


#End Region

#Region "MANAGE ACCOUNTS"

    Public Sub InsertNewAccount()
        Dim userAccountName As String = UserAccounts.cboUserTypeManageAccounts.Text
        Dim userDBID As String = UserAccounts.lblIDManageAccounts.Text
        Dim userType As String = UserAccounts.cboUserTypeManageAccounts.Text
        Dim userName As String = UserAccounts.txtUserNameManageAccounts.Text
        Dim firstName As String = UserAccounts.txtFirstNameManageAccounts.Text
        Dim lastName As String = UserAccounts.txtLastNameManageAccounts.Text
        Dim eMail As String = UserAccounts.txtUserEmailManageAccounts.Text
        Dim employeeID As String = UserAccounts.txtEmployeeIDManageAccounts.Text
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Try

            If userAccountName = "" Then
                MsgBox("Please choose a user type.")
            Else
                Using (newsqlconn)
                    Dim sqlcmd As New SqlCommand()
                    With sqlcmd
                        .Connection = newsqlconn
                        .CommandText = "sp_InsertNewUserAccount"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@username", userName)
                        .Parameters.AddWithValue("@lastname", lastName)
                        .Parameters.AddWithValue("@firstname", firstName)
                        .Parameters.AddWithValue("@usertype", userType)
                        .Parameters.AddWithValue("@useremail", eMail)
                        .Parameters.AddWithValue("@emplid", employeeID)
                        .ExecuteNonQuery()
                    End With
                End Using
                MsgBox("User account updated Successfully")
            End If

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Information)
            'iReturn = False
        End Try
        newsqlconn.Close()
        UserAccountsLoad()
    End Sub

    Public Sub UserAccountsLoad()
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM useraccounts"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            sqlda.Update(dt)

            With UserAccounts
                .DataGridView2.DataSource = bs
                .DataGridView2.AutoResizeColumns()
                .cboUserTypeManageAccounts.ResetText()
                With .DataGridView2
                    'newsqlconn.open()
                    .AutoGenerateColumns = True
                    .Columns(1).HeaderCell.Value = "Username"
                    .Columns(2).HeaderCell.Value = "Last Name"
                    .Columns(3).HeaderCell.Value = "First Name"
                    .Columns(4).HeaderCell.Value = "Account Type"
                    .Columns(5).HeaderCell.Value = "E-Mail"
                    .Columns("ID").Visible = False
                    .Columns("userpassword").Visible = False
                    .Columns("emplid").Visible = False
                    .Columns("contact").Visible = False
                    .Columns("other").Visible = False
                    .Columns("notes").Visible = False
                    .Columns("manager").Visible = False
                End With
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading unto form: (UserAccountsLoad) - " & ex.Message)
        End Try
        newsqlconn.Close()
    End Sub

    Public Sub CheckUsertypeAccounts()
        Dim FullName As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim EmployeeID As String = ManagerForm.lblEmployeeIDMainForm.Text
        Dim UserType As String = ManagerForm.lblUserTypeMainForm.Text
        Dim Reader As SqlDataReader

        Try
            Dim newsqlconn As New SqlConnection(connstring)
            If newsqlconn.State = ConnectionState.Closed Then
                newsqlconn.Open()
            ElseIf newsqlconn.State = ConnectionState.Open Then
            End If

            sqlquery = "SELECT * FROM (SELECT ID, firstname, lastname, (firstname + ' ' + lastname) AS FullName, useremail, usertype AS Type, emplid AS EmployeeID " &
            " FROM useraccounts) base WHERE FullName = @FullName And EmployeeID = @EmployeeID"

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)

            sqlcmd.Parameters.AddWithValue("@FullName", FullName)
            sqlcmd.Parameters.AddWithValue("@EmployeeID", EmployeeID)


            Reader = sqlcmd.ExecuteReader
            While Reader.Read
                'FullName = Reader.GetString(3)
                'EmployeeID = Reader.GetInt32(0)
                ManagerForm.lblUserTypeMainForm.Text = Reader.GetString(5)
                UserType = Reader.GetString(5)
            End While

            newsqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error checking user: " & ex.Message)
        End Try

        With ManagerForm
            If UserType = "Users" Then
                .MainMenu_ECRbtn.Visible = False
                .MainMenu_AIbtn.Visible = False
                .MainMenu_MyECRbtn.Visible = True
                .MainMenu_MyECRbtn_RequestsInProgess.Visible = True
                .MainMenu_MyECRbtn_RequestsInProgess.Visible = True
                .MainMenu_MyECRbtn_MyFinished.Visible = True
                .MainMenu_SharePoint.Visible = True
                .MainMenu_btnSettings.Visible = True
                .MainMenu_Settingsbtn_AdvancedSearch.Visible = False
                .MainMenu_Settingsbtn_UserAdministration.Visible = False
                .MainMenu_Settingsbtn_About.Visible = True
                .MainMenu_Settingsbtn_EmailGroup.Visible = False
                .MainMenu_Reportsbtn.Visible = False
                .MainMenu_Logbtn.Visible = False
                .MainMenu_LogOutbtn.Visible = True
                .BtnEditViewECRPage.Visible = False
            ElseIf UserType = "Administrator" Or UserType = "Manager" Then
                .MainMenu_ECRbtn.Visible = True
                .MainMenu_MyECRbtn.Visible = True
                .MainMenu_AIbtn.Visible = True
                .MainMenu_Logbtn.Visible = True
                .MainMenu_SharePoint.Visible = True
                .MainMenu_btnSettings.Visible = True
                .MainMenu_Reportsbtn.Visible = True
                .MainMenu_LogOutbtn.Visible = True
                .MainMenu_Settingsbtn_UserAdministration.Visible = True
            ElseIf UserType = "Engineer" Then
                .MainMenu_ECRbtn.Visible = True
                .MainMenu_MyECRbtn.Visible = False
                .MainMenu_Logbtn.Visible = True
                .MainMenu_AIbtn.Visible = True
                .MainMenu_SharePoint.Visible = True
                .MainMenu_FlowData.Visible = True
                .MainMenu_btnSettings.Visible = True
                .MainMenu_Settingsbtn_AdvancedSearch.Visible = False
                .MainMenu_Settingsbtn_UserAdministration.Visible = False
                .MainMenu_Settingsbtn_About.Visible = True
                .MainMenu_Settingsbtn_EmailGroup.Visible = False
                .MainMenu_Reportsbtn.Visible = True
                .MainMenu_LogOutbtn.Visible = True
            ElseIf UserType = "Quality" Then
                .MainMenu_ECRbtn.Visible = False
                .MainMenu_MyECRbtn.Visible = True
                .MainMenu_Logbtn.Visible = True
                .MainMenu_AIbtn.Visible = True
                .MainMenu_SharePoint.Visible = True
                .MainMenu_FlowData.Visible = True
                .MainMenu_btnSettings.Visible = True
                .MainMenu_Settingsbtn_AdvancedSearch.Visible = False
                .MainMenu_Settingsbtn_UserAdministration.Visible = False
                .MainMenu_Settingsbtn_About.Visible = True
                .MainMenu_Settingsbtn_EmailGroup.Visible = False
                .MainMenu_Reportsbtn.Visible = True
                .MainMenu_LogOutbtn.Visible = True
            ElseIf UserType = "Production" Then
                .MainMenu_ECRbtn.Visible = False
                .MainMenu_MyECRbtn.Visible = True
                .MainMenu_Logbtn.Visible = True
                .MainMenu_AIbtn.Visible = False
                .MainMenu_SharePoint.Visible = True
                .MainMenu_FlowData.Visible = True
                .MainMenu_btnSettings.Visible = True
                .MainMenu_Settingsbtn_AdvancedSearch.Visible = False
                .MainMenu_Settingsbtn_UserAdministration.Visible = False
                .MainMenu_Settingsbtn_About.Visible = True
                .MainMenu_Settingsbtn_EmailGroup.Visible = False
                .MainMenu_Reportsbtn.Visible = True
                .MainMenu_LogOutbtn.Visible = True
            Else
                .MenuStrip1.Visible = False
                .MainMenu_ECRbtn.Visible = False
                .MainMenu_AIbtn.Visible = False
                .MainMenu_MyECRbtn.Visible = False
                .MainMenu_SharePoint.Visible = False
                .MainMenu_btnSettings.Visible = False
                .MainMenu_Reportsbtn.Visible = False
                .MainMenu_Logbtn.Visible = False
                .MainMenu_LogOutbtn.Visible = True
                .BtnEditViewECRPage.Visible = False
            End If
        End With

    End Sub

    Public Sub CheckEngineers()

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        Dim dt As New DataTable
        Dim sqladapter As New SqlDataAdapter

        If newsqlconn.State = ConnectionState.Open Then
            ' newsqlconn.Close()
        ElseIf newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        End If

        Using newsqlconn
            Dim command As SqlCommand = New SqlCommand("SELECT id, useremail, usertype FROM ucrms.useraccounts WHERE usertype = 'Administrator';", newsqlconn)
            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                Do While reader.Read()
                    'MessageBox.Show(reader.GetInt32(0) & vbTab & reader.GetString(1))
                    Dim emailAddresses As String = reader.GetString(1)
                    theEmail.From = New MailAddress("relay@ushersm.com")
                    theEmail.To.Add(emailAddresses)
                    theEmail.Subject = "New Request Number: " & ManagerForm.lblActionItemsWorkPage.Text & " . "
                    theEmail.IsBodyHtml = False
                    theEmail.Body = "Do not reply to this email." +
                            Environment.NewLine + " Status: New " +
                            Environment.NewLine + " Created by: " & ManagerForm.lblUserFullNameMainForm.Text & "" +
                            Environment.NewLine + " " +
                            Environment.NewLine + " Date Created: " & ManagerForm.lblDateCreatedActionItemPage.Text & "" +
                            Environment.NewLine + " Plan ID: " & ManagerForm.txtAddTaskActionItemsPage.Text & "" +
                            Environment.NewLine + " Operation: " & ManagerForm.txtAddReferenceActionItemsPage.Text & "" +
                            Environment.NewLine + " Issue Type: " & ManagerForm.cboAddStateActionItemsPage.Text & "" +
                            Environment.NewLine + " Notes: " & ManagerForm.txtAddNotesActionItemsPage.Text & "" +
                            Environment.NewLine + " "
                    Smtp_Server.Send(theEmail)
                    theEmail.To.Clear()
                Loop
            Else
                MessageBox.Show("No rows found.")
            End If

            reader.Close()
        End Using
        newsqlconn.Close()

    End Sub

#End Region

#Region "VIEW LOGS"
    Public Sub ViewLogECR()
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM LogFiles ORDER BY id DESC "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView4.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView4
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .AutoGenerateColumns = True
                .Columns("id").Visible = False
                .Columns("UserFullName").Visible = False
                '.Columns("UserActivity").Visible = False
                '.Columns("Description").Visible = False
                .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
                .Font = New Font(.Font, FontStyle.Regular)
                .ForeColor = Color.Black
                .Columns("EcrConfNumLog").HeaderText = "ECR #"
                .Columns("EcrConfNumLog").Width = 80
                .Columns("EcrConfNumLog").DisplayIndex = 0
                .Columns("ActivityDate").HeaderText = "Date and Time"
                .Columns("ActivityDate").Width = 140
                .Columns("ActivityDate").DisplayIndex = 1
                .Columns("UserActivity").HeaderText = "UserActivity"
                .Columns("UserActivity").Width = 300
                .Columns("UserActivity").DisplayIndex = 2
                .Columns("Description").HeaderText = "Description"
                '.Columns("Description").Width = 600
                .Columns("Description").DisplayIndex = 3
            End With
            newsqlconn.Close()
        Catch ex As Exception
            MsgBox("Error load: (ViewLog) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Sub ViewLogActionItems()
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlquery = "SELECT * FROM ActionItemLog ORDER BY id DESC "

            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
            sqlda.SelectCommand = sqlcmd
            sqlda.Fill(dt)
            bs.DataSource = dt
            ManagerForm.DataGridView4.DataSource = bs
            sqlda.Update(dt)
            With ManagerForm.DataGridView4
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .AutoGenerateColumns = True
                .Columns("id").Visible = False
                .Columns("UserFullName").Visible = False
                '.Columns("UserActivity").Visible = False
                '.Columns("Description").Visible = False
                .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
                .Font = New Font(.Font, FontStyle.Regular)
                .ForeColor = Color.Black
                .Columns("ActionItemNum").HeaderText = "Action Item # #"
                .Columns("ActionItemNum").Width = 80
                .Columns("ActionItemNum").DisplayIndex = 0
                .Columns("ActivityDate").HeaderText = "Date and Time"
                .Columns("ActivityDate").Width = 140
                .Columns("ActivityDate").DisplayIndex = 1
                .Columns("UserActivity").HeaderText = "UserActivity"
                .Columns("UserActivity").Width = 300
                .Columns("UserActivity").DisplayIndex = 2
                .Columns("Notes").HeaderText = "Notes"
                '.Columns("Description").Width = 600
                .Columns("Notes").DisplayIndex = 3
            End With
            newsqlconn.Close()
        Catch ex As Exception
            MsgBox("Error load: (ViewLog) - " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

#Region "LOGGING"
    Public Sub LogActivitiesNewECRCreated()

        Dim newDescriptionRequest As String = ManagerForm.txtAddCommentsNewECRPage.Text
        Dim newECRNum As String = ManagerForm.lblECRNumNewECRPage.Text
        Dim UserFullNameLog As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim ActivityLog As String = UserFullNameLog + " created a new ECR item"
        Dim ActivitydateLog As String = Now

        Dim newActionItemNum As String = ManagerForm.lblActionItemsNewPage.Text
        Dim activityLogActionItem As String = UserFullNameLog + " created a new Action Item"
        Dim newActionItemNotes As String = ManagerForm.txtAddNotesActionItemsPage.Text


        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        If ManagerForm.GroupBox_ActionItemsPage.Visible = True Then
            Try
                Using (newsqlconn)
                    Dim sqlcmd = New SqlCommand()
                    With sqlcmd
                        .Connection = newsqlconn
                        .CommandText = "sp_InsertNewActionItemLog"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@UserFullName", UserFullNameLog)
                        .Parameters.AddWithValue("@ActionItemNum", newActionItemNum)
                        .Parameters.AddWithValue("@UserActivity", activityLogActionItem)
                        .Parameters.AddWithValue("@ActivityDate", ActivitydateLog)
                        .Parameters.AddWithValue("@Notes", newActionItemNotes)
                        .ExecuteNonQuery()
                    End With
                End Using

                publicvariables.SendEmail_ToCreatorofItem()
                'publicvariables.SendNewECREmailToEngineeering()
            Catch ex As Exception
                MessageBox.Show("Cannot log - LogActivitiesNewECRCreated: " & ex.Message)
            End Try
            newsqlconn.Close()

        ElseIf ManagerForm.GroupBoxAddNewECR.Visible = True Then
            Try
                Using (newsqlconn)
                    Dim sqlcmd = New SqlCommand()
                    With sqlcmd
                        .Connection = newsqlconn
                        .CommandText = "sp_InsertNewECRLogFiles"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@UserFullName", UserFullNameLog)
                        .Parameters.AddWithValue("@EcrConfNumLog", newECRNum)
                        .Parameters.AddWithValue("@UserActivity", ActivityLog)
                        .Parameters.AddWithValue("@ActivityDate", ActivitydateLog)
                        .Parameters.AddWithValue("@Description", newDescriptionRequest)
                        .ExecuteNonQuery()
                    End With
                End Using

                publicvariables.SendEmail_ToCreatorofItem()
                publicvariables.SendNewECREmailToEngineeering()
            Catch ex As Exception
                MessageBox.Show("Cannot log - LogActivitiesNewECRCreated: " & ex.Message)
            End Try
            newsqlconn.Close()


        Else

        End If


    End Sub

    Public Sub LogAllActivityActionItems()

        Dim UserFullNameLog As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim ActivitydateLog As String = Now
        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        'Dim actoinActionItemActivityNew As String = UserFullNameLog + " created a new Action Item"
        Dim actoinActionItemActivityUpdated As String = UserFullNameLog + " updated an action item"
        Dim actionItemNotes As String = ManagerForm.txtNotesActionItemPage.Text

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            Using (newsqlconn)
                Dim sqlcmd = New SqlCommand()
                With sqlcmd
                    .Connection = newsqlconn
                    .CommandText = "sp_InsertNewActionItemLog"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@UserFullName", UserFullNameLog)
                    .Parameters.AddWithValue("@ActionItemNum", actionItemNum)
                    .Parameters.AddWithValue("@UserActivity", actoinActionItemActivityUpdated)
                    .Parameters.AddWithValue("@ActivityDate", ActivitydateLog)
                    .Parameters.AddWithValue("@Notes", actionItemNotes)
                    .ExecuteNonQuery()
                End With
            End Using

        Catch ex As Exception
            MessageBox.Show("Cannot log Action Items - LogAllActivityActionItems: " & ex.Message)
        End Try
        newsqlconn.Close()

    End Sub

    Public Sub LogActivitiesItemEdited()

        Dim unamelog As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim activity As String = unamelog + " has edited item: " + ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim activitydate As String = ManagerForm.lblTimeMainForm.Text + " " + ManagerForm.lblDateMainForm.Text
        Dim itemnum As String = ManagerForm.lblEcrNumECREditItemsPage.Text

        Dim sqlstr As String
        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlstr = "INSERT INTO LogFiles (uname, EcrConfNum_activity, activity, activitydate) " &
                " VALUES (@uname, @EcrConfNum_activity, @activity, @activitydate); " &
                " SELECT MAX(ID) AS LASTID FROM LogFiles"

            Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
                With sqlcmd
                    newsqlconn.Open()
                    .Parameters.AddWithValue("@uname", unamelog)
                    .Parameters.AddWithValue("@EcrConfNum_activity", itemnum)
                    .Parameters.AddWithValue("@activity", activity)
                    .Parameters.AddWithValue("@activitydate", activitydate)
                    .ExecuteNonQuery()
                End With

            End Using
            newsqlconn.Close()
        Catch ex As Exception
            MessageBox.Show("Cannot log- logActivitiesItemEdited: " & ex.Message)
        End Try

    End Sub

    Public Sub LogAllFinishedActions()

        Dim UserFullNameLog As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim ECRNum As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim description As String = ManagerForm.txtDescriptionECREditItemsPage.Text
        Dim UserActivityLog As String = UserFullNameLog + " updated item: " + ECRNum + " to: " + ManagerForm.cboStatusECREditItemsPage.Text
        Dim ActivityDateLog As String = Now
        Dim sqlstr As String
        Dim newsqlconn As New SqlConnection(connstring)

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        Try
            sqlstr = "INSERT INTO LogFiles (UserFullName, EcrConfNumLog, UserActivity, ActivityDate, Description) " &
                " VALUES (@UserFullName, @EcrConfNumLog, @UserActivity, @ActivityDate, @Description); " &
                " SELECT MAX(ID) AS LASTID FROM LogFiles"

            If ManagerForm.GroupBoxEditECRItems.Visible = True Then

                Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
                    With sqlcmd
                        'newsqlconn.Open()
                        With .Parameters
                            .AddWithValue("@UserFullName", UserFullNameLog)
                            .AddWithValue("@EcrConfNumLog", ECRNum)
                            .AddWithValue("@UserActivity", UserActivityLog)
                            .AddWithValue("@ActivityDate", ActivityDateLog)
                            .AddWithValue("Description", description)
                        End With
                        .ExecuteNonQuery()
                    End With
                End Using

            ElseIf ManagerForm.GroupBoxActionItemsWorkPage.Visible = True Then

                Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
                    With sqlcmd
                        'newsqlconn.Open()
                        With .Parameters
                            .AddWithValue("@UserFullName", UserFullNameLog)
                            .AddWithValue("@EcrConfNumLog", ECRNum)
                            .AddWithValue("@UserActivity", UserActivityLog)
                            .AddWithValue("@ActivityDate", ActivityDateLog)
                        End With
                        .ExecuteNonQuery()
                    End With
                End Using

            ElseIf ManagerForm.GroupBox_ViewOnlyRequestOp.Visible = True Then

                Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
                    With sqlcmd
                        'newsqlconn.Open()
                        With .Parameters
                            .AddWithValue("@UserFullName", UserFullNameLog)
                            .AddWithValue("@EcrConfNumLog", ECRNum)
                            .AddWithValue("@UserActivity", UserActivityLog)
                            .AddWithValue("@ActivityDate", ActivityDateLog)
                        End With
                        .ExecuteNonQuery()
                    End With
                End Using
            End If


        Catch ex As Exception
            MessageBox.Show("Cannot log, error - (LogAllFinishedActions): " & ex.Message)
        End Try
        newsqlconn.Close()


    End Sub

#End Region

#Region "REPORTING"

    Public Sub ByOwner()


    End Sub
#End Region

#Region "CLEARS FIELDS"
    Private Sub Clearfields()

        ClearTextBoxes()

        'Dim a As Control
        'For Each a In ManagerForm.GroupBox3.Controls
        '    If TypeOf a Is TextBox Then
        '        a.Text = Nothing
        '    End If
        'Next
    End Sub

    Public Sub ClearTextBoxes(Optional ByVal ctlcol As Control.ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = ManagerForm.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is TextBox Then
                DirectCast(ctl, TextBox).Clear()
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    ClearTextBoxes(ctl.Controls)
                End If
            End If
        Next
    End Sub
#End Region

End Class
