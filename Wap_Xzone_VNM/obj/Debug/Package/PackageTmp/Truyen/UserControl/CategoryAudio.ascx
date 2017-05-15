<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryAudio.ascx.cs" Inherits="WapXzone_VNM.Truyen.UserControl.CategoryAudio" %>

<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

 <!-- Begin chuyen muc -->
        <div class="newsCat">
            <div class="newsCat-head">
                <h2><a href="#" title="Tin hot">Chuyên mục khác</a></h2>
            </div>
            <div class="newsCat-content">
                <div class="news-late">
                    <ul class="category-lis">

                        <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <a href="<%# UrlProcess.TruyenAudioChuyenMuc(ConvertUtility.ToString(Eval("StyleId").ToString()),1,Eval("StyleName").ToString()) %>">
                                        <%# Eval("StyleName")%>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
        </div>
        <!-- End chuyen muc -->