<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameDownload.aspx.cs" Inherits="WapXzone_VNM.Wap.GameDownload" %>
<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>
<%@ Register src="UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>
<%@ Register src="../Music/UserControl/RTHot.ascx" tagname="RTHot" tagprefix="uc1" %>
<%@ Register src="../Game/UserControl/GameHot.ascx" tagname="GameHot" tagprefix="uc2" %>
<%@ Register src="../Tintuc/UserControl/HotNews.ascx" tagname="HotNews" tagprefix="uc5" %>
<%@ Register src="UserControl/LinksHome.ascx" tagname="LinksHome" tagprefix="uc6" %>
<%@ Register src="UserControl/EventHOT.ascx" tagname="EventHOT" tagprefix="uc7" %>
<%@ Register src="UserControl/VNMServices.ascx" tagname="VNMServices" tagprefix="uc8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Trang chu :.</title>
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
    <%--Event HOT--%>
    <%--<uc7:EventHOT ID="EventHOT1" runat="server" EnableViewState="False" />--%>
   
    <asp:Panel ID="plList" runat="server">
    </asp:Panel>
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
    <%-- <mobile:form id="Form1" runat="server">    
    <Mobile:Image runat="server">
        <DeviceSpecific>
            <Choice ImageURL="http://wap.vietnamobile.com.vn/img/logo.png" />
        </DeviceSpecific>
    </Mobile:Image>
    <mobile:Panel ID="plList" Runat="server"></mobile:Panel>
    </mobile:form>--%>
</body>
</html>
