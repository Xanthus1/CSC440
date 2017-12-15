using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Review
/// </summary>
public class Review
{
    private int id;
    private int paperID;
    private int reviewerID;
    private int completed;
    private string rating;
    private string comment;
    private string privateComment;

    //constructor
    public Review(int id, int paperID, int reviewerID, string rating, string comment, string privateComment, int completed)
    {
        this.id = id;
        this.paperID = paperID;
        this.reviewerID = reviewerID;
        this.rating = rating;
        this.comment = comment;
        this.privateComment = privateComment;
        this.completed = completed;
    }

    //blank constructor
    public Review()
    {
        this.id = -1;
        this.paperID = -1;
        this.reviewerID = -1;
        this.rating = "";
        this.comment = "";
        this.privateComment = "";
        this.completed = 0;
    }

    // returns whether this review exists (whether it was instantiated with data or default constructor)
    public Boolean exists()
    {
        return (id != -1);
    }

    public int getID()
    {
        return id;
    }
    public int getPaperID()
    {
        return paperID;
    }
    public int getReviewerID()
    {
        return reviewerID;
    }
    public string getRating()
    {
        return rating;
    }
    public string getComment()
    {
        return comment;
    }
    public string getPrivateComment()
    {
        return privateComment;
    }

    //add review given paper id and reviewerid
    public static void addReview(int pID, int rID)
    {
        DBHelper.insertQuery("INSERT INTO reviews (paperID, reviewer, rating, comment, privatecomment, completed) Values("+pID+", "+ rID+", 'NA', 'NA', 'NA', 0)",
        "root", "");
    }

    //add new review
    public static void submitReview(int id, string rating, string comment, string privateComment)
    {
        DBHelper.insertQuery("UPDATE reviews SET completed=1, comment='"+comment+ "', privatecomment='" + privateComment + "', rating='" + rating + "' WHERE id="+id,
            "root","");
    }

    //get review based on paperID
    public static List<Review> getReviewForPaper(int paperID)
    {
        List<Review> reviewList = new List<Review>();

        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM reviews WHERE PaperID=" + paperID, "root", "");

        // only try to access result if there is one
        if (myTable.Rows.Count > 0)
        {
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                DataRow row = myTable.Rows[i];
                reviewList.Add (new Review(Int32.Parse(row["ID"].ToString()),
                    Int32.Parse(row["paperID"].ToString()),
                    Int32.Parse(row["reviewer"].ToString()),
                    row["Rating"].ToString(),
                    row["Comment"].ToString(),
                    row["PrivateComment"].ToString(),
                    Int32.Parse(row["completed"].ToString())
                    ));
            }
        }

        return reviewList;
    }

    //get reviews based on reviewerID
    public static List<Review> getReviewsForReviewer(int reviewerID)
    {
        List<Review> reviewList = new List<Review>();

        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM reviews WHERE reviewer=" + reviewerID, "root", "");

        // only try to access result if there is one
        if (myTable.Rows.Count > 0)
        {
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                DataRow row = myTable.Rows[i];
                reviewList.Add(new Review(Int32.Parse(row["ID"].ToString()),
                    Int32.Parse(row["paperID"].ToString()),
                    Int32.Parse(row["reviewer"].ToString()),
                    row["Rating"].ToString(),
                    row["Comment"].ToString(),
                    row["PrivateComment"].ToString(),
                    Int32.Parse(row["completed"].ToString())
                    ));
            }
        }

        return reviewList;
    }
    //count how many reviewes the reviewer has been assigned
    public static int getReviewCountForReviewer(int reviewerID)
    {
        List<Review> reviewList = getReviewsForReviewer(reviewerID);
        int reviewcount = 0;
        foreach (Review r in reviewList)
        {
            if (r.getReviewerID() == reviewerID)
            {
                reviewcount++;
            }
        }
        return reviewcount;
    }
    //count how paper reviews has been assigned for a paper.
    public static int getReviewCountForPaper(int paperID)
    {
        List<Review> reviewList = getReviewForPaper(paperID);
        int reviewcount = 0;
        foreach (Review r in reviewList)
        {
            if (r.getPaperID() == paperID)
            {
                reviewcount++;
            }
        }
        return reviewcount;
    }

    //when the conference goes from bid phase to review phase
    public static void setReviewsByConf(int confID)
    {
        List<Paper> paperList = Paper.getPapersByConf(confID);
        List<Bid> bidList = new List<Bid>();

        //get all bids that match up to the papers
        foreach (Paper p in paperList)
        {
            List<Bid> tmpBidList = Bid.getBidByPaper(p.getID());
            bidList.AddRange(tmpBidList);
        }
        //get all papers in the conference
        foreach (Paper p in paperList)
        {
            //for each bid level 5 to -1 (-1 deletes bid)
            for (int i = 5; i >= -1; i--)
            {
                //for each bid
                foreach (Bid b in bidList)
                {
                    //if it matches up with the paper
                    if (b.getPaperID() == p.getID())
                    {
                        // if the bid rating matches i
                        if (b.getRating() == i)
                        {
                            //check if the reviewer has <7 and the paper has <3
                            if ((getReviewCountForReviewer(b.getReviewerID()) < 7) && (getReviewCountForPaper(b.getPaperID()) < 3))
                            {
                                //assign review and delete bid
                                addReview(b.getPaperID(), b.getReviewerID());
                                Bid.deleteBid(b.getID());
                            }
                        }
                        if (i == -1)
                        {
                            //delete bid it was not assigned and bidding phase is over
                            Bid.deleteBid(b.getID());
                        }
                    }
                }
            }
        }
    }
}