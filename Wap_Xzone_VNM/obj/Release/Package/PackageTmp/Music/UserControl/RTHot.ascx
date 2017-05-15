<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RTHot.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.RTHot" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<div class="div1">
	<div><asp:HyperLink ID="lnkXemThem" CssClass="logo-vnm" runat="server" EnableViewState="False">Nhạc HOT</asp:HyperLink></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptHottest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <img src="/img/b-ring.gif" alt="thumb" class="thumblist">
                <div class="item-info"> 
                    <p><asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink> <img src="/Music/img/hot_icon.gif"></p>
                    <p><asp:Literal ID="ltrCasy" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink></p>
                </div>
                <div class="clearfix"></div>
            </div>            
        </ItemTemplate>        
    </asp:Repeater>    

    <asp:Panel ID="Panel1" runat="server">
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="/Music/DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm Nhạc Chuông HOT") %> </span>
                 </a>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

</div>
<div class="clearfix"></div>
<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>
<div class="clearfix"></div>