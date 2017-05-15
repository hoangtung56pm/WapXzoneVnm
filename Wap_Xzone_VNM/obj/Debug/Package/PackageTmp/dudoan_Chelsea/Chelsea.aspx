<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chelsea.aspx.cs" Inherits="WapXzone_VNM.dudoan_Chelsea.Chelsea" %>
<link type="text/css" rel="stylesheet" href="/Library/css/style.css"/>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
   
<head id="Head1" runat="server">
    <title></title>
     <meta name="viewport" content="user-scalable = no">
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
         <script type="text/javascript">
             $(document).ready(function () {
                 $("#tab1").show();
                 $("#tab2").hide();
                 $("#tab3").hide();
                 $("#tab4").hide();
            
             $(".home").click(function () {
                 $('#tab1').show();
                 $("#tab2").hide();
                 $("#tab3").hide();
                 $("#tab4").hide();
             });
             $("#thele").on("click", function () {
                 $('#tab2').show();
                 $("#tab1").hide();
                 $("#tab3").hide();
                 $("#tab4").hide();
             });
             $(".giaithuong").click(function () {
                 $('#tab3').show();
                 $("#tab1").hide();
                 $("#tab2").hide();
                 $("#tab4").hide();
             });
             $(".dangky").click(function () {
                 $('#tab4').show();
                 $("#tab1").hide();
                 $("#tab2").hide();
                 $("#tab3").hide();
             });
     });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
    <img src="/Library/Img/trang-chu.png" class="icon_khach"/>
        <span>Xin chào: Khách|Hướng dẫn</span>
    </div>
        <div id="menu">
            <ul id="nav">
                <li class="homepage" >
                    <a class="home">Trang chủ</a> 
                </li>
                <li class="page1"  >
                     <a id="thele">Thể lệ</a> 
                </li>
                <li class="page2" >
                     <a class="giaithuong">Giải thưởng</a>
                </li>
                <li class="page3">
               <a class="dangky">Đăng ký</a>
                </li>
            </ul>
        </div>
        <div id="tab1">
                <div class="bodyimg">
            <img src="/Library/Img/bg-body.png" style="width: 100%"/>
        </div>
        <div class="text">
             <img src="/Library/Img/text.png" style="width: 100%"/>
        </div>
            </div>
        <div id="tab2">
             <p class="head_thele">
                       THỂ LỆ CHƯƠNG TRÌNH
                </p>
                <ul>
                    <li>
                        1.	Tên chương trình: “Dự đoán Chelsea”
                    </li>
                    <li>
                        2.	Thời gian diễn ra chương trình: 
                        <p>
                              -  Từ ngày 1/9/2015 đến hết tháng 5/2016  
                        </p>
                  
                    </li>
                    <li>
                       
                        3.	Hình thức thực hiện:
                        <p>
                              -   Dự đoán các trận thi đấu của đội tuyển Chelsea mà ban tổ chức lựa chọn ở tất cả các giải mà câu lạc bộ Chelsea thi đấu.
                        </p>
                    
                    </li>
                    <li>
                           
                        4.	Đối tượng tham gia:
                        <p>
                           - Tất cả công dân Việt Nam có sử dụng thuê bao mạng Vietnamobile
                        </p>
                    </li>
                    <li>
                        5.	Nội dung chương trình:
                        <p>
                            -	Thời gian đăng kí tham gia chương trình bắt đầu từ ngày 1/9/2015
                        </p>
                        <p>
                            -	Người chơi có thể đăng kí tham gia chương trình bất cứ lúc nào trong thời gian chương trình diễn ra. 
                        </p>
                        <p>
                             -	Người chơi soạn tin: DK gửi 1003 để đăng kí tham gia chương trình (Miễn phí đăng kí tham gia)
                        </p>
                        <p>
                            -	Để dự đoán kết quả trận đấu soạn tin: X Y Z gửi 1003 trong đó:
                        </p>
                        <div id="nhantin">
                            <ul>
                                <li>
                                     X là số bàn thắng Chelsea ghi được
                                </li>
                                <li>
                                    Y là số bàn thắng của đối thủ
                                </li>
                                <li>
                                       Z là số người có cùng dự đoán
                                </li>
                            </ul>
                        </div>
                  
                    
                        <p>
                        -	Ban tổ chức sẽ lựa chọn ra mỗi tuần 1 trận đấu diễn ra vào cuối tuần. (Thứ 7 hoặc Chủ nhật) để người chơi tham gia dự đoán
                             </p>
                        <p>
                             -	Thời gian dự đoán của 1 trận đấu được tính từ lúc có tin nhắn thông báo trả về về thông tin trận đấu được lựa chọn để dự đoán (10h00 ngày thứ 2 hàng tuần) cho đến sau 60 phút kể từ thời điểm bắt đầu diễn ra trận đấu
                        </p>
                        <p>
                              -	Kết quả dự đoán sẽ được thông báo sau 1 tuần tại địa chỉ: <a href="http://vietnamobile.com.vn/layout2.php?pdid=154">http://vietnamobile.com.vn/layout2.php?pdid=154</a> 
                        </p>
                        <p>
                             -	Ban tổ chức không chịu trách nhiệm về sư dự đoán chậm trễ của người chơi. Ban tổ chức khuyến cáo người chơi nên dự đoán sớm để tránh trường hợp nghẽn mạng.
                        </p>

                    </li>
                    <li>
                            
                        6.	Cơ cấu giải thưởng:
                        <p>
                                   - Xem chi tiết trong mục giải thưởng
                        </p>
                
                    </li>
                    <li>
                        
                        7.	Cách xác định người thắng giải
                        <p>
                                 - Giải tuần
                            Khách hàng có câu trả lời đúng tỉ số trận đấu và dự đoán số người có câu trả lời đúng gần nhất. (Khách hàng trúng giải sẽ được thông báo trong vòng 3 ngày sau khi trận đấu kết thúc)
                            </p>
                        <p>
                            - Giải tháng
                            Khách hàng may mắn được lựa chọn ngẫu nhiên trong số các khách hàng tham gia dự đoán trong tháng. (Khách hàng trúng giải sẽ được thông báo vào đầu tháng kế tiếp)
                        </p>
                            
                           
                        <p>
                           -	Giải khuyến khích
                            Tất cả khách hàng tham dự có câu trả lời đúng về tỉ số trận đấu sẽ nhận đươc 5000 VNĐ vào tài khoản nội mạng được sử dụng trong 2 ngày (Số tiền sẽ được cộng ngay ngày hôm sau khi trận đấu kết thúc)
                    
                        </p>
                            
                        	
                    </li>
                    <li>
                        
                        8.	Thủ tục trao giải:
                        <p>
                           - Sau khi được thông báo trúng giải Người đoạt giải liên hệ trực tiếp với trung tâm CSKH Vietnamobile theo số 0922 123 123 (miễn phí) – 0922 789 789 (300đ/tin) – vietnamobile.com.vn
                        </p>
                        
                    </li>
                    <li>
                        9.	Các quy định khác
                        <p>
                        -	Bằng việc tham gia chương tình “dự đoán Chelsea” người chơi đã chấp thuận rằng: “Người chơi đã đọc, hiểu biết đầy đủ thể lệ chương trình. Hoàn toàn tự nguyện tham gia chương trình và tuân thủ mọi quy định trong thể lệ của chương  trình.
                                 </p>
                            <p>
                                  -	Ban tổ chức có quyền thay đổi nội dung thể lệ để đảm bảo tính minh bạch và công bằng của chương trình
                            </p>
                        <p>
                             -	Chương trình có thể bị tạm ngừng, trì hoãn vì những lý do bất khả kháng (Là những sự việc vượt quá khả năng kiểm soát của vietnamobile và không thể đoán trước được như: Chiến tranh, cháy nổ, hỏa hoạn, thiên tai, bị hacker phá hoại, lỗi đường truyền, trận đấu bị hủy thi đấu…) Trong trường hợp này giá trị giải thưởng sẽ không được cộng dồn cho giải tuần, giải tháng kế tiếp.
                        </p>
                        <p>
                             -	Ban tổ chức không chịu trách nhiệm về lỗi đường truyền, thất lạc tin nhắn vì bất kì lý do gì, những vấn đề tranh chấp, khiếu kiện do lỗi cá nhân người chơi và bên thứ 3 trong quá trình tham gia dự đoán.
                        </p>
                        <p>
                               -	Ban tổ chức sẽ không chịu trách nhiệm hình sự hoặc bất kì khiếu kiện nào do lỗi hệ thống, các sai sót sự cố kĩ thuật và lỗi nhập liệu… của nhân sự phụ trách chương trình này.
                        </p>
                        <p>
                             -	Ban tổ chức có quyền sử dụng thông tin và hình ảnh của người chơi vào các hoạt động quảng cáo
                        </p>
                        <p>
                           -	Chương trình “Dự đoán Chelsea’’ thuộc sở hữu của Vietnamobile, nghiêm cấm việc sử dụng, sao chép nội dung, hình ảnh của người chơi dưới mọi hình thức.  
                        </p>
                        <p>
                                 -	Vietnamobile cam kết thưc hiện đúng và hoàn toàn chịu trách nhiệm về chương trình này theo các quy định trên.
                        </p>

                    </li>
                </ul>
            
          
        </div>
        <div id="tab3">
            <div class="bodyimg">
            <img src="/Library/Img/bg-body.png" style="width: 100%"/>
        </div>
        <div class="text">
            <div id="imgtext" style="padding-top: 50px">
                  <img src="/Library/Img/site-giai-thuong.png" style="width: 100%"/>
            </div>
            <div id="text_giaithuong" style="padding-top: 30px">
                   <span>Giải tuần (1 giải/tuần) </span>
            <p>Khách hàng có câu trả lời đúng số bàn thắng của Chelsea và dự đoán số người có cùng câu trả lời đúng gần nhất</p>
            <p>Khách hàng đoạt giải tuần sẽ được thông báo trong vòng 3 ngày sau khi trận đấu kết thúc.</p>
            <span>Giải tháng (1 giải/tháng)</span>
            <p>Khách hàng may mắn được lựa chọn ngẫu nhiên trong số các khách hàng tham gia dự đoán trong tháng</p>
            <p>Khách hàng đoạt giải tháng sẽ được thông báo vào đầu tháng kế tiếp</p>
            <span>Giải khuyến khích</span>
            <p>
                Tất cả các khách hàng tham dự có câu trả lời đúng về số bàn tháng của Chelsea sẽ
                nhận được 5000đ vào tài khoản nội mạng sử dụng trong 2 ngày.
            </p>
            <p>Các khách hàng đoạt giải khuyến khích sẽ được nhận 5000đ vào tài khoản ngay ngày
                hôm sau khi trận đấu kết thúc.
            </p>
            </div>
         
        </div>
        </div>
        <div id="tab4">
            <div id="tab5" runat="server">
          <p>Quý khách đã đăng ký thành công dịch vụ</p>
            <p>Dự đoán Chelsea của Vietnammobile, soạn tin:</p> 
              
                
            <img src="/Library/Img/dk-thanh-cong-nhan-tu-3g.png" style="width: 100%"/>
            <p>Để tham gia chương trình và giành nhiều phần quà giá trị ngay hôm nay!</p>
            </div>
              <div id="tab6" runat="server">
                                <p>Chúc mừng quý khách đã đến với chương trình</p>
            <p>Dự đoán Chelsea của Vietnammobile, soạn tin:</p>                   
                                    
              
            <img src="/Library/Img/truy-cap-bang-wifi.png" style="width: 100%"/>
            <p>Để tham gia chương trình và giành nhiều phần quà giá trị ngay hôm nay!</p>
            </div>
        </div>
    </form>
    <div id="footer">
        </div>

</body>
</html>
