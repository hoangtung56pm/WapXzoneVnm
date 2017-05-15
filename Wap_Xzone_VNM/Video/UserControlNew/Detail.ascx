<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlNew.Detail" %>
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
                        <asp:HyperLink ID="lnkHomeChannel" CssClass="link-non-white" runat="server" EnableViewState="False">VIDEO</asp:HyperLink>
                        <span class="style5">»
                            <asp:HyperLink ID="lnkCateChannel" CssClass="link-non-white" runat="server" EnableViewState="False"></asp:HyperLink></span>
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
            <asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">
                        <tr>
                            <td width="8" rowspan="2" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="90" />
                            </td>
                            <td width="82" rowspan="2" align="left" valign="top">
                                <table width="90" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="c6c6c6">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td bgcolor="#EDEDED">
                                                        <img alt="" src="<%# AppEnv.GetAvatar(Eval("VThumnail").ToString(),82,66) %>" width="82"
                                                            height="66" hspace="3" vspace="3" />
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
                                    <%# AppEnv.CheckLang(Eval("VTitle_Unicode").ToString())%></span><br />
                                <%= AppEnv.CheckLang("Giá") %>: <%= AppEnv.GetSetting("videoprice")%> <%= AppEnv.CheckLang("đ") %>
                            </td>
                            <td rowspan="2" align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="90" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="style2">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25" align="left" valign="top">
                                            <%--<img alt="" src="/imagesnew/Devices-video-television-icon.png" width="24" height="24" />--%>
                                            <img alt="" src="/imagesnew/icon/eyes.png" />
                                        </td>
                                        <td>
                                            <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                                        </td>
                                        <td width="125%" align="left" valign="middle">
                                            <strong>
                                                <a href="<%# UrlProcess.GetVideoViewUrlNew(lang.ToString(),width,Eval("W_VItemID").ToString()) %>" class="link-non-black">
                                                Xem trực tuyến
                                                </a> 
                                            </strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <%--<img alt="" src="/imagesnew/Sign-Download-icon.png" width="25" height="25" />--%>
                                            <img alt="" src="/imagesnew/icon/down.png" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="left" valign="middle">
                                            <strong>
                                                <a href="<%# UrlProcess.GetVideoDownloadUrlNew(lang.ToString(),width,Eval("W_VItemID").ToString()) %>" class="link-non-black">Tải</a>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td align="left" valign="top">
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
                        <%= AppEnv.CheckLang("Các video khác") %>
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
            <asp:Repeater ID="rptVideoCungLoai" runat="server" EnableViewState="false">
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
                                                        <a href="<%# UrlProcess.GetVideoDetailUrlNew(lang.ToString(),"detail",width,Eval("W_VItemID").ToString()) %>">
                                                            <img alt="" src="<%# AppEnv.GetAvatar(Eval("VThumnail").ToString(),82,66) %>" width="82" height="66" hspace="3" vspace="3" />
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
                                    <a class="link-non-orange" href="<%# UrlProcess.GetVideoDetailUrlNew(lang.ToString(),"detail",width,Eval("W_VItemID").ToString()) %>">
                                        <%# AppEnv.CheckLang(Eval("VTitle_Unicode").ToString())%>
                                    </a>
                                </span><br />
                                <%= AppEnv.CheckLang("Thể loại") %>: <%# AppEnv.CheckLang(Eval("Web_Name").ToString())%><br />
                                <strong>
                                    <a class="link-non-black" href="<%# UrlProcess.GetVideoDownloadUrlNew(lang.ToString(),width,Eval("W_VItemID").ToString()) %>">
                                        <img alt="" src="/imagesnew/icon/down.png" /> <%= AppEnv.CheckLang("Tải") %>
                                    </a>

                                    |
                                    
                                    <a class="link-non-black" href="<%# UrlProcess.GetVideoViewUrlNew(lang.ToString(),width,Eval("W_VItemID").ToString()) %>"> 
                                        <img alt="" src="/imagesnew/icon/eyes.png" /> Xem
                                    </a>
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
