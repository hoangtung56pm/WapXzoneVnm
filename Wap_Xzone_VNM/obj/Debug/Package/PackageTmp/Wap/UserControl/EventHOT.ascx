<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventHOT.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.EventHOT" %>

<div class="div1">
    <div>
        <asp:HyperLink ID="lnkLienket" CssClass="link-non-black logo-vnm" runat="server" EnableViewState="False" Text="Event HOT"></asp:HyperLink></div>
</div>
<div class="boxcontent">
    <div class="listlink" runat="server" visible="false">
        <span class="bold">
            <asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal></span>
        <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
    </div>
    <asp:Repeater ID="rptLienket" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                <p>
                    <span class="bold">
                        <asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal></span>
                    <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
                    <img alt="" src="/img/hot_icon.gif"></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
