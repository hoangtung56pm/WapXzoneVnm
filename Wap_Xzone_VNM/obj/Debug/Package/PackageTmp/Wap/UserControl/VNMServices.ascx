<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VNMServices.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.VNMServices" %>
<div class="rbroundbox">
    <div class="rbtop logo-vnm"><div><asp:Literal ID="ltrDichVu" runat="server" Text="DICH VU VIETNAMOBILE"></asp:Literal></div></div>
</div>
<div class="clearfix"></div>
<asp:Repeater ID="rptDichvu" runat="server">
    <ItemTemplate>
        <asp:Literal ID="ltrDaudong" runat="server"></asp:Literal>
        <asp:HyperLink ID="lnkIcon" runat="server">
            <asp:Image ID="imgAvatar" runat="server" style="border: medium none;" />
        </asp:HyperLink>
        <p><asp:HyperLink ID="lnkText" runat="server"></asp:HyperLink></p>
        <asp:Literal ID="ltrCuoidong" runat="server"></asp:Literal>
    </ItemTemplate>
</asp:Repeater>