<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boivui.aspx.cs" Inherits="WapXzone_VNM.Hoangdao.Boivui" %>
<%@ Register src="../Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="../Wap/UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Boivui :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "css/boivui.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="body">
        <div class="header">
          <div class="left"></div>
        </div>
        <%--Content here--%>    
        <asp:PlaceHolder runat="server" ID="plContent"></asp:PlaceHolder>    
        <%--end Content here--%>    
        <uc1:Links ID="Links1" runat="server" />    
        <uc3:Footer ID="Footer4" runat="server" />
        <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />
    </div>
    </form>
</body>
</html>
