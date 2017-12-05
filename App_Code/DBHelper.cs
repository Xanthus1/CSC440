using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBHelper
/// </summary>
public class DBHelper
{
    public DBHelper()
    {
        
    }

    static public DataTable dataTableFromQuery(String qry, String user, String pass)
    {
        //Get updated list of conferences from database
        String myConnectionString;
        DataTable myTable = new DataTable(); // stores the query results
        myConnectionString = "server=127.0.0.1; user=" + user + "; database=csc440conferencemanagement; port=3306;password=" + pass + ";";
        MySqlConnection conn = new MySqlConnection(myConnectionString);

        // open connection
        conn = new MySqlConnection(myConnectionString);

        try
        {
            conn.Open();

            // Select statement from string
            string sql = qry;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
            myAdapter.Fill(myTable);

            Console.Write("Success");
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            // database query didn't work: return empty list
        }

        conn.Close();

        return myTable;
    }
}