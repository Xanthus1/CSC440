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
            Description:&nbsp;<asp:Label ID="lbl_description" runat="server" Text="[ Description ]"></asp:Label>
        </p>
        <p style="text-align: center">
            <asp:Image ID="img_conf" runat="server" Height="202px" Width="298px" />
        </p>
        <p style="text-align: center">
            <asp:Label ID="lbl_status" runat="server" Text="Status: "></asp:Label>
        </p>
        <p style="text-align: center">
            <asp:Button ID="btn_checkin" runat="server" OnClick="btn_checkin_Click" Text="Check In" />
        </p>
        <p style="text-align: center">
            <asp:Button ID="btn_viewpapers" runat="server" OnClick="btn_viewpapers_Click" Text="View Papers" />
        </p>
        <p style="text-align: center">
        <asp:Button ID="btn_viewpaper" runat="server" OnClick="btn_viewpaper_Click" Text="View Paper and Comments" />
        </p>
        <p style="text-align: center">
            <asp:Button ID="btn_register_researcher" runat="server" OnClick="btn_register_Click" Text="Register As Researcher" Width="175px" />
        </p>
        <p style="text-align: center">
            <asp:Button ID="btn_register_reviewer" runat="server" OnClick="btn_register_Click" Text="Register As Reviewer" Width="175px" />
        </p>
        <p style="text-align: center">
            <strong>
            <asp:Label ID="lbl_paperSubmittal" runat="server" Text="-- Paper Submittal --" style="text-decoration: underline"></asp:Label>
            </strong>
        </p>
        <p style="text-align: center">
            <asp:FileUpload id="FileUploadControl" runat="server" Width="249px" />
        </p>
        <p style="text-align: center">
            <asp:label id="lbl_pdescription" runat="server" text="Paper Description"/>
        </p>
        <p style="text-align: center">
            &nbsp;
            <asp:TextBox ID="paper_desc" runat="server" AutoPostBack="false" Height="137px" Width="481px"></asp:TextBox>
            </p>
        <p style="text-align: center">
            <asp:Button ID="btn_submitpaper" runat="server" OnClick="btn_submitpaper_Click" Text="Submit Paper" />
        </p>
        <p style="text-align: center">
            <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
        </p>
        
    </form>
</asp:Content>

