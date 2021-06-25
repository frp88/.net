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
    public partial class frmSala : Form
    {
        DataSetPatrimonioTableAdapters.tblsalaTableAdapter _Sala = new DataSetPatrimonioTableAdapters.tblsalaTableAdapter();
        int idSala = 0;
        public frmSala()
        {
            InitializeComponent();
        }

        private void frmSalaAnexo_Shown(object sender, EventArgs e)
        {
            this.buscaSalas();
            txtNome.Focus();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal.frmSala = new frmSala();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            frmNovaSala frmNovo = new frmNovaSala();
            frmNovo.ShowDialog();
            this.buscaSalas();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            this.buscaSalas();
        }

        private void dgvSala_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmNovaSala frmNovo = new frmNovaSala();
            frmNovo.txtAnexo.Text = dgvSala.Rows[e.RowIndex].Cells["anexo"].Value.ToString();
            frmNovo.txtNumero.Text = dgvSala.Rows[e.RowIndex].Cells["numero"].Value.ToString();
            frmNovo.txtDescricao.Text = dgvSala.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
            frmNovo.IdSalaOriginal = Convert.ToInt32(dgvSala.Rows[e.RowIndex].Cells["idSala"].Value.ToString());
            frmNovo.tipoOperacao = 1; //Atualização
            frmNovo.ShowDialog();
            this.buscaSalas();
        }

        private void dgvSala_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvSala.ColumnCount > 0)
            {
                foreach (DataGridViewColumn coluna in dgvSala.Columns)
                {
                    switch (coluna.Name)
                    {
                        case "anexo":
                            coluna.DisplayIndex = 0;
                            coluna.HeaderText = "Anexo";
                            coluna.ToolTipText = "Anexo";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 150;
                            break;
                        case "numero":
                            coluna.DisplayIndex = 1;
                            coluna.HeaderText = "Número";
                            coluna.ToolTipText = "Número do Local";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 60;
                            break;
                        case "descricao":
                            coluna.DisplayIndex = 2;
                            coluna.HeaderText = "Descrição";
                            coluna.ToolTipText = "Descrição do Local";
                            coluna.Width = 380;
                            break;
                        case "btDetalhes":
                            coluna.DisplayIndex = 3;
                            coluna.ToolTipText = "Histórico de Movimentações";
                            coluna.HeaderText = "Hist.";
                            coluna.Width = 30;
                            break;
                        default:
                            coluna.Visible = false;
                            break;
                    }
                }
            }
            if (dgvSala.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvSala.Rows)
                {
                    //row.Cells["anexo"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["descricao"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    row.Cells["numero"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["btDetalhes"].Value = "...";
                    row.Cells["btDetalhes"].ToolTipText = "Clique aqui para ver o histórico de movimentações.";
                }
            }
            dgvSala.ClearSelection();
        }

        private void dgvSala_MouseUp(object sender, MouseEventArgs e)
        {
            dgvSala.MultiSelect = false;

            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info;
                info = dgvSala.HitTest(e.X, e.Y);
                if (info.Type == DataGridViewHitTestType.Cell)
                {
                    if (info.Type == DataGridViewHitTestType.Cell && info.ColumnIndex == 1)
                        dgvSala.CurrentCell.Selected = false;
                    dgvSala[info.ColumnIndex, info.RowIndex].Selected = true;
                    dgvSala.Refresh();
                    idSala = Convert.ToInt32(dgvSala.Rows[info.RowIndex].Cells["idSala"].Value.ToString());
                    contextMenuStrip1.Show(dgvSala, new Point(e.X, e.Y));
                }
            }
        }
        private void excluirTipoDeBemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
                if (_Mov.GetDataByIdSala(idSala).Rows.Count > 0)
                    MessageBox.Show("Não é possível excluir esse Local!\n\nO local possui registro de movimentações.", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    _Sala.Delete(idSala);
                    MessageBox.Show("Local excluído com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.buscaSalas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Excluir o Local.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void buscaSalas()
        {
            int num = 0;
            int.TryParse(txtNome.Text.Trim(), out num);
            dgvSala.DataSource = _Sala.GetDataByNumPatrimonio_Descricao(num, "%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
        }

        private void dgvSala_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSala.Columns[e.ColumnIndex].Name == "btDetalhes")
                {
                    frmDetalhes frmNovo = new frmDetalhes();
                    frmNovo.tipoConsulta = frmDetalhes.TipoConsulta.Sala;
                    frmNovo.sql = dgvSala.Rows[e.RowIndex].Cells["idSala"].Value.ToString();
                    frmNovo.ShowDialog();
                    //frmPrincipal.frmDet.tipoConsulta = frmDetalhes.TipoConsulta.Sala;
                    //frmPrincipal.frmDet.sql = dgvSala.Rows[e.RowIndex].Cells["idSala"].Value.ToString();
                    //frmPrincipal.frmDet.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    //frmPrincipal.frmDet.Show();
                }
            }
            catch (Exception)
            {
                //faz algo se der erro
            }
        }
        private void frmSala_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmPrincipal.frmSala = new frmSala();
        }
    }
}
