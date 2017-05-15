<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GieoQue.aspx.cs" Inherits="WapXzone_VNM.DichvuTet.GieoQue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="/DichvuTet/Content/GieoQue/css/import.css"
        media="all" />
    <title>Dich vu TET - Gieo Que </title>
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
                                Bạn muốn biết năm nay hên hay xui? Có tiền hay có tình? Bạn băn khoăn về ngày mai?
                                Tương lai, công danh, sự nghiệp, tình duyên của mình như thế nào? Cùng gieo quẻ
                                để biết câu trả lời nhé!</p>
                        </div>

                        <asp:Panel ID="pnlThongBao" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                Để tham gia chương trình bạn soạn tin nhắn TUVI gửi 1119 hoặc 
                                <a href="/dang-ky-gieo-que.aspx" style="color: #000; font-weight: bold; font-size: 12px; text-decoration: underline;">
                                    click vào đây
                                </a> 
                                để đăng ký tham gia
                            </h6>
                        </asp:Panel>

                        <asp:Panel ID="pnlThongBaoSoanSms" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                Để tham gia chương trình bạn soạn tin nhắn TUVI gửi 1119 hoặc 
                                <a href="sms:1119?body=TUVI" style="color: #000; font-weight: bold; font-size: 12px; text-decoration: underline;">
                                    click vào đây
                                </a> 
                                để đăng ký tham gia
                            </h6>
                        </asp:Panel>

                        <asp:Panel ID="pnlThongBaoWeb" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                Để tham gia chương trình bạn soạn tin nhắn TUVI gửi 1119 hoặc 
                                <a href="#" style="color: #000; font-weight: bold; font-size: 12px; text-decoration: underline;">
                                    click vào đây
                                </a> 
                                để đăng ký tham gia
                            </h6>
                        </asp:Panel>

                        <asp:Panel ID="pnlSms" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                Xin vui lòng sử dụng 3G hoặc soạn tin nhắn TUVI gửi 1119
                            </h6>
                        </asp:Panel>

                         <asp:Panel ID="pnlThanhCong" runat="server" EnableViewState="false" Visible="false">
                            <h6 style="text-decoration: none;">
                                <asp:Literal EnableViewState="false" ID="litThanhCong" runat="server"></asp:Literal>
                            </h6>
                        </asp:Panel>

                        <div class="ruler"></div>
                        <div class="ruler"></div>

                        <p>
                            <i style="font-size: 9px">Đây là gói dịch vụ gửi tin mỗi với mức phí 5000vnđ/1 ngày.
                                Trong trường hợp khách hàng không muốn tiếp tục tham gia chương trình và không muốn
                                nhận được câu hỏi từ hệ thống, khách hàng có thể nhắn tin (miễn phí) theo cú pháp
                                HUY TUVI gửi đến 1119</i></p>
                        <div class="ruler"></div>
                        <div class="ruler"></div>
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
