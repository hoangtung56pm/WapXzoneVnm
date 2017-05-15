<%@ OutputCache Duration="600" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControl.Category" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkTheThao" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:Literal ID="ltrCacGiaiDau" runat="server" EnableViewState="False"></asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <asp:Panel ID="pnlGiaidau" runat="server">            
            <div class="listlink">            
	            ♥ <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
            </div>
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>
<div class="clearfix"></div>