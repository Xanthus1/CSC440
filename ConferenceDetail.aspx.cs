using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConferenceDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conference conf;
        // based on privelege and/or whether you have a paper for this conference
        // hide buttons as necessary (Register, Submit paper, View paper and Comments, Review papers)
        // todo: query based on registration access (reviewer or not)


        //Get Current conference from previous form
        if (Request.QueryString["ConfID"] == null)
        {
            lbl_Title.Text = "Error";
            conf = new Conference();
        }
        else {
            // get ID from previous form
            String idString = Request.QueryString["ConfID"].ToString();
            int id = Int32.Parse(idString);

            // get conference object from table using id
            conf = Conference.getConference(id);
            lbl_Title.Text = conf.getName();
            lbl_description.Text = conf.getDescription();
            //todo: get dateTime
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
        if (FileUploadControl.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                StatusLabel.Text = "Upload status: File uploaded!";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
}