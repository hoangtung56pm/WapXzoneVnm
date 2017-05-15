<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MusicDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.MusicDetail" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register src="MoiNhat.ascx" tagname="MoiNhat" tagprefix="uc1" %>

        <div class="song-detail">

            <%--<div class="thumbnail-img">
                <img src="/Content/asset/Images/minh-vuong.png" alt=""/>
            </div>--%>

            <div class="info-song">
                <asp:Repeater ID="rptDetail" EnableViewState="false" runat="server">
                    <ItemTemplate>
                        <h6><%# Eval("SongNameUnicode")%></h6>
                        <span>Ca sỹ: <%# Eval("ArtistNameUnicode")%></span>
                        <span>Thể loại: <%# Eval("StyleNameUnicode")%></span>
                        <span>Lượt tải: <%# Eval("Download")%></span>
                        <span>Giá tải: <%= price %> đ</span>
                        <span>
                            <a href="<%# UrlProcess.AmNhacDowload(Eval("W_MItemID").ToString()) %>">
                                <img src="/Content/asset/Images/download-song.png" alt="" style="width: 19px"/> 
                                Tải về
                            </a>
                        </span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <uc1:MoiNhat ID="MoiNhat1" runat="server" EnableViewState="False" />   