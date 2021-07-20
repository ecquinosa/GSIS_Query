Public Partial Class CPS_Status
    Inherits System.Web.UI.Page

    'USE dbcCPS exec dbo.prcActivityStatusCount

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not CBool(Session("AUTHENTICATED")) Then
            Response.Redirect("Login.aspx")
        Else
            Dim objDC As New DataConnection
            objDC.ConnectionString = Connection_String()
            Dim dt_CPS_Activity As DataTable = objDC.ExecuteDataTable("USE dbcCPS exec dbo.prcActivityStatusCount 1")

            If dt_CPS_Activity.Rows.Count = 0 Then
                label_Query.Text = "CPS Status Unavailable"
            Else
                grid_Query.DataSource = dt_CPS_Activity
                grid_Query.DataBind()
            End If
        End If
    End Sub

End Class