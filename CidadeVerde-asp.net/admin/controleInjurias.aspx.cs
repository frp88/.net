using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class admin_controleInjurias : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["sorteio"] = "DESC";
            GridViewInjurias.DataSource = cv.buscaInjurias();
            GridViewInjurias.DataBind();
            HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasInjurias.aspx";
        }
    }
    #endregion

    #region PANEL LISTA Injúrias
    /// <summary>
    /// Filtrar as Injúrias por uma determinada situaçao
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbSituacaoInjuria_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoInjuria.Text = String.Empty;
        FiltraInjurias();
    }
    /// <summary>
    /// Botao filtrar as arvores do sistema
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFiltrar_Click(object sender, EventArgs e)
    {
        rbSituacaoInjuria.SelectedIndex = -1;
        FiltraInjurias();
    }
    /// <summary>
    /// Escolhe a quantidade de Árvores que será mostrada na tela
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMostrarInjurias_SelectedIndexChanged(object sender, EventArgs e)
    {
        FiltraInjurias();
    }
    /// <summary>
    /// Popula o gridViewInjurias
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewInjurias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 1: // Doença Presente
                        e.Row.Cells[2].ToolTip = "Doença ainda Presente";
                        e.Row.Cells[2].Text = "<img src='../images/bolaLaranja.png' /> ";
                        break;
                    case 2: // Doença Recuperada
                        e.Row.Cells[2].ToolTip = "Doença Recuperada";
                        e.Row.Cells[2].Text = "<img src='../images/bolaVerde.png' />";
                        break;
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[1].Visible = false; // nStatus Injúria
            e.Row.Cells[9].Visible = false; // codArvore
        }
    }
    /// <summary>
    /// Visualiza as Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewInjurias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewInjurias.Rows[indice];

            //// Obtem ID da Conta
            Int32 codInjuria = Convert.ToInt32(linha.Cells[0].Text.Trim());
            Int32 statusInjuria = Convert.ToInt32(linha.Cells[1].Text.Trim());
            ViewState["codInjuria"] = codInjuria.ToString();
            ViewState["statusInjuria"] = statusInjuria.ToString();
            ViewState["codArvore"] = linha.Cells[9].Text.Trim();
            ViewState["statusArvore"] = linha.Cells[4].Text.Trim();
            ViewState["codIdentArvore"] = linha.Cells[5].Text.Trim();
            if (e.CommandName.Equals("editarInjuria"))
            {
                if (statusInjuria == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "cadInjuria", "javascript: alert('Não é possivel cadastrar uma nova ação! Árvore Morta.');", true);
                    ImageDialog.ImageUrl = "../images/erro32.png";
                    LabelDialog.Text = "Não é possível Editar a Injúria!<br /><br />Injúria Recuperada.";
                    //mensagem Java Script
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                }
                else
                {
                    //Popula campos
                    populaCamposCadInjuria();

                    //Seleciona Valores já cadastrados
                    DataSetCidadeVerde.tblInjuriasDataTable dtInjuria = cv.buscaInjuriaByCodInjuria(codInjuria);

                    ddlCodigoIdentArvore.SelectedValue = dtInjuria[0].codArvore.ToString();

                    ddlLocalAfetado.SelectedValue = dtInjuria[0].codLocalAfetado.ToString();
                    ddlIntensidade.SelectedValue = dtInjuria[0].codIntensidade.ToString();
                    txtDescInjuria.Text = dtInjuria[0].descInjuria;
                    txtDataConclusao.Text = (dtInjuria[0].IsdtInjuriaNull() ? String.Empty : dtInjuria[0].dtInjuria.ToShortDateString());
                    ddlStatusInjuria.SelectedValue = dtInjuria[0].statusInjuria.ToString();
                    LabelTituloCadInjuria.Text = "Editar Injúria";
                    //Mostra o panel
                    PanelListaInjurias.Visible = false;
                    PanelConfirmaInjuria.Visible = false;
                    PanelCadastrarInjuria.Visible = true;
                }
            }
        }
        catch (Exception)
        {
        }
    }
    /// <summary>
    /// Realiza a ordenaçao entre pelo clique as colunas
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewInjurias_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSetCidadeVerde.tblInjuriasDataTable resultado = cv.buscaInjurias();
        DataRow[] temp = null;
        if (ViewState["sorteio"] != null)
        {
            if (ViewState["sorteio"].ToString().Equals("ASC"))
                ViewState["sorteio"] = "DESC";
            else
                ViewState["sorteio"] = "ASC";
        }
        GridViewInjurias.PageSize = Convert.ToInt32(ddlMostrarInjurias.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoInjuria.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;

            switch (rbSituacaoInjuria.SelectedValue)
            {
                case "1":
                    temp = resultado.Select("statusInjuria = 1", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewInjurias.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelInjuriasPresentes.aspx";
                    break;
                case "2":
                    temp = resultado.Select("statusInjuria = 2", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewInjurias.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelInjuriasRecuperadas.aspx";
                    break;
                default:
                    temp = resultado.Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    GridViewInjurias.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasInjurias.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            Int32 codInjuria;
            if (Int32.TryParse(txtCodigoInjuria.Text.Trim(), out codInjuria))
            {
                GridViewInjurias.DataSource = temp = resultado.Select("codInjuria = " + codInjuria, e.SortExpression + " " + ViewState["sorteio"].ToString());
                GridViewInjurias.DataSource = temp.Length == 0 ? null : temp.CopyToDataTable();
            }
        }
        GridViewInjurias.DataBind();
    }
    /// <summary>
    /// Aterna entre paginas da lista de Injurias
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewInjurias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewInjurias.PageIndex = e.NewPageIndex;
        FiltraInjurias();
    }
    /// <summary>
    /// Muda de página no GridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewInjurias.PageIndex = e.NewPageIndex;
        FiltraInjurias();
    }
    /// <summary>
    /// Mostra a Tela de Cadastro de Açoes de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCadastrarInjuria_Click(object sender, EventArgs e)
    {
        LimpaViewState();
        populaCamposCadInjuria();
        LabelTituloCadInjuria.Text = "Cadastrar Injúria";
        PanelListaInjurias.Visible = false;
        PanelConfirmaInjuria.Visible = false;
        PanelCadastrarInjuria.Visible = true;

    }
    /// <summary>
    /// Filtra as árvores do GridViewArvores por uma determinada situação
    /// </summary>
    public void FiltraInjurias()
    {
        GridViewInjurias.PageSize = Convert.ToInt32(ddlMostrarInjurias.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoInjuria.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;
            switch (rbSituacaoInjuria.SelectedValue)
            {
                case "1":
                    GridViewInjurias.DataSource = cv.buscaInjuriaByStatusInjuria(1);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelInjuriasPresentes.aspx";
                    break;
                case "2":
                    GridViewInjurias.DataSource = cv.buscaInjuriaByStatusInjuria(2);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelInjuriasRecuperadas.aspx";
                    break;
                default:
                    GridViewInjurias.DataSource = cv.buscaInjurias();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasInjurias.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            Int32 codInjuria;
            if (Int32.TryParse(txtCodigoInjuria.Text.Trim(), out codInjuria))
                GridViewInjurias.DataSource = cv.buscaInjuriaByCodInjuria(codInjuria);
        }
        GridViewInjurias.DataBind();
    }
    #endregion

    #region CADASTRO / ATUALIZAÇÃO  DE InjúriaS
    /// <summary>
    /// Volta para a tela de Lista de Injúrias
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarListaInjurias_Click(object sender, EventArgs e)
    {
        LimpaViewState();
        LimpaDadosInjuria();
        PanelCadastrarInjuria.Visible = false;
        PanelConfirmaInjuria.Visible = false;
        PanelListaInjurias.Visible = true;
        FiltraInjurias();
    }
    /// <summary>
    /// Cadastra / atualiza uma  determinada Injúria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarInjuria_Click(object sender, EventArgs e)
    {
        LabelErroInjuria.Visible = false;
        LabelConfirmaInjuria.Visible = false;
        try
        {
            if (ddlCodigoIdentArvore.SelectedIndex == 0)
                throw new Exception("Selecione a Árvore.");
            if (ddlLocalAfetado.SelectedIndex == 0)
                throw new Exception("Selecione o Local Afetado.");
            if (ddlIntensidade.SelectedIndex == 0)
                throw new Exception("Selecione a Intensidade.");
            if (String.IsNullOrEmpty(txtDescInjuria.Text.Trim()))
                if (String.IsNullOrEmpty(txtDescInjuria.Text.Trim()))
                    throw new Exception("Digite a Descrição da Injúria.");
            if (ddlStatusInjuria.SelectedValue.Equals("2"))
                if (String.IsNullOrEmpty(txtDataConclusao.Text.Trim()))
                    throw new Exception("Digite a Data da Recuperação");
            DateTime dtAux;
            if (!String.IsNullOrEmpty(txtDataConclusao.Text.Trim()))
            {
                if (!DateTime.TryParse(txtDataConclusao.Text.Trim(), out dtAux))
                    throw new Exception("Data Inválida");
            }
            DateTime? dtInjuria = null;
            if (!String.IsNullOrEmpty(txtDataConclusao.Text))
                dtInjuria = Convert.ToDateTime(txtDataConclusao.Text.Trim());

            Int32 codArvore = Convert.ToInt32(ddlCodigoIdentArvore.SelectedValue);
            Int32 codInjuria;
            if (ViewState["codInjuria"] == null)
            {
                //Insere uma Injúria da Arvore
                codInjuria = cv.InsereInjuria(codArvore, Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue),
                    txtDescInjuria.Text.Trim(), dtInjuria, Convert.ToInt32(ddlStatusInjuria.SelectedValue));
                if (codInjuria == 0)
                    throw new Exception("Erro de Inserção de Injúria.");

                ViewState["codInjuria"] = codInjuria;
                LabelConfirmaInjuria.Text = "Injúria cadastrada com sucesso!";
            }
            else
            {
                //Atualiza uma Injúria da Arvore
                if (!cv.atualizaInjuria(codArvore, Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescInjuria.Text.Trim(),
                    dtInjuria, Convert.ToInt32(ddlStatusInjuria.SelectedValue), Convert.ToInt32(ViewState["codInjuria"].ToString())))
                    throw new Exception("Erro de Atualização da Injúria");
                LabelConfirmaInjuria.Text = "Injúria atualizada com sucesso!";
            }

            //Verifica se o Status da Injúria está ativa (=1) e se o status da arvore é saudável (=1) (se a arvore está saudável ela não tem Doença)
            Int32 statusArvore = cv.buscaArvoreByCodArvore(codArvore)[0].nStatus;
            if (ddlStatusInjuria.SelectedValue == "1" && statusArvore == 1)
                //atualiza o status da arvore para Injuria (=3)
                cv.atualizaStatusArvore(3, codArvore);
            //Verifica se o Status da Injúria está Concluida (=2)
            if (ddlStatusInjuria.SelectedValue == "2")
                // Atualiza Status da árvore (saudavel / injuriada
                atualizaStatusArvore(codArvore);

            if (ViewState["codArvore"] != null)
            {
                Int32 codArvoreAnterior = Convert.ToInt32(ViewState["codArvore"].ToString());
                //Atualiza Status de Árvore anterior (se alterou a arvore com a Injúria)
                if (codArvoreAnterior != codArvore)
                    // Atualiza Status da árvore (saudavel / doente)
                    atualizaStatusArvore(codArvoreAnterior);
            }
            ViewState["codArvore"] = codArvore.ToString();
            ImageConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaInjuria.Visible = true;
            //LimpaDadosInjuria();
        }
        catch (Exception err)
        {
            ImageConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelErroInjuria.Text = err.Message;
            LabelErroInjuria.Visible = true;
        }
        PanelConfirmaInjuria.Visible = true;
    }

    /// <summary>
    /// Cancela o cadastro / atualização de uma Injúria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarInjuria_Click(object sender, EventArgs e)
    {
        PanelConfirmaInjuria.Visible = false;
        LimpaDadosInjuria();
        ViewState.Remove("codInjuria");
        ViewState.Remove("statusInjuria");
        ViewState.Remove("codArvore");
        ViewState.Remove("statusArvore");
        ViewState.Remove("codIdentArvore");
    }
    /// <summary>
    /// Atualiza o Status da Arvore para saudavel ou Doente
    /// </summary>
    /// <param name="codArvore"></param>
    protected void atualizaStatusArvore(int codArvore)
    {
        if (cv.quantInjuriasArvore(codArvore) == 0)
        {
            //verifica se vai atualizar pra doente ou saudavel
            if (cv.quantInjuriasArvore(codArvore) == 0)
                //atualiza o status da arvore para saudável (=1)
                cv.atualizaStatusArvore(1, codArvore);
            else
                //atualiza o status da arvore para Doente (=2)
                cv.atualizaStatusArvore(2, codArvore);
        }
    }
    /// <summary>
    /// Lima campos da tela cadastra / atualiza Injúria
    /// </summary>
    protected void LimpaDadosInjuria()
    {
        ddlCodigoIdentArvore.SelectedIndex = 0;
        ddlIntensidade.SelectedIndex = 0;
        ddlLocalAfetado.SelectedIndex = 0;
        ddlStatusInjuria.SelectedIndex = 0;
        txtDescInjuria.Text = String.Empty;
        txtDataConclusao.Text = String.Empty;
    }
    protected void LimpaViewState()
    {
        ViewState.Remove("codInjuria");
        ViewState.Remove("statusInjuria");
        ViewState.Remove("codArvore");
        ViewState.Remove("statusArvore");
        ViewState.Remove("codIdentArvore");
    }
    public void populaCamposCadInjuria()
    {
        //Popula campos
        ddlCodigoIdentArvore.DataSource = cv.buscaArvoresVivas();
        ddlCodigoIdentArvore.DataBind();
        ddlCodigoIdentArvore.Items.Insert(0, "Selecione uma Árvore");
        ddlIntensidade.DataSource = cv.buscaIntensidade();
        ddlIntensidade.DataBind();
        ddlIntensidade.Items.Insert(0, "Selecione a Intensidade");
        ddlLocalAfetado.DataSource = cv.buscaLocalAfetado();
        ddlLocalAfetado.DataBind();
        ddlLocalAfetado.Items.Insert(0, "Selecione o Local Afetado");
    }
    #endregion
}
