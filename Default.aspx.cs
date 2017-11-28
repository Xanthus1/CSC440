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
        conference = new Conference("Event", "The best event Ever!");
        confList = new List<Conference>();

        confList.Add(conference);
        confList.Add(new Conference("New Thing", "Not as good as the other"));
        
        Label1.Text = conference.getName() + " : " + conference.getDescription();

        xantest.InnerHtml = Conference.conferenceTableHtml(confList);

        Label1.Text = "Oh Hai " + (String)HttpContext.Current.Session["name"];        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session["name"] = "New Guy";

        Server.Transfer("newPage.aspx", true);
    }
}