using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SistemaPatrimonio
{
    public partial class frmMultiplasMovimentacoes : Form
    {
        DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
        DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter _Hist = new DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter();
        DataSetPatrimonioTableAdapters.tbltipoTableAdapter _Tipo = new DataSetPatrimonioTableAdapters.tbltipoTableAdapter();
        DataSetPatrimonio.tblDetalhesDataTable dtDetalhes = null;
        public static String observacao = String.Empty;
        public static int idSala = 0;
        public static String siapeFunc = String.Empty;
        public static String nomeFunc = String.Empty;
        public static bool confirmaTransferencia = false;

        public frmMultiplasMovimentacoes()
        {
            InitializeComponent();
        }

        private void frmMultiplasMovimentacoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmPrincipal.frmMultiMov = new frmMultiplasMovimentacoes();
        }

        private void frmMultiplasMovimentacoes_Shown(object sender, EventArgs e)
        {
            cbTipoBem.ValueMember = "idTipo";
            cbTipoBem.DisplayMember = "descricao";
            cbTipoBem.DataSource = _Tipo.GetDataByComTodos();
            //dgvMovimentacao.DataSource = _Hist.GetData();
            this.buscaMovimentacoes();
            txtNome.Focus();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            this.buscaMovimentacoes();
        }

        private void cbTipoBem_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buscaMovimentacoes();
        }

        private void ckbNaoDevolvidos_CheckedChanged(object sender, EventArgs e)
        {
            this.buscaMovimentacoes();
        }

        private void dgvMovimentacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dgvMovimentacao.Columns[e.ColumnIndex].Name == "transferir")
            //        if (String.IsNullOrEmpty(dgvMovimentacao.Rows[e.RowIndex].Cells["dtDevolucao"].Value.ToString()))
            //        {
            //            frmTransferirBem frmTransferir = new frmTransferirBem();
            //            frmTransferir.codMovimentacaoAntiga = Convert.ToInt32(dgvMovimentacao.Rows[e.RowIndex].Cells["idMovimentacao"].Value.ToString());
            //            frmTransferir.codBem = Convert.ToInt32(dgvMovimentacao.Rows[e.RowIndex].Cells["numeroBem"].Value.ToString());
            //            frmTransferir.labelDescBem.Text = "Bem: " + dgvMovimentacao.Rows[e.RowIndex].Cells["descBem"].Value.ToString();
            //            frmTransferir.labelNumPatri.Text = "Nro Patrimonial: " + dgvMovimentacao.Rows[e.RowIndex].Cells["numPatrimonio"].Value.ToString();
            //            frmTransferir.ShowDialog();
            //            //dgvMovimentacao.DataSource = _Hist.GetData();
            //            this.buscaMovimentacoes();
            //        }
            //        else
            //            MessageBox.Show("Não é possível realizar essa transferência!\n\nBem / Equipamento já Transferido ou Indisponível.", "Alerta",
            //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //catch (Exception)
            //{
            //    //faz algo se der erro
            //}
        }

        private void dgvMovimentacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmObservacaoBem frmObs = new frmObservacaoBem();
            frmObs.txtObservacoes.Text = dgvMovimentacao.Rows[e.RowIndex].Cells["observacao"].Value.ToString();
            frmObs.codMovimentacao = Convert.ToInt32(dgvMovimentacao.Rows[e.RowIndex].Cells["idMovimentacao"].Value.ToString());
            frmObs.ShowDialog();
            //dgvMovimentacao.DataSource = _Hist.GetData();
            this.buscaMovimentacoes();
        }

        private void dgvMovimentacao_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvMovimentacao.ColumnCount > 0)
            {
                // m.idMovimentacao, m.numeroBem, m.siapeFunc, m.numeroSala, m.dtRetirada, m.dtDevolucao, m.observacao, f.siape, 
                //f.Nome, s.idSala, s.numero, s.anexo, s.descricao, b.idBem, b.numPatrimonio, b.descricao AS descBem, b.dtCadastro, 
                //b.dtDeposito, b.dtBaixa, b.motivoBaixa, b.tipo
                foreach (DataGridViewColumn coluna in dgvMovimentacao.Columns)
                {
                    switch (coluna.Name)
                    {
                        case "transferir":
                            coluna.DisplayIndex = 0;
                            //coluna.HeaderText = "Tra.";
                            //coluna.HeaderCell.ToolTipText = "Transferir o Bem / Equipamento";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 20;
                            break;
                        case "Nome":
                            coluna.DisplayIndex = 1;
                            coluna.HeaderText = "Nome Funcionário";
                            coluna.HeaderCell.ToolTipText = "Nome do Funcionário";
                            coluna.Width = 180;
                            coluna.ReadOnly = true;
                            break;
                        case "descBem":
                            coluna.DisplayIndex = 2;
                            coluna.HeaderText = "Bem / Equipamento";
                            coluna.HeaderCell.ToolTipText = "Descrição do Bem / Equipamento";
                            coluna.Width = 180;
                            coluna.ReadOnly = true;
                            break;
                        case "numPatrimonio":
                            coluna.DisplayIndex = 3;
                            coluna.HeaderText = "Nro Patri.";
                            coluna.HeaderCell.ToolTipText = "Número Patrimonial";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 90;
                            coluna.ReadOnly = true;
                            break;
                        case "descricao":
                            coluna.DisplayIndex = 4;
                            coluna.HeaderText = "Local";
                            coluna.HeaderCell.ToolTipText = "Descrição do Local";
                            coluna.Width = 160;
                            coluna.ReadOnly = true;
                            break;
                        case "anexo":
                            coluna.DisplayIndex = 5;
                            coluna.HeaderText = "Anexo";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            coluna.ReadOnly = true;
                            break;
                        case "numero":
                            coluna.DisplayIndex = 6;
                            coluna.HeaderText = "Nro";
                            coluna.HeaderCell.ToolTipText = "Número da Sala";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 40;
                            coluna.ReadOnly = true;
                            break;
                        case "dtRetirada":
                            coluna.DisplayIndex = 7;
                            coluna.HeaderText = "Dt Ret.";
                            coluna.HeaderCell.ToolTipText = "Data de Retirada";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            coluna.ReadOnly = true;
                            break;
                        case "dtDevolucao":
                            coluna.DisplayIndex = 8;
                            coluna.HeaderText = "Dt Dev.";
                            coluna.HeaderCell.ToolTipText = "Data de Devolução";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            coluna.ReadOnly = true;
                            break;
                        default:
                            coluna.Visible = false;
                            break;
                    }
                }
            }
            if (dgvMovimentacao.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvMovimentacao.Rows)
                {
                    //row.Cells["Nome"].ToolTipText = "Duplo clique para Visualizar a Observação.";
                    //row.Cells["descBem"].ToolTipText = "Duplo clique para Visualizar a Observação.";
                    //row.Cells["numPatrimonio"].ToolTipText = "Duplo clique para Visualizar a Observação.";
                    //row.Cells["descricao"].ToolTipText = "Duplo clique para Visualizar a Observação.";
                    //row.Cells["anexo"].ToolTipText = "Duplo clique para Visualizar as Observação.";
                    //row.Cells["numero"].ToolTipText = "Duplo clique para Visualizar a Observação.";
                    row.Cells["dtRetirada"].ToolTipText = row.Cells["dtRetirada"].Value.ToString();
                    row.Cells["dtDevolucao"].ToolTipText = row.Cells["dtDevolucao"].Value.ToString();
                    ////row.Cells["transferir"].Value = "...";                    
                    row.Cells["transferir"].ToolTipText = "Clique aqui para Transferir o Bem / Equipamento.";
                    //row.Cells["transferir"].ReadOnly = false;
                }
            }
            dgvMovimentacao.ClearSelection();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal.frmMultiMov = new frmMultiplasMovimentacoes();
        }

        private void btTransferirBens_Click(object sender, EventArgs e)
        {
            bool algumaBolsaSelecionada = false;
            foreach (DataGridViewRow row in dgvMovimentacao.Rows)
            {
                if (Convert.ToBoolean(row.Cells["transferir"].Value))
                {
                    algumaBolsaSelecionada = true;
                    break;
                }
            }
            if (algumaBolsaSelecionada)
            {
                frmTransfVariosBens frmTransVariosBens = new frmTransfVariosBens();
                frmTransVariosBens.ShowDialog();
                if (confirmaTransferencia)
                {
                    try
                    {
                        DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter _Det = new DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter();
                        DataSetPatrimonio.tblDetalhesRow rowDet;
                        DataTable dtAux = new DataTable();
                        dtAux.Columns.Add("Nome", typeof(string));
                        dtAux.Columns.Add("siapeFunc", typeof(string));
                        dtAux.Columns.Add("descBem", typeof(string));
                        dtAux.Columns.Add("numPatrimonio", typeof(string));
                        dtAux.Columns.Add("descricao", typeof(string));
                        dtAux.Columns.Add("anexo", typeof(string));
                        dtAux.Columns.Add("numero", typeof(int));
                        dtAux.Columns.Add("dtRetirada", typeof(DateTime));
                        dtAux.Columns.Add("dtDevolucao", typeof(DateTime));
                        dtAux.Columns["dtDevolucao"].AllowDBNull = true;

                        // percorre as movimentaçoes para Transferi-los
                        foreach (DataGridViewRow row in dgvMovimentacao.Rows)
                        {
                            //if ((bool)(row.Cells["transferir"].Value))
                            if (Convert.ToBoolean(row.Cells["transferir"].Value))
                            {
                                _Mov.UpdateDevolveBemByIdMovimentacao(Convert.ToInt32(row.Cells["idMovimentacao"].Value.ToString()));
                                _Mov.InsertQuery(Convert.ToInt32(row.Cells["numeroBem"].Value.ToString()), siapeFunc, idSala, observacao);

                                rowDet = _Det.GetDataByIdMovimentacao(Convert.ToInt32(_Mov.GetUltimoRegistro()[0].idMovimentacao))[0];

                                DateTime? aDataDev = null;
                                if (!rowDet.IsdtDepositoNull())
                                    aDataDev = rowDet.dtDevolucao;
                                dtAux.Rows.Add(rowDet.Nome, rowDet.siapeFunc, rowDet.descBem, rowDet.numPatrimonio, rowDet.descricao, rowDet.anexo,
                                    rowDet.numero, rowDet.dtRetirada, aDataDev);
                                nomeFunc = rowDet.Nome;
                            }
                        }
                        if (MessageBox.Show("Bens Transferidos com Sucesso!\n\nDeseja Imprimir o o Relatório de Transferência?", "Imprimir Relatório de Transferência de Bens",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //Funçao de Imprimir a lista de bens transferidos
                            this.ImprimeRelatorioDeTransferencia(dtAux, nomeFunc);
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro na transferência dos Bens\n\nEntre em contato com o Desenvolvedor do Sistema\n\n" + ex.Message, "Atenção !!! Erro !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.buscaMovimentacoes();
                }
            }
            else
                MessageBox.Show("Selecione pelo menos um Bem / Equipamento para Transferir.", "Atenção !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buscaMovimentacoes()
        {
            if (String.IsNullOrEmpty(txtNome.Text) && Convert.ToInt32(cbTipoBem.SelectedValue) == 0)
                dgvMovimentacao.DataSource = dtDetalhes = _Hist.GetDataByDtDevNull();
            else if (String.IsNullOrEmpty(txtNome.Text))
            {
                dgvMovimentacao.DataSource = dtDetalhes = (Convert.ToInt32(cbTipoBem.SelectedValue) == 0 ? _Hist.GetDataByDtDevNull() :
                _Hist.GetDataByTipoBemDtDevNull(Convert.ToInt32(cbTipoBem.SelectedValue)));
            }
            else if (Convert.ToInt32(cbTipoBem.SelectedValue) == 0)
            {
                string aux = txtNome.Text;
                dgvMovimentacao.DataSource = dtDetalhes = String.IsNullOrEmpty(txtNome.Text) ? _Hist.GetDataByDtDevNull() :
                     (_Hist.GetDataByTodosFiltrosDtDevNull("%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%"));
            }
            else
            {
                string aux = txtNome.Text;
                dgvMovimentacao.DataSource = dtDetalhes = _Hist.GetDataByTodosFiltros_eTipoBemDtDevNull(Convert.ToInt32(cbTipoBem.SelectedValue),
                    "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%");
            }
        }

        public void ImprimeRelatorioDeTransferencia(DataTable dtImprimir, String nome)
        {
            frmRelatorio frmRel = new frmRelatorio();
            frmRel.reportViewer1.Clear();

            ReportParameter[] parametros = new ReportParameter[1];
            parametros[0] = new ReportParameter("Nome", nome);
            frmRel.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaPatrimonio.TransfVariosBens.rdlc";
            frmRel.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSetHistoricoMov", (Object)dtImprimir));
            frmRel.reportViewer1.LocalReport.SetParameters(parametros);
            frmRel.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            frmRel.reportViewer1.ZoomMode = ZoomMode.FullPage;
            frmRel.reportViewer1.RefreshReport();
            frmRel.Text = "Transferência de Bens / Equipamentos";
            frmRel.Show();
        }

        private void ckBoxTodas_CheckedChanged(object sender, EventArgs e)
        {
            // Marca ou desmarca todas as movimentaçoes
            foreach (DataGridViewRow row in dgvMovimentacao.Rows)
            {
                dgvMovimentacao.ClearSelection();
                row.Cells["transferir"].Value = ckBoxTodas.Checked;
            }
        }
    }
}
