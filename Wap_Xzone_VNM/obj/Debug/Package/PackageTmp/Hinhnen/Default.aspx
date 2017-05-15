<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WapXzone_VNM.Hinhnen.Default" %>
<%@ Register src="../Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="../Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>
<%@ Register src="../Wap/UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>
<%@ Register src="UserControl/Category.ascx" tagname="Category" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Hinh nen :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:Header ID="Header1" runat="server" />    
    <%--Content here--%>    
    <asp:PlaceHolder runat="server" ID="plContent"></asp:PlaceHolder>    
    <%--end Content here--%>
    <uc2:Category ID="Category1" runat="server" />
    <uc1:Links ID="Links1" runat="server" />    
    <uc3:Footer ID="Footer4" runat="server" />
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />
    </form>
</body>
</html>
