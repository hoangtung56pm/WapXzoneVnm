<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.AlbumDetail" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="music">
            <h4 class="title-music">
                <asp:Literal ID="ltrAlbumName" runat="server" EnableViewState="False"></asp:Literal>
            </h4>

            <div class="list-music">
                <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <div class="item">
                            <%--<a href="#" class="thumbnail-music">
                                <img src="/Content/asset/Images/thumbnail-nhac-small.png" alt=""/>
                            </a>--%>
                            <a class="music-name" href="<%# UrlProcess.AmNhacChiTiet(ConvertUtility.ToInt32(Eval("W_MItemID")),Eval("SongName").ToString()) %>">
                                <%# Eval("SongNameUnicode")%>
                            </a>
                            <span class="ca-si">
                                <%# Eval("ArtistNameUnicode")%>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>