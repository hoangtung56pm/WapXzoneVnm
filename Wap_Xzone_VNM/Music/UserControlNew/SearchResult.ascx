<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs"Inherits="WapXzone_VNM.Music.UserControlNew.SearchResult" %>
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
                        <asp:Literal ID="ltrKetQua" runat="server" EnableViewState="False">KẾT QUẢ TÌM KIẾM</asp:Literal> : 
                        <asp:Literal ID="ltrAlbumName" runat="server" EnableViewState="False"></asp:Literal>
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
            <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="8" align="left" valign="middle">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="25" />
                            </td>
                            <td colspan="3" align="left" valign="middle">
                                <span class="style4"><strong class="style4"><asp:Literal ID="ltrBaihat" runat="server" EnableViewState="False"></asp:Literal></strong></span>
                                <span class="style10"><br />
                                    <asp:Literal ID="ltrTheLoai" runat="server" EnableViewState="False"></asp:Literal><br />
                                    <asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal><br />
                                    <asp:HyperLink CssClass="link-non-black" ID="lnkTai" runat="server" EnableViewState="False"></asp:HyperLink>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left" valign="middle">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="5" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" valign="top" bgcolor="c3c3c3">
                                <img alt="" src="/imagesnew/blank.gif" width="8" height="1" />
                            </td>
                        </tr>
                    </table>

                </ItemTemplate>
            </asp:Repeater>
            
            <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <img alt="" src="/imagesnew/blank.gif" width="8" height="20" />
                    </td>
                    <td width="125%" align="left" valign="middle">
                        <span class="style11">(<asp:Literal ID="ltrMota" runat="server" EnableViewState="False"></asp:Literal>
                            <asp:Literal ID="ltrSobai" runat="server" EnableViewState="False"></asp:Literal>)
                        </span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
