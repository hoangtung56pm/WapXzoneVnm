<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="WapXzone_VNM.Game.UserControlHigh.Menu" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div id="menu" class="menu">

    <ul>

        <li>
            <p class="danh-muc">
                Danh mục
            </p>
        </li>

        <li>
            <a href="<%= AppEnv.GetSetting("SmartPhoneHome") %>">
                <img alt="" src="/Content/asset/Images/icon-menu.png" /> Trang chủ
            </a>
        </li>

        <asp:Repeater ID="rptMenu" runat="server">
            <ItemTemplate>
                <li>
                    <a href="<%# UrlProcess.GameChuyenMuc(ConvertUtility.ToInt32(Eval("W_GameCategoryID").ToString()),1,Eval("Title").ToString()) %>">
                        <img alt="" src="/Content/asset/Images/icon-menu.png" /> <%# Eval("Title_Unicode")%>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>

    </ul>
</div>