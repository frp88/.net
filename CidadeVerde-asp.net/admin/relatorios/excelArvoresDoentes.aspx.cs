using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class admin_relatorios_excelArvoresDoentes : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewArvores.DataSource = cv.buscaArvoreBynStatus(2);
        GridViewArvores.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=ListaArvoresDoentes.xls");
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HtmlForm fm = new HtmlForm();
        Response.Charset = "UTF-8";
        EnableViewState = false;
        Controls.Add(fm);
        fm.Controls.Add(GridViewArvores);
        fm.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }
    protected void GridViewArvores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (Convert.ToInt32(e.Row.Cells[2].Text.Trim()))
                {
                    case 2: // Doente
                        e.Row.Cells[2].Text = "Doente";
                        break;
                    case 3: // Doente
                        e.Row.Cells[2].Text = "Ferida";
                        break;
                    case 4: // Doente
                        e.Row.Cells[2].Text = "Morta";
                        break;
                    default: //Caso 1 - Saudável
                        e.Row.Cells[2].Text = "Saudavel";
                        break;
                }
                e.Row.Cells[1].Text = "&nbsp;" + e.Row.Cells[1].Text.Trim() + "&nbsp;";

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[0].Visible = false; // codArvore
            e.Row.Cells[3].Visible = false; // codEspecie
        }
    }
}
