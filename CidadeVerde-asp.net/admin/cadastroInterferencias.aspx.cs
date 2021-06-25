using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_cadastroInterferencias : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();

    #region ENUMERAÇÃO
    public enum Cadastrar
    {
        iluminacao = 1,
        muroEdificacao = 2,
        posteamento = 3,
        raizPavimento = 4,
        sinalizacao = 5,
        situacaoFiacao = 6,
        tipoFiacao = 7,
        trafego = 8
    }
    #endregion

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ocultaPaineis();
            panelInicio.Visible = true;
            //Monta as abas
            // $(function() {$("#accordion").accordion();});
            //ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript:  $(function() {$('#accordion').accordion();});", true);
            GridViewIluminacao.DataSource = cv.buscaIluminacao();
            GridViewIluminacao.DataBind();
            GridViewMuro.DataSource = cv.buscaMuroEdificacao();
            GridViewMuro.DataBind();
            GridViewPosteamento.DataSource = cv.buscaPosteamentos();
            GridViewPosteamento.DataBind();
            GridViewRaiz.DataSource = cv.buscaRaizPavimento();
            GridViewRaiz.DataBind();
            GridViewSinalizacao.DataSource = cv.buscaSinalizacao();
            GridViewSinalizacao.DataBind();
            GridViewSituacaoFiacao.DataSource = cv.buscaSituacaoFiacao();
            GridViewSituacaoFiacao.DataBind();
            GridViewTipoFiacao.DataSource = cv.buscaTipoFiacao();
            GridViewTipoFiacao.DataBind();
            GridViewTrafego.DataSource = cv.buscaTrafego();
            GridViewTrafego.DataBind();
        }
    }
    #endregion

    #region INICIO
    /// <summary>
    /// seleciona qual cadastro / atualização será executado
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlTipoInterferencias_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    panelInicio.Visible = false;
    //    switch ((Cadastrar)Enum.Parse(typeof(Cadastrar), ddlTipoInterferencias.SelectedValue))
    //    {
    //        case Cadastrar.iluminacao:
    //            //GridViewIluminacoes.DataSource = cv.buscaiFamilias();
    //            //GridViewFamilias.DataBind();
    //            //PanelFamiliaCad.Visible = true;
    //            break;
    //        case Cadastrar.muroEdificacao:
    //            //GridViewParasitas.DataSource = cv.buscaParasitas();
    //            //GridViewParasitas.DataBind();
    //            //PanelParasitasCad.Visible = true;
    //            break;
    //        case Cadastrar.posteamento:
    //            //GridViewGrupoParasitas.DataSource = cv.buscaGrupoParasitas();
    //            //GridViewGrupoParasitas.DataBind();
    //            //PanelGrupoParasitaCad.Visible = true;
    //            break;
    //        case Cadastrar.raizPavimento:
    //            //GridViewLocalAfetado.DataSource = cv.buscaLocalAfetado();
    //            //GridViewLocalAfetado.DataBind();
    //            //PanelLocalAfetadoCad.Visible = true;
    //            break;
    //        case Cadastrar.sinalizacao:
    //            //GridViewIntensidade.DataSource = cv.buscaIntensidade();
    //            //GridViewIntensidade.DataBind();
    //            //PanelIntensidadeCad.Visible = true;
    //            break;
    //        case Cadastrar.situacaoFiacao:
    //            //GridViewAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
    //            //GridViewAcaoRecomendada.DataBind();
    //            //PanelAcaoRecCad.Visible = true;
    //            break;
    //        case Cadastrar.tipoFiacao:
    //            //GridViewLocalEntorno.DataSource = cv.buscaLocalEntorno();
    //            //GridViewLocalEntorno.DataBind();
    //            //PanelLocalEntornoCad.Visible = true;
    //            break;
    //        case Cadastrar.trafego:
    //            //GridViewParticipacao.DataSource = cv.buscaParticipacao();
    //            //GridViewParticipacao.DataBind();
    //            //PanelParticipacaoCad.Visible = true;
    //            break;
    //        default:
    //            panelInicio.Visible = true;
    //            break;
    //    }
    //}
    /// <summary>
    /// Oculta todos paineis
    /// </summary>
    protected void ocultaPaineis()
    {
        panelInicio.Visible = false;
        PanelIluminacaoCad.Visible = false;
        //PanelGeneroCad.Visible = false;
        //PanelParasitasCad.Visible = false;
        //PanelGrupoParasitaCad.Visible = false;
        //PanelLocalAfetadoCad.Visible = false;
        //PanelIntensidadeCad.Visible = false;
        //PanelAcaoRecCad.Visible = false;
        //PanelLocalEntornoCad.Visible = false;
        //PanelParticipacaoCad.Visible = false;
        //PanelPavimentoCad.Visible = false;
        //PanelTipoLogradouroCad.Visible = false;
    }
    #endregion

    #region ILUMINAÇÃO
    /// <summary>
    /// Monta tabela Iluminacao
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewIluminacao_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Iluminação?');");
            }
            e.Row.Cells[0].Visible = false; // codIluminacao
        }
    }
    /// <summary>
    /// Edita Iluminacao
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewIluminacao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewIluminacao.Rows[indice];

            //// Obtem ID da Conta
            Int32 codIluminacao = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarIluminacao"))
            {
                ViewState["codIluminacao"] = codIluminacao.ToString();
                txtIluminacao.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirIluminacao"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Iluminação!");
                    if (!cv.deletaIluminacao(codIluminacao))
                        throw new Exception("Não é possível excluir a Iluminação!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Iluminação excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewIluminacao.DataSource = cv.buscaIluminacao();
                    GridViewIluminacao.DataBind();
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
        PanelIluminacaoConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIluminacao", "javascript: $('#divIluminacao')[0].style.display = 'block';", true);
    }
    protected void GridViewIluminacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewIluminacao.PageIndex = e.NewPageIndex;
        GridViewIluminacao.DataSource = cv.buscaIluminacao();
        GridViewIluminacao.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIluminacao", "javascript: $('#divIluminacao')[0].style.display = 'block';", true);
    }
    /// <summary>
    /// CADASTRA / EDITA UMA ILUMINAÇÃO
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btIluminacaoSalvar_Click(object sender, EventArgs e)
    {
        LabelIluminacaoOk.Visible = false;
        LabelIluminacaoErro.Visible = false;
        PanelIluminacaoConfirma.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtIluminacao.Text.Trim()))
                throw new Exception("Digite a Iluminação!");
            if (ViewState["codIluminacao"] == null)
            {
                //cadastra nova Iluminacao
                cv.InsereIluminacao(txtIluminacao.Text.Trim());
                LabelIluminacaoOk.Text = "Iluminação inserida com sucesso!";
            }
            else
            {
                //edita a Iluminacao
                cv.atualizaIluminacao(txtIluminacao.Text.Trim(), Convert.ToInt32(ViewState["codIluminacao"].ToString()));
                LabelIluminacaoOk.Text = "Iluminação atualizada com sucesso!";
            }
            ImageIluminacaoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelIluminacaoOk.Visible = true;
            ViewState.Remove("codIluminacao");
            txtIluminacao.Text = String.Empty;
            GridViewIluminacao.DataSource = cv.buscaIluminacao();
            GridViewIluminacao.DataBind();
        }
        catch (Exception err)
        {
            ImageIluminacaoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelIluminacaoErro.Text = err.Message;
            LabelIluminacaoErro.Visible = true;
        }
        PanelIluminacaoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIluminacao", "javascript: $('#divIluminacao')[0].style.display = 'block';", true);
    }
    protected void btIluminacaoCancelar_Click(object sender, EventArgs e)
    {
        txtIluminacao.Text = String.Empty;
        ViewState.Remove("codIluminacao");
        PanelIluminacaoConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIluminacao", "javascript: $('#divIluminacao')[0].style.display = 'block';", true);
    }
    #endregion

    #region MURO EDIFICAÇÃO
    /// <summary>
    /// Popula o GridViewMuro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewMuro_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Muro da Edificação?');");
            }
            e.Row.Cells[0].Visible = false; // codMuro
        }
    }
    /// <summary>
    /// Edita um determinado MuroEdificacao do GridViewMuro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewMuro_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewMuro.Rows[indice];

            //// Obtem ID da Conta
            Int32 codMuro = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarMuro"))
            {
                ViewState["codMuro"] = codMuro.ToString();
                txtMuro.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirMuro"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Muro Edificação!");

                    if (!cv.deletaMuro(codMuro))
                        throw new Exception("Não é possível excluir o Muro Edificação!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Muro Edificação excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewMuro.DataSource = cv.buscaMuroEdificacao();
                    GridViewMuro.DataBind();
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
        PanelMuroConfirma.Visible = false;
        //função para não ocultar os Cursos
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeMuro", "javascript: $('#divMuro')[0].style.display = 'block';", true);
    }
    /// <summary>
    /// Alterna entre paginas do GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewMuro_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewMuro.PageIndex = e.NewPageIndex;
        GridViewMuro.DataSource = cv.buscaParasitas();
        GridViewMuro.DataBind();
        //função para não ocultar os Cursos
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeMuro", "javascript: $('#divMuro')[0].style.display = 'block';", true);
    }
    /// <summary>
    /// Cadastra / Edita um MuroEdificação
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btMuroSalvar_Click(object sender, EventArgs e)
    {
        LabelMuroOk.Visible = false;
        LabelMuroErro.Visible = false;
        PanelMuroConfirma.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtMuro.Text.Trim()))
                throw new Exception("Digite o Muro Edificação!");
            if (ViewState["codMuro"] == null)
            {
                //cadastra novo Muro edificação
                cv.InsereMuroEdificacao(txtMuro.Text.Trim());
                LabelMuroOk.Text = "Muro Edificação inserido com sucesso!";
            }
            else
            {
                //edita um Muro Edificação
                cv.atualizaMuroEdificacao(txtMuro.Text.Trim(), Convert.ToInt32(ViewState["codMuro"].ToString()));
                LabelMuroOk.Text = "Muro Edificação atualizado com sucesso!";
            }
            ImageMuroConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelMuroOk.Visible = true;
            ViewState.Remove("codMuro");
            txtMuro.Text = String.Empty;
            GridViewMuro.DataSource = cv.buscaMuroEdificacao();
            GridViewMuro.DataBind();
        }
        catch (Exception err)
        {
            ImageMuroConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelMuroErro.Text = err.Message;
            LabelMuroErro.Visible = true;
        }
        PanelMuroConfirma.Visible = true;
        //função para não ocultar os Cursos
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeMuro", "javascript: $('#divMuro')[0].style.display = 'block';", true);
    }
    protected void btMuroCancelar_Click(object sender, EventArgs e)
    {
        txtMuro.Text = String.Empty;
        PanelMuroConfirma.Visible = false;
        ViewState.Remove("codMuro");
        //função para não ocultar os Cursos
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeMuro", "javascript: $('#divMuro')[0].style.display = 'block';", true);
    }
    #endregion

    #region POSTEAMENTO
    protected void GridViewPosteamento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Posteamento?');");
            }
            e.Row.Cells[0].Visible = false; // codPosteamento
        }
    }
    protected void GridViewPosteamento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewPosteamento.Rows[indice];

            //// Obtem ID da Conta
            Int32 codPosteamento = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarPosteamento"))
            {
                ViewState["codPosteamento"] = codPosteamento.ToString();
                txtPosteamento.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirPosteamento"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Posteamento!");
                    if (!cv.deletaPosteamento(codPosteamento))
                        throw new Exception("Não é possível excluir Tipo de Posteamento!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Tipo de Posteamento excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewPosteamento.DataSource = cv.buscaPosteamentos();
                    GridViewPosteamento.DataBind();
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
        PanelPosteamentoConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePosteamento", "javascript: $('#divPosteamento')[0].style.display = 'block';", true);
    }
    protected void GridViewPosteamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPosteamento.PageIndex = e.NewPageIndex;
        GridViewPosteamento.DataSource = cv.buscaPosteamentos();
        GridViewPosteamento.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePosteamento", "javascript: $('#divPosteamento')[0].style.display = 'block';", true);
    }

    protected void btPosteamentoSalvar_Click(object sender, EventArgs e)
    {
        LabelPosteamentoConfirmaOk.Visible = false;
        LabelPosteamentoConfirmaErro.Visible = false;
        PanelPosteamentoConfirma.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtPosteamento.Text.Trim()))
                throw new Exception("Digite o Posteamento!");
            if (ViewState["codPosteamento"] == null)
            {
                //cadastra novo Posteamento
                cv.InserePosteamento(txtPosteamento.Text.Trim());
                LabelPosteamentoConfirmaOk.Text = "Posteamento inserido com sucesso!";
            }
            else
            {
                //edita o Posteamento
                cv.atualizaPosteamento(txtPosteamento.Text.Trim(), Convert.ToInt32(ViewState["codPosteamento"].ToString()));
                LabelPosteamentoConfirmaOk.Text = "Posteamento atualizado com sucesso!";
            }
            ImagePosteamentoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelPosteamentoConfirmaOk.Visible = true;
            ViewState.Remove("codPosteamento");
            txtPosteamento.Text = String.Empty;
            GridViewPosteamento.DataSource = cv.buscaPosteamentos();
            GridViewPosteamento.DataBind();
        }
        catch (Exception err)
        {
            ImagePosteamentoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelPosteamentoConfirmaErro.Text = err.Message;
            LabelPosteamentoConfirmaErro.Visible = true;
        }
        PanelPosteamentoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePosteamento", "javascript: $('#divPosteamento')[0].style.display = 'block';", true);
    }
    protected void btPosteamentoCancelar_Click(object sender, EventArgs e)
    {
        txtPosteamento.Text = String.Empty;
        PanelPosteamentoConfirma.Visible = false;
        ViewState.Remove("codPosteamento");
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePosteamento", "javascript: $('#divPosteamento')[0].style.display = 'block';", true);
    }
    #endregion

    #region SINALIZAÇÃO
    protected void GridViewSinalizacao_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Sinalização?');");
            }
            e.Row.Cells[0].Visible = false; // codSinalizacao
        }
    }
    protected void GridViewSinalizacao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewSinalizacao.Rows[indice];

            //// Obtem ID da Conta
            Int32 codSinalizacao = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarSinalizacao"))
            {
                ViewState["codSinalizacao"] = codSinalizacao.ToString();
                txtSinalizacao.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirSinalizacao"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Sinalização!");
                    if (!cv.deletaSinalizacao(codSinalizacao))
                        throw new Exception("Não é possível excluir a Sinalização!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Sinalização excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewSinalizacao.DataSource = cv.buscaSinalizacao();
                    GridViewSinalizacao.DataBind();
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
        PanelSinalizacaoConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSinalizacao", "javascript: $('#divSinalizacao')[0].style.display = 'block';", true);
    }
    protected void GridViewSinalizacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewSinalizacao.PageIndex = e.NewPageIndex;
        GridViewSinalizacao.DataSource = cv.buscaSinalizacao();
        GridViewSinalizacao.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSinalizacao", "javascript: $('#divSinalizacao')[0].style.display = 'block';", true);
    }

    protected void btSinalizacaoSalvar_Click(object sender, EventArgs e)
    {
        LabelSinalizacaoOk.Visible = false;
        LabelSinalizacaoErro.Visible = false;
        PanelSinalizacaoConfirma.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtSinalizacao.Text.Trim()))
                throw new Exception("Digite a Sinalização!");
            if (ViewState["codSinalizacao"] == null)
            {
                //cadastra nova Sinalizacao
                cv.InsereSinalizacao(txtSinalizacao.Text.Trim());
                LabelSinalizacaoOk.Text = "Sinalização inserida com sucesso!";
            }
            else
            {
                //edita a Sinalizacao
                cv.atualizaSinalizacao(txtSinalizacao.Text.Trim(), Convert.ToInt32(ViewState["codSinalizacao"].ToString()));
                LabelSinalizacaoOk.Text = "Sinalização atualizada com sucesso!";
            }
            ImageSinalizacaoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelSinalizacaoOk.Visible = true;
            ViewState.Remove("codSinalizacao");
            txtSinalizacao.Text = String.Empty;
            GridViewSinalizacao.DataSource = cv.buscaSinalizacao();
            GridViewSinalizacao.DataBind();
        }
        catch (Exception err)
        {
            ImageSinalizacaoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelSinalizacaoErro.Text = err.Message;
            LabelSinalizacaoErro.Visible = true;
        }
        PanelSinalizacaoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSinalizacao", "javascript: $('#divSinalizacao')[0].style.display = 'block';", true);
    }
    protected void btSinalizacaoCancelar_Click(object sender, EventArgs e)
    {
        txtSinalizacao.Text = String.Empty;
        PanelSinalizacaoConfirma.Visible = false;
        ViewState.Remove("codSinalizacao");
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSinalizacao", "javascript: $('#divSinalizacao')[0].style.display = 'block';", true);
    }
    #endregion

    #region SITUAÇÃO DA FIAÇÃO
    protected void GridViewSituacaoFiacao_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Situação da Fiação?');");
            }
            e.Row.Cells[0].Visible = false; // codSituacaoFiacao
        }
    }
    protected void GridViewSituacaoFiacao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewSituacaoFiacao.Rows[indice];

            //// Obtem ID da Conta
            Int32 codSituacaoFiacao = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarSituacaoFiacao"))
            {
                ViewState["codSituacaoFiacao"] = codSituacaoFiacao.ToString();
                txtSituacaoFiacao.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirSituacaoFiacao"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Situação da Fiação!");
                    if (!cv.deletaSituacaoFiacao(codSituacaoFiacao))
                        throw new Exception("Não é possível excluir a Situação da Fiação!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Situação da Fiação excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewSituacaoFiacao.DataSource = cv.buscaSituacaoFiacao();
                    GridViewSituacaoFiacao.DataBind();
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
        PanelSituacaoFiacaoConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSituacaoFiacao", "javascript: $('#divSituacaoFiacao')[0].style.display = 'block';", true);
    }
    protected void GridViewSituacaoFiacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewSituacaoFiacao.PageIndex = e.NewPageIndex;
        GridViewSituacaoFiacao.DataSource = cv.buscaSituacaoFiacao();
        GridViewSituacaoFiacao.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSituacaoFiacao", "javascript: $('#divSituacaoFiacao')[0].style.display = 'block';", true);
    }

    protected void btSituacaoFiacaoSalvar_Click(object sender, EventArgs e)
    {
        LabelSituacaoFiacaoOk.Visible = false;
        LabelSituacaoFiacaoErro.Visible = false;
        PanelSituacaoFiacaoConfirma.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtSituacaoFiacao.Text.Trim()))
                throw new Exception("Digite a Situação da Fiação!");
            if (ViewState["codSituacaoFiacao"] == null)
            {
                //cadastra nova SituacaoFiacao
                cv.InsereSituacaoFiacao(txtSituacaoFiacao.Text.Trim());
                LabelSituacaoFiacaoOk.Text = "Situação da Fiação inserida com sucesso!";
            }
            else
            {
                //edita a SituacaoFiacao
                cv.atualizaSituacaoFiacao(txtSituacaoFiacao.Text.Trim(), Convert.ToInt32(ViewState["codSituacaoFiacao"].ToString()));
                LabelSituacaoFiacaoOk.Text = "Situação da Fiação atualizada com sucesso!";
            }
            ImageSituacaoFiacaoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelSituacaoFiacaoOk.Visible = true;
            ViewState.Remove("codSituacaoFiacao");
            txtSituacaoFiacao.Text = String.Empty;
            GridViewSituacaoFiacao.DataSource = cv.buscaSituacaoFiacao();
            GridViewSituacaoFiacao.DataBind();
        }
        catch (Exception err)
        {
            ImageSituacaoFiacaoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelSituacaoFiacaoErro.Text = err.Message;
            LabelSituacaoFiacaoErro.Visible = true;
        }
        PanelSituacaoFiacaoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSituacaoFiacao", "javascript: $('#divSituacaoFiacao')[0].style.display = 'block';", true);
    }
    protected void btSituacaoFiacaoCancelar_Click(object sender, EventArgs e)
    {
        txtSituacaoFiacao.Text = String.Empty;
        PanelSituacaoFiacaoConfirma.Visible = false;
        ViewState.Remove("codSituacaoFiacao");
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeSituacaoFiacao", "javascript: $('#divSituacaoFiacao')[0].style.display = 'block';", true);
    }
    #endregion

    #region TIPO DE FIAÇÃO
    protected void GridViewTipoFiacao_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Tipo da Fiação?');");
            }
            e.Row.Cells[0].Visible = false; // codTipoFiacao
        }
    }
    protected void GridViewTipoFiacao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewTipoFiacao.Rows[indice];

            //// Obtem ID da Conta
            Int32 codTipoFiacao = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarTipoFiacao"))
            {
                ViewState["codTipoFiacao"] = codTipoFiacao.ToString();
                txtTipoFiacao.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirTipoFiacao"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Tipo da Fiação!");
                    if (!cv.deletaTipoFiacao(codTipoFiacao))
                        throw new Exception("Não é possível excluir o Tipo de Fiação!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Tipo de Fiação excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewTipoFiacao.DataSource = cv.buscaTipoFiacao();
                    GridViewTipoFiacao.DataBind();
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
        PanelTipoFiacaoConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoFiacao", "javascript: $('#divTipoFiacao')[0].style.display = 'block';", true);
    }
    protected void GridViewTipoFiacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewTipoFiacao.PageIndex = e.NewPageIndex;
        GridViewTipoFiacao.DataSource = cv.buscaTipoFiacao();
        GridViewTipoFiacao.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoFiacao", "javascript: $('#divTipoFiacao')[0].style.display = 'block';", true);
    }

    protected void btTipoFiacaoSalvar_Click(object sender, EventArgs e)
    {
        LabelTipoFiacaoOk.Visible = false;
        LabelTipoFiacaoErro.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtTipoFiacao.Text.Trim()))
                throw new Exception("Digite o Tipo de Fiação!");
            if (ViewState["codTipoFiacao"] == null)
            {
                //cadastra novo Tipo de Fiacao
                cv.InsereTipoFiacao(txtTipoFiacao.Text.Trim());
                LabelTipoFiacaoOk.Text = "Tipo de Fiação inserido com sucesso!";
            }
            else
            {
                //edita o Tipo de Fiação 
                cv.atualizaTipoFiacao(txtTipoFiacao.Text.Trim(), Convert.ToInt32(ViewState["codTipoFiacao"].ToString()));
                LabelTipoFiacaoOk.Text = "Tipo de Fiação atualizada com sucesso!";
            }
            ImageTipoFiacaoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelTipoFiacaoOk.Visible = true;
            ViewState.Remove("codTipoFiacao");
            txtTipoFiacao.Text = String.Empty;
            GridViewTipoFiacao.DataSource = cv.buscaTipoFiacao();
            GridViewTipoFiacao.DataBind();
        }
        catch (Exception err)
        {
            ImageTipoFiacaoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelTipoFiacaoErro.Text = err.Message;
            LabelTipoFiacaoErro.Visible = true;
        }
        PanelTipoFiacaoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoFiacao", "javascript: $('#divTipoFiacao')[0].style.display = 'block';", true);
    }
    protected void btTipoFiacaoCancelar_Click(object sender, EventArgs e)
    {
        txtTipoFiacao.Text = String.Empty;
        PanelTipoFiacaoConfirma.Visible = false;
        ViewState.Remove("codTipoFiacao");
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoFiacao", "javascript: $('#divTipoFiacao')[0].style.display = 'block';", true);
    }
    #endregion

    #region TIPO DE RAIZ NO PAVIMENTO
    protected void GridViewRaiz_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Raiz no Pavimento?');");
            }
            e.Row.Cells[0].Visible = false; // codRaiz
        }
    }
    protected void GridViewRaiz_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewRaiz.Rows[indice];

            //// Obtem ID da Conta
            Int32 codRaiz = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarRaiz"))
            {
                ViewState["codRaiz"] = codRaiz.ToString();
                txtRaiz.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirRaiz"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Raiz no Pavimetno!");
                    if (!cv.deletaRaizPavimento(codRaiz))
                        throw new Exception("Não é possível excluir a Raiz no Pavimento!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Raiz no Pavimento excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewRaiz.DataSource = cv.buscaRaizPavimento();
                    GridViewRaiz.DataBind();
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
        PanelRaizConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeRaiz", "javascript: $('#divRaiz')[0].style.display = 'block';", true);
    }
    protected void GridViewRaiz_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRaiz.PageIndex = e.NewPageIndex;
        GridViewRaiz.DataSource = cv.buscaRaizPavimento();
        GridViewRaiz.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeRaiz", "javascript: $('#divRaiz')[0].style.display = 'block';", true);
    }

    protected void btRaizSalvar_Click(object sender, EventArgs e)
    {
        LabelRaizOk.Visible = false;
        LabelRaizErro.Visible = false;
        PanelRaizConfirma.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtRaiz.Text.Trim()))
                throw new Exception("Digite o Tipo de Raiz no Pavimento!");
            if (ViewState["codRaiz"] == null)
            {
                //cadastra novo Tipo de Raiz no Pavimento
                cv.InsereRaizPavimento(txtRaiz.Text.Trim());
                LabelRaizOk.Text = "Tipo de Raiz no Pavimento inserido com sucesso!";
            }
            else
            {
                //edita o Tipo de Raiz no Pavimento
                cv.atualizaRaizPavimento(txtRaiz.Text.Trim(), Convert.ToInt32(ViewState["codRaiz"].ToString()));
                LabelRaizOk.Text = "Tipo de Raiz no Pavimento atualizado com sucesso!";
            }
            ImageRaizConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelRaizOk.Visible = true;
            ViewState.Remove("codRaiz");
            txtRaiz.Text = String.Empty;
            GridViewRaiz.DataSource = cv.buscaRaizPavimento();
            GridViewRaiz.DataBind();
        }
        catch (Exception err)
        {
            ImageRaizConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelRaizErro.Text = err.Message;
            LabelRaizErro.Visible = true;
        }
        PanelRaizConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeRaiz", "javascript: $('#divRaiz')[0].style.display = 'block';", true);
    }
    protected void btRaizCancelar_Click(object sender, EventArgs e)
    {
        txtRaiz.Text = String.Empty;
        PanelRaizConfirma.Visible = false;
        ViewState.Remove("codRaiz");
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeRaiz", "javascript: $('#divRaiz')[0].style.display = 'block';", true);
    }
    #endregion

    #region TRÁFEGO
    protected void GridViewTrafego_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Tráfego?');");
            }
            e.Row.Cells[0].Visible = false; // codTipoFiacao
        }
    }
    protected void GridViewTrafego_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewTrafego.Rows[indice];

            //// Obtem ID da Conta
            Int32 codTrafego = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarTrafego"))
            {
                ViewState["codTrafego"] = codTrafego.ToString();
                txtTrafego.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());

            }
            if (e.CommandName.Equals("excluirTrafego"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Tráfego!");
                    if (!cv.deletaTrafego(codTrafego))
                        throw new Exception("Não é possível excluir o Tráfego!<br />Existe registros na tabela Interferências.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Tráfego excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewTrafego.DataSource = cv.buscaTrafego();
                    GridViewTrafego.DataBind();
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
        PanelTrafegoConfirma.Visible = false;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTrafego", "javascript: $('#divTrafego')[0].style.display = 'block';", true);
    }
    protected void GridViewTrafego_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewTrafego.PageIndex = e.NewPageIndex;
        GridViewTrafego.DataSource = cv.buscaTrafego();
        GridViewTrafego.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTrafego", "javascript: $('#divTrafego')[0].style.display = 'block';", true);
    }

    protected void btTrafegoSalvar_Click(object sender, EventArgs e)
    {
        LabelTrafegoOk.Visible = false;
        LabelTrafegoErro.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtTrafego.Text.Trim()))
                throw new Exception("Digite o Tráfego!");
            if (ViewState["codTrafego"] == null)
            {
                //cadastra novo Trafego
                cv.InsereTrafego(txtTrafego.Text.Trim());
                LabelTrafegoOk.Text = "Tráfego inserido com sucesso!";
            }
            else
            {
                //edita o Trafego
                cv.atualizaTrafego(txtTrafego.Text.Trim(), Convert.ToInt32(ViewState["codTrafego"].ToString()));
                LabelTrafegoOk.Text = "Tráfego atualizada com sucesso!";
            }
            ImageTrafegoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelTrafegoOk.Visible = true;
            ViewState.Remove("codTrafego");
            txtTrafego.Text = String.Empty;
            GridViewTrafego.DataSource = cv.buscaTrafego();
            GridViewTrafego.DataBind();
        }
        catch (Exception err)
        {
            ImageTrafegoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelTrafegoErro.Text = err.Message;
            LabelTrafegoErro.Visible = true;
        }
        PanelTrafegoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTrafego", "javascript: $('#divTrafego')[0].style.display = 'block';", true);
    }
    protected void btTrafegoCancelar_Click(object sender, EventArgs e)
    {
        txtTrafego.Text = String.Empty;
        PanelTrafegoConfirma.Visible = false;
        ViewState.Remove("codTrafego");
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTrafego", "javascript: $('#divTrafego')[0].style.display = 'block';", true);
    }
    #endregion
}
