using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class admin_cadastroCEP : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridViewCEPs.DataSource = cv.buscaCEPs();
            GridViewCEPs.DataBind();
        }
    }
    #endregion

    #region PANEL GRID CEPs
    /// <summary>
    /// Mostra a Tela de Cadastro de CEPs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadCEP_Click(object sender, EventArgs e)
    {
        ddlTipoLogradouro.DataSource = cv.buscaTipoLogradouro();
        ddlTipoLogradouro.DataBind();
        ddlTipoLogradouro.Items.Insert(0, "Selecione o Tipo de Logradouro");
        //Verifica o CEP Logado tem perimssao para editar os dados
        //if (tipoCEP > 2)
        //  throw new Exception("Você não tem permissão para Edição de CEPs.");
        //Verifica se o CEP
        habilitaCamposCad(true);
        PanelVerCEPs.Visible = false;
        PanelCadCEP.Visible = true;
        ViewState.Remove("sCEP");
        LabelTitulo.Text = "Cadastrar CEP";
    }

    /// <summary>
    /// Botao filtrar os CEPs do sistema
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFiltrar_Click(object sender, EventArgs e)
    {
        populaGridCEP();
    }
    /// <summary>
    /// Popula o gridViewCEPs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewCEPs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[4].Text = e.Row.Cells[3].Text.Trim() + " " + e.Row.Cells[1].Text.Trim();
                Label labelLogradouro = (Label)e.Row.Cells[4].FindControl("labelLogradouro");
                labelLogradouro.Text = e.Row.Cells[3].Text.Trim() + " " + e.Row.Cells[1].Text.Trim();
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[9].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o CEP?');");
            }
            e.Row.Cells[1].Visible = false; // sLogradouro
            e.Row.Cells[2].Visible = false; // codTipoLogradouro
            e.Row.Cells[3].Visible = false; // descTipoLogradouro
        }
    }
    /// <summary>
    /// Visualiza os Dados de um determinado CEP
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewCEPs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewCEPs.Rows[indice];

            //// Obtem ID da Conta
            String sCEP = linha.Cells[0].Text.Trim();
            if (e.CommandName.Equals("editarCEP"))
            {
                ddlTipoLogradouro.DataSource = cv.buscaTipoLogradouro();
                ddlTipoLogradouro.DataBind();
                ddlTipoLogradouro.Items.Insert(0, "Selecione o Tipo de Logradouro");

                ViewState["sCEP"] = sCEP;
                habilitaCamposCad(false);
                LabelTitulo.Text = "Editar CEP";
                txtCEP.Text = linha.Cells[0].Text.Trim();
                ddlTipoLogradouro.SelectedValue = linha.Cells[2].Text.Trim();
                txtLogradouro.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
                txtBairro.Text = Server.HtmlDecode(linha.Cells[5].Text.Trim());
                txtCidade.Text = Server.HtmlDecode(linha.Cells[6].Text.Trim());
                ddlEstado.SelectedValue = linha.Cells[7].Text.Trim();
                PanelVerCEPs.Visible = false;
                PanelCadCEP.Visible = true;
            }
            if (e.CommandName.Equals("excluirCEP"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o CEP!");
                    if (!cv.deletaCEP(sCEP))
                        throw new Exception("Não é possível excluir o CEP!");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "CEP excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewCEPs.DataSource = cv.buscaCEPs();
                    GridViewCEPs.DataBind();
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
        catch (Exception)
        {
        }
    }
    /// <summary>
    /// Muda de página no GridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewCEPs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewCEPs.PageIndex = e.NewPageIndex;
    }
    #endregion
    #region PANEL CADASTRO / ATUALIZAÇÃO / EXCLUSÃO DE CEP
    /// <summary>
    /// Volta para a Tela do Grid de CEPs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarTelaVerArvore_Click(object sender, EventArgs e)
    {
        LimpaDadosCEP();
        populaGridCEP();
        PanelCadCEP.Visible = false;
        PanelVerCEPs.Visible = true;
        ViewState.Remove("sCEP");
    }

    /// <summary>
    /// Cadastra / atualiza um CEP
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarCEP_Click(object sender, EventArgs e)
    {
        LabelConfirmaCEP.Visible = false;
        LabelErroCEP.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtCEP.Text.Trim()))
                throw new Exception("Digite o CEP!");
            Int64 nCEP;
            if (!String.IsNullOrEmpty(txtCEP.Text.Trim()) && !Int64.TryParse(txtCEP.Text.Trim(), out nCEP))
                throw new Exception("CEP Inválido!");
            if (txtCEP.Text.Trim().Length != 8)
                throw new Exception("CEP Inválido!");
            if (ddlTipoLogradouro.SelectedIndex == 0)
                throw new Exception("Selecione o Tipo de Logradouro!");
            if (String.IsNullOrEmpty(txtLogradouro.Text.Trim()))
                throw new Exception("Digite o Logradouro!");
            if (String.IsNullOrEmpty(txtBairro.Text.Trim()))
                throw new Exception("Digite o Bairro!");
            if (String.IsNullOrEmpty(txtCidade.Text.Trim()))
                throw new Exception("Digite a Cidade!");
            if (ddlEstado.SelectedIndex == 0)
                throw new Exception("Selecione o Estado!");
            if (ViewState["sCEP"] == null)
            {
                if (!cv.InsereCEP(txtCEP.Text.Trim(), txtLogradouro.Text.Trim(), txtBairro.Text.Trim(), txtCidade.Text.Trim(),
                    ddlEstado.SelectedValue.ToString(), Convert.ToInt32(ddlTipoLogradouro.SelectedValue)))
                    throw new Exception("Erro no Cadastro do CEP!");
                ViewState["sCEP"] = txtCEP.Text.Trim();
                LabelConfirmaCEP.Text = "CEP cadastrado com sucesso!";
                //LimpaDadosCEP();
            }
            else
            {
                if (!cv.atualizaCEP(txtCEP.Text.Trim(), txtLogradouro.Text.Trim(), txtBairro.Text.Trim(), txtCidade.Text.Trim(),
                 ddlEstado.SelectedValue.ToString(), Convert.ToInt32(ddlTipoLogradouro.SelectedValue)))
                    throw new Exception("Erro de Atualização do CEP!");
                LabelConfirmaCEP.Text = "CEP atualizado com sucesso!";
            }
            ImageConfirmaCEP.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaCEP.Visible = true;
            //ViewState.Remove("codCEP");
        }
        catch (Exception err)
        {
            ImageConfirmaCEP.ImageUrl = "~/images/exclamation32.png";
            LabelErroCEP.Text = err.Message;
            LabelErroCEP.Visible = true;
        }
        PanelConfirmaCEP.Visible = true;
    }
    /// <summary>
    /// Cancela o cadastro / atualização de um CEP
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarCEP_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codCEP");
        LimpaDadosCEP();
        PanelConfirmaCEP.Visible = false;
    }

    protected void populaGridCEP()
    {
        if (String.IsNullOrEmpty(txtFiltro.Text.Trim()))
            GridViewCEPs.DataSource = cv.buscaCEPs();
        else
            GridViewCEPs.DataSource = cv.buscaCEPBysCEP(txtFiltro.Text.Trim());
        GridViewCEPs.DataBind();
    }
    /// <summary>
    /// Lima campos da tela cadastra / atualiza CEP
    /// </summary>
    protected void LimpaDadosCEP()
    {
        txtCEP.Text = String.Empty;
        txtLogradouro.Text = String.Empty;
        txtBairro.Text = String.Empty;
        txtCidade.Text = String.Empty;
        txtFiltro.Text = String.Empty;
        ddlTipoLogradouro.SelectedIndex = 0;
        ddlEstado.SelectedIndex = 0;
        PanelConfirmaCEP.Visible = false;
        ViewState.Remove("sCEP");
        habilitaCamposCad(true);
    }
    /// <summary>
    /// Habilita Labels, TextBox e Botoes para cadastro
    /// </summary>
    protected void habilitaCamposCad(Boolean habilita)
    {
        //if (habilita)
        //{
        //    LabelTitulo.Text = "Cadastrar CEP";
        //    LabelTituloLogin.Visible = false;
        //    LabelLogin.Visible = false;
        //    LabelCadLogin.Visible = true;
        //    txtLogin.Visible = true;
        //}
        //else
        //{
        //    LabelTitulo.Text = "Atualizar CEP";
        //    LabelTituloLogin.Visible = true;
        //    LabelLogin.Visible = true;
        //    LabelCadLogin.Visible = false;
        //    txtLogin.Visible = false;
        //}
    }
    #endregion

}
