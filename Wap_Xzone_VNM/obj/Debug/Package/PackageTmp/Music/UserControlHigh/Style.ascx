﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Style.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.Style" %>

<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<div class="music">
            <h4 class="title-music">
                <a style="color:#FF7E00;" href="<%= UrlProcess.AmNhacChuyenMucTheLoai("1","bai-hat-theo-the-loai","1") %>">
                Bài hát theo thể loại
                </a>
            </h4>

            <div class="list-music">
                <asp:Repeater ID="rptTheLoai" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <div class="item">
                            <a class="music-name" href="<%# UrlProcess.AmNhacChuyenMucTheLoaiList(Eval("StyleID").ToString(),Eval("StyleName").ToString(),"1") %>">
                                <%# Eval("StyleNameUnicode")%>
                            </a>
                            <span class="ca-si">
                                <%--<%# Eval("ArtistNameUnicode")%>--%>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            
              <%--<a class="xemthem" href="<%= UrlProcess.VideoChuyenMuc(31,1,"clip-nhac") %>">
                <img src="/Content/asset/Images/btn-xemthem.png" alt=""/>
            </a>--%>

            <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

        </div>