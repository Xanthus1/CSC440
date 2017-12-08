using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    Account account;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // get account from session or init as Guest
        account = new Account();
        account.loadFromSession();

        // if you're a logged in user, show Logout instead of login
        if (account.isUser()){
            loginDiv.InnerHtml = "<a href='Logout.aspx'> Logout </a>";
        }

        // guests can't access conferences
        if (account.isGuest())
        {
            confLink.InnerHtml = ""; 
        }

        //update welcome text
        welcomeDiv.InnerHtml = "Welcome     " + account.getName() + "!";
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
