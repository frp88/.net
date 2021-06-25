namespace SistemaPatrimonio
{
    partial class frmMovimentacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimentacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btGerarRelatorio = new System.Windows.Forms.Button();
            this.ckbNaoDevolvidos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoBem = new System.Windows.Forms.ComboBox();
            this.dgvMovimentacao = new System.Windows.Forms.DataGridView();
            this.transferir2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.transferir = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btFechar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentacao)).BeginInit();
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
            this.tabPage1.Controls.Add(this.btGerarRelatorio);
            this.tabPage1.Controls.Add(this.ckbNaoDevolvidos);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbTipoBem);
            this.tabPage1.Controls.Add(this.dgvMovimentacao);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(966, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Movimentação de Bens / Equipamentos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btGerarRelatorio
            // 
            this.btGerarRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btGerarRelatorio.Image")));
            this.btGerarRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerarRelatorio.Location = new System.Drawing.Point(222, 39);
            this.btGerarRelatorio.Name = "btGerarRelatorio";
            this.btGerarRelatorio.Size = new System.Drawing.Size(206, 25);
            this.btGerarRelatorio.TabIndex = 3;
            this.btGerarRelatorio.Text = "Gerar Relatório";
            this.btGerarRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btGerarRelatorio, "Clique aqui para Gerar o Relatório.");
            this.btGerarRelatorio.UseVisualStyleBackColor = true;
            this.btGerarRelatorio.Click += new System.EventHandler(this.btGerarRelatorio_Click);
            // 
            // ckbNaoDevolvidos
            // 
            this.ckbNaoDevolvidos.AutoSize = true;
            this.ckbNaoDevolvidos.Checked = true;
            this.ckbNaoDevolvidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNaoDevolvidos.Location = new System.Drawing.Point(11, 43);
            this.ckbNaoDevolvidos.Name = "ckbNaoDevolvidos";
            this.ckbNaoDevolvidos.Size = new System.Drawing.Size(178, 18);
            this.ckbNaoDevolvidos.TabIndex = 5;
            this.ckbNaoDevolvidos.Text = "Somente os Não Devolvidos";
            this.ckbNaoDevolvidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbNaoDevolvidos.UseVisualStyleBackColor = true;
            this.ckbNaoDevolvidos.CheckedChanged += new System.EventHandler(this.ckbNaoDevolvidos_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 12);
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
            this.cbTipoBem.Location = new System.Drawing.Point(711, 9);
            this.cbTipoBem.Name = "cbTipoBem";
            this.cbTipoBem.Size = new System.Drawing.Size(244, 22);
            this.cbTipoBem.TabIndex = 3;
            this.cbTipoBem.SelectedValueChanged += new System.EventHandler(this.cbTipoBem_SelectedValueChanged);
            // 
            // dgvMovimentacao
            // 
            this.dgvMovimentacao.AllowUserToAddRows = false;
            this.dgvMovimentacao.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMovimentacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimentacao.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimentacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transferir2,
            this.transferir});
            this.dgvMovimentacao.Location = new System.Drawing.Point(11, 70);
            this.dgvMovimentacao.Name = "dgvMovimentacao";
            this.dgvMovimentacao.ReadOnly = true;
            this.dgvMovimentacao.RowHeadersWidth = 15;
            this.dgvMovimentacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimentacao.Size = new System.Drawing.Size(944, 375);
            this.dgvMovimentacao.TabIndex = 4;
            this.dgvMovimentacao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimentacao_CellClick);
            this.dgvMovimentacao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimentacao_CellDoubleClick);
            this.dgvMovimentacao.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMovimentacao_DataBindingComplete);
            // 
            // transferir2
            // 
            this.transferir2.HeaderText = "";
            this.transferir2.Name = "transferir2";
            this.transferir2.ReadOnly = true;
            this.transferir2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.transferir2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // transferir
            // 
            this.transferir.HeaderText = "";
            this.transferir.Image = global::SistemaPatrimonio.Properties.Resources.transferir;
            this.transferir.Name = "transferir";
            this.transferir.ReadOnly = true;
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
            this.txtNome.Size = new System.Drawing.Size(330, 22);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 503);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Duplo clique para Visualizar a Observação";
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(881, 505);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(105, 25);
            this.btFechar.TabIndex = 2;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btFechar, "Fechar Tela.");
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaPatrimonio.Properties.Resources.information;
            this.pictureBox1.Location = new System.Drawing.Point(27, 501);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Informação.");
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::SistemaPatrimonio.Properties.Resources.transferir;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // frmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 542);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "frmMovimentacao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentação de Bens / Equipamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMovimentacao_FormClosing);
            this.Shown += new System.EventHandler(this.frmMovimentacao_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTipoBem;
        private System.Windows.Forms.DataGridView dgvMovimentacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btGerarRelatorio;
        private System.Windows.Forms.CheckBox ckbNaoDevolvidos;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn transferir2;
        private System.Windows.Forms.DataGridViewImageColumn transferir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}