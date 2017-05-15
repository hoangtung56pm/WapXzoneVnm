<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagging.ascx.cs" Inherits="WapXzone_VNM.Hot100.UserControl.Pagging" %>
<div class="content-page">
    <asp:HyperLink ID="lnkFist" runat="server" Text="Dau" ></asp:HyperLink>&nbsp;|&nbsp;
    <asp:HyperLink ID="lnkPrev" runat="server" Text="Truoc"></asp:HyperLink>&nbsp;|&nbsp;
    <asp:Repeater ID="rptPage" runat="server">
        <ItemTemplate>
            <asp:Literal ID="ltrPage" runat="server"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
    &nbsp;|&nbsp;<asp:HyperLink ID="lnkNext" runat="server"  Text="Sau" ></asp:HyperLink>&nbsp;|&nbsp;
    <asp:HyperLink ID="lnkEnd" runat="server" Text=" Cuoi"></asp:HyperLink>
</div>

