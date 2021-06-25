namespace SistemaPatrimonio
{
    partial class frmSala
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSala));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvSala = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btNovo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btFechar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirTipoDeBemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btDetalhes2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btDetalhes = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSala)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 487);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSala);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.btNovo);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controle de Locais";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvSala
            // 
            this.dgvSala.AllowUserToAddRows = false;
            this.dgvSala.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSala.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSala.BackgroundColor = System.Drawing.Color.White;
            this.dgvSala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSala.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btDetalhes2,
            this.btDetalhes});
            this.dgvSala.Location = new System.Drawing.Point(11, 38);
            this.dgvSala.Name = "dgvSala";
            this.dgvSala.ReadOnly = true;
            this.dgvSala.RowHeadersWidth = 15;
            this.dgvSala.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSala.Size = new System.Drawing.Size(660, 407);
            this.dgvSala.TabIndex = 3;
            this.dgvSala.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSala_CellClick);
            this.dgvSala.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSala_CellDoubleClick);
            this.dgvSala.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSala_DataBindingComplete);
            this.dgvSala.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvSala_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite o anexo, número ou descrição:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(226, 9);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 22);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyUp);
            // 
            // btNovo
            // 
            this.btNovo.Image = ((System.Drawing.Image)(resources.GetObject("btNovo.Image")));
            this.btNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNovo.Location = new System.Drawing.Point(553, 6);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(118, 25);
            this.btNovo.TabIndex = 2;
            this.btNovo.Text = "Novo Cadastro";
            this.btNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btNovo, "Cadastrar Novo Local.");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 503);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duplo clique para editar | Botão Direito para Excluir";
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(597, 505);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(105, 25);
            this.btFechar.TabIndex = 1;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btFechar, "Fechar Tela.");
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirTipoDeBemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 26);
            // 
            // excluirTipoDeBemToolStripMenuItem
            // 
            this.excluirTipoDeBemToolStripMenuItem.Name = "excluirTipoDeBemToolStripMenuItem";
            this.excluirTipoDeBemToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.excluirTipoDeBemToolStripMenuItem.Text = "Excluir Sala?";
            this.excluirTipoDeBemToolStripMenuItem.Click += new System.EventHandler(this.excluirTipoDeBemToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaPatrimonio.Properties.Resources.information;
            this.pictureBox1.Location = new System.Drawing.Point(27, 501);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Informação.");
            // 
            // btDetalhes2
            // 
            this.btDetalhes2.HeaderText = "";
            this.btDetalhes2.Name = "btDetalhes2";
            this.btDetalhes2.ReadOnly = true;
            // 
            // btDetalhes
            // 
            this.btDetalhes.HeaderText = "";
            this.btDetalhes.Image = global::SistemaPatrimonio.Properties.Resources.detalhes;
            this.btDetalhes.Name = "btDetalhes";
            this.btDetalhes.ReadOnly = true;
            // 
            // frmSala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 542);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btFechar);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frmSala";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Locais";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSala_FormClosing);
            this.Shown += new System.EventHandler(this.frmSalaAnexo_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSala)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvSala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirTipoDeBemToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewButtonColumn btDetalhes2;
        private System.Windows.Forms.DataGridViewImageColumn btDetalhes;
    }
}