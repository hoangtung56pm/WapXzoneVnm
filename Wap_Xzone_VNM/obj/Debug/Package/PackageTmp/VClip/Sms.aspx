<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sms.aspx.cs" Inherits="WapXzone_VNM.VClip.Video.Sms" %>

<%@ Import Namespace="WapXzone_VNM.VClip.Library" %>
<%@ Register Src="/VClip/UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="/VClip/UserControl/Header.ascx" TagName="Header" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: VMCLIP :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "/VClip/css/style.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:Header ID="Header1" runat="server" />
    <div class="main-container" style="padding: 0 0 5px 0; text-align: center;">
        <br />
        <br />
            Dịch vụ VMClip yêu cầu sử dụng kết nối 3G hoặc GPRS
        <br />
        <br />
        <a href="/VClip/default.aspx"><b><< Quay về Trang chủ >> </b></a>
    </div>
    <uc3:Footer ID="Footer4" runat="server" />
    </form>
</body>
</html>
