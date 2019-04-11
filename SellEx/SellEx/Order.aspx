<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="SellEx.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 350px;
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList2" runat="server" DataKeyField="PID" DataSourceID="SqlDataSource1" OnItemCommand="DataList2_ItemCommand">
                <ItemTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label1" runat="server" BackColor="#33CCFF" Font-Size="Large" Text='<%# Eval("ProductName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label3" runat="server" BackColor="#33CCFF" Font-Size="Large" Text="price:    "></asp:Label>
                                <asp:Label ID="Label2" runat="server" BackColor="#33CCFF" Font-Size="Large" Text='<%# Eval("Price") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label4" runat="server" BackColor="#33CCFF" Font-Size="Large" Text="Contact:    "></asp:Label>
                                <asp:Label ID="Label5" runat="server" BackColor="#33CCFF" Font-Size="Large" Text='<%# Eval("Phone") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label6" runat="server" BackColor="#33CCFF" Font-Size="Large" Text="To buy this product please contact the above number and after contact if you
                                    willing to buy please press the order button"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Button ID="Button1" runat="server" BackColor="#33CCFF" Height="35px" Text="Order" Width="80px" CommandName="GetText" CommandArgument='<%#Eval("ProductName") %>'/>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Product] WHERE ([PID] = @PID)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="PID" QueryStringField="id" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
