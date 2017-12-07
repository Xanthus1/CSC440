<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <table>
            <tr><td>Name</td><td>
                <asp:TextBox ID="tb_name" runat="server" OnTextChanged="tb_TextChanged" AutoPostBack="false"></asp:TextBox>
                </td></tr>
            <tr><td>Email</td><td>
                <asp:TextBox ID="tb_email" runat="server" OnTextChanged="tb_TextChanged" AutoPostBack="false"></asp:TextBox>
                </td></tr>
            <tr><td>Password</td><td>
                <asp:TextBox ID="tb_password" runat="server" OnTextChanged="tb_TextChanged" AutoPostBack="false" AutoCompleteType="Disabled"></asp:TextBox>
                </td></tr>
            <tr><td>Confirm Password</td><td>
                <asp:TextBox ID="tb_passwordconfirm" runat="server" OnTextChanged="tb_TextChanged" AutoPostBack="false" AutoCompleteType="Disabled"></asp:TextBox>
                </td></tr>
        </table>
        <br />
        <div id="warningDiv" runat="server"></div>
        <br />
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" />
    </form>
</asp:Content>

