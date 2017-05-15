
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.AlbumDetail" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="div1">
  <div>ALBUM</div>
</div>
<div class="boxcontent">
    <div class="hotnews"> 
  		<asp:Literal ID="ltrAlbumName" runat="server" EnableViewState="False"></asp:Literal><br />
    	<asp:Image CssClass="thumb-b" ID="albumAvatar" alt="thumb" runat="server" />
    	<p style="text-align:left;">
        	<asp:Literal ID="ltrMota" runat="server" EnableViewState="False"></asp:Literal><asp:Literal ID="ltrSobai" runat="server" EnableViewState="False"></asp:Literal><br />
        	<asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False" Visible="false"></asp:Literal>
        </p>
        <div class="clearfix"></div>
  	</div>
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div style="" class="item">
    	        <div class="iteminfo">
        	        <asp:Literal ID="ltrBaihat" runat="server" EnableViewState="False"></asp:Literal><br>
           	        <span class="orange"><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal></span><br>           	        
      		        <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"></asp:HyperLink> | 
                    <asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="black">Tặng</span></asp:HyperLink>
                </div>
    	        <div class="clearfix"></div>
  	        </div>            
        </ItemTemplate>
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
</div>
<div class="clearfix"></div>