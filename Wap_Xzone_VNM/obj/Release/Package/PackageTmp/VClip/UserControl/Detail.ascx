<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.VClip.UserControl.Detail" %>
<%@ Import Namespace="WapXzone_VNM.VClip.Library" %>
<%@ Import Namespace="WapXzone_VNM.VClip.Library.UrlProcess" %>
<div class="main-container">
    <div class="topToolbar">
        <p class="clearfix">
            <asp:HyperLink class="back" ID="hplBack" runat="server" EnableViewState="false">Quay lại</asp:HyperLink>
            <a href="#" class="btn-like">Thích</a>
        </p>
    </div>
    <asp:Repeater ID="rptDetail" runat="server" OnItemCommand="rptDetail_ItemCommand">
        <ItemTemplate>
            <div class="videoDetail">
                <a href="#">
                    <img src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload/") %>"
                        alt="" />
                </a>
                <asp:LinkButton ID="lnkPlay" CommandName="Play" CommandArgument='<%# Eval("W_VItemID") %>'
                    runat="server" CssClass="btn-play">Play</asp:LinkButton>
                <span class="videotime">
                    <%# AppEnv.TimeRemove(Eval("VDuration").ToString()) %></span>
            </div>
            <div class="detail">
                <h2>
                    <%# Eval("VTitle_Unicode")%></h2>
                <p>
                    Thể loại:<%# Eval("Web_Name")%></p>
                <div class="line">
                    <p class="rate">
                        <span style="width: 40%;"></span>
                    </p>
                    <label class="strong">
                        <%# AppEnv.ConvertToMb(Eval("VMobileSize").ToString()) %>MB</label>
                    <label class="like">
                        <%# Eval("T_Vinaphone_Download") %></label>
                    <label class="time">
                        <%# AppEnv.TimeRemove(Eval("VDuration").ToString()) %></label>
                    <label class="eye">
                        <%# Eval("T_Vinaphone_Preview") %></label>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear10px">
    </div>
    <div class="download">
        <ul class="listOption">
            <li><b>
                <asp:Label ID="lblDownPrice" runat="server" EnableViewState="true"></asp:Label></b>
                <label>
                    <asp:LinkButton ID="lnkTaiVeMay" runat="server" CssClass="link-non-black" OnClick="lnkTaiVeMay_Click">Tải về máy</asp:LinkButton>
                </label>
            </li>
            <li><b>
                <asp:Label ID="lblViewPrice" runat="server" EnableViewState="true"></asp:Label></b>
                <label>
                    <asp:LinkButton ID="lnkXemOnline" runat="server" CssClass="link-non-black" OnClick="lnkXemOnline_Click">Xem online</asp:LinkButton>
                </label>
            </li>
            <li></li>
        </ul>
    </div>
    <div class="clear10px">
    </div>
    
    <h4 class="otherVideo">
        Video cùng thể loại</h4>
    <ul class="listVideo">
        <asp:Repeater ID="rptCungTheLoai" runat="server" EnableViewState="false">
            <ItemTemplate>
                <li>
                    <div class="item">
                        <a href="<%# UrlProcess.GetVideoDetailUrl(lang.ToString(),width,Eval("W_VItemID").ToString()) %>"
                            class="imgVideo">
                            <img src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload/") %>"
                                width="88" height="65" alt="" />
                            <span>
                                <%# AppEnv.TimeRemove(Eval("VDuration").ToString()) %></span> </a>
                        <div class="descVideo">
                            <h2>
                                <a class="titleVideo" href="<%# UrlProcess.GetVideoDetailUrl(lang.ToString(),width,Eval("W_VItemID").ToString()) %>">
                                    <%# Eval("VTitle_Unicode")%>
                                </a>
                            </h2>
                            <p class="rate">
                                <span style="width: 40%;"></span>
                            </p>
                            <label class="eye">
                                <%# Eval("T_Vinaphone_Preview") %></label>
                            <p class="block">
                                <label class="strong">
                                    <%# Eval("VMobileSize") %>Kb</label>
                                <label class="like">
                                    <%# Eval("T_Vinaphone_Download") %></label>
                                <label class="time">
                                    <%# AppEnv.TimeRemove(Eval("VDuration").ToString()) %></label>
                            </p>
                        </div>
                        <a href="<%# UrlProcess.GetVideoDetailUrl(lang.ToString(),width,Eval("W_VItemID").ToString()) %>"
                            class="viewDetail">Chi tiết</a> <span class="hoverState"></span>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
