<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultHigh.aspx.cs" Inherits="WapXzone_VNM.Phanmem.DefaultHigh" %>

<%@ Register src="/Wap/UserControlHigh/Footer.ascx" tagname="Footer" tagprefix="uc1" %>
<%@ Register src="/Wap/UserControlHigh/Header.ascx" tagname="Header" tagprefix="uc2" %>
<%@ Register src="/Wap/UserControlHigh/Menu.ascx" tagname="Menu" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControlHigh/Filter.ascx" tagname="Filter" tagprefix="uc4" %>
<%@ Register src="/PhanMem/UserControlHigh/Category.ascx" tagname="Category" tagprefix="uc5" %>
<%@ Register src="/PhanMem/UserControlHigh/Home.ascx" tagname="Home" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>.: Wap Vietnamobile - Ung Dung :.</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css"/>

    <%--<link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.css"/>--%>
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css"/>

    <!--Swiper-matter-->
    <link rel="stylesheet" href="/Content/asset/Plugin/appstore/css/idangerous.swiper.css"/>
    <link rel="stylesheet" href="/Content/asset/Plugin/appstore/css/idangerous.swiper.3dflow.css"/>
    <link rel="stylesheet" href="/Content/asset/Plugin/appstore/css/appstore.css"/>
    <link rel="stylesheet" href="/Content/asset/Css/style.css"/>

    <%--<script type="text/javascript" src="/Content/asset/Javascript/jquery-1.10.2.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Javascript/jquery.min.js"></script>

    <!-- Don't forget to get the latest Swiper and scrollbar version here-->
    <script type="text/javascript" src="/Content/asset/Plugin/appstore/js/idangerous.swiper-2.0.min.js"></script>
    <script type="text/javascript" src="/Content/asset/Plugin/appstore/js/idangerous.swiper.3dflow-2.0.js"></script>
    <script type="text/javascript" src="/Content/asset/Plugin/appstore/js/appstore.js"></script>

    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.js"></script>--%>
    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.hammer.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>

    <script type="text/javascript" src="/Content/asset/Plugin/bootstrap-3.0.3/dist/js/tab.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>

</head>
<body>
    
    
<uc3:Menu ID="Menu1" runat="server" EnableViewState="False" />   

<div class="wrapper">

<!--begin header-->
<uc2:Header ID="Header1" runat="server" EnableViewState="False" />   

<!--begin body-->
<div class="body">

<asp:PlaceHolder runat="server" EnableViewState="False" ID="plContent"></asp:PlaceHolder>

<uc5:Category ID="Category1" runat="server" EnableViewState="False" />   

</div>

<uc1:Footer ID="Footer1" runat="server" EnableViewState="False" />   

</div>
    
    <img height="0" src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

</body>
</html>
