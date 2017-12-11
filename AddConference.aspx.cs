using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddConference : System.Web.UI.Page
{
    Account account;
    protected void Page_Load(object sender, EventArgs e)
    {
        // get account from session or init as Guest
        account = new Account();
        account.loadFromSession();

        // Guests don't have access to conferences: show error and stop loading page
        if (!(account.isAdmin()))
        {
            div1.InnerHtml = "<b> Error: Login with your admin account to access the conferences page</b>";
            return;
        }
        StatusLabel.Text = "Status: ";
        //on first load only
        if (!this.IsPostBack)
        {
           //set the default time to 8:00 AM
           time_selector.Hour = 08;
           time_selector.Minute = 00;
           time_selector.AmPm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
        }
    }

    protected void btn_submitpaper_Click(object sender, EventArgs e)
    {
        //Storing default picture and maxpapers variables.
        string storedPath = "default.jpg"; 
        int maxPapers = 100;
        //if someone selects a file in the file browser
        if (FileUploadControl.HasFile)
        {
            //get the file info
            try
            {
                string fileName = Path.GetFileName(FileUploadControl.FileName);
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                storedPath = fileName;
                //jpg is the only accespted file format, any other file types will be declined
                if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    string imagePath = Path.Combine(Server.MapPath("~/Images/") + fileName);
                    FileUploadControl.SaveAs(imagePath);
                    StatusLabel.Text += "Upload status: File uploaded to " + imagePath.ToString()+". ";
                }
                //if it isn't jpg, print an error
                else
                {
                    StatusLabel.Text += "Upload status: The file could not be uploaded. " + extension + " Invalid file extension. jpg is the only supported image type. ";
                }
            }
            //for general unknown errors, print that error
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
        //if this a number, not text then set the maxpapers to the number.
        if (Int32.TryParse(max_papers.Text, out maxPapers))
        {
            maxPapers = Int32.Parse(max_papers.Text);
        }
        //if not, set it to 100 and change the display text. 
        else
        {
            max_papers.Text = "100";
            StatusLabel.Text += "Max Paper input was invalid, default is set to 100.";
        }
        //no more than 1000 papers allowed
        if (maxPapers > 1000)
        {
            maxPapers = 1000;
        }
        //conference name is required
        if (con_name.Text.Equals(""))
        {
            StatusLabel.Text += "Conference Add Failed: Conference name is blank";
        }
        //conference description is required.
        else if (con_desc.Text.Equals(""))
        {
            StatusLabel.Text += "Conference Add Failed: Conference description is blank";
        }
        //if all details are filled out
        else
        { 
            Conference conf = new Conference();
            try
            {
                //add the conference given the input
                conf.createConference(con_name.Text, con_desc.Text, maxPapers, storedPath, updateDateTime());

                //reset the input fields to blank or default. 
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
                //if the conference isn't added, display this error.
                selected_date.Text += "Conference Add Failed: Database Add Failed";
            }
        }
    }
    //anytime a new date is changed
    protected void datepicker_SelectionChanged(object sender, EventArgs e)
    {
        //change display date text
        selected_date.Text = updateDateTime().ToString();
    }

    public DateTime updateDateTime()
    {
        //when a new date is selected, this updates the display date dext and returns the new selected datetime.
        DateTime dateTime = new DateTime(datepicker.SelectedDate.Year, datepicker.SelectedDate.Month, datepicker.SelectedDate.Day, time_selector.Hour, time_selector.Minute, 0);
        return dateTime; 
    }
}