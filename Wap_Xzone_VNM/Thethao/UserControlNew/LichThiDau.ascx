<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichThiDau.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlNew.LichThiDau" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Pagging.ascx" TagName="Paging" TagPrefix="uc1" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            <asp:HyperLink CssClass="link-non-white" ID="lnkTheThao" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:Literal ID="lnkLichthidau" runat="server" EnableViewState="False"></asp:Literal>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      
    </table>

      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style15">
            <asp:Label ID="lblCompetitonName" runat="server" EnableViewState="False">Giải</asp:Label><asp:Literal ID="ltrRoundName" runat="server" EnableViewState="False"></asp:Literal>
          </td>
        </tr>
      </table>

       <asp:Repeater ID="rptLichThiDau" runat="server" EnableViewState="False">
            <ItemTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="8" rowspan="3" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="9" /></td>
                      <td width="50%" rowspan="2" align="right" valign="top" class="style15"> <%# Eval("Team_Name1")%> </td>
                      <td align="center" valign="top" class="style14">? - ? </td>
                      <td width="50%" rowspan="2" align="left" valign="top" class="style15"> <%# Eval("Team_Name2")%> </td>
                    </tr>
                    <tr>
                      <td align="center" valign="top" class="style14"><img alt="" src="/imagesnew/blank.gif" width="30" height="5" /></td>
                    </tr>
                    <tr>
                      <td colspan="3" align="center" valign="top"><span class="style10"><%# ConvertUtility.ToDateTime(Eval("StartTime")).ToString("dd/MM/yyyy HH:mm")%> </span></td>
                    </tr>
                    <tr>
                      <td colspan="4" align="center" valign="top" class="style14">
                            <asp:HyperLink CssClass="link-non-orange" ID="lnkTuVan" runat="server" EnableViewState="False" Text="Tu van"></asp:HyperLink> | 
                            <asp:HyperLink CssClass="link-non-orange" ID="lnkThongke" runat="server" EnableViewState="False" Text="Thong ke"></asp:HyperLink> | 
                            <asp:HyperLink CssClass="link-non-orange" ID="lnkKQCho" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>       
                      </td>
                    </tr>
                    <tr>
                      <td colspan="4" align="left" valign="top"><span class="style14"><img alt="" src="/imagesnew/blank.gif" width="30" height="5" /></span></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>

        <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
        
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
          <td width="125%" align="left" valign="middle">
            <span class="style11">
                <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
            </span>
          </td>
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

