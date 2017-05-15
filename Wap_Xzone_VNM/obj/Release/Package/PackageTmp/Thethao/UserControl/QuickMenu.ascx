<%@ OutputCache Duration="3600" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickMenu.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControl.QuickMenu" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrDuLieuBongDa" runat="server" EnableViewState="False">DỮ LIỆU BÓNG ĐÁ</asp:Literal></div></div>
</div>
<div class="boxcontent">
	<div class="listlink">
    	♥ <asp:HyperLink ID="lnkThongKeDacBiet" runat="server" EnableViewState="False">Thống kê đặc biệt</asp:HyperLink> <img src="../img/hot_icon.gif">
    </div>
	<div class="listlink">
    	♥ <asp:HyperLink ID="lnkKQNgay" runat="server" EnableViewState="False">Kết quả hôm nay</asp:HyperLink>
    </div>
    <div class="listlink">
    	♥ <asp:HyperLink ID="lnkLTDNgay" runat="server" EnableViewState="False">Lịch thi đấu hôm nay</asp:HyperLink>
    </div>
    <div class="listlink">
    	♥ <asp:HyperLink ID="lnkLTD" runat="server" EnableViewState="False">Lịch thi đấu</asp:HyperLink>
    </div>
    <div class="listlink">
    	♥ <asp:HyperLink ID="lnkKQTD" runat="server" EnableViewState="False">Kết quả thi đấu</asp:HyperLink>
    </div>
    <div class="listlink">
    	♥ <asp:HyperLink ID="lnkBXH" runat="server" EnableViewState="False">Bảng xếp hạng</asp:HyperLink>
    </div>
</div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrGiaiTriBongDa" runat="server" EnableViewState="False">GIẢI TRÍ BÓNG ĐÁ</asp:Literal></div></div>
</div>
<div class="boxcontent">
	<div class="listlink">
    	<img alt="+" src="../img/b-ring.gif"> <asp:HyperLink ID="lnkNhac" runat="server" EnableViewState="False">Nhạc chuông</asp:HyperLink>
    </div>
   	<div class="listlink">
    	<img alt="+" src="../img/b-fun1.gif"> <asp:HyperLink ID="lnkVideo" runat="server" EnableViewState="False">Video clip</asp:HyperLink>
    </div>
    <div class="listlink">
    	<img alt="+" src="../img/b-ball.gif"> <asp:HyperLink ID="lnkAnh" runat="server" EnableViewState="False">Hình đẹp thể thao</asp:HyperLink>
    </div>
</div>