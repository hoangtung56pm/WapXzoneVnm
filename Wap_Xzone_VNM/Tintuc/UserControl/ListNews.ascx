<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListNews.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControl.ListNews" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc3" %>

<div class="rbroundbox">
	<div class="rbtop"><div>
	    <asp:HyperLink ID="lnkHomeChannel" runat="server" EnableViewState="False">TIN TUC</asp:HyperLink> 
        <%--» <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>--%>
	</div></div>
</div>

<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="item" style="height:70px;">
                <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" CssClass="thumb-b" alt="thumb" />
                <asp:HyperLink CssClass="bold" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                <p><asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></p>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="item" style="height:70px;background-color:#DEDEDD">
                <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" CssClass="thumb-b" alt="thumb" />
                <asp:HyperLink CssClass="bold" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                <p><asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></p>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>

<uc3:Paging ID="Paging1" runat="server" EnableViewState="False" />