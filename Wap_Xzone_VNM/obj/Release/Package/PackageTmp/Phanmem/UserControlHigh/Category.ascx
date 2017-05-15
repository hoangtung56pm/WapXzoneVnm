<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Phanmem.UserControlHigh.Category" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="category-phanmem">
    <h4 class="title-phanmem">
        Thể loại phần mềm
    </h4>
    <ul>
        
        <%--<li><a href="#">Vmg zone</a></li>
        <li><a href="#">Káº¿t ná»‘i</a></li>
        <li><a href="#">Tiá»‡n Ã­ch</a></li>
        <li><a href="#">GiÃ¡o dá»¥c</a></li>
        <li><a href="#">Giáº£i trÃ­</a></li>--%>

        <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
            <ItemTemplate>
                <li>
                    <a href="<%# UrlProcess.PhanMemChuyenMuc(ConvertUtility.ToInt32(Eval("W_AppCategoryID")),1,Eval("Title").ToString()) %>">
                        <%# Eval("Title_Unicode")%>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>

    </ul>
</div>