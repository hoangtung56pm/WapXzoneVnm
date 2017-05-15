<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Artist.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.Artist" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<div class="music">
            <h4 class="title-music">
                <%--<a style="color:#FF7E00;" href="<%= UrlProcess.AmNhacChuyenMucCaSy("1","bai-hat-theo-ca-sy","1") %>">--%>
                Bài hát theo ca sỹ
                <%--</a>--%>
            </h4>

            <div class="list-music">
                <asp:Repeater ID="rptTopCaSy" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <div class="item">
                            <a class="music-name" href="<%# UrlProcess.AmNhacChuyenMucCaSyList(Eval("ArtistID").ToString(),Eval("ArtistName").ToString(),"1") %>">
                                <%# Eval("ArtistNameUnicode")%>
                            </a>
                            <span class="ca-si">
                                <%--<%# Eval("ArtistNameUnicode")%>--%>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            
             <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

        </div>