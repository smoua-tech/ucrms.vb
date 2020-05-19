Imports System.Deployment
Imports System.IO
Imports System.Net.Mail
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports MetroFramework.Forms.MetroForm
Imports System.Deployment.Application
Imports System.Globalization

Public Class ManagerForm
    Inherits MetroFramework.Forms.MetroForm
    Dim StatementSQL As New StatementsSQL()
    Dim publicvariables As New publicvariables
    Public sqlquery As String
    Public sqlcmd As New SqlCommand
    Public SQLAdapter As SqlDataAdapter
    Public mysqldr As SqlDataReader
    Public sqldatatable As DataTable
    Public Event CellMouseEnter As DataGridViewCellEventHandler
    Dim ButtonEmailAndSave As Boolean 'Make sure this is before all subs
    Public Property ImageScalingSize As Size
    'Dim sqlcon As SqlConnection = DBConn()
    'Public sqlconn = New SqlConnection With {
    '        .ConnectionString = "server=umtgv-db-01-dev.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms"
    '    }
    Dim connstring As String = "server=umtgv-db-01-dev.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms"

#Region "MAIN FORM LOADING"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Text = String.Format("{0}", ApplicationTitle)
        lblProdName.Text = My.Application.Info.ProductName
        lblCopyRight.Text = My.Application.Info.Copyright

        If (ApplicationDeployment.IsNetworkDeployed) Then
            With ApplicationDeployment.CurrentDeployment.CurrentVersion
                Me.lblVersionToBeDisplayed.Text = "" & .Major & "." & .Minor & "." & .Build & "." & .Revision
            End With
        End If

        Login.Hide()
        Hidegb()
        'StatementSQL.CheckUsertypeAccounts() 'Checks for account type
        lblUserEmailMainForm.Text = Login.lblemail.Text
        lblEmployeeIDMainForm.Text = Login.lblempid.Text
        lblUserFullNameMainForm.Text = Login.lblfullname.Text

        Dim myStrA As String = lblUserFullNameMainForm.Text
        Dim result As String() = myStrA.Split(New Char(-1) {}, StringSplitOptions.RemoveEmptyEntries)

        firstnametxt.Text = result(0)
        lastnametxt.Text = result(1)

        'StatementSQL.CheckAccounts() 'Checks for existing accounts

        Me.AutoScroll = True
        Me.BringToFront()
        TimerDate.Start()

        Try
            Me.WindowState = FormWindowState.Normal
        Catch ex As Exception
            MsgBox("Could not log in. " & ex.Message, MsgBoxStyle.Information)
        End Try
        'Me.reportViewer_01.RefreshReport

    End Sub
#End Region

#Region "Time, Date and Zone"
    Private Sub TimerDate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDate.Tick
        lblTimeMainForm.Text = TimeOfDay
        lblDateMainForm.Text = Today.Date.ToString("dddd, dd MMMM yyyy")
        lblZoneMainForm.Text = TimeZone.CurrentTimeZone.StandardName

    End Sub
#End Region

#Region "Enable all Buttons"
    Private Sub Enablebtns()
        'btnmenu_viewallrailspage.Enabled = True
        MainMenu_ECRbtn_ViewAll.Enabled = True
        MainMenu_ECRbtn_MyFinished.Enabled = True
        MainMenu_Reportsbtn.Enabled = True
        MainMenu_Logbtn.Enabled = True
        MainMenu_btnSettings.Enabled = True
        MainMenu_Logbtn.Enabled = True
        MainMenu_MyECRbtn_RequestNew.Enabled = True
    End Sub
#End Region

#Region "Hide all GroupBoxes"
    Private Sub Hidegb()

        GroupBoxECRGridView.Hide()
        GroupBoxAddNewECR.Hide()
        GroupBoxViewECRPage.Hide()
        GroupBoxEditECRItems.Hide()
        GroupBoxActivityLog.Hide()
        GroupBoxReports.Hide()
        GroupBox_ActionItemsPage.Hide()
        GroupBoxActionItemsGridView.Hide()
        GroupBox_ViewOnlyRequestOp.Hide()
        GroupBoxActionItemsWorkPage.Hide()

    End Sub
#End Region

