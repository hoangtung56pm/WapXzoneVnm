<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeAudio.ascx.cs" Inherits="WapXzone_VNM.Truyen.UserControl.HomeAudio" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/Truyen/UserControl/CategoryAudio.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>


<!-- Begin .wapper -->
<div class="wapper">
    <div class="content">

        
        <uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

        <ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.TruyenAudioHome() %>"><i class="icon-caret-right"></i><span>Truyện Audio</span></a></li>
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
                <h2>
                    <a href="javascript:void(0)">
                        Truyện mới
                    </a>
                </h2>
            </div>
            <div class="newsCat-content">
                
                <asp:Repeater ID="rptTruyenMoi" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="gioi-tinh">
                            <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId").ToString()),Eval("SongName").ToString()) %>">
                                <img src="<%# AppEnv.GetAvatarByPath(Eval("Content_Avatar").ToString(),125,94) %>" alt=""/>
                            </a>
                            <div class="info-gioitinh">
                                <h3>
                                    <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId").ToString()),Eval("SongName").ToString()) %>"> 
                                        <%# Eval("SongName")%>
                                    </a>
                                </h3>
                                <div>Thể loại: <a href="<%# UrlProcess.TruyenAudioChuyenMuc(ConvertUtility.ToString(Eval("StyleId").ToString()),1,Eval("StyleName").ToString()) %>"><%# Eval("StyleName") %></a></div>
                                <div>Tác giả: Đang cập nhật</div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <!-- End chuyen muc -->
        </div>
        <!-- end tin tuc -->


        <!-- begin tin tuc -->
        <div class="newsCat">
            <!-- Begin chuyen muc -->
            <div class="newsCat-head">
                <h2>
                    <a href="javascript:void(0)">Truyện hot</a>
                </h2>
            </div>
            <div class="newsCat-content">
                
                <asp:Repeater ID="rptTruyenHot" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="gioi-tinh">
                            <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId").ToString()),Eval("SongName").ToString()) %>">
                                <img src="<%# AppEnv.GetAvatarByPath(Eval("Content_Avatar").ToString(),125,94) %>" alt=""/>
                            </a>
                            <div class="info-gioitinh">
                                <h3>
                                    <a href="<%# UrlProcess.TruyenAudioChiTiet(ConvertUtility.ToString(Eval("SongId").ToString()),Eval("SongName").ToString()) %>"> 
                                        <%# Eval("SongName")%>
                                    </a>
                                </h3>
                                <div>Thể loại: <a href="<%# UrlProcess.TruyenAudioChuyenMuc(ConvertUtility.ToString(Eval("StyleId").ToString()),1,Eval("StyleName").ToString()) %>"><%# Eval("StyleName")%></a></div>
                                <div>Tác giả: Đang cập nhật</div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <!-- End chuyen muc -->
        </div>
        <!-- end tin tuc -->

       <uc1:Category ID="Category1" runat="server" EnableViewState="False" />

    </div>
</div>
<!-- End .wapper-->