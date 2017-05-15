﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultHigh.aspx.cs" Inherits="WapXzone_VNM.Xoso.DefaultHigh" %>

<%@ Register src="/Wap/UserControlHigh/Footer.ascx" tagname="Footer" tagprefix="uc1" %>
<%@ Register src="/Wap/UserControlHigh/Header.ascx" tagname="Header" tagprefix="uc2" %>
<%@ Register src="/Wap/UserControlHigh/Menu.ascx" tagname="Menu" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControlHigh/Filter.ascx" tagname="Filter" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>.: Vietnamobile - Xo So :.</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css"/>
    <link rel="stylesheet" href="/Content/asset/Css/style.css"/>
    <script type="text/javascript" src="/Content/asset/Javascript/jquery.min.js"></script>
    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.hammer.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>

</head>
<body>

    <%--<form id="form1" runat="server">
    <div>
    
    </div>
    </form>--%>

    
<uc3:Menu ID="Menu1" runat="server" EnableViewState="true" />   

<div class="wrapper">

    <!--begin header-->
    <uc2:Header ID="Header1" runat="server" EnableViewState="true" />   

    <!--begin body-->
    <div class="body">
        <form id="form1" runat="server">
            <asp:PlaceHolder runat="server" EnableViewState="true" ID="plContent"></asp:PlaceHolder>
       </form>
    </div>

    <uc1:Footer ID="Footer1" runat="server" EnableViewState="true" />   

</div>
    
    <img height="0" src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

</body>
</html>
