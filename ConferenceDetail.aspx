<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConferenceDetail.aspx.cs" Inherits="ConferenceDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <p style="text-align: center">
            <asp:Label ID="lbl_Title" runat="server" Text="[ Conference Title ]"></asp:Label>
&nbsp;-
            <asp:Label ID="lbl_datetime" runat="server" Text="[ Date / Time ]"></asp:Label>
        </p>
        <p style="text-align: center">
            <asp:Image ID="img_conf" runat="server" Height="98px" Width="117px" />
        </p>
        <p style="text-align: center">
            <asp:Button ID="btn_checkin" runat="server" OnClick="btn_checkin_Click" Text="Check In" />
        </p>
        <p style="text-align: center">
&nbsp;<asp:Label ID="lbl_description" runat="server" Text="[ Description ]"></asp:Label>
        </p>
        <p style="text-align: center">
&nbsp;<asp:Button ID="btn_viewpaper" runat="server" OnClick="btn_viewpaper_Click" Text="View Paper and Comments" />
            <asp:Button ID="btn_reviewpapers" runat="server" OnClick="btn_reviewpapers_Click" Text="Review Papers" />
        </p>
        <p style="text-align: center">
            <asp:Button ID="btn_submitpaper" runat="server" OnClick="btn_submitpaper_Click" Text="Submit Paper" />
        </p>
    </form>
</asp:Content>

