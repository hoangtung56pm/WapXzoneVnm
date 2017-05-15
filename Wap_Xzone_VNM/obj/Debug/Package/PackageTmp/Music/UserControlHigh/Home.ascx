<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register src="MoiNhat.ascx" tagname="MoiNhat" tagprefix="uc1" %>
<%@ Register src="BaiHatTheoCaSy.ascx" tagname="BaiHatTheoCaSy" tagprefix="uc2" %>
<%@ Register src="BaiHatTheoTheLoai.ascx" tagname="BaiHatTheoTheLoai" tagprefix="uc3" %>
        

        <asp:Repeater ID="rptVideoTop" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="single-music">
                    <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID").ToString()),Eval("VTitle").ToString()) %>">
                        <img src="<%# AppEnv.GetTrueAvatarPath(Eval("VThumnail").ToString())  %>" alt=""/>
                    </a>

                    <div class="info">
                        <span class="music-name"><%# Eval("VTitle_Unicode")%></span> <br/>
                        <span class="ca-si"><%# Eval("Web_Name")%></span>
                    </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>

        <%--Clip Nhạc--%>
        <div class="music">
            <h4 class="title-music">Clip Nhạc</h4>

            <div class="list-music">
                
                <asp:Repeater ID="rptVideoList" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="item">
                            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID").ToString()),Eval("VTitle").ToString()) %>" class="thumbnail-music">
                                <img src="<%# AppEnv.GetAvatar(Eval("VThumnail").ToString(),70,40) %>" alt=""/>
                            </a>

                            <a class="music-name" href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID").ToString()),Eval("VTitle").ToString()) %>">
                                 <%# AppEnv.TrimLength(Eval("VTitle_Unicode").ToString(),15)%>
                            </a>

                            <span class="ca-si">
                                <%# Eval("Web_Name")%>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <a class="xemthem" href="<%= UrlProcess.VideoChuyenMuc(31,1,"clip-nhac") %>">
                <img src="/Content/asset/Images/btn-xemthem.png" alt=""/>
            </a>
        </div>

       <%-- <div class="ads-music">
            <a href="#">
                <img src="/Content/asset/Images/ads-nhac.png" alt=""/>
            </a>
        </div>--%>

         <%--Bai Hat--%>
        <uc1:MoiNhat ID="MoiNhat1" runat="server" EnableViewState="False" />   

        <%--Album Hot--%>
        <div class="album">
            <h4 class="title-music">
                <a style="color:#FF7E00;" href="<%= UrlProcess.AmNhacChuyenMucAlbum("1","album-hot","1") %>">
                    Album HOT
                </a>
            </h4>
            <div class="list-album">
                
                <asp:Repeater ID="rptAlbum" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="item">
                            <div>
                                <a href="<%# UrlProcess.AmNhacAlbumChiTiet(ConvertUtility.ToInt32(Eval("W_MAlbumID")),Eval("AlbumName").ToString()) %>">
                                    <%--<img src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),145,142)  %>" alt=""/>--%>
                                    <img alt="" src="<%# AppEnv.GetTrueAvatarPath(Eval("Avatar").ToString()) %>">
                                </a>
                                <div class="info">
                                    <span><b><%# Eval("AlbumNameUnicode")%></b></span> 
                                    <%--<br/>
                                    <span>Minh Vương</span>--%>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

       

        <%--Bai Hat Theo Ca Sy--%>
        <uc2:BaiHatTheoCaSy ID="BaiHatTheoCaSy1" runat="server" EnableViewState="False" />   

        <%--Bai Hat Theo The Loai--%>
        <uc3:BaiHatTheoTheLoai ID="BaiHatTheoTheLoai1" runat="server" EnableViewState="False" />  
