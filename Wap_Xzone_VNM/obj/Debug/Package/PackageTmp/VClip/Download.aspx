<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="WapXzone_VNM.VClip.Download" %>

<%@ Register Src="/VClip/UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="/VClip/UserControl/Header.ascx" TagName="Header" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <div class="main-container">
        <asp:Panel ID="pnlSMS" runat="server" Visible="false">
             <asp:Literal ID="ltrHuongdan" runat="server"></asp:Literal>
           <div class="clear10px"></div>
            <div style="text-align: center;" class="boxcontent">
                <p>
                    <asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>
            </div><div class="clear10px"></div>
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
                <asp:Button ID="btnCo" runat="server" OnClick="btnCo_Click" />
                <asp:Button ID="btnKhong" runat="server" OnClick="btnKhong_Click" />
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
                <p>
                    <asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal></p>
                <p>
                    <asp:HyperLink ID="lnkDownload" runat="server"></asp:HyperLink></p>
            </div>
        </asp:Panel>
    </div>
    <uc3:Footer ID="Footer4" runat="server" />
    </form>
</body>
</html>
