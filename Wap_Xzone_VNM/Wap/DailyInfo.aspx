<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyInfo.aspx.cs" Inherits="WapXzone_VNM.Wap.DailyInfo" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - DailyInfo :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />

    <asp:Literal ID="ltrWidth" EnableViewState="false" runat="server"></asp:Literal>

    <%--<meta name="viewport" content="width=device-width; initial-scale=1.0" />--%>

    <style media="screen" type="text/css">
        @import "../css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:header ID="Header1" runat="server" EnableViewState="False" />    
    
    <%--Huong dan--%>
    <div class="div1">
    <div>
        <p class="link-non-black">
            Giới thiệu dịch vụ
        </p>
     </div>
</div>
    <div class="boxcontent">
        <p>
            <b>
                - Dịch vụ Subscription cung cấp nội dung qua SMS/MMS cho các thuê bao Vietnamobile theo hình thức thuê bao đăng ký nhận nội dung một lần và hệ thống sẽ gửi nội dung về máy di động của khách hàng trong suốt thời hạn sử dụng của dịch vụ.
                <br />- Số truy cập dịch vụ: 223/949
            </b>
        </p>

         <%--<table border="1" cellpadding="0" cellspacing="0" width="100%" >
            <tr align="center" style="background:#92D050; height:25px;">
                <td width="33%">STT</td>
                <td width="33%">Tên dịch vụ</td>
                <td width="30%">Số mã dự thưởng</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>1</td>
                <td>Game hot tuần</td>
                <td>2</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>2</td>
                <td>Video clip ngày</td>
                <td>2</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>3</td>
                <td>Soi cầu ngày</td>
                <td>2</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>4</td>
                <td>Truyện cười ngày</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>5</td>
                <td>KQXS ngày</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>6</td>
                <td>Thời tiết ngày</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>7</td>
                <td>Tra cứu giá vàng</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>8</td>
                <td>Tin nóng</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>9</td>
                <td>Tin thể thao 24h</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>10</td>
                <td>Tin tổng hợp</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>11</td>
                <td>Tin chuyện của Sao</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>12</td>
                <td>Nhạc chuông HOT</td>
                <td>2</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>13</td>
                <td>Tin Sức khỏe đời sống</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>14</td>
                <td>Kết quả bóng đá ngày</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>15</td>
                <td>Kết quả bóng đá theo giải</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>16</td>
                <td>Tin khuyến mại</td>
                <td>1</td>
            </tr>

            <tr style="height:25px;" align="center">
                <td>17</td>
                <td>Tư vấn người lớn</td>
                <td>1</td>
            </tr>

         </table>--%>

    </div>
    <%--End Huong dan--%>


    <div class="rbroundbox">
        <div class="rbtop logo-vnm"><div><asp:Literal ID="ltrDichVu" runat="server" Text="Cac dich vu DailyInfo"></asp:Literal></div></div>
    </div>
    <div class="clearfix"></div>

    <div class="rowcontent">
    
        <div class="col1">
        <a href="/Wap/S2/Game/S2_GameInfo.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2071VMN_W_ICON_Game.png"/></a>
        <p><a href="/Wap/S2/Game/S2_GameInfo.aspx?lang=<%= lang %>&w=<%= width %>">Game</a></p>
        </div>
    
        <div class="col2">
        <a href="/Wap/S2/Clip/S2_ClipInfo.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2070VMN_W_ICON_Video-clip.png" /></a>
        <p><a href="/Wap/S2/Clip/S2_ClipInfo.aspx?lang=<%= lang %>&w=<%= width %>" >Clip</a></p>
        </div>
    
        <div class="col3">
        <a href="/Wap/S2/ThoiTiet/S2_ThoiTietInfo.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2072VMN_W_ICON_thu-gian.png"/></a>
        <p><a href="/Wap/S2/ThoiTiet/S2_ThoiTietInfo.aspx?lang=<%= lang %>&w=<%= width %>"><%= AppEnv.CheckLang("Thời tiết") %></a></p>
        </div>

    </div>

    <div class="clearfix"></div>

    <div class="rowcontent">
    
        <div class="col1">
            <a href="/Wap/S2/XoSo/S2_XoSoInfo.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2071VMN_W_ICON_Xo-so.png"/></a>
            <p><a href="/Wap/S2/XoSo/S2_XoSoInfo.aspx?lang=<%= lang %>&w=<%= width %>"><%= AppEnv.CheckLang("Xổ số")%></a></p>
        </div>
    
        <div class="col2">
        <a href="/Wap/S2/Cuoi/S2_CuoiInfo.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2070VMN_W_ICON_Hinh-nen.png" /></a>
        <p><a href="/Wap/S2/Cuoi/S2_CuoiInfo.aspx?lang=<%= lang %>&w=<%= width %>" ><%= AppEnv.CheckLang("Truyện cười")%></a></p>
        </div>
    
        <div class="col3">
        <a href="/Wap/S2/SoiCau/S2_SoiCauInfo.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2073VMN_W_ICON_Tin-tuc.png"/></a>
        <p><a href="/Wap/S2/SoiCau/S2_SoiCauInfo.aspx?lang=<%= lang %>&w=<%= width %>"><%= AppEnv.CheckLang("Thống kê cặp số") %></a></p>
        </div>

    </div>

     <div class="clearfix"></div>
        
    <div class="rowcontent">

       

         <div class="col1">
        <a href="/Wap/S2/BongDa/Info.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2071VMN_W_ICON_Bong-da1.png"/></a>
        <p><a href="/Wap/S2/BongDa/Info.aspx?lang=<%= lang %>&w=<%= width %>"><%= AppEnv.CheckLang("Kết quả bóng đá")%></a></p>
        </div>

         <div class="col2">
        <a href="/Wap/S2/NhacChuong/Info.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2070VMN_W_ICON_Am-nhac.png"/></a>
        <p><a href="/Wap/S2/NhacChuong/Info.aspx?lang=<%= lang %>&w=<%= width %>"><%= AppEnv.CheckLang("Nhạc chuông")%></a></p>
        </div>

        <div class="col3">
        <a href="/Wap/S2/TinTuc/Info.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2073VMN_W_ICON_Tin-tuc.png"/></a>
        <p><a href="/Wap/S2/TinTuc/Info.aspx?lang=<%= lang %>&w=<%= width %>"><%= AppEnv.CheckLang("Tin Tức")%></a></p>
        </div>

    </div>

     <div class="clearfix"></div>
        
    <%--<div class="rowcontent">

         <div class="col1">
        <a href="/Wap/S2/BongDa/Info.aspx?lang=<%= lang %>&w=<%= width %>"><img alt="" style="border-width:0px;border: medium none;" src="http://media.xzone.vn//Upload/WAP/CP/2071VMN_W_ICON_Bong-da1.png"/></a>
        <p><a href="/Wap/S2/BongDa/Info.aspx?lang=<%= lang %>&w=<%= width %>"><%= AppEnv.CheckLang("Kết quả bóng đá")%></a></p>
        </div>

    </div>--%>

    <%--<div class="clearfix"></div>
     <div class="rbroundbox">
        <div class="rbtop logo-vnm"><div>Tra cứu mã số dự thưởng</div></div>
    </div>
    <div class="clearfix"></div>

    <div class="rowcontent">
        Số điện thoại <asp:TextBox ID="txtMsisdn" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Tìm" onclick="btnSearch_Click" />
        <br />
        (Ví dụ : 84978888888)
        <br />

        <asp:Label ID="lblThongBao" Visible="false" runat="server"></asp:Label>

        <asp:Repeater ID="rptGiftCode" runat="server">

            <HeaderTemplate>
                <table border="1" cellpadding="0" cellspacing="0" width="100%" >
                    <tr align="center" style="background:#92D050; height:25px;">
                        <td width="33%">Dịch vụ</td>
                        <td width="30%">Mã dự thưởng</td>
                        <td width="33%">Ngày đăng ký</td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr style="height:25px;" align="center">
                    <td><%# Eval("Service_Name")%></td>
                    <td><%# Eval("Gift_Code")%></td>
                    <td><%# ConvertUtility.ToDateTime(Eval("Register_Time")).ToString("dd/MM/yyyy hh:mm") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>

    </div>--%>

    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    </form>
</body>
</html>
