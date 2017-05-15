<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Paging.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.Paging" %>

<div style="text-align: center;" class="item-paging">
    <asp:Literal ID="ltrNoData" runat="server" EnableViewState="False" Visible="false">Du lieu cua muc nay hien dang duoc cap nhat.</asp:Literal>
    <asp:HyperLink ID="lnkFirst" CssClass="bold" runat="server" EnableViewState="False">«</asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" CssClass="bold" runat="server" EnableViewState="False">&lt;</asp:HyperLink>
    <asp:Repeater ID="rptPage" runat="server" EnableViewState="False">
        <ItemTemplate>
            <asp:Label ID="ltrPage" CssClass="bold" runat="server" EnableViewState="False" /> 
            <asp:Literal ID="ltrGach" runat="server" EnableViewState="False">|</asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkNext" CssClass="bold" runat="server" EnableViewState="False">&gt;</asp:HyperLink>
    <asp:HyperLink ID="lnkLast" CssClass="bold" runat="server" EnableViewState="False">»</asp:HyperLink>
    <div class="clearfix"></div>
</div>