using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Registration
/// </summary>
public class Registration
{
    private int id;
    private int userID;
    private int confID;
    private int privilege;
    static int ACCESS_RESEARCHER = 1;
    static int ACCESS_APPLY_FOR_REVIEWER = 2;
    static int ACCESS_REVIEWER = 3;

    public Registration(int id, int userID, int confID, int privilege)
    {
        this.id = id;
        this.userID = userID;
        this.confID = confID;
        this.privilege = privilege;
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

    public void register(int uID, int cID)
    {
        //need to consider autoincrement.
        //need to consider privilege
       //Registration r = new Registration(0, uID, cID, ACCESS_RESEARCHER);
        //sql command to upload registration
    }

    public void setPrivilege(int userID, int privilege)
    {
           //not sure where this would be called?
            
    }
}