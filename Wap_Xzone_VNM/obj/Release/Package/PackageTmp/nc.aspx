<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nc.aspx.cs" Inherits="WapXzone_VNM.nc" %>

<%@ Register Src="/Wap/UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="/Wap/UserControl/Header.ascx" TagName="Header" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <uc4:Header ID="Header1" runat="server" />
    <div>
        <asp:Panel ID="pnlSMS" runat="server" Visible="false">
            <div class="rbroundbox">
                <div class="rbtop">
                    <div>
                        <asp:Literal ID="ltrHuongdan" runat="server">HƯỚNG DẪN</asp:Literal></div>
                </div>
            </div>
            <div style="text-align: center;" class="boxcontent">
                <br />
                <br />
                <p>
                    <asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>
    <uc3:Footer ID="Footer4" runat="server" />
    </form>
</body>
</html>
