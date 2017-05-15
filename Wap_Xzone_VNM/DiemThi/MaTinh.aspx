<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaTinh.aspx.cs" Inherits="WapXzone_VNM.DiemThi.MaTinh" %>
<%@ Register src="../Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="../Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>
<%@ Register src="../Wap/UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>
<%@ Register src="UserControl/DanhMucDichVu.ascx" tagname="DanhMucDichVu" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Diem thi :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:Header ID="Header1" runat="server" />    
    <%--Content here--%>    
    <div class="rbroundbox">
        <div class="rbtop"><div><asp:Literal ID="ltrDichvu" runat="server"></asp:Literal></div></div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">DN</div>
        <div class="ts-col-title">Đà Nẵng</div>
        <div class="ts-col-code bold pink">HY</div>
        <div class="ts-col-title">Hưng Yên</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">QN</div>
        <div class="ts-col-title">Quảng Nam</div>
        <div class="ts-col-code bold pink">TB</div>
        <div class="ts-col-title">Thái Bình</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">QNG</div>
        <div class="ts-col-title">Quảng Ngãi</div>
        <div class="ts-col-code bold pink">HNA</div>
        <div class="ts-col-title">Hà Nam</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">BDI</div>
        <div class="ts-col-title">Bình Định</div>
        <div class="ts-col-code bold pink">ND</div>
        <div class="ts-col-title">Nam Định</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">PY</div>
        <div class="ts-col-title">Phú Yên</div>
        <div class="ts-col-code bold pink">NB</div>
        <div class="ts-col-title">Ninh Bình</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">KH</div>
        <div class="ts-col-title">Khánh Hòa</div>
        <div class="ts-col-code bold pink">NT</div>
        <div class="ts-col-title">Ninh Thuận</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">KT</div>
        <div class="ts-col-title">Kon Tum</div>
        <div class="ts-col-code bold pink">BT</div>
        <div class="ts-col-title">Bình Thuận</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">GL</div>
        <div class="ts-col-title">Gia Lai</div>
        <div class="ts-col-code bold pink">BP</div>
        <div class="ts-col-title">Bình Phước</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">DL</div>
        <div class="ts-col-title">Đắc Lắc</div>
        <div class="ts-col-code bold pink">TNI</div>
        <div class="ts-col-title">Tây Ninh</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">DNO</div>
        <div class="ts-col-title">Đắc Nông</div>
        <div class="ts-col-code bold pink">BD</div>
        <div class="ts-col-title">Bình Dương</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">LD</div>
        <div class="ts-col-title">Lâm Đồng</div>
        <div class="ts-col-code bold pink">DNA</div>
        <div class="ts-col-title">Đồng Nai</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">HGA</div>
        <div class="ts-col-title">Hà Giang</div>
        <div class="ts-col-code bold pink">BR</div>
        <div class="ts-col-title">Bà Rịa</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">CB</div>
        <div class="ts-col-title">Cao Bằng</div>
        <div class="ts-col-code bold pink">HCM</div>
        <div class="ts-col-title">Tp Hcm</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">BK</div>
        <div class="ts-col-title">Bắc Kạn</div>
        <div class="ts-col-code bold pink">LA</div>
        <div class="ts-col-title">Long An</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">TQ</div>
        <div class="ts-col-title">Tuyên Quang</div>
        <div class="ts-col-code bold pink">TG</div>
        <div class="ts-col-title">Tiền Giang</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">LC</div>
        <div class="ts-col-title">Lào Cai</div>
        <div class="ts-col-code bold pink">BTR</div>
        <div class="ts-col-title">Bến Tre</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">YB</div>
        <div class="ts-col-title">Yên Bái</div>
        <div class="ts-col-code bold pink">TV</div>
        <div class="ts-col-title">Trà Vinh</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">TN</div>
        <div class="ts-col-title">Thái Nguyên</div>
        <div class="ts-col-code bold pink">VL</div>
        <div class="ts-col-title">Vĩnh Long</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">LS</div>
        <div class="ts-col-title">Lạng Sơn</div>
        <div class="ts-col-code bold pink">DT</div>
        <div class="ts-col-title">Đồng Tháp</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">QNI</div>
        <div class="ts-col-title">Quảng Ninh</div>
        <div class="ts-col-code bold pink">AG</div>
        <div class="ts-col-title">An Giang</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">BG</div>
        <div class="ts-col-title">Bắc Giang</div>
        <div class="ts-col-code bold pink">KG</div>
        <div class="ts-col-title">Kiên Giang</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">PT</div>
        <div class="ts-col-title">Phú Thọ</div>
        <div class="ts-col-code bold pink">CT</div>
        <div class="ts-col-title">Cần Thơ</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">TBA</div>
        <div class="ts-col-title">Tây Bắc</div>
        <div class="ts-col-code bold pink">HG</div>
        <div class="ts-col-title">Hậu Giang</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">DB</div>
        <div class="ts-col-title">Điện Biên</div>
        <div class="ts-col-code bold pink">ST</div>
        <div class="ts-col-title">Sóc Trăng</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">LCH</div>
        <div class="ts-col-title">Lai Châu</div>
        <div class="ts-col-code bold pink">BL</div>
        <div class="ts-col-title">Bạc Liêu</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">SL</div>
        <div class="ts-col-title">Sơn La</div>
        <div class="ts-col-code bold pink">CM</div>
        <div class="ts-col-title">Cà Mau</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">HB</div>
        <div class="ts-col-title">Hòa Bình</div>
        <div class="ts-col-code bold pink">TH</div>
        <div class="ts-col-title">Thanh Hóa</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">VP</div>
        <div class="ts-col-title">Vĩnh Phúc</div>
        <div class="ts-col-code bold pink">NA</div>
        <div class="ts-col-title">Nghệ An</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">BN</div>
        <div class="ts-col-title">Bắc Ninh</div>
        <div class="ts-col-code bold pink">HTI</div>
        <div class="ts-col-title">Hà Tĩnh</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">HT</div>
        <div class="ts-col-title">Hà Tây</div>
        <div class="ts-col-code bold pink">QB</div>
        <div class="ts-col-title">Quảng Bình</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">HD</div>
        <div class="ts-col-title">Hải Dương</div>
        <div class="ts-col-code bold pink">QT</div>
        <div class="ts-col-title">Quảng Trị</div>
    </div>
    <div class="ts-4cols-0">
	    <div class="ts-col-code bold pink">HP</div>
        <div class="ts-col-title">Hải Phòng</div>
        <div class="ts-col-code bold pink">H</div>
        <div class="ts-col-title">Huế</div>
    </div>
    <div class="ts-4cols-1">
	    <div class="ts-col-code bold pink">&nbsp;</div>
        <div class="ts-col-title">&nbsp;</div>
        <div class="ts-col-code bold pink">HN</div>
        <div class="ts-col-title">Hà Nội</div>
    </div>
    <div class="clearfix"></div>
    <uc2:DanhMucDichVu ID="DanhMucDichVu1" runat="server" />
    <%--end Content here--%>    
    <uc1:Links ID="Links1" runat="server" />    
    <uc3:Footer ID="Footer4" runat="server" />
    </form>
</body>
</html>
