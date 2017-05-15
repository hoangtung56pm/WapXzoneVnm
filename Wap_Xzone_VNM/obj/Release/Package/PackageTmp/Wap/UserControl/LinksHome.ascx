<%@ OutputCache Duration="3600" VaryByParam="lang;w" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinksHome.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.LinksHome" %>
<div class="div1">
	<div><asp:HyperLink ID="lnkLienket" CssClass="logo-vnm" runat="server" EnableViewState="False" Text="LIEN KET"></asp:HyperLink></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptLienket" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                <p>♥ <span class="bold"><asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal></span>
                <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>	
</div>
