<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WapXzone_VNM.Hot100.Default" %>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile Wap - HOT 100 :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "img/hot100.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="khung">
        <img src="img/banner.jpg" width="100%" />
    </div>
    <div class="clearfix"></div>
    <%--Content here--%>
    <asp:PlaceHolder runat="server" ID="plThongbao" EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder runat="server" ID="plContent" EnableViewState="false"></asp:PlaceHolder>
    <%--end Content here--%>
    <div class="clearfix"></div>    
    <div class="khung">
        <div class="footer">
        <span>&nbsp;<img src="img/muiten.jpg" alt="+" /> <asp:Literal ID="ltrHoTro" runat="server" Text="Hỗ trợ: 19001255"></asp:Literal></span>
        <span style="float:right">
            <asp:HyperLink ID="lnkDautrang" runat="server" NavigateUrl="#">Đầu trang <img src="img/dautrang.jpg" alt="+" style="border:0px" /></asp:HyperLink></span>
        </div>
    </div>
    </form>
</body>
</html>
