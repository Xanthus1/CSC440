using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Registration
/// </summary>
public class Registration
{
    private int id; //todo: we might not need this accessable. we can always search based on userID and confID
    private int userID;
    private int confID;
    private int privilege;
    private Boolean checkedIn;
    private Boolean registered;
    static int ACCESS_NONE = 0; // before registering and adding to the database, user has no access
    public static int ACCESS_RESEARCHER = 1;
    public static int ACCESS_REVIEWER = 2;


    // constructor is called when viewing conference details - you have an active user and conference ID available 
    // even if they aren't registered yet. This method will see if they are registered
    // and load the rest of the info if they are. If not, it defaults
    public Registration(int userID, int confID)
    {
        this.userID = userID;
        this.confID = confID;

        privilege = ACCESS_NONE;
        checkedIn = false;
        registered = false;

        // Check DB: load privilege, checkedIn, and set whether the user is registered for this conference
        loadRegistration();
    }


    public int getID()
    {
        return id;
    }

    public int getUserID()
    {
        return userID;
    }

    public int getConfID()
    {
        return confID;
    }
    public int getPrivilege()
    {
        return privilege;
    }
    public Boolean isCheckedIn()
    {
        return checkedIn;
    }
    public Boolean isRegistered()
    {
        return registered;
    }
    public void checkIn()
    {
        // update registration in DB and set checkedin to 1 (true)
        DBHelper.insertQuery("UPDATE registration SET checkedin=1 WHERE confID=" + confID + " AND userID=" + userID,
            "root", "");

        checkedIn = true;
    }

    // loads registration info into this class using the active conferenceID and userID
    public void loadRegistration()
    {
        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM registration WHERE userid='"+userID+"' AND confid='"+confID+"'",
            "root","");

        if (myTable.Rows.Count > 0)
        {
            DataRow row = myTable.Rows[0];
            privilege = Int32.Parse(row["privilege"].ToString());
            checkedIn = row["checkedin"].ToString().Equals("1"); // set to true if it's 1, to false if it's 0
            registered = true;
        }
    }

    // registers with confID and userID loaded into this object
    public void register()
    {
       // todo: currently will default privilege to reviewer
        privilege = ACCESS_REVIEWER;

        // when you initially register, you are checked out. DB stores as 0 or 1 for false and true.
        int checkedInInt = 0 ;
        
        DBHelper.insertQuery("INSERT into registration (userid, confid, privilege, checkedin) VALUES (" + userID + "," + confID + "," + privilege + "," + checkedInInt + ")",
            "root","");

        
    }

    public void setPrivilege(int privilege)
    {
        this.privilege = privilege;
    }
}