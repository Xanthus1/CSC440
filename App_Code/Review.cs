using System;
using System.Collections.Generic;
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
    private string rating;
    private string comment;
    private string privateComment;

    public Review(int id, int paperID, int reviewerID, string rating, string comment, string privateComment)
    {
        this.id = id;
        this.paperID = paperID;
        this.reviewerID = reviwerID;
        this.rating = rating;
        this.comment = comment;
        this.privateComment = privateComment;
    }

    public void submitReview()
    {
    }

    public Review[] getReviewsForPaper(int paperID)
    {
    }
}