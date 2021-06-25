using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_cadastroDoencas : AcessoRestrito
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
    /// Visualiza as Doenças de uma determinada Árvore
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
            if (e.CommandName.Equals("verDoencas"))
            {
                GridViewDoencasArvore.DataSource = cv.buscaDoencasByCodArvore(codArvore);
                GridViewDoencasArvore.DataBind();
                LabelCodigoArvore.Text = ViewState["codIdentArvore"].ToString();
                PanelVerArvore.Visible = false;
                PanelDoencasArvore.Visible = true;
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
    /// Escolhe a quantidade de Árvores que será mostrada na tela
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMostrarArvore_SelectedIndexChanged(object sender, EventArgs e)
    {
        FiltraArvores();
    }

    /// <summary>
    /// Filtra as árvores do GridViewArvores por uma determinada situação
    /// </summary>
    public void FiltraArvores()
    {
        GridViewArvores.PageSize = Convert.ToInt32(ddlMostrarArvore.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoIdentArvore.Text.Trim()))
        {
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

    #region PANEL GRID DOENÇAS

    /// <summary>
    /// Popula as Doenças de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewDoencasArvore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image status = (Image)e.Row.Cells[2].FindControl("ImageStatusArvore");
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 1: // Ainda Doente
                        status.ToolTip = "Doença ainda Presente";
                        status.ImageUrl = "~/images/bolaAmarela.png";
                        break;
                    case 2: // Curada
                        status.ToolTip = "Doença Recuperada";
                        status.ImageUrl = "~/images/bolaVerde.png";
                        break;
                }
                e.Row.Cells[5].Text = (e.Row.Cells[3].Text == "&nbsp;" ? e.Row.Cells[4].Text : e.Row.Cells[3].Text);
                //e.Row.Cells[3].Text = (e.Row.Cells[3].Text == "&nbsp;" ? "FESP - UEMG" : e.Row.Cells[3].Text);

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[12].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Doença?');");
            }
            e.Row.Cells[0].Visible = false; // codDoenca
            e.Row.Cells[1].Visible = false; // nStatus Doença
            e.Row.Cells[3].Visible = false; // descParasita
            e.Row.Cells[4].Visible = false; // descGrupoParasita
        }
    }

    protected void GridViewDoencasArvore_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewDoencasArvore.Rows[indice];

            //// Obtem ID da Conta
            Int32 codDoenca = Convert.ToInt32(linha.Cells[0].Text.Trim());
            ViewState["codDoenca"] = codDoenca;
            Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
            //Verifica se a Arvore nao está morta
            if (statusArvore == 4)
                throw new Exception("Não é possível editar a doença!<br /> Árvore Morta.");

            if (e.CommandName.Equals("editarDoenca"))
            {
                //Popula campos
                populaCamposCadDoenca();

                //Seleciona Valores já cadastrados
                DataSetCidadeVerde.tblDoencasDataTable dtDoenca = cv.buscaDoencaByCodDoenca(codDoenca);
                if (linha.Cells[3].Text.Trim() != "&nbsp;")
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
                ddlLocalAfetado.SelectedValue = dtDoenca[0].codLocalAfetado.ToString();
                ddlIntensidade.SelectedValue = dtDoenca[0].codIntensidade.ToString();
                txtDescDoenca.Text = dtDoenca[0].descDoenca;
                txtDataDoenca.Text = (dtDoenca[0].IsdtDoencaNull() ? String.Empty : dtDoenca[0].dtDoenca.ToShortDateString());
                ddlStatusDoenca.SelectedValue = dtDoenca[0].statusDoenca.ToString();

                //Mostra o panel
                PanelDoencasArvore.Visible = false;
                PanelCadastrarDoenca.Visible = true;
            }
            if (e.CommandName.Equals("excluirDoenca"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Doença!");
                    if (!cv.deletaDoenca(codDoenca))
                        throw new Exception("Não é possível excluir a Doença!");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Doença excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewDoencasArvore.DataSource = cv.buscaDoencasByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
                    GridViewDoencasArvore.DataBind();
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
            //   ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('Não é possível editar a doença! Árvore Morta.');", true);
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
    protected void btVoltarTelaVerArvore_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codArvore");
        ViewState.Remove("codIdentArvore");
        ViewState.Remove("statusArvore");
        FiltraArvores();
        PanelDoencasArvore.Visible = false;
        PanelVerArvore.Visible = true;
    }
    /// <summary>
    /// Mostra a Tela de Cadastro de Doenças de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadastrarDoenca_Click(object sender, EventArgs e)
    {
        Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
        //Verifica se a Arvore nao está morta
        if (statusArvore == 4)
        {
            //   ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('Não é possível cadastrar uma nova doença! Árvore Morta.');", true);
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = "Não é possível cadastrar uma nova doença!<br /> Árvore Morta.";
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
        else
        {
            populaCamposCadDoenca();
            PanelDoencasArvore.Visible = false;
            PanelCadastrarDoenca.Visible = true;
            ViewState.Remove("codDoenca");
        }
    }
    #endregion

    #region CADASTRO / ATUALIZAÇÃO DOENÇAS
    /// <summary>
    /// Cadastra / atualiza uma doença de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarDoenca_Click(object sender, EventArgs e)
    {
        try
        {
            LabelConfirmaDoenca.Visible = false;
            LabelErroDoenca.Visible = false;
            Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
            Int32 codArvore = Convert.ToInt32(ViewState["codArvore"].ToString());

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
                throw new Exception("Digite a Descrição.");
            if (ddlStatusDoenca.SelectedValue.Equals("2"))
                if (String.IsNullOrEmpty(txtDataDoenca.Text.Trim()))
                    throw new Exception("Digite a Data de Recuperação");
            DateTime dtAux;
            if (!String.IsNullOrEmpty(txtDataDoenca.Text.Trim()))
                if (!DateTime.TryParse(txtDataDoenca.Text.Trim(), out dtAux))
                    throw new Exception("Data Inválida");
            DateTime? dtDoenca = null;
            if (!String.IsNullOrEmpty(txtDataDoenca.Text))
                dtDoenca = Convert.ToDateTime(txtDataDoenca.Text.Trim());

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
                    throw new Exception("Erro de Inserção da Doença");

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
                        dtDoenca, Convert.ToInt32(ddlStatusDoenca.SelectedValue), Convert.ToInt32(ViewState["codDoenca"])))
                        throw new Exception("Erro de Atualização da Doença");
                }
                else
                {
                    if (!cv.atualizaDoenca(codArvore, null, Convert.ToInt32(ddlGrupoParasitas.SelectedValue),
                        Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescDoenca.Text.Trim(),
                        dtDoenca, Convert.ToInt32(ddlStatusDoenca.SelectedValue), Convert.ToInt32(ViewState["codDoenca"])))
                        throw new Exception("Erro de Atualização da Doença");
                }
                LabelConfirmaDoenca.Text = "Doença atualizada com sucesso!";
            }

            //Verifica se o Status da doença está ativa (=1) e se o status da arvore é saudável (=1) (se a arvore está saudável ela não tem doença)
            if (ddlStatusDoenca.SelectedValue == "1" && statusArvore == 1)
                //atualiza o status da arvore para doente (=2)
                cv.atualizaStatusArvore(2, codArvore);
            //Verifica se o Status da doença está Recuperada (=2)
            if (ddlStatusDoenca.SelectedValue == "2")
                // Atualiza Status da árvore (saudavel / injuriada
                atualizaStatusArvore(codArvore);

            ImageConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelErroDoenca.Visible = false;
            LabelConfirmaDoenca.Visible = true;
            GridViewDoencasArvore.DataSource = cv.buscaDoencasByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
            GridViewDoencasArvore.DataBind();
        }
        catch (Exception err)
        {
            LabelConfirmaDoenca.Visible = false;
            LabelErroDoenca.Text = err.Message;
            ImageConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelErroDoenca.Visible = true;
        }
        LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();
        PanelConfirmaDoenca.Visible = true;
    }
    /// <summary>
    /// Cancela o cadastro / atualização de uma doença
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarDoenca_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codDoenca");
        LimpaDadosDoenca();
        LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();
    }
    /// <summary>
    /// Volta para a tela de Doenças de uma Determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarDoencasArvore_Click(object sender, EventArgs e)
    {
        LabelCodigoArvore.Text = ViewState["codIdentArvore"].ToString();
        ViewState.Remove("codDoenca");
        LimpaDadosDoenca();
        PanelCadastrarDoenca.Visible = false;
        PanelDoencasArvore.Visible = true;
    }
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
        LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();
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

    public void populaCamposCadDoenca()
    {
        //Popula campos
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
        LabelCodArvore.Text = ViewState["codIdentArvore"].ToString();
    }
    /// <summary>
    /// Lima campos da tela cadastra / atualiza doença
    /// </summary>
    protected void LimpaDadosDoenca()
    {
        rbTipoParasitas.SelectedIndex = -1;
        ddlParasitas.SelectedIndex = 0;
        ddlGrupoParasitas.SelectedIndex = 0;
        ddlLocalAfetado.SelectedIndex = 0;
        ddlIntensidade.SelectedIndex = 0;
        ddlStatusDoenca.SelectedIndex = 0;
        txtDescDoenca.Text = String.Empty;
        txtDataDoenca.Text = String.Empty;
        LabelConfirmaDoenca.Visible = false;
        LabelErroDoenca.Visible = false;
        PanelGrupoParasitas.Visible = false;
        PanelParasitas.Visible = false;
        PanelConfirmaDoenca.Visible = false;
    }
    #endregion


}

