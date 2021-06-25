using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;


public partial class admin_consultaInjuriasAnual : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAno.Items.Clear();
            ddlAno.DataSource = cv.pegaAnosInjurias();
            ddlAno.DataBind();

            //ddlAno.SelectedValue = DateTime.Now.Year.ToString();
            MontaGrafico(Convert.ToInt32(ddlAno.SelectedValue));
            //ListItem list = new ListItem(DateTimeFormatInfo.CurrentInfo.GetMonthName(i), i.ToString());
            //DropDownListMeses.Items.Add(list);
        }
    }

    protected void MontaGrafico(Int32 ano)
    {
        DataSetCidadeVerde.dtRelatoriosAnualDataTable dtRelat = cv.RelatQuantArvInjuriadasByAno(ano);
        ChartArvores.ChartAreas[0].AxisX.Minimum = 0;
        ChartArvores.ChartAreas[0].AxisX.Maximum = 13;
        ChartArvores.Series[0].Points.Clear();
        ChartArvores.Series[1].Points.Clear();

        ChartArvores.Titles["TitleTitulo"].Text = "Quantidade Total de Árvores Injuriadas e Recuperadas  no ano de " + ano.ToString();
        DataPoint pointInjurias = null;
        DataPoint pointRecuperadas = null;

        if (dtRelat != null)
        {
            //Consulta no banco das valores de doenças cadastradas por mes e as doenças recupedas
            for (int i = 1; i <= 12; i++)
            {
                if (dtRelat.Count > 0 && dtRelat.Select("Mes = " + i).Length > 0)
                {
                    pointInjurias = new DataPoint(i, (Int32)dtRelat.Select("Mes = " + i)[0]["Arvores"]);
                    pointRecuperadas = new DataPoint(i, (Int32)dtRelat.Select("Mes = " + i)[0]["Recuperadas"]);
                    pointInjurias.ToolTip = "Total árvores Injuriadas no mês: " + dtRelat.Select("Mes = " + i)[0]["Arvores"].ToString();
                    pointRecuperadas.ToolTip = "Total de árvores recupedas no mês: " + dtRelat.Select("Mes = " + i)[0]["Recuperadas"].ToString();
                    ChartArvores.Series[0].Points.Add(pointInjurias);
                    ChartArvores.Series[1].Points.Add(pointRecuperadas);
                }
                else
                {
                    pointInjurias = new DataPoint(i, 0);
                    pointRecuperadas = new DataPoint(i, 0);
                    pointInjurias.ToolTip = "Total árvores Injuriadas no mês: 0";
                    pointRecuperadas.ToolTip = "Total de árvores recupedas no mês: 0";
                    ChartArvores.Series[0].Points.Add(pointInjurias);
                    ChartArvores.Series[1].Points.Add(pointRecuperadas);
                }
            }
        }
        //esse else é provisorio
        else
        {
            pointInjurias = new DataPoint(1, 0);
            pointRecuperadas = new DataPoint(2, 0);
            pointInjurias.ToolTip = "Total árvores Injuriadas no mês: 0";
            pointRecuperadas.ToolTip = "Total de árvores recupedas no mês: 0";
            ChartArvores.Series[0].Points.Add(pointInjurias);
            ChartArvores.Series[1].Points.Add(pointRecuperadas);
        }
        ((TextAnnotation)ChartArvores.Annotations[0]).Text = "Ano Selecionado: " + ano.ToString();
    }
    /// <summary>
    /// Seleciona o Ano Para Gerar o Gráfico
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
    {
        MontaGrafico(Convert.ToInt32(ddlAno.SelectedValue));
    }
}
