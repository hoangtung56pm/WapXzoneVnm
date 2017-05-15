<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RTHot.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlNew.RTHot" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="left" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td background="/imagesnew/bgrtop2.gif">
                        <img src="/imagesnew/blank.gif" width="5" height="10" />
                    </td>
                    <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif"
                        class="style1">
                        <%= AppEnv.CheckLang("Nhạc Hot") %>
                        <span class="style5">&gt; <a class="link-non-white" href="<%= UrlProcess.GetMusicHomeUrlNew(lang.ToString(),width) %>">
                            <%= AppEnv.CheckLang("Xem thêm") %></a> </span>
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
            <asp:Repeater ID="rptMusic" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrgame.gif">
                        <tr>
                            <td width="8" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="30" />
                            </td>
                            <td width="36" align="left" valign="top">
                                <img alt="" src="/imagesnew/iconnhac.jpg" width="15" height="14" />
                            </td>
                            <td width="20" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="5" height="10" />
                            </td>
                            <td width="125%" align="left" valign="top" class="style2">
                                <span class="style4"><a class="link-non-orange" href="<%# UrlProcess.GetMusicDetailUrlNew(lang.ToString(),width,Eval("W_MItemID").ToString()) %>">
                                    <%# AppEnv.CheckLang(Eval("SongNameUnicode").ToString())%>
                                </a></span>
                                <br />
                                <%= AppEnv.CheckLang("Ca sỹ") %>:
                                <%# AppEnv.CheckLang(Eval("ArtistNameUnicode").ToString())%>
                                <br />
                                <strong><a class="link-non-black" href="<%# UrlProcess.GetMusicDownloadUrlNew(lang.ToString(),width,Eval("W_MItemID").ToString()) %>">
                                    <%= AppEnv.CheckLang("Tải") %>
                                </a></strong>
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
                        <span class="style11">
                            <asp:Literal ID="litGia" runat="server" EnableViewState="false"></asp:Literal>
                        </span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
