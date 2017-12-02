using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Registration

public partial class Register : System.Web.UI.Page
{
    Account account;
    protected void Page_Load(object sender, EventArgs e)
    {
        account = new Account();
    }

    //clicking submit 

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        // register account
    }
}