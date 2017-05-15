<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControlHigh.Detail" %>

<%@ Register Src="Home.ascx" TagName="Home" TagPrefix="uc1" %>

<div class="box-thugian">
                <h4>
                    <asp:Label ID="lblItemName" runat="server" EnableViewState="False"></asp:Label>
                </h4>
                
                <%--<p>--%>
                <div style="padding-left:5px; padding-right:5px;">
                    <asp:Literal ID="litContent" runat="server" EnableViewState="false"></asp:Literal>
                </div>
                    
                <%--</p>--%>

            </div>

<uc1:Home ID="Home1" runat="server" EnableViewState="False" />