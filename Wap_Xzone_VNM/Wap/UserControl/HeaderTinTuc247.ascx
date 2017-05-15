<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderTinTuc247.ascx.cs"
    Inherits="WapXzone_VNM.Wap.UserControl.HeaderTinTuc247" %>
<%--<table style="width:100%;" border="0" cellpadding="0" cellspacing="0" background="/img/h_vl_bg.jpg" >--%>
<table style="width: 100%; background-color: #EBE9E6;" border="0" cellpadding="0"
    cellspacing="0">
    <tbody>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltrXinChao" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="height: 40px" align="center">
            </td>
        </tr>
       
    </tbody>
</table>
<div class="clearfix">
</div>
<%--<div class="mainmenu">
    <asp:HyperLink ID="lnkTrangChu" runat="server">Trang chủ</asp:HyperLink>
    |
    <asp:HyperLink ID="lnkGame" runat="server">Game</asp:HyperLink>
    |
    <asp:HyperLink ID="lnkNhac" Visible="false" runat="server">Nhạc</asp:HyperLink>
    
    <asp:HyperLink ID="lnkKetQua" runat="server">Bóng đá</asp:HyperLink>
    | <a href="/trangnhaccho/index.html">Nhạc chờ</a> | <a href="/Wap/DailyInfo.aspx?lang=<%= lang %>&w=<%= width %>">
        DailyInfo</a>
    <asp:HyperLink ID="lnkWap3g" Visible="false" runat="server">Wap 3G</asp:HyperLink>
</div>--%>
<div class="clearfix">
</div>
<%--<div class="sfrm" style="display: none;">
    <div class="sfrmtop">
        <div>
            <asp:TextBox ID="txtKeyword" CssClass="sfrminput inputx" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlDataType" CssClass="sfrminput input60" runat="server">
                <asp:ListItem Value="1" Text="Nhạc"></asp:ListItem>
                <asp:ListItem Value="2" Text="Hình nền"></asp:ListItem>
                <asp:ListItem Value="3" Text="Game"></asp:ListItem>
                <asp:ListItem Value="4" Text="Ứng dụng"></asp:ListItem>
                <asp:ListItem Value="5" Text="Video"></asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="btnSearch" ImageUrl="../../img/sfrm-icon.png" CssClass="sfrmsubmit"
                runat="server" OnClick="btnSearch_Click" CausesValidation="False" />
        </div>
    </div>
</div>--%>
