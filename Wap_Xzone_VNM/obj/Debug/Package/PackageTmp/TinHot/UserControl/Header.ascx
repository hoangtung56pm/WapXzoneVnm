<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WapXzone_VNM.TinHot.UserControl.Header" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<div class="header">

    <div>
        Xin chào <span style="color: #FF0099;"><asp:Literal ID="ltrXinChao" runat="server" EnableViewState="false"></asp:Literal></span>
   </div>

   

    <div class="banner">
        <asp:Literal ID="litAdvTop" runat="server"></asp:Literal>
    </div>

    <marquee scrolldelay="90" direction="left">

        <asp:Repeater ID="rptHotNews" runat="server" EnableViewState="false">
            <ItemTemplate>
                <asp:HyperLink ID="lnkHotnews" runat="server" style="color:#FF6600"></asp:HyperLink>
                <asp:Literal ID="ltrSeprator" runat="server"></asp:Literal>
            </ItemTemplate>
        </asp:Repeater>

    </marquee>

    <div class="nav-header">
            <a href="<%= AppEnv.GetSetting("WapDefault") %>">Trang chủ</a> |
            <a href="<%= AppEnv.NavigateUrlHighHeader("game") %>">Game</a>
            |
           <%-- <a href="/ai-sexy-hon/linh-miu.aspx">Hẹn hò</a>
            |--%>
            <a href="/trangnhaccho/index.html">Nhạc chờ</a>
            |
            <a href="/Wap/DailyInfo.aspx?lang=1&w=320">DailyInfo</a>
    </div>
</div>