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
    public partial class frmConfiguracao : Form
    {
        public frmConfiguracao(bool podeRepetir)
        {
            InitializeComponent();

            if (!podeRepetir) {
                rbSim.Checked = false;
                rbNao.Checked = true;
            }
            else
            {
                rbSim.Checked = true;
                rbNao.Checked = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (chkIniciarNovoSorteio.Checked)
            {
                frmSorteio.listaNrosSorteados.Clear();
            }
            frmInicial.podeRepetirNroSorteado = rbSim.Checked;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovoSorteio_Click(object sender, EventArgs e)
        {

        }
    }
}
