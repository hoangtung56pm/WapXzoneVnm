
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.NewsDetail" %>
<div class="div1">
  <div>TIN SHOWBIZ</div>
</div>
<div class="boxcontent">
    <div class="hotnews"> 
        <asp:Image ID="imgAvatar" runat="server" style="float:left; margin:0 5px 2px 0;" alt="thumb" />
        <asp:Label ID="lblHeadline" runat="server" EnableViewState="False" CssClass="bold"></asp:Label>
        <p>
            <asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label>
    	    <asp:Literal ID="ltrBody" runat="server" EnableViewState="False"></asp:Literal>
        </p>
        <div class="clearfix"></div>
  </div>
</div>
<%--end detail--%>
<div class="mainmenu"><span class="bold"><asp:Label ID="lblCat" runat="server" EnableViewState="False">TIN DA DANG</asp:Label></span></div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                • <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>	
</div>
<div class="clearfix"></div>
