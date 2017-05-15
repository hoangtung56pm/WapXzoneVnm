<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="WapXzone_VNM.TinTuc247.Download" %>

<%@ Register Src="../Wap/UserControl/FooterTinTuc247.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="../Wap/UserControl/HeaderTinTuc247.ascx" TagName="Header" TagPrefix="uc4" %>
<%@ Register Src="/Tintuc247/UserControl/Category.ascx" TagName="Category" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: TinTuc247.com.vn :.</title>
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
    <asp:Panel ID="pnlSMS" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrHuongdan" runat="server">HƯỚNG DẪN</asp:Literal></div>
            </div>
        </div>
        <div style="text-align: center;" class="boxcontent">
            <p>
                <asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrTitle" runat="server">THÔNG BÁO</asp:Literal></div>
            </div>
        </div>
        <div style="text-align: center;" class="boxcontent">
            <p>
                <asp:Literal ID="ltrThongBao" runat="server">THÔNG BÁO</asp:Literal></p>
            <%--  <asp:Button ID="btnCo" runat="server" onclick="btnCo_Click" /> 
            <asp:Button ID="btnKhong" runat="server" onclick="btnKhong_Click" />--%>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="rbroundbox">
            <div class="rbtop">
                <div>
                    <asp:Literal ID="ltrTieuDe" runat="server">NỘI DUNG</asp:Literal></div>
            </div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
            <br />
            <br />
            <asp:Literal ID="ltrNoiDung" runat="server">Nội dung dữ liệu trả về</asp:Literal>
        </div>
    </asp:Panel>
    <div class="div1">
        <div>
            <asp:Label ID="lblCat" runat="server" EnableViewState="False">TIN DA DANG</asp:Label></div>
    </div>
    <div class="boxcontent">
        <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
            <ItemTemplate>
                <div class="listlink">
                    ♥
                    <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clearfix">
    </div>
    <%--end Content here--%>
    <uc2:Category ID="Category1" runat="server" EnableViewState="False" />
    <uc3:Footer ID="Footer4" runat="server" />
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />
    </form>
</body>
</html>
