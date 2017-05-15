<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Album.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.Album" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<%--Album Hot--%>
        <div class="album">
            <h4 class="title-music">
                <a style="color:#FF7E00;" href="<%= UrlProcess.AmNhacChuyenMucAlbum("1","1","album-hot") %>">
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

            <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

        </div>