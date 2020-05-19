<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Login
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.lblusertype = New System.Windows.Forms.Label()
        Me.lblfullname = New System.Windows.Forms.Label()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnlogin = New System.Windows.Forms.Button()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.lblempid = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLogInVersion = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblusertype
        '
        Me.lblusertype.AutoSize = True
        Me.lblusertype.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblusertype.Location = New System.Drawing.Point(282, 13)
        Me.lblusertype.Name = "lblusertype"
        Me.lblusertype.Size = New System.Drawing.Size(47, 13)
        Me.lblusertype.TabIndex = 16
        Me.lblusertype.Text = "usertype"
        Me.lblusertype.Visible = False
        '
        'lblfullname
        '
        Me.lblfullname.AutoSize = True
        Me.lblfullname.BackColor = System.Drawing.Color.Transparent
        Me.lblfullname.ForeColor = System.Drawing.Color.Black
        Me.lblfullname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblfullname.Location = New System.Drawing.Point(173, 13)
        Me.lblfullname.Name = "lblfullname"
        Me.lblfullname.Size = New System.Drawing.Size(53, 13)
        Me.lblfullname.TabIndex = 15
        Me.lblfullname.Text = "firstlastnm"
        Me.lblfullname.Visible = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.SteelBlue
        Me.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btncancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue
        Me.btncancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.btncancel.ForeColor = System.Drawing.Color.White
        Me.btncancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btncancel.Location = New System.Drawing.Point(285, 148)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(102, 35)
        Me.btncancel.TabIndex = 14
        Me.btncancel.Text = "&Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btnlogin
        '
        Me.btnlogin.BackColor = System.Drawing.Color.SteelBlue
        Me.btnlogin.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnlogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue
        Me.btnlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue
        Me.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.btnlogin.ForeColor = System.Drawing.Color.White
        Me.btnlogin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnlogin.Location = New System.Drawing.Point(182, 148)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(102, 35)
        Me.btnlogin.TabIndex = 13
        Me.btnlogin.Text = "&Login"
        Me.btnlogin.UseVisualStyleBackColor = False
        '
        'txtpassword
        '
        Me.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpassword.Font = New System.Drawing.Font("Lucida Sans", 12.0!)
        Me.txtpassword.Location = New System.Drawing.Point(175, 103)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(220, 26)
        Me.txtpassword.TabIndex = 12
        '
        'txtusername
        '
        Me.txtusername.BackColor = System.Drawing.Color.White
        Me.txtusername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtusername.Font = New System.Drawing.Font("Lucida Sans", 12.0!)
        Me.txtusername.Location = New System.Drawing.Point(175, 46)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(220, 26)
        Me.txtusername.TabIndex = 11
        '
        'lblemail
        '
        Me.lblemail.AutoSize = True
        Me.lblemail.BackColor = System.Drawing.Color.Transparent
        Me.lblemail.ForeColor = System.Drawing.Color.Black
        Me.lblemail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblemail.Location = New System.Drawing.Point(345, 14)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(25, 13)
        Me.lblemail.TabIndex = 18
        Me.lblemail.Text = "mail"
        Me.lblemail.Visible = False
        '
        'lblempid
        '
        Me.lblempid.AutoSize = True
        Me.lblempid.ForeColor = System.Drawing.Color.Black
        Me.lblempid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblempid.Location = New System.Drawing.Point(235, 14)
        Me.lblempid.Name = "lblempid"
        Me.lblempid.Size = New System.Drawing.Size(37, 13)
        Me.lblempid.TabIndex = 17
        Me.lblempid.Text = "emplid"
        Me.lblempid.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UCRMS.My.Resources.Resources.Email_Sig_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(10, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(173, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 16)
        Me.Label10.TabIndex = 154
        Me.Label10.Text = "Username:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(173, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Password:"
        '
        'lblLogInVersion
        '
        Me.lblLogInVersion.AutoSize = True
        Me.lblLogInVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblLogInVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogInVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblLogInVersion.Location = New System.Drawing.Point(7, 178)
        Me.lblLogInVersion.Name = "lblLogInVersion"
        Me.lblLogInVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblLogInVersion.TabIndex = 156
        Me.lblLogInVersion.Text = "Version"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(285, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 19)
        Me.Button1.TabIndex = 157
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Login
        '
        Me.ClientSize = New System.Drawing.Size(407, 199)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblLogInVersion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblemail)
        Me.Controls.Add(Me.lblempid)
        Me.Controls.Add(Me.lblusertype)
        Me.Controls.Add(Me.lblfullname)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnlogin)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtusername)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblusertype As Label
    Friend WithEvents lblfullname As Label
    Friend WithEvents btncancel As Button
    Friend WithEvents btnlogin As Button
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents txtusername As TextBox

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
            With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                Me.lblLogInVersion.Text = "V" & .Major & "." & .Minor & "." & .Build & "." & .Revision
            End With
        End If
    End Sub

    Friend WithEvents lblemail As Label
    Friend WithEvents lblempid As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblLogInVersion As Label
    Friend WithEvents Button1 As Button
End Class
