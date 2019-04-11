<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complain.aspx.cs" Inherits="SellEx.Complain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Complain Box</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="margin:0px">
            <div class="row">
                <div class="col-md-3" style="padding-bottom:10px">
                    <asp:Label ID="Label2" runat="server" Text="Name" style="padding-left:10px"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Email" style="padding-left:25px"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Messege" style="padding-left:60px"></asp:Label>
                </div>
            </div>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
