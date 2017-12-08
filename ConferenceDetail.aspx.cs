﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConferenceDetail : System.Web.UI.Page
{
    static String IMAGE_RESOURCE_PATH = "/papers"; // todo: is this used or needed?
    Account account;
    Conference conf; // store conference loaded on this page
    Registration registration; // store registration details (whether checked in or registered or not)


    protected void Page_Load(object sender, EventArgs e)
    {
        // get account from session or init as Guest
        account = new Account();
        account.loadFromSession();

        // Guests don't have access to conferences: show error and stop loading page
        if (account.isGuest())
        {
            form1.InnerHtml = "<b> Error: Login with your account to access the Conference details page</b>";
            return;
        }

        //Get Current conference from URL (passed from conference list button)
        if (Request.QueryString["ConfID"] == null)
        {
            lbl_Title.Text = "Error";
            conf = new Conference();
        }
        else
        {
            // get ID from previous form
            String idString = Request.QueryString["ConfID"].ToString();
            int confID = Int32.Parse(idString);

            // get conference object from Database using id
            conf = Conference.getConference(confID);

            // update data on page from conference
            lbl_Title.Text = conf.getName();
            lbl_description.Text = conf.getDescription();
            lbl_datetime.Text = conf.getDateTime().ToString();
        }

        // get Registration info / init registration object
        // we need this to get registration and checkin status before updating the page controls
        registration = conf.getRegistration(account.getUserKey());

        //hide buttons based on registration / checked in status / privilege
        refreshPageVisibleControls();

        // image handeling: Burden comment?
        if (!this.IsPostBack)
        {
            img_conf.ImageUrl = "~/Images/" + conf.getImagePath();
        }
    }


    protected void btn_reviewpapers_Click(object sender, EventArgs e)
    {
        Server.Transfer("Papers.aspx?ConfID=" + conf.getID());
    }

    // button to view your currently submitted paper
    protected void btn_viewpaper_Click(object sender, EventArgs e)
    {
        //pull paper from Paper folder based on filename in DB
        String docPath = Paper.getPaperPath(account.getUserKey(),conf.getID()); // docpath is currently just filename

        byte[] Content = File.ReadAllBytes(Path.Combine(Server.MapPath("~/Papers/") + "/" + docPath));
        Response.ContentType = "text/docx";
        Response.AddHeader("content-disposition", "attachment; filename=" + docPath); // docpath is currently just filename
        Response.BufferOutput = true;
        Response.OutputStream.Write(Content, 0, Content.Length);
        Response.End();
    }

    protected void btn_checkin_Click(object sender, EventArgs e)
    {
        registration.checkIn();
    }

    protected void btn_register_Click(object sender, EventArgs e)
    {
        // depending on which button was pressed, set the privilege level
        Button btn = (Button)sender;

        if (btn.ID.Equals("btn_register_researcher"))
        {
            registration.setPrivilege(Registration.PRIV_RESEARCHER);
        }
        else
        {
            registration.setPrivilege(Registration.PRIV_REVIEWER);
        }

        // use conference object to process registration details, and register user to conference
        conf.processNewRegistration(registration);

        // change visibility of controls based on registration / privilege
        refreshPageVisibleControls();

    }

    // refreshes the controls visible on the page based on registration status and privilege
    protected void refreshPageVisibleControls()
    {
        //todo: Handeling viewing your own paper
        btn_viewpaper.Visible = false; // todo: allow this is you're a researcher?

        // if you're already registered, don't show register buttons
        if (registration.isRegistered())
        {
            btn_register_researcher.Visible = false;
            btn_register_reviewer.Visible = false;

            // if you're registered, check if you've submitted a paper
            // if you have, hide the paper submittal
            int authorID = Int32.Parse(HttpContext.Current.Session["userKey"].ToString());
            int confID = conf.getID();

            if (account.hasPaperForConf(confID))
            {
                StatusLabel.Visible = false;
                FileUploadControl.Visible = false;
                btn_submitpaper.Visible = false;
            }
            else
            {
                StatusLabel.Visible = false;
            }
            

            // if already checked in , hide checkin button
            if (registration.isCheckedIn())
            {
                btn_checkin.Visible = false;
            }

        }
        else
        {
            // if you're not registered, you can't submit a paper or checkin
            StatusLabel.Visible = false;
            FileUploadControl.Visible = false;
            btn_submitpaper.Visible = false;

            // not registered, can't check in
            btn_checkin.Visible = false;
        }

        //todo: Burden hide the view paper button unless you have one submitted

        
    }

    //todo: Burden comments
    protected void btn_submitpaper_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                string fileName = Path.GetFileName(FileUploadControl.FileName);
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;

                if (extension.Equals(".docx", StringComparison.OrdinalIgnoreCase))
                {

                    String path = Path.Combine(Server.MapPath("~/Papers/") + fileName);
                    FileUploadControl.SaveAs(path);
                    StatusLabel.Text = "Upload status: File uploaded to "+path;

                    String title = lbl_Title.Text;
                    
                    account.submitPaper(conf.getID(), title, fileName); // currently works just using filename, all papers in /papers/ directory
                }
                else
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. " + extension + " Invalid file extension. DOCX is the only supported file type";
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
}

