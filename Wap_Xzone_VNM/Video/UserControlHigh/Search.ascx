<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.Search" %>

<form id="Form1" runat="server">
            
            <div style="padding-top: 5px;" align="center">
                <asp:TextBox runat="server" ID="txtKey"></asp:TextBox>
                <asp:Button BackColor="#ff7e00" ForeColor="white" ID="btnSearch" Text="Tìm phim" runat="server" OnClick="btnSearch_Click"/>
            </div>

        </form>
