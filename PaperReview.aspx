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
        <asp:DropDownList id="list_ratings"
                    AutoPostBack="True"
                    runat="server">

                  <asp:ListItem Selected="True" Value="Strongly Decline"> Strongly Decline </asp:ListItem>
                  <asp:ListItem Value="Decline"> Decline </asp:ListItem>
                  <asp:ListItem Value="Neutral"> Neutral </asp:ListItem>
                  <asp:ListItem Value="Accept"> Accept </asp:ListItem>
                  <asp:ListItem Value="Strongly Accept"> Strongly Accept </asp:ListItem>

               </asp:DropDownList>
        <br />
        <span style="text-decoration: underline">Review</span><br />
        <br />
        Public Comment:<asp:TextBox ID="public_comment" runat="server" Height="16px" Width="447px"></asp:TextBox>
        <br />
        (For Researcher)<br />
        <br />
        Private Comment:
        <asp:TextBox ID="private_comment" runat="server" Height="16px" Width="447px"></asp:TextBox>
        <br />
        (For Admin Only)<br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Submit Review" OnClick="Button2_Click" />
        <br />
    </form>
</asp:Content>

