
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.NewsList" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc3" %>
<div class="div1">
  <div>TIN SHOWBIZ</div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="newsitem">
                <asp:HyperLink CssClass="bold" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink><br />
                <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" CssClass="thumb-b" alt="thumb" />                
                <p><asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></p>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="newsitem" style="background-color:#DEDEDD;">
                <asp:HyperLink CssClass="bold" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink><br />
                <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" CssClass="thumb-b" alt="thumb" />                
                <p><asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></p>
                <div class="clearfix"></div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>
<uc3:Paging ID="Paging1" runat="server" EnableViewState="False" />