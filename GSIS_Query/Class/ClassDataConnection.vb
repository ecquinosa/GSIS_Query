Public Class DataConnection

    Private member_State As Boolean
    Private member_Exception As String
    Private member_ConnectionString As String

    Public DataAccess As ClassDataAccessSQL

    Public Property ConnectionString() As String
        Get
            Return member_ConnectionString
        End Get
        Set(ByVal value As String)
            member_ConnectionString = value
        End Set
    End Property

    Public Property State() As Boolean
        Get
            Return member_State
        End Get
        Set(ByVal value As Boolean)
            member_State = value
        End Set
    End Property

    Public Property Exception() As String
        Get
            Return member_Exception
        End Get
        Set(ByVal value As String)
            member_Exception = value
        End Set
    End Property

    Public Function ExecuteDataReader(ByVal SQLQuery As String) As Boolean

        DataAccess = New ClassDataAccessSQL(ConnectionString)

        If Not DataAccess.SQL(SQLQuery, ClassDataAccessSQL.ConnectionType.DataReader) Then
            Exception = "Failed to populate data from database."
            DataAccess.Dispose()
            Return False
        Else
            Exception = "No Error"
            Return True
        End If

    End Function

    Public Function ExecuteDataTable(ByVal SQLQuery As String) As DataTable

        DataAccess = New ClassDataAccessSQL(ConnectionString)
        DataAccess.SQL(SQLQuery, ClassDataAccessSQL.ConnectionType.DataAdapter)

        ExecuteDataTable = DataAccess.DataTable

        DataAccess.Dispose()

    End Function

    Public Function ExecuteCommand(ByVal SQLQuery As String) As Boolean

        DataAccess = New ClassDataAccessSQL(ConnectionString)

        Try
            If Not DataAccess.SQL(SQLQuery, ClassDataAccessSQL.ConnectionType.DataCommand) Then
                State = False
                Exception = "Database Error."
            Else
                State = True
                Exception = "Success"
            End If

        Catch ex As Exception

            State = False
            Exception = ex.ToString

        End Try

        DataAccess.Dispose()

        Return State

    End Function

    Public Function GetValue(ByVal SQLQuery As String) As Object
        Dim dt As DataTable = ExecuteDataTable(SQLQuery)
        If dt.Rows.Count = 0 Then
            Return ""
        Else
            Return dt.Rows(0)(0)
        End If
    End Function

    Public Function Seek(ByVal SQLQuery As String) As Boolean

        DataAccess = New ClassDataAccessSQL(ConnectionString)

        If Not DataAccess.SQL(SQLQuery, ClassDataAccessSQL.ConnectionType.DataReader) Then
            Seek = False
        Else
            Seek = DataAccess.DataReader.Read
        End If

        DataAccess.Dispose()

    End Function

    Public Function OpenConnection() As Boolean
        DataAccess = New ClassDataAccessSQL(ConnectionString)
        Return DataAccess.ConnectWithoutDisconnecting
    End Function

    Public Function Execute(ByVal SQLQeury As String) As Boolean
        Return DataAccess.Execute(SQLQeury)
    End Function

    Public Sub CloseConnection()
        DataAccess.CloseConnection()
        DataAccess.Dispose()
    End Sub

End Class
