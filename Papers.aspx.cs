﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// list of papers for anybody to view
// if you're a reviewer and in bid phase , you will see a bid column
// if you're an admin, you will see a button to change to the Review phase and assign reviews

public partial class Papers : System.Web.UI.Page
{
    static int MAX_REVIEWS = 3; // Max number of reviews a paper can have
    Conference conference;
    List<Paper> paperList;
    List<Bid> bidList;
    List<Review> reviewList;
    Account account;
    Registration registration;

    // booleans to hide/show actions for papers depending on 
    // conference phase, and privilege for this conference
    private Boolean showBids = false;
    private Boolean showReview = false;
    private Boolean showView = false;

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
      
        paperList = new List<Paper>();

        // conference ID passed by previous page
        int confID;
        try
        {
            confID = int.Parse(Request.QueryString["ConfID"].ToString());
        }
        catch(Exception ex)
        {
            lbl_status.Visible = false;
            lbl_status.Text = "Error loading conference: " + ex.Message;
            return; // no confID selected, don't show anything
        }
        // get conference
        conference = Conference.getConference(confID);

        // get registration (for privilege, to see whether you can bid or not
        registration = conference.getRegistration(account.getUserKey());


        setPageDisplay(); // makes changes to the header based on conference phase, and whether admin or not

        getPapersBids(); // gets papers and bids for this conference
        
        paperTableDisplay(); // displays paper tables with bids
        
    }

    // makes changes to the header based on conference phase, and whether admin or not
    private void setPageDisplay()
    {
        // hide the "Assign reviews to bid button", until logic below determins to show it
        btnAssignReview.Visible = false;

        //during bid phase, hide the review columns
        if (conference.isBidPhase())
        {
            headerReview.Visible = false;

            // if admin in this phase, show the button to go to next phase
            if (account.isAdmin())
            {
                btnAssignReview.Visible = true;
            }
        }
        else
        {
            // in review phase, hide Bid column
            headerBid.Visible = false;
        }

        // if not a reviewer, hide the header and bid column regardless of phase
        if (!(registration.isReviewer()))
        {
            headerReview.Visible = false;
            headerBid.Visible = false;
        }
    }

    //method to add papers/related buttons to table
    private void paperTableDisplay()
    {
        // add row for each paper
        // use i to keep count, paper[0] correlates with bid[0], etc.
        int i = 0;
        Bid b;

        foreach (Paper p in paperList)
        {
            // get review for this paper (if you have one)
            // we can use review.exists() to check whether one does or not
            Review review = account.getReviewForPaper(p.getID());

            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            b = bidList[i];

            // Title
            td = new TableCell();
            td.Text = p.getTitle();
            tr.Cells.Add(td);

            //Author
            td = new TableCell();
            td.Text = p.getAuthorName();
            tr.Cells.Add(td);

            // description
            td = new TableCell();
            td.Text = p.getDescription();
            tr.Cells.Add(td);

            // bid values
            // only show if in bid phase and if reviewer
            if (conference.isBidPhase() && registration.isReviewer())
            {
                td = new TableCell();
                TextBox tb = new TextBox();
                tb.Text = "" + b.getRating();
                td.Controls.Add(tb);
                tb.TextChanged += tb_bid_Changed;
                tb.Attributes["bidIndex"] = "" + i;
                tb.AutoPostBack = true;
                tr.Cells.Add(td);
            }

            //Review button 
            // only show if in review phase and you are reviewer
            
            if (conference.isReviewPhase() && registration.isReviewer())
            {
                // return a blank cell, unless you have a review, in which case show a button 
                td = new TableCell();
                if (conference.isReviewPhase() && review.exists())
                {
                    td = new TableCell();
                    Button btn = new Button();
                    btn.Text = "Review";
                    btn.Attributes.Add("paperID", "" + p.getID()); // store key attribute, so onclick method knows which paper to review
                    btn.Click += btn_Review_Click;
                    td.Controls.Add(btn);
                }
                tr.Cells.Add(td);
            }
            

            paperTable.Rows.Add(tr);
           

            i++;
        }
    }
    protected void getPapersBids()
    {   
        paperList = new List<Paper>();
        bidList = new List<Bid>();

        // get table joining papers for this conference and bids for this reviewer
        // left join, get all papers even if you don't have a current bid, a bid obj will be created
        String sqlSel = "u.name as username," +
            "p.id as paperid, p.authorid as authorid, p.docpath as docpath, p.confid as confid, p.title as title," +
            "p.description as description, b.id as bkey, b.rating as rating";

        DataTable myTable = DBHelper.dataTableFromQuery("SELECT " + sqlSel
            + " FROM papers p "
            + "LEFT JOIN bid b ON p.id=b.paperid "
            + "LEFT JOIN user u ON p.authorid=u.id "
            + "WHERE p.confid=" + conference.getID(),
            "root", "");

        // convert retrieved data to Paper and Bid objects on the table
        // Reference these objects when performing button operations
        foreach (DataRow row in myTable.Rows)
        {
            Paper p = new Paper(Int32.Parse(row["paperid"].ToString()),
                Int32.Parse(row["authorid"].ToString()),
                row["username"].ToString(),
                conference.getID(),
                row["title"].ToString(),
                row["description"].ToString(),
                row["docpath"].ToString()
                );

            paperList.Add(p);


            Bid b;
            // if there isn't a bid for this paper, initialize a bid objects 
            // the button method in the table will set the rating, and save it to the db

            if (row["bkey"].ToString().Equals(""))
            {
                b = new Bid(account.getUserKey(),
                    Int32.Parse(row["paperid"].ToString()));
            }
            else
            {
                // if there is a bid object, load id and 
                int bkey = int.Parse(row["bkey"].ToString());
                int paperID = int.Parse(row["paperid"].ToString());
                int rating = int.Parse(row["rating"].ToString());

                b = new Bid(bkey, account.getUserKey(), paperID, rating);
            }
            bidList.Add(b);

        }
    }

    protected void btn_Review_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Server.Transfer("PaperReview.aspx?PaperID=" + btn.Attributes["paperID"], true);
    }

    protected void tb_bid_Changed(object sender, EventArgs e)
    {
        // get bid index from text changed sender
        TextBox tb = (TextBox)sender;
        int bidIndex =   int.Parse(tb.Attributes["bidIndex"].ToString());
        int newRating = int.Parse(tb.Text);

        // get bid object from list
        // save bid with updated value
        bidList[bidIndex].saveBid(newRating);
    }

    // assign reviews to the bids
    protected void btnAssignReview_Click(object sender, EventArgs e)
    {
        // changes phase to review phase
        Review.setReviewsByConf(conference.getID());
        conference.startReviewPhase();
        btnAssignReview.Visible = false;
    }
}