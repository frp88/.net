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
    public partial class frmTipoBem : Form
    {
        DataSetPatrimonioTableAdapters.tbltipoTableAdapter _TipoBem = new DataSetPatrimonioTableAdapters.tbltipoTableAdapter();
        int idTipoBem = 0;

        public frmTipoBem()
        {
            InitializeComponent();
        }

        private void frmTipoBem_Shown(object sender, EventArgs e)
        {
            dgvTiposBem.DataSource = _TipoBem.GetDataByDescricao("%" + txtNome.Text.Trim() + "%");
            txtNome.Focus();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            frmNovoTipoBem frmNovo = new frmNovoTipoBem();
            frmNovo.ShowDialog();
            dgvTiposBem.DataSource = _TipoBem.GetDataByDescricao("%" + txtNome.Text.Trim() + "%");
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal.frmTipoBem = new frmTipoBem();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            dgvTiposBem.DataSource = _TipoBem.GetDataByDescricao("%" + txtNome.Text.Trim() + "%");
        }

        private void dgvTiposBem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmNovoTipoBem frmNovo = new frmNovoTipoBem();
            frmNovo.txtDescricaoTipoBem.Text = dgvTiposBem.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
            frmNovo.codTipoBem = Convert.ToInt32(dgvTiposBem.Rows[e.RowIndex].Cells["idTipo"].Value.ToString());
            frmNovo.tipoOperacao = 1; //Atualização
            frmNovo.ShowDialog();
            dgvTiposBem.DataSource = _TipoBem.GetDataByDescricao("%" + txtNome.Text.Trim() + "%");
        }

        private void dgvTiposBem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvTiposBem.ColumnCount > 0)
            {
                foreach (DataGridViewColumn coluna in dgvTiposBem.Columns)
                {
                    switch (coluna.Name)
                    {
                        case "descricao":
                            coluna.DisplayIndex = 0;
                            coluna.HeaderText = "Descrição";
                            coluna.ToolTipText = "Descrição do Tipo de Bem / Equipamento";
                            coluna.Width = 620;
                            break;
                        default:
                            coluna.Visible = false;
                            break;
                    }
                }
            }
            if (dgvTiposBem.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvTiposBem.Rows)
                {
                    row.Cells["descricao"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                }
            }
            dgvTiposBem.ClearSelection();
        }

        private void dgvTiposBem_MouseUp(object sender, MouseEventArgs e)
        {
            dgvTiposBem.MultiSelect = false;

            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info;
                info = dgvTiposBem.HitTest(e.X, e.Y);
                if (info.Type == DataGridViewHitTestType.Cell)
                {
                    if (info.Type == DataGridViewHitTestType.Cell && info.ColumnIndex == 1)
                        dgvTiposBem.CurrentCell.Selected = false;
                    dgvTiposBem[info.ColumnIndex, info.RowIndex].Selected = true;
                    dgvTiposBem.Refresh();
                    idTipoBem = Convert.ToInt32(dgvTiposBem.Rows[info.RowIndex].Cells["idTipo"].Value.ToString());
                    //dgvTiposBem = Convert.ToInt32(dgvTiposBem.Rows[info.RowIndex].Cells["codMarca"].Value);
                    contextMenuStrip1.Show(dgvTiposBem, new Point(e.X, e.Y));
                }
            }
        }

        private void excluirTipoDeBemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetPatrimonioTableAdapters.tblbemTableAdapter _Bem = new DataSetPatrimonioTableAdapters.tblbemTableAdapter();
                if (_Bem.GetDataByIdTipoBem(idTipoBem).Rows.Count > 0)
                    MessageBox.Show("Não é possível excluir esse Tipo de Bem!\n\nEste Tipo de Bem já está referenciado em algum Bem  / Equipamento.", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    _TipoBem.Delete(idTipoBem);
                    MessageBox.Show("Tipo de Bem Excluído com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTiposBem.DataSource = _TipoBem.GetDataByDescricao("%" + txtNome.Text.Trim() + "%");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Excluir o Tipo de Bem.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmTipoBem_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmPrincipal.frmTipoBem = new frmTipoBem();
        }
    }
}
