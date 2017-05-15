<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DichVuNoiBat.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlNew.DichVuNoiBat" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/blank.gif" width="5" height="10" /></td>
    <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Dịch vụ nổi bật") %> <span class="style5"></span></td>
    <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
  </tr>
  <tr>
    <td colspan="3" align="left" valign="top"><img src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
</table>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td rowspan="2" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="10" /></td>
    <td width="125%" align="left" valign="top">

    <asp:Repeater ID="rptLienket" runat="server" EnableViewState="false">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left" valign="middle" class="style2">
                    <span class="style8">
                        <asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal>
                    </span>
                    <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
                    <img alt="" src="/imagesnew/hot_icon.gif" width="30" height="12" border="0" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
            </tr>
    </table>
        </ItemTemplate>
    </asp:Repeater>

      </td>
    <td rowspan="2" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="10" /></td>
  </tr>
  <tr>
    <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
</table> <%--Tin--%>