<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Truyen.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.Truyen" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="tin-hot">
    
    <div class="box-title">
        <a class="title" href="<%= UrlProcess.TruyenOnlineHome() %>">Truyện</a>
    </div>
    
    <asp:Repeater runat="server" ID="rptTop" EnableViewState="False">
        <ItemTemplate>
            <div class="tin-hot-large">
                <div class="img">
                    <a href="<%# UrlProcess.TruyenOnlineChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                        <img alt="" src="<%# AppEnv.GetTrueAvatarPath(Eval("Content_Avatar").ToString()) %>">
                    </a>
                </div>
                <div class="name">
                    <a href="<%# UrlProcess.TruyenOnlineChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    

    <div class="border-bottom"></div>
    <div class="list-news">
        
        <asp:Repeater runat="server" ID="rptBottom" EnableViewState="False">
            <ItemTemplate>
                <div class="item">
                <a href="<%# UrlProcess.TruyenOnlineChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                    <%--<img alt="" src="<%# AppEnv.NavigateGetAvatar(Eval("Content_Avatar").ToString().Replace("/0.50x50.jpg","/0.jpg"),145,101,0) %>">--%>
                    <img alt="" src="<%# AppEnv.GetTrueAvatarPath(Eval("Content_Avatar").ToString()) %>">
                </a>

                <p class="description">
                    <a href="<%# UrlProcess.TruyenOnlineChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                        <%# Eval("Content_Headline")%>
                    </a>
                </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</div>