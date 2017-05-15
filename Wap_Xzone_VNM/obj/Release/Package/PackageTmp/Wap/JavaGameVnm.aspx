<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JavaGameVnm.aspx.cs" Inherits="WapXzone_VNM.Wap.JavaGameVnm" %>


<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="UserControl/Header.ascx" TagName="Header" TagPrefix="uc4" %>
<%@ Register Src="UserControl/Links.ascx" TagName="Links" TagPrefix="uc1" %>
<%@ Register Src="../Music/UserControl/RTHot.ascx" TagName="RTHot" TagPrefix="uc1" %>
<%@ Register Src="../Game/UserControl/GameHot.ascx" TagName="GameHot" TagPrefix="uc2" %>
<%@ Register Src="../Tintuc/UserControl/HotNews.ascx" TagName="HotNews" TagPrefix="uc5" %>
<%@ Register Src="UserControl/LinksHome.ascx" TagName="LinksHome" TagPrefix="uc6" %>
<%@ Register Src="UserControl/EventHOT.ascx" TagName="EventHOT" TagPrefix="uc7" %>
<%@ Register Src="UserControl/VNMServices.ascx" TagName="VNMServices" TagPrefix="uc8" %>
<%@ Register Src="../Game/UserControl/JavaGameVnm.ascx" TagName="JavaGame" TagPrefix="uc9" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - VNM GAME :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/main.css";
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <uc4:Header ID="Header1" runat="server" EnableViewState="False" />
    <uc9:JavaGame ID="JavaGame1" runat="server" EnableViewState="False" />
    <%--Nhạc HOT--%>
    <uc1:RTHot ID="RTHot1" runat="server" EnableViewState="False" />
    <%--Quảng cáo--%>
    <div class="boxcontent">
        <asp:Literal ID="litAds" runat="server" EnableViewState="False"></asp:Literal>
    </div>
    <div class="clearfix">
    </div>
    <%--Game HOT--%>
    <uc2:GameHot ID="GameHot1" runat="server" EnableViewState="False" />
    <%--Menu Dịch vụ--%>
    <uc8:VNMServices ID="VNMServices1" runat="server" />
    <div class="clearfix">
    </div>
    <%--Quảng cáo--%>
    <div class="boxcontent">
        <asp:Literal ID="litAds1" runat="server" EnableViewState="False"></asp:Literal>
    </div>
    <div class="clearfix">
    </div>
    <%--Tin HOT--%>
    <uc5:HotNews ID="HotNews1" runat="server" EnableViewState="False" />
    <%--Liên kết--%>
    <uc6:LinksHome ID="LinksHome1" runat="server" EnableViewState="False" />
    <uc3:Footer ID="Footer1" runat="server" EnableViewState="False" />
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />
    </form>
</body>
</html>