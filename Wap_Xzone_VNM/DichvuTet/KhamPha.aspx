<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KhamPha.aspx.cs" Inherits="WapXzone_VNM.DichvuTet.KhamPha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="/DichvuTet/Content/KhamPha/css/import.css"
        media="all" />
    <title>Dich vu TET - Kham Pha </title>
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
                        <div style="float: left; width: 100%; background-color: #f5f5f5; padding: 3px 0 3px 0;
                            border-bottom: 1px #e7e7e7 solid; border-top: 1px #fff solid; margin: 0 0 10px 0;">
                            <p style="text-align: center !important; font-size: 12px;">
                                Những kĩ năng ân ái tuyệt đỉnh, các bí kíp phòng the, nghệ thuật vuốt ve và quyến
                                rũ đối phương, được chia sẻ, gỡ rối những tình huống khó với chuyên gia tâm lý Đinh
                                Đoàn...tất tần tật nghệ thuật ứng xử và văn hóa phòng the có ở đây</p>
                        </div>

                        <asp:Panel ID="pnlThongBao" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                Đăng kí dịch vụ bạn soạn tin nhắn GT gửi 1119 hoặc 
                                <a href="/dang-ky-kham-pha.aspx" style="font-size: 12px; font-weight: bold; color: #000; text-decoration: underline;">click vào đây</a>
                                để tham gia
                            </h6>
                         </asp:Panel>

                        <asp:Panel ID="pnlThongBaoSoanSms" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                Đăng kí dịch vụ bạn soạn tin nhắn GT gửi 1119 hoặc 
                                <a href="sms:1119?body=GT" style="font-size: 12px; font-weight: bold; color: #000; text-decoration: underline;">click vào đây</a>
                                để tham gia
                            </h6>
                         </asp:Panel>

                        <asp:Panel ID="pnlThongBaoWeb" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                Đăng kí dịch vụ bạn soạn tin nhắn GT gửi 1119 hoặc 
                                <a href="#" style="font-size: 12px; font-weight: bold; color: #000; text-decoration: underline;">click vào đây</a>
                                để tham gia
                            </h6>
                         </asp:Panel>

                        <asp:Panel ID="pnlSms" runat="server" EnableViewState="false" Visible="false">
                            <p style="text-align: center; padding: 0 0 10px 0; font-size:12px;">
                            <b style="font-weight:bold;">Xin vui lòng sử dụng 3G hoặc soạn tin nhắn GT gửi 1119</b>
                            </p>
                        </asp:Panel>

                        <asp:Panel ID="pnlThanhCong" runat="server" EnableViewState="false" Visible="false">
                        <p style="text-align: center; padding: 0 0 10px 0; font-size:12px;">
                            <b style="font-weight:bold;">
                                <asp:Literal EnableViewState="false" ID="litThanhCong" runat="server"></asp:Literal>
                            </b>
                        </p>
                    </asp:Panel>

                        <div class="ruler"></div>
                        <div class="ruler"></div>

                        <p>
                            <i style="font-size: 9px">Đây là gói dịch vụ gửi tin mỗi với mức phí 5000vnđ/1 ngày.
                                Trong trường hợp khách hàng không muốn tiếp tục tham gia chương trình và không muốn
                                nhận được câu hỏi từ hệ thống, khách hàng có thể nhắn tin (miễn phí) theo cú pháp
                                HUY GT gửi đến 1119</i></p>
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
                <p>
                    Hotline: 19001255
                </p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
