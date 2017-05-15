<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YoutubeSearch.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.YoutubeSearch" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<%@ Register src="Search.ascx" tagname="Search" tagprefix="uc2" %>

<div class="category-video">
   
        
        <uc2:Search ID="Search" runat="server" EnableViewState="False" />
        
        <div class="title-video">
            <span>
                <asp:Label ID="lblKetqua" Text="Kết quả tìm kiếm" runat="server" EnableViewState="false"></asp:Label>
            </span>
            <div class="border-color">
                <div></div>
            </div>
        </div>

        <div class="video-download">

            <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <a href="<%# UrlProcess.YoutubeChiTiet(ConvertUtility.ToInt32(Eval("Id")),Eval("Title_Kd").ToString()) %>" class="thumbnail-video">
                            <img width="140" src="<%# AppEnv.GetSetting("urldata") + Eval("Avatar").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                        </a>
                        <p class="description">
                            <a href="<%# UrlProcess.YoutubeChiTiet(ConvertUtility.ToInt32(Eval("Id")),Eval("Title_Kd").ToString()) %>">
                                <%# Eval("Title")%>
                            </a>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>

        <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

    </div>