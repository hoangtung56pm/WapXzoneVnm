<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotHome.ascx.cs" Inherits="WapXzone_VNM.Xoso.UserControlNew.LotHome" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="SelectedDate.ascx" TagName="SelectedDate" TagPrefix="uc1" %>
<uc1:SelectedDate Visible="true" ID="SelectedDate1" runat="server" />

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Các tỉnh mở thưởng") %></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
       
        <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">

        <tr>
          <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="55" /></td>
          <td width="125%" align="left" valign="top">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="6"><span class="style12_XoSo">
                    <asp:HyperLink CssClass="link-non-black" ID="lnkThudo" runat="server" EnableViewState="False">Thu do</asp:HyperLink>
                </span></td>
              </tr>
              <tr>
                <td colspan="6" align="left" valign="top" class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="5" /></td>
              </tr>
              <tr>
                <td width="65" align="left" valign="top"><table width="65" border="0" cellpadding="1" cellspacing="1" background="/imagesnew/bgrbt.jpg">
                    <tr>
                      <td align="center" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="2" height="20" /></td>
                            <td width="125%" align="center" valign="middle" class="style13_XoSo">
                                <asp:HyperLink CssClass="link-non-black" ID="lnkKQCho" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
                <td width="5" align="left" valign="top"><span class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></span></td>
                <td width="65" align="left" valign="top"><table width="65" border="0" cellpadding="1" cellspacing="1" background="/imagesnew/bgrbt.jpg">
                    <tr>
                      <td align="center" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="2" height="20" /></td>
                            <td width="125%" align="center" valign="middle" class="style13_XoSo">
                                <asp:HyperLink CssClass="link-non-black" ID="lnkSoiCau" runat="server" EnableViewState="False" Text="Soi cau"></asp:HyperLink>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
                <td width="5" align="left" valign="top"><span class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></span></td>
                <td width="65" align="left" valign="top"><table width="65" border="0" cellpadding="1" cellspacing="1" background="/imagesnew/bgrbt.jpg">
                    <tr>
                      <td align="center" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="2" height="20" /></td>
                            <td width="125%" align="center" valign="middle" class="style13_XoSo">
                                <asp:HyperLink ID="lnkxemkq" CssClass="link-non-black" runat="server" EnableViewState="False" Text="KQ"></asp:HyperLink>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
                <td align="left" valign="top">&nbsp;</td>
              </tr>
          </table>

          <asp:Panel ID="pnlXsThuDo" runat="server">
            <div class="clear5px"></div>
            <div align="left">
                <a class="link-non-orange" href="<%= UrlProcess.GetS2RegisterXoSoUrl(lang.ToString(),width,"1") %>"><%= AppEnv.CheckLang("Nhận KQXS hàng ngày (500đ/ngày)") %></a>
            </div>
          </asp:Panel>

          <div class="clear5px"></div>


          </td>
        </tr>
        <tr>
          <td height="1" colspan="2" align="left" valign="top" bgcolor="#CCCCCC"><span class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="1" /></span></td>
        </tr>
      </table>

      <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
        <tr>
          <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
        </tr>
      </table>
        
       <asp:Repeater ID="rptlst" runat="server" EnableViewState="false">
            <ItemTemplate>
                
                 <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">

        <tr>
          <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="55" /></td>
          <td width="125%" align="left" valign="top">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="6"><span class="style12_XoSo">
                    <asp:HyperLink CssClass="link-non-black" ID="lnkCity" NavigateUrl="#" runat="server" EnableViewState="False"></asp:HyperLink>
                </span></td>
              </tr>
              <tr>
                <td colspan="6" align="left" valign="top" class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="5" /></td>
              </tr>
              <tr>
                <td width="65" align="left" valign="top"><table width="65" border="0" cellpadding="1" cellspacing="1" background="/imagesnew/bgrbt.jpg">
                    <tr>
                      <td align="center" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="2" height="20" /></td>
                            <td width="125%" align="center" valign="middle" class="style13_XoSo">
                                <asp:HyperLink CssClass="link-non-black" ID="lnkkqc" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
                <td width="5" align="left" valign="top"><span class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></span></td>
                <td width="65" align="left" valign="top"><table width="65" border="0" cellpadding="1" cellspacing="1" background="/imagesnew/bgrbt.jpg">
                    <tr>
                      <td align="center" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="2" height="20" /></td>
                            <td width="125%" align="center" valign="middle" class="style13_XoSo">
                                <asp:HyperLink CssClass="link-non-black" ID="lnksc" runat="server" EnableViewState="False" Text="Soi cau"></asp:HyperLink>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
                <td width="5" align="left" valign="top"><span class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></span></td>
                <td width="65" align="left" valign="top"><table width="65" border="0" cellpadding="1" cellspacing="1" background="/imagesnew/bgrbt.jpg">
                    <tr>
                      <td align="center" valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="2" height="20" /></td>
                            <td width="125%" align="center" valign="middle" class="style13_XoSo">
                                <asp:HyperLink CssClass="link-non-black" ID="lnkxkq" runat="server" EnableViewState="False" Text="KQ"></asp:HyperLink>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
                <td align="left" valign="top">&nbsp;</td>
              </tr>
          </table>

          <asp:Panel ID="pnlXsList" runat="server">
          <div class="clear5px"></div>
            <div align="left">
                <asp:HyperLink ID="lnkS2DangKy" CssClass="link-non-orange" runat="server" EnableViewState="false"></asp:HyperLink>
          </div>
          </asp:Panel>

          <div class="clear5px"></div>

          </td>
        </tr>
        <tr>
          <td height="1" colspan="2" align="left" valign="top" bgcolor="#CCCCCC"><span class="style12_XoSo"><img alt="" src="/imagesnew/blank.gif" width="5" height="1" /></span></td>
        </tr>
      </table>


                 <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>

            </ItemTemplate>
       </asp:Repeater>

    </td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
    <td width="125%" align="left" valign="middle" class="style11"> (<%= AppEnv.CheckLang("Giá") %>: <%= AppEnv.CheckLang("KQ chờ") %> <%= AppEnv.GetSetting("kqchoxsprice")%> đ, <%= AppEnv.CheckLang("Soi cầu") %> <%= AppEnv.GetSetting("xssoicauprice")%> đ, <%= AppEnv.CheckLang("Kết quả") %> <%= AppEnv.GetSetting("kqxsprice")%> đ) </td>
  </tr>
</table>