using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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


    // blank constructor
    public Conference()
    {
        this.id = -1;
        this.name = "CONFERENCE_NONE";
        this.description = "DESCRIPTION_NONE";
        this.paperLimit = -1;
        this.imagePath = "IMAGEPATH_NONE";
        this.dateTime = DateTime.Today;
    }

    public String getName()
    {
        return name;
    }
    public String getDescription()
    {
        return description;
    }

    public int getID()
    {
        return id;
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
    
    // get conference from table using key id
    static public Conference getConference(int id)
    {
        Conference conf = new Conference(); // blank conference object : gets rewritten with sql select

        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM conference WHERE ID=" + id,"root","");

        // only try to access result if there is one
        if (myTable.Rows.Count > 0)
        {
            DataRow row = myTable.Rows[0];
            conf = new Conference(Int32.Parse(row["ID"].ToString()),
                row["name"].ToString(),
                row["description"].ToString(),
                Int32.Parse(row["paperLimit"].ToString()),
                row["imagePath"].ToString(),
                DateTime.Parse(row["dateTime"].ToString()) // todo: might need to convert SQL DateTime to this datetime class
                );
        }
    
        
        return conf;
    }

    static public List<Conference> getConferenceList()
    {
        List<Conference> confList = new List<Conference>();

        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM conference", "root", "");

        // convert retrieved data to Conference objects and add them to the list
        foreach (DataRow row in myTable.Rows)
        {
                
            Conference conf = new Conference(Int32.Parse(row["ID"].ToString()),
                row["name"].ToString(),
                row["description"].ToString(),
                Int32.Parse(row["paperLimit"].ToString()),
                row["imagePath"].ToString(),
                DateTime.Parse(row["dateTime"].ToString()) // todo: might need to convert SQL DateTime to this datetime class
                );
                   
            confList.Add(conf);
        }


        return confList;
        
    }

    public void createConference(string cName, string cDesc, int pMax, string iPath, DateTime dTime)
    {
        String date_time = dTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //need to add image path
        DBHelper.insertQuery("Insert Into conference (`Name`, `Description`, `PaperLimit`, `ImagePath`, `DateTime`) VALUES ('"+cName+"', '"+cDesc+"', "+pMax+", '"+iPath+"', '"+date_time+"')", "root","");
    }
}