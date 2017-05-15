<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register src="Category.ascx" tagname="Category" tagprefix="uc1" %>

 <div class="category-video">
        <div class="title-video">
            <span>Tải nhiều nhất</span>
            <div class="border-color">
                <div></div>
            </div>
        </div>

        <div class="video-download">

            <asp:Repeater ID="rptTaiNhieuNhat" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>" class="thumbnail-video">
                            <img width="140" src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                        </a>
                        <p class="description">
                            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                                <%# Eval("VTitle_Unicode")%>
                            </a>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>

        <div class="view-all">
            <a href="<%= UrlProcess.VideoChuyenMuc(1,1,"tai-nhieu-nhat") %>">
                <img src="/Content/asset/Images/btn-view-all.png" alt=""/>
            </a>
        </div>

    </div>

 <div class="category-video">
        <div class="title-video">
            <span>Mới cập nhật</span>
            <div class="border-color">
                <div></div>
            </div>
        </div>

        <div class="video-download">

            <asp:Repeater ID="rptMoiCapNhat" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>" class="thumbnail-video">
                            <img width="140" src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                        </a>
                        <p class="description">
                            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                                <%# Eval("VTitle_Unicode")%>
                            </a>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>

        <div class="view-all">
            <a href="<%= UrlProcess.VideoChuyenMuc(2,1,"Moi-cap-nhat") %>">
                <img src="/Content/asset/Images/btn-view-all.png" alt=""/>
            </a>
        </div>

    </div>

 <div class="category-video">
        <div class="title-video">
            <span>Nóng trong ngày</span>
            <div class="border-color">
                <div></div>
            </div>
        </div>

        <div class="video-download">

            <asp:Repeater ID="rptNongTrongNgay" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>" class="thumbnail-video">
                            <img width="140" src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                        </a>
                        <p class="description">
                            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                                <%# Eval("VTitle_Unicode")%>
                            </a>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>

        <div class="view-all">
            <a href="<%= UrlProcess.VideoChuyenMuc(4,1,"nong-trong-ngay") %>">
                <img src="/Content/asset/Images/btn-view-all.png" alt=""/>
            </a>
        </div>

    </div>

<div class="category-video">
        <div class="title-video">
            <span>Shock - Độc - Lạ</span>
            <div class="border-color">
                <div></div>
            </div>
        </div>

        <div class="video-download">

            <asp:Repeater ID="rptShock" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>" class="thumbnail-video">
                            <img width="140" src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                        </a>
                        <p class="description">
                            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                                <%# Eval("VTitle_Unicode")%>
                            </a>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>

        <div class="view-all">
            <a href="<%= UrlProcess.VideoChuyenMuc(21,1,"shock-doc-la") %>">
                <img src="/Content/asset/Images/btn-view-all.png" alt=""/>
            </a>
        </div>

    </div>

    <uc1:Category ID="Category1" runat="server" EnableViewState="False" />   