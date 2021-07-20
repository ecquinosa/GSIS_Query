Public Partial Class Login
    Inherits System.Web.UI.Page

    Protected Function ValidateFields(ByRef Status As String) As Boolean

        If textbox_Password.Text.Trim = "" Then
            Status = "Please enter old password."
            Return False
        End If

        If textbox_NewPassword.Text.Trim = "" Then
            Status = "Please enter new password."
            Return False
        End If

        If textbox_ConfirmPassword.Text.Trim = "" Then
            Status = "Please confirm your new password."
            Return False
        End If

        If Not textbox_NewPassword.Text.Trim = textbox_ConfirmPassword.Text.Trim Then
            Status = "Please confirm your new password."
            Return False
        End If

        Status = ""

        Return True

    End Function

    Protected Function Authenticate(ByVal Username As String, ByVal Password As String) As Boolean

        Dim dc As New DataConnection
        dc.ConnectionString = Connection_String()
        Authenticate = dc.Seek("SELECT * FROM table_Users WHERE USER_USER_NAME='" & Username & "' AND USER_PASSWORD = '" & Password & "'")

        'If Authenticate Then
        '    Try
        '        Dim log As New IO.StreamWriter(Server.MapPath(".\App_LocalResources\Usage_Log.txt"), True)
        '        log.WriteLine(Username + vbTab + Now.ToShortTimeString + " " + Now.ToShortDateString)
        '        log.Flush()
        '        log.Close()
        '    Catch ex As Exception
        '    End Try
        'End If

    End Function

    Protected Function UpdatePassword(ByVal Username As String, ByVal OldPassword As String, ByVal NewPassword As String) As Boolean

        Dim dc As New DataConnection
        dc.ConnectionString = Connection_String()
        UpdatePassword = dc.ExecuteCommand("UPDATE table_Users SET USER_PASSWORD='" + NewPassword + "' WHERE USER_USER_NAME='" + Username + "' AND USER_PASSWORD='" + OldPassword + "'")

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'On Error Resume Next
        'If Not IO.File.Exists(Server.MapPath(".\App_LocalResources\Usage_Log.txt")) Then
        '    IO.File.Create(Server.MapPath(".\App_LocalResources\Usage_Log.txt")).Close()
        'End If
        Session.Clear()
    End Sub

    Protected Sub button_Login_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button_Login.Click
        If Authenticate(textbox_Username.Text, textbox_Password.Text) Then
            If textbox_Username.Text.Trim = textbox_Password.Text.Trim Then
                panel_ChangePassword.Visible = True
                button_Login.Visible = False
                label_Status.Text = "Please change your password now."
                textbox_Username.ReadOnly = True
            Else
                panel_ChangePassword.Visible = False
                Session.Add("AUTHENTICATED", True)
                Session.Add("USER", textbox_Username.Text)
                Session.Add("FROM", "0")
                Session.Add("TO", "0")
                Session.Add("PICTURE_BUFFER", Nothing)
                Response.Redirect("Home.aspx")
            End If
        Else
            panel_ChangePassword.Visible = False
            button_Login.Visible = True
            textbox_Username.ReadOnly = False
            label_Status.Text = "Invalid Login Credentials"
        End If
    End Sub

    Protected Sub button_ChangePassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button_ChangePassword.Click
        If ValidateFields(label_Status.Text) Then
            If UpdatePassword(textbox_Username.Text.Trim, textbox_Password.Text.Trim, textbox_NewPassword.Text.Trim) Then
                panel_ChangePassword.Visible = False
                Session.Add("AUTHENTICATED", True)
                Session.Add("USER", textbox_Username.Text)
                Session.Add("FROM", "0")
                Session.Add("TO", "0")
                Session.Add("PICTURE_BUFFER", Nothing)
                Response.Redirect("Home.aspx")
            Else
                label_Status.Text = "Unable to change password"
            End If
        End If
    End Sub
End Class