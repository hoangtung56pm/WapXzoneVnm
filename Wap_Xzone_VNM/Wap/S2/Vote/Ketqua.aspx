<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ketqua.aspx.cs" Inherits="WapXzone_VNM.Wap.S2.Vote.Ketqua" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%--<meta charset="UTF-8"/>--%>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <link rel="stylesheet" type="text/css" href="/Vote/css/normalize.css" media="all"/>
    <link rel="stylesheet" type="text/css" href="/Vote/css/styles.css" media="all"/>
    <script type="text/javascript" src="/Vote/js/jquery-1.8.3.min.js"></script>
    <title>Hen Ho Cung Than Tuong</title>
</head>
<body>
    <form id="form1" runat="server">

    
<div class="head-banner">
    <b><asp:Literal ID="litMsisdn" runat="server"></asp:Literal></b>
    <img src="/Vote/images/banner.png" alt=""/>
</div>

<div class="action-status clearfix">
    <ul>
        <li class="bg-yellow">
            <a href="/Wap/S2/Vote/Ketqua.aspx?t=vote1" title="Yêu Thích">
                <strong>
                    <asp:Label ID="lblMtLike" runat="server"></asp:Label>
                </strong>
                <b>Yêu Thích</b>
            </a>
            <span class="split">&nbsp;</span>
        </li>
        <li>
            <a href="/Wap/S2/Vote/Ketqua.aspx?t=gach1" title="Ném Gạch">
                <strong>
                    <asp:Label ID="lblMtUnLike" runat="server"></asp:Label>
                </strong>
                <b>Ném Gạch</b>
            </a>
        </li>
    </ul>
    <label class="vs">vs</label>
    <ul class="big">
        <li>
            <a href="/Wap/S2/Vote/Ketqua.aspx?t=gach2" title="Ném Gạch">
                <strong>
                    <asp:Label ID="lblLmUnLike" runat="server"></asp:Label>
                </strong>
                <b>Ném Gạch</b>
            </a>
        </li>
        <li class="bg-yellow">
            <a href="/Wap/S2/Vote/Ketqua.aspx?t=vote2" title="Yêu Thích">
                <strong>
                    <asp:Label ID="lblLmLike" runat="server"></asp:Label>
                </strong>
                <b>Yêu Thích</b>
            </a>
            <span class="split">&nbsp;</span>
        </li>
    </ul>
</div>

