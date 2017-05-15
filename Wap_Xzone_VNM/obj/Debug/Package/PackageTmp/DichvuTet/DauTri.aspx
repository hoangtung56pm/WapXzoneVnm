<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DauTri.aspx.cs" Inherits="WapXzone_VNM.DichvuTet.DauTri" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <link rel="stylesheet" type="text/css" href="/DichvuTet/Content/DauTri/css/import.css" media="all"/>
    <%--<script type="text/javascript" src="/Vote/js/jquery-1.8.3.min.js"></script>--%>
    <title>Dich vu TET - Dau Tri </title>

</head>

<body>
    <form id="form1" runat="server">
    
    <div id="container">
	<div id="header">
	</div>
	<div id="mainBody">
		<div id="content">
			<div id="content-in">
				<div class="sub-content">
					<div style="float: left; width: 100%; background-color: #f5f5f5; padding: 3px 0 3px 0; border-bottom: 1px #e7e7e7 solid; border-top: 1px #fff solid; margin: 0 0 10px 0;">
						<p style="text-align: center !important;">
                            <a href="https://docs.google.com/a/vmgmedia.vn/document/d/1wpqvbG-l1sAfLHvszHIGLyODOVrvdqBSC3Arvi3qw88/pub">Danh sách trúng thưởng </a>
                            <img alt="" src="/DichvuTet/Content/DauTri/images/new.gif" />
                        </p>
					</div>

                    <asp:Panel ID="pnlThongBao" runat="server" EnableViewState="false" Visible="false">
                        <p style="text-align: center; padding: 0 0 10px 0; font-size:12px;">
                        Để tham gia chương trình và trúng 
                        <b style="font-weight:bold;">iPhone 5C</b>, 
                        bạn soạn tin nhắn DT gửi 1119 hoặc 
                        <a href="/dang-ky-dau-tri.aspx" style="font-size:12px;">click vào đây</a> 
                        để đăng ký tham gia
                        </p>
                    </asp:Panel>

                    <asp:Panel ID="pnlThongBaoSoanSms" runat="server" EnableViewState="false" Visible="false">
                        <p style="text-align: center; padding: 0 0 10px 0; font-size:12px;">
                        Để tham gia chương trình và trúng 
                        <b style="font-weight:bold;">iPhone 5C</b>, 
                        bạn soạn tin nhắn DT gửi 1119 hoặc 
                        <a href="sms:1119?body=DT" style="font-size:12px;">click vào đây</a> 
                        để đăng ký tham gia
                        </p>
                    </asp:Panel>

                    <asp:Panel ID="pnlThongBaoWeb" runat="server" EnableViewState="false" Visible="false">
                        <p style="text-align: center; padding: 0 0 10px 0; font-size:12px;">
                        Để tham gia chương trình và trúng 
                        <b style="font-weight:bold;">iPhone 5C</b>, 
                        bạn soạn tin nhắn DT gửi 1119 hoặc 
                        <a href="#" style="font-size:12px;">click vào đây</a> 
                        để đăng ký tham gia
                        </p>
                    </asp:Panel>

                    <asp:Panel ID="pnlSms" runat="server" EnableViewState="false" Visible="false">
                         <p style="text-align: center; padding: 0 0 10px 0; font-size:12px;">
                            <b style="font-weight:bold;">Xin vui lòng sử dụng 3G hoặc soạn tin nhắn DT gửi 1119</b>
                         </p>
                    </asp:Panel>

                    <asp:Panel ID="pnlThanhCong" runat="server" EnableViewState="false" Visible="false">
                        <p style="text-align: center; padding: 0 0 10px 0; font-size:12px;">
                            <b style="font-weight:bold;">
                                <asp:Literal EnableViewState="false" ID="litThanhCong" runat="server"></asp:Literal>
                            </b>
                        </p>
                    </asp:Panel>

					<h5 style="font-size:12px;">Hướng dẫn sử dụng và thể lệ chương trình</h5>
					<div class="ruler"></div>
					<h6 style="color:#000">1. Giới thiệu</h6>
					<p>- Chương trình: Đấu trí Tết 2014 là chương trình 
					thử tài hiểu biết về các vấn đề trong cuộc sống thông qua các 
					câu hỏi trắc nghiệm lựa chọn đáp án. <br />
					- Thời gian khuyến mãi: 13/01/2014 đến 23/02/2014
					<br />
					- Hình thức trúng thưởng: Trả lời câu hỏi tích lũy điểm số
					<br />
					- Giải thưởng của chương trình: <b>IPhone5C trị giá 14.000.000vnd</b> 
					và nhiều thẻ cào mệnh giá <b>500.000 VND, 200.000 VND</b>
					</p>
					<div class="ruler">
					</div>
					<hr />
					<div class="ruler">
					</div>
					<h6 style="color:#000">2. Quy định gói “Đấu trí Tết 2014” và cước phí</h6>
					<p>- Đăng ký thành viên: DT gửi 1119 (Miễn phí) <br />
					- Trả lời câu hỏi: A hoặc B gửi 1119 
					<br />
					- Tra cứu điểm số: DIEM gửi 1119</p>
					<div class="ruler">
					</div>
					<hr />
					<div class="ruler">
					</div>
					<h6 style="color:#000;">3. Cơ cấu giải thưởng</h6>
					<p>- Giải <b>Iphone 5C</b> dành cho người có điểm số cao nhất 
					trong 6 tuần (từ 13/1 đến 23/2) <br />
					- Giải thẻ cào 500.000VND dành cho người có điểm số cao 
					nhất mỗi tuần. Tuần được tính từ thứ 2 đến hết chủ nhật
					<br />
					- Giải thẻ cào 200.000VND dành cho 4 người có điểm số 
					cao nhất và nhì trong ngày 1 và 2/2 </p>
					<div class="ruler">
					</div>
					<div class="ruler">
					</div>
					<p><i>(Lưu ý: Mỗi số điện thoại tham gia chỉ được công nhận là trúng giải tuần 1 lần/kỳ. Khách hàng tham gia chương trình sẽ nhận được câu hỏi hàng ngày với cước phí 5000đ/ngày)</i></p>
					<div class="ruler">
					</div>
					<div class="ruler">
					</div>
				</div>
			</div>
		</div>
	</div>
	<div id="footer">
		<div id="footer_center">
			<p>Hotline: 19001255 </p>
		</div>
	</div>
</div>

    </form>
</body>
</html>
