<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Conferences.aspx.cs" Inherits="Conferences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div style="text-align: center">
        <asp:Button ID="add_conf" runat="server" OnClick="add_conf_Click" Text="Add Conference" />
               
        <br />
               
        <asp:Table ID="confTable" runat="server" Width="85%" HorizontalAlign="Center">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="10%">Details/Register</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="25%">Conference</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50%">Description</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="15%">Date</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        </div>
    </form>
</asp:Content>

