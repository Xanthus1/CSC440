using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Paper
/// </summary>
public class Paper
{
    private int id;
    private int authorID;
    private String authorName; // this field is from the user table, using AuthorID as foreign key
    private int confID;
    private string title;
    private string docPath;
    private int reviewCount; // this field is calculated from how many reviews this paper currently has
    
    // constructor function used to create a paper object with data from the DB
    public Paper(int id, int authorID, String authorName, int confID, string title, string path, int reviewCount)
    {
        this.id = id;
        this.authorID = authorID;
        this.authorName = authorName;
        this.confID = confID;
        this.title = title;
        this.docPath = path;
        this.reviewCount = reviewCount;
    }

    //methods to get paper data
    public int getID()
    {
        return id;
    }

    public int getAuthorID()
    {
        return authorID;
    }

    public String getAuthorName() // this is data obtained from the user table
    {
        return authorName;
    }

    public int getConfID() {
        return confID;
    }

    public String getTitle()
    {
        return title;
    }

    public String getDocPath()
    {
        return docPath;
    }

    public int getReviewCount()
    {
        return reviewCount;
    }

    // submitting new paper: this public method takes parameters from the web page
    // to insert a new paper row in the DB upon upload
    static public void submitPaper(int authorID, int confID, String title, string docPath)
    {
        // insert new paper into the DB
        DBHelper.insertQuery("INSERT INTO papers (authorid,confid,title,docPath) VALUES("
            + authorID + "," + confID + ",'" + title + "','" + docPath + "')",
            "root", "");
    }

    static public Boolean hasSubmitted(int authorID, int confID)
    {
        // query for a paper matching this conference and user
        DataTable myTable = new DataTable();
        myTable = DBHelper.dataTableFromQuery("SELECT * FROM papers WHERE authorid=" + authorID + " AND confid=" + confID,
            "root", "");

        // if there is a paper found, return true, otherwise return false
        if (myTable.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    static public String getPaperPath(int authorID, int confID)
    {
        // query for a paper matching this conference and user
        DataTable myTable = new DataTable();
        myTable = DBHelper.dataTableFromQuery("SELECT * FROM papers WHERE authorid=" + authorID + " AND confid=" + confID,
            "root", "");

        // if there is a paper found, return the path
        if (myTable.Rows.Count > 0)
        {
            DataRow row = myTable.Rows[0];
            return row["docPath"].ToString();
        }
        return null;
    }

    public List<Paper> getPapersForConf(int confID)
    {
        List<Paper> paperList = new List<Paper>();

        //todo: access database and get list of papers for specific conference
        // need to do a Join to also get the name of the author from the user table
        return paperList;
    }

    public void viewPaper(int id)
    {
    
    }
}