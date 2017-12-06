using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddConference : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StatusLabel.Text += "";
        if (!this.IsPostBack)
        {
            time_selector.Hour = 08;
            time_selector.Minute = 00;
            time_selector.AmPm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
        }
    }

    protected void btn_submitpaper_Click(object sender, EventArgs e)
    {

        string storedPath = "default.jpg"; 
        int maxPapers = 100;
        if (FileUploadControl.HasFile)
        {
            try
            {
                string fileName = Path.GetFileName(FileUploadControl.FileName);
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                storedPath = fileName;

                if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    string imagePath = Path.Combine(Server.MapPath("~/Images/") + fileName);
                    FileUploadControl.SaveAs(imagePath);
                    StatusLabel.Text += "Upload status: File uploaded to " + imagePath.ToString()+". ";
                }
                else
                {
                    StatusLabel.Text += "Upload status: The file could not be uploaded. " + extension + " Invalid file extension. jpg is the only supported image type. ";
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text += "Upload status: The file could not be uploaded. The following error occured: " + ex.Message + ". ";
            }
        }
        else
        {
            //if no image is uploaded, set the default image in the stored path
            storedPath = storedPath+"~/Images/Default.jpg";
        }
        if (Int32.TryParse(max_papers.Text, out maxPapers))
        {
            maxPapers = Int32.Parse(max_papers.Text);
        }
        else
        {
            max_papers.Text = "100";
            StatusLabel.Text += "Max Paper input was invalid, default is set to 100.";
        }
        if (maxPapers > 1000)
        {
            maxPapers = 1000;
        }

        if (con_name.Text.Equals(""))
        {
            StatusLabel.Text += "Conference Add Failed: Conference name is blank";
        }
        else if (con_desc.Text.Equals(""))
        {
            StatusLabel.Text += "Conference Add Failed: Conference description is blank";
        }
        else
        {
            Conference conf = new Conference();
            try
            {
                //add the conference
                conf.createConference(con_name.Text, con_desc.Text, maxPapers, storedPath, updateDateTime());
                //reset the fields 
                StatusLabel.Text = "Conference Add Successful!";
                con_desc.Text = "";
                max_papers.Text = "";
                con_name.Text = "";
                selected_date.Text = "";
                datepicker.SelectedDate = DateTime.MinValue;
                time_selector.Hour = 08;
                time_selector.Minute = 00;
                time_selector.AmPm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
            }
            catch
            {
                selected_date.Text += "Conference Add Failed: Database Add Failed";
            }
        }
    }

    protected void datepicker_SelectionChanged(object sender, EventArgs e)
    {
        selected_date.Text = updateDateTime().ToString();//updateDateTime().ToShortDateString() + " " +updateDateTime().ToShortTimeString();
    }

    public DateTime updateDateTime()
    {
        DateTime dateTime = new DateTime(datepicker.SelectedDate.Year, datepicker.SelectedDate.Month, datepicker.SelectedDate.Day, time_selector.Hour, time_selector.Minute, 0);
        return dateTime; 
    }
}