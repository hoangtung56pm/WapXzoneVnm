<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlNew.Header" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<div>
    <asp:Literal ID="ltrXinChao" runat="server"></asp:Literal>
</div>

<%--<table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrtop.gif">
    <tr>
        <td align="left" valign="top">
            <img alt="" src="/imagesnew/blank.gif" width="5" height="10" />
        </td>
        <td width="125%" align="left" valign="middle">
            <span class="style1">Vietnamobile</span>
        </td>
    </tr>
</table>--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="center" valign="top">
            <a class="noelbanner" href="http://wap.vietnamobile.com.vn">
                <img alt="" src="/imagesnew/banner.gif" width="193" height="37" />
            </a>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="ebe9e6">
    <tr>
        <td align="left" valign="top" bgcolor="babbbd">
            <img alt="" src="/imagesnew/blank.gif" width="16" height="1" />
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="33" align="left" valign="top">
                        <a href="/Wap/Default.aspx?lang=<%= lang %>&w=<%= width %>">
                            <img alt="" src="/imagesnew/home.jpg" width="33" height="25" />
                        </a>
                    </td>
                    <td class="style2">
                        <asp:Literal ID="litGame" runat="server"></asp:Literal>
                        |
                        <asp:Literal ID="litMusic" runat="server"></asp:Literal>
                        |
                        <asp:Literal ID="litClip" runat="server"></asp:Literal>
                    </td>
                    <td width="56" align="center" valign="middle" bgcolor="cacaca">
                        <span class="style2">
                            <a class="link-non-black" href="http://wap.vietnamobile.com.vn/Wap/Default.aspx?lang=<%= lang %>&w=<%= width %>">
                                Wap 2G
                            </a>
                         </span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
