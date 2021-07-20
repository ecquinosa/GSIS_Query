<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master"
    CodeBehind="Query_GSU.aspx.vb" Inherits="GSIS_Query.Query_GSU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table align="center" style="text-align: center; color: #FFFFFF; font-weight: bold;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="GSU Filename" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textbox_GSUFilename" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="button_Submit" runat="server" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <table style="text-align: center; color: #FFFFFF; font-weight: bold;">
            <tr>
                <td>
                    <asp:Label ID="label_Query" runat="server" Text="Please Enter Query"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grid_Query" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None">
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
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label_Summary" runat="server" Text="Release Summary" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grid_GSU_ReleaseDetail" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None" AutoGenerateColumns="False" PageSize="5">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="Date Released" DataFormatString="{0:d}" 
                                HeaderText="Date Released" NullDisplayText="NO DATE FOUND" />
                            <asp:BoundField DataField="Quantity Released" HeaderText="Quantity Released" />
                        </Columns>
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
