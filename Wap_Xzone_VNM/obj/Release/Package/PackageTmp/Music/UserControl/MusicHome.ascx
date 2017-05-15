<%@ OutputCache Duration="3600" VaryByParam="lang;w" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MusicHome.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.MusicHome" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<div class="div1">
  <div><asp:Literal ID="ltrVideo" runat="server" EnableViewState="False">CLIP NHẠC</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptVideo" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False" Visible="false"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkXem" runat="server" EnableViewState="False"><span class="black bold">Xem</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>
    <p style="text-align:right;">    	
        <asp:HyperLink ID="lnkVideoTiep" runat="server" EnableViewState="False">» Xem tiếp</asp:HyperLink>
    </p>
</div>
<div class="div1">
  <div><asp:Literal ID="ltrMoiNhat" runat="server" EnableViewState="False">MỚI NHẤT</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptMoiNhat" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="item">
    	        <img src="img/m-list-icon.png" alt="+" class="thumblist">
    	        <div class="iteminfo">
    	            <asp:Literal ID="ltrBaihat" runat="server" EnableViewState="False"></asp:Literal>
        	    </div>
    	        <div class="clearfix"></div>
  	        </div>            
        </ItemTemplate>        
    </asp:Repeater>

    <asp:Panel ID="Panel1" runat="server">
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="/Music/DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm Nhạc Chuông HOT") %> </span>
                 </a>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

    <p style="text-align:right;">    	
        <asp:HyperLink ID="lnkMoiNhatTiep" runat="server" EnableViewState="False">» Xem tiếp</asp:HyperLink>
    </p>
</div>
<div class="div1">
  <div><asp:Literal ID="ltrHotThang" runat="server" EnableViewState="False">HOT THÁNG</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptHotThang" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="item">
    	        <img src="img/m-list-icon.png" alt="+" class="thumblist">
    	        <div class="iteminfo">
    	            <asp:Literal ID="ltrBaihat" runat="server" EnableViewState="False"></asp:Literal>
        	    </div>
    	        <div class="clearfix"></div>
  	        </div>            
        </ItemTemplate>        
    </asp:Repeater>

    <asp:Panel ID="Panel2" runat="server">
            <div class="clear5px"></div>

            <div align="center">
                <a class="link-non-orange" href="/Music/DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm Nhạc chuông HOT") %> </span>
                 </a>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

    <p style="text-align:right;">    	
        <asp:HyperLink ID="lnkHotThangTiep" runat="server" EnableViewState="False">» Xem tiếp</asp:HyperLink>
    </p>
</div>
<div class="div1">
	<div><asp:Literal ID="ltrAlbumChonloc" runat="server" EnableViewState="False">ALBUM CHỌN LỌC</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptAlbumChonloc" runat="server" EnableViewState="False">
        <ItemTemplate>
            <asp:Literal ID="startDIV" runat="server" EnableViewState="False"></asp:Literal>
            <asp:Literal ID="ltrAvatar" runat="server" EnableViewState="False"></asp:Literal>        
            <asp:Literal ID="endDIV" runat="server" EnableViewState="False"></asp:Literal>
        </ItemTemplate>        
    </asp:Repeater>
    <p style="text-align:right;">    	
        <asp:HyperLink ID="lnkAlbum" runat="server" EnableViewState="False">» Xem tiếp</asp:HyperLink>
    </p>
</div>
<div class="div1">
  <div><asp:Literal ID="ltrTopCaSy" runat="server" EnableViewState="False">BÀI HÁT THEO CA SỸ</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptTopCaSy" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
    	        <img src="img/m-list-icon2.png">
    	        <asp:Literal ID="ltrCaSy" runat="server" EnableViewState="False"></asp:Literal>
  	        </div>            
        </ItemTemplate>        
    </asp:Repeater>
    <p style="text-align:right;">    	
        <asp:HyperLink ID="lnkCaSy" runat="server" EnableViewState="False">» Xem tiếp</asp:HyperLink>
    </p>
</div>
<div class="div1">
	<div><asp:Literal ID="ltrTheLoai" runat="server" EnableViewState="False">BÀI HÁT THEO THỂ LOẠI</asp:Literal></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptTheLoai" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
    	        <img src="img/m-list-icon.png">
    	        <asp:Literal ID="ltrTheLoai" runat="server" EnableViewState="False"></asp:Literal>
  	        </div>            
        </ItemTemplate>        
    </asp:Repeater>
    <p style="text-align:right;">    	
        <asp:HyperLink ID="lnkTheLoai" runat="server" EnableViewState="False">» Xem tiếp</asp:HyperLink>
    </p>
</div>