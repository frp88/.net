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

namespace ProjetoVeiculos
{
    public partial class frmCadastroVeiculo : Form
    {
        public frmCadastroVeiculo()
        {
            InitializeComponent();
        }
        
        public void BuscaVeiculos()
        {
            // Define o Comando SQL (SELECT) para recuperar os veículos
            //String comandoSql = "SELECT * FROM tblVeiculo";
            String comandoSql = @"SELECT v.*, m.marca 
                            FROM tblVeiculo v INNER JOIN tblMarca m 
                            ON v.idMarca = m.id";
            // Criar um Objeto da Classe Conecta
            //Conecta conecta = new Conecta();
            ConectaMySQL conecta = new ConectaMySQL();
            // Chama o Método "RetornaTabela" da Classe Conecta
            dgvVeiculos.DataSource = conecta.RetornaTabela(comandoSql);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Define o comando SQL (INSERT)
            String comandoSQL = "INSERT INTO tblVeiculo(modelo, " +
            "ano, preco, idMarca) VALUES ('" + txtModelo.Text + "', " + 
            txtAno.Text + ", " + txtPreco.Text + ", " + 
            cbMarca.SelectedValue +")";
            // Cria/instancia um objeto da classe Conecta
            //Conecta c = new Conecta();
            ConectaMySQL c = new ConectaMySQL();
            // Chamar o Método "ExecutaComando" da classe Conecta
            c.ExecutaComandos(comandoSQL);
            MessageBox.Show("Veículo cadastrado com Sucesso!");
            this.BuscaVeiculos();
            this.btnLimpar_Click(null, null);
        }

        private void frmCadastroVeiculo_Load(object sender, EventArgs e)
        {
            this.AtualizaCodigo();
            this.BuscaVeiculos();
            // Chama a Função que Preenche o ComboBox cbMarca
            this.PreencheComboBoxMarca();
            btnAtualizar.Enabled = false;
        }

        public void PreencheComboBoxMarca() {
            DataTable dtMarca; // Declara a tabela
            // Define o comando SQL para recuperar as marcas
            String comandoSQL = "SELECT id, marca FROM " + 
            "tblMarca ORDER BY marca ASC";
            // Criar um objeto da classe Conecta
            //Conecta con = new Conecta();
            ConectaMySQL con = new ConectaMySQL();
            // Retorna os registros do BD
            dtMarca = con.RetornaTabela(comandoSQL);
            // Define qual coluna será mostrada no ComboBox
            cbMarca.DisplayMember = "marca";
            // Define qual a coluna será utilizada via programação
            cbMarca.ValueMember = "id";
            // Define qual a Fonte de Dados irá preencher o ComboBox
            cbMarca.DataSource = dtMarca;        
        }
        
        public void AtualizaCodigo()
        {
            // Criar um objeto da classe Conecta
            //Conecta conecta = new Conecta();
            ConectaMySQL conecta = new ConectaMySQL();
            int codigo = conecta.RetornaValor("SELECT MAX(id) FROM tblVeiculo") + 1;
            lblCodigo.Text = codigo.ToString();
        }

        private void dgvVeiculos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn coluna in dgvVeiculos.Columns)
            {
                switch (coluna.Name)
                {
                    case "id":
                        coluna.Visible = false;
                        break;
                    case "modelo":
                        coluna.Width = 210;
                        coluna.HeaderText = "Modelo";
                        break;
                    case "ano":
                        coluna.Width = 70;
                        coluna.HeaderText = "Ano";
                        break;
                    case "preco":
                        coluna.Width = 200;
                        coluna.HeaderText = "Preço";
                        //coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //coluna.DefaultCellStyle.BackColor = Color.Blue;
                        //coluna.DefaultCellStyle.ForeColor = Color.White;
                        coluna.DefaultCellStyle.Format = "C2";
                        break;
                    case "Atualizar":
                        coluna.Width = 30;
                        coluna.DisplayIndex = 0;
                        break;
                    case "excluir":
                        coluna.Width = 30;
                        coluna.DisplayIndex = 1;
                        break;
                    case "marca":
                        coluna.Width = 130;
                        break;
                    default:
                        coluna.Visible = false;
                        break;
                }

            }
        }

        private void dgvVeiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVeiculos.Columns[e.ColumnIndex] ==
                dgvVeiculos.Columns["atualizar"])
            {
                // Preenche os TextBox com as informaõçes dos veículos
                txtModelo.Text =
                    dgvVeiculos.Rows[e.RowIndex].Cells["modelo"].Value.ToString();
                txtAno.Text = dgvVeiculos.Rows[e.RowIndex].Cells["ano"].Value.ToString();
                txtPreco.Text = dgvVeiculos.Rows[e.RowIndex].Cells["preco"].Value.ToString();
                lblCodigo.Text = dgvVeiculos.Rows[e.RowIndex].Cells["id"].Value.ToString();
                cbMarca.SelectedValue = dgvVeiculos.Rows[e.RowIndex].Cells["idMarca"].Value.ToString();

                
                btnAtualizar.Enabled = true;
                btnCadastrar.Enabled = false;
            }
            else if (dgvVeiculos.Columns[e.ColumnIndex] ==
                dgvVeiculos.Columns["excluir"])
            {
                if (MessageBox.Show("Deseja Realmente Excluir esse Veículo?",
                    "Confirmar Exclusão", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Excluir o Veículo da linha clicada
                    String comandoSQL = "DELETE FROM tblveiculo WHERE id = " +
                        dgvVeiculos.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    // Cria um objeto da classe Conecta
                    //Conecta conecta = new Conecta();
                    ConectaMySQL conecta = new ConectaMySQL();

                    conecta.ExecutaComandos(comandoSQL);
                    this.BuscaVeiculos();
                    MessageBox.Show("Veículo Excluído com Sucesso!!!");
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            // Define o comando SQL para atualizar o Veículo
            String comandoSQL = "UPDATE tblVeiculo SET modelo = '" +
                txtModelo.Text + "', ano = " + txtAno.Text + ", preco = "
                + txtPreco.Text + ", idMarca = "+ cbMarca.SelectedValue +" where id = " + lblCodigo.Text;
            // Cria um objeto da classe Conecta
            //Conecta con = new Conecta();
            ConectaMySQL con = new ConectaMySQL();

            // Chama a Função que executa o comando SQL
            con.ExecutaComandos(comandoSQL);
            // Atualiza o dgvVeiculos
            this.BuscaVeiculos();
            MessageBox.Show("Veículo Atualizado com Sucesso!");
            this.btnLimpar_Click(null, null);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //txtModelo.Text = txtAno.Text = txtPreco.Text = String.Empty;
            txtModelo.Text = String.Empty;
            txtAno.Text = String.Empty;
            txtPreco.Clear();
            cbMarca.SelectedIndex = 0; // Selecionar o primeiro valor do ComboBox
            btnCadastrar.Enabled = true; // Habilita o botão
            btnAtualizar.Enabled = false;// Desabilita o botão
            txtModelo.Focus(); // Colocar o cursor no componente
            this.AtualizaCodigo();
        }
    }
}
