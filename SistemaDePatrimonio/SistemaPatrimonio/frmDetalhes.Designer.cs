namespace SistemaPatrimonio
{
    partial class frmDetalhes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalhes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btGerarRelatorio = new System.Windows.Forms.Button();
            this.ckbNaoDevolvidos = new System.Windows.Forms.CheckBox();
            this.dgvHistoricoMov = new System.Windows.Forms.DataGridView();
            this.btFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoMov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(968, 473);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btGerarRelatorio);
            this.tabPage1.Controls.Add(this.ckbNaoDevolvidos);
            this.tabPage1.Controls.Add(this.dgvHistoricoMov);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(960, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hitórico de Movimentações";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btGerarRelatorio
            // 
            this.btGerarRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btGerarRelatorio.Image")));
            this.btGerarRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerarRelatorio.Location = new System.Drawing.Point(213, 6);
            this.btGerarRelatorio.Name = "btGerarRelatorio";
            this.btGerarRelatorio.Size = new System.Drawing.Size(171, 25);
            this.btGerarRelatorio.TabIndex = 2;
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
            this.ckbNaoDevolvidos.Location = new System.Drawing.Point(6, 10);
            this.ckbNaoDevolvidos.Name = "ckbNaoDevolvidos";
            this.ckbNaoDevolvidos.Size = new System.Drawing.Size(178, 18);
            this.ckbNaoDevolvidos.TabIndex = 6;
            this.ckbNaoDevolvidos.Text = "Somente os Não Devolvidos";
            this.ckbNaoDevolvidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbNaoDevolvidos.UseVisualStyleBackColor = true;
            this.ckbNaoDevolvidos.CheckedChanged += new System.EventHandler(this.ckbNaoDevolvidos_CheckedChanged);
            // 
            // dgvHistoricoMov
            // 
            this.dgvHistoricoMov.AllowUserToAddRows = false;
            this.dgvHistoricoMov.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvHistoricoMov.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistoricoMov.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistoricoMov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoricoMov.Location = new System.Drawing.Point(6, 37);
            this.dgvHistoricoMov.Name = "dgvHistoricoMov";
            this.dgvHistoricoMov.ReadOnly = true;
            this.dgvHistoricoMov.RowHeadersWidth = 15;
            this.dgvHistoricoMov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoricoMov.Size = new System.Drawing.Size(948, 403);
            this.dgvHistoricoMov.TabIndex = 0;
            this.dgvHistoricoMov.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvHistoricoMov_DataBindingComplete);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(875, 491);
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
            this.pictureBox1.Location = new System.Drawing.Point(22, 487);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Informação.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Clique no cabeçalho de qualquer coluna para ordenar os dados";
            // 
            // frmDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 528);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1008, 562);
            this.MinimumSize = new System.Drawing.Size(1008, 562);
            this.Name = "frmDetalhes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hitórico de Movimentações";
            this.Shown += new System.EventHandler(this.frmDetalhes_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoMov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvHistoricoMov;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btGerarRelatorio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox ckbNaoDevolvidos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}