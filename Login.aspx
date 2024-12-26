<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ITSG_Inventory.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ITSG Inventory Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="LoginPage/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row main-content bg-success text-center">
                <div class="col-md-4 text-center company__info">
                    <span class="company__logo">
                        <h2>
                            <span>
                                <img src="LoginPage/img/imageLogo.png" height="60%" width="60%" />
                            </span>
                        </h2>
                    </span>
                    <h4 class="company_title">Inventory System</h4>
                </div>
                <div class="col-md-8 col-xs-12 col-sm-12 login_form ">
                    <div class="container-fluid">
                        <div class="row">
                            <h2>Log In</h2>
                        </div>
                        <div class="row">
                            <div class="row">
                                <asp:TextBox runat="server" ID="txtuser" placeholder="Username/Domain" class="form__input" Style="text-align: center;"></asp:TextBox>
                            </div>
                            <div class="row">
                                <asp:TextBox runat="server" ID="txtpass" placeholder="Password" TextMode="Password" class="form__input" Style="text-align: center;"></asp:TextBox>
                            </div>
                            <div class="row">
                                <asp:Label runat="server" ID="lblerror" class="form_label" Style="color: red;" Visible="false"></asp:Label>
                            </div>
                            <div class="row">
                                <center>
                                    <asp:Button runat="server" ID="btnlogin" Text="Submit" class="btn1" OnClick="btnlogin_Click" />
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
