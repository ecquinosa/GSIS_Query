﻿Imports System.Data.SqlClient
Imports System.Drawing

''' <summary>
''' Data Access Class for SQL Queries.
''' </summary>
''' <remarks>
''' Code By : BARON PATRICK T. PAREDES<br/>
''' Contact#: 0927-8497119<br/>
''' Email   : barspars@yahoo.com<br/>
''' Email   : baronpatrick.paredes@gmail.com<br/>
''' Date    : December 01, 2009
''' </remarks>
Public Class ClassDataAccessSQL

    Implements IDisposable

#Region "Members"

    Private isDisposed As Boolean = False

    Private member_Connection As SqlConnection
    Private member_Command As SqlCommand
    Private member_DataReader As SqlDataReader
    Private member_DataAdapter As SqlDataAdapter

    Private member_DataTable As DataTable

    Private member_Exception As String
    Private member_ConnectionString As String

#End Region

#Region "Constuctor"

    ''' <summary>
    ''' Constructing New Data Access Object
    ''' </summary>
    ''' <param name="ConnectionString">A Valid SQL Connection String.</param>
    ''' <remarks>Use connection string generated by a UDL File.</remarks>
    ''' <example>Dim Obj As New ClassDataAccess(ValidConnectionString)</example>
    Public Sub New(ByVal ConnectionString As String)
        member_ConnectionString = ConnectionString
    End Sub

#End Region

#Region "Properties"

    ''' <summary>
    ''' Exception Property of the object.
    ''' </summary>
    ''' <returns>Returns the error exception thrown by the object.</returns>
    Public ReadOnly Property Exception() As String
        Get
            Return member_Exception
        End Get
    End Property

    ''' <summary>
    ''' An SQLbDataReader Object returned after executing a successful execution of a SQL Command.
    ''' </summary>
    ''' <returns>Current SQLDataReader in object memory.</returns>
    Public ReadOnly Property DataReader() As SqlDataReader
        Get
            Return member_DataReader
        End Get
    End Property

    ''' <summary>
    ''' A DataTable Object returned after executing a successful execution of a SQL Command.
    ''' </summary>
    ''' <returns>Current DataTable in object memory.</returns>
    Public ReadOnly Property DataTable() As DataTable
        Get
            Return member_DataTable
        End Get
    End Property

#End Region

