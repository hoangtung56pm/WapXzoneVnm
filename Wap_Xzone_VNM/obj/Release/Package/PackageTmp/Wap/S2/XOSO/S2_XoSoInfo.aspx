<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S2_XoSoInfo.aspx.cs" Inherits="WapXzone_VNM.Wap.S2.XOSO.S2_XoSoInfo" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Register src="/Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Xổ Số :.</title>
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
        <p class="link-non-black"><%= AppEnv.CheckLang("Xổ Số") %></p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b>Giới thiệu</b>  
           

<br />Cung cấp kết quả xổ số các tỉnh nhanh chóng, chính xác, thuận tiện. Kết quả sẽ được gửi ngay tới khách hàng sau khi mở thưởng.
    Đăng ký một lần nhận tin mãi mãi
<br /><b>Đặc biệt miễn phí sử dụng 14 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Chọn đăng ký hoặc soạn tin: DK &lt;Mã Tỉnh&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%> (miến phí đăng ký)
<br />Hủy đăng ký soạn tin: HUY &lt;Mã Tỉnh&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%>
<br />Giá cước: 5.00VNĐ/ngày
        </p>

        <br />

         <table border="1" cellpadding="0" cellspacing="0" width="100%" >
            <tr align="center" style="background:#92D050; height:25px;">
                <td width="33%">Vùng</td>
                <td width="33%">Mã Tỉnh</td>
                <td width="30%">Đăng ký</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Thủ Đô</td>
                <td>MB</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&id=0">Đăng ký</a>
                </td>
            </tr>

            <asp:Repeater ID="rptlst" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr style="height:25px;" align="center">
                        <td><asp:Literal ID="litCityName" runat="server"></asp:Literal></td>
                        <td><asp:Literal ID="litCityCode" runat="server"></asp:Literal></td>
                    <td>
                        <%--<a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=td">Đăng ký</a>--%>
                        <asp:Literal ID="litLink" runat="server"></asp:Literal>
                    </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>

    </div>
    <%--End Huong dan--%>


    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--<img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>
    </form>
</body>
</html>
