using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["name"] == null)
        {
            // no current session, initialize session as guest
            Account.setGuestSession();
        }

        // if guest, hide the conferences button
        if(HttpContext.Current.Session["accessLevel"].ToString() == ""+Account.ACCESS_GUEST)
        {
            confLink.Visible = false;
        }
        else
        {
            // if you're a logged in user, show Logout instead of login
            loginDiv.InnerHtml =  "<a href='Logout.aspx'> Logout </a>";
        }

        //update welcome text
        welcomeDiv.InnerHtml = "Welcome     " + HttpContext.Current.Session["name"].ToString() + "!";
    }


    protected void btnHome_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default.aspx");
    }

    protected void btnConf_Click(object sender, EventArgs e)
    {
        Server.Transfer("Register.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Server.Transfer("Login.aspx");
    }
}
