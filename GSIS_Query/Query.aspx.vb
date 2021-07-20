Public Partial Class Query
    Inherits System.Web.UI.Page


    Protected Function GetCPS_Status(ByVal pCRN As String) As String
        Dim cps_Query As String = "sp_GetCPS_Status " + "'" & pCRN & "',1"

        Dim dc As New DataConnection
        dc.ConnectionString = Connection_String()

        Dim dt_CPS As DataTable = dc.ExecuteDataTable(cps_Query)
        If dt_CPS.Rows.Count = 0 Then
            GetCPS_Status = "NOT YET AVAILABLE"
        Else
            GetCPS_Status = dt_CPS.Rows(0)(1).ToString.ToUpper
        End If

        dt_CPS.Dispose()

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not CBool(Session("AUTHENTICATED")) Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub button_Query_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button_Query.Click

        On Error Resume Next
        If textbox_SearchValue1.Text.Trim = "" Then
            label_Query.Text = "Please enter value first."
            grid_Query.DataSource = Nothing
            grid_Query.DataBind()
        Else

            multiview_Main.Visible = False

            Dim s_Value As String = textbox_SearchValue1.Text.Trim
            Dim s_Value2 As String = textbox_SearchValue2.Text.Trim
            Dim query As String = ""
            Dim dc As New DataConnection
            dc.ConnectionString = Connection_String()

            Select Case dropdown_Query.Text
                Case "CRN"

                    If s_Value.Trim.Length = 12 Then
                        s_Value = s_Value.Substring(0, 3) + "-" + _
                                  s_Value.Substring(3, 4) + "-" + _
                                  s_Value.Substring(7, 4) + "-" + _
                                  s_Value.Substring(11, 1)
                    End If

                    query = "sp_WebQuery '" + s_Value + "','',1"
                    'query = "SELECT * FROM view_getData WHERE crn='" & s_Value & "'"
                Case "CSN"
                    query = "sp_WebQuery '" + s_Value + "','',2"
                    'query = "SELECT * FROM view_getData WHERE barcode='" & s_Value & "'"
                Case "GSIS #"
                    query = "sp_WebQuery '" + s_Value + "','',3"
                    'query = "SELECT * FROM view_getData WHERE gsis_no='" & s_Value & "'"
                Case "GSU #"
                    query = "sp_WebQuery '" + s_Value + "','',4"
                    'query = "SELECT * FROM view_getData WHERE GSUSeries='" & s_Value & "'"
                Case "First Name"
                    query = "sp_WebQuery '" + s_Value + "','" + s_Value2 + "',5"
                    'query = "SELECT * FROM view_getData WHERE first_name='" & s_Value & "' AND last_name='" & s_Value2 & "'"
                Case Else
                    query = "sp_WebQuery '" + s_Value + "','',1"
                    'query = "SELECT * FROM view_getData WHERE crn='" & s_Value & "'"
            End Select

            Dim dt_GSIS As DataTable = dc.ExecuteDataTable(query)
            If dt_GSIS.Rows.Count = 0 Then

                If dropdown_Query.Text = "First Name" Then
                    label_Query.Text = "No records found for " + s_Value + " " + s_Value2
                Else
                    label_Query.Text = "Query Output - " + s_Value
                End If

                grid_Query.DataSource = Nothing
                grid_Query.DataBind()
            Else

                If dropdown_Query.Text = "First Name" Then
                    label_Query.Text = "Query Output - " + s_Value + " " + s_Value2
                Else
                    label_Query.Text = "Query Output - " + s_Value
                End If

                grid_Query.DataSource = dt_GSIS
                grid_Query.DataBind()

                If dt_GSIS.Rows.Count = 1 Then
                    'Dim dt As DataTable = dc.ExecuteDataTable(query)
                    Dim dt As DataTable = dt_GSIS
                    If Not dt.Rows.Count = 0 Then

                        label_CRN.Text = dt(0)("crn").ToString
                        label_CSN.Text = dt(0)("barcode").ToString
                        label_FirstName.Text = dt(0)("first_name").ToString
                        label_MiddleName.Text = dt(0)("middle_name").ToString
                        label_LastName.Text = dt(0)("last_name").ToString
                        label_Birthdate.Text = dt(0)("birthday").ToString
                        label_Address.Text = dt(0)("p_address").ToString
                        label_GSIS.Text = dt(0)("gsis_no").ToString
                        label_GSU.Text = dt(0)("GSUSeries").ToString

                        If CBool(dt(0)("isreleased")) Then
                            If dt(0)("DateReleased").ToString.Trim = "" Then
                                label_Allcard.Text = "RELEASED"
                            Else
                                label_Allcard.Text = CDate(dt(0)("DateReleased").ToString).ToShortDateString
                            End If
                        Else
                            label_Allcard.Text = GetCPS_Status(dt(0)("crn").ToString)
                        End If

                        If dt(0)("uDateReleased").ToString.Trim = "" Then
                            label_Unionbank.Text = "NOT YET AVAILABLE"
                        Else
                            label_Unionbank.Text = CDate(dt(0)("uDateReleased").ToString).ToShortDateString
                        End If

                        If dt(0)("gmDateReleased").ToString.Trim = "" Then
                            label_GsisMain.Text = "NOT YET AVAILABLE"
                        Else
                            label_GsisMain.Text = CDate(dt(0)("gmDateReleased").ToString).ToShortDateString
                        End If

                        If dt(0)("gbDateReleased").ToString.Trim = "" Then
                            label_GsisBranch.Text = "NOT YET AVAILABLE"
                        Else
                            label_GsisBranch.Text = CDate(dt(0)("gbDateReleased").ToString).ToShortDateString
                        End If

                        Dim folder As String = dt(0)("Folder").ToString
                        Dim filename As String = My.Settings.UMID_Raw + "\" + folder + "\" + dt(0)("barcode").ToString + "\" + dt(0)("barcode").ToString + "_Photo.jpg"

                        If IO.File.Exists(filename) Then

                            Dim fs As New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
                            Dim picBuffer(fs.Length) As Byte
                            fs.Read(picBuffer, 0, fs.Length)
                            Session("PICTURE_BUFFER") = picBuffer
                            fs.Dispose()

                            System.Threading.Thread.Sleep(1)
                            image_Photo.ImageUrl = "Imager.aspx"
                            label_Status.Text = ""

                        Else
                            image_Photo.ImageUrl = Nothing
                            label_Status.Text = "Photo not found!"
                        End If

                        Dim dt_GSISInfo As DataTable = dc.ExecuteDataTable("SELECT * FROM GSIS_Info WHERE crn='" + label_CRN.Text + "'")
                        If dt_GSISInfo.Rows.Count = 0 Then
                            label_Info1.Text = "NOT AVAILABLE"
                            label_Info2.Text = "NOT AVAILABLE"
                            label_Info3.Text = "NOT AVAILABLE"
                        Else
                            label_Info1.Text = dt_GSISInfo(0)(1).ToString.ToUpper
                            label_Info2.Text = dt_GSISInfo(0)(2).ToString.ToUpper
                            label_Info3.Text = dt_GSISInfo(0)(3).ToString.ToUpper
                        End If

                        multiview_Main.Visible = True
                        multiview_Main.SetActiveView(view_Details)

                    Else
                        multiview_Main.Visible = False
                    End If

                End If

            End If
        End If

    End Sub

    Private Sub grid_Query_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grid_Query.RowCommand

        Dim row As GridViewRow = grid_Query.Rows(Convert.ToInt32(e.CommandArgument))
        Dim dc As New DataConnection
        dc.ConnectionString = Connection_String()

        Dim OldSelectQuery As String = "SELECT TOP 1 * FROM view_getData WHERE barcode='" & row.Cells(4).Text & "'"
        Dim SelectQuery As String = "sp_WebQuery '" + row.Cells(4).Text + "','" + row.Cells(5).Text + "',6"
        Dim dt As DataTable = dc.ExecuteDataTable(SelectQuery)
        If Not dt.Rows.Count = 0 Then

            label_CRN.Text = dt(0)("crn").ToString
            label_CSN.Text = dt(0)("barcode").ToString
            label_FirstName.Text = dt(0)("first_name").ToString
            label_MiddleName.Text = dt(0)("middle_name").ToString
            label_LastName.Text = dt(0)("last_name").ToString
            label_Birthdate.Text = dt(0)("birthday").ToString
            label_Address.Text = dt(0)("p_address").ToString
            label_GSIS.Text = dt(0)("gsis_no").ToString
            label_GSU.Text = dt(0)("GSUSeries").ToString

            If CBool(dt(0)("isreleased")) Then
                If dt(0)("DateReleased").ToString.Trim = "" Then
                    label_Allcard.Text = "RELEASED"
                Else
                    label_Allcard.Text = CDate(dt(0)("DateReleased").ToString).ToShortDateString
                End If
            Else
                label_Allcard.Text = GetCPS_Status(dt(0)("crn").ToString)
            End If

            If dt(0)("uDateReleased").ToString.Trim = "" Then
                label_Unionbank.Text = "NOT YET AVAILABLE"
            Else
                label_Unionbank.Text = CDate(dt(0)("uDateReleased").ToString).ToShortDateString
            End If

            If dt(0)("gmDateReleased").ToString.Trim = "" Then
                label_GsisMain.Text = "NOT YET AVAILABLE"
            Else
                label_GsisMain.Text = CDate(dt(0)("gmDateReleased").ToString).ToShortDateString
            End If

            If dt(0)("gbDateReleased").ToString.Trim = "" Then
                label_GsisBranch.Text = "NOT YET AVAILABLE"
            Else
                label_GsisBranch.Text = CDate(dt(0)("gbDateReleased").ToString).ToShortDateString
            End If

            Dim folder As String = dt(0)("Folder").ToString
            Dim filename As String = My.Settings.UMID_Raw + "\" + folder + "\" + dt(0)("barcode").ToString + "\" + dt(0)("barcode").ToString + "_Photo.jpg"

            If IO.File.Exists(filename) Then

                Dim fs As New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
                Dim picBuffer(fs.Length) As Byte
                fs.Read(picBuffer, 0, fs.Length)
                Session("PICTURE_BUFFER") = picBuffer
                fs.Dispose()

                System.Threading.Thread.Sleep(1)
                image_Photo.ImageUrl = "Imager.aspx"
                label_Status.Text = ""

            Else
                image_Photo.ImageUrl = Nothing
                label_Status.Text = "Photo not found!"
            End If

            Dim dt_GSISInfo As DataTable = dc.ExecuteDataTable("SELECT * FROM GSIS_Info WHERE crn='" + label_CRN.Text + "'")
            If dt_GSISInfo.Rows.Count = 0 Then
                label_Info1.Text = "NOT AVAILABLE"
                label_Info2.Text = "NOT AVAILABLE"
                label_Info3.Text = "NOT AVAILABLE"
            Else
                label_Info1.Text = dt_GSISInfo(0)(1).ToString.ToUpper
                label_Info2.Text = dt_GSISInfo(0)(2).ToString.ToUpper
                label_Info3.Text = dt_GSISInfo(0)(3).ToString.ToUpper
            End If

            multiview_Main.Visible = True
            multiview_Main.SetActiveView(view_Details)

        Else
            multiview_Main.Visible = False
        End If

    End Sub

    Protected Function GetCopy() As String
        Return label_CRN.Text.Trim + vbTab + _
               label_CSN.Text.Trim + vbTab + _
               label_GSIS.Text.Trim + vbTab + _
               label_GSU.Text.Trim + vbTab + _
               label_FirstName.Text.Trim + vbTab + _
               label_MiddleName.Text.Trim + vbTab + _
               label_LastName.Text.Trim + vbTab + _
               label_Allcard.Text.Trim + vbTab + _
               label_Unionbank.Text.Trim + vbTab + _
               label_GsisMain.Text.Trim + vbTab + _
               label_GsisBranch.Text.Trim
    End Function

    Private Sub dropdown_Query_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dropdown_Query.SelectedIndexChanged

        textbox_SearchValue1.Text = ""
        textbox_SearchValue2.Text = ""

        label_SearchValue2.Visible = CBool(dropdown_Query.Text = "First Name")
        textbox_SearchValue2.Visible = CBool(dropdown_Query.Text = "First Name")

        textbox_SearchValue1.Focus()

    End Sub
End Class