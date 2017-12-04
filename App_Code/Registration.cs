using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Registration
/// </summary>
public class Registration
{
    int id;
    int userID;
    int confID;
    int privilege; 
    
    public Registration(int id, int userID, int confID, int privilege)
    {
        this.id = id;
        this.userID = userID;
        this.confID = confID;
        this.privilege = privilege;
    }

    public void register(int userID, int confID)
    {

    }

    public void setPrivilege(int userID, int privilege)
    {
            
    }
}