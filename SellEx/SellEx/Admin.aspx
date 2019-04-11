<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SellEx.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
	<title>Admin</title>
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="CSS/admin.css" rel="stylesheet" />
    <link href="CSS/Font.css" rel="stylesheet" />
</head>
<body class="form-v9">
    <div class="page-content">
        <div class="form-v9-content">
            <form class="form-detail" runat="server">
                <center>
                <div>
                    <asp:Button ID="Button3" runat="server" Text="Messege" width="180px" OnClick="Button3_Click" />
                </div>
               </center>
                <h2>Admin Panel</h2>
                <div class="form-row-total">
                    <div class="form-row">
                        <asp:TextBox ID="TextBox1" class="input-text" placeholder="Product Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <asp:TextBox ID="TextBox2" class="input-text" placeholder="User Email" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row-total">
                    <div class="form-row-last">
                        <asp:Button ID="Button1" runat="server" Text="Remove" OnClick="Button1_Click" />
                    </div>
                    <div class="form-row-last">
                        <asp:Button ID="Button2" runat="server" Text="Deactivate" OnClick="Button2_Click" />
                    </div>
                </div>
                <div class="form-row-last">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
