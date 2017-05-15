
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BCBHome.ascx.cs" Inherits="WapXzone_VNM.Bancanbiet.UserControl.BCBHome" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Label ID="lblTitle" runat="server" EnableViewState="False">MAY ATM</asp:Label></div></div>
</div>
<div class="boxcontent">    
    <div class="listlink" style="font-style:italic; font-weight:bold;">
        <asp:Literal ID="ltrMienphi" runat="server" EnableViewState="False">(Dich vu mien phi)</asp:Literal>    
    </div>    
    <asp:Repeater ID="rptAtm" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                ♥ <asp:HyperLink ID="lnkAtm" runat="server" EnableViewState="False"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="rbroundbox">
	<div class="rbtop"><div>TAXI</div></div>
</div>
<div class="boxcontent">
    <div class="listlink" style="font-style:italic; font-weight:bold;">
        <asp:Literal ID="ltrMienphi1" runat="server" EnableViewState="False">(Dich vu mien phi)</asp:Literal>    
    </div>
    <asp:Repeater ID="rptTaxi" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="listlink">
                ♥ <asp:HyperLink ID="lnktaxi" runat="server" EnableViewState="False"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>