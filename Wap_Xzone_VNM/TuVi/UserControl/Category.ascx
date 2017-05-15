<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone.TuVi.UserControl.Category" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Label ID="lblTitle" runat="server">TỬ VI</asp:Label></div></div>
</div>
<div class="boxcontent">
    <asp:Label ID="ltrHuongdan" runat="server">Bạn hãy điền đầy đủ các thông tin sau:</asp:Label>
    <p>
        <asp:Label ID="lblNgaysinh" runat="server">Ngày sinh:</asp:Label><br />
        <asp:TextBox ID="txtNgay" Width="25" runat="server"></asp:TextBox> /
        <asp:TextBox ID="txtThang" Width="25" runat="server"></asp:TextBox> /
        <asp:TextBox ID="txtNam" Width="40" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblGioitinh" runat="server">Giới tính:</asp:Label>
        <br />
        <asp:DropDownList ID="ddlGioitinh" runat="server">
            <asp:ListItem Text="Nam" Value="9"></asp:ListItem>
            <asp:ListItem Text="Nữ" Value="10"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnXem" runat="server" Text="Xem" onclick="btnXem_Click" />
    </p>
    <asp:Label ForeColor="Red" ID="lblThongbao" runat="server" Visible="false"></asp:Label>
    <p><asp:Literal ID="ltrGia" runat="server">Giá dịch vụ: 3.000 VNĐ</asp:Literal></p>
</div>