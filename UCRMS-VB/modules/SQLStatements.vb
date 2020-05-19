'Imports System.Net.Mail
'Imports System.Data
'Imports System.Data.SqlClient

'Module sqlstatements

'    Public sqlcmd As New SqlCommand
'    Public sqlda As New SqlDataAdapter
'    Public mydatatable As DataTable
'    Public sqlquery As String
'    Public myitemid As String
'    'Public table As DataTable
'    Dim result As Integer
'    Dim sqlconn As SqlConnection = DBConn()
'    Public newsqlconn = New SqlConnection With {
'            .ConnectionString = "server=umtgv-db-01-dev.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms"
'        }

'#Region "LOADS ECR ITEMS INTO DATDGRIDVIEW"
'    'Loads ALL action items to view
'    Public Sub LoadAllECRItemsList()
'        Try
'            Dim SQLDataTable As New DataTable
'            Dim bindingSourceAllECRItems As New BindingSource
'            'Dim newsqlconn As New SqlConnection

'            sqlquery = "SELECT ID, EcrConfNum, DateCreated, DateModified, DateAssigned, Status, ECRSubject, ReferenceDocLoc,  " &
'                " Creator, CreatorEmail, ItemOwner, OwnerEmail, DateFinished FROM ChangeRequestItemsDet " &
'                " WHERE Status <> 'Finished' ORDER BY ID DESC"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(SQLDataTable)
'            bindingSourceAllECRItems.DataSource = SQLDataTable
'            ManagerForm.DataGridView1.DataSource = bindingSourceAllECRItems
'            sqlda.Update(SQLDataTable)
'            With ManagerForm.DataGridView1

'                If newsqlconn.State = ConnectionState.Closed Then
'                    newsqlconn.Open()
'                ElseIf newsqlconn.State = ConnectionState.Open Then
'                End If

'                .AutoGenerateColumns = True
'                '.Columns("id").Visible = False
'                '.Columns("comments").Visible = False
'                '.Columns("CreatorEmail").Visible = False
'            End With
'            newsqlconn.Close()
'        Catch ex As Exception
'            MsgBox("Cannot load ALL ECR Items from: (LoadECRItemsList) - " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'    'Loads ECR Items that are assigned only to the logged in user
'    Public Sub LoadMyItems()
'        Try
'            Dim SQLDataTable As New DataTable
'            Dim bindingsource_items As New BindingSource
'            Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text
'            'Dim newsqlconn As New SqlConnection

'            If newsqlconn.State = ConnectionState.Closed Then
'                newsqlconn.Open()
'            ElseIf newsqlconn.State = ConnectionState.Open Then
'            End If

'            sqlquery = "SELECT ID, EcrConfNum, DateCreated, DateModified, DateAssigned, Status, ECRSubject, ReferenceDocLoc,  " &
'                " Creator, CreatorEmail, ItemOwner, OwnerEmail, DateFinished FROM ChangeRequestItemsDet " &
'                " WHERE ItemOwner = '" & userFullName & "' AND Status <> 'Finished' ORDER BY ID DESC"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(SQLDataTable)
'            bindingsource_items.DataSource = SQLDataTable
'            ManagerForm.DataGridView1.DataSource = bindingsource_items
'            sqlda.Update(SQLDataTable)
'            With ManagerForm.DataGridView1
'                .AutoGenerateColumns = True
'            End With
'            newsqlconn.Close()
'        Catch ex As Exception
'            MsgBox("Cannot my ECR items from: (LoadMyItems) - " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'    'Loads ECR Items that had been requested by the logged in user
'    Public Sub LoadMyRequestedECRItems()
'        Try
'            Dim SQLDataTable As New DataTable
'            Dim bindingsource_items As New BindingSource
'            Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text
'            'Dim newsqlconn As New SqlConnection

'            If newsqlconn.State = ConnectionState.Closed Then
'                newsqlconn.Open()
'            ElseIf newsqlconn.State = ConnectionState.Open Then
'            End If

'            sqlquery = "SELECT ID, EcrConfNum, DateCreated, DateModified, DateAssigned, Status, ECRSubject, ReferenceDocLoc,  " &
'                " Creator, CreatorEmail, ItemOwner, OwnerEmail, DateFinished FROM ChangeRequestItemsDet " &
'                " WHERE Creator = '" & userFullName & "' AND Status <> 'Finished' ORDER BY ID DESC"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(SQLDataTable)
'            bindingsource_items.DataSource = SQLDataTable
'            ManagerForm.DataGridView1.DataSource = bindingsource_items
'            sqlda.Update(SQLDataTable)
'            With ManagerForm.DataGridView1
'                .AutoGenerateColumns = True
'            End With
'            newsqlconn.Close()
'        Catch ex As Exception
'            MsgBox("Cannot load my requested ECR items from: (LoadMyRequestedECRItems) - " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'    'Loads Action Items that is used in search bar
'    Public Sub SearchECRItems()
'        Try
'            Dim SQLDataTable As New DataTable
'            Dim bindingsource_items As New BindingSource
'            Dim searchText As String = ManagerForm.searchbar.Text

'            sqlquery = "SELECT id, EcrConfNum, DateCreated, DateModified, ECRSubject, ReferenceDocLoc, DateAssigned,  " &
'                " Creator, ItemOwner, OwnerEmail, DateFinished, Status  " &
'                " FROM ChangeRequestItemsDet " &
'                " WHERE EcrConfNum Like '%" & searchText & "%' " &
'                " OR DateCreated LIKE '%" & searchText & "%'  " &
'                " OR DateFinished LIKE '%" & searchText & "%' " &
'                " OR ECRSubject LIKE '%" & searchText & "%' " &
'                " OR Creator LIKE '%" & searchText & "%' " &
'                " OR ItemOwner LIKE '%" & searchText & "%' " &
'                " ORDER BY ID DESC"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(SQLDataTable)
'            bindingsource_items.DataSource = SQLDataTable
'            ManagerForm.DataGridView1.DataSource = bindingsource_items
'            sqlda.Update(SQLDataTable)
'            With ManagerForm.DataGridView1
'                If newsqlconn.State = ConnectionState.Closed Then
'                    newsqlconn.Open()
'                ElseIf newsqlconn.State = ConnectionState.Open Then
'                End If
'                .AutoGenerateColumns = True
'                '.Columns("id").Visible = False
'                '.Columns("comments").Visible = False
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'    End Sub

'    'Loads all finished ECR from the logged in Engineer
'    Public Sub LoadFinishedItems()
'        Try
'            Dim SQLDataTAble As New DataTable
'            Dim BindingSourceItems As New BindingSource
'            Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text

'            sqlquery = "SELECT ID, EcrConfNum, DateCreated, DateModified, ECRSubject, ReferenceDocLoc, DateAssigned,  " &
'                " Creator, ItemOwner, OwnerEmail, DateFinished, Status FROM ChangeRequestItemsDet " &
'                " WHERE ItemOwner = '" & userFullName & "' AND Status = 'Finished' ORDER BY DateFinished DESC"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(SQLDataTAble)
'            BindingSourceItems.DataSource = SQLDataTAble
'            ManagerForm.DataGridView1.DataSource = BindingSourceItems
'            sqlda.Update(SQLDataTAble)
'            With ManagerForm.DataGridView1
'                newsqlconn.Open()
'                .AutoGenerateColumns = True
'            End With
'            newsqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'    'Loads all finished ECR from the logged in requested User
'    Public Sub LoadMyRequestedFinishedItems()
'        Try
'            Dim SQLDataTAble As New DataTable
'            Dim BindingSourceItems As New BindingSource
'            Dim userFullName As String = ManagerForm.lblUserFullNameMainForm.Text

'            sqlquery = "SELECT ID, EcrConfNum, DateCreated, DateModified, ECRSubject, ReferenceDocLoc, DateAssigned,  " &
'                " Creator, ItemOwner, OwnerEmail, DateFinished, Status FROM ChangeRequestItemsDet " &
'                " WHERE Creator = '" & userFullName & "' AND Status = 'Finished' ORDER BY DateFinished DESC"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(SQLDataTAble)
'            BindingSourceItems.DataSource = SQLDataTAble
'            ManagerForm.DataGridView1.DataSource = BindingSourceItems
'            sqlda.Update(SQLDataTAble)
'            With ManagerForm.DataGridView1
'                newsqlconn.Open()
'                .AutoGenerateColumns = True
'            End With
'            newsqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'    'Loads Rails Items that are selected
'    Public Sub GoToActionItemSelected()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource
'            Dim clickon As String = ManagerForm.DataGridView4.CurrentRow.Cells(2).Value.ToString

'            sqlquery = "SELECT ID, EcrConfNum, DateCreated, DateModified, DateAssigned, Status, ECRSubject, ReferenceDocLoc,  " &
'                " Creator, CreatorEmail, ItemOwner, OwnerEmail, DateFinished FROM ucrms.ChangeRequestItemsDet " &
'                " WHERE EcrConfNum = '" & clickon & "' "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView1.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView1
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'    End Sub

'    Public Sub GoToRequestChangeSelected()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource
'            Dim clickon As String = ManagerForm.DataGridView4.CurrentRow.Cells(2).Value.ToString

'            sqlquery = "SELECT ID, EcrConfNum, plan_id, operation, category, Creator, CreatorEmail, DateCreated, DateModified, DateAssigned, " &
'                " date_finished, description, Status, ItemOwner,OwnerEmail FROM ucrms.ChangeRequest " &
'                " WHERE EcrConfNum = '" & clickon & "' "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView8.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView8
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                '.Columns("id").Visible = False
'                '.Columns("comments").Visible = False
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'    End Sub

'#End Region

'#Region "LOADS REQUESTED OP SHEET CHANGES INTO DATAGRIDVIEW"
'    Public Sub LoadAsssignedOpSheetChanges()

'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource

'            sqlquery = "SELECT ID, EcrConfNum, plan_id, operation, category, Creator, CreatorEmail, DateCreated, DateModified, DateAssigned, " &
'                    " date_finished, description, Status, ItemOwner, OwnerEmail FROM ucrms.ChangeRequest " &
'                    " WHERE ItemOwner = '" & ManagerForm.lblUserFullNameMainForm.Text & "' AND Status <> 'Finished' ORDER BY ID DESC "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView8.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView8
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                '.Columns("id").Visible = False
'                '.Columns("comments").Visible = False
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try


'    End Sub

'    'Loads ALL requested OP Sheet changes into view
'    Public Sub LoadMyRequestedOpSheetChanges()

'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource

'            sqlquery = "SELECT ID, EcrConfNum, plan_id, operation, category, Creator, CreatorEmail, DateCreated, DateModified, DateAssigned, " &
'                    " date_finished, description, Status, ItemOwner, OwnerEmail FROM ucrms.ChangeRequest " &
'                    " WHERE Creator = '" & ManagerForm.lblUserFullNameMainForm.Text & "' AND Status <> 'Finished' ORDER BY ID DESC "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView8.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView8
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                '.Columns("id").Visible = False
'                '.Columns("comments").Visible = False
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try


'    End Sub

'    Public Sub LoadRequestedOpSheetChanges()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource

'            sqlquery = "Select ID, EcrConfNum, plan_id, operation, category, Creator, CreatorEmail, DateCreated, DateModified, DateAssigned, " &
'                " date_finished, description, Status, ItemOwner,OwnerEmail FROM ucrms.ChangeRequest " &
'                " WHERE Status <> 'Finished' ORDER BY ID DESC"

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView8.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView8
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                '.Columns("ID").Visible = False
'                '.Columns("comments").Visible = False
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'    End Sub

'    'Items in the search bar will be queried 
'    Public Sub SearchReqOpSheetChanges()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource
'            Dim searchText As String = ManagerForm.searchBarReqOpSheetChanges.Text

'            sqlquery = "Select ID, EcrConfNum, plan_id, operation, category, Creator, CreatorEmail, DateCreated, DateModified, DateAssigned, " &
'                " date_finished, description, Status, ItemOwner,OwnerEmail FROM ucrms.ChangeRequest " &
'                " WHERE EcrConfNum Like '%" & searchText & "%' " &
'                " OR plan_id LIKE '%" & searchText & "%'  " &
'                " OR operation LIKE '%" & searchText & "%' " &
'                " OR category LIKE '%" & searchText & "%' " &
'                " OR Creator LIKE '%" & searchText & "%' " &
'                " OR DateCreated LIKE '%" & searchText & "%'  " &
'                " OR DateModified LIKE '%" & searchText & "%' " &
'                " OR description LIKE '%" & searchText & "%' " &
'                " OR Status LIKE '%" & searchText & "%' " &
'                " OR Creator LIKE '%" & searchText & "%' " &
'                " OR ItemOwner LIKE '%" & searchText & "%' " &
'                " ORDER BY ID DESC"

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView8.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView8
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                '.Columns("id").Visible = False
'                '.Columns("comments").Visible = False
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'    End Sub
'#End Region

'#Region "LOADS COMMENTS IN THE COMMENTS SECTION"
'    Public Sub LoadComments()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource

