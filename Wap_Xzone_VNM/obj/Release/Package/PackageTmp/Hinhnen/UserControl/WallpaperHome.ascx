
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WallpaperHome.ascx.cs"
    Inherits="WapXzone_VNM.Hinhnen.UserControl.WallpaperHome" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTaiNhieuNhat" runat="server">TOP DOWNLOAD</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptHottest" runat="server">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" Visible="false"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" />

    <asp:Panel ID="pnlS2DkGame2" runat="server">
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="/HinhNen/DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí Hình Nền HOT") %> </span>
                 </a>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

</div>
<div class="clearfix"></div>
<div class="boxcontent">
	<asp:Literal ID="ltrAdvLevel2" runat="server"></asp:Literal>
</div>
<div class="clearfix"></div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrMoiNhat" runat="server">MỚI CẬP NHẬT</asp:Literal></div></div>
</div>
<div class="boxcontent">   
    <asp:Repeater ID="rptLastest" runat="server">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" Visible="false"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>     
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging2" runat="server" />

    <asp:Panel ID="Panel1" runat="server">
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="/HinhNen/DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí Hình Nền HOT") %> </span>
                 </a>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

</div>
<div class="clearfix"></div>

