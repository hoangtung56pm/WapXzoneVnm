<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Clip.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlNew.Clip" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>
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
                        Clip<span class="style5"> &gt;&gt;<asp:HyperLink CssClass="link-non-white" ID="lnkXemThem" runat="server" EnableViewState="false" ><%= AppEnv.CheckLang("Xem thêm") %></asp:HyperLink></span>
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
            <asp:Repeater ID="rptVideo" runat="server" EnableViewState="false">
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
                                                        <a href="<%# UrlProcess.GetVideoDetailUrlNew(lang.ToString(),"detail",width.ToString(),Eval("W_VItemID").ToString()) %>">
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
                                    <a class="link-non-orange" href="<%# UrlProcess.GetVideoDetailUrlNew(lang.ToString(),"detail",width.ToString(),Eval("W_VItemID").ToString()) %>">
                                        <%# AppEnv.CheckLang(ConvertUtility.ToString(Eval("VTitle_Unicode")))%>
                                    </a>
                                </span>
                                <br />
                                <%= AppEnv.CheckLang("Thể loại") %>: <%# AppEnv.CheckLang(ConvertUtility.ToString(Eval("Web_Name")))%><br />
                                <strong>
                                    <a class="link-non-black" href="<%# UrlProcess.GetVideoDownloadUrlNew(lang.ToString(),width.ToString(),Eval("W_VItemID").ToString()) %>">
                                        <img alt="" src="/imagesnew/icon/down.png" /> <%= AppEnv.CheckLang("Tải") %>
                                    </a> 

                                    | 

                                    <a class="link-non-black" href="<%# UrlProcess.GetVideoViewUrlNew(lang.ToString(),width.ToString(),Eval("W_VItemID").ToString()) %>"> 
                                         <img alt="" src="/imagesnew/icon/eyes.png" /> <%= AppEnv.CheckLang("Xem") %> 
                                    </a> 
                                </strong>
                            </td>
                            <td align="left" valign="top">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="90" />
                            </td>
                        </tr>
                    </table>
                  <asp:Literal ID="litTable" runat="server" EnableViewState="false"></asp:Literal>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>

</table>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="20" />
                    </td>
                    <td width="125%" align="left" valign="middle">
                        <span class="style11">(<%= AppEnv.CheckLang("Giá") %>: <%= AppEnv.GetSetting("videoprice")%> <%= AppEnv.CheckLang("đ") %>/video)</span>
                    </td>
                </tr>
            </table>

            
