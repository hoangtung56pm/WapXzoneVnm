<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlNew.List" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>
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

                        <asp:HyperLink ID="lnkHomeChannel" CssClass="link-non-white font12px" runat="server" EnableViewState="False">VIDEO</asp:HyperLink> » 
                        <span class="style5">
                            <asp:HyperLink CssClass="link-non-white font12px" ID="lnkCateChannel" runat="server" EnableViewState="False"></asp:HyperLink>
                        </span>

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
            <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="false">
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
                                                            <img alt="" src="<%# AppEnv.GetAvatar(ConvertUtility.ToString(Eval("VThumnail").ToString()),82,66) %>"
                                                                width="82" height="66" hspace="3" vspace="3" />
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
                                <%= AppEnv.CheckLang("Thể loại") %>:
                                <%# Eval("Web_Name")%><br />
                                <strong>
                                <a class="link-non-black" href="<%# UrlProcess.GetVideoDownloadUrlNew(lang.ToString(),width,Eval("W_VItemID").ToString()) %>">
                                    <img alt="" src="/imagesnew/icon/down.png" /> <%= AppEnv.CheckLang("Tải") %>
                                </a> 
                                I 
                                <a class="link-non-black" href="<%# UrlProcess.GetVideoViewUrlNew(lang.ToString(),width,Eval("W_VItemID").ToString()) %>">
                                    <img alt="" src="/imagesnew/icon/eyes.png" /> <%= AppEnv.CheckLang("Xem") %>
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
            <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
            <div class="clear5px"></div>

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