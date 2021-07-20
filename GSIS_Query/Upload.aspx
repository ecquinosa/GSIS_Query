<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master"
    CodeBehind="Upload.aspx.vb" Inherits="GSIS_Query.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form id="Form1" method="post" enctype="multipart/form-data">--%>
    <div align="center">
        <br />
        <table>
            <tr>
                <td>
                    <%--<p align="center">
                        <b>Uploading of data may take a while. Please be patient.</b></p>--%>
                    <p align="center">
                        <b>This page is currently unavailable.</b></p>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="textbox_Upload" TextMode="MultiLine" Rows="10" Columns="60" runat="server"
                        ReadOnly="True" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <table>
                            <tr>
                                <td>
                                    <input id="filMyFile" type="file" runat="server" width="100%" visible="False" />
                                </td>
                                <td>
                                    <asp:Button ID="button_Upload" runat="server" Text="Upload" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label_Status" Font-Bold="True" ForeColor="#ff0000" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <%-- </form>--%>
</asp:Content>
