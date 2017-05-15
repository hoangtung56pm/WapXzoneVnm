<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuVanDacBiet.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.TuVanDacBiet" %>

<div class="rbroundbox">
	<div class="rbtop"><div class="download-style"><asp:HyperLink ID="lnkTheThao" runat="server" EnableViewState="False">BÓNG ĐÁ</asp:HyperLink> » <asp:Literal ID="ltrtvdb" runat="server" EnableViewState="False">TƯ VẤN ĐẶC BIỆT</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptdv87" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                ♥ <asp:HyperLink ID="lnkdv87" runat="server" EnableViewState="False"></asp:HyperLink> <asp:Literal ID="ltrDangCapNhat" runat="server" EnableViewState="False"></asp:Literal></p>                
           </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="clearfix"></div>
<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>
<div class="clearfix"></div>