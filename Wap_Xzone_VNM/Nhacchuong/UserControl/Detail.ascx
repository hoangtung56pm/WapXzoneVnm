<%@ OutputCache Duration="333" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Nhacchuong.UserControl.Detail" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc2" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkHomeChannel" runat="server">NNAC</asp:HyperLink> » <asp:HyperLink ID="lnkCateChannel" runat="server"></asp:HyperLink></div></div>
</div>
<div class="boxcontent">
    <div class="item">        
        <p><span class="blue bold"><asp:Literal ID="ltrTenAnh" runat="server"></asp:Literal></span></p>
        <p><asp:Literal ID="ltrCasy" runat="server"></asp:Literal></p>
        <p><asp:Literal ID="ltrNhom" runat="server"></asp:Literal></p>
        <%--<p><asp:Literal ID="ltrLuottai" runat="server" Visible="false"></asp:Literal></p>--%>
        <p><asp:Literal ID="ltrGiaTai" runat="server"></asp:Literal></p>
        <%--<p><asp:Literal ID="ltrGiaTang" runat="server"></asp:Literal></p>--%>
        <img src="../../img/i-download.png"><asp:HyperLink ID="lnkTai" runat="server"><span class="bold">Tải về</span></asp:HyperLink>
        <div class="clearfix"></div>
    </div>
</div>
<div class="send">
    <span><asp:Literal ID="ltrGuiTang" runat="server">Gửi tặng</asp:Literal></span>
    <asp:TextBox ID="txtSoDienThoaiTang" CssClass="sendinput input80" runat="server"></asp:TextBox>    
    <asp:ImageButton ID="btnTang" runat="server" 
        ImageUrl="../../img/button-gift.png" onclick="btnTang_Click" />
</div>
<div class="clearfix"></div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrCungTheLoai" runat="server">CÙNG THỂ LOẠI</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptCungTheLoai" runat="server">
        <ItemTemplate>            
            <div class="item">
                <img src="../img/b-ring.gif" alt="thumb" class="thumblist">
                <div class="item-info"> 
                    <asp:HyperLink ID="lnkTenAnh" runat="server"></asp:HyperLink>
                    <p><asp:Literal ID="ltrCasy" runat="server"></asp:Literal></p>                    
                    <asp:HyperLink ID="lnkTai" runat="server"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate>      
    </asp:Repeater>
    <uc2:Paging ID="Paging1" runat="server" />
</div>
