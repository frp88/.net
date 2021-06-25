using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;

namespace SistemaPatrimonio
{
    public partial class frmTransferirBem : Form
    {
        DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
        DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter _Func = new DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter();
        DataSetPatrimonioTableAdapters.tblsalaTableAdapter _Sala = new DataSetPatrimonioTableAdapters.tblsalaTableAdapter();

        public int codBem = 0;
        public int codMovimentacaoAntiga = 0;

        public frmTransferirBem()
        {
            InitializeComponent();
        }

        private void frmTransferirBem_Shown(object sender, EventArgs e)
        {
            cbResponsavel.ValueMember = "siape";
            cbResponsavel.DisplayMember = "Nome";
            cbResponsavel.DataSource = _Func.GetDataByOrdenado();

            //cbSala.ValueMember = "idSala";
            //cbSala.DisplayMember = "descricao";
            //cbSala.DataSource = _Sala.GetDataByOrdenado();

            DataSetPatrimonio.tblsalaDataTable dtSala = _Sala.GetDataByOrdenado();
            DataTable dtAux = new DataTable();
            dtAux.Columns.Add("idSala", typeof(int));
            dtAux.Columns.Add("sala", typeof(string));
            foreach (var item in dtSala)
            {
                dtAux.Rows.Add(item.idSala, item.anexo + " - " + item.descricao + " - " + item.numero.ToString());
            }
            cbSala.ValueMember = "idSala";
            cbSala.DisplayMember = "sala";
            cbSala.DataSource = dtAux;

            DataSetPatrimonio.tblmovimentacaoDataTable dtMov = _Mov.GetDataByIdMovimentacao(codMovimentacaoAntiga);
            cbResponsavel.SelectedValue = dtMov[0].siapeFunc;
            cbSala.SelectedValue = dtMov[0].numeroSala;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                _Mov.UpdateDevolveBemByIdMovimentacao(codMovimentacaoAntiga);
                _Mov.InsertQuery(codBem, cbResponsavel.SelectedValue.ToString(), Convert.ToInt32(cbSala.SelectedValue), txtObservacao.Text);
                if (MessageBox.Show("Bem / Equipamento transferido com sucesso!\n\nDeseja Gerar o Termo de Compromisso?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btTransferir.Text = "Gerando Termo...";
                    btTransferir.Enabled = btFechar.Enabled = false;
                    this.ImprimeTermoDeCompromisso();
                    btTransferir.Text = "Transferir Bem";
                    btTransferir.Enabled = btFechar.Enabled = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Transferir o Bem / Equipamento.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ImprimeTermoDeCompromisso()
        {
            DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter _Det = new DataSetPatrimonioTableAdapters.tblDetalhesTableAdapter();
            DataSetPatrimonio.tblDetalhesDataTable dtDetalhes = _Det.GetDataByIdBem(codBem);

            frmRelatorio frmRel = new frmRelatorio();
            frmRel.reportViewer1.Clear();

            ReportParameter[] parametros = new ReportParameter[11];
            parametros[0] = new ReportParameter("descBem", dtDetalhes[0].descBem);
            parametros[1] = new ReportParameter("numPatrimonio", dtDetalhes[0].numPatrimonio);
            parametros[2] = new ReportParameter("numeroBem", dtDetalhes[0].numeroBem.ToString());
            parametros[3] = new ReportParameter("Nome", dtDetalhes[0].Nome);
            parametros[4] = new ReportParameter("siapeFunc", dtDetalhes[0].siapeFunc);
            parametros[5] = new ReportParameter("descSala", dtDetalhes[0].descricao);
            parametros[6] = new ReportParameter("anexo", dtDetalhes[0].anexo);
            parametros[7] = new ReportParameter("numero", dtDetalhes[0].numeroSala.ToString());
            parametros[8] = new ReportParameter("dtRetirada", dtDetalhes[0].dtRetirada.ToShortDateString());
            parametros[9] = new ReportParameter("horaRetirada", dtDetalhes[0].dtRetirada.ToShortTimeString());
            parametros[10] = new ReportParameter("observacao", dtDetalhes[0].IsobservacaoNull() ? "" : dtDetalhes[0].observacao);

            frmRel.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaPatrimonio.Termo_de_Compromisso.rdlc";
            //frmRel.reportViewer1.LocalReport.DataSources.Add(
            //    new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRelatorio", (Object)dtDetalhes));
            frmRel.reportViewer1.LocalReport.SetParameters(parametros);
            frmRel.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            frmRel.reportViewer1.ZoomMode = ZoomMode.FullPage;
            frmRel.reportViewer1.RefreshReport();

            frmRel.Text = "Termo de Compromisso";
            frmRel.Show();
        }
    }
}
