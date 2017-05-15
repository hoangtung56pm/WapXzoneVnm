<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagging.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControlNew.Pagging" %>

<div style="text-align: center;" class="item">
    <asp:Literal ID="ltrNoData" runat="server" EnableViewState="False" Visible="false">Khong co game ho tro may cua ban.</asp:Literal>
    <asp:HyperLink ID="lnkFirst" CssClass="bold link-non-black" runat="server" EnableViewState="False">«</asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" CssClass="bold link-non-black" runat="server" EnableViewState="False">&lt;</asp:HyperLink>
    <asp:Repeater ID="rptPage" runat="server" EnableViewState="False">
        <ItemTemplate>
            <asp:Label ID="ltrPage" CssClass="bold" runat="server" EnableViewState="False" /> 
            <asp:Literal ID="ltrGach" runat="server" EnableViewState="False">|</asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkNext" CssClass="bold link-non-black" runat="server" EnableViewState="False">&gt;</asp:HyperLink>
    <asp:HyperLink ID="lnkLast" CssClass="bold link-non-black" runat="server" EnableViewState="False">»</asp:HyperLink>
    <div class="clearfix"></div>
</div>