<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.Category" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="box-tag">
        <ul class="list-tag">

            <%--<li><a href="#">Nháº¡c quá»‘c táº¿</a></li>
            <li><a href="#">Äá»™ng váº­t hÃ i Æ°á»›c</a></li>
            <li><a href="#">Game show</a></li>
            <li><a href="#">Phim hoáº¡t hÃ¬nh</a></li>
            <li><a href="#" class="active">Trailer phim</a></li>--%>

            <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <li>
                        <a href="<%# UrlProcess.VideoChuyenMuc(ConvertUtility.ToInt32(Eval("W_VCategoryID").ToString()),1,Eval("Title").ToString()) %>">
                            <%# Eval("Title_Unicode")%>
                        </a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>

        </ul>
    </div>