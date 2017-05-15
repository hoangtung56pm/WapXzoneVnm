<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotHome.ascx.cs" Inherits="WapXzone_VNM.Xoso.UserControl.LotHome" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Register Src="SelectDate.ascx" TagName="SelectDate" TagPrefix="uc1" %>
<uc1:SelectDate ID="SelectDate1" runat="server" />

<div class="rbroundbox">
	<div class="rbtop"><div><asp:Label ID="lblTitle" runat="server" EnableViewState="False">CAC TINH MO THUONG</asp:Label></div></div>
</div>
<div class="boxcontent">
    <div class="item">
        <div class="item-info">
            <asp:HyperLink ID="lnkThudo" runat="server" EnableViewState="False">Thu do</asp:HyperLink>
            <p><asp:HyperLink ID="lnkKQCho" CssClass="orange bold" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>&nbsp;|
            &nbsp;<asp:HyperLink ID="lnkSoiCau" runat="server" EnableViewState="False" Text="Thong ke cap so"></asp:HyperLink>&nbsp;|
            &nbsp;<asp:HyperLink ID="lnkxemkq" runat="server" EnableViewState="False" Text="KQ"></asp:HyperLink></p>

            <asp:Panel ID="pnlXsThuDo" runat="server">
            <div class="clear5px"></div>
            <div align="left">

                <%--<a class="link-non-orange" href="<%= UrlProcess.GetS2RegisterXoSoUrl2G(lang.ToString(),width,"1") %>">--%>



                <%--//Sửa bỏi Bình Trần - 25/11/2016  --%> 
              <%--  <a class="link-non-orange" href="/Xoso/KetQua.aspx?id=1&lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Nhận KQXS hàng ngày") %> </span> 
                </a>--%>

            </div>
            <div class="clear5px"></div>
          </asp:Panel>

        </div>
        <div class="clearfix"></div>        
    </div>
    <div class="clearfix"></div>
    <asp:Repeater ID="rptlst" runat="server" EnableViewState="False">
        <ItemTemplate>
        <div class="item">            
            <div class="item-info"><asp:HyperLink ID="lnkCity" NavigateUrl="#" runat="server" EnableViewState="False"></asp:HyperLink>
                <p><asp:HyperLink ID="lnkkqc" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>&nbsp;|
                &nbsp;<asp:HyperLink ID="lnksc" runat="server" EnableViewState="False" Text="Thong ke cap so"></asp:HyperLink>&nbsp;|
                &nbsp;<asp:HyperLink ID="lnkxkq" runat="server" EnableViewState="False" Text="KQ"></asp:HyperLink></p>

                <asp:Panel ID="pnlXsList" runat="server">
          <div class="clear5px"></div>
            <div align="left">
                <asp:HyperLink ID="lnkS2DangKy" CssClass="link-non-orange" runat="server" EnableViewState="false"></asp:HyperLink>
          </div>
          <div class="clear5px"></div>
          </asp:Panel>

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