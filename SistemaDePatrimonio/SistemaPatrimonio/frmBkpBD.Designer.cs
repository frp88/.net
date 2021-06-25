namespace SistemaPatrimonio
{
    partial class frmBkpBD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBkpBD));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btFazerBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btSelecionarLocal = new System.Windows.Forms.Button();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.btFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 202);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btFazerBackup);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btSelecionarLocal);
            this.tabPage1.Controls.Add(this.txtLocal);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(604, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Backup dos Dados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btFazerBackup
            // 
            this.btFazerBackup.Font = new System.Drawing.Font("Tahoma", 18F);
            this.btFazerBackup.Location = new System.Drawing.Point(12, 120);
            this.btFazerBackup.Name = "btFazerBackup";
            this.btFazerBackup.Size = new System.Drawing.Size(579, 40);
            this.btFazerBackup.TabIndex = 22;
            this.btFazerBackup.Text = "Fazer o Backup";
            this.toolTip1.SetToolTip(this.btFazerBackup, "Clique aqui para Fazer o Backup do Banco de Dados do Sistema.");
            this.btFazerBackup.UseVisualStyleBackColor = true;
            this.btFazerBackup.Click += new System.EventHandler(this.btFazerBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "Caminho e Nome do Arquivo de Backup do Banco de Dados do Sistema";
            // 
            // btSelecionarLocal
            // 
            this.btSelecionarLocal.Font = new System.Drawing.Font("Tahoma", 18F);
            this.btSelecionarLocal.Location = new System.Drawing.Point(12, 12);
            this.btSelecionarLocal.Name = "btSelecionarLocal";
            this.btSelecionarLocal.Size = new System.Drawing.Size(579, 40);
            this.btSelecionarLocal.TabIndex = 19;
            this.btSelecionarLocal.Text = "Selecionar o Local";
            this.toolTip1.SetToolTip(this.btSelecionarLocal, "Clique aqui para Selecionar o Local onde será salvo o arquivo de Backup do Banco " +
                    "de Dados do Sistema.");
            this.btSelecionarLocal.UseVisualStyleBackColor = true;
            this.btSelecionarLocal.Click += new System.EventHandler(this.btSelecionarLocal_Click);
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(12, 80);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(579, 22);
            this.txtLocal.TabIndex = 20;
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(519, 220);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(105, 25);
            this.btFechar.TabIndex = 17;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btFechar, "Fechar a Tela.");
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // frmBkpBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 255);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBkpBD";
            this.Text = "Backup dos Dados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBkpBD_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btSelecionarLocal;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btFazerBackup;
        private System.Windows.Forms.Label label1;
    }
}