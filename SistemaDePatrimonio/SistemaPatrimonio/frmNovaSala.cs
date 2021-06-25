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
    public partial class frmNovaSala : Form
    {
        DataSetPatrimonioTableAdapters.tblsalaTableAdapter _Sala = new DataSetPatrimonioTableAdapters.tblsalaTableAdapter();
        public int tipoOperacao = 0;
        public int IdSalaOriginal = 0;
        public frmNovaSala()
        {
            InitializeComponent();
        }

        private void frmNovoSalaAnexo_Shown(object sender, EventArgs e)
        {
            if (tipoOperacao == 0)
            {
                this.Text = "Inserir Novo Local";
                tabControl1.TabPages[0].Text = "Novo Local";
            }
            else
            {
                this.Text = "Editar Local";
                tabControl1.TabPages[0].Text = "Editar Local";
            }
            txtAnexo.Focus();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Sala.GetDataByAnexo_Numero(Convert.ToInt32(txtNumero.Text.Trim()), txtAnexo.Text).Rows.Count > 0)
                    throw new Exception("Anexo e Número já cadastrados para um determinado Local.");
                //tipoOperacao: 0 - Inserção / 1 - Atualização
                if (tipoOperacao == 0)
                    _Sala.Insert(Convert.ToUInt32(txtNumero.Text.Trim()), txtAnexo.Text, txtDescricao.Text);
                else
                    _Sala.Update(Convert.ToInt32(txtNumero.Text.Trim()), txtAnexo.Text, txtDescricao.Text, IdSalaOriginal);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível Cadastrar / Editar o Local.\n\nDesc. do Erro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
