<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControlHigh.List" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<%@ Register Src="Category.ascx" TagName="Category1" TagPrefix="uc2" %>


<div class="anhnen-1">
    
    <div class="list-img">
        <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="item">
                    <div class="border-left"></div>
                    <a href="<%# UrlProcess.HinhNenChiTiet(ConvertUtility.ToInt32(Eval("W_WItemID").ToString()),Eval("WTitle").ToString()) %>">
                        <img src="<%# AppEnv.GetTrueAvatarPath(Eval("WThumnail").ToString().Replace("thumb_","")) %>" alt="" />
                    </a>
                    <div class="info">
                        <b><%# Eval("WTitle_Unicode")%></b>
                        <br />
                        <span>Thể loại: <%# Eval("Web_Name")%></span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <%--<div class="view-all">
        <a href="<%= UrlProcess.HinhNenChuyenMuc(catId,1,catName) %>">
            <img alt="" src="/Content/asset/Images/btn-view-all.png"/>
        </a>
    </div>--%>

    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

</div>

<uc2:Category1 ID="Category1" runat="server" EnableViewState="False" />