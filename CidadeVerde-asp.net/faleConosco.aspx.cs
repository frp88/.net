using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;

public partial class faleConosco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtArvore.Text = Request.QueryString["cod"];
    }
    protected void btEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            String nomeArquivo = String.Empty;
            // Define nome do arquivo e seu caminho completo
            nomeArquivo = FileUploadArquivo.PostedFile.FileName;

            if (String.IsNullOrEmpty(txtNomeRemetente.Text))
                throw new Exception("Digite o Nome!");
            if (String.IsNullOrEmpty(txtEmailRemetente.Text))
                throw new Exception("Digite o E-mail!");
            if (!String.IsNullOrEmpty(txtEmailRemetente.Text))
                if (!ValidaEmail(txtEmailRemetente.Text.Trim()))
                {
                    txtEmailRemetente.Focus();
                    throw new Exception("E-mail Inválido!");
                }
            if (String.IsNullOrEmpty(txtAssunto.Text))
                throw new Exception("Digite o Assunto!");
            if (String.IsNullOrEmpty(txtMensagem.Text))
                throw new Exception("Digite a Mensagem!");

            ////Fim da validação dos campos
            //String emailDestinatario = "cidadeverdepassos@gmail.com";
            //String senhaDestinatario = "arvore2010";

            //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            //mail.To.Add(emailDestinatario);
            //mail.From = new MailAddress(emailDestinatario, "E-mail do Site", System.Text.Encoding.UTF8);
            //mail.Subject = txtAssunto.Text.Trim();
            //mail.SubjectEncoding = System.Text.Encoding.UTF8;
            //mail.Body = "<strong>Nome:</strong> " + txtNomeRemetente.Text.Trim() +
            //    "<br /><br /><strong>E-mail:</strong> " + txtEmailRemetente.Text.Trim() +
            //    "<br /><br />" + "<strong>Código da Árvore:</strong> " + txtArvore.Text.Trim() +
            //    "<br /><br /><strong>Mensagem:</strong> " + txtMensagem.Text;

            //if (!String.IsNullOrEmpty(nomeArquivo))
            //    mail.Attachments.Add(new Attachment(FileUploadArquivo.PostedFile.InputStream, nomeArquivo));

            //mail.BodyEncoding = System.Text.Encoding.UTF8;
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High; //prioridade do e-mail
            //SmtpClient cliente = new SmtpClient();  //adicionando as credenciais do seu e-mail e senha:

            //cliente.Credentials = new System.Net.NetworkCredential(emailDestinatario, senhaDestinatario);
            //cliente.Port = 587; // esta porta é a utilizada pelo gmail para envio
            //cliente.Host = "smtp.gmail.com"; //definindo o provedor que irá disparar o e-mail
            //cliente.EnableSsl = true; //gmail trabalha com server secured layer

            //Envia o E-mail
            //cliente.Send(mail);

            enviaEmail(txtNomeRemetente.Text.Trim(), txtEmailRemetente.Text.Trim(), "fernando.proenca@fespmg.edu.br", txtArvore.Text.Trim(), txtAssunto.Text.Trim(), txtMensagem.Text.Trim(), nomeArquivo);

            LabelConfirma.ForeColor = System.Drawing.Color.FromName("#056d00");
            LabelConfirma.Text = "E-mail enviado com sucesso";
            txtNomeRemetente.Text = String.Empty;
            txtEmailRemetente.Text = String.Empty;
            txtAssunto.Text = String.Empty;
            txtMensagem.Text = String.Empty;
            ImageConfirma.ImageUrl = "~/images/confirmation32.png";
            PanelConfirma.Visible = true;
        }
        catch (Exception err)
        {
            ImageConfirma.ImageUrl = "~/images/exclamation32.png";
            LabelConfirma.ForeColor = System.Drawing.Color.Red;//FromName("#CC0000");
            LabelConfirma.Text = err.Message;//"Ocorreu um erro ao enviar o e-mail.";
            PanelConfirma.Visible = true;
        }
    }

    /// <summary>
    /// Limpa todos os campos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btLimpar_Click(object sender, EventArgs e)
    {
        txtNomeRemetente.Text = String.Empty;
        txtEmailRemetente.Text = String.Empty;
        txtArvore.Text = String.Empty;
        txtAssunto.Text =
        txtMensagem.Text = String.Empty;
        PanelConfirma.Visible = false;
    }

    #region E-MAIL

    /// <summary>
    /// ENVIAR E-MAIL
    /// </summary>
    /// <param name="nome"></param>
    /// <param name="emailEmissor"></param>
    /// <param name="emailReceptor"></param>
    /// <param name="codArvore"></param>
    /// <param name="assunto"></param>
    /// <param name="mensagem"></param>
    /// <param name="arquivo"></param>
    /// <returns></returns>
    public Boolean enviaEmail(String nome, String emailEmissor, String emailReceptor, String codigoArvore, String assunto, String mensagem, String arquivo)
    {
        try
        {
            string CorpoEmail = "" + "<br /><strong>Data:</strong> " + DateTime.UtcNow.ToString() + "<br /><strongNome:</strong> "
                + nome + "<br /><strong>E-Mail:</strong> " + emailEmissor + (String.IsNullOrEmpty(codigoArvore) ? "" : "<br /><strong>Código Árvore:</strong> " + codigoArvore)
            + "<br><strong>Assunto:</strong> " + assunto + "<br><strong>Mensagem:</strong> " + mensagem;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailEmissor);
            mailMessage.To.Add(emailReceptor);
            // mailMessage.CC.Add("CopiarEmailPara@MinhaEmpresa.com.br");
            // Assunto
            mailMessage.Subject = assunto;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            // A mensagem é do tipo HTML(true) ou Texto Puro (false)?   
            mailMessage.IsBodyHtml = true;
            // Corpo da Mensagem, conteudo da variavel criada acima
            mailMessage.Body = CorpoEmail.ToString();

            //Arquivo
            if (!String.IsNullOrEmpty(arquivo))
                mailMessage.Attachments.Add(new Attachment(FileUploadArquivo.PostedFile.InputStream, arquivo));

            SmtpClient smtpClient = new SmtpClient("mail.fespmg.edu.br");
            // Envia a mensagem   
            smtpClient.Send(mailMessage);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

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

    #endregion
}
