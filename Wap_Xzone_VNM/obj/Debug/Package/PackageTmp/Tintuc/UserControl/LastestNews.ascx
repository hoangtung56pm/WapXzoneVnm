
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastestNews.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControl.LastestNews" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div>
	    <asp:Label ID="lblTitle" runat="server" EnableViewState="False">TIN MOI NHAT</asp:Label>
	</div></div>
</div>
<div class="boxcontent">
    <div class="item" style="height:70px;" id="divtintonghop" visible="false" runat="server">
        <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" CssClass="thumb-b" alt="thumb" />
        <asp:HyperLink CssClass="bold" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
        <p><asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></p>
        <div class="clearfix"></div>
    </div>
    <asp:Repeater ID="rptlastest" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="item" style="height:70px;background-color:#DEDEDD">
                <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" CssClass="thumb-b" alt="thumb" />
                <asp:HyperLink CssClass="bold" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                <p><asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></p>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="item" style="height:70px;">
                <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" CssClass="thumb-b" alt="thumb" />
                <asp:HyperLink CssClass="bold" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                <p><asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></p>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>
<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
<div class="clearfix"></div>