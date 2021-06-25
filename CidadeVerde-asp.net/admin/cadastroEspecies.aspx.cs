using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;

public partial class admin_cadastroEspecies : AcessoRestrito
{
    CidadeVerde cv = new CidadeVerde();
    private String PathServidor = @"~/fotos/especies/";
    private String PathFotosTemp = String.Empty;

    #region LOAD DA PÁGINA
    protected void Page_Load(object sender, EventArgs e)
    {
        PathServidor = Server.MapPath("~/fotos/especies");
        PathFotosTemp = Server.MapPath("~/fotos/especies/temp");
        if (!IsPostBack)
        {
            ViewState["sorteio"] = "DESC";
            FiltraEspecies();
            montaCampos();
            HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasEspecies.aspx";
        }
    }
    #endregion

    #region LISTA DE ESPÉCIES
    /// <summary>
    /// Função para filtrar as espécies
    /// </summary>
    protected void FiltraEspecies()
    {
        GridViewEspecies.PageSize = Convert.ToInt32(ddlMostrarEspecie.SelectedValue);
        if (String.IsNullOrEmpty(txtFitroNomeCientifico.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;
            switch (rbRecEspecie.SelectedValue)
            {
                case "1":
                    GridViewEspecies.DataSource = cv.buscaEspecieBynRecArborizacaoUrbana(1);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelEspeciesRecomendadas.aspx";
                    break;
                case "2":
                    GridViewEspecies.DataSource = cv.buscaEspecieBynRecArborizacaoUrbana(2);
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelEspeciesNaoRecomendadas.aspx";
                    break;
                default:
                    GridViewEspecies.DataSource = cv.buscaEspecies();
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasEspecies.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            GridViewEspecies.DataSource = cv.buscaEspecieBysNomeCientifico(txtFitroNomeCientifico.Text.Trim());
        }
        GridViewEspecies.DataBind();
    }
    /// <summary>
    /// Ordena pela coluna clicada do grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewEspecies_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewEspecies.PageSize = Convert.ToInt32(ddlMostrarEspecie.SelectedValue);
        if (ViewState["sorteio"] != null)
        {
            if (ViewState["sorteio"].ToString().Equals("ASC"))
                ViewState["sorteio"] = "DESC";
            else
                ViewState["sorteio"] = "ASC";
        }
        if (String.IsNullOrEmpty(txtFitroNomeCientifico.Text.Trim()))
        {
            HyperLinkImprimir.Visible = true;
            switch (rbRecEspecie.SelectedValue)
            {
                case "1":
                    GridViewEspecies.DataSource = cv.buscaEspecieBynRecArborizacaoUrbana(1).Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelEspeciesRecomendadas.aspx";
                    break;
                case "2":
                    GridViewEspecies.DataSource = cv.buscaEspecieBynRecArborizacaoUrbana(2).Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelEspeciesNaoRecomendadas.aspx";
                    break;
                default:
                    GridViewEspecies.DataSource = cv.buscaEspecies().Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
                    HyperLinkImprimir.NavigateUrl = "~/admin/relatorios/excelTodasEspecies.aspx";
                    break;
            }
        }
        else
        {
            HyperLinkImprimir.Visible = false;
            GridViewEspecies.DataSource = cv.buscaEspecieBysNomeCientifico(txtFitroNomeCientifico.Text.Trim()).Select("", e.SortExpression + " " + ViewState["sorteio"].ToString());
        }

        GridViewEspecies.DataBind();
    }
    /// <summary>
    /// Popula GridViewEspecies
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewEspecies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Image status = (Image)e.Row.Cells[2].FindControl("ImageRecEspecie");
                switch (Convert.ToInt32(e.Row.Cells[1].Text.Trim()))
                {
                    case 2: // Especie Não Recomendada
                        e.Row.Cells[2].ToolTip = "Espécie Não Recomendada";
                        e.Row.Cells[2].Text = "<img src='../images/negativo.png' />";
                        //status.ToolTip = "Espécie Não Recomendada";
                        //status.ImageUrl = "~/images/negativo.png";
                        break;
                    default: //Caso 1 - Especie Recomendada
                        e.Row.Cells[2].ToolTip = "Espécie Recomendada";
                        e.Row.Cells[2].Text = "<img src='../images/positivo.png' />";
                        //status.ToolTip = "Espécie Recomendada";
                        //status.ImageUrl = "~/images/positivo.png";
                        break;
                }
                //e.Row.Cells[8].Text = e.Row.Cells[8].Text.Trim().Equals("1") ? "Sim" : "Não";
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));

                e.Row.Cells[11].Attributes.Add("onclick", "javascript: return " + "confirm('Deseja Realmente Excluir a Espécie?');");
            }
            e.Row.Cells[0].Visible = false; // codEspécie
            e.Row.Cells[1].Visible = false; // nRecArborizacaoUrbana
            e.Row.Cells[4].Visible = false; // codGenero
        }
    }

    /// <summary>
    /// Mostra detalhes da Espécie e seus Nomes Populares
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewEspecies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);
            // Obtem Linha Especifica
            GridViewRow linha = GridViewEspecies.Rows[indice];
            //// Obtem ID da Conta
            Int32 codEspecie = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("verDetEspecie"))
            {
                ViewState["codEspecie"] = codEspecie.ToString();
                GridViewNomesPopulares.DataSource = cv.buscaNomePopularByCodEspecie(codEspecie);
                GridViewNomesPopulares.DataBind();
                ddlTipoRaiz.SelectedIndex = 0;
                populaDadosEspecie(codEspecie);
                PanelConfirmaEspecie.Visible = false;
                PanelConfirmaNomesComuns.Visible = false;
                panelVerEspecies.Visible = false;
                PanelAdminEspecie.Visible = true;
                iniciaImagem();
                ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
            }
            if (e.CommandName.Equals("excluirEspecie"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Espécie!");
                    ViewState.Remove("codEspecie");
                    if (!cv.deletaEspecie(codEspecie))
                        throw new Exception("Não é possível excluir a Espécie! <br />Existe registros na tabela Árvore e/ou na<br />tabela Nome Popular.");
                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Espécie excluída com Sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
                    GridViewEspecies.DataSource = cv.buscaEspecies();
                    GridViewEspecies.DataBind();
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
        ViewState.Remove("codNomePopular");
    }
    /// <summary>
    /// Alterna entre paginas da lista de Especies
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewEspecies_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewEspecies.PageIndex = e.NewPageIndex;
        GridViewEspecies.DataSource = cv.buscaEspecies();
        GridViewEspecies.DataBind();
    }
    /// <summary>
    /// Seleciona a Situação para o Filtro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbRecEspecie_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFitroNomeCientifico.Text = String.Empty;
        FiltraEspecies();
    }
    /// <summary>
    /// Filtra as Especies pelo nome cientifico
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btFiltrar_Click(object sender, EventArgs e)
    {
        FiltraEspecies();
    }
    /// <summary>
    /// Escolhe a quantidade de Especies que será mostrada na tela
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMostrarEspecie_SelectedIndexChanged(object sender, EventArgs e)
    {
        FiltraEspecies();
    }
    /// <summary>
    /// Motra painel Cadastrar Espécie
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btPanelCadastrarEspecie_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codEspecie");
        ViewState.Remove("codNomePopular");
        PanelConfirmaEspecie.Visible = false;
        PanelConfirmaNomesComuns.Visible = false;
        panelVerEspecies.Visible = false;
        PanelAdminEspecie.Visible = true;
        ddlTipoRaiz.SelectedIndex = 0;
        limpaCampos();
        GridViewNomesPopulares.DataSource = null;
        GridViewNomesPopulares.DataBind();
        iniciaImagem();

        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
    }

    #endregion

    #region ADMINISTRAR ESPÉCIES
    protected void btVoltarTelaListaEspecies_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codEspecie");
        ViewState.Remove("codNomePopular");
        PanelAdminEspecie.Visible = false;
        panelVerEspecies.Visible = true;
    }
    protected void ddlGenero_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
    }
    protected void ddlTipoRaiz_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
    }
    protected void ddlFormaCopa_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
    }
    protected void ddlRecArborizacaoUrbana_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
    }
    #endregion

    #region CONTROLE ESPÉCIES
    protected void btEspecieSalvar_Click(object sender, EventArgs e)
    {
        LabelConfirmaEspecieErro.Visible = false;
        LabelConfirmaEspecieOk.Visible = false;
        try
        {
            //Verifica se a Espécie já está cadastrada
            Int32 codEspecie = 0;
            if (ViewState["codEspecie"] != null)
                codEspecie = Convert.ToInt32(ViewState["codEspecie"].ToString());
            if (ddlGenero.SelectedIndex == 0)
                throw new Exception("Selecione o Gênero!");
            if (String.IsNullOrEmpty(txtNomeCientfico.Text.Trim()))
                throw new Exception("Digite o Nome Científico!");
            if (String.IsNullOrEmpty(txtClima.Text.Trim()))
                throw new Exception("Digite o Clima!");
            if (String.IsNullOrEmpty(txtCorFlor.Text.Trim()))
                throw new Exception("Digite a Cor da Flor!");
            if (String.IsNullOrEmpty(txtEpocaFloracao.Text.Trim()))
                throw new Exception("Digite a Época de Floração!");
            if (String.IsNullOrEmpty(txtPropagacao.Text.Trim()))
                throw new Exception("Digite a Propagação!");
            if (String.IsNullOrEmpty(txtOrigem.Text.Trim()))
                throw new Exception("Digite a Origem da Espécie!");

            Double alturaMedia;
            if (String.IsNullOrEmpty(txtAlturaMedia.Text.Trim()))
                throw new Exception("Digite a Altura Média!");
            else if (!Double.TryParse(txtAlturaMedia.Text.Trim(), out alturaMedia))
                throw new Exception("Altura Média Inválida!");
            if (ddlTipoRaiz.SelectedIndex == 0)
                throw new Exception("Selecione o Tipo da Raiz!");
            if (ddlFormaCopa.SelectedIndex == 0)
                throw new Exception("Selecione a Forma da Copa!");

            //INSERSÃO / ATUALIZAÇÃO
            DataSetCidadeVerde.tblEspecieDataTable dtEspecie = cv.buscaEspecieByCodEspecie(codEspecie);
            if (dtEspecie == null)
            {
                //Insersão da Espécie
                codEspecie = cv.InsereEspecie(Convert.ToInt32(ddlGenero.SelectedValue), txtNomeCientfico.Text.Trim(), txtClima.Text.Trim(), txtCorFlor.Text.Trim(),
                    txtEpocaFloracao.Text.Trim(), Convert.ToInt32(ddlTipoRaiz.SelectedValue), Convert.ToInt32(ddlFormaCopa.SelectedValue),
                    alturaMedia, txtObs.Text.Trim(), txtPropagacao.Text.Trim(), txtOrigem.Text.Trim(), Convert.ToInt32(ddlRecArborizacaoUrbana.SelectedValue));
                if (codEspecie == 0)
                    throw new Exception("Erro de Inserção da Espécie!");
                LabelConfirmaEspecieOk.Text = "Espécie Inserida com Sucesso!";
                ViewState["codEspecie"] = codEspecie;
                ViewState.Remove("codNomePopular");
                txtNomePopular.Text = String.Empty;
            }
            else
            {
                //Atualização da Espécie
                if (!cv.AtualizaEspecie(Convert.ToInt32(ddlGenero.SelectedValue), txtNomeCientfico.Text.Trim(), txtClima.Text.Trim(), txtCorFlor.Text.Trim(),
                    txtEpocaFloracao.Text.Trim(), Convert.ToInt32(ddlTipoRaiz.SelectedValue), Convert.ToInt32(ddlFormaCopa.SelectedValue),
                    alturaMedia, txtObs.Text.Trim(), txtPropagacao.Text.Trim(), txtOrigem.Text.Trim(), Convert.ToInt32(ddlRecArborizacaoUrbana.SelectedValue), codEspecie))
                    throw new Exception("Erro de Atualização da Espécie!");
                LabelConfirmaEspecieOk.Text = "Espécie Atualizada com Sucesso!";
            }
            //Confirmação de Cadastro / Atualização executado com sucesso!
            ImageConfirmaEspecie.ImageUrl = "~/images/confirmation32.png";
            LabelConfirmaEspecieOk.Visible = true;
            GridViewEspecies.DataSource = cv.buscaEspecies();
            GridViewEspecies.DataBind();
        }
        catch (Exception err)
        {
            ImageConfirmaEspecie.ImageUrl = "~/images/exclamation32.png";
            LabelConfirmaEspecieErro.Text = err.Message;
            LabelConfirmaEspecieErro.Visible = true;
        }
        PanelConfirmaEspecie.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
    }
    protected void btEspecieCancelar_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codNomePopular");
        txtNomePopular.Text = String.Empty;
        PanelConfirmaEspecie.Visible = false;
        PanelConfirmaNomesComuns.Visible = false;
        if (ViewState["codEspecie"] != null)
            populaDadosEspecie(Convert.ToInt32(ViewState["codEspecie"].ToString()));
        else
            limpaCampos();
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaDadosEspecie');", true);
    }
    public void montaCampos()
    {
        ddlFormaCopa.DataSource = cv.buscaFormaCopa();
        ddlFormaCopa.DataBind();
        ddlFormaCopa.Items.Insert(0, "Selecione uma Forma da Copa");
        ddlFormaCopa.SelectedIndex = 0;
        ddlGenero.DataSource = cv.buscaGeneros();
        ddlGenero.DataBind();
        ddlGenero.Items.Insert(0, "Selecione um Gênero");
        ddlGenero.SelectedIndex = 0;
    }
    public void populaDadosEspecie(Int32 codEspecie)
    {
        DataSetCidadeVerde.tblEspecieDataTable dtEspecie = cv.buscaEspecieByCodEspecie(codEspecie);
        ddlGenero.SelectedValue = dtEspecie[0].codGenero.ToString();
        txtNomeCientfico.Text = dtEspecie[0].sNomeCientifico;
        txtClima.Text = dtEspecie[0].sClima;
        txtCorFlor.Text = dtEspecie[0].sCorDaFlor;
        txtEpocaFloracao.Text = dtEspecie[0].sEpocaFloracao;
        txtPropagacao.Text = dtEspecie[0].sPropagacao;
        txtOrigem.Text = dtEspecie[0].sOrigem;
        txtAlturaMedia.Text = dtEspecie[0].nAlturaMedia.ToString();
        txtObs.Text = dtEspecie[0].sObs;
        ddlTipoRaiz.SelectedValue = dtEspecie[0].nTipoRaiz.ToString();
        ddlFormaCopa.SelectedValue = dtEspecie[0].codFormaCopa.ToString();
        ddlRecArborizacaoUrbana.SelectedValue = dtEspecie[0].nRecArborizacaoUrbana.ToString();
    }
    public void limpaCampos()
    {
        ddlGenero.SelectedIndex = 0;
        txtNomeCientfico.Text = String.Empty;
        txtClima.Text = String.Empty;
        txtCorFlor.Text = String.Empty;
        txtEpocaFloracao.Text = String.Empty;
        txtPropagacao.Text = String.Empty;
        txtOrigem.Text = String.Empty;
        txtAlturaMedia.Text = String.Empty;
        txtObs.Text = String.Empty;
        ddlTipoRaiz.SelectedIndex = 0;
        ddlFormaCopa.SelectedIndex = 0;
        ddlRecArborizacaoUrbana.SelectedIndex = 0;
    }
    #endregion

    #region IMAGEM
    protected void btAlterarFoto_Click(object sender, EventArgs e)
    {

        PanelConfirmaEspecie.Visible = false;
        PanelConfirmaNomesComuns.Visible = false;
        if (ViewState["codEspecie"] == null)
        {
            ImageDialog.ImageUrl = "../images/erro32.png";
            LabelDialog.Text = "Não é possível alterar a Imagem!<br /> Cadastre primeiro os dados da Espécie.";
            //mensagem Java Script
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
        }
        else
            PanelUpload.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaImagemEspecie');", true);
    }
    protected void btCancelarUpload_Click(object sender, EventArgs e)
    {
        PanelConfirmaEspecie.Visible = false;
        PanelConfirmaNomesComuns.Visible = false;
        PanelUpload.Visible = false;
        LabelErroUploadFoto.Visible = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaImagemEspecie');", true);
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
            string caminhoFinal = Path.Combine(PathServidor, ViewState["codEspecie"].ToString() + ".jpg");

            if (!Resize(caminhotemp, caminhoFinal, 400, 300)) // 250, 303
                throw new Exception("Erro ao redimensionar arquivo.");

            //verifica se o arquivo foi salvo no destino final
            FileInfo Fi_servidor = new FileInfo(caminhoFinal);
            if (!Fi_servidor.Exists) //Se não salvou no diretorio.
                throw new Exception("Ocorreu um erro ao fazer o upload. tente novamente. " + caminhoFinal);

            //Salva o Caminho da Foto no Banco
            if (!cv.atualizaImagemEspecie(Convert.ToInt32(ViewState["codEspecie"].ToString())))
                throw new Exception("Erro ao salvar o caminho da imagem da espécie no Banco.");

            PanelUpload.Visible = false;
            iniciaImagem();
        }
        catch (Exception erro)
        {
            LabelErroUploadFoto.Text = erro.Message;
            LabelErroUploadFoto.Visible = true;
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaImagemEspecie');", true);
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
        PathServidor = Server.MapPath("~/fotos/especies");
        PathFotosTemp = Server.MapPath("~/fotos/especies/temp");

        //Tira o ajax do botao upload de arquivo
        //ScriptManager scriptmanager = ScriptManager.GetCurrent();
        //scriptmanager.RegisterPostBackControl(ImageButtonEnviarUpload);
        //scriptmanager.RegisterPostBackControl(ImageButtonAlterarFoto);


        // Exibe Foto de Perfil
        String strArqFoto = String.Empty;
        if (ViewState["codEspecie"] != null)
            strArqFoto = Path.Combine(PathServidor, ViewState["codEspecie"].ToString() + ".jpg");
        else
            strArqFoto = Path.Combine(PathServidor, "");

        // Verifica se arquivo é válido e existe
        FileInfo fi = new FileInfo(strArqFoto);

        if (fi.Exists) //&& strArqFoto.Trim().Length > 0)
            ImageEspecie.ImageUrl = "~/fotos/especies/" + ViewState["codEspecie"].ToString() + ".jpg";
        else
            ImageEspecie.ImageUrl = "~/fotos/arvores/semFotoArvore.png";
        PanelUpload.Visible = false;
    }
    #endregion

    #region NOMES POPULARES
    /// <summary>
    /// Popula o GridViewNomePopular
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewNomesPopulares_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor= '#75AF74'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor= " + (e.Row.RowIndex % 2 == 0 ? "'#FFFFFF'" : "'#d5d5d5'"));
            }
            e.Row.Cells[0].Visible = false; // codNomePopular
            e.Row.Cells[2].Visible = false; // codEspecie
        }
    }
    /// <summary>
    /// Edita um Determinado Nome Popular
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewNomesPopulares_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            PanelConfirmaEspecie.Visible = false;
            PanelConfirmaNomesComuns.Visible = false;
            // Captura Indice da Linha do GridView
            Int32 indice = Convert.ToInt32(e.CommandArgument);
            // Obtem Linha Especifica
            GridViewRow linha = GridViewNomesPopulares.Rows[indice];
            //// Obtem ID da Conta
            Int32 codNomePopular = Convert.ToInt32(linha.Cells[0].Text.Trim());
            if (e.CommandName.Equals("editarNomePopular"))
            {

                ViewState["codNomePopular"] = codNomePopular.ToString();
                txtNomePopular.Text = Server.HtmlDecode(linha.Cells[1].Text.Trim());
            }
            if (e.CommandName.Equals("excluirNomePopular"))
            {
                try
                {
                    if (TipoUsuario > 2)
                        throw new Exception("Usuário não tem permissão para excluir<br />a Espécie!");
                    txtNomePopular.Text = String.Empty;
                    if (!cv.deletaNomePopular(codNomePopular))
                        throw new Exception("Erro de exclusão do Nome Popular.");

                    ImageDialog.ImageUrl = "../images/confirmation32.png";
                    LabelDialog.Text = "Nome Popular Excluído com Sucesso!";

                    GridViewNomesPopulares.DataSource = cv.buscaNomePopularByCodEspecie(Convert.ToInt32(ViewState["codEspecie"]));
                    GridViewNomesPopulares.DataBind();
                    ViewState.Remove("codNomePopular");

                }
                catch (Exception ex)
                {
                    ImageDialog.ImageUrl = "../images/erro32.png";
                    LabelDialog.Text = ex.Message;
                }
                //mensagem Java Script
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "javascript: $('#dialog').dialog({ width: 400, resizable: false, bgiframe: true, modal: true, buttons: { Ok: function() { $(this).dialog('close'); }}});", true);
            }
        }
        catch (Exception)
        {
        }
        //Monta Abas
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaNomesComuns');", true);
    }
    /// <summary>
    /// Alterna entre páginas dos Nomes Populares
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewNomesPopulares_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewNomesPopulares.PageIndex = e.NewPageIndex;
        GridViewNomesPopulares.DataSource = cv.buscaNomePopularByCodEspecie(Convert.ToInt32(ViewState["codEspecie"]));
        GridViewNomesPopulares.DataBind();
    }
    protected void btSalvarNomePopular_Click(object sender, EventArgs e)
    {
        LabelOkNomesComuns.Visible = false;
        LabelErroNomesComuns.Visible = false;
        try
        {
            //Verifica se a árvore já está cadastrada
            if (ViewState["codEspecie"] == null)
                throw new Exception("Cadastre primeiro os dados da Espécie.");
            Int32 codEspecie = Convert.ToInt32(ViewState["codEspecie"].ToString());
            if (String.IsNullOrEmpty(txtNomePopular.Text.Trim()))
                throw new Exception("Digite o Nome Popular da Espécie!");
            //INSERSÃO / ATUALIZAÇÃO
            if (ViewState["codNomePopular"] == null)
            {
                //Insersão de um Nome Popular da Espécie
                if (!cv.InsereNomePopular(txtNomePopular.Text.Trim(), Convert.ToInt32(ViewState["codEspecie"].ToString())))
                    throw new Exception("Erro de Inserção do Nome Popular!");
                LabelOkNomesComuns.Text = "Nome Popular Inserido com Sucesso!";
            }
            else
            {
                //Atualização de um Nome Popular da Espécie
                if (!cv.atualizaNomePopular(txtNomePopular.Text.Trim(), Convert.ToInt32(ViewState["codNomePopular"].ToString())))
                    throw new Exception("Erro de Atualização do Nome Popular!");
                LabelOkNomesComuns.Text = "Nome Popular Atualizado com Sucesso!";
            }
            ImageConfirmaNomesComuns.ImageUrl = "~/images/confirmation32.png";
            LabelOkNomesComuns.Visible = true;
            txtNomePopular.Text = String.Empty;
            ViewState.Remove("codNomePopular");
            GridViewNomesPopulares.DataSource = cv.buscaNomePopularByCodEspecie(Convert.ToInt32(ViewState["codEspecie"]));
            GridViewNomesPopulares.DataBind();
        }
        catch (Exception err)
        {
            ImageConfirmaNomesComuns.ImageUrl = "~/images/exclamation32.png";
            LabelErroNomesComuns.Text = err.Message;
            LabelErroNomesComuns.Visible = true;
        }
        PanelConfirmaEspecie.Visible = false;
        PanelConfirmaNomesComuns.Visible = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaNomesComuns');", true);
    }
    protected void btCancelarNomePopular_Click(object sender, EventArgs e)
    {
        ViewState.Remove("codNomePopular");
        txtNomePopular.Text = String.Empty;
        PanelConfirmaEspecie.Visible = false;
        PanelConfirmaNomesComuns.Visible = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "Abas", "javascript: $('#abas').tabs().tabs('select', '#abaNomesComuns');", true);
    }
    #endregion
}
