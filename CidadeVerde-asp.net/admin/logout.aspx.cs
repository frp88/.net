using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_logout : AcessoRestrito
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AcessoRestrito acesso = new AcessoRestrito();
        acesso.logout();
    }
    //protected void btLogout_Click(object sender, EventArgs e)
    //{
    //    AcessoRestrito acesso = new AcessoRestrito();
    //    acesso.logout();
    //}
}
