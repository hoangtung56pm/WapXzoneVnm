<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendGift.aspx.cs" Inherits="WapXzone_VNM.Music.SendGift" %>
<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="UserControl/Links.ascx" tagname="Links" tagprefix="uc2" %>
<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Am nhac :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "css/music.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Header ID="Header1" runat="server" />    
    <%--Content here--%>
    <asp:Panel ID="pnlSMS" runat="server" Visible="false">
        <div class="div1">
            <div><asp:Literal ID="ltrHuongdan" runat="server">HƯỚNG DẪN</asp:Literal></div>
        </div> 
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>            
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
        <div class="div1">
            <div><asp:Literal ID="ltrTitle" runat="server">THÔNG BÁO</asp:Literal></div>
        </div>
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrThongBao" runat="server">THÔNG BÁO</asp:Literal></p>
            <asp:Button ID="btnCo" runat="server" onclick="btnCo_Click" /> 
            <asp:Button ID="btnKhong" runat="server" onclick="btnKhong_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="div1">
            <div><asp:Literal ID="ltrTieuDe" runat="server">NỘI DUNG</asp:Literal></div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
	        <p><asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal></p>            
	        <p><asp:HyperLink ID="lnkDownload" runat="server"></asp:HyperLink></p>
	        <p><asp:HyperLink ID="lnkKhuyenMai" runat="server"></asp:HyperLink></p>
        </div>
    </asp:Panel>
    <%--end Content here--%>
    <uc2:Links ID="Links1" runat="server" />    
    <uc3:Footer ID="Footer1" runat="server" />
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />
    </form>
</body>
</html>
