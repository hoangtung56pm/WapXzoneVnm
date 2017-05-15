<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs" Inherits="WapXzone_VNM.Phanmem.UserControl.SearchResult" %>
<%@ Register src="Paging.ascx" tagname="Paging" tagprefix="uc1" %>
<p style="padding:0 0 2px 2%;">
    <asp:HyperLink ID="lnkValidModel" runat="server">Chỉ hiện thị những game hỗ trợ</asp:HyperLink>
</p>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTenChuyenMuc" runat="server" EnableViewState="False"></asp:Literal></div></div>
</div>
<div class="boxcontent">
    <div class="itemlist">
        <asp:Literal ID="ltrCount" runat="server" EnableViewState="False"></asp:Literal>
    </div>    
    <asp:Repeater ID="rptResult" runat="server" EnableViewState="False">
        <ItemTemplate> 
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate>           
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
</div>
<div class="clearfix"></div>