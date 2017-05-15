<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="WapXzone_VNM.Wap.S2.BongDa.Info" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Register src="/Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - BONG DA :.</title>
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
        <p class="link-non-black"><%= AppEnv.CheckLang("Bóng đá") %></p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b>Giới thiệu</b>  
           
<br />Nhận kết quả bóng đá các giải đấu hấp dân nhất thế giới nhanh và chính xác nhất.
<br />Đăng ký một lần nhận tin mãi mãi
<br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Chọn đăng ký hoặc soạn tin: DK KQ &lt;Mã Dịch vụ&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%> (miến phí đăng ký)
<br />Hủy đăng ký soạn tin: HUY KQ &lt;Mã Dịch vụ&gt; gửi <%= AppEnv.GetSetting("S2ShortCode")%>
<br />Giá cước: 3000VNĐ/tuần
        </p>

        <br />

        <table border="1" cellpadding="0" cellspacing="0" width="100%" >
            <tr align="center" style="background:#92D050; height:25px;">
                <td width="33%">Tên giải</td>
                <td width="33%">Mã dịch vụ</td>
                <td width="30%">Đăng ký</td>
            </tr>
            
            <tr style="height:25px;" align="center">
                <td>Kết quả bóng đá ngày</td>
                <td>HN</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=hn">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Giải ngoại hạng Anh</td>
                <td>ANH</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=anh">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>League 1</td>
                <td>PHAP</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=phap">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Serie A</td>
                <td>Y</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=y">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Bundesliga</td>
                <td>DUC</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=duc">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>La Liga</td>
                <td>TBN</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=tbn">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>Champion League</td>
                <td>CL</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=cl">Đăng ký</a>
                </td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>V League</td>
                <td>VN</td>
                <td>
                    <a style="color:Orange;font-weight:bold;" href="DangKy.aspx?lang=<%= lang %>&w=<%= width %>&t=vn">Đăng ký</a>
                </td>
            </tr>

        </table>
    </div>
    <%--End Huong dan--%>


    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    </form>
</body>
</html>

