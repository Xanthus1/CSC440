using System;
using System.Collections.Generic;
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

    public void submitPaper(string localPath)
    {

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