using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// List of papers for reviewer only

public partial class Papers : System.Web.UI.Page
{
    static int MAX_REVIEWS = 3; // Max number of reviews a paper can have
    List<Paper> paperList;
    int confID; 

    protected void Page_Load(object sender, EventArgs e)
    {
         paperList = new List<Paper>();

        // conference ID passed by previous page
        try
        {
            confID = int.Parse(Request.QueryString["ConfID"].ToString());
        }
        catch
        {
            //todo: Show error message (Replace content area)
            return; // no confID selected, don't show anything
        }

        //todo: SQL query to get papers for this conference
        //todo: handle when confID doesn't exist (show error)
        //todo: handle when you don't have permissions to view papers (show "You are not authorized")


        // test data insert
        paperList.Add(new Paper(1, 1, "Me", 1, "The Dawn of Man", "/test.doc", 2));

        paperTableDisplay();
    }

    //method to add papers/related buttons to table
    public void paperTableDisplay()
    {
        // add row for each conference
        foreach (Paper p in paperList)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            
            // Title
            td = new TableCell();
            td.Text = p.getTitle();
            tr.Cells.Add(td);

            //Author
            td = new TableCell();
            td.Text = p.getAuthorName();
            tr.Cells.Add(td);

            //Number of reviews
            td = new TableCell();
            td.Text = p.getReviewCount()+"/"+MAX_REVIEWS;
            tr.Cells.Add(td);

            //Review button 
            td = new TableCell();
            Button btn = new Button();
            btn.Text = "Review";
            btn.Attributes.Add("paperID", "" +p.getID()); // store key attribute, so onclick method knows which paper to review
            btn.Click += btn_Review_Click;
            td.Controls.Add(btn);
            tr.Cells.Add(td);

            paperTable.Rows.Add(tr);
        }
    }

    protected void btn_Review_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Server.Transfer("PaperView.aspx?PaperID=" + btn.Attributes["paperID"], true);
    }
}