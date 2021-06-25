using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaPatrimonio
{
    public partial class frmFuncionario : Form
    {
        String siapeFunc = string.Empty;
        DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter _Funcionario = new DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter();

        public frmFuncionario()
        {
            InitializeComponent();
        }

        private void frmFuncionario_Shown(object sender, EventArgs e)
        {
            dgvFuncionarios.DataSource = _Funcionario.GetDataBysNome("%" + txtNome.Text.Trim() + "%");
            txtNome.Focus();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            //btPesquisar_Click(null, null);
            dgvFuncionarios.DataSource = _Funcionario.GetDataBysNome("%" + txtNome.Text.Trim() + "%");
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            dgvFuncionarios.DataSource = _Funcionario.GetDataBysNome("%" + txtNome.Text.Trim() + "%");
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            frmNovoFuncionario frmNovo = new frmNovoFuncionario();
            frmNovo.ShowDialog();
            dgvFuncionarios.DataSource = _Funcionario.GetDataBysNome("%" + txtNome.Text.Trim() + "%");
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal.frmFunc = new frmFuncionario();
        }

        private void dgvFuncionarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvFuncionarios.ColumnCount > 0)
            {
                foreach (DataGridViewColumn coluna in dgvFuncionarios.Columns)
                {
                    switch (coluna.Name)
                    {
                        case "Nome":
                            coluna.DisplayIndex = 0;
                            coluna.HeaderText = "Nome";
                            coluna.Width = 480;
                            break;
                        case "siape":
                            coluna.DisplayIndex = 1;
                            coluna.HeaderText = "SIAPE";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 110;
                            break;
                        case "btDetalhes":
                            coluna.DisplayIndex = 2;
                            coluna.ToolTipText = "Histórico";
                            coluna.HeaderText = "Hist.";
                            coluna.Width = 30;
                            break;
                        default:
                            coluna.Visible = false;
                            break;
                    }
                }
            }
            if (dgvFuncionarios.RowCount > 0)
            {

                foreach (DataGridViewRow row in dgvFuncionarios.Rows)
                {
                    row.Cells["Nome"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir.";
                    row.Cells["siape"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir.";
                    //row.Cells["btDetalhes"].Value = "...";
                    row.Cells["btDetalhes"].ToolTipText = "Clique aqui para ver o histórico de movimentações.";
                }
            }
            dgvFuncionarios.ClearSelection();
        }

        private void dgvFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmNovoFuncionario frmNovo = new frmNovoFuncionario();
            frmNovo.txtNome.Text = dgvFuncionarios.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
            frmNovo.txtSiape.Text = frmNovo.siapeOriginal = dgvFuncionarios.Rows[e.RowIndex].Cells["siape"].Value.ToString();
            frmNovo.tipoOperacao = 1; //Atualização
            frmNovo.ShowDialog();
            dgvFuncionarios.DataSource = _Funcionario.GetDataBysNome("%" + txtNome.Text.Trim() + "%");
            //MessageBox.Show("Abrir tela de edição do Funcionario.");
            ////limpaCampos();
            ////string ende = dgvPessoas.Rows[e.RowIndex].Cells["logradouro"].Value.ToString();
            //int codPessoaSelecionada = (int)dgvPessoas.Rows[e.RowIndex].Cells["codPessoa"].Value;
            //DataSetMadeireira.tblPessoaDataTable dtPessoa = mad.buscaPessoaPeloCodPessoa(codPessoaSelecionada);
            //codCadPessoa = codPessoaSelecionada;

            ////Pessoa Física - Cliente 
            //if (dtPessoa[0].tipoPessoa == 3 && !dtPessoa[0].IssexoNull())
            //{
            //    txtNome.Text = dtPessoa[0].nome;
            //    txtCPF.Text = dtPessoa[0].cpf_cnpj;
            //}
        }

        private void dgvFuncionarios_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //   MessageBox.Show("Clique com o botao direito do mouse.");
            //MessageBox.Show(this.dgvFuncionarios.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dgvFuncionarios_MouseUp(object sender, MouseEventArgs e)
        {
            dgvFuncionarios.MultiSelect = false;

            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info;
                info = dgvFuncionarios.HitTest(e.X, e.Y);
                if (info.Type == DataGridViewHitTestType.Cell)
                {
                    if (info.Type == DataGridViewHitTestType.Cell && info.ColumnIndex == 1)
                        dgvFuncionarios.CurrentCell.Selected = false;
                    dgvFuncionarios[info.ColumnIndex, info.RowIndex].Selected = true;
                    dgvFuncionarios.Refresh();
                    siapeFunc = dgvFuncionarios.Rows[info.RowIndex].Cells["siape"].Value.ToString();
                    //dgvFuncionarios = Convert.ToInt32(dgvFuncionarios.Rows[info.RowIndex].Cells["codMarca"].Value);
                    contextMenuStrip1.Show(dgvFuncionarios, new Point(e.X, e.Y));
                }
            }
        }

        private void excluirFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
                if (_Mov.GetDataBySiapeFunc(siapeFunc).Rows.Count > 0)
                    MessageBox.Show("Não é possível excluir esse Funcionário!\n\nO Funcionário possui registro de movimentações.", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    _Funcionario.Delete(siapeFunc);
                    MessageBox.Show("Funcionário Excluído com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvFuncionarios.DataSource = _Funcionario.GetDataBysNome("%" + txtNome.Text.Trim() + "%");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Excluir o Funcionário.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFuncionarios.Columns[e.ColumnIndex].Name == "btDetalhes")
                {
                    frmDetalhes frmNovo = new frmDetalhes();
                    frmNovo.tipoConsulta = frmDetalhes.TipoConsulta.Funcionario;
                    frmNovo.sql = dgvFuncionarios.Rows[e.RowIndex].Cells["siape"].Value.ToString();
                    frmNovo.ShowDialog();

                    //frmPrincipal.frmDet.tipoConsulta = frmDetalhes.TipoConsulta.Funcionario;
                    //frmPrincipal.frmDet.sql = dgvFuncionarios.Rows[e.RowIndex].Cells["siape"].Value.ToString();
                    //frmPrincipal.frmDet.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    //frmPrincipal.frmDet.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //faz algo se der erro
            }
        }
        private void frmFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmPrincipal.frmFunc = new frmFuncionario();
        }
    }
}
