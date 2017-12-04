using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Account
{
    private String name;
    private int userKey; // key relating to user in database
    private int accessLevel;
    static int ACCESS_GUEST = 1;
    static int ACCESS_USER = 2;
    static int ACCESS_ADMIN = 3;
    static int USER_NONE = -1;

    public Account()
    {
        // init account with blank credentials
        name = "Guest";
        accessLevel = ACCESS_GUEST;
        userKey = USER_NONE;
    }

    public String getName()
    {
        return name;
    }

    public int getAccessLevel()
    {
        return accessLevel;
    }

    // return 
    public Boolean login(String n, String p)
    {
        //access database

        // try to login with credentials

        //test
        if(n.Equals("Admin") && p.Equals("Admin"))
        {
            accessLevel = ACCESS_ADMIN;
        }
        else
        {
            accessLevel = ACCESS_USER;
        }
        name = n;
        userKey = 1;


        // update session after logging in ( stay logged in when navigating )
        sessionUpdate();

        // return whether login successful, set accesslevel
        return true;
    }

    // attempts to register account
    // todo: more parameters
    public void register(String n, String p)
    {
        //validate that name is not taken
    }

    // loads account from current session
    public void loadFromSession()
    {
        if(HttpContext.Current.Session["name"] != null)
        {
            name = HttpContext.Current.Session["name"].ToString();
            userKey = int.Parse(HttpContext.Current.Session["userKey"].ToString());
            accessLevel = int.Parse(HttpContext.Current.Session["accessLevel"].ToString());
        }
        else // if info is not currently in session, load other info
        {
            name = "Guest";
            accessLevel = ACCESS_GUEST;
        }
    }

    //  uses class information and stores it to your session
    public void sessionUpdate()
    {
        HttpContext.Current.Session["name"] = name;
        HttpContext.Current.Session["userKey"] = userKey;
        HttpContext.Current.Session["accessLevel"] = accessLevel;
    }
}