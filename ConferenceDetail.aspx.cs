using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConferenceDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // based on privelege and/or whether you have a paper for this conference
        // hide buttons as necessary (Register, Submit paper, View paper and Comments, Review papers)
        // todo: query based on registration access (reviewer or not)


        //todo: get Current conference from previous form

        //testing updating data from previous form
        if (Request.QueryString["ConfID"] == null)
        {
            lbl_Title.Text = "Error";
        }
        else {
            lbl_Title.Text = Request.QueryString["ConfID"].ToString();
        }

    }

    protected void btn_reviewpapers_Click(object sender, EventArgs e)
    {

    }

    protected void btn_viewpaper_Click(object sender, EventArgs e)
    {

    }

    protected void btn_checkin_Click(object sender, EventArgs e)
    {

    }

    protected void btn_submitpaper_Click(object sender, EventArgs e)
    {

    }
}