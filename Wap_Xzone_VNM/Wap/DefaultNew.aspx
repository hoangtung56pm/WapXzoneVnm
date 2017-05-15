<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultNew.aspx.cs" Inherits="WapXzone_VNM.Wap.DefaultNew" %>

<%@ Register Src="UserControlNew/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="UserControlNew/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="UserControlNew/DichVuMienPhi.ascx" TagName="DichVuMienPhi" TagPrefix="uc3" %>
<%@ Register Src="UserControlNew/TinTuc.ascx" TagName="TinTuc" TagPrefix="uc4" %>
<%@ Register Src="UserControlNew/DichVu.ascx" TagName="DichVu" TagPrefix="uc5" %>
<%@ Register Src="UserControlNew/Clip.ascx" TagName="Clip" TagPrefix="uc6" %>
<%@ Register Src="UserControlNew/Game.ascx" TagName="Game" TagPrefix="uc7" %>
<%@ Register Src="UserControlNew/LienKet.ascx" TagName="LienKet" TagPrefix="uc8" %>
<%@ Register Src="UserControlNew/DichVuNoiBat.ascx" TagName="DichVuNoiBat" TagPrefix="uc9" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Trang chu :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/mainnew.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--Header--%>
    <uc1:Header ID="Header1" runat="server" EnableViewState="False" />
    <%--End Header--%>

    <%--Content--%>

    <uc9:DichVuNoiBat ID="DichVuNoiBat1" runat="server" EnableViewState="False" />

    <uc3:DichVuMienPhi ID="DichVuMienPhi1" Visible="false" runat="server" EnableViewState="False" />

    <%--<uc4:TinTuc ID="TinTuc1" runat="server" EnableViewState="False" />--%>
    <uc6:Clip ID="Clip1" runat="server" EnableViewState="False" />

    <uc7:Game ID="Game1" runat="server" EnableViewState="False" />

    <uc5:DichVu ID="DichVu1" runat="server" EnableViewState="False" />

    <%--<uc6:Clip ID="Clip1" runat="server" EnableViewState="False" />--%>
    <uc4:TinTuc ID="TinTuc1" runat="server" EnableViewState="False" />

    
    <uc8:LienKet ID="LienKet1" runat="server" EnableViewState="False" />
    <%--End Content--%>

    <%--Footer--%>
    <uc2:Footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--End Footer--%>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
