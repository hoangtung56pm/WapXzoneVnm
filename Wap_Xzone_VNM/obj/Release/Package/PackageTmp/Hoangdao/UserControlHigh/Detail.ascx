<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Hoangdao.UserControlHigh.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="box-thugian">
                <h4>
                    <%--<asp:Label ID="lblItemName" runat="server" EnableViewState="False"></asp:Label>--%>
                    <a href="<%= UrlProcess.HoangDaoHome() %>">Tử Vi</a>
                </h4>
                
                <%--<p>--%>
                <div style="padding-left:5px; padding-right:5px;">
                    <asp:Literal ID="litContent" runat="server" EnableViewState="false"></asp:Literal>
                </div>
                    
                <%--</p>--%>

            </div>