<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SellEx.MyProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile</title>
    <link href="CSS/logincss.css" rel="stylesheet" />
</head>
<body>
    <div class="limiter">
		<div class="container-login100" style="background-image: url('Image/bag1.jpg');">
			<div class="wrap-login100">
                <form class="form1" runat="server">
                    <span class="login100-form-title p-b-34 p-t-27">
                        My Profile
                    </span>
                    <br />
                    <span class="login100-form-logo">
                        <i class="zmdi zmdi-landscape"></i>
                    </span>
                    <br />
                    <div class="wrap-input100 validate-input">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                    <br />
                    <div class="wrap-input100 validate-input" data-validate="Enter password">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div>
                        
                    </div>
                </form>
			</div>
		</div>
	</div>
</body>
</html>
