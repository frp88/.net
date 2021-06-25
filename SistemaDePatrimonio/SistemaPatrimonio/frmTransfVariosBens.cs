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
    public partial class frmTransfVariosBens : Form
    {
        DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
        DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter _Func = new DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter();
        DataSetPatrimonioTableAdapters.tblsalaTableAdapter _Sala = new DataSetPatrimonioTableAdapters.tblsalaTableAdapter();

        public frmTransfVariosBens()
        {
            InitializeComponent();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente Trasnferir os Bens / Equipamentos?", "Confirmação de Transferência de Bens",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmMultiplasMovimentacoes.siapeFunc = cbResponsavel.SelectedValue.ToString();
                frmMultiplasMovimentacoes.idSala = Convert.ToInt32(cbSala.SelectedValue.ToString());
                frmMultiplasMovimentacoes.observacao = txtObservacao.Text;
                frmMultiplasMovimentacoes.confirmaTransferencia = true;
                this.Close();
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            frmMultiplasMovimentacoes.confirmaTransferencia = false;
            this.Close();
        }

        private void frmTransfVariosBens_Shown(object sender, EventArgs e)
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
        }
    }
}
