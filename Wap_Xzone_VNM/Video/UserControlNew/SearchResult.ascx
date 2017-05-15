<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs"Inherits="WapXzone_VNM.Video.UserControlNew.SearchResult" %>
<%@ Register Src="Pagging.ascx" TagName="Paging" TagPrefix="uc1" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="left" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td background="/imagesnew/bgrtop2.gif">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="10" />
                    </td>
                    <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif"
                        class="style1">
                        <asp:Literal ID="ltrTenChuyenMuc" runat="server" EnableViewState="False">KET QUA TIM KIEM</asp:Literal>
                    </td>
                    <td align="left" valign="top" background="/imagesnew/bgrtop2.gif">
                        <img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="rptResult" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">
                        <tr>
                            <td width="8" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="90" />
                            </td>
                            <td width="82" align="left" valign="top">
                                <table width="90" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False">
                                                            <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="82" Height="66" />
                                                        </asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="20" height="10" />
                            </td>
                            <td width="125%" align="left" valign="top" class="style2">
                                <span class="style4">
                                    <asp:HyperLink CssClass="link-non-orange" ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                                </span>
                                <br />
                                <asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False"></asp:Literal><br />
                                <asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal><br />
                                <strong>
                                    <asp:HyperLink ID="lnkTai" CssClass="link-non-black" runat="server" EnableViewState="False">Tải</asp:HyperLink>
                                    I
                                    <asp:HyperLink ID="lnkXem" CssClass="link-non-black" runat="server" EnableViewState="False">Xem</asp:HyperLink>
                                </strong>
                            </td>
                            <td align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="90" />
                            </td>
                        </tr>
                    </table>
                    <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>
                </ItemTemplate>
            </asp:Repeater>
            <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="20" />
                    </td>
                    <td width="125%" align="left" valign="middle">
                        <span class="style11">(<asp:Literal ID="ltrCount" runat="server" EnableViewState="False"></asp:Literal>)</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
