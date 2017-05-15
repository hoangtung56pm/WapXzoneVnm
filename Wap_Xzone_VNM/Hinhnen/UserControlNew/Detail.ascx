<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControlNew.Detail" %>

<%@ Register Src="Pagging.ascx" TagName="Paging" TagPrefix="uc2" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            <asp:HyperLink CssClass="link-non-white" ID="lnkHomeChannel" runat="server">ANH</asp:HyperLink> » 
            <asp:HyperLink CssClass="link-non-white" ID="lnkCateChannel" runat="server"></asp:HyperLink>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
            <td width="82" align="left" valign="top"><table width="90" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                      <tr>
                        <td bgcolor="#EDEDED">
                            <asp:Image ID="imgDetail" runat="server" alt="thumb" Width="159" Height="127" />
                        </td>
                      </tr>
                  </table></td>
                </tr>
            </table></td>
            <td width="20" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="20" height="10" /></td>
            <td width="125%" align="left" valign="top" class="style2">
                    <span class="style4">
                        <asp:Literal ID="ltrTenAnh" runat="server"></asp:Literal>
                    </span><br />
                <span class="style10"><asp:Literal ID="ltrGiaTai" runat="server"></asp:Literal><br />
                <asp:HyperLink CssClass="link-non-black text-bold" ID="lnkTai" runat="server"><span class="bold">Tải về</span></asp:HyperLink> </span><br />
              <br /></td>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
          </tr>
        </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
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
            <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
            <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
                <asp:Literal ID="ltrCungTheLoai" runat="server">CÙNG THỂ LOẠI</asp:Literal>
            </td>
            <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
          </tr>
          <tr>
            <td colspan="3" align="left" valign="top" bgcolor="#F5F5F5"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
          </tr>
        </table>

        <asp:Repeater ID="rptCungTheLoai" runat="server">
            <ItemTemplate>

                 <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">
                    <tr>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
            <td width="82" align="left" valign="top"><table width="90" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                      <tr>
                        <td bgcolor="#EDEDED">
                            <asp:HyperLink ID="lnkAvatar" runat="server">
                                <asp:Image ID="imgAvatar" runat="server" Width="82" Height="66" />
                            </asp:HyperLink>
                        </td>
                      </tr>
                  </table></td>
                </tr>
            </table></td>
            <td width="20" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="20" height="10" /></td>
            <td width="125%" align="left" valign="top" class="style2">
                <span class="style4">
                    <asp:HyperLink CssClass="link-non-orange" ID="lnkTenAnh" runat="server"></asp:HyperLink>
                </span><br />
                <span class="style10"><asp:Literal ID="ltrTheloai" runat="server"></asp:Literal><br />
                <asp:Literal ID="ltrLuottai" runat="server"></asp:Literal><br />
                <asp:HyperLink CssClass="link-non-black text-bold" ID="lnkTai" runat="server">Tải</asp:HyperLink> </span><br />
            <br /></td>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
          </tr>
                </table>

                 <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>
                    
            </ItemTemplate>
        </asp:Repeater>

        <uc2:Paging ID="Paging1" runat="server" />

    </td>
  </tr>
</table>