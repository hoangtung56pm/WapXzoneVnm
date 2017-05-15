<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs"
    Inherits="WapXzone_VNM.TinTuc247.UserControl.SearchResult" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc3" %>
<div class="hinhnen-title">
    <asp:Label ID="lblTitle" runat="server" EnableViewState="False">Ket qua tim kiem</asp:Label>
</div>
<div class="clear10px">
</div>
<div class="ketqua-timkiem">
    <asp:Literal ID="ltrCount" runat="server" EnableViewState="False"></asp:Literal>
</div>
<div class="content-category">
    <asp:Repeater ID="rptResult" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="content-row0">
                <div class="row-img">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="46px" />
                </div>
                <div class="row-title">
                    <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                    <div class="clear0px">
                    </div>
                    <asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label>
                </div>
            </div>
            <div class="clear5px">
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="content-row1">
                <div class="row-img">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="46px" />
                    <%--<img src="../Images/vnm_vnmicon.jpg" style="border: none">--%>
                </div>
                <div class="row-title">
                    <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                    <div class="clear0px">
                    </div>
                    <asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label>
                </div>
            </div>
            <div class="clear5px">
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>
<div class="clear5px">
</div>
<%--page--%>
<div class="page-number">
    <uc3:Paging ID="Paging1" runat="server" EnableViewState="False" />
</div>