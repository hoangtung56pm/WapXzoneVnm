<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteNew.aspx.cs" Inherits="WapXzone_VNM.VoteNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <link rel="stylesheet" type="text/css" href="/VoteNew/css/normalize.css" media="all"/>
    <link rel="stylesheet" type="text/css" href="/VoteNew/css/styles.css" media="all"/>
    <script type="text/javascript" src="/VoteNew/js/jquery-1.8.3.min.js"></script>
    <title>HOT GIRL QUAN TU</title>

</head>
<body>
    <form id="form1" runat="server">
    
    <div class="head-banner">
    <img src="/VoteNew/images/banner-1.png" alt=""/>
</div>

<div class="action-status clearfix">
    <a class="btn-vote" href="/hot-girl-vote.aspx">
        <img src="/VoteNew/images/btn-vote.png" alt=""/>
        <span class="count-vote"><%= VoteSum %></span>
    </a>
</div>

<div class="main-container clearfix">
    
    <div align="center">
        <b>
            <asp:Literal ID="litThongBao" runat="server"></asp:Literal>
        </b>
    </div>

    <div class="vote-list clearfix">
        <table class="table-vote">
            <thead>
                <tr>
                    <th>STT</th>
                    <th>SỐ ĐIỆN THOẠI</th>
                    <th>SỐ LƯỢT VOTE</th>
                </tr>
            </thead>
            <tbody>
                
                <asp:Repeater ID="rptTop" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("RowNumber") %></td>
                            <td><%# Eval("User_ID") %></td>
                            <td><%# Eval("Vote_Count") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.accordion-title').click(function () {
                $('.accordion-title').removeClass('accordion-open');
                $('.accordion-content').slideUp(200);
                if ($(this).next().is(':hidden') == true) {
                    $(this).addClass('accordion-open');
                    $(this).next().slideDown(200);
                }
                return false;
            });
            $('.accordion-content').hide();
        });
    </script>

    <div class="accordion-block">
        <h2 class="accordion-title"><a href="#">BÌNH LUẬN</a></h2>
        <div class="accordion-content">

            <div style="padding-bottom: 1em;" align="center">
                    <div id="fb-root"></div>
                    <script>                        (function (d, s, id) {
                            var js, fjs = d.getElementsByTagName(s)[0];
                            if (d.getElementById(id)) return;
                            js = d.createElement(s); js.id = id;
                            js.src = "//connect.facebook.net/vi_VN/all.js#xfbml=1";
                            fjs.parentNode.insertBefore(js, fjs);
                        } (document, 'script', 'facebook-jssdk'));</script>
                    <asp:Literal runat="server" ID="ltCommentFB"></asp:Literal>
                </div>


        </div>

        <h2 class="accordion-title"><a href="#">THÔNG TIN CHƯƠNG TRÌNH</a></h2>
        <div class="accordion-content">
            <p>a) Thời gian chạy chương trình</p>
            <br/>
            <p>Thời gian: từ ngày 15/03/2014 đến 20/04/2014</p>
            <br/>
            <p>b) Giải thưởng</p>
            <br/>
            <p>Hẹn hò với HOT GIRLS: Mai Thỏ - Hường Hana - Hà Min - Cún Chảnh</p>
            <br/>
            <p>c)   Quy định tham gia quay thưởng</p>
            <br/>
            <p>Thuê bao đã vote cho hình ảnh đại diện của Vietnamobile.</p>
            <br/>
            <p>thuê bao có Mã dự thưởng khi vote cho hình ảnh đại diện (Vote ít nhất 1 lần) +  Trước thời điểm Quay thưởng thuê bao đó không được nhắn tin hủy dịch vụ.</p>
        </div>

        <h2 class="accordion-title"><a href="#">CÁCH THỨC TRAO GIẢI</a></h2>
        <div class="accordion-content">
            <p> Thời gian thống kê số lượng để xác định thuê bao trúng thưởng:</p>
            <br />
            <p>- Lần hẹn hò 1 : Ngày 25/04/2014</p>
            <br />
            <p>
                Ngay sau khi có kết quả thống kê BTC sẽ gọi điện cho khách hàng để thông báo trúng thưởng,  xác minh các thủ tục cần thiết và thời gian tham gia các buổi hẹn hò với HOT girl
            </p>
            <br />
            <p>
                Nếu người trúng thưởng và tất cả những người trúng thưởng tiếp theo trong danh sách dự phòng bị tước giải thưởng, giải thưởng được xem là chưa được trao và thuộc quyền định đoạt của BTC.
            </p>

        </div>

        <h2 class="accordion-title"><a href="#">3.	Cách xác định người trúng giải:</a></h2>
        <div class="accordion-content">
            <p>
                - Người có số lượt Vote nhiều nhất sẽ được lựa chọn 1 trong 4 Hot Girls để tham dự bữa tối lãng mạn cùng người đẹp.
            </p>
        </div>

        <h2 class="accordion-title"><a href="#">DANH SÁCH NGƯỜI TRÚNG GIẢI</a></h2>
        <div class="accordion-content">
            <p>
                Danh sách trúng giải sẽ được cập nhật vào cuối chương trình
            </p>
        </div>

    </div>

</div>

<div class="footer">
    <script>
        $(document).ready(function () {
            $('.back-top').click(function () {
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        });
    </script>
    <p>
        <a href="#" class="back-top">Đầu trang</a>
        &nbsp;|&nbsp;
        <a href="#">Không dấu</a>
        &nbsp;|&nbsp;
        Hỗ trợ: 19001255
    </p>
    Bản quyền Vietnamobile
</div>

    </form>
</body>
</html>
