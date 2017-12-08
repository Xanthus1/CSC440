using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    Account account;
    protected void Page_Load(object sender, EventArgs e)
    {
        // get account from session or init as Guest
        account = new Account();
        account.loadFromSession();
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        // validate inputs before attempting registration
        Boolean valid = true;
        String warning = "";

        // if fields are empty, highlight in red and add to the warning message
        if (tb_email.Text.Equals(""))
        {
            warning += "Missing Email<p>";
            tb_email.BackColor = System.Drawing.Color.Red;

            valid = false;
        }
        if (tb_password.Text.Equals(""))
        {
            warning += "Missing password<p>";
            tb_password.BackColor = System.Drawing.Color.Red;

            valid = false;
        }

        // Inputs were valid, attempt to login
        if (valid)
        {
            // if loging in successfully
            if(account.login(tb_email.Text, tb_password.Text))
            {
                Server.Transfer("Default.aspx");
            }
            else
            {
                warning += "Login Failed<p>";
                warningDiv.InnerHtml = warning;
            }

        }
        else
        {
            warningDiv.InnerHtml = warning;
        }        
        
    }

    protected void btn_create_new_account_Click(object sender, EventArgs e)
    {
        Server.Transfer("Register.aspx");
    }

    // if you're changing text when it was an error, change it back to white 
    protected void tb_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;

        if (tb.BackColor == System.Drawing.Color.Red)
        {
            tb.BackColor = System.Drawing.Color.White;
            warningDiv.InnerHtml = ""; // clear warning message
        }
    }
}