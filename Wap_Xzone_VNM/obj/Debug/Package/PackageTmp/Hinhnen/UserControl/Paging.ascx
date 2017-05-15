<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Paging.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControl.Paging" %>
<div style="text-align: center;" class="item">
    <asp:Literal ID="ltrNoData" runat="server" Visible="false">Du lieu cua muc nay hien dang duoc cap nhat.</asp:Literal>
    <asp:HyperLink ID="lnkFirst" CssClass="bold" runat="server">«</asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" CssClass="bold" runat="server">&lt;</asp:HyperLink>
    <asp:Repeater ID="rptPage" runat="server">
        <ItemTemplate>
            <asp:Label ID="ltrPage" CssClass="bold" runat="server" /> 
            <asp:Literal ID="ltrGach" runat="server">|</asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkNext" CssClass="bold" runat="server">&gt;</asp:HyperLink>
    <asp:HyperLink ID="lnkLast" CssClass="bold" runat="server">»</asp:HyperLink>
    <div class="clearfix"></div>
</div>



