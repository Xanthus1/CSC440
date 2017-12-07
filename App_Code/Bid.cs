using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bid
/// </summary>
public class Bid
{
    private int id;
    private int userID;
    private int paperID;
    private int rating;

    // create a potential bid, with userid and paperid. later when you save it, you just need to pass the rating
    public Bid(int userID, int paperID)
    {
        rating = 0;
        this.userID = userID;
        this.paperID = paperID;
    }

    // if you create a bid from the DB, pass all fields
    public Bid(int id, int userID, int paperID, int rating)
    {
        this.id = id;
        this.userID = userID;
        this.paperID = paperID;
        this.rating = rating;
    }

    // get bid rating
    public int getRating()
    {
        return rating;
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
                +"(" + userID + "," + paperID + "," + r+ ")",
                "root", "");

            // update object with new primary key: the latest one added to the table
            //todo: this can be returned from the insert
            int newKey = int.Parse(DBHelper.dataTableFromQuery("SELECT max(id) as id FROM bid",
                "root","").Rows[0]["id"].ToString());

            id = newKey;
        }

        rating = r;
    }
}