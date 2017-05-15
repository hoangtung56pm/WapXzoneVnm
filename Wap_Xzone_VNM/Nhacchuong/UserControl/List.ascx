<%@ OutputCache Duration="333" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Nhacchuong.UserControl.List" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkHomeChannel" runat="server" EnableViewState="False">NNAC</asp:HyperLink> » <asp:HyperLink ID="lnkCateChannel" runat="server" EnableViewState="False"></asp:HyperLink></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
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