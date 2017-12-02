<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr><td>Name</td><td>
            <asp:TextBox ID="tb_name" runat="server"></asp:TextBox>
            </td></tr>
        <tr><td>Password</td><td>
            <asp:TextBox ID="tb_password" runat="server"></asp:TextBox>
            </td></tr>
    </table>
<br />
<asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" />
</asp:Content>

