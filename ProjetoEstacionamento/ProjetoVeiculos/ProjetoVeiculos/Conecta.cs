using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVeiculos
{
    // Classe de Conexão com BD
    class Conecta
    {
        // Define String de Conexão com o BD SQL Server
        static String strConexao = @"Data Source=FRP-PC; " +
        "Initial Catalog=bdVeiculo; Integrated Security=True";
        // Cria a Conexão com o BD SQL Server
        SqlConnection con = new SqlConnection(strConexao);

        /// <summary>
        /// Executa os Comandos SQL de INSERT, UPDATE e DELETE
        /// </summary>
        /// <param name="comandoSql"> Recebe a string refererente ao comando SQL</param>
        /// <returns>Retorna TRUE se não der erro e FALSE se der erro</returns>
        public Boolean ExecutaComandos(String comandoSql)
        {
           try
            {
                con.Open(); // Abre a conexão com o BD
                // Define o comando SQL
                SqlCommand comando = new SqlCommand(comandoSql, con);
                // Executa o comando SQL e retorna o total de linhas afetadas no BD
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Retorna um Valor Inteiro
        /// </summary>
        /// <param name="comandoSQL"></param>
        /// <returns></returns>
        public int RetornaValor(String comandoSQL)
        {
             try
            {
                con.Open(); // Abre conexão com BD
                // Define o comando de consulta
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                // Executa o comando que retorna o último registro
                int valor = Convert.ToInt32(comando.ExecuteScalar());
                return valor;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                throw;
            }
            finally
            {
                con.Close(); // Fecha a Conexão com o BD
            }

        }

        /// <summary>
        /// Retorna os Resgistros de uma Tabela do BD
        /// </summary>
        /// <param name="comandoSQL"></param>
        /// <returns></returns>
        public DataTable RetornaTabela(String comandoSQL)
        {
            try
            {
                con.Open(); // Abre conexão com BD
                // Define o comando de consulta
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                // Cria uma Tabela Genérica (DataTable)
                DataTable tabela = new DataTable();
                // Cria um Adaptador de Dados que recebe o resultado da consulta
                SqlDataAdapter adaptador = new SqlDataAdapter(comandoSQL, con);
                // Adiciona na tabela genérica a estrutura de dados adaptáveis
                adaptador.Fill(tabela);
                // Retorna a tabela (DataTable)
                return tabela;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                throw;
            }
            finally
            {
                con.Close(); // Fecha a Conexão com o BD
            }
        }
    }
}
