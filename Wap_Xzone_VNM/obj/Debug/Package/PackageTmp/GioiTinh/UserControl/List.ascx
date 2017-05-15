﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.GioiTinh.UserControl.List" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/GioiTinh/UserControl/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>
<%@ Register Src="/GioiTinh/UserControl/Paging.ascx" TagName="Paging" TagPrefix="uc3" %>

<!-- Begin .wapper -->
<div class="wapper">
<div class="content">


<uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

<ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.GioiTinhHome() %>"><i class="icon-caret-right"></i><span>Giới tính</span></a></li>
                <li><a href="<%= UrlProcess.GioiTinhChuyenMuc(ConvertUtility.ToInt32(catID.ToString()),1,CatName) %>"><i class="icon-caret-right"></i><span><%= CatName %></span></a></li>
            </ul>


<!-- begin tin tuc -->
<div class="newsCat">

    <div class="newsCat-head">
        <h2><a href="#" title="Tin hot"><%= CatName %></a></h2>
    </div>

    <div class="newsCat-content">
        
        <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="news">
            <h3>
                <a href="<%# UrlProcess.GioiTinhChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                    <%# Eval("Content_Headline")%>
                </a>
            </h3>
            <a href="<%# UrlProcess.GioiTinhChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                <img src="<%# AppEnv.GetAvatarByPath(Eval("Content_Avatar").ToString(),125,94) %>" alt=""/>
            </a>
            <p>
                <%# Eval("Content_Teaser")%>
            </p>
        </div>
            </ItemTemplate>
        </asp:Repeater>

       
        <uc3:Paging ID="Paging1" runat="server" EnableViewState="False" />

    </div>

</div>
<!-- end tin tuc -->

    <uc1:Category ID="Category1" runat="server" EnableViewState="False" />

</div>
</div>
<!-- End .wapper-->