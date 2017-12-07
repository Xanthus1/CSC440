using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// This page is for a researcher to view their own paper with the ratings/comments
public partial class PaperView : System.Web.UI.Page
{
    Paper paper;


    protected void Page_Load(object sender, EventArgs e)
    {
        // init guest settings if session doesn't exist
        if (HttpContext.Current.Session["name"] == null)
        {
            // no current session, initialize session as guest
            Account.setGuestSession();
        }
        // Guests don't have access to conferences: show error and stop loading page
        if (HttpContext.Current.Session["accesslevel"].ToString().Equals("" + Account.ACCESS_GUEST))
        {
            form1.InnerHtml = "<b> Error: Login with your account to access the conferences page</b>";
            return;
        }

        
        // get paper ID from URL 
        //todo: make sure this reviewer has access to paper
        int paperID = int.Parse(Request.QueryString["PaperID"].ToString());
        paper = Paper.getPaper(paperID);

        //update paper data on page
        lbl_author.Text = paper.getAuthorName();
        lbl_description.Text =paper.getDescription();
        lbl_title.Text = paper.getTitle();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //pull paper from Paper folder based on filename in DB
        int confID = paper.getConfID();
        int authorID = Int32.Parse(HttpContext.Current.Session["userKey"].ToString());
        String docPath = Paper.getPaperPath(authorID, confID); // docpath is currently just filename

        byte[] Content = File.ReadAllBytes(Path.Combine(Server.MapPath("~/Papers/") + "/" + docPath));
        Response.ContentType = "text/docx";
        Response.AddHeader("content-disposition", "attachment; filename=" + docPath); // docpath is currently just filename
        Response.BufferOutput = true;
        Response.OutputStream.Write(Content, 0, Content.Length);
        Response.End();
    }
}