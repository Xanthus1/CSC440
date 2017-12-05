using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Conference
/// </summary> 
public class Conference
{
    private int id;
    private String name;
    private String description;
    private int paperLimit;
    private String imagePath;
    private DateTime dateTime;

    // Constructor requires all conference info
    public Conference(int id, String name, String description, int paperLimit, String imagePath, DateTime dateTime)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.paperLimit = paperLimit;
        this.imagePath = imagePath;
        this.dateTime = dateTime;
    }

    public int getId()
    {
        return id;
    }
    public String getName()
    {
        return name;
    }
    public String getDescription()
    {
        return description;
    }
    public int getPaperLimit()
    {
        return paperLimit;
    }
    public String getImagePath()
    {
        return imagePath;
    }
    public DateTime getDateTime()
    {
        return dateTime;
    }
    // todo: get methods for other vars

    public void createConference()
    {
        //sql
    }
}