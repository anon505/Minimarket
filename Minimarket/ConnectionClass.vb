Imports System.Windows.Forms

Public Enum DataBaseTypeEnum As Integer
    mySQL = 0
    MSSQL
End Enum

Public Class Connection
    Implements IDisposable

#Region "Events"

    ''' <summary>
    ''' Event raise to allow external event logging
    ''' </summary>
    ''' <param name="eventText"></param>
    ''' <param name="eventType"></param>
    ''' <remarks></remarks>
    Public Event eLog(ByVal eventText As String, ByVal eventType As System.Diagnostics.EventLogEntryType)

#End Region
#Region "Declarations"

    Private conn As MySql.Data.MySqlClient.MySqlConnection

#End Region



#Region "Properties"
    Private _connectionString As String
    Public ReadOnly Property connectionString() As String
        Get
            Return _connectionString
        End Get

    End Property

    Public ReadOnly Property Server() As String
        Get
            Dim ret As String = ""
            If conn IsNot Nothing Then
                ret = conn.DataSource
            End If
            Return ret
        End Get

    End Property

    Public ReadOnly Property Database() As String
        Get
            Dim ret As String = ""
            If conn IsNot Nothing Then
                ret = conn.Database
            End If
            Return ret
        End Get
    End Property

    Private _UserName As String
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            If _UserName <> value Then
                _UserName = value

            End If
        End Set
    End Property

    Private _password As String
    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            If _password <> value Then
                _password = value
            End If


        End Set
    End Property

    Private _timeOut As Integer = 5000
    Public Property timeOut() As Integer
        Get
            Return _timeOut
        End Get
        Set(ByVal value As Integer)
            _timeOut = value
        End Set
    End Property

    ''' <summary>
    ''' If true error events will be displayed in a messagebox
    ''' If false the eLog event will be raised 
    ''' </summary>
    ''' <remarks></remarks>
    Private _VERBOSE As Boolean
    Public WriteOnly Property VERBOSE() As Boolean

        Set(ByVal value As Boolean)
            _VERBOSE = value
        End Set
    End Property

#End Region

    Public Overrides Function ToString() As String

        Return String.Format("{0} on {1}", Me.Database, Me.Server)

    End Function


#Region "Properties"


#End Region

#Region "Constructors"
    ''' <summary>
    ''' Creates a new instance of the Connection class.
    ''' </summary>
    ''' <param name="_connString">Connection string to connection to the database</param>
    ''' <remarks> A call to the shared function TestConnection should be made to validate the connection string first</remarks>
    Public Sub New(ByVal _connString As String)

        '  _connString &= ";Connection Timeout=5;default command timeout=5;"
        _connectionString = _connString
        conn = New MySql.Data.MySqlClient.MySqlConnection(connectionString)

    End Sub

#End Region


#Region "Methods"

#Region "Execute Routines"

