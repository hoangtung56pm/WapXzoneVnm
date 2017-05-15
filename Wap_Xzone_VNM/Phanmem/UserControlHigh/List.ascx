<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Phanmem.UserControlHigh.List" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<div class="box-phanmem">

    <h4 class="title-phanmem">
        <asp:Label ID="lblChuyenMuc" runat="server" EnableViewState="false"></asp:Label>
    </h4>

    <div class="box">
        <div class="list-game">
            <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="border">
                            <a href="<%# UrlProcess.PhanMemChiTiet(ConvertUtility.ToInt32(Eval("W_AppItemID")),Eval("AppName").ToString()) %>">
                                <img class="img-radius"  alt="" src="<%# AppEnv.GetAvatarByPath(Eval("Avatar").ToString(),70,70) %>">
                            </a>
                            <p class="phanmem-height">
                                <%# AppEnv.TrimLength(Eval("AppNameUnicode").ToString(),50) %>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

</div>