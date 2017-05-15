<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WapXzone_VNM.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.css"/>
    <link rel="stylesheet" href="/Content/asset/Css/style.css"/>
    <script type="text/javascript" src="/Content/asset/Javascript/jquery-1.10.2.min.js"></script>

    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>

</head>
<body>

    <%--<form id="form1" runat="server">--%>
    
    <div id="menu" class="menu">

    <ul>
        <li>
            <p class="danh-muc">
                Danh mục
            </p>
        </li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" /> Menu1</a></li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a></li>
        <li>
            <a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a>
            <span class="quantity-item">25</span>
        </li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a></li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a></li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a></li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a></li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a></li>
        <li><a href="#">
                <img src="/Content/asset/Images/icon-menu.png" />Menu1</a></li>

    </ul>
</div>

<div class="wrapper">
<!--begin header-->
<div class="header">
    <a href="#menu" class="btn-menu">
        <img src="/Content/asset/Images/btn-menu.png" alt=""/>
    </a>
    <a class="option" href="#">
        <img src="/Content/asset/Images/option.png" alt=""/>
    </a>
    <img src="/Content/asset/Images/vii.png" alt="" class="logo"/>
</div>
<!--begin body-->
<div class="body">
<div class="filter">
    <ul class="nav-top">
        <li><a href="#" class="active">Game</a></li>
        <li><a href="#">Video</a></li>
        <li><a href="#">Daily info</a></li>
    </ul>
</div>
<div class="tin-hot">
    <div class="box-title">
        <div class="title">
            <h4>Tin Hot</h4>
        </div>
        <div class="xem-them">
            <a href="#">Xem thêm <span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
    </div>
    <div class="list-news">
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/img-news.png" alt=""/>
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/img-news.png" alt=""/>
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/img-news.png" alt=""/>
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/img-news.png" alt=""/>
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
    </div>
    <div class="border-bottom"></div>
</div>
<div class="ads">
    <a href="#">
        <img src="/Content/asset/Images/ads.png" alt=""/>
    </a>

</div>
<div class="video">
    <div class="box-title">
        <div class="title">
            <h4>Video</h4>
        </div>
        <div class="xem-them">
            <a href="#">Xem thêm <span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
    </div>
    <div class="video-large">
        <a href="#">
            <img src="/Content/asset/Images/thumbnail-video-large.png" alt=""/>
        </a>

        <p class="description">
            10 cảnh nóng bỏng nhất năm của Kate upton
        </p>
    </div>
    <div class="list-news list-video">
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/thumbnail-video-small.png" alt=""/>
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/thumbnail-video-small.png" alt=""/>
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
    </div>
    <div class="border-bottom"></div>
</div>
<div class="ads">
    <a href="#">
        <img src="/Content/asset/Images/ads.png" alt=""/>
    </a>
</div>
<div class="game">
    <div class="box-title">
        <div class="title">
            <h4>Game Hay</h4>
        </div>
        <div class="xem-them">
            <a href="#">Xem thêm <span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
    </div>
    <div class="list-game">
        <div class="item">
            <div class="border">
                <a href="#">
                    <img src="/Content/asset/Images/thumbnail-game.png" alt=""/>
                </a>

                <p class="name">Angry
                    Birds Go!</p>

                <p class="price">FREE</p>
            </div>
        </div>
        <div class="item">
            <div class="border">
                <a href="#">
                    <img src="/Content/asset/Images/thumbnail-game.png" alt=""/>
                </a>

                <p class="name">Angry
                    Birds Go!</p>

                <p class="price">FREE</p>
            </div>
        </div>
        <div class="item">
            <div class="border">
                <a href="#">
                    <img src="/Content/asset/Images/thumbnail-game.png" alt=""/>
                </a>

                <p class="name">Angry
                    Birds Go!</p>

                <p class="price">FREE</p>
            </div>
        </div>
        <div class="item">
            <div class="border">
                <a href="#">
                    <img src="/Content/asset/Images/thumbnail-game.png" alt=""/>
                </a>

                <p class="name">Angry
                    Birds Go!</p>

                <p class="price">FREE</p>
            </div>
        </div>
        <div class="item">
            <div class="border">
                <a href="#">
                    <img src="/Content/asset/Images/thumbnail-game.png" alt=""/>
                </a>

                <p class="name">Angry
                    Birds Go!</p>

                <p class="price">FREE</p>
            </div>
        </div>
        <div class="item">
            <div class="border">
                <a href="#">
                    <img src="/Content/asset/Images/thumbnail-game.png" alt=""/>
                </a>

                <p class="name">Angry
                    Birds Go!</p>

                <p class="price">FREE</p>
            </div>
        </div>
    </div>
    <div class="border-bottom"></div>
</div>
<div class="ads">
    <a href="#">
        <img src="/Content/asset/Images/ads.png" alt=""/>
    </a>
