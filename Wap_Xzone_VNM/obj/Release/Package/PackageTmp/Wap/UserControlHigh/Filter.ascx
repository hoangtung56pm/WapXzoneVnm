<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Filter.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.Filter" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="filter">
    <ul class="nav-top">
        <li><a href="<%= UrlProcess.GameHome() %>">Game</a></li>
        <li><a href="<%= UrlProcess.VideoHome() %>">Video</a></li>
        <li><a href="/Wap/DailyInfo.aspx?lang=1&w=320">Daily info</a></li>
    </ul>
</div>
