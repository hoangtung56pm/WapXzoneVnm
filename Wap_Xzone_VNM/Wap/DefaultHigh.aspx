<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultHigh.aspx.cs" Inherits="WapXzone_VNM.Wap.DefaultHigh" %>

<%@ Register Src="UserControlHigh/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControlHigh/Header.ascx" TagName="Header" TagPrefix="uc2" %>
<%@ Register Src="UserControlHigh/Menu.ascx" TagName="Menu" TagPrefix="uc3" %>
<%@ Register Src="UserControlHigh/Filter.ascx" TagName="Filter" TagPrefix="uc4" %>
<%@ Register Src="UserControlHigh/TinHot.ascx" TagName="TinHot" TagPrefix="uc5" %>
<%@ Register Src="UserControlHigh/TopBanner.ascx" TagName="TopBanner" TagPrefix="uc6" %>
<%@ Register Src="UserControlHigh/BottomBanner.ascx" TagName="BottomBanner" TagPrefix="uc7" %>
<%@ Register Src="UserControlHigh/Video.ascx" TagName="Video" TagPrefix="uc8" %>
<%@ Register Src="UserControlHigh/GameHay.ascx" TagName="GameHay" TagPrefix="uc9" %>
<%@ Register Src="UserControlHigh/GioiTinh.ascx" TagName="GioiTinh" TagPrefix="uc10" %>

<%@ Register Src="UserControlHigh/Truyen.ascx" TagName="Truyen" TagPrefix="uc11" %>
<%@ Register Src="UserControlHigh/DichVu.ascx" TagName="DichVu" TagPrefix="uc12" %>

<%@ Register Src="UserControlHigh/WebTinKhuyenMai.ascx" TagName="TinKhuyenMai" TagPrefix="uc13" %>

<%@ Register Src="UserControlHigh/Phim.ascx" TagName="Phim" TagPrefix="uc14" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>.: Vietnamobile - Trang chu :.</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css" />
    <link rel="stylesheet" href="/Content/asset/Css/style.css" />
    <script type="text/javascript" src="/assets/jquery/jquery-2.1.4.min.js"></script>
    <%--<script type="text/javascript" src="/Content/asset/Javascript/jquery.min.js"></script>--%>
    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.hammer.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>

    <%--<script type="text/javascript" src="/Script/jquery-1.7.1.min.js"></script>--%>
    <script type="text/javascript" src="/Script/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/jquery-ui.css" />
    <link href="/css/braviStyle.css" rel="stylesheet" type="text/css" />
    <script src="/Script/braviPopup.js" type="text/javascript"></script>


    <link href="/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/masonry/3.3.2/masonry.pkgd.min.js"></script>
    <%--<script type="text/javascript" src="/assets/jquery/jquery-2.1.4.min.js"></script>--%>
    <script type="text/javascript" src="/assets/plugins/bootstrap/js/bootstrap.js"></script>
    <%--<script type="text/javascript">          
           $(document).ready(function () {
               $('#btnTest').click(function () {
                   //$.braviPopUp('popup', 'http://wap.vietnamobile.com.vn/Sub/RegisGameportal.aspx', 350, 1000); 
                   $.braviPopUp('popup', 'http://wap.vietnamobile.com.vn/Sub/RegisGameportal.aspx', 320, 1000);
               });
           });
    </script>--%>

   <%-- <script type="text/javascript">
        $(document).ready(function () {
            //alert('Hệ thống bận vui lòng thử lại sau !');
            //document.getElementById('btnTest').click();
            $("#popup-login").modal();
        });
    </script>
    <style> 

        .close {
            cursor: pointer;
            float: right;
            margin-top: -30px;
            
        }
        .close:hover{
            margin-top: -30px;
        }
    </style>--%>
</head>
<body>

    <%--<form id="form1" runat="server">--%>

    <div class="dialogBox" style="display: none;">
        <a class="center-parent" id="btnTest" style="display: block; height: 30px; width: 50px; background-color: black; margin-left: 50%;"></a>
    </div>

    <uc3:Menu ID="Menu1" runat="server" EnableViewState="False" />

    <div class="wrapper">

        <uc2:Header ID="Header1" runat="server" EnableViewState="False" />

        <div class="body">

            <uc4:Filter ID="Filter1" runat="server" EnableViewState="False" />

            <uc5:TinHot ID="TinHot1" runat="server" EnableViewState="False" />

            <uc6:TopBanner ID="TopBanner1" runat="server" EnableViewState="False" />

            <uc8:Video ID="Video1" runat="server" EnableViewState="False" />

            <uc7:BottomBanner ID="BottomBanner1" runat="server" EnableViewState="False" />

            <%--<uc9:GameHay ID="GameHay1" runat="server" EnableViewState="False" />--%>

            <%--<uc6:TopBanner ID="TopBanner2" runat="server" EnableViewState="False" />--%>

            <uc10:GioiTinh ID="GioiTinh1" runat="server" EnableViewState="False" />

            <uc11:Truyen ID="Truyen1" runat="server" EnableViewState="False" />

            <uc14:Phim ID="Phim" runat="server" EnableViewState="False" />

            <uc12:DichVu ID="DichVu1" runat="server" EnableViewState="False" />

            <uc13:TinKhuyenMai ID="TinKhuyenMai1" runat="server" EnableViewState="False" />

        </div>

        <uc1:Footer ID="Footer1" runat="server" EnableViewState="False" />

    </div>

    <div class="modal fade" id="popup-login">
        <div class="modal-dialog">
            <div class="modal-content">
                
            <%--    <div class="modal-body" style="padding:0;">
                    
                    <a href="http://visport.vn/wap/DangKy.aspx" onclick="return confirm('Bạn có đồng ý đăng ký dịch vụ Visport với giá 5.000đ/ngày không ?')" ><img style="width: 100%; margin-top: -30px;" src="/images/Popup.jpg" /></a>
                    
                   
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">
                                <img src="/images/close.jpg" alt="" style="width: 28px">                                   

                            </span>
                        </button>
                </div>--%>
                
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <%--</form>--%>
</body>
</html>
