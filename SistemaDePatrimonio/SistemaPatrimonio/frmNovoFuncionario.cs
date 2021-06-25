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
    public partial class frmNovoFuncionario : Form
    {
        public int tipoOperacao = 0;
        public String siapeOriginal = String.Empty;
        DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter _Funcionario = new DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter();
        public frmNovoFuncionario()
        {
            InitializeComponent();
        }
        private void frmNovoFuncionario_Shown(object sender, EventArgs e)
        {
            if (tipoOperacao == 0)
            {
                this.Text = "Inserir Novo Funcionário";
                tabControl1.TabPages[0].Text = "Novo Funcionário";
            }
            else
            {
                this.Text = "Editar Funcionário";
                tabControl1.TabPages[0].Text = "Editar Funcionário";
            }
            txtNome.Focus();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //tipoOperacao: 0 - Inserção / 1 - Atualização
                if (tipoOperacao == 0)
                    _Funcionario.Insert(txtSiape.Text, txtNome.Text);
                else
                    _Funcionario.Update(txtSiape.Text, txtNome.Text, siapeOriginal);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Cadastrar / Editar o  Funcionário.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
