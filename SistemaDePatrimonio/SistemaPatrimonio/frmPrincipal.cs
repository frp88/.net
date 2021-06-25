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
    public partial class frmPrincipal : Form
    {
        //DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter _Funcionario = new DataSetPatrimonioTableAdapters.tblfuncionarioTableAdapter();
        public static frmBem frmBem = new frmBem();
        public static frmFuncionario frmFunc = new frmFuncionario();
        public static frmSala frmSala = new frmSala();
        public static frmTipoBem frmTipoBem = new frmTipoBem();
        public static frmMovimentacao frmMov = new frmMovimentacao();
        public static frmMultiplasMovimentacoes frmMultiMov = new frmMultiplasMovimentacoes();
        public static frmBkpBD frmBkpBD = new frmBkpBD();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void bemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmBem.ShowDialog();
            frmBem frmBem = new frmBem();
            frmBem.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmBem.MdiParent = this;
            frmBem.Shown += new EventHandler(Shown);
            frmBem.Show();
            frmBem.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void funcionarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //frmFuncionario frmFunc = new frmFuncionario();
            //frmFunc.ShowDialog();

            frmFunc.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmFunc.MdiParent = this;
            frmFunc.Shown += new EventHandler(Shown);
            frmFunc.Show();
            frmFunc.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void salaAnexoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSala frmSala = new frmSala();
            //frmSala.ShowDialog();
            frmSala.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmSala.MdiParent = this;
            frmSala.Shown += new EventHandler(Shown);
            frmSala.Show();
            frmSala.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void tipoDeBemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmTipoBem frmTipoBem = new frmTipoBem();
            //frmTipoBem.ShowDialog();
            frmTipoBem.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmTipoBem.MdiParent = this;
            frmTipoBem.Shown += new EventHandler(Shown);
            frmTipoBem.Show();
            frmTipoBem.FormClosed += new FormClosedEventHandler(FormClosed);
            //if (Application.OpenForms.Cast<Form>().Count(f => f.GetType().Equals(typeof(frmTipoBem))))
            {

            }
        }

        private void umaMovimentacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmMovimentacao frmMov = new frmMovimentacao();
            //frmMov.ShowDialog();
            frmMov.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmMov.MdiParent = this;
            frmMov.Shown += new EventHandler(Shown);
            frmMov.Show();
            frmMov.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void multiplasMovimentacoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMovimentacao frmMov = new frmMovimentacao();
            //frmMov.ShowDialog();
            frmMultiMov.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmMultiMov.MdiParent = this;
            frmMultiMov.Shown += new EventHandler(Shown);
            frmMultiMov.Show();
            frmMultiMov.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void backUpDosDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBkpBD.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmBkpBD.MdiParent = this;
            frmBkpBD.Shown += new EventHandler(Shown);
            frmBkpBD.Show();
            frmBkpBD.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do sistema?", "Sair do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        void Shown(object sender, EventArgs e)
        {
            ((Form)sender).BringToFront();
            panel1.SendToBack();
        }

        void FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.MdiChildren.Count() == 0)
            if (MdiChildren.Count() == 1)
                panel1.BringToFront();
        }

        public Boolean verificaForms(String nomeForm)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == nomeForm)
                    return true;
            }
            return false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
