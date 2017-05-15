<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HotNews.ascx.cs" Inherits="WapXzone_VNM.Tintuc.UserControlNew.HotNews" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top">
        
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            
            <a class="link-non-white" href="<%= UrlProcess.GetNewsHomeUrlNew(lang.ToString(),width) %>">
                <%= AppEnv.CheckLang("Tin tức") %>
            </a>

         <span class="style5"></span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
        
        <asp:Repeater ID="rptTopNews" runat="server" EnableViewState="false">
            <ItemTemplate>
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
                                    <a href="<%# UrlProcess.GetNewsDetailUrlNew(lang.ToString(),"detail",width,Eval("Distribution_ID").ToString()) %>">
                                        <img alt="" src="<%# AppEnv.GetAvatar(Eval("Content_Avatar").ToString(),82,65) %>" width="82" height="65" hspace="3" vspace="3" />
                                    </a>
                              </td>
                            </tr>
                        </table></td>
                      </tr>
                  </table></td>
                  <td width="10" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="10" height="10" /></td>
                </tr>
              </table>
                <span class="style4">
                    <a class="link-non-orange" href="<%# UrlProcess.GetNewsDetailUrlNew(lang.ToString(),"detail",width,Eval("Distribution_ID").ToString()) %>">
                        <%# AppEnv.CheckLang(Eval("Content_Headline").ToString()) %>
                    </a>
                     <br />

                </span>

                <span class="style4"><br />
              </span></td>
            <td align="left" valign="top" bgcolor="ededed"><img alt="" src="/imagesnew/blank.gif" width="15" height="10" /></td>
          </tr>
          <tr>
            <td colspan="3" align="left" valign="top" bgcolor="#EDEDED"><img alt="" src="/imagesnew/blank.gif" width="8" height="10" /></td>
          </tr>
          <tr>
            <td colspan="3" align="left" valign="top" bgcolor="c3c3c3"><img alt="" src="/imagesnew/blank.gif" width="9" height="1" /></td>
          </tr>
        </table>
            </ItemTemplate>    
        </asp:Repeater>

        

      <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
          <tr>
            <td align="left" valign="top" bgcolor="#EDEDED"><img src="/imagesnew/blank.gif" width="5" height="9" /></td>
          </tr>
        </table>

      <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <asp:Repeater ID="rptNews" runat="server">
            <ItemTemplate>
                <tr>
                    <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="12" /></td>
                    <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/arrow.jpg" width="8" height="7" /></td>
                    <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="12" /></td>
                    <td width="125%" align="left" valign="middle" class="style12">
                        <a class="link-non-black" href="<%# UrlProcess.GetNewsDetailUrlNew(lang.ToString(),"detail",width,Eval("Distribution_ID").ToString()) %>">
                            <%# AppEnv.CheckLang(Eval("Content_Headline").ToString()) %>
                        </a>
                    </td>
                </tr>
            </ItemTemplate>
          </asp:Repeater>
      </table>
     
     </td>
  </tr>
</table>