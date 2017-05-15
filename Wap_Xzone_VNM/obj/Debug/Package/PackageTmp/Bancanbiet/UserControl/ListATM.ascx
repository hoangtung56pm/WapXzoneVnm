
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListATM.ascx.cs" Inherits="WapXzone_VNM.Bancanbiet.UserControl.ListATM" %>
<div class="rbroundbox">
	<div class="rbtop"><div>
	    <asp:HyperLink ID="lnkChanelHome" runat="server" EnableViewState="False">MAY ATM </asp:HyperLink> » <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink></div></div>
</div>
<div class="clearfix"></div>
<div class="boxcontent">    
    <asp:Repeater ID="rptcity" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                ♥ <asp:HyperLink ID="lnkCity" runat="server" EnableViewState="False"></asp:HyperLink>                
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="clearfix"></div>