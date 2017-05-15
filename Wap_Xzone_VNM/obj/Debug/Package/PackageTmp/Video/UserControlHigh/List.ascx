<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.List" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<%@ Register src="Category.ascx" tagname="Category" tagprefix="uc2" %>

<div class="category-video">
        <div class="title-video">
            <span>
                <asp:Label ID="lblCategorryName" runat="server" EnableViewState="false"></asp:Label>
            </span>
            <div class="border-color">
                <div></div>
            </div>
        </div>

        <div class="video-download">

            <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>" class="thumbnail-video">
                            <img width="140" src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                        </a>
                        <p class="description">
                            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                                <%# Eval("VTitle_Unicode")%>
                            </a>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>

        <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

    </div>

<uc2:Category ID="Category1" runat="server" EnableViewState="False" />   