﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TheLoaiHinhNen.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControlNew.TheLoaiHinhNen" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><asp:Literal ID="ltrTheLoai" runat="server">THỂ LOẠI HÌNH</asp:Literal></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          
          <asp:Repeater ID="rptTheLoai" runat="server" EnableViewState="false">
            <ItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/iconhinh.jpg" width="15" height="15" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10"><asp:HyperLink CssClass="link-non-black" ID="lnkCatName" runat="server"></asp:HyperLink></td>
          </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/iconhinh.jpg" width="15" height="15" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7"><span class="style10"><asp:HyperLink CssClass="link-non-black" ID="lnkCatName" runat="server"></asp:HyperLink></span></td>
          </tr>
            </AlternatingItemTemplate>
          </asp:Repeater> 
  
      </table></td>
  </tr>
</table>