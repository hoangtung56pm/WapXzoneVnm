
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Video.UserControl.Category" %>

<%--<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>--%>

<div class="clearfix"></div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTheLoai" runat="server" EnableViewState="False">THỂ LOẠI VIDEO</asp:Literal></div></div>
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
