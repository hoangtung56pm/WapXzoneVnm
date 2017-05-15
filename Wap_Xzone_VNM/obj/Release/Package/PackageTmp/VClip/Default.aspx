<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WapXzone_VNM.VClip.Default" %>

<%@ Register src="/VClip/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="/VClip/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <title>.: VMCLIP :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "/VClip/css/style.css";
    </style>

    <script type="text/javascript" src="/VClip/js/jquery.min.js"></script>
    <script type="text/javascript" src="/VClip/js/script.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc4:Header ID="Header1" runat="server" />  
      
    <%--Content here--%>    
    <asp:PlaceHolder runat="server" ID="plContent"></asp:PlaceHolder>    
    <%--end Content here--%>

    <uc3:Footer ID="Footer4" runat="server" />
    
    </form>
</body>
</html>
