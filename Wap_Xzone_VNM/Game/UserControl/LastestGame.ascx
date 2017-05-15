<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastestGame.ascx.cs" Inherits="WapXzone_VNM.Game.UserControl.LastestGame" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<asp:Panel ID="pnlHienThi" runat="server" EnableViewState="false" Visible="false">
    <p style="padding:0 0 2px 2%;">
        Quý khách được miễn phí 2 game hot nhất trên mạng Vietnamobile.Game hot sẽ được gửi cho quý khách vào thứ 2 và thứ 4 hàng tuần ! Chân thành cảm ơn
    </p>
</asp:Panel>


<p style="padding:0 0 2px 2%;">
    <asp:HyperLink ID="lnkValidModel" runat="server">Chỉ hiện thị những game hỗ trợ</asp:HyperLink>
</p>


<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTaiNhieuNhat" runat="server" EnableViewState="False">TOP DOWNLOAD</asp:Literal></div></div>
</div>
<div class="boxcontent">     
    <asp:Repeater ID="rptHottest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False" Visible="false"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

    <asp:Panel ID="pnlS2DkGame1" runat="server">
            
            <div class="clear5px"></div>
       <%-- //Sửa bỏi Bình Trần - 25/11/2016  --%> 
          <%--  <div align="center">
                <a class="link-non-orange" href="<%= UrlProcess.GetGameS2RegisterUrl2G(lang.ToString(),width) %>">
                   <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí GAME HOT tuần") %> </span>
                </a>
            </div>--%>

            <div class="clear5px"></div>

            </asp:Panel>

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
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False" Visible="false"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>     
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging2" runat="server" EnableViewState="False" />

    <asp:Panel ID="pnlS2DkGame2" runat="server">
            <div class="clear5px"></div>
       <%-- //Sửa bỏi Bình Trần - 25/11/2016  --%> 
          <%--  <div align="center">
                <a class="link-non-orange" href="<%= UrlProcess.GetGameS2RegisterUrl2G(lang.ToString(),width) %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí GAME HOT tuần") %> </span>
                 </a>
            </div>--%>

            <div class="clear5px"></div>

            </asp:Panel>

</div>
<div class="clearfix"></div>