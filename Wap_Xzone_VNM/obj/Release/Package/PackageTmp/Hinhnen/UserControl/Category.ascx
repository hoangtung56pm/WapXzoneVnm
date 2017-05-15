<%@ OutputCache Duration="3600" VaryByParam="lang;w" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControl.Category" %>
<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server"></asp:Literal>    
</div>
<div class="clearfix"></div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTheLoai" runat="server">THỂ LOẠI HÌNH</asp:Literal></div></div>
</div>
<div class="boxcontent">
	<asp:Repeater ID="rptCategory" runat="server">
        <ItemTemplate>
            <div class="listlink">
    	        ♥ <asp:HyperLink ID="lnkCatName" runat="server"></asp:HyperLink>
            </div>        
        </ItemTemplate>        
    </asp:Repeater>   	
</div>
