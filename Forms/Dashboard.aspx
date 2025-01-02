<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Test_Inventory.Forms.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblusername" Class="dropdown-item" />
    <asp:Button runat="server" ID="btnpop" Text="pop" OnClick="btnpop_Click" />

    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!-- Modal as Panel -->
            <asp:Panel ID="popupModal" runat="server" Visible="false" CssClass="popup-container">
                <div class="popup-content">
                    <div class="popup-header">
                        <h4>Popup Title</h4>
                        <button class="close-btn" OnClick="btnClose_Click">×</button>
                    </div>
                    <div class="popup-body">
                        <p>This is the content inside the popup modal.</p>
                    </div>
                    <div class="popup-footer">
                        <button class="btn btn-success" OnClick="btnClose_Click">Close</button>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
     <asp:UpdatePanel runat="server">
     <ContentTemplate>
         <div id="popupModal" class="modal" runat="server" visible="false" style="display: block; z-index: 1000; background-color: rgba(0, 0, 0, 0.37); overflow-y: auto;" autopostback="true">
             <div class="modal-dialog modal-lg modal-dialog-top">
                 <div class="modal-content">
                     <div class="modal-header">
                         <div class="modal-title" style="text-align: center;">
                             <h5>Equipment List</h5>
                         </div>
                         <asp:Button runat="server" ID="btnmodalclose" class="btn btn-close" OnClick="btnClose_Click"></asp:Button>
                     </div>
                     <div class="modal-body" style="overflow: auto;">
                         <div class="container-fluid" style="height: 400px; overflow: auto;">

             

                         </div>
                     </div>
                     <div class="modal-footer" runat="server" id="modalfooter">
                         <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                             <ContentTemplate>
                                 <div class="row">
                                     <div class="col">
                                         <div class="row">
                                             <%--<div class="col px-1">
                                                 <asp:Button runat="server" ID="btnreclaim" Text="Reclaim" OnClick="btnreclaim_Click" CssClass="btn btn-danger" />
                                             </div>
                                             <div class="col px-1">
                                                 <asp:Button runat="server" ID="btnadd" Text="Add" OnClick="btnadd_Click" CssClass="btn btn-primary" />
                                             </div>
                                             <div class="col px-1">
                                                 <asp:Button runat="server" ID="btnsave" Text="Save" CssClass="btn btn-success" autopostback="true" OnClick="btnsave_Click" />
                                             </div>--%>
                                         </div>
                                     </div>
                                 </div>
                             </ContentTemplate>
                         </asp:UpdatePanel>
                     </div>
                 </div>
             </div>

         </div> 
     </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
