using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class admin_minhaConta : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    /// <summary>
    /// Load da pagina
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetCidadeVerde.tblUsuarioDataTable dtUsuario = cv.buscaUsuarioByCodUsuario(CodUsuario);
            ViewState["nome"] = txtNome.Text = dtUsuario[0].sNome;
            ViewState["cpf"] = txtCPF.Text = dtUsuario[0].sCPF;
            ViewState["telefone"] = txtTelefone.Text = dtUsuario[0].sTelefone;
            ViewState["email"] = txtEmail.Text = dtUsuario[0].sEmail;
            ViewState["senha"] = dtUsuario[0].sSenha;
            ViewState["usuario"] = LabelUsuarioDadosPessoais.Text = LabelUsuarioAlterarSenha.Text = dtUsuario[0].sLogin;

            ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosPessoais');", true);
        }
    }
    /// <summary>
    /// Salvar edição dados pessoais
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarDadosPessoais_Click(object sender, EventArgs e)
    {
        PanelConfirmaSenha.Visible = false;
        LabelDadosPessoaisErro.Visible = LabelDadosPessoaisOk.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtNome.Text.Trim()))
                throw new Exception("Digite o Nome!");
            if (String.IsNullOrEmpty(txtCPF.Text.Trim()))
                throw new Exception("Digite o CPF!");
            //else if (!ValidaCPF(txtCPF.Text.Trim()))
            //    throw new Exception("CPF Inválido!");
            if (String.IsNullOrEmpty(txtTelefone.Text.Trim()))
                throw new Exception("Digite o Telefone!");
            if (String.IsNullOrEmpty(txtEmail.Text.Trim()))
                throw new Exception("Digite o E-mail!");
            else if (!ValidaEmail(txtEmail.Text.Trim()))
                throw new Exception("E-mail Inválido!");

            cv.atualizaMeusDados(txtCPF.Text.Trim(), txtNome.Text.Trim(), txtEmail.Text.Trim(), txtTelefone.Text.Trim(), CodUsuario);

            ViewState["nome"] = txtNome.Text.Trim();
            ViewState["cpf"] = txtCPF.Text.Trim();
            ViewState["telefone"] = txtTelefone.Text.Trim();
            ViewState["email"] = txtEmail.Text.Trim();

            ImageConfirmaDadosPessoais.ImageUrl = "~/images/confirmation32.png";
            LabelDadosPessoaisOk.Visible = true;
            txtSenhaAntiga.Text = txtNovaSenha.Text = txtRepitaNovaSenha.Text = String.Empty;
        }
        catch (Exception ex)
        {
            ImageConfirmaDadosPessoais.ImageUrl = "~/images/exclamation32.png";
            LabelDadosPessoaisErro.Text = ex.Message;
            LabelDadosPessoaisErro.Visible = true;
        }
        PanelConfirmaDadosArvore.Visible = true;
        //LabelUsuario.Text = "Olá, " + NomeCompleto;// + NomeCompleto + CodUsuario;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosPessoais');", true);
    }
    /// <summary>
    /// Cancelar Edição dos dados pessoais
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarDadosPessoais_Click(object sender, EventArgs e)
    {
        PanelConfirmaDadosArvore.Visible = false;
        PanelConfirmaSenha.Visible = false;
        txtNome.Text = ViewState["nome"].ToString();
        txtCPF.Text = ViewState["cpf"].ToString();
        txtTelefone.Text = ViewState["telefone"].ToString();
        txtEmail.Text = ViewState["email"].ToString();
        txtSenhaAntiga.Text = txtNovaSenha.Text = txtRepitaNovaSenha.Text = String.Empty;

        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosPessoais');", true);
    }
    /// <summary>
    /// Alterar senha do Usuário
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btSalvarSenha_Click(object sender, EventArgs e)
    {
        PanelConfirmaDadosArvore.Visible = false;
        LabelSenhaOK.Visible = false;
        LabelSenhaErro.Visible = false;
        try
        {
            if (String.IsNullOrEmpty(txtSenhaAntiga.Text))
                throw new Exception("Digite a Senha Antiga!");
            if (String.IsNullOrEmpty(txtNovaSenha.Text))
                throw new Exception("Digite a Nova Senha!");
            if (String.IsNullOrEmpty(txtRepitaNovaSenha.Text))
                throw new Exception("Digite Confirmação da Senha!");
            if (!txtSenhaAntiga.Text.Trim().Equals(ViewState["senha"].ToString()))
                throw new Exception("Senha Antiga Inválida!");
            if (!txtNovaSenha.Text.Trim().Equals(txtRepitaNovaSenha.Text.Trim()))
                throw new Exception("Nova Senha e Confirmação de Senha não Coincidem!");

            cv.atualizaMinhaSenhaByCodUsuario(txtNovaSenha.Text.Trim(), CodUsuario);

            //Atualiza a Senha no Acesso a Paginas
            AcessoRestrito acesso = new AcessoRestrito(ViewState["usuario"].ToString(), txtNovaSenha.Text.Trim());
            if (!acesso.login(ViewState["usuario"].ToString(), txtNovaSenha.Text.Trim()))
                throw new Exception("Login ou senha inválidos!");

            ViewState["senha"] = txtNovaSenha.Text.Trim();
            ImageConfirmaSenha.ImageUrl = "~/images/confirmation32.png";
            LabelSenhaOK.Visible = true;
            txtSenhaAntiga.Text = txtNovaSenha.Text = txtRepitaNovaSenha.Text = String.Empty;
        }
        catch (Exception ex)
        {
            ImageConfirmaSenha.ImageUrl = "~/images/exclamation32.png";
            LabelSenhaErro.Text = ex.Message;
            LabelSenhaErro.Visible = true;
        }
        PanelConfirmaSenha.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaAlterarSenha');", true);
    }
    /// <summary>
    /// Cancelar Edição de Senha
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btCancelarSenha_Click(object sender, EventArgs e)
    {
        txtSenhaAntiga.Text = txtNovaSenha.Text = txtRepitaNovaSenha.Text = String.Empty;
        PanelConfirmaDadosArvore.Visible = false;
        PanelConfirmaSenha.Visible = false;

        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaAlterarSenha');", true);
    }

    #region METODOS DE VALIDAÇÃO

    /// <summary>
    /// Verifica Se O Email É Valido
    /// </summary>
    /// <param name="email">Email a Ser Verificado</param>
    /// <returns>True = Email Valido, False = Email Invalido</returns>
    public Boolean ValidaEmail(String email)
    {
        try
        {
            //Valida o email
            if (Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                return true;
            throw new Exception();
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica Se O CPF É Valido
    /// </summary>
    /// <param name="cpf">CPF a Ser Verificado</param>
    /// <returns>True = CPF Valido, False = CPF Invalido</returns>
    public Boolean ValidaCPF(String cpf)
    {
        try
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || cpf.ToCharArray().Distinct().ToArray().Length == 1)
                throw new Exception();
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica Se o CNPJ É Valido
    /// </summary>
    /// <param name="vrCNPJ">CNPJ a Ser Verificado</param>
    /// <returns>True = CNPJ Valido, False = CNPJ Invalido</returns>
    public Boolean ValidaCNPJ(String vrCNPJ)
    {
        try
        {
            string CNPJ = vrCNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
            if (CNPJ.Length != 14 || CNPJ.ToCharArray().Distinct().ToArray().Length == 1)
                throw new Exception();
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;
            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;
            for (nrDig = 0; nrDig < 14; nrDig++)
            {
                digitos[nrDig] = int.Parse(
                    CNPJ.Substring(nrDig, 1));
                if (nrDig <= 11)
                    soma[0] += (digitos[nrDig] *
                      int.Parse(ftmt.Substring(
                       nrDig + 1, 1)));
                if (nrDig <= 12)
                    soma[1] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(
                        nrDig, 1)));
            }
            for (nrDig = 0; nrDig < 2; nrDig++)
            {
                resultado[nrDig] = (soma[nrDig] % 11);
                if ((resultado[nrDig] == 0) || (
                    resultado[nrDig] == 1))
                    CNPJOk[nrDig] = (
                    digitos[12 + nrDig] == 0);
                else
                    CNPJOk[nrDig] = (
                    digitos[12 + nrDig] == (
                    11 - resultado[nrDig]));
            }
            return (CNPJOk[0] && CNPJOk[1]);
        }
        catch
        {
            return false;
        }
    }
    #endregion
}
