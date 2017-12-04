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
    private int confID;
    private string title;
    private string path;
    
    public Paper(int id, int authorID, int confID, string title, string path)
    {
        this.id = id;
        this.authorID = authorID;
        this.confID = confID;
        this.title = title;
        this.path = path;
    }

    public void submitPaper(string localPath)
    {

    }

    public String[] getPapersForConf(int confID)
    {
        return papersForConf
    }

    public void viewPaper(int id)
    {

    }
}