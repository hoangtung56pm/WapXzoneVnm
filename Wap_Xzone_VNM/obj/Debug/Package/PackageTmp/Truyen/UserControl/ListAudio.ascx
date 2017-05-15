<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListAudio.ascx.cs" Inherits="WapXzone_VNM.Truyen.UserControl.ListAudio" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/Truyen/UserControl/CategoryAudio.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>
<%@ Register Src="/Truyen/UserControl/PagingAudio.ascx" TagName="Paging" TagPrefix="uc3" %>


<!-- Begin .wapper -->
<div class="wapper">
    <div class="content">


     <uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

        <ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.TruyenAudioHome() %>"><i class="icon-caret-right"></i><span>Truyện Audio</span></a></li>

                <li><a href="<%= UrlProcess.TruyenAudioChuyenMuc(catID,1,CatName) %>"><i class="icon-caret-right"></i><span><%= CatName %></span></a></li>

            </ul>

        <div class="newsCat">
            <div class="gioitinh-head">
                <h2><a href="<%= UrlProcess.TruyenOnlineHome() %>"><i class="icon-book"></i><span>Truyện online</span></a></h2>
                <h2><a href="<%= UrlProcess.TruyenAudioHome() %>"><i class="icon-headphones"></i>Audio</a></h2>
            </div>
        </div>
        <!-- begin tin tuc -->
        <div class="newsCat">
            <!-- Begin chuyen muc -->
            <div class="newsCat-head">
                <h2><a href="<%= UrlProcess.TruyenAudioChuyenMuc(catID,1,CatName) %>"><%= CatName %></a></h2>
            </div>
            <div class="newsCat-content">

                <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="gioi-tinh">
                            <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId")),Eval("SongName").ToString()) %>">
                                <img src="<%# AppEnv.GetAvatarByPath(Eval("Content_Avatar").ToString(),125,94) %>" alt=""/>
                            </a>
                            <div class="info-gioitinh">
                                <h3>
                                    <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId")),Eval("SongName").ToString()) %>">
                                        <%# Eval("SongName")%>
                                    </a>
                                </h3>
                                <div>Thể loại: 
                                    <a href="<%= UrlProcess.TruyenAudioChuyenMuc(catID,1,CatName) %>"><%= CatName%></a>
                                </div>
                                <div>Tác giả: Đang cập nhật</div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <uc3:Paging ID="Paging1" runat="server" EnableViewState="False" />

            </div>
            <!-- End chuyen muc -->
        </div>
        <!-- end tin tuc -->

       <uc1:Category ID="Category1" runat="server" EnableViewState="False" />

    </div>
</div>
<!-- End .wapper-->