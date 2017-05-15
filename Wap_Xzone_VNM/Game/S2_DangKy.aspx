﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S2_DangKy.aspx.cs" Inherits="WapXzone_VNM.Game.S2_DangKy" %>


<%@ Register Src="../Wap/UserControlNew/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControlNew/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="../Wap/UserControlNew/TimKiem.ascx" TagName="TimKiem" TagPrefix="uc3" %>

<%@ Register Src="UserControlNew/TheLoaiGame.ascx" TagName="TheLoaiGame" TagPrefix="uc4" %>

<%@ Register Src="../Game/UserControlNew/TruyCapNhanh.ascx" TagName="TruyCapNhanh"
    TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Download Game :.</title>
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
    <uc1:Header ID="Header1" runat="server" EnableViewState="True" />
    <uc3:TimKiem ID="TimKiem1" runat="server" EnableViewState="True" />
    <%--End Header--%>
    <%--Content--%>
    
    <asp:Panel ID="pnlSMS" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrHuongdan" runat="server">Game HOT</asp:Literal></div>
            </div>
        </div>
        <div style="text-align: center;" class="boxcontent">
            <p style="text-align: left;">
                <asp:Literal ID="ltrSMS" runat="server"></asp:Literal>
            </p>

            <asp:Button ID="btnQuayLai" Text="Quay lại" runat="server" OnClick="btnQuayLai_Click" />

        </div>
    </asp:Panel>

    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrTitle" runat="server">Game Hot</asp:Literal></div>
            </div>
        </div>
        <div style="text-align: center;" class="boxcontent">
            <p style="text-align: left;">
                <asp:Literal ID="ltrThongBao" runat="server">Giới Thiệu</asp:Literal>
            </p>

            <p style="text-align: left;">
                <asp:Literal ID="ltrThongBaoNoiDung" runat="server"></asp:Literal>
            </p>

            <asp:Button ID="btnCo" Text="Đăng ký" runat="server" OnClick="btnCo_Click" />
            <asp:Button ID="btnKhong" Text="Quay lại" runat="server" OnClick="btnKhong_Click" />
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrTieuDe" runat="server">Game HOT</asp:Literal></div>
            </div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
            <p>
                <asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal>
            </p>

        </div>
    </asp:Panel>

    <%--End Content--%>

    <uc4:TheLoaiGame ID="TheLoaiGame1" runat="server" EnableViewState="True" />
    <uc5:TruyCapNhanh ID="TruyCapNhanh1" runat="server" EnableViewState="True" />
    <%--Footer--%>
    <uc2:Footer ID="Footer1" runat="server" EnableViewState="True" />
    <%--End Footer--%>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
