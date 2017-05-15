<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterForDownload.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.FilterForDownload" %>

<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="filter">
    <ul class="nav-top">
        <li><a href="<%= UrlProcess.GameHome() %>">Trang chủ</a></li>
        <li><a href="<%= UrlProcess.VideoHome() %>">Video</a></li>
        <li><a href="/Wap/DailyInfo.aspx?lang=1&w=320">Daily info</a></li>
    </ul>
</div>