<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.TinHot.UserControl.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/TinHot/UserControl/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>

<div class="wapper">

    

    <div class="content">
        
        <uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

        <ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.TinTucHome() %>"><i class="icon-caret-right"></i><span>Tin Tức</span></a></li>
            </ul>

        <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
            <ItemTemplate>
                <!-- begin tin tuc -->
                <div class="newsCat">
                    <div class="newsCat-head">
                        <h2>
                            <a href="<%# UrlProcess.TinTucChuyenMuc(ConvertUtility.ToInt32(Eval("Zone_ID").ToString()),1,Eval("Zone_Name").ToString()) %>">
                                <%# Eval("Zone_Name") %></a>
                       </h2>
                    </div>
                    <div class="newsCat-content">

                        <asp:Repeater ID="rptTop" runat="server">
                            <ItemTemplate>
                                <div class="news">
                                    <h3>
                                        <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                            <%# Eval("Content_Headline") %>
                                        </a>
                                    </h3>
                                    <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                        <img src="<%# AppEnv.NavigateGetAvatar(Eval("Content_Avatar").ToString(),125,94,ZoneId) %>" alt="" />

                                    </a>
                                    <p>
                                        <%# AppEnv.TrimLength(Eval("Content_Teaser").ToString(),60) %>
                                    </p>
                                    <%# ConvertUtility.ToDateTime(Eval("Content_CreateDate")).ToString("dd/MM hh:mm") %>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <ul class="news-lis">
                            <asp:Repeater ID="rptBottom" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                            <%# Eval("Content_Headline") %>
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>

                    </div>
                </div>
                <!-- end tin tuc -->
            </ItemTemplate>
        </asp:Repeater>

        <uc1:Category ID="Category1" runat="server" EnableViewState="False" />

    </div>



</div>
