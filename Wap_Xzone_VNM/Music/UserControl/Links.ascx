<%@ OutputCache Duration="3600" VaryByParam="lang;w" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Links.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.Links" %>
<div class="mainmenu"><span class="bold"><asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal></span></div>
<div class="boxcontent">    
    <asp:Repeater ID="rptLienket" runat="server" EnableViewState="False">
        <ItemTemplate>        
            <div class="listlink"><img src="img/m-list-icon.png"> 
                <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
            </div>        
        </ItemTemplate>    
    </asp:Repeater>
</div>