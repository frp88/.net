using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CidadeVerde
/// </summary>
public class CidadeVerde : System.Web.UI.Page
{

    #region MÉTODO CONSTRUTOR
    /// <summary>
    /// MÉTODO CONSTRUTOR
    /// </summary>
    public CidadeVerde()
    {
        // //altera a string de conexão (do banco Árvore Local)
        string conexao = "Data Source = localhost; Initial Catalog = arvores; Integrated Security = True;";

        _Arvore.Connection.ConnectionString = _Localizacao.Connection.ConnectionString = _Entorno.Connection.ConnectionString = _Interferencia.Connection.ConnectionString =
        _Especie.Connection.ConnectionString = _Familia.Connection.ConnectionString = _FormaCopa.Connection.ConnectionString = _Genero.Connection.ConnectionString =
        _NomeComum.Connection.ConnectionString = _Doencas.Connection.ConnectionString = _Parasitas.Connection.ConnectionString = _GrupoParasitas.Connection.ConnectionString =
        _LocalAfetado.Connection.ConnectionString = _Intensidade.Connection.ConnectionString = _Injurias.Connection.ConnectionString = _Pavimento.Connection.ConnectionString =
        _LocalEntorno.Connection.ConnectionString = _Participacao.Connection.ConnectionString = _Historico.Connection.ConnectionString = _AcaoRecomendada.Connection.ConnectionString =
        _CEP.Connection.ConnectionString = _TipoLogradouro.Connection.ConnectionString = _Usuario.Connection.ConnectionString = _RelatorioAnual.Connection.ConnectionString =
       _Iluminacacao.Connection.ConnectionString = _MuroEdificacao.Connection.ConnectionString = _Posteamento.Connection.ConnectionString =
        _RaizPavimento.Connection.ConnectionString = _Sinalizacao.Connection.ConnectionString = _SituacaoFiacao.Connection.ConnectionString = _TipoFiacao.Connection.ConnectionString =
        _Trafego.Connection.ConnectionString = _Coordenadas.Connection.ConnectionString = conexao;
    }
    #endregion

    #region PROPRIEDADES PRIVADAS
    protected DataSetCidadeVerdeTableAdapters.tblArvoreTableAdapter _Arvore = new DataSetCidadeVerdeTableAdapters.tblArvoreTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblLocalizacaoTableAdapter _Localizacao = new DataSetCidadeVerdeTableAdapters.tblLocalizacaoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblEntornoTableAdapter _Entorno = new DataSetCidadeVerdeTableAdapters.tblEntornoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblInterferenciaTableAdapter _Interferencia = new DataSetCidadeVerdeTableAdapters.tblInterferenciaTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblEspecieTableAdapter _Especie = new DataSetCidadeVerdeTableAdapters.tblEspecieTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblFamiliaTableAdapter _Familia = new DataSetCidadeVerdeTableAdapters.tblFamiliaTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblFormaCopaTableAdapter _FormaCopa = new DataSetCidadeVerdeTableAdapters.tblFormaCopaTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblGeneroTableAdapter _Genero = new DataSetCidadeVerdeTableAdapters.tblGeneroTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblNomeComumTableAdapter _NomeComum = new DataSetCidadeVerdeTableAdapters.tblNomeComumTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblDoencasTableAdapter _Doencas = new DataSetCidadeVerdeTableAdapters.tblDoencasTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblParasitasTableAdapter _Parasitas = new DataSetCidadeVerdeTableAdapters.tblParasitasTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblGrupoParasitasTableAdapter _GrupoParasitas = new DataSetCidadeVerdeTableAdapters.tblGrupoParasitasTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblLocalAfetadoTableAdapter _LocalAfetado = new DataSetCidadeVerdeTableAdapters.tblLocalAfetadoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblIntensidadeTableAdapter _Intensidade = new DataSetCidadeVerdeTableAdapters.tblIntensidadeTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblInjuriasTableAdapter _Injurias = new DataSetCidadeVerdeTableAdapters.tblInjuriasTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblPavimentoTableAdapter _Pavimento = new DataSetCidadeVerdeTableAdapters.tblPavimentoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblLocalEntornoTableAdapter _LocalEntorno = new DataSetCidadeVerdeTableAdapters.tblLocalEntornoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblParticipacaoTableAdapter _Participacao = new DataSetCidadeVerdeTableAdapters.tblParticipacaoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblHistoricoArvoreTableAdapter _Historico = new DataSetCidadeVerdeTableAdapters.tblHistoricoArvoreTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblAcaoRecomendadaTableAdapter _AcaoRecomendada = new DataSetCidadeVerdeTableAdapters.tblAcaoRecomendadaTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblCEPTableAdapter _CEP = new DataSetCidadeVerdeTableAdapters.tblCEPTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblTipoLogradouroTableAdapter _TipoLogradouro = new DataSetCidadeVerdeTableAdapters.tblTipoLogradouroTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblUsuarioTableAdapter _Usuario = new DataSetCidadeVerdeTableAdapters.tblUsuarioTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.pegaDados _PegaDados = new DataSetCidadeVerdeTableAdapters.pegaDados();
    protected DataSetCidadeVerdeTableAdapters.dtRelatoriosAnualTableAdapter _RelatorioAnual = new DataSetCidadeVerdeTableAdapters.dtRelatoriosAnualTableAdapter();

    #region INTERFERENCIAS
    protected DataSetCidadeVerdeTableAdapters.tblIluminacaoTableAdapter _Iluminacacao = new DataSetCidadeVerdeTableAdapters.tblIluminacaoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblMuroEdificacaoTableAdapter _MuroEdificacao = new DataSetCidadeVerdeTableAdapters.tblMuroEdificacaoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblPosteamentoTableAdapter _Posteamento = new DataSetCidadeVerdeTableAdapters.tblPosteamentoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblRaizPavimentoTableAdapter _RaizPavimento = new DataSetCidadeVerdeTableAdapters.tblRaizPavimentoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblSinalizacaoTableAdapter _Sinalizacao = new DataSetCidadeVerdeTableAdapters.tblSinalizacaoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblSituacaoFiacaoTableAdapter _SituacaoFiacao = new DataSetCidadeVerdeTableAdapters.tblSituacaoFiacaoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblTipoFiacaoTableAdapter _TipoFiacao = new DataSetCidadeVerdeTableAdapters.tblTipoFiacaoTableAdapter();
    protected DataSetCidadeVerdeTableAdapters.tblTrafegoTableAdapter _Trafego = new DataSetCidadeVerdeTableAdapters.tblTrafegoTableAdapter();
    #endregion
    protected DataSetCidadeVerdeTableAdapters.tblCoordenadasTableAdapter _Coordenadas = new DataSetCidadeVerdeTableAdapters.tblCoordenadasTableAdapter();
    #endregion


    #region PROPRIEDADES PUBLICAS

    #region SELEÇÃO

