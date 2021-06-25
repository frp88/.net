using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_cadastroUsuario : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridViewUsuarios.DataSource = cv.buscaUsuarios();
            GridViewUsuarios.DataBind();
        }
    }
    #endregion

    #region PANEL GRID USUÁRIOS
    /// <summary>
    /// Mostra a Tela de Cadastro de Usuarios
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            if (TipoUsuario > 2)
                throw new Exception("Usuário não tem permissão para Cadastrar<br />Usuário!");

            habilitaCamposCad(true);
            PanelVerUsuarios.Visible = false;
            PanelCadUsuario.Visible = true;
            ViewState.Remove("codUsuario");
        }
        catch (Exception err)
        {
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = err.Message;
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
    }

    /// <summary>
    /// Botao filtrar os Usuarios do sistema
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFiltrar_Click(object sender, EventArgs e)
    {
        populaGridUsuario();
    }
    /// <summary>
    /// Popula o gridViewUsuarios
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image status = (Image)e.Row.Cells[2].FindControl("ImageTipoUsuario");
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 1: // Master
                        status.ToolTip = "Master";
                        status.ImageUrl = "~/images/userMaster.png";
                        break;
                    case 2: // Administrador
                        status.ToolTip = "Administrador";
                        status.ImageUrl = "~/images/userAdmin.png";
                        break;
                    default: //Caso 1 - Usuário
                        status.ToolTip = "Usuário";
                        status.ImageUrl = "~/images/userUsuario.png";
                        break;
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[9].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir o Usuário?');");
            }
            e.Row.Cells[0].Visible = false; // codUsuario
            e.Row.Cells[1].Visible = false; // nTipo Usuario
        }
    }
    /// <summary>
    /// Visualiza os Dados de um determinado Usuario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);

            // Obtem Linha Especifica
            GridViewRow linha = GridViewUsuarios.Rows[indice];

            //// Obtem ID da Conta
            Int32 codUsuario = Convert.ToInt32(linha.Cells[0].Text.Trim());
            ViewState["sLogin"] = linha.Cells[5].Text.Trim();
            Int32 usuarioSelecionado = Convert.ToInt32(ViewState["tipoUsuario"] = linha.Cells[1].Text.Trim());

            if (usuarioSelecionado == 1)
                throw new Exception("Não é possível editar esse Usuário!<br /> Usuário Master.");

            if (TipoUsuario > 2)
                throw new Exception("Usuário não tem permissão para editar<br />os Dados do Usuário!");

            if (e.CommandName.Equals("editarUsuario"))
            {
                ViewState["codUsuario"] = codUsuario.ToString();
                habilitaCamposCad(false);
                LabelLogin.Text = ViewState["sLogin"].ToString();
                txtNome.Text = linha.Cells[4].Text.Trim();
                txtCPF.Text = linha.Cells[3].Text.Trim();
                txtEmail.Text = linha.Cells[6].Text.Trim();
                txtTelefone.Text = linha.Cells[7].Text.Trim();
                ddlTipoUsuario.SelectedValue = linha.Cells[1].Text.Trim();
                PanelVerUsuarios.Visible = false;
                PanelCadUsuario.Visible = true;
            }
            if (e.CommandName.Equals("excluirUsuario"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />o Usuário!");
                    if (!cv.deletaUsuario(codUsuario))
                        throw new Exception("Não é possível excluir o Usuário!");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Usuário excluído com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewUsuarios.DataSource = cv.buscaUsuarios();
                    GridViewUsuarios.DataBind();
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
        catch (Exception err)
        {
            //   ScriptManager.RegisterStartupScript(this, GetType(), "cadDoenca", "javascript: alert('" + err.Message + "');", true);
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = err.Message;
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
    }
    /// <summary>
    /// Muda de página no GridViewArvores
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewUsuarios.PageIndex = e.NewPageIndex;
    }


    #endregion

    #region PANEL CADASTRO / ATUALIZAÇÃO USUÁRIO
    /// <summary>
    /// Volta para a Tela do Grid de Usuarios
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVoltarVerUsuarios_Click(object sender, EventArgs e)
    {
        LimpaDadosUsuario();
        populaGridUsuario();
        PanelCadUsuario.Visible = false;
        PanelVerUsuarios.Visible = true;
        ViewState.Remove("codUsuario");
    }
    /// <summary>
    /// Reinicia a senha de um determinado Usuario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btReiniciarSenha_Click(object sender, EventArgs e)
    {
        cv.atualizaSenhaByCodUsuario(Convert.ToInt32(ViewState["codUsuario"].ToString()));
        LabelMsgReiniciaSenha.Visible = true;
    }
    /// <summary>
    /// Verifica a disponibilidade do Login desejado
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btVerificarDisponibilidade_Click(object sender, EventArgs e)
    {
        try
        {
            if (String.IsNullOrEmpty(txtLogin.Text.Trim()))
                throw new Exception("Digite o login desejado!");
            if (!cv.verificaDisponibilidadeLogin(txtLogin.Text.Trim()))
                throw new Exception("Login já cadastrado!");
            LabelLoginCadastrado.Visible = false;
            LabelLoginDisponivel.Visible = true;
        }
        catch (Exception err)
        {
            LabelLoginCadastrado.Text = err.Message;
            LabelLoginDisponivel.Visible = false;
            LabelLoginCadastrado.Visible = true;
        }
        LabelMsgReiniciaSenha.Visible = false;
        PanelConfirmaUsuario.Visible = false;
    }
    /// <summary>
    /// Cadastra / atualiza um Usuario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarUsuario_Click(object sender, EventArgs e)
    {
        LabelConfirmaUsuario.Visible = false;
        LabelErroUsuario.Visible = false;
        try
        {
            if (ViewState["codUsuario"] == null)
                if (String.IsNullOrEmpty(txtLogin.Text.Trim()))
                    throw new Exception("Digite o login desejado!");
            if (!cv.verificaDisponibilidadeLogin(txtLogin.Text.Trim()))
                throw new Exception("Login já cadastrado!");
            if (String.IsNullOrEmpty(txtNome.Text.Trim()))
                throw new Exception("Digite o Nome!");
            if (String.IsNullOrEmpty(txtCPF.Text.Trim()))
                throw new Exception("Digite o CPF!");
            if (String.IsNullOrEmpty(txtEmail.Text.Trim()))
                throw new Exception("Digite o E-mail!");
            if (String.IsNullOrEmpty(txtTelefone.Text.Trim()))
                throw new Exception("Digite o Telefone!");
            if (ddlTipoUsuario.SelectedIndex == 0)
                throw new Exception("Selecione o Tipo do Usuário!");
            if (ViewState["codUsuario"] == null)
            {
                if (!cv.InsereUsuario(txtCPF.Text.Trim(), txtNome.Text.Trim(), txtLogin.Text.Trim(), Convert.ToInt32(ddlTipoUsuario.SelectedValue),
                    txtEmail.Text.Trim(), txtTelefone.Text.Trim()))
                    throw new Exception("Erro no Cadastro de Usuário!");
                LabelConfirmaUsuario.Text = "Usuário cadastrado com sucesso!";
                LimpaDadosUsuario();
            }
            else
            {
                if (!cv.atualizaUsuarioByCodUsuario(txtCPF.Text.Trim(), txtNome.Text.Trim(), Convert.ToInt32(ddlTipoUsuario.SelectedValue),
                    txtEmail.Text.Trim(), txtTelefone.Text.Trim(), Convert.ToInt32(ViewState["codUsuario"].ToString())))
                    throw new Exception("Erro de Atualização do Usuário!");
                LabelConfirmaUsuario.Text = "Usuário atualizado com sucesso!";
                LabelTituloLogin.Visible = true;
                LabelLogin.Text = ViewState["sLogin"].ToString();
                LabelLogin.Visible = true;
            }
            ImageConfirmaUsuario.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaUsuario.Visible = true;
            ViewState.Remove("codUsuario");
        }
        catch (Exception err)
        {
            if (ViewState["codUsuario"] != null)
                LabelLogin.Text = ViewState["sLogin"].ToString();
            ImageConfirmaUsuario.ImageUrl = "~/images/exclamation32.png";
            LabelErroUsuario.Text = err.Message;
            LabelErroUsuario.Visible = true;
        }
        PanelConfirmaUsuario.Visible = true;
    }
    /// <summary>
    /// Cancela o cadastro / atualização de uma Injuria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarUsuario_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codUsuario");
        PanelConfirmaUsuario.Visible = false;
    }

    protected void populaGridUsuario()
    {
        if (String.IsNullOrEmpty(txtFiltro.Text.Trim()))
            GridViewUsuarios.DataSource = cv.buscaUsuarios();
        else
        {
            Int64 aux = 0;
            if (Int64.TryParse(txtFiltro.Text.Trim(), out aux))
                GridViewUsuarios.DataSource = cv.buscaUsuarioBysCPF(txtFiltro.Text.Trim());
            else
                GridViewUsuarios.DataSource = cv.buscaUsuarioBysNome(txtFiltro.Text.Trim());
        }
        GridViewUsuarios.DataBind();
    }
    /// <summary>
    /// Lima campos da tela cadastra / atualiza Injuria
    /// </summary>
    protected void LimpaDadosUsuario()
    {
        txtLogin.Text = String.Empty;
        txtNome.Text = String.Empty;
        txtCPF.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtTelefone.Text = String.Empty;
        ddlTipoUsuario.SelectedIndex = 0;
        LabelLogin.Visible = false;
        LabelMsgReiniciaSenha.Visible = false;
        LabelLoginCadastrado.Visible = false;
        LabelLoginDisponivel.Visible = false;
        PanelConfirmaUsuario.Visible = false;
        ViewState.Remove("codUsuario");
        ViewState.Remove("sLogin");
        ViewState.Remove("tipoUsuario");
        habilitaCamposCad(true);
    }
    /// <summary>
    /// Habilita Labels, TextBox e Botoes para cadastro
    /// </summary>
    protected void habilitaCamposCad(Boolean habilita)
    {
        if (habilita)
        {
            LabelTitulo.Text = "Cadastrar Usuário";
            btReiniciarSenha.Visible = false;
            LabelTituloLogin.Visible = false;
            LabelLogin.Visible = false;
            txtLogin.Visible = true;
            btVerificarDisponibilidade.Visible = true;
        }
        else
        {
            LabelTitulo.Text = "Atualizar Usuário";
            btReiniciarSenha.Visible = true;
            LabelTituloLogin.Visible = true;
            LabelLogin.Visible = true;
            LabelCadLogin.Visible = false;
            txtLogin.Visible = false;
            btVerificarDisponibilidade.Visible = false;
        }
    }
    #endregion
}
