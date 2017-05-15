<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="henhocungthantuong.aspx.cs" Inherits="WapXzone_VNM.henhocungthantuong" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Hen Ho Cung Than Tuong</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    
    <!-- Bootstrap -->
    <link href="/Vote/assets/plugins/bootstrap-3.0/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
    <link rel="stylesheet" href="/Vote/assets/css/style.css"/>

</head>
<body>
    <form id="form1" runat="server">
        
        <div class="content-outer">
    <div class="content">
        
        <!-- begin .banner-->
        <div class="banner">
             <b><asp:Literal ID="ltrXinChao" runat="server"></asp:Literal></b>
            <img src="/Vote/assets/img/banner.png" alt=""/>
        </div>
        <!-- end banner -->

        <!-- begin .head -->
        <div class="head-nemgach">
            <div class="left">
                <a href="/Wap/S2/Vote/Ketqua.aspx?t=vote1"><img src="/Vote/assets/img/like-left.png" alt=""/></a>
                <a href="/Wap/S2/Vote/Ketqua.aspx?t=gach1"><img src="/Vote/assets/img/brickbat-left.png" alt=""/></a>
                <div class="clearfix"></div>
            </div>
            <div class="logo">
                <img src="/Vote/assets/img/vs-color.png" alt=""/>
            </div>
            <div class="right">
                <a href="/Wap/S2/Vote/Ketqua.aspx?t=gach2"><img src="/Vote/assets/img/brickbat-right.png" alt=""/></a>
                <a href="/Wap/S2/Vote/Ketqua.aspx?t=vote2"><img src="/Vote/assets/img/like-right.png" alt=""/></a>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </div>
        <!-- end .head -->

        <!-- begin .vote-phone -->
        <div class="vote-phone">
            <div class="mai-tho">
                <div class="inner">
                    <h3>Danh sách vote Mai Thỏ</h3>
                    <ul>
                        <asp:Repeater ID="rptMaiTho" runat="server">
                            <ItemTemplate>
                                <li><a href="#"><i><%# Eval("RowNumber")%></i><span><%# Eval("User_ID")%></span></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>

            <div class="linh-miu">
                <div class="inner">
                    <h3>Danh sách vote Linh Miu</h3>
                    <ul>
                        <asp:Repeater ID="rptLinhMiu" runat="server">
                            <ItemTemplate>
                                <li><a href="#"><i><%# Eval("RowNumber")%></i><span><%# Eval("User_ID")%></span></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <!-- end .vote-phone -->

        <!-- begin .about -->
        <div class="about">
            <div class="box-about">
                <h3 class="button-add">Thông tin chương trình <img src="/Vote/assets/img/button-add.png" alt=""/></h3>
                <div class="content">
                    <p>
                        
                        Tham gia ngay và giành cơ hội hẹn hò ngoài đời thật với các HOT girl Mai Thỏ và Linh Miu quyến rũ <br /><br />
                        - Thời gian chương trình:<br /> Bắt đầu từ ngày 01/10/2013 đến 30/12/2013<br /><br />
                        <b>1.Cơ cấu giải thưởng:</b><br />
                        4 khách hàng trúng thưởng ,  mỗi tháng sẽ có 1 buổi hẹn hò ăn tối dành cho 2 khách hàng có số lượt VOTE nhiều nhất với HOT girl tại nhà hàng sang trọng 
                        <br /><br />
                        <b>2. Thể lệ chương trình</b><br />
                        - Mỗi lần click <b>“ Thích”</b> trên wap hoặc soạn tin nhắn <b>VOTE 1 [hoặc 2]</b> gửi <b>8279</b> thì tương ứng bạn đã bình chọn 1 VOTE cho HOT girl Mai Thỏ hoặc HOT girl Linh Miu<br /><br />
                        - Mỗi lần click <b>“ Ném gạch”</b> trên wap hoặc soạn tin nhắn <b>GACH 1 [hoặc 2]</b> gửi <b>8279</b> thì tương ứng bạn đã ném 1 GACH cho HOT girl Mai Thỏ hoặc HOT girl Linh Miu<br /><br />
                        <b>Chú ý :</b> Khi <b>“Ném gạch”</b> cho HOT girl Mai Thỏ thì tương ứng là bạn bình chọn 1 VOTE cho HOT girl Linh Miu và ngược lại

                        <br /><br />- Người thắng cuộc là người có tổng số lượt <b>VOTE + Ném gạch</b> nhiều nhất
                        <br /><br />- 2 Người trúng giải tháng 1sẽ được loại bỏ khỏi hệ thống. Người chưa trúng giải vẫn được giữ nguyên số lượng VOTE tính dồn khi VOTE tiếp 


                    </p>
                </div>
            </div>
            <div class="box-about">
                <h3 class="button-add">Cách xác định người trúng giải<img src="/Vote/assets/img/button-add.png" alt=""/></h3>
                <div class="content">
                    <p>
                        - Thuê bao có số lượng VOTE + Ném gạch nhiều nhất<br /><br />
                        - Thuê bao đang hoạt động ở trạng thái 2 chiều<br /><br />
                        - Thuê bao không hủy dịch vụ trong suốt chương trình<br /><br />
                    </p>
                </div>
            </div>
            <div class="box-about">
                <h3 class="button-add">Cách thức trao giải<img src="/Vote/assets/img/button-add.png" alt=""/></h3>
                <div class="content">
                    <p>
                        - Ngay sau khi có kết quả thống kê, BTC sẽ gọi điện cho khách hàng để thông báo trúng thưởng và xác minh các thủ tục cần thiết<br /><br />
                        - Nếu người trúng thưởng và tất cả những người trúng thưởng tiếp theo trong danh sách dự phòng bị tước giải thưởng, giải thưởng được xem là chưa được trao và thuộc quyền định đoạt của BTC.

                    </p>
                </div>
            </div>
            <div class="box-about">
                <h3 class="button-add">Danh sách người trúng thưởng<img src="/Vote/assets/img/button-add.png" alt=""/></h3>
                <div class="content">
                    <p>
                        - Danh sách trúng thưởng sẽ được cập nhật vào cuối chương trình
                    </p>
                </div>
            </div>
        </div>
        <!-- end .about -->

        <!-- begin .footer -->
        <div class="footer">
            <p>Bản quyền Vietnamobile</p>
        </div>
        <!-- end .footer -->
    </div>
</div>

    </form>

    <script type="text/javascript" src="/Vote/assets/plugins/jquery.min.js"></script>
    <script type="text/javascript" src="/Vote/assets/plugins/bootstrap-3.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="/Vote/assets/js/app.js"></script>

</body>
</html>
