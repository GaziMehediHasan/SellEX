<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="SellEx.Items" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 165px;
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
            <asp:DataList ID="DataList2" runat="server" DataKeyField="PID" DataSourceID="SqlDataSource1" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList2_ItemCommand">
                <ItemTemplate>
                    <br />
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">
                                <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# Eval("Image") %>' Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label1" runat="server" BackColor="#33CCFF" Font-Size="Large" Text='<%# Eval("ProductName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label3" runat="server" BackColor="#66CCFF" Font-Size="Large" Text="Price:    "></asp:Label>
                                <asp:Label ID="Label2" runat="server" BackColor="#66CCFF" Font-Size="Large" Text='<%# Eval("Price") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Button ID="Button1" runat="server" BackColor="Blue" Height="35px" Text="View Details" Width="75px" CommandName="viewdetail" CommandArgument='<%#Eval("PID") %>'/>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
