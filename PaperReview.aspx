<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperReview.aspx.cs" Inherits="PaperView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        Paper Title:
        <asp:Label ID="lbl_title" runat="server" Text="[ Title ] "></asp:Label>
        <br />
        <br />
        Author:
        <asp:Label ID="lbl_author" runat="server" Text="[ Author ]"></asp:Label>
        <br />
        <br />
        Description:
        <asp:Label ID="lbl_description" runat="server" Text="[ Description ]"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download Paper" />
        <br />
        <br />
        <br />
        <span style="text-decoration: underline">Review</span><br />
        <br />
        Public Comment:<asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="447px"></asp:TextBox>
        <br />
        (For Researcher)<br />
        <br />
        Private Comment:
        <asp:TextBox ID="TextBox2" runat="server" Height="16px" Width="447px"></asp:TextBox>
        <br />
        (For Admin Only)<br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Submit Review" />
        <br />
    </form>
</asp:Content>

