<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master" CodeBehind="CPS_Status.aspx.vb" Inherits="GSIS_Query.CPS_Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table style="text-align: center; color: #FFFFFF; font-weight: bold;">
            <tr>
                <td>
                    <asp:Label ID="label_Query" runat="server" Text="CPS Activity Summary"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grid_Query" runat="server" CellPadding="4"
                        ForeColor="#333333" GridLines="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
