<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Artist.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.Artist" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="div1">
  <div><asp:Literal ID="ltrCaSY" runat="server" EnableViewState="False">BÀI HÁT THEO CA SỸ</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False" OnItemDataBound="rptlstCategory_ItemDataBound">
        <ItemTemplate>
            <div class="listlink">
    	        <img src="img/m-list-icon2.png">
    	        <asp:Literal ID="ltrCaSy" runat="server" EnableViewState="False"></asp:Literal>
  	        </div>   
        </ItemTemplate>
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
</div>
<div class="clearfix"></div>