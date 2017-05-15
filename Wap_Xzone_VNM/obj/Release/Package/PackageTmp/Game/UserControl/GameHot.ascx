<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameHot.ascx.cs" Inherits="WapXzone_VNM.Game.UserControl.GameHot" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="div1">    
	<div><asp:HyperLink ID="lnkXemThem" CssClass="logo-vnm" runat="server" EnableViewState="False">Game HOT</asp:HyperLink></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptHottest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink> <img src="../img/hot_icon.gif">
                    <p><asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>    

    <asp:Panel ID="pnlS2DkGame2" runat="server">
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="<%= UrlProcess.GetGameS2RegisterUrl2G(lang.ToString(),width) %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí GAME HOT tuần") %> </span>
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