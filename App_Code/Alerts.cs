using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Alerts
/// </summary>
public class Alerts
{
    private int id;
    private int userID; 
    private int accessLevel;
    private Boolean viewed;
    public Alerts(int id, int userID, int accessLevel, Boolean viewed)
    {
        this.id = id;
        this.userID = userID;
        this.accessLevel = accessLevel;
        this.viewed = viewed;
    }
    public Alerts()
    {
        this.id = -1;
        this.userID = -1;
        this.accessLevel = -1;
        this.viewed = false;
    }

    public int getID()
    {
        return id;
    }
    public int getUserID()
    {
        return userID;
    }
    public int getAccessLevel()
    {
        return accessLevel;
    }
    public Boolean getViewed()
    {
        return viewed;
    }

}