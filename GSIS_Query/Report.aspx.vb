Public Partial Class Report1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not CBool(Session("AUTHENTICATED")) Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub button_PerBatch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button_PerBatch.Click
        If CBool(Session("AUTHENTICATED")) Then
            Session("FROM") = textbox_From.Text.Trim
            Session("TO") = textbox_To.Text.Trim
            Response.Redirect("ReportPerBatch.aspx")
        End If
    End Sub

    Protected Sub button_PerGSU_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button_PerGSU.Click
        If CBool(Session("AUTHENTICATED")) Then
            Session("FROM") = textbox_From.Text.Trim
            Session("TO") = textbox_To.Text.Trim
            Response.Redirect("ReportPerGSU.aspx")
        End If
    End Sub
End Class