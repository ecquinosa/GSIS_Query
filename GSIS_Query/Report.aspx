<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Report.aspx.vb" Inherits="GSIS_Query.Report1"
    MasterPageFile="~/GSIS_Query.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table style="text-align: center">
            <tr>
                <td>
                    <p style="font-weight: bold; font-family: calibri">
                        Download GSIS Report</p>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="From" Width="60px" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textbox_From" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="To" Width="60px" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textbox_To" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="button_PerBatch" runat="server" Text="Sort By Batch" Width="150px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="button_PerGSU" runat="server" Text="Sort By GSU" Width="150px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