    #region ARVORES
    /// <summary>
    /// BUSCA TODAS AS ARVORES
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblArvoreDataTable buscaArvores()
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetArvore();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODAS AS ARVORES VIVAS
    /// </summary>
    /// <returns></returns>
    ///    
    public DataSetCidadeVerde.tblArvoreDataTable buscaArvoresVivas()
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetArvoresVivas();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA UMA ARVORE PELO CODIGO DA ARVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblArvoreDataTable buscaArvoreByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetArvoreByCodArvore(codArvore);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA UMA ARVORE PELO CODIGO DE IDENTIFICAÇÃO DA ARVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblArvoreDataTable buscaArvoreByCodIdentificacao(String codIdentificacao)
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetArvoreBysCodIdentificacao(codIdentificacao);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public String buscaCodIdentArvoreByCodArvore(Int32 codArvore)
    {
        try
        {
            String resultado = _Arvore.pegaCodIdentArvore(codArvore).ToString();
            return resultado;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca o Status da arvore pelo codigo da arvore
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Int32 buscaStatusArvoreByCodArvore(Int32 codArvore)
    {
        try
        {
            Int32 resultado = Convert.ToInt32(_Arvore.GetStatusArvoreByCodArvore(codArvore).ToString());
            if (resultado > 0)
                return resultado;
            else
                return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// Busca o Total de árvores by nStatus
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    /// 
    public Int32 buscaQuantArvoreBynStatus(Int32 status)
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetQuantArvoresBynStatus(status);

            if (resultado.Count > 0)
            {
                Int32 Total = Convert.ToInt32(resultado[0]["Total"].ToString());
                return Total;
            }
            else
                return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// Busca o Total de árvores pelo CEP e pelo nStatus
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    /// 
    public Int32 buscaQuantArvoreBysCEPnStatus(Int32 status, String cep)
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetQuantArvoresBysCEPnStatus(status, cep);

            if (resultado.Count > 0)
            {
                Int32 Total = Convert.ToInt32(resultado[0]["Total"].ToString());
                return Total;
            }
            else
                return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// Busca os Totais de árvores em todos os status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    /// 
    public DataSetCidadeVerde.tblArvoreDataTable buscaQuantStatusArvores()
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetQuantStatusArvores();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA UMA ARVORE PELO STATUS DA ARVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblArvoreDataTable buscaArvoreBynStatus(Int32 status)
    {
        try
        {
            DataSetCidadeVerde.tblArvoreDataTable resultado = _Arvore.GetArvoreBynStatus(status);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region ESPÉCIE, GÊNERO, FAMÍLIA, NOME COMUM E FORMA DA COPA
    /// <summary>
    /// BUSCA TODAS AS ESPECIES
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblEspecieDataTable buscaEspecies()
    {
        try
        {
            DataSetCidadeVerde.tblEspecieDataTable resultado = _Especie.GetEspecie();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as Espécies BY codEspecie
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblEspecieDataTable buscaEspecieByCodEspecie(Int32 codEspecie)
    {
        try
        {
            DataSetCidadeVerde.tblEspecieDataTable resultado = _Especie.GetEspecieByCodEspecie(codEspecie);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as Espécies BY sNomeCientifico
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblEspecieDataTable buscaEspecieBysNomeCientifico(String nomeCientifico)
    {
        try
        {
            DataSetCidadeVerde.tblEspecieDataTable resultado = _Especie.GetEspeciesBysNomeCientifico("%" + nomeCientifico + "%");
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Busca as Espécies BY nRecArborizacaoUrbana
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblEspecieDataTable buscaEspecieBynRecArborizacaoUrbana(Int32 recomendada)
    {
        try
        {
            DataSetCidadeVerde.tblEspecieDataTable resultado = _Especie.GetEspecieBynRecArborizacaoUrbana(recomendada);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Pega o Codigo da Ultima Espécie Cadasstrada
    /// </summary>
    /// <returns></returns>
    public Int32 ultCodEspecie()
    {
        try
        {
            Int32 resultado = (Int32)(_PegaDados.pegaUltCodEspecie());
            if (resultado > 0)
                return resultado;
            else
                return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// BUSCA TODAS AS FAMILIAS
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblFamiliaDataTable buscaFamilias()
    {
        try
        {
            DataSetCidadeVerde.tblFamiliaDataTable resultado = _Familia.GetFamilias();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Familia BY CodFamilia
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblFamiliaDataTable buscaFamiliaByCodFamilia(Int32 codFamilia)
    {
        try
        {
            DataSetCidadeVerde.tblFamiliaDataTable resultado = _Familia.GetFamiliaByCodFamilia(codFamilia);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODAS AS GENERO
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblGeneroDataTable buscaGeneros()
    {
        try
        {
            DataSetCidadeVerde.tblGeneroDataTable resultado = _Genero.GetGenero();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Gênero BY CodGenero
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblGeneroDataTable buscaGeneroByCodGenero(Int32 codGenero)
    {
        try
        {
            DataSetCidadeVerde.tblGeneroDataTable resultado = _Genero.GetGeneroByCodGenero(codGenero);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODOS NOMES COMUNS
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblNomeComumDataTable buscaNomePopular()
    {
        try
        {
            DataSetCidadeVerde.tblNomeComumDataTable resultado = _NomeComum.GetNomeComum();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos nomes comuns de uma determinada espécie
    /// </summary>
    /// <param name="codEspecie"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblNomeComumDataTable buscaNomePopularByCodEspecie(Int32 codEspecie)
    {
        try
        {
            DataSetCidadeVerde.tblNomeComumDataTable resultado = _NomeComum.GetNomeComumByCodEspecie(codEspecie);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca o Nome Comum TOP 1 de uma determinada espécie
    /// </summary>
    /// <param name="codEspecie"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblNomeComumDataTable buscaNomePopularTOP1ByCodEspecie(Int32 codEspecie)
    {
        try
        {
            DataSetCidadeVerde.tblNomeComumDataTable resultado = _NomeComum.GetNomeComumTOP1ByCodEspecie(codEspecie);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um determinado Nome Comum
    /// </summary>
    /// <param name="codEspecie"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblNomeComumDataTable buscaNomePopularByCodNomePopular(Int32 codNomePopular)
    {
        try
        {
            DataSetCidadeVerde.tblNomeComumDataTable resultado = _NomeComum.GetNomeComumByCodNomeComum(codNomePopular);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODAS AS FORMAS DE COPA
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblFormaCopaDataTable buscaFormaCopa()
    {
        try
        {
            DataSetCidadeVerde.tblFormaCopaDataTable resultado = _FormaCopa.GetFormaCopa();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Forma da Copa BY CodFormaCopa
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblFormaCopaDataTable buscaFormaCopaByCodFormaCopa(Int32 codFormaCopa)
    {
        try
        {
            DataSetCidadeVerde.tblFormaCopaDataTable resultado = _FormaCopa.GetFormaCopaByCodFormaCopa(codFormaCopa);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region DOENÇAS E INJÚRIAS
    /// <summary>
    /// Busca todas as doenças
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblDoencasDataTable buscaDoencas()
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable resultado = _Doencas.GetDoencas();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca doença pelo codigo da doença
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblDoencasDataTable buscaDoencaByCodDoenca(Int32 codDoenca)
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable resultado = _Doencas.GetDoencaByCodDoenca(codDoenca);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as doenças pelo codigo da Arvore
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblDoencasDataTable buscaDoencasByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable resultado = _Doencas.GetDoencasByCodArvore(codArvore);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca doenças pelo situação da Doença
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblDoencasDataTable buscaDoencaBynStatusDoenca(Int32 status)
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable resultado = _Doencas.GetDoencaBynStatusDoenca(status);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos Parasitas
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblParasitasDataTable buscaParasitas()
    {
        try
        {
            DataSetCidadeVerde.tblParasitasDataTable resultado = _Parasitas.GetParasitas();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Parasita BY CodParasita
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblParasitasDataTable buscaParasitaByCodParasita(Int32 codParasita)
    {
        try
        {
            DataSetCidadeVerde.tblParasitasDataTable resultado = _Parasitas.GetPasrasitaByCodParasita(codParasita);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos Grupos de Parasitas
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblGrupoParasitasDataTable buscaGrupoParasitas()
    {
        try
        {
            DataSetCidadeVerde.tblGrupoParasitasDataTable resultado = _GrupoParasitas.GetGrupoParasitas();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Grupo de Parasita BY CodGrupoParasita
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblGrupoParasitasDataTable buscaGrupoParasitaByCodGrupoParasitas(Int32 codGrupoParasita)
    {
        try
        {
            DataSetCidadeVerde.tblGrupoParasitasDataTable resultado = _GrupoParasitas.GetGrupoParasitasByCodGrupoParasitas(codGrupoParasita);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos os Locais Afetados
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalAfetadoDataTable buscaLocalAfetado()
    {
        try
        {
            DataSetCidadeVerde.tblLocalAfetadoDataTable resultado = _LocalAfetado.GetLocalAfetado();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Local Afetado BY CodLocalAfetado
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalAfetadoDataTable buscaLocalAfetadoByCodLocalAfetado(Int32 codLocalAfetado)
    {
        try
        {
            DataSetCidadeVerde.tblLocalAfetadoDataTable resultado = _LocalAfetado.GetLocalAfetadoByCodLocalAfetado(codLocalAfetado);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todas Intensidades
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblIntensidadeDataTable buscaIntensidade()
    {
        try
        {
            DataSetCidadeVerde.tblIntensidadeDataTable resultado = _Intensidade.GetIntensidade();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Intensidade BY CodIntensidade
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblIntensidadeDataTable buscaIntensidadeByCodIntensidade(Int32 codIntensidade)
    {
        try
        {
            DataSetCidadeVerde.tblIntensidadeDataTable resultado = _Intensidade.GetIntensidadeByCodIntensidade(codIntensidade);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todas as Injurias
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblInjuriasDataTable buscaInjurias()
    {
        try
        {
            DataSetCidadeVerde.tblInjuriasDataTable resultado = _Injurias.GetInjurias();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca Injuria pelo codigo da Injuria
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblInjuriasDataTable buscaInjuriaByCodInjuria(Int32 codInjuria)
    {
        try
        {
            DataSetCidadeVerde.tblInjuriasDataTable resultado = _Injurias.GetInjuriaByCodInjuria(codInjuria);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as Injurias pelo codigo da Arvore
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblInjuriasDataTable buscaInjuriasByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblInjuriasDataTable resultado = _Injurias.GetInjuriaByCodArvore(codArvore);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca Injuria pelo Status da Injuria
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblInjuriasDataTable buscaInjuriaByStatusInjuria(Int32 statusInjuria)
    {
        try
        {
            DataSetCidadeVerde.tblInjuriasDataTable resultado = _Injurias.GetInjuriaByStatusInjuria(statusInjuria);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region ENTORNO
    /// <summary>
    /// Busca todos os Entornos das Árvores
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblEntornoDataTable buscaEntornos()
    {
        try
        {
            DataSetCidadeVerde.tblEntornoDataTable resultado = _Entorno.GetEntorno();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca Entorno de um determinada arvore pelo codigo da árvore
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblEntornoDataTable buscaEntornoByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblEntornoDataTable resultado = _Entorno.GetEntornoByCodArvore(codArvore);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos Locais para o Entorno de uma Arvore
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalEntornoDataTable buscaLocalEntorno()
    {
        try
        {
            DataSetCidadeVerde.tblLocalEntornoDataTable resultado = _LocalEntorno.GetLocalEntorno();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um determinado Local Entorno By codLocalEntorno
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalEntornoDataTable buscaLocalEntornoByCodLocalEntorno(Int32 codLocalEntorno)
    {
        try
        {
            DataSetCidadeVerde.tblLocalEntornoDataTable resultado = _LocalEntorno.GetLocalEntornoByCodLocalEntorno(codLocalEntorno);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos os Pavimentos  para o Entorno de uma Arvore
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblPavimentoDataTable buscaPavimento()
    {
        try
        {
            DataSetCidadeVerde.tblPavimentoDataTable resultado = _Pavimento.GetPavimento();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Pavimento By codPavimento
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblPavimentoDataTable buscaPavimentoByCodPavimento(Int32 codPavimento)
    {
        try
        {
            DataSetCidadeVerde.tblPavimentoDataTable resultado = _Pavimento.GetPavimentoByCodPavimento(codPavimento);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos as Participações para o Entorno de uma Arvore
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblParticipacaoDataTable buscaParticipacao()
    {
        try
        {
            DataSetCidadeVerde.tblParticipacaoDataTable resultado = _Participacao.GetParticipacao();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma determinada Participação BY codParticipacao
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblParticipacaoDataTable buscaParticipacaoByCodParticipacao(Int32 codParticipacao)
    {
        try
        {
            DataSetCidadeVerde.tblParticipacaoDataTable resultado = _Participacao.GetParticipacaoByCodParticipacao(codParticipacao);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region LOCALIZAÇÃO
    /// <summary>
    /// buca todos os CEPs
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblCEPDataTable buscaCEPs()
    {
        try
        {
            DataSetCidadeVerde.tblCEPDataTable resultado = _CEP.GetCEPs();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca os dados de um determinado CEP
    /// </summary>
    /// <param name="cep"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblCEPDataTable buscaCEPBysCEP(String cep)
    {
        try
        {
            DataSetCidadeVerde.tblCEPDataTable resultado = _CEP.GetCEPBysCEP(cep);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todos os CEPs Distintos
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalizacaoDataTable buscaCEPsDistintos()
    {
        try
        {
            DataSetCidadeVerde.tblLocalizacaoDataTable resultado = _Localizacao.GetCEPsDistintos();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }


    /// <summary>
    /// Busca todas as localizações
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalizacaoDataTable buscaLocalizacao()
    {
        try
        {
            DataSetCidadeVerde.tblLocalizacaoDataTable resultado = _Localizacao.GetLocalizacao();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca a Localização pelo Código da Árvore
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalizacaoDataTable buscaLocalizacaoByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblLocalizacaoDataTable resultado = _Localizacao.GetLocalizacaoByCodArvore(codArvore);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca a Localização pelo Código da Localização
    /// </summary>
    /// <param name="codLocalizacao"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalizacaoDataTable buscaLocalizacaoByCodLocalizacao(Int32 codLocalizacao)
    {
        try
        {
            DataSetCidadeVerde.tblLocalizacaoDataTable resultado = _Localizacao.GetLocalizacaoByCodLocalizacao(codLocalizacao);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca a Localização pelo sCEP
    /// </summary>
    /// <param name="codLocalizacao"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblLocalizacaoDataTable buscaLocalizacaoBysCEP(String sCEP)
    {
        try
        {
            DataSetCidadeVerde.tblLocalizacaoDataTable resultado = _Localizacao.GetLocalizacaoBysCEP(sCEP);
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca Todos os Tipos de Logradouro
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblTipoLogradouroDataTable buscaTipoLogradouro()
    {
        try
        {
            DataSetCidadeVerde.tblTipoLogradouroDataTable retultado = _TipoLogradouro.GetTipoLogradouro();
            if (retultado.Count > 0)
                return retultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Tipo de Logradouro BY CodTipoLogradouro
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblTipoLogradouroDataTable buscaTipoLogradouroByCodTipoLogradouro(Int32 codTipoLogradouro)
    {
        try
        {
            DataSetCidadeVerde.tblTipoLogradouroDataTable retultado = _TipoLogradouro.GetTipoLogradouroByCodTipoLogradouro(codTipoLogradouro);
            if (retultado.Count > 0)
                return retultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region COORDENADAS
    /// <summary>
    /// BUSCA TODAS COORDENADAS GEOGRÁFICAS
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblCoordenadasDataTable buscaCoordenadas()
    {
        try
        {
            DataSetCidadeVerde.tblCoordenadasDataTable retultado = _Coordenadas.GetCoordenadas();
            if (retultado.Count > 0)
                return retultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca Todas as Coordenadas das Árvores Vivas
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblCoordenadasDataTable buscaCoordenadasByArvoresVivas()
    {
        try
        {
            DataSetCidadeVerde.tblCoordenadasDataTable retultado = _Coordenadas.GetCoordenadasByArvoresVivas();
            if (retultado.Count > 0)
                return retultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as coordenadas geograficas de uma determinada árvore
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblCoordenadasDataTable buscaCoordenadasByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblCoordenadasDataTable retultado = _Coordenadas.GetCoordenadasByCodArvore(codArvore);
            if (retultado.Count > 0)
                return retultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region AÇÕES
    /// <summary>
    /// Busca todas as Açoes / Historico 
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblHistoricoArvoreDataTable buscaHistorico()
    {
        try
        {
            DataSetCidadeVerde.tblHistoricoArvoreDataTable resultado = _Historico.GetHistoricoArvore();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as Açoes / Historico pelo Codigo da Arvore
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblHistoricoArvoreDataTable buscaHistoricoByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblHistoricoArvoreDataTable resultado = _Historico.GetHistoricoByCodArvore(codArvore);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as Açoes / Historico pelo Codigo do Historico
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblHistoricoArvoreDataTable buscaHistoricoByCodHistorico(Int32 codHistorico)
    {
        try
        {
            DataSetCidadeVerde.tblHistoricoArvoreDataTable resultado = _Historico.GetHistoricoByCodHistorico(codHistorico);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca as Açoes / Historico pelo Status do Historico
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblHistoricoArvoreDataTable buscaHistoricoBynStatusHistorico(Int32 status)
    {
        try
        {
            DataSetCidadeVerde.tblHistoricoArvoreDataTable resultado = _Historico.GetHistoricoBynStatusHistorico(status);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca todas as Açoes Recomendadas 
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblAcaoRecomendadaDataTable buscaAcoesRecomendadas()
    {
        try
        {
            DataSetCidadeVerde.tblAcaoRecomendadaDataTable resultado = _AcaoRecomendada.GetAcaoRecomendada();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Ação Recomendada BY CodAcaoRecomendada
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblAcaoRecomendadaDataTable buscaAcoesRecomendadasByCodAcaoRec(Int32 codAcaoRec)
    {
        try
        {
            DataSetCidadeVerde.tblAcaoRecomendadaDataTable resultado = _AcaoRecomendada.GetAcaoRecomendadaByCodAcaoRecomendada(codAcaoRec);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region INTERFERÊNCIAS
    /// <summary>
    /// BUSCA TODAS AS INTERFERENCIAS
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblInterferenciaDataTable buscaInterferencias()
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable resultado = _Interferencia.GetInterferencia();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca Uma Interferencia BY CodArvore
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblInterferenciaDataTable buscaInterferenciaByCodArvore(Int32 codArvore)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable resultado = _Interferencia.GetInterferenciaByCodArvore(codArvore);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODAS AS ILUMINAÇÕES
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblIluminacaoDataTable buscaIluminacao()
    {
        try
        {
            DataSetCidadeVerde.tblIluminacaoDataTable resultado = _Iluminacacao.GetIluminacao();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Iluminação BY CodIluminacao
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblIluminacaoDataTable buscaIluminacaoByCodIluminacao(Int32 codIluminacao)
    {
        try
        {
            DataSetCidadeVerde.tblIluminacaoDataTable resultado = _Iluminacacao.GetIlumincacaoBycodIluminacao(codIluminacao);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODOS OS MUROS EDIFICAÇÃO
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblMuroEdificacaoDataTable buscaMuroEdificacao()
    {
        try
        {
            DataSetCidadeVerde.tblMuroEdificacaoDataTable resultado = _MuroEdificacao.GetMuroEdificacao();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Muro Edificição BY CodMuroEdificaçao
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblMuroEdificacaoDataTable buscaMuroEdificacaoByCodMuroEdificacao(Int32 codMuro)
    {
        try
        {
            DataSetCidadeVerde.tblMuroEdificacaoDataTable resultado = _MuroEdificacao.GetMuroEdificacaoByCodMuroEdificacao(codMuro);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODAS OS POSTEAMENTOS
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblPosteamentoDataTable buscaPosteamentos()
    {
        try
        {
            DataSetCidadeVerde.tblPosteamentoDataTable resultado = _Posteamento.GetPosteamento();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Posteamentos BY CodPosteamento
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblPosteamentoDataTable buscaPosteamentosByCodPosteamento(Int32 codPosteamento)
    {
        try
        {
            DataSetCidadeVerde.tblPosteamentoDataTable resultado = _Posteamento.GetPosteamentoByCodPosteamento(codPosteamento);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODAS AS RAIZES NO PAVIMENTO
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblRaizPavimentoDataTable buscaRaizPavimento()
    {
        try
        {
            DataSetCidadeVerde.tblRaizPavimentoDataTable resultado = _RaizPavimento.GetRaizPavimento();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Raiz no Pavimento BY CodRaizPavimento
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblRaizPavimentoDataTable buscaRaizPavimentoByCodRaizPavimento(Int32 codRaiz)
    {
        try
        {
            DataSetCidadeVerde.tblRaizPavimentoDataTable resultado = _RaizPavimento.GetRaizPavimentoByCodRaizPavimento(codRaiz);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODAS AS SINALIZAÇÕES
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblSinalizacaoDataTable buscaSinalizacao()
    {
        try
        {
            DataSetCidadeVerde.tblSinalizacaoDataTable resultado = _Sinalizacao.GetSinalizacao();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Sinalização BY CodSinalizacao
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblSinalizacaoDataTable buscaSinalizacaoByCodSinalizacao(Int32 codSinalizacao)
    {
        try
        {
            DataSetCidadeVerde.tblSinalizacaoDataTable resultado = _Sinalizacao.GetSinalizacaoByCodSinalizacao(codSinalizacao);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODOS OS SITUAÇÕES DA FIAÇÃO
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblSituacaoFiacaoDataTable buscaSituacaoFiacao()
    {
        try
        {
            DataSetCidadeVerde.tblSituacaoFiacaoDataTable resultado = _SituacaoFiacao.GetSituacaoFiacao();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca uma Situação da Fiação BY CodSituacaoFiacao
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblSituacaoFiacaoDataTable buscaSituacaoFiacaoByCodSituacaoFiacao(Int32 codSituacaoFiacao)
    {
        try
        {
            DataSetCidadeVerde.tblSituacaoFiacaoDataTable resultado = _SituacaoFiacao.GetSituacaoFiacaoByCodSituacaoFiacao(codSituacaoFiacao);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODOS OS TIPOS DE FIAÇÃO
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblTipoFiacaoDataTable buscaTipoFiacao()
    {
        try
        {
            DataSetCidadeVerde.tblTipoFiacaoDataTable resultado = _TipoFiacao.GetTipoFiacao();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Tipo de Fiação BY CodTipoFiacao
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblTipoFiacaoDataTable buscaTipoFiacaoByCodTipoFiacao(Int32 codTipoFiacao)
    {
        try
        {
            DataSetCidadeVerde.tblTipoFiacaoDataTable resultado = _TipoFiacao.GetTipoFiacaoByCodTipoFiacao(codTipoFiacao);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA TODOS OS TRÁFEGOS
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblTrafegoDataTable buscaTrafego()
    {
        try
        {
            DataSetCidadeVerde.tblTrafegoDataTable resultado = _Trafego.GetTrafego();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca um Tráfego BY CodTrafego
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblTrafegoDataTable buscaTrafegoByCodTrafego(Int32 codTrafego)
    {
        try
        {
            DataSetCidadeVerde.tblTrafegoDataTable resultado = _Trafego.GetTrafegoByCodTrafego(codTrafego);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #region USUÁRIO
    /// <summary>
    /// Busca todos usuários
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblUsuarioDataTable buscaUsuarios()
    {
        try
        {
            DataSetCidadeVerde.tblUsuarioDataTable resultado = _Usuario.GetUsuario();
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca usuario pelo Codigo do Usuário
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblUsuarioDataTable buscaUsuarioByCodUsuario(Int32 codUsuario)
    {
        try
        {
            DataSetCidadeVerde.tblUsuarioDataTable resultado = _Usuario.GetUsuarioByCodUsuario(codUsuario);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca usuario pelo CPF
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblUsuarioDataTable buscaUsuarioBysCPF(String cpf)
    {
        try
        {
            DataSetCidadeVerde.tblUsuarioDataTable resultado = _Usuario.GetUsuarioBysCPF(cpf);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca usuario pelo Nome
    /// </summary>
    /// <param name="Nome"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblUsuarioDataTable buscaUsuarioBysNome(String nome)
    {
        try
        {
            DataSetCidadeVerde.tblUsuarioDataTable resultado = _Usuario.GetUsuarioBysNome(nome);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca usuario pelo Login
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblUsuarioDataTable buscaUsuarioBysLogin(String login)
    {
        try
        {
            DataSetCidadeVerde.tblUsuarioDataTable resultado = _Usuario.GetUsuarioBysLogin(login);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Busca usuario pelo Login e Senha
    /// </summary>
    /// <param name="login"></param>
    /// <param name="senha"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.tblUsuarioDataTable buscaUsuarioByLoginSenha(String login, String senha)
    {
        try
        {
            DataSetCidadeVerde.tblUsuarioDataTable resultado = _Usuario.GetUsuarioBysLoginesSenha(login, senha);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// Verifica Disponibilidade do Usuario
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public Boolean verificaDisponibilidadeLogin(String login)
    {
        try
        {
            DataSetCidadeVerde.tblUsuarioDataTable resultado = _Usuario.GetUsuarioBysLogin(login);
            if (resultado.Rows.Count == 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    #endregion

    #region INSERÇÃO
    /// <summary>
    /// INSERE UMA ARVORE NO SISTEMA
    /// </summary>
    /// <param name="codEspecie"></param>
    /// <param name="dtLevantamento"></param>
    /// <param name="altura"></param>
    /// <param name="DiamentoCopa"></param>
    /// <param name="status"></param>
    /// <param name="dtPlantio"></param>
    /// <param name="PersistenciaFolhas"></param>
    /// <returns></returns>
    public Int32 InsereArvore(Int32 codEspecie, DateTime? dtLevantamento,
        Double? altura, Double? DiamentoCopa, Int32 status, DateTime? dtPlantio, String PersistenciaFolhas)
    {
        try
        {
            //Insere Árvore
            Int32 codArvore = Convert.ToInt32(_Arvore.InsertArvore(codEspecie, dtLevantamento, altura, DiamentoCopa, status, dtPlantio, PersistenciaFolhas));
            return codArvore;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public String InsereCodIndentArvore(Int32 codArvore)
    {
        try
        {
            //Insere codIdentArvore
            String codIdentArvore = _PegaDados.geraCodIdentificacaoArvore(codArvore.ToString()).ToString();// (_PegaDados.geraCodIdentificacaoArvore(codArvore)).ToString();
            _Arvore.UpdateCodIdentificacaoByCodArvore(codIdentArvore, codArvore);
            return codIdentArvore;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// INSERE UMA LOCALIZAÇÃO PARA UMA DERTERMINADA ARVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <param name="sCEP"></param>
    /// <param name="sLogradouro"></param>
    /// <param name="sBairro"></param>
    /// <param name="sComplemento"></param>
    /// <param name="nNumero"></param>
    /// <param name="sCidade"></param>
    /// <param name="sEstado"></param>
    /// <param name="nTipoLogradouro"></param>
    /// <returns></returns>
    public Boolean InsereLocalizacao(Int32 codArvore, String sCEP, String sLogradouro, String sBairro, String sComplemento,
        Int32 nNumero, String sCidade, String sEstado, Int32 nTipoLogradouro)
    {
        try
        {
            if (nNumero == -1)
            {
                if (Convert.ToInt32(_Localizacao.InsertLocalizacao(codArvore, sCEP, sLogradouro, sBairro, sComplemento, null, sCidade, sEstado, nTipoLogradouro)) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (Convert.ToInt32(_Localizacao.InsertLocalizacao(codArvore, sCEP, sLogradouro, sBairro, sComplemento, nNumero, sCidade, sEstado, nTipoLogradouro)) > 0)
                    return true;
                else
                    return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE AS COORDENADAS GEOGRÁFICAS DE UMA DETERMINADA ÁRVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <param name="coordenadas"></param>
    /// <returns></returns>
    public Boolean InsereCoordenadas(Int32 codArvore, String latitude, String longitude)
    {
        try
        {
            latitude = latitude.Replace(",", ".");
            longitude = longitude.Replace(",", ".");
            String coordenadas = "POINT(" + longitude + " " + latitude + ")";
            if (Convert.ToInt32(_Coordenadas.InsertCoordenadas(codArvore, coordenadas)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// INSERE UM ENTORNO DE UMA DETERMINADA ÁRVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <param name="codLocal"></param>
    /// <param name="codPavimento"></param>
    /// <param name="codParticipacao"></param>
    /// <param name="nLargRua"></param>
    /// <param name="nLargPasseio"></param>
    /// <returns></returns>
    public Boolean InsereEntorno(Int32 codArvore, Int32 codLocalEntorno, Int32 codPavimento, Int32 codParticipacao, Double? nLargRua, Double? nLargPasseio)
    {
        try
        {
            if (Convert.ToInt32(_Entorno.InsertEntorno(codArvore, codLocalEntorno, codPavimento, codParticipacao, nLargRua, nLargPasseio)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA INTERFERÊNCIA PARA UMA DERTERMINADA ARVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <param name="codTrafego"></param>
    /// <param name="codRaizPavimento"></param>
    /// <param name="codSituacaoFiacao"></param>
    /// <param name="codPosteamento"></param>
    /// <param name="codIluminacao"></param>
    /// <param name="codSinalizacao"></param>
    /// <param name="codMuroEdificacao"></param>
    /// <param name="codTipoFiacao"></param>
    /// <returns></returns>
    public Boolean InsereInterferencia(Int32 codArvore, Int32 codTrafego, Int32 codRaizPavimento, Int32 codSituacaoFiacao, Int32 codPosteamento,
        Int32 codIluminacao, Int32 codSinalizacao, Int32 codMuroEdificacao, Int32 codTipoFiacao)
    {
        try
        {
            if (Convert.ToInt32(_Interferencia.InsertInterferencia(codArvore, codTrafego, codRaizPavimento, codSituacaoFiacao, codPosteamento, codIluminacao,
                codSinalizacao, codMuroEdificacao, codTipoFiacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA DOENÇA DE UMA DETERMINADA ÁRVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <param name="codParasita"></param>
    /// <param name="codGrupoParasita"></param>
    /// <param name="codLocalAfetado"></param>
    /// <param name="codIntensidade"></param>
    /// <param name="descricao"></param>
    /// <param name="dtDoenca"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public Int32 InsereDoenca(Int32 codArvore, Int32? codParasita, Int32? codGrupoParasita, Int32 codLocalAfetado, Int32 codIntensidade, String descricao, DateTime? dtDoenca, Int32 status)
    {
        try
        {
            Int32 resultado = Convert.ToInt32(_Doencas.InsertDoenca(codArvore, codParasita, codGrupoParasita, codLocalAfetado, codIntensidade, descricao, dtDoenca, status));
            if (resultado > 0)
                return resultado;
            else
                return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// INSERE UMA INJURIA DE UMA DETERMINADA ÁRVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <param name="codLocalAfetado"></param>
    /// <param name="codIntensidade"></param>
    /// <param name="descricao"></param>
    /// <param name="dtInjuria"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public Int32 InsereInjuria(Int32 codArvore, Int32 codLocalAfetado, Int32 codIntensidade, String descricao, DateTime? dtInjuria, Int32 status)
    {
        try
        {
            Int32 resultado = Convert.ToInt32(_Injurias.InsertInjuria(codArvore, codLocalAfetado, codIntensidade, descricao, dtInjuria, status));
            return resultado;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// INSERE UMA AÇÃO / HISTÓRICO DE UMA DETERMINADA ÁRVORE
    /// </summary>
    /// <param name="codAcaoRecomendada"></param>
    /// <param name="codFitossanidade"></param>
    /// <param name="codArvore"></param>
    /// <param name="dtHistorico"></param>
    /// <param name="nStatusHistorico"></param>
    /// <param name="descHistorico"></param>
    /// <returns></returns>
    public Int32 InsereAcao(Int32 codAcaoRecomendada, Int32 codArvore, DateTime? dtHistorico,
        Int32 nStatusHistorico, String descHistorico)
    {
        try
        {
            Int32 resultato = Convert.ToInt32(_Historico.InsertHistorico(codAcaoRecomendada, codArvore, dtHistorico, nStatusHistorico, descHistorico));
            return resultato;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// INSERE UM NOVO USUÁRIO
    /// </summary>
    /// <param name="cpf"></param>
    /// <param name="nome"></param>
    /// <param name="login"></param>
    /// <param name="tipo"></param>
    /// <param name="email"></param>
    /// <param name="telefone"></param>
    /// <returns></returns>
    public Boolean InsereUsuario(String cpf, String nome, String login, Int32 tipo, String email, String telefone)
    {
        try
        {
            if (Convert.ToInt32(_Usuario.InsertUsuario(cpf, nome, login, tipo, email, telefone)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM CEP
    /// </summary>
    /// <param name="sCEP"></param>
    /// <param name="Logradouro"></param>
    /// <param name="Bairro"></param>
    /// <param name="sCidade"></param>
    /// <param name="sEstado"></param>
    /// <param name="codTipoLogradouro"></param>
    /// <returns></returns>
    public Boolean InsereCEP(String sCEP, String Logradouro, String Bairro, String sCidade, String sEstado, Int32 codTipoLogradouro)
    {
        try
        {
            if (buscaCEPBysCEP(sCEP) == null)
            {
                if (Convert.ToInt32(_CEP.InsertCEP(sCEP, Logradouro, Bairro, sCidade, sEstado, codTipoLogradouro)) > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// INSERE UMA FAMILIA NO SISTEMA
    /// </summary>
    /// <param name="descFamilia"></param>
    /// <returns></returns>
    public Boolean InsereFamilia(String descFamilia)
    {
        try
        {
            if (Convert.ToInt32(_Familia.InsertFamilia(descFamilia)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM GENERO
    /// </summary>
    /// <param name="codFamilia"></param>
    /// <param name="descGenero"></param>
    /// <returns></returns>
    public Boolean InsereGenero(Int32 codFamilia, String descGenero)
    {
        try
        {
            if (Convert.ToInt32(_Genero.InsertGenero(codFamilia, descGenero)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA ESPÉCIE
    /// </summary>
    /// <param name="codGenero"></param>
    /// <param name="sNomeCientifico"></param>
    /// <param name="sClima"></param>
    /// <param name="sCorDaFlor"></param>
    /// <param name="sEpocaFloracao"></param>
    /// <param name="nTipoRaiz"></param>
    /// <param name="codFormaCopa"></param>
    /// <param name="alturaMedia"></param>
    /// <param name="sObs"></param>
    /// <param name="sPropagacao"></param>
    /// <param name="sOrigem"></param>
    /// <param name="nRecArborizacaoUrbana"></param>
    /// <returns></returns>
    public Int32 InsereEspecie(Int32 codGenero, String sNomeCientifico, String sClima, String sCorDaFlor, String sEpocaFloracao, Int32 nTipoRaiz,
        Int32 codFormaCopa, Double? alturaMedia, String sObs, String sPropagacao, String sOrigem, Int32 nRecArborizacaoUrbana)
    {
        try
        {
            Int32 resultado = Convert.ToInt32(_Especie.InsertEspecie(codGenero, sNomeCientifico, sClima, sCorDaFlor, sEpocaFloracao, nTipoRaiz, codFormaCopa,
                 alturaMedia, sObs, sPropagacao, sOrigem, nRecArborizacaoUrbana));
            return resultado;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// INSERE UM NOME POPULAR DE UMA DETERMINADA ESPÉCIE
    /// </summary>
    /// <param name="descNomePopular"></param>
    /// <param name="codEspecie"></param>
    /// <returns></returns>
    public Boolean InsereNomePopular(String descNomePopular, Int32 codEspecie)
    {
        try
        {
            if (Convert.ToInt32(_NomeComum.InsertNomeComum(descNomePopular, codEspecie)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA FORMA DA COPA NO SISTEMA
    /// </summary>
    /// <param name="descFormaCopa"></param>
    /// <returns></returns>
    public Boolean InsereFormaCopa(String descFormaCopa)
    {
        try
        {
            if (Convert.ToInt32(_FormaCopa.InsertFormaCopa(descFormaCopa)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM PARASITA
    /// </summary>
    /// <param name="descParasita"></param>
    /// <returns></returns>
    public Boolean InsereParasita(String descParasita)
    {
        try
        {
            if (Convert.ToInt32(_Parasitas.InsertParasita(descParasita)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM GRUPO DE PARASITA
    /// </summary>
    /// <param name="descGrupoParasita"></param>
    /// <returns></returns>
    public Boolean InsereGrupoParasita(String descGrupoParasita)
    {
        try
        {
            if (Convert.ToInt32(_GrupoParasitas.InsertGrupoParasita(descGrupoParasita)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM LOCAL AFETADO
    /// </summary>
    /// <param name="descLocalAfetado"></param>
    /// <returns></returns>
    public Boolean InsereLocalAfetado(String descLocalAfetado)
    {
        try
        {
            if (Convert.ToInt32(_LocalAfetado.InsertLocalAfetado(descLocalAfetado)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA INTENSIDADE
    /// </summary>
    /// <param name="descIntensidade"></param>
    /// <returns></returns>
    public Boolean InsereIntensidade(String descIntensidade)
    {
        try
        {
            if (Convert.ToInt32(_Intensidade.InsertIntensidade(descIntensidade)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA AÇÃO RECOMENDADA
    /// </summary>
    /// <param name="descAcaoRecomendada"></param>
    /// <returns></returns>
    public Boolean InsereAcaoRecomendada(String descAcaoRecomendada)
    {
        try
        {
            if (Convert.ToInt32(_AcaoRecomendada.InsertAcaoRecomendada(descAcaoRecomendada)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM LOCAL ENTORNO DA ÁRVORE
    /// </summary>
    /// <param name="descLocalEntorno"></param>
    /// <returns></returns>
    public Boolean InsereLocalEntorno(String descLocalEntorno)
    {
        try
        {
            if (Convert.ToInt32(_LocalEntorno.InsertLocalEntorno(descLocalEntorno)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA PARTICIPAÇÃO
    /// </summary>
    /// <param name="descParticipacao"></param>
    /// <returns></returns>
    public Boolean InsereParticipacao(String descParticipacao)
    {
        try
        {
            if (Convert.ToInt32(_Participacao.InsertParticipacao(descParticipacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM PAVIMENTO
    /// </summary>
    /// <param name="descPavimento"></param>
    /// <returns></returns>
    public Boolean InserePavimento(String descPavimento)
    {
        try
        {
            if (Convert.ToInt32(_Pavimento.InsertPavimento(descPavimento)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM TIPO DE LOGRADOURO
    /// </summary>
    /// <param name="descTipoLogradouro"></param>
    /// <returns></returns>
    public Boolean InsereTipoLogradouro(String descTipoLogradouro)
    {
        try
        {
            if (Convert.ToInt32(_TipoLogradouro.InsertTipoLogradouro(descTipoLogradouro)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    #region INSERÇÃO DE INTEREFERÊMCIAS
    /// <summary>
    /// INSERE UMA ILUMINAÇÃO
    /// </summary>
    /// <param name="descIluminacao"></param>
    /// <returns></returns>
    public Boolean InsereIluminacao(String descIluminacao)
    {
        try
        {
            if (Convert.ToInt32(_Iluminacacao.InsertIluminacao(descIluminacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM MUROEDIFICAÇÃO
    /// </summary>
    /// <param name="descMuroEdificacao"></param>
    /// <returns></returns>
    public Boolean InsereMuroEdificacao(String descMuroEdificacao)
    {
        try
        {
            if (Convert.ToInt32(_MuroEdificacao.InsertMuroEdificacao(descMuroEdificacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM POSTEAMENTO
    /// </summary>
    /// <param name="descPosteamento"></param>
    /// <returns></returns>
    public Boolean InserePosteamento(String descPosteamento)
    {
        try
        {
            if (Convert.ToInt32(_Posteamento.InsertPosteamento(descPosteamento)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA RAIZ PAVIMENTO
    /// </summary>
    /// <param name="descRaizPavimento"></param>
    /// <returns></returns>
    public Boolean InsereRaizPavimento(String descRaizPavimento)
    {
        try
        {
            if (Convert.ToInt32(_RaizPavimento.InsertRaizPavimento(descRaizPavimento)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA SINALIZACAÇÃO
    /// </summary>
    /// <param name="descSinalizacao"></param>
    /// <returns></returns>
    public Boolean InsereSinalizacao(String descSinalizacao)
    {
        try
        {
            if (Convert.ToInt32(_Sinalizacao.InsertSinalizacao(descSinalizacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UMA SITUAÇÃO DA FIAÇÃO
    /// </summary>
    /// <param name="descSituacaoFiacao"></param>
    /// <returns></returns>
    public Boolean InsereSituacaoFiacao(String descSituacaoFiacao)
    {
        try
        {
            if (Convert.ToInt32(_SituacaoFiacao.InsertSituacaoFiacao(descSituacaoFiacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM TIPO DE FIAÇÃO
    /// </summary>
    /// <param name="descTipoFiacao"></param>
    /// <returns></returns>
    public Boolean InsereTipoFiacao(String descTipoFiacao)
    {
        try
        {
            if (Convert.ToInt32(_TipoFiacao.InsertTipoFiacao(descTipoFiacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE UM TRÁFEGO
    /// </summary>
    /// <param name="descTrafego"></param>
    /// <returns></returns>
    public Boolean InsereTrafego(String descTrafego)
    {
        try
        {
            if (Convert.ToInt32(_Trafego.InsertTrafego(descTrafego)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    #endregion

    #region ATUALIZAÇÃO
    /// <summary>
    /// ATUALIZA STATUS DA ÁRVORE PELO CÓDIGO DA ÁRVORE
    /// </summary>
    /// <param name="status"></param>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean atualizaStatusArvore(Int32 status, Int32 codArvore)
    {
        try
        {
            if (Convert.ToInt32(_Arvore.UpdateStatusArvore(status, codArvore)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA OS DADOS DA ÁRVORE PELO CÓDIGO DA ÁRVORE
    /// </summary>
    /// <param name="codEspecie"></param>
    /// <param name="dtLevantamento"></param>
    /// <param name="altura"></param>
    /// <param name="diametroCopa"></param>
    /// <param name="status"></param>
    /// <param name="dtPlantio"></param>
    /// <param name="PersistenciaFolhas"></param>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean atualizaArvore(Int32 codEspecie, DateTime? dtLevantamento, Double? altura, Double? diametroCopa,
        Int32 status, DateTime? dtPlantio, String PersistenciaFolhas, Int32 codArvore)
    {
        try
        {
            if (Convert.ToInt32(_Arvore.UpdateArvore(codEspecie, dtLevantamento, altura, diametroCopa, status, dtPlantio, PersistenciaFolhas, codArvore)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA A LOCALIZAÇÃO DE UMA DETERMINADA ÁRVORE PELO CÓDIGO DA ÁRVORE
    /// </summary>
    /// <param name="status"></param>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean atualizaLocalizacao(String cep, String logradouro, String bairro, String complemento, Int32? numero, String cidade,
        String estado, Int32 tipoLogradouro, Int32 codArvore)
    {
        try
        {
            if (numero == -1)
            {
                if (Convert.ToInt32(_Localizacao.UpdateLocalizacao(cep, logradouro, bairro, complemento, null, cidade, estado, tipoLogradouro, codArvore)) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (Convert.ToInt32(_Localizacao.UpdateLocalizacao(cep, logradouro, bairro, complemento, numero, cidade, estado, tipoLogradouro, codArvore)) > 0)
                    return true;
                else
                    return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA O ENTORNO DE UMA DETERMINADA ÁRVORE PELO CÓDIGO DA ÁRVORE
    /// </summary>
    /// <param name="status"></param>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean atualizaEntorno(Int32 codPavimento, Int32 codParticipacao, Double larguraRua, Double larguraPasseio,
         Int32 codLocalEntorno, Int32 codArvore)
    {
        try
        {
            if (Convert.ToInt32(_Entorno.UpdateEntorno(codPavimento, codParticipacao, larguraRua, larguraPasseio, codLocalEntorno, codArvore)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA A INTERFERÊNCIA DE UMA DETERMINADA ÁRVORE PELO CÓDIGO DA ÁRVORE
    /// </summary>
    /// <param name="codTrafego"></param>
    /// <param name="codRaizPavimento"></param>
    /// <param name="codSituacaoFiacao"></param>
    /// <param name="codPosteamento"></param>
    /// <param name="codIluminacao"></param>
    /// <param name="codSinalizacao"></param>
    /// <param name="codMuroEdificacao"></param>
    /// <param name="codTipoFiacao"></param>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean atualizaInterferencia(Int32 codTrafego, Int32 codRaizPavimento, Int32 codSituacaoFiacao, Int32 codPosteamento,
        Int32 codIluminacao, Int32 codSinalizacao, Int32 codMuroEdificacao, Int32 codTipoFiacao, Int32 codArvore)
    {
        try
        {
            if (Convert.ToInt32(_Interferencia.UpdateInterferencia(codTrafego, codRaizPavimento, codSituacaoFiacao, codPosteamento, codIluminacao,
                codSinalizacao, codMuroEdificacao, codTipoFiacao, codArvore)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// INSERE / ATUALIZA IMAGEM DA ÁRVORE NO BANCO
    /// </summary>
    /// <param name="sImagem"></param>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean atualizaImagem(String sImagem, Int32 codArvore)
    {
        try
        {
            if (Convert.ToInt32(_Arvore.UpdateImagem(sImagem, codArvore)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// INSERE / ATUALIZA IMAGEM DE UMA ESPÉCIE NO BANCO
    /// </summary>
    /// <param name="sImagem"></param>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean atualizaImagemEspecie(Int32 codEspecie)
    {
        try
        {
            if (Convert.ToInt32(_Especie.UpdateImagemEspecie(codEspecie, codEspecie)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary> 
    /// ATUALIZA UMA DOENÇA DE UMA DETERMINADA ÁRVORE PELO CÓDIGO DA DOENÇA
    /// </summary>
    /// <param name="codParasita"></param>
    /// <param name="codGrupoParasita"></param>
    /// <param name="codLocalAfetado"></param>
    /// <param name="codIntensidade"></param>
    /// <param name="descDoenca"></param>
    /// <param name="dtDoenca"></param>
    /// <param name="statusDoenca"></param>
    /// <param name="codDoenca"></param>
    /// <returns></returns>
    public Boolean atualizaDoenca(Int32 codArvore, Int32? codParasita, Int32? codGrupoParasita, Int32 codLocalAfetado,
        Int32 codIntensidade, String descDoenca, DateTime? dtDoenca, Int32 statusDoenca, Int32 codDoenca)
    {
        try
        {
            if (Convert.ToInt32(_Doencas.UpdateDoenca(codArvore, codParasita, codGrupoParasita, codLocalAfetado,
                codIntensidade, descDoenca, dtDoenca, statusDoenca, codDoenca)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA INJÚRIA DE UMA DETERMINADA ÁRVORE PELO CÓDIGO DA INJÚRIA
    /// </summary>
    /// <param name="codLocalAfetado"></param>
    /// <param name="codIntensidade"></param>
    /// <param name="descInjuria"></param>
    /// <param name="dtInjuria"></param>
    /// <param name="statusInjuria"></param>
    /// <param name="codInjuria"></param>
    /// <returns></returns>
    public Boolean atualizaInjuria(Int32 codArvore, Int32 codLocalAfetado, Int32 codIntensidade, String descInjuria, DateTime? dtInjuria, Int32 statusInjuria, Int32 codInjuria)
    {
        try
        {
            if (Convert.ToInt32(_Injurias.UpdateInjuria(codArvore, codLocalAfetado, codIntensidade, descInjuria, dtInjuria, statusInjuria, codInjuria)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA AÇÃO DE UMA DETERMINADA ÁRVORE PELO CÓDIGO DA AÇÃO
    /// </summary>
    /// <param name="codAcaoRecomendada"></param>
    /// <param name="codArvore"></param>
    /// <param name="dtHistorico"></param>
    /// <param name="nStatusHistorico"></param>
    /// <param name="descHistorico"></param>
    /// <param name="codHistorico"></param>
    /// <returns></returns>
    public Boolean atualizaAcao(Int32 codAcaoRecomendada, Int32 codArvore, DateTime? dtHistorico, Int32 nStatusHistorico, String descHistorico, Int32 codHistorico)
    {
        try
        {
            if (Convert.ToInt32(_Historico.UpdateHistorico(codAcaoRecomendada, codArvore, dtHistorico, nStatusHistorico, descHistorico, codHistorico)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA CEP PELO SCEP
    /// </summary>
    /// <param name="sCEP"></param>
    /// <param name="Logradouro"></param>
    /// <param name="sBairro"></param>
    /// <param name="sCidade"></param>
    /// <param name="sEstado"></param>
    /// <param name="codTipoLogradouro"></param>
    /// <returns></returns>
    public Boolean atualizaCEP(String sCEP, String Logradouro, String sBairro, String sCidade, String sEstado, Int32 codTipoLogradouro)
    {
        try
        {
            if (Convert.ToInt32(_CEP.UpdateCEP(sCEP, Logradouro, sBairro, sCidade, sEstado, codTipoLogradouro)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// ATUALIZA FAMILIA
    /// </summary>
    /// <param name="descFamilia"></param>
    /// <param name="codFamilia"></param>
    /// <returns></returns>
    public Boolean atualizaFamilia(String descFamilia, Int32 codFamilia)
    {
        try
        {
            if (Convert.ToInt32(_Familia.UpdateFamilia(descFamilia, codFamilia)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA GENERO BY CODGENERO
    /// </summary>
    /// <param name="codFamilia"></param>
    /// <param name="descGenero"></param>
    /// <param name="codGenero"></param>
    /// <returns></returns>
    public Boolean atualizaGenero(Int32 codFamilia, String descGenero, Int32 codGenero)
    {
        try
        {
            if (Convert.ToInt32(_Genero.UpdateGenero(codFamilia, descGenero, codGenero)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA A ESPÉCIE BY CODESPECIE
    /// </summary>
    /// <param name="codGenero"></param>
    /// <param name="sNomeCientifico"></param>
    /// <param name="sClima"></param>
    /// <param name="sCorDaFlor"></param>
    /// <param name="sEpocaFloracao"></param>
    /// <param name="nTipoRaiz"></param>
    /// <param name="codFormaCopa"></param>
    /// <param name="alturaMedia"></param>
    /// <param name="sObs"></param>
    /// <param name="sPropagacao"></param>
    /// <param name="sOrigem"></param>
    /// <param name="sPersistenciaFolhas"></param>
    /// <param name="codEspecie"></param>
    /// <returns></returns>
    public Boolean AtualizaEspecie(Int32 codGenero, String sNomeCientifico, String sClima, String sCorDaFlor, String sEpocaFloracao, Int32 nTipoRaiz,
        Int32 codFormaCopa, Double? alturaMedia, String sObs, String sPropagacao, String sOrigem, Int32 nRecArborizacaoUrbana, Int32 codEspecie)
    {
        try
        {
            if (Convert.ToInt32(_Especie.UpdateEspecie(codGenero, sNomeCientifico, sClima, sCorDaFlor, sEpocaFloracao, nTipoRaiz, codFormaCopa,
                alturaMedia, sObs, sPropagacao, sOrigem, nRecArborizacaoUrbana, codEspecie)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM NOME COMUM BY CODNOMEPOPULAR
    /// </summary>
    /// <param name="descNomeComum"></param>
    /// <param name="codNomeComum"></param>
    /// <returns></returns>
    public Boolean atualizaNomePopular(String descNomePopular, Int32 codNomePopular)
    {
        try
        {
            if (Convert.ToInt32(_NomeComum.UpdateNomeComum(descNomePopular, codNomePopular)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA FORMA DA COPA BY CODFORMACOPA
    /// </summary>
    /// <param name="descFormaCopa"></param>
    /// <param name="codFormaCopa"></param>
    /// <returns></returns>
    public Boolean atualizaFormaCopa(String descFormaCopa, Int32 codFormaCopa)
    {
        try
        {
            if (Convert.ToInt32(_FormaCopa.UpdateFormaCopa(descFormaCopa, codFormaCopa)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM PARASITA BY CODPARASITA
    /// </summary>
    /// <param name="descParasita"></param>
    /// <param name="codParasita"></param>
    /// <returns></returns>
    public Boolean atualizaParasita(String descParasita, Int32 codParasita)
    {
        try
        {
            if (Convert.ToInt32(_Parasitas.UpdateParasita(descParasita, codParasita)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM GRUPOPARASITA BY CODGRUPOPARASITA
    /// </summary>
    /// <param name="descGrupoParasita"></param>
    /// <param name="codGrupoParasita"></param>
    /// <returns></returns>
    public Boolean atualizaGrupoParasita(String descGrupoParasita, Int32 codGrupoParasita)
    {
        try
        {
            if (Convert.ToInt32(_GrupoParasitas.UpdateGrupoParasita(descGrupoParasita, codGrupoParasita)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA O LOCAL AFETADO BY CODLOCALAFETADO
    /// </summary>
    /// <param name="descLocalAfetado"></param>
    /// <param name="codLocalAfetado"></param>
    /// <returns></returns>
    public Boolean atualizaLocalAfetado(String descLocalAfetado, Int32 codLocalAfetado)
    {
        try
        {
            if (Convert.ToInt32(_LocalAfetado.UpdateLocalAfetado(descLocalAfetado, codLocalAfetado)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA INTENSIDADE BY CODINTENSIDADE
    /// </summary>
    /// <param name="descIntensidade"></param>
    /// <param name="codIntensidade"></param>
    /// <returns></returns>
    public Boolean atualizaIntensidade(String descIntensidade, Int32 codIntensidade)
    {
        try
        {
            if (Convert.ToInt32(_Intensidade.UpdateIntensidade(descIntensidade, codIntensidade)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA AÇÃO RECOMENDADA BY CODACAORECOMENDADA
    /// </summary>
    /// <param name="descAcaoRecomendada"></param>
    /// <param name="codAcaoRecomendada"></param>
    /// <returns></returns>
    public Boolean atualizaAcaoRecomendada(String descAcaoRecomendada, Int32 codAcaoRecomendada)
    {
        try
        {
            if (Convert.ToInt32(_AcaoRecomendada.UpdateAcaoRecomendada(descAcaoRecomendada, codAcaoRecomendada)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA O LOCAL ENTORNO DA ÁRVORE
    /// </summary>
    /// <param name="descLocalEntorno"></param>
    /// <param name="codLocalEntorno"></param>
    /// <returns></returns>
    public Boolean atualizaLocalEntorno(String descLocalEntorno, Int32 codLocalEntorno)
    {
        try
        {
            if (Convert.ToInt32(_LocalEntorno.UpdateLocalEntorno(descLocalEntorno, codLocalEntorno)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA PARTICIPAÇÃO BY CODPARTICIPACAO
    /// </summary>
    /// <param name="descParticipacao"></param>
    /// <param name="codParticipacao"></param>
    /// <returns></returns>
    public Boolean atualizaParticipacao(String descParticipacao, Int32 codParticipacao)
    {
        try
        {
            if (Convert.ToInt32(_Participacao.UpdateParticipacao(descParticipacao, codParticipacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA PAVIMENTO BY CODPAVIMENTO
    /// </summary>
    /// <param name="descPavimento"></param>
    /// <param name="codPavimento"></param>
    /// <returns></returns>
    public Boolean atualizaPavimento(String descPavimento, Int32 codPavimento)
    {
        try
        {
            if (Convert.ToInt32(_Pavimento.UpdatePavimento(descPavimento, codPavimento)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM TIPO DE LOGRADOURO BY CODTIPOLOGRADOURO
    /// </summary>
    /// <param name="descTipoLogradouro"></param>
    /// <param name="codTipoLogradouro"></param>
    /// <returns></returns>
    public Boolean atualizaTipoLogradouro(String descTipoLogradouro, Int32 codTipoLogradouro)
    {
        try
        {
            if (Convert.ToInt32(_TipoLogradouro.UpdateTipoLogradouro(descTipoLogradouro, codTipoLogradouro)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #region ATUALIZAÇÃO DE INTERFERÊNCIAS
    /// <summary>
    /// ATUALIZA UMA ILUMINAÇÃO
    /// </summary>
    /// <param name="descIluminacao"></param>
    /// <param name="codIluminacao"></param>
    /// <returns></returns>
    public Boolean atualizaIluminacao(String descIluminacao, Int32 codIluminacao)
    {
        try
        {
            if (Convert.ToInt32(_Iluminacacao.UpdateIluminacao(descIluminacao, codIluminacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM MURO EDIFICAÇÃO
    /// </summary>
    /// <param name="descMuroEdificacao"></param>
    /// <param name="codMuroEdificacao"></param>
    /// <returns></returns>
    public Boolean atualizaMuroEdificacao(String descMuroEdificacao, Int32 codMuroEdificacao)
    {
        try
        {
            if (Convert.ToInt32(_MuroEdificacao.UpdateMuroEdificacao(descMuroEdificacao, codMuroEdificacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM POSTEAMENTO
    /// </summary>
    /// <param name="descPosteamento"></param>
    /// <param name="codPosteamento"></param>
    /// <returns></returns>
    public Boolean atualizaPosteamento(String descPosteamento, Int32 codPosteamento)
    {
        try
        {
            if (Convert.ToInt32(_Posteamento.UpdatePosteamento(descPosteamento, codPosteamento)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA RAIZ PAVIMENTO
    /// </summary>
    /// <param name="descRaizPavimento"></param>
    /// <param name="codRaizPavimento"></param>
    /// <returns></returns>
    public Boolean atualizaRaizPavimento(String descRaizPavimento, Int32 codRaizPavimento)
    {
        try
        {
            if (Convert.ToInt32(_RaizPavimento.UpdateRaizPavimento(descRaizPavimento, codRaizPavimento)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA SINALIZAÇÃO
    /// </summary>
    /// <param name="descSinalizacao"></param>
    /// <param name="codSinalizacao"></param>
    /// <returns></returns>
    public Boolean atualizaSinalizacao(String descSinalizacao, Int32 codSinalizacao)
    {
        try
        {
            if (Convert.ToInt32(_Sinalizacao.UpdateSinalizacao(descSinalizacao, codSinalizacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UMA SITUAÇÃO DA FIAÇÃO
    /// </summary>
    /// <param name="descSituacaoFiacao"></param>
    /// <param name="codSituacaoFiacao"></param>
    /// <returns></returns>
    public Boolean atualizaSituacaoFiacao(String descSituacaoFiacao, Int32 codSituacaoFiacao)
    {
        try
        {
            if (Convert.ToInt32(_SituacaoFiacao.UpdateSituacaoFiacao(descSituacaoFiacao, codSituacaoFiacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM TIPO DE FIAÇÃO
    /// </summary>
    /// <param name="descTipoFiacao"></param>
    /// <param name="codTipoFiacao"></param>
    /// <returns></returns>
    public Boolean atualizaTipoFiacao(String descTipoFiacao, Int32 codTipoFiacao)
    {
        try
        {
            if (Convert.ToInt32(_TipoFiacao.UpdateTipoFiacao(descTipoFiacao, codTipoFiacao)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA UM TRÁFEGO
    /// </summary>
    /// <param name="descTrafego"></param>
    /// <param name="codTrafego"></param>
    /// <returns></returns>
    public Boolean atualizaTrafego(String descTrafego, Int32 codTrafego)
    {
        try
        {
            if (Convert.ToInt32(_Trafego.UpdateTrafego(descTrafego, codTrafego)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    #endregion

    #region EXCLUSÃO
    /// <summary>
    /// DELETA AS COORDENADAS GEOGRÁFICAS DE UMA DETERMINADA ÁRVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean deletaCoordenadas(Int32 codArvore)
    {
        try
        {
            if (Convert.ToInt32(_Coordenadas.DeleteCoordenadasBycodArvore(codArvore)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA NOME POPULAR DE UMA ESPÉCIE BY CODNOMEPOPULAR
    /// </summary>
    /// <param name="codNomePopular"></param>
    /// <returns></returns>
    public Boolean deletaNomePopular(Int32 codNomePopular)
    {
        try
        {
            if (Convert.ToInt32(_NomeComum.DeleteNomeComum(codNomePopular)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UM DETERMINADO CEP
    /// </summary>
    /// <param name="sCEP"></param>
    /// <returns></returns>
    public Boolean deletaCEP(String sCEP)
    {
        try
        {
            //if (buscaLocalizacaoBysCEP(sCEP) != null)
            //    return false;
            //else
            //{
            _CEP.DeleteCEP(sCEP);
            return true;
            //}
        }

        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// EXCLUIR FAMILIA PELO CODIGO DA FAMILIA
    /// </summary>
    /// <param name="codFamilia"></param>
    /// <returns></returns>
    public Boolean deletaFamilia(Int32 codFamilia)
    {
        try
        {
            DataSetCidadeVerde.tblGeneroDataTable dtGenero = buscaGeneros();
            foreach (DataSetCidadeVerde.tblGeneroRow generos in dtGenero)
            {
                if (generos.codFamilia == codFamilia)
                    throw new Exception();
            }
            //Deleta a Familia
            _Familia.DeleteFamilia(codFamilia);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// EXCLUIR GENERO PELO CODIGO DA GENERO
    /// </summary>
    /// <param name="codGenero"></param>
    /// <returns></returns>
    public Boolean deletaGenero(Int32 codGenero)
    {
        try
        {
            DataSetCidadeVerde.tblEspecieDataTable dtEspecie = buscaEspecies();
            foreach (DataSetCidadeVerde.tblEspecieRow especies in dtEspecie)
            {
                if (especies.codGenero == codGenero)
                    throw new Exception();
            }
            //Deleta a Familia
            _Genero.DeleteGenero(codGenero);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// EXCLUIR FORMA DA COPA PELO CODIGO DA FORMA DA COPA
    /// </summary>
    /// <param name="codFormaCopa"></param>
    /// <returns></returns>
    public Boolean deletaFormaCopa(Int32 codFormaCopa)
    {
        try
        {
            DataSetCidadeVerde.tblEspecieDataTable dtEspecie = buscaEspecies();
            foreach (DataSetCidadeVerde.tblEspecieRow especies in dtEspecie)
            {
                if (especies.codFormaCopa == codFormaCopa)
                    throw new Exception();
            }
            //Deleta a Familia
            _FormaCopa.DeleteFormaCopa(codFormaCopa);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    ///  EXCLUIR PARASITA PELO CODIGO DO PARASITA
    /// </summary>
    /// <param name="codParasita"></param>
    /// <returns></returns>
    public Boolean deletaParasita(Int32 codParasita)
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable dtDoenca = buscaDoencas();
            foreach (DataSetCidadeVerde.tblDoencasRow doenca in dtDoenca)
            {
                if (!doenca.IscodParasitaNull())
                {
                    if (doenca.codParasita == codParasita)
                        throw new Exception();
                }
            }
            //Deleta a Parasita
            _Parasitas.DeleteParasita(codParasita);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    ///  EXCLUIR GRUPO DE PARASITA PELO CODIGO DO GRUPO DE PARASITA 
    /// </summary>
    /// <param name="codGrupoParasita"></param>
    /// <returns></returns>
    public Boolean deletaGrupoParasita(Int32 codGrupoParasita)
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable dtDoenca = buscaDoencas();
            foreach (DataSetCidadeVerde.tblDoencasRow doenca in dtDoenca)
            {
                if (!doenca.IscodGrupoParasitaNull())
                {
                    if (doenca.codGrupoParasita == codGrupoParasita)
                        throw new Exception();
                }
            }
            //Deleta a Grupo de Parasita
            _GrupoParasitas.DeleteGrupoParasita(codGrupoParasita);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA LOCAL AFETADO PELO CODIGO DO LOCAL AFETADO
    /// </summary>
    /// <param name="codLocalAfetado"></param>
    /// <returns></returns>
    public Boolean deletaLocalAfetado(Int32 codLocalAfetado)
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable dtDoenca = buscaDoencas();
            foreach (DataSetCidadeVerde.tblDoencasRow doenca in dtDoenca)
            {
                if (!doenca.IscodLocalAfetadoNull())
                {
                    if (doenca.codLocalAfetado == codLocalAfetado)
                        throw new Exception();
                }
            }
            //Deleta o Local Afetado
            _LocalAfetado.DeleteLocalAfetado(codLocalAfetado);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA INTENSIDADE PELO CODIGO DA INTENSIDADE
    /// </summary>
    /// <param name="codIntensidade"></param>
    /// <returns></returns>
    public Boolean deletaIntensidade(Int32 codIntensidade)
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable dtDoenca = buscaDoencas();
            foreach (DataSetCidadeVerde.tblDoencasRow doenca in dtDoenca)
            {
                if (!doenca.IscodIntensidadeNull())
                {
                    if (doenca.codIntensidade == codIntensidade)
                        throw new Exception();
                }
            }
            //Deleta o Intensidade
            _Intensidade.DeleteIntensidade(codIntensidade);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA AÇÃO RECOMENDADA PELO CODIGO DA AÇÃO RECOMENDADA
    /// </summary>
    /// <param name="codAcaoRecomendada"></param>
    /// <returns></returns>
    public Boolean deletaAcaoRecomendada(Int32 codAcaoRecomendada)
    {
        try
        {
            DataSetCidadeVerde.tblHistoricoArvoreDataTable dtHistorico = buscaHistorico();
            foreach (DataSetCidadeVerde.tblHistoricoArvoreRow historico in dtHistorico)
            {
                if (!historico.IscodAcaoRecomendadaNull())
                {
                    if (historico.codAcaoRecomendada == codAcaoRecomendada)
                        throw new Exception();
                }
            }
            //Deleta a Ação Recomendada
            _AcaoRecomendada.DeleteAcaoRecomendada(codAcaoRecomendada);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA LOCAL ENTORNO PELO CODIGO DO LOCAL ENTORNO
    /// </summary>
    /// <param name="codLocalEntorno"></param>
    /// <returns></returns>
    public Boolean deletaLocalEntorno(Int32 codLocalEntorno)
    {
        try
        {
            DataSetCidadeVerde.tblEntornoDataTable dtEntornoArvore = buscaEntornos();
            foreach (DataSetCidadeVerde.tblEntornoRow entorno in dtEntornoArvore)
            {
                if (!entorno.IscodLocalEntornoNull())
                {
                    if (entorno.codLocalEntorno == codLocalEntorno)
                        throw new Exception();
                }
            }
            //Deleta o Local Entorno
            _LocalEntorno.DeleteLocalEntorno(codLocalEntorno);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA PARTICIPAÇÃO PELO CODIGO DA PARTICIPAÇÃO
    /// </summary>
    /// <param name="codParticipacao"></param>
    /// <returns></returns>
    public Boolean deletaParticipacao(Int32 codParticipacao)
    {
        try
        {
            DataSetCidadeVerde.tblEntornoDataTable dtEntornoArvore = buscaEntornos();
            foreach (DataSetCidadeVerde.tblEntornoRow entorno in dtEntornoArvore)
            {
                if (!entorno.IscodParticipacaoNull())
                {
                    if (entorno.codParticipacao == codParticipacao)
                        throw new Exception();
                }
            }
            //Deleta a Participacao
            _Participacao.DeleteParticipacao(codParticipacao);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA PAVIMENTO PELO CODIGO DA PAVIMENTO
    /// </summary>
    /// <param name="codPavimento"></param>
    /// <returns></returns>
    public Boolean deletaPavimento(Int32 codPavimento)
    {
        try
        {
            DataSetCidadeVerde.tblEntornoDataTable dtEntornoArvore = buscaEntornos();
            foreach (DataSetCidadeVerde.tblEntornoRow entorno in dtEntornoArvore)
            {
                if (!entorno.IscodPavimentoNull())
                {
                    if (entorno.codPavimento == codPavimento)
                        throw new Exception();
                }
            }
            //Deleta o Pavimento
            _Pavimento.DeletePavimento(codPavimento);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA O TIPO DE LOGRADOURO PELO CODIGO DO TIPOLOGRADOURO
    /// </summary>
    /// <param name="codTipoLogradouro"></param>
    /// <returns></returns>
    public Boolean deletaTipoLogradouro(Int32 codTipoLogradouro)
    {
        try
        {
            DataSetCidadeVerde.tblLocalizacaoDataTable dtLocalizacao = buscaLocalizacao();
            foreach (DataSetCidadeVerde.tblLocalizacaoRow localizacao in dtLocalizacao)
            {
                if (!localizacao.IscodTipoLogradouroNull())
                {
                    if (localizacao.codTipoLogradouro == codTipoLogradouro)
                        throw new Exception();
                }
            }
            DataSetCidadeVerde.tblCEPDataTable dtCEP = buscaCEPs();
            foreach (DataSetCidadeVerde.tblCEPRow cep in dtCEP)
            {
                if (!cep.IscodTipoLogradouroNull())
                {
                    if (cep.codTipoLogradouro == codTipoLogradouro)
                        throw new Exception();
                }
            }
            //Deleta o Tipo de Logradouro
            _TipoLogradouro.DeleteTipoLogradouro(codTipoLogradouro);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UMA DETERMINADA ESPECIE
    /// </summary>
    /// <param name="codEspecie"></param>
    /// <returns></returns>
    public Boolean deletaEspecie(Int32 codEspecie)
    {
        try
        {
            DataSetCidadeVerde.tblNomeComumDataTable dtNomePopular = buscaNomePopular();
            foreach (DataSetCidadeVerde.tblNomeComumRow nomePopular in dtNomePopular)
            {
                if (!nomePopular.IscodEspecieNull())
                {
                    if (nomePopular.codEspecie == codEspecie)
                        throw new Exception();
                }
            }
            DataSetCidadeVerde.tblArvoreDataTable dtArvore = buscaArvores();
            foreach (DataSetCidadeVerde.tblArvoreRow arvore in dtArvore)
            {
                if (!arvore.IscodEspecieNull())
                {
                    if (arvore.codEspecie == codEspecie)
                        throw new Exception();
                }
            }
            //Deleta a Espécie
            _Especie.DeleteEspecie(codEspecie);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// DELETA UMA ARVORE PELO CODIGO DA ARVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Boolean deletaArvore(Int32 codArvore)
    {
        try
        {
            //Verifica essa árvore tem doença
            DataSetCidadeVerde.tblDoencasDataTable dtDoenca = buscaDoencas();
            foreach (DataSetCidadeVerde.tblDoencasRow doenca in dtDoenca)
            {
                if (!doenca.IscodArvoreNull())
                {
                    if (doenca.codArvore == codArvore)
                        throw new Exception();
                }
            }
            //Verifica essa árvore tem Injúria
            DataSetCidadeVerde.tblInjuriasDataTable dtInjuria = buscaInjurias();
            foreach (DataSetCidadeVerde.tblInjuriasRow injuria in dtInjuria)
            {
                if (!injuria.IscodArvoreNull())
                {
                    if (injuria.codArvore == codArvore)
                        throw new Exception();
                }
            }
            //Verifica essa árvore tem Histórico
            DataSetCidadeVerde.tblHistoricoArvoreDataTable dtAcoes = buscaHistorico();
            foreach (DataSetCidadeVerde.tblHistoricoArvoreRow acoes in dtAcoes)
            {
                if (!acoes.IscodArvoreNull())
                {
                    if (acoes.codArvore == codArvore)
                        throw new Exception();
                }
            }
            //Deleta a Interferência da Árvore
            _Interferencia.DeleteInterferencia(codArvore);
            //Deleta o Entorno da Árvore
            _Entorno.DeleteEntorno(codArvore);
            //Deleta a Localização da Árvore
            _Localizacao.DeleteLocalizacao(codArvore);
            //Deleta a Coordenada da Árvore
            _Coordenadas.DeleteCoordenadasBycodArvore(codArvore);
            //Deleta a Árvore
            _Arvore.DeleteArvore(codArvore);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// EXCLUI UMA DOENÇA PELO CODIGO DA DOENÇA
    /// </summary>
    /// <param name="codDoenca"></param>
    /// <returns></returns>
    public Boolean deletaDoenca(Int32 codDoenca)
    {
        try
        {
            _Doencas.DeleteDoenca(codDoenca);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// EXCLUI UMA INJURIA PELO CODIGO DA INJURIA
    /// </summary>
    /// <param name="codInjuria"></param>
    /// <returns></returns>
    public Boolean deletaInjuria(Int32 codInjuria)
    {
        try
        {
            _Injurias.DeleteInjuria(codInjuria);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// EXCLUI UMA AÇÃO PELO CODIGO DA AÇÃO
    /// </summary>
    /// <param name="codHistorico"></param>
    /// <returns></returns>
    public Boolean deletaAcao(Int32 codAcao)
    {
        try
        {
            _Historico.DeleteHistoricoArvore(codAcao);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// EXCLUI UM USUÁRIO PELO CODIGO DO USUÁRIO
    /// </summary>
    /// <param name="codUsuario"></param>
    /// <returns></returns>
    public Boolean deletaUsuario(Int32 codUsuario)
    {
        try
        {
            _Usuario.DeleteUsuario(codUsuario);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    #region EXCLUSÃO DE INTERFERÊNCIAS
    /// <summary>
    /// DELETA UMA ILUMINAÇÃO PELO CODIGO DA ILUMINAÇÃO
    /// </summary>
    /// <param name="sCEP"></param>
    /// <returns></returns>
    public Boolean deletaIluminacao(Int32 codIluminacao)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codIluminacao == codIluminacao)
                    throw new Exception();
            }
            //Deleta a Iluminacação
            _Iluminacacao.DeleteIluminacao(codIluminacao);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UM MURO EDIFICAÇÃO PELO CODIGO DO MURO EDIFICAÇÃO
    /// </summary>
    /// <param name="sCEP"></param>
    /// <returns></returns>
    public Boolean deletaMuro(Int32 codMuro)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codMuroEdificacao == codMuro)
                    throw new Exception();
            }
            //Deleta o Muro Edificação
            _MuroEdificacao.DeleteMuroEdificacao(codMuro);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UM POSTEAMENTO PELO CODIGO DO POSTEAMENTO
    /// </summary>
    /// <param name="sCEP"></param>
    /// <returns></returns>
    public Boolean deletaPosteamento(Int32 codPosteamento)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codPosteamento == codPosteamento)
                    throw new Exception();
            }
            //Deleta o Posteamento
            _Posteamento.DeletePosteamento(codPosteamento);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UMA SINALIZAÇÃO PELO CODIGO DA SINALIZAÇÃO
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public Boolean deletaSinalizacao(Int32 codSinalizacao)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codSinalizacao == codSinalizacao)
                    throw new Exception();
            }
            //Deleta a Sinalizacao
            _Sinalizacao.DeleteSinalizacao(codSinalizacao);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UMA SITUAÇÃO DA FIAÇÃO PELO CODIGO DA SITUAÇÃO DA FIAÇÃO
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public Boolean deletaSituacaoFiacao(Int32 codSituacaoFiacao)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codSituacaoFiacao == codSituacaoFiacao)
                    throw new Exception();
            }
            //Deleta a Situaçao da Fiação
            _SituacaoFiacao.DeleteSituacaoFiacao(codSituacaoFiacao);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UMA TIPO DE FIAÇÃO PELO CODIGO DO TIPO DE FIAÇÃO
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public Boolean deletaTipoFiacao(Int32 codTipoFiacao)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codTipoFiacao == codTipoFiacao)
                    throw new Exception();
            }
            //Deleta o Tipo de Fiação
            _TipoFiacao.DeleteTipoFiacao(codTipoFiacao);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UMA RAIZ NO PAVIMENTO PELO CODIGO DA RAIZ DO PAVIMENTO
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public Boolean deletaRaizPavimento(Int32 codRaizPavimento)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codRaizPavimento == codRaizPavimento)
                    throw new Exception();
            }
            //Deleta a Raiz no Pavimento
            _RaizPavimento.DeleteRaizPavimento(codRaizPavimento);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// DELETA UM TRÁFEGO PELO CODIGO DO TRÁFEGO
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public Boolean deletaTrafego(Int32 codTrafego)
    {
        try
        {
            DataSetCidadeVerde.tblInterferenciaDataTable dtInterferencia = buscaInterferencias();
            foreach (DataSetCidadeVerde.tblInterferenciaRow linhaInter in dtInterferencia)
            {
                if (linhaInter.codTrafego == codTrafego)
                    throw new Exception();
            }
            //Deleta o Tráfego
            _Trafego.DeleteTrafego(codTrafego);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    #endregion

    #region FUNÇÕES ESPECIFICAS
    /// <summary>
    /// RETORNA A QUANTIDADE DE DOENÇAS DE UMA DETERMIDADA ÁRVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Int32 quantDoencasArvore(Int32 codArvore)
    {
        try
        {
            Int32 quantDoencas = Convert.ToInt32(_Doencas.ScalarQuantDoencasArvore(codArvore).ToString());
            if (quantDoencas > 0)
                return quantDoencas;
            else
                return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// RETORNA A QUANTIDADE DE INJURIAS DE UMA DETERMIDADA ÁRVORE
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Int32 quantInjuriasArvore(Int32 codArvore)
    {
        try
        {
            Int32 quantDoencas = Convert.ToInt32(_Injurias.ScalarQuantInjuriasArvore(codArvore).ToString());
            if (quantDoencas > 0)
                return quantDoencas;
            else
                return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    /// <summary>
    /// RETORNA A QUANTIDADE DE INTERFERENCIAS
    /// </summary>
    /// <param name="codArvore"></param>
    /// <returns></returns>
    public Int32 quantInterferencias()
    {
        return (Int32)(_Interferencia.getQuantInterferencias());
    }

    #region ATUALIZA USUARIO
    /// <summary>
    /// ATUALIZA SENHA BY CodUsuario
    /// </summary>
    /// <param name="codUsuario"></param>
    /// <returns></returns>
    public Boolean atualizaSenhaByCodUsuario(Int32 codUsuario)
    {
        try
        {
            if (Convert.ToInt32(_Usuario.UpdateSenhaByCodUsuario(codUsuario)) > 0)
                return true;
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA SENHA BY sLogin
    /// </summary>
    /// <param name="codUsuario"></param>
    /// <returns></returns>
    public Boolean atualizaSenhaBysLogin(String login)
    {
        try
        {
            if (Convert.ToInt32(_Usuario.UpdateSenhaBysLogin(login)) > 0)
                return true;
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIIZA SENHA DO USUÁRIO LOGADO BY CODUSUARIO
    /// </summary>
    /// <param name="codUsuario"></param>
    /// <returns></returns>
    public Boolean atualizaMinhaSenhaByCodUsuario(String novaSenha, Int32 codUsuario)
    {
        try
        {
            if (Convert.ToInt32(_Usuario.UpdateMinhaSenha(novaSenha, codUsuario)) > 0)
                return true;
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA O USUÁRIO PELO CODIGO DO USUÁRIO
    /// </summary>
    /// <param name="cpf"></param>
    /// <param name="nome"></param>
    /// <param name="tipo"></param>
    /// <param name="email"></param>
    /// <param name="telefone"></param>
    /// <param name="codUsuario"></param>
    /// <returns></returns>
    public Boolean atualizaUsuarioByCodUsuario(String cpf, String nome, Int32 tipo, String email, String telefone, Int32 codUsuario)
    {
        try
        {
            if (Convert.ToInt32(_Usuario.UpdateUsuarioByCodUsuario(cpf, nome, tipo, email, telefone, codUsuario)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA O USUÁRIO PELO LOGIN DO USUARIO
    /// </summary>
    /// <param name="cpf"></param>
    /// <param name="nome"></param>
    /// <param name="email"></param>
    /// <param name="telefone"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public Boolean atualizaUsuarioBysLogin(String cpf, String nome, String email, String telefone, String login)
    {
        try
        {
            if (Convert.ToInt32(_Usuario.UpdateUsuarioBysLogin(cpf, nome, email, telefone, login)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// ATUALIZA OS DADOS PESSOAIS DO USUÁRIO LOGADO BY CODUSUARIO
    /// </summary>
    /// <param name="cpf"></param>
    /// <param name="nome"></param>
    /// <param name="email"></param>
    /// <param name="telefone"></param>
    /// <param name="codUsuario"></param>
    /// <returns></returns>
    public Boolean atualizaMeusDados(String cpf, String nome, String email, String telefone, Int32 codUsuario)
    {
        try
        {
            if (Convert.ToInt32(_Usuario.UpdateMeusDados(cpf, nome, email, telefone, codUsuario)) > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion
    #endregion

    #region RELATÓRIOS
    /// <summary>
    /// LISTA A QUANTIDADE DE ARVORES DOENTES, ARVORES DOENTES QUE FORAM RECUPERADAS E O MES DESSAS QUANTIDADES
    /// </summary>
    /// <param name="ano"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.dtRelatoriosAnualDataTable RelatQuantArvDoentesByAno(Int32 ano)
    {
        try
        {
            DataSetCidadeVerde.dtRelatoriosAnualDataTable resultado = _RelatorioAnual.GetRelatQuantArvDoentesByAno(ano);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA OS ANOS QUE TEM ARVORES DOENTES
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblDoencasDataTable pegaAnosDoencas()
    {
        try
        {
            DataSetCidadeVerde.tblDoencasDataTable resultado = _Doencas.GetAnosDoencas();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// LISTA A QUANTIDADE DE ARVORES INJURIADAS, ARVORES INJURIADAS QUE FORAM RECUPERADAS E O MES DESSAS QUANTIDADES
    /// </summary>
    /// <param name="ano"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.dtRelatoriosAnualDataTable RelatQuantArvInjuriadasByAno(Int32 ano)
    {
        try
        {
            DataSetCidadeVerde.dtRelatoriosAnualDataTable resultado = _RelatorioAnual.GetRelatQuantArvInjuriadasByAno(ano);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA OS ANOS QUE TEM ARVORES INJURIADAS
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblInjuriasDataTable pegaAnosInjurias()
    {
        try
        {
            DataSetCidadeVerde.tblInjuriasDataTable resultado = _Injurias.GetAnosInjurias();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// LISTA A QUANTIDADE DE ARVORES QUE TIVERAM AÇÕES CADASTRADAS E QUAIS FORAM CONCLUÍDAS E O MES DESSAS QUANTIDADES
    /// </summary>
    /// <param name="ano"></param>
    /// <returns></returns>
    public DataSetCidadeVerde.dtRelatoriosAnualDataTable RelatQuantArvAcoesByAno(Int32 ano)
    {
        try
        {
            DataSetCidadeVerde.dtRelatoriosAnualDataTable resultado = _RelatorioAnual.GetRelatQuantArvAcoesByAno(ano);
            if (resultado.Rows.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    /// <summary>
    /// BUSCA OS ANOS QUE TEVE ALGUMA AÇÃO CADASTRADA
    /// </summary>
    /// <returns></returns>
    public DataSetCidadeVerde.tblHistoricoArvoreDataTable pegaAnosAcao()
    {
        try
        {
            DataSetCidadeVerde.tblHistoricoArvoreDataTable resultado = _Historico.GetAnosHistorico();
            if (resultado.Count > 0)
                return resultado;
            else
                return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion

    #endregion
}


