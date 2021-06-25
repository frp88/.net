using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

public partial class admin_consultaSituacaoArvores : AcessoRestrito
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CidadeVerde cv = new CidadeVerde();
        DataSetCidadeVerde.tblArvoreDataTable dtStatus = cv.buscaQuantStatusArvores();
        Int32 Saudavel = cv.buscaQuantArvoreBynStatus(1);
        Int32 Doentes = cv.buscaQuantArvoreBynStatus(2);
        Int32 Feridas = cv.buscaQuantArvoreBynStatus(3);
        Int32 Mortas = cv.buscaQuantArvoreBynStatus(4);

        ChartPizza.Series[0].Points.Clear();

        DataPoint pointSaudavel = new DataPoint(1, Saudavel);
        pointSaudavel.LegendToolTip = "Quantidade de Árvores Saudáveis = " + Saudavel.ToString();
        pointSaudavel.ToolTip = "Quantidade de Árvores Saudáveis = " + Saudavel.ToString();
        pointSaudavel.LegendText = "Árvores Saudáveis";
        pointSaudavel.Color = System.Drawing.Color.Green;
        pointSaudavel.Label = Saudavel.ToString();
        ChartPizza.Series[0].Points.Add(pointSaudavel);

        DataPoint pointDoente = new DataPoint(2, Doentes);
        pointDoente.LegendToolTip = "Quantidade de Árvores Doentes = " + Doentes.ToString();
        pointDoente.ToolTip = "Quantidade de Árvores Doentes = " + Doentes.ToString();
        pointDoente.LegendText = "Árvores Doentes";
        pointDoente.Color = System.Drawing.Color.Yellow;
        pointDoente.Label = Doentes.ToString();
        ChartPizza.Series[0].Points.Add(pointDoente);

        DataPoint pointFeridas = new DataPoint(3, Feridas);
        pointFeridas.LegendToolTip = "Quantidade de Árvores Feridas = " + Feridas.ToString();
        pointFeridas.ToolTip = "Quantidade de Árvores Feridas = " + Feridas.ToString();
        pointFeridas.LegendText = "Árvores Feridas";
        pointFeridas.Color = System.Drawing.Color.OrangeRed;
        pointFeridas.Label = Feridas.ToString();
        ChartPizza.Series[0].Points.Add(pointFeridas);

        DataPoint pointMortas = new DataPoint(4, Mortas);
        pointMortas.LegendToolTip = "Quantidade de Árvores Mortas = " + Mortas.ToString();
        pointMortas.ToolTip = "Quantidade de Árvores Mortas = " + Mortas.ToString();
        pointMortas.LegendText = "Árvores Mortas";
        pointMortas.Color = System.Drawing.Color.Gray;
        pointMortas.Label = Mortas.ToString();
        ChartPizza.Series[0].Points.Add(pointMortas);
    }
}