#Region "ExecuteNonQuery"
    'execute non query
    ''' <summary>
    ''' Executes a non-query command on the database 
    ''' </summary>
    ''' <param name="cmdString">The command string for the database query</param>
    ''' <returns>True is the query suceeds, otherwise False</returns>
    ''' <remarks></remarks>
    Public Overloads Function ExecuteNonQuery(ByVal cmdString As String) As Boolean

        Dim ret As Boolean = True
        'create a connection and a command the execute the command
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)

            ret = ExecuteNonQuery(cmd)

        End Using

        Return ret

    End Function
    ''' <summary>
    ''' Executes a parameterized non-query command on the database 
    ''' </summary>
    ''' <param name="cmdString">The command string for the database query</param>
    ''' <param name="parameters">Dictionary of parameters used by the query</param>
    ''' <returns>True if the query suceeds, otherwise False</returns>
    ''' <remarks>The parameters dictionary object contains the parameter name in the key collection and its corresponding value in the values collection. </remarks>
    Public Overloads Function ExecuteNonQuery(ByVal cmdString As String, ByVal parameters As System.Collections.Generic.Dictionary(Of String, Object)) As Boolean

        Dim ret As Boolean
        'create a connection and a command the execute the command
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)

            For i As Integer = 0 To parameters.Keys.Count - 1
                cmd.Parameters.AddWithValue(parameters.Keys(i), parameters.Values(i))
            Next

            ret = ExecuteNonQuery(cmd)

        End Using

        Return ret

    End Function
    Private Overloads Function ExecuteNonQuery(ByVal cmd As MySql.Data.MySqlClient.MySqlCommand) As Boolean

        Dim ret As Boolean
        ' Using conn As New MySql.Data.MySqlClient.MySqlConnection(connectionString)
        cmd.Connection = conn
        cmd.CommandTimeout = timeOut
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If

            cmd.ExecuteNonQuery()
            'the query suceeded, so return true 
            ret = True

        Catch ex As Exception

            'the query failed, so log the exception and return false 

            LogSQLError(ex)
            ret = False
        Finally
            conn.Close()
        End Try

        'End Using
        ' End Using
        Return ret

    End Function
#End Region

#Region "ExecuteReader"
    'execute reader
    ''' <summary>
    ''' Executes a reader command on the database 
    ''' </summary>
    ''' <param name="cmdString">The command string for the database query</param>
    ''' <returns>Returns a data table with the query results. If the query fails, nothing will be returned.</returns>
    ''' <remarks></remarks>
    Public Overloads Function ExecuteReader(ByVal cmdString As String) As DataTable

        Dim ret As DataTable
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)

            ret = ExecuteReader(cmd)

        End Using

        Return ret

    End Function
    ''' <summary>
    ''' Executes a parameterized reader command on the database 
    ''' </summary>
    ''' <param name="cmdString">The command string for the database query</param>
    ''' <param name="parameters">Dictionary of parameters used by the query</param>
    ''' <returns>Returns a data table with the query results. If the query fails, nothing will be returned.</returns>
    ''' <remarks>The parameters dictionary object contains the parameter name in the key collection and its corresponding value in the values collection.</remarks>
    Public Overloads Function ExecuteReader(ByVal cmdString As String, ByVal parameters As System.Collections.Generic.Dictionary(Of String, Object)) As DataTable

        Dim ret As DataTable
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)

            For i As Integer = 0 To parameters.Keys.Count - 1
                cmd.Parameters.AddWithValue(parameters.Keys(i), parameters.Values(i))
            Next
            ret = ExecuteReader(cmd)

        End Using
        '   End Using
        Return ret




    End Function
    Private Overloads Function ExecuteReader(ByVal cmd As MySql.Data.MySqlClient.MySqlCommand) As DataTable

        Dim ret As DataTable = Nothing

        If conn IsNot Nothing Then
            Try
                cmd.Connection = conn
                cmd.CommandTimeout = timeOut
                If Not conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
                Dim dT As New DataTable
                dT.Load(cmd.ExecuteReader)
                'the query suceeded, so return the table 
                ret = dT

            Catch ex As Exception
                'the query failed, so log the exception and return nothing
                Console.WriteLine(ex)
                LogSQLError(ex)
                ret = Nothing
            Finally
                conn.Close()
            End Try
        End If

        Return ret



    End Function
#End Region

