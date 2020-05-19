Public Class FlowForm
    Private Sub TestResultsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles TestResultsBindingNavigatorSaveItem.Click
        'Me.Validate()
        'Me.TestResultsBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.Ds_LiquidFlow6148)

    End Sub

    Private Sub FlowForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        HideAllGroupBoxes()


    End Sub

    Private Sub HideAllGroupBoxes()
        GroupBox6148Flow.Hide()
        GroupBox6609Airflow.Hide()
        GroupBoxAirFlow6610.Hide()
        GroupBoxLiquidFlow6800.Hide()
        GroupBoxAirFlow6892.Hide()
    End Sub

    Private Sub BtnLoadFlowData_Click(sender As Object, e As EventArgs) Handles BtnLoadFlowData.Click
        Dim RLLiquid6148 As String = "6148-RLFS-LIQFL-WS02"
        Dim RLAirFl6609 As String = "6609-RLFS-AIRFL-WS01"
        Dim GVAirFl6610 As String = "6610-GVFS-AIRFL-WS23"
        Dim GVLiquidFl6800 As String = "6800-GVFS-LIQFL-WS28"
        Dim GVAirFl6892 As String = "6892-GVFS-AIRFL-WS27"
        Dim date1 As Date

        If ComboBoxFlowMachines.Text = RLLiquid6148 Then
            HideAllGroupBoxes()
            GroupBox6148Flow.Dock = DockStyle.Fill
            GroupBox6148Flow.Show()

            'TODO: This line of code loads data into the 'Ds_LiquidFlow6148.TestResults' table. You can move, or remove it, as needed.
            Me.TestResultsTableAdapter.Fill(Me.Ds_LiquidFlow6148.TestResults)

            For i As Integer = 0 To DataGridView6148.Rows.Count - 1
                Dim convertedDate As Date = DataGridView6148.Rows(i).Cells(1).Value
                Dim newdate = DateTime.Parse(convertedDate)
                date1 = CDate(newdate) ' prints 03/03/2019
                DataGridView6148.Rows(i).Cells(1).Value = date1
                'End If
            Next


        ElseIf ComboBoxFlowMachines.Text = RLAirFl6609 Then
            HideAllGroupBoxes()
            GroupBox6609Airflow.Dock = DockStyle.Fill
            GroupBox6609Airflow.Show()

            'TODO: This line of code loads data into the 'Ds_Airflow6609.TestResults' table. You can move, or remove it, as needed.
            Me.TestResultsTableAdapter1.Fill(Me.Ds_Airflow6609.TestResults)

            For i As Integer = 0 To DataGridView6609.Rows.Count - 1
                Dim convertedDate As Date = DataGridView6609.Rows(i).Cells(1).Value
                Dim newdate = DateTime.Parse(convertedDate)
                date1 = CDate(newdate) ' prints 03/03/2019
                DataGridView6609.Rows(i).Cells(1).Value = date1
                'End If
            Next

        ElseIf ComboBoxFlowMachines.Text = GVAirFl6610 Then
            HideAllGroupBoxes()
            GroupBoxAirFlow6610.Dock = DockStyle.Fill
            GroupBoxAirFlow6610.Show()

            'TODO: This line of code loads data into the 'Ds_Airflow6610.TestResults' table. You can move, or remove it, as needed.
            Me.TestResultsTableAdapter2.Fill(Me.Ds_Airflow6610.TestResults)

            For i As Integer = 0 To DataGridView6610.Rows.Count - 1
                Dim convertedDate As Date = DataGridView6610.Rows(i).Cells(1).Value
                Dim newdate = DateTime.Parse(convertedDate)
                date1 = CDate(newdate) ' prints 03/03/2019
                DataGridView6610.Rows(i).Cells(1).Value = date1
                'End If
            Next

        ElseIf ComboBoxFlowMachines.Text = GVLiquidFl6800 Then
            HideAllGroupBoxes()
            GroupBoxLiquidFlow6800.Dock = DockStyle.Fill
            GroupBoxLiquidFlow6800.Show()
            'TODO: This line of code loads data into the 'Ds_Liquidflow6800.TestResults' table. You can move, or remove it, as needed.
            Me.TestResultsTableAdapter3.Fill(Me.Ds_Liquidflow6800.TestResults)

            For i As Integer = 0 To DataGridView6800.Rows.Count - 1
                Dim convertedDate As Date = DataGridView6800.Rows(i).Cells(1).Value
                Dim newdate = DateTime.Parse(convertedDate)
                date1 = CDate(newdate) ' prints 03/03/2019
                DataGridView6800.Rows(i).Cells(1).Value = date1
                'End If
            Next

        ElseIf ComboBoxFlowMachines.Text = GVAirFl6892 Then
            HideAllGroupBoxes()
            GroupBoxAirFlow6892.Dock = DockStyle.Fill
            GroupBoxAirFlow6892.Show()
            'TODO: This line of code loads data into the 'Ds_Airflow6892.TestResults' table. You can move, or remove it, as needed.
            Me.TestResultsTableAdapter4.Fill(Me.Ds_Airflow6892.TestResults)

            For i As Integer = 0 To DataGridView6892.Rows.Count - 1
                Dim convertedDate As Date = DataGridView6892.Rows(i).Cells(1).Value
                Dim newdate = DateTime.Parse(convertedDate)
                date1 = CDate(newdate) ' prints 03/03/2019
                DataGridView6892.Rows(i).Cells(1).Value = date1
                'End If
            Next

        Else

        End If
    End Sub

    Private Sub BtnFilter6148_Click(sender As Object, e As EventArgs) Handles BtnFilter6148.Click
        Dim employeeID As String = OperatorIDTextBox6148.Text
        'Dim passFail As String = PassFailComboBox6148.Text

        Dim passFail As String = PassFailComboBox6148.Text
        'Dim ds As DataSet = Me.GetData()
        Dim dataView As DataView = Ds_LiquidFlow6148.Tables(0).DefaultView

        If Not String.IsNullOrEmpty(passFail) Then
            dataView.RowFilter = "PassFail = '" & passFail & "'"
            dataView.RowFilter = "OperatorID like '" & employeeID & "'"
        End If

        DataGridView6148.DataSource = dataView
    End Sub

    Private Sub BtnRefesh6148_Click(sender As Object, e As EventArgs) Handles BtnRefesh6148.Click
        Dim date1 As Date
        Me.TestResultsTableAdapter.Fill(Me.Ds_LiquidFlow6148.TestResults)

        For i As Integer = 0 To DataGridView6148.Rows.Count - 1
            Dim convertedDate As Date = DataGridView6148.Rows(i).Cells(1).Value
            Dim newdate = DateTime.Parse(convertedDate)
            date1 = CDate(newdate) ' prints 03/03/2019
            DataGridView6148.Rows(i).Cells(1).Value = date1
        Next


        DataGridView6148.DataSource = Ds_LiquidFlow6148.Tables(0).DefaultView
        DataGridView6148.Refresh() 'should redraw with the new data
    End Sub
End Class