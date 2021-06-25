using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_cadastroAcoes : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["sorteio"] = "DESC";
            GridViewArvores.DataSource = cv.buscaArvores();
            GridViewArvores.DataBind();
        }
    }
    #endregion

    #region PANEL GRID ARVORES

    /// <summary>
    /// Filtrar as arvores pelo click nas situaçoes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbSituacaoArvore_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoIdentArvore.Text = String.Empty;
        FiltraArvores();
    }
    /// <summary>
    /// Botao filtrar as arvores do sistema
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFiltrar_Click(object sender, EventArgs e)
    {
        rbSituacaoArvore.SelectedIndex = -1;
        FiltraArvores();
    }
    /// <summary>
    /// Escolhe a quantidade de Árvores que será mostrada na tela
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMostrarArvore_SelectedIndexChanged(object sender, EventArgs e)
    {
        FiltraArvores();
    }
    /// <summary>
    /// Popula o gridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (Convert.ToInt32(e.Row.Cells[2].Text.Trim()))
                {
                    case 2: // Doente
                        e.Row.Cells[2].ToolTip = "Árvore Doente";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreDoente.png' /> ";
                        break;
                    case 3: // Ferida
                        e.Row.Cells[2].ToolTip = "Árvore Ferida";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreFerida.png' />";
                        break;
                    case 4: // Morta
                        e.Row.Cells[2].ToolTip = "Árvore Morta";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreMorta.png' />";
                        break;
                    default: //Caso 1 - Saudável
                        e.Row.Cells[2].ToolTip = "Árvore Saudável";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreSaudavel.png' />";
                        break;
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[0].Visible = false; // codArvore
            e.Row.Cells[1].Visible = false; // nStatus arvore
            e.Row.Cells[3].Visible = false; // codEspecie
        }
    }
    /// <summary>
    /// Visualiza as Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewArvores.Rows[indice];

            //// Obtem ID da Conta
            Int32 codArvore = Convert.ToInt32(linha.Cells[0].Text.Trim());
            ViewState["codArvore"] = codArvore.ToString();
            ViewState["codIdentArvore"] = linha.Cells[4].Text.Trim();
            ViewState["statusArvore"] = linha.Cells[1].Text.Trim();
            if (e.CommandName.Equals("verAcoes"))
            {
                GridViewAcoesArvore.DataSource = cv.buscaHistoricoByCodArvore(codArvore);
                GridViewAcoesArvore.DataBind();
                LabelCodigoArvore.Text = ViewState["codIdentArvore"].ToString();
                PanelVerArvore.Visible = false;
                PanelHitoricoAcoesArvore.Visible = true;
            }
        }
        catch (Exception)
        {
        }
    }
    /// <summary>
    /// ORDENA OS DADOS DA TABELA DEPENDENDO DO CLICK NA COLUNA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewArvores.PageSize = Convert.ToInt32(ddlMostrarArvore.SelectedValue);
        DataSetCidadeVerde.tblArvoreDataTable resultado = cv.buscaArvores();
        if (ViewState["sorteio"] != null)
        {
            if (ViewState["sorteio"].ToString().Equals("ASC"))
                ViewState["sorteio"] = "DESC";
            else
                ViewState["sorteio"] = "ASC";
        }
        if (String.IsNullOrEmpty(txtCodigoIdentArvore.Text.Trim()))
        {
            switch (rbSituacaoArvore.SelectedValue)
            {
                case "1":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 1", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    break;
                case "2":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 2", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    break;
                case "3":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 3", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    break;
                case "4":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 4", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    break;
                default:
                    GridViewArvores.DataSource = resultado.Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    break;
            }
        }
        else
        {
            GridViewArvores.DataSource = resultado.Select("sCodIdentificacao like " + txtCodigoIdentArvore.Text.Trim(), e.SortExpression + " " + ViewState["sorteio"].ToString());
        }
        GridViewArvores.DataBind();
    }
    /// <summary>
    /// Muda de página no GridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewArvores.PageIndex = e.NewPageIndex;
        FiltraArvores();
    }
    /// <summary>
    /// Filtra as árvores do GridViewArvores por uma determinada situação
    /// </summary>
    public void FiltraArvores()
    {
        if (String.IsNullOrEmpty(txtCodigoIdentArvore.Text.Trim()))
        {
            GridViewArvores.PageSize = Convert.ToInt32(ddlMostrarArvore.SelectedValue);
            switch (rbSituacaoArvore.SelectedValue)
            {
                case "1":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(1);
                    break;
                case "2":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(2);
                    break;
                case "3":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(3);
                    break;
                case "4":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(4);
                    break;
                default:
                    GridViewArvores.DataSource = cv.buscaArvores();
                    break;
            }
        }
        else
        {
            GridViewArvores.DataSource = cv.buscaArvoreByCodIdentificacao(txtCodigoIdentArvore.Text.Trim());
        }
        GridViewArvores.DataBind();
    }
    #endregion

    #region PANEL GRID AÇÕES
    /// <summary>
    /// Popula as Açoes de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewAcoesArvore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image status = (Image)e.Row.Cells[2].FindControl("ImageStatusArvore");
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 1: // Em andamento
                        status.ToolTip = "Ação pendente";
                        status.ImageUrl = "~/images/bolaVermelha.png";
                        break;
                    case 2: // Concluida
                        status.ToolTip = "Ação concluída";
                        status.ImageUrl = "~/images/bolaVerde.png";
                        break;
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[8].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Ação?');");
            }
            e.Row.Cells[0].Visible = false; // codHistorico
            e.Row.Cells[1].Visible = false; // nStatus Acao
        }
    }
    /// <summary>
    /// Edita uma determinada Ação
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewAcoesArvore_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewAcoesArvore.Rows[indice];

            //// Obtem ID da Conta
            Int32 codAcao = Convert.ToInt32(linha.Cells[0].Text.Trim());
            Int32 statusAcao = Convert.ToInt32(linha.Cells[1].Text.Trim());
            ViewState["codAcao"] = codAcao;
            Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
            //Verifica se a Arvore nao está morta
            if (statusArvore == 4)
                throw new Exception("Não é possível editar a ação! <br /><br /> Árvore Morta.");

            //Verifica se a ação não está concluida
            if (statusAcao == 2)
                throw new Exception("Não é possível editar a ação! <br /><br />Ação Conluída.");

            if (e.CommandName.Equals("editarAcao"))
            {
                //Popula campos
                ddlAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
                ddlAcaoRecomendada.DataBind();
                ddlAcaoRecomendada.Items.Insert(0, "Selecione a Ação Rec.");
                LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();

                //Seleciona Valores já cadastrados
                DataSetCidadeVerde.tblHistoricoArvoreDataTable dtAcao = cv.buscaHistoricoByCodHistorico(codAcao);
                txtDescAcao.Text = dtAcao[0].descHistorico;
                txtDataAcao.Text = (dtAcao[0].IsdtHistoricoNull() ? String.Empty : dtAcao[0].dtHistorico.ToShortDateString());
                ddlAcaoRecomendada.SelectedValue = dtAcao[0].codAcaoRecomendada.ToString();
                ddlStatusAcao.SelectedValue = dtAcao[0].nStatusHistorico.ToString();
                //ddlStatusArvore.SelectedValue = ViewState["statusArvore"].ToString();

                //Mostra o panel
                PanelHitoricoAcoesArvore.Visible = false;
                PanelCadastrarAcao.Visible = true;
            }
            if (e.CommandName.Equals("excluirAcao"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Ação!");
                    if (!cv.deletaAcao(codAcao))
                        throw new Exception("Não é possível excluir a Ação!");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Injúria excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewAcoesArvore.DataSource = cv.buscaHistoricoByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
                    GridViewAcoesArvore.DataBind();
                }
                catch (Exception err)
                {
                    //   ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('" + err.Message + "');", true);
                    ImageDialog.ImageUrl = "../images/erro32.png";
                    LabelDialog.Text = err.Message;
                    //mensagem Java Script
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                }
            }
        }
        catch (Exception ex)
        {
            //   ScriptManager.RegisterStartupScript(this, GetType(), "cadAcao", "javascript: alert('Não é possível editar a ação! Árvore Morta.');", true);
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = ex.Message;
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);

        }
    }
    /// <summary>
    /// Volta para a tela de Árvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarTelaVerAcao_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codArvore");
        ViewState.Remove("codIdentArvore");
        ViewState.Remove("statusArvore");
        PanelHitoricoAcoesArvore.Visible = false;
        PanelVerArvore.Visible = true;
        GridViewArvores.DataSource = cv.buscaArvores();
        GridViewArvores.DataBind();
    }
    /// <summary>
    /// Mostra a Tela de Cadastro de Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadastrarAcao_Click(object sender, EventArgs e)
    {
        Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
        //Verifica se a Arvore nao está morta
        if (statusArvore == 4)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('Não é possivel cadastrar uma nova ação! Árvore Morta.');", true);
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = "Não é possível cadastrar uma nova ação! Árvore Morta.";
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
        else
        {
            ddlAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
            ddlAcaoRecomendada.DataBind();
            ddlAcaoRecomendada.Items.Insert(0, "Selecione a Ação Rec.");
            LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();
            //ddlStatusArvore.SelectedValue = ViewState["statusArvore"].ToString();

            PanelHitoricoAcoesArvore.Visible = false;
            PanelCadastrarAcao.Visible = true;
        }
    }
    #endregion

    #region CADASTRO / ATUALIZAÇÃO AÇÕES
    /// <summary>
    /// Cadastra / atualiza uma ação de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarAcao_Click(object sender, EventArgs e)
    {
        LabelErroAcao.Visible = false;
        LabelConfirmaAcao.Visible = false;
        try
        {
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
            Int32 codAcao;
            if (ViewState["codAcao"] == null)
            {
                //Cadastra Ação
                codAcao = Convert.ToInt32(cv.InsereAcao(Convert.ToInt32(ddlAcaoRecomendada.SelectedValue), Convert.ToInt32(ViewState["codArvore"].ToString()),
                    dtAcao, Convert.ToInt32(ddlStatusAcao.SelectedValue), txtDescAcao.Text.Trim()));
                if (codAcao == 0)
                    throw new Exception("Erro de Inserção!");
                LabelConfirmaAcao.Text = "Ação cadastrada com sucesso!";
                ViewState["codAcao"] = codAcao.ToString();
            }
            else
            {
                //Atualiza Ação
                codAcao = Convert.ToInt32(cv.atualizaAcao(Convert.ToInt32(ddlAcaoRecomendada.SelectedValue), Convert.ToInt32(ViewState["codArvore"].ToString()),
                   dtAcao, Convert.ToInt32(ddlStatusAcao.SelectedValue), txtDescAcao.Text.Trim(), Convert.ToInt32(ViewState["codAcao"].ToString())));
                if (codAcao == 0)
                    throw new Exception("Erro de Atualização!");
                LabelConfirmaAcao.Text = "Ação atualizada com sucesso!";
            }
            //ViewState["statusArvore"] = ddlStatusArvore.SelectedValue;
            //if (!cv.atualizaStatusArvore(Convert.ToInt32(ddlStatusArvore.SelectedValue), Convert.ToInt32(ViewState["codArvore"].ToString())))
            //  throw new Exception("Erro de Atualização da Situação da Árvore.");

            ImageConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaAcao.Visible = true;
        }
        catch (Exception err)
        {
            ImageConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelErroAcao.Text = err.Message;
            LabelErroAcao.Visible = true;
        }
        PanelConfirmaAcao.Visible = true;
        LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();
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
        LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();
        ViewState.Remove("codAcao");
    }
    /// <summary>
    /// Volta para a tela de Doenças de uma Determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarAcoesArvore_Click(object sender, EventArgs e)
    {
        GridViewAcoesArvore.DataSource = cv.buscaHistoricoByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
        GridViewAcoesArvore.DataBind();
        LabelCodigoArvore.Text = ViewState["codIdentArvore"].ToString();
        ViewState.Remove("codAcao");
        LimpaDadosAcao();
        PanelConfirmaAcao.Visible = false;
        PanelCadastrarAcao.Visible = false;
        PanelHitoricoAcoesArvore.Visible = true;
    }

    /// <summary>
    /// Lima campos da tela cadastra / atualiza Ação
    /// </summary>
    protected void LimpaDadosAcao()
    {
        ddlAcaoRecomendada.SelectedIndex = 0;
        ddlStatusAcao.SelectedIndex = 0;
        txtDescAcao.Text = String.Empty;
        txtDataAcao.Text = String.Empty;
    }
    #endregion
}
