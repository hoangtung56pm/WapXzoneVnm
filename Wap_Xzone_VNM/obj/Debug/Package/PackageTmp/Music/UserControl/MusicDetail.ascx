<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MusicDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.MusicDetail" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc2" %>
<div class="div1">
  <div><asp:Literal ID="ltrAmNhac" runat="server">ÂM NHẠC</asp:Literal></div>
</div>
<div class="boxcontent">
    <div class="item">        
        <p><span class="bold"><asp:Literal ID="ltrTenAnh" runat="server"></asp:Literal></span></p>
        <p><asp:Literal ID="ltrCasy" runat="server"></asp:Literal></p>
        <p><asp:Literal ID="ltrNhom" runat="server"></asp:Literal></p>
        <asp:Literal ID="ltrLuottai" runat="server"></asp:Literal></p>
        <p><asp:Literal ID="ltrGiaTai" runat="server"></asp:Literal></p>
        <%--<p><asp:Literal ID="ltrGiaTang" runat="server"></asp:Literal></p>--%>
        <img src="../../img/i-download.png">
        <asp:HyperLink ID="lnkTai" runat="server"><span class="bold">Tải về</span></asp:HyperLink>

        <div class="clearfix"></div>
    </div>
</div>
<div class="send">
    <span><asp:Literal ID="ltrGuiTang" runat="server">Gửi tặng</asp:Literal></span>
    <asp:TextBox ID="txtSoDienThoaiTang" CssClass="sendinput input80" runat="server"></asp:TextBox>    
    <asp:ImageButton ID="btnTang" runat="server" ImageUrl="../../img/button-gift.png" onclick="btnTang_Click" />
</div>
<div class="boxcontent">
    <p style="text-align:right;">
        <asp:HyperLink ID="lnkQuayLai" runat="server" EnableViewState="False">» Quay lại</asp:HyperLink>
    </p>
</div>
<div class="clearfix"></div>