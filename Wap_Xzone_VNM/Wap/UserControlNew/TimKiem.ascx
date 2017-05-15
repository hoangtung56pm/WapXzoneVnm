<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimKiem.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlNew.TimKiem" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
    <tr>
        <td width="5" align="left" valign="top">
            <img alt="" src="/imagesnew/blank.gif" width="5" height="25" />
        </td>
        <td align="left" valign="middle">
            <label>
                <asp:TextBox ID="txtKey" runat="server" EnableViewState="false"></asp:TextBox>
            </label>
        </td>
        <td width="5" align="left" valign="middle">
            <img alt="" src="/imagesnew/blank.gif" width="5" height="10" />
        </td>
        <td align="left" valign="middle">
            <label>
                <asp:DropDownList ID="dgrCategory" runat="server">
                    <asp:ListItem Value="1">Nhạc</asp:ListItem>
                    <asp:ListItem Value="2">Hình nền</asp:ListItem>
                    <asp:ListItem Value="3">Game</asp:ListItem>
                    <asp:ListItem Value="4">Ứng dụng</asp:ListItem>
                    <asp:ListItem Value="5">Video</asp:ListItem>
                </asp:DropDownList>
            </label>
        </td>
        <td width="5" align="left" valign="middle">
            <img alt="" src="/imagesnew/blank.gif" width="5" height="10" />
        </td>
        <td width="125%" align="left" valign="middle">
            <asp:ImageButton runat="server" ID="btnSearch" ImageUrl="/imagesnew/search.png" Width="16"
                Height="15" OnClick="btnSearch_Click"></asp:ImageButton>
        </td>
    </tr>
</table>
