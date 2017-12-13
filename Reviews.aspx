<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reviews.aspx.cs" Inherits="Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <form id="form1" runat="server">
        <asp:Table ID="reviewTable" runat="server" Width="100%" Height="40px">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Height="30px" Width="25%">Rating</asp:TableHeaderCell>
                <asp:TableHeaderCell Height="30px" Width="750%">Comment</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </form>
</asp:Content>
