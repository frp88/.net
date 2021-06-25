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
    public partial class frmMotivoBaixa : Form
    {
        public int idBem = 0;
        public frmMotivoBaixa()
        {
            InitializeComponent();
        }

        private void frmMotivoBaixa_Shown(object sender, EventArgs e)
        {
            txtMotivoBaixa.Focus();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btBaixar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetPatrimonioTableAdapters.tblbemTableAdapter _Bem = new DataSetPatrimonioTableAdapters.tblbemTableAdapter();
                _Bem.UpdateBaixaBem(txtMotivoBaixa.Text, idBem);
                MessageBox.Show("Bem / Equipamento Baixado com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Baixar o Bem / Equipamento.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
