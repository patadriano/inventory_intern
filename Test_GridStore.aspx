

<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test_GridStore.aspx.cs" Inherits="Test_Inventory.Test_GridStore" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<asp:Repeater ID="rptProducts" runat="server">
    <HeaderTemplate>
        <div style="display: grid; grid-template-columns: repeat(3, 1fr); gap: 20px; margin: 20px;">
    </HeaderTemplate>
    <ItemTemplate>
        <div style="border: 1px solid #ddd; padding: 15px; background-color: #fff; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); text-align: center; transition: transform 0.3s ease-in-out;">
            <img src="<%# Eval("ImageUrl") %>"  style="width: 100%; height: auto; max-width: 200px; margin-bottom: 15px; object-fit: cover;" />
            <h3 style="font-size: 18px; margin: 10px 0;"> <%# Eval("PostTitle") %> </h3>
            <p style="font-size: 14px; color: #555;"> <%# Eval("PostDesc") %> </p>
            <p style="font-size: 14px; color: #555;"><strong>Post ID:</strong> <%# Eval("PostID") %></p>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div> <!-- Closing product-grid div -->
    </FooterTemplate>
</asp:Repeater>


</asp:Content>
