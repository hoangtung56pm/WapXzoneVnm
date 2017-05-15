<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Style.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.Style" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="div1">
  <div><asp:Literal ID="ltrTheLoai" runat="server" EnableViewState="False">BÀI HÁT THEO THỂ LOẠI</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False" OnItemDataBound="rptlstCategory_ItemDataBound">
        <ItemTemplate>
            <div class="listlink">
    	        <img src="img/m-list-icon.png">
    	        <asp:Literal ID="ltrTheLoai" runat="server" EnableViewState="False"></asp:Literal>
  	        </div>   
        </ItemTemplate>
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
</div>
<div class="clearfix"></div>