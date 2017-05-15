<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="WapXzone.VClip.Video.Success" %>
<%@ Import Namespace="WapXzone.VClip.Library" %>

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
   <div class="main-container" style="padding: 0 0 5px 0; text-align:center;">
       <%-- 1. (092) Chuc mung! Quy khach da Dky thanh cong DV VMclip (5000vnd/ 7ngay). Quy
        khach se duoc su dung dich vu den het ngay dd/mm/yy ( da bao gom 7 ngay MIEN PHI
        su dung). Truy cap ngay http://wap.vietnamobile.com.vn/clip de su dung dich vu.
        De huy DK, soan: VMclip OFF gui 223. HT: 19001255 
        <br />
        <br />
        2. (092) Dich vu VMclip yeu cau
        dien thoai cua quy khach co ho tro chuc nang xem video truc tuyen va ket noi mang.
        De cai dat GPRS tu dong soan tin GPRS gui 223 ( Mien phi cai dat GPRS )--%>

        <br />

        <b>Đăng ký thành công</b> <br />

        <b>Chúc mừng bạn đã được sử dụng dịch vụ VMClip miễn phí trong 07 ngày</b>

        <br />
        <br />

        <b>Để hủy dịch vụ soạn tin : Clip OFF gửi 949</b>
        <br />
        <br />

       <a href="<%= AppEnv.GetSetting("WapDefault") %>"> <b> << Quay về Trang chủ >> </b> </a><br /><br />
       <b>Gói xem video tuần: 3000đ</b>
       <br />

   </div>
    <uc3:Footer ID="Footer4" runat="server" />
    </form>
</body>
</html>
