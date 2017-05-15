<%@ OutputCache Duration="3600" VaryByParam="lang;w;display" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.Footer" %>
<div class="footer">
	<div style="padding-top: 15px; background-color:#F79720;" >
	    <asp:HyperLink ID="lnkDauTrang" runat="server" EnableViewState="False">Đầu trang</asp:HyperLink> | 
        <asp:HyperLink ID="lnkNgonNgu" runat="server" EnableViewState="False">Khong dau</asp:HyperLink> | 
        <asp:Literal ID="ltrHoTro" runat="server" EnableViewState="False">Hỗ trợ: 19001255</asp:Literal> 
        <%--|--%><asp:HyperLink ID="lnkWap3g" Visible="false" runat="server" EnableViewState="False">Wap 3G</asp:HyperLink>
	</div>
    <div class="bold"><asp:Literal ID="ltrBanquyen" runat="server" EnableViewState="False">Bản quyền Vietnamobile</asp:Literal></div>    
</div>