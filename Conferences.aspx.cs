using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// page for reviewers to review papers for conference
public partial class Conferences : System.Web.UI.Page
{
    List<Conference> confList; // list of all active conferences

    protected void Page_Load(object sender, EventArgs e)
    {
        confList = new List<Conference>();

        //todo: Get updated list of conferences from database

        DateTime date = DateTime.Today;
        confList.Add(new Conference(1, "Conf", "Description thing", 2, "here", date));

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
        Server.Transfer("ConferenceDetail.aspx?ConfID="+btn.Text,true);
        confTable.Visible = false;
    }
}