#Region "ECR"
    Private Sub MainMenu_btnECRNewEcr_Click(sender As Object, e As EventArgs) Handles MainMenu_ECRbtn_NewEcr.Click
        Enablebtns()
        lblYourECRNumberIS.Visible = False
        lblECRNumNewECRPage.Visible = False

        'btnViewItems.Enabled = False

        'hide group boxes first before showing the single group boxes or else all if it will not work correctly
        Hidegb()
        'Shows the New ECR Form to fill for user
        GroupBoxAddNewECR.Dock = DockStyle.Fill
        GroupBoxAddNewECR.Show()
        ClearItemsfields()

        'Calls a method to load the combo box with the users
        StatementSQL.LoadUsersCbo_AddECRPage()

    End Sub
    Private Sub MainMenu_btnECRViewAllEcr_Click(sender As Object, e As EventArgs) Handles MainMenu_ECRbtn_ViewAll.Click
        Dim newsqlconn As New SqlConnection(connstring)
        newsqlconn.Close()
        'cboowner_edit.DataSource = Nothing
        cboAddOwnerNewECRPage.DataBindings.Clear()
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxECRGridView.Dock = DockStyle.Fill
        GroupBoxECRGridView.Show()
        StatementSQL.LoadAllECRItemsList()

    End Sub
    Private Sub MainMenu_btnECRViewMyFinishedEcr_Click(sender As Object, e As EventArgs) Handles MainMenu_ECRbtn_MyFinished.Click
        'newsqlconn.Close()
        cboAddOwnerNewECRPage.DataBindings.Clear()
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxECRGridView.Dock = DockStyle.Fill
        GroupBoxECRGridView.Show()
        StatementSQL.LoadFinishedItems()
    End Sub
    Private Sub MainMenu_btnECRViewMyAssignedEcrs_Click_1(sender As Object, e As EventArgs) Handles MainMenu_ECRbtn_MyAssigned.Click
        Dim newsqlconn As New SqlConnection(connstring)
        newsqlconn.Close()
        cboAddOwnerNewECRPage.DataBindings.Clear()
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxECRGridView.Dock = DockStyle.Fill
        GroupBoxECRGridView.Show()
        StatementSQL.LoadMyItems()
    End Sub
    Private Sub BtnEditViewECRPage_Click(sender As Object, e As EventArgs) Handles BtnEditViewECRPage.Click

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxEditECRItems.Dock = DockStyle.Fill
        GroupBoxEditECRItems.Show()

        Try
            lblEcrNumECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            lblDateCreatedECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
            lblDateModifiedECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
            lblDateAssignedECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
            lblDateFinishedECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(12).Value.ToString
            lblRequestorECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
            lblRequestorEmailMainPage.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString
            cboEngineerECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString
            lblItemOwnersEmailMainPage.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString
            cboStatusECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
            cboSiteECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(13).Value.ToString
            cboChangeTypeECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
            txtDocNumECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
            txtDocRevECREditItemsPage.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString

            'Loads the current status of the ECR item
            StatementSQL.LoadCboStatusDropDown_EditPage()
            'Loads the assigned owner of the ECR item
            StatementSQL.LoadAssignedToUsersCbo_EditPage()
            'LoadOwnerNameDropdown_EditPage()
            StatementSQL.LoadComments_EditPage()

        Catch ex As Exception
            MsgBox("The Jedi is strong with the force! " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
        ' End Using
    End Sub
    Private Sub BtnEmailSubmitECRItemsPage_Click(sender As Object, e As EventArgs) Handles BtnEmailSubmitECRItemsPage.Click

        StatementSQL.UpdateECRItems() ' Includes emails out to the assigned user after saving
        btnClearNewECRItemsPage.PerformClick()
        MainMenu_ECRbtn_ViewAll.PerformClick()

    End Sub


    Public Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Dim userType As String = lblUserTypeMainForm.Text

        'If userType = "Administrator" Or "Engineer" Or "Quality Engineer" Then

        'Else
        '    BtnEditViewECRPage.Enabled = False
        'End If

        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxViewECRPage.Dock = DockStyle.Fill
        GroupBoxViewECRPage.Show()
        'PostItemsForm.Show()

        ' Below is the column number for the data
        ' 1 = EcrConfNum
        ' 2 = DateCreated
        ' 3 = DateModified 
        ' 4 = DateAssigned
        ' 5 = status
        ' 6 = ECRSubject
        ' 8 = creator
        ' 9 = creator_email
        ' 10 = owner
        ' 11 = owner_email
        ' 12 = DateFinished

        lblEcrNumberViewECRPage.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString

        lblDateCreatedViewECRPage.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        lblDateModifiedViewECRPage.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        lblDateAssignedViewECRPage.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
        lblDateFinishedViewECRPage.Text = DataGridView1.CurrentRow.Cells(12).Value.ToString

        lblRequestorViewECRPage.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
        lblRequestorEmailMainPage.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString
        lblRequestorEmailViewECRPage.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString

        lblEngineerViewEcrPage.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString
        lblItemOwnersEmailMainPage.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString
        lblEngineerEmailViewEcrPage.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString

        lblStatusViewEcrPage.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
        lblSiteViewEcrPage.Text = DataGridView1.CurrentRow.Cells(13).Value.ToString
        lblChangeTypeViewEcrPage.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
        lblDocNumViewEcrPage.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
        lblDocRevViewEcrPage.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
        StatementSQL.LoadComments()


    End Sub


    ' ************* Code to change color when mouse is hovered over datagridview but it is buggy******************
    'Public Sub DataGridView1_CellMouseEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
    '    DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray
    '    DataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Black
    '    If e.RowIndex > 1 Then
    '        DataGridView1.Rows(e.RowIndex).Selected = True
    '    End If
    'End Sub
    'Private Sub DataGridView1_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
    '    DataGridView1.RowsDefaultCellStyle.SelectionBackColor = DefaultBackColor
    '    DataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Black

    'End Sub

    Public Function IsDataGridViewEmpty(ByRef dataGridView2 As DataGridView) As Boolean
        'email2Buyer()
        Dim isEmpty As Boolean
        isEmpty = True
        For Each row As DataGridViewRow In dataGridView2.Rows
            For Each cell As DataGridViewCell In row.Cells
                If Not String.IsNullOrEmpty(cell.Value) Then
                    ' Check if the string only consists of spaces
                    If Not String.IsNullOrEmpty(Trim(cell.Value.ToString())) Then
                        isEmpty = False
                        Exit For
                    End If
                End If
            Next
        Next
        Return isEmpty
    End Function

    Private Sub Cboowner_add_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddOwnerNewECRPage.SelectedIndexChanged
        'LoadOwnerInfo_AddActionItemsPage()
        StatementSQL.LoadOwnerInfoNewEcrPage()

    End Sub

    Private Sub Cboowner_edit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEngineerECREditItemsPage.SelectedIndexChanged
        StatementSQL.LoadOwnerECREditPage()

    End Sub


    Private Sub Btncancel_Click(sender As Object, e As EventArgs) Handles BtnCancelECRItemsPage.Click
        'Me.Controls.Clear() 'removes all the controls on the form
        Hidegb()
    End Sub

#End Region

#Region "MY ECR"
    Private Sub btnSubmitNewECRItem_Click(sender As Object, e As EventArgs) Handles btnSubmitNewECRItem.Click

        If cboAddChangeTypeNewECRPage.Text = "" Then
            MsgBox("To Continue you need to choose a Change Type.", MsgBoxStyle.Exclamation)
        ElseIf cboAddEcrSiteNewECRPage.Text = "" Then
            MsgBox("To Continue you need to choose a Site.", MsgBoxStyle.Exclamation)
        ElseIf txtAddCommentsNewECRPage.Text = "" Then
            MsgBox("You must have a description!", MsgBoxStyle.Exclamation)
        Else
            'Grabs a new Item Number and increments to the next number
            StatementSQL.GetActionItemNumber()
            'Inserts ECR requests into SQL 
            'StatementSQL.AddNewEcrItems()
            'Inserts ECR Descriptions or Comments in SQL
            'StatementSQL.InsertDescriptionsNewECRPage()
            'Creates a log
            'StatementSQL.LogActivitiesNewECRCreated()

            'publicvariables.SendEmail_ToRequestor()
            'publicvariables.SendNewECREmailToEngineeering()

            'notify-email creator he/she has created a new action item for reference
            'sendeMail_ofNewActionItem()
            btnClearNewECRItemsPage.PerformClick()
            Hidegb()
            cboAddEcrSiteNewECRPage.SelectedIndex = -1
            cboAddChangeTypeNewECRPage.SelectedIndex = -1
        End If

    End Sub
    Private Sub MainMenu_MyECRbtn_RequestNew_Click(sender As Object, e As EventArgs) Handles MainMenu_MyECRbtn_RequestNew.Click
        Enablebtns()
        lblYourECRNumberIS.Visible = False
        lblECRNumNewECRPage.Visible = False

        'btnViewItems.Enabled = False

        'hide group boxes first before showing the single group boxes or else all if it will not work correctly
        Hidegb()
        'Shows the New ECR Form to fill for user
        GroupBoxAddNewECR.Dock = DockStyle.Fill
        GroupBoxAddNewECR.Show()
        ClearItemsfields()

        'Calls a method to load the combo box with the users
        StatementSQL.LoadUsersCbo_AddECRPage()

    End Sub
    Private Sub MainMenu_btnMyECRMyRequests_Click(sender As Object, e As EventArgs) Handles MainMenu_MyECRbtn_RequestsInProgess.Click

        cboAddOwnerNewECRPage.DataBindings.Clear()
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxECRGridView.Dock = DockStyle.Fill
        GroupBoxECRGridView.Show()
        StatementSQL.LoadMyRequestedECRItems()


    End Sub
    Private Sub MainMenu_MyECRbtn_MyFinished_Click(sender As Object, e As EventArgs) Handles MainMenu_MyECRbtn_MyFinished.Click
        'newsqlconn.Close()
        cboAddOwnerNewECRPage.DataBindings.Clear()
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxECRGridView.Dock = DockStyle.Fill
        GroupBoxECRGridView.Show()
        StatementSQL.LoadMyRequestedFinishedItems()
    End Sub
    Private Sub BtnSearchActionItems_Click(sender As Object, e As EventArgs) Handles BtnSearchMyECR.Click
        StatementSQL.SearchECRItems()
    End Sub


    Private Sub Txthomesearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearchECRBar.TextChanged
        'SearchECRItems()
    End Sub



    Private Sub ECRLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainMenu_Logbtn_ECRLogs.Click
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxActivityLog.Dock = DockStyle.Fill
        GroupBoxActivityLog.Show()
        StatementSQL.ViewLogECR()
    End Sub

    Private Sub YourItemNumberIs_Click(sender As Object, e As EventArgs) Handles lblYourItemNumberIs.Click

    End Sub

#End Region

#Region "ACTION ITEMS SECTION"

    Private Sub MainMenu_AIbtn_AddActionItem_Click(sender As Object, e As EventArgs) Handles MainMenu_AIbtn_AddActionItem.Click
        Enablebtns()
        lblYourItemNumberIs.Visible = False
        lblActionItemsNewPage.Visible = False

        Hidegb()
        GroupBox_ActionItemsPage.Dock = DockStyle.Fill
        GroupBox_ActionItemsPage.Show()
        ClearItemsfields()


    End Sub
    Private Sub MainMenu_AIbtn_ViewAllActionItems_Click(sender As Object, e As EventArgs) Handles MainMenu_AIbtn_ViewAllActionItems.Click
        Dim newsqlconn As New SqlConnection(connstring)
        newsqlconn.Close()
        Enablebtns()
        Hidegb()
        GroupBoxActionItemsGridView.Dock = DockStyle.Fill
        GroupBoxActionItemsGridView.Show()
        StatementSQL.LoadAllActionItems()


    End Sub
    Private Sub btnSubmitActionItemsPage_Click(sender As Object, e As EventArgs) Handles btnSubmitActionItemsPage.Click

        If txtAddTaskActionItemsPage.Text = "" Then
            MsgBox("Please fill out a task.", MsgBoxStyle.Exclamation)
        ElseIf txtAddReferenceActionItemsPage.Text = "" Then
            MsgBox("Please fill out a reference", MsgBoxStyle.Exclamation)
        ElseIf cboAddStateActionItemsPage.Text = "" Then
            MsgBox("Please select a state of the Action Item", MsgBoxStyle.Exclamation)
        Else

            StatementSQL.GetActionItemNumber()

        End If
        btnclearrequestopsheet.PerformClick()
        Hidegb()
    End Sub
    Private Sub cboowner_RequestOPChangePage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOwnerActionItemPage.SelectedIndexChanged

        'Dim sqldatatable As New DataTable
        'Dim SQLAdapter As New SqlDataAdapter
        'Dim myReader As SqlDataReader

        'Try
        '    If newsqlconn.State = ConnectionState.Closed Then
        '        newsqlconn.Open()
        '    ElseIf newsqlconn.State = ConnectionState.Open Then
        '    End If
        '    sqlquery = "SELECT * FROM (SELECT id, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype FROM useraccounts) base " &
        '        " WHERE FullName = '" & cboowner_RequestOPChangePage.Text & "' "

        '    sqlcmd = New SqlCommand(sqlquery, newsqlconn)
        '    myReader = sqlcmd.ExecuteReader

        '    While myReader.Read
        '        lblowner_id_edit.Text = myReader.GetInt32("id")
        '        lblAssignedToFullNameMainPage.Text = myReader.GetString("FullName")
        '        lblAssignedToEmailMainPage.Text = myReader.GetString("user_email")
        '        lblUserTypeMainPage.Text = myReader.GetString("user_type")
        '        'lblcreators_email.Text = myReader.GetString("creator_email")
        '    End While
        '    newsqlconn.Close()

        'Catch ex As Exception
        '    MessageBox.Show("Error in this section Cboowner_RequestOPChangePage_SelectedIndexChanged: " & ex.Message)
        'End Try
    End Sub

    Private Function ThereAreChangesDtp(ByVal dtpDateTimePicker As DateTimePicker,
                                        ByVal DataReader As SqlDataReader,
                                        ByVal strDB_Veld As String,
                                        ByVal intColumn As Integer) As Boolean
        If dtpDateTimePicker.Checked = DataReader.IsDBNull(intColumn) OrElse
    (dtpDateTimePicker.Checked AndAlso dtpDateTimePicker.Value.Date <> CDate(DataReader(strDB_Veld)).Date) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub DataGridView8_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView8.CellContentClick
        Hidegb()

        If lblUserTypeMainForm.Text = "Administrator" Or lblUserTypeMainForm.Text = "Engineer" Or lblUserTypeMainForm.Text = "Manager" Then
            GroupBoxActionItemsWorkPage.Dock = DockStyle.Fill
            GroupBoxActionItemsWorkPage.Show()

            lblActionItemsWorkPage.Text = DataGridView8.CurrentRow.Cells(1).Value.ToString
            lblTaskActionItemPage.Text = DataGridView8.CurrentRow.Cells(2).Value.ToString
            lblReferenceActionItemPage.Text = DataGridView8.CurrentRow.Cells(3).Value.ToString
            cboStateActionItemPage.Text = DataGridView8.CurrentRow.Cells(4).Value.ToString
            lblDateCreatedActionItemPage.Text = DataGridView8.CurrentRow.Cells(5).Value.ToString
            lblDateModifiedActionItemPage.Text = DataGridView8.CurrentRow.Cells(6).Value.ToString
            lblDateAssignedActionItemPage.Text = DataGridView8.CurrentRow.Cells(7).Value.ToString
            lblDateFinishedActionItemPage.Text = DataGridView8.CurrentRow.Cells(8).Value.ToString
            lblCreatedByActionItemsPage.Text = DataGridView8.CurrentRow.Cells(9).Value.ToString
            cboOwnerActionItemPage.Text = DataGridView8.CurrentRow.Cells(11).Value.ToString
            lblAssignedToFullNameMainPage.Text = DataGridView8.CurrentRow.Cells(11).Value.ToString
            cboStatusActionItemPage.Text = DataGridView8.CurrentRow.Cells(13).Value.ToString
            lblItemOwnersEmailMainPage.Text = DataGridView8.CurrentRow.Cells(12).Value.ToString

            If DataGridView8.CurrentRow.Cells(14).Value.ToString Is Nothing Then
                DataGridView8.CurrentRow.Cells(14).Value = Now
                DateTimePicker2.Value = DataGridView8.CurrentRow.Cells(14).Value.ToString
                ' MessageBox.Show("Cell is empty")
            ElseIf DataGridView8.CurrentRow.Cells(14).Value.ToString IsNot Nothing Then
                If DataGridView8.CurrentRow.Cells(14).Value.ToString = DateTime.MinValue.Date.ToString Then
                    DateTimePicker2.Value = Now
                    '  MessageBox.Show("Show MinValue: " & DataGridView8.CurrentRow.Cells(14).Value.ToString)
                Else
                    '  MessageBox.Show("Has Date: " & DataGridView8.CurrentRow.Cells(14).Value.ToString)
                    DateTimePicker2.Value = DataGridView8.CurrentRow.Cells(14).Value.ToString
                End If
            End If

            'Loads notes history
            StatementSQL.LoadComments()
            StatementSQL.LoadAssignedToUsersCbo_EditPage()


        End If
    End Sub

    Private Sub MainMenu_AIbtn_MyActionItems_Click(sender As Object, e As EventArgs) Handles MainMenu_AIbtn_MyActionItems.Click
        Dim newsqlconn As New SqlConnection(connstring)
        newsqlconn.Close()
        cboOwnerActionItemPage.DataBindings.Clear()
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxActionItemsGridView.Dock = DockStyle.Fill
        GroupBoxActionItemsGridView.Show()
        StatementSQL.LoadMyAssignedActionItems()

    End Sub

    Private Sub MainMenu_AIbtn_MyFinishedActionItems_Click(sender As Object, e As EventArgs) Handles MainMenu_AIbtn_MyFinishedActionItems.Click
        Dim newsqlconn As New SqlConnection(connstring)
        newsqlconn.Close()
        cboOwnerActionItemPage.DataBindings.Clear()
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxActionItemsGridView.Dock = DockStyle.Fill
        GroupBoxActionItemsGridView.Show()
        StatementSQL.LoadMyFinishedActionItems()
    End Sub

    Private Sub MainMenu_Logbtn_ActionItemLogs_Click(sender As Object, e As EventArgs) Handles MainMenu_Logbtn_ActionItemLogs.Click
        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxActivityLog.Dock = DockStyle.Fill
        GroupBoxActivityLog.Show()
        StatementSQL.ViewLogActionItems()
    End Sub

    Private Sub Btnemailsave_RequestOPChangePage_Click(sender As Object, e As EventArgs) Handles btnSaveActionItemPage.Click
        'StatementSQL.UpdateReqOpSheetChanges() ' After update, it emails to the assigned user after saving
        Hidegb()
        StatementSQL.UpdateActionItems()

    End Sub

    Private Sub BtnSearchReqOpSheetChanges_Click(sender As Object, e As EventArgs) Handles BtnSearchActionItems.Click
        StatementSQL.SearchActionItems()
    End Sub

#End Region

#Region "ACTIVITY - HISTORY PAGE"

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles MainMenu_Logbtn.Click


    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

        If lblUserTypeMainForm.Text = "Administrator" Then
            SwitchToItemsFromActivityLogs()

        ElseIf lblUserTypeMainForm.Text = "Manager" Then
            SwitchToItemsFromActivityLogs()

        ElseIf lblUserTypeMainForm.Text = "Engineer" Then
            SwitchToItemsFromActivityLogs()

        Else
            SwitchToItemsFromActivity_NonEngineer()

        End If

    End Sub

    Public Sub SwitchToItemsFromActivityLogs()
        'Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        'Dim itemNumber As String
        'itemNumber = DataGridView4.CurrentRow.Cells(2).Value.ToString

        'If itemNumber Like "R[C]*" = True Then
        '    'MessageBox.Show("This is a Request OP Sheet Change item")
        '    GroupBox_RequestedOpSheetChanges.Dock = DockStyle.Fill
        '    GroupBox_RequestedOpSheetChanges.Show()
        '    StatementSQL.GoToRequestChangeSelected()
        '    Dim arg = New DataGridViewCellEventArgs(3, 2)
        '    DataGridView8_CellContentClick(Me.DataGridView8, arg)
        'Else
        '    GroupBoxViewECRItems.Dock = DockStyle.Fill
        '    GroupBoxViewECRItems.Show()
        '    StatementSQL.GoToActionItemSelected()
        '    Dim arg = New DataGridViewCellEventArgs(3, 2)
        '    DataGridView1_CellContentClick_1(Me.DataGridView1, arg)

        'End If
    End Sub

    Public Sub SwitchToItemsFromActivity_NonEngineer()

        Dim itemNumber As String
        itemNumber = DataGridView4.CurrentRow.Cells(2).Value.ToString

        If itemNumber Like "R[C]*" = True Then
            MessageBox.Show("Sorry you do not access to these items, please contact your supervisor for access.")

        Else
            Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
            GroupBoxECRGridView.Dock = DockStyle.Fill
            GroupBoxECRGridView.Show()
            StatementSQL.GoToActionItemSelected()
            Dim arg = New DataGridViewCellEventArgs(3, 2)
            DataGridView1_CellContentClick_1(Me.DataGridView1, arg)

        End If

    End Sub

#End Region

#Region "REPORTS"
    Private Sub BtnReport_Click(sender As Object, e As EventArgs) Handles MainMenu_Reportsbtn.Click

        Enablebtns()
        Hidegb() 'hide grouboxes first before showing the single grouboxes or else all if it will not work correctly
        GroupBoxReports.Dock = DockStyle.Fill
        GroupBoxReports.Show()

    End Sub

    Private Sub btnActionItemsByOwners_Click(sender As Object, e As EventArgs) Handles btnActionItemsByOwners.Click


    End Sub


#End Region

#Region "CLEARING FIELDS"
    Private Sub ClearItemsfields()
        For Each txt As Control In Me.GroupBox_InfoMainForm.Controls
            If TypeOf txt Is Label Then
                txt.Text = String.Empty
            End If
        Next
    End Sub

    Private Sub ClearTextBox(ByVal root As Control)
        For Each cntrl As Control In root.Controls
            ClearTextBox(cntrl)
            If TypeOf cntrl Is TextBox Then
                CType(cntrl, TextBox).Text = String.Empty
            End If
        Next cntrl
    End Sub

    Private Sub ClearTable(table As DataTable)
        Try
            table.Clear()
        Catch e As DataException
            ' Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.",
              e.GetType().ToString())
        End Try
    End Sub

    Private Sub Btnclear_additems_page_Click(sender As Object, e As EventArgs) Handles btnClearNewECRItemsPage.Click
        Dim a As Control

        For Each a In Me.GroupBoxAddNewECR.Controls
            If TypeOf a Is TextBox Then
                a.Text = Nothing
            End If
        Next

    End Sub

    Private Sub Btnclearrequestopsheet_Click(sender As Object, e As EventArgs) Handles btnclearrequestopsheet.Click

        For Each a In Me.GroupBox_ActionItemsPage.Controls
            If TypeOf a Is TextBox Then
                a.Text = Nothing
            End If
        Next
    End Sub

    Private Sub Clearfields()
        For Each cntrl As Control In Me.Controls
            ClearTextBox(cntrl)
            If TypeOf cntrl Is TextBox Then
                CType(cntrl, TextBox).Text = String.Empty
            End If
        Next cntrl
    End Sub

