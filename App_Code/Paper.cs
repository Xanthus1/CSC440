using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
    private string description;
    private string docPath;
    
    // constructor function used to create a paper object with data from the DB
    // when we need to access the paper, having the authorname is useful
    public Paper(int id, int authorID, String authorName, int confID, string title, string description, string path)
    {
        this.id = id;
        this.authorID = authorID;
        this.authorName = authorName;
        this.confID = confID;
        this.title = title;
        this.description = description;
        this.docPath = path;
    }

    //blank constructor
    public Paper()
    {
        this.id = -1;
        this.authorID = -1;
        this.authorName = "";
        this.confID = -1;
        this.title = "";
        this.description = "";
        this.docPath = "";
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

    public String getDescription()
    {
        return description;
    }

    public String getTitle()
    {
        return title;
    }

    public String getDocPath()
    {
        return docPath;
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

    static public Paper getPaper(int paperID)
    {
        Paper p;

        //get paper where paperID =
        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM papers WHERE id=" + paperID,
            "root", "");

        DataRow row = myTable.Rows[0];

        p = new Paper(Int32.Parse(row["ID"].ToString()),
                Int32.Parse(row["authorid"].ToString()),
                "Author Name", // Todo: also get author name, need a join
                Int32.Parse(row["confid"].ToString()),
                row["title"].ToString(),
                row["description"].ToString(),
                row["docpath"].ToString());

        return p;
    }

    static public List<Paper> getPapersByConf(int confID)
    {
        List<Paper> p = new List<Paper>();

        //get all papers where confID =
        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM papers WHERE confid=" + confID,
            "root", "");

        foreach (DataRow row in myTable.Rows)
        {
            p.Add(new Paper(Int32.Parse(row["ID"].ToString()),
                Int32.Parse(row["authorid"].ToString()),
                "Author Name", 
                Int32.Parse(row["confid"].ToString()),
                row["title"].ToString(),
                row["description"].ToString(),
                row["docpath"].ToString()));

        }
        return p;
    }

    public static Paper getPaperByConfandUser(int confID, int userID)
    {
        Paper p = new Paper();

        //get all papers where confID = and where userID=
        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM papers WHERE confid=" + confID +" AND AuthorID = "+ userID,
            "root", "");

        foreach (DataRow row in myTable.Rows)
        {
            p = (new Paper(Int32.Parse(row["ID"].ToString()),
                Int32.Parse(row["authorid"].ToString()),
                "Author Name",
                Int32.Parse(row["confid"].ToString()),
                row["title"].ToString(),
                row["description"].ToString(),
                row["docpath"].ToString()));
        }
        return p;
    }
}