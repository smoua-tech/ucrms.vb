Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient

Public Class Publicvariables
    Public sqlcmd As New SqlCommand
    Public sqlda As New SqlDataAdapter
    Public table As DataTable
    ReadOnly Smtp_Server As SmtpClient
    Public theEmail As MailMessage()
    Public sqlquery As String
    Public myitemid As String
    ReadOnly result As Integer
    ReadOnly newsqlconn As SqlConnection = DBConn()
    ReadOnly connstring As String = "server=umtgv-db-01-dev.umt.local;User Id=db.app.svc;password=64JL2zCTBDEojhB1MfsW;database=ucrms"

    Private Sub Autogenerate_id()
        newsqlconn.Open()
        sqlcmd.Connection = newsqlconn
        sqlcmd.CommandText = "select max (id) from "
        newsqlconn.Dispose()
    End Sub

    Public Sub Loginsearch(ByVal sqlstr As String)
        Try
            With sqlcmd
                .Connection = newsqlconn
                .CommandText = sqlstr
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        newsqlconn.Close()
        'sqlda.Dispose()
    End Sub

    Public Sub LogInUsersMainForm()

    End Sub

    Public Sub LogInUserMainForm()
        'Dim MainForm As New Main
        'MainForm.Show()
        'MainForm.LoginToolStripMenu.Visible = False
        'MainForm.FullNameToolStripMenu.Visible = True
        'MainForm.UserIDToolStripMenu.Visible = True
        'MainForm.TabControl1.TabPages.Insert(0, Main.TabPage1)
    End Sub

    Public Sub Loggingout()
        'Dim user As String
        'Dim table As New DataTable
        'Dim id As Integer
        'Dim userid, logindate As String
        ''user = Main.FullNameToolStripMenu.Text
        ''id = Main.UserIDToolStripMenu.Text

        'sqlda.SelectCommand = sqlcmd
        'sqlda.Fill(table)

        'If table.Rows.Count > 0 Then
        '    id = table.Rows(0).Item(0)
        '    userid = table.Rows(0).Item(1)
        '    logindate = table.Rows(0).Item(2)
        '    If userid = ManagerForm.lblEmployeeIDMainForm.Text Then
        '        sqlquery = "UPDATE logs SET lastlogout=NOW() " &
        '            " WHERE userid= '" & userid & "' AND lastlogout= '0' "

        '        Using sqlcmd = New SqlCommand(sqlquery, newsqlconn)
        '            newsqlconn.Open()
        '            Dim theenterID = Convert.ToInt32(sqlcmd.ExecuteScalar())
        '            'System.Threading.Thread.Sleep(1000)
        '        End Using

        '        If newsqlconn.State = ConnectionState.Open Then
        '            'MsgBox("Logging out at: " & DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:sstt "))
        '            newsqlconn.Close()
        '        ElseIf newsqlconn.State = ConnectionState.Closed Then
        '        End If
        '        ManagerForm.Label45.Text = "Log In"
        '    Else
        '        MsgBox("User ID does not match")
        '    End If
        'Else
        '    MsgBox("Db error")
        'End If
    End Sub

#Region "HIDE ALL GROUPBOXES"

    Private Sub Hidegb()

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

#Region "NOTIFICATION / EMAIL"
    Sub SendEmail_ToCreatorofItem()
        Dim sqlstr As String
        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim siteECR As String = ManagerForm.cboAddEcrSiteNewECRPage.Text
        Dim newECRNumber As String = ManagerForm.lblECRNumNewECRPage.Text
        Dim requestorEmailAddress As String = ManagerForm.lblUserEmailMainForm.Text
        Dim loggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim changeTypeECR As String = ManagerForm.cboAddChangeTypeNewECRPage.Text
        Dim docNumECR As String = ManagerForm.txtAddEcrDocNumNewECRPage.Text
        Dim docRevECR As String = ManagerForm.txtAddEcrDocRevNewECRPage.Text
        Dim descrComments As String = ManagerForm.txtAddCommentsNewECRPage.Text
        Dim dateDue As Date = ManagerForm.DateTimePicker1.Value.ToString

        Dim newActioItemNum As String = ManagerForm.lblActionItemsNewPage.Text
        Dim taskActionItem As String = ManagerForm.txtAddTaskActionItemsPage.Text
        Dim referenceActionItem As String = ManagerForm.txtAddReferenceActionItemsPage.Text
        Dim stateOfActionItem As String = ManagerForm.cboAddStateActionItemsPage.Text
        Dim notesActionItem As String = ManagerForm.txtAddNotesActionItemsPage.Text

        Dim newOwnerEmailActionItem As String

        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"



        'Dim listofEmailAddresses As New List(Of MailAddress)
        'listofEmailAddresses.Add(New MailAddress(ManagerForm.lbluser_email.Text))
        'listofEmailAddresses.Add(New MailAddress(ManagerForm.lblowners_email.Text))
        If ManagerForm.GroupBox_ActionItemsPage.Visible = True Then

            Dim newDataSet As New DataSet
            'Grabbing the newly assigned owner's email from here
            sqlstr = "SELECT * FROM (SELECT id as ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype as Type, emplid AS EmployeeID" &
            " FROM useraccounts) base WHERE FullName = '" & loggedInUser & "'"
            sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
            sqlda.Fill(newDataSet, "ucrms")
            newOwnerEmailActionItem = newDataSet.Tables("ucrms").Rows(0).Item(4)
            'MsgBox(newOwnerEmailActionItem)

            Dim addressFrom As MailAddress = New MailAddress("relay@ushersm.com", "Engineering Action Items")
            'Dim addressTo As MailAddress = New MailAddress(ownerEmailActionItem)
            Dim newAddressTo As MailAddress = New MailAddress(newOwnerEmailActionItem)
            Dim message As MailMessage = New MailMessage(addressFrom, newAddressTo)
            message.IsBodyHtml = True
            message.Subject = "Your Action Item Number is: " & newActioItemNum & " "
            Dim htmlString As String = "<html>
                                    <body>
                                    <h1>Do Not reply to this email.</h1>
                                    <br>Date Created: " & Now & "</br>
                                    <br>Date Due: " & dateDue & "</br>
                                    <br>Task: " & taskActionItem & "</br>
                                    <br>Reference: " & referenceActionItem & "</br>
                                    <br>State: " & stateOfActionItem & "</br>
                                    <br>Status: New </br>
                                    <br>Notes: " & notesActionItem & "</br>
                                    <p></p>
                                    <p><font size=2><font color = #000080>NOTICE OF CONFIDENTIALITY: 
                                    This message and any attachments are for the sole use of the intended recipient(s) or authorized agent(s) 
                                    only and may contain confidential and/or legally privileged information. Any unauthorized view, use, disclosure 
                                    or distribution is expressly prohibited. If you are not the intended recipient, you are strictly prohibited 
                                    from disclosing, copying, distributing or using any or all of this communication. Please contact the sender 
                                    at 864 516-2690 immediately and destroy this message and all copies in any form.</font></p>
                                    
                                    </body>
                                    </html>"
            message.Body = htmlString
            Smtp_Server.Send(message)

        ElseIf ManagerForm.GroupBoxAddNewECR.Visible = True Then
            theEmail.From = New MailAddress("relay@ushersm.com")
            theEmail.To.Add(requestorEmailAddress)
            theEmail.Subject = "Your Confirmation ECR Number is: " & newECRNumber & " "
            theEmail.IsBodyHtml = False
            theEmail.Body = "Do not reply to this email." +
            Environment.NewLine + " Your ECR has been sent to Engineering." +
            Environment.NewLine + " Requestor: " & loggedInUser & "" +
            Environment.NewLine + " " +
            Environment.NewLine + " Site: " & siteECR & "" +
            Environment.NewLine + " Date Created: " & Now & "" +
            Environment.NewLine + " ECR Change Type: " & changeTypeECR & "" +
            Environment.NewLine + " Document #: " & docNumECR & "" +
            Environment.NewLine + " Document Rev: " & docRevECR & "" +
            Environment.NewLine + " Description of Request: " & descrComments & "" +
            Environment.NewLine + " "
            Smtp_Server.Send(theEmail)
            theEmail.To.Clear()
            '-- send email

        Else

        End If


    End Sub

    Public Sub SendNewECREmailToEngineeering()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim siteECR As String = ManagerForm.cboAddEcrSiteNewECRPage.Text
        Dim newECRNumber As String = ManagerForm.lblECRNumNewECRPage.Text
        Dim requestorEmailAddress As String = ManagerForm.lblUserEmailMainForm.Text
        Dim requestorFullName As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim changeTypeECR As String = ManagerForm.cboAddChangeTypeNewECRPage.Text
        Dim docNumECR As String = ManagerForm.txtAddEcrDocNumNewECRPage.Text
        Dim docRevECR As String = ManagerForm.txtAddEcrDocRevNewECRPage.Text
        Dim descrComments As String = ManagerForm.txtAddCommentsNewECRPage.Text

        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        'Dim listofEmailAddresses As New List(Of MailAddress)
        'listofEmailAddresses.Add(New MailAddress("smoua@ushersm.com")) 'Engineer's email will go here - NEED TO CHANGE THIS TO THE GROUP WHEN FINAL
        'listofEmailAddresses.Add(New MailAddress(creatorEmailAddress)) ' Creator's email will go here

        'For Each tempEmails As MailAddress In listofEmailAddresses
        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add("ecr@ushersm.com") ' ECR Group's Email Harcoded
        theEmail.Subject = "New ECR: " & newECRNumber & ", has been submitted for review. "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
            Environment.NewLine + " Status: New" +
            Environment.NewLine + " Requestor: " & requestorFullName & "" +
            Environment.NewLine + " " +
            Environment.NewLine + " Site: " & siteECR & "" +
            Environment.NewLine + " Date Created: " & Now & "" +
            Environment.NewLine + " ECR Change Type: " & changeTypeECR & "" +
            Environment.NewLine + " Document #: " & docNumECR & "" +
            Environment.NewLine + " Document Rev: " & docRevECR & "" +
            Environment.NewLine + " Description of Request: " & descrComments & "" +
            Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()
        '-- send email
        'Next

    End Sub

    Public Sub SendeMail_OfReassignmentUser()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim newECRNumber As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim emailAddress As String = ManagerForm.lblItemOwnersEmailMainPage.Text

        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add(emailAddress)
        theEmail.Subject = "ECR #: " & newECRNumber & ", has been reassigned to you "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
                            Environment.NewLine + " Status: New " & ManagerForm.cboStatusECREditItemsPage.Text & "" +
                            Environment.NewLine + " Created by: " & ManagerForm.lblRequestorECREditItemsPage.Text & "" +
                            Environment.NewLine + " " +
                            Environment.NewLine + " Date Created: " & ManagerForm.lblDateCreatedECREditItemsPage.Text & "" +
                            Environment.NewLine + " ECR Subject: " & ManagerForm.txtECRSubjectECREditItemsPage.Text & "" +
                            Environment.NewLine + " Reference: " & ManagerForm.txtDocNumECREditItemsPage.Text & "" +
                            Environment.NewLine + " Description / Comments: " & ManagerForm.txtDescriptionECREditItemsPage.Text & "" +
                            Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()

    End Sub

    Public Sub SendeMail_FinishedECR()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim ECRNumber As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim dateCreated As String = ManagerForm.lblDateCreatedECREditItemsPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedECREditItemsPage.Text
        Dim currentStatus As String = ManagerForm.cboStatusECREditItemsPage.Text
        Dim assignedEngineer As String = ManagerForm.cboEngineerECREditItemsPage.Text
        Dim loggedInPersonsEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim assignedEngineerEmail As String = ManagerForm.lblEngineerEmailViewEcrPage.Text
        Dim requestorEmailAddress As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim requestorFullName As String = ManagerForm.lblRequestorECREditItemsPage.Text
        Dim changeType As String = ManagerForm.cboChangeTypeECREditItemsPage.Text
        Dim docNum As String = ManagerForm.txtDocNumECREditItemsPage.Text
        Dim docRev As String = ManagerForm.txtDocRevECREditItemsPage.Text
        Dim descrComments As String = ManagerForm.txtDescriptionECREditItemsPage.Text
        Dim emailAddress As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        If assignedEngineer = requestorFullName Then
            theEmail.From = New MailAddress("relay@ushersm.com")
            theEmail.To.Add(requestorEmailAddress)
            theEmail.Subject = "" & ECRNumber & " has been completed by: " & assignedEngineer & " "
            theEmail.IsBodyHtml = False
            theEmail.Body = "Do not reply to this email." +
            Environment.NewLine + " " +
            Environment.NewLine + " Status: " & currentStatus & "" +
            Environment.NewLine + " Date Created: " & dateCreated & "" +
            Environment.NewLine + " Date Finished: " & Now & "" +
            Environment.NewLine + " Requestor: " & requestorFullName & "" +
            Environment.NewLine + " Engineer: " & assignedEngineer & "" +
            Environment.NewLine + " " +
            Environment.NewLine + " ECR Change Type: " & changeType & "" +
            Environment.NewLine + " Document #: " & docNum & "" +
            Environment.NewLine + " Document Rev: " & docRev & "" +
            Environment.NewLine + " Description / Comments: " & descrComments & "" +
            Environment.NewLine + " " +
            Environment.NewLine + " "
            Smtp_Server.Send(theEmail)
            theEmail.To.Clear()
            '-- send email

        ElseIf assignedEngineer <> requestorFullName Then
            Dim listofEmailAddresses As New List(Of MailAddress)
            listofEmailAddresses.Add(New MailAddress(assignedEngineerEmail))
            listofEmailAddresses.Add(New MailAddress(requestorEmailAddress))
            'listofEmailAddresses.Add(New MailAddress(loggedInPersonsEmail))
            For Each tempEmails As MailAddress In listofEmailAddresses
                theEmail.From = New MailAddress("relay@ushersm.com")
                theEmail.To.Add(tempEmails)
                theEmail.Subject = "" & ECRNumber & " has been completed by: " & assignedEngineer & " "
                theEmail.IsBodyHtml = False
                theEmail.Body = "Do not reply to this email." +
                Environment.NewLine + " " +
                Environment.NewLine + " Status: " & currentStatus & "" +
                Environment.NewLine + " Date Created: " & dateCreated & "" +
                Environment.NewLine + " Date Finished: " & Now & "" +
                Environment.NewLine + " Requestor: " & requestorFullName & "" +
                Environment.NewLine + " Engineer: " & assignedEngineer & "" +
                Environment.NewLine + " " +
                Environment.NewLine + " ECR Change Type: " & changeType & "" +
                Environment.NewLine + " Document #: " & docNum & "" +
                Environment.NewLine + " Document Rev: " & docRev & "" +
                Environment.NewLine + " Description / Comments: " & descrComments & "" +
                Environment.NewLine + " " +
                Environment.NewLine + " "
                Smtp_Server.Send(theEmail)
                theEmail.To.Clear()
                '-- send email
            Next
        End If
    End Sub

    Public Sub SendEmailECRStatus()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim ECRNumber As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim loggedInEngineer As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim loggedInEngineerEmail As String = ManagerForm.lblUserEmailMainForm.Text
        Dim assignedEngineer As String = ManagerForm.cboEngineerECREditItemsPage.Text
        Dim assignedEngineerEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim creatorEmailAddress As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim creatorFullName As String = ManagerForm.lblRequestorECREditItemsPage.Text
        Dim ecrSubject As String = ManagerForm.txtECRSubjectECREditItemsPage.Text
        Dim reference As String = ManagerForm.txtDocNumECREditItemsPage.Text
        Dim descrComments As String = ManagerForm.txtDescriptionECREditItemsPage.Text
        Dim dateCreated As String = ManagerForm.lblDateCreatedECREditItemsPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedECREditItemsPage.Text
        Dim currentStatus As String = ManagerForm.cboStatusECREditItemsPage.Text
        ' Dim emailAddress As String = ManagerForm.lblEngineerEmailMainPage.Text
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        If assignedEngineer = loggedInEngineer Then
            theEmail.From = New MailAddress("relay@ushersm.com")
            theEmail.To.Add(assignedEngineerEmail)
            theEmail.Subject = "" & ECRNumber & " has been modified by: " & assignedEngineer & " "
            theEmail.IsBodyHtml = False
            theEmail.Body = "Do not reply to this email." +
            Environment.NewLine + " " +
            Environment.NewLine + " Status: " & currentStatus & "" +
            Environment.NewLine + " Date Created: " & dateCreated & "" +
            Environment.NewLine + " Date Finished: " & Now & "" +
            Environment.NewLine + " Created by: " & creatorFullName & "" +
            Environment.NewLine + " Engineer: " & assignedEngineer & "" +
            Environment.NewLine + " " +
            Environment.NewLine + " ECR Subject: " & ecrSubject & "" +
            Environment.NewLine + " Reference: " & reference & "" +
            Environment.NewLine + " Description / Comments: " & descrComments & "" +
            Environment.NewLine + " " +
            Environment.NewLine + " "
            Smtp_Server.Send(theEmail)
            theEmail.To.Clear()
            '-- send email

        ElseIf loggedInEngineer <> assignedEngineer Then
            Dim listofEmailAddresses As New List(Of MailAddress)
            listofEmailAddresses.Add(New MailAddress(loggedInEngineerEmail))
            listofEmailAddresses.Add(New MailAddress(assignedEngineerEmail))
            For Each tempEmails As MailAddress In listofEmailAddresses
                theEmail.From = New MailAddress("relay@ushersm.com")
                theEmail.To.Add(tempEmails)
                theEmail.Subject = "" & ECRNumber & " has been modified by: " & assignedEngineer & " "
                theEmail.IsBodyHtml = False
                theEmail.Body = "Do not reply to this email." +
                Environment.NewLine + " " +
                Environment.NewLine + " Status: " & currentStatus & "" +
                Environment.NewLine + " Date Created: " & dateCreated & "" +
                Environment.NewLine + " Date Finished: " & Now & "" +
                Environment.NewLine + " Created by: " & creatorFullName & "" +
                Environment.NewLine + " Engineer: " & assignedEngineer & "" +
                Environment.NewLine + " " +
                Environment.NewLine + " ECR Subject: " & ecrSubject & "" +
                Environment.NewLine + " Reference: " & reference & "" +
                Environment.NewLine + " Description / Comments: " & descrComments & "" +
                Environment.NewLine + " " +
                Environment.NewLine + " "
                Smtp_Server.Send(theEmail)
                theEmail.To.Clear()
                '-- send email
            Next
        End If

    End Sub

    Public Sub SendEmailECRReassignment()
        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim ECRNumber As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim loggedInEngineer As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim loggedInEngineerEmail As String = ManagerForm.lblUserEmailMainForm.Text
        Dim assignedEngineer As String = ManagerForm.cboEngineerECREditItemsPage.Text
        Dim assignedEngineerEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim creatorEmailAddress As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim creatorFullName As String = ManagerForm.lblRequestorECREditItemsPage.Text
        Dim ecrSubject As String = ManagerForm.txtECRSubjectECREditItemsPage.Text
        Dim reference As String = ManagerForm.txtDocNumECREditItemsPage.Text
        Dim descrComments As String = ManagerForm.txtDescriptionECREditItemsPage.Text
        Dim dateCreated As String = ManagerForm.lblDateCreatedECREditItemsPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedECREditItemsPage.Text
        Dim currentStatus As String = ManagerForm.cboStatusECREditItemsPage.Text
        ' Dim emailAddress As String = ManagerForm.lblEngineerEmailMainPage.Text
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"
        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add(assignedEngineerEmail)
        theEmail.Subject = "" & ECRNumber & " has been assigned to you by: " & loggedInEngineer & " "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
        Environment.NewLine + " " +
        Environment.NewLine + " Status: " & currentStatus & "" +
        Environment.NewLine + " Date Created: " & dateCreated & "" +
        Environment.NewLine + " Date Finished: " & Now & "" +
        Environment.NewLine + " Created by: " & creatorFullName & "" +
        Environment.NewLine + " Engineer: " & assignedEngineer & "" +
        Environment.NewLine + " " +
        Environment.NewLine + " ECR Subject: " & ecrSubject & "" +
        Environment.NewLine + " Reference: " & reference & "" +
        Environment.NewLine + " Description / Comments: " & descrComments & "" +
        Environment.NewLine + " " +
        Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()
        '-- send email
    End Sub

    Public Sub SendEmailECRStatusToAssignedEngineer()
        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim ECRNumber As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim loggedInEngineer As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim loggedInEngineerEmail As String = ManagerForm.lblUserEmailMainForm.Text
        Dim assignedEngineer As String = ManagerForm.cboEngineerECREditItemsPage.Text
        Dim assignedEngineerEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim creatorEmailAddress As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim creatorFullName As String = ManagerForm.lblRequestorECREditItemsPage.Text
        Dim ecrSubject As String = ManagerForm.txtECRSubjectECREditItemsPage.Text
        Dim reference As String = ManagerForm.txtDocNumECREditItemsPage.Text
        Dim descrComments As String = ManagerForm.txtDescriptionECREditItemsPage.Text
        Dim dateCreated As String = ManagerForm.lblDateCreatedECREditItemsPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedECREditItemsPage.Text
        Dim currentStatus As String = ManagerForm.cboStatusECREditItemsPage.Text
        ' Dim emailAddress As String = ManagerForm.lblEngineerEmailMainPage.Text
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"
        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add(assignedEngineerEmail)
        theEmail.Subject = "" & ECRNumber & " has been modified by: " & loggedInEngineer & " "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
        Environment.NewLine + " " +
        Environment.NewLine + " Status: " & currentStatus & "" +
        Environment.NewLine + " Date Created: " & dateCreated & "" +
        Environment.NewLine + " Date Finished: " & Now & "" +
        Environment.NewLine + " Created by: " & creatorFullName & "" +
        Environment.NewLine + " Engineer: " & assignedEngineer & "" +
        Environment.NewLine + " " +
        Environment.NewLine + " ECR Subject: " & ecrSubject & "" +
        Environment.NewLine + " Reference: " & reference & "" +
        Environment.NewLine + " Description / Comments: " & descrComments & "" +
        Environment.NewLine + " " +
        Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()
        '-- send email
    End Sub

    Public Sub SendeMail_FinishedECRFromAnotherEngineer()
        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim ECRNumber As String = ManagerForm.lblEcrNumECREditItemsPage.Text
        Dim loggedInEngineer As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim loggedInEngineerEmail As String = ManagerForm.lblUserEmailMainForm.Text
        Dim assignedEngineer As String = ManagerForm.cboEngineerECREditItemsPage.Text
        Dim assignedEngineerEmail As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim creatorEmailAddress As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim creatorFullName As String = ManagerForm.lblRequestorECREditItemsPage.Text
        Dim ecrSubject As String = ManagerForm.txtECRSubjectECREditItemsPage.Text
        Dim reference As String = ManagerForm.txtDocNumECREditItemsPage.Text
        Dim descrComments As String = ManagerForm.txtDescriptionECREditItemsPage.Text
        Dim dateCreated As String = ManagerForm.lblDateCreatedECREditItemsPage.Text
        Dim dateFinished As String = ManagerForm.lblDateFinishedECREditItemsPage.Text
        Dim currentStatus As String = ManagerForm.cboStatusECREditItemsPage.Text
        ' Dim emailAddress As String = ManagerForm.lblEngineerEmailMainPage.Text
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"
        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add(assignedEngineerEmail)
        theEmail.Subject = "Your assigned: " & ECRNumber & " has been finished by: " & loggedInEngineer & " "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
        Environment.NewLine + " " +
        Environment.NewLine + " Status: " & currentStatus & "" +
        Environment.NewLine + " Date Created: " & dateCreated & "" +
        Environment.NewLine + " Date Finished: " & Now & "" +
        Environment.NewLine + " Created by: " & creatorFullName & "" +
        Environment.NewLine + " Engineer: " & assignedEngineer & "" +
        Environment.NewLine + " " +
        Environment.NewLine + " ECR Subject: " & ecrSubject & "" +
        Environment.NewLine + " Reference: " & reference & "" +
        Environment.NewLine + " Description / Comments: " & descrComments & "" +
        Environment.NewLine + " " +
        Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()
        '-- send email
    End Sub

    Public Sub SendEmail_ToNewOwner()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        'Dim listofEmailAddresses As New List(Of MailAddress)
        'listofEmailAddresses.Add(New MailAddress(ManagerForm.lbluser_email.Text))
        'listofEmailAddresses.Add(New MailAddress(ManagerForm.lblowners_email.Text))

        Dim emailAddress As String = ManagerForm.lblItemOwnersEmailMainPage.Text

        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add(emailAddress)
        theEmail.Subject = "New ECR item created: " & ManagerForm.lblECRNumNewECRPage.Text & " "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
            Environment.NewLine + " New ECR item has been created and assigned to you." +
            Environment.NewLine + " Created by: " & ManagerForm.lblUserFullNameMainForm.Text & "" +
            Environment.NewLine + " " +
            Environment.NewLine + " Date Created: " & Now & "" +
            Environment.NewLine + " ECR Subject: " & ManagerForm.txtAddEcrSubjectNewECRPage.Text & "" +
            Environment.NewLine + " Reference documentation if any: " & ManagerForm.txtAddEcrDocNumNewECRPage.Text & "" +
            Environment.NewLine + " Description: " & ManagerForm.txtAddCommentsNewECRPage.Text & "" +
            Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()
        '-- send email

    End Sub

    Public Sub SendeMail_UpdateActionItem()

        Dim Smtp_Server As New SmtpClient
        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        Dim taskActionItem As String = ManagerForm.lblTaskActionItemPage.Text
        Dim referenceActionItem As String = ManagerForm.lblReferenceActionItemPage.Text
        Dim stateActionItem As String = ManagerForm.cboStateActionItemPage.Text
        Dim dateCreated As String = ManagerForm.lblDateCreatedActionItemPage.Text
        Dim statusActionItem As String = ManagerForm.cboStatusActionItemPage.Text
        Dim notesActionItems As String = ManagerForm.txtNotesActionItemPage.Text
        Dim creatorOfActionItem As String = ManagerForm.lblCreatedByActionItemsPage.Text
        Dim creatorEmailActionItem As String = ManagerForm.lblRequestorEmailMainPage.Text
        Dim ownerSelectedActionItem As String = ManagerForm.cboOwnerActionItemPage.Text
        Dim loggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim dateDue As Date = ManagerForm.DateTimePicker2.Value.ToString

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

        Dim newDataSet As New DataSet
        'Grabbing the newly assigned owner's email from here
        sqlstr = "SELECT * FROM (SELECT id as ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype as Type, emplid AS EmployeeID" &
            " FROM useraccounts) base WHERE FullName = '" & ManagerForm.cboOwnerActionItemPage.Text & "'"
        sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
        sqlda.Fill(newDataSet, "ucrms")
        newOwnerEmailActionItem = newDataSet.Tables("ucrms").Rows(0).Item(4)
        'MsgBox(newOwnerEmailActionItem)

        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        Dim addressFrom As MailAddress = New MailAddress("relay@ushersm.com", "Engineering Action Items")
        'Dim addressTo As MailAddress = New MailAddress(ownerEmailActionItem)
        Dim newAddressTo As MailAddress = New MailAddress(newOwnerEmailActionItem)
        Dim message As MailMessage = New MailMessage(addressFrom, newAddressTo)
        message.IsBodyHtml = True


        If loggedInUser <> ownerSelectedActionItem And ownerOfCurrentActionItem <> ownerSelectedActionItem Then
            'Grabbing the newly assigned owner's email from here
            'email to the new assigned owner from another owner
            message.Subject = "Action Item: " & actionItemNum & " has been re-assigned to you by " & loggedInUser & ". "

        ElseIf loggedInUser <> ownerSelectedActionItem And ownerOfCurrentActionItem = "" Then
            'email to the new assigned owner on a new Action Item
            message.Subject = "Action Item: " & actionItemNum & " has been assigned to you by " & loggedInUser & ". "

        ElseIf loggedInUser = ownerSelectedActionItem And loggedInUser = ownerOfCurrentActionItem Then
            'email to yourseld after you updated the Action Item
            message.Subject = "Action Item: " & actionItemNum & " updated by " & loggedInUser & ". "

        ElseIf loggedInUser <> ownerOfCurrentActionItem And ownerOfCurrentActionItem = ownerSelectedActionItem And loggedInUser <> ownerSelectedActionItem Then
            'email to the new assigned owner from another owner
            message.Subject = "Action Item: " & actionItemNum & " has been edited or re-assigned to you by " & loggedInUser & ". "

        ElseIf loggedInUser = ownerSelectedActionItem And ownerOfCurrentActionItem = "" Then
            'email to yourself after assigning the Action Item to yourself
            message.Subject = "You have assigned Action Item: " & actionItemNum & " to yourself. "



        ElseIf loggedInUser <> ownerSelectedActionItem And loggedInUser <> ownerOfCurrentActionItem Then
            'email to the owner that someone updated the Action Item
            message.Subject = "Your Action Item: " & actionItemNum & " has been edited by " & loggedInUser & ". "

        End If

        Dim htmlString As String = "<html>
                                    <body>
                                    <h1>Do Not reply to this email.</h1>
                                    <br>Date Created: " & dateCreated & "</br>
                                    <br>Date Due: " & dateDue & "</br>
                                    <br>Date Updated: " & Now & "</br>
                                    <br>Task: " & taskActionItem & "</br>
                                    <br>Reference: " & referenceActionItem & "</br>
                                    <br>State: " & stateActionItem & "</br>
                                    <br>Status: " & statusActionItem & "</br>
                                    <br>Notes: " & notesActionItems & "</br>
                                    <p></p>
                                    <p><font size=2><font color = #000080>NOTICE OF CONFIDENTIALITY: 
                                    This message and any attachments are for the sole use of the intended recipient(s) or authorized agent(s) 
                                    only and may contain confidential and/or legally privileged information. Any unauthorized view, use, disclosure 
                                    or distribution is expressly prohibited. If you are not the intended recipient, you are strictly prohibited 
                                    from disclosing, copying, distributing or using any or all of this communication. Please contact the sender 
                                    at 864 516-2690 immediately and destroy this message and all copies in any form.</font></p>
                                    
                                    </body>
                                    </html>"
        message.Body = htmlString
        Smtp_Server.Send(message)
        'MsgBox("Sent Successfully!")
        newsqlconn.Close()

    End Sub

    Public Sub SendeMail_FinishedActionItems()
        Dim Smtp_Server As New SmtpClient
        Dim actionItemNum As String = ManagerForm.lblActionItemsWorkPage.Text
        Dim taskActionItem As String = ManagerForm.lblTaskActionItemPage.Text
        Dim referenceActionItem As String = ManagerForm.lblReferenceActionItemPage.Text
        Dim stateActionItem As String = ManagerForm.cboStateActionItemPage.Text
        Dim dateCreated As String = ManagerForm.lblDateCreatedActionItemPage.Text
        Dim statusActionItem As String = ManagerForm.cboStatusActionItemPage.Text
        Dim notesActionItems As String = ManagerForm.txtNotesActionItemPage.Text
        Dim creatorOfActionItem As String = ManagerForm.lblCreatedByActionItemsPage.Text
        Dim ownerSelectedActionItem As String = ManagerForm.cboOwnerActionItemPage.Text
        Dim loggedInUser As String = ManagerForm.lblUserFullNameMainForm.Text
        Dim loggedInUserEmail As String = ManagerForm.lblUserEmailMainForm.Text
        Dim dateDue As Date = ManagerForm.DateTimePicker2.Value.ToString

        Dim ownerEmailActionItem As String
        Dim ownerOfCurrentActionItem As String
        Dim newOwnerEmailActionItem As String
        Dim creatorEmailActionItem As String
        Dim sqldatatable As New DataTable
        Dim SQLAdapter As New SqlDataAdapter
        Dim sqlstr As String
        Dim myDataSet As New DataSet

        Dim newsqlconn As New SqlConnection(connstring)
        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        sqlstr = "SELECT ActionItemNum, Owner, OwnerEmail, CreatorEmail FROM ActionItemsDet " &
        " WHERE ActionItemNum ='" & actionItemNum & "'"
        sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
        sqlda.Fill(myDataSet, "ucrms")
        ownerOfCurrentActionItem = myDataSet.Tables("ucrms").Rows(0).Item(1)
        ownerEmailActionItem = myDataSet.Tables("ucrms").Rows(0).Item(2)
        creatorEmailActionItem = myDataSet.Tables("ucrms").Rows(0).Item(3)

        Dim newDataSet As New DataSet
        'Grabbing the newly assigned owner's email from here
        sqlstr = "SELECT * FROM (SELECT id as ID, firstname, lastname, CONCAT_WS(' ', firstname, lastname) as FullName, useremail, usertype as Type, emplid AS EmployeeID" &
            " FROM useraccounts) base WHERE FullName = '" & ManagerForm.cboOwnerActionItemPage.Text & "'"
        sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
        sqlda.Fill(newDataSet, "ucrms")
        newOwnerEmailActionItem = newDataSet.Tables("ucrms").Rows(0).Item(4)
        'MsgBox(newOwnerEmailActionItem)

        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        Dim listofEmailAddresses As New List(Of MailAddress)
        'listofEmailAddresses.Add(New MailAddress(creatorEmailActionItem))
        listofEmailAddresses.Add(New MailAddress(creatorEmailActionItem))
        listofEmailAddresses.Add(New MailAddress(loggedInUserEmail))


        For Each tempEmails As MailAddress In listofEmailAddresses

            Dim message As New MailMessage()
            'Dim addressFrom As MailAddress = New MailAddress("relay@ushersm.com", "Engineering Action Items")
            'Dim AddressTo As MailAddress = New MailAddress(tempEmails)
            'Dim message As MailMessage = New MailMessage(addressFrom, tempEmails)

            message.From = New MailAddress("relay@ushersm.com")
            Message.To.Add(tempEmails)

            Message.IsBodyHtml = True

            If loggedInUser = ownerSelectedActionItem And loggedInUser = ownerOfCurrentActionItem Then
                'email to the new assigned owner from another owner
                message.Subject = "You have finished Action Item: " & actionItemNum & ". "

            ElseIf loggedInUser <> ownerSelectedActionItem And loggedInUser <> ownerOfCurrentActionItem Then
                'email to the new assigned owner on a new Action Item
                message.Subject = "Your Assigned Action Item: " & actionItemNum & " has been marked FINISHED by " & loggedInUser & ". "

            ElseIf loggedInUser = ownerSelectedActionItem And ownerSelectedActionItem <> ownerOfCurrentActionItem Then
                'email to yourseld after you updated the Action Item
                message.Subject = "Action Item: " & actionItemNum & " was re-assigned to " & ownerSelectedActionItem & ". "

            ElseIf loggedInUser <> ownerSelectedActionItem And ownerSelectedActionItem <> ownerOfCurrentActionItem Then
                'email to the new assigned owner from another owner
                message.Subject = "Action Item: " & actionItemNum & " has been assigned to you as Finished by: " & loggedInUser & ". "

            End If

            Dim htmlString As String = "<html>
                                    <body>
                                    <h1>Do Not reply to this email.</h1>
                                    <br>Date Created: " & dateCreated & "</br>
                                    <br>Date Due: " & dateDue & "</br>
                                    <br>Date Finished: " & Now & "</br>
                                    <br>Task: " & taskActionItem & "</br>
                                    <br>Reference: " & referenceActionItem & "</br>
                                    <br>State: " & stateActionItem & "</br>
                                    <br>Status: " & statusActionItem & "</br>
                                    <br>Notes: " & notesActionItems & "</br>
                                    <p></p>
                                    <p><font size=2><font color = #000080>NOTICE OF CONFIDENTIALITY: 
                                    This message and any attachments are for the sole use of the intended recipient(s) or authorized agent(s) 
                                    only and may contain confidential and/or legally privileged information. Any unauthorized view, use, disclosure 
                                    or distribution is expressly prohibited. If you are not the intended recipient, you are strictly prohibited 
                                    from disclosing, copying, distributing or using any or all of this communication. Please contact the sender 
                                    at 864 516-2690 immediately and destroy this message and all copies in any form.</font></p>
                                    
                                    </body>
                                    </html>"
            message.Body = htmlString
            Smtp_Server.Send(message)
            'MsgBox("Sent Successfully!")
        Next

        newsqlconn.Close()



    End Sub






    Public Sub SendEmail_ToBoth_EditItemsPage()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        Dim listofEmailAddresses As New List(Of MailAddress)
        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblUserEmailMainForm.Text))
        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblItemOwnersEmailMainPage.Text))

        For Each tempEmails As MailAddress In listofEmailAddresses
            theEmail.From = New MailAddress("relay@ushersm.com")
            theEmail.To.Add(tempEmails)
            theEmail.Subject = "Action Item: " & ManagerForm.lblEcrNumECREditItemsPage.Text & " Is " & ManagerForm.cboStatusECREditItemsPage.Text & " . "
            theEmail.IsBodyHtml = False
            theEmail.Body = "Do Not reply to this email." +
                    Environment.NewLine + " Status: " & ManagerForm.cboStatusECREditItemsPage.Text & "" +
                    Environment.NewLine + " Created by: " & ManagerForm.lblRequestorECREditItemsPage.Text & "" +
                    Environment.NewLine + " Assigned to: " & ManagerForm.lblAssignedToFullNameMainPage.Text & "" +
                    Environment.NewLine + " " +
                    Environment.NewLine + " Date Created: " & ManagerForm.lblDateCreatedECREditItemsPage.Text & "" +
                    Environment.NewLine + " Date Assigned: " & Now & "" +
                    Environment.NewLine + " Item: " & ManagerForm.txtECRSubjectECREditItemsPage.Text & "" +
                    Environment.NewLine + " Reference Doc: " & ManagerForm.txtDocNumECREditItemsPage.Text & "" +
                    Environment.NewLine + " Comments: " & ManagerForm.txtDescriptionECREditItemsPage.Text & "" +
                    Environment.NewLine + " "
            Smtp_Server.Send(theEmail)
            theEmail.To.Clear()
            '-- send email
        Next



    End Sub

    Public Sub SendEmailCreators_NewRequestOpSheetChanges()
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

        Dim sqlstr As String
        Dim actionitemnumber As String
        Dim myDataSet As New DataSet

        sqlstr = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECR_Number FROM  tblauto WHERE ID = 2"
        sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
        'newsqlconn.Open()
        sqlda.Fill(myDataSet, "ucrms")
        actionitemnumber = myDataSet.Tables("ucrms").Rows(0).Item(2)
        'ManagerForm.lblReqNum.Text = reqItemNumber

        'MessageBox.Show(reader.GetInt32(0) & vbTab & reader.GetString(1))
        Dim emailAddress As String = ManagerForm.lblUserEmailMainForm.Text
        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add(emailAddress)
        theEmail.Subject = "Your RAILS #: " & ManagerForm.lblActionItemsNewPage.Text & " . "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
                            Environment.NewLine + " " +
                            Environment.NewLine + " Date Created: " & Now & "" +
                            Environment.NewLine + " Status: New " +
                            Environment.NewLine + " Plan ID: " & ManagerForm.txtAddTaskActionItemsPage.Text & "" +
                            Environment.NewLine + " Operation: " & ManagerForm.txtAddReferenceActionItemsPage.Text & "" +
                            Environment.NewLine + " Issue Type: " & ManagerForm.cboAddStateActionItemsPage.Text & "" +
                            Environment.NewLine + " Notes: " & ManagerForm.txtAddNotesActionItemsPage.Text & "" +
                            Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()

        newsqlconn.Close()

    End Sub

    Public Sub SendEmailEngineering_NewRequestOpSheetChange()
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

        Dim sqldatatable As New DataTable
        Dim SQLAdapter As New SqlDataAdapter
        Dim sqlstr As String
        Dim reqItemNumber As String
        Dim myDataSet As New DataSet

        sqlstr = "SELECT appendchar, autoend, CONCAT_WS('-',appendchar,autoend) AS ECR_Number FROM  tblauto WHERE ID = 2"
        sqlda = New SqlDataAdapter(sqlstr, newsqlconn)
        'newsqlconn.Open()
        sqlda.Fill(myDataSet, "ucrms")
        reqItemNumber = myDataSet.Tables("ucrms").Rows(0).Item(2)
        'ManagerForm.lblReqNum.Text = reqItemNumber


        Using newsqlconn
            Dim command As SqlCommand = New SqlCommand("SELECT id, user_mail, usertype FROM ucrms.useraccounts WHERE usertype = 'Engineer';", newsqlconn)
            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                Do While reader.Read()
                    'MessageBox.Show(reader.GetInt32(0) & vbTab & reader.GetString(1))
                    Dim emailAddresses As String = reader.GetString(1)
                    theEmail.From = New MailAddress("relay@ushersm.com")
                    theEmail.To.Add(emailAddresses)
                    theEmail.Subject = "New Request Number: " & ManagerForm.lblActionItemsNewPage.Text & " . "
                    theEmail.IsBodyHtml = False
                    theEmail.Body = "Do not reply to this email." +
                            Environment.NewLine + " Status: New " +
                            Environment.NewLine + " Created by: " & ManagerForm.lblUserFullNameMainForm.Text & "" +
                            Environment.NewLine + " " +
                            Environment.NewLine + " Date Created: " & Now & "" +
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

    Public Sub SendEmail_ToBoth_RequestedOpSheetChange()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        Dim listofEmailAddresses As New List(Of MailAddress)
        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblUserEmailMainForm.Text)) 'Engineer's email will go here
        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblRequestorEmailMainPage.Text)) ' Creator's email will go here

        For Each tempEmails As MailAddress In listofEmailAddresses
            theEmail.From = New MailAddress("relay@ushersm.com")
            theEmail.To.Add(tempEmails)
            theEmail.Subject = "Request Number: " & ManagerForm.lblActionItemsWorkPage.Text & " is " & ManagerForm.cboStateActionItemPage.Text & " . "
            theEmail.IsBodyHtml = False
            theEmail.Body = "Do not reply to this email." +
                    Environment.NewLine + " Status: " & ManagerForm.cboStateActionItemPage.Text & "" +
                    Environment.NewLine + " Created by: " & ManagerForm.lblCreatedByActionItemsPage.Text & "" +
                    Environment.NewLine + " Assigned to: " & ManagerForm.cboOwnerActionItemPage.Text & "" +
                    Environment.NewLine + " " +
                    Environment.NewLine + " Date Created: " & ManagerForm.lblDateCreatedActionItemPage.Text & "" +
                    Environment.NewLine + " Date Updatd: " & Now & "" +
                    Environment.NewLine + " Plan ID: " & ManagerForm.txtplanid_RequestOPChangePage.Text & "" +
                    Environment.NewLine + " Operation: " & ManagerForm.txtReferenceActionItemPage.Text & "" +
                    Environment.NewLine + " Issue Type: " & ManagerForm.cboStatusActionItemPage.Text & "" +
                    Environment.NewLine + " Notes: " & ManagerForm.txtNotesActionItemPage.Text & "" +
                    Environment.NewLine + " "
            Smtp_Server.Send(theEmail)
            theEmail.To.Clear()
            '-- send email
        Next

    End Sub

    Public Sub SendEmail_ToBoth_RequestedOpSheetChangeFinished()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        Dim listofEmailAddresses As New List(Of MailAddress)
        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblUserEmailMainForm.Text))
        listofEmailAddresses.Add(New MailAddress(ManagerForm.lblRequestorEmailMainPage.Text))

        For Each tempEmails As MailAddress In listofEmailAddresses
            theEmail.From = New MailAddress("relay@ushersm.com")
            theEmail.To.Add(tempEmails)
            theEmail.Subject = "Request Number: " & ManagerForm.lblActionItemsWorkPage.Text & " is " & ManagerForm.cboStateActionItemPage.Text & " . "
            theEmail.IsBodyHtml = False
            theEmail.Body = "Do not reply to this email." +
                    Environment.NewLine + " Status: " & ManagerForm.cboStateActionItemPage.Text & "" +
                    Environment.NewLine + " Requested by: " & ManagerForm.lblCreatedByActionItemsPage.Text & "" +
                    Environment.NewLine + " Engineer: " & ManagerForm.cboOwnerActionItemPage.Text & "" +
                    Environment.NewLine + " " +
                    Environment.NewLine + " Date Created: " & ManagerForm.lblDateCreatedActionItemPage.Text & "" +
                    Environment.NewLine + " Date Finished: " & Now & "" +
                    Environment.NewLine + " Plan ID: " & ManagerForm.txtplanid_RequestOPChangePage.Text & "" +
                    Environment.NewLine + " Operation: " & ManagerForm.txtReferenceActionItemPage.Text & "" +
                    Environment.NewLine + " Issue Type: " & ManagerForm.cboStatusActionItemPage.Text & "" +
                    Environment.NewLine + " Notes: " & ManagerForm.txtNotesActionItemPage.Text & "" +
                    Environment.NewLine + " "
            Smtp_Server.Send(theEmail)
            theEmail.To.Clear()
            '-- send email
        Next

    End Sub

    Public Sub SendEmail_RequestorCommentResponse()

        Dim Smtp_Server As New SmtpClient
        Dim theEmail As New MailMessage()
        Dim requestNum As String = ManagerForm.lblitemnum_viewopsheetchange.Text
        Dim emailAddress As String = ManagerForm.lblItemOwnersEmailMainPage.Text
        Dim requester As String = ManagerForm.lblcreator__viewopsheetchanges.Text

        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Port = 25
        Smtp_Server.EnableSsl = False
        Smtp_Server.Host = "ushers-apps-02.umt.local"

        theEmail.From = New MailAddress("relay@ushersm.com")
        theEmail.To.Add(emailAddress)
        theEmail.Subject = "Response from " & requester & ", on " & requestNum & ". "
        theEmail.IsBodyHtml = False
        theEmail.Body = "Do not reply to this email." +
                            Environment.NewLine + " Status: " & ManagerForm.lblstatus__viewopsheetchanges.Text & "" +
                            Environment.NewLine + " Created by: " & ManagerForm.lblcreator__viewopsheetchanges.Text & "" +
                            Environment.NewLine + " " +
                            Environment.NewLine + " Date Created: " & ManagerForm.lbldatestampin_viewopsheetchanges.Text & "" +
                            Environment.NewLine + " Request #: " & ManagerForm.lblitemnum_viewopsheetchange.Text & "" +
                            Environment.NewLine + " Plan ID: " & ManagerForm.lblplanid__viewopsheetchanges.Text & "" +
                            Environment.NewLine + " Operation: " & ManagerForm.lbloperation__viewopsheetchanges.Text & "" +
                            Environment.NewLine + " Comments: " & ManagerForm.txtaddcomments_viewoppage.Text & "" +
                            Environment.NewLine + " "
        Smtp_Server.Send(theEmail)
        theEmail.To.Clear()

    End Sub
#End Region



End Class
