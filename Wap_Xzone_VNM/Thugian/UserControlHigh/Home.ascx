<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControlHigh.Home" %>
    
    <asp:Repeater ID="rptZone" runat="server" EnableViewState="false">
        <ItemTemplate>
            <div class="box-thugian">
                <h4>
                    <asp:Label ID="lblCatetoryName" runat="server" EnableViewState="False"></asp:Label>
                </h4>
                <ul class="list-truyen">

                    <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>