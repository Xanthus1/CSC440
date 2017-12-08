using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // get account from session or init as Guest
        Account.logout();

        // update text
        HtmlGenericControl welcomeDiv = (HtmlGenericControl) Master.FindControl("welcomeDiv");
        welcomeDiv.InnerHtml = "Welcome Guest!";

    }
}