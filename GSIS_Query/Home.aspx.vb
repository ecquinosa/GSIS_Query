Partial Public Class Home
    Inherits System.Web.UI.Page

    Private dt_OpenBatches As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not CBool(Session("AUTHENTICATED")) Then
                Response.Redirect("Login.aspx")
            Else

                label_Username.Text = Session("USER")

                Dim dc As New DataConnection
                Dim dt_Summary As New DataTable
                Dim Batches, TotalGSIS, TotalUBP, Released, Reprint, ReprintReleased As Long
                Dim GSU As String
                Dim row As DataRow

                dc.ConnectionString = Connection_String()

                TotalGSIS = dc.GetValue("SELECT COUNT(crn) FROM dbo.UMID WHERE AGENCY='GSIS'")
                TotalUBP = dc.GetValue("SELECT COUNT(crn) FROM dbo.Extract_dtl WHERE Batch NOT BETWEEN 17 and 22")
                Batches = dc.GetValue("SELECT Max(batch_name) FROM dbo.Extract_hdr")
                Released = dc.GetValue("SELECT COUNT(crn) FROM dbo.Extract_dtl WHERE isReleased=1")
                Reprint = dc.GetValue("SELECT COUNT(crn) FROM dbo.Extract_dtl_reprint")
                ReprintReleased = dc.GetValue("SELECT COUNT(crn) FROM dbo.Extract_dtl_reprint WHERE isReleased=1")
                GSU = dc.GetValue("SELECT Max(GSUfilename) FROM dbo.Extract_hdr")

                dt_OpenBatches = dc.ExecuteDataTable("spGet_OpenBatch")

                dt_Summary.Columns.Add("GSIS UMID Summary")
                dt_Summary.Columns.Add("")

                row = dt_Summary.NewRow
                row(0) = "Current Batch"
                row(1) = Batches.ToString
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = "Current GSU"
                row(1) = GSU
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = ""
                row(1) = ""
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = "Data Summary"
                row(1) = ""
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = "GSIS"
                row(1) = TotalGSIS.ToString
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = "UBP"
                row(1) = TotalUBP.ToString
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = "Replacement"
                row(1) = Reprint.ToString
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = ""
                row(1) = ""
                dt_Summary.Rows.Add(row)

                row = dt_Summary.NewRow
                row(0) = "Total Released"
                row(1) = CStr(Released + ReprintReleased)
                dt_Summary.Rows.Add(row)

                'row = dt_Summary.NewRow
                'row(0) = ""
                'row(1) = ""
                'dt_Summary.Rows.Add(row)

                grid_Summary.DataSource = dt_Summary
                grid_Summary.DataBind()

                grid_OpenBatches.DataSource = dt_OpenBatches
                grid_OpenBatches.DataBind()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grid_OpenBatches_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grid_OpenBatches.PageIndexChanging
        grid_OpenBatches.PageIndex = e.NewPageIndex
        grid_OpenBatches.DataSource = dt_OpenBatches
        grid_OpenBatches.DataBind()
    End Sub

End Class