<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControlNew.Detail" %>
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
                        <asp:HyperLink ID="lnkHomeChannel" CssClass="link-non-white font12px" runat="server" EnableViewState="False">TIN TUC</asp:HyperLink> <span class="style5"> » <asp:HyperLink CssClass="link-non-white font12px" ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink></span>
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
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="8" align="left" valign="top">
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="90" />
                    </td>
                    <td align="left" valign="top">
                        <p>
                            <span class="style4">
                               <asp:Label ID="lblHeadline" runat="server" EnableViewState="False"></asp:Label>
                            </span>
                            
                            <br />
                         </p>

                         <span class="style10 text-align-justify">
                            <asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label><br />
                            <asp:Literal ID="ltrBody" runat="server" EnableViewState="False"></asp:Literal>
                         </span>
                    </td>
                    <td align="left" valign="top">
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="90" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top">
                        <img alt="" src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>
            <%--Tin lien quan--%>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                
                <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                    <td width="8" align="left" valign="middle">
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="12" />
                    </td>
                    <td width="8" align="left" valign="middle">
                        <img alt="" src="/imagesnew/arrow.jpg" width="8" height="7" />
                    </td>
                    <td width="8" align="left" valign="middle">
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="12" />
                    </td>
                    <td width="125%" align="left" valign="middle" class="style12">
                        <asp:HyperLink CssClass="link-non-black" ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                    </td>
                </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
            <%--End Tin lien quan--%>

            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td align="left" valign="top">
                        <img src="/imagesnew/blank.gif" width="5" height="9" />
                    </td>
                </tr>
            </table>

        </td>
    </tr>
</table>
