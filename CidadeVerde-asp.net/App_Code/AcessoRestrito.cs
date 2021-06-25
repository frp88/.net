using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
/// <summary>
/// Summary description for AcessoRestrito
/// </summary>
public class AcessoRestrito : System.Web.UI.Page
{
    //propriedade privada
    private Boolean isLogado = false;

    /// <summary>
    /// Instancia propriedade logado
    /// </summary>
    public Boolean IsLogado
    {
        get { return isLogado; }
        set { isLogado = value; }
    }

    private String _NomeCompleto;
    private Int32 _CodUsuario;
    private Int32 _TipoUsuario;

    /// <summary>
    /// Instancia o Nome do Usuario
    /// </summary>
    public String NomeCompleto
    {
        get
        {

            try
            {
                HttpCookie loginStatus = HttpContext.Current.Request.Cookies[("LoginStatus").ToBase64Encode()];
                HttpCookie loginSenha = HttpContext.Current.Request.Cookies[("LoginSenha").ToBase64Encode()];
                if (loginStatus != null && loginSenha != null)
                {
                    CidadeVerde cv = new CidadeVerde();
                    DataSetCidadeVerde.tblUsuarioDataTable dtUser = cv.buscaUsuarioByLoginSenha(loginStatus.Value.ToBase64Decode(), loginSenha.Value.ToBase64Decode());
                    if (dtUser.Count > 0)
                    {
                        NomeCompleto = dtUser[0].sNome;
                        TipoUsuario = dtUser[0].nTipo;
                    }
                    else
                        throw new Exception();
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {

                NomeCompleto = String.Empty;
            }

            return _NomeCompleto;
        }
        private set { _NomeCompleto = value; }
    }

    /// <summary>
    /// Instancia o Codigo do Usuario
    /// </summary>
    public Int32 CodUsuario
    {
        get
        {
            try
            {
                HttpCookie loginStatus = HttpContext.Current.Request.Cookies[("LoginStatus").ToBase64Encode()];
                HttpCookie loginSenha = HttpContext.Current.Request.Cookies[("LoginSenha").ToBase64Encode()];
                if (loginStatus != null && loginSenha != null)
                {
                    CidadeVerde cv = new CidadeVerde();
                    DataSetCidadeVerde.tblUsuarioDataTable dtUser = cv.buscaUsuarioByLoginSenha(loginStatus.Value.ToBase64Decode(), loginSenha.Value.ToBase64Decode());
                    if (dtUser.Count > 0)
                        CodUsuario = dtUser[0].codUsuario;
                    else
                        throw new Exception();
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                CodUsuario = 0;
            }

            return _CodUsuario;
        }
        private set { _CodUsuario = value; }
    }

    /// <summary>
    /// Instancia o Tipo do Usuario
    /// </summary>
    public Int32 TipoUsuario
    {
        get
        {
            try
            {
                HttpCookie loginStatus = HttpContext.Current.Request.Cookies[("LoginStatus").ToBase64Encode()];
                HttpCookie loginSenha = HttpContext.Current.Request.Cookies[("LoginSenha").ToBase64Encode()];
                if (loginStatus != null && loginSenha != null)
                {
                    CidadeVerde cv = new CidadeVerde();
                    DataSetCidadeVerde.tblUsuarioDataTable dtUser = cv.buscaUsuarioByLoginSenha(loginStatus.Value.ToBase64Decode(), loginSenha.Value.ToBase64Decode());
                    if (dtUser.Count > 0)
                        TipoUsuario = dtUser[0].nTipo;
                    else
                        throw new Exception();
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                TipoUsuario = 0;
            }

            return _TipoUsuario;
        }
        private set { _TipoUsuario = value; }
    }


    /// <summary>
    /// Metodo Construtor
    /// </summary>
    public AcessoRestrito()
    {
        HttpCookie loginStatus = HttpContext.Current.Request.Cookies[("LoginStatus").ToBase64Encode()];
        HttpCookie loginSenha = HttpContext.Current.Request.Cookies[("LoginSenha").ToBase64Encode()];
        if (loginStatus != null && loginSenha != null)
        {
            CidadeVerde cv = new CidadeVerde();
            if (cv.buscaUsuarioByLoginSenha(loginStatus.Value.ToBase64Decode(), loginSenha.Value.ToBase64Decode()).Count > 0)
                IsLogado = true;
            else
                logout();
        }

        if (!IsLogado)
        {
            HttpContext.Current.Response.Redirect("~/login.aspx");
        }
    }
    /// <summary>
    /// Metodo Construtor verificando o login e a senha
    /// </summary>
    /// <param name="usuario"></param>
    /// <param name="senha"></param>
    public AcessoRestrito(String usuario, String senha)
    {
        login(usuario, senha);
    }

    /// <summary>
    /// Faz login no Sistema
    /// </summary>
    /// <param name="usuario"></param>
    /// <param name="senha"></param>
    /// <returns></returns>
    public Boolean login(String usuario, String senha)
    {
        try
        {
            //verifica o login e a senha do usuario
            CidadeVerde cv = new CidadeVerde();
            DataSetCidadeVerde.tblUsuarioDataTable dtUser = cv.buscaUsuarioByLoginSenha(usuario, senha);
            if (dtUser.Count == 0)
                throw new Exception();

            //HttpCookie loginstatus = new HttpCookie("LoginStatus", "TESTEEEEEEEEEEEEEEE");
            IsLogado = true;
            HttpCookie loginStatus = new HttpCookie(("LoginStatus").ToBase64Encode(), dtUser[0].sLogin.ToBase64Encode());
            HttpCookie loginSenha = new HttpCookie(("LoginSenha").ToBase64Encode(), dtUser[0].sSenha.ToBase64Encode());

            HttpContext.Current.Response.Cookies.Add(loginStatus);
            HttpContext.Current.Response.Cookies.Add(loginSenha);

            return true;
        }
        catch (Exception)
        {
            IsLogado = false;

            HttpCookie loginstatus = new HttpCookie(("LoginStatus").ToBase64Encode(), "null");
            loginstatus.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(loginstatus);

            HttpCookie loginsenha = new HttpCookie(("LoginSenha").ToBase64Encode(), "null");
            loginsenha.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(loginsenha);

            return false;
        }
    }

    /// <summary>
    /// Faz logout no sistema
    /// </summary>
    public void logout()
    {
        IsLogado = false;

        HttpCookie loginstatus = new HttpCookie(("LoginStatus").ToBase64Encode(), "null");
        loginstatus.Expires = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.Cookies.Add(loginstatus);

        HttpCookie loginsenha = new HttpCookie(("LoginSenha").ToBase64Encode(), "null");
        loginsenha.Expires = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.Cookies.Add(loginsenha);

        HttpContext.Current.Response.Redirect("~/login.aspx");
    }
}
