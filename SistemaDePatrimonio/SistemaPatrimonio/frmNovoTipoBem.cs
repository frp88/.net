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
    public partial class frmNovoTipoBem : Form
    {
        public int tipoOperacao = 0;
        public int codTipoBem = 0;
        DataSetPatrimonioTableAdapters.tbltipoTableAdapter _TipoBem = new DataSetPatrimonioTableAdapters.tbltipoTableAdapter();
        public frmNovoTipoBem()
        {
            InitializeComponent();
        }

        private void frmNovoTipoBem_Shown(object sender, EventArgs e)
        {
            if (tipoOperacao == 0)
            {
                this.Text = "Inserir Novo Tipo de Bem / Equipamento";
                tabControl1.TabPages[0].Text = "Novo Tipo de Bem / Equipamento";
            }
            else
            {
                this.Text = "Editar Tipo de Bem / Equipamento";
                tabControl1.TabPages[0].Text = "Editar Tipo de Bem / Equipamento";
            }
            txtDescricaoTipoBem.Focus();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //tipoOperacao: 0 - Inserção / 1 - Atualização
                if (tipoOperacao == 0)
                    _TipoBem.Insert(txtDescricaoTipoBem.Text);
                else
                    _TipoBem.Update(txtDescricaoTipoBem.Text, codTipoBem);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Cadastrar / Editar o Tipo de Bem.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
