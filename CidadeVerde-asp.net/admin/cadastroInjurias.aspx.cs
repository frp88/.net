using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_cadastroInjurias : AcessoRestrito
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
    protected void GridViewInjuriasArvore_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewInjuriasArvore.Rows[indice];

            //// Obtem ID da Conta
            Int32 codInjuria = Convert.ToInt32(linha.Cells[0].Text.Trim());
            ViewState["codInjuria"] = codInjuria;
            Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
            //Verifica se a Arvore nao está morta
            if (statusArvore == 4)
                throw new Exception("Não é possível  editar a Injúria!<br /> Árvore Morta.");
            if (e.CommandName.Equals("editarInjuria"))
            {
                //Popula campos
                ddlIntensidade.DataSource = cv.buscaIntensidade();
                ddlIntensidade.DataBind();
                ddlIntensidade.Items.Insert(0, "Selecione a Intensidade");
                ddlLocalAfetado.DataSource = cv.buscaLocalAfetado();
                ddlLocalAfetado.DataBind();
                ddlLocalAfetado.Items.Insert(0, "Selecione o Local Afetado");
                LabelCodArvore.Text = ViewState["codIndentArvore"].ToString();
                //Seleciona Valores já cadastrados
                DataSetCidadeVerde.tblInjuriasDataTable dtInjuria = cv.buscaInjuriaByCodInjuria(codInjuria);
                ddlLocalAfetado.SelectedValue = dtInjuria[0].codLocalAfetado.ToString();
                ddlIntensidade.SelectedValue = dtInjuria[0].codIntensidade.ToString();
                txtDescInjuria.Text = dtInjuria[0].descInjuria;
                txtDataInjuria.Text = (dtInjuria[0].IsdtInjuriaNull() ? String.Empty : dtInjuria[0].dtInjuria.ToShortDateString());//dtInjuria[0].dtCadInjuria.ToShortDateString();
                ddlStatusInjuria.SelectedValue = dtInjuria[0].statusInjuria.ToString();

                //Mostra o panel
                PanelInjuriasArvore.Visible = false;
                PanelCadastrarInjuria.Visible = true;
            }
            if (e.CommandName.Equals("excluirInjuria"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Injúria!");
                    if (!cv.deletaInjuria(codInjuria))
                        throw new Exception("Não é possível excluir a Injúria!");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Injúria excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewInjuriasArvore.DataSource = cv.buscaInjuriasByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
                    GridViewInjuriasArvore.DataBind();
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
            //   ScriptManager.RegisterStartupScript(this, GetType(), "cadInjuria", "javascript: alert('Não é possível editar a Injúria! Árvore Morta.');", true);
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = ex.Message;
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
    }
    /// <summary>
    /// Visualiza as Injurias de uma determinada Árvore
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
            ViewState["codIndentArvore"] = linha.Cells[4].Text.Trim();
            ViewState["statusArvore"] = linha.Cells[1].Text.Trim();
            if (e.CommandName.Equals("verInjurias"))
            {
                GridViewInjuriasArvore.DataSource = cv.buscaInjuriasByCodArvore(codArvore);
                GridViewInjuriasArvore.DataBind();
                LabelCodigoArvore.Text = ViewState["codIndentArvore"].ToString();
                PanelVerArvore.Visible = false;
                PanelInjuriasArvore.Visible = true;
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

    #region PANEL GRID INJÚRIAS
    /// <summary>
    /// Popula as Injurias de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewInjuriasArvore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image status = (Image)e.Row.Cells[2].FindControl("ImageStatusArvore");
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 1: // Ainda Ferida
                        status.ToolTip = "Injúria Presente";
                        status.ImageUrl = "~/images/bolaLaranja.png";
                        break;
                    case 2: // Curada
                        status.ToolTip = "Injúria Curada";
                        status.ImageUrl = "~/images/bolaVerde.png";
                        break;
                }

                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[10].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Injúria?');");
            }
            e.Row.Cells[0].Visible = false; // codDoenca
            e.Row.Cells[1].Visible = false; // nStatus Injuria
        }
    }
    /// <summary>
    /// Volta para a tela de Árvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarTelaVerInjuria_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codArvore");
        ViewState.Remove("codIndentArvore");
        ViewState.Remove("statusArvore");
        FiltraArvores();
        PanelInjuriasArvore.Visible = false;
        PanelVerArvore.Visible = true;
    }
    /// <summary>
    /// Mostra a Tela de Cadastro de Injurias de uma determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadastrarInjuria_Click(object sender, EventArgs e)
    {
        Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
        //Verifica se a Arvore nao está morta
        if (statusArvore == 4)
        {
            //   ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('Não é possível cadastrar uma nova Injúria! Árvore Morta.');", true);
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = "Não é possível cadastrar uma nova Injúria!<br /> Árvore Morta.";
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
        else
        {
            //Popula Campos Cad Injuria
            ddlIntensidade.DataSource = cv.buscaIntensidade();
            ddlIntensidade.DataBind();
            ddlIntensidade.Items.Insert(0, "Selecione a Intensidade");
            ddlLocalAfetado.DataSource = cv.buscaLocalAfetado();
            ddlLocalAfetado.DataBind();
            ddlLocalAfetado.Items.Insert(0, "Selecione o Local Afetado");
            LabelCodArvore.Text = ViewState["codIndentArvore"].ToString();

            PanelInjuriasArvore.Visible = false;
            PanelCadastrarInjuria.Visible = true;
        }
    }
    #endregion

    #region CADASTRO / ATUALIZAÇÃO INJÚRIAS
    /// <summary>
    /// Cadastra / atualiza uma injurias de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarInjuria_Click(object sender, EventArgs e)
    {
        LabelConfirmaInjuria.Visible = false;
        LabelErroInjuria.Visible = false;
        Int32 statusArvore = Convert.ToInt32(ViewState["statusArvore"].ToString());
        Int32 codArvore = Convert.ToInt32(ViewState["codArvore"].ToString());
        try
        {
            if (ddlLocalAfetado.SelectedIndex == 0)
                throw new Exception("Selecione o Local Afetado.");
            if (ddlIntensidade.SelectedIndex == 0)
                throw new Exception("Selecione a Intensidade.");
            if (String.IsNullOrEmpty(txtDescInjuria.Text.Trim()))
                throw new Exception("Digite a Descrição.");

            if (ddlStatusInjuria.SelectedValue.Equals("2"))
                if (String.IsNullOrEmpty(txtDataInjuria.Text.Trim()))
                    throw new Exception("Digite a Data da Recuperação");
            DateTime dtAux;
            if (!String.IsNullOrEmpty(txtDataInjuria.Text.Trim()))
                if (!DateTime.TryParse(txtDataInjuria.Text.Trim(), out dtAux))
                    throw new Exception("Data Inválida");

            DateTime? dtInjuria = null;
            if (!String.IsNullOrEmpty(txtDataInjuria.Text.Trim()))
                dtInjuria = Convert.ToDateTime(txtDataInjuria.Text.Trim());

            Int32 codInjuria;
            if (ViewState["codInjuria"] == null)
            {
                codInjuria = Convert.ToInt32(cv.InsereInjuria(Convert.ToInt32(ViewState["codArvore"].ToString()), Convert.ToInt32(ddlLocalAfetado.SelectedValue),
                    Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescInjuria.Text.Trim(), dtInjuria, Convert.ToInt32(ddlStatusInjuria.SelectedValue)));
                if (codInjuria == 0)
                    throw new Exception("Erro de Cadastro de Injúria!");
                LabelConfirmaInjuria.Text = "Injúria cadastrada com sucesso!";
                ViewState["codInjuria"] = codInjuria.ToString();
            }
            else
            {
                if (!cv.atualizaInjuria(Convert.ToInt32(ViewState["codArvore"].ToString()), Convert.ToInt32(ddlLocalAfetado.SelectedValue), Convert.ToInt32(ddlIntensidade.SelectedValue), txtDescInjuria.Text.Trim(),
                     dtInjuria, Convert.ToInt32(ddlStatusInjuria.SelectedValue), Convert.ToInt32(ViewState["codInjuria"])))
                    throw new Exception("Erro de Atualização de Injúria!");
                LabelConfirmaInjuria.Text = "Injúria atualizada com sucesso!";
            }

            //Verifica se o Status da Injuria está ativa (=1) e se o status da arvore é saudável (=1) (se a arvore está saudável ela não tem Injuria)
            if (ddlStatusInjuria.SelectedValue == "1" && statusArvore == 1)
                //atualiza o status da arvore para injuria (=2)
                cv.atualizaStatusArvore(3, codArvore);
            //Verifica se o Status da doença está Recuperada (=2)
            if (ddlStatusInjuria.SelectedValue == "2")
                // Atualiza Status da árvore (saudavel / Doente)
                atualizaStatusArvore(codArvore);

            ImageConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaInjuria.Visible = true;
        }
        catch (Exception err)
        {
            ImageConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelErroInjuria.Text = err.Message;
            LabelErroInjuria.Visible = true;
        }
        PanelConfirmaInjuria.Visible = true;
        LabelCodArvore.Text = ViewState["codIndentArvore"].ToString();
    }
    /// <summary>
    /// Cancela o cadastro / atualização de uma Injuria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarInjuria_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codInjuria");
        LabelCodArvore.Text = ViewState["codIndentArvore"].ToString();
        PanelConfirmaInjuria.Visible = false;
    }
    /// <summary>
    /// Volta para a tela de Doenças de uma Determinada Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarInjuriasArvore_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codInjuria");
        GridViewInjuriasArvore.DataSource = cv.buscaInjuriasByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
        GridViewInjuriasArvore.DataBind();
        LabelCodigoArvore.Text = ViewState["codIndentArvore"].ToString();
        LimpaDadosInjuria();
        PanelConfirmaInjuria.Visible = false;
        PanelCadastrarInjuria.Visible = false;
        PanelInjuriasArvore.Visible = true;
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
            if (cv.quantDoencasArvore(codArvore) == 0)
                //atualiza o status da arvore para saudável (=1)
                cv.atualizaStatusArvore(1, codArvore);
            else
                //atualiza o status da arvore para Doente (=2)
                cv.atualizaStatusArvore(2, codArvore);
        }
    }
    /// <summary>
    /// Lima campos da tela cadastra / atualiza Injuria
    /// </summary>
    protected void LimpaDadosInjuria()
    {
        ddlLocalAfetado.SelectedIndex = 0;
        ddlIntensidade.SelectedIndex = 0;
        ddlStatusInjuria.SelectedIndex = 0;
        txtDescInjuria.Text = String.Empty;
        txtDataInjuria.Text = String.Empty;
    }
    #endregion
}
