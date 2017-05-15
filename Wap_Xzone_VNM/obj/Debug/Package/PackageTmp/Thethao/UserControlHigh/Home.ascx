<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register src="DuLieuBongDa.ascx" tagname="DuLieuBongDa" tagprefix="uc1" %>

<div class="category-video">

            <div class="title-video">
                <span>Clip bóng đá 24H</span>
                <div class="border-color">
                    <div></div>
                </div>
            </div>

            <div class="video-download">

                <asp:Repeater ID="rptVideo" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="item">
                            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>" class="thumbnail-video">
                                <img src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                            </a>
                            <p class="description">
                                <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                                    <%# Eval("VTitle_Unicode")%>
                                </a>
                            </p>
                            <p class="detail">
                                <a href="<%# UrlProcess.VideoDownload(ConvertUtility.ToInt32(Eval("W_VItemID"))) %>">Tải | </a>
                                <a href="<%# UrlProcess.VideoView(ConvertUtility.ToInt32(Eval("W_VItemID"))) %>">Xem</a>
                                <%--<a href="#">Tặng</a>--%>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </div>

        <div class="tin-tuc">

            <div class="title-video">
                <span style="font-weight: 600;text-transform: uppercase;">
                    <a style="color: #FF7E00;" href="/tin-tuc/chuyen-muc/129/1/The-thao.aspx">
                        Tiêu điểm thể thao
                    </a>
                </span>
                <div class="border-color">
                    <div></div>
                </div>
            </div>

            <div class="news-large">

                <asp:Repeater ID="rptTopNews" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                            <h4>
                                <%# Eval("Content_Headline")%>
                            </h4>
                        </a>
                        <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                            <img alt="" src="<%# AppEnv.GetAvatarTheThaoSo(Eval("Content_Avatar").ToString(),297,208) %>">
                        </a>
                        <p style="margin-top: 5px" class="description">
                            <%# Eval("Content_Teaser") %>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>

                <ul class="news-referent">
                    
                    <asp:Repeater ID="rptListNews" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li>
                                <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                    <%# Eval("Content_Headline")%>
                                </a>
                                <br />
                                <span><%# ConvertUtility.ToDateTime(Eval("Content_CreateDate")).ToString("dd/MM/yyyy HH:mm")%></span>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>

            </div>

           <%-- <div class="box-tag tag-news">
                <ul class="list-tag">
                    <li><a href="<%= UrlProcess.TheThaoTranCauVang("4") %>">Trận cầu vàng</a></li>
                    <li><a href="<%= UrlProcess.TheThaoTuVanDacBiet() %>">Tư vấn đặc biệt</a></li>
                </ul>
            </div>--%>

        </div>

        <uc1:DuLieuBongDa ID="DuLieuBongDa1" runat="server" EnableViewState="False" />   