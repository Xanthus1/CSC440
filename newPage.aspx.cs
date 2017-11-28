using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Conference conference;
    List<Conference> confList;

    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "WHADUP!";

        Server.Transfer("Default.aspx", true);
    }
}