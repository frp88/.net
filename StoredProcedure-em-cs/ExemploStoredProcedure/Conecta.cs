using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExemploStoredProcedure
{
    class Conecta
    {
        // Define a String de Conexão com o BD
        static string strConexao =
                    @"SERVER=localhost;DATABASE=bdexemplo;UID=root;PASSWORD=1234";

        // Cria a conexão com o BD
        MySqlConnection con = new MySqlConnection(strConexao);

        // Método que executa os comandos Insert, Update e Delete
        public string ExecutaComandos(MySqlCommand comandoSql)
        {
            try
            {
                con.Open(); // Abre a conexão com BD
                comandoSql.Connection = con;
                comandoSql.ExecuteNonQuery(); // Executa o comando SQL
                return "Ok";
            }
            catch (Exception erro)
            {
                return erro.Message; // retorna a msg de erro
            }
            finally
            {
                con.Close(); // fecha a conexão com o BD
            }
        }

        // Método que retorna um único valor (Ex. SUM, COUNT, ETC.
        public double RetornaValor(MySqlCommand comandoSql)
        {
            try
            {
                con.Open(); // Abre a conexão com BD
                            // Define o comando SQL
                comandoSql.Connection = con;
                // Executa o comando SQL e converte o valor retornado para decimal
                double valor = Convert.ToDouble(comandoSql.ExecuteScalar());
                return valor;
            }
            catch (Exception erro)
            {
                // Imprime o erro no console
                Console.WriteLine("Erro: " + erro.Message);
                throw;
            }
            finally
            {
                con.Close(); // Fecha a conexão com BD
            }
        }

        // Método que retorna um conjunto de registros de uma tabela do BD
        public DataTable RetornaTabela(MySqlCommand comandoSql)
        {
            try
            {
                con.Open(); // Abre a conexão com o BD
                            // Define o comando SQL (select)
                comandoSql.Connection = con;
                // Executa o comando SQL e armazena os 
                // registros na variável 'dados'
                MySqlDataReader dados = comandoSql.ExecuteReader();
                // Cria um tabela genérica
                DataTable tabela = new DataTable();
                // Carrega os registros para o 'DataTable'
                tabela.Load(dados);
                // Retorna a tabela genérica com os registros
                return tabela;
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro: " + erro.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
