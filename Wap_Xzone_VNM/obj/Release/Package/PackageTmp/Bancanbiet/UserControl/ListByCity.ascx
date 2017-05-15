
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListByCity.ascx.cs" Inherits="WapXzone_VNM.Bancanbiet.UserControl.ListByCity" %>
<div class="rbroundbox">
	<div class="rbtop"><div>
	    <asp:HyperLink ID="lnkAtm" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink></div></div>
</div>
<div class="clearfix"></div>
<div class="boxcontent"> 
    <asp:Repeater ID="rptcity" runat="server" EnableViewState="False">
        <ItemTemplate>                        
            <div class="listlink">                
                ♥ <asp:HyperLink ID="lnkByCity" runat="server" EnableViewState="False"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>    
</div>
<div class="clearfix"></div>