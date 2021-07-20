Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Public Class Upload
    Inherits System.Web.UI.Page

    Protected Function WriteToFile(ByVal strPath As String, ByRef Buffer() As Byte) As Boolean
        Try

            If IO.File.Exists(strPath) Then
                IO.File.Delete(strPath)
            End If

            Dim newFile As New FileStream(strPath, FileMode.Create)
            newFile.Write(Buffer, 0, Buffer.Length)
            newFile.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not CBool(Session("AUTHENTICATED")) Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub button_Upload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button_Upload.Click

        If filMyFile.PostedFile Is Nothing Then
            label_Status.Text = "Please upload a file first!"
            Exit Sub
        End If

        If IO.Path.GetExtension(filMyFile.PostedFile.FileName) = "txt" Then
            label_Status.Text = "Please upload text files only!"
            Exit Sub
        End If

        Dim fp As IO.StreamReader
        Dim myFile As HttpPostedFile = filMyFile.PostedFile
        Dim myFile_Length As Integer = myFile.ContentLength
        Dim myFile_Name As String = IO.Path.GetFileName(myFile.FileName)

        If myFile_Length = 0 Then
            label_Status.Text = "Empty File!"
            Exit Sub
        End If

        Dim myData(myFile_Length) As Byte
        myFile.InputStream.Read(myData, 0, myFile_Length)

        textbox_Upload.Text = ""

        If WriteToFile(Server.MapPath(".\App_LocalResources\Upload\") + myFile_Name, myData) Then
            Try
                Dim dc As New DataConnection
                Dim Fail As Integer = 0
                dc.ConnectionString = Connection_String()
                If Not dc.OpenConnection() Then
                    label_Status.Text = "Server Busy!"
                    Exit Sub
                End If
                Dim line As String = ""
                fp = IO.File.OpenText(Server.MapPath(".\App_LocalResources\Upload\") & myFile_Name)
                While Not fp.EndOfStream
                    line = fp.ReadLine
                    textbox_Upload.Text += line + vbNewLine
                    If Not line.Trim = "" Then
                        Try
                            Dim query As String = ""
                            Dim lines() As String = line.Split(",")
                            Select Case lines(0).ToUpper
                                Case "U"
                                    query = "UPDATE Extract_dtl SET uDateReleased='" & lines(3) & "' WHERE crn='" & lines(1) & "' AND GSUSeries='" & lines(2) & "'"
                                Case "GM"
                                    query = "UPDATE Extract_dtl SET gmDateReleased='" & lines(3) & "' WHERE crn='" & lines(1) & "' AND gsis_no='" & lines(2) & "'"
                                Case "GB"
                                    query = "UPDATE Extract_dtl SET gbDateReleased='" & lines(3) & "' WHERE crn='" & lines(1) & "' AND gsis_no='" & lines(2) & "'"
                                Case Else
                                    query = ""
                                    Fail += 1
                            End Select

                            If Not query = "" Then
                                If Not dc.Execute(query) Then
                                    Fail += 1
                                End If
                            End If
                        Catch ex As Exception
                            Fail += 1
                        End Try
                    End If
                End While

                fp.Close()
                dc.CloseConnection()
                label_Status.Text = "File has been Uploaded with " + Fail.ToString + " Error(s)"

            Catch err As Exception
                label_Status.Text = "Error <br><br>" & err.ToString()
            End Try
        Else
            label_Status.Text = "Failed to upload text file."
        End If

    End Sub
End Class