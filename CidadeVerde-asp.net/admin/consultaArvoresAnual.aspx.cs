using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;


public partial class admin_consultaArvoresAnual : AcessoRestrito
{
    protected enum TipoConsulta
    {
        ArvoresDoentes = 1, ArvoresInjuriadas = 2, AcoesArvores = 3
    }
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAno.Items.Clear();
            ddlAno.DataSource = cv.pegaAnosDoencas();
            ddlAno.DataBind();

            //ddlAno.SelectedValue = DateTime.Now.Year.ToString();
            MontaGrafico(TipoConsulta.ArvoresDoentes, Convert.ToInt32(ddlAno.SelectedValue));
            //ListItem list = new ListItem(DateTimeFormatInfo.CurrentInfo.GetMonthName(i), i.ToString());
            //DropDownListMeses.Items.Add(list);
        }
    }
    /// <summary>
    /// Monta Grafico pelo Tipo de Consulta e o Ano selecionado
    /// </summary>
    /// <param name="tipoConsulta"></param>
    /// <param name="ano"></param>
    protected void MontaGrafico(TipoConsulta tipoConsulta, Int32 ano)
    {
        DataSetCidadeVerde.dtRelatoriosAnualDataTable dtRelat = null;
        DataPoint pointArvores = null;
        DataPoint pointRecuperadas = null;
        switch (tipoConsulta)
        {
            case TipoConsulta.ArvoresDoentes:
                dtRelat = cv.RelatQuantArvDoentesByAno(ano);
                ChartArvores.Titles["TitleTitulo"].Text = "Quantidade Total de Árvores Doentes e Recuperadas  no ano de " + ano.ToString();
                ChartArvores.Series[0].Color = System.Drawing.Color.Yellow;//Points.Add(pointArvores);
                break;
            case TipoConsulta.ArvoresInjuriadas:
                dtRelat = cv.RelatQuantArvInjuriadasByAno(ano);
                ChartArvores.Titles["TitleTitulo"].Text = "Quantidade Total de Árvores Injuriadas e Recuperadas  no ano de " + ano.ToString();
                ChartArvores.Series[0].Color = System.Drawing.Color.Orange;
                break;
            case TipoConsulta.AcoesArvores:
                dtRelat = cv.RelatQuantArvAcoesByAno(ano);
                ChartArvores.Titles["TitleTitulo"].Text = "Quantidade Total de Árvores que sofreram Ações no ano de " + ano.ToString();
                ChartArvores.Series[0].Color = System.Drawing.Color.Red;
                break;

        }
        ChartArvores.ChartAreas[0].AxisX.Minimum = 0;
        ChartArvores.ChartAreas[0].AxisX.Maximum = 13;
        ChartArvores.Series[0].Points.Clear();
        ChartArvores.Series[1].Points.Clear();

        if (dtRelat != null)
        {
            //Consulta no banco das valores de doenças cadastradas por mes e as doenças recupedas
            for (int i = 1; i <= 12; i++)
            {
                if (dtRelat.Count > 0 && dtRelat.Select("Mes = " + i).Length > 0)
                {
                    pointArvores = new DataPoint(i, (Int32)dtRelat.Select("Mes = " + i)[0]["Arvores"]);
                    pointRecuperadas = new DataPoint(i, (Int32)dtRelat.Select("Mes = " + i)[0]["Recuperadas"]);
                    pointArvores.ToolTip = (tipoConsulta == TipoConsulta.ArvoresDoentes ? "Total de árvores doentes no mês: " :
                        tipoConsulta == TipoConsulta.ArvoresInjuriadas ? "Total de árvores injuriadas no mês: "
                        : "Total de árvores que sofreram ações no mês: ") + dtRelat.Select("Mes = " + i)[0]["Arvores"].ToString();
                    pointRecuperadas.ToolTip = (tipoConsulta == TipoConsulta.AcoesArvores ? "Total de árvores que sofreram ações e foram concluídas no mês: "
                        : "Total de árvores recuperadas no mês: ") + dtRelat.Select("Mes = " + i)[0]["Recuperadas"].ToString();
                    ChartArvores.Series[0].Points.Add(pointArvores);
                    ChartArvores.Series[1].Points.Add(pointRecuperadas);
                }
                else
                {
                    pointArvores = new DataPoint(i, 0);
                    pointRecuperadas = new DataPoint(i, 0);
                    pointArvores.ToolTip += "0";
                    pointRecuperadas.ToolTip += "0";
                    ChartArvores.Series[0].Points.Add(pointArvores);
                    ChartArvores.Series[1].Points.Add(pointRecuperadas);
                }
            }
        }
        //esse else é provisorio
        //else
        //{
        //    pointArvores = new DataPoint(1, 0);
        //    pointRecuperadas = new DataPoint(2, 0);
        //    pointArvores.ToolTip += "0";
        //    pointRecuperadas.ToolTip += "0";
        //    ChartArvores.Series[0].Points.Add(pointArvores);
        //    ChartArvores.Series[1].Points.Add(pointRecuperadas);
        //}
        ((TextAnnotation)ChartArvores.Annotations[0]).Text = "Ano Selecionado: " + ano.ToString();
    }
    /// <summary>
    /// Seleciona o Ano Para Gerar o Gráfico
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlTipoConsulta.SelectedValue)
        {
            case "2":
                MontaGrafico(TipoConsulta.ArvoresInjuriadas, Convert.ToInt32(ddlAno.SelectedValue));
                break;
            case "3":
                MontaGrafico(TipoConsulta.AcoesArvores, Convert.ToInt32(ddlAno.SelectedValue));
                break;
            default:
                MontaGrafico(TipoConsulta.ArvoresDoentes, Convert.ToInt32(ddlAno.SelectedValue));
                break;
        }
    }
    /// <summary>
    /// Seleciona o tipo de consulta que pretende realizar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAno.Items.Clear();
        switch (ddlTipoConsulta.SelectedValue)
        {
            //Árvores Injuriadas
            case "2":
                ddlAno.DataSource = cv.pegaAnosInjurias();
                ddlAno.DataBind();
                MontaGrafico(TipoConsulta.ArvoresInjuriadas, Convert.ToInt32(ddlAno.SelectedValue));
                break;
            //Árvores que sofreram ações
            case "3":
                ddlAno.DataSource = cv.pegaAnosAcao();
                ddlAno.DataBind();
                MontaGrafico(TipoConsulta.AcoesArvores, Convert.ToInt32(ddlAno.SelectedValue));
                break;
            //Árvores Doentes
            default:
                ddlAno.DataSource = cv.pegaAnosDoencas();
                ddlAno.DataBind();
                MontaGrafico(TipoConsulta.ArvoresDoentes, Convert.ToInt32(ddlAno.SelectedValue));
                break;
        }
    }
}
