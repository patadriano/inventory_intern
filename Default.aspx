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
          <asp:Repeater runat=”server” ID=”repeater1″>
            <ItemTemplate>
            <asp:Image ID=”Image1″ ImageUrl=<%# Eval(“Url”) %> runat=”server” Width=”200px” Height=”200px” />
            </ItemTemplate>
            </asp:Repeater>
        </main>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>

</body>

</html>



