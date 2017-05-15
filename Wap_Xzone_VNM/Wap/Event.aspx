<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="WapXzone_VNM.Wap.Event" %>
<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="UserControl/Links.ascx" tagname="Links" tagprefix="uc3" %>
<%@ Register src="../Video/UserControl/Event_Video.ascx" tagname="Event_Video" tagprefix="uc4" %>
<%@ Register src="../Music/UserControl/Event_Music.ascx" tagname="Event_Music" tagprefix="uc5" %>
<%@ Register src="../Hinhnen/UserControl/Event_Image.ascx" tagname="Event_Image" tagprefix="uc6" %>
<%@ Register src="../Tintuc/UserControl/Event_News.ascx" tagname="Event_News" tagprefix="uc7" %>
<%@ Register src="../Game/UserControl/Event_Game.ascx" tagname="Event_Game" tagprefix="uc8" %>
<%@ Register src="../Thugian/UserControl/Event_Thugian.ascx" tagname="Event_Thugian" tagprefix="uc9" %>
<%@ Register src="../Thugian/UserControl/Event_Thugian02.ascx" tagname="Event_Thugian02" tagprefix="uc10" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: OLYMPIC 2012 :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="Header1" runat="server" EnableViewState="False" />

    <div class="clearfix">
    </div>
    <%--Video HOT--%>
    <uc4:Event_Video ID="Event_Video1" runat="server" EnableViewState="False" />
    <div class="clearfix">
    </div>
    <%--Game HOT--%>
    <uc8:Event_Game ID="Event_Game2" runat="server" EnableViewState="False" />
    <div class="clearfix">
    </div>
    <%--Nhạc HOT--%>
    <uc5:Event_Music ID="Event_Music2" runat="server" EnableViewState="False" />
    <div class="clearfix">
    </div>
    <uc6:Event_Image ID="Event_Image2" runat="server" EnableViewState="False" />
    <div class="clearfix">
    </div>
    <%--Tư vấn HOT--%>
    <%-- <uc9:Event_Thugian ID="Event_Thugian1" runat="server" EnableViewState="False" />        
    <div class="clearfix"></div>--%>
    <%--Hình nền HOT--%>
    <%--Tư vấn HOT 02--%>
    <%-- <uc10:Event_Thugian02 ID="Event_Thugian021" runat="server" EnableViewState="False" />        
    <div class="clearfix"></div>--%>
    <%--Tin HOT--%>
    <uc7:event_news id="Event_News1" runat="server" enableviewstate="False" />
    <div class="clearfix">
    </div>

    <uc3:Links ID="Links1" runat="server" EnableViewState="False" />
    <div class="clearfix"></div>
    <uc2:footer ID="Footer1" runat="server" EnableViewState="False" />
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />
    </form>
</body>
</html>
