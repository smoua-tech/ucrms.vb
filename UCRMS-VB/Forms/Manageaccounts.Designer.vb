<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manageaccounts
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnCreateNewUser = New System.Windows.Forms.Button()
        Me.BtnEditUserAccounts = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnCreateNewUser)
        Me.GroupBox1.Controls.Add(Me.BtnEditUserAccounts)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 219)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage Accounts"
        '
        'BtnCreateNewUser
        '
        Me.BtnCreateNewUser.Location = New System.Drawing.Point(159, 120)
        Me.BtnCreateNewUser.Name = "BtnCreateNewUser"
        Me.BtnCreateNewUser.Size = New System.Drawing.Size(162, 52)
        Me.BtnCreateNewUser.TabIndex = 1
        Me.BtnCreateNewUser.Text = "Create New User"
        Me.BtnCreateNewUser.UseVisualStyleBackColor = True
        '
        'BtnEditUserAccounts
        '
        Me.BtnEditUserAccounts.Location = New System.Drawing.Point(159, 51)
        Me.BtnEditUserAccounts.Name = "BtnEditUserAccounts"
        Me.BtnEditUserAccounts.Size = New System.Drawing.Size(162, 52)
        Me.BtnEditUserAccounts.TabIndex = 0
        Me.BtnEditUserAccounts.Text = "Edit User Accounts"
        Me.BtnEditUserAccounts.UseVisualStyleBackColor = True
        '
        'Manageaccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 247)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Manageaccounts"
        Me.Text = "Manage Accounts"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnCreateNewUser As Button
    Friend WithEvents BtnEditUserAccounts As Button
End Class
