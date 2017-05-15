<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Album.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.Album" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="div1">
  <div>ALBUM</div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False" OnItemDataBound="rptlstCategory_ItemDataBound">
        <ItemTemplate>
            <div class="newsitem"> 
  		        <asp:Literal ID="ltrAlbum" runat="server" EnableViewState="False"></asp:Literal><br>
  		        <asp:Literal ID="ltrAvatar" runat="server" EnableViewState="False"></asp:Literal><br>    	        
    	        <p style="text-align:left;">
        	        <asp:Literal ID="ltrMota" runat="server" EnableViewState="False"></asp:Literal>
                    <asp:Literal ID="ltrSobai" runat="server" EnableViewState="False"></asp:Literal><br />
                    <asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False" Visible="false"></asp:Literal>
                </p>
                <div class="clearfix"></div>
  	        </div>
        </ItemTemplate>
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
</div>
<div class="clearfix"></div>