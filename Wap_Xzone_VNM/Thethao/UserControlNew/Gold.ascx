<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gold.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlNew.Gold" %>


<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><asp:Literal ID="ltrTitle" runat="server" EnableViewState="False">TIEU DIEM THE THAO</asp:Literal>
            <span class="style5"><asp:HyperLink ID="lnkCacTinKhac" CssClass="link-non-white" runat="server" EnableViewState="False">» Cac tin khac</asp:HyperLink></span>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="left" valign="top" bgcolor="ededed"><img alt="" src="/imagesnew/blank.gif" width="8" height="10" /></td>
            <td width="125%" align="left" valign="top" bgcolor="ededed"><table width="82" border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                  <td><table width="90" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                            <tr>
                              <td bgcolor="#EDEDED">
                                    <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False">
                                        <asp:Image ID="imgAvatar" Width="82" runat="server" EnableViewState="False" alt="thumb" />
                                    </asp:HyperLink>
                              </td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                  <td width="10" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="10" height="10" /></td>
                </tr>
              </table>
                <span class="style4"><asp:HyperLink ID="lnkTitle" CssClass="link-non-orange" runat="server" EnableViewState="False"></asp:HyperLink>
                    <br />
                </span>

                <span class="style2"><asp:Literal ID="litTeaser" runat="server" EnableViewState="false"></asp:Literal></span>
                
                <span class="style4"><br /></span></td>
            <td align="left" valign="top" bgcolor="ededed"><img alt="" src="/imagesnew/blank.gif" width="15" height="10" /></td>
          </tr>
          <tr>
            <td colspan="3" align="left" valign="top" bgcolor="#EDEDED"><img alt="" src="/imagesnew/blank.gif" width="8" height="10" /></td>
          </tr>
          <tr>
            <td colspan="3" align="left" valign="top" bgcolor="c3c3c3"><img alt="" src="/imagesnew/blank.gif" width="9" height="1" /></td>
          </tr>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
          <tr>
            <td align="left" valign="top" bgcolor="#EDEDED"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
          </tr>
      </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          
          <asp:Repeater ID="rptNewLastest" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <asp:Panel ID="othernews" runat="server" EnableViewState="False">
                        <tr>
                            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="12" /></td>
                            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/arrow.jpg" width="8" height="7" /></td>
                            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="12" /></td>
                            <td width="125%" align="left" valign="middle" class="style12">
                                <asp:HyperLink ID="lnkTitlelist" CssClass="link-non-black" runat="server" EnableViewState="False"></asp:HyperLink>
                            </td>
                        </tr>
                    </asp:Panel>
                </ItemTemplate>
          </asp:Repeater>
        </table>
    </td>
  </tr>
</table> <%--Tieu diem the thao--%>

<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#DCDCDC">
  <tr>
    <td colspan="2"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
  <tr>
    <td colspan="2" align="center" valign="top">
        <asp:HyperLink ID="lnkTuVanDacBiet" runat="server" EnableViewState="False">
            <img alt="" src="/imagesnew/i-tuvan87.gif" width="204" height="28" />
        </asp:HyperLink>
    </td>
  </tr>
  <tr>
    <td colspan="2"><img alt="" src="/imagesnew/blank.gif" width="5" height="5" /></td>
  </tr>
  <tr>
    <td colspan="2" align="center" valign="top">
        <asp:HyperLink ID="lnkTranCauVang" runat="server" EnableViewState="False">
            <img alt="" src="/imagesnew/i-trancauvang.gif" width="204" height="28" />
        </asp:HyperLink>
    </td>
  </tr>
  <tr>
    <td colspan="2"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
  <tr>
    <td><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
    <td width="125%">
        <p class="style2"><asp:Literal ID="ltrDangKy" runat="server" EnableViewState="False"></asp:Literal><br />
        <span class="style4"><asp:HyperLink ID="lnkDangKy" CssClass="link-non-orange" runat="server" EnableViewState="False">» Dang ky «</asp:HyperLink></span> 
        </p>
    </td></tr></table> <%--Tran cau vang--%>

