using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;

public partial class admin_relatorios_excelTodasEspecies : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewEspecies.DataSource = cv.buscaEspecies();
        GridViewEspecies.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=ListaEspecies.xls");
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HtmlForm fm = new HtmlForm();
        Response.Charset = "UTF-8";
        EnableViewState = false;
        Controls.Add(fm);
        fm.Controls.Add(GridViewEspecies);
        fm.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }
    /// <summary>
    /// Popula GridViewEspecies
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewEspecies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Convert.ToInt32(e.Row.Cells[1].Text.Trim()) == 1 ? "Sim" : Server.HtmlEncode("Não");

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[0].Visible = false; // codEspécie
            e.Row.Cells[3].Visible = false; // codGenero
        }
    }
}
