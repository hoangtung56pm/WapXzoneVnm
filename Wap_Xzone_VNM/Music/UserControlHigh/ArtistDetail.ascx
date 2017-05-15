<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArtistDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlHigh.ArtistDetail" %>

<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<div class="music">
            <h4 class="title-music">
                <%--<a style="color:#FF7E00;" href="<%= UrlProcess.AmNhacChuyenMucCaSy("1","bai-hat-theo-ca-sy","1") %>">--%>
                <asp:Literal ID="ltrArtistName" runat="server" EnableViewState="False"></asp:Literal>    	
                <%--</a>--%>
            </h4>

            <div class="list-music">
                <asp:Repeater ID="rptList" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <div class="item">
                            <a class="music-name" href="<%# UrlProcess.AmNhacChiTiet(ConvertUtility.ToInt32(Eval("W_MItemID").ToString()),Eval("SongName").ToString()) %>">
                                <%# Eval("SongNameUnicode")%>
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