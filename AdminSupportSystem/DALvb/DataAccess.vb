Option Strict On
Imports System.Data.SqlClient
Imports UDT


Namespace DALvb

    Public Class DataAccess

        ''' <summary>
        ''' Private constructor for DataAccess
        ''' </summary>
        Private Sub New()
        End Sub

        ''' <summary>
        ''' Retrieves various information from the database
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <param name="parms"></param>
        ''' <returns></returns>
        Public Shared Function GetData(sql As String, Optional parms As List(Of parmStructure) = Nothing) As DataTable
            Dim cmd As New SqlCommand
            Dim cnn As New SqlConnection(My.Settings.cnnString)
            cmd.Connection = cnn
            cmd.CommandText = sql
            cmd.CommandType = CommandType.StoredProcedure

            If parms IsNot Nothing Then
                Call AddParms(parms, cmd)
            End If

            Using cnn
                Dim da As New SqlDataAdapter
                Using da
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Sends various information to the database
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <param name="parms"></param>
        ''' <returns></returns>
        Public Shared Function SendData(sql As String, Optional parms As List(Of parmStructure) = Nothing) As integer
            Dim cmd As New SqlCommand
            Dim cnn As New SqlConnection(My.Settings.cnnString)
            cmd.Connection = cnn
            cmd.CommandText = sql
            cmd.CommandType = CommandType.StoredProcedure

            If parms IsNot Nothing Then
                Call AddParms(parms, cmd)
            End If

            Using cnn
                cnn.Open()
                dim x As Integer = cmd.ExecuteNonQuery()
                UnloadParms(cmd, parms)
                Return x
            End Using
        End Function

        ''' <summary>
        ''' Adds parameters to a list of parameters to be sent to the database
        ''' </summary>
        ''' <param name="parms"></param>
        ''' <param name="cmd"></param>
        Private Shared Sub AddParms(parms As List(Of parmStructure), cmd As SqlCommand)
            For i As Integer = 0 To parms.Count - 1
                cmd.Parameters.Add(parms(i).parmName, parms(i).parmType, parms(i).parmSize)
                cmd.Parameters(i).Direction = parms(i).parmDirection
                cmd.Parameters(i).Value = parms(i).parmValue
            Next
        End Sub

        ''' <summary>
        ''' Unloads a list of paramaters that are being sent to the database
        ''' </summary>
        ''' <param name="cmd"></param>
        ''' <param name="parms"></param>
        Private Shared Sub UnloadParms(cmd As SqlCommand, parms As List(Of parmStructure))
            For i As Integer = 0 To parms.Count - 1
                Dim d As parmStructure = parms(i)
                d.parmValue = cmd.Parameters(i).Value
                parms(i) = d
            Next
        End Sub

    End Class

End Namespace