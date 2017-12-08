using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// Home Page - Displays conference that is occuring next
public partial class _Default : System.Web.UI.Page
{
    Account account;
    Conference conference;

    protected void Page_Load(object sender, EventArgs e)
    {
        // get account from session or init as Guest
        account = new Account();
        account.loadFromSession();

        //todo: load latest conference
        // display title, image, description

        //todo: display alerts
    }


}