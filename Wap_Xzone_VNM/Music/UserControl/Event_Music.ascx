<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event_Music.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.Event_Music" %>
<%--<%@ Register Src="../../Wap/UserControl/Paging.ascx" TagName="Paging" TagPrefix="uc1" %>--%>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTieude" runat="server" EnableViewState="False">Nhạc chuông Giáng sinh</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptHottest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <img src="../img/m-list-icon.png" alt="thumb" class="thumblist">
                <div class="item-info"> 
                    <p><asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink> <img src="../img/hot_icon.gif"></p>
                    <p><asp:Literal ID="ltrCasy" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink></p>
                </div>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate>        
    </asp:Repeater>    
    <div class="clearfix"></div>
    <%--<uc1:Paging ID="Paging1" runat="server" />--%>
</div>
<div class="clearfix"></div>
<div class="listlink" style="font-style:italic;">
    <asp:HyperLink ID="lnkXemthem" runat="server">Xem thêm »</asp:HyperLink>
    <%--<asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>   --%> 
</div>
<div class="clearfix"></div>