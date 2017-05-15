﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S2_GameInfo.aspx.cs" Inherits="WapXzone_VNM.Wap.S2.Game.S2_GameInfo" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>


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
        <p class="link-non-black">GAME HOT</p>
     </div>
</div>
    <div class="boxcontent">
        <%--<p>--%>
            <b>Giới thiệu</b> 
            
            <br />
            Cung cấp cho các bạn những game mới và hấp dẫn nhất. Hàng tuần, hệ thống sẽ gửi cho bạn 2 game được nhiều người tải nhất vào thứ 2 và thứ 4. Đăng ký một lần nhận tin mãi mãi 
           <br /><b>Đặc biệt miễn phí trải nghiệm 2 Game HOT đầu tiên cho khách hàng lần đầu đăng ký</b>

           <br /><br />
                <div align="center">
                    <a class="link-non-orange" href="S2_DangKy2G.aspx?lang=<%= lang %>&w=<%= width %>">
                       <img alt="" src="/img/hot_icon.gif"/> <span class="orange bold"> << <%= AppEnv.CheckLang("Đăng Ký") %> >> </span> <img alt="" src="/img/hot_icon.gif"/>
                    </a>
                </div>

            <br /><b>Sử dụng dịch vụ:</b>
            <br />Để đăng ký soạn tin: DK GAME gửi <%= AppEnv.GetSetting("S2ShortCode")%> (miến phí đăng ký)
            <br />Hủy đăng ký soạn tin: HUY GAME gửi <%= AppEnv.GetSetting("S2ShortCode")%>
            <%--<br />Giá cước: 5.000VNĐ/game--%>
        <%--</p>--%>
    </div>
    <%--End Huong dan--%>


    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--<img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>
    </form>
</body>
</html>
