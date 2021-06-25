using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class admin_relatorios_excelTodasInjurias : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewInjurias.DataSource = cv.buscaInjurias();
        GridViewInjurias.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=ListaInjurias.xls");
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HtmlForm fm = new HtmlForm();
        Response.Charset = "UTF-8";
        EnableViewState = false;
        Controls.Add(fm);
        fm.Controls.Add(GridViewInjurias);
        fm.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }
    /// <summary>
    /// Popula o gridViewInjurias
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewInjurias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Convert.ToInt32(e.Row.Cells[1].Text.Trim()) == 1 ? "Presente" : "Recuperada";
                e.Row.Cells[2].Text = "&nbsp;" + e.Row.Cells[2].Text.Trim() + "&nbsp;";

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[8].Visible = false; // codArvore
        }
    }
}
