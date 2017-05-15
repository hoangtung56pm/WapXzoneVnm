<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongBao.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.ThongBao" %>

<asp:Panel runat="server" ID="pnlThongBao" Visible="false" EnableViewState="false">

<div class="div1">
    <div>
        <asp:HyperLink ID="lnkLienket" CssClass="link-non-black logo-vnm" runat="server" EnableViewState="False" Text="Thông báo khuyến mãi">
        </asp:HyperLink>
    </div>
</div>
<div class="boxcontent">

    <asp:Literal ID="litThongBao" runat="server" EnableViewState="false"></asp:Literal>

</div>

</asp:Panel>

