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
    public Boolean getViewed()
    {
        return viewed;
    }

    public static List<Alerts> getAlertsListforUser(int userKey)
    {
        List<Alerts> alertsList = new List<Alerts>();


        //todo: sql to get alerts

        return alertsList;
    }

    static public void  addAlert(String alertString, int userKey)
    {
        //todo: add alert to database
    }

}