using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MasterPageAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, GetType(), "DataPicker", "$(document).ready(function () { $('.calendario').datepicker() });", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "datepicker", "javascript: $('.calendario').datepicker();", true);
    }
}
