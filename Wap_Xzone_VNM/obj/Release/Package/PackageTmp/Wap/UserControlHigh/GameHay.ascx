<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameHay.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.GameHay" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="clear7px"></div>

<div class="tin-hot">
    <div class="box-title">
        <a class="title" href="<%= UrlProcess.GameHome() %>">Game</a>
    </div>

    <div class="list-news">
        
        <asp:Repeater runat="server" ID="rptBottom" EnableViewState="False">
            <ItemTemplate>
                <div class="item-game">
            <a href="<%# UrlProcess.GameChiTiet(ConvertUtility.ToInt32(Eval("W_GameItemID")),Eval("GameName").ToString()) %>">
                <img class="img-radius" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),146,146) %>" alt=""/>
            </a>

            <p class="description" style="height: 30px;">
                <a href="<%# UrlProcess.GameChiTiet(ConvertUtility.ToInt32(Eval("W_GameItemID")),Eval("GameName").ToString()) %>">
                    <%# AppEnv.TrimLength(Eval("GameNameUnicode").ToString(),15) %>
                </a>
            </p>
        </div>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>

</div>