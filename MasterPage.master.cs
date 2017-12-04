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
        Account account = new Account();

        account.sessionUpdate();

        if (account.getAccessLevel() == 2)
        {
            confLink.InnerHtml = "";
        }
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