'            sqlquery = "SELECT DateCreated, Description FROM tblComments " &
'                " WHERE EcrConfNum = '" & ManagerForm.lblEcrNumViewPage.Text & "' ORDER BY DateCreated desc"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView2.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView2
'                If newsqlconn.State = ConnectionState.Closed Then
'                    newsqlconn.Open()
'                ElseIf newsqlconn.State = ConnectionState.Open Then
'                End If
'                .AutoGenerateColumns = True
'                ManagerForm.DataGridView2.Columns("DateCreated").HeaderText = "Date Created"
'                ManagerForm.DataGridView2.Columns("DateCreated").Width = 125
'                ManagerForm.DataGridView2.Columns("Description").HeaderText = "Description"
'                '.Columns("ID").Visible = False
'                '.Columns("EcrConfNum").Visible = False
'                '.Columns("Date").Visible = True
'                '.Columns("Comments").Visible = True
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox("Error loading comments: (LoadComments) - " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'    Public Sub LoadComments_EditPage()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource

'            sqlquery = "SELECT DateCreated, Description FROM tblComments " &
'                " WHERE EcrConfNum = '" & ManagerForm.lblEcrNumViewPage.Text & "' ORDER BY DateCreated desc"

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView3.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView3
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                With ManagerForm.DataGridView3
'                    .Columns("DateCreated").HeaderText = "Date Created"
'                    .Columns("DateCreated").Width = 125
'                    .Columns("Description").HeaderText = "Description"
'                End With
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'    Public Sub LoadComments_RequestOPChangePage()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource

'            sqlquery = "SELECT DateCreated, Description FROM tblComments " &
'                " WHERE `EcrConfNum` = '" & ManagerForm.lblitemnum_RequestOPChangePage.Text & "' ORDER BY DateCreated desc"

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView5.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView5
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                .Columns("DateCreated").HeaderText = "Date Created"
'                .Columns("DateCreated").Width = 125
'                .Columns("Description").HeaderText = "Description"
'                '.Columns("ID").Visible = False
'                '.Columns("EcrConfNum").Visible = False
'                '.Columns("Date").Visible = True
'                '.Columns("Comments").Visible = True
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub
'    Public Sub LoadMyComments_RequestOPChangePage()
'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_items As New BindingSource

'            sqlquery = "SELECT DateCreated, Description FROM tblComments " &
'                " WHERE `EcrConfNum` = '" & ManagerForm.lblitemnum_viewopsheetchange.Text & "' ORDER BY DateCreated desc"

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_items.DataSource = mydt
'            ManagerForm.DataGridView6.DataSource = bindingsource_items
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView6
'                sqlconn.Open()
'                .AutoGenerateColumns = True
'                .Columns("DateCreated").HeaderText = "Date Created"
'                .Columns("DateCreated").Width = 125
'                .Columns("Description").HeaderText = "Description"
'                '.Columns("ID").Visible = False
'                '.Columns("EcrConfNum").Visible = False
'                '.Columns("Date").Visible = True
'                '.Columns("Comments").Visible = True
'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'#End Region

'#Region "WHEN LOADING COMBO BOX"

'    'Loads the list of the drop down Status in the combo box and diaplayed what the current status is
'    Public Sub LoadCboStatusDropDown_EditPage()
'        Try
'            If sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            ElseIf sqlconn.State = ConnectionState.Open Then

'            End If

'            Dim sqldatatable As New DataTable
'            Dim ecrStatus As String = ManagerForm.lblStatusViewEcrPage.Text

'            ManagerForm.cboStatusECRItemsPage.Text = ecrStatus
'            sqlquery = "SELECT Status FROM tblStatus"
'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                ManagerForm.cboStatusECRItemsPage.DataSource = sqldatatable
'                ManagerForm.cboStatusECRItemsPage.DisplayMember = "Status"
'                ManagerForm.cboStatusECRItemsPage.ValueMember = "Status"
'                ManagerForm.cboStatusECRItemsPage.Text = ecrStatus
'            End If

'        Catch ex As Exception
'            MessageBox.Show("Error loading Status in the drop down box: (LoadCboStatusDropDown_EditPage) - " & ex.Message)
'            sqlconn.Close()

'        End Try
'    End Sub

'    'Calls method to pull what the Status is of the items when selected.
'    Public Sub LoadsStatusCBO_EditPage()
'        Dim sqlquery As String
'        Dim newSQLAdapter As New SqlDataAdapter
'        Dim ds As New DataSet
'        Dim sqldatatable As New DataTable
'        Dim ecrStatus As String = ManagerForm.lblStatusViewEcrPage.Text
'        Dim ecrConfirmNum As String = ManagerForm.lblECRNumEditPage.Text

'        Try
'            If ecrStatus <> "" Then

'                sqlquery = "SELECT EcrConfNum, Status FROM ChangeRequestItemsDet WHERE EcrConfNum = '" & ecrConfirmNum & "' "
'                sqlcmd = New SqlCommand(sqlquery, sqlconn)
'                newSQLAdapter.SelectCommand = sqlcmd
'                newSQLAdapter.Fill(sqldatatable)
'                'newSQLAdapter = New SqlDataAdapter(sqlquery, sqlconn)
'                'sqlconn.Open()
'                newSQLAdapter.Fill(ds, "ucrms")

'                If sqldatatable.Rows.Count > 0 Then
'                    With ManagerForm
'                        .lblStatusViewEcrPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
'                        .cboStatusECRItemsPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
'                    End With
'                Else
'                End If

'            Else
'                LoadCboStatusDropDown_EditPage()
'            End If

'        Catch ex As Exception
'            MsgBox("Cannot load combo box [Status]: (LoadCurrentStatusForCBO_EditPage) - " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'        sqlconn.Close()

'    End Sub


'    'Loads Status according to what the user had input in
'    Public Sub LoadCurrentCboStatus_EditPage()

'        Try
'            Dim sqlQuery As String
'            Dim newSQLAdapter As New SqlDataAdapter
'            Dim ds As New DataSet
'            'Dim ecfConfirmNum As String = ManagerForm.lblEcrNumViewPage.Text
'            Dim ecfConfirmNum As String = ManagerForm.lblECRNumEditPage.Text


'            sqlQuery = "SELECT EcrConfNum, Status FROM ChangeRequestItemsDet WHERE EcrConfNum = '" & ecfConfirmNum & "' "
'            newSQLAdapter = New SqlDataAdapter(sqlQuery, sqlconn)
'            'sqlconn.Open()
'            newSQLAdapter.Fill(ds, "ucrms")

'            With ManagerForm
'                .cboStatusECRItemsPage.Text = ds.Tables("ucrms").Rows(0).Item(1)
'            End With

'            'MsgBox(ManagerForm.lblStatusViewEcrPage.Text)
'        Catch ex As Exception
'            MsgBox("Cannot load combo box [Status], Please contact the Administrator: " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'        sqlconn.Close()

'    End Sub

'    Public Sub LoadOwnerNameDropdown_EditPage()

'        Try
'            Dim sqlQuery As String
'            Dim newSQLAdapter As New SqlDataAdapter
'            Dim ds As New DataSet
'            Dim ecrConFirmNumb As String = ManagerForm.lblECRNumEditPage.Text
'            Dim sqlDataTable As New DataTable

'            sqlQuery = "SELECT EcrConfNum, ItemOwner FROM ChangeRequestItemsDet WHERE EcrConfNum = '" & ecrConFirmNumb & "' ORDER BY ItemOwner asc"
'            sqlcmd = New SqlCommand(sqlQuery, newsqlconn)
'            newSQLAdapter.SelectCommand = sqlcmd
'            newSQLAdapter.Fill(sqlDataTable)

'            'newSQLAdapter = New SqlDataAdapter(sqlQuery, sqlconn)

'            'sqlconn.Open()
'            newSQLAdapter.Fill(ds, "ucrms")
'            If sqlDataTable.Rows.Count > 0 Then

'                With ManagerForm
'                    .cboAssignedToECRItemsPage.Text = ds.Tables("ucrms").Rows(0).Item(1).Value.ToString
'                End With
'            Else

'            End If

'        Catch ex As Exception
'            MsgBox("Cannot load Item Owner: (LoadOwnerNameDropdown_EditPage) - " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'        sqlconn.Close()

'    End Sub

'    'Loads the list of names to choose from in the combo box 
'    Public Sub LoadAssignedToUsersCbo_EditPage()

'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter
'        Dim ecrOwner As String = ManagerForm.lblOwnerViewEcrPage.Text


'        Try
'            'If ecrOwner = "" Then
'            ' MsgBox("No Owner")
'            If newsqlconn.State = ConnectionState.Closed Then
'                newsqlconn.Open()
'            ElseIf newsqlconn.State = ConnectionState.Open Then
'            End If

'            sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email, usertype AS type  " &
'                " FROM useraccounts ORDER BY Users asc"
'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                With ManagerForm
'                    .cboAssignedToECRItemsPage.DataSource = sqldatatable
'                    .cboAssignedToECRItemsPage.DisplayMember = "Users"
'                    .cboAssignedToECRItemsPage.ValueMember = "Users"
'                    .cboAssignedToECRItemsPage.SelectedIndex = -1
'                    .cboAssignedToECRItemsPage.Text = ecrOwner
'                End With
'            End If

'            newsqlconn.Close()
'            'Else
'            'LoadUsersCbo_AddPage()
'            'End If

'        Catch ex As Exception
'            MessageBox.Show("Error loading users into the dropdown box while editing items: (LoadUsersCbo_EditPage) - " & ex.Message)
'        End Try

'    End Sub

'    Public Sub LoadCboStatusDropDown_RequestOPChangePage()
'        Dim sqldatatable As New DataTable

'        Try
'            sqlquery = "SELECT `Status` FROM ucrms.tblStatus"
'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                With ManagerForm
'                    .cbostatus_RequestOPChangePage.DataSource = sqldatatable
'                    .cbostatus_RequestOPChangePage.DisplayMember = "Status"
'                    .cbostatus_RequestOPChangePage.ValueMember = "Status"
'                End With
'            End If

'        Catch ex As Exception
'            MessageBox.Show("Error loading Status in the drop down box : (LoadCboStatusDropDown_RequestOPChangePage) - " & ex.Message)
'            sqlconn.Close()

'        End Try
'    End Sub

'    ' Loads the current Status on the item back into the view
'    Public Sub LoadCurrentCboStatusDropDown_RequestOPChangePage()
'        Try
'            Dim sqlstr As String
'            Dim sqlda As New SqlDataAdapter
'            Dim ds As New DataSet

'            sqlstr = "SELECT EcrConfNum, Status FROM ChangeRequest " &
'                " WHERE EcrConfNum = '" & ManagerForm.lblitemnum_RequestOPChangePage.Text & "' "
'            sqlda = New SqlDataAdapter(sqlstr, sqlconn)
'            sqlda.Fill(ds, "ucrms")

'            With ManagerForm
'                .cbostatus_RequestOPChangePage.Text = ds.Tables("ucrms").Rows(0).Item(1)
'            End With

'        Catch ex As Exception
'            MsgBox("Cannot load combo box, Please contact the Administrator" & ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'        sqlconn.Close()

'    End Sub

'    Public Sub LoadCboIssueType_NewRequestOPChangePage()
'        Dim sqldatatable As New DataTable

'        Try
'            sqlquery = "SELECT issue_type FROM IssueType"
'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                With ManagerForm
'                    .cboissue_type.DataSource = sqldatatable
'                    .cboissue_type.DisplayMember = "issue_type"
'                    .cboissue_type.ValueMember = "issue_type"
'                End With
'            End If

'        Catch ex As Exception
'            MessageBox.Show("Error loading Status in the issue type drop down box :" & ex.Message)
'            sqlconn.Close()

'        End Try
'        ManagerForm.cboissue_type.SelectedIndex = -1

'    End Sub

'    Public Sub LoadCboIssueType_RequestOPChangePage()
'        Dim sqldatatable As New DataTable

'        Try
'            sqlquery = "SELECT issue_type FROM IssueType"
'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                With ManagerForm
'                    .cbocategory_RequestOPChangePage.DataSource = sqldatatable
'                    .cbocategory_RequestOPChangePage.DisplayMember = "issue_type"
'                    .cbocategory_RequestOPChangePage.ValueMember = "issue_type"
'                End With
'            End If

'        Catch ex As Exception
'            MessageBox.Show("Error loading Status in the issue type drop down box :" & ex.Message)
'            sqlconn.Close()

'        End Try


'    End Sub

'    ' Loads the current Issue Type back into view when selected from datagridview8
'    Public Sub LoadsCurrentIssueType_RequestOPChangePage()
'        Try
'            Dim sqlstr As String
'            Dim sqlda As New SqlDataAdapter
'            Dim ds As New DataSet

'            sqlstr = "SELECT `EcrConfNum`, `category` FROM ucrms.tblchange_request " &
'                " WHERE `EcrConfNum` = '" & ManagerForm.lblitemnum_RequestOPChangePage.Text & "' "
'            sqlda = New SqlDataAdapter(sqlstr, sqlconn)
'            sqlda.Fill(ds, "ucrms")

'            With ManagerForm
'                .cbocategory_RequestOPChangePage.Text = ds.Tables("ucrms").Rows(0).Item(1)
'            End With

'        Catch ex As Exception
'            MsgBox("Cannot load combo box issue type, Please contact the Administrator" & ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'        sqlconn.Close()
'    End Sub

'    Public Sub LoadUsersCbo_RequestOPChangePage()

'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter

'        Try
'            If sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            ElseIf sqlconn.State = ConnectionState.Open Then
'            End If

'            sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email, usertype AS type  " &
'                " FROM ucrms.useraccounts ORDER BY Users asc"
'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                With ManagerForm
'                    .cboowner_RequestOPChangePage.DataSource = sqldatatable
'                    .cboowner_RequestOPChangePage.DisplayMember = "Users"
'                    .cboowner_RequestOPChangePage.ValueMember = "Users"
'                    .cboowner_RequestOPChangePage.SelectedIndex = -1
'                End With

'            End If
'            sqlconn.Close()

'        Catch ex As Exception
'            MessageBox.Show("Error loading users into the dropdown box while editing items: " & ex.Message)
'        End Try

'    End Sub

'    ' Loads the current user/ItemOwner into view when selected
'    Public Sub LoadCurrentUsersCbo_RequestOPChangePage()
'        Try


'            Dim sqlstr As String
'            Dim sqlda As New SqlDataAdapter
'            Dim ds As New DataSet

'            sqlstr = "SELECT `EcrConfNum`, `ItemOwner` FROM ucrms.tblchange_request " &
'                    " WHERE `EcrConfNum` = '" & ManagerForm.lblitemnum_RequestOPChangePage.Text & "' ORDER BY ItemOwner asc"
'            sqlda = New SqlDataAdapter(sqlstr, sqlconn)
'            sqlda.Fill(ds, "ucrms")

'            With ManagerForm
'                .cboowner_RequestOPChangePage.Text = ds.Tables("ucrms").Rows(0).Item(1)
'            End With


'        Catch ex As Exception
'            'MsgBox("Cannot load ItemOwner for the request OP sheet changes, please contact the Administrator, " & ex.Message, MsgBoxStyle.Exclamation)
'        End Try
'        sqlconn.Close()
'    End Sub

'    Public Sub CboloadCategory_RequestOPChangePage()

'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter

'        Try
'            If sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            ElseIf sqlconn.State = ConnectionState.Open Then
'            End If

'            sqlquery = "SELECT ID AS ID, issue_type AS Category " &
'                " FROM ucrms.IssueType"
'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                With ManagerForm
'                    .cboissue_type.DataSource = sqldatatable
'                    .cboissue_type.DisplayMember = "Category"
'                    .cboissue_type.ValueMember = "Category"
'                    .cboissue_type.SelectedIndex = -1
'                End With

'            End If
'            sqlconn.Close()

'        Catch ex As Exception
'            MessageBox.Show("Error loading category into the dropdown box in the add items page: " & ex.Message)
'        End Try

'    End Sub

'    Public Sub LoadUsersCbo_AddPage() ' Loads the combo box with the users

'        Dim sqldatatable As New DataTable
'        Dim sqlda As New SqlDataAdapter

'        Try
'            If newsqlconn.State = ConnectionState.Closed Then
'                newsqlconn.Open()
'            ElseIf newsqlconn.State = ConnectionState.Open Then
'            End If

'            sqlquery = "SELECT ID AS ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) AS Users, useremail AS email, usertype AS type  " &
'                " FROM useraccounts ORDER BY Users asc"
'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(sqldatatable)

'            If sqldatatable.Rows.Count > 0 Then
'                With ManagerForm
'                    .cboAddOwnerNewECRPage.DisplayMember = "Users"
'                    .cboAddOwnerNewECRPage.DataSource = sqldatatable
'                    .cboAddOwnerNewECRPage.ValueMember = "Users"
'                    .cboAddOwnerNewECRPage.SelectedIndex = -1
'                    'MessageBox.Show(.cboAddOwner.DisplayMember)
'                End With

'            End If
'            newsqlconn.Close()

'        Catch ex As Exception
'            MessageBox.Show("Error loading users into the dropdown box in the add new ECR page: (LoadUsersCbo_AddPage) - " & ex.Message)
'        End Try

'    End Sub

'    Public Sub LoadOwnerECREditPage()

'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter
'        Dim myReader As SqlDataReader

'        Try
'            If sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            ElseIf sqlconn.State = ConnectionState.Open Then
'            End If
'            sqlquery = "SELECT * FROM (SELECT ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype FROM useraccounts) base " &
'                " WHERE FullName = '" & ManagerForm.cboAssignedToECRItemsPage.Text & "' "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            myReader = sqlcmd.ExecuteReader

'            While myReader.Read
'                ManagerForm.lblowner_id_edit.Text = myReader.GetInt32(0)
'                ManagerForm.lblownerfullname.Text = myReader.GetString(3)
'                ManagerForm.lblowners_email.Text = myReader.GetString(4)
'                ManagerForm.lblusertype_edit.Text = myReader.GetString(5)
'                'lblcreators_email.Text = myReader.GetString("CreatorEmail")
'            End While
'            sqlconn.Close()

'        Catch ex As Exception
'            MessageBox.Show("Error in this section: (LoadOwnerECREditPage) - " & ex.Message)
'        End Try
'    End Sub

'    Public Sub LoadOwnerInfoNewEcrPage()

'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter
'        Dim myReader As SqlDataReader

'        Try
'            If sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            ElseIf sqlconn.State = ConnectionState.Open Then
'            End If
'            sqlquery = "SELECT * FROM (SELECT id, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype FROM useraccounts) base " &
'                " WHERE FullName = '" & ManagerForm.cboAddOwnerNewECRPage.Text & "' "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            myReader = sqlcmd.ExecuteReader

'            While myReader.Read
'                ManagerForm.lblowner_id_edit.Text = myReader.GetInt32(0)
'                ManagerForm.lblownerfullname.Text = myReader.GetString(3)
'                ManagerForm.lblowners_email.Text = myReader.GetString(4)
'                ManagerForm.lblusertype_edit.Text = myReader.GetString(5)
'                'lblcreators_email.Text = myReader.GetString("CreatorEmail")
'            End While
'            sqlconn.Close()

'        Catch ex As Exception
'            MessageBox.Show("Error in this section: LoadOwnerInfoNewEcrPage " & ex.Message)
'        End Try
'    End Sub

'#End Region

'#Region "ADDING NEW ITEMS INTO ECR"

'    Public Sub AddNewEcrItems()
'        'Dim sqlstr As String
'        Try
'            If sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            ElseIf sqlconn.State = ConnectionState.Open Then
'            End If

'            If ManagerForm.txtAddEcrSubjectNewECRPage.Text = "" Then
'                MsgBox("A New ECR Item has To be filled out first before continuing.")
'            Else
'                Using (sqlconn)
'                    Dim sqlcmd As New SqlCommand()

'                    With sqlcmd
'                        .Connection = sqlconn
'                        'sqlconn.Open()
'                        .CommandText = "sp_InsertNewEcrRecords"
'                        .CommandType = CommandType.StoredProcedure
'                        .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblECRNumNewECRPage.Text)
'                        .Parameters.AddWithValue("@DateCreated", Now)
'                        .Parameters.AddWithValue("@Status", "New")
'                        .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtAddEcrSubjectNewECRPage.Text)
'                        .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtAddEcrRefDocNewECRPage.Text)
'                        .Parameters.AddWithValue("@Creator", ManagerForm.lblUserFullNameMainForm.Text)
'                        .Parameters.AddWithValue("@CreatorEmail", ManagerForm.lblUserEmailMainForm.Text)
'                        .ExecuteNonQuery()
'                    End With
'                End Using
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Cannot create a new ECR - (AddNewEcrItems): " & ex.Message)
'        End Try
'        sqlconn.Close()

'    End Sub

'    Public Sub TestAddNewEcrItems()
'        Try
'            If ManagerForm.txtAddEcrSubjectNewECRPage.Text = "" Then
'                MsgBox("Please enter an ECR Subject to continue.")
'            Else
'                'sqlconn = New SqlConnection(sqlstr)
'                Using (sqlconn)
'                    Dim sqlcmd As New SqlCommand()

'                    With sqlcmd
'                        .Connection = sqlconn
'                        sqlconn.Open()
'                        .CommandText = "sp_InsertNewEcrRecords"
'                        .CommandType = CommandType.StoredProcedure
'                        .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblECRNumNewECRPage.Text)
'                        .Parameters.AddWithValue("@DateCreated", Now)
'                        .Parameters.AddWithValue("@Status", "Open")
'                        .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtAddEcrSubjectNewECRPage.Text)
'                        .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtAddEcrRefDocNewECRPage.Text)
'                        .Parameters.AddWithValue("@Creator", ManagerForm.lblUserFullNameMainForm.Text)
'                        .Parameters.AddWithValue("@CreatorEmail", ManagerForm.lblUserEmailMainForm.Text)
'                        .ExecuteNonQuery()
'                    End With

'                End Using

'            End If
'        Catch ex As Exception
'            MessageBox.Show("Cannot create an action item " & ex.Message)
'        End Try
'        sqlconn.Close()

'    End Sub
'    Public Sub RequestOpSheetChanges()
'        Dim sqlstr As String
'        Try
'            If ManagerForm.txtplanid_reqchge.Text = "" Then
'                MsgBox("Please enter an Plan ID.")

'            Else

'                sqlstr = "INSERT INTO ChangeRequest " &
'                " (EcrConfNum, plan_id, operation, category , Creator, CreatorEmail, DateCreated, description, Status) " &
'                " VALUES (@EcrConfNum, @plan_id, @operation, @category, @Creator, @CreatorEmail, @DateCreated, @description, @Status); " &
'                " SELECT LAST_INSERT_ID()"
'                Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                    With sqlcmd
'                        sqlconn.Open()
'                        .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblrequestnum_newrequestpage.Text)
'                        .Parameters.AddWithValue("@plan_id", ManagerForm.txtplanid_reqchge.Text)
'                        .Parameters.AddWithValue("@operation", ManagerForm.txtop_reqchge.Text)
'                        .Parameters.AddWithValue("@category", ManagerForm.cboissue_type.Text)
'                        .Parameters.AddWithValue("@Creator", ManagerForm.lblUserFullNameMainForm.Text)
'                        .Parameters.AddWithValue("@CreatorEmail", ManagerForm.lblUserEmailMainForm.Text)
'                        .Parameters.AddWithValue("@DateCreated", Now)
'                        .Parameters.AddWithValue("@description", ManagerForm.txtdesc_reqchge.Text)
'                        .Parameters.AddWithValue("@Status", "Open")
'                        .ExecuteNonQuery()
'                    End With
'                End Using

'            End If
'        Catch ex As Exception
'            MessageBox.Show("Cannot create a request " & ex.Message)
'        End Try
'        sqlconn.Close()


'    End Sub

'#End Region

'#Region "EDITING ECR ITEMS"
'    Public Sub UpdateECRItems()
'        Dim sqlda As New SqlDataAdapter
'        Dim mydatatable As New DataTable
'        Dim CreatorFullName As String
'        CreatorFullName = ManagerForm.lblCreatorECREditPage.Text

'        'Checks for the connection
'        If newsqlconn.State = ConnectionState.Open Then
'            'MsgBox("Logging out at " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm : sstt "))
'            newsqlconn.Close()
'        ElseIf newsqlconn.State = ConnectionState.Closed Then
'        End If

'        'Calls the function to write all the comments on a seperate table to track the history of it
'        'writeNewComments_ActionItemsEditPage()

'#Region "If statement - ElseIf Action Item  = Finished Then"

'        'If statement starts here collects the information depending on how the user enters the data
'        If ManagerForm.txtECRSubjectECRItemsPage.Text = "" Then
'            MsgBox("An ECR Item has To be filled out first before continuing.")

'        ElseIf ManagerForm.cboStatusECRItemsPage.Text = "Finished" Then

'            Try
'                sqlda.SelectCommand = sqlcmd
'                sqlda.Fill(mydatatable)

'                If ManagerForm.cboAssignedToECRItemsPage.Text <> CreatorFullName Then

'                    Using cmdSaveVend As New SqlCommand()
'                        cmdSaveVend.Connection = newsqlconn
'                        With cmdSaveVend
'                            newsqlconn.Open()

'                            .CommandText = "UPDATE ChangeRequestItemsDet " &
'                            " SET DateFinished=@DateFinished, " &
'                            " DateAssigned=@DateAssigned, " &
'                            " Status=@Status, " &
'                            " ECRSubject=@ECRSubject, " &
'                            " ReferenceDocLoc=@ReferenceDocLoc, " &
'                            " ItemOwner=@ItemOwner, " &
'                            " OwnerEmail=@OwnerEmail " &
'                            " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                            .CommandType = Data.CommandType.Text
'                            .Parameters.AddWithValue("@DateFinished", Now)
'                            .Parameters.AddWithValue("@DateAssigned", Now)
'                            .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                            .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                        End With
'                        cmdSaveVend.ExecuteNonQuery()

'                    End Using

'                ElseIf ManagerForm.cboAssignedToECRItemsPage.Text = CreatorFullName Then

'                    Using cmdSaveVend As New SqlCommand()
'                        cmdSaveVend.Connection = newsqlconn
'                        With cmdSaveVend
'                            newsqlconn.Open()

'                            .CommandText = "UPDATE ChangeRequestItemsDet " &
'                            " SET DateFinished=@DateFinished, " &
'                            " DateAssigned=@DateAssigned, " &
'                            " Status=@Status, " &
'                            " ECRSubject=@ECRSubject, " &
'                            " ReferenceDocLoc=@ReferenceDocLoc, " &
'                            " ItemOwner=@ItemOwner, " &
'                            " OwnerEmail=@OwnerEmail " &
'                            " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                            .CommandType = Data.CommandType.Text
'                            .Parameters.AddWithValue("@DateFinished", Now)
'                            .Parameters.AddWithValue("@DateAssigned", Now)
'                            .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                            .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                        End With
'                        cmdSaveVend.ExecuteNonQuery()

'                    End Using

'                End If

'                newsqlconn.Close()

'                MsgBox("ECR Item: " & " '" & ManagerForm.lblECRNumEditPage.Text & "' " & " has been marked as finished.")

'                ' 2 - Logging into history for tracking purposes 
'                LogAllFinishedActions()
'                'Calls the function to write all the comments on a seperate table to track the history of it
'                WriteNewComments_ActionItemsEditPage()
'                ' 1 - Sends email to the Creator and the ItemOwner upon finishing an item
'                SendeMail_AllUsersUponItemsEdited()
'            Catch ex As SqlException
'                MsgBox("Error cannot exceute finished, (second if statement) -  " & ex.Message, MsgBoxStyle.Information)
'            End Try


'        ElseIf ManagerForm.cboStatusECRItemsPage.Text <> "Finished" Then


'            Try
'                If ManagerForm.cboAssignedToECRItemsPage.Text <> CreatorFullName Then

'                    If ManagerForm.cboAssignedToECRItemsPage.Text = "" Then

'                    ElseIf ManagerForm.cboAssignedToECRItemsPage.Text <> "" Then
'                        ' email the newly assigned user the confirmation of assignment
'                        SendeMail_OfReassignmentUser()

'                    End If


'                    Using cmdSaveVend As New SqlCommand()
'                        cmdSaveVend.Connection = newsqlconn
'                        With cmdSaveVend
'                            newsqlconn.Open()

'                            .CommandText = "UPDATE ChangeRequestItemsDet " &
'                                " SET DateModified=@DateModified, " &
'                                " DateAssigned=@DateAssigned, " &
'                                " Status=@Status, " &
'                                " ECRSubject=@ECRSubject, " &
'                                " ReferenceDocLoc=@ReferenceDocLoc, " &
'                                " ItemOwner=@ItemOwner, " &
'                                " OwnerEmail=@OwnerEmail " &
'                                " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                            .CommandType = Data.CommandType.Text
'                            .Parameters.AddWithValue("@DateModified", Now)
'                            .Parameters.AddWithValue("@DateAssigned", Now)
'                            .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                            .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                        End With
'                        cmdSaveVend.ExecuteNonQuery()

'                    End Using

'                ElseIf ManagerForm.cboAssignedToECRItemsPage.Text = CreatorFullName Then

'                    Using cmdSaveVend As New SqlCommand()
'                        cmdSaveVend.Connection = newsqlconn
'                        With cmdSaveVend
'                            newsqlconn.Open()

'                            .CommandText = "UPDATE ChangeRequestItemsDet " &
'                                " SET DateModified=@DateModified, " &
'                                " DateAssigned=@DateAssigned, " &
'                                " Status=@Status, " &
'                                " ECRSubject=@ECRSubject, " &
'                                " ReferenceDocLoc=@ReferenceDocLoc, " &
'                                " ItemOwner=@ItemOwner, " &
'                                " OwnerEmail=@OwnerEmail " &
'                                " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                            .CommandType = Data.CommandType.Text
'                            .Parameters.AddWithValue("@DateModified", Now)
'                            .Parameters.AddWithValue("@DateAssigned", Now)
'                            .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                            .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                            .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                        End With
'                        cmdSaveVend.ExecuteNonQuery()

'                    End Using

'                End If

'                newsqlconn.Close()
'                ' 2 - Logging into history for tracking purposes 
'                LogAllFinishedActions()
'                'Calls the function to write all the comments on a seperate table to track the history of it
'                WriteNewComments_ActionItemsEditPage()
'                ' 1 - Sends email to the Creator and the ItemOwner upon finishing an item
'                SendeMail_AllUsersUponItemsEdited()
'            Catch ex As SqlException
'                MsgBox("Error cannot exceute saving ECR item, (third if statement) - " & ex.Message, MsgBoxStyle.Information)
'            End Try

'#End Region

'        Else

'        End If

'        'MsgBox("Action Item: " & " '" & ManagerForm.lblitemnum_editactionitempage.Text & "' " & " has been saved.")
'        Clearfields()
'        ClearTextBoxes()
'        ManagerForm.cboStatusECRItemsPage.SelectedIndex = -1
'        ManagerForm.cboAssignedToECRItemsPage.SelectedIndex = -1


'    End Sub

'    Public Sub UpdateActionItemsNoEmail()

'        Dim sqlda As New SqlDataAdapter
'        Dim mydatatable As New DataTable
'        Dim CreatorFullName As String
'        CreatorFullName = ManagerForm.lblcreatorfullname.Text

'        'Checks for the connection
'        If sqlconn.State = ConnectionState.Open Then
'            'MsgBox("Logging out at " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm : sstt "))
'            sqlconn.Close()
'        ElseIf sqlconn.State = ConnectionState.Closed Then
'        End If

'        'Calls the function to write all the comments on a seperate table to track the history of it
'        'writeNewComments_ActionItemsEditPage()

'#Region "If statement - ElseIf Action Item  = Finished Then"

'        'If statement starts here collects the information depending on how the user enters the data
'        If ManagerForm.txtECRSubjectECRItemsPage.Text = "" Then
'            MsgBox("An Action Item has To be filled out first before continuing.")

'        ElseIf ManagerForm.cboStatusECRItemsPage.Text = "Finished" Then

'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydatatable)

'            If ManagerForm.cboAssignedToECRItemsPage.Text <> CreatorFullName Then

'                Using cmdSaveVend As New SqlCommand()
'                    cmdSaveVend.Connection = sqlconn
'                    With cmdSaveVend
'                        sqlconn.Open()

'                        .CommandText = "UPDATE ChangeRequestItemsDet " &
'                            " SET DateFinished=@DateFinished, " &
'                            " DateAssigned=@DateAssigned, " &
'                            " Status=@Status, " &
'                            " ECRSubject=@ECRSubject, " &
'                            " ReferenceDocLoc=@ReferenceDocLoc, " &
'                            " ItemOwner=@ItemOwner, " &
'                            " OwnerEmail=@OwnerEmail " &
'                            " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                        .CommandType = Data.CommandType.Text
'                        .Parameters.AddWithValue("@DateFinished", Now)
'                        .Parameters.AddWithValue("@DateAssigned", Now)
'                        .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                        .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                    End With
'                    cmdSaveVend.ExecuteNonQuery()

'                End Using

'            ElseIf ManagerForm.cboAssignedToECRItemsPage.Text = CreatorFullName Then

'                Using cmdSaveVend As New SqlCommand()
'                    cmdSaveVend.Connection = sqlconn
'                    With cmdSaveVend
'                        sqlconn.Open()

'                        .CommandText = "UPDATE ChangeRequestItemsDet " &
'                            " SET DateFinished=@DateFinished, " &
'                            " DateAssigned=@DateAssigned, " &
'                            " Status=@Status, " &
'                            " ECRSubject=@ECRSubject, " &
'                            " ReferenceDocLoc=@ReferenceDocLoc, " &
'                            " ItemOwner=@ItemOwner, " &
'                            " OwnerEmail=@OwnerEmail " &
'                            " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                        .CommandType = Data.CommandType.Text
'                        .Parameters.AddWithValue("@DateFinished", Now)
'                        .Parameters.AddWithValue("@DateAssigned", Now)
'                        .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                        .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                    End With
'                    cmdSaveVend.ExecuteNonQuery()

'                End Using

'            End If

'            sqlconn.Close()

'            MsgBox("Action Item: " & " '" & ManagerForm.lblECRNumEditPage.Text & "' " & " has been marked as finished.")

'            ' 2 - Logging into history for tracking purposes 
'            LogAllFinishedActions()
'            'Calls the function to write all the comments on a seperate table to track the history of it
'            WriteNewComments_ActionItemsEditPage()

'            ' ' Comment out becuase user selected to click on save and not the Email & Save button
'            ' sendeMail_AllUsersUponItemsEdited()

'        ElseIf ManagerForm.cboStatusECRItemsPage.Text <> "Finished" Then

'            If ManagerForm.cboAssignedToECRItemsPage.Text <> CreatorFullName Then

'                'If ManagerForm.cboowner_editactionitempage.Text = "" Then

'                'ElseIf ManagerForm.cboowner_editactionitempage.Text <> "" Then
'                '    ' Email will still go out becuase of reassigning to a new ItemOwner
'                '    ' sendeMail_OfReassignmentUser()
'                'ElseIf ManagerForm.cboowner_editactionitempage.Text <> ManagerForm.cboowner_editactionitempage.Text Then
'                '    ' Email will still go out becuase of reassigning to a new ItemOwner
'                '    'sendeMail_OfReassignmentUser()
'                'End If

'                Using cmdSaveVend As New SqlCommand()
'                    cmdSaveVend.Connection = sqlconn
'                    With cmdSaveVend
'                        sqlconn.Open()

'                        .CommandText = "UPDATE ChangeRequestItemsDet " &
'                                " SET DateModified=@DateModified, " &
'                                " DateAssigned=@DateAssigned, " &
'                                " Status=@Status, " &
'                                " ECRSubject=@ECRSubject, " &
'                                " ReferenceDocLoc=@ReferenceDocLoc, " &
'                                " ItemOwner=@ItemOwner, " &
'                                " OwnerEmail=@OwnerEmail " &
'                                " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                        .CommandType = Data.CommandType.Text
'                        .Parameters.AddWithValue("@DateModified", Now)
'                        .Parameters.AddWithValue("@DateAssigned", Now)
'                        .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                        .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                    End With
'                    cmdSaveVend.ExecuteNonQuery()

'                End Using

'            ElseIf ManagerForm.cboAssignedToECRItemsPage.Text = CreatorFullName Then

'                Using cmdSaveVend As New SqlCommand()
'                    cmdSaveVend.Connection = sqlconn
'                    With cmdSaveVend
'                        sqlconn.Open()

'                        .CommandText = "UPDATE ChangeRequestItemsDet " &
'                                " SET DateModified=@DateModified, " &
'                                " DateAssigned=@DateAssigned, " &
'                                " Status=@Status, " &
'                                " ECRSubject=@ECRSubject, " &
'                                " ReferenceDocLoc=@ReferenceDocLoc, " &
'                                " ItemOwner=@ItemOwner, " &
'                                " OwnerEmail=@OwnerEmail " &
'                                " WHERE EcrConfNum= '" & ManagerForm.lblECRNumEditPage.Text & "';"

'                        .CommandType = Data.CommandType.Text
'                        .Parameters.AddWithValue("@DateModified", Now)
'                        .Parameters.AddWithValue("@DateAssigned", Now)
'                        .Parameters.AddWithValue("@Status", ManagerForm.cboStatusECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ECRSubject", ManagerForm.txtECRSubjectECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ReferenceDocLoc", ManagerForm.txtRefDocECRItemsPage.Text)
'                        .Parameters.AddWithValue("@ItemOwner", ManagerForm.cboAssignedToECRItemsPage.Text)
'                        .Parameters.AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)

'                    End With
'                    cmdSaveVend.ExecuteNonQuery()

'                End Using

'            End If

'            sqlconn.Close()
'            ' 2 - Logging into history for tracking purposes 
'            LogAllFinishedActions()
'            'Calls the function to write all the comments on a seperate table to track the history of it
'            WriteNewComments_ActionItemsEditPage()
'            ' Comment out becuase user selected to click on save and not the Email & Save button
'            ' sendeMail_AllUsersUponItemsEdited()

'#End Region

'        Else

'        End If

'        'MsgBox("Action Item: " & " '" & ManagerForm.lblitemnum_editactionitempage.Text & "' " & " has been saved.")
'        Clearfields()
'        ClearTextBoxes()
'        ManagerForm.cboStatusECRItemsPage.SelectedIndex = -1
'        ManagerForm.cboAssignedToECRItemsPage.SelectedIndex = -1
'    End Sub

'#End Region

'#Region "EDITING REQUEST OP SHEET CHANGES"

'    Public Sub UpdateReqOpSheetChanges_NoEmail()
'        Dim sqlda As New SqlDataAdapter
'        Dim mydatatable As New DataTable
'        Dim CreatorFullName As String
'        CreatorFullName = ManagerForm.lblcreatorfullname.Text

'        'Checks for the connection
'        If sqlconn.State = ConnectionState.Open Then
'            'MsgBox("Logging out at: " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:sstt "))
'            sqlconn.Close()
'        ElseIf sqlconn.State = ConnectionState.Closed Then
'        End If

'        If ManagerForm.txtplanid_RequestOPChangePage.Text = "" Then
'            MsgBox("There must be an Plan ID before continuing.")

'#Region "ElseIf Item is finished"
'        ElseIf ManagerForm.cboowner_RequestOPChangePage.Text = "Finished" Then

'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydatatable)


'            'Calls subroutine -Sends email upon finishing
'            ' SendFinishedItemNotifyToBoth_RequestedOpSheetChange()

'            'Calls subroutine- Logged into activity history
'            LogAllFinishedActions()
'            'Calls subroutine to save the comments, if there is none it ignores it
'            SaveCommentsAndOrNotes()
'            'Calls subroutine to save everything when finished
'            SaveItemIntoDbFinished_RequestOpSheetChange()

'#End Region
'#Region "ElseIf Item is NOT Finished"
'        ElseIf ManagerForm.cboowner_RequestOPChangePage.Text <> "Finished" Then

'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydatatable)

'            If ManagerForm.cboowner_RequestOPChangePage.Text = CreatorFullName Then
'                ' MessageBox.Show("Not Finished And Creator is ItemOwner")
'                'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
'                ' sendEmail_ToBoth_RequestedOpSheetChange()
'                'Calls subroutine- Logged into activity history
'                LogAllFinishedActions()
'                'Calls subroutine to save the comments, if there is none it ignores it
'                SaveCommentsAndOrNotes()
'                'Calls subroutine - save when item is NOT Finished and Creator is not the ItemOwner of the item
'                SaveItemIntodb_RequestOPChangePage()

'            ElseIf ManagerForm.cboowner_RequestOPChangePage.Text <> CreatorFullName Then

'                'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
'                ' sendEmail_ToBoth_RequestedOpSheetChange()
'                'Calls subroutine- Logged into activity history
'                LogAllFinishedActions()
'                'Calls subroutine to save the comments, if there is none it ignores it
'                SaveCommentsAndOrNotes()
'                'Calls subroutine - saves when item is finished
'                SaveItemIntodb_RequestOPChangePage()

'            End If

'#End Region

'            ClearTextBoxes()
'            ManagerForm.cbostatus_RequestOPChangePage.SelectedIndex = -1
'            ManagerForm.cboowner_RequestOPChangePage.SelectedIndex = -1
'            ManagerForm.cbocategory_RequestOPChangePage.SelectedIndex = -1
'            ManagerForm.lblitemnum_RequestOPChangePage.Text = ""
'        End If

'    End Sub

'    Public Sub UpdateReqOpSheetChanges()
'        Dim sqlda As New SqlDataAdapter
'        Dim mydatatable As New DataTable

'        'Checks for the connection
'        If sqlconn.State = ConnectionState.Open Then
'            'MsgBox("Logging out at: " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:sstt "))
'            sqlconn.Close()
'        ElseIf sqlconn.State = ConnectionState.Closed Then
'        End If

'        If ManagerForm.txtplanid_RequestOPChangePage.Text = "" Then
'            MsgBox("There must be an Plan ID before continuing.")

'#Region "ElseIf Item is finished"
'        ElseIf ManagerForm.cbostatus_RequestOPChangePage.Text = "Finished" Then

'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydatatable)

'            'Calls subroutine -Sends email upon finishing
'            SendEmail_ToBoth_RequestedOpSheetChangeFinished()

'            'Calls subroutine- Logged into activity history
'            LogAllFinishedActions()
'            'Calls subroutine to save the comments, if there is none it ignores it
'            SaveCommentsAndOrNotes()
'            'Calls subroutine to save everything when finished
'            SaveItemIntoDbFinished_RequestOpSheetChange()

'#End Region
'#Region "ElseIf Item is NOT Finished"
'        ElseIf ManagerForm.cbostatus_RequestOPChangePage.Text <> "Finished" Then
'            Dim CreatorFullName As String
'            CreatorFullName = ManagerForm.lblcreator_RequestOPChangePage.Text

'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydatatable)

'            If ManagerForm.cboowner_RequestOPChangePage.Text = CreatorFullName Then
'                ' MessageBox.Show("Not Finished And Creator is ItemOwner")
'                'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
'                SendEmail_ToBoth_RequestedOpSheetChange()
'                'Calls subroutine- Logged into activity history
'                LogAllFinishedActions()
'                'Calls subroutine to save the comments, if there is none it ignores it
'                SaveCommentsAndOrNotes()
'                'Calls subroutine - save when item is NOT Finished and Creator is not the ItemOwner of the item
'                SaveItemIntodb_RequestOPChangePage()
'                sqlconn.Close()
'            ElseIf ManagerForm.cboowner_RequestOPChangePage.Text <> CreatorFullName Then

'                'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
'                SendEmail_ToBoth_RequestedOpSheetChange()
'                'Calls subroutine- Logged into activity history
'                LogAllFinishedActions()
'                'Calls subroutine to save the comments, if there is none it ignores it
'                SaveCommentsAndOrNotes()
'                'Calls subroutine - saves when item is finished
'                SaveItemIntodb_RequestOPChangePage()
'                sqlconn.Close()
'            End If

'#End Region

'            ClearTextBoxes()
'            ManagerForm.cbostatus_RequestOPChangePage.SelectedIndex = -1
'            ManagerForm.cboowner_RequestOPChangePage.SelectedIndex = -1
'            ManagerForm.cbocategory_RequestOPChangePage.SelectedIndex = -1
'            ManagerForm.lblitemnum_RequestOPChangePage.Text = ""
'        End If

'    End Sub

'    Public Sub SaveItemIntodb_RequestOPChangePage()

'        Using cmdSaveVend As New SqlCommand()
'            cmdSaveVend.Connection = sqlconn
'            With cmdSaveVend
'                sqlconn.Open()
'                .CommandText = "UPDATE ChangeRequest " &
'                    " SET DateModified=@DateModified, " &
'                    " DateAssigned=@DateAssigned, " &
'                    " Status=@Status, " &
'                    " plan_id=@plan_id, " &
'                    " operation=@operation, " &
'                    " category=@category, " &
'                    " ItemOwner=@ItemOwner, " &
'                    " OwnerEmail=@OwnerEmail " &
'                    " WHERE EcrConfNum= '" & ManagerForm.lblitemnum_RequestOPChangePage.Text & "';"

'                .CommandType = Data.CommandType.Text

'                With .Parameters
'                    .AddWithValue("@DateModified", Now)
'                    .AddWithValue("@DateAssigned", Now)
'                    .AddWithValue("@Status", ManagerForm.cbostatus_RequestOPChangePage.Text)
'                    .AddWithValue("@plan_id", ManagerForm.txtplanid_RequestOPChangePage.Text)
'                    .AddWithValue("@operation", ManagerForm.txtop_RequestOPChangePage.Text)
'                    .AddWithValue("@category", ManagerForm.cbocategory_RequestOPChangePage.Text)
'                    .AddWithValue("@ItemOwner", ManagerForm.cboowner_RequestOPChangePage.Text)
'                    .AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)
'                End With

'            End With
'            Try
'                'System.Threading.Thread.Sleep(1000)
'                cmdSaveVend.ExecuteNonQuery()
'                MsgBox("Updated Successfully")
'                Clearfields()
'            Catch ex As SqlException
'                MsgBox("Error cannot save, " & ManagerForm.lblitemnum_RequestOPChangePage.Text & " " & ex.Message, MsgBoxStyle.Information)
'            End Try
'            sqlconn.Close()
'        End Using
'    End Sub

'    Public Sub SaveItemIntoDbFinished_RequestOpSheetChange()

'        Using cmdSaveVend As New SqlCommand()
'            cmdSaveVend.Connection = sqlconn
'            With cmdSaveVend
'                sqlconn.Open()

'                .CommandText = "UPDATE ChangeRequest " &
'                        " SET DateModified=@DateModified, " &
'                        " date_finished=@date_finished, " &
'                        " plan_id=@plan_id, " &
'                        " operation=@operation, " &
'                        " category=@category, " &
'                        " Status=@Status, " &
'                        " ItemOwner=@ItemOwner, " &
'                        " OwnerEmail=@OwnerEmail " &
'                        " WHERE EcrConfNum= '" & ManagerForm.lblitemnum_RequestOPChangePage.Text & "';"

'                .CommandType = Data.CommandType.Text
'                With .Parameters
'                    .AddWithValue("@DateModified", Now)
'                    .AddWithValue("@date_finished", Now)
'                    .AddWithValue("@plan_id", ManagerForm.txtplanid_RequestOPChangePage.Text)
'                    .AddWithValue("@operation", ManagerForm.txtop_RequestOPChangePage.Text)
'                    .AddWithValue("@category", ManagerForm.cbocategory_RequestOPChangePage.Text)
'                    .AddWithValue("@Status", ManagerForm.cbostatus_RequestOPChangePage.Text)
'                    .AddWithValue("@ItemOwner", ManagerForm.cboowner_RequestOPChangePage.Text)
'                    .AddWithValue("@OwnerEmail", ManagerForm.lblowners_email.Text)
'                End With

'            End With
'            Try
'                'System.Threading.Thread.Sleep(1000)
'                cmdSaveVend.ExecuteNonQuery()
'                MsgBox("Updated Successfully")
'                Clearfields()
'            Catch ex As SqlException
'                MsgBox("Error cannot update after finishing request for OP Sheet Change, " & ex.Message, MsgBoxStyle.Information)
'            End Try
'            sqlconn.Close()
'        End Using

'    End Sub

'    Public Sub AddCommentsOpSheetChangeRequestPage()

'        Dim sqlda As New SqlDataAdapter
'        Dim mydatatable As New DataTable

'        'Checks for the connection
'        If sqlconn.State = ConnectionState.Open Then
'            'MsgBox("Logging out at: " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:sstt "))
'            sqlconn.Close()
'        ElseIf sqlconn.State = ConnectionState.Closed Then
'        End If

'        sqlda.SelectCommand = sqlcmd
'        sqlda.Fill(mydatatable)
'        'Calls subroutine to save the comments, if there is none it ignores it
'        SaveCommentsAndOrNotes()
'        'Calls subroutine - Sends the assigned user and the Creator an email, once edited by an Engineer
'        SendEmail_RequestorCommentResponse()
'        'Calls subroutine- Logged into activity history
'        LogAllFinishedActions()
'        Clearfields()

'        sqlconn.Close()

'    End Sub

'#End Region

'#Region "WRITE COMMENTS AND SAVES HISTORY"

'    Public Sub SaveCommentsAndOrNotes()

'        If ManagerForm.GroupBox_EditOpShChanges.Visible = True Then

'            If ManagerForm.txtnotes_RequestOPChangePage.Text = "" Then
'                ' MessageBox.Show("There are no comments in the Text box")

'            ElseIf ManagerForm.txtnotes_RequestOPChangePage.Text <> "" Then
'                'writeNewCommentsActionItems()
'                WriteAllCommentsNotes()
'            End If

'        ElseIf ManagerForm.GroupBox_EditItems.Visible = True Then

'            If ManagerForm.txtCommentsECRItemsPage.Text = "" Then
'                'MessageBox.Show("There are no comments in the Text box")
'            ElseIf ManagerForm.txtCommentsECRItemsPage.Text.Trim.Length > 0 Then
'                'writeNewCommentsActionItems()
'                WriteAllCommentsNotes()
'            End If

'        ElseIf ManagerForm.GroupBox_ViewOnlyRequestOp.Visible = True Then

'            If ManagerForm.txtaddcomments_viewoppage.Text = "" Then
'                'MessageBox.Show("There are no comments in the Text box")
'            ElseIf ManagerForm.txtaddcomments_viewoppage.Text.Trim.Length > 0 Then
'                'writeNewCommentsActionItems()
'                WriteAllCommentsNotes()
'            End If
'        End If

'    End Sub

'    Public Sub WriteAllCommentsNotes()

'        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text

'        Dim sqlstr As String
'        Try
'            sqlstr = "INSERT INTO tblComments " &
'                " (EcrConfNum, " &
'                " date, " &
'                " comments) " &
'                " VALUES (@EcrConfNum," &
'                " @date," &
'                " @comments); " &
'                " SELECT MAX(ID) AS LASTID FROM tblComments"

'            'Dim comments As String

'            If ManagerForm.GroupBox_EditItems.Visible = True Then

'                'comments = ManagerForm.txtcomments_edit.Text
'                Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                    With sqlcmd
'                        sqlconn.Open()
'                        With .Parameters
'                            .AddWithValue("@EcrConfNum", ManagerForm.lblECRNumEditPage.Text)
'                            .AddWithValue("@date", Now)
'                            .AddWithValue("@comments", (currentLoggedInUser + " commented: " + ManagerForm.txtCommentsECRItemsPage.Text))
'                        End With
'                        .ExecuteNonQuery()

'                    End With
'                End Using

'            ElseIf ManagerForm.GroupBox_EditOpShChanges.Visible = True Then

'                'comments = ManagerForm.txtnotes_RequestOPChangePage.Text
'                Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                    With sqlcmd
'                        sqlconn.Open()
'                        With .Parameters
'                            .AddWithValue("@EcrConfNum", ManagerForm.lblitemnum_RequestOPChangePage.Text)
'                            .AddWithValue("@date", Now)
'                            .AddWithValue("@comments", (currentLoggedInUser + " commented: " + ManagerForm.txtnotes_RequestOPChangePage.Text))
'                        End With
'                        .ExecuteNonQuery()
'                    End With
'                End Using

'            ElseIf ManagerForm.GroupBox_ViewOnlyRequestOp.Visible = True Then

'                'comments = ManagerForm.txtnotes_RequestOPChangePage.Text
'                Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                    With sqlcmd
'                        sqlconn.Open()
'                        With .Parameters
'                            .AddWithValue("@EcrConfNum", ManagerForm.lblitemnum_viewopsheetchange.Text)
'                            .AddWithValue("@date", Now)
'                            .AddWithValue("@comments", (currentLoggedInUser + " commented: " + ManagerForm.txtaddcomments_viewoppage.Text))
'                        End With
'                        .ExecuteNonQuery()
'                    End With
'                End Using
'            End If

'            sqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Cannot insert comments: " & ex.Message)
'        End Try

'    End Sub

'    Public Sub InsertCommentsNewECRPage()

'        Dim sqlstr As String
'        Try
'            If sqlconn.State = ConnectionState.Closed Then
'                newsqlconn.Open()
'            ElseIf sqlconn.State = ConnectionState.Open Then
'            End If
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
'                    'sqlconn.Open()
'                    With .Parameters
'                        .AddWithValue("@EcrConfNum", ManagerForm.lblECRNumNewECRPage.Text)
'                        .AddWithValue("@DateCreated", Now)
'                        .AddWithValue("@Description", ManagerForm.txtAddCommentsNewECRPage.Text)
'                    End With
'                    .ExecuteNonQuery()
'                End With
'            End Using

'            newsqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Cannot insert new comments (InsertCommentsNewECRPage): " & ex.Message)
'        End Try

'    End Sub


'    Public Sub WriteNewComments_ActionItemsEditPage()
'        Dim sqlstr As String
'        Dim ecrConfirmNumb As String = ManagerForm.lblECRNumEditPage.Text
'        Dim commentsECRItemsPage As String = ManagerForm.txtCommentsECRItemsPage.Text
'        Dim ownerFullName As String = ManagerForm.cboAssignedToECRItemsPage.Text
'        Dim creatorFullName As String = ManagerForm.lblUserFullNameMainForm.Text
'        Dim currentLoggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text

'        If commentsECRItemsPage = "" Then
'            'MsgBox("This works")
'        ElseIf commentsECRItemsPage <> "" Then

'            If ownerFullName <> currentLoggedInUser Then
'                Try
'                    sqlstr = "INSERT INTO tblComments " &
'                        "( EcrConfNum, " &
'                        " DateCreated, " &
'                        " Description) " &
'                        " VALUES (@EcrConfNum," &
'                        " @DateCreated," &
'                        " @Description); " &
'                        " SELECT MAX(ID) AS LASTID FROM tblComments"
'                    Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
'                        With sqlcmd
'                            newsqlconn.Open()
'                            .Parameters.AddWithValue("@EcrConfNum", ecrConfirmNumb)
'                            .Parameters.AddWithValue("@DateCreated", Now)
'                            .Parameters.AddWithValue("@Description", (currentLoggedInUser + " commented: " + commentsECRItemsPage))
'                            .ExecuteNonQuery()
'                        End With
'                        newsqlconn.Close()

'                    End Using
'                Catch ex As Exception
'                    MessageBox.Show("Cannot insert comments: (first if) - " & ex.Message)
'                End Try

'            Else

'                Try
'                    sqlstr = "INSERT INTO tblComments " &
'                    " (EcrConfNum, " &
'                    " DateCreated, " &
'                    " Description) " &
'                    " VALUES (@EcrConfNum," &
'                    " @DateCreated," &
'                    " @Description); " &
'                    " SELECT MAX(ID) AS LASTID FROM tblComments"
'                    Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
'                        With sqlcmd
'                            newsqlconn.Open()
'                            .Parameters.AddWithValue("@EcrConfNum", ecrConfirmNumb)
'                            .Parameters.AddWithValue("@DateCreated", Now)
'                            .Parameters.AddWithValue("@Description", commentsECRItemsPage)
'                            .ExecuteNonQuery()
'                        End With
'                        newsqlconn.Close()

'                    End Using
'                Catch ex As Exception
'                    MessageBox.Show("Cannot insert comments: (seocnd if) - " & ex.Message)
'                End Try

'            End If

'        End If

'    End Sub

'    Public Sub WriteNewComments_RequestOPChangePage()
'        Dim sqlstr As String

'        If ManagerForm.txtnotes_RequestOPChangePage.Text = "" Then
'            'MsgBox("This works")
'        ElseIf ManagerForm.txtnotes_RequestOPChangePage.Text <> "" Then

'            Try
'                sqlstr = "INSERT INTO tblComments " &
'                    " (EcrConfNum, " &
'                    " DateCreated, " &
'                    " Description) " &
'                    " VALUES (@EcrConfNum," &
'                    " @DateCreated," &
'                    " @Description); " &
'                    " SELECT MAX(ID) AS LASTID FROM tblComments"
'                Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                    With sqlcmd
'                        sqlconn.Open()
'                        .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblitemnum_RequestOPChangePage.Text)
'                        .Parameters.AddWithValue("@DateCreated", Now)
'                        .Parameters.AddWithValue("@Description", ManagerForm.txtnotes_RequestOPChangePage.Text)
'                        .ExecuteNonQuery()
'                    End With
'                    sqlconn.Close()

'                End Using
'            Catch ex As Exception
'                MessageBox.Show("Cannot insert comments: " & ex.Message)
'            End Try
'        End If

'    End Sub

'    Public Sub WriteNewDescription_RequestOPChangePage()
'        Dim sqlstr As String
'        Try
'            sqlstr = "INSERT INTO tblComments " &
'                " (EcrConfNum, " &
'                " DateCreated, " &
'                " Description) " &
'                " VALUES (@EcrConfNum," &
'                " @DateCreated," &
'                " @description); " &
'                " SELECT MAX(ID) AS LASTID FROM tblComments"
'            Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                With sqlcmd
'                    sqlconn.Open()
'                    .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblrequestnum_newrequestpage.Text)
'                    .Parameters.AddWithValue("@date", Now)
'                    .Parameters.AddWithValue("@Description", ManagerForm.txtdesc_reqchge.Text)
'                    .ExecuteNonQuery()
'                End With

'            End Using
'            sqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Cannot insert: " & ex.Message)
'        End Try
'    End Sub

'    Public Sub WriteNotes_RequestOpSheetChangePage()
'        Dim sqlstr As String

'        If ManagerForm.txtCommentsECRItemsPage.Text = "" Then
'            'MsgBox("This works")
'        ElseIf ManagerForm.txtCommentsECRItemsPage.Text <> "" Then

'            Try
'                sqlstr = "INSERT INTO tblComments " &
'                    " (EcrConfNum, " &
'                    " DateCreated, " &
'                    " Description) " &
'                    " VALUES (@EcrConfNum," &
'                    " @DateCreated," &
'                    " @Description); " &
'                    " SELECT MAX(ID) AS LASTID FROM tblComments"
'                Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                    With sqlcmd
'                        sqlconn.Open()
'                        .Parameters.AddWithValue("@EcrConfNum", ManagerForm.lblECRNumEditPage.Text)
'                        .Parameters.AddWithValue("@DateCreated", Now)
'                        .Parameters.AddWithValue("@Description", ManagerForm.txtCommentsECRItemsPage.Text)
'                        .ExecuteNonQuery()
'                    End With
'                    sqlconn.Close()

'                End Using
'            Catch ex As Exception
'                MessageBox.Show("Cannot insert comments: " & ex.Message)
'            End Try
'        End If

'    End Sub
'#End Region

'#Region "INCREMENTS THE ECR ITEM NUMBER"
'    Public Sub GetGetActionItemNumber()
'        Try
'            Dim sqlstr As String
'            Dim txtEcrConfirmationNum As String
'            Dim sqlda As New SqlDataAdapter
'            Dim ds As New DataSet

'            sqlstr = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECR_Number FROM tblauto WHERE ID = 1"
'            sqlda = New SqlDataAdapter(sqlstr, sqlconn)
'            'sqlconn.Open()
'            sqlda.Fill(ds, "ucrms")
'            txtEcrConfirmationNum = ds.Tables("ucrms").Rows(0).Item(2)
'            ManagerForm.lblECRNumNewECRPage.Text = txtEcrConfirmationNum
'            'MsgBox(txtmsgnew)

'            Dim iReturn As Boolean
'            Using cmdupdate As New SqlCommand()
'                cmdupdate.Connection = sqlconn
'                With cmdupdate
'                    If sqlconn.State = ConnectionState.Open Then
'                    ElseIf sqlconn.State = ConnectionState.Closed Then
'                        sqlconn.Open()
'                    End If

'                    .CommandText = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 1"
'                    .CommandType = Data.CommandType.Text

'                End With
'                Try
'                    cmdupdate.ExecuteNonQuery()
'                    iReturn = True
'                Catch ex As SqlException
'                    MsgBox(ex.Message, MsgBoxStyle.Information)
'                    iReturn = False
'                End Try
'                'sqlconn.Close()
'            End Using

'        Catch ex As Exception
'            MsgBox("Cannot load Item Confirmation #, Please contact the Administrator")
'        End Try
'        sqlconn.Close()
'    End Sub
'#End Region

'#Region "INCREMENTS THE REQUEST OP SHEET CHANGE ITEMS"
'    Public Sub GetRequestOpSheetChangeItemNum()
'        Try
'            Dim sqlstr As String
'            Dim reqItemNumber As String
'            Dim sqlda As New SqlDataAdapter
'            Dim ds As New DataSet

'            sqlstr = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECR_Number FROM tblauto WHERE ID = 2"
'            sqlda = New SqlDataAdapter(sqlstr, sqlconn)
'            'sqlconn.Open()
'            sqlda.Fill(ds, "ucrms")
'            reqItemNumber = ds.Tables("ucrms").Rows(0).Item(2)
'            ManagerForm.lblrequestnum_newrequestpage.Text = reqItemNumber
'            'MsgBox(txtmsgnew)

'            Dim iReturn As Boolean
'            Using cmdupdate As New SqlCommand()
'                cmdupdate.Connection = sqlconn
'                With cmdupdate
'                    If sqlconn.State = ConnectionState.Open Then
'                    ElseIf sqlconn.State = ConnectionState.Closed Then
'                        sqlconn.Open()
'                    End If

'                    .CommandText = "UPDATE tblauto SET autoend = autoend + incrementvalue WHERE id = 2"
'                    .CommandType = Data.CommandType.Text

'                End With
'                Try
'                    cmdupdate.ExecuteNonQuery()
'                    iReturn = True
'                Catch ex As SqlException
'                    MsgBox(ex.Message, MsgBoxStyle.Information)
'                    iReturn = False
'                End Try
'                'sqlconn.Close()
'            End Using

'        Catch ex As Exception
'            MsgBox("Cannot load Item Confirmation #, Please contact the Administrator")
'        End Try
'        sqlconn.Close()
'    End Sub

'#End Region

'#Region "TESTING PARAMETERS"
'    Public Sub Test()
'        Try
'            Dim reqconf As String
'            Dim sum As String
'            Dim sqlda As New SqlDataAdapter
'            Dim mysqlds As New DataSet

'            reqconf = "SELECT emplid, ID FROM useraccounts WHERE emplid = '" & Login.lblempid.Text & "'; "
'            sqlda = New SqlDataAdapter(reqconf, sqlconn)
'            sqlda.Fill(mysqlds, "ucrms")
'            sum = mysqlds.Tables("ucrms").Rows(0).Item(1)
'            MsgBox(Login.lblempid.Text)

'        Catch ex As Exception
'            MsgBox("Cannot load, Please contact the Administrator")
'        End Try
'        sqlconn.Close()
'    End Sub

'    Public Sub RUNTHIS()
'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter
'        Dim myReader As SqlDataReader

'        Try
'            If sqlconn.State = ConnectionState.Open Then
'                'Do Nothing
'            ElseIf sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()

'            End If

'            sqlquery = "SELECT * FROM (SELECT id as ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype as Type FROM useraccounts) base " &
'                " WHERE FullName = '" & ManagerForm.lblUserFullNameMainForm.Text & "' "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            myReader = sqlcmd.ExecuteReader

'            While myReader.Read
'                MsgBox("Can you see this? " & ManagerForm.lblUserTypeMainForm.Text)
'                ManagerForm.fullnamelbl.Text = myReader.GetString("FullName")
'                ManagerForm.lblDBIDMainForm.Text = myReader.GetInt32("ID")
'                ManagerForm.lblUserTypeMainForm.Text = myReader.GetString("Type")
'            End While

'            sqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Error checking user: " & ex.Message)
'        End Try

'        With ManagerForm
'            If .lblUserTypeMainForm.Text = "Administrator" Then
'                .MainMenu_btnReports.Visible = True
'            Else
'                .MainMenu_btnReports.Visible = False
'            End If
'        End With

'    End Sub

'    Public Sub RefreshData()
'        table.Clear()
'        sqlda.Fill(table)

'    End Sub

'    Public Sub TestSendEmailToMoreThanOne()

'        If sqlconn.State = ConnectionState.Closed Then
'            sqlconn.Open()
'        ElseIf sqlconn.State = ConnectionState.Open Then
'        End If

'        Dim Smtp_Server As New SmtpClient
'        Dim theEmail As New MailMessage()
'        Smtp_Server.UseDefaultCredentials = False
'        Smtp_Server.Port = 25
'        Smtp_Server.EnableSsl = False
'        Smtp_Server.Host = "ushers-apps-02.umt.local"

'        'Dim theMailMessages As New MailMessage
'        'theMailMessages.To.Add("your_email_address") '-- after this the collection has one.
'        'theMailMessages.To.Clear()  '-- after this the collection is empty.

'        Dim listofEmailAddresses As New List(Of MailAddress)
'        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblcreators_email.Text))
'        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblowners_email.Text))

'        For Each tempEmails As MailAddress In listofEmailAddresses
'            theEmail.From = New MailAddress("relay@ushersm.com")
'            'theEmail = New MailMessage
'            theEmail.To.Add(tempEmails)
'            theEmail.Subject = "ECR Item: " & ManagerForm.lblECRNumEditPage.Text & " is finished"
'            'theEmail.Body = generateBody()
'            theEmail.IsBodyHtml = False
'            theEmail.Body = "Do not reply to this email." +
'                Environment.NewLine + " Status: " & ManagerForm.cboStatusECRItemsPage.Text & "" +
'                Environment.NewLine + " Created by: " & ManagerForm.lblCreatorECREditPage.Text & "" +
'                Environment.NewLine + " Assigned to: " & ManagerForm.lblownerfullname.Text & "" +
'                Environment.NewLine + " Date Created: " & ManagerForm.lbldatestampin_editactionitempage.Text & "" +
'                Environment.NewLine + " Date Assigned: " & Now & "" +
'                Environment.NewLine + " Reference Doc: " & ManagerForm.txtRefDocECRItemsPage.Text & "" +
'                Environment.NewLine + " Description: " & ManagerForm.txtCommentsECRItemsPage.Text & "" +
'                Environment.NewLine + " "
'            Smtp_Server.Send(theEmail)
'            theEmail.To.Clear()
'            '-- send email

'        Next
'    End Sub

'    Public Sub GenerateBody()

'    End Sub

'#End Region

'#Region "MANAGE ACCOUNTS"
'    Public Sub LogInAdminMainForm()
'        ManagerForm.Show()
'    End Sub


'    Public Sub CheckAccounts()

'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter
'        Dim myReader As SqlDataReader

'        Try
'            If sqlconn.State = ConnectionState.Open Then
'                'Do Nothing
'            ElseIf sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            End If

'            sqlquery = "SELECT * FROM (SELECT id, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype FROM useraccounts) base " &
'                " WHERE FullName = '" & ManagerForm.lblUserFullNameMainForm.Text & "' "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            myReader = sqlcmd.ExecuteReader

'            If myReader.HasRows Then
'                'Do nothing

'            Else
'                MessageBox.Show("Looks like this is your first time logging into the system.")
'                myReader.Close() 'Has to close the Data Reader first before writing to the database

'                'Proceed to create a new user into the database
'                Dim sqlstr As String
'                Try
'                    sqlstr = "INSERT INTO useraccounts " &
'                        " (firstname, lastname, useremail, usertype, emplid) " &
'                        " VALUES (@firstname, @lastname, @useremail, @usertype, @emplid); " &
'                        " SELECT LAST_INSERT_ID()"
'                    Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                        With sqlcmd
'                            If sqlconn.State = ConnectionState.Open Then
'                                'Do Nothing
'                            ElseIf sqlconn.State = ConnectionState.Closed Then
'                                sqlconn.Open()
'                            End If
'                            .Parameters.AddWithValue("@firstname", ManagerForm.firstnametxt.Text)
'                            .Parameters.AddWithValue("@lastname", ManagerForm.lastnametxt.Text)
'                            .Parameters.AddWithValue("@useremail", ManagerForm.lblUserEmailMainForm.Text)
'                            .Parameters.AddWithValue("@usertype", "New")
'                            .Parameters.AddWithValue("@emplid", ManagerForm.lblEmployeeIDMainForm.Text)
'                            .ExecuteNonQuery()
'                        End With

'                    End Using
'                    sqlconn.Close()
'                Catch ex As Exception
'                    MessageBox.Show("Cannot add new user: " & ex.Message)
'                End Try

'            End If

'            sqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Error checking user: " & ex.Message)
'        End Try
'    End Sub

'    Public Sub CreateNewUserAccount()
'        Dim userAccountName As String = UserAccounts.cboUserTypeManageAccounts.Text
'        Dim userDBID As String = UserAccounts.lblIDManageAccounts.Text
'        Dim userType As String = UserAccounts.cboUserTypeManageAccounts.Text
'        Dim userName As String = UserAccounts.txtUserNameManageAccounts.Text
'        Dim firstName As String = UserAccounts.txtFirstNameManageAccounts.Text
'        Dim lastName As String = UserAccounts.txtLastNameManageAccounts.Text
'        Dim eMail As String = UserAccounts.txtUserEmailManageAccounts.Text
'        If newsqlconn.State = ConnectionState.Closed Then
'            newsqlconn.Open()
'            MsgBox("Connection was closed but is now opened")
'        ElseIf newsqlconn.State = ConnectionState.Open Then
'            MsgBox("Connection IS Opened")
'        End If
'        Try

'            If userAccountName = "" Then
'                MsgBox("Please choose a user type.")
'            Else
'                'Dim result As DialogResult = MessageBox.Show("A new user account or change will be made.", "Warning", MessageBoxButtons.YesNo)
'                'If result = DialogResult.Yes Then

'                'End If
'                Using (newsqlconn)
'                    Dim sqlcmd As New SqlCommand()
'                    With sqlcmd
'                        .Connection = newsqlconn
'                        .CommandText = "sp_InsertNewUSerAccount"
'                        .CommandType = CommandType.StoredProcedure
'                        .Parameters.AddWithValue("@username", userName)
'                        .Parameters.AddWithValue("@lastname", lastName)
'                        .Parameters.AddWithValue("@firstname", firstName)
'                        .Parameters.AddWithValue("@usertype", userType)
'                        .ExecuteNonQuery()
'                    End With
'                End Using
'                MsgBox("User account updated Successfully")
'            End If

'        Catch ex As SqlException
'            MsgBox(ex.Message, MsgBoxStyle.Information)
'            'iReturn = False
'        End Try

'        If newsqlconn.State = ConnectionState.Closed Then
'            'newsqlconn.Open()
'            MsgBox("Connection is closed already")
'        ElseIf newsqlconn.State = ConnectionState.Open Then
'            newsqlconn.Close()
'            MsgBox("Closing the connection")
'        End If


'        'UserAccountsLoad()
'    End Sub

'    Public Sub UserAccountsLoad()
'        If newsqlconn.State = ConnectionState.Closed Then
'            'newsqlconn = New SqlConnection
'            newsqlconn.Open()
'            MsgBox("Connection Was closed but is now Opened")
'        ElseIf newsqlconn.State = ConnectionState.Open Then
'            MsgBox("Connection Was Opened Already")
'        End If

'        Try
'            Dim SQLDataTable As New DataTable
'            Dim BindingSourceUserAccts As New BindingSource
'            'Dim newsqlconn As New SqlConnection


'            sqlquery = "SELECT * FROM useraccounts"

'            sqlcmd = New SqlCommand(sqlquery, newsqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(SQLDataTable)
'            BindingSourceUserAccts.DataSource = SQLDataTable
'            sqlda.Update(SQLDataTable)

'            With UserAccounts
'                .DataGridView2.DataSource = BindingSourceUserAccts
'                .DataGridView2.AutoResizeColumns()
'                .cboUserTypeManageAccounts.ResetText()
'                With .DataGridView2
'                    'newsqlconn.open()
'                    .AutoGenerateColumns = True
'                    .Columns(1).HeaderCell.Value = "Username"
'                    .Columns(2).HeaderCell.Value = "Last Name"
'                    .Columns(3).HeaderCell.Value = "First Name"
'                    .Columns(4).HeaderCell.Value = "Account Type"
'                    .Columns(5).HeaderCell.Value = "E-Mail"
'                    .Columns("ID").Visible = False
'                    .Columns("userpassword").Visible = False
'                    .Columns("emplid").Visible = False
'                    .Columns("contact").Visible = False
'                    .Columns("other").Visible = False
'                    .Columns("notes").Visible = False
'                    .Columns("manager").Visible = False
'                End With
'            End With
'        Catch ex As Exception
'            MessageBox.Show("Error loading unto form: (UserAccountsLoad) - " & ex.Message)
'        End Try
'        newsqlconn.close()
'    End Sub

'    Public Sub CheckUsertypeAccounts()
'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter
'        Dim Reader As SqlDataReader

'        Try
'            If sqlconn.State = ConnectionState.Open Then
'                'Do Nothing
'            ElseIf sqlconn.State = ConnectionState.Closed Then
'                sqlconn.Open()
'            End If

'            sqlquery = "SELECT * FROM (SELECT id as ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype as Type FROM useraccounts) base " &
'                " WHERE FullName = '" & ManagerForm.lblUserFullNameMainForm.Text & "' "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            Reader = sqlcmd.ExecuteReader
'            ' Reader = sqlquery.ExecuteReader()
'            While Reader.Read
'                ManagerForm.lblUserFullNameMainForm.Text = Reader.GetString(3)
'                ManagerForm.lblDBIDMainForm.Text = Reader.GetInt32(0)
'                ManagerForm.lblUserTypeMainForm.Text = Reader.GetString(5)

'            End While

'            sqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Error checking user: " & ex.Message)
'        End Try

'        With ManagerForm
'            If .lblUserTypeMainForm.Text = "Administrator" Or .lblUserTypeMainForm.Text = "Manager" Then
'                .MainMenu_btnECR.Visible = True
'                .MainMenu_btnMyECR.Visible = True
'                .MainMenu_btnLog.Visible = True
'                .MainMenu_btnSettings.Visible = True
'                .MainMenu_btnReports.Visible = True
'                .MainMenu_btnLogout.Visible = True
'                .MainMenu_btnSettingsUserAdministration.Visible = True
'            ElseIf .lblUserTypeMainForm.Text = "Engineer" Then
'                .MainMenu_btnECR.Visible = True
'                .MainMenu_btnLog.Visible = True
'                .MainMenu_btnSettings.Visible = True
'                .MainMenu_btnSettingsAdvancedSearch.Visible = False
'                .MainMenu_btnSettingsUserAdministration.Visible = False
'                .MainMenu_btnSettingsAbout.Visible = True
'                .MainMenu_btnReports.Visible = True
'                .MainMenu_btnLogout.Visible = True
'            ElseIf .lblUserTypeMainForm.Text = "Quality Engineer" Or .lblUserTypeMainForm.Text = "Quality Tech" Then
'                .MainMenu_btnECR.Visible = True
'                .MainMenu_btnMyECR.Visible = True
'                .MainMenu_btnMyECRMyRequests.Visible = True
'                .MainMenu_btnLog.Visible = True
'                .MainMenu_btnReports.Visible = True
'                .MainMenu_btnLogout.Visible = True
'            ElseIf .lblUserTypeMainForm.Text = "Users" Then
'                .MainMenu_btnECR.Visible = False
'                .MainMenu_btnMyECR.Visible = True
'                .MainMenu_btnMyECRMyRequests.Visible = True
'                .MainMenu_btnMyECRMyRequests.Visible = True
'                .MainMenu_btnMyECRFinishedRequests.Visible = True
'                .MainMenu_btnSettings.Visible = True
'                .MainMenu_btnSettingsAdvancedSearch.Visible = False
'                .MainMenu_btnSettingsUserAdministration.Visible = False
'                .MainMenu_btnSettingsAbout.Visible = True
'                .MainMenu_btnReports.Visible = False
'                .MainMenu_btnLog.Visible = False
'                .MainMenu_btnLogout.Visible = True
'            Else
'            End If
'        End With

'    End Sub

'    Public Sub CheckEngineers()

'        If sqlconn.State = ConnectionState.Closed Then
'            sqlconn.Open()
'        ElseIf sqlconn.State = ConnectionState.Open Then
'        End If

'        Dim Smtp_Server As New SmtpClient
'        Dim theEmail As New MailMessage()
'        Smtp_Server.UseDefaultCredentials = False
'        Smtp_Server.Port = 25
'        Smtp_Server.EnableSsl = False
'        Smtp_Server.Host = "ushers-apps-02.umt.local"

'        Dim sqldatatable As New DataTable
'        Dim sqladapter As New SqlDataAdapter

'        If sqlconn.State = ConnectionState.Open Then
'            ' sqlconn.Close()
'        ElseIf sqlconn.State = ConnectionState.Closed Then
'            sqlconn.Open()
'        End If

'        Using sqlconn
'            Dim command As SqlCommand = New SqlCommand("SELECT id, useremail, usertype FROM ucrms.useraccounts WHERE usertype = 'Administrator';", sqlconn)
'            Dim reader As SqlDataReader = command.ExecuteReader()

'            If reader.HasRows Then
'                Do While reader.Read()
'                    'MessageBox.Show(reader.GetInt32(0) & vbTab & reader.GetString(1))
'                    Dim emailAddresses As String = reader.GetString(1)
'                    theEmail.From = New MailAddress("relay@ushersm.com")
'                    theEmail.To.Add(emailAddresses)
'                    theEmail.Subject = "New Request Number: " & ManagerForm.lblitemnum_RequestOPChangePage.Text & " . "
'                    theEmail.IsBodyHtml = False
'                    theEmail.Body = "Do not reply to this email." +
'                            Environment.NewLine + " Status: New " +
'                            Environment.NewLine + " Created by: " & ManagerForm.lblUserFullNameMainForm.Text & "" +
'                            Environment.NewLine + " " +
'                            Environment.NewLine + " Date Created: " & ManagerForm.lbldatestampin_RequestOPChangePage.Text & "" +
'                            Environment.NewLine + " Plan ID: " & ManagerForm.txtplanid_reqchge.Text & "" +
'                            Environment.NewLine + " Operation: " & ManagerForm.txtop_reqchge.Text & "" +
'                            Environment.NewLine + " Issue Type: " & ManagerForm.cboissue_type.Text & "" +
'                            Environment.NewLine + " Notes: " & ManagerForm.txtdesc_reqchge.Text & "" +
'                            Environment.NewLine + " "
'                    Smtp_Server.Send(theEmail)
'                    theEmail.To.Clear()
'                Loop
'            Else
'                MessageBox.Show("No rows found.")
'            End If

'            reader.Close()
'        End Using
'        sqlconn.Close()

'    End Sub

'#End Region

'#Region "VIEW LOG"
'    Public Sub ViewLog()
'        'for log file
'        'Dim uname As String =frmlogin.lbluname.text

'        Try
'            Dim mydt As New DataTable
'            Dim bindingsource_logs As New BindingSource


'            sqlquery = "SELECT * FROM LogFiles ORDER BY id desc "

'            sqlcmd = New SqlCommand(sqlquery, sqlconn)
'            sqlda.SelectCommand = sqlcmd
'            sqlda.Fill(mydt)
'            bindingsource_logs.DataSource = mydt
'            ManagerForm.DataGridView4.DataSource = bindingsource_logs
'            sqlda.Update(mydt)
'            With ManagerForm.DataGridView4
'                If sqlconn.State = ConnectionState.Open Then
'                    'Do Nothing
'                ElseIf sqlconn.State = ConnectionState.Closed Then
'                    sqlconn.Open()
'                End If
'                .AutoGenerateColumns = True
'                .Columns("id").Visible = False
'                .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
'                '.Font = New Font(.Font, FontStyle.Regular)
'                '.ForeColor = Color.Black
'                '.Columns("uname").HeaderText = "Name"
'                '.Columns("Name").Width = 100
'                '.Columns("EcrConfNum_activity").HeaderText = "Item Number"
'                '.Columns("Item Number").Width = 100
'                '.Columns("activity").HeaderText = "Activity"
'                '.Columns("activitydate").HeaderText = "Time and date the activity was done"


'            End With
'            sqlconn.Close()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
'        End Try

'    End Sub

'#End Region

'#Region "LOGGING"
'    Public Sub LogActivitiesNewECRCreated()
'        Try
'            If newsqlconn.State = ConnectionState.Closed Then
'                newsqlconn.Open()
'            ElseIf newsqlconn.State = ConnectionState.Open Then
'            End If

'            Dim UserFullNameLog As String = ManagerForm.lblUserFullNameMainForm.Text
'            Dim ActivityLog As String = UserFullNameLog + " created a new ECR item"
'            Dim ActivitydateLog As String = Now
'            Dim EcrConfNumLog As String = ManagerForm.lblECRNumNewECRPage.Text

'            Dim sqlstr As String

'            sqlstr = "INSERT INTO LogFiles (UserFullName, EcrConfNumLog, UserActivity, ActivityDate) " &
'                    " VALUES (@UserFullName, @EcrConfNumLog, @UserActivity, @ActivityDate); " &
'                    " SELECT MAX(ID) AS LASTID FROM LogFiles"

'            Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)

'                With sqlcmd
'                    .Parameters.AddWithValue("@UserFullName", UserFullNameLog)
'                    .Parameters.AddWithValue("@EcrConfNumLog", EcrConfNumLog)
'                    .Parameters.AddWithValue("@UserActivity", ActivityLog)
'                    .Parameters.AddWithValue("@ActivityDate", ActivitydateLog)
'                    .ExecuteNonQuery()
'                End With

'            End Using
'            newsqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Cannot log - LogActivitiesNewECRCreated: " & ex.Message)
'        End Try

'    End Sub

'    Public Sub LogNewRequestedOPSheetChanges()

'        Dim unamelog As String = ManagerForm.lblUserFullNameMainForm.Text
'        Dim activity As String = unamelog + " requested an OP Sheet Change"
'        Dim activitydate As String = ManagerForm.lblTimeMainForm.Text + " " + ManagerForm.lblDateMainForm.Text
'        Dim itemnum As String = ManagerForm.lblrequestnum_newrequestpage.Text
'        Dim sqlstr As String

'        Try
'            sqlstr = "INSERT INTO LogFiles (uname, EcrConfNum_activity, activity, activitydate) " &
'                " VALUES (@uname, @EcrConfNum_activity, @activity, @activitydate); " &
'                " SELECT MAX(ID) AS LASTID FROM LogFiles"

'            Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                With sqlcmd
'                    sqlconn.Open()
'                    .Parameters.AddWithValue("@uname", unamelog)
'                    .Parameters.AddWithValue("@EcrConfNum_activity", itemnum)
'                    .Parameters.AddWithValue("@activity", activity)
'                    .Parameters.AddWithValue("@activitydate", activitydate)
'                    .ExecuteNonQuery()
'                End With

'            End Using
'            sqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Cannot log - logNewRequestedOPSheetChanges: " & ex.Message)
'        End Try

'    End Sub

'    Public Sub LogActivitiesItemEdited()

'        Dim unamelog As String = ManagerForm.lblUserFullNameMainForm.Text
'        Dim activity As String = unamelog + " has edited item: " + ManagerForm.lblECRNumEditPage.Text
'        Dim activitydate As String = ManagerForm.lblTimeMainForm.Text + " " + ManagerForm.lblDateMainForm.Text
'        Dim itemnum As String = ManagerForm.lblECRNumEditPage.Text

'        Dim sqlstr As String
'        Try
'            sqlstr = "INSERT INTO LogFiles (uname, EcrConfNum_activity, activity, activitydate) " &
'                " VALUES (@uname, @EcrConfNum_activity, @activity, @activitydate); " &
'                " SELECT MAX(ID) AS LASTID FROM LogFiles"

'            Using sqlcmd = New SqlCommand(sqlstr, sqlconn)
'                With sqlcmd
'                    sqlconn.Open()
'                    .Parameters.AddWithValue("@uname", unamelog)
'                    .Parameters.AddWithValue("@EcrConfNum_activity", itemnum)
'                    .Parameters.AddWithValue("@activity", activity)
'                    .Parameters.AddWithValue("@activitydate", activitydate)
'                    .ExecuteNonQuery()
'                End With

'            End Using
'            sqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Cannot log- logActivitiesItemEdited: " & ex.Message)
'        End Try

'    End Sub

'    Public Sub LogAllFinishedActions()

'        Dim sqlstr As String
'        Try
'            sqlstr = "INSERT INTO LogFiles (UserFullName, EcrConfNumLog, UserActivity, ActivityDate) " &
'                " VALUES (@UserFullName, @EcrConfNumLog, @UserActivity, @ActivityDate); " &
'                " SELECT MAX(ID) AS LASTID FROM LogFiles"

'            If ManagerForm.GroupBox_EditItems.Visible = True Then

'                Dim UserFullNameLog As String = ManagerForm.lblUserFullNameMainForm.Text
'                Dim ECRNumLog As String = ManagerForm.lblECRNumEditPage.Text
'                Dim UserActivityLog As String = UserFullNameLog + " updated item: " + ECRNumLog + " to: " + ManagerForm.cboStatusECRItemsPage.Text
'                Dim ActivityDateLog As String = Now
'                Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
'                    With sqlcmd
'                        newsqlconn.Open()
'                        With .Parameters
'                            .AddWithValue("@UserFullName", UserFullNameLog)
'                            .AddWithValue("@EcrConfNumLog", ECRNumLog)
'                            .AddWithValue("@UserActivity", UserActivityLog)
'                            .AddWithValue("@ActivityDate", ActivityDateLog)
'                        End With
'                        .ExecuteNonQuery()
'                    End With
'                End Using

'            ElseIf ManagerForm.GroupBox_EditOpShChanges.Visible = True Then

'                Dim UserFullNameLog As String = ManagerForm.lblUserFullNameMainForm.Text
'                Dim ECRNumLog As String = ManagerForm.lblitemnum_RequestOPChangePage.Text
'                Dim UserActivityLog As String = UserFullNameLog + " updated item: " + ECRNumLog + " to: " + ManagerForm.cbostatus_RequestOPChangePage.Text
'                Dim ActivityDateLog As String = Now
'                Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
'                    With sqlcmd
'                        newsqlconn.Open()
'                        With .Parameters
'                            .AddWithValue("@UserFullName", UserFullNameLog)
'                            .AddWithValue("@EcrConfNumLog", ECRNumLog)
'                            .AddWithValue("@UserActivity", UserActivityLog)
'                            .AddWithValue("@ActivityDate", ActivityDateLog)
'                        End With
'                        .ExecuteNonQuery()
'                    End With
'                End Using


'            ElseIf ManagerForm.GroupBox_ViewOnlyRequestOp.Visible = True Then

'                Dim UserFullNameLog As String = ManagerForm.lblUserFullNameMainForm.Text
'                Dim ECRNumLog As String = ManagerForm.lblitemnum_viewopsheetchange.Text
'                Dim UserActivityLog As String = UserFullNameLog + " responded on: " + ECRNumLog + " to: " + ManagerForm.lblowner__viewopsheetchanges.Text
'                Dim ActivityDateLog As String = Now
'                Using sqlcmd = New SqlCommand(sqlstr, newsqlconn)
'                    With sqlcmd
'                        newsqlconn.Open()
'                        With .Parameters
'                            .AddWithValue("@UserFullName", UserFullNameLog)
'                            .AddWithValue("@EcrConfNumLog", ECRNumLog)
'                            .AddWithValue("@UserActivity", UserActivityLog)
'                            .AddWithValue("@ActivityDate", ActivityDateLog)
'                        End With
'                        .ExecuteNonQuery()
'                    End With
'                End Using
'            End If


'            newsqlconn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Cannot log, error - logActivitiesItemFinished: " & ex.Message)
'        End Try


'    End Sub

'#End Region

'#Region "REPORTING"

'    Public Sub ByOwner()


'    End Sub
'#End Region

'#Region "CLEARS FIELDS"
'    Private Sub Clearfields()

'        ClearTextBoxes()

'        'Dim a As Control
'        'For Each a In ManagerForm.GroupBox3.Controls
'        '    If TypeOf a Is TextBox Then
'        '        a.Text = Nothing
'        '    End If
'        'Next
'    End Sub

'    Public Sub ClearTextBoxes(Optional ByVal ctlcol As Control.ControlCollection = Nothing)
'        If ctlcol Is Nothing Then ctlcol = ManagerForm.Controls
'        For Each ctl As Control In ctlcol
'            If TypeOf (ctl) Is TextBox Then
'                DirectCast(ctl, TextBox).Clear()
'            Else
'                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
'                    ClearTextBoxes(ctl.Controls)
'                End If
'            End If
'        Next
'    End Sub
'#End Region

'End Module
