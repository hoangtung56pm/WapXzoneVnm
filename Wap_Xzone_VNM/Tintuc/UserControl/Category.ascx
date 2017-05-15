

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControl.Category" %>
<div class="rbroundbox">
	<div class="rbtop"><div>
	    <asp:Literal ID="ltrTitle" runat="server" EnableViewState="False">CHUYEN MUC TIN TUC</asp:Literal>
	</div></div>    
</div>
<div class="boxcontent">     
    <asp:Repeater ID="rptCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
    	        ♥ <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
