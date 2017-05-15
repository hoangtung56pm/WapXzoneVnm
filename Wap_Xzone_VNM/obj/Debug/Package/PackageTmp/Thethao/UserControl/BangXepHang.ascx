
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BangXepHang.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControl.BangXepHang" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkTheThao" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:Literal ID="ltrBangxephang" runat="server" EnableViewState="False"></asp:Literal></div></div>
</div>
<div class="div1">
	<div><asp:Label ID="lblCompetitonName" runat="server" EnableViewState="False">Giải</asp:Label><asp:Literal ID="ltrRoundName" runat="server" EnableViewState="False"></asp:Literal></div>
</div>
<div class="thethao-bxhtitle">
  <div class="bxh-col1">No.</div>
  <div class="bxh-col1"><asp:Label ID="lblDoi" runat="server" EnableViewState="False">Doi</asp:Label></div>
  <div class="bxh-col1">T</div>
  <div class="bxh-col1">H</div>
  <div class="bxh-col1">B</div>
  <div class="bxh-col1"><asp:Label ID="lblDiem" runat="server" EnableViewState="False">Diem</asp:Label></div>
</div>
<asp:Repeater ID="rptbxh" runat="server" EnableViewState="False">
    <ItemTemplate>
        <div class="thethao-bxhrow-0">
            <div class="row-col"><asp:Literal ID="lblstt" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblCode" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblwin" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblDraw" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblLost" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblPoint" runat="server" EnableViewState="False"></asp:Literal></div>        
        </div>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <div class="thethao-bxhrow-1">
            <div class="row-col"><asp:Literal ID="lblstt" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblCode" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblwin" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblDraw" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblLost" runat="server" EnableViewState="False"></asp:Literal></div>
            <div class="row-col"><asp:Literal ID="lblPoint" runat="server" EnableViewState="False"></asp:Literal></div>        
        </div>
    </AlternatingItemTemplate>
</asp:Repeater>
<div class="clearfix"></div>