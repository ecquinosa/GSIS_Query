Public Partial Class Query_GSU
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not CBool(Session("AUTHENTICATED")) Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub button_Submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button_Submit.Click
        On Error Resume Next
        If textbox_GSUFilename.Text.Trim = "" Then
            label_Query.Text = "Please enter value first."
            grid_Query.DataSource = Nothing
            grid_Query.DataBind()
            grid_GSU_ReleaseDetail.DataSource = Nothing
            grid_GSU_ReleaseDetail.DataBind()
            label_Summary.Visible = False
        Else

            Dim dc As New DataConnection
            Dim dt_Return As DataTable
            Dim dt_ReleaseSummary As DataTable

            dc.ConnectionString = Connection_String()

            dt_Return = dc.ExecuteDataTable("spGet_GSU_Details '" & textbox_GSUFilename.Text & "'")
            If dt_Return.Rows.Count = 0 Then
                label_Query.Text = "No records found for " + textbox_GSUFilename.Text
                grid_Query.DataSource = Nothing
                grid_Query.DataBind()
                grid_GSU_ReleaseDetail.DataSource = Nothing
                grid_GSU_ReleaseDetail.DataBind()
                label_Summary.Visible = False
                Exit Sub
            Else
                grid_Query.DataSource = dt_Return
                grid_Query.DataBind()

                dt_ReleaseSummary = dc.ExecuteDataTable("spGet_GSU_ReleaseSummary '" & textbox_GSUFilename.Text & "'")
                If dt_ReleaseSummary.Rows.Count = 0 Then
                    label_Summary.Visible = False
                    grid_GSU_ReleaseDetail.DataSource = Nothing
                Else
                    label_Summary.Visible = True
                    grid_GSU_ReleaseDetail.DataSource = dt_ReleaseSummary
                End If

                grid_GSU_ReleaseDetail.DataBind()

            End If
        End If
    End Sub

    'Private Sub grid_GSU_ReleaseDetail_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grid_GSU_ReleaseDetail.PageIndexChanging
    '    grid_GSU_ReleaseDetail.PageIndex = e.NewPageIndex
    '    grid_GSU_ReleaseDetail.DataSource = dt_ReleaseSummary
    '    grid_GSU_ReleaseDetail.DataBind()
    'End Sub

End Class