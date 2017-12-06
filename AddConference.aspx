<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddConference.aspx.cs" Inherits="AddConference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <form runat="server">
           <br />
           <br />
        <table align="center">
        <tr>
            <td style="width: 181px; text-align: center">Conference Name</td>
            <td style="width: 451px">
                <asp:TextBox ID="con_name" runat="server"  OnTextChanged="tb_TextChanged" AutoPostBack="true" Height="16px" Width="432px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 181px; text-align: center; height: 157px;">Conference Description</td>
            <td style="width: 451px; height: 157px;">
                <asp:TextBox ID="con_desc" runat="server"  OnTextChanged="tb_TextChanged" AutoPostBack="true" Height="137px" Width="433px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 181px; text-align: center">Maximum Paper Submissions</td>
            <td style="width: 451px">
                <asp:TextBox ID="max_papers" runat="server"  OnTextChanged="tb_TextChanged" AutoPostBack="true" Height="16px" Width="46px"></asp:TextBox>
            </td>
        </tr>
        </table>
           <div style="text-align: center">
               <br />
               Upload an Image for This Conference<p style="text-align: center">
                   <asp:FileUpload ID="FileUploadControl" runat="server" />
               </p>
               <p style="text-align: center">
                   <asp:Label ID="StatusLabel" runat="server" text="Upload status: " />
               </p>
               <asp:Button ID="add_conf" runat="server" OnClick="btn_submitpaper_Click" Text="Add Conference" />
               <br />
               <br />
               <br />
           </div>
    </form>
</asp:Content>
