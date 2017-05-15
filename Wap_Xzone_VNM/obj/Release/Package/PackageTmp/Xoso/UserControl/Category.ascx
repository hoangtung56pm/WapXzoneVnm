<%@ OutputCache Duration="3600" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs"
    Inherits="WapXzone_VNM.Xoso.UserControl.Category" %>
<div class="rbroundbox">
    <div class="rbtop"><div><asp:Label ID="lblOthersService" runat="server" EnableViewState="False">CAC DICH VU</asp:Label></div></div>
</div>
<div class="boxcontent">
    <div class="listlink">
        <p>♥ <asp:HyperLink ID="lnksoicau" runat="server" EnableViewState="False">Thong ke cap so</asp:HyperLink></p>
    </div>
    <div class="listlink">
        <p>♥ <asp:HyperLink ID="lnktructiep" runat="server" EnableViewState="False">Ket qua cho (truc tiep)</asp:HyperLink></p>
    </div>
    <div class="listlink">
        <p>♥ <asp:HyperLink ID="lnk20day" runat="server" EnableViewState="False">Ket qua 30 ngay lien tiep</asp:HyperLink></p>
    </div>
    <div class="listlink" style="font-style:italic;">
        <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
    </div>
</div>
<div class="clearfix"></div>