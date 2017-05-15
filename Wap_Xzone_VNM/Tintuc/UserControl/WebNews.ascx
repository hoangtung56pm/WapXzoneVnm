<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebNews.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControl.WebNews" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="div1">
	<div><asp:HyperLink ID="lnkTintuc" CssClass="logo-vnm" runat="server" EnableViewState="False">Dịch vụ Vietnamobile</asp:HyperLink></div>
</div>

<div class="boxcontent">
    
   <%-- <div class="hotnews">
        <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False"><asp:Image ID="imgAvatar" runat="server" CssClass="thumb-b" alt="thumb" /></asp:HyperLink>
        <asp:HyperLink ID="lnkTitle" CssClass="bold" runat="server" EnableViewState="False"></asp:HyperLink>
        <p><asp:Literal ID="ltrTime" runat="server" EnableViewState="False">Thời gian</asp:Literal></p>        
    </div>

    <div class="clearfix"></div>--%>

    <asp:Repeater ID="rptCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
                        
            <%--<asp:Panel ID="othernews" runat="server" EnableViewState="False">--%>
                
                <div class="listlink">         
                    ♥ <a href="<%# UrlProcess.WebTinTucChuyenMuc(Eval("Id").ToString(),Eval("Name").ToString()) %>"><%# Eval("Name") %></a>
                </div>                

            <%--</asp:Panel>--%>

        </ItemTemplate>
    </asp:Repeater>

    <%--<div class="listlink">    	
        <asp:HyperLink ID="lnkCacTinKhac" runat="server" EnableViewState="False">Các tin khác »</asp:HyperLink>
    </div>--%>

</div>