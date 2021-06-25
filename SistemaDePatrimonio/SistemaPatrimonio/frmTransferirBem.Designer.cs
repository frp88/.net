namespace SistemaPatrimonio
{
    partial class frmTransferirBem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferirBem));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelNumPatri = new System.Windows.Forms.Label();
            this.labelDescBem = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbResponsavel = new System.Windows.Forms.ComboBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btTransferir = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(14, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(563, 349);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelNumPatri);
            this.tabPage1.Controls.Add(this.labelDescBem);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(555, 322);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transferir Bem";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelNumPatri
            // 
            this.labelNumPatri.AutoSize = true;
            this.labelNumPatri.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelNumPatri.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelNumPatri.Location = new System.Drawing.Point(7, 49);
            this.labelNumPatri.Name = "labelNumPatri";
            this.labelNumPatri.Size = new System.Drawing.Size(20, 17);
            this.labelNumPatri.TabIndex = 1;
            this.labelNumPatri.Text = "...";
            // 
            // labelDescBem
            // 
            this.labelDescBem.AutoSize = true;
            this.labelDescBem.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelDescBem.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelDescBem.Location = new System.Drawing.Point(7, 17);
            this.labelDescBem.Name = "labelDescBem";
            this.labelDescBem.Size = new System.Drawing.Size(20, 17);
            this.labelDescBem.TabIndex = 0;
            this.labelDescBem.Text = "...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbResponsavel);
            this.groupBox1.Controls.Add(this.txtObservacao);
            this.groupBox1.Controls.Add(this.cbSala);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(6, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 226);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Transferência";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "Novo Responsável";
            // 
            // cbResponsavel
            // 
            this.cbResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsavel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbResponsavel.FormattingEnabled = true;
            this.cbResponsavel.Location = new System.Drawing.Point(9, 42);
            this.cbResponsavel.Name = "cbResponsavel";
            this.cbResponsavel.Size = new System.Drawing.Size(525, 22);
            this.cbResponsavel.TabIndex = 3;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtObservacao.Location = new System.Drawing.Point(9, 146);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(525, 71);
            this.txtObservacao.TabIndex = 7;
            // 
            // cbSala
            // 
            this.cbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSala.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(9, 95);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(525, 22);
            this.cbSala.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(6, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Observação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Anexo - Descrição do Local - Número do Local";
            // 
            // btTransferir
            // 
            this.btTransferir.Image = global::SistemaPatrimonio.Properties.Resources.transferir;
            this.btTransferir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTransferir.Location = new System.Drawing.Point(14, 368);
            this.btTransferir.Name = "btTransferir";
            this.btTransferir.Size = new System.Drawing.Size(131, 27);
            this.btTransferir.TabIndex = 1;
            this.btTransferir.Text = "Transferir Bem";
            this.btTransferir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btTransferir, "Transferir Bem / Equipamento.");
            this.btTransferir.UseVisualStyleBackColor = true;
            this.btTransferir.Click += new System.EventHandler(this.btTransferir_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(455, 368);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(122, 27);
            this.btFechar.TabIndex = 2;
            this.btFechar.Text = "Cancelar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btFechar, "Cancelar Transferência de Bem / Equipamento.");
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // frmTransferirBem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 407);
            this.Controls.Add(this.btTransferir);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(605, 441);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(605, 441);
            this.Name = "frmTransferirBem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferência de Bem";
            this.Shown += new System.EventHandler(this.frmTransferirBem_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btTransferir;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSala;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbResponsavel;
        public System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelDescBem;
        public System.Windows.Forms.Label labelNumPatri;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}