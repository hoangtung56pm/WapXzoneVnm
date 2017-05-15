<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControl.SearchResult" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTenChuyenMuc" runat="server">KET QUA TIM KIEM</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <div class="itemlist">
        <asp:Literal ID="ltrCount" runat="server"></asp:Literal>
    </div>
    <asp:Repeater ID="rptlstResult" runat="server">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" />
</div>
<div class="clearfix"></div>