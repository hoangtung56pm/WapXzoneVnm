<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S2_DangKy.aspx.cs" Inherits="WapXzone_VNM.Wap.S2.CUOI.S2_DangKy" %>

<%@ Register src="/Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>
<%--<%@ Register src="../Wap/UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>--%>
<%--<%@ Register src="UserControl/Category.ascx" tagname="Category" tagprefix="uc2" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - CUOI :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "/css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:Header ID="Header1" runat="server" EnableViewState="False" />  

    <%--Content here--%>
    
    <asp:Panel ID="pnlSMS" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrHuongdan" runat="server"></asp:Literal></div>
            </div>
        </div>
        <div style="text-align: center;" class="boxcontent">
            <p style="text-align: left;">
                <asp:Literal ID="ltrSMS" runat="server"></asp:Literal>
            </p>

            <asp:Button ID="btnQuayLai" Visible="false" Text="Quay lại" runat="server" OnClick="btnQuayLai_Click" />

        </div>
    </asp:Panel>

    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrTitle" runat="server">Cuoi</asp:Literal></div>
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
            <asp:Button ID="btnKhong" Visible="false" Text="Quay lại" runat="server" OnClick="btnKhong_Click" />
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrTieuDe" runat="server">Truyen Cuoi</asp:Literal></div>
            </div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
            <p>
                <asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal>
            </p>

        </div>
    </asp:Panel>

    <%--end Content here--%>

    <%--<uc2:Category ID="Category1" runat="server" EnableViewState="False" />--%>
   <%-- <uc1:Links ID="Links1" runat="server" EnableViewState="False" />    --%>
    <uc3:Footer ID="Footer4" runat="server" EnableViewState="False" />   
    <%--<img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>
    </form>
</body>
</html>