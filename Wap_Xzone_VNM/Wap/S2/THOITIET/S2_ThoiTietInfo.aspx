<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S2_ThoiTietInfo.aspx.cs" Inherits="WapXzone_VNM.Wap.S2.THOITIET.S2_ThoiTietInfo" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Register src="/Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - THOI TIET :.</title>
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
        <p class="link-non-black"><%= AppEnv.CheckLang("Thời Tiết") %></p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b>Giới thiệu</b>  
            <%--<a class="link-non-orange float-right" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                   <span class="orange bold"> << <%= AppEnv.CheckLang("Đăng Ký") %> >> </span>
            </a>--%>

<br />Cập nhật thông tin thời tiết của tất cả các tỉnh thành trong cả nước với thông tin nhanh và chính xác nhất mỗi ngày.Đăng ký một lần nhận tin mãi mãi
<br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Chọn đăng ký hoặc soạn tin: DK TT &lt;Mã Tỉnh&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%> (miến phí đăng ký)
<br />Hủy đăng ký soạn tin: HUY TT &lt;Mã Tỉnh&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%>
<br />Giá cước: 500VNĐ/ngày
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
                <td>TD</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=td">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Đông Bắc Bộ</td>
                <td>DBB</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=dbb">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tây Bắc Bộ</td>
                <td>TBB</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=tbb">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Bắc Trung Bộ</td>
                <td>BTB</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=btb">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Nam Trung Bộ</td>
                <td>NTB</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=ntb">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tây Nguyên</td>
                <td>TN</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=tn">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Nam Bộ</td>
                <td>NB</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=nb">Đăng ký</a>
                </td>
            </tr>

        </table>

    </div>
    <%--End Huong dan--%>


    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--<img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>
    </form>
</body>
</html>
