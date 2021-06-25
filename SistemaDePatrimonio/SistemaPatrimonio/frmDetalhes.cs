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
    public partial class frmDetalhes : Form
    {
        public enum TipoConsulta
        {
            Bem = 0,
            Funcionario = 1,
            Sala = 2
        };
        public TipoConsulta tipoConsulta;
        public String sql;
        DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter _Det = new DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter();
        public frmDetalhes()
        {
            InitializeComponent();
        }

        private void frmDetalhes_Shown(object sender, EventArgs e)
        {
            this.BuscaMovimentacoes();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            //frmPrincipal.frmDet = new frmDetalhes();
            //frmPrincipal.frmDet.MdiParent = frmPrincipal.frmPrinc;
        }

        private void dgvHistoricoMov_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvHistoricoMov.ColumnCount > 0)
            {
                foreach (DataGridViewColumn coluna in dgvHistoricoMov.Columns)
                {
                    switch (coluna.Name)
                    {
                        case "Nome":
                            coluna.DisplayIndex = 0;
                            coluna.HeaderText = "Nome Funcionário";
                            coluna.Width = 170;
                            break;
                        case "siape":
                            coluna.DisplayIndex = 1;
                            coluna.HeaderText = "SIAPE";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 72;
                            break;
                        case "descBem":
                            coluna.DisplayIndex = 2;
                            coluna.HeaderText = "Bem / Equipamento";
                            coluna.Width = 170;
                            break;
                        case "numPatrimonio":
                            coluna.DisplayIndex = 3;
                            coluna.HeaderText = "Nro Pat.";
                            coluna.HeaderCell.ToolTipText = "Número Patrimonial";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "descricao":
                            coluna.DisplayIndex = 4;
                            coluna.HeaderText = "Local";
                            coluna.Width = 130;
                            break;
                        case "anexo":
                            coluna.DisplayIndex = 5;
                            coluna.HeaderText = "Anexo";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "numero":
                            coluna.DisplayIndex = 6;
                            coluna.HeaderText = "Nro";
                            coluna.HeaderCell.ToolTipText = "Número da Local";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 50;
                            break;

                        case "dtRetirada":
                            coluna.DisplayIndex = 7;
                            coluna.HeaderText = "Dt Ret.";
                            coluna.HeaderCell.ToolTipText = "Data de Retirada";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        case "dtDevolucao":
                            coluna.DisplayIndex = 8;
                            coluna.HeaderText = "Dt Dev.";
                            coluna.HeaderCell.ToolTipText = "Data de Devolução";
                            coluna.DefaultCellStyle.Format = "d";
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.Width = 80;
                            break;
                        default:
                            coluna.Visible = false;
                            break;
                    }
                }
            }
            if (dgvHistoricoMov.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvHistoricoMov.Rows)
                {
                    //row.Cells["descricao"].ToolTipText = "Duplo clique para editar | Botão Direito para Excluir";
                }
            }
            dgvHistoricoMov.ClearSelection();
        }

        private void btGerarRelatorio_Click(object sender, EventArgs e)
        {
            this.btGerarRelatorio.Text = "Gerando Relátorio...";
            this.btGerarRelatorio.Enabled = btFechar.Enabled = false;
            this.ImprimeRelatorio();
            this.btGerarRelatorio.Text = "Gerar Relatório";
            this.btGerarRelatorio.Enabled = btFechar.Enabled = true;
        }

        private void ckbNaoDevolvidos_CheckedChanged(object sender, EventArgs e)
        {
            this.BuscaMovimentacoes();
        }

        public void BuscaMovimentacoes()
        {
            switch (tipoConsulta)
            {
                case TipoConsulta.Bem:
                    dgvHistoricoMov.DataSource = (ckbNaoDevolvidos.Checked ?
                        _Det.GetDataTodasMovByIdBem_DtDevNull(Convert.ToInt32(sql)) : _Det.GetDataTodasMovByIdBem(Convert.ToInt32(sql)));
                    break;
                case TipoConsulta.Funcionario:
                    dgvHistoricoMov.DataSource = (ckbNaoDevolvidos.Checked ?
                        _Det.GetDataBySiapeFunc_DtDevNull(sql) : _Det.GetDataBySiapeFunc(sql));
                    break;
                case TipoConsulta.Sala:
                    dgvHistoricoMov.DataSource = (ckbNaoDevolvidos.Checked ?
                        _Det.GetDataByIdSala_DtDevNull(Convert.ToInt32(sql)) : _Det.GetDataByIdSala(Convert.ToInt32(sql)));
                    break;
                default:
                    break;
            }
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
            foreach (DataGridViewRow row in dgvHistoricoMov.Rows)
            {
                DateTime? aDataDev = null;
                if (!String.IsNullOrEmpty(row.Cells["dtDevolucao"].Value.ToString()))
                    aDataDev = Convert.ToDateTime(row.Cells["dtDevolucao"].Value.ToString());

                dtAux.Rows.Add(row.Cells["Nome"].Value.ToString(), row.Cells["siapeFunc"].Value.ToString(), row.Cells["descBem"].Value.ToString(),
                    row.Cells["numPatrimonio"].Value.ToString(), row.Cells["descricao"].Value.ToString(), row.Cells["anexo"].Value.ToString(),
                    Convert.ToInt32(row.Cells["numero"].Value.ToString()), Convert.ToDateTime(row.Cells["dtRetirada"].Value.ToString()), aDataDev);
            }


            frmRel.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaPatrimonio.HistoricoMovimentacao.rdlc";
            frmRel.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSetHistoricoMov", (Object)dtAux));
            //frmRel.reportViewer1.LocalReport.SetParameters(parametros);
            frmRel.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            frmRel.reportViewer1.ZoomMode = ZoomMode.FullPage;
            frmRel.reportViewer1.RefreshReport();

            frmRel.Text = "Histórico de Movimentações";
            frmRel.Show();
        }

    }
}
