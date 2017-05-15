<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultNew.aspx.cs" Inherits="WapXzone_VNM.Hoangdao.DefaultNew" %>

<%@ Register Src="../Wap/UserControlNew/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControlNew/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="../Wap/UserControlNew/TimKiem.ascx" TagName="TimKiem" TagPrefix="uc3" %>
<%@ Register Src="../Game/UserControlNew/TruyCapNhanh.ascx" TagName="TruyCapNhanh" TagPrefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Hoang Dao :.</title>
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
    <uc3:TimKiem ID="TimKiem1" runat="server" EnableViewState="False" />
    <%--End Header--%>

    <%--Content--%>
    <asp:PlaceHolder runat="server" EnableViewState="False" ID="plContent"></asp:PlaceHolder>
    <%--End Content--%>
    <uc5:TruyCapNhanh ID="TruyCapNhanh1" runat="server" EnableViewState="False" />

    <%--Footer--%>
    <uc2:Footer ID="Footer1" runat="server" EnableViewState="False" />
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />
    <%--End Footer--%>

    </form>
</body>
</html>