</div>
<div class="tin-hot">
    <div class="box-title">
        <div class="title">
            <h4>Giới Tính</h4>
        </div>
        <div class="xem-them">
            <a href="#">Xem thêm <span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
    </div>
    <div class="list-news">
        <div class="item">
            <a href="#">
                <img alt="" src="/Content/asset/Images/img-news.png">
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img alt="" src="/Content/asset/Images/img-news.png">
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img alt="" src="/Content/asset/Images/img-news.png">
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img alt="" src="/Content/asset/Images/img-news.png">
            </a>

            <p class="description">
                <a href="#">
                    Tàu ngầm của việt nam được bốc dỡ thế nào?
                </a>
            </p>
        </div>
    </div>
    <div class="border-bottom"></div>
</div>
<div class="truyen">
    <div class="box-title">
        <div class="title">
            <h4>Truyện</h4>
        </div>
        <div class="xem-them">
            <a href="#">Xem thêm <span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
    </div>
    <div class="list-truyen">
        <div class="item">
            <a class="thumbnail-img" href="#">
                <img src="/Content/asset/Images/thumbnail-truyen.png" alt=""/>
            </a>
            <div class="info">
                <h4><a href="#">Ma Long( Chương 3) </a></h4>
                <span>Thể loại: Kiếm hiệp <br/>
                    Chương 3: Sống lại 10 năm trước <br/>
                    (thượng)Nguồn: VipvandaDịch: Nhóm dịch black vipvanda  :Một thiếu... </span>
            </div>
        </div>
        <div class="item">
            <a class="thumbnail-img" href="#">
                <img src="/Content/asset/Images/thumbnail-truyen.png" alt=""/>
            </a>
            <div class="info">
                <h4><a href="#">Ma Long( Chương 3) </a></h4>
                <span>Thể loại: Kiếm hiệp <br/>
                    Chương 3: Sống lại 10 năm trước <br/>
                    (thượng)Nguồn: VipvandaDịch: Nhóm dịch black vipvanda  :Một thiếu... </span>
            </div>
        </div>
        <div class="item">
            <a class="thumbnail-img" href="#">
                <img src="/Content/asset/Images/thumbnail-truyen.png" alt=""/>
            </a>
            <div class="info">
                <h4><a href="#">Ma Long( Chương 3) </a></h4>
                <span>Thể loại: Kiếm hiệp <br/>
                    Chương 3: Sống lại 10 năm trước <br/>
                    (thượng)Nguồn: VipvandaDịch: Nhóm dịch black vipvanda  :Một thiếu... </span>
            </div>
        </div>
        <div class="item">
            <a class="thumbnail-img" href="#">
                <img src="/Content/asset/Images/thumbnail-truyen.png" alt=""/>
            </a>
            <div class="info">
                <h4><a href="#">Ma Long( Chương 3) </a></h4>
                <span>Thể loại: Kiếm hiệp <br/>
                    Chương 3: Sống lại 10 năm trước <br/>
                    (thượng)Nguồn: VipvandaDịch: Nhóm dịch black vipvanda  :Một thiếu... </span>
            </div>
        </div>
    </div>
</div>
<div class="dich-vu">
    <div class="box-title">
        <div class="title">
            <h4>Dịch vụ khác</h4>
        </div>
        <div class="xem-them">
            <a href="#">Xem thêm <span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
    </div>
    <div class="list-dichvu">
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-camera.png" alt=""/>
            </a>

            <p class="name">
                Video clip
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/xoso.png" alt=""/>
            </a>

            <p class="name">
                Xổ số
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/nhac.png" alt=""/>
            </a>

            <p class="name">
                Nhạc
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-thethao.png" alt=""/>
            </a>

            <p class="name">
                Bóng đá
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-boivui.png" alt=""/>
            </a>

            <p class="name">
                Bói vui
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-cafe.png" alt=""/>
            </a>

            <p class="name">
                Thư giãn
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-hinhnen.png" alt=""/>
            </a>

            <p class="name">
                Hình nền
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-tintuc.png" alt=""/>
            </a>

            <p class="name">
                Tin tức
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-henho.png" alt=""/>
            </a>

            <p class="name">
                Hẹn hò
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-phanmem.png" alt=""/>
            </a>

            <p class="name">
                Phần mềm
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-game.png" alt=""/>
            </a>

            <p class="name">
                Game
            </p>
        </div>
        <div class="item">
            <a href="#">
                <img src="/Content/asset/Images/icon-truyen.png" alt=""/>
            </a>

            <p class="name">
                Truyện Online
            </p>
        </div>
    </div>
</div>
</div>

<div class="footer">
    <span>Đầu trang | Không dấu | hỗ trợ: 19001255</span> <br/>
    <span>Bản quyền vietnammobile</span>
</div>
</div>


    <%--</form>--%>

</body>
</html>
