<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastestNews.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControlNew.LastestNews" %>

<%@ Register src="Category.ascx" tagname="Category" tagprefix="uc1" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><asp:Label ID="lblTitle" runat="server" EnableViewState="False">CHU DE HOT</asp:Label><span class="style5"></span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF"><img src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">
        <tr>
          <td width="8" align="left" valign="top"><img src="/imagesnew/blank.gif" width="8" height="55" /></td>
          <td width="125%" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="style10">
                    <asp:Literal ID="ltrDangKy" runat="server" EnableViewState="False"></asp:Literal>
                 </td>
              </tr>
              <tr>
                <td align="left" valign="top" class="style12_XoSo"><img src="/imagesnew/blank.gif" width="5" height="5" /></td>
              </tr>
              <tr>
                <td align="left" valign="top"><table width="65" border="0" cellpadding="1" cellspacing="1" background="/imagesnew/bgrbt.jpg">
                    <tr>
                      <td align="center" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top"><img src="/imagesnew/blank.gif" width="2" height="20" /></td>
                            <td width="125%" align="center" valign="middle" class="style13_XoSo">
                                <asp:HyperLink ID="lnkDangKy" CssClass="link-non-black" runat="server" EnableViewState="False"></asp:HyperLink>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table>                  </td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td height="1" colspan="2" align="left" valign="top" bgcolor="#CCCCCC"><span class="style12_XoSo"><img src="/imagesnew/blank.gif" width="5" height="1" /></span></td>
        </tr>
      </table>
    </td>
  </tr>
</table> <%--Thu Gian--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
    <td width="125%" align="left" valign="middle" class="style11">
         <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>
    </td>
  </tr>
</table>

<uc1:Category ID="Category1" runat="server" EnableViewState="False" />
