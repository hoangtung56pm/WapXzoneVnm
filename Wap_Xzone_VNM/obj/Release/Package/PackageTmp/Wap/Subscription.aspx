<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Subscription.aspx.cs" Inherits="WapXzone_VNM.Wap.Subscription" %>

<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Subscription :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
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
        <p class="link-non-black">Hướng dẫn</p>
     </div>
</div>
    <div class="boxcontent">
        <p>
            <b>- Dịch vụ DailyInfo cung cấp nội dung qua SMS/MMS cho các thuê bao Vietnamobile theo hình thức thuê bao đăng ký nhận nội dung một lần và hệ thống sẽ gửi nội dung về máy di động của khách hàng trong suốt thời hạn sử dụng của dịch vụ.</b>
            <br />
            <b>- Số truy cập dịch vụ: 949</b>
        </p>
    </div>
    <%--End Huong dan--%>

    <%--Game--%>
    <div class="div1">
    <div>
        <p class="link-non-black">Dịch vụ game HOT</p>
     </div>
</div>
    <div class="boxcontent">
        <p>
            <b>Giới thiệu</b><br />
            Cung cấp cho các bạn những game mới và hấp dẫn nhất. Hàng tuần, hệ thống sẽ gửi cho bạn 2 game được nhiều người tải nhất vào thứ 2 và thứ 4. Đăng ký một lần nhận tin mãi mãi 
            <br /><b>Đặc biệt miễn phí trải nghiệm 2 Game HOT đầu tiên cho khách hàng lần đầu đăng ký</b>
            <br /><br /><b>Sử dụng dịch vụ:</b>
            <br />Để đăng ký soạn tin: DK GAME gửi 949
            <br />Hủy đăng ký soạn tin: HUY GAME gửi 949
            <br />Giá cước: 5.000VNĐ/game
        </p>
    </div>
    <%--End Game--%>

     <%--Video--%>
    <div class="div1">
    <div>
        <p class="link-non-black">Dịch vụ Video Clip</p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b>Giới thiệu</b>
<br />Cung cấp cho bạn những clip hot và nóng hổi nhất. Những thông tin mới, đặc sắc sẽ được truyền tải đến cho bạn hàng ngày. Đăng ký một lần nhận tin mãi mãi 
<br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Để đăng ký soạn tin: DK CLIP gửi 949
<br />Hủy đăng ký soạn tin: HUY CLIP gửi 949
<br />Giá cước: 2.000VNĐ/ngày
        </p>
    </div>
    <%--End Video--%>

     <%--Xổ Số--%>
    <div class="div1">
    <div>
        <p class="link-non-black">Dịch vụ Xổ số</p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b> Giới thiệu </b>
    <br />Cung cấp kết quả xổ số các tỉnh nhanh chóng, chính xác, thuận tiện. Kết quả sẽ được gửi ngay tới khách hàng sau khi mở thưởng.
    <br />Đăng ký một lần nhận tin mãi mãi
    <br /><b> biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
    <br /><br /><b>Sử dụng dịch vụ:</b>
    <br />Để đăng ký soạn tin: DK &lt;Mã Tỉnh&gt; 949
    <br />Hủy đăng ký soạn tin: HUY &lt;Mã Tỉnh&gt; 949
    <br />Giá cước: 500VNĐ/ngày
        </p>
    </div>
    <%--End Xổ Số--%>

     <%--Cặp số may mắn--%>
    <div class="div1">
    <div>
        <p class="link-non-black">Dịch vụ Cặp số may mắn</p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b>Giới thiệu</b> 
        <br />Cung cấp dự đoán cặp số may mắn các tỉnh nhanh chóng, chính xác, thuận tiện. Tư vấn và nhận định cặp số sẽ về trong ngày hiện tại
        <br />Đăng ký một lần nhận tin mãi mãi
        <br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>

        <br /><br /><b>Sử dụng dịch vụ:</b>
        <br />Để đăng ký soạn tin: DK SC &lt;Mã Tỉnh&gt; 949
        <br />Hủy đăng ký soạn tin: HUY SC &lt;Mã Tỉnh&gt; 949
        <br />Giá cước: 2000VNĐ/ngày
        </p>
    </div>
    <%--End Cặp số may mắn--%>

    <%--Truyên cười--%>
    <div class="div1">
    <div>
        <p class="link-non-black">Dịch vụ Truyện cười</p>
     </div>
</div>
    <div class="boxcontent">
        <p>
            <b>Giới thiệu</b>
<br />Hãy khởi đầu ngày mới bằng những câu chuyện cười dí dỏm và thú vị. Đăng ký một lần nhận tin mãi mãi
<br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Để đăng ký soạn tin: DK CUOI 949
<br />Hủy đăng ký soạn tin: HUY CUOI 949
<br />Giá cước: 500VNĐ/ngày
        </p>
    </div>
    <%--End Truyện cười--%>

     <%--Thời tiết--%>
    <div class="div1">
    <div>
        <p class="link-non-black">Dịch vụ Thời tiết</p>
     </div>
</div>
    <div class="boxcontent">
        <p>
           <b>Giới thiệu</b>
<br />Cập nhật thông tin thời tiết của tất cả các tỉnh thành trong cả nước với thông tin nhanh và chính xác nhất mỗi ngày.
<br />Đăng ký một lần nhận tin mãi mãi
<br /><b>Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký</b>
<br /><br /><b>Sử dụng dịch vụ:</b>
<br />Để đăng ký soạn tin: DK TT &lt;Mã Tỉnh&gt; 949
<br />Hủy đăng ký soạn tin: HUY TT &lt;Mã Tỉnh&gt; 949
<br />Giá cước: 500VNĐ/ngày
        </p>
    </div>
    <%--End Thời tiết--%>

    <uc3:footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--<img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>
    </form>
</body>
</html>