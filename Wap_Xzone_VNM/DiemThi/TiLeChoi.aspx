<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiLeChoi.aspx.cs" Inherits="WapXzone_VNM.Diemthi.TiLeChoi" %>
<%@ Register src="../Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc3" %>
<%@ Register src="../Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc4" %>
<%@ Register src="../Wap/UserControl/Links.ascx" tagname="Links" tagprefix="uc1" %>
<%@ Register src="UserControl/DanhMucDichVu.ascx" tagname="DanhMucDichVu" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Diem thi :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/main.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc4:Header ID="Header1" runat="server" />    
    <%--Content here--%>
    <div class="rbroundbox">
        <div class="rbtop"><div><asp:Literal ID="ltrDichvu" runat="server"></asp:Literal></div></div>
    </div>
    <asp:Panel ID="pnlSMS" runat="server" Visible="false">        
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>            
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlYeuCau" runat="server" Visible="true">        
        <div class="boxcontent">
	        <div class="listlink">
    	        <span class="bold pink"><asp:Literal ID="ltrMaTruong" runat="server"></asp:Literal></span>
            </div>
   	        <div class="listlink">
   	            <table cellpadding="0" cellspacing="0">
   	                <tr>
   	                    <td><asp:TextBox ID="txtMaTruong" CssClass="sfrminput input80" runat="server"></asp:TextBox></td>
   	                    <td>&nbsp;<asp:ImageButton ID="btnThucHien" runat="server" 
                                ImageUrl="/img/button-gift.png" onclick="btnThucHien_Click" /></td>
   	                </tr>
   	            </table>
            </div>            
            <div class="listlink">
    	        <asp:Literal ID="ltrGia" runat="server"></asp:Literal>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
	        <p style="margin:5px 0 5px 0;"><asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal></p>            
        </div>
    </asp:Panel>
    <%--end Content here--%>
    <uc2:DanhMucDichVu ID="DanhMucDichVu1" runat="server" />
    <uc1:Links ID="Links1" runat="server" />    
    <uc3:Footer ID="Footer4" runat="server" />
    </form>
</body>
</html>
