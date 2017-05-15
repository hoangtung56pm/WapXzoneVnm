<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaTruong.aspx.cs" Inherits="WapXzone_VNM.Diemthi.MaTruong" %>
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
    <div class="clearfix"></div>
    <div class="boxcontent">	        
        <div class="listlink">
	        <span class="bold pink"><asp:Literal ID="ltrTukhoa" runat="server"></asp:Literal></span>
        </div>
        <div class="listlink">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:TextBox ID="txtTukhoa" CssClass="sfrminput" Width="120px" runat="server"></asp:TextBox></td>
                    <td>&nbsp;<asp:ImageButton ID="btnThucHien" runat="server" 
                            ImageUrl="/img/button-find-xz.png" onclick="btnThucHien_Click" /></td>
                </tr>
            </table>
        </div>
        <div class="listlink">
	        <asp:Literal ID="ltrGia" runat="server"></asp:Literal>
        </div>
        <div class="clearfix"></div>
        <asp:Repeater ID="rptMaTruong" runat="server">
        <ItemTemplate>
            <asp:Literal runat="server" ID="ltrDiv"></asp:Literal>            
	            <div class="ts-col-code bold pink"><asp:Literal runat="server" ID="ltrMaTruong"></asp:Literal></div>
                <div class="ts-col-title"><asp:Literal runat="server" ID="ltrTenTruong"></asp:Literal></div>
            </div>
        </ItemTemplate>
        </asp:Repeater>
        <div class="clearfix"></div>
    </div>
    <%--end Content here--%>
    <uc2:DanhMucDichVu ID="DanhMucDichVu1" runat="server" />
    <uc1:Links ID="Links1" runat="server" />    
    <uc3:Footer ID="Footer4" runat="server" />
    </form>
</body>
</html>