#End Region

#Region "TESTING PARAMETERS"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''Dim iString As String = "2020-05-05 22:12 PM"
        'Dim iString As String = "Wed, May 28, 2020"
        'Dim oDate As DateTime = DateTime.ParseExact(iString, "ddd, MM-dd-yyy", System.Globalization.CultureInfo.InvariantCulture)
        'MsgBox(oDate.ToString())


        'Dim dateString, format As String
        'Dim result As Date
        'Dim validInput As Integer

        'Dim provider As CultureInfo = CultureInfo.InvariantCulture

        ''dateString = "Sun 15 Jun 2008 8:30 AM -06:00"
        'dateString = "Sun 15 Jun 2008"
        'format = "dd MMM yyyy"

        'Try
        '    result = Date.ParseExact(dateString, format, provider)
        '    MsgBox("{0} converts to {1}.", dateString, result.ToString())
        'Catch
        '    MsgBox("{0} is not in the correct format.", dateString, result.ToString())
        'End Try

        '*** The below is what you need to parse and convert the fow data dates
        Dim date1 As Date
        Dim date2 As Date
        Dim date3 As Date
        date1 = CDate("Wed, May 28, 2014") ' prints 03/03/2019
        date2 = CDate("9:37:51 AM") ' prints 12:27:00 PM
        date3 = CDate("March 03, 2019 12:27:00 PM") ' prints 03/03/2019 12:27:00 PM

        MessageBox.Show(date1 + Environment.NewLine + date2 + Environment.NewLine + date3)


    End Sub

    Private Sub btnOldSaveActionItem_Click(sender As Object, e As EventArgs)
        Dim Smtp_Server As New SmtpClient
        Dim sqlda As New SqlDataAdapter
        Dim actionItemNum As String = lblActionItemsWorkPage.Text
        Dim taskActionItem As String = lblTaskActionItemPage.Text
        Dim referenceActionItem As String = lblReferenceActionItemPage.Text
        Dim stateActionItem As String = cboStateActionItemPage.Text
        Dim dateCreated As String = lblDateCreatedActionItemPage.Text
        Dim statusActionItem As String = cboStatusActionItemPage.Text
        Dim notesActionItems As String = txtNotesActionItemPage.Text
        Dim creatorOfActionItem As String = lblCreatedByActionItemsPage.Text
        Dim creatorEmailActionItem As String = lblRequestorEmailMainPage.Text
        Dim ownerSelectedActionItem As String = cboOwnerActionItemPage.Text
        Dim loggedInUser As String = lblUserFullNameMainForm.Text

        Dim ownerEmailActionItem As String
        Dim ownerOfCurrentActionItem As String
        Dim newOwnerEmailActionItem As String
        Dim sqldatatable As New DataTable
        Dim SQLAdapter As New SqlDataAdapter
        Dim sqlstr As String
        Dim myDataSet As New DataSet

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If


        sqlstr = "SELECT ActionItemNum, Owner, OwnerEmail FROM ActionItemsDet " &
        " WHERE ActionItemNum ='" & actionItemNum & "'"
        sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
        sqlda.Fill(myDataSet, "ucrms")
        ownerOfCurrentActionItem = myDataSet.Tables("ucrms").Rows(0).Item(1)
        ownerEmailActionItem = myDataSet.Tables("ucrms").Rows(0).Item(2)
        MsgBox("Current owner is: " & ownerOfCurrentActionItem & " and email is: " & ownerEmailActionItem)


        Dim newDataSet As New DataSet
        'Grabbing the newly assigned owner's email from here
        sqlstr = "SELECT * FROM (SELECT id as ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype as Type, emplid AS EmployeeID" &
            " FROM useraccounts) base WHERE FullName = '" & ownerSelectedActionItem & "'"
        sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
        sqlda.Fill(newDataSet, "ucrms")
        newOwnerEmailActionItem = newDataSet.Tables("ucrms").Rows(0).Item(4)
        MsgBox(newOwnerEmailActionItem)

        MsgBox("You want to assign to: " & newOwnerEmailActionItem)
        newsqlconn.Close()
    End Sub

    Private Sub Txtweblink_KeyPress(ByVal sender As Object, ByVal _
        e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(1) Then
            DirectCast(sender, TextBox).SelectAll()
            e.Handled = True
        End If
    End Sub
    Private Sub Autogenerate_id()
        Dim newsqlconn As New SqlConnection(connstring)
        newsqlconn.Open()
        sqlcmd.Connection = newsqlconn
        sqlcmd.CommandText = "select max (id) from "
        newsqlconn.Dispose()
    End Sub
    Public Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region

#Region "SETTINGS"
    Private Sub MainMenu_btnSettingsUserAdministration_Click(sender As Object, e As EventArgs) Handles MainMenu_Settingsbtn_UserAdministration.Click
        'Manageaccounts.Dispose()
        UserAccounts.ShowDialog()
    End Sub
    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles MainMenu_btnSettings.Click
        'AboutBox1.ShowDialog()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainMenu_Settingsbtn_About.Click
        AboutBox1.Show()

    End Sub

#End Region

#Region "LOGOUT"

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles MainMenu_LogOutbtn.Click
        'Me.Close()
        Login.Close()
    End Sub

    Private Sub Btncancel_RequestOPChangePage_Click(sender As Object, e As EventArgs) Handles btnCancelActionItemPage.Click
        Hidegb()
    End Sub

    Private Sub TestC_Click(sender As Object, e As EventArgs)
        publicvariables.SendeMail_UpdateActionItem()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

    End Sub

    Private Sub MainMenu_SharePoint_Click(sender As Object, e As EventArgs) Handles MainMenu_SharePoint.Click
        Process.Start("https://ushersmachine.sharepoint.com/")
    End Sub

    Private Sub FlowDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainMenu_FlowData.Click
        Dim newsqlconn As New SqlConnection(connstring)
        newsqlconn.Close()
        Enablebtns()
        Hidegb()
        FlowForm.Show()
    End Sub



#End Region


End Class