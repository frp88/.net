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
    public partial class frmMovimentacao : Form
    {
        DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
        DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter _Hist = new DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter();
        DataSetPatrimonioTableAdapters.tbltipoTableAdapter _Tipo = new DataSetPatrimonioTableAdapters.tbltipoTableAdapter();

        public frmMovimentacao()
        {
            InitializeComponent();
        }

        private void frmMovimentacao_Shown(object sender, EventArgs e)
        {
            cbTipoBem.ValueMember = "idTipo";
            cbTipoBem.DisplayMember = "descricao";
            cbTipoBem.DataSource = _Tipo.GetDataByComTodos();
            //dgvMovimentacao.DataSource = _Hist.GetData();
            this.buscaMovimentacoes();
            txtNome.Focus();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal.frmMov = new frmMovimentacao();
        }

        /// <summary>
        /// configura grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        case "Nome":
                            coluna.DisplayIndex = 0;
                            coluna.HeaderText = "Nome Funcionário";
                            coluna.HeaderCell.ToolTipText = "Nome do Funcionário";
                            coluna.Width = 180;
                            break;
                        case "descBem":
                            coluna.DisplayIndex = 1;
                            coluna.HeaderText = "Bem / Equipamento";
                            coluna.HeaderCell.ToolTipText = "Descrição do Bem / Equipamento";
                            coluna.Width = 180;
                            break;
                        case "numPatrimonio":
                            coluna.DisplayIndex = 2;
                            coluna.HeaderText = "Nro Patri.";
                            coluna.HeaderCell.ToolTipText = "Número Patrimonial";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 90;
                            break;
                        case "descricao":
                            coluna.DisplayIndex = 3;
                            coluna.HeaderText = "Local";
                            coluna.HeaderCell.ToolTipText = "Descrição do Local";
                            coluna.Width = 160;
                            break;
                        case "anexo":
                            coluna.DisplayIndex = 4;
                            coluna.HeaderText = "Anexo";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 70;
                            break;
                        case "numero":
                            coluna.DisplayIndex = 5;
                            coluna.HeaderText = "Nro";
                            coluna.HeaderCell.ToolTipText = "Número da Sala";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 40;
                            break;

                        case "dtRetirada":
                            coluna.DisplayIndex = 6;
                            coluna.HeaderText = "Dt Ret.";
                            coluna.HeaderCell.ToolTipText = "Data de Retirada";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "dtDevolucao":
                            coluna.DisplayIndex = 7;
                            coluna.HeaderText = "Dt Dev.";
                            coluna.HeaderCell.ToolTipText = "Data de Devolução";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "transferir":
                            coluna.DisplayIndex = 8;
                            coluna.HeaderText = "Tra.";
                            coluna.HeaderCell.ToolTipText = "Transferir o Bem / Equipamento";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 30;
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
                    if (String.IsNullOrEmpty(row.Cells["dtDevolucao"].Value.ToString()))
                        row.Cells["transferir"].ToolTipText = "Clique aqui para Transferir o Bem / Equipamento.";
                    else
                        row.Cells["transferir"].ToolTipText = "Bem / Equipamento já transferido ou Indisponível..";
                }
            }
            dgvMovimentacao.ClearSelection();
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

        private void dgvMovimentacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMovimentacao.Columns[e.ColumnIndex].Name == "transferir")
                    if (String.IsNullOrEmpty(dgvMovimentacao.Rows[e.RowIndex].Cells["dtDevolucao"].Value.ToString()))
                    {
                        frmTransferirBem frmTransferir = new frmTransferirBem();
                        frmTransferir.codMovimentacaoAntiga = Convert.ToInt32(dgvMovimentacao.Rows[e.RowIndex].Cells["idMovimentacao"].Value.ToString());
                        frmTransferir.codBem = Convert.ToInt32(dgvMovimentacao.Rows[e.RowIndex].Cells["numeroBem"].Value.ToString());
                        frmTransferir.labelDescBem.Text = "Bem: " + dgvMovimentacao.Rows[e.RowIndex].Cells["descBem"].Value.ToString();
                        frmTransferir.labelNumPatri.Text = "Nro Patrimonial: " + dgvMovimentacao.Rows[e.RowIndex].Cells["numPatrimonio"].Value.ToString();
                        frmTransferir.ShowDialog();
                        //dgvMovimentacao.DataSource = _Hist.GetData();
                        this.buscaMovimentacoes();
                    }
                    else
                        MessageBox.Show("Não é possível realizar essa transferência!\n\nBem / Equipamento já Transferido ou Indisponível.", "Alerta",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Transferir o Bem / Equipamento.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbTipoBem_SelectedValueChanged(object sender, EventArgs e)
        {

            //dgvMovimentacao.DataSource = (Convert.ToInt32(cbTipoBem.SelectedValue) == 0 ? _Hist.GetData() :
            //    _Hist.GetDataByTipoBem(Convert.ToInt32(cbTipoBem.SelectedValue)));
            this.buscaMovimentacoes();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            this.buscaMovimentacoes();
        }

        private void buscaMovimentacoes()
        {
            if (String.IsNullOrEmpty(txtNome.Text) && Convert.ToInt32(cbTipoBem.SelectedValue) == 0)
                dgvMovimentacao.DataSource = (ckbNaoDevolvidos.Checked ? _Hist.GetDataByDtDevNull() : _Hist.GetData());
            else if (String.IsNullOrEmpty(txtNome.Text))
            {
                dgvMovimentacao.DataSource = (Convert.ToInt32(cbTipoBem.SelectedValue) == 0 ? (ckbNaoDevolvidos.Checked ? _Hist.GetDataByDtDevNull() : _Hist.GetData()) :
               (ckbNaoDevolvidos.Checked ? _Hist.GetDataByTipoBemDtDevNull(Convert.ToInt32(cbTipoBem.SelectedValue)) : _Hist.GetDataByTipoBem(Convert.ToInt32(cbTipoBem.SelectedValue))));
            }
            else if (Convert.ToInt32(cbTipoBem.SelectedValue) == 0)
            {
                string aux = txtNome.Text;
                dgvMovimentacao.DataSource = (String.IsNullOrEmpty(txtNome.Text) ? (ckbNaoDevolvidos.Checked ? _Hist.GetDataByDtDevNull() : _Hist.GetData()) :
                    (ckbNaoDevolvidos.Checked ? (_Hist.GetDataByTodosFiltrosDtDevNull("%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%")) :
                    (_Hist.GetDataByTodosFiltros("%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%"))));
            }
            else
            {
                string aux = txtNome.Text;
                dgvMovimentacao.DataSource = (ckbNaoDevolvidos.Checked ? _Hist.GetDataByTodosFiltros_eTipoBemDtDevNull(Convert.ToInt32(cbTipoBem.SelectedValue),
                    "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%") :
                    _Hist.GetDataByTodosFiltros_eTipoBem(Convert.ToInt32(cbTipoBem.SelectedValue), "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%", "%" + aux + "%"));
            }
        }

        private void ckbNaoDevolvidos_CheckedChanged(object sender, EventArgs e)
        {
            this.buscaMovimentacoes();
        }

        private void btGerarRelatorio_Click(object sender, EventArgs e)
        {
            btGerarRelatorio.Text = "Gerando Relatório...";
            btGerarRelatorio.Enabled = btFechar.Enabled = false;

            this.ImprimeRelatorio();

            btGerarRelatorio.Text = "Gerar Relatório";
            btGerarRelatorio.Enabled = btFechar.Enabled = true;
        }

        public void ImprimeRelatorio()
        {
            //DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter _Det = new DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter();
            //DataSetPatrimonio.tblDetalhesDataTable dtDetalhes = _Det.GetDataByIdBem(codBem);

            frmRelatorio frmRel = new frmRelatorio();
            frmRel.reportViewer1.Clear();

            //ReportParameter[] parametros = new ReportParameter[11];
            //parametros[0] = new ReportParameter("descBem", dtDetalhes[0].descBem);
            //parametros[1] = new ReportParameter("numPatrimonio", dtDetalhes[0].numPatrimonio);
            //parametros[2] = new ReportParameter("numeroBem", dtDetalhes[0].numeroBem.ToString());
            //parametros[3] = new ReportParameter("Nome", dtDetalhes[0].Nome);
            //parametros[4] = new ReportParameter("siapeFunc", dtDetalhes[0].siapeFunc);
            //parametros[5] = new ReportParameter("descSala", dtDetalhes[0].descricao);
            //parametros[6] = new ReportParameter("anexo", dtDetalhes[0].anexo);
            //parametros[7] = new ReportParameter("numero", dtDetalhes[0].numeroSala.ToString());
            //parametros[8] = new ReportParameter("dtRetirada", dtDetalhes[0].dtRetirada.ToShortDateString());
            //parametros[9] = new ReportParameter("horaRetirada", dtDetalhes[0].dtRetirada.ToShortTimeString());
            //parametros[10] = new ReportParameter("observacao", dtDetalhes[0].IsobservacaoNull() ? "" : dtDetalhes[0].observacao);

            frmRel.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaPatrimonio.HistoricoMovimentacao.rdlc";
            //frmRel.reportViewer1.LocalReport.DataSources.Add(
            //    new Microsoft.Reporting.WinForms.ReportDataSource("DataSetHistoricoMov", (Object)dtDetalhes));

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
                DateTime? aDataDev = null;
                if (!String.IsNullOrEmpty(row.Cells["dtDevolucao"].Value.ToString()))
                    aDataDev = Convert.ToDateTime(row.Cells["dtDevolucao"].Value.ToString());

                dtAux.Rows.Add(row.Cells["Nome"].Value.ToString(), row.Cells["siapeFunc"].Value.ToString(), row.Cells["descBem"].Value.ToString(),
                    row.Cells["numPatrimonio"].Value.ToString(), row.Cells["descricao"].Value.ToString(), row.Cells["anexo"].Value.ToString(),
                    Convert.ToInt32(row.Cells["numero"].Value.ToString()), Convert.ToDateTime(row.Cells["dtRetirada"].Value.ToString()), aDataDev);
            }

            frmRel.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSetHistoricoMov", (Object)dtAux));
            //frmRel.reportViewer1.LocalReport.SetParameters(parametros);
            frmRel.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            frmRel.reportViewer1.ZoomMode = ZoomMode.FullPage;
            frmRel.reportViewer1.RefreshReport();
            frmRel.Text = "Histórico de Movimentações";
            frmRel.Show();
        }

        private void frmMovimentacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmPrincipal.frmMov = new frmMovimentacao();
        }
    }
}