<div class="main-container clearfix">

    <div align="center">
                    <b>
                        <asp:Literal ID="litThongBao" runat="server"></asp:Literal>
                    </b>
                </div>

    <div class="vote-list clearfix">
        <dl>
            <dt>Danh sách Vote mai thỏ</dt>
            <dd>
                <ul>
                    <asp:Repeater ID="rptMaiTho" runat="server">
                            <ItemTemplate>
                                <li><span><%# Eval("RowNumber")%></span><label><%# Eval("User_ID")%></label></li>
                            </ItemTemplate>
                        </asp:Repeater>
                </ul>
            </dd>
        </dl>
        <dl>
            <dt>Danh sách Vote linh miu</dt>
            <dd>
                <ul>
                    <asp:Repeater ID="rptLinhMiu" runat="server">
                            <ItemTemplate>
                                <li><span><%# Eval("RowNumber")%></span><label><%# Eval("User_ID")%></label></li>
                            </ItemTemplate>
                        </asp:Repeater>
                </ul>
            </dd>
        </dl>
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
//            $('.accordion-content').hide();
        });
    </script>

    
    <div class="accordion-block">

        <h2 class="accordion-title accordion-open"><a href="#">BÌNH LUẬN</a></h2>
        <div class="accordion-content accordion-open" style="display:block">
            
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
        <div class="accordion-content" style="display:none">
            <p>Tham gia ngay và giành cơ hội hẹn hò ngoài đời thật với các HOT girl Mai Thỏ và Linh Miu quyến rũ</p>
            <br />
            <p>- Thời gian chương trình:</p>
            <br/>
            <p>Bắt đầu từ ngày <b>01/10/2013 đến 01/12/2013</b></p>
            <br/>
            <p><b>1.Cơ cấu giải thưởng:</b></p>
            <br/>
            <p>- 4 khách hàng trúng thưởng ,  mỗi tháng sẽ có 1 buổi hẹn hò ăn tối dành cho 2 khách hàng có số lượt VOTE nhiều nhất với HOT girl tại nhà hàng sang trọng cùng với những phần quà hấp dẫn từ chương trình</p>
            <br/>
            <p><b>2.Thể lệ chương trình</b></p>
            <br/>
            <p>- Mỗi lần click <b>“Yêu Thích”</b> trên wap hoặc soạn tin nhắn <b>VOTE 1 [hoặc 2]</b> gửi <b>8279</b> thì tương ứng bạn đã bình chọn 1 VOTE cho HOT girl Mai Thỏ hoặc HOT girl Linh Miu</p>
            <br/>
            <p>- Mỗi lần click <b>“ Ném gạch”</b> trên wap hoặc soạn tin nhắn <b>GACH 1 [hoặc 2]</b> gửi <b>8279</b> thì tương ứng bạn đã ném 1 GACH cho HOT girl Mai Thỏ hoặc HOT girl Linh Miu</p>
            <br/>
            <p><b>Chú ý :</b> Khi <b>“Ném gạch”</b> cho HOT girl Mai Thỏ thì tương ứng là bạn bình chọn 1 VOTE cho HOT girl Linh Miu và ngược lại</p>
            <br/>
            <p>- Người thắng cuộc là người có tổng số lượt <b>VOTE + Ném gạch</b> nhiều nhất</p>
            <br/>
            <%--<p>- 2 Người trúng giải tháng 1sẽ được loại bỏ khỏi hệ thống. Người chưa trúng giải vẫn được giữ nguyên số lượng VOTE tính dồn khi VOTE tiếp</p>--%>
        </div>

        <h2 class="accordion-title"><a href="#">CÁCH XÁC ĐỊNH NGƯỜI TRÚNG GIẢI</a></h2>
        <div class="accordion-content" style="display:none">

            <p>- Thuê bao có số lượng VOTE + Ném gạch nhiều nhất</p><br />
            <p>- Thuê bao đang hoạt động ở trạng thái 2 chiều</p><br />
            <p>- Thuê bao không hủy dịch vụ trong suốt chương trình</p><br />

        </div>

        <h2 class="accordion-title"><a href="#">CÁCH THỨC TRAO GIẢI</a></h2>
        <div class="accordion-content" style="display:none">
            <p>Thời gian thống kê số lượng để xác định thuê bao trúng  thưởng:</p><br />
            <p>- <b>Lần hẹn hò 1 : Ngày 15/11/2013</b></p><br />
            <p>- <b>Lần hẹn hò 2 : Ngày 15/12/2013</b></p><br />
            <p>- Ngay sau khi có kết quả thống kê, BTC sẽ gọi điện cho khách hàng để thông báo trúng thưởng xác minh các thủ tục cần thiết và thời gian tham gia các buổi hẹn hò với HOT girl</p><br />
            <p>- Nếu người trúng thưởng và tất cả những người trúng thưởng tiếp theo trong danh sách dự phòng bị tước giải thưởng, giải thưởng được xem là chưa được trao và thuộc quyền định đoạt của BTC.</p><br />
            <p>- <b>Chú ý : Người trúng thưởng sẽ phải chịu toàn bộ chi phí đi lại để tới địa điểm hẹn hò cùng HOT girl</b></p>
            
        </div>

        <h2 class="accordion-title"><a href="#">DANH SÁCH NGƯỜI TRÚNG GIẢI</a></h2>
        <div class="accordion-content" style="display:none">
            <p>- Danh sách trúng thưởng sẽ được cập nhật vào cuối chương trình</p><br />
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
