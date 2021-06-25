using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginAntigo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsuario.Focus();
    }
    protected void btEntrar_Click(object sender, EventArgs e)
    {
        try
        {
            PanelErroLogin.Visible = false;
            if (String.IsNullOrEmpty(txtUsuario.Text.Trim()))
                throw new Exception("Digite o usuário!");
            if (String.IsNullOrEmpty(txtSenha.Text.Trim()))
                throw new Exception("Digite a senha!");
            AcessoRestrito acesso = new AcessoRestrito(txtUsuario.Text.Trim(), txtSenha.Text.Trim());
            if (!acesso.login(txtUsuario.Text.Trim(), txtSenha.Text.Trim()))
                throw new Exception("Usuário ou Senha Inválidos!");
            // Acessa a pagina inicial da admin
            HttpContext.Current.Response.Redirect("~/admin/inicio.aspx");
        }
        catch (Exception err)
        {
            LabelErroLogin.Text = err.Message;
            PanelErroLogin.Visible = true;
            txtUsuario.Focus();
        }
    }
}
