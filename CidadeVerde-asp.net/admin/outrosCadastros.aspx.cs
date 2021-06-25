using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_outrosCadastros : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();

    #region ENUMERAÇÃO
    public enum Cadastrar
    {
        familia = 1,
        genero = 2,
        parasitas = 3,
        grupoParasitas = 4,
        locaAfetado = 5,
        intensidade = 6,
        acaoRecomendada = 7,
        localEntorno = 8,
        participacao = 9,
        pavimento = 10,
        tipoLogradouro = 11
    }
    #endregion

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridViewFamilias.DataSource = cv.buscaFamilias();
            GridViewFamilias.DataBind();
            PanelFamiliaCad.Visible = true;

            GridViewFormaCopa.DataSource = cv.buscaFormaCopa();
            GridViewFormaCopa.DataBind();
            PanelFormaCopaCad.Visible = true;

            GridViewGeneros.DataSource = cv.buscaGeneros();
            GridViewGeneros.DataBind();
            ddlFamilia.DataSource = cv.buscaFamilias();
            ddlFamilia.DataBind();
            ddlFamilia.Items.Insert(0, "Selecione uma família");
            ddlFamilia.SelectedIndex = 0;
            PanelGeneroCad.Visible = true;

            GridViewParasitas.DataSource = cv.buscaParasitas();
            GridViewParasitas.DataBind();
            PanelParasitasCad.Visible = true;

            GridViewGrupoParasitas.DataSource = cv.buscaGrupoParasitas();
            GridViewGrupoParasitas.DataBind();
            PanelGrupoParasitaCad.Visible = true;
            GridViewLocalAfetado.DataSource = cv.buscaLocalAfetado();
            GridViewLocalAfetado.DataBind();
            PanelLocalAfetadoCad.Visible = true;

            GridViewIntensidade.DataSource = cv.buscaIntensidade();
            GridViewIntensidade.DataBind();
            PanelIntensidadeCad.Visible = true;

            GridViewAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
            GridViewAcaoRecomendada.DataBind();
            PanelAcaoRecCad.Visible = true;

            GridViewLocalEntorno.DataSource = cv.buscaLocalEntorno();
            GridViewLocalEntorno.DataBind();
            PanelLocalEntornoCad.Visible = true;

            GridViewParticipacao.DataSource = cv.buscaParticipacao();
            GridViewParticipacao.DataBind();
            PanelParticipacaoCad.Visible = true;

            GridViewPavimento.DataSource = cv.buscaPavimento();
            GridViewPavimento.DataBind();
            PanelPavimentoCad.Visible = true;

            GridViewTipoLogradouro.DataSource = cv.buscaTipoLogradouro();
            GridViewTipoLogradouro.DataBind();
            PanelTipoLogradouroCad.Visible = true;

            //ocultaPaineis();
            panelInicio.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript:  $(function() {$('#accordion').accordion();});", true);
        }
    }
    #endregion

    #region INICIO
    /// <summary>
    /// Oculta todos paineis
    /// </summary>
    protected void ocultaPaineis()
    {
        panelInicio.Visible = false;
        PanelFamiliaCad.Visible = false;
        PanelGeneroCad.Visible = false;
        PanelParasitasCad.Visible = false;
        PanelGrupoParasitaCad.Visible = false;
        PanelLocalAfetadoCad.Visible = false;
        PanelIntensidadeCad.Visible = false;
        PanelAcaoRecCad.Visible = false;
        PanelLocalEntornoCad.Visible = false;
        PanelParticipacaoCad.Visible = false;
        PanelPavimentoCad.Visible = false;
        PanelTipoLogradouroCad.Visible = false;
    }
    #endregion

    #region FAMILIAS
    /// <summary>
    /// Monta tabela familia
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewFamilias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Família?');");
            }
            e.Row.Cells[0].Visible = false; // codFamilia
        }
    }
    /// <summary>
    /// Edita familia
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewFamilias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewFamilias.Rows[indice];

            //// Obtem ID da Conta
            Int32 codFamilia = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarFamilia"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codFamilia"] = codFamilia.ToString();
                txtFamilia.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirFamilia"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Família!");
                    removeViewStates();
                    if (!cv.deletaFamilia(codFamilia))
                        throw new Exception("Não é possível excluir a Família!<br />Existe registros na tabela Gênero.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Família excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewFamilias.DataSource = cv.buscaFamilias();
                    GridViewFamilias.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFamilia", "javascript: $('#divFamilia')[0].style.display = 'block';", true);
    }

    protected void GridViewFamilias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFamilias.PageIndex = e.NewPageIndex;
        GridViewFamilias.DataSource = cv.buscaFamilias();
        GridViewFamilias.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFamilia", "javascript: $('#divFamilia')[0].style.display = 'block';", true);
    }
    /// <summary>
    /// CADASTRA / EDITA UMA FAMILIA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFamiliaSalvar_Click(object sender, EventArgs e)
    {
        LabelFamiliaOk.Visible = false;
        LabelFamiliaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtFamilia.Text.Trim()))
                throw new Exception("Digite a Família!");
            if (ViewState["codFamilia"] == null)
            {
                //cadastra nova familia
                cv.InsereFamilia(txtFamilia.Text.Trim());
                LabelFamiliaOk.Text = "Família inserida com sucesso!";
            }
            else
            {
                //edita a familia
                cv.atualizaFamilia(txtFamilia.Text.Trim(), Convert.ToInt32(ViewState["codFamilia"].ToString()));
                LabelFamiliaOk.Text = "Família atualizada com sucesso!";
            }
            ImageFamliaConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelFamiliaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewFamilias.DataSource = cv.buscaFamilias();
            GridViewFamilias.DataBind();
            ddlFamilia.DataSource = cv.buscaFamilias();
            ddlFamilia.DataBind();
            ddlFamilia.Items.Insert(0, "Selecione uma família");
            ddlFamilia.SelectedIndex = 0;
        }
        catch (Exception err)
        {
            ImageFamliaConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelFamiliaErro.Text = err.Message;
            LabelFamiliaErro.Visible = true;
        }
        PanelFamiliaConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFamilia", "javascript: $('#divFamilia')[0].style.display = 'block';", true);
    }
    protected void btFamiliaCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFamilia", "javascript: $('#divFamilia')[0].style.display = 'block';", true);
    }
    #endregion

    #region FORMA DA COPA
    /// <summary>
    /// Monta tabela Forma da Copa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewFormaCopa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Forma da Copa?');");
            }
            e.Row.Cells[0].Visible = false; // codFormaCopa
        }
    }
    /// <summary>
    /// Edita Forma da Copa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewFormaCopa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewFormaCopa.Rows[indice];

            //// Obtem ID da Conta
            Int32 codFormaCopa = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarFormaCopa"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codFormaCopa"] = codFormaCopa.ToString();
                txtFormaCopa.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirFormaCopa"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Forma da Copa!");
                    removeViewStates();
                    if (!cv.deletaFormaCopa(codFormaCopa))
                        throw new Exception("Não é possível excluir a Forma da Copa!<br />Existe registros na tabela Espécie.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Forma da Copa excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewFormaCopa.DataSource = cv.buscaFormaCopa();
                    GridViewFormaCopa.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFormaCopa", "javascript: $('#divFormaCopa')[0].style.display = 'block';", true);
    }
    protected void GridViewFormaCopa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFormaCopa.PageIndex = e.NewPageIndex;
        GridViewFormaCopa.DataSource = cv.buscaFormaCopa();
        GridViewFormaCopa.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFormaCopa", "javascript: $('#divFormaCopa')[0].style.display = 'block';", true);
    }
    /// <summary>
    /// CADASTRA / EDITA UMA FORMA DA COPA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFormaCopaSalvar_Click(object sender, EventArgs e)
    {
        LabelFormaCopaOk.Visible = false;
        LabelFormaCopaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtFormaCopa.Text.Trim()))
                throw new Exception("Digite a Forma da Copa!");
            if (ViewState["codFormaCopa"] == null)
            {
                //cadastra nova Forma da Copa
                cv.InsereFormaCopa(txtFormaCopa.Text.Trim());
                LabelFormaCopaOk.Text = "Forma da Copa inserida com sucesso!";
            }
            else
            {
                //edita a Forma da Copa
                cv.atualizaFormaCopa(txtFormaCopa.Text.Trim(), Convert.ToInt32(ViewState["codFormaCopa"].ToString()));
                LabelFormaCopaOk.Text = "Forma da Copa atualizada com sucesso!";
            }
            ImageFormaCopaConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelFormaCopaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewFormaCopa.DataSource = cv.buscaFormaCopa();
            GridViewFormaCopa.DataBind();
        }
        catch (Exception err)
        {
            ImageFormaCopaConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelFormaCopaErro.Text = err.Message;
            LabelFormaCopaErro.Visible = true;
        }
        PanelFormaCopaConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFormaCopa", "javascript: $('#divFormaCopa')[0].style.display = 'block';", true);
    }
    protected void btFormaCopaCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeFormaCopa", "javascript: $('#divFormaCopa')[0].style.display = 'block';", true);
    }
    #endregion

    #region GENERO
    /// <summary>
    /// SELECIONA UMA FAMILIA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFamilia_SelectedIndexChanged(object sender, EventArgs e)
    {
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGenero", "javascript: $('#divGenero')[0].style.display = 'block';", true);
    }
    /// <summary>
    /// MONTA A TABELA DE LISTA DE GENEROS
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewGeneros_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[5].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Gênero?');");
            }
            e.Row.Cells[0].Visible = false; // codGenero
            e.Row.Cells[2].Visible = false; // codFamilia
        }
    }
    protected void GridViewGeneros_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewGeneros.Rows[indice];

            //// Obtem ID da Conta
            Int32 codGenero = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarGenero"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codGenero"] = codGenero.ToString();
                ddlFamilia.SelectedValue = Server.HtmlDecode(linha.Cells[2].Text.Trim());// linha.Cells[2].Text.Trim();
                txtGenero.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());// linha.Cells[1].Text.Trim();                
            }
            if (e.CommandName.Equals("excluirGenero"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Gênero!");
                    removeViewStates();
                    if (!cv.deletaGenero(codGenero))
                        throw new Exception("Não é possível excluir o Gênero!<br />Existe registros na tabela Espécie.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Gênero excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewGeneros.DataSource = cv.buscaGeneros();
                    GridViewGeneros.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGenero", "javascript: $('#divGenero')[0].style.display = 'block';", true);
    }
    protected void GridViewGeneros_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewGeneros.PageIndex = e.NewPageIndex;
        GridViewGeneros.DataSource = cv.buscaGeneros();
        GridViewGeneros.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGenero", "javascript: $('#divGenero')[0].style.display = 'block';", true);
    }

    protected void btGeneroSalvar_Click(object sender, EventArgs e)
    {
        LabelGeneroOk.Visible = false;
        LabelGeneroErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (ddlFamilia.SelectedIndex == 0)
                throw new Exception("Selecione uma família!");
            if (String.IsNullOrEmpty(txtGenero.Text.Trim()))
                throw new Exception("Digite o Gênero!");
            if (ViewState["codGenero"] == null)
            {
                //cadastra novo genero
                cv.InsereGenero(Convert.ToInt32(ddlFamilia.SelectedValue), txtGenero.Text.Trim());
                LabelGeneroOk.Text = "Gênero inserido com sucesso!";
            }
            else
            {
                //edita o genero
                cv.atualizaGenero(Convert.ToInt32(ddlFamilia.SelectedValue), txtGenero.Text.Trim(), Convert.ToInt32(ViewState["codGenero"].ToString()));
                LabelGeneroOk.Text = "Gênero atualizado com sucesso!";
            }
            ImageGeneroConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelGeneroOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewGeneros.DataSource = cv.buscaGeneros();
            GridViewGeneros.DataBind();
        }
        catch (Exception err)
        {
            ImageGeneroConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelGeneroErro.Text = err.Message;
            LabelGeneroErro.Visible = true;
        }
        PanelGeneroConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGenero", "javascript: $('#divGenero')[0].style.display = 'block';", true);
    }
    protected void btGeneroCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGenero", "javascript: $('#divGenero')[0].style.display = 'block';", true);
    }

    #endregion

    #region PARASITAS
    protected void GridViewParasitas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o parasita?');");
            }
            e.Row.Cells[0].Visible = false; // codParasita
        }
    }
    protected void GridViewParasitas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewParasitas.Rows[indice];

            //// Obtem ID da Conta
            Int32 codParasita = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarParasita"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codParasita"] = codParasita.ToString();
                txtParasita.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());//linha.Cells[1].Text.Trim();
            }
            if (e.CommandName.Equals("excluirParasita"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Parasita!");
                    removeViewStates();
                    if (!cv.deletaParasita(codParasita))
                        throw new Exception("Não é possível excluir o Parasita!<br />Existe registros na tabela Doenças.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Parasita excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewParasitas.DataSource = cv.buscaParasitas();
                    GridViewParasitas.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParasitas", "javascript: $('#divParasitas')[0].style.display = 'block';", true);
    }
    protected void GridViewParasitas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewParasitas.PageIndex = e.NewPageIndex;
        GridViewParasitas.DataSource = cv.buscaParasitas();
        GridViewParasitas.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParasitas", "javascript: $('#divParasitas')[0].style.display = 'block';", true);
    }
    protected void btParasitaSalvar_Click(object sender, EventArgs e)
    {
        LabelParasitaOk.Visible = false;
        LabelParasitaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtParasita.Text.Trim()))
                throw new Exception("Digite o Parasita!");
            if (ViewState["codParasita"] == null)
            {
                //cadastra novo parasita
                cv.InsereParasita(txtParasita.Text.Trim());
                LabelParasitaOk.Text = "Parasita inserido com sucesso!";
            }
            else
            {
                //edita o parasita
                cv.atualizaParasita(txtParasita.Text.Trim(), Convert.ToInt32(ViewState["codParasita"].ToString()));
                LabelParasitaOk.Text = "Parasita atualizado com sucesso!";
            }
            ImageParasitaConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelParasitaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewParasitas.DataSource = cv.buscaParasitas();
            GridViewParasitas.DataBind();
        }
        catch (Exception err)
        {
            ImageParasitaConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelParasitaErro.Text = err.Message;
            LabelParasitaErro.Visible = true;
        }
        PanelParasitaConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParasitas", "javascript: $('#divParasitas')[0].style.display = 'block';", true);
    }
    protected void btParasitaCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParasitas", "javascript: $('#divParasitas')[0].style.display = 'block';", true);
    }
    #endregion

    #region GRUPO DE PARASITAS
    protected void GridViewGrupoParasitas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Grupo de Parasitas?');");
            }
            e.Row.Cells[0].Visible = false; // codGrupoParasita
        }
    }
    protected void GridViewGrupoParasitas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewGrupoParasitas.Rows[indice];

            //// Obtem ID da Conta
            Int32 codGrupoParasita = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarGrupoParasita"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codGrupoParasita"] = codGrupoParasita.ToString();
                txtGrupoParasita.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());//linha.Cells[1].Text.Trim();
            }
            if (e.CommandName.Equals("excluirGrupoParasita"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Grupo de Parasita!");
                    removeViewStates();
                    if (!cv.deletaGrupoParasita(codGrupoParasita))
                        throw new Exception("Não é possível excluir o Grupo de Parasita!<br />Existe registros na tabela Doenças.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Grupo de Parasita excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewGrupoParasitas.DataSource = cv.buscaGrupoParasitas();
                    GridViewGrupoParasitas.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGrupoParasitas", "javascript: $('#divGrupoParasitas')[0].style.display = 'block';", true);
    }
    protected void GridViewGrupoParasitas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewGrupoParasitas.PageIndex = e.NewPageIndex;
        GridViewGrupoParasitas.DataSource = cv.buscaGrupoParasitas();
        GridViewGrupoParasitas.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGrupoParasitas", "javascript: $('#divGrupoParasitas')[0].style.display = 'block';", true);
    }

    protected void btGrupoParasitaSalvar_Click(object sender, EventArgs e)
    {
        LabelGrupoParasitaConfirmaOk.Visible = false;
        LabelGrupoParasitaConfirmaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtGrupoParasita.Text.Trim()))
                throw new Exception("Digite o Grupo de Parasita!");
            if (ViewState["codGrupoParasita"] == null)
            {
                //cadastra novo grupo de parasita
                cv.InsereGrupoParasita(txtGrupoParasita.Text.Trim());
                LabelGrupoParasitaConfirmaOk.Text = "Grupo de Parasita inserido com sucesso!";
            }
            else
            {
                //edita o parasita
                cv.atualizaGrupoParasita(txtGrupoParasita.Text.Trim(), Convert.ToInt32(ViewState["codGrupoParasita"].ToString()));
                LabelGrupoParasitaConfirmaOk.Text = "Grupo de Parasita atualizado com sucesso!";
            }
            ImageGrupoParasitaConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelGrupoParasitaConfirmaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewGrupoParasitas.DataSource = cv.buscaGrupoParasitas();
            GridViewGrupoParasitas.DataBind();
        }
        catch (Exception err)
        {
            ImageGrupoParasitaConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelGrupoParasitaConfirmaErro.Text = err.Message;
            LabelGrupoParasitaConfirmaErro.Visible = true;
        }
        PanelGrupoParasitaConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGrupoParasitas", "javascript: $('#divGrupoParasitas')[0].style.display = 'block';", true);
    }
    protected void btGrupoParasitaCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeGrupoParasitas", "javascript: $('#divGrupoParasitas')[0].style.display = 'block';", true);
    }
    #endregion

    #region LOCALAFETADO
    protected void GridViewLocalAfetado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Local Afetado?');");
            }
            e.Row.Cells[0].Visible = false; // codLocalAfetado
        }
    }
    protected void GridViewLocalAfetado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewLocalAfetado.Rows[indice];

            //// Obtem ID da Conta
            Int32 codLocalAfetado = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarLocalAfetado"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codLocalAfetado"] = codLocalAfetado.ToString();
                txtLocalAfetado.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());//linha.Cells[1].Text.Trim();
                PanelLocalAfetadoConfirma.Visible = false;
            }
            if (e.CommandName.Equals("excluirLocalAfetado"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Local Afetado!");
                    removeViewStates();
                    if (!cv.deletaLocalAfetado(codLocalAfetado))
                        throw new Exception("Não é possível excluir o Local Afetado!<br />Existe registros na tabela Doenças.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Local Afetado excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewLocalAfetado.DataSource = cv.buscaLocalAfetado();
                    GridViewLocalAfetado.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeLocalAfetado", "javascript: $('#divLocalAfetado')[0].style.display = 'block';", true);
    }
    protected void GridViewLocalAfetado_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewLocalAfetado.PageIndex = e.NewPageIndex;
        GridViewLocalAfetado.DataSource = cv.buscaGrupoParasitas();
        GridViewLocalAfetado.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeLocalAfetado", "javascript: $('#divLocalAfetado')[0].style.display = 'block';", true);
    }
    protected void btLocalAfetadoSalvar_Click(object sender, EventArgs e)
    {
        LabelLocalAfetadoConfirmaOk.Visible = false;
        LabelLocalAfetadoConfirmaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtLocalAfetado.Text.Trim()))
                throw new Exception("Digite o Local Afetado!");
            if (ViewState["codLocalAfetado"] == null)
            {
                //cadastra novo Local Afetado
                cv.InsereLocalAfetado(txtLocalAfetado.Text.Trim());
                LabelLocalAfetadoConfirmaOk.Text = "Local Afetado inserido com sucesso!";
            }
            else
            {
                //edita o Local Afetado
                cv.atualizaLocalAfetado(txtLocalAfetado.Text.Trim(), Convert.ToInt32(ViewState["codLocalAfetado"].ToString()));
                LabelLocalAfetadoConfirmaOk.Text = "Local Afetado atualizado com sucesso!";
            }
            ImageLocalAfetadoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelLocalAfetadoConfirmaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewLocalAfetado.DataSource = cv.buscaLocalAfetado();
            GridViewLocalAfetado.DataBind();
        }
        catch (Exception err)
        {
            ImageLocalAfetadoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelLocalAfetadoConfirmaErro.Text = err.Message;
            LabelLocalAfetadoConfirmaErro.Visible = true;
        }
        PanelLocalAfetadoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeLocalAfetado", "javascript: $('#divLocalAfetado')[0].style.display = 'block';", true);
    }
    protected void btLocalAfetadoCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeLocalAfetado", "javascript: $('#divLocalAfetado')[0].style.display = 'block';", true);
    }
    #endregion

    #region INTENSIDADE
    protected void GridViewIntensidade_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Intensidade?');");
            }
            e.Row.Cells[0].Visible = false; // codIntensidade
        }
    }
    protected void GridViewIntensidade_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewIntensidade.Rows[indice];

            //// Obtem ID da Conta
            Int32 codIntensidade = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarIntensidade"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codIntensidade"] = codIntensidade.ToString();
                txtIntensidade.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());//linha.Cells[1].Text.Trim();
            }
            if (e.CommandName.Equals("excluirIntensidade"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Intensidade!");
                    removeViewStates();
                    if (!cv.deletaIntensidade(codIntensidade))
                        throw new Exception("Não é possível excluir a Intensidade!<br />Existe registros na tabela Doenças.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Intensidade excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewIntensidade.DataSource = cv.buscaIntensidade();
                    GridViewIntensidade.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIntensidade", "javascript: $('#divIntensidade')[0].style.display = 'block';", true);
    }
    protected void GridViewIntensidade_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewIntensidade.PageIndex = e.NewPageIndex;
        GridViewIntensidade.DataSource = cv.buscaIntensidade();
        GridViewIntensidade.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIntensidade", "javascript: $('#divIntensidade')[0].style.display = 'block';", true);
    }
    protected void btIntensidadeSalvar_Click(object sender, EventArgs e)
    {
        LabelIntensidadeConfirmaOk.Visible = false;
        LabelIntensidadeConfirmaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtIntensidade.Text.Trim()))
                throw new Exception("Digite a Intensidade!");
            if (ViewState["codIntensidade"] == null)
            {
                //cadastra nova Intensidade
                cv.InsereIntensidade(txtIntensidade.Text.Trim());
                LabelIntensidadeConfirmaOk.Text = "Intensidade inserida com sucesso!";
            }
            else
            {
                //edita a intensidade
                cv.atualizaIntensidade(txtIntensidade.Text.Trim(), Convert.ToInt32(ViewState["codIntensidade"].ToString()));
                LabelIntensidadeConfirmaOk.Text = "Intensidade atualizada com sucesso!";
            }
            ImageIntensidadeConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelIntensidadeConfirmaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewIntensidade.DataSource = cv.buscaIntensidade();
            GridViewIntensidade.DataBind();
        }
        catch (Exception err)
        {
            ImageIntensidadeConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelIntensidadeConfirmaErro.Text = err.Message;
            LabelIntensidadeConfirmaErro.Visible = true;
        }
        PanelIntensidadeConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIntensidade", "javascript: $('#divIntensidade')[0].style.display = 'block';", true);
    }
    protected void btIntensidadeCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeIntensidade", "javascript: $('#divIntensidade')[0].style.display = 'block';", true);
    }
    #endregion

    #region AÇÃO RECOMENDADA
    protected void GridViewAcaoRecomendada_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Ação Recomendada?');");
            }
            e.Row.Cells[0].Visible = false; // codAcaoRecomendada
        }
    }
    protected void GridViewAcaoRecomendada_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewAcaoRecomendada.Rows[indice];

            //// Obtem ID da Conta
            Int32 codAcaoRecomendada = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarAcaoRec"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codAcaoRecomendada"] = codAcaoRecomendada.ToString();
                txtAcaoRec.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());//linha.Cells[1].Text.Trim();
                PanelAcaoRecConfirma.Visible = false;
            }
            if (e.CommandName.Equals("excluirAcaoRec"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Ação Recomendada!");
                    removeViewStates();
                    if (!cv.deletaAcaoRecomendada(codAcaoRecomendada))
                        throw new Exception("Não é possível excluir a Ação Recomendada!<br />Existe registros na tabela Ações Árvores.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Ação Recomendada excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
                    GridViewAcaoRecomendada.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeAcaoRec", "javascript: $('#divAcaoRec')[0].style.display = 'block';", true);
    }
    protected void GridViewAcaoRecomendada_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewAcaoRecomendada.PageIndex = e.NewPageIndex;
        GridViewAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
        GridViewAcaoRecomendada.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeAcaoRec", "javascript: $('#divAcaoRec')[0].style.display = 'block';", true);
    }
    protected void btAcaoRecSalvar_Click(object sender, EventArgs e)
    {
        LabelAcaoRecConfirmaOk.Visible = false;
        LabelAcaoRecConfirmaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtAcaoRec.Text.Trim()))
                throw new Exception("Digite a Ação Recomendada!");
            if (ViewState["codAcaoRecomendada"] == null)
            {
                //cadastra nova Ação Recomenadada
                cv.InsereAcaoRecomendada(txtAcaoRec.Text.Trim());
                LabelAcaoRecConfirmaOk.Text = "Ação Recomendada inserida com sucesso!";
            }
            else
            {
                //edita a Ação Recomendada
                cv.atualizaAcaoRecomendada(txtAcaoRec.Text.Trim(), Convert.ToInt32(ViewState["codAcaoRecomendada"].ToString()));
                LabelAcaoRecConfirmaOk.Text = "Ação Recomendada atualizada com sucesso!";
            }
            ImageAcaoRecConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelAcaoRecConfirmaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewAcaoRecomendada.DataSource = cv.buscaAcoesRecomendadas();
            GridViewAcaoRecomendada.DataBind();
        }
        catch (Exception err)
        {
            ImageAcaoRecConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelAcaoRecConfirmaErro.Text = err.Message;
            LabelAcaoRecConfirmaErro.Visible = true;
        }
        PanelAcaoRecConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeAcaoRec", "javascript: $('#divAcaoRec')[0].style.display = 'block';", true);
    }
    protected void btAcaoRecCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeAcaoRec", "javascript: $('#divAcaoRec')[0].style.display = 'block';", true);
    }
    #endregion

    #region LOCAL ENTORNO DA ÁRVORE
    protected void GridViewLocalEntorno_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Local Entrono?');");
            }
            e.Row.Cells[0].Visible = false; // codLocalEntorno
        }
    }
    protected void GridViewLocalEntorno_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewLocalEntorno.Rows[indice];

            //// Obtem ID da Conta
            Int32 codLocalEntorno = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarLocalEntorno"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codLocalEntorno"] = codLocalEntorno.ToString();
                txtLocalEntorno.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
                PanelLocalEntornoConfirma.Visible = false;
            }
            if (e.CommandName.Equals("excluirLocalEntorno"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Local Entorno!");
                    removeViewStates();
                    if (!cv.deletaLocalEntorno(codLocalEntorno))
                        throw new Exception("Não é possível excluir o Local Entorno! <br />Existe registros na tabela Entorno.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Local Entorno excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewLocalEntorno.DataSource = cv.buscaLocalEntorno();
                    GridViewLocalEntorno.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeEntorno", "javascript: $('#divEntorno')[0].style.display = 'block';", true);
    }
    protected void GridViewLocalEntorno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewLocalEntorno.PageIndex = e.NewPageIndex;
        GridViewLocalEntorno.DataSource = cv.buscaLocalEntorno();
        GridViewLocalEntorno.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeEntorno", "javascript: $('#divEntorno')[0].style.display = 'block';", true);
    }
    protected void btLocalEntornoSalvar_Click(object sender, EventArgs e)
    {
        LabelLocalEntornoOk.Visible = false;
        LabelLocalEntornoErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtLocalEntorno.Text.Trim()))
                throw new Exception("Digite o Local de Entorno da Árvore!");
            if (ViewState["codLocalEntorno"] == null)
            {
                //cadastra novo Local Entorno
                cv.InsereLocalEntorno(txtLocalEntorno.Text.Trim());
                LabelLocalEntornoOk.Text = "Local Entorno inserido com sucesso!";
            }
            else
            {
                //edita o Local Entorno
                cv.atualizaLocalEntorno(txtLocalEntorno.Text.Trim(), Convert.ToInt32(ViewState["codLocalEntorno"].ToString()));
                LabelLocalEntornoOk.Text = "Local Entorno atualizada com sucesso!";
            }
            ImageLocalEntornoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelLocalEntornoOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewLocalEntorno.DataSource = cv.buscaLocalEntorno();
            GridViewLocalEntorno.DataBind();
        }
        catch (Exception err)
        {
            ImageLocalEntornoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelLocalEntornoErro.Text = err.Message;
            LabelLocalEntornoErro.Visible = true;
        }
        PanelLocalEntornoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeEntorno", "javascript: $('#divEntorno')[0].style.display = 'block';", true);
    }
    protected void btLocalEntornoCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeEntorno", "javascript: $('#divEntorno')[0].style.display = 'block';", true);
    }
    #endregion

    #region PARTICIPAÇÃO
    protected void GridViewParticipacao_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Participação?');");
            }
            e.Row.Cells[0].Visible = false; // codParticipacao
        }
    }
    protected void GridViewParticipacao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewParticipacao.Rows[indice];

            //// Obtem ID da Conta
            Int32 codParticipacao = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarParticipacao"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codParticipacao"] = codParticipacao.ToString();
                txtParcipacao.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
                PanelParticipacaoConfirma.Visible = false;
            }
            if (e.CommandName.Equals("excluirParticipacao"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Participação!");
                    removeViewStates();
                    if (!cv.deletaParticipacao(codParticipacao))
                        throw new Exception("Não é possível excluir a Participação! <br />Existe registros na tabela Entorno.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Participação excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewParticipacao.DataSource = cv.buscaParticipacao();
                    GridViewParticipacao.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParticipacao", "javascript: $('#divParticipacao')[0].style.display = 'block';", true);
    }
    protected void GridViewParticipacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewParticipacao.PageIndex = e.NewPageIndex;
        GridViewParticipacao.DataSource = cv.buscaParticipacao();
        GridViewParticipacao.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParticipacao", "javascript: $('#divParticipacao')[0].style.display = 'block';", true);
    }
    protected void btParticipacaoSalvar_Click(object sender, EventArgs e)
    {
        LabelParticipacaoConfirmaOk.Visible = false;
        LabelParticipacaoConfirmaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtParcipacao.Text.Trim()))
                throw new Exception("Digite a Participação da Árvore!");
            if (ViewState["codParticipacao"] == null)
            {
                //cadastra nova Participação
                cv.InsereParticipacao(txtParcipacao.Text.Trim());
                LabelParticipacaoConfirmaOk.Text = "Participação inserida com sucesso!";
            }
            else
            {
                //edita a Participação
                cv.atualizaParticipacao(txtParcipacao.Text.Trim(), Convert.ToInt32(ViewState["codParticipacao"].ToString()));
                LabelParticipacaoConfirmaOk.Text = "Participação atualizada com sucesso!";
            }
            ImageParticipacaoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelParticipacaoConfirmaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewParticipacao.DataSource = cv.buscaParticipacao();
            GridViewParticipacao.DataBind();
        }
        catch (Exception err)
        {
            ImageParticipacaoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelParticipacaoConfirmaErro.Text = err.Message;
            LabelParticipacaoConfirmaErro.Visible = true;
        }
        PanelParticipacaoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParticipacao", "javascript: $('#divParticipacao')[0].style.display = 'block';", true);
    }
    protected void btParticipacaoCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeParticipacao", "javascript: $('#divParticipacao')[0].style.display = 'block';", true);
    }
    #endregion

    #region PAVIMENTO
    protected void GridViewPavimento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Pavimento?');");
            }
            e.Row.Cells[0].Visible = false; // codPavimento
        }
    }
    protected void GridViewPavimento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewPavimento.Rows[indice];

            //// Obtem ID da Conta
            Int32 codPavimento = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarPavimento"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codPavimento"] = codPavimento.ToString();
                txtPavimento.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
                PanelPavimentoConfirma.Visible = false;
            }
            if (e.CommandName.Equals("excluirPavimento"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Pavimento!");
                    removeViewStates();
                    if (!cv.deletaPavimento(codPavimento))
                        throw new Exception("Não é possível excluir o Pavimento! <br />Existe registros na tabela Entorno.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Pavimento excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewPavimento.DataSource = cv.buscaPavimento();
                    GridViewPavimento.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePavimento", "javascript: $('#divPavimento')[0].style.display = 'block';", true);
    }
    protected void GridViewPavimento_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPavimento.PageIndex = e.NewPageIndex;
        GridViewPavimento.DataSource = cv.buscaParticipacao();
        GridViewPavimento.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePavimento", "javascript: $('#divPavimento')[0].style.display = 'block';", true);
    }
    protected void btPavimentoSalvar_Click(object sender, EventArgs e)
    {
        LabelPavimentoConfirmaOk.Visible = false;
        LabelPavimentoConfirmaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtPavimento.Text.Trim()))
                throw new Exception("Digite o Pavimento da Árvore!");
            if (ViewState["codPavimento"] == null)
            {
                //cadastra novo Pavimento
                cv.InserePavimento(txtPavimento.Text.Trim());
                LabelPavimentoConfirmaOk.Text = "Pavimento inserido com sucesso!";
            }
            else
            {
                //edita a Pavimento
                cv.atualizaPavimento(txtPavimento.Text.Trim(), Convert.ToInt32(ViewState["codPavimento"].ToString()));
                LabelPavimentoConfirmaOk.Text = "Pavimento atualizado com sucesso!";
            }
            ImagePavimentoConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelPavimentoConfirmaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewPavimento.DataSource = cv.buscaPavimento();
            GridViewPavimento.DataBind();
        }
        catch (Exception err)
        {
            ImagePavimentoConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelPavimentoConfirmaErro.Text = err.Message;
            LabelPavimentoConfirmaErro.Visible = true;
        }
        PanelPavimentoConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePavimento", "javascript: $('#divPavimento')[0].style.display = 'block';", true);
    }
    protected void btPavimentoCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandePavimento", "javascript: $('#divPavimento')[0].style.display = 'block';", true);
    }
    #endregion

    #region TIPO LOGRADOURO
    protected void GridViewTipoLogradouro_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[3].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Tipo de Logradouro?');");
            }
            e.Row.Cells[0].Visible = false; // codTipoLogradouro
        }
    }
    protected void GridViewTipoLogradouro_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewTipoLogradouro.Rows[indice];

            //// Obtem ID da Conta
            Int32 codTipoLogradouro = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarTipoLogradouro"))
            {
                limpaCampos();
                removeViewStates();
                ViewState["codTipoLogradouro"] = codTipoLogradouro.ToString();
                txtTipoLogradouro.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
                PanelTipoLogradouroConfirma.Visible = false;
            }
            if (e.CommandName.Equals("excluirTipoLogradouro"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Tipo de Logradouro!");
                    removeViewStates();
                    if (!cv.deletaTipoLogradouro(codTipoLogradouro))
                        throw new Exception("Não é possível excluir o Tipo de Logradouro! <br />Existe registros na tabela Loc. e/ou CEP.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Tipo de Logradouro excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewTipoLogradouro.DataSource = cv.buscaTipoLogradouro();
                    GridViewTipoLogradouro.DataBind();
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
        ocultaPaineisConfirmacao();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoLogradouro", "javascript: $('#divTipoLogradouro')[0].style.display = 'block';", true);
    }
    protected void GridViewTipoLogradouro_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewTipoLogradouro.PageIndex = e.NewPageIndex;
        GridViewTipoLogradouro.DataSource = cv.buscaTipoLogradouro();
        GridViewTipoLogradouro.DataBind();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoLogradouro", "javascript: $('#divTipoLogradouro')[0].style.display = 'block';", true);
    }
    protected void btTipoLogradouroSalvar_Click(object sender, EventArgs e)
    {
        LabelTipoLogradouroConfirmaOk.Visible = false;
        LabelTipoLogradouroConfirmaErro.Visible = false;
        ocultaPaineisConfirmacao();
        try
        {
            if (String.IsNullOrEmpty(txtTipoLogradouro.Text.Trim()))
                throw new Exception("Digite o Tipo de Logradouro da Árvore!");
            if (ViewState["codTipoLogradouro"] == null)
            {
                //cadastra novo Tipo de Logradouro
                cv.InsereTipoLogradouro(txtTipoLogradouro.Text.Trim());
                LabelTipoLogradouroConfirmaOk.Text = "Tipo de Logradouro inserido com sucesso!";
            }
            else
            {
                //edita o Tipo de Logradouro
                cv.atualizaTipoLogradouro(txtTipoLogradouro.Text.Trim(), Convert.ToInt32(ViewState["codTipoLogradouro"].ToString()));
                LabelTipoLogradouroConfirmaOk.Text = "Tipo de Logradouro atualizado com sucesso!";
            }
            ImageTipoLogradouroConfirma.ImageUrl = "~/images/confirmation32.png";
            LabelTipoLogradouroConfirmaOk.Visible = true;
            limpaCampos();
            removeViewStates();
            GridViewTipoLogradouro.DataSource = cv.buscaTipoLogradouro();
            GridViewTipoLogradouro.DataBind();
        }
        catch (Exception err)
        {
            ImageTipoLogradouroConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelTipoLogradouroConfirmaErro.Text = err.Message;
            LabelTipoLogradouroConfirmaErro.Visible = true;
        }
        PanelTipoLogradouroConfirma.Visible = true;
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoLogradouro", "javascript: $('#divTipoLogradouro')[0].style.display = 'block';", true);
    }
    protected void btTipoLogradouroCancelar_Click(object sender, EventArgs e)
    {
        ocultaPaineisConfirmacao();
        limpaCampos();
        removeViewStates();
        //função para não ocultar a Div
        ScriptManager.RegisterStartupScript(this, GetType(), "ExpandeTipoLogradouro", "javascript: $('#divTipoLogradouro')[0].style.display = 'block';", true);
    }
    #endregion

    #region CONTROLE
    /// <summary>
    /// Oculta todos paineis de confirmação
    /// </summary>
    public void ocultaPaineisConfirmacao()
    {
        PanelFamiliaConfirma.Visible = false;
        PanelFormaCopaConfirma.Visible = false;
        PanelGeneroConfirma.Visible = false;
        PanelParasitaConfirma.Visible = false;
        PanelGrupoParasitaConfirma.Visible = false;
        PanelLocalAfetadoConfirma.Visible = false;
        PanelIntensidadeConfirma.Visible = false;
        PanelAcaoRecConfirma.Visible = false;
        PanelLocalEntornoConfirma.Visible = false;
        PanelParticipacaoConfirma.Visible = false;
        PanelPavimentoConfirma.Visible = false;
        PanelTipoLogradouroConfirma.Visible = false;
    }
    /// <summary>
    /// Limpa todos os Campos
    /// </summary>
    public void limpaCampos()
    {
        txtFamilia.Text = String.Empty;
        ddlFamilia.SelectedIndex = 0;
        txtGenero.Text = String.Empty;
        txtFormaCopa.Text = String.Empty;
        txtParasita.Text = String.Empty;
        txtGrupoParasita.Text = String.Empty;
        txtLocalAfetado.Text = String.Empty;
        txtIntensidade.Text = String.Empty;
        txtAcaoRec.Text = String.Empty;
        txtLocalEntorno.Text = String.Empty;
        txtParcipacao.Text = String.Empty;
        txtPavimento.Text = String.Empty;
        txtTipoLogradouro.Text = String.Empty;
    }
    /// <summary>
    /// Remove todos ViewStates
    /// </summary>
    public void removeViewStates()
    {
        ViewState.Remove("codFamilia");
        ViewState.Remove("codFormaCopa");
        ViewState.Remove("codGenero");
        ViewState.Remove("codParasita");
        ViewState.Remove("codGrupoParasita");
        ViewState.Remove("codLocalAfetado");
        ViewState.Remove("codIntensidade");
        ViewState.Remove("codAcaoRec");
        ViewState.Remove("codAcaoRecomendada");
        ViewState.Remove("codLocalEntorno");
        ViewState.Remove("codParticipacao");
        ViewState.Remove("codPavimento");
        ViewState.Remove("codTipoLogradouro");
    }

    #endregion

}
