
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastestNews.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControl.LastestNews" %>
<%@ Register src="Category.ascx" tagname="Category" tagprefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Label ID="lblTitle" runat="server" EnableViewState="False">CHU DE HOT</asp:Label></div></div>
</div>
<div class="boxcontent">
	<p><img src="../img/hot_icon.gif"> <asp:Literal ID="ltrDangKy" runat="server" EnableViewState="False"></asp:Literal> </p>
   	<div class="clearfix"></div>
    <asp:HyperLink ID="lnkDangKy" runat="server" EnableViewState="False"><span class="blue bold"><asp:Literal ID="ltrDK" runat="server" EnableViewState="False"></asp:Literal></span></asp:HyperLink>    
    <div class="clearfix"></div>
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>
</div>
<%--<div class="boxcontent">
    <asp:Repeater ID="rptlastest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
            <span class="thumblist">♥</span>
                <div class="item-info"> 
                    <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink><br />
                    <asp:Literal ID="ltrLuotxem" runat="server" EnableViewState="False"></asp:Literal>
                </div>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>--%>
<uc1:Category ID="Category1" runat="server" EnableViewState="False" />