#Region "Data Functions"

    ''' <summary>
    ''' Closes the connection properly.
    ''' </summary>
    Public Sub CloseConnection()
        If member_Connection.State = ConnectionState.Open Then member_Connection.Close()
    End Sub

    Public Function ConnectWithoutDisconnecting() As Boolean

        Try
            member_Connection = New SqlConnection(member_ConnectionString)
            member_Connection.Open()
        Catch ex As Exception
            member_Exception = ex.ToString
            Return False
        End Try

        Return True

    End Function

    Public Function Execute(ByVal SQLQuery As String) As Boolean

        Try

            member_Command = New SqlCommand

            member_Command.CommandText = SQLQuery
            member_Command.Connection = member_Connection

            member_Command.ExecuteNonQuery()
            member_Command.Dispose()

        Catch ex As Exception
            member_Exception = ex.ToString
            Return False
        End Try

        Return True

    End Function

    Public Enum ConnectionType As Integer
        DataReader
        DataCommand
        DataAdapter
    End Enum

    ''' <summary>
    ''' Connect using the connection string provided by the constructor.
    ''' </summary>
    ''' <param name="ConnectionString">A Valid SQL Connection String.</param>
    ''' <returns>True=Connection Success, False=Connection Failed.</returns>
    ''' <example>Obj.Connect(ValidConnectionString)</example>
    Public Function Connect(ByVal ConnectionString As String) As Boolean

        Try

            member_Connection = New SqlConnection(ConnectionString)
            member_Connection.Open()

        Catch ex As SqlException

            member_Exception = ex.ToString

            Return False

        Finally

            CloseConnection()

        End Try

        member_Exception = "No Error"


        Return True

    End Function

    ''' <summary>
    ''' SQL Function for any SQL Command Syntax.
    ''' </summary>
    ''' <param name="SQLQuery">A Valid SQL Query Command.</param>
    ''' <param name="ConnType"><see>ConnectioType</see></param>
    ''' <returns>True=Command Success, False=Command Failed</returns>
    ''' <example>
    ''' 1. Obj.SQL("SELECT * FROM TABLE1",ConnectionType.DataReader)<br></br>
    '''    Returns SQLDataReader<br></br>
    ''' 2. Obj.SQL("DELETE FROM TABLE1", ConnectionType.DataCommand)<br></br>
    ''' 3. Obj.SQL("INSERT INTO TABLE1 VALUES('VALUE')", ConnectionType.DataCommand)<br></br>
    ''' 4. Obj.SQL("UPDATE TABLE1 SET Field1='VALUE'", ConnectionType.DataCommand)<br></br>
    ''' 5. Obj.SQL("SELECT * FROM TABLE1", ConnectionType.DataAdapter)<br></br>
    '''    Returns DataTable
    ''' </example>
    Public Function SQL(ByVal SQLQuery As String, ByVal ConnType As ConnectionType) As Boolean

        If Connect(member_ConnectionString) = False Then Return False

        Try
            member_Connection.Open()

            Select Case ConnType

                Case ConnectionType.DataReader

                    member_Command = New SqlCommand

                    member_Command.CommandText = SQLQuery
                    member_Command.Connection = member_Connection

                    member_DataReader = member_Command.ExecuteReader

                Case ConnectionType.DataCommand

                    member_Command = New SqlCommand

                    member_Command.CommandText = SQLQuery
                    member_Command.Connection = member_Connection

                    member_Command.ExecuteNonQuery()
                    member_Command.Dispose()

                    CloseConnection()

                Case ConnectionType.DataAdapter

                    member_DataAdapter = New SqlDataAdapter
                    member_Command = New SqlCommand

                    member_Command.CommandText = SQLQuery
                    member_Command.Connection = member_Connection

                    member_DataAdapter.SelectCommand = member_Command

                    member_DataTable = New DataTable

                    With member_DataAdapter.SelectCommand.CommandType = CommandType.Text
                        member_DataAdapter.Fill(member_DataTable)
                    End With

                    member_DataAdapter.Dispose()

                    CloseConnection()

            End Select

        Catch ex As SqlException

            member_Exception = ex.ToString

            Return False

        Catch ex As Exception

            member_Exception = ex.ToString

            Return False

        End Try

        member_Exception = "No Error"

        Return True

    End Function

#End Region

#Region "Data Procedures"

    ''' <summary>
    ''' Procedure for populating Table Fields into a String Array.
    ''' </summary>
    ''' <param name="SQLQuery">A Valid SQL SELECT Query Command.</param>
    ''' <returns>An array of string consisting the current fields of a table.</returns>
    ''' <remarks>
    ''' 1. Accepts SQL SELECT Query only<br></br>
    ''' 2. SELECT Top 1 for optimized performance.
    ''' </remarks>
    ''' <example>Obj.GetFieldNames("SELECT * FROM Table1")</example>
    Public Function GetFieldNames(ByVal SQLQuery As String) As String()

        On Error Resume Next

        If SQL(SQLQuery, ConnectionType.DataReader) = False Then Return Nothing

        Dim fields(member_DataReader.FieldCount() - 1) As String

        For i As Integer = 0 To member_DataReader.FieldCount() - 1

            fields(i) = member_DataReader.GetName(i)

        Next

        Return fields

    End Function

#End Region

#Region "Deconstructor"

    ''' <summary>
    ''' Deconstructor of the object.
    ''' </summary>
    ''' <example>Obj.Dispose()</example>
    Public Sub Dispose() Implements IDisposable.Dispose
        On Error Resume Next
        Dispose(True)           'Deconstructing Sub Routine
        GC.SuppressFinalize(Me) 'Garbage Collector
    End Sub

    ''' <summary>
    ''' Deconstructing routine of the object.
    ''' </summary>
    ''' <example>Dispose(True)</example>
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)

        If Not isDisposed Then

            If disposing Then

                CloseConnection()

                member_ConnectionString = ""
                member_Exception = ""

                If Not member_DataTable Is Nothing Then
                    member_DataTable.Dispose()
                    member_DataTable = Nothing
                End If

                If Not member_DataAdapter Is Nothing Then
                    member_DataAdapter.Dispose()
                    member_DataAdapter = Nothing
                End If

                If Not member_Command Is Nothing Then
                    member_Command.Dispose()
                    member_Command = Nothing
                End If

                If Not member_Connection Is Nothing Then
                    member_Connection.Close()
                    member_Connection = Nothing
                End If

            End If
        End If

        isDisposed = True

    End Sub

#End Region

End Class