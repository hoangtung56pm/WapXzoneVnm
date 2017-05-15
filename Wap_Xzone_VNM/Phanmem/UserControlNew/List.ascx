﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Phanmem.UserControlNew.List" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<%@ Register Src="Pagging.ascx" TagName="Paging" TagPrefix="uc1" %>

<p style="padding:0 0 2px 2%; display:none;">
    <asp:HyperLink ID="lnkValidModel" runat="server">Chỉ hiện thị những game hỗ trợ</asp:HyperLink>
</p>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            <span class="style2"> 
                <asp:HyperLink CssClass="link-non-white" ID="lnkHomeChannel" runat="server" EnableViewState="False">PHAN MEM</asp:HyperLink> » 
                <asp:HyperLink CssClass="link-non-white" ID="lnkCateChannel" runat="server" EnableViewState="False"></asp:HyperLink>
            </span>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
      
      <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>

            <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrgame.gif">
        <tr>
          <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="66" /></td>
          <td width="36" align="left" valign="top"><table width="36" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                    <tr>
                      <td bgcolor="#EDEDED">
                        <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False">
                            <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="36" Height="48" />
                        </asp:HyperLink>
                      </td>
                    </tr>
                </table></td>
              </tr>
          </table></td>
          <td width="20" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="20" height="10" /></td>
          <td width="125%" align="left" valign="top" class="style2">
          <span class="style4">
            <asp:HyperLink CssClass="link-non-orange" ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
          </span><br />
            <asp:Literal ID="ltrTheloai" runat="server" EnableViewState="False"></asp:Literal><br />
            <strong>
                <asp:HyperLink ID="lnkTai" CssClass="link-non-black" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>
            </strong></td>
          <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
        </tr>
      </table>

            <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>

        </ItemTemplate>
      </asp:Repeater>

      <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
        
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
          <td width="125%" align="left" valign="middle"><span class="style11">
            <asp:Literal runat="server" EnableViewState="false" ID="litGia"></asp:Literal>
          </span></td>
        </tr>
      </table></td>
  </tr>
</table>