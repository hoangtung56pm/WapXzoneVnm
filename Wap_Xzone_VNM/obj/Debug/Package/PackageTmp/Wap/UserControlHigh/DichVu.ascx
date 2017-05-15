<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DichVu.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlHigh.DichVu" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<div class="dich-vu">
    
   <%-- <div class="box-title" style="height: 40px;">
        <div class="title">
            <h4>Dịch vụ khác</h4>
        </div>
    </div>--%>
    
     <div class="box-title">
        <a class="title" href="#">Dịch vụ khác</a>
    </div>

    <div class="list-dichvu">
        
        <asp:Repeater ID="rptDichVu" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="item">
                    <a href="<%# AppEnv.NavigateUrlHigh(Eval("CP_Url").ToString()) %>">
                        <img src="<%# AppEnv.GetTrueAvatarPath(Eval("CP_Category_Avatar").ToString().Replace("~", "")) %>" alt=""/>
                    </a>
                    <p class="name">
                        <%# Eval("CP_CategoryUnicode") %>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</div>