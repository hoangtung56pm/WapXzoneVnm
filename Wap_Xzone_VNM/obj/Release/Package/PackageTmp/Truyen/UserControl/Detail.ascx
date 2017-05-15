<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Truyen.UserControl.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>


<!-- Begin .wapper -->
<div class="wapper">
    <div class="content">

        <uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

        <!-- begin tin tuc -->
        <div class="newsCat">
            <ul class="detail-gioitinh">
                 <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.TruyenOnlineHome() %>"><i class="icon-caret-right"></i><span>Truyện online</span></a></li>
                <li><a href="<%= UrlProcess.TruyenOnlineChuyenMuc(catID,1,catName) %>"><i class="icon-caret-right"></i><span><%= catName %></span></a></li>
            </ul>
            <div class="newsCat-head">
                <h2>
                    <a href="#">
                        <asp:Literal ID="litName" runat="server" EnableViewState="false"></asp:Literal>
                    </a>
                </h2>
            </div>
            <div class="newsCat-content">
                <div class="news-detail">

                     <asp:Panel ID="pnlContent" runat="server" EnableViewState="false" Visible="false">
                        <%--Content Here--%>
                        <p>
                            <asp:Literal ID="litContent" runat="server" EnableViewState="false"></asp:Literal>
                        </p>
                    </asp:Panel>

                    <asp:Panel ID="pnlContentError" runat="server" EnableViewState="false" Visible="false">
                        <%--Content Here--%>
                        <p>
                            <asp:Literal ID="litContentError" runat="server" EnableViewState="false"></asp:Literal>
                        </p>
                    </asp:Panel>

                </div>

                <!-- begin tin cung chuyen muc-->
                <div class="news-late">
                    <h3><a href="<%= UrlProcess.TruyenOnlineChuyenMuc(catID,1,catName) %>">Tin cùng chuyên mục</a></h3>
                    <ul class="news-lis">

                        <asp:Repeater ID="rptTop" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <a href="<%# UrlProcess.TruyenOnlineChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                        <%# Eval("Content_Headline") %>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
                <!-- end tin cung chuyen muc-->

                <a class="newsCat-more" href="<%= UrlProcess.TruyenOnlineChuyenMuc(catID,1,catName) %>" title="Xem thêm">Xem thêm</a>
            </div>
        </div>
        <!-- end tin tuc -->


        <div class="newsCat" id="hide-you-like">
            <div class="gioitinh-head">
                <h2 class="active"><a href="#truyen" title="Tin hot"><i class="icon-book"></i><span>Truyện online</span></a></h2>
                <h2><a href="#audio" title="Tin hot"><i class="icon-headphones"></i>Audio</a></h2>
            </div>
            <div class="newsCat-content">
                <!-- Begin chuyen muc -->
                <div id="truyen" class="you-like newsCat">
                    <div class="newsCat-content">
                        <div class="news-late">
                            <ul class="category-lis">
                                
                                <asp:Repeater ID="rptCateOnline" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <li>
                                            <a href="<%# UrlProcess.TruyenOnlineChuyenMuc(ConvertUtility.ToInt32(Eval("Zone_ID").ToString()),1,Eval("Zone_Name").ToString()) %>">
                                                <%# Eval("Zone_Name")%>
                                             </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                </div>
                <!-- End chuyen muc -->

                <div id="audio" class="you-like newsCat">
                    <div class="newsCat-content">
                        <div class="news-late">
                            <ul class="category-lis">

                                <asp:Repeater ID="rptCateAudio" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <li>
                                            <a href="<%# UrlProcess.TruyenAudioChuyenMuc(Eval("StyleId").ToString(),1,Eval("StyleName").ToString()) %>">
                                               <%# Eval("StyleName") %>
                                            </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End .wapper-->