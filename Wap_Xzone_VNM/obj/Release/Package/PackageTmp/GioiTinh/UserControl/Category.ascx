<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.GioiTinh.UserControl.Category" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<!-- Begin chuyen muc -->
    <div class="newsCat">
        <div class="newsCat-head">
            <h2><a href="#" title="Tin hot">Chuyên mục</a></h2>
        </div>
        <div class="newsCat-content">
            <div class="news-late">
                <ul class="category-lis">
                    
                    <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li>
                                <a href="<%# UrlProcess.GioiTinhChuyenMuc(ConvertUtility.ToInt32(Eval("Zone_ID").ToString()),1,Eval("Zone_Name").ToString()) %>">
                                    <%# Eval("Zone_Name")%>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </ul>
            </div>
        </div>
    </div>
    <!-- End chuyen muc -->