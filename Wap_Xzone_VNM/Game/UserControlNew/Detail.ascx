<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Game.UserControlNew.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
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
                        <asp:HyperLink ID="lnkHomeChannel" runat="server" CssClass="link-non-white" EnableViewState="False">GAME</asp:HyperLink>
                        »
                        <asp:HyperLink ID="lnkCateChannel" runat="server" CssClass="link-non-white" EnableViewState="False"></asp:HyperLink>
                    </td>
                    <td align="left" valign="top" background="/imagesnew/bgrtop2.gif">
                        <img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left" valign="top">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="8" rowspan="2" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="66" />
                            </td>
                            <td width="36" rowspan="2" align="left" valign="top">
                                <table width="36" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <img alt="" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),120,141) %>" width="120"
                                                            height="141" hspace="3" vspace="3" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20" rowspan="2" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="20" height="10" />
                            </td>
                            <td width="125%" align="left" valign="top" class="style2">
                                <span class="style4">
                                    <%# AppEnv.CheckLang(Eval("GameNameUnicode").ToString())%></span><br />
                                <%= AppEnv.CheckLang("Thể loại") %>:
                                <%# AppEnv.CheckLang(Eval("Web_Name").ToString()) %><br />
                                <%= AppEnv.CheckLang("Giá") %>:
                                <%= Price %> <%= AppEnv.CheckLang("đ") %><br />
                                <%= AppEnv.CheckLang("Giới thiệu") %>:
                                <%# AppEnv.CheckLang(Eval("DescriptionUnicode").ToString())%>
                            </td>
                            <td rowspan="2" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="5" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="style2">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25" align="left" valign="top">
                                            <%--<img alt="" src="/imagesnew/icon/down.png" />--%>
                                        </td>
                                        <td>
                                            <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                                        </td>
                                        <td width="125%" align="left" valign="middle">
                                            <strong>
                                                <asp:HyperLink CssClass="link-non-black" ID="lnkTai" runat="server" EnableViewState="False">
                                                </asp:HyperLink>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="f5f5f5">
                <tr>
                    <td align="left" valign="top" bgcolor="#EBE9E6">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
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
                        <%= AppEnv.CheckLang("Game cùng thể loại") %>
                        <span class="style5"></span>
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
            <asp:Repeater ID="rptGameCungLoai" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrgame.gif">
                        <tr>
                            <td width="8" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="66" />
                            </td>
                            <td width="36" align="left" valign="top">
                                <table width="36" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <a href="<%# UrlProcess.GetGameDetailUrlNew(lang.ToString(),"detail",width,Eval("W_GameItemID").ToString(),hotro.ToString()) %>">
                                                            <img alt="" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),36,48) %>" width="36"
                                                            height="48" hspace="3" vspace="3" />
                                                         </a>
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
                                    <a href="<%# UrlProcess.GetGameDetailUrlNew(lang.ToString(),"detail",width,Eval("W_GameItemID").ToString(),hotro) %>" class="link-non-orange"><%# AppEnv.CheckLang(Eval("GameNameUnicode").ToString())%></a>
                                    </span><br />
                                <%= AppEnv.CheckLang("Thể loại") %>:
                                <%# AppEnv.CheckLang(Eval("Web_Name").ToString())%><br />
                                <strong>
                                    <asp:HyperLink CssClass="link-non-black" ID="lnkTai" runat="server" EnableViewState="False">
                                    </asp:HyperLink>
                                </strong>
                            </td>
                            <td align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="5" />
                            </td>
                        </tr>
                    </table>
                    <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>
                </ItemTemplate>
            </asp:Repeater>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="20" />
                    </td>
                    <td width="125%" align="left" valign="middle">
                        <span class="style11">(<%= AppEnv.CheckLang("Giá") %>: <%= AppEnv.GetSetting("gameprice")%> <%= AppEnv.CheckLang("đ") %>/game)</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--Game cung the loai--%>