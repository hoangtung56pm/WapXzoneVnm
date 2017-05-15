<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultHigh.aspx.cs" Inherits="WapXzone_VNM.Wap.DefaultHigh" %>

<%@ Register src="UserControlHigh/Footer.ascx" tagname="Footer" tagprefix="uc1" %>
<%@ Register src="UserControlHigh/Header.ascx" tagname="Header" tagprefix="uc2" %>
<%@ Register src="UserControlHigh/Menu.ascx" tagname="Menu" tagprefix="uc3" %>
<%@ Register src="UserControlHigh/Filter.ascx" tagname="Filter" tagprefix="uc4" %>
<%@ Register src="UserControlHigh/TinHot.ascx" tagname="TinHot" tagprefix="uc5" %>
<%@ Register src="UserControlHigh/TopBanner.ascx" tagname="TopBanner" tagprefix="uc6" %>
<%@ Register src="UserControlHigh/BottomBanner.ascx" tagname="BottomBanner" tagprefix="uc7" %>
<%@ Register src="UserControlHigh/Video.ascx" tagname="Video" tagprefix="uc8" %>
<%@ Register src="UserControlHigh/GameHay.ascx" tagname="GameHay" tagprefix="uc9" %>
<%@ Register src="UserControlHigh/GioiTinh.ascx" tagname="GioiTinh" tagprefix="uc10" %>

<%@ Register src="UserControlHigh/Truyen.ascx" tagname="Truyen" tagprefix="uc11" %>
<%@ Register src="UserControlHigh/DichVu.ascx" tagname="DichVu" tagprefix="uc12" %>

<%@ Register src="UserControlHigh/WebTinKhuyenMai.ascx" tagname="TinKhuyenMai" tagprefix="uc13" %>

<%@ Register src="UserControlHigh/Phim.ascx" tagname="Phim" tagprefix="uc14" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>.: Vietnamobile - Trang chu :.</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css"/>
    <link rel="stylesheet" href="/Content/asset/Css/style.css"/>
    <script type="text/javascript" src="/Content/asset/Javascript/jquery.min.js"></script>
    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.hammer.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>

</head>
<body>

    <%--<form id="form1" runat="server">--%>


<uc3:Menu ID="Menu1" runat="server" EnableViewState="False" />   

<div class="wrapper">

<uc2:Header ID="Header1" runat="server" EnableViewState="False" />   

<div class="body">

<uc4:Filter ID="Filter1" runat="server" EnableViewState="False" />  

<uc5:TinHot ID="TinHot1" runat="server" EnableViewState="False" />  

<uc6:TopBanner ID="TopBanner1" runat="server" EnableViewState="False" />  

<uc8:Video ID="Video1" runat="server" EnableViewState="False" />  

<uc7:BottomBanner ID="BottomBanner1" runat="server" EnableViewState="False" />  

<uc9:GameHay ID="GameHay1" runat="server" EnableViewState="False" />  

<uc6:TopBanner ID="TopBanner2" runat="server" EnableViewState="False" />  

<uc10:GioiTinh ID="GioiTinh1" runat="server" EnableViewState="False" />  

<uc11:Truyen ID="Truyen1" runat="server" EnableViewState="False" />  
    
<uc14:Phim ID="Phim" runat="server" EnableViewState="False" />  

<uc12:DichVu ID="DichVu1" runat="server" EnableViewState="False" />  
    
<uc13:TinKhuyenMai ID="TinKhuyenMai1" runat="server" EnableViewState="False" />  

</div>

<uc1:Footer ID="Footer1" runat="server" EnableViewState="False" />   

</div>


    <%--</form>--%>

</body>
</html>
