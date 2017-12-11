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
    Account account;
    Paper paper;
    Review review;
    List<Review> reviewList;
    Boolean isValidReview;

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

        
        // get paper ID from URL 
        int paperID = int.Parse(Request.QueryString["PaperID"].ToString());
        paper = Paper.getPaper(paperID);

        //load all reviews for this paper
        reviewList = Review.getReviewForPaper(paperID);

        foreach (Review r in reviewList)
        {
            //check if reviewer is valid
            if (r.getReviewerID() == account.getUserKey())
            {
                isValidReview = true;
                review = r;
            }
        }

        if (!isValidReview)
        {
            form1.InnerHtml = "<b> You do not have permission to review this paper.</b>";
            return;
        }

        //update paper data on page
        lbl_author.Text = paper.getAuthorName();
        lbl_description.Text =paper.getDescription();
        lbl_title.Text = paper.getTitle();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //pull paper from Paper folder based on filename in DB
        int confID = paper.getConfID();
        int authorID = paper.getAuthorID();
        String docPath = Paper.getPaperPath(authorID, confID); // docpath is currently just filename

        byte[] Content = File.ReadAllBytes(Path.Combine(Server.MapPath("~/Papers/") + "/" + docPath));
        Response.ContentType = "text/docx";
        Response.AddHeader("content-disposition", "attachment; filename=" + docPath); // docpath is currently just filename
        Response.BufferOutput = true;
        Response.OutputStream.Write(Content, 0, Content.Length);
        Response.End();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Review.submitReview(review.getID(),review.getPaperID(),review.getReviewerID(),list_ratings.SelectedValue,public_comment.Text, private_comment.Text);
    }
}