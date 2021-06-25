namespace SistemaPatrimonio
{
    partial class frmBem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBem));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoBem = new System.Windows.Forms.ComboBox();
            this.dgvBem = new System.Windows.Forms.DataGridView();
            this.btDetalhes2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deposito2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.baixa2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btDetalhes = new System.Windows.Forms.DataGridViewImageColumn();
            this.deposito = new System.Windows.Forms.DataGridViewImageColumn();
            this.baixa = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btNovo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirBemEquipamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btFechar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBem)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(974, 487);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbTipoBem);
            this.tabPage1.Controls.Add(this.dgvBem);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.btNovo);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(966, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controle de Bens / Equipamentos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Bem:";
            // 
            // cbTipoBem
            // 
            this.cbTipoBem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoBem.FormattingEnabled = true;
            this.cbTipoBem.Items.AddRange(new object[] {
            "Selecione um Tipo de Bem"});
            this.cbTipoBem.Location = new System.Drawing.Point(598, 9);
            this.cbTipoBem.Name = "cbTipoBem";
            this.cbTipoBem.Size = new System.Drawing.Size(222, 22);
            this.cbTipoBem.TabIndex = 3;
            this.cbTipoBem.SelectedValueChanged += new System.EventHandler(this.cbTipoBem_SelectedValueChanged);
            // 
            // dgvBem
            // 
            this.dgvBem.AllowUserToAddRows = false;
            this.dgvBem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBem.BackgroundColor = System.Drawing.Color.White;
            this.dgvBem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btDetalhes2,
            this.deposito2,
            this.baixa2,
            this.btDetalhes,
            this.deposito,
            this.baixa});
            this.dgvBem.Location = new System.Drawing.Point(11, 38);
            this.dgvBem.Name = "dgvBem";
            this.dgvBem.ReadOnly = true;
            this.dgvBem.RowHeadersWidth = 15;
            this.dgvBem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBem.Size = new System.Drawing.Size(944, 407);
            this.dgvBem.TabIndex = 5;
            this.dgvBem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBem_CellClick);
            this.dgvBem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBem_CellDoubleClick);
            this.dgvBem.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvBem_DataBindingComplete);
            this.dgvBem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvBem_MouseUp);
            // 
            // btDetalhes2
            // 
            this.btDetalhes2.HeaderText = "";
            this.btDetalhes2.Name = "btDetalhes2";
            this.btDetalhes2.ReadOnly = true;
            // 
            // deposito2
            // 
            this.deposito2.HeaderText = "";
            this.deposito2.Name = "deposito2";
            this.deposito2.ReadOnly = true;
            this.deposito2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deposito2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // baixa2
            // 
            this.baixa2.HeaderText = "";
            this.baixa2.Name = "baixa2";
            this.baixa2.ReadOnly = true;
            this.baixa2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.baixa2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btDetalhes
            // 
            this.btDetalhes.HeaderText = "";
            this.btDetalhes.Image = global::SistemaPatrimonio.Properties.Resources.detalhes;
            this.btDetalhes.Name = "btDetalhes";
            this.btDetalhes.ReadOnly = true;
            // 
            // deposito
            // 
            this.deposito.HeaderText = "";
            this.deposito.Image = global::SistemaPatrimonio.Properties.Resources.imgDepositar;
            this.deposito.Name = "deposito";
            this.deposito.ReadOnly = true;
            // 
            // baixa
            // 
            this.baixa.HeaderText = "";
            this.baixa.Image = global::SistemaPatrimonio.Properties.Resources.imgBaixar;
            this.baixa.Name = "baixa";
            this.baixa.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite o nro Pat. ou o Desc. do Bem:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(222, 9);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(284, 22);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyUp);
            // 
            // btNovo
            // 
            this.btNovo.Image = ((System.Drawing.Image)(resources.GetObject("btNovo.Image")));
            this.btNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNovo.Location = new System.Drawing.Point(837, 7);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(118, 25);
            this.btNovo.TabIndex = 4;
            this.btNovo.Text = "Novo Cadastro";
            this.btNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btNovo, "Cadastrar Novo Bem /Equipamento.");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 502);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Duplo clique para editar | Botão Direito para Excluir";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirBemEquipamentoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(223, 26);
            // 
            // excluirBemEquipamentoToolStripMenuItem
            // 
            this.excluirBemEquipamentoToolStripMenuItem.Name = "excluirBemEquipamentoToolStripMenuItem";
            this.excluirBemEquipamentoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.excluirBemEquipamentoToolStripMenuItem.Text = "Excluir Bem / Equipamento?";
            this.excluirBemEquipamentoToolStripMenuItem.Click += new System.EventHandler(this.excluirBemEquipamentoToolStripMenuItem_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(881, 505);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(105, 25);
            this.btFechar.TabIndex = 1;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btFechar, "Fechar Tela.");
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaPatrimonio.Properties.Resources.information;
            this.pictureBox1.Location = new System.Drawing.Point(27, 502);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Informação.");
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Image";
            this.dataGridViewImageColumn1.Image = global::SistemaPatrimonio.Properties.Resources.information;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::SistemaPatrimonio.Properties.Resources.imgDepositar;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = global::SistemaPatrimonio.Properties.Resources.imgBaixar;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            // 
            // frmBem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 542);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Bens / Equipamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBem_FormClosing);
            this.Shown += new System.EventHandler(this.frmBem_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvBem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirBemEquipamentoToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTipoBem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn btDetalhes2;
        private System.Windows.Forms.DataGridViewButtonColumn deposito2;
        private System.Windows.Forms.DataGridViewButtonColumn baixa2;
        private System.Windows.Forms.DataGridViewImageColumn btDetalhes;
        private System.Windows.Forms.DataGridViewImageColumn deposito;
        private System.Windows.Forms.DataGridViewImageColumn baixa;
    }
}