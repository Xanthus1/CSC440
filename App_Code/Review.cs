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
        this.reviewerID = reviewerID;
        this.rating = rating;
        this.comment = comment;
        this.privateComment = privateComment;
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
    public void submitReview(int id, int paperID, int reviewerID, string rating, string comment, string privateComment)
    {
        Review r = new Review(id, paperID, reviewerID, rating, comment, privateComment);
        //sql command to upload review
    }
    public List<Review> getReviewsForPaper(int paperID)
    {
        List<Review> reviewList = new List<Review>();

        //todo: SQL to get reviews
        return reviewList;
    }

    public static void assignReviewsForConference(int confID)
    {
        //todo: SQL command to assign reviews based on bid 
        // currently, just assign the top 3 reviews for each paper
    }
}