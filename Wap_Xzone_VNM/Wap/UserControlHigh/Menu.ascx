<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.Menu" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div id="menu" class="menu">

    <ul>

        <li>
            <p class="danh-muc">
                Danh mục
            </p>
        </li>

        <li><a href="<%= AppEnv.GetSetting("SmartPhoneHome") %>">
                <img alt="" src="/Content/asset/Images/icon-menu.png" />Trang chủ</a>
        </li>

        <li><a href="<%= UrlProcess.GameHome() %>">
                <img alt="" src="/Content/asset/Images/icon/game.png" /> Game</a>
        </li>

        <li><a href="<%= UrlProcess.GioiTinhHome() %>">
                <img alt="" src="/Content/asset/Images/icon/gioi-tinh.png" />Giới tính</a></li>

        <li>
            <a href="<%= UrlProcess.HinhNenHome() %>">
                <img alt="" src="/Content/asset/Images/icon/anh.png" />Hình nền</a>
            <%--<span class="quantity-item">25</span>--%>
        </li>

        <li><a href="<%= UrlProcess.HoangDaoHome() %>">
                <img alt="" src="/Content/asset/Images/icon/cung-hoang-cao.png" />Hoàng đạo</a></li>

        <li><a href="<%= UrlProcess.AmNhacHome() %>">
                <img alt="" src="/Content/asset/Images/icon/music.png" />Music</a></li>

        <li><a href="<%= UrlProcess.PhanMemHome() %>">
                <img alt="" src="/Content/asset/Images/icon/phan-mem.png" />Phần mềm</a></li>

        <li><a href="<%= UrlProcess.TheThaoHome() %>">
                <img alt="" src="/Content/asset/Images/icon/thethao.png" />Thể thao</a></li>

        <li><a href="<%= UrlProcess.ThuGianHome() %>">
                <img alt="" src="/Content/asset/Images/icon/thu-gian.png" />Thư giãn</a></li>

        <li><a href="<%= UrlProcess.TinTucHome() %>">
                <img alt="" src="/Content/asset/Images/icon/tintuc.png" />Tin tức</a></li>

        <li><a href="<%= UrlProcess.TruyenOnlineHome() %>">
                <img alt="" src="/Content/asset/Images/icon/truyen.png" />Truyện</a></li>

        <li><a href="<%= UrlProcess.VideoHome() %>">
                <img alt="" src="/Content/asset/Images/icon/video.png" />Video</a></li>

       <%-- <li><a href="<%= UrlProcess.XoSoHome() %>">
                <img alt="" src="/Content/asset/Images/icon/xo-so.png" />Xổ số</a></li>--%>


    </ul>
</div>
