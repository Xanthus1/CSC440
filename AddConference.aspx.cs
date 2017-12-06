using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddConference : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submitpaper_Click(object sender, EventArgs e)
    {
        //have to add image upload logic
        int maxPapers = 100;

        if (Int32.TryParse(max_papers.Text, out maxPapers))
        {
            maxPapers = Int32.Parse(max_papers.Text);
        }
        if (maxPapers > 1000)
        {
            maxPapers = 1000;
        }

        if (con_name.Text.Equals(""))
        {
            StatusLabel.Text = "Conference Add Failed: Conference name is blank";
        }
        else if (con_desc.Text.Equals(""))
        {
            StatusLabel.Text = "Conference Add Failed: Conference description is blank";
        }
        else
        {
            Conference conf = new Conference();
            conf.createConference(con_name.Text,con_desc.Text,maxPapers);
        }
    }
}