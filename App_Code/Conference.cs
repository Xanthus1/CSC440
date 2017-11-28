using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Conference
/// </summary>
public class Conference
{
    private String name;
    private String description;

    public Conference(String name, String description)
    {
        this.name = name;
        this.description = description;
    }

    public String getName()
    {
        return name;
    }

    public String getDescription()
    {
        return description;
    }

    //method to return a list of conferences as a table
    public static String conferenceTableHtml(List<Conference> confList)
    {
        // init table string and set headers
        string s = "<table>";
        s += "<tr><th>Name</th><th>Description</th></tr>";

        //load table row
        foreach(var conf in confList)
        {
            s += "<tr><td>" + conf.getName() + "</td><td>" + conf.getDescription() + "</td></tr>";
        }

        // finish table
        s+="</table";

        // return string
        return s;
    }
}