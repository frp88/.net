using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class arborizacaoUrbana : System.Web.UI.Page
{
    CidadeVerde cv = new CidadeVerde();

    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewEspeciesRecomendadas.DataSource = cv.buscaEspecieBynRecArborizacaoUrbana(1);
        GridViewEspeciesRecomendadas.DataBind();

        GridViewEspeciesNaoRecomendadas.DataSource = cv.buscaEspecieBynRecArborizacaoUrbana(2);
        GridViewEspeciesNaoRecomendadas.DataBind();

        if (!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaArvoreRecomendada');", true);
        }
        //gvEspeciesRecomendadas.DataSource
    }

    protected void GridViewEspeciesRecomendadas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image status = (Image)e.Row.Cells[2].FindControl("ImageEspecie");

                status.ImageUrl = Convert.ToInt32(e.Row.Cells[1].Text.Trim()) == 0 ?
                  "~/fotos/arvores/semFotoArvore.png" : "fotos/especies/" + e.Row.Cells[1].Text.Trim() + ".jpg";
                //switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                //{
                //    case 0: // Especie Sem Imagem
                //        //status.ToolTip = "Espécie Sem Imagem";
                //        status.ImageUrl = "~/fotos/arvores/semFotoArvore.png";
                //        break;
                //    default: //Caso 1 - Especie Recomendada
                //        //status.ToolTip = "Espécie Recomendada";
                //        status.ImageUrl = "fotos/especies/" + e.Row.Cells[1].Text.Trim() + ".jpg";
                //        break;
                //}
                status.Attributes.Add("title", e.Row.Cells[3].Text);
                e.Row.Cells[5].Text += "&nbsp;m";

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= '#FFFFFF'");
            }
            e.Row.Cells[0].Visible = false; // codEspécie
            e.Row.Cells[1].Visible = false; // nImagem
            e.Row.Cells[6].Visible = false; // codGenero
        }
    }
    protected void GridViewEspeciesNaoRecomendadas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image status = (Image)e.Row.Cells[2].FindControl("ImageEspecie");

                status.ImageUrl = Convert.ToInt32(e.Row.Cells[1].Text.Trim()) == 0 ?
                    "~/fotos/arvores/semFotoArvore.png" : "fotos/especies/" + e.Row.Cells[1].Text.Trim() + ".jpg";

                status.Attributes.Add("title", e.Row.Cells[3].Text);
                e.Row.Cells[5].Text += "&nbsp;m";

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= '#FFFFFF'");
            }
            e.Row.Cells[0].Visible = false; // codEspécie
            e.Row.Cells[1].Visible = false; // nImagem
            e.Row.Cells[6].Visible = false; // codGenero
        }
    }
}
