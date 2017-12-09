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
        // get account from session or init as Guest
        account = new Account();
        account.loadFromSession();
    }

    //clicking submit  to register new account

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        // validate inputs (todo: use Account to verify, returning warning message
        String name = tb_name.Text;
        String email = tb_email.Text;
        String password = tb_password.Text;
        String passwordConfirm = tb_passwordconfirm.Text;

        String warning = "";
        Boolean valid = true;

        // if fields are empty, highlight in red and add to the warning message
        if (tb_name.Text.Equals(""))
        {
            warning += "Missing Name<p>";


            valid = false;
        }
        if (tb_email.Text.Equals(""))
        {
            warning += "Missing Email<p>";
            tb_email.BackColor = System.Drawing.Color.Red;

            valid = false;
        }

        // if passwords don't match, highlight in red and add to warning message
        if (!tb_password.Text.Equals(tb_passwordconfirm.Text))
        {
            warning += "Passwords don't match<p>";

            tb_password.BackColor = System.Drawing.Color.Red;
            tb_passwordconfirm.BackColor = System.Drawing.Color.Red;

            valid = false;
        }

        // password length must be at least 6 chars
        if (tb_password.Text.Length < 6)
        {
            warning += "Password needs to be at least 6 characters<p>";

            tb_password.BackColor = System.Drawing.Color.Red;
            tb_passwordconfirm.BackColor = System.Drawing.Color.Red;

            valid = false;
        }

        //test if email is already registered
        if (Account.isEmailTaken(tb_email.Text))
        {
            warning += "E-mail has already been taken";

            tb_email.BackColor = System.Drawing.Color.Red;

            valid = false;
        }

        // if valid, register account and go to homepage. Otherwise 
        if (valid)
        {
            // create account and navigate to login page
            Account.register(tb_email.Text, tb_name.Text, tb_password.Text);

            Server.Transfer("Default.aspx");
        }
        else
        {
            // display warning message with input issues
            warningDiv.InnerHtml = warning;
        }

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