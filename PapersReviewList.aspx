<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PapersReviewList.aspx.cs" Inherits="Papers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="btnAssignReview" runat="server" Text="Assign Reviews to Bids" OnClick="btnAssignReview_Click"/> 
        <br />
        <asp:Table ID="paperTable" runat="server" Width="100%" Height="40px">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Height="30px" Width="20%">Paper Title</asp:TableHeaderCell>
                <asp:TableHeaderCell Height="30px" Width="20%">Author</asp:TableHeaderCell>
                <asp:TableHeaderCell Height="30px" Width="20%">Description</asp:TableHeaderCell>
                <asp:TableHeaderCell Height="30px" ID="headerBid" Width="20%">Bid Score</asp:TableHeaderCell>
                <asp:TableHeaderCell Height="30px" ID="headerReview" Width="20%">Review</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

