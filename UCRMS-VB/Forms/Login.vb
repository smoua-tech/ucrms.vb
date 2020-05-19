Imports System.DirectoryServices
Imports System.Deployment
Imports MetroFramework.Forms.MetroForm

Public Class Login
    Inherits MetroFramework.Forms.MetroForm
    Dim publicvariables As New publicvariables
    Dim StatementsSQL As New StatementsSQL

    Public Sub Btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

        Dim isauthenticated As Boolean = AuthenticateUser()
        Dim isauthenticatedUsers As Boolean = AuthenticateUserUsers()

        If isauthenticated Then
            StatementsSQL.LogInToMainForm()
            StatementsSQL.CheckUsertypeAccounts()

        ElseIf isauthenticatedUsers Then
            publicvariables.LogInUsersMainForm()
            StatementsSQL.CheckUsertypeAccounts()

        Else
            MsgBox("You have not been approved to log in to the system, please contact your manager.")
        End If

    End Sub



    Public Sub Btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Public Function AuthenticateUser() As Boolean
        Dim username As String = txtusername.Text
        Dim ADpassword As String = txtpassword.Text
        Dim domain As String = "umt.local"
        Dim _path As String = "umt\"
        Dim groupSecurityCheck As String = "UCRMS-Users"
        Dim isAuthenticated As Boolean = Check_If_Member_Of_AD_Group(username, groupSecurityCheck, domain, ADpassword)
        Return isAuthenticated
    End Function
    Public Function AuthenticateUserUsers() As Boolean
        Dim username As String = txtusername.Text
        Dim ADpassword As String = txtpassword.Text
        Dim domain As String = "umt.local"
        Dim _path As String = "umt\"
        Dim groupUsersCheck As String = "UCRMS-Users"
        Dim isAuthenticatedUsers As Boolean = Check_If_Users_Member_Of_AD_Group(username, groupUsersCheck, domain, ADpassword)
        Return isAuthenticatedUsers
    End Function

    Public Function Check_If_Member_Of_AD_Group(ByVal username As String, ByVal groupSecurityCheck As String,
                                                ByVal domain As String, ByVal ADpassword As String) As Boolean
        'This is a function that receives a username to see if it's a member of a specific group in AD.
        Try

            'If they provided a password, then add it as an argument to the function, AndAlso, 
            'Basically it does not worry about checking the next condition if the first one is not true.
            If (ADpassword <> "") Then
                'Setting up LDAP basic entry string
                Dim EntryString As String
                EntryString = "LDAP://" & domain

                'Dimension DirectoryEntry object 
                Dim myDE As DirectoryEntry

                'The groups returned may have different combinations of lowercase and uppercase, so grouptoCheck lowercase.
                groupSecurityCheck = groupSecurityCheck.ToLower()
                'groupUsersCheck = groupUsersCheck.ToLower()

                'We create a new instance of the Directory Entry Includes login and password
                myDE = New DirectoryEntry(EntryString, username, ADpassword)
                Dim myDirectorySearcher As New DirectorySearcher(myDE)
                'Above we create new instance of a DirectorySearcher We also specify the Directory Entry as an argument.

                myDirectorySearcher.Filter = "sAMAccountName=" & username
                'Above we specify to filter our results where sAMAccountName is equal to our username passed in.
                myDirectorySearcher.PropertiesToLoad.Add("MemberOf")
                'We only care about the MemberOf Properties, and we specify that above.

                Dim myresult As SearchResult = myDirectorySearcher.FindOne()
                'SearchResult is a node in Active Directory that is returned during a search through System.DirectoryServices.DirectorySearcher
                'Above, we dim a myresult object, and assign a node returned from myDirectorySearcher.FindOne()
                'It is rare to see similar login Id's in Active Directory, so no need to call FindAll(), so Instead call FindOne()

                Dim NumberOfGroups As Integer
                NumberOfGroups = myresult.Properties("memberOf").Count() - 1
                'Above we get the number of groups the user is a memberOf, and store it in a variable. It is zero indexed, so we
                'remove 1 so we can loop through it.

                Dim tempString As String 'A temp string that we will use to get only what we need from the MemberOf string property

                While (NumberOfGroups >= 0)
                    tempString = myresult.Properties("MemberOf").Item(NumberOfGroups)
                    tempString = tempString.Substring(0, tempString.IndexOf(",", 0)) 'Set tempString to the first index of "," starting from the zeroth element of itself.
                    tempString = tempString.Replace("CN=", "") 'Remove the "CN=" from the beginning of the string
                    tempString = tempString.ToLower() 'Make all letters lowercase
                    tempString = tempString.Trim() 'Trim any blank characters from the edges

                    If (groupSecurityCheck = tempString) Then

                        GetActiveDirUserDetails(username)
                        'Dim nameFull As String
                        'nameFull = FullName.Text
                        'Me.MainForm = New Main(nameFull)

                        Return True
                    ElseIf (groupSecurityCheck = tempString) Then
                        'logInUserMainForm()
                        GetActiveDirUserDetails(username)
                        Return True
                    End If
                    'If we have a match, the return is true username is a member of grouptoCheck

                    NumberOfGroups = NumberOfGroups - 1
                End While

                'If the code reaches here, there was no match. Return false
                Return False
            Else
                'Message for users when password field is empty.
                MessageBox.Show("Password needed to log in.")
            End If

        Catch ex As Exception
            'MsgBox("Error: " & ex.ToString)

        End Try

    End Function

    Public Function Check_If_Users_Member_Of_AD_Group(ByVal username As String, ByVal groupUsersCheck As String,
                                                ByVal domain As String, ByVal ADpassword As String) As Boolean
        'This is a function that receives a username to see if it's a member of a specific group in AD.
        Try
            'Setting up LDAP basic entry string
            Dim EntryString As String
            EntryString = "LDAP://" & domain

            'Dimension DirectoryEntry object 
            Dim myDE As DirectoryEntry

            'groupAdminCheck = groupAdminCheck.ToLower()
            groupUsersCheck = groupUsersCheck.ToLower()
            'The groups returned may have different combinations of lowercase and uppercase, make grouptoCheck lowercase.

            If (ADpassword <> "") Then
                'If they provided a password, then add it as an argument to the function about AndAlso
                'Basically it does not worry about checking the next condition if the first one is not true.
                myDE = New DirectoryEntry(EntryString, username, ADpassword)
                'Above, create a new instance of the Directory Entry Includes login and password
            Else
                'Else, use the account credentials of the machine making the request. You might not be able to get 
                'away with this if your production server does not have rights to query Active Directory.
                myDE = New DirectoryEntry(EntryString)
                'Above, create a new instance of the Directory Entry Does not include login and password
            End If

            Dim myDirectorySearcher As New DirectorySearcher(myDE)
            'Above we create new instance of a DirectorySearcher We also specify the Directory Entry as an argument.

            myDirectorySearcher.Filter = "sAMAccountName=" & username
            'Above we specify to filter our results where sAMAccountName is equal to our username passed in.
            myDirectorySearcher.PropertiesToLoad.Add("MemberOf")
            'We only care about the MemberOf Properties, and we specify that above.

            Dim myresult As SearchResult = myDirectorySearcher.FindOne()
            'SearchResult is a node in Active Directory that is returned during a search through System.DirectoryServices.DirectorySearcher
            'Above, we dim a myresult object, and assign a node returned from myDirectorySearcher.FindOne()
            'It is rare to see similar login Id's in Active Directory, so no need to call FindAll(), so Instead call FindOne()

            Dim NumberOfGroups As Integer
            NumberOfGroups = myresult.Properties("memberOf").Count() - 1
            'Above get the number of groups the user is a memberOf, and store it in a variable. It is zero indexed, remove 1 to loop through it.

            Dim tempString As String
            'A temp string that we will use to get only what we need from the MemberOf string property

            While (NumberOfGroups >= 0)
                tempString = myresult.Properties("MemberOf").Item(NumberOfGroups)
                tempString = tempString.Substring(0, tempString.IndexOf(",", 0)) 'Set tempString to the first index of "," starting from the zeroth element of itself.
                tempString = tempString.Replace("CN=", "") 'remove the "CN=" from the beginning of the string
                tempString = tempString.ToLower() 'Make all letters lowercase
                tempString = tempString.Trim()  'Finnally, trim any blank characters from the edges

                If (groupUsersCheck = tempString) Then

                    GetActiveDirUserDetails(username)
                    'Dim nameFull As String
                    'nameFull = FullName.Text
                    'Me.MainForm = New Main(nameFull)

                    Return True
                ElseIf (groupUsersCheck = tempString) Then
                    'logInUserMainForm()
                    GetActiveDirUserDetails(username)
                    Return True
                End If
                'If we have a match, the return is true username is a member of grouptoCheck
                NumberOfGroups = NumberOfGroups - 1
            End While

            'If the code reaches here, there was no match. Return false
            Return False

        Catch ex As Exception
            'MsgBox("Error: " & ex.ToString)

        End Try

    End Function

    Public Sub GetActiveDirUserDetails(ByVal userid As String) 'As String
        Dim dirEntry As System.DirectoryServices.DirectoryEntry
        Dim dirSearcher As System.DirectoryServices.DirectorySearcher
        Dim domainName As String = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName
        Try
            dirEntry = New System.DirectoryServices.DirectoryEntry("LDAP://" & domainName)
            dirSearcher = New System.DirectoryServices.DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(samAccountName=" & userid & ")"

            ' User's first name and last name
            dirSearcher.PropertiesToLoad.Add("name")
            'User's first name
            dirSearcher.PropertiesToLoad.Add("GivenName")
            'User's last name
            dirSearcher.PropertiesToLoad.Add("sn")
            'User's email address
            dirSearcher.PropertiesToLoad.Add("mail")
            'User's employee ID
            dirSearcher.PropertiesToLoad.Add("employeeID")
            'User's employee ID
            dirSearcher.PropertiesToLoad.Add("mailNickname")

            Dim sr As SearchResult = dirSearcher.FindOne()

            If sr Is Nothing Then 'return false if user isn't found 
                'Return False
            End If

            Dim de As System.DirectoryServices.DirectoryEntry = sr.GetDirectoryEntry()
            'Dim userFirstLastName As String
            'Dim MainMenu As New Main
            'Dim user_Email As String
            'userFirstLastName = de.Properties("name").Value.ToString() '& " " & de.Properties("employeeID").Value.ToString()
            lblfullname.Text = de.Properties("name").Value.ToString()
            lblempid.Text = de.Properties("employeeID").Value.ToString()

            If de.Properties("mail").Value = "" Then
                lblemail.Text = "ucrms@ushersm.com"
            Else
                lblemail.Text = de.Properties("mail").Value.ToString()
            End If
            'lblemail.Text = de.Properties("mail").Value.ToString()

            'lblemail.Text = de.Properties("mailNickname").Value.ToString()

            'MainMenu.EmailToolStripMenuItem.Text = de.Properties("mail").Value.ToString()
            'Return userFirstLastName

        Catch ex As Exception ' return false if exception occurs 
            'Return ex.Message
        End Try
    End Sub

    Private Sub FullName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblfullname.TextChanged
        'Dim MainForm As New Main
        'If Not MainForm Is Nothing Then
        '    'MainForm.ValueFromParent = Me.FullName.Text
        'End If
    End Sub

    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is
          Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FlowForm.Show()
    End Sub
End Class
