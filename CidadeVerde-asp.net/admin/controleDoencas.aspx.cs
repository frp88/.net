using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_controleDoencas : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["sorteio"] = "DESC";
            GridViewDoencas.DataSource = cv.buscaDoencas();
            GridViewDoencas.DataBind();
            HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasDoencas.aspx";
        }
    }
    #endregion

    #region PANEL LISTA DOENÇAS
    /// <summary>
    /// Filtrar as doenças por uma determinada situaçao
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbSituacaoDoenca_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoDoenca.Text = String.Empty;
        FiltraDoencas();
    }
    /// <summary>
    /// Botao filtrar as arvores do sistema
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFiltrar_Click(object sender, EventArgs e)
    {
        rbSituacaoDoenca.SelectedIndex = -1;
        FiltraDoencas();
    }
    /// <summary>
    /// Escolhe a quantidade de Árvores que será mostrada na tela
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMostrarDoencas_SelectedIndexChanged(object sender, EventArgs e)
    {
        FiltraDoencas();
    }
    /// <summary>
    /// Popula o gridViewDoencas
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewDoencas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 1: // Doença Presente
                        e.Row.Cells[2].ToolTip = "Doença ainda Presente";
                        e.Row.Cells[2].Text = "<img src='../images/bolaAmarela.png' /> ";
                        break;
                    case 2: // Doença Recuperada
                        e.Row.Cells[2].ToolTip = "Doença Recuperada";
                        e.Row.Cells[2].Text = "<img src='../images/bolaVerde.png' />";
                        break;
                }
                e.Row.Cells[6].Text = (e.Row.Cells[4].Text == "&nbsp;" ? e.Row.Cells[5].Text : e.Row.Cells[4].Text);
                e.Row.Cells[4].Text = e.Row.Cells[5].Text = String.Empty;

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[1].Visible = false; // nStatus Doença
            e.Row.Cells[4].Visible = false; // descParasita
            e.Row.Cells[5].Visible = false; // descGrupoParasita
            e.Row.Cells[12].Visible = false; // codArvore
        }
    }
    /// <summary>
    /// Visualiza as Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewDoencas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewDoencas.Rows[indice];

            //// Obtem ID da Conta
            Int32 codDoenca = Convert.ToInt32(linha.Cells[0].Text.Trim());
            Int32 statusDoenca = Convert.ToInt32(linha.Cells[1].Text.Trim());
            ViewState["codDoenca"] = codDoenca.ToString();
            ViewState["statusDoenca"] = statusDoenca.ToString();
            ViewState["codArvore"] = linha.Cells[12].Text.Trim();
            ViewState["statusArvore"] = linha.Cells[4].Text.Trim();
            ViewState["codIdentArvore"] = linha.Cells[5].Text.Trim();
            if (e.CommandName.Equals("editarDoenca"))
            {

                if (statusDoenca == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('Não é possivel cadastrar uma nova ação! Árvore Morta.');", true);
                    ImageDialog.ImageUrl = "../images/erro32.png";
                    LabelDialog.Text = "Não é possível Editar a Doença!<br /><br />Doença Recuperada.";
                    //mensagem Java Script
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                }
                else
                {
                    //Popula campos
                    populaCamposCadDoenca();

                    //Seleciona Valores já cadastrados
                    DataSetCidadeVerde.tblDoencasDataTable dtDoenca = cv.buscaDoencaByCodDoenca(codDoenca);
                    if (linha.Cells[4].Text.Trim() != "&nbsp;")
                    {
                        PanelParasitas.Visible = true;
                        PanelGrupoParasitas.Visible = false;
                        ddlParasitas.SelectedValue = dtDoenca[0].codParasita.ToString();
                        rbTipoParasitas.SelectedValue = "1";
                    }
                    else
                    {
                        PanelParasitas.Visible = false;
                        PanelGrupoParasitas.Visible = true;
                        ddlGrupoParasitas.SelectedValue = dtDoenca[0].codGrupoParasita.ToString();
                        rbTipoParasitas.SelectedValue = "2";
                    }
                    ddlCodigoIdentArvore.SelectedValue = dtDoenca[0].codArvore.ToString();
                    ddlLocalAfetado.SelectedValue = dtDoenca[0].codLocalAfetado.ToString();
                    ddlIntensidade.SelectedValue = dtDoenca[0].codIntensidade.ToString();
                    txtDescDoenca.Text = dtDoenca[0].descDoenca;
                    txtDataConclusao.Text = (dtDoenca[0].IsdtDoencaNull() ? String.Empty : dtDoenca[0].dtDoenca.ToShortDateString());
                    ddlStatusDoenca.SelectedValue = dtDoenca[0].statusDoenca.ToString();
                    LabelTituloCadDoenca.Text = "Editar Doença";
                    //Mostra o panel
                    PanelListaDoencas.Visible = false;
                    PanelConfirmaDoenca.Visible = false;
                    PanelCadastrarDoenca.Visible = true;
                }
            }
        }
        catch (Exception)
        {
        }
    }
    /// <summary>
    /// Realiza o a ordem das colunas da lista
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewDoencas_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSetCidadeVerde.tblDoencasDataTable resultado = cv.buscaDoencas();
        DataRow[] temp = null;
        if (ViewState["sorteio"] != null)
        {
            if (ViewState["sorteio"].ToString().Equals("ASC"))
                ViewState["sorteio"] = "DESC";
            else
                ViewState["sorteio"] = "ASC";
        }
        GridViewDoencas.PageSize = Convert.ToInt32(ddlMostrarDoencas.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoDoenca.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;

            switch (rbSituacaoDoenca.SelectedValue)
            {
                case "1":
                    temp = resultado.Select("statusDoenca = 1", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewDoencas.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelDoencasPresentes.aspx";
                    break;
                case "2":
                    temp = resultado.Select("statusDoenca = 2", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewDoencas.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelDoencasRecuperadas.aspx";
                    break;
                default:
                    temp = resultado.Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewDoencas.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasDoencas.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            Int32 codDoenca;
            if (Int32.TryParse(txtCodigoDoenca.Text.Trim(), out codDoenca))
            {
                GridViewDoencas.DataSource = temp = resultado.Select("codDoenca = " + codDoenca, e.SortExpression + " " + ViewState["sorteio"].ToString());
                GridViewDoencas.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
            }
        }
        GridViewDoencas.DataBind();
    }
    /// <summary>
    /// Aterna entre paginas da lista de doencas
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewDoencas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewDoencas.PageIndex = e.NewPageIndex;
        FiltraDoencas();
    }
    /// <summary>
    /// Muda de página no GridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewDoencas.PageIndex = e.NewPageIndex;
        FiltraDoencas();
    }
    /// <summary>
    /// Mostra a Tela de Cadastro de Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCadastrarDoenca_Click(object sender, EventArgs e)
    {
        LimpaViewState();
        populaCamposCadDoenca();
        LabelTituloCadDoenca.Text = "Cadastrar Doença";
        PanelListaDoencas.Visible = false;
        PanelConfirmaDoenca.Visible = false;
        PanelCadastrarDoenca.Visible = true;

    }
    /// <summary>
    /// Filtra as árvores do GridViewArvores por uma determinada situação
    /// </summary>
    public void FiltraDoencas()
    {
        GridViewDoencas.PageSize = Convert.ToInt32(ddlMostrarDoencas.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoDoenca.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;
            switch (rbSituacaoDoenca.SelectedValue)
            {
                case "1":
                    GridViewDoencas.DataSource = cv.buscaDoencaBynStatusDoenca(1);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelDoencasPresentes.aspx";
                    break;
                case "2":
                    GridViewDoencas.DataSource = cv.buscaDoencaBynStatusDoenca(2);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelDoencasRecuperadas.aspx";
                    break;
                default:
                    GridViewDoencas.DataSource = cv.buscaDoencas();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasDoencas.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            Int32 codDoenca;
            if (Int32.TryParse(txtCodigoDoenca.Text.Trim(), out codDoenca))
                GridViewDoencas.DataSource = cv.buscaDoencaByCodDoenca(codDoenca);
        }
        GridViewDoencas.DataBind();
    }
    #endregion

    #region CADASTRO / ATUALIZAÇÃO  DE DOENÇAS
    /// <summary>
    /// Seleciona se a doenças é causada por um parasita ou por um tipo de parasita
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbTipoParasitas_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (rbTipoParasitas.SelectedValue)
        {
            case "1":
                PanelGrupoParasitas.Visible = false;
                PanelParasitas.Visible = true;
                break;
            case "2":
                PanelParasitas.Visible = false;
                PanelGrupoParasitas.Visible = true;
                break;
            default:
                PanelParasitas.Visible = false;
                PanelGrupoParasitas.Visible = false;
                break;
        }
    }

    /// <summary>
    /// Volta para a tela de Lista de Doenças
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarListaDoencas_Click(object sender, EventArgs e)
    {
        LimpaViewState();
        LimpaDadosDoenca();
        PanelCadastrarDoenca.Visible = false;
        PanelConfirmaDoenca.Visible = false;
        PanelListaDoencas.Visible = true;
        FiltraDoencas();
    }
    /// <summary>
    /// Cadastra / atualiza uma  determinada Doença
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarDoenca_Click(object sender, EventArgs e)
    {
        LabelErroDoenca.Visible = false;
        LabelConfirmaDoenca.Visible = false;
        try
        {
            if (ddlCodigoIdentArvore.SelectedIndex == 0)
                throw new Exception("Selecione a Árvore.");
            if (rbTipoParasitas.SelectedValue != "1" && rbTipoParasitas.SelectedValue != "2")
                throw new Exception("Selecione um Tipo de Parasita!");
            else if (rbTipoParasitas.SelectedValue == "1" && ddlParasitas.SelectedIndex == 0)
                throw new Exception("Selecione um Parasita!");
            else if (rbTipoParasitas.SelectedValue == "2" && ddlGrupoParasitas.SelectedIndex == 0)
                throw new Exception("Selecione um Grupo de Parasita!");
            if (ddlLocalAfetado.SelectedIndex == 0)
                throw new Exception("Selecione o Local Afetado.");
            if (ddlIntensidade.SelectedIndex == 0)
                throw new Exception("Selecione a Intensidade.");
            if (String.IsNullOrEmpty(txtDescDoenca.Text.Trim()))
                if (String.IsNullOrEmpty(txtDescDoenca.Text.Trim()))
                    throw new Exception("Digite a Descrição da Doença.");
            if (ddlStatusDoenca.SelectedValue.Equals("2"))
                if (String.IsNullOrEmpty(txtDataConclusao.Text.Trim()))
                    throw new Exception("Digite a Data da Recuperação");
            DateTime dtAux;
            if (!String.IsNullOrEmpty(txtDataConclusao.Text.Trim()))
            {
                if (!DateTime.TryParse(txtDataConclusao.Text.Trim(), out dtAux))
                    throw new Exception("Data Inválida");
            }
            DateTime? dtDoenca = null;
            if (!String.IsNullOrEmpty(txtDataConclusao.Text))
                dtDoenca = Convert.ToDateTime(txtDataConclusao.Text.Trim());

            Int32 codArvore = Convert.ToInt32(ddlCodigoIdentArvore.SelectedValue);
            Int32 codDoenca;
            if (ViewState["codDoenca"] == null)
            {
                //Insere uma Doença da Arvore
                if (rbTipoParasitas.SelectedValue == "1")
                {
                    codDoenca = cv.InsereDoenca(codArvore, Convert.ToInt32(ddlParasitas.SelectedValue), null,
                        Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescDoenca.Text.Trim(),
                        dtDoenca, Convert.ToInt32(ddlStatusDoenca.SelectedValue));
                }
                else
                {
                    codDoenca = cv.InsereDoenca(codArvore, null, Convert.ToInt32(ddlGrupoParasitas.SelectedValue),
                 Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescDoenca.Text.Trim(),
                 dtDoenca, Convert.ToInt32(ddlStatusDoenca.SelectedValue));
                }
                if (codDoenca == 0)
                    throw new Exception("Erro de Inserção de Doença.");

                ViewState["codDoenca"] = codDoenca;
                LabelConfirmaDoenca.Text = "Doença cadastrada com sucesso!";
            }
            else
            {
                //Atualiza uma Doença da Arvore
                if (rbTipoParasitas.SelectedValue == "1")
                {
                    if (!cv.atualizaDoenca(codArvore, Convert.ToInt32(ddlParasitas.SelectedValue), null,
                      Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescDoenca.Text.Trim(),
                      dtDoenca, Convert.ToInt32(ddlStatusDoenca.SelectedValue), Convert.ToInt32(ViewState["codDoenca"].ToString())))
                        throw new Exception("Erro de Atualização da Doença");
                }
                else
                {
                    if (!cv.atualizaDoenca(codArvore, null, Convert.ToInt32(ddlGrupoParasitas.SelectedValue),
                        Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescDoenca.Text.Trim(),
                        dtDoenca, Convert.ToInt32(ddlStatusDoenca.SelectedValue), Convert.ToInt32(ViewState["codDoenca"].ToString())))
                        throw new Exception("Erro de Atualização da Doença");
                }
                LabelConfirmaDoenca.Text = "Doença atualizada com sucesso!";
            }

            //Verifica se o Status da doença está ativa (=1) e se o status da arvore é saudável (=1) (se a arvore está saudável ela não tem doença)
            Int32 statusArvore = cv.buscaArvoreByCodArvore(codArvore)[0].nStatus;
            if (ddlStatusDoenca.SelectedValue == "1" && statusArvore == 1)
                //atualiza o status da arvore para doente (=2)
                cv.atualizaStatusArvore(2, codArvore);
            //Verifica se o Status da doença está Concluida (=2)
            if (ddlStatusDoenca.SelectedValue == "2")
                // Atualiza Status da árvore (saudavel / injuriada
                atualizaStatusArvore(codArvore);

            if (ViewState["codArvore"] != null)
            {
                Int32 codArvoreAnterior = Convert.ToInt32(ViewState["codArvore"].ToString());
                //Atualiza Status de Árvore anterior (se alterou a arvore com a doença)
                if (codArvoreAnterior != codArvore)
                    // verifica se a arvore não tem mais nenhuma doença
                    // Atualiza Status da árvore (saudavel / injuriada
                    atualizaStatusArvore(codArvoreAnterior);
            }
            ViewState["codArvore"] = codArvore.ToString();
            ImageConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaDoenca.Visible = true;
            //LimpaDadosDoenca();
        }
        catch (Exception err)
        {
            ImageConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelErroDoenca.Text = err.Message;
            LabelErroDoenca.Visible = true;
        }
        PanelConfirmaDoenca.Visible = true;
    }

    /// <summary>
    /// Cancela o cadastro / atualização de uma Doença
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarDoenca_Click(object sender, EventArgs e)
    {
        PanelConfirmaDoenca.Visible = false;
        LimpaDadosDoenca();
        ViewState.Remove("codDoenca");
        ViewState.Remove("statusDoenca");
        ViewState.Remove("codArvore");
        ViewState.Remove("statusArvore");
        ViewState.Remove("codIdentArvore");
    }

    /// <summary>
    /// Atualiza o Status da Arvore para saudavel ou injuriada
    /// </summary>
    /// <param name="codArvore"></param>
    protected void atualizaStatusArvore(int codArvore)
    {
        if (cv.quantDoencasArvore(codArvore) == 0)
        {
            //verifica se vai atualizar pra injuriada ou saudavel
            if (cv.quantInjuriasArvore(codArvore) == 0)
                //atualiza o status da arvore para saudável (=1)
                cv.atualizaStatusArvore(1, codArvore);
            else
                cv.atualizaStatusArvore(3, codArvore);
        }
    }
    /// <summary>
    /// Lima campos da tela cadastra / atualiza Doença
    /// </summary>
    protected void LimpaDadosDoenca()
    {
        ddlCodigoIdentArvore.SelectedIndex = 0;
        ddlGrupoParasitas.SelectedIndex = 0;
        ddlParasitas.SelectedIndex = 0;
        ddlIntensidade.SelectedIndex = 0;
        ddlLocalAfetado.SelectedIndex = 0;
        ddlStatusDoenca.SelectedIndex = 0;
        txtDescDoenca.Text = String.Empty;
        txtDataConclusao.Text = String.Empty;
    }
    protected void LimpaViewState()
    {
        ViewState.Remove("codDoenca");
        ViewState.Remove("statusDoenca");
        ViewState.Remove("codArvore");
        ViewState.Remove("statusArvore");
        ViewState.Remove("codIdentArvore");
    }
    public void populaCamposCadDoenca()
    {
        //Popula campos
        ddlCodigoIdentArvore.DataSource = cv.buscaArvoresVivas();
        ddlCodigoIdentArvore.DataBind();
        ddlCodigoIdentArvore.Items.Insert(0, "Selecione uma Árvore");
        ddlParasitas.DataSource = cv.buscaParasitas();
        ddlParasitas.DataBind();
        ddlParasitas.Items.Insert(0, "Selecione o Parasita");
        ddlGrupoParasitas.DataSource = cv.buscaGrupoParasitas();
        ddlGrupoParasitas.DataBind();
        ddlGrupoParasitas.Items.Insert(0, "Selecione o Grupo de Parasita");
        ddlIntensidade.DataSource = cv.buscaIntensidade();
        ddlIntensidade.DataBind();
        ddlIntensidade.Items.Insert(0, "Selecione a Intensidade");
        ddlLocalAfetado.DataSource = cv.buscaLocalAfetado();
        ddlLocalAfetado.DataBind();
        ddlLocalAfetado.Items.Insert(0, "Selecione o Local Afetado");
    }
    #endregion
}