<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.SearchResult" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="div1">
  <div><asp:Literal ID="ltrKetQua" runat="server" EnableViewState="False">KẾT QUẢ TÌM KIẾM</asp:Literal></div>
</div>
<div class="boxcontent">
    <div class="hotnews" style="border-bottom:#b200b2 1px solid;"> 
  		<asp:Literal ID="ltrAlbumName" runat="server" EnableViewState="False"></asp:Literal><br />    	
    	<p style="text-align:left;">
        	<asp:Literal ID="ltrMota" runat="server" EnableViewState="False"></asp:Literal><asp:Literal ID="ltrSobai" runat="server" EnableViewState="False"></asp:Literal>        	
        </p>
        <div class="clearfix"></div>
  	</div>
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div style="" class="item">
    	        <div class="iteminfo">
        	        <asp:Literal ID="ltrBaihat" runat="server" EnableViewState="False"></asp:Literal><br>
        	        <asp:Literal ID="ltrTheLoai" runat="server" EnableViewState="False"></asp:Literal><br>
           	        <asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal><br>
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