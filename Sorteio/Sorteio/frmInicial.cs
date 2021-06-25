using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorteio
{
    public partial class frmInicial : Form
    {
        public static bool podeRepetirNroSorteado = false;
        public frmInicial()
        {
            InitializeComponent();
            txtTotal.Focus();
        }

        private void btnSorteio_MouseHover(object sender, EventArgs e)
        {
            btnSortear.BackColor = Color.FromArgb(0, 191, 255);
        }

        private void btnSorteio_MouseLeave(object sender, EventArgs e)
        {
            btnSortear.BackColor = Color.FromArgb(24, 116, 205);
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            int total = 0;
            if (!int.TryParse(txtTotal.Text.Trim(), out total))
            {
                MessageBox.Show("Digite um número inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTotal.Focus();
            }
            else if ((!podeRepetirNroSorteado) && 
                (total <= frmSorteio.listaNrosSorteados.Count))
            {
                MessageBox.Show("Todos os participantes já foram sorteados!\n\n" + 
                    "Para realizar um novo sorteio clique no botão 'Configurações' " +
                    "e inicie um novo sorteio ou permita que um mesmo participante " + 
                    "possa ser sorteado novamente.", "Alerta...", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmSorteio frmSortear = new frmSorteio(total);
                frmSortear.ShowDialog();
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            frmConfiguracao frmConfigurar = new frmConfiguracao(podeRepetirNroSorteado);
            frmConfigurar.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente encerrar a aplicação?", "Encerrar Aplicação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
