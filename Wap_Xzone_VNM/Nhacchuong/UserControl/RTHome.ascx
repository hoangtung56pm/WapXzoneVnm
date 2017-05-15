<%@ OutputCache Duration="333" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RTHome.ascx.cs" Inherits="WapXzone_VNM.Nhacchuong.UserControl.RTHome" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTaiNhieuNhat" runat="server" EnableViewState="False">TOP DOWNLOAD</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptHottest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <img src="../img/b-ring.gif" alt="thumb" class="thumblist">
                <div class="item-info"> 
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p><asp:Literal ID="ltrCasy" runat="server" EnableViewState="False"></asp:Literal></p>                    
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
</div>
<div class="clearfix"></div>
<div class="boxcontent">
	<asp:Literal ID="ltrAdvLevel2" runat="server" EnableViewState="False"></asp:Literal>
</div>
<div class="clearfix"></div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrMoiNhat" runat="server" EnableViewState="False">MỚI CẬP NHẬT</asp:Literal></div></div>
</div>
<div class="boxcontent">   
    <asp:Repeater ID="rptLastest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <img src="../img/b-ring.gif" alt="thumb" class="thumblist">
                <div class="item-info"> 
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p><asp:Literal ID="ltrCasy" runat="server" EnableViewState="False"></asp:Literal></p>                    
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>  
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging2" runat="server" EnableViewState="False" />
</div>
<div class="clearfix"></div>

