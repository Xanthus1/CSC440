using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConferenceDetail : System.Web.UI.Page
{
    static String IMAGE_RESOURCE_PATH = "/papers";

    protected void Page_Load(object sender, EventArgs e)
    {
        // based on privelege and/or whether you have a paper for this conference
        // hide buttons as necessary (Register, Submit paper, View paper and Comments, Review papers)
        // todo: query based on registration access (reviewer or not)


        //todo: get Current conference from previous form

        //testing updating data from previous form
        if (Request.QueryString["ConfID"] == null)
        {
            lbl_Title.Text = "Error";
        }
        else
        {
            lbl_Title.Text = Request.QueryString["ConfID"].ToString();
        }

    }

    protected void btn_reviewpapers_Click(object sender, EventArgs e)
    {

    }

    protected void btn_viewpaper_Click(object sender, EventArgs e)
    {
        //works for test file, have to get paths from sql
        byte[] Content = File.ReadAllBytes(Path.Combine(Server.MapPath("~/Papers/") + "/" + "cmdb_documentation.docx"));
        Response.ContentType = "text/docx";
        Response.AddHeader("content-disposition", "attachment; filename=" + "cmdb_documentation" + ".docx");
        Response.BufferOutput = true;
        Response.OutputStream.Write(Content, 0, Content.Length);
        Response.End();
    }

    protected void btn_checkin_Click(object sender, EventArgs e)
    {

    }

    protected void btn_submitpaper_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                string fileName = Path.GetFileName(FileUploadControl.FileName);
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;

                if (extension.Equals(".docx", StringComparison.OrdinalIgnoreCase))
                {
                    FileUploadControl.SaveAs(Path.Combine(Server.MapPath("~/Papers/") + "/" + fileName));
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                else
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. " + extension + " Invalid file extension. DOCX is the only supported file type";
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
}

