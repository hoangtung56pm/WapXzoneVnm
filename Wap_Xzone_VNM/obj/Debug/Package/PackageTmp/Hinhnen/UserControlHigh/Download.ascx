<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Download.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControlHigh.Download" %>

<div class="anhnen-1">
    <div class="list-img">
        
        <asp:Panel ID="pnlNoiDung" runat="server" EnableViewState="false" Visible="false">
            <p>
                <asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal>
            </p>

            <p>
                <asp:HyperLink ID="lnkDownload" runat="server"></asp:HyperLink>
            </p>
        </asp:Panel>

        <asp:Panel ID="pnlThongBao" runat="server" EnableViewState="false" Visible="false">
            <p>
                <asp:Literal ID="ltrThongBao" runat="server"></asp:Literal>
            </p>
        </asp:Panel>

    </div>
</div>
