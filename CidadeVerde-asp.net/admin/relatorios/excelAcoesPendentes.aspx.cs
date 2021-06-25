using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class admin_relatorios_excelAcoesPendentes : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewAcoes.DataSource = cv.buscaHistoricoBynStatusHistorico(1);
        GridViewAcoes.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=ListaAçõesPendentes.xls");
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HtmlForm fm = new HtmlForm();
        Response.Charset = "UTF-8";
        EnableViewState = false;
        Controls.Add(fm);
        fm.Controls.Add(GridViewAcoes);
        fm.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }
    protected void GridViewAcoes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Convert.ToInt32(e.Row.Cells[1].Text.Trim()) == 1 ? "Concluida" : "Pendente";
                e.Row.Cells[3].Text = "&nbsp;" + e.Row.Cells[3].Text.Trim() + "&nbsp;";

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[2].Visible = false; // codArvore
        }
    }
}
