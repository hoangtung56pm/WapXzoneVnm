<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.Video" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="clear7px"></div>

<div class="tin-hot">
    <div class="box-title">
        <a class="title" href="<%= UrlProcess.VideoHome() %>">Video</a>
    </div>
    
    <asp:Repeater runat="server" ID="rptTopNew" EnableViewState="False">
        <ItemTemplate>
            <div class="tin-hot-large">
        <div class="img">
            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                <%--<img src="<%# AppEnv.GetAvatar(Eval("VThumnail").ToString().Replace("~/Upload","/Upload"),306,172) %>" alt=""/>--%>
                <%--<img src="<%# AppEnv.GetTrueAvatarPath(Eval("VThumnail").ToString()) %>" width="306" height="172" alt=""/>--%>
                <img src="<%# AppEnv.GetTrueAvatarPath(Eval("VThumnail").ToString()) %>" alt=""/>
            </a>
        </div>
        <div class="name">
            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                <%# Eval("VTitle_Unicode")%>
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
            <a href="<%# UrlProcess.VideoChiTiet(ConvertUtility.ToInt32(Eval("W_VItemID")),Eval("VTitle").ToString()) %>">
                <%--<img src="<%# AppEnv.GetAvatar(Eval("VThumnail").ToString().Replace("~/Upload","/Upload"),145,0) %>" alt=""/>--%>
                <img src="<%# AppEnv.GetTrueAvatarPath(Eval("VThumnail").ToString()) %>" width="145" height="101" alt=""/>
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

</div>