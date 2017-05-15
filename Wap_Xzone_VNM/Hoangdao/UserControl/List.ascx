
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Hoangdao.UserControl.List" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkHomeChannel" runat="server" EnableViewState="False">TU VI</asp:HyperLink> » <asp:Literal ID="ltrTieude" runat="server" EnableViewState="False"></asp:Literal></div></div>	
</div>
<div class="clearfix"></div>
<div class="boxcontent">
    <div class="item">
        <img src="../img/hd_thaicuc.png" class="thumblist">
        <div class="item-info"> 
            <asp:HyperLink ID="lnkNgay" runat="server" EnableViewState="False" Enabled="false"></asp:HyperLink>
            <p><asp:Literal ID="ltrGiaNgay" runat="server" EnableViewState="False"></asp:Literal></p>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../img/hd_thaicuc.png" class="thumblist">
        <div class="item-info"> 
            <asp:HyperLink ID="lnkTuan" runat="server" EnableViewState="False" Enabled="false"></asp:HyperLink>
            <p><asp:Literal ID="ltrGiaTuan" runat="server" EnableViewState="False"></asp:Literal></p>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../img/hd_thaicuc.png" class="thumblist">
        <div class="item-info"> 
            <asp:HyperLink ID="lnkThang" runat="server" EnableViewState="False" Enabled="false"></asp:HyperLink>
            <p><asp:Literal ID="ltrGiaThang" runat="server" EnableViewState="False"></asp:Literal></p>
        </div>
    </div> 
    <div class="clearfix"></div>
</div>
<div class="clearfix"></div>