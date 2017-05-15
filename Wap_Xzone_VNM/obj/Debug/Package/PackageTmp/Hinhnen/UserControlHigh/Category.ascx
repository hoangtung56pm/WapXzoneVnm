<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControlHigh.Category" %>

<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="category-phanmem">
    <h4 class="title-phanmem">
        Thể loại Hình nền
    </h4>
    <ul>
        <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
            <ItemTemplate>
                <li>
                    <a href="<%# UrlProcess.HinhNenChuyenMuc(ConvertUtility.ToInt32(Eval("W_CategoryID")),1,Eval("Title").ToString()) %>">
                        <%# Eval("Title_Unicode")%>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>