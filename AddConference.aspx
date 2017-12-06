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
            </td>
        </tr>
        <tr>
            <td style="width: 181px; text-align: center; height: 157px;">Conference Description</td>
            <td style="width: 451px; height: 157px;">
            </td>
        </tr>
        <tr>
            <td style="width: 181px; text-align: center">Maximum Paper Submissions</td>
            <td style="width: 451px">

            </td>
        </tr>
        </table>
           <br />
           <div style="width:475px;margin-left:auto;margin-right:auto"> 
           <asp:Calendar ID ="datepicker" runat="server" Height="190px" Width="475px" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="FullMonth" OnSelectionChanged="datepicker_SelectionChanged">
               <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
               <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
               <OtherMonthDayStyle ForeColor="#999999" />
               <SelectedDayStyle BackColor="#333399" ForeColor="White" />
               <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
               <TodayDayStyle BackColor="#CCCCCC" />
               </asp:Calendar>
               </div>
           <div style="text-align: center">
               Selected Date:<br />
                <asp:TextBox ID="selected_date" runat="server" AutoPostBack="true" Height="16px" Width="227px"></asp:TextBox>
               <br />
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
