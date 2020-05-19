<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FlowData
    'Inherits System.Windows.Forms.Form
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cboFlowDataWorkOrder = New System.Windows.Forms.ComboBox()
        Me.DateTimePickerStartDate = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerStopDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSearchBar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboOperator = New System.Windows.Forms.ComboBox()
        Me.cboFlowDataPartNum = New System.Windows.Forms.ComboBox()
        Me.cboFlowDataOperationDescr = New System.Windows.Forms.ComboBox()
        Me.cboFlowDataPassFail = New System.Windows.Forms.ComboBox()
        Me.BtnLoadFlowData = New System.Windows.Forms.Button()
        Me.cboFlowMachineName = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.cboFlowDataSerialNum = New System.Windows.Forms.ComboBox()
        Me.BtnTest = New System.Windows.Forms.Button()
        Me.BtnFlowDataSearch = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(5, 349)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1015, 451)
        Me.DataGridView1.TabIndex = 0
        '
        'cboFlowDataWorkOrder
        '
        Me.cboFlowDataWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlowDataWorkOrder.FormattingEnabled = True
        Me.cboFlowDataWorkOrder.Location = New System.Drawing.Point(18, 89)
        Me.cboFlowDataWorkOrder.Name = "cboFlowDataWorkOrder"
        Me.cboFlowDataWorkOrder.Size = New System.Drawing.Size(241, 23)
        Me.cboFlowDataWorkOrder.TabIndex = 5
        '
        'DateTimePickerStartDate
        '
        Me.DateTimePickerStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerStartDate.Location = New System.Drawing.Point(279, 133)
        Me.DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        Me.DateTimePickerStartDate.Size = New System.Drawing.Size(211, 21)
        Me.DateTimePickerStartDate.TabIndex = 6
        '
        'DateTimePickerStopDate
        '
        Me.DateTimePickerStopDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerStopDate.Location = New System.Drawing.Point(279, 177)
        Me.DateTimePickerStopDate.Name = "DateTimePickerStopDate"
        Me.DateTimePickerStopDate.Size = New System.Drawing.Size(211, 21)
        Me.DateTimePickerStopDate.TabIndex = 7
        '
        'txtSearchBar
        '
        Me.txtSearchBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtSearchBar.Location = New System.Drawing.Point(508, 115)
        Me.txtSearchBar.Name = "txtSearchBar"
        Me.txtSearchBar.Size = New System.Drawing.Size(139, 24)
        Me.txtSearchBar.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Work Order"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Operator"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Part Numbers"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Operation Descriptions"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(276, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Pass/Fail"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(276, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Start Time"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(276, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Stop Time"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(276, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Serial Number"
        '
        'cboOperator
        '
        Me.cboOperator.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOperator.FormattingEnabled = True
        Me.cboOperator.Location = New System.Drawing.Point(18, 133)
        Me.cboOperator.Name = "cboOperator"
        Me.cboOperator.Size = New System.Drawing.Size(241, 23)
        Me.cboOperator.TabIndex = 17
        '
        'cboFlowDataPartNum
        '
        Me.cboFlowDataPartNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlowDataPartNum.FormattingEnabled = True
        Me.cboFlowDataPartNum.Location = New System.Drawing.Point(18, 177)
        Me.cboFlowDataPartNum.Name = "cboFlowDataPartNum"
        Me.cboFlowDataPartNum.Size = New System.Drawing.Size(241, 23)
        Me.cboFlowDataPartNum.TabIndex = 18
        '
        'cboFlowDataOperationDescr
        '
        Me.cboFlowDataOperationDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlowDataOperationDescr.FormattingEnabled = True
        Me.cboFlowDataOperationDescr.Location = New System.Drawing.Point(18, 221)
        Me.cboFlowDataOperationDescr.Name = "cboFlowDataOperationDescr"
        Me.cboFlowDataOperationDescr.Size = New System.Drawing.Size(241, 23)
        Me.cboFlowDataOperationDescr.TabIndex = 19
        '
        'cboFlowDataPassFail
        '
        Me.cboFlowDataPassFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlowDataPassFail.FormattingEnabled = True
        Me.cboFlowDataPassFail.Items.AddRange(New Object() {"PASS", "FAIL"})
        Me.cboFlowDataPassFail.Location = New System.Drawing.Point(279, 89)
        Me.cboFlowDataPassFail.Name = "cboFlowDataPassFail"
        Me.cboFlowDataPassFail.Size = New System.Drawing.Size(121, 23)
        Me.cboFlowDataPassFail.TabIndex = 20
        '
        'BtnLoadFlowData
        '
        Me.BtnLoadFlowData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLoadFlowData.BackColor = System.Drawing.Color.DarkCyan
        Me.BtnLoadFlowData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray
        Me.BtnLoadFlowData.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.BtnLoadFlowData.ForeColor = System.Drawing.Color.White
        Me.BtnLoadFlowData.Location = New System.Drawing.Point(508, 20)
        Me.BtnLoadFlowData.Name = "BtnLoadFlowData"
        Me.BtnLoadFlowData.Size = New System.Drawing.Size(115, 40)
        Me.BtnLoadFlowData.TabIndex = 21
        Me.BtnLoadFlowData.Text = "Load"
        Me.BtnLoadFlowData.UseVisualStyleBackColor = False
        '
        'cboFlowMachineName
        '
        Me.cboFlowMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlowMachineName.FormattingEnabled = True
        Me.cboFlowMachineName.Items.AddRange(New Object() {"6148-RLFS-LIQFL-WS02", "6609-RLFS-AIRFL-WS01", "6610-GVFS-AIRFL-WS23", "6800-GVFS-LIQFL-WS28", "6892-GVFS-AIRFL-WS27"})
        Me.cboFlowMachineName.Location = New System.Drawing.Point(279, 37)
        Me.cboFlowMachineName.Name = "cboFlowMachineName"
        Me.cboFlowMachineName.Size = New System.Drawing.Size(211, 23)
        Me.cboFlowMachineName.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(276, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Flow Machine"
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Location = New System.Drawing.Point(12, 259)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(95, 13)
        Me.statusLabel.TabIndex = 28
        Me.statusLabel.Text = "statusLabelDisplay"
        Me.statusLabel.Visible = False
        '
        'cboFlowDataSerialNum
        '
        Me.cboFlowDataSerialNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFlowDataSerialNum.FormattingEnabled = True
        Me.cboFlowDataSerialNum.Location = New System.Drawing.Point(277, 219)
        Me.cboFlowDataSerialNum.Name = "cboFlowDataSerialNum"
        Me.cboFlowDataSerialNum.Size = New System.Drawing.Size(213, 23)
        Me.cboFlowDataSerialNum.TabIndex = 29
        '
        'BtnTest
        '
        Me.BtnTest.BackColor = System.Drawing.Color.DarkCyan
        Me.BtnTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.BtnTest.ForeColor = System.Drawing.Color.White
        Me.BtnTest.Location = New System.Drawing.Point(508, 146)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(115, 40)
        Me.BtnTest.TabIndex = 30
        Me.BtnTest.Text = "Show Test"
        Me.BtnTest.UseVisualStyleBackColor = False
        '
        'BtnFlowDataSearch
        '
        Me.BtnFlowDataSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFlowDataSearch.BackColor = System.Drawing.Color.DarkCyan
        Me.BtnFlowDataSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray
        Me.BtnFlowDataSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.BtnFlowDataSearch.ForeColor = System.Drawing.Color.White
        Me.BtnFlowDataSearch.Location = New System.Drawing.Point(629, 66)
        Me.BtnFlowDataSearch.Name = "BtnFlowDataSearch"
        Me.BtnFlowDataSearch.Size = New System.Drawing.Size(115, 40)
        Me.BtnFlowDataSearch.TabIndex = 31
        Me.BtnFlowDataSearch.Text = "Search"
        Me.BtnFlowDataSearch.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(629, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 40)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "Working Show"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(508, 194)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 35)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(699, 133)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(303, 95)
        Me.ListBox1.TabIndex = 34
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(508, 235)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(115, 37)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FlowData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 846)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnFlowDataSearch)
        Me.Controls.Add(Me.BtnTest)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboFlowDataSerialNum)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboFlowMachineName)
        Me.Controls.Add(Me.BtnLoadFlowData)
        Me.Controls.Add(Me.cboFlowDataPassFail)
        Me.Controls.Add(Me.cboFlowDataOperationDescr)
        Me.Controls.Add(Me.cboFlowDataPartNum)
        Me.Controls.Add(Me.cboOperator)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearchBar)
        Me.Controls.Add(Me.DateTimePickerStopDate)
        Me.Controls.Add(Me.DateTimePickerStartDate)
        Me.Controls.Add(Me.cboFlowDataWorkOrder)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FlowData"
        Me.Text = "FlowData"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cboFlowDataWorkOrder As ComboBox
    Friend WithEvents DateTimePickerStartDate As DateTimePicker
    Friend WithEvents DateTimePickerStopDate As DateTimePicker
    Friend WithEvents txtSearchBar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboOperator As ComboBox
    Friend WithEvents cboFlowDataPartNum As ComboBox
    Friend WithEvents cboFlowDataOperationDescr As ComboBox
    Friend WithEvents cboFlowDataPassFail As ComboBox
    Friend WithEvents BtnLoadFlowData As Button
    Friend WithEvents cboFlowMachineName As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents statusLabel As Label
    Friend WithEvents cboFlowDataSerialNum As ComboBox
    Friend WithEvents BtnTest As Button
    Friend WithEvents BtnFlowDataSearch As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button3 As Button
End Class
