using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoVeiculos
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroVeiculo frmCad = new frmCadastroVeiculo();
            frmCad.ShowDialog();
        }
    }
}
