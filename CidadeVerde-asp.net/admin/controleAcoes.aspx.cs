using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class controleAcoes : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["sorteio"] = "DESC";
            GridViewAcoes.DataSource = cv.buscaHistorico();
            GridViewAcoes.DataBind();
            HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasAcoes.aspx";
        }
    }
    #endregion

    #region PANEL LISTA AÇÕES
    /// <summary>
    /// Filtrar as arvores pelo click nas situaçoes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbSituacaoAcao_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoAcao.Text = String.Empty;
        FiltraAcoes();
    }
    /// <summary>
    /// Botao filtrar as arvores do sistema
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFiltrar_Click(object sender, EventArgs e)
    {
        rbSituacaoAcao.SelectedIndex = -1;
        FiltraAcoes();
    }
    /// <summary>
    /// Escolhe a quantidade de Árvores que será mostrada na tela
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMostrarAcoes_SelectedIndexChanged(object sender, EventArgs e)
    {
        FiltraAcoes();
    }
    /// <summary>
    /// Popula o gridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewAcoes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 1: // Pendente
                        e.Row.Cells[2].ToolTip = "Ação Pendente";
                        e.Row.Cells[2].Text = "<img src='../images/bolaVermelha.png' /> ";
                        break;
                    case 2: // Concluída
                        e.Row.Cells[2].ToolTip = "Ação Concluída";
                        e.Row.Cells[2].Text = "<img src='../images/bolaVerde.png' />";
                        break;
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[1].Visible = false; // nStatusHistorico
            e.Row.Cells[3].Visible = false; // codArvore
        }
    }
    /// <summary>
    /// Visualiza as Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewAcoes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewAcoes.Rows[indice];

            //// Obtem ID da Conta
            Int32 codAcao = Convert.ToInt32(linha.Cells[0].Text.Trim());
            Int32 statusAcao = Convert.ToInt32(linha.Cells[1].Text.Trim());
            ViewState["codAcao"] = codAcao.ToString();
            ViewState["StatusAcao"] = linha.Cells[1].Text.Trim();
            ViewState["codArvore"] = linha.Cells[3].Text.Trim();
            ViewState["codIdentArvore"] = linha.Cells[4].Text.Trim();
            if (e.CommandName.Equals("editarAcao"))
            {
                if (statusAcao == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('Não é possivel cadastrar uma nova ação! Árvore Morta.');", true);
                    ImageDialog.ImageUrl = "../images/erro32.png";
                    LabelDialog.Text = "Não é possível Editar a Ação!<br /><br /> Ação Concluída.";
                    //mensagem Java Script
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                }
                else
                {
                    DataSetCidadeVerde.tblHistoricoArvoreDataTable dtAcao = cv.buscaHistoricoByCodHistorico(codAcao);
                    //Popula campos
                    ddlCodigoIdentArvore.DataSource = cv.buscaArvoresVivas();
                    ddlCodigoIdentArvore.DataBind();
                    ddlCodigoIdentArvore.Items.Insert(0, "Selecione uma Árvore");
                    ddlAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
                    ddlAcaoRecomendada.DataBind();
                    ddlAcaoRecomendada.Items.Insert(0, "Selecione a Ação Recomendada");

                    //Seleciona Valores já cadastrados
                    ddlCodigoIdentArvore.SelectedValue = dtAcao[0].codArvore.ToString();
                    txtDescAcao.Text = dtAcao[0].descHistorico;
                    txtDataAcao.Text = (dtAcao[0].IsdtHistoricoNull() ? String.Empty : dtAcao[0].dtHistorico.ToShortDateString());
                    ddlAcaoRecomendada.SelectedValue = dtAcao[0].codAcaoRecomendada.ToString();
                    ddlStatusAcao.SelectedValue = dtAcao[0].nStatusHistorico.ToString();
                    //ddlStatusArvore.SelectedValue = dtAcao[0].nStatus.ToString();

                    LabelTituloCad.Text = "Editar Ação";
                    //Mostra o panel
                    PanelListaAcoes.Visible = false;
                    PanelConfirmaAcao.Visible = false;
                    PanelCadastrarAcao.Visible = true;
                }
            }
        }
        catch (Exception)
        {
        }
    }
    /// <summary>
    /// Ordena as linhas pelo clique em uma coluna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewAcoes_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSetCidadeVerde.tblHistoricoArvoreDataTable resultado = cv.buscaHistorico();
        DataRow[] temp = null;
        if (ViewState["sorteio"] != null)
        {
            if (ViewState["sorteio"].ToString().Equals("ASC"))
                ViewState["sorteio"] = "DESC";
            else
                ViewState["sorteio"] = "ASC";
        }
        GridViewAcoes.PageSize = Convert.ToInt32(ddlMostrarAcoes.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoAcao.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;

            switch (rbSituacaoAcao.SelectedValue)
            {
                case "1":
                    temp = resultado.Select("nStatusHistorico = 1", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewAcoes.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelAcoesPendentes.aspx";
                    break;
                case "2":
                    temp = resultado.Select("nStatusHistorico = 2", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewAcoes.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelAcoesConcluidas.aspx";
                    break;
                default:
                    temp = resultado.Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewAcoes.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasAcoes.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            Int32 codAcao;
            if (Int32.TryParse(txtCodigoAcao.Text.Trim(), out codAcao))
            {
                GridViewAcoes.DataSource = temp = resultado.Select("codHistorico = " + codAcao, e.SortExpression + " " + ViewState["sorteio"].ToString());
                GridViewAcoes.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
            }
        }
        GridViewAcoes.DataBind();
    }
    /// <summary>
    /// Muda de página no GridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewAcoes.PageIndex = e.NewPageIndex;
        FiltraAcoes();
    }
    /// <summary>
    /// Mostra a Tela de Cadastro de Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadastrarAcao_Click(object sender, EventArgs e)
    {
        ddlCodigoIdentArvore.DataSource = cv.buscaArvoresVivas();
        ddlCodigoIdentArvore.DataBind();
        ddlCodigoIdentArvore.Items.Insert(0, "Selecione a Árvore");

        ddlAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
        ddlAcaoRecomendada.DataBind();
        ddlAcaoRecomendada.Items.Insert(0, "Selecione a Ação Recomendada");

        rbSituacaoAcao.SelectedIndex = 0;
        LabelTituloCad.Text = "Cadastrar Ação";
        PanelListaAcoes.Visible = false;
        PanelCadastrarAcao.Visible = true;
    }
    /// <summary>
    /// Filtra as árvores do GridViewArvores por uma determinada situação
    /// </summary>
    public void FiltraAcoes()
    {
        GridViewAcoes.PageSize = Convert.ToInt32(ddlMostrarAcoes.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoAcao.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;
            switch (rbSituacaoAcao.SelectedValue)
            {
                case "1":
                    GridViewAcoes.DataSource = cv.buscaHistoricoBynStatusHistorico(1);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelAcoesPendentes.aspx";
                    break;
                case "2":
                    GridViewAcoes.DataSource = cv.buscaHistoricoBynStatusHistorico(2);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelAcoesConcluidas.aspx";
                    break;
                default:
                    GridViewAcoes.DataSource = cv.buscaHistorico();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasAcoes.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            Int32 codAcao;
            if (Int32.TryParse(txtCodigoAcao.Text.Trim(), out codAcao))
                GridViewAcoes.DataSource = cv.buscaHistoricoByCodHistorico(codAcao);
        }
        GridViewAcoes.DataBind();
    }
    protected void GridViewAcoes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewAcoes.PageIndex = e.NewPageIndex;
        FiltraAcoes();
    }

    #endregion

    #region CADASTRO / ATUALIZAÇÃO  DE AÇÕES

    /// <summary>
    /// Volta para a tela de Lista de Ações
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarListaAcoes_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codAcao");
        ViewState.Remove("StatusAcao");
        ViewState.Remove("codArvore");
        ViewState.Remove("codIdentArvore");
        PanelCadastrarAcao.Visible = false;
        PanelListaAcoes.Visible = true;
        FiltraAcoes();
    }
    /// <summary>
    /// Cadastra / atualiza uma  determinada ação
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarAcao_Click(object sender, EventArgs e)
    {
        LabelErroAcao.Visible = false;
        LabelConfirmaAcao.Visible = false;
        try
        {
            if (ddlCodigoIdentArvore.SelectedIndex == 0)
                throw new Exception("Selecione a Árvore.");
            if (String.IsNullOrEmpty(txtDescAcao.Text.Trim()))
                throw new Exception("Digite a Descrição da Ação.");
            DateTime dtAux;
            if (!String.IsNullOrEmpty(txtDataAcao.Text.Trim()))
                if (!DateTime.TryParse(txtDataAcao.Text.Trim(), out dtAux))
                    throw new Exception("Data Inválida");
            if (ddlAcaoRecomendada.SelectedIndex == 0)
                throw new Exception("Selecione a Ação Recomendada.");
            if (ddlStatusAcao.SelectedValue.Equals("2"))
                if (String.IsNullOrEmpty(txtDataAcao.Text.Trim()))
                    throw new Exception("Digite a Data de Realização");
            DateTime? dtAcao = null;
            if (!String.IsNullOrEmpty(txtDataAcao.Text))
                dtAcao = Convert.ToDateTime(txtDataAcao.Text.Trim());
            Int32 codArvore = Convert.ToInt32(ddlCodigoIdentArvore.SelectedValue);
            Int32 codAcao;
            if (ViewState["codAcao"] == null)
            {
                //Cadastra Ação
                codAcao = cv.InsereAcao(Convert.ToInt32(ddlAcaoRecomendada.SelectedValue), Convert.ToInt32(ddlCodigoIdentArvore.SelectedValue),
                     dtAcao, Convert.ToInt32(ddlStatusAcao.SelectedValue), txtDescAcao.Text.Trim());
                if (codAcao == 0)
                    throw new Exception("Erro de Inserção!");
                LabelConfirmaAcao.Text = "Ação cadastrada com sucesso!";
                ViewState["codAcao"] = codAcao.ToString();
            }
            else
            {
                //Atualiza Ação
                if (!cv.atualizaAcao(Convert.ToInt32(ddlAcaoRecomendada.SelectedValue), Convert.ToInt32(ddlCodigoIdentArvore.SelectedValue),
                       dtAcao, Convert.ToInt32(ddlStatusAcao.SelectedValue), txtDescAcao.Text.Trim(), Convert.ToInt32(ViewState["codAcao"].ToString())))
                    throw new Exception("Erro de Atualização!");
                LabelConfirmaAcao.Text = "Ação atualizada com sucesso!";
            }
            //ViewState["statusArvore"] = ddlStatusArvore.SelectedValue;
            //if (!cv.atualizaStatusArvore(Convert.ToInt32(ddlStatusArvore.SelectedValue), Convert.ToInt32(ddlCodigoIdentArvore.SelectedValue)))
            //    throw new Exception("Erro de Atualização da Situação da Árvore.");
            ImageConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaAcao.Visible = true;
            //ViewState.Remove("codAcao");
            //LimpaDadosAcao();
        }
        catch (Exception err)
        {
            ImageConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelErroAcao.Text = err.Message;
            LabelErroAcao.Visible = true;
        }
        PanelConfirmaAcao.Visible = true;
    }
    /// <summary>
    /// Cancela o cadastro / atualização de uma Ação
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarAcao_Click(object sender, EventArgs e)
    {
        PanelConfirmaAcao.Visible = false;
        LimpaDadosAcao();
        ViewState.Remove("codAcao");
    }

    /// <summary>
    /// Lima campos da tela cadastra / atualiza Ação
    /// </summary>
    protected void LimpaDadosAcao()
    {
        ddlCodigoIdentArvore.SelectedIndex = 0;
        ddlAcaoRecomendada.SelectedIndex = 0;
        ddlStatusAcao.SelectedIndex = 0;
        txtDescAcao.Text = String.Empty;
        txtDataAcao.Text = String.Empty;
    }
    #endregion
}
