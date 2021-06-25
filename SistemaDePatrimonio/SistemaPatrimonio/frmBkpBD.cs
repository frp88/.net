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
    public partial class frmBkpBD : Form
    {
        /// <summary>
        /// Instancia o Formulário
        /// </summary>
        public frmBkpBD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Seleciona o Local onde irá gravar o arquivo de Backup do Banco de Dados do Sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSelecionarLocal_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtLocal.Text = folderBrowserDialog1.SelectedPath.ToString() + @"\bkpPatrimonio_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
            }
        }
        
        /// <summary>
        /// Realiza o Backup do Banco de Dados do Sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btFazerBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtLocal.Text))
                    throw new Exception("Selecione um local para Realizar o Backup do Banco de Dados do Sistema.");
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //proc.StartInfo.FileName = @"D:\UFSCar - PPGCC\MePBD\Projeto SistemaPatrimonio\SistemaPatrimonio\bkpBD.bat";  -- ~/images/
                proc.StartInfo.FileName = @"\bkpBD.bat";
                proc.StartInfo.Arguments = txtLocal.Text.Trim() + ".sql";
                proc.EnableRaisingEvents = false;
                proc.Start();
                proc.Close();
                MessageBox.Show("Back Realizado com Sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na realizar o Backup do Banco de Dados\n\n" + ex.Message, "Atenção! Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Fecha a Tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal.frmFunc = new frmFuncionario();
        }

        /// <summary>
        /// Fecha o Formulário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBkpBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmPrincipal.frmFunc = new frmFuncionario();
        }
    }
}
