<%----%>
<div class="div1">
  <div>TIN SHOWBIZ</div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsHot.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.NewsHot" %>
<div class="boxcontent">
    <div class="hotnews">
        <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink><br />
        <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False"><asp:Image ID="imgAvatar" runat="server" CssClass="thumb-b" alt="thumb" /></asp:HyperLink>        
        <p><asp:Literal ID="ltrTeaser" runat="server" EnableViewState="False">Thời gian</asp:Literal></p>
        <p><asp:Literal ID="ltrTime" runat="server" EnableViewState="False">Thời gian</asp:Literal></p> 
    </div>
    <div class="clearfix"></div>
    <p>
        <asp:Repeater ID="rptNewLastest" runat="server" EnableViewState="False">
            <ItemTemplate>            
                <asp:Panel ID="othernews" runat="server" EnableViewState="False">
                    • <asp:HyperLink ID="lnkTitlelist" runat="server" EnableViewState="False"></asp:HyperLink><br />
                </asp:Panel>
            </ItemTemplate>
        </asp:Repeater>
    </p>    
    <p style="text-align:right;">    	
        <asp:HyperLink ID="lnkCacTinKhac" runat="server" EnableViewState="False">» Xem tiếp</asp:HyperLink>
    </p>
</div>