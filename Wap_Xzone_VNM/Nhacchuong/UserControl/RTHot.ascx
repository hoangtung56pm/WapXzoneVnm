<%@ OutputCache Duration="333" VaryByParam="lang;w" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RTHot.ascx.cs" Inherits="WapXzone_VNM.Nhacchuong.UserControl.RTHot" %>
<div class="div1">
	<div><asp:HyperLink ID="lnkXemThem" runat="server" EnableViewState="False">Nhạc HOT</asp:HyperLink></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptHottest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <img src="../img/b-ring.gif" alt="thumb" class="thumblist">
                <div class="item-info"> 
                    <p><asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink> <img src="../img/hot_icon.gif"></p>
                    <p><asp:Literal ID="ltrCasy" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink></p>
                </div>
                <div class="clearfix"></div>
            </div>            
        </ItemTemplate>        
    </asp:Repeater>    
</div>
<div class="clearfix"></div>
<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>
<div class="clearfix"></div>