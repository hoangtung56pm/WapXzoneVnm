<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailAudio.ascx.cs" Inherits="WapXzone_VNM.Truyen.UserControl.DetailAudio" %>
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
                <li><a href="<%= UrlProcess.TruyenAudioHome() %>"><i class="icon-caret-right"></i><span>Truyện audio</span></a></li>
                <li><a href="<%= UrlProcess.TruyenAudioChuyenMuc(catID,1,catName) %>"><i class="icon-caret-right"></i><span><%= catName %></span></a></li>
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
            </div>
        </div>
        <!-- end tin tuc -->

        <!-- begin tin tuc -->
        <div class="newsCat">
            <div class="newsCat-head">
                <h2><a href="javascript:void(0)">Truyện mới</a></h2>
            </div>
            <div class="newsCat-content">
                
                <asp:Repeater ID="rptTop" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="gioi-tinh">
                        <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId").ToString()),Eval("SongName").ToString()) %>">
                            <img  src="<%# AppEnv.GetAvatarByPath(Eval("Content_Avatar").ToString(),125,94) %>" alt=""/>
                        </a>
                        <div class="info-gioitinh">
                            <h3>
                                <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId").ToString()),Eval("SongName").ToString()) %>">
                                    <%# Eval("SongName")%>
                                </a>
                            </h3>
                            <div>Thể loại: 
                                        <a href="<%# UrlProcess.TruyenAudioChuyenMuc(ConvertUtility.ToString(Eval("StyleId").ToString()),1,Eval("StyleName").ToString()) %>">
                                            <%# Eval("StyleName") %>
                                        </a>
                            </div>
                        <%--<div>Tác giả: Suutam</div>--%>
                        </div>
                       </div>
                    </ItemTemplate>
                </asp:Repeater>
                
                <ul class="news-lis">

                    <asp:Repeater ID="rptBottom" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li>
                                <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId").ToString()),Eval("SongName").ToString()) %>"><%# Eval("SongName")%></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
        </div>
        <!-- end tin tuc -->

        <div class="newsCat" id="hide-you-like">
            <div class="gioitinh-head">
                <h2 class="active"><a href="#truyen"><i class="icon-book"></i><span>Truyện online</span></a></h2>
                <h2><a href="#audio"><i class="icon-headphones"></i>Audio</a></h2>
            </div>
            <div class="newsCat-content">

                <ul id="truyen" class="you-like">

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

                <ul id="audio" class="you-like">

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
<!-- End .wapper-->