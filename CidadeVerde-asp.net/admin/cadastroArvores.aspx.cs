using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using CEP;
using Subgurim.Controles;
//using Subgurim.Controles;

public partial class admin_cadastroArvores : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    private String PathServidor = @"~/fotos/arvores/";
    private String PathFotosTemp = String.Empty;

    #region LOAD DA PAGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        PathServidor = Server.MapPath("~/fotos/arvores");
        PathFotosTemp = Server.MapPath("~/fotos/arvores/temp");

        if (!IsPostBack)
        {
            ViewState["sorteio"] = "DESC";
            GridViewArvores.DataSource = cv.buscaArvores();
            GridViewArvores.DataBind();
            HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasArvores.aspx";
        }

        this.configuraGoogleMaps();
    }
    #endregion

    #region VER ARVORES
    /// <summary>
    /// Filtra as Árvores pela situaçao da Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbSituacaoArvore_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoIdentArvore.Text = String.Empty;
        FiltraArvores();
    }
    /// <summary>
    /// Filtra as Árvores pelo codigo da Árvore
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
    /// Popula o Grid de Árvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Image status = (Image)e.Row.Cells[2].FindControl("ImageStatusArvore");
                switch (Convert.ToInt32(e.Row.Cells[2].Text.Trim()))
                {
                    case 2: // Doente
                        //status.ToolTip = "Árvore Doente";
                        e.Row.Cells[2].ToolTip = "Árvore Doente";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreDoente.png' /> ";
                        //e.Row.Cells[2].Text = "<img src='../images/arvoreAzul.png' /> ";
                        break;
                    case 3: // Ferida
                        //status.ToolTip = "Árvore Ferida";
                        //status.ImageUrl = "~/images/arvoreFerida.png";
                        e.Row.Cells[2].ToolTip = "Árvore Ferida";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreFerida.png' />";
                        //e.Row.Cells[2].Text = "<img src='../images/arvoreVermelho.png' />";
                        break;
                    case 4: // Morta
                        //status.ToolTip = "Árvore Morta";
                        //status.ImageUrl = "~/images/arvoreMorta.png";

                        e.Row.Cells[2].ToolTip = "Árvore Morta";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreMorta.png' />";
                        //e.Row.Cells[2].Text = "<img src='../images/arvorePreta.png' />";
                        break;
                    default: //Caso 1 - Saudável
                        //status.ToolTip = "Árvore Saudável";
                        //status.ImageUrl = "~/images/arvoreSaudavel.png";
                        e.Row.Cells[2].ToolTip = "Árvore Saudável";
                        e.Row.Cells[2].Text = "<img src='../images/arvoreSaudavel.png' />";
                        break;
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[11].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Árvore?');");
            }
            e.Row.Cells[0].Visible = false; // codArvore
            e.Row.Cells[1].Visible = false; // nStatus arvore
            //e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false; // codEspecie
        }
    }
    /// <summary>
    /// Mudar de pagina na lista de arvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewArvores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewArvores.PageIndex = e.NewPageIndex;
        GridViewArvores.DataSource = cv.buscaArvores();
        GridViewArvores.DataBind();
    }
    /// <summary>
    /// Abre a tela de Edição dos Dados de uma determinada Árvore
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
            Int32 statusArvore = Convert.ToInt32(linha.Cells[1].Text.Trim());
            if (e.CommandName.Equals("verArvore"))
            {
                ViewState["codArvore"] = codArvore;
                ViewState["codIdentArvore"] = linha.Cells[4].Text.Trim();
                //Verifica se a Arvore nao está morta
                //if (statusArvore == 3)
                //{
                //ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('Não é possível editar a Árvore! Árvore Morta.');", true);
                //ImageDialog.ImageUrl = "../images/erro32.png";
                //LabelDialog.Text = "Não é possível editar a Árvore!<br /> Árvore Morta";
                //mensagem Java Script
                //ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);

                // }
                //else
                //{
                //Popula campos
                populaCamposCadArvore();
                populaDadosArvore(codArvore);
                populaEnderecoArvore(codArvore);
                populaCoordenadasArvore(codArvore);
                populaEntornoArvore(codArvore);
                populaInterferenciasArvore(codArvore);
                LabelCadArvore.Text = "Detalhes da Árvore - Código da Árvore: " + ViewState["codIdentArvore"].ToString();
                ////Mostra o panel

                panelVerArvore.Visible = false;
                PanelAdminArvore.Visible = true;
                iniciaImagem();
                //Monta as abas
                if (statusArvore == 4)
                    apenasVerDetArvores(true);
                else
                    apenasVerDetArvores(false);
                ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs();", true);
                //}
            }
            if (e.CommandName.Equals("excluirArvore"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Árvore!");
                    ViewState.Remove("codArvore");
                    ViewState.Remove("codIdentArvore");
                    if (!cv.deletaArvore(codArvore))
                        throw new Exception("Não é possível excluir a Árvore! <br />Existe registros na tabela Doenças, <br /> Injúrias e/ou Ações.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Árvore excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewArvores.DataSource = cv.buscaArvores();
                    GridViewArvores.DataBind();
                }
                catch (Exception ex)
                {
                    LabelDialog.Text = ex.Message;
                    ImageDialog.ImageUrl = "../images/erro32.png";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                }
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
            HyperLinkImprimir.Visible = true;
            switch (rbSituacaoArvore.SelectedValue)
            {
                case "1":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 1", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresSaudaveis.aspx";
                    break;
                case "2":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 2", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresDoentes.aspx";
                    break;
                case "3":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 3", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresInjuriadas.aspx";
                    break;
                case "4":
                    GridViewArvores.DataSource = resultado.Select("nStatus = 4", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresMortas.aspx";
                    break;
                default:
                    GridViewArvores.DataSource = resultado.Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasArvores.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            GridViewArvores.DataSource = resultado.Select("sCodIdentificacao like " + txtCodigoIdentArvore.Text.Trim(), e.SortExpression + " " + ViewState["sorteio"].ToString());
        }
        GridViewArvores.DataBind();
    }
    /// <summary>
    /// Filtra as árvores do GridViewArvores por uma determinada situação
    /// </summary>
    public void FiltraArvores()
    {
        GridViewArvores.PageSize = Convert.ToInt32(ddlMostrarArvore.SelectedValue);
        if (String.IsNullOrEmpty(txtCodigoIdentArvore.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;
            switch (rbSituacaoArvore.SelectedValue)
            {
                case "1":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(1);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresSaudaveis.aspx";
                    break;
                case "2":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(2);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresDoentes.aspx";
                    break;
                case "3":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(3);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresInjuriadas.aspx";
                    break;
                case "4":
                    GridViewArvores.DataSource = cv.buscaArvoreBynStatus(4);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelArvoresMortas.aspx";
                    break;
                default:
                    GridViewArvores.DataSource = cv.buscaArvores();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasArvores.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            GridViewArvores.DataSource = cv.buscaArvoreByCodIdentificacao(txtCodigoIdentArvore.Text.Trim());
        }
        GridViewArvores.DataBind();
    }

    /// <summary>
    /// Ocultar o panel VerArvores e mostrar o panel CadastrarArvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadastrarArvore_Click(object sender, EventArgs e)
    {
        apenasVerDetArvores(false);
        populaCamposCadArvore();
        LabelCadArvore.Text = "Cadastro de Árvores";
        panelVerArvore.Visible = false;
        PanelAdminArvore.Visible = true;
        ViewState.Remove("codArvore");
        ViewState.Remove("codIdentArvore");
        iniciaImagem();
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs();", true);//abaDadosArvore
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaCoordenadasArvore');", true);
        //btCoordenadasCancelar_Click(null, null);
    }
    #endregion

    #region ADMINISTRAR ÁRVORES
    /// <summary>
    /// Ocultar o panel CadastrarArvore e mostrar o panel VerArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    protected void btVoltarTelaVerArvore_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codArvore");
        ViewState.Remove("codIdentArvore");
        ViewState.Remove("latitude");
        ViewState.Remove("longitude");

        LimpaCamposDadosArvore();
        LimpaCamposEndereco();
        LimpaCamposCoordenadas();
        LimpaCamposEntorno();
        limpaCamposInterferencias();

        ocultaPaineisConfirmacao();

        FiltraArvores();
        PanelAdminArvore.Visible = false;
        panelVerArvore.Visible = true;
    }

    #region DADOS ARVORE
    /// <summary>
    /// Cancela Cadastro / Atualização dos Dados da Árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btDadosArvoreCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        if (ViewState["codArvore"] != null)
            populaDadosArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosArvore');", true);
    }
    protected void ddlStatusArvore_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosArvore');", true);
    }
    /// <summary>
    /// Avançar para a Aba LocalArvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btDadosArvoreSalvar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        LabelDadosArvoreOk.Visible = false;
        LabelDadosArvoreErro.Visible = false;
        try
        {
            Decimal decim;
            DateTime dtLevantamento, dtPlantio;
            if (ddlTipoEspecie.SelectedIndex == 0)
                throw new Exception("Selecione uma Espécie!");
            if (String.IsNullOrEmpty(txtDiametroCopa.Text.Trim()))
                throw new Exception("Digite o Diâmetro da Copa!");
            if (!String.IsNullOrEmpty(txtDiametroCopa.Text.Trim()))
                if (!Decimal.TryParse(txtDiametroCopa.Text.Trim(), out decim))
                    throw new Exception("Diâmetro Inválido!");
            if (String.IsNullOrEmpty(txtAltura.Text.Trim()))
                throw new Exception("Digite a Altura!");
            if (!String.IsNullOrEmpty(txtAltura.Text.Trim()))
                if (!Decimal.TryParse(txtAltura.Text.Trim(), out decim))
                    throw new Exception("Altura Inválida!");
            if (String.IsNullOrEmpty(txtPersistenciaFolhas.Text.Trim()))
                throw new Exception("Digite a Persistência das Folhas!");

            if (String.IsNullOrEmpty(txtDataPlantio.Text.Trim()))
                throw new Exception("Digite a Data de Plantio!");
            if (!String.IsNullOrEmpty(txtDataPlantio.Text.Trim()))
                if (!DateTime.TryParse(txtDataLevantamento.Text.Trim(), out dtPlantio))
                    throw new Exception("Data de Plantio Inválida!");
            if (String.IsNullOrEmpty(txtDataLevantamento.Text.Trim()))
                throw new Exception("Digite a Data de Levantamento!");
            if (!String.IsNullOrEmpty(txtDataLevantamento.Text.Trim()))
                if (!DateTime.TryParse(txtDataLevantamento.Text.Trim(), out dtLevantamento))
                    throw new Exception("Data de Levantamento Inválida!");


            if (ViewState["codArvore"] == null)
            {
                Int32 codArvore = 0;
                String codIndentArvore = null;
                //Insersão dos Dados da Arvore
                codArvore = cv.InsereArvore(Convert.ToInt32(ddlTipoEspecie.SelectedValue), Convert.ToDateTime(txtDataLevantamento.Text.Trim()),
                  Convert.ToDouble(txtAltura.Text.Trim()), Convert.ToDouble(txtDiametroCopa.Text.Trim()), Convert.ToInt32(ddlStatusArvore.SelectedValue),
                   Convert.ToDateTime(txtDataPlantio.Text.Trim()), txtPersistenciaFolhas.Text.Trim());
                if (codArvore == 0)
                    throw new Exception("Erro de Inserção dos Dados da Árvore!");
                codIndentArvore = cv.InsereCodIndentArvore(codArvore);
                if (String.IsNullOrEmpty(codIndentArvore))
                    throw new Exception("Erro de Inserção dos Dados da Árvore!");

                ViewState["codArvore"] = codArvore;
                ViewState["codIdentArvore"] = codIndentArvore;

                //Dados Cadastrados com Sucesso!
                LabelDadosArvoreOk.Text = "Árvore Cadastrada com Sucesso! <br />Código de identificação: <font color='#000000'>" + codIndentArvore;
                LabelCadArvore.Text = "Cadastro da Árvore - Código da Árvore: " + codIndentArvore;
            }
            else
            {
                //Atualização dos Dados da Arvore
                if (!cv.atualizaArvore(Convert.ToInt32(ddlTipoEspecie.SelectedValue), Convert.ToDateTime(txtDataLevantamento.Text.Trim()), Convert.ToDouble(txtAltura.Text.Trim()),
                    Convert.ToDouble(txtDiametroCopa.Text.Trim()), Convert.ToInt32(ddlStatusArvore.SelectedValue), Convert.ToDateTime(txtDataPlantio.Text.Trim()),
                     txtPersistenciaFolhas.Text.Trim(), Convert.ToInt32(ViewState["codArvore"].ToString())))
                    throw new Exception("Erro de Atualização dos Dados da Árvore!");
                LabelDadosArvoreOk.Text = "Árvore Atualizada com Sucesso!";
            }
            ImageConfirmaDadosArvore.ImageUrl = "~/images/confirmation32.png";
            LabelDadosArvoreOk.Visible = true;
        }
        catch (Exception err)
        {
            LabelDadosArvoreErro.Text = err.Message;
            ImageConfirmaDadosArvore.ImageUrl = "~/images/exclamation32.png";
            LabelDadosArvoreErro.Visible = true;
        }
        PanelConfirmaDadosArvore.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosArvore');", true);
    }
    /// <summary>
    /// Botão Cancela cadastro / atualização do local da árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarLocalArvore_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Tabs", "javascript: $('#tabs').tabs().tabs('select', '#abaDadosArvore');", true);
    }
    protected void ddlTipoEspecie_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosArvore');", true);
    }
    #endregion

    #region ENDEREÇO
    /// <summary>
    /// Localiza um determinado Endereço pelo CEP
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btLocalizarCEP_Click(object sender, EventArgs e)
    {
        try
        {
            if (String.IsNullOrEmpty(txtCEP.Text.Trim()))
                throw new Exception("Digite um CEP!");
            Int64 nCEP;
            if (!String.IsNullOrEmpty(txtCEP.Text.Trim()) && !Int64.TryParse(txtCEP.Text.Trim(), out nCEP))
                throw new Exception("CEP Inválido!");
            if (txtCEP.Text.Trim().Length != 8)
                throw new Exception("CEP Inválido!");

            DataSetCidadeVerde.tblCEPDataTable dtCEP = cv.buscaCEPBysCEP(txtCEP.Text.Trim());
            if (dtCEP != null)
            {
                LabelErroCEP.Visible = false;
                txtBairro.Text = dtCEP[0].sBairro;
                txtCidade.Text = dtCEP[0].sCidade;
                txtLogradouro.Text = dtCEP[0].sLogradouro;
                ddlEstado.SelectedValue = dtCEP[0].sEstado.ToString();
                ddlTipoLogradouro.SelectedValue = dtCEP[0].codTipoLogradouro.ToString();
            }
            else
            {
                throw new Exception("CEP não Encontrado!");

                ////WEB SERVER CEP

                //wscep webCEP = new wscep();
                //DataSet dtWebCEP = webCEP.cep(txtCEP.Text.Trim());
                //if (dtWebCEP.Tables[0].Rows.Count == 0)
                //    throw new Exception("CEP não Encontrado!");

                //LabelErroCEP.Visible = false;
                //txtBairro.Text = dtWebCEP.Tables[0].Rows[0]["bairro"].ToString();
                //txtCidade.Text = dtWebCEP.Tables[0].Rows[0]["cidade"].ToString();
                //txtLogradouro.Text = dtWebCEP.Tables[0].Rows[0]["nome"].ToString();
                //ddlEstado.SelectedValue = dtWebCEP.Tables[0].Rows[0]["UF"].ToString();
                //ddlTipoLogradouro.SelectedItem.Text = dtWebCEP.Tables[0].Rows[0]["logradouro"].ToString();
            }
        }
        catch (Exception err)
        {
            LabelErroCEP.Text = err.Message;
            LabelErroCEP.Visible = true;
            txtCEP.Focus();
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaEnderecoArvore');", true);
    }

    /// <summary>
    /// Voltar para a Aba DadosArvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btEnderecoCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        if (ViewState["codArvore"] != null)
            populaEnderecoArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaEnderecoArvore');", true);
    }
    /// <summary>
    /// Avançar para Aba EntornoArvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btEnderecoSalvar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        LabelEnderecoAvoreErro.Visible = false;
        LabelEnderecoAvoreOk.Visible = false;
        try
        {
            //Verifica se a árvore já está cadastrada
            if (ViewState["codArvore"] == null)
                throw new Exception("Cadastre primeiro os Dados da Árvore.");
            if (String.IsNullOrEmpty(txtCEP.Text.Trim()))
                throw new Exception("Digite um CEP!");
            Int64 nCEP;
            if (!String.IsNullOrEmpty(txtCEP.Text.Trim()) && !Int64.TryParse(txtCEP.Text.Trim(), out nCEP))
                throw new Exception("CEP Inválido!");
            if (txtCEP.Text.Trim().Length != 8)
                throw new Exception("CEP Inválido!");

            if (ddlTipoLogradouro.SelectedIndex == 0)
                throw new Exception("Selecione um Tipo de Logradouro!");
            if (String.IsNullOrEmpty(txtLogradouro.Text.Trim()))
                throw new Exception("Digite o Logradouro!");
            if (String.IsNullOrEmpty(txtBairro.Text.Trim()))
                throw new Exception("Digite o Bairro!");
            if (String.IsNullOrEmpty(txtCidade.Text.Trim()))
                throw new Exception("Digite a Cidade!");
            if (ddlEstado.SelectedIndex == 0)
                throw new Exception("Selecione um Estado!");
            Int32 numero = -1;
            if (!String.IsNullOrEmpty(txtNumero.Text.Trim()))
                if (!Int32.TryParse(txtNumero.Text.Trim(), out numero))
                    throw new Exception("Número Inválido!");

            //INSERSÃO / ATUALIZAÇÃO
            DataSetCidadeVerde.tblLocalizacaoDataTable dtLocalizacao = cv.buscaLocalizacaoByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
            if (dtLocalizacao == null)
            {
                //Insersão da Localização da Arvore
                if (!cv.InsereLocalizacao(Convert.ToInt32(ViewState["codArvore"].ToString()), txtCEP.Text.Trim(), txtLogradouro.Text.Trim(),
                    txtBairro.Text.Trim(), txtComplemento.Text.Trim(), numero, txtCidade.Text.Trim(),
                    ddlEstado.SelectedValue, Convert.ToInt32(ddlTipoLogradouro.SelectedValue)))
                    throw new Exception("Erro de Inserção do Endereço da Árvore!");
                LabelEnderecoAvoreOk.Text = "Endereço Inserido com Sucesso!";
            }
            else
            {
                //Atualização dos Dados da Arvore
                if (!cv.atualizaLocalizacao(txtCEP.Text.Trim(), txtLogradouro.Text.Trim(),
                   txtBairro.Text.Trim(), txtComplemento.Text.Trim(), numero, txtCidade.Text.Trim(),
                   ddlEstado.SelectedValue, Convert.ToInt32(ddlTipoLogradouro.SelectedValue), Convert.ToInt32(ViewState["codArvore"].ToString())))
                    throw new Exception("Erro de Atualização do Endereço da Árvore!");
                LabelEnderecoAvoreOk.Text = "Endereço Atualizado com Sucesso!";
            }
            ImageConfirmaEnderecoArvore.ImageUrl = "~/images/confirmation32.png";
            LabelEnderecoAvoreOk.Visible = true;
        }
        catch (Exception err)
        {
            LabelEnderecoAvoreErro.Text = err.Message;
            LabelEnderecoAvoreErro.Visible = true;
            ImageConfirmaEnderecoArvore.ImageUrl = "~/images/exclamation32.png";
        }
        PanelConfirmaEnderecoArvore.Visible = true;
        //Monta as Abas
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaEnderecoArvore');", true);
    }
    #endregion

    #region LOCALIZAÇÃO GEOGRÁFICA
    protected void btCoordenadasSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            ocultaPaineisConfirmacao();
            LabelCoordenasErro.Visible = false;
            LabelCoordenadasOk.Visible = false;
            //Verifica se a árvore já está cadastrada
            if (ViewState["codArvore"] == null)
                throw new Exception("Cadastre primeiro os Dados da Árvore.");
            Int32 codArvore = Convert.ToInt32(ViewState["codArvore"].ToString());

            Double lati;
            Double longi;
            if (String.IsNullOrEmpty(txtLatitude.Text.Trim()))
                throw new Exception("Digite a latitude!");
            else if (!Double.TryParse(txtLatitude.Text.Trim(), out lati))
                throw new Exception("Latitude Inválida!");

            if (String.IsNullOrEmpty(txtLongitude.Text.Trim()))
                throw new Exception("Digite a longitude!");
            else if (!Double.TryParse(txtLongitude.Text.Trim(), out longi))
                throw new Exception("Longitude Inválida!");

            DataSetCidadeVerde.tblCoordenadasDataTable dtCoor = new DataSetCidadeVerde.tblCoordenadasDataTable();
            dtCoor = cv.buscaCoordenadasByCodArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
            Boolean insereCoor = true;
            if (dtCoor != null)
            {
                insereCoor = false;
                if (!cv.deletaCoordenadas(Convert.ToInt32(ViewState["codArvore"].ToString())))
                    throw new Exception("Erro de Exclusão das Coordenadas da Árvore!");
            }
            if (!String.IsNullOrEmpty(txtLatitude.Text.Trim()) && !String.IsNullOrEmpty(txtLongitude.Text.Trim()))
            {
                if (!cv.InsereCoordenadas(Convert.ToInt32(ViewState["codArvore"].ToString()), txtLatitude.Text.Trim(), txtLongitude.Text.Trim()))
                    throw new Exception("Erro de Atualização das Coordenadas da Árvore!");
            }
            LabelCoordenadasOk.Text = insereCoor ? "Localização Geográfica Inserida com Sucesso!" : "Localização Geográfica Atualizada com Sucesso!";

            ImageConfirmaCoordenadas.ImageUrl = "~/images/confirmation32.png";
            LabelCoordenadasOk.Visible = true;
        }
        catch (Exception err)
        {
            LabelCoordenasErro.Text = err.Message;
            LabelCoordenasErro.Visible = true;
            ImageConfirmaCoordenadas.ImageUrl = "~/images/exclamation32.png";
        }
        PanelConfirmaCoordenadas.Visible = true;
        //Monta as Abas
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaCoordenadasArvore');", true);
    }
    protected void btCoordenadasCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        if (ViewState["codArvore"] != null)
            populaCoordenadasArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
        //Monta as Abas
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaCoordenadasArvore');", true);
    }
    #endregion

    #region ENTORNO
    /// <summary>
    /// Cancela cadastro / atualização da árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btEntornoCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        if (ViewState["codArvore"] != null)
            populaEntornoArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
        //Monta as Abas
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaEntornoArvore');", true);
    }
    /// <summary>
    /// Botao Inserir ou Atualizar Dados das Arvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btEntornoSalvar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        LabelEntornoArvoreErro.Visible = false;
        LabelEntornoArvoreOk.Visible = false;
        try
        {
            //Verifica se a árvore já está cadastrada
            if (ViewState["codArvore"] == null)
                throw new Exception("Cadastre primeiro os Dados da Árvore.");
            Int32 codArvore = Convert.ToInt32(ViewState["codArvore"].ToString());

            Double LarguraPasseio, larguraRua;
            if (ddlLocalArvore.SelectedIndex == 0)
                throw new Exception("Selecione o Local da Árvore!");
            if (ddlPavimento.SelectedIndex == 0)
                throw new Exception("Selecione o Pavimento!");
            if (ddlParticipacao.SelectedIndex == 0)
                throw new Exception("Selecione a Participação!");
            if (String.IsNullOrEmpty(txtLarguraPasseio.Text.Trim()))
                throw new Exception("Digite a Largura do Passeio!");
            if (!String.IsNullOrEmpty(txtLarguraPasseio.Text.Trim()))
                if (!Double.TryParse(txtLarguraPasseio.Text.Trim(), out LarguraPasseio))
                    throw new Exception("Largura do Passeio Inválido!");
            if (String.IsNullOrEmpty(txtLarguraRua.Text.Trim()))
                throw new Exception("Digite a Largura da Rua!");
            if (!String.IsNullOrEmpty(txtLarguraRua.Text.Trim()))
                if (!Double.TryParse(txtLarguraRua.Text.Trim(), out larguraRua))
                    throw new Exception("Largura da Rua Inválida!");

            //INSERSÃO / ATUALIZAÇÃO
            DataSetCidadeVerde.tblEntornoDataTable dtEntorno = cv.buscaEntornoByCodArvore(codArvore);
            if (dtEntorno == null)
            {
                //Insersão do Entorno da Arvore
                if (!cv.InsereEntorno(codArvore, Convert.ToInt32(ddlLocalArvore.SelectedValue),
                    Convert.ToInt32(ddlPavimento.SelectedValue), Convert.ToInt32(ddlParticipacao.SelectedValue),
                    Convert.ToDouble(txtLarguraRua.Text.Trim()), Convert.ToDouble(txtLarguraPasseio.Text.Trim())))
                    throw new Exception("Erro de Inserção do Entorno da Árvore!");
                LabelEntornoArvoreOk.Text = "Entorno Inserido com Sucesso!";
            }
            else
            {
                //Atualização do Entorno da Arvore
                if (!cv.atualizaEntorno(Convert.ToInt32(ddlPavimento.SelectedValue), Convert.ToInt32(ddlParticipacao.SelectedValue),
                      Convert.ToDouble(txtLarguraRua.Text.Trim()), Convert.ToDouble(txtLarguraPasseio.Text.Trim()),
                      Convert.ToInt32(ddlLocalArvore.SelectedValue), codArvore))
                    throw new Exception("Erro de Atualização do Entorno da Árvore!");
                LabelEntornoArvoreOk.Text = "Entorno Atualizado com Sucesso!";
            }
            // LimpaCamposDadosArvore();
            // LimpaCamposLocalizacao();
            // LimpaCamposEntorno();
            //Confirmação de Cadastro / Atualização executado com sucesso!
            ImageConfirmaEntorno.ImageUrl = "~/images/confirmation32.png";
            LabelEntornoArvoreOk.Visible = true;
        }
        catch (Exception err)
        {
            ImageConfirmaEntorno.ImageUrl = "~/images/exclamation32.png";
            LabelEntornoArvoreErro.Text = err.Message;
            LabelEntornoArvoreErro.Visible = true;
        }
        PanelConfirmaEntornoArvore.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaEntornoArvore');", true);
    }
    #endregion

    #region INTERFERÊNCIAS
    /// <summary>
    /// Cadastrar / Editar uma Interferencia de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btInterferenciasSalvar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        LabelInterferenciaErro.Visible = false;
        LabelInterferenciaOk.Visible = false;
        try
        {
            //Verifica se a árvore já está cadastrada
            if (ViewState["codArvore"] == null)
                throw new Exception("Cadastre primeiro os Dados da Árvore.");
            Int32 codArvore = Convert.ToInt32(ViewState["codArvore"].ToString());

            if (ddlIluminacao.SelectedIndex == 0)
                throw new Exception("Selecione a Iluminação!");
            if (ddlMuroEdificacao.SelectedIndex == 0)
                throw new Exception("Selecione o Muro Edificação!");
            if (ddlPosteamento.SelectedIndex == 0)
                throw new Exception("Selecione o Posteamento!");
            if (ddlRaizPavimento.SelectedIndex == 0)
                throw new Exception("Selecione o Tipo de Raiz no Pavimento!");
            if (ddlSinalizacao.SelectedIndex == 0)
                throw new Exception("Selecione a Sinalização!");
            if (ddlSituacaoFiacao.SelectedIndex == 0)
                throw new Exception("Selecione a Situação da Fiação!");
            if (ddlTipoFiacao.SelectedIndex == 0)
                throw new Exception("Selecione o Tipo de Fiação!");
            if (ddlTrafego.SelectedIndex == 0)
                throw new Exception("Selecione o Tráfego!");

            //INSERSÃO / ATUALIZAÇÃO
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = cv.buscaInterferenciaByCodArvore(codArvore);
            if (dtInterferencia == null)
            {
                //Insersão das Interferencias da Arvore
                if (!cv.InsereInterferencia(codArvore, Convert.ToInt32(ddlTrafego.SelectedValue), Convert.ToInt32(ddlRaizPavimento.SelectedValue),
                    Convert.ToInt32(ddlSituacaoFiacao.SelectedValue), Convert.ToInt32(ddlPosteamento.SelectedValue), Convert.ToInt32(ddlIluminacao.SelectedValue),
                    Convert.ToInt32(ddlSinalizacao.SelectedValue), Convert.ToInt32(ddlMuroEdificacao.SelectedValue), Convert.ToInt32(ddlTipoFiacao.SelectedValue)))
                    throw new Exception("Erro de Inserção das Interferências da Árvore!");
                LabelInterferenciaOk.Text = "Interferências Cadastradas com Sucesso!";
            }
            else
            {
                //Atualização do Entorno da Arvore
                if (!cv.atualizaInterferencia(Convert.ToInt32(ddlTrafego.SelectedValue), Convert.ToInt32(ddlRaizPavimento.SelectedValue),
                    Convert.ToInt32(ddlSituacaoFiacao.SelectedValue), Convert.ToInt32(ddlPosteamento.SelectedValue),
                    Convert.ToInt32(ddlIluminacao.SelectedValue), Convert.ToInt32(ddlSinalizacao.SelectedValue),
                    Convert.ToInt32(ddlMuroEdificacao.SelectedValue), Convert.ToInt32(ddlTipoFiacao.SelectedValue), codArvore))
                    throw new Exception("Erro de Atualização das Interferências da Árvore!");
                LabelInterferenciaOk.Text = "Interferências Atualizadas com Sucesso!";
            }
            //Confirmação de Cadastro / Atualização executado com sucesso!
            ImageInterferenciaConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelInterferenciaOk.Visible = true;
        }
        catch (Exception err)
        {
            ImageInterferenciaConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelInterferenciaErro.Text = err.Message;
            LabelInterferenciaErro.Visible = true;
        }
        PanelConfirmaInterferencias.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaInterferenciasArvore');", true);
    }
    /// <summary>
    /// Cancelar Cadastro / Edição uma Interferencia de uma determinada árvore
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btInterferenciasCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        if (ViewState["codArvore"] != null)
            populaInterferenciasArvore(Convert.ToInt32(ViewState["codArvore"].ToString()));
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaInterferenciasArvore');", true);
    }
    #endregion

    #region IMAGEM
    protected void btAlterarFoto_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        if (ViewState["codIdentArvore"] == null)
        {
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = "Não é possível alterar a Imagem!<br /> Cadastre primeiro os Dados da Árvore.";
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
        else
            PanelUpload.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaImagemArvore');", true);
    }
    protected void btCancelarUpload_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        LabelErroUploadFoto.Visible = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaImagemArvore');", true);
    }
    /// <summary>
    /// ENVIAR A FOTO PARA O SERVIDOR E SALVAR O CAMINHO DA FOTO
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btEnviarUpload_Click(object sender, EventArgs e)
    {
        try
        {
            LabelErroUploadFoto.Visible = false;
            //verifica se existe o arquivo
            if (!FileUploadFoto.HasFile)
                throw new Exception("Nenhum arquivo foi selecionado.");

            //verifica a extensao do arquivo
            List<string> extensoes = new List<string>();
            extensoes.Add(".png");
            extensoes.Add(".jpg");
            extensoes.Add(".jpeg");
            extensoes.Add(".bmp");
            extensoes.Add(".gif");
            if (!extensoes.Contains(Path.GetExtension(FileUploadFoto.PostedFile.FileName)))
                throw new Exception("O arquivo não é uma imagem válida.");

            //verifica o tamanho do arquivo
            if (FileUploadFoto.PostedFile.ContentLength / 1024 > 4000)
                throw new Exception("O tamanho do arquivo é maior do que o máximo permitido.");

            //pega o nome do arquivo para salvar na pasta Temp
            String nomeArquivoTemp = DateTime.Now.Ticks.ToString();

            String caminhotemp = Path.Combine(PathFotosTemp, nomeArquivoTemp + Path.GetExtension(FileUploadFoto.PostedFile.FileName));

            //salva o arquivo na pasta Temp
            FileUploadFoto.SaveAs(caminhotemp);

            //redimensiona o arquivo e salva no caminho definitivo
            string caminhoFinal = Path.Combine(PathServidor, ViewState["codIdentArvore"].ToString() + ".jpg");

            if (!Resize(caminhotemp, caminhoFinal, 200, 150)) // 250, 303
                throw new Exception("Erro ao redimensionar arquivo.");

            //verifica se o arquivo foi salvo no destino final
            FileInfo Fi_servidor = new FileInfo(caminhoFinal);
            if (!Fi_servidor.Exists) //Se não salvou no diretorio.
                throw new Exception("Ocorreu um erro ao fazer o upload. tente novamente. " + caminhoFinal);

            //Salva o Caminho da Foto no Banco
            if (!cv.atualizaImagem(ViewState["codIdentArvore"].ToString(), Convert.ToInt32(ViewState["codArvore"].ToString())))
                throw new Exception("Erro ao salvar o caminho da imagem no Banco.");

            PanelUpload.Visible = false;
            iniciaImagem();
        }
        catch (Exception erro)
        {
            LabelErroUploadFoto.Text = erro.Message;
            LabelErroUploadFoto.Visible = true;
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaImagemArvore');", true);
    }
    /// <summary>
    /// Redimensiona imagem
    /// scrPath = path da imagem original
    /// destPath = path para a nova imagem
    /// caso o destPath seja igual ao srcPath, a nova imagem substitui a anterior
    /// </summary>
    public static Boolean Resize(string srcPath, string destPath, int nWidth, int nHeight)
    {
        try
        {
            //String temp;

            // Abre arquivo original
            System.Drawing.Image img = System.Drawing.Image.FromFile(srcPath);
            int oWidth = img.Width;   // largura original
            int oHeight = img.Height; // altura original

            // Cria a copia da imagem
            System.Drawing.Image imgThumb = img.GetThumbnailImage(nWidth, nHeight, null, new System.IntPtr(0));

            imgThumb.Save(destPath, ImageFormat.Jpeg); // salva nova imagem no destino
            imgThumb.Dispose(); // libera memoria
            img.Dispose(); // libera memória
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Busca a Imagem da Árvore
    /// </summary>
    protected void iniciaImagem()
    {
        PathServidor = Server.MapPath("~/fotos/arvores");
        PathFotosTemp = Server.MapPath("~/fotos/arvores/temp");

        //Tira o ajax do botao upload de arquivo
        //ScriptManager scriptmanager = ScriptManager.GetCurrent();
        //scriptmanager.RegisterPostBackControl(ImageButtonEnviarUpload);
        //scriptmanager.RegisterPostBackControl(ImageButtonAlterarFoto);


        // Exibe Foto de Perfil
        String strArqFoto = String.Empty;
        if (ViewState["codIdentArvore"] != null)
            strArqFoto = Path.Combine(PathServidor, ViewState["codIdentArvore"].ToString() + ".jpg");
        else
            strArqFoto = Path.Combine(PathServidor, "");

        // Verifica se arquivo é válido e existe
        FileInfo fi = new FileInfo(strArqFoto);

        if (fi.Exists) //&& strArqFoto.Trim().Length > 0)
            ImageArvore.ImageUrl = "~/fotos/arvores/" + ViewState["codIdentArvore"].ToString() + ".jpg";
        else
            ImageArvore.ImageUrl = "~/fotos/arvores/semFotoArvore.png";
        PanelUpload.Visible = false;
    }
    #endregion

    #region POPULA E LIMPA CAMPOS DADOS, LOCALIZAÇÃO, ENTORNO E INTEREFÊNCIAS ARVORE
    /// <summary>
    /// Editar / Visualizar informações de uma determinada Árvore
    /// </summary>
    /// <param name="apenasVer"></param>
    public void apenasVerDetArvores(Boolean apenasVer)
    {
        //Dados da Árvore
        ddlTipoEspecie.Enabled = !apenasVer;
        txtDiametroCopa.ReadOnly = apenasVer;
        txtDataPlantio.ReadOnly = apenasVer;
        txtDataLevantamento.ReadOnly = apenasVer;
        txtAltura.ReadOnly = apenasVer;
        ddlStatusArvore.Enabled = !apenasVer;
        btDadosArvoreSalvar.Visible = !apenasVer;
        btDadosArvoreCancelar.Visible = !apenasVer;
        //Localização da Árvore
        txtCEP.ReadOnly = apenasVer;
        ddlTipoLogradouro.Enabled = !apenasVer;
        txtLogradouro.ReadOnly = apenasVer;
        txtBairro.ReadOnly = apenasVer;
        txtCidade.ReadOnly = apenasVer;
        ddlEstado.Enabled = !apenasVer;
        txtComplemento.ReadOnly = apenasVer;
        txtNumero.ReadOnly = apenasVer;
        btLocalizarCEP.Visible = !apenasVer;
        btEnderecoSalvar.Visible = !apenasVer;
        btEnderecoCancelar.Visible = !apenasVer;
        //Localização Geográfica
        txtLatitude.ReadOnly = apenasVer;
        txtLongitude.ReadOnly = apenasVer;
        btLocalizarCEP.Visible = !apenasVer;
        btCoordenadasSalvar.Visible = !apenasVer;
        btCoordenadasCancelar.Visible = !apenasVer;
        //Entorno da Árvore
        ddlLocalArvore.Enabled = !apenasVer;
        ddlPavimento.Enabled = !apenasVer;
        ddlParticipacao.Enabled = !apenasVer;
        txtLarguraPasseio.ReadOnly = apenasVer;
        txtLarguraRua.ReadOnly = apenasVer;
        btEntornoSalvar.Visible = !apenasVer;
        btEntornoCancelar.Visible = !apenasVer;
        //Interferências da Árvore
        ddlIluminacao.Enabled = !apenasVer;
        ddlMuroEdificacao.Enabled = !apenasVer;
        ddlPosteamento.Enabled = !apenasVer;
        ddlRaizPavimento.Enabled = !apenasVer;
        ddlSinalizacao.Enabled = !apenasVer;
        ddlSituacaoFiacao.Enabled = !apenasVer;
        ddlTipoFiacao.Enabled = !apenasVer;
        ddlTrafego.Enabled = !apenasVer;
        //Imagem da Árvore
        btAlterarFoto.Visible = !apenasVer;
    }
    /// <summary>
    /// Limpa campos aba Dados da Árvore
    /// </summary>
    public void LimpaCamposDadosArvore()
    {
        ddlTipoEspecie.SelectedIndex = 0;
        txtAltura.Text = String.Empty;
        txtPersistenciaFolhas.Text = String.Empty;
        txtDiametroCopa.Text = String.Empty;
        txtDataPlantio.Text = String.Empty;
        txtDataLevantamento.Text = String.Empty;
        ddlStatusArvore.SelectedIndex = 0;
        PanelConfirmaDadosArvore.Visible = false;
    }
    /// <summary>
    /// Limpa campos aba Localização
    /// </summary>
    public void LimpaCamposEndereco()
    {
        txtCEP.Text = String.Empty;
        ddlTipoLogradouro.SelectedIndex = 0;
        txtLogradouro.Text = String.Empty;
        txtBairro.Text = String.Empty;
        txtCidade.Text = String.Empty;
        ddlEstado.SelectedIndex = 0;
        txtComplemento.Text = String.Empty;
        txtNumero.Text = String.Empty;
        LabelErroCEP.Visible = false;
    }
    /// <summary>
    /// Limpa campos aba Localização
    /// </summary>
    public void LimpaCamposCoordenadas()
    {
        txtLatitude.Text = String.Empty;
        txtLongitude.Text = String.Empty;
    }
    /// <summary>
    /// Limpa campos aba Entorno
    /// </summary>
    protected void LimpaCamposEntorno()
    {
        ddlLocalArvore.SelectedIndex = 0;
        ddlPavimento.SelectedIndex = 0;
        ddlParticipacao.SelectedIndex = 0;
        txtLarguraRua.Text = String.Empty;
        txtLarguraPasseio.Text = String.Empty;
    }
    /// <summary>
    /// Limpa campos aba Interferência
    /// </summary>
    protected void limpaCamposInterferencias()
    {
        ddlIluminacao.SelectedIndex = 0;
        ddlMuroEdificacao.SelectedIndex = 0;
        ddlPosteamento.SelectedIndex = 0;
        ddlRaizPavimento.SelectedIndex = 0;
        ddlSinalizacao.SelectedIndex = 0;
        ddlSituacaoFiacao.SelectedIndex = 0;
        ddlTipoFiacao.SelectedIndex = 0;
        ddlTrafego.SelectedIndex = 0;
    }
    /// <summary>
    /// Oculta Paineis de confirmação
    /// </summary>
    protected void ocultaPaineisConfirmacao()
    {
        PanelConfirmaDadosArvore.Visible = false;
        PanelConfirmaEnderecoArvore.Visible = false;
        PanelConfirmaCoordenadas.Visible = false;
        PanelConfirmaEntornoArvore.Visible = false;
        PanelConfirmaInterferencias.Visible = false;
        PanelUpload.Visible = false;
    }
    /// <summary>
    /// Popula Campos Dados da Árvore
    /// </summary>
    /// <param name="codArvore"></param>
    protected void populaDadosArvore(Int32 codArvore)
    {
        DataSetCidadeVerde.tblArvoreDataTable dtArvore = cv.buscaArvoreByCodArvore(codArvore);
        ddlTipoEspecie.SelectedValue = dtArvore[0].codEspecie.ToString();
        txtDiametroCopa.Text = dtArvore[0].nDiametroCopa.ToString();
        txtDataPlantio.Text = dtArvore[0].dtPlantio.ToShortDateString();
        txtDataLevantamento.Text = dtArvore[0].dtLevantamento.ToShortDateString();
        txtPersistenciaFolhas.Text = dtArvore[0].sPersistenciaFolhas;
        txtAltura.Text = dtArvore[0].nAltura.ToString();
        ddlStatusArvore.SelectedValue = dtArvore[0].nStatus.ToString();
    }
    /// <summary>
    ///  Popula Endereço da Árvore
    /// </summary>
    /// <param name="codArvore"></param>
    protected void populaEnderecoArvore(Int32 codArvore)
    {
        DataSetCidadeVerde.tblLocalizacaoDataTable dtLocalizacao = cv.buscaLocalizacaoByCodArvore(codArvore);
        if (dtLocalizacao != null)
        {
            txtCEP.Text = dtLocalizacao[0].sCEP;
            ddlTipoLogradouro.SelectedValue = dtLocalizacao[0].codTipoLogradouro.ToString();
            txtLogradouro.Text = dtLocalizacao[0].sLogradouro;
            txtBairro.Text = dtLocalizacao[0].sBairro;
            txtCidade.Text = dtLocalizacao[0].sCidade;
            ddlEstado.SelectedValue = dtLocalizacao[0].sEstado;
            txtComplemento.Text = (dtLocalizacao[0].IssComplementoNull() ? String.Empty : dtLocalizacao[0].sComplemento);
            txtNumero.Text = (dtLocalizacao[0].IsnNumeroNull() || dtLocalizacao[0].nNumero == 0 ? String.Empty : dtLocalizacao[0].nNumero.ToString());
        }
    }
    /// <summary>
    /// Popula Coordenadas da Árvore
    /// </summary>
    /// <param name="codArvore"></param>
    protected void populaCoordenadasArvore(Int32 codArvore)
    {
        DataSetCidadeVerde.tblCoordenadasDataTable dtCoordenadas = cv.buscaCoordenadasByCodArvore(codArvore);
        if (dtCoordenadas != null)
        {
            ViewState["latitude"] = dtCoordenadas[0].ItemArray.GetValue(2).ToString();
            ViewState["longitude"] = dtCoordenadas[0].ItemArray.GetValue(3).ToString();
            txtLatitude.Text = ViewState["latitude"].ToString();
            txtLongitude.Text = ViewState["longitude"].ToString();
        }
    }
    /// <summary>
    /// Popula Entorno da Árvore
    /// </summary>
    /// <param name="codArvore"></param>
    protected void populaEntornoArvore(Int32 codArvore)
    {
        DataSetCidadeVerde.tblEntornoDataTable dtEntorno = cv.buscaEntornoByCodArvore(codArvore);
        if (dtEntorno != null)
        {
            ddlLocalArvore.SelectedValue = dtEntorno[0].codLocalEntorno.ToString();
            ddlPavimento.SelectedValue = dtEntorno[0].codPavimento.ToString();
            ddlParticipacao.SelectedValue = dtEntorno[0].codParticipacao.ToString();
            txtLarguraPasseio.Text = dtEntorno[0].nLarguraPasseio.ToString();
            txtLarguraRua.Text = dtEntorno[0].nLarguraRua.ToString();
        }
    }
    /// <summary>
    /// Popula Interferências da Árvore
    /// </summary>
    /// <param name="codArvore"></param>
    protected void populaInterferenciasArvore(Int32 codArvore)
    {
        DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencias = cv.buscaInterferenciaByCodArvore(codArvore);
        if (dtInterferencias != null)
        {
            ddlIluminacao.SelectedValue = dtInterferencias[0].codIluminacao.ToString();
            ddlMuroEdificacao.SelectedValue = dtInterferencias[0].codMuroEdificacao.ToString();
            ddlPosteamento.SelectedValue = dtInterferencias[0].codRaizPavimento.ToString();
            ddlRaizPavimento.SelectedValue = dtInterferencias[0].codRaizPavimento.ToString();
            ddlSinalizacao.SelectedValue = dtInterferencias[0].codSinalizacao.ToString();
            ddlSituacaoFiacao.SelectedValue = dtInterferencias[0].codSituacaoFiacao.ToString();
            ddlTipoFiacao.SelectedValue = dtInterferencias[0].codTipoFiacao.ToString();
            ddlTrafego.SelectedValue = dtInterferencias[0].codTrafego.ToString();
        }
    }
    /// <summary>
    /// Popula Campos Para Cadastro / Atualização
    /// </summary>
    public void populaCamposCadArvore()
    {
        ddlTipoEspecie.DataSource = cv.buscaEspecies();
        ddlTipoEspecie.DataBind();
        ddlTipoEspecie.Items.Insert(0, "Selecione uma Espécie");

        ddlTipoLogradouro.DataSource = cv.buscaTipoLogradouro();
        ddlTipoLogradouro.DataBind();
        ddlTipoLogradouro.Items.Insert(0, "Selecione um Tipo de Logradouro");

        ddlLocalArvore.DataSource = cv.buscaLocalEntorno();
        ddlLocalArvore.DataBind();
        ddlLocalArvore.Items.Insert(0, "Selecione o Local da Árvore");

        ddlPavimento.DataSource = cv.buscaPavimento();
        ddlPavimento.DataBind();
        ddlPavimento.Items.Insert(0, "Selecione o Pavimento");

        ddlParticipacao.DataSource = cv.buscaParticipacao();
        ddlParticipacao.DataBind();
        ddlParticipacao.Items.Insert(0, "Selecione a Participação");

        ddlIluminacao.DataSource = cv.buscaIluminacao();
        ddlIluminacao.DataBind();
        ddlIluminacao.Items.Insert(0, "Selecione a Iluminação");

        ddlMuroEdificacao.DataSource = cv.buscaMuroEdificacao();
        ddlMuroEdificacao.DataBind();
        ddlMuroEdificacao.Items.Insert(0, "Selecione o Muro Edificação");

        ddlPosteamento.DataSource = cv.buscaPosteamentos();
        ddlPosteamento.DataBind();
        ddlPosteamento.Items.Insert(0, "Selecione o Posteamento");

        ddlSinalizacao.DataSource = cv.buscaSinalizacao();
        ddlSinalizacao.DataBind();
        ddlSinalizacao.Items.Insert(0, "Selecione a Sinalização");

        ddlSituacaoFiacao.DataSource = cv.buscaSituacaoFiacao();
        ddlSituacaoFiacao.DataBind();
        ddlSituacaoFiacao.Items.Insert(0, "Selecione a Situação da Fiação");

        ddlTipoFiacao.DataSource = cv.buscaTipoFiacao();
        ddlTipoFiacao.DataBind();
        ddlTipoFiacao.Items.Insert(0, "Selecione o Tipo de Fiação");

        ddlRaizPavimento.DataSource = cv.buscaRaizPavimento();
        ddlRaizPavimento.DataBind();
        ddlRaizPavimento.Items.Insert(0, "Selecione a Raiz no Pavimento");

        ddlTrafego.DataSource = cv.buscaTrafego();
        ddlTrafego.DataBind();
        ddlTrafego.Items.Insert(0, "Selecione o Tráfego");
    }
    #endregion
    #endregion

    #region GOOGLE MAPS

    /// <summary>
    /// Configura o Google Maps
    /// </summary>
    protected void configuraGoogleMaps()
    {
        //Latitude e Longitude da rua 3 de maio (Bloco 9)
        double latitude = -20.718065825161304; //-20.7213728750453
        double longitude = -46.61069869995117; //-46.6091952400208
        ////Define a posição do inicio do google maps
        //mapa.Latitude = latitude;
        //mapa.Longitude = longitude;

        ////mapa.EnableContinuousZoom = true;
        //mapa.EnableDragging = true;
        ////Zoom do Google Maps
        //mapa.Zoom = 14;
        //Tamanho da área do google maps
       
        mapa.Key = "AIzaSyC9D8SWWpI1csCBdiDAe3xfdOS3oh2bcNw";

        mapa.Width = 550;
        mapa.Height = 400;

        // Habilitando o zoom no mapa
        mapa.enableHookMouseWheelToZoom = true;

        // Definir o tipo do mapa
        // Satellite, Hybrid, Physical, Normal
        mapa.mapType = GMapType.GTypes.Normal;

        // Define a Latitude e Logitude inicial do Mapa
        // Como moro em Brasília, coloquei o Congresso Nacional
        GLatLng latitudeLongitude = new GLatLng(latitude, longitude);

        // Definimos onde será o ponto inicial do nosso mapa
        // e o numero é o ZOOM inicial
        mapa.setCenter(latitudeLongitude, 15);

        // Ver imagem para entender quais sao os controles adicionados
        GControl mapType = new GControl(GControl.preBuilt.MapTypeControl);
        GControl overview = new GControl(GControl.preBuilt.GOverviewMapControl);
        //GControl small = new GControl(GControl.preBuilt.SmallMapControl);
        GControl largeZoom = new GControl(GControl.preBuilt.LargeMapControl);
        // GControl contr = new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl);

        mapa.addControl(mapType); // Ver imagem
        mapa.addControl(overview); // Ver imagem
        //  mapa.addControl(small); // Ver imagem
        mapa.addControl(largeZoom); // Ver imagem
        //mapa.addControl(contr);
    }

    #endregion
}
