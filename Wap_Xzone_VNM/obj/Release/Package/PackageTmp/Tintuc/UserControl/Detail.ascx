
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControl.Detail" %>
<div class="rbroundbox">
	<div class="rbtop"><div>
	    <asp:HyperLink ID="lnkHomeChannel" runat="server" EnableViewState="False">TIN TUC</asp:HyperLink> » <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
	</div></div>
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
<div class="div1"><div><asp:Label ID="lblCat" runat="server" EnableViewState="False">TIN DA DANG</asp:Label></div></div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                ♥ <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>	
</div>
<div class="clearfix"></div>
