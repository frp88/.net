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
    public partial class frmObservacaoBem : Form
    {
        public int codMovimentacao = 0;
        public frmObservacaoBem()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btAddObservacao_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter _Mov = new DataSetPatrimonioTableAdapters.tblmovimentacaoTableAdapter();
                _Mov.UpdateObservacao(txtObservacoes.Text + " " + txtNovasObservacoes.Text, codMovimentacao);
                MessageBox.Show("Observação adicionada com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Adicionar a Observação.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
