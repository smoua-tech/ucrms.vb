<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserAccounts
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox_ListsOfUsers = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox_UserInformationDetails = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmployeeIDManageAccounts = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserNameManageAccounts = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLastNameManageAccounts = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblIDManageAccounts = New System.Windows.Forms.Label()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.cboUserTypeManageAccounts = New System.Windows.Forms.ComboBox()
        Me.txtUserEmailManageAccounts = New System.Windows.Forms.TextBox()
        Me.txtFirstNameManageAccounts = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnLoadManageAccounts = New System.Windows.Forms.Button()
        Me.BtnCreateNewManageAccounts = New System.Windows.Forms.Button()
        Me.BtnSaveManageAccounts = New System.Windows.Forms.Button()
        Me.GroupBox_ManageAccounts = New System.Windows.Forms.GroupBox()
        Me.BtnCreateNewUser = New System.Windows.Forms.Button()
        Me.BtnEditUserAccounts = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCloseManageAccounts = New System.Windows.Forms.Button()
        Me.BtnManageAccounts = New System.Windows.Forms.Button()
        Me.GroupBox_ListsOfUsers.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_UserInformationDetails.SuspendLayout()
        Me.GroupBox_ManageAccounts.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_ListsOfUsers
        '
        Me.GroupBox_ListsOfUsers.Controls.Add(Me.DataGridView2)
        Me.GroupBox_ListsOfUsers.Location = New System.Drawing.Point(371, 53)
        Me.GroupBox_ListsOfUsers.Name = "GroupBox_ListsOfUsers"
        Me.GroupBox_ListsOfUsers.Size = New System.Drawing.Size(676, 290)
        Me.GroupBox_ListsOfUsers.TabIndex = 6
        Me.GroupBox_ListsOfUsers.TabStop = False
        Me.GroupBox_ListsOfUsers.Text = "List of Users"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(670, 271)
        Me.DataGridView2.TabIndex = 0
        '
        'GroupBox_UserInformationDetails
        '
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.Label4)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.txtEmployeeIDManageAccounts)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.Label1)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.txtUserNameManageAccounts)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.Label2)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.txtLastNameManageAccounts)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.Label6)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.lblIDManageAccounts)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.btncancel)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.cboUserTypeManageAccounts)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.txtUserEmailManageAccounts)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.txtFirstNameManageAccounts)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.Label7)
        Me.GroupBox_UserInformationDetails.Controls.Add(Me.Label3)
        Me.GroupBox_UserInformationDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox_UserInformationDetails.Location = New System.Drawing.Point(60, 116)
        Me.GroupBox_UserInformationDetails.Name = "GroupBox_UserInformationDetails"
        Me.GroupBox_UserInformationDetails.Size = New System.Drawing.Size(358, 190)
        Me.GroupBox_UserInformationDetails.TabIndex = 5
        Me.GroupBox_UserInformationDetails.TabStop = False
        Me.GroupBox_UserInformationDetails.Text = "User Information"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Employee ID :"
        '
        'txtEmployeeIDManageAccounts
        '
        Me.txtEmployeeIDManageAccounts.Location = New System.Drawing.Point(104, 30)
        Me.txtEmployeeIDManageAccounts.Name = "txtEmployeeIDManageAccounts"
        Me.txtEmployeeIDManageAccounts.Size = New System.Drawing.Size(234, 22)
        Me.txtEmployeeIDManageAccounts.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Username :"
        '
        'txtUserNameManageAccounts
        '
        Me.txtUserNameManageAccounts.Location = New System.Drawing.Point(104, 56)
        Me.txtUserNameManageAccounts.Name = "txtUserNameManageAccounts"
        Me.txtUserNameManageAccounts.Size = New System.Drawing.Size(234, 22)
        Me.txtUserNameManageAccounts.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "First Name :"
        '
        'txtLastNameManageAccounts
        '
        Me.txtLastNameManageAccounts.Location = New System.Drawing.Point(104, 108)
        Me.txtLastNameManageAccounts.Name = "txtLastNameManageAccounts"
        Me.txtLastNameManageAccounts.Size = New System.Drawing.Size(234, 22)
        Me.txtLastNameManageAccounts.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Email :"
        '
        'lblIDManageAccounts
        '
        Me.lblIDManageAccounts.AutoSize = True
        Me.lblIDManageAccounts.Location = New System.Drawing.Point(11, 202)
        Me.lblIDManageAccounts.Name = "lblIDManageAccounts"
        Me.lblIDManageAccounts.Size = New System.Drawing.Size(19, 16)
        Me.lblIDManageAccounts.TabIndex = 14
        Me.lblIDManageAccounts.Text = "id"
        '
        'btncancel
        '
        Me.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancel.Location = New System.Drawing.Point(6, 257)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(71, 24)
        Me.btncancel.TabIndex = 11
        Me.btncancel.Text = "Close"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'cboUserTypeManageAccounts
        '
        Me.cboUserTypeManageAccounts.FormattingEnabled = True
        Me.cboUserTypeManageAccounts.Items.AddRange(New Object() {"Administrator", "Manager", "Engineer", "Quality", "CMM Operator", "Production", "New", "Users"})
        Me.cboUserTypeManageAccounts.Location = New System.Drawing.Point(104, 156)
        Me.cboUserTypeManageAccounts.Name = "cboUserTypeManageAccounts"
        Me.cboUserTypeManageAccounts.Size = New System.Drawing.Size(234, 24)
        Me.cboUserTypeManageAccounts.TabIndex = 5
        '
        'txtUserEmailManageAccounts
        '
        Me.txtUserEmailManageAccounts.Location = New System.Drawing.Point(104, 132)
        Me.txtUserEmailManageAccounts.Name = "txtUserEmailManageAccounts"
        Me.txtUserEmailManageAccounts.Size = New System.Drawing.Size(234, 22)
        Me.txtUserEmailManageAccounts.TabIndex = 4
        '
        'txtFirstNameManageAccounts
        '
        Me.txtFirstNameManageAccounts.Location = New System.Drawing.Point(104, 84)
        Me.txtFirstNameManageAccounts.Name = "txtFirstNameManageAccounts"
        Me.txtFirstNameManageAccounts.Size = New System.Drawing.Size(234, 22)
        Me.txtFirstNameManageAccounts.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "User  Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Last Name:"
        '
        'BtnLoadManageAccounts
        '
        Me.BtnLoadManageAccounts.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnLoadManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoadManageAccounts.ForeColor = System.Drawing.Color.White
        Me.BtnLoadManageAccounts.Location = New System.Drawing.Point(132, 291)
        Me.BtnLoadManageAccounts.Name = "BtnLoadManageAccounts"
        Me.BtnLoadManageAccounts.Size = New System.Drawing.Size(110, 40)
        Me.BtnLoadManageAccounts.TabIndex = 20
        Me.BtnLoadManageAccounts.Text = "Load"
        Me.BtnLoadManageAccounts.UseVisualStyleBackColor = False
        '
        'BtnCreateNewManageAccounts
        '
        Me.BtnCreateNewManageAccounts.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCreateNewManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCreateNewManageAccounts.ForeColor = System.Drawing.Color.White
        Me.BtnCreateNewManageAccounts.Location = New System.Drawing.Point(255, 291)
        Me.BtnCreateNewManageAccounts.Name = "BtnCreateNewManageAccounts"
        Me.BtnCreateNewManageAccounts.Size = New System.Drawing.Size(110, 40)
        Me.BtnCreateNewManageAccounts.TabIndex = 9
        Me.BtnCreateNewManageAccounts.Text = "Create"
        Me.BtnCreateNewManageAccounts.UseVisualStyleBackColor = False
        '
        'BtnSaveManageAccounts
        '
        Me.BtnSaveManageAccounts.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSaveManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveManageAccounts.ForeColor = System.Drawing.Color.White
        Me.BtnSaveManageAccounts.Location = New System.Drawing.Point(255, 291)
        Me.BtnSaveManageAccounts.Name = "BtnSaveManageAccounts"
        Me.BtnSaveManageAccounts.Size = New System.Drawing.Size(110, 40)
        Me.BtnSaveManageAccounts.TabIndex = 0
        Me.BtnSaveManageAccounts.Text = "Save"
        Me.BtnSaveManageAccounts.UseVisualStyleBackColor = False
        '
        'GroupBox_ManageAccounts
        '
        Me.GroupBox_ManageAccounts.Controls.Add(Me.BtnCreateNewUser)
        Me.GroupBox_ManageAccounts.Controls.Add(Me.BtnEditUserAccounts)
        Me.GroupBox_ManageAccounts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox_ManageAccounts.Location = New System.Drawing.Point(184, 43)
        Me.GroupBox_ManageAccounts.Name = "GroupBox_ManageAccounts"
        Me.GroupBox_ManageAccounts.Size = New System.Drawing.Size(261, 184)
        Me.GroupBox_ManageAccounts.TabIndex = 26
        Me.GroupBox_ManageAccounts.TabStop = False
        Me.GroupBox_ManageAccounts.Text = "Manage Accounts"
        '
        'BtnCreateNewUser
        '
        Me.BtnCreateNewUser.Location = New System.Drawing.Point(53, 112)
        Me.BtnCreateNewUser.Name = "BtnCreateNewUser"
        Me.BtnCreateNewUser.Size = New System.Drawing.Size(162, 52)
        Me.BtnCreateNewUser.TabIndex = 1
        Me.BtnCreateNewUser.Text = "Create New User"
        Me.BtnCreateNewUser.UseVisualStyleBackColor = True
        '
        'BtnEditUserAccounts
        '
        Me.BtnEditUserAccounts.Location = New System.Drawing.Point(53, 36)
        Me.BtnEditUserAccounts.Name = "BtnEditUserAccounts"
        Me.BtnEditUserAccounts.Size = New System.Drawing.Size(162, 52)
        Me.BtnEditUserAccounts.TabIndex = 0
        Me.BtnEditUserAccounts.Text = "Edit User Accounts"
        Me.BtnEditUserAccounts.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox_UserInformationDetails)
        Me.Panel1.Controls.Add(Me.GroupBox_ManageAccounts)
        Me.Panel1.Location = New System.Drawing.Point(8, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(357, 200)
        Me.Panel1.TabIndex = 26
        '
        'BtnCloseManageAccounts
        '
        Me.BtnCloseManageAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCloseManageAccounts.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCloseManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCloseManageAccounts.ForeColor = System.Drawing.Color.White
        Me.BtnCloseManageAccounts.Location = New System.Drawing.Point(934, 358)
        Me.BtnCloseManageAccounts.Name = "BtnCloseManageAccounts"
        Me.BtnCloseManageAccounts.Size = New System.Drawing.Size(110, 40)
        Me.BtnCloseManageAccounts.TabIndex = 2
        Me.BtnCloseManageAccounts.Text = "Close"
        Me.BtnCloseManageAccounts.UseVisualStyleBackColor = False
        '
        'BtnManageAccounts
        '
        Me.BtnManageAccounts.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnManageAccounts.ForeColor = System.Drawing.Color.White
        Me.BtnManageAccounts.Location = New System.Drawing.Point(8, 291)
        Me.BtnManageAccounts.Name = "BtnManageAccounts"
        Me.BtnManageAccounts.Size = New System.Drawing.Size(110, 40)
        Me.BtnManageAccounts.TabIndex = 1
        Me.BtnManageAccounts.Text = "Back"
        Me.BtnManageAccounts.UseVisualStyleBackColor = False
        '
        'UserAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 421)
        Me.Controls.Add(Me.BtnManageAccounts)
        Me.Controls.Add(Me.BtnCloseManageAccounts)
        Me.Controls.Add(Me.BtnLoadManageAccounts)
        Me.Controls.Add(Me.BtnCreateNewManageAccounts)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox_ListsOfUsers)
        Me.Controls.Add(Me.BtnSaveManageAccounts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(235, 211)
        Me.Name = "UserAccounts"
        Me.Text = "User Account Settings"
        Me.GroupBox_ListsOfUsers.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_UserInformationDetails.ResumeLayout(False)
        Me.GroupBox_UserInformationDetails.PerformLayout()
        Me.GroupBox_ManageAccounts.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox_ListsOfUsers As GroupBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents GroupBox_UserInformationDetails As GroupBox
    Friend WithEvents BtnLoadManageAccounts As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLastNameManageAccounts As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnCreateNewManageAccounts As Button
    Friend WithEvents lblIDManageAccounts As Label
    Friend WithEvents btncancel As Button
    Friend WithEvents cboUserTypeManageAccounts As ComboBox
    Friend WithEvents txtUserEmailManageAccounts As TextBox
    Friend WithEvents txtFirstNameManageAccounts As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUserNameManageAccounts As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmployeeIDManageAccounts As TextBox
    Friend WithEvents BtnSaveManageAccounts As Button
    Friend WithEvents GroupBox_ManageAccounts As GroupBox
    Friend WithEvents BtnCreateNewUser As Button
    Friend WithEvents BtnEditUserAccounts As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCloseManageAccounts As Button
    Friend WithEvents BtnManageAccounts As Button
End Class
