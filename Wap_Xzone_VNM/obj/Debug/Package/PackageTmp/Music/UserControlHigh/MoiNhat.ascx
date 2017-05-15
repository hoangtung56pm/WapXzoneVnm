<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoiNhat.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.MoiNhat" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="music">
            <h4 class="title-music">
                Mới nhất
            </h4>

            <div class="list-music">
                <asp:Repeater ID="rptMoiNhat" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <div class="item">
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