#Region "ExecuteScalar"
    'execute scalar
    ''' <summary>
    ''' Executes a scalar command on the database 
    ''' </summary>
    ''' <param name="cmdString">The command string for the database query</param>
    ''' <returns>Returns an object with the query results. If the query fails, nothing will be returned.</returns>
    ''' <remarks></remarks>
    Public Overloads Function ExecuteScalar(ByVal cmdString As String) As Object

        Dim ret As Object
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)

            ret = ExecuteScalar(cmd)

        End Using

        Return ret

    End Function
    ''' <summary>
    ''' Executes a parameterized scalar command on the database 
    ''' </summary>
    ''' <param name="cmdString">The command string for the database query</param>
    ''' <param name="parameters">Dictionary of parameters used by the query. </param>
    ''' <returns>Returns an object with the query results. If the query fails, nothing will be returned.</returns>
    ''' <remarks>The parameters dictionary object contains the parameter name in the key collection and its corresponding value in the values collection.</remarks>
    Public Overloads Function ExecuteScalar(ByVal cmdString As String, ByVal parameters As System.Collections.Generic.Dictionary(Of String, Object)) As Object

        Dim ret As Object
        'create a connection and a command the execute the command
        ' Using conn As New MySql.Data.MySqlClient.MySqlConnection(_connectionString)
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)


            For i As Integer = 0 To parameters.Keys.Count - 1
                cmd.Parameters.AddWithValue(parameters.Keys(i), parameters.Values(i))
            Next

            ret = ExecuteScalar(cmd)

        End Using
        '  End Using
        Return ret

    End Function
    Private Overloads Function ExecuteScalar(ByVal cmd As MySql.Data.MySqlClient.MySqlCommand) As Object

        Dim ret As Object

        Try
            cmd.Connection = conn
            cmd.CommandTimeout = timeOut

            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim o As Object = cmd.ExecuteScalar

            'the query suceeded, so return the the object 
            ret = o

        Catch ex As Exception
            'the query failed, so log the exception and return nothing
            LogSQLError(ex)
            ret = Nothing
        Finally
            conn.Close()
        End Try
        'End Using
        ' End Using
        Return ret


    End Function
#End Region

#Region "ExecuteInsert with record ID Return"
    'excute insert with ID return
    Public Overloads Function InsertWithID(ByVal cmdString As String) As Integer

        Dim ret As Integer = -1
        'create a connection and a command the execute the command
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)

            If ExecuteNonQuery(cmd) Then
                ret = getLastID(cmd)
            End If

        End Using
        Return ret

    End Function
    Public Overloads Function InsertWithID(ByVal cmdString As String, ByVal parameters As Dictionary(Of String, Object)) As Integer

        Dim ret As Integer = -1
        'create a connection and a command the execute the command
        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(cmdString)


            For i As Integer = 0 To parameters.Keys.Count - 1
                cmd.Parameters.AddWithValue(parameters.Keys(i), parameters.Values(i))
            Next

            If ExecuteNonQuery(cmd) Then
                ret = getLastID(cmd)
            End If

        End Using
        Return ret



    End Function
    Private Function getLastID(ByVal cmd As MySql.Data.MySqlClient.MySqlCommand) As Integer

        Dim ret As Integer = -1
        cmd.CommandText = "SELECT LAST_INSERT_ID()"
        Dim dt As DataTable = ExecuteReader(cmd)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ret = CInt(dt.Rows(0)(0))

        End If
        Return ret

    End Function

#End Region


#End Region

#Region "logSQL Errors"

    Public Sub LogSQLError(ByVal ex As Exception)


        Dim Severity As EventLogEntryType = EventLogEntryType.Error
        Dim Description As String = String.Format("SQL Factory Exception.{1}Error string: {0}{1}{1}{2}", ex.Message, Environment.NewLine, ex.ToString)
        Call LogException(Description, Severity)


    End Sub

    Public Sub LogException(ByVal description As String, ByVal severity As EventLogEntryType)



        Dim logText As String = String.Format("{0},{1}", severity, description)
        If _VERBOSE Then
            MessageBox.Show(String.Format("An SQL exception has been raised.{0}Severity: {1}{0}{2}", Environment.NewLine, severity, description))
        Else
            RaiseEvent eLog(description, severity)
            '   Beep()
        End If


    End Sub
#End Region

#Region "Helpers"


    ''' <summary>
    ''' Checks the database connected to for the existance of a particualr table
    ''' </summary>
    ''' <param name="tblName">Name of the data table to search for</param>
    ''' <returns>Returns True if the database contains the table or False if either the table is not in the database or if the query fails</returns>
    ''' <remarks></remarks>
    Public Function doesTableExist(ByVal tblName As String) As Boolean

        Dim ret As Boolean = False
        If conn IsNot Nothing Then

            Dim cmdString As String = String.Format("show tables like '{0}'", tblName.ToLower)
            Dim o As Object = ExecuteScalar(cmdString)
            ret = o IsNot Nothing

        End If
        Return ret


    End Function


    ''' <summary>
    ''' Returns the size of the database in Bytes
    ''' </summary>
    ''' <returns>Returns to size of the database in byte or -1 if the query fails</returns>
    ''' <remarks>The database must be reachable using the credentials given to the connection</remarks>
    Public Function databaseSizeInBytes() As Double

        Dim ret As Double = -1

        Dim cmdString As String = String.Format("SELECT sum( data_length + index_length )" & _
                                                "FROM information_schema.TABLES " & _
                                                "WHERE TABLE_SCHEMA like '{0}' " & _
                                                "GROUP BY table_schema ; ", Me.Database)
        Dim o As Object = Me.ExecuteScalar(cmdString)
        If o IsNot Nothing Then

            Double.TryParse(o.ToString, ret)

        End If
        Return ret


    End Function


    ''' <summary>
    ''' Returns the number of data rows in a datatable contained in the connection's database
    ''' </summary>
    ''' <param name="tableName">Name of the table to return the row count from</param>
    ''' <returns>Return the number of rows in the table or -1 if the query fails</returns>
    ''' <remarks>The table must belong to the database that is connected to</remarks>
    Public Function getDataBaseRowCount(ByVal tableName As String) As Integer

        'if the table does not exist, return -1
        'otherwise return the number of rows...
        Dim rowCount As Integer = -1

        If doesTableExist(tableName) Then
            Dim cmdString As String = String.Format("SELECT COUNT(*) FROM {0}", tableName)
            Dim o As Object = Me.ExecuteScalar(cmdString)
            If o IsNot Nothing Then
                rowCount = CInt(o)
            End If
        End If
        Return rowCount

    End Function


    ''' <summary>
    ''' The getSQLParameterStringFromList will convert a Dictionary of parameters to a string that can be embedded in a command string
    ''' </summary>
    ''' <param name="pList">Dictionary of parameters to be converted</param>
    ''' <returns></returns>
    ''' <remarks>The parameters dictionary object contains the parameter name in the key collection and its corresponding value in the values collection.
    ''' For a command string using the results to succeed, the parameter names in the Dictionary's key collection <B>must be in the form of @<I>fieldName</I></B></remarks>
    Public Function getSQLParameterStringFromList(ByVal plist As Dictionary(Of String, Object)) As String

        'create thecmdString from the parameter list...
        Dim pString As New List(Of String)
        For Each parameter As String In plist.Keys
            pString.Add(String.Format("`{0}`={1}", parameter.Substring(1), parameter))
        Next
        Return String.Join(",", pString)

    End Function


    ''' <summary>
    ''' Gets the maximum value from a data column in a table.
    ''' </summary>
    ''' <returns>Return the last index or -1 if the query fails</returns>
    ''' <remarks></remarks>
    Public Function getMaxFromColumn(ByVal columnName As String, ByVal tblName As String) As Integer

        Dim id As Integer = -1
        If conn IsNot Nothing Then
            Dim cmdString = String.Format("SELECT MAX(`{0}`) FROM {1}", columnName, tblName)
            Dim o As Object = ExecuteScalar(cmdString)
            Integer.TryParse(o.ToString, id)
        End If
        Return id


    End Function


    ''' <summary>
    ''' Returns the columns name for a particular table
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getColumnNames(ByVal tableName As String) As DataTable

        Dim cmdString As String = String.Format("SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` " & _
                                                "WHERE `TABLE_SCHEMA`='{0}' AND `TABLE_NAME`='{1}'", conn.Database, tableName)

        Dim dt As DataTable = ExecuteReader(cmdString)
        'set the primary key
        dt.PrimaryKey = {dt.Columns("COLUMN_NAME")}
        Return dt


    End Function

