<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Papers.aspx.cs" Inherits="Papers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <form id="form1" runat="server">
        <asp:Table ID="paperTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="30%">Paper Title</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="20%">Author</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="25%">Times Reviewed</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="25%">Review</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

