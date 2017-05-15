
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControl.Detail" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc2" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkHomeChannel" runat="server">ANH</asp:HyperLink> » <asp:HyperLink ID="lnkCateChannel" runat="server"></asp:HyperLink></div></div>
</div>
<div class="boxcontent">
    <div class="item">
        <asp:Image ID="imgDetail" runat="server" alt="thumb" class="thumb-bb"/>
        <h1 style="font-size:10px;"><asp:Literal ID="ltrTenAnh" runat="server"></asp:Literal></h1>
        <p><asp:Literal ID="ltrLuottai" runat="server" Visible="false"></asp:Literal></p>
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
                <asp:HyperLink ID="lnkAvatar" runat="server" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>
    <uc2:Paging ID="Paging1" runat="server" />
</div>
