using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExemploStoredProcedure
{
    public partial class frmFuncionario : Form
    {
        public frmFuncionario()
        {
            InitializeComponent();
            PreencheDgvFuncionarios();
        }

        // Método que Busca todos os Funcionários do BD
        void PreencheDgvFuncionarios()
        {
            try
            {
                Conecta conecta = new Conecta();
                // Define o comando SQL para executar o Procedimento Armazenado
                MySqlCommand cmd = new MySqlCommand("CALL sp_BuscaFuncionarios()");
                DataTable dt = new DataTable();
                dt = conecta.RetornaTabela(cmd);
                // Popula DataGridView com os registros do DataTable
                dgvFuncionarios.DataSource = dt;
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        // Método que Cadastra Funcionário no BD
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Conecta conecta = new Conecta();
                // Define o Procedimento Armazenado que fará a inserção
                MySqlCommand cmd = new MySqlCommand(@"
                    CALL sp_InsereFuncionario(@nome, @idade, @salario)");
                // Define os valores para os parâmetros do Procedimento Armazenado
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@idade", txtIdade.Text.Trim());
                cmd.Parameters.AddWithValue("@salario", txtSalario.Text.Trim());
                // Executa o comando SQL e retorna o total de linhas afetadas no BD
                conecta.ExecutaComandos(cmd);
                MessageBox.Show("Funcionário Cadastrado com Sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                PreencheDgvFuncionarios();
            }
        }


        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                Conecta conecta = new Conecta();
                // Define o comando SQL para executar o Procedimento Armazenado
                MySqlCommand cmd = new MySqlCommand(@"CALL sp_BuscaFuncionarioPeloId(@id)");
                // Define os parâmetros do Procedimento Armazenado
                cmd.Parameters.AddWithValue("@id", txtIdFuncionario.Text.Trim());

                DataTable dt = conecta.RetornaTabela(cmd);
                // Verifica se a consulta retornou registros
                if (dt.Rows.Count > 0)
                {
                    txtNomeA.Text = dt.Rows[0]["nome"].ToString();
                    txtIdadeA.Text = dt.Rows[0]["idade"].ToString();
                    txtSalarioA.Text = dt.Rows[0]["salario"].ToString();
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado!!!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Conecta conecta = new Conecta();
                // Define o comando SQL para executar o Procedimento Armazenado
                MySqlCommand cmd = new MySqlCommand(@"
                    CALL sp_AtualizaFuncionario(@nome, @idade, @salario, @id)");
                // Define os valores para os parâmetros do Procedimento Armazenado
                cmd.Parameters.AddWithValue("@nome", txtNomeA.Text);
                cmd.Parameters.AddWithValue("@idade", txtIdadeA.Text.Trim());
                cmd.Parameters.AddWithValue("@salario", txtSalarioA.Text.Trim());
                cmd.Parameters.AddWithValue("@id", txtIdFuncionario.Text.Trim());
                // Executa o comando SQL e retorna o total de linhas afetadas no BD
                conecta.ExecutaComandos(cmd);
                MessageBox.Show("Funcionário Atualizado com Sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                PreencheDgvFuncionarios();
            }
        }

        private void btnBuscarFuncionarioE_Click(object sender, EventArgs e)
        {
            try
            {
                Conecta conecta = new Conecta();
                // Define o comando SQL para executar o Procedimento Armazenado
                MySqlCommand cmd = new MySqlCommand("CALL sp_BuscaFuncionarioPeloId(@id)");
                // Define os valores para os parâmetros do Procedimento Armazenado
                cmd.Parameters.AddWithValue("@id", txtIdFuncionarioE.Text.Trim());

                // Cria uma Tabela Genérica auxiliar
                DataTable dt = conecta.RetornaTabela(cmd);
                // Carrega os dados para o DataTable
                if (dt.Rows.Count > 0)
                {
                    lblNome.Text = dt.Rows[0]["nome"].ToString();
                    lblIdade.Text = dt.Rows[0]["idade"].ToString();
                    lblSalario.Text = dt.Rows[0]["salario"].ToString();
                }
                else
                {
                    lblNome.Text = lblIdade.Text = lblSalario.Text = "...";
                    MessageBox.Show("Funcionário não encontrado!!!");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Conecta conecta = new Conecta();
                // Define o comando SQL para executar o Procedimento Armazenado
                MySqlCommand cmd = new MySqlCommand("CALL sp_ExcluiFuncionario(@id)");
                // Define os valores para os parâmetros do Procedimento Armazenado
                cmd.Parameters.AddWithValue("@id", txtIdFuncionarioE.Text.Trim());
                // Executa o comando SQL e retorna o total de linhas afetadas no BD
                conecta.ExecutaComandos(cmd);
                MessageBox.Show("Funcionário Excluído com Sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                PreencheDgvFuncionarios();
            }
        }
    }
}
