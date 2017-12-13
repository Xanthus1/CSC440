using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reviews : System.Web.UI.Page
{
    List<Review> reviewList;
    Conference conference;
    Account account;
    Paper paper;

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

        reviewList = new List<Review>();

        // conference ID passed by previous page
        int confID;
        try
        {
            confID = int.Parse(Request.QueryString["ConfID"].ToString());
        }

        catch (Exception ex)
        {
            form1.InnerHtml = "<b> Error loading the conference: "+ex+"</b>";
            return; // no confID selected, don't show anything
        }
        // get conference
        conference = Conference.getConference(confID);

        paper = Paper.getPaperByConfandUser(confID, account.getUserKey());
        reviewList = Review.getReviewForPaper(paper.getID());

        reviewTableDisplay();
    }

    private void reviewTableDisplay()
    {
        // add row for each paper
        // use i to keep count, paper[0] correlates with bid[0], etc.

        foreach (Review r in reviewList)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();

            // Rating
            td = new TableCell();
            td.Text = r.getRating();
            tr.Cells.Add(td);

            //Author
            td = new TableCell();
            td.Text = r.getComment();
            tr.Cells.Add(td);

            reviewTable.Rows.Add(tr);
        }
    }
}