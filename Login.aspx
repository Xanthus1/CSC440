<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <form runat="server">
        <table>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="tb_email" runat="server"  OnTextChanged="tb_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="tb_password" runat="server"  OnTextChanged="tb_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        </table>
    <br />
    <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" Text="Login" />
        <br />
        <br />
        Don&#39;t have an account?<br />
        <asp:Button ID="btn_create_new_account" runat="server" OnClick="btn_create_new_account_Click" Text="Create New Account" />
        <br />
        <div id="warningDiv" runat="server"></div>
    </form>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

