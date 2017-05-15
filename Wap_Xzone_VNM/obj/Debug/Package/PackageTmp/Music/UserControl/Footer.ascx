<%@ OutputCache Duration="3600" VaryByParam="lang;w;display" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.Footer" %>
<div class="clearfix"></div>
<div class="mainmenu"> 
    <asp:HyperLink ID="lnkTrangChu" runat="server">Trang chủ</asp:HyperLink>
     » <asp:HyperLink ID="lnkAmNhac" runat="server">Âm nhạc</asp:HyperLink><asp:Literal ID="ltrLienKet" runat="server"></asp:Literal>
</div>
<div class="clearfix"></div>
<div class="footer">
	<div style="padding-top: 15px;  background-color:#F79720;">

        <asp:HyperLink ID="lnkDauTrang" runat="server" EnableViewState="False">Đầu trang</asp:HyperLink> | 
        <asp:HyperLink ID="lnkNgonNgu" runat="server" EnableViewState="False">Khong dau</asp:HyperLink> | 
        <asp:Literal ID="ltrHoTro" runat="server" EnableViewState="False">Hỗ trợ: 19001255</asp:Literal> 

	</div>
    <div class="bold"><asp:Literal ID="ltrBanquyen" runat="server" EnableViewState="False">Bản quyền Vietnamobile</asp:Literal></div>    
</div>