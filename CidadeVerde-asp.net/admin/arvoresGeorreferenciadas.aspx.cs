using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_arvoresGeorreferenciadas : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetCidadeVerde.tblCoordenadasDataTable dtCoordenadas = cv.buscaCoordenadas();
        GridViewCoordenadas.DataSource = cv.buscaCoordenadas();
        GridViewCoordenadas.DataBind();
        for (int i = 0; i < dtCoordenadas.Rows.Count; i++)
        {
            TextBox1.Text += dtCoordenadas[i]["latitude"].ToString() + " == " + dtCoordenadas[i]["longitude"].ToString() + "\n";

        }
    }
}
