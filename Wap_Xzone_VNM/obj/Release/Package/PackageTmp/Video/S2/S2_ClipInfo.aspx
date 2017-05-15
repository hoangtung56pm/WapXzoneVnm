<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S2_ClipInfo.aspx.cs" Inherits="WapXzone_VNM.Video.S2.S2_ClipInfo" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register src="/Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Game Info :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "/css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:header ID="Header1" runat="server" EnableViewState="False" />    
    
    <%--Huong dan--%>
    <div class="div1">
    <div>
        <p class="link-non-black">VIDEO CLIP</p>
     </div>
</div>
    <div class="boxcontent">
        <p>

           <b>Giới thiệu</b>  
            <a class="link-non-orange float-right" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                   <span class="orange bold"> << <%= AppEnv.CheckLang("Đăng Ký") %> >> </span>
            </a>

<br />Cung cấp cho bạn những clip hot và nóng hổi nhất. Những thông tin mới, đặc sắc sẽ được truyền tải đến cho bạn hàng ngày. Đăng ký một lần nhận tin mãi mãi 
<br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Để đăng ký soạn tin: DK CLIP gửi <%= AppEnv.GetSetting("S2ShortCode")%>
<br />Hủy đăng ký soạn tin: HUY CLIP gửi <%= AppEnv.GetSetting("S2ShortCode")%>
<br />Giá cước: 2.000VNĐ/ngày
        </p>
    </div>
    <%--End Huong dan--%>


    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--<img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>
    </form>
</body>
</html>
