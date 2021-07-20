<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master"
    CodeBehind="ReportPerGSU.aspx.vb" Inherits="GSIS_Query.ReportPerGSU" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Panel ID="Panel1" runat="server" BackColor="White">
            <table>
                <tr>
                    <td align="center">
                        <asp:HyperLink ID="link_Report" runat="server" NavigateUrl="Report.aspx">Back to Summary Report</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="color:Black;">
                        <CR:CrystalReportViewer ID="reportViewer_PerGSU" runat="server" AutoDataBind="true"
                            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReportSourceID="reportSource_PerGSU"
                            DisplayGroupTree="False" />
                        <CR:CrystalReportSource ID="reportSource_PerGSU" runat="server">
                            <Report FileName="Reports\DataPerGSU.rpt">
                            </Report>
                        </CR:CrystalReportSource>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
