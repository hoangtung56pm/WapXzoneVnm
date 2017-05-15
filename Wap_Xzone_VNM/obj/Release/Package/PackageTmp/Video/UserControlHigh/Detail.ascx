<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register src="Category.ascx" tagname="Category" tagprefix="uc2" %>

        <asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="video-play">
                    <h4><%# Eval("VTitle_Unicode")%></h4>
                    <a href="#">
                        <img src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                    </a>

                </div>
            </ItemTemplate>

            <FooterTemplate>
                <p>
                        <%--<img alt="" width="19" height="18" style="padding-left:3px;" src="/img/icontv.png">--%>

                        <a href="<%= UrlProcess.VideoView(id) %>">
                            <span class="bold">Xem trực tuyến</span>
                         </a>

                        <a href="<%= UrlProcess.VideoDownload(id) %>">
                            <span class="bold">Tải về</span>
                        </a>

                 </p>
            </FooterTemplate>

        </asp:Repeater>

        <div class="category-video">
            <div class="title-video">
                <span>Clip liên quan</span>
                <div class="border-color">
                    <div></div>
                </div>
            </div>
            <div class="video-download">

                <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
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
                <a href="<%= UrlProcess.VideoChuyenMuc(ConvertUtility.ToInt32(CatId),1,CatName) %>">
                    <img src="/Content/asset/Images/btn-view-all.png" alt=""/>
                </a>
            </div>
        </div>

        <uc2:Category ID="Category1" runat="server" EnableViewState="False" />   