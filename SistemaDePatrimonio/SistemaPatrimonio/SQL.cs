using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SistemaPatrimonio
{
    public static class SQL
    {
        public static String Conexao = "server=localhost;User Id=root;password=eu;Persist Security Info=True;database=patrimonio";
        public enum RetornoBD
        {
            NonQuery, Scalar
        }

        public static DataTable Select(string query)
        {
            try
            {
                //SqlDataAdapter adp = new SqlDataAdapter(query, Conexao);
                MySqlDataAdapter adp = new MySqlDataAdapter(query, Conexao);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object UpdateDeleteInsert(string query, RetornoBD retornoBD)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query);

                return (retornoBD == RetornoBD.NonQuery ? cmd.ExecuteNonQuery() : cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
