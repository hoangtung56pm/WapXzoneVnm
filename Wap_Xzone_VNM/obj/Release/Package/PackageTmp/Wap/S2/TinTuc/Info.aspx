<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="WapXzone_VNM.Wap.S2.TinTuc.Info" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Register src="/Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - TIN TUC :.</title>
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
        <p class="link-non-black"><%= AppEnv.CheckLang("Tin Tức") %></p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b>Giới thiệu</b>  
           
<br />Cung cấp những thông tin mới và nhanh nhất về các vấn đề kinh tế, văn hóa,xã hội. Tin tức được cập nhật hàng ngày 
<br />Đăng ký một lần nhận tin mãi mãi
<br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Chọn đăng ký hoặc soạn tin: DK &lt;Mã Dịch vụ&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%> (miến phí đăng ký)
<br />Hủy đăng ký soạn tin: HUY &lt;Mã Dịch vụ&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%>
<br />Giá cước: 1000VNĐ/ngày
        </p>

        <br />

        <table border="1" cellpadding="0" cellspacing="0" width="100%" >
            <tr align="center" style="background:#92D050; height:25px;">
                <td width="33%">Dịch vụ</td>
                <td width="33%">Mã dịch vụ</td>
                <td width="30%">Đăng ký</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tra cứu giá vàng</td>
                <td>VA</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="/Wap/S2/VANG/S2_DangKy.aspx?lang=<%= lang %>&w=<%= width %>">Đăng ký</a>
                </td>
            </tr>
            
            <tr style="height:25px;" align="center">
                <td>Tin nóng</td>
                <td>NONG</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=nong">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tin thể thao 24h</td>
                <td>THETHAO</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=thethao">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tin tổng hợp</td>
                <td>TONGHOP</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=tonghop">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tin chuyện của sao</td>
                <td>SAO</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=sao">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tin sức khỏe đời sống</td>
                <td>DS</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=ds">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Tư vấn người lớn</td>
                <td>NL</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=NL">Đăng ký</a>
                </td>
            </tr>

        </table>
    </div>
    <%--End Huong dan--%>


    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    </form>
</body>
</html>

