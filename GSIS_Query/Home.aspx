<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master"
    CodeBehind="Home.aspx.vb" Inherits="GSIS_Query.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <br />
        <b>Welcome </b>
        <asp:Label ID="label_Username" runat="server" Font-Bold="True"></asp:Label><b> to Allcard
            UMID Online Inquiry </b>
        <br />
        <b>Please select a task</b>
        <br />
        <br />
    </div>
    <div align="center">
        <table>
            <tr>
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                                <p align="center" style="font-weight: bold; font-family: calibri">
                                    GSIS UMID Report Summary</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grid_Summary" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="Horizontal" Font-Bold="True" Font-Size="Large" 
                                    ShowHeader="False">
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
                </td>
                <td>
                </td>
                <td>
                </td>
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                                <p align="center" style="font-weight: bold; font-family: calibri">
                                    Open Batches</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grid_OpenBatches" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AllowPaging="True">
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
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
