<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GSIS_Query.Master"
    CodeBehind="Query.aspx.vb" Inherits="GSIS_Query.Query" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="dropdown_Query" runat="server" Width="100" 
                        AutoPostBack="True">
                        <asp:ListItem>CRN</asp:ListItem>
                        <asp:ListItem>CSN</asp:ListItem>
                        <asp:ListItem>GSIS #</asp:ListItem>
                        <asp:ListItem>GSU #</asp:ListItem>
                        <asp:ListItem>First Name</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="textbox_SearchValue1" runat="server" Width="200" />
                </td>
                <td>
                    <asp:Button Text="Submit" ID="button_Query" runat="server" Width="200" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label_SearchValue2" runat="server" Text="Last Name" 
                        Visible="False" CssClass="label_align" Width="90px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textbox_SearchValue2" runat="server" Width="200" Visible="False" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
        <table style="text-align: center; color: #FFFFFF; font-weight: bold;">
            <tr>
                <td>
                    <asp:Label ID="label_Query" runat="server" Text="Please Enter Query"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grid_Query" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="crn" HeaderText="Crn" />
                            <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                            <asp:BoundField DataField="first_name" HeaderText="First Name" />
                            <asp:BoundField DataField="middle_name" HeaderText="Middle Name" />
                            <asp:BoundField DataField="barcode" HeaderText="CSN" />
                            <asp:BoundField DataField="GSUfilename" HeaderText="GSU Filename" />
                            <asp:BoundField DataField="batch" HeaderText="Batch" />
                            <asp:ButtonField Text="Select">
                                <ItemStyle ForeColor="Red" />
                            </asp:ButtonField>
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
        <br />
    </div>
    <div align="center">
        <asp:MultiView ID="multiview_Main" runat="server">
            <asp:View ID="view_Details" runat="server">
                <table>
                    <tr>
                        <td>
                            <table  bgcolor="white" style="border: thin solid #FF0000; padding: inherit; margin: auto; font-family: Verdana;
                                color: black; text-align: left" border="1" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" BackColor="White" Text="CRN" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_CRN" runat="server" BackColor="White" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" BackColor="White" Text="CSN" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_CSN" runat="server" BackColor="White" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" BackColor="White" Text="First Name" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_FirstName" runat="server" BackColor="White" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" BackColor="White" Text="Middle Name" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_MiddleName" runat="server" BackColor="White" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" BackColor="White" Text="Last Name" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_LastName" runat="server" BackColor="White" Text="" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" BackColor="White" Text="Birthdate" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_Birthdate" runat="server" BackColor="White" Text="" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="White">
                                        <asp:Label ID="Label13" runat="server" BackColor="White" Text="Address" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_Address" runat="server" BackColor="White" Text="" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div style="font-family: Verdana; color: black; border-right-style: solid; border-left-style: solid;
                                border-right-width: thin; border-left-width: thin; border-right-color: #FF0000;
                                border-left-color: #FF0000; border-top-style: solid; border-top-width: thin;
                                border-top-color: #FF0000;">
                                <asp:Label ID="Label8" runat="server" BackColor="White" Text="RELEASE DETAILS" Width="514px"></asp:Label>
                            </div>
                            <table  bgcolor="white" style="font-family: Verdana; color: black; border-right-width: thin; border-bottom-width: thin;
                                border-left-width: thin; border-right-style: solid; border-bottom-style: solid;
                                border-left-style: solid; border-right-color: #FF0000; border-bottom-color: #FF0000;
                                border-left-color: #FF0000;" border="1" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="label6" runat="server" BackColor="White" Text="Allcard" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_Allcard" runat="server" BackColor="White" Text="" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="label7" runat="server" BackColor="White" Text="Unionbank" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_Unionbank" runat="server" BackColor="White" Text="NOT YET AVAILABLE"
                                            Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="label10" runat="server" BackColor="White" Text="GSIS Main" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_GsisMain" runat="server" BackColor="White" Text="NOT YET AVAILABLE"
                                            Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="label12" runat="server" BackColor="White" Text="GSIS Branch" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_GsisBranch" runat="server" BackColor="White" Text="NOT YET AVAILABLE"
                                            Width="400px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                             <div style="font-family: Verdana; color: black; border-right-style: solid; border-left-style: solid;
                                border-right-width: thin; border-left-width: thin; border-right-color: #FF0000;
                                border-left-color: #FF0000; border-top-style: solid; border-top-width: thin;
                                border-top-color: #FF0000;">
                                <asp:Label ID="Label11" runat="server" BackColor="White" Text="ADDITIONAL GSIS INFO" Width="514px"></asp:Label>
                            </div>
                            <table  bgcolor="white" style="font-family: Verdana; color: black; border-right-width: thin; border-bottom-width: thin;
                                border-left-width: thin; border-right-style: solid; border-bottom-style: solid;
                                border-left-style: solid; border-right-color: #FF0000; border-bottom-color: #FF0000;
                                border-left-color: #FF0000;" border="1" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="label14" runat="server" BackColor="White" Text="INFO_1" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_Info1" runat="server" BackColor="White" Text="NOT AVAILABLE" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="label16" runat="server" BackColor="White" Text="INFO_2" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_Info2" runat="server" BackColor="White" Text="NOT AVAILABLE"
                                            Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="label18" runat="server" BackColor="White" Text="INFO_3" Width="110px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="label_Info3" runat="server" BackColor="White" Text="NOT AVAILABLE"
                                            Width="255px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="label_GSIS" runat="server" Text="" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="label_GSU" runat="server" Text="" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <span id="Data" value="<%=GetCopy()%>"></span>
                                        </td>
                                        <td>
                                            <a href="javascript:clipper()" style="color: #FFFFFF; font-weight: bold">Copy</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td valign=top>
                            <asp:Image ID="image_Photo" runat="server" Height="320px" ImageAlign="Middle" Width="240px"/>
                            <%--<asp:ImageMap ID="image_Photo" runat="server" Height="320px" ImageAlign="Right" Width="240px">
                            </asp:ImageMap>--%>
                        </td>
                    </tr>
                </table>
                <div align="center">
                    <asp:Label ID="label_Status" runat="server" Text="" ForeColor="White"></asp:Label></div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
