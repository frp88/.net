using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaPatrimonio
{
    public partial class frmBem : Form
    {
        //idBem - numPatrimonio - descricao - dtCadastro - dtDeposito - dtBaixa - motivoBaixa - tipo
        DataSetPatrimonioTableAdapters.tblbemTableAdapter _Bem = new DataSetPatrimonioTableAdapters.tblbemTableAdapter();
        DataSetPatrimonioTableAdapters.tbltipoTableAdapter _Tipo = new DataSetPatrimonioTableAdapters.tbltipoTableAdapter();
        int idBem = 0;
        public frmBem()
        {
            InitializeComponent();
        }

        private void frmBem_Shown(object sender, EventArgs e)
        {
            cbTipoBem.ValueMember = "idTipo";
            cbTipoBem.DisplayMember = "descricao";
            cbTipoBem.DataSource = _Tipo.GetDataByComTodos();
            //dgvBem.DataSource = _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
            this.buscaBens();
            txtNome.Focus();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            frmNovoBem frmNovo = new frmNovoBem();
            frmNovo.ShowDialog();
            //dgvBem.DataSource = _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
            this.buscaBens();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal.frmBem = new frmBem();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            //dgvBem.DataSource = _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
            this.buscaBens();
        }

        private void dgvBem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmNovoBem frmNovo = new frmNovoBem();
            frmNovo.txtNumPatrimonio.Text = dgvBem.Rows[e.RowIndex].Cells["numPatrimonio"].Value.ToString();
            frmNovo.cbTipoBem.SelectedValue = Convert.ToInt32(dgvBem.Rows[e.RowIndex].Cells["tipo"].Value.ToString());
            frmNovo.txtDescricao.Text = dgvBem.Rows[e.RowIndex].Cells["descBem"].Value.ToString();
            frmNovo.numeroBemOriginal = Convert.ToInt32(dgvBem.Rows[e.RowIndex].Cells["idBem"].Value.ToString());
            frmNovo.tipoOperacao = 1; //Atualização
            frmNovo.ShowDialog();
            //dgvBem.DataSource = _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
            this.buscaBens();
        }

        private void dgvBem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvBem.ColumnCount > 0)
            {
                foreach (DataGridViewColumn coluna in dgvBem.Columns)
                {
                    switch (coluna.Name)
                    {
                        case "idBem":
                            coluna.DisplayIndex = 0;
                            coluna.HeaderText = "Cod.";
                            coluna.HeaderCell.ToolTipText = "Código";
                            coluna.Width = 30;
                            break;
                        case "numPatrimonio":
                            coluna.DisplayIndex = 1;
                            coluna.HeaderText = "Nro Pat.";
                            coluna.HeaderCell.ToolTipText = "Número de Patrimônio";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 85;
                            break;
                        case "descBem":
                            coluna.DisplayIndex = 2;
                            coluna.HeaderText = "Descrição";
                            coluna.Width = 300;
                            break;
                        case "descTipoBem":
                            coluna.DisplayIndex = 3;
                            coluna.HeaderText = "Tipo";
                            coluna.HeaderCell.ToolTipText = "Tipo de Bem / Equip.";
                            coluna.Width = 160;
                            break;
                        case "dtCadastro":
                            coluna.DisplayIndex = 4;
                            coluna.HeaderText = "Dt Cad.";
                            coluna.HeaderCell.ToolTipText = "Data de Cadastro";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "dtDeposito":
                            coluna.DisplayIndex = 5;
                            coluna.HeaderText = "Dt Dep.";
                            coluna.HeaderCell.ToolTipText = "Data de Depósito";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "dtBaixa":
                            coluna.DisplayIndex = 6;
                            coluna.HeaderText = "Dt Baixa";
                            coluna.HeaderCell.ToolTipText = "Data de Baixa";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "btDetalhes":
                            coluna.DisplayIndex = 9;
                            coluna.ToolTipText = "Histórico";
                            coluna.HeaderText = "Hist.";
                            coluna.Width = 30;
                            break;
                        case "deposito":
                            coluna.DisplayIndex = 10;
                            coluna.ToolTipText = "Depositar Bem";
                            coluna.HeaderText = "Dep.";
                            coluna.Width = 32;
                            break;
                        case "baixa":
                            coluna.DisplayIndex = 11;
                            coluna.ToolTipText = "Baixar Bem";
                            coluna.HeaderText = "Baixa";
                            coluna.Width = 35;
                            break;
                        default:
                            coluna.Visible = false;
                            break;
                    }
                }
            }
            if (dgvBem.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvBem.Rows)
                {
                    row.Cells["idBem"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    row.Cells["numPatrimonio"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["descBem"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["descTipoBem"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["dtCadastro"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["dtDeposito"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["dtBaixa"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    row.Cells["dtCadastro"].ToolTipText = row.Cells["dtCadastro"].Value.ToString();
                    row.Cells["dtDeposito"].ToolTipText = row.Cells["dtDeposito"].Value.ToString();
                    row.Cells["dtBaixa"].ToolTipText = row.Cells["dtBaixa"].Value.ToString();
                    //row.Cells["motivoBaixa"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                    //row.Cells["btDetalhes"].Value = "...";
                    row.Cells["btDetalhes"].ToolTipText = "Clique aqui para ver o histórico de movimentações.";
                    //row.Cells["deposito"].Value = "D";
                    row.Cells["deposito"].ToolTipText = "Clique aqui para depositar o bem.";
                    //row.Cells["baixa"].Value = "B";
                    row.Cells["baixa"].ToolTipText = "Clique aqui para ver baixar o bem.";
                }
            }
            dgvBem.ClearSelection();
        }

        private void dgvBem_MouseUp(object sender, MouseEventArgs e)
        {
            dgvBem.MultiSelect = false;

            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info;
                info = dgvBem.HitTest(e.X, e.Y);
                if (info.Type == DataGridViewHitTestType.Cell)
                {
                    if (info.Type == DataGridViewHitTestType.Cell && info.ColumnIndex == 1)
                        dgvBem.CurrentCell.Selected = false;
                    dgvBem[info.ColumnIndex, info.RowIndex].Selected = true;
                    dgvBem.Refresh();
                    idBem = Convert.ToInt32(dgvBem.Rows[info.RowIndex].Cells["idBem"].Value.ToString());
                    //dgvTiposBem = Convert.ToInt32(dgvTiposBem.Rows[info.RowIndex].Cells["codMarca"].Value);
                    contextMenuStrip1.Show(dgvBem, new Point(e.X, e.Y));
                }
            }
        }

        private void excluirBemEquipamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
                if (_Mov.GetDataByIdBem(idBem).Rows.Count > 1)
                    MessageBox.Show("Não é possível excluir esse Bem / Equipamento!\n\nO Bem / Equipamento possui registro de movimentações.", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    _Mov.DeleteByIdBem(idBem);
                    _Bem.DeleteQuery(idBem);
                    MessageBox.Show("Bem / Equipamento Excluído com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgvBem.DataSource = _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
                    this.buscaBens();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Excluir o Bem / Equipamento.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvBem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int codBem = Convert.ToInt32(dgvBem.Rows[e.RowIndex].Cells["idBem"].Value.ToString());
                switch (dgvBem.Columns[e.ColumnIndex].Name)
                {
                    case "btDetalhes":
                        frmDetalhes frmNovo = new frmDetalhes();
                        frmNovo.tipoConsulta = frmDetalhes.TipoConsulta.Bem;
                        frmNovo.sql = codBem.ToString();
                        frmNovo.ShowDialog();
                        //frmPrincipal.frmDet.tipoConsulta = frmDetalhes.TipoConsulta.Bem;
                        //frmPrincipal.frmDet.sql = codBem.ToString();
                        //frmPrincipal.frmDet.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        //frmPrincipal.frmDet.Show();
                        break;
                    case "inf":
                        MessageBox.Show("teste");
                        break;
                    case "deposito":
                        if (String.IsNullOrEmpty(dgvBem.Rows[e.RowIndex].Cells["dtDeposito"].Value.ToString())
                            && String.IsNullOrEmpty(dgvBem.Rows[e.RowIndex].Cells["dtBaixa"].Value.ToString()))
                        {

                            DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
                            _Mov.UpdateDevolveBemByIdBem_DtDevolucaoNula("Produto Depositado.", codBem);
                            _Bem.UpdateDepositaBem(codBem);
                            MessageBox.Show("Bem / Equipamento Depositado com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //dgvBem.DataSource = _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
                            this.buscaBens();
                        }
                        else
                            MessageBox.Show("Não é possível realizar o Deoósito deste Bem / Equipamento!\n\nBem / Equipamento já foi Depositado.", "Alerta",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "baixa":
                        if (!String.IsNullOrEmpty(dgvBem.Rows[e.RowIndex].Cells["dtDeposito"].Value.ToString())
                           && String.IsNullOrEmpty(dgvBem.Rows[e.RowIndex].Cells["dtBaixa"].Value.ToString()))
                        {
                            frmMotivoBaixa frmBaixa = new frmMotivoBaixa();
                            frmBaixa.idBem = codBem;
                            frmBaixa.ShowDialog();
                            //dgvBem.DataSource = _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
                            this.buscaBens();
                        }
                        else
                            MessageBox.Show("Não é possível realizar a Baixa deste Bem / Equipamento!\n\nBem / Equipamento está em uso ou já foi Baixado.", "Alerta",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                //faz algo se der erro
            }
        }

        private void cbTipoBem_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buscaBens();
        }

        private void buscaBens()
        {
            if (String.IsNullOrEmpty(txtNome.Text) && Convert.ToInt32(cbTipoBem.SelectedValue) == 0)
                dgvBem.DataSource = _Bem.GetData();
            else if (String.IsNullOrEmpty(txtNome.Text))
            {
                dgvBem.DataSource = (Convert.ToInt32(cbTipoBem.SelectedValue) == 0 ? _Bem.GetData() :
               _Bem.GetDataByIdTipoBem(Convert.ToInt32(cbTipoBem.SelectedValue)));
            }
            else if (Convert.ToInt32(cbTipoBem.SelectedValue) == 0)
            {
                dgvBem.DataSource = (String.IsNullOrEmpty(txtNome.Text) ? _Bem.GetData() :
                _Bem.GetDataByNumPatrimonio_Descricao("%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%"));
            }
            else
            {
                dgvBem.DataSource = _Bem.GetDataByIdTipo_NumPatrimonio_Descricao(Convert.ToInt32(cbTipoBem.SelectedValue),
                  "%" + txtNome.Text.Trim() + "%", "%" + txtNome.Text.Trim() + "%");
            }
        }

        private void frmBem_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmPrincipal.frmBem = new frmBem();
        }
    }

}//idBem - numPatrimonio - descricao - dtCadastro - dtDeposito - dtBaixa - motivoBaixa - tipo
//private void dgvBolsa_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
//       {
//           try
//           {
//               // pra cada coluna
//               foreach (DataGridViewColumn coluna in dgvBolsa.Columns)
//               {
//                   switch (coluna.Name)
//                   {
//                       case "ckBox": coluna.Width = 30;
//                           //coluna.HeaderText = "Descrição";
//                           coluna.DisplayIndex = 0;
//                           coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//                           break;
//                       case "sDescricao": coluna.Width = 205;
//                           coluna.HeaderText = "Bolsa";
//                           coluna.DisplayIndex = 1;
//                           coluna.ReadOnly = true;
//                           coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
//                           break;
//                       case "sNome": coluna.Width = 215;
//                           coluna.HeaderText = "Aluno";
//                           coluna.DisplayIndex = 2;
//                           coluna.ReadOnly = true;
//                           coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
//                           break;
//                       case "sNomeCurso": coluna.Width = 210;
//                           coluna.HeaderText = "Curso";
//                           coluna.DisplayIndex = 3;
//                           coluna.ReadOnly = true;
//                           coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
//                           break;
//                       //case "dSituacao": coluna.Width = 90;
//                       //    coluna.HeaderText = "Ult. Alteração";
//                       //    coluna.DefaultCellStyle.Format = "d";
//                       //    coluna.DisplayIndex = 4;
//                       //    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
//                       //    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//                       //    break;

//                       case "nValorAd": coluna.Width = 85;
//                           coluna.HeaderText = "Valor Ad.";
//                           //coluna.DefaultCellStyle.Format = "C2";
//                           coluna.DefaultCellStyle.Format = "N2";
//                           coluna.DisplayIndex = 4;
//                           coluna.ReadOnly = true;
//                           coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
//                           coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//                           break;
//                       default: coluna.Visible = false;
//                           break;
//                       case "nValorInf": coluna.Width = 85;
//                           coluna.HeaderText = "Valor Inf.";
//                           //coluna.DefaultCellStyle.Format = "C2";
//                           coluna.DefaultCellStyle.Format = "N2";
//                           coluna.DisplayIndex = 5;
//                           coluna.ReadOnly = true;
//                           coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
//                           coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//                           break;
//                   }
//               }
//               // colore as rows
//               foreach (DataGridViewRow row in dgvBolsa.Rows)
//               {
//                   switch ((int)row.Cells["nSituacao"].Value)
//                   {
//                       case 2: row.DefaultCellStyle.BackColor = Color.LightSkyBlue; break;
//                       case 3: row.DefaultCellStyle.BackColor = Color.Thistle; break;
//                       case 4: row.DefaultCellStyle.BackColor = pCorPendente.BackColor; break;
//                   }
//               }
//               dgvBolsa.ClearSelection();
//           }
//           catch (Exception ex)
//           {
//               MessageBox.Show("Não foi possível configurar a tabela de bolsas...\n\nDesc.: " + ex.Message,
//                     "Falha ao configurar a tabela de bolsas", MessageBoxButtons.OK, MessageBoxIcon.Error);
//           }
//       }