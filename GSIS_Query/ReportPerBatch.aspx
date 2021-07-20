<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master"
    CodeBehind="ReportPerBatch.aspx.vb" Inherits="GSIS_Query.ReportPerBatch" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="100%">
            <table>
                <tr>
                    <td align="center">
                        <asp:HyperLink ID="line_Report" runat="server" NavigateUrl="~/Report.aspx">Back to Report Summary</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <CR:CrystalReportViewer ID="reportViewer_PerBatch" runat="server" AutoDataBind="true"
                            ReportSourceID="report_PerBatch" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False"
                            EnableParameterPrompt="False" Width="1029px" Height="798px" />
                        <CR:CrystalReportSource ID="report_PerBatch" runat="server">
                            <Report FileName="Reports\DataPerBatch.rpt">
                            </Report>
                        </CR:CrystalReportSource>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
