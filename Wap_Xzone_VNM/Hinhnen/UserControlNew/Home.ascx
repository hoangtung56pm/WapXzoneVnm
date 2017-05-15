<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControlNew.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
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
                        <asp:Literal ID="litTaiNhieuNhat" runat="server"></asp:Literal>
                    </td>
                    <td align="left" valign="top" background="/imagesnew/bgrtop2.gif">
                        <img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left" valign="top" bgcolor="#ECECEC">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <asp:Repeater ID="rptTaiNhieuNhat1" runat="server">
                        <ItemTemplate>
                            <td rowspan="2" bgcolor="ececec">
                                &nbsp;
                            </td>
                            <td align="center" valign="top" bgcolor="ececec">
                                <table width="90" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <a href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                                            <img alt="" src="<%# AppEnv.GetAvatar(Eval("WThumnail").ToString(),85,85) %>" width="85"
                                                                height="85" hspace="3" vspace="3" />
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                    <td rowspan="2" bgcolor="ececec">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <asp:Repeater ID="rptTaiNhieuNhat11" runat="server">
                        <ItemTemplate>
                            <td align="center" valign="middle" bgcolor="ececec" class="style2">
                                <a class="link-non-black" href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                    <%# AppEnv.CheckLang(Eval("WTitle_Unicode").ToString())%>
                                </a>
                                <br />
                                <strong><a class="link-non-black" href="<%# UrlProcess.GetWallpaperDownloadUrlNew(lang.ToString(),width,Eval("W_WItemID").ToString(),Eval("W_CategoryID").ToString()) %>">
                                    <%= AppEnv.CheckLang("Tải") %>
                                </a> </strong>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <tr>
                    <td colspan="7" align="left" valign="top" bgcolor="c3c3c3">
                        <img alt="" src="/imagesnew/blank.gif" width="16" height="1" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ECECEC">
                <tr>
                    <td align="left" valign="top">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <asp:Repeater ID="rptTaiNhieuNhat2" runat="server">
                        <ItemTemplate>
                            <td rowspan="2" bgcolor="ececec">
                                &nbsp;
                            </td>
                            <td align="center" valign="top" bgcolor="ececec">
                                <table width="90" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <a href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                                            <img alt="" src="<%# AppEnv.GetAvatar(Eval("WThumnail").ToString(),85,85) %>" width="85"
                                                                height="85" hspace="3" vspace="3" />
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                    <td rowspan="2" bgcolor="ececec">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <asp:Repeater ID="rptTaiNhieuNhat22" runat="server">
                        <ItemTemplate>
                            <td align="center" valign="middle" bgcolor="ececec" class="style2">
                                <a class="link-non-black" href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                    <%# AppEnv.CheckLang(Eval("WTitle_Unicode").ToString())%>
                                </a>
                                <br />
                                <strong><a class="link-non-black" href="<%# UrlProcess.GetWallpaperDownloadUrlNew(lang.ToString(),width,Eval("W_WItemID").ToString(),Eval("W_CategoryID").ToString()) %>">
                                    <%= AppEnv.CheckLang("Tải") %>
                                </a> </strong>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <tr>
                    <td colspan="7" align="left" valign="top" bgcolor="c3c3c3">
                        <img alt="" src="/imagesnew/blank.gif" width="16" height="1" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--Tai nhieu nhat--%>
<div class="clear5px">
</div>
<uc1:Paging ID="Paging1" runat="server" />
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
                        <asp:Literal ID="litMoiCapNhat" runat="server"></asp:Literal>
                    </td>
                    <td align="left" valign="top" background="/imagesnew/bgrtop2.gif">
                        <img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left" valign="top" bgcolor="#ECECEC">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <asp:Repeater ID="rptMoiCapNhat1" runat="server">
                        <ItemTemplate>
                            <td rowspan="2" bgcolor="ececec">
                                &nbsp;
                            </td>
                            <td align="center" valign="top" bgcolor="ececec">
                                <table width="90" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <a href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                                            <img alt="" src="<%# AppEnv.GetAvatar(Eval("WThumnail").ToString(),85,85) %>" width="85"
                                                                height="85" hspace="3" vspace="3" />
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                    <td rowspan="2" bgcolor="ececec">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <asp:Repeater ID="rptMoiCapNhat11" runat="server">
                        <ItemTemplate>
                            <td align="center" valign="middle" bgcolor="ececec" class="style2">
                                <a class="link-non-black" href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                    <%# AppEnv.CheckLang(Eval("WTitle_Unicode").ToString())%>
                                </a>
                                <br />
                                <strong><a class="link-non-black" href="<%# UrlProcess.GetWallpaperDownloadUrlNew(lang.ToString(),width,Eval("W_WItemID").ToString(),Eval("W_CategoryID").ToString()) %>">
                                    <%= AppEnv.CheckLang("Tải") %>
                                </a> </strong>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <tr>
                    <td colspan="7" align="left" valign="top" bgcolor="c3c3c3">
                        <img alt="" src="/imagesnew/blank.gif" width="16" height="1" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ECECEC">
                <tr>
                    <td align="left" valign="top">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <asp:Repeater ID="rptMoiCapNhat2" runat="server">
                        <ItemTemplate>
                            <td rowspan="2" bgcolor="ececec">
                                &nbsp;
                            </td>
                            <td align="center" valign="top" bgcolor="ececec">
                                <table width="90" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <a href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                                            <img alt="" src="<%# AppEnv.GetAvatar(Eval("WThumnail").ToString(),85,85) %>" width="85"
                                                                height="85" hspace="3" vspace="3" />
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <tr>
                    <asp:Repeater ID="rptMoiCapNhat22" runat="server">
                        <ItemTemplate>
                            <td align="center" valign="middle" bgcolor="ececec" class="style2">
                                <a class="link-non-black" href="<%# UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(),"detail",width,Eval("W_WItemID").ToString()) %>">
                                    <%# AppEnv.CheckLang(Eval("WTitle_Unicode").ToString())%>
                                </a>
                                <br />
                                <strong><a class="link-non-black" href="<%# UrlProcess.GetWallpaperDownloadUrlNew(lang.ToString(),width,Eval("W_WItemID").ToString(),Eval("W_CategoryID").ToString()) %>">
                                    <%= AppEnv.CheckLang("Tải") %>
                                </a> </strong>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <tr>
                    <td colspan="7" align="left" valign="top" bgcolor="c3c3c3">
                        <img alt="" src="/imagesnew/blank.gif" width="16" height="1" />
                    </td>
                </tr>
            </table>
            <div class="clear5px">
            </div>
            <uc1:Paging ID="Paging2" runat="server" />
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
<%--Moi Cap nhat--%>
