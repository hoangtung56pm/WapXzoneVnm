<%@ OutputCache Duration="3600" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HoangdaoHome.ascx.cs" Inherits="WapXzone_VNM.Hoangdao.UserControl.HoangdaoHome" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTieude" runat="server" EnableViewState="False">TỬ VI</asp:Literal></div></div>
</div>
<div class="clearfix"></div>
<div class="boxcontent">   
    <div class="item">
        <img src="../../img/hd_baobinh.gif" class="thumblist" style="width:35px" />
        <div class="item-info">
            <asp:HyperLink ID="lnkNhanMa" runat="server" EnableViewState="False"></asp:HyperLink>
            <p>(<asp:Label ID="lblNgayNhanMa" runat="server" EnableViewState="False"></asp:Label>)</p>
        </div>        
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_songngu.gif" class="thumblist" style="width:35px" />
        <div class="item-info">        
            <asp:HyperLink ID="lnkNamDuong" runat="server" EnableViewState="False"></asp:HyperLink>
            <p>(<asp:Label ID="lblNgayNamDuong" runat="server" EnableViewState="False"></asp:Label>)</p>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_bachduong.gif" class="thumblist" style="width:35px" />
        <div class="item-info">        
            <asp:HyperLink ID="lnkBaoBinh" runat="server" EnableViewState="False"></asp:HyperLink>
            <p>(<asp:Label ID="lblNgayBaoBinh" runat="server" EnableViewState="False"></asp:Label>)</p>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_kimnguu.gif" class="thumblist" style="width:35px" />
        <div class="item-info">        
            <asp:HyperLink ID="lnkSongNgu" runat="server" EnableViewState="False"></asp:HyperLink>
            <p>(<asp:Label ID="lblNgaySongNgu" runat="server" EnableViewState="False"></asp:Label>)</p>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_songtu.gif" class="thumblist" style="width:35px" />                    
        <div class="item-info">        
            <asp:HyperLink ID="lnkDuongCuu" runat="server" EnableViewState="False"></asp:HyperLink>
            <p>(<asp:Label ID="lblNgayDuongCuu" runat="server" EnableViewState="False"></asp:Label>)</p>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_cugiai.gif" class="thumblist" style="width:35px" />                    
        <div class="item-info">
            <asp:HyperLink ID="lnkKimNguu" runat="server" EnableViewState="False"></asp:HyperLink>
            <p>(<asp:Label ID="lblNgayKimNguu" runat="server" EnableViewState="False"></asp:Label>)</p>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_sutu.gif" class="thumblist" style="width:35px" />                    
        <div class="item-info">
            <asp:HyperLink ID="lnkSongTu" runat="server" EnableViewState="False"></asp:HyperLink>
            <p>(<asp:Label ID="lblNgaySongTu" runat="server" EnableViewState="False"></asp:Label>)</p>                
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_xunu.gif" class="thumblist" style="width:35px" />                    
        <div class="item-info">            
            <asp:HyperLink ID="lnkCuGiai" runat="server" EnableViewState="False"></asp:HyperLink>
            
            <p>(<asp:Label ID="lblNgayCuGiai" runat="server" EnableViewState="False"></asp:Label>)</p>        
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_thienbinh.gif" class="thumblist" style="width:35px" />                    
        <div class="item-info">        
            <asp:HyperLink ID="lnkSuTu" runat="server" EnableViewState="False"></asp:HyperLink>            
            <p>(<asp:Label ID="lblNgaySuTu" runat="server" EnableViewState="False"></asp:Label>)</p>                    
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_hocap.gif" class="thumblist" style="width:35px" />        
        <div class="item-info">            
            <asp:HyperLink ID="lnkXuNu" runat="server" EnableViewState="False"></asp:HyperLink>            
            <p>(<asp:Label ID="lblNgayXuNu" runat="server" EnableViewState="False"></asp:Label>)</p>                    
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_nhanma.gif" class="thumblist" style="width:35px" />        
        <div class="item-info">            
            <asp:HyperLink ID="lnkThienBinh" runat="server" EnableViewState="False"></asp:HyperLink>            
            <p>(<asp:Label ID="lblNgayThienBinh" runat="server" EnableViewState="False"></asp:Label>)</p>                    
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="item">
        <img src="../../img/hd_maket.gif" class="thumblist" style="width:35px" />        
        <div class="item-info">        
            <asp:HyperLink ID="lnkBoCap" runat="server" EnableViewState="False"></asp:HyperLink>            
            <p>(<asp:Label ID="lblNgayBoCap" runat="server" EnableViewState="False"></asp:Label>)</p>                    
        </div>
    </div>    
</div>
<div class="clearfix"></div>