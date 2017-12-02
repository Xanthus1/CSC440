using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// Home Page
public partial class _Default : System.Web.UI.Page
{
    Account account;
    Conference conference;
    List<Conference> confList;

    protected void Page_Load(object sender, EventArgs e)
    {
        confList = new List<Conference>();
        
        Label1.Text = conference.getName() + " : " + conference.getDescription();

        xantest.InnerHtml = conferenceTableHtml(confList);

        account = new Account();

        Label1.Text = "Oh Hai " + account.getName() + " Access:" + account.getAccessLevel();
    }

    //method to return a list of conferences as a table
    public static String conferenceTableHtml(List<Conference> confList)
    {
        // init table string and set headers
        string s = "<table>";
        s += "<tr><th>Name</th><th>Description</th></tr>";

        //load table row
        foreach (var conf in confList)
        {
            s += "<tr><td>" + conf.getName() + "</td><td>" + conf.getDescription() + "</td></tr>";
        }

        // finish table
        s += "</table";

        // return string
        return s;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        account.login("Admin", "Admin");
        Label1.Text = "Oh Hai " + account.getName() + " Access:" + account.getAccessLevel();
    }
}