<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BigPromotion.aspx.cs" Inherits="WapXzone_VNM.BigPromotion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>.: Big Promotion :.</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;"/>
    <meta name="format-detection" content="telephone=no"/>
    <meta name="description" content=""/>
    <meta name="keywords" content=""/>
    <meta name="ROBOTS" content="index, follow"/>
    <link rel="stylesheet" href="/Content/wc2014/css/reset.css" type="text/css"/>
    <link rel="stylesheet" href="/Content/wc2014/css/index.css" type="text/css"/>

</head>
<body>
    <form id="form1" runat="server">
        
    
        <div id="wrapper">
		<!--header-->
		<img src="/Content/wc2014/img/banner-top.gif" id="banner-top"/>
		<!-- END:header -->
		
        <div class="title-head">
            <span class="txt-green">Tra MDT (vd: 84123456789)</span>
                <asp:TextBox runat="server" ID="txtSdt"></asp:TextBox>
                <asp:Button Text="Tra cứu" ID="btnTim" runat="server" OnClick="btnTim_Click"/>
                
        </div>
            
            <asp:Repeater runat="server" EnableViewState="False" ID="rptCode">
                
                <HeaderTemplate>
                    <table class="table100">
				<tr>
					<th>Stt</th>
					<th>Mã dự thưởng</th>
				</tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
					    <td><%# Eval("RowNumber") %></td>
					    <td><%# Eval("Code") %></td>
				    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>

            

		
		<div class="title-head"><span class="txt-green">Thể lệ chương trình</span></div>
		
		<div class="padding5 txt-white" id="the-le-ch-trinh">
			
			<h2 class="txt-white txt-uppercase bottom8"><b>1. Tên chương trình</b></h2>
			
			<p class="bottom8">
				Trải nghiệm dịch vụ Giá trị gia tăng – trúng xe SH sành điệu
			</p>
			
			<%--<h2 class="txt-white txt-uppercase bottom8"><b>B)Cơ cấu Giải thưởng</b></h2>
			
			<h2 class="txt-white txt-uppercase bottom8">Vòng Bảng:</h2>
			
			<table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>SL</th>
					<th width="40%">Giải thưởng</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải Nhất</td>
					<td>1</td>
					<td>Tiền mặt: 1.000.000 VNĐ</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải khuyến khích</td>
					<td>10</td>
					<td>Thẻ cào: 50.000 VNĐ</td>
				</tr>
			</table>
			
			<h2 class="txt-white txt-uppercase bottom8 top8">Toàn giải:</h2>
			
			<table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>SL</th>
					<th width="40%">Giải thưởng</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải Nhất</td>
					<td>1</td>
					<td>Điện thoại Samsung Galaxy Y – khoảng 3tr</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải khuyến khích</td>
					<td>20</td>
					<td>Thẻ cào mệnh giá 100.000 VNĐ</td>
				</tr>
			</table>
			
			<h2 class="txt-white txt-uppercase bottom8 top8"><b>Giải thưởng trao thành 5 đợt theo lượt trận</b></h2>
			
			<h2 class="txt-white txt-uppercase bottom8">3 lượt vòng bảng</h2>
			
			<h2 class="txt-white txt-uppercase bottom8">Lượt 1:</h2>
			
			<table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>SL</th>
					<th width="40%">Giải thưởng</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải Nhất</td>
					<td>1</td>
					<td>Tiền mặt 500.000 VND Quy đổi số điểm tích lũy có được 1 điểm = 500 VNĐ 
					</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải khuyến khích</td>
					<td>20</td>
					<td>Thẻ cào 20.000 VNĐ</td>
				</tr>
			</table>
			
			<h2 class="txt-white txt-uppercase bottom8 top8">Lượt 2:</h2>
			
			<table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>SL</th>
					<th width="40%">Giải thưởng</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải Nhất</td>
					<td>1</td>
					<td>Tiền mặt 500.000 VND Quy đổi số điểm tích lũy có được 1 điểm = 500 VNĐ 
					</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải khuyến khích</td>
					<td>20</td>
					<td>Thẻ cào 20.000 VNĐ</td>
				</tr>
			</table>
			
			<h2 class="txt-white txt-uppercase bottom8 top8">Lượt 3:</h2>
			
			<table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>SL</th>
					<th width="40%">Giải thưởng</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải Nhất</td>
					<td>1</td>
					<td>Tiền mặt 500.000 VND Quy đổi số điểm tích lũy có được 1 điểm = 500 VNĐ 
					</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải khuyến khích</td>
					<td>20</td>
					<td>Thẻ cào 20.000 VNĐ</td>
				</tr>
			</table>
			
			<h2 class="txt-white txt-uppercase bottom8 top8">Vòng tứ kết</h2>
			
			<table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>SL</th>
					<th width="40%">Giải thưởng</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải Nhất</td>
					<td>1</td>
					<td>Tiền mặt: 1.000.000 VNĐ</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải khuyến khích</td>
					<td>20</td>
					<td>Thẻ cào 50.000 VNĐ</td>
				</tr>
			</table>
			
			<h2 class="txt-white txt-uppercase bottom8 top8">Toàn giải</h2>
			
			<table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>SL</th>
					<th width="40%">Giải thưởng</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải Nhất</td>
					<td>1</td>
					<td>Du lịch Thái Lan 16.000.000 VNĐ</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải khuyến khích</td>
					<td>20</td>
					<td>Thẻ cào 100.000 VNĐ</td>
				</tr>
			</table>--%>
			
			<h2 class="txt-white txt-uppercase bottom8 top8"><b>2. Mô tả chương trình</b></h2>
			
			<p>
				Nhằm mục tiêu mang các dịch vụ giá trị gia tăng đến gần hơn với khách hàng, Vietnamobile triển khai chương trình khuyến mại “Trải nghiệm dịch vụ gia tăng – trúng xe SH sành điệu” cho 3 dịch vụ Game portal, Shot and Print, nhạc chuông
			</p>
			
			<h2 class="txt-white txt-uppercase bottom8 top8"><b>3. Thời gian chương trình:</b></h2>
			
			<p>
			    Từ 0h00 ngày 10/08/2014 đến 23h59:59 ngày 30/12/2014.
			</p>
			
			<h2 class="txt-white txt-uppercase bottom8 top8"><b>4. Hình thức khuyến mại</b></h2>
			
			<p>
				Bốc thăm trúng thưởng
			</p>
			
			<h2 class="txt-white txt-uppercase bottom8 top8"><b>5. Đối tượng tham gia</b></h2>
			
			<p>
			    Thuê bao (trả trước và trả sau) đang hoạt động hai chiều trên mạng Vietnamobile
			</p>
			
			<h2 class="txt-white txt-uppercase bottom8 top8"><b>6. Cơ cấu giải thưởng:</b></h2>
			
            <table class="table100">
				<tr>
					<th>Stt</th>
					<th>Cơ cấu giải thưởng</th>
					<th>Giá trị</th>
                    <th>SL</th>
					<th width="40%">Thành tiền (VNĐ)</th>
				</tr>
				<tr>
					<td>1</td>
					<td>Giải tháng Ipad mini Retina 16GB </td>
					<td>14.000.000</td>
					<td>5</td>
                    <td>70.000.000</td>
				</tr>
				<tr>
					<td>2</td>
					<td>Giải chung cuộc Xe SH 150cc </td>
					<td>80.000.000</td>
					<td>1</td>
                    <td>80.000.000</td>
				</tr>
			</table>

			<h2 class="txt-white txt-uppercase bottom8 top8"><b>7. Nội dung chương trình:</b></h2>
            <p>
                Khách hàng đăng ký gói dịch vụ của chương trình (bao gồm game portal, shot and print và nhạc chuông) sẽ được trải nghiệm miễn phí 5 ngày và có 2 mã dự thưởng để có cơ hội trúng một xe SH sành điệu cùng nhiều ipad mini hấp đẫn khác . Hết thời gian miễn phí trải nghiệm, dịch vụ sẽ tự động hủy dịch vụ sau 15 ngày. 
                <br />
                Cách dịch vụ trong chương trình khuyến mại bao gồm:<br/>
                - Dịch vụ Game portal<br/>
                - Dịch vụ Shot and Print<br/>
                - Dịch vụ nhạc chuông <br/>
                Để tham gia chương trình, khách hàng chỉ cần đăng ký qua một cú pháp chung  

            </p>
            
            <table class="table100">
                
				<tr>
					<th>Tên dịch vụ</th>
					<th>Cú pháp đăng ký</th>
					<th>Cú pháp hủy</th>
				</tr>

				<tr>
					<td>Gói dịch vụ (Game portal, Shot and Print, Nhac chuong)</td>
					<td>GOI gửi 949</td>
					<td>HUY GOI gửi 949</td>
				</tr>
				
			</table>
            
            <p>
                
                Ngoài ra khách hàng còn có thể đăng ký trực tiếp trên wapsite hoặc các kênh truyền thông của Vietnamobile <br/>
                Sau khi đăng ký dịch vụ thành công, khách hàng sẽ nhận được MT thông báo đăng ký thành công <br/><br/>
                
                “Chuc mung quy khach da dang ky CTKM trai nghiem dich vu GTGT, trung thuong SH sanh dieu va nhieu ipad mini. Qkhach duoc su dung mien phi 5 ngay goi dich vu ( bao gom game portal, shot and print, nhac chuong) va nhan 2 MDT: xxxxxx, xxxxx de tham gia quay thuonng vao cuoi chuong trinh. Sau khi het khuyen mai 15 ngay, he thong se tu dong huy toan bo dich vu cho khach hang. De huy dich vu soan HUY GOI gui 949 ”
                <br/>
                <br/>
                
                Mã dự thưởng là một dãy số gồm 8 chữ số do hệ thống tự động sinh ra
                Khách hàng có thể tra cứu MDT của mình bằng cách truy cập wapsite: <a href="http://wap.vietnamobile.com.vn/bigpromotion.aspx">http://wap.vietnamobile.com.vn/bigpromotion.aspx</a> nhập số điện thoại.
                <br/>
                
                Chú ý:<br/>
                - Với gói dịch vụ khách hàng đăng ký sẽ nhận được 2 mã dự thưởng.<br/>
                - Khách hàng gia hạn 1 dịch vụ sau 1 tuần sẽ nhận được thêm 1 mã dự thưởng và được trả vè qua SMS với nội dung như sau :
                <br/><br/>
                
               <i> “Ban da gia han thanh cong goi dich vu Vietnamobile. Ban duoc them x MDT la: xxxxx, xxxxx , xxxxx”<br/>
                X: là số mã dự thưởng tương ứng với số dịch vụ gia hạn thành công. Trường hợp hệ thống gia hạn được cả 3 dịch vụ sẽ nhận được 3 MDT hàng tuần. Hệ thống sẽ trả về MT thông báo MDT vào chủ nhật hàng tuần. 
                   </i>

                <br/>
                <br/>
                
                - Mã số dự thưởng chỉ có giá trị khi thuê bao vẫn đang active dịch vụ, trường hợp thuê bao đã hủy dịch vụ thì mã dự thưởng của thuê bao đó sẽ không đưa vào dữ liệu dùng để quay thưởng
                <br/>
                - Trường hợp khách hàng hủy dịch vụ và đăng ký lại sẽ không được tính mã dự thưởng mới 
                Khách hàng hủy dịch vụ bằng cách soạn tin theo cú pháp HUY GOI gửi 949. Hệ thống sẽ tự động hủy cùng lúc cả 3 dịch vụ khách hàng đã đăng ký và trả về MT với nội dung như sau : 
                <br/><br/>
                <i>
                    Quy khach da huy thanh cong goi dich vu ( bao gom game portal, shot and print, nhac chuong). Ma du thuong cua Qkhach se khong duoc tham gia quay thuong. De dang ky lai dich vu soan GOI gui 949
                </i>


            </p>
            
            <h2 class="txt-white txt-uppercase bottom8 top8"><b>8. Kịch bản tính cước:</b></h2>
            <p>
                - Hệ thống tiền hành charge tiền vào lúc 0h00 với danh sách khách hàng đăng ký tham gia chương trình.<br/>
                - Kể từ thời điểm tạm dừng dịch vụ, hệ thống sẽ retry lại việc charge tiền hàng tuần (cách 7 ngày sau thời điểm bị khóa) nếu charge được tiền sẽ tự động trả nội dung câu hỏi, điểm thưởng, mã dự thưởng cho khách hàng.  
            </p>
            
            <h2 class="txt-white txt-uppercase bottom8 top8"><b>9. Cách thức xác định thuê bao trúng thưởng :</b></h2>
            <p>
                
                - Việc quay thưởng được thực hiện theo hình thức quay số phần mềm điện tử tại: công ty cổ phần truyền thông VMG, tầng 7 tòa nhà Viễn Đông 36 Hoàng Cầu và được chứng kiến bởi đại diện của Công ty Cổ phần Truyền thông VMG
                <br/>
                - Việc quay thưởng sẽ được diễn ra sau khi kết thúc thời gian dự thưởng 10 ngày. Dữ liệu bao gồm tập các mã dự thưởng của các thuê bao đang active dịch vụ đến thời điểm quay thưởng. Hệ thống quay thưởng sẽ xác định ngẫu nhiên 02 mã số trúng thưởng tương ướng với 01 mã số trúng thưởng chính thức và 01 mã số trúng thưởng dự phòng thông qua quay số bằng phần mềm điện tử.


            </p>

		</div>
	
	</div>


    </form>
</body>
</html>
