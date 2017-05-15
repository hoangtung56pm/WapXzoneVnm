<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JavaGameVnm.ascx.cs" Inherits="WapXzone_VNM.Game.UserControl.JavaGameVnm" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
    <div class="rbtop">
        <div>
            <asp:HyperLink ID="lnkHomeChannel" runat="server" EnableViewState="False">DỊCH VỤ GAME CỦA VIETNAMOBILE</asp:HyperLink>
        </div>
    </div>
</div>
<div class="clearfix">
</div>
<div style="padding: 5px 0 5px 5px;">
    <asp:Label ID="lblAlert" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
</div>
<div class="clearfix">
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p>
                        <asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False" Visible="false"></asp:Literal></p>
                    <p>
                        <asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p>
                        <i>Giá : 15000đ/Game</i></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False" Font-Size="15px"><span class="orange bold">Tải</span></asp:HyperLink>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="clearfix">
</div>