<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameHot.ascx.cs" Inherits="WapXzone_VNM.Game.UserControlNew.GameHot" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
                <a class="link-non-white" href="<%= UrlProcess.GetGameHomeUrlNew(lang.ToString(),width,"0") %>">
                    Game HOT 
                </a>
         <span class="style5"></span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
      
      <asp:Repeater ID="rptGame" runat="server" EnableViewState="false">
        <ItemTemplate>
             <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrgame.gif">
          <tr>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="66" /></td>
            <td width="36" align="left" valign="top"><table width="36" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                      <tr>
                        <td bgcolor="#EDEDED">
                            <a href="<%# UrlProcess.GetGameDetailUrlNew(lang.ToString(),"detail",width,Eval("W_GameItemID").ToString(),hotro) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),36,48) %>" width="36" height="48" hspace="3" vspace="3" />
                            </a>
                        </td>
                      </tr>
                  </table></td>
                </tr>
            </table></td>
            <td width="20" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="20" height="10" /></td>
            <td width="125%" align="left" valign="top" class="style2"><span class="style4">
                
                <a class="link-non-orange" href="<%# UrlProcess.GetGameDetailUrlNew(lang.ToString(),"detail",width,Eval("W_GameItemID").ToString(),"0") %>">
                    <%# AppEnv.CheckLang(Eval("GameNameUnicode").ToString())%>
                </a>

             </span><br />
              <%= AppEnv.CheckLang("Thể loại") %>: <%# AppEnv.CheckLang(Eval("Web_Name").ToString())%><br />
              <strong><asp:HyperLink CssClass="link-non-black" ID="lnkTai" runat="server"></asp:HyperLink></strong></td>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
          </tr>
        </table>
             <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>   
        </ItemTemplate>
      </asp:Repeater>



      <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
            <td width="125%" align="left" valign="middle"><span class="style11">
                <asp:Literal ID="litGia" runat="server" EnableViewState="false"></asp:Literal>
            </span></td>
          </tr>
      </table>
     
     </td>
  </tr>
</table>