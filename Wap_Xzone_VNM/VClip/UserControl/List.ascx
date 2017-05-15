<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.VClip.UserControl.List" %>
<%@ Import Namespace="WapXzone_VNM.VClip.Library" %>
<%@ Import Namespace="WapXzone_VNM.VClip.Library.UrlProcess" %>

<%@ Register Src="Pagging.ascx" TagName="Paging" TagPrefix="uc1" %>



<div class="main-container">
    
    <h4 class="otherVideo">
        <asp:HyperLink CssClass="link-non-white" ID="lnkHomeChannel" runat="server" EnableViewState="False">Trang chủ</asp:HyperLink> » 
        <asp:HyperLink CssClass="link-non-white" ID="lnkCateChannel" runat="server" EnableViewState="False"></asp:HyperLink>
    </h4>

    <ul class="listVideo">
        
        <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
            <ItemTemplate>
                 <li>
                    <div class="item">
                <a href="<%# UrlProcess.GetVideoDetailUrl(lang.ToString(),width,Eval("W_VItemID").ToString()) %>" class="imgVideo">
                    <img src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload/") %>" width="88" height="65" alt=""/><span><%# AppEnv.TimeRemove(Eval("VDuration").ToString()) %></span>
                </a>
                <div class="descVideo">
                    <h2>
                        <a class="titleVideo" href="<%# UrlProcess.GetVideoDetailUrl(lang.ToString(),width,Eval("W_VItemID").ToString()) %>">
                            <%# Eval("VTitle_Unicode")%>
                        </a>
                    </h2>  
                    <p class="rate"><span style="width: 40%;"></span></p>
                    <label class="eye"><%# Eval("T_Vinaphone_Preview") %></label>   
                    <p class="block">
                        <label class="strong"><%# AppEnv.ConvertToMb(Eval("VMobileSize").ToString()) %>MB</label>
                        <label class="like"><%# Eval("T_Vinaphone_Download") %></label>
                        <label class="time"><%# AppEnv.TimeRemove(Eval("VDuration").ToString()) %></label>
                    </p>
                </div> 
                <a href="<%# UrlProcess.GetVideoDetailUrl(lang.ToString(),width,Eval("W_VItemID").ToString()) %>" class="viewDetail">Chi tiết</a>
                <span class="hoverState"></span>   
            </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>

    </ul>

    <div class="clear10px"></div>
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
     <div class="clear10px"></div>
 </div>
