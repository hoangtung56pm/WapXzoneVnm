<%@ OutputCache Duration="3600" VaryByParam="lang;w" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Links.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.Links" %>
<div class="div1">
    <div><asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal></div>
</div>
<div class="boxcontent">
    <div class="listlink">
    	<img src="/img/i-home.png"><asp:HyperLink ID="lnkTrangChu" runat="server" EnableViewState="False"></asp:HyperLink>
    </div>
    <asp:Repeater ID="rptLienket" runat="server" EnableViewState="False">
        <ItemTemplate>        
            <div class="listlink">♥
                <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
            </div>        
        </ItemTemplate>    
    </asp:Repeater>
</div>