using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bid
/// </summary>
public class Bid
{
    private int id;
    private int reviewerID;
    private int paperID;
    private int rating;

    // create a potential bid, with userid and paperid. later when you save it, you just need to pass the rating
    public Bid(int reviewerID, int paperID)
    {
        rating = 0;
        this.reviewerID = reviewerID;
        this.paperID = paperID;
    }

    // if you create a bid from the DB, pass all fields
    public Bid(int id, int reviewerID, int paperID, int rating)
    {
        this.id = id;
        this.reviewerID = reviewerID;
        this.paperID = paperID;
        this.rating = rating;
    }
    public int getID()
    {
        return id;
    }
    // get bid rating
    public int getRating()
    {
        return rating;
    }
    public int getPaperID()
    {
        return paperID;
    }
    public int getReviewerID()
    {
        return reviewerID;
    }
    // saves bid in database
    public void saveBid(int r)
    {
        // if this has an existing id in the table, and we change rating to 0, delete the bid  
        if(id>0 && r == 0)
        {
            DBHelper.insertQuery("DELETE FROM bid WHERE id=" + id,
                "root", "");
        }

        // if this has been rated before, then it's not a new bid
        // simply do an update statement to change the rating
        if (rating > 0)
        {
            DBHelper.insertQuery("UPDATE bid SET rating=" + r + " WHERE id="+id,
                "root","");
        }
        else
        {
            // this is a new bid, do an insert
            DBHelper.insertQuery("INSERT INTO bid (reviewerID,paperid,rating) VALUES"
                +"(" + reviewerID + "," + paperID + "," + r+ ")",
                "root", "");

            // update object with new primary key: the latest one added to the table
            //todo: this can be returned from the insert
            int newKey = int.Parse(DBHelper.dataTableFromQuery("SELECT max(id) as id FROM bid",
                "root","").Rows[0]["id"].ToString());

            id = newKey;
        }

        rating = r;
    }
    public static void deleteBid(int bidID)
    {
        DBHelper.insertQuery("DELETE FROM bid WHERE id=" + bidID,
                "root", "");
    }

    public static List<Bid> getBidByPaper(int paperID)
    {
        List<Bid> bidList = new List<Bid>();
       
        //new bid list where paperid =
        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM bid WHERE paperid=" + paperID,
            "root", "");

        //add all those matching bids to the bidList
        foreach (DataRow row in myTable.Rows)
        {
            bidList.Add(new Bid(Int32.Parse(row["ID"].ToString()),
                Int32.Parse(row["reviewerID"].ToString()),
                Int32.Parse(row["paperID"].ToString()),
                Int32.Parse(row["Rating"].ToString())));
        }

        return bidList;
    }
}