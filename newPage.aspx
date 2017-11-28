<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="newPage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <div class="header">
        <div class="span">
            CSC 440 APPP
        </div>
    </div>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div id="xantest" runat="server"></div>
    Hey
    <div>
     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>    
</asp:Content>

