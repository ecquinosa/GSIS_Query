Public Partial Class ReportPerBatch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If CBool(Session("AUTHENTICATED")) Then
            If Not Session("FROM") = "" Or Session("TO") = "" Then
                Try
                    report_PerBatch.ReportDocument.SetParameterValue(0, Session("FROM"))
                    report_PerBatch.ReportDocument.SetParameterValue(1, Session("TO"))
                    report_PerBatch.ReportDocument.SetDatabaseLogon(My.Settings.Username, Enc.TripleDesDecryptText(My.Settings.Password), My.Settings.Server, My.Settings.Database)
                Catch ex As Exception
                    Response.Redirect("Report.aspx")
                End Try
            Else
                Response.Redirect("Report.aspx")
            End If
        Else
            Response.Redirect("Login.aspx")
        End If
    End Sub

End Class