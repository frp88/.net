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
    public partial class frmSorteio : Form
    {
        static int totalParticipantes = 0, numeroSorteado = 0, quantSorteios = 0;
        public static List<int> listaNrosSorteados = new List<int>();
        static bool nroJaSorteado = false;

        public frmSorteio(int total)
        {
            InitializeComponent();

            timer1.Enabled = false;
            totalParticipantes = total;
            this.Sortear();
        }

        public void Sortear()
        {
            if ((!frmInicial.podeRepetirNroSorteado) && 
                (totalParticipantes <= listaNrosSorteados.Count))
            {
                MessageBox.Show("Todos os participantes já foram sorteados!\n\n" +
                    "Para realizar um novo sorteio volte na Tela Inicial, clique " +
                    "no botão 'Configurações' e inicie um novo sorteio ou permita " + 
                    "que um mesmo participante possa ser sorteado novamente.",
                    "Alerta...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                labelNroSorteado.Visible = labelNroSorteadoMais100.Visible = false;
                btnSortearNovamente.Visible = btnVoltar.Visible = false;
                labelResultado.Left += 70;
                labelResultado.Text = "Sorteando...";
                // Dispara o evento do sorteio
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nroJaSorteado = false;
            labelNroSorteado.Visible = labelNroSorteadoMais100.Visible = false;
            Random rnd = new Random();
            // Sorteia um número aleatório
            numeroSorteado = rnd.Next(1, (totalParticipantes + 1));
            quantSorteios++;

            if (numeroSorteado < 100)
            {
                labelNroSorteado.Text = (numeroSorteado < 10 ? ("0" + numeroSorteado.ToString()) : numeroSorteado.ToString());
                labelNroSorteado.Visible = true;
            }
            else
            {
                labelNroSorteadoMais100.Text = numeroSorteado.ToString();
                labelNroSorteadoMais100.Visible = true;
            }

            if (quantSorteios > 20)
            {
                if (!frmInicial.podeRepetirNroSorteado)
                {
                    foreach (int nro in listaNrosSorteados)
                    {
                        if (nro == numeroSorteado)
                        {
                            nroJaSorteado = true;
                        }
                    }
                }
                if (!nroJaSorteado)
                {
                    timer1.Enabled = false;
                    quantSorteios = 0;
                    labelResultado.Left -= 70;
                    labelResultado.Text = "Número Sorteado: " +
                        (numeroSorteado < 10 ?
                        ("0" + numeroSorteado.ToString()) :
                        numeroSorteado.ToString());
                    btnSortearNovamente.Visible = btnVoltar.Visible = true;
                    // Adiciona o número sorteado à lista
                    listaNrosSorteados.Add(numeroSorteado);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSortearNovamente_Click(object sender, EventArgs e)
        {
            this.Sortear();
        }

        private void frmSorteio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                String msg = "Números Sorteados:\n\n";
                int i = 0;
                foreach (int nro in listaNrosSorteados)
                {
                    i++;
                    msg += i + "º - " + nro + "\n";
                }
                msg += "\nTotal de números sorteados: " + i;
                MessageBox.Show(msg);
            }
        }
    }
}
