<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Phim.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.Phim" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.Constant" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>


<div class="clear7px"></div>

<div class="tin-hot">
    <div class="box-title">
        <a class="title" href="<%= UrlProcess.YoutubeChuyenMuc(1,Constant.YoutubeFilmRewriteCatName) %>">PHIM</a>
    </div>
    
    <asp:Repeater runat="server" ID="rptTopNew" EnableViewState="False">
        <ItemTemplate>
            <div class="tin-hot-large">
        <div class="img">
            <a href="<%# UrlProcess.YoutubeChiTiet(ConvertUtility.ToInt32(Eval("Id")),Eval("Title_Kd").ToString()) %>">
                <img src="<%# AppEnv.GetTrueAvatarPath(Eval("Avatar").ToString()) %>" alt=""/>
            </a>
        </div>
        <div class="name">
            <a href="<%# UrlProcess.YoutubeChiTiet(ConvertUtility.ToInt32(Eval("Id")),Eval("Title_Kd").ToString()) %>">
                <%# Eval("Title")%>
            </a>
        </div>
    </div>
        </ItemTemplate>
    </asp:Repeater>

    

    <div class="border-bottom"></div>

    <div class="list-news">
        
        <asp:Repeater runat="server" ID="rptBottomNew" EnableViewState="False">
            <ItemTemplate>
                <div class="item">
            <a href="<%# UrlProcess.YoutubeChiTiet(ConvertUtility.ToInt32(Eval("Id")),Eval("Title_Kd").ToString()) %>">
                <img src="<%# AppEnv.GetTrueAvatarPath(Eval("Avatar").ToString()) %>" width="145" height="101" alt=""/>
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

</div>