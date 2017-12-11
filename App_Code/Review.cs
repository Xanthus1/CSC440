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
    public static void addReview(int pID, int rID)
    {
        DBHelper.insertQuery("INSERT INTO reviews (paperID, reviewer, rating, comment, privatecomment, completed) Values("+pID+", "+ rID+", 'NA', 'NA', 'NA', 0)",
        "root", "");
    }
    public static void submitReview(int id, int pID, int rID, string rating, string comment, string privateComment)
    {
        DBHelper.insertQuery("UPDATE reviews SET completed=1, comment='"+comment+ "', privatecomment='" + privateComment + "', rating='" + rating + "' WHERE paperID=" + pID + " AND reviewer=" + rID,
        "root", "");
    }
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

    public static List<Review> getReviewForReviewer(int reviewerID)
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

    public static int getReviewCountForReviewer(int reviewerID)
    {
        List<Review> reviewList = getReviewForReviewer(reviewerID);
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

    public static void setReviewsByConf(int confID)
    {
        List<Paper> paperList = Paper.getPapersByConf(confID);
        Debug.WriteLine(paperList.Count);
        List<Bid> bidList = new List<Bid>();
        Debug.WriteLine(bidList.Count);
        foreach (Paper p in paperList)
        {
            List<Bid> tmpBidList = Bid.getBidByPaper(p.getID());
            bidList.AddRange(tmpBidList);
        }

        foreach (Paper p in paperList)
        {
            for (int i = 5; i >= -1; i--)
            {
                foreach (Bid b in bidList)
                {
                    if (b.getPaperID() == p.getID())
                    {
                        if (b.getRating() == i)
                        {
                            if ((getReviewCountForReviewer(b.getReviewerID()) < 7) && (getReviewCountForPaper(b.getPaperID()) < 3))
                            {
                                addReview(b.getPaperID(), b.getReviewerID());
                            }
                        }
                        if (i == -1)
                        {
                            //Bid.deleteBid(b.getID());
                        }
                    }
                }
            }
        }
    }
}