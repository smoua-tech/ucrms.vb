Imports System.ComponentModel
Imports System.Threading
Imports System.Data.OleDb
Imports System.Globalization


Public Class FlowData
    Inherits MetroFramework.Forms.MetroForm
    Dim StatementSQL As New StatementsSQL()
    Dim publicvariables As New Publicvariables
    WithEvents bs As New BindingSource
    Dim sqlda As New OleDbDataAdapter
    'Private dtGrd As DataTable
    Dim da As OleDbDataAdapter
    Public sqlquery As String
    Public sqldatatable As DataTable
    Public Event CellMouseEnter As DataGridViewCellEventHandler    
    Public accesstring6148Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
    Public newsqlconn As New OleDbConnection(accesstring6148Liq)


    Protected Shared Sub OnStateChange(sender As Object, args As StateChangeEventArgs)
        MessageBox.Show("The current Connection state has changed from {0} to {1}." & args.OriginalState & args.CurrentState)
    End Sub

    Private Sub FlowData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'dt.Columns.AddRange({New DataColumn With {.ColumnName = "OperatorID", .AutoIncrement = True, .AutoIncrementSeed = 1, .AutoIncrementStep = 1}})
        'DateTimePickerStartDate.Format = DateTimePickerFormat.Custom
        'DateTimePickerStopDate.Format = DateTimePickerFormat.Custom
        'DateTimePickerStartDate.CustomFormat = "MM/dd/yyyy"
        'DateTimePickerStopDate.CustomFormat = "MM/dd/yyyy"

        DateTimePickerStartDate.Value = Format(DateTimePickerStartDate.Value, "MM/dd/yyyy")
        DateTimePickerStopDate.Value = Format(DateTimePickerStopDate.Value, "MM/dd/yyyy")

        'Dim dr As DataRow = dt.NewRow
        'dr(1) = "OperatorID"
        'DataGridView1.DataSource = dt
        'dtGrd = dt

    End Sub


    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
        Dim employeeID As String = cboOperator.Text
        Dim passFail As String = cboFlowDataPassFail.Text

        'Dim accesstring6148Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
        Dim con As New OleDb.OleDbConnection
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
        If con.State = ConnectionState.Closed Then
            con.Open()
        ElseIf con.State = ConnectionState.Open Then
        End If

        Dim dt As New DataTable
        Dim dv As New DataView(dt)

        If Not IsNothing(da) Then
            da.Fill(dt)
            dt.Select("OperatorID = 0")

            dv.RowFilter = "OperatorID = '" & employeeID & "'"
            DataGridView1.DataSource = dv

        End If

        DataGridView1.DataSource = dt
        'DataGridView1.DataBind()


        'Dim ds As DataSet = New DataSet
        'Dim adapter As New OleDb.OleDbDataAdapter
        'Dim sql As String
        'sql = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults"
        'adapter.SelectCommand = New OleDb.OleDbCommand(sql, con)
        'adapter.Fill(ds)
        'DataGridView1.DataSource = ds
        'DataGridView1.DataSource = ds.Tables(0)

        con.Close()

    End Sub

    Private Sub BtnFlowDataSearch_Click(sender As Object, e As EventArgs) Handles BtnFlowDataSearch.Click
        '****************************************
        '**! Working code to filter from the dataset in dgv but only ONE filter
        Dim employeeID As String = cboOperator.Text
        Dim passFail As String = cboFlowDataPassFail.Text
        Dim ds As New DataSet
        Dim dt As DataTable

        dt = TryCast(DataGridView1.DataSource, DataTable)
        'If dt IsNot Nothing Then
        dt.DefaultView.RowFilter = String.Format("OperatorID = '" & employeeID & "'", Trim(cboOperator.Text))
        'dt.DefaultView.RowFilter = String.Format("PassFail = '" & passFail & "'", Trim(cboFlowDataPassFail.Text))
        'End If

    End Sub
    Private Sub HasRows(ByVal connection As OleDbConnection)
        Using connection
            Dim command As OleDbCommand = New OleDbCommand(
          "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults;",
          connection)
            connection.Open()

            Dim reader As OleDbDataReader = command.ExecuteReader()

            If reader.HasRows Then
                Do While reader.Read()
                    Console.WriteLine(reader.GetInt32(0) _
                  & vbTab & reader.GetString(1))
                Loop
            Else
                Console.WriteLine("No rows found.")
            End If

            reader.Close()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        shinedown()
    End Sub

    Dim TestResults As New DataTable

    Private Sub shinedown()
        Dim employeeID As String = cboOperator.Text
        Dim passFail As String = cboFlowDataPassFail.Text
        Dim date1 As Date

        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
        Dim provider As CultureInfo = CultureInfo.InvariantCulture

        Dim sql As String = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults"
        Dim da As New OleDbDataAdapter(sql, connectionString)
        'Dim TestResults = New DataTable()
        'Dim TestResults As New DataTable
        da.Fill(TestResults)


        Dim filter As String = "OperatorID = '" & employeeID & "'"
        Dim FilteredRows As DataRow() = TestResults.Select(filter)


        For Each row As DataRow In FilteredRows
            ListBox1.Items.Add(String.Format("{0},   {1}", row("PartNumber"), row("SerialNumber")))
            DataGridView1.DataSource = FilteredRows.CopyToDataTable()
        Next


    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If cboOperator.Text <> String.Empty AndAlso cboFlowDataPassFail.Text <> String.Empty Then
            '  Define the filter
            Dim filter As String = String.Format("'Empl ID' Like '{0}*' AND 'Pass / Fail' = '{1}'", cboOperator.Text, cboFlowDataPassFail.Text)
            ' Filter the rows using Select() method of DataTable
            Dim FilteredRows As DataRow() = TestResults.Select(filter)

            DataGridView1.DataSource = FilteredRows.CopyToDataTable()

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DemonstrateDataTable()

    End Sub

    Private Sub DemonstrateDataTable()

        Dim connectionString As String
        Dim oledbCnn As OleDbConnection
        Dim oledbCmd As OleDbCommand
        'Dim da As OleDbDataAdapter
        Dim sql As String
        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim date1 As Date

        If cboFlowMachineName.Text = "6148-RLFS-LIQFL-WS02" Then
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
            sql = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults"
            oledbCnn = New OleDbConnection(connectionString)
            oledbCnn.Open()
            oledbCmd = New OleDbCommand(sql, oledbCnn) With {
                .CommandType = CommandType.Text
            }
            Dim da = New OleDbDataAdapter(oledbCmd)
            Dim TestResults = New DataTable()
            da.Fill(TestResults)

            Try
                With DataGridView1
                    .DataSource = TestResults
                    .Columns(0).HeaderText = "Empl ID"
                    .Columns(1).HeaderText = "Part #"
                    .Columns(2).HeaderText = "OP Description"
                    .Columns(3).HeaderText = "Serial #"
                    .Columns(4).HeaderText = "Test Measure Value"
                    .Columns(5).HeaderText = "Actual Set Point"
                    .Columns(6).HeaderText = "Pass / Fail"
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1

                            If DataGridView1.Rows(i).Cells("DateString").Value Is DBNull.Value Then
                                DataGridView1.Rows(i).Cells("DateString").Value = ""
                            Else
                                .Columns("DateString").HeaderText = "Date"
                                Dim convertedDate As Date = DataGridView1.Rows(i).Cells("DateString").Value
                                Dim newdate = DateTime.Parse(convertedDate)
                                date1 = CDate(newdate) ' prints 03/03/2019
                                DataGridView1.Rows(i).Cells("DateString").Value = date1
                                .Columns("TimeString").HeaderText = "Time"
                            End If
                        Next

                    Catch ex As Exception
                        MsgBox("Cannot load FlowData's crappy Date from access: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try

                End With

            Catch ex As Exception
                MsgBox("Can not open connection ! ")
            End Try

            oledbCnn.Close()

        ElseIf cboFlowMachineName.Text = "6609-RLFS-AIRFL-WS01" Then
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6609-RLFS-AIRFL-WS01\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
            sql = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults"
            oledbCnn = New OleDbConnection(connectionString)
            oledbCnn.Open()
            oledbCmd = New OleDbCommand(sql, oledbCnn) With {
                .CommandType = CommandType.Text
            }
            Dim da = New OleDbDataAdapter(oledbCmd)
            Dim TestResults = New DataTable()
            da.Fill(TestResults)

            Try
                With DataGridView1
                    .DataSource = TestResults
                    .Columns(0).HeaderText = "Empl ID"
                    .Columns(1).HeaderText = "Part #"
                    .Columns(2).HeaderText = "OP Description"
                    .Columns(3).HeaderText = "Serial #"
                    .Columns(4).HeaderText = "Test Measure Value"
                    .Columns(5).HeaderText = "Actual Set Point"
                    .Columns(6).HeaderText = "Pass / Fail"
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1

                            If DataGridView1.Rows(i).Cells("DateString").Value Is DBNull.Value Then
                                DataGridView1.Rows(i).Cells("DateString").Value = ""
                            Else
                                .Columns("DateString").HeaderText = "Date"
                                Dim convertedDate As Date = DataGridView1.Rows(i).Cells("DateString").Value
                                Dim newdate = DateTime.Parse(convertedDate)
                                date1 = CDate(newdate) ' prints 03/03/2019
                                DataGridView1.Rows(i).Cells("DateString").Value = date1
                                .Columns("TimeString").HeaderText = "Time"
                            End If
                        Next

                    Catch ex As Exception
                        MsgBox("Cannot load FlowData's crappy Date from access: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try

                End With

            Catch ex As Exception
                MsgBox("Can not open connection ! ")
            End Try

            oledbCnn.Close()

        End If



    End Sub



    Private Sub DemonstrateDataReader()

        Dim connectionString As String
        Dim oledbCnn As OleDbConnection
        Dim oledbCmd As OleDbCommand
        Dim sql As String

        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
        sql = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults"

        oledbCnn = New OleDbConnection(connectionString)
        Try
            oledbCnn.Open()
            oledbCmd = New OleDbCommand(sql, oledbCnn)
            Dim oledbReader As OleDbDataReader = oledbCmd.ExecuteReader()
            While oledbReader.Read
                MsgBox(oledbReader.Item(0) & "  -  " & oledbReader.Item(1) & "  -  " & oledbReader.Item(2))
                'DataGridView1.CurrentRow.Cells(0).Value = oledbReader.Item(0)("OperatorID").ToString()
                'DataGridView1.CurrentRow.Cells(2).Value = oledbReader.Item(1)("PartNumber").ToString()
                'DataGridView1.CurrentRow.Cells(3).Value = oledbReader.Item(2)("OperationDescription").ToString()
                'DataGridView1.CurrentRow.Cells(4).Value = oledbReader.Item(3)("SerialNumber").ToString()
                'DataGridView1.CurrentRow.Cells(5).Value = oledbReader.Item(4)("TestMeasureValue").ToString()
                'DataGridView1.CurrentRow.Cells(6).Value = oledbReader.Item(5)("ActualSetpoint").ToString()
                'DataGridView1.CurrentRow.Cells(7).Value = oledbReader.Item(6)("PassFail").ToString()
                'DataGridView1.CurrentRow.Cells(8).Value = oledbReader.Item(7)("DateString").ToString()
                'DataGridView1.CurrentRow.Cells(9).Value = oledbReader.Item(8)("TimeString").ToString()
            End While
            oledbReader.Close()
            oledbCmd.Dispose()
            oledbCnn.Close()
        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        End Try


    End Sub


    Private Sub DataGridView1ValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        ' Assumes connection represents a SqlConnection object.  
        AddHandler newsqlconn.StateChange, New StateChangeEventHandler(AddressOf OnStateChange)


        If DataGridView1.Columns(e.ColumnIndex).Name = "OperatorID" Then

            'Prevent duplicates
            For i As Integer = 0 To DataGridView1.RowCount - 2
                For j As Integer = i + 1 To DataGridView1.RowCount - 2
                    If DataGridView1.Rows(i).Cells(0).Value = DataGridView1.Rows(j).Cells(0).Value Then
                        'MsgBox(DataGridView1.Rows(j).Cells(0).Value)
                        'DataGridView1.Rows(j).Cells(0).Value = ""
                        'Dim cbx As ComboBox = DataGridView1.EditingControl
                        cboOperator.DisplayMember = "OperatorID"
                        cboOperator.ValueMember = "OperatorID"
                        cboOperator.SelectedIndex = -1
                        cboOperator.Text = DataGridView1.Rows(j).Cells(0).Value
                        Exit Sub
                    End If

                Next
            Next


            Dim accesstring6148Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
            Dim newsqlconn As New OleDbConnection(accesstring6148Liq)

            If newsqlconn.State = ConnectionState.Closed Then
                newsqlconn.Open()
            ElseIf newsqlconn.State = ConnectionState.Open Then
            End If


            Using cmd As New OleDbCommand()

                Dim SQL As String = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults"
                'Dim Concat_SQL As String = " Where "
                'SQL = String.Concat(SQL, Concat_SQL, " ID_NUMBER = :id")
                'cmd.Parameters.Add(New OracleParameter("id", DataGridView1.CurrentRow.Cells(0).Value))
                'cmd.Connection = newsqlconn()
                cmd.CommandText = SQL
                cmd.CommandType = CommandType.Text

                Dim dr As OleDbDataReader = cmd.ExecuteReader()
                Dim dt As New DataTable
                dt.Load(dr)

                DataGridView1.CurrentRow.Cells(1).Value = dt.Rows(0)("OperatorID").ToString()
                DataGridView1.CurrentRow.Cells(2).Value = dt.Rows(0)("PartNumber").ToString()
                DataGridView1.CurrentRow.Cells(3).Value = dt.Rows(0)("OperationDescription").ToString()
                DataGridView1.CurrentRow.Cells(4).Value = dt.Rows(0)("SerialNumber").ToString()
                DataGridView1.CurrentRow.Cells(5).Value = dt.Rows(0)("TestMeasureValue").ToString()
                DataGridView1.CurrentRow.Cells(6).Value = dt.Rows(0)("ActualSetpoint").ToString()
                DataGridView1.CurrentRow.Cells(7).Value = dt.Rows(0)("PassFail").ToString()
                DataGridView1.CurrentRow.Cells(8).Value = dt.Rows(0)("DateString").ToString()
                DataGridView1.CurrentRow.Cells(9).Value = dt.Rows(0)("TimeString").ToString()

            End Using

            newsqlconn.Close()

        End If

    End Sub

    Private Sub dgv1()
        Dim dt As New DataTable
        Dim bs As New BindingSource
        Dim sqlquery As String

        Dim dv As DataView = New DataView()

        Dim serialNumber As String = cboFlowDataSerialNum.Text
        Dim workOrder As String = cboFlowDataWorkOrder.Text
        Dim emplID As String = cboOperator.Text
        Dim partNumber As String = cboFlowDataPartNum.Text
        Dim operationDescr As String = cboFlowDataOperationDescr.Text
        Dim passfail As String = cboFlowDataPassFail.Text.ToString
        Dim testSearch As String = txtSearchBar.Text
        'Dim startDate As String = FlowData.DateTimePickerStartDate.Text
        'Dim stopDate As String = FlowData.DateTimePickerStopDate.Text
        Dim startDate As Date = Date.Parse(DateTimePickerStartDate.Text).ToString("MM'/'dd'/'yyyy")
        Dim stopDate As Date = Date.Parse(DateTimePickerStopDate.Text).ToString("MM'/'dd'/'yyyy")

        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim date1 As Date
        'Dim date2 As Date
        'Dim date3 As Date





        Dim accesstring6148Liq As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\umt.local\data\Flow Data\6148-RLFS-LIQFL-WS02\Test Results\TEST OUTPUT DATA.MDB;Persist Security Info=False;"
        Dim newsqlconn As New OleDbConnection(accesstring6148Liq)

        If newsqlconn.State = ConnectionState.Closed Then
            newsqlconn.Open()
        ElseIf newsqlconn.State = ConnectionState.Open Then
        End If

        sqlquery = "SELECT OperatorID, PartNumber, OperationDescription, SerialNumber, TestMeasureValue, ActualSetpoint, PassFail, DateString, TimeString FROM TestResults " '&
        Dim cmd As New OleDbCommand(sqlquery, newsqlconn)
        Dim da As New OleDbDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)




        bs.DataSource = dt
        DataGridView1.DataSource = bs

        cboOperator.DataSource = dt
        cboOperator.DisplayMember = "OperatorID"
        cboOperator.ValueMember = "OperatorID"
        cboOperator.SelectedIndex = -1




        newsqlconn.Close()
    End Sub

    Private Sub BtnLoadFlowData_Click(sender As Object, e As EventArgs) Handles BtnLoadFlowData.Click

        'Display the dialogue to initiate the background work.
        Using waitDialogue = GetWaitDialogue()
            waitDialogue.ShowDialog()
        End Using

    End Sub

    Private Sub BackgroundWorkerForm_DoWork(sender As Object, e As DoWorkEventArgs)
        'Simulate some time-consuming work.
        'MessageBox.Show("BLAH")

        For i = 0 To 100
            Dim worker = DirectCast(sender, BackgroundWorker)

            If worker.CancellationPending Then
                e.Cancel = True

                Exit For
            End If

            worker.ReportProgress(i)


            Thread.Sleep(100)
        Next
    End Sub

    'This method will be executed by the BackgroundWorker in the dialogue.
    Private Sub BackgroundWorkerForm_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        statusLabel.Text = (e.ProgressPercentage / 100).ToString("p0")
    End Sub

    'This method will be executed by the BackgroundWorker in the dialogue.
    Private Sub BackgroundWorkerForm_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        statusLabel.Text = If(e.Cancelled, "Operation cancelled", "Operation complete")
    End Sub

    Private Function GetWaitDialogue() As ProgressForm
        Dim dialogue As ProgressForm

        dialogue = New ProgressForm(AddressOf BackgroundWorkerForm_DoWork,
                                                AddressOf BackgroundWorkerForm_ProgressChanged,
                                                AddressOf BackgroundWorkerForm_RunWorkerCompleted)

        'Only display a Cancel button if the corresponding CheckBox is checked.
        'dialogue.SupportsCancellation
        Return dialogue
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub



    Private Sub BtnFlowDataSearch_MouseHover(sender As Object, e As EventArgs) Handles BtnFlowDataSearch.MouseHover
        BtnFlowDataSearch.BackColor = System.Drawing.Color.Azure
        BtnFlowDataSearch.ForeColor = Color.Black
    End Sub

    Private Sub BtnFlowDataSearch_MouseLeave(sender As Object, e As EventArgs) Handles BtnFlowDataSearch.MouseLeave
        BtnFlowDataSearch.BackColor = System.Drawing.Color.DarkCyan
        BtnFlowDataSearch.ForeColor = Color.White
    End Sub

    Private Sub BtnLoadFlowData_MouseHover(sender As Object, e As EventArgs) Handles BtnLoadFlowData.MouseHover
        BtnLoadFlowData.BackColor = System.Drawing.Color.Azure
        BtnLoadFlowData.ForeColor = Color.Black
    End Sub

    Private Sub BtnLoadFlowData_MouseLeave(sender As Object, e As EventArgs) Handles BtnLoadFlowData.MouseLeave
        BtnLoadFlowData.BackColor = System.Drawing.Color.DarkCyan
        BtnLoadFlowData.ForeColor = Color.White
    End Sub

End Class