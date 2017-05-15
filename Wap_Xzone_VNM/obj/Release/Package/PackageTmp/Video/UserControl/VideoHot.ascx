<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoHot.ascx.cs" Inherits="WapXzone_VNM.Video.UserControl.VideoHot" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%--<div class="rbroundbox">
	<div class="rbtop"><div>

        <a class="link-non-black" href="<%= UrlProcess.GetVideoHomeUrl(lang.ToString(),width) %>">
            VIDEO HOT
        </a>
     
      </div></div>
</div>--%>

<div class="div1">    
	<div><%--<asp:HyperLink ID="lnkXemThem" runat="server" EnableViewState="False">Game HOT</asp:HyperLink>--%>
         <a class="link-non-black logo-vnm" href="<%= UrlProcess.GetVideoHomeUrl(lang.ToString(),width) %>">
            VIDEO HOT
        </a>
    </div>
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
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkXem" runat="server" EnableViewState="False"><span class="orange bold">Xem</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>

    <asp:Panel ID="pnlS2DkGame2" runat="server">
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="/Video/DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí VIDEO HOT tuần") %> </span>
                 </a>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

</div>

<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>
