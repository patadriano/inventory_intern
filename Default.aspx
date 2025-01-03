<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test_Inventory._Default" %>





<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - ASP.NET</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Additional CSS or JS Files -->
</head>

<body>
    <div class="container">
        <main>
            <section class="row" aria-labelledby="aspnetTitle">
                <h1 id="aspnetTitle">ASP.NET</h1>
                <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
                <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
            </section>

            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <!-- Login Form -->
                    <h2>Login</h2>
                    <asp:TextBox runat="server" ID="txtuser" CssClass="form-control" placeholder="Username/Domain" />
                    <asp:TextBox runat="server" ID="txtpassword" CssClass="form-control" placeholder="Password" TextMode="Password" />
                    <br />
                    <asp:Button runat="server" ID="btnlogin" Text="Login" OnClick="btnlogin_Click" CssClass="btn btn-primary btn-md" />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
                </div>
            </div>
        </main>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>

</body>

</html>



