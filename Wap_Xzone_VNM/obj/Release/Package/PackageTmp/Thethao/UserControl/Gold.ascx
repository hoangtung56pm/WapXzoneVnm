<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gold.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControl.Gold" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTitle" runat="server" EnableViewState="False">TIEU DIEM THE THAO</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <div class="hotnews">
        <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False"><asp:Image ID="imgAvatar" runat="server" EnableViewState="False" class="thumb-b" alt="thumb" /></asp:HyperLink>
        <asp:HyperLink ID="lnkTitle" CssClass="bold" runat="server" EnableViewState="False"></asp:HyperLink>
        <p><asp:Literal ID="ltrTime" runat="server" EnableViewState="False">Thời gian</asp:Literal></p>
        <%--<p><asp:Literal ID="ltrTeaser" runat="server" EnableViewState="False">Chi tiết</asp:Literal></p>--%>
        <div class="clearfix"></div>
    </div>
    <asp:Repeater ID="rptNewLastest" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <asp:Panel ID="othernews" runat="server" EnableViewState="False">
                <div class="listlink">         
                    ♥ <asp:HyperLink ID="lnkTitlelist" runat="server" EnableViewState="False"></asp:HyperLink>
                </div>                
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>
    <div class="listlink">
    	<asp:HyperLink ID="lnkCacTinKhac" runat="server" EnableViewState="False">Cac tin khac »</asp:HyperLink>
    </div>
</div>
<div class="clearfix"></div>
<%--<div style="background-color:#dcdcdc;height:100px">
	<table style="width:98%;">
    	<tbody><tr style="text-align:center;">
        	<td>
            	<asp:HyperLink ID="lnkTranCauVang" runat="server" EnableViewState="False"><img src="../../img/i-trancauvang.gif"></asp:HyperLink>
            </td>
        </tr>
        <tr style="text-align:center;">
        	<td>
        		<asp:HyperLink ID="lnkTuVanDacBiet" runat="server" EnableViewState="False"><img src="../../img/i-tuvan87.gif"></asp:HyperLink>
            </td>
        </tr>
        <tr style="text-align:left;">
        	<td style="padding:5px;">
    			<p><img src="../../img/b-ball.gif"> <asp:Literal ID="ltrDangKy" runat="server" EnableViewState="False"></asp:Literal></p>
   				<div class="clearfix"></div>
    			<asp:HyperLink ID="lnkDangKy" runat="server" EnableViewState="False"><span class="blue bold">» Dang ky «</span></asp:HyperLink>
            </td>
        </tr>
    </tbody></table>
</div>--%>
<div style="background-color:#dcdcdc; padding:5px 5px 5px 5px;">
	<p style="text-align:center">
    	<asp:HyperLink ID="lnkTranCauVang" runat="server" EnableViewState="False"><img src="../../img/i-trancauvang.gif"></asp:HyperLink>
    </p>
    <p style="text-align:center">
        <asp:HyperLink ID="lnkTuVanDacBiet" runat="server" EnableViewState="False"><img src="../../img/i-tuvan87.gif"></asp:HyperLink>
    </p>
    <div class="listlink">
        <p><img src="../../img/b-ball.gif"> <asp:Literal ID="ltrDangKy" runat="server" EnableViewState="False"></asp:Literal></p>   		
        <p><asp:HyperLink ID="lnkDangKy" runat="server" EnableViewState="False"><span class="blue bold">» Dang ky «</span></asp:HyperLink></p>
    </div>
</div>
<div class="clearfix"></div>
<div class="boxcontent">    
    <asp:Repeater ID="rptTrancaudinh" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="item"> 
                <img src="../../img/b-ball.gif" alt="thumb" class="thumblist">
                <div class="item-info">
                    <asp:Label ID="ltrGame" runat="server" EnableViewState="False"></asp:Label>                 
                    <p><asp:Literal ID="ltrTime" runat="server" EnableViewState="False"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTuVan" runat="server" EnableViewState="False" Text="Tu van"></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkThongke" runat="server" EnableViewState="False" Text="Thong ke"></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkKQCho" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>      
                </div>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate>        
    </asp:Repeater>
</div>
<uc1:Paging ID="Pagging1" runat="server" EnableViewState="False" />
<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>
<div class="clearfix"></div>