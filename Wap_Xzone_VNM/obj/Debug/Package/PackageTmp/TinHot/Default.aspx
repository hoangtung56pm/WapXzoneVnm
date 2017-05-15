<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WapXzone_VNM.TinHot.Default" %>

<%@ Register src="../Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="../Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>
<%@ Register src="../Wap/UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>

<%@ Register src="/TinHot/UserControl/Msisdn.ascx" tagname="Msisdn" tagprefix="uc5" %>

<%@ Register src="/TinHot/UserControl/Header.ascx" tagname="Header" tagprefix="uc6" %>
<%@ Register src="/TinHot/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc7" %>

<%--<%@ Register src="UserControl/Category.ascx" tagname="Category" tagprefix="uc2" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Trang Tin tuc :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>

    <%--<style media="screen" type="text/css">
        @import "../css/main.css";
    </style>--%>

    <%--<link rel="stylesheet" href="/css/main.css"/>--%>

    <link rel="stylesheet" href="/RadioStyle/Content/radio/plugin/bootstrap/css/bootstrap.min.css"/>
    <!-- Optional theme -->
    <link rel="stylesheet" href="/RadioStyle/Content/radio/plugin/bootstrap/css/bootstrap-theme.min.css"/>

    <link rel="stylesheet" href="/RadioStyle/Content/radio/plugin/font-awesome/css/font-awesome.min.css"/>

    <!--[if IE 7]>
    <link rel="stylesheet" href="/RadioStyle/Content/radio/plugin/font-awesome/css/font-awesome-ie7.min.css"/>
    <![endif]-->
    <link rel="stylesheet" href="/RadioStyle/Content/radio/css/styles.css"/>
    
    <%--MENU for SMART PHONE--%>
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css"/>
    <asp:Literal ID="ltrSmartCss" runat="server" EnableViewState="False"></asp:Literal>

</head>
<body>
    <%--<form id="form1" runat="server">--%>

    <%--<uc6:Header ID="Header1" runat="server" EnableViewState="False" />   --%>
    
    <asp:PlaceHolder runat="server" EnableViewState="False" ID="plMenu"></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" EnableViewState="False" ID="plHeader"></asp:PlaceHolder>

    <%--Content here--%>
    <asp:PlaceHolder runat="server" EnableViewState="False" ID="plContent"></asp:PlaceHolder>
    <%--end Content here--%>    
    <uc7:Footer ID="Footer1" runat="server" EnableViewState="False" />   

    <%--<img alt="" src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>

    <%--</form>--%>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script type="text/javascript" src="/RadioStyle/Content/radio/js/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script type="text/javascript" src="/RadioStyle/Content/radio/plugin/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="/RadioStyle/Content/radio/js/app.js"></script>
    
    <%--MENU for SMART PHONE--%>
    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.hammer.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>
    
    <img height="0" src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

</body>
</html>
