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
        else
        {
            max_papers.Text = "100";
            StatusLabel.Text = "Max Paper input was invalid, default is set to 100.";
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
            try
            {
                conf.createConference(con_name.Text, con_desc.Text, maxPapers, datepicker.SelectedDate);
                StatusLabel.Text = "Conference Add Successful!";
                con_desc.Text = "";
                max_papers.Text = "";
                con_name.Text = "";
                selected_date.Text = "";
                datepicker.SelectedDate = DateTime.MinValue;
            }
            catch
            {

            }
        }
    }

    protected void datepicker_SelectionChanged(object sender, EventArgs e)
    {
        selected_date.Text = datepicker.SelectedDate.ToShortDateString();
    }
}