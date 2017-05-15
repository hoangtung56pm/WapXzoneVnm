<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone.TuVi.UserControl.Detail" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTieude" runat="server"></asp:Literal></div></div>
</div>
<div class="boxcontent">
    <div id="divthongbao" class="item" runat="server">
        <asp:Literal ID="ltrthongbao" runat="server"></asp:Literal></div>
    <div class="clearfix"></div>
    <div class="item">
        <asp:Label ID="lblNoidung" runat="server"></asp:Label>
    </div>
    <div class="item">
        <asp:HyperLink ID="lnkBack" NavigateUrl="JavaScript:history.go(-1)" runat="server">Quay lai</asp:HyperLink>
    </div>
</div>
<div class="clearfix"></div>