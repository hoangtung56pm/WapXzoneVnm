<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Game.UserControl.List" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<p style="padding:0 0 2px 2%;">
    <asp:HyperLink ID="lnkValidModel" runat="server">Chỉ hiện thị những game hỗ trợ</asp:HyperLink>
</p>
<div class="rbroundbox">    
	<div class="rbtop"><div><asp:HyperLink ID="lnkHomeChannel" runat="server" EnableViewState="False">GAME</asp:HyperLink> » <asp:HyperLink ID="lnkCateChannel" runat="server" EnableViewState="False"></asp:HyperLink></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False" Visible="false"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

    <asp:Panel ID="pnlS2DkGame1" runat="server">
            
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="<%= UrlProcess.GetGameS2RegisterUrl2G(lang.ToString(),width) %>">
                   <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí GAME HOT tuần") %> </span>
                </a>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

</div>
<div class="clearfix"></div>