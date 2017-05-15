<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WapXzone_VNM.Wap.Default" %>
<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>
<%@ Register src="UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>
<%@ Register src="../Music/UserControl/RTHot.ascx" tagname="RTHot" tagprefix="uc1" %>
<%@ Register src="../Game/UserControl/GameHot.ascx" tagname="GameHot" tagprefix="uc2" %>
<%@ Register src="../Tintuc/UserControl/HotNews.ascx" tagname="HotNews" tagprefix="uc5" %>
<%@ Register src="UserControl/LinksHome.ascx" tagname="LinksHome" tagprefix="uc6" %>
<%@ Register src="UserControl/EventHOT.ascx" tagname="EventHOT" tagprefix="uc7" %>
<%@ Register src="UserControl/VNMServices.ascx" tagname="VNMServices" tagprefix="uc8" %>

<%@ Register src="../Video/UserControl/VideoHot.ascx" tagname="VideoHot" tagprefix="uc9" %>


<%@ Register src="UserControl/BottomBanner.ascx" tagname="BottomBanner" tagprefix="uc10" %>

<%@ Register src="UserControl/ThongBao.ascx" tagname="ThongBao" tagprefix="uc11" %>

<%@ Register src="../Tintuc/UserControl/WebNews.ascx" tagname="WebNews" tagprefix="uc12" %>

<%@ Register src="../Video/UserControl/YoutubePhim.ascx" tagname="YoutubePhim" tagprefix="uc13" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Trang chu :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />

    <%--<asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>--%>
    <meta name="viewport" content="width=device-width; initial-scale=1.0" />	

    <style media="screen" type="text/css">
        @import "../css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">

    <uc4:header ID="Header1" runat="server" EnableViewState="False" />    

    <uc11:ThongBao ID="ThongBao1" runat="server" EnableViewState="False" /> 

    <%--Event HOT--%>
    <uc7:EventHOT ID="EventHOT1" runat="server" EnableViewState="False" />
    <%--Nhạc HOT--%>
    <uc1:RTHot ID="RTHot1" runat="server" EnableViewState="False" />    

    <%--Quảng cáo--%>    
    <%--<div class="boxcontent">
        <asp:Literal ID="litAds" runat="server" EnableViewState="False"></asp:Literal>
    </div>
    <div class="clearfix"></div>--%>

    <%--Game HOT--%>
    <uc2:GameHot ID="GameHot1" runat="server" EnableViewState="False" />
    <uc9:VideoHot ID="VideoHot1" runat="server" />   
        
        
    <%--TAB PHIM--%>
    <uc13:YoutubePhim ID="YoutubePhim1" runat="server" />     
        
         
    <%--Menu Dịch vụ--%>
    <uc8:VNMServices ID="VNMServices1" runat="server" />    
  
    <div class="clearfix"></div>

    <%--Quảng cáo--%>
   <%-- <div class="boxcontent">
        <asp:Literal ID="litAds" runat="server" EnableViewState="False"></asp:Literal>
    </div>
    <div class="clearfix"></div>--%>
    <uc10:BottomBanner ID="BottomBanner1" runat="server" EnableViewState="False" />    

    <%--Tin HOT--%>
    <uc5:HotNews ID="HotNews1" runat="server" EnableViewState="False" />
    <%--Liên kết--%>
    <%--<uc6:LinksHome ID="LinksHome1" runat="server" EnableViewState="False" />--%>
        
     <%--Tin KHUYEN MAI--%>
    <uc12:WebNews ID="WebNews" runat="server" EnableViewState="False" />

    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
