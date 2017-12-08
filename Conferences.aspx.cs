using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

// page for reviewers to review papers for conference
public partial class Conferences : System.Web.UI.Page
{
    Account account;
    List<Conference> confList; // list of all active conferences

    protected void Page_Load(object sender, EventArgs e)
    {
        // get account from session or init as Guest
        account = new Account();
        account.loadFromSession();

        // Guests don't have access to conferences: show error and stop loading page
        if (account.isGuest())
        {
            form1.InnerHtml = "<b> Error: Login with your account to access the conferences page</b>";
            return;
        }
        //check if user is admin, if not make the add conference button invisible
        if (!(account.isAdmin()))
        {
            add_conf.Visible = false;
        }

        // Get list of conferences from database
        confList = Conference.getConferenceList();

        // this function uses conference list to update the table on the page
        conferenceTableDisplay();
    }

    //method to return a list of conferences as a table
    // todo : changing from returning a string to editing ASP Table
    public void conferenceTableDisplay()
    {
        // add row for each conference
        foreach (Conference c in confList)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            //Button
            //todo: finalize code + click event
            Button btn = new Button();
            btn.Text = "View";
            btn.Attributes["confID"] = ""+c.getID();
            btn.Click += btn_View_Click;
            td.Controls.Add(btn);
            tr.Cells.Add(td);
            
            // Name
            td = new TableCell();
            td.Text = c.getName();
            tr.Cells.Add(td);

            //Description
            td = new TableCell();
            td.Text = c.getDescription();
            tr.Cells.Add(td);

            // date 
            td = new TableCell();
            td.Text = c.getDateTime().ToString();
            tr.Cells.Add(td);

            confTable.Rows.Add(tr);

        } 
    }

    // when you click view conference, go to conference detail 
    protected void btn_View_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Server.Transfer("ConferenceDetail.aspx?ConfID="+btn.Attributes["confID"],true);
        confTable.Visible = false;
    }

    protected void add_conf_Click(object sender, EventArgs e)
    {
        //send the user (only admin can see) to the add conference page
        Server.Transfer("AddConference.aspx");
    }
}