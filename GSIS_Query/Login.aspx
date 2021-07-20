<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master"
    CodeBehind="Login.aspx.vb" Inherits="GSIS_Query.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" style="text-align: center; color: #FFFFFF; font-weight: bold;">
        <asp:Label ID="label_Status" runat="server" Text="Please login"></asp:Label>
        <table align="center" style="text-align: center; color: #FFFFFF; font-weight: bold;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Username" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textbox_Username" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textbox_Password" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="button_Login" runat="server" Text="Submit" Width="100%" />
                </td>
            </tr>
        </table>
        <br />
        <div align="center">
            <asp:Panel ID="panel_ChangePassword" runat="server" Visible="False">
                <table style="border: thin solid #FFFFFF; text-align: center; color: #FFFFFF; font-weight: bold;">
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="New Password" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_NewPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Confirm" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textbox_ConfirmPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="button_ChangePassword" runat="server" Text="Change Password" Width="100%" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
