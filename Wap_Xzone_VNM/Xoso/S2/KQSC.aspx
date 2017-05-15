﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KQSC.aspx.cs" Inherits="WapXzone_VNM.Xoso.S2.KQSC" %>

<%@ Register Src="../../Wap/UserControlNew/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../../Wap/UserControlNew/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="../../Wap/UserControlNew/TimKiem.ascx" TagName="TimKiem" TagPrefix="uc3" %>
<%@ Register Src="../../Game/UserControlNew/TruyCapNhanh.ascx" TagName="TruyCapNhanh" TagPrefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Xo So :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../../css/mainnew.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--Header--%>
    <uc1:header ID="Header1" runat="server" EnableViewState="True" />
    <uc3:timkiem ID="TimKiem1" runat="server" EnableViewState="True" />
    <%--End Header--%>
    <%--Content--%>

    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrTieuDe" runat="server"></asp:Literal></div>
            </div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
            <p>
                <asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal>
            </p>

            <asp:Button ID="Button1" Text="Quay lại" runat="server" OnClick="btnQuayLai_Click" />

        </div>
    </asp:Panel>

    <%--End Content--%>

    <uc5:truycapnhanh ID="TruyCapNhanh1" runat="server" EnableViewState="True" />
    <%--Footer--%>
    <uc2:footer ID="Footer1" runat="server" EnableViewState="True" />
    <%--End Footer--%>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
