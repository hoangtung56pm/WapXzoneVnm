<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WapXzone_VNM.VClip.UserControl.Header" %>
<%@ Import Namespace="WapXzone_VNM.VClip.Library" %>
<%@ Import Namespace="WapXzone_VNM.VClip.Library.UrlProcess" %>
<header>
    <h1 class="logo"></h1>   
    <a href="#" class="categoryIcon btn-category"></a> 
    <p class="mobile"><label><span><%= Msisdn %></span></label></p>
     <nav>   
        <label> 
            <a href="<%= UrlProcess.GetVideoCategoryUrl(lang.ToString(),width,"1") %>"><span>Mới cập nhật</span></a>
            <a href="<%= UrlProcess.GetVideoCategoryUrl(lang.ToString(),width,"2") %>"><span>Tải nhiều nhất</span></a>
            <a href="<%= UrlProcess.GetVideoCategoryUrl(lang.ToString(),width,"21") %>"><span>Yêu thích nhất</span></a>   
        </label>     
    </nav>

    

</header>
