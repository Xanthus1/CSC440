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
    List<Conference> confList; // list of all active conferences
    

    protected void Page_Load(object sender, EventArgs e)
    {
        // init guest settings if session doesn't exist
        if (HttpContext.Current.Session["name"] == null)
        {
            // no current session, initialize session as guest
            Account.setGuestSession();
        }
        // Guests don't have access to conferences: show error
        if (HttpContext.Current.Session["accesslevel"].ToString().Equals(""+Account.ACCESS_GUEST))
        {
            // todo: show error message
            form1.InnerHtml = "<b> Error: Login with your account to access the conferences page</b>";
            return;
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
            //todo: use function
            td = new TableCell();
            td.Text = "" + DateTime.Today;
            tr.Cells.Add(td);

            confTable.Rows.Add(tr);

        } 
    }


    protected void btn_View_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Server.Transfer("ConferenceDetail.aspx?ConfID="+btn.Attributes["confID"],true);
        confTable.Visible = false;
    }
}