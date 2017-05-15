<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Game.UserControlHigh.List" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<%@ Register Src="Category.ascx" TagName="Category1" TagPrefix="uc2" %>

<div class="game">
        <div class="box-title">
            <div class="title">
                <h4>
                    <asp:Label ID="lblCategoryName" runat="server" EnableViewState="false"></asp:Label>
                </h4>
            </div>

        </div>
        <div class="list-game">
            <asp:Repeater ID="rptGameHay" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="border">
                            <a href="<%# UrlProcess.GameChiTiet(ConvertUtility.ToInt32(Eval("W_GameItemID")),Eval("GameName").ToString()) %>">
                                <img class="img-radius" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),83,82) %>" alt=""/>
                            </a>
                            <p class="name">
                                <%# AppEnv.TrimLength(Eval("GameNameUnicode").ToString(),15)%>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

    </div>

<uc2:Category1 ID="Category1" runat="server" EnableViewState="False" />