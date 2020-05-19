Imports System.ComponentModel

Public Class ProgressForm
    Inherits MetroFramework.Forms.MetroForm
    Dim StatementSQL As New StatementsSQL()
    Private Sub ProgressForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


#Region "Constructors"

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm"/> class.
    ''' </summary>
    ''' <remarks>
    ''' Parameterless constructor is private to ensure handlers are provided for <see cref="BackgroundWorker"/>.
    ''' </remarks>
    Private Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler)
        Me.New()

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork

        'Local event handlers
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onProgressChanged">
    ''' Handler for the <see cref="BackgroundWorker.ProgressChanged">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler,
                   onProgressChanged As ProgressChangedEventHandler)
        Me.New()

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork
        AddHandler BackgroundWorker1.ProgressChanged, onProgressChanged

        'Local event handlers
        AddHandler BackgroundWorker1.ProgressChanged, AddressOf BackgroundWorker1_ProgressChanged
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted

        'A ProgressChanged handler has been provided so the ProgressBar will be updated explicitly based on the BackgroundWorker.
        BackgroundWorker1.WorkerReportsProgress = True
        ProgressBar1.Style = ProgressBarStyle.Continuous
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onRunWorkerCompleted">
    ''' Handler for the <see cref="BackgroundWorker.RunWorkerCompleted">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler,
                   onRunWorkerCompleted As RunWorkerCompletedEventHandler)
        Me.New()

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork
        AddHandler BackgroundWorker1.RunWorkerCompleted, onRunWorkerCompleted

        'Local event handlers
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onProgressChanged">
    ''' Handler for the <see cref="BackgroundWorker.ProgressChanged">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onRunWorkerCompleted">
    ''' Handler for the <see cref="BackgroundWorker.RunWorkerCompleted">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler,
                   onProgressChanged As ProgressChangedEventHandler,
                   onRunWorkerCompleted As RunWorkerCompletedEventHandler)
        Me.New()

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork
        AddHandler BackgroundWorker1.ProgressChanged, onProgressChanged
        AddHandler BackgroundWorker1.RunWorkerCompleted, onRunWorkerCompleted

        'Local event handlers
        AddHandler BackgroundWorker1.ProgressChanged, AddressOf BackgroundWorker1_ProgressChanged
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted

        'A ProgressChanged handler has been provided so the ProgressBar will be updated explicitly based on the BackgroundWorker.
        BackgroundWorker1.WorkerReportsProgress = True
        ProgressBar1.Style = ProgressBarStyle.Continuous
    End Sub

#End Region 'Constructors

#Region "Properties"

    Public WriteOnly Property SupportsCancellation As Boolean
        Set
            BackgroundWorker1.WorkerSupportsCancellation = Value

            'If the worker can be cancelled, show the Cancel button and make the form big enough to see it.
            btnCancelProgressBar.Visible = Value
            Height = If(Value, 115, 86)
        End Set
    End Property

#End Region 'Properties

#Region "Methods"

    Private Sub BackgroundWorkerForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Start the background work when the form is displayed.
        BackgroundWorker1.RunWorkerAsync()
        StatementSQL.LoadFlowData()

    End Sub

    Private Sub cancelWorkButton_Click(sender As Object, e As EventArgs) Handles btnCancelProgressBar.Click
        'Disable the button to prevent another click.
        btnCancelProgressBar.Enabled = False

        'Cancel the background work.
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        'Update the ProgressBar.
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        'Close the form when the work is done.
        Close()
    End Sub

#End Region 'Methods

End Class