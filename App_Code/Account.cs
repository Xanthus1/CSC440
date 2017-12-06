using System;
using System.Collections.Generic;
using System.Data;
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
    public static int ACCESS_GUEST = 1;
    public static int ACCESS_USER = 2;
    public static int ACCESS_ADMIN = 3;
    public static int USER_NONE = -1;

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
    static public Boolean login(String e, String p)
    {
        //access database

        // try to login with credentials  
        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM user WHERE email='"+e+"' AND password='" + p + "'",
            "root","");

        // if there is no result, fail login.
        if (myTable.Rows.Count == 0)
        {
            return false;
        }

        // update session after logging in ( stay logged in when navigating )
        DataRow row = myTable.Rows[0];
        HttpContext.Current.Session["name"] = row["name"].ToString();
        HttpContext.Current.Session["userKey"] = row["id"].ToString();
        HttpContext.Current.Session["accessLevel"] = row["accesslevel"].ToString();

        // return whether login successful
        return true;
    }

    // Register account
    // call only after validation has been completed
    static public void register(String e, String n, String p)
    {
        // insert new user into table (id is autoincrement)
        //        INSERT INTO user (email, password, accesslevel, name) VALUES("email", "pass", 1, "name")

        DBHelper.insertQuery("INSERT INTO user (email,password,accesslevel,name) VALUES ('" 
            + e + "','" + p + "'," + ACCESS_USER + ",'" + n + "')", "root", "");
    }

    static public Boolean isEmailTaken(String e)
    {
        // validate that e-mail has not registered
        DataTable myTable = DBHelper.dataTableFromQuery("SELECT * FROM user WHERE email='" + e + "'", "root", "");

        // account is not taken
        if (myTable.Rows.Count > 0 )
        {
            return true;
        }
        return false;
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
    public static void setGuestSession()
    {
        // no session active, set session name to guest 
        HttpContext.Current.Session["name"] = "Guest";
        HttpContext.Current.Session["userKey"] = Account.USER_NONE;
        HttpContext.Current.Session["accessLevel"] = Account.ACCESS_GUEST;
    }
}