#End Region

#End Region

#Region "Shared Methods"


    ''' <summary>
    ''' Overloaded Call this method to create a connection. All parameters passed to the method are ByRef so the caller can access the values after the connection is made.
    ''' </summary>
    ''' <param name="dbServer">ByRef - Machine IP address that is hosting the serve</param>
    ''' <param name="dbUser">ByRef - Database user name</param>
    ''' <param name="dbPassword">ByRef password for the dbUser</param>
    ''' <param name="dbName">Byref - Name of the database on the server</param>
    ''' <returns>If the connection cannot be made, the Connection Dialog will be displayed to the user. If a connection is made, the credentials in the dialog box are returned in the ByRef arguments.</returns>
    Public Shared Function getConnection(ByRef dbServer As String, _
                                         ByRef dbUser As String, _
                                         ByRef dbPassword As String, _
                                         ByRef dbName As String) As Connection

        Dim _conn As Connection = EstablishDBConnection(dbServer, dbUser, dbPassword, dbName)
        Do Until _conn IsNot Nothing
            Dim s As String = String.Format("A connection to {0}/{1} with user {2} could not be established.", dbServer, dbName, dbUser)

            MessageBox.Show(s)
        Loop

        If _conn IsNot Nothing Then
            _conn.UserName = dbUser
            _conn.password = dbPassword

        End If


        Return _conn

    End Function

    ''' <summary>
    ''' Overloaded. Call this method to create a connection from a connection string.
    ''' </summary>
    ''' <param name="connString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getConnection(ByVal connString As String) As Connection

        Dim conn As Connection = Nothing
        If CBool(Connection.TestConnection(connString, DataBaseTypeEnum.mySQL)) Then
            conn = New Connection(connString)
        End If
        Return conn

    End Function


    Private Shared Function EstablishDBConnection(ByVal dbServer As String, _
                                                  ByVal dbUser As String, _
                                                  ByVal dbPassword As String, _
                                                  ByVal dbName As String) As Connection

        Dim conn As Connection = Nothing

        Dim server As String = dbServer
        Dim user As String = dbUser
        Dim pw As String = dbPassword
        Dim db As String = dbName

        Dim _connString As String = String.Format("Server={0};Uid={1};Pwd={2};Database={3}", server, user, pw, db)
        If CBool(Connection.TestConnection(_connString, DataBaseTypeEnum.mySQL)) Then

            conn = New Connection(_connString)

        End If
        Return conn

    End Function


    ''' <summary>
    ''' Overloaded. Shared method to test a connection string. This method should be called before creating the connection
    ''' </summary>
    ''' <param name="connString">Connection string to test</param>
    ''' <param name="dbType">DataBaseTypeEnum enumeration to set the database manufacturer</param>
    ''' <returns>Return true if the test succeeds, faslse if it fails</returns>
    ''' <remarks></remarks>
    Friend Shared Function TestConnection(ByVal connString As String, ByVal dbType As DataBaseTypeEnum) As Boolean

        Dim ret As Boolean
        Select Case dbType
            Case DataBaseTypeEnum.mySQL

                'append the connection timeout

                connString &= ";Connection Timeout=5;default command timeout=5;"

                Using conn As New MySql.Data.MySqlClient.MySqlConnection(connString)
                    Try

                        conn.Open()
                        ret = True
                    Catch ex As Exception
                        ret = False
                    Finally
                        conn.Close()
                    End Try
                End Using


            Case DataBaseTypeEnum.MSSQL

                Using conn As New System.Data.SqlClient.SqlConnection(connString)
                    Try
                        conn.Open()
                        ret = True
                    Catch ex As Exception
                        ret = False
                    Finally
                        conn.Close()
                    End Try
                End Using




        End Select


        Return ret




    End Function


    ''' <summary>
    ''' Returns a date string formated for a mySQL data base
    ''' </summary>
    ''' <param name="DateToConvert">DateTime object to convert to mySQL database format</param>
    ''' <returns>String representing the data and time in mySQL format</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSQLDateString(ByVal DateToConvert As DateTime) As String

        Dim dateString As String = DateToConvert.ToString("yyyy-M-d H:mm:ss")
        Return dateString


    End Function



#End Region


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If
            If conn IsNot Nothing Then
                conn.Dispose()
            End If


            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class



