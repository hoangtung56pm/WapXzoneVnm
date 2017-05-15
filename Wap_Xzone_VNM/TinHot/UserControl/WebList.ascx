﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebList.ascx.cs" Inherits="WapXzone_VNM.TinHot.UserControl.WebList" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/TinHot/UserControl/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Paging.ascx" TagName="Paging" TagPrefix="uc2" %>

<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc3" %>

<!-- Begin .wapper -->
<div class="wapper">
<div class="content">


<ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <%--<li><a href="<%= UrlProcess.TinTucHome() %>"><i class="icon-caret-right"></i><span>Tin Tức</span></a></li>--%>
                <%--<li><a href="<%= UrlProcess.TinTucChuyenMuc(ConvertUtility.ToInt32(catID.ToString()),1,CatName) %>"><i class="icon-caret-right"></i><span><%= CatName %></span></a></li>--%>
            </ul>

<!-- begin tin tuc -->
<div class="newsCat">
    
    <div class="newsCat-head">
        <h2><a href="#" title="Tin khuyen mai"><%= CatName %></a></h2>
    </div>

    <div class="newsCat-content">
        
        <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="news">
                    
                    <h3>
                        <a href="<%# UrlProcess.WebTinTucChiTiet(Eval("Id").ToString(),Eval("Title_kd").ToString()) %>">
                            <%# Eval("Title")%>
                        </a>
                    </h3>

                    <%--<a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                        <img src="<%# AppEnv.NavigateGetAvatar(Eval("Content_Avatar").ToString(),125,94,catID) %>" alt=""/>
                    </a>--%>

                    <p>
                        <%# AppEnv.TrimLength( UnicodeUtility.RemoveHtmlTags(Eval("Content").ToString()) ,60) %>
                    </p>
                    
                    <%--<%# ConvertUtility.ToDateTime(Eval("Content_CreateDate")).ToString("dd/MM hh:mm") %>--%>

                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</div>
<!-- end tin tuc -->

<%--<uc1:Category ID="Category1" runat="server" EnableViewState="False" />--%>
    
</div>
</div>
<!-- End .wapper-->