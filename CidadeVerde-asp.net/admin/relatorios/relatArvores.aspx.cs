using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Reporting.WebForms;
//using lojaDataSetTableAdapters;
public partial class admin_relatorios_relatArvores : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportViewer1.Reset();
        ReportViewer1.LocalReport.ReportPath = @"admin/relatorios/RelatorioArvores.rdlc";
        ReportDataSource datasource = new ReportDataSource("DataSetCidadeVerde_tblArvore", cv.buscaArvores());//new lojaDataSetTableAdapters.tblPessoaTableAdapter().GetData());
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
}
