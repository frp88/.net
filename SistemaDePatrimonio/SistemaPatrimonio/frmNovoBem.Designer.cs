namespace SistemaPatrimonio
{
    partial class frmNovoBem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNovoBem));
            this.btSalvar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxRespLoc = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.cbResponsavel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxDadosBem = new System.Windows.Forms.GroupBox();
            this.cbTipoBem = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumPatrimonio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxRespLoc.SuspendLayout();
            this.groupBoxDadosBem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSalvar
            // 
            this.btSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btSalvar.Image")));
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSalvar.Location = new System.Drawing.Point(12, 385);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(105, 25);
            this.btSalvar.TabIndex = 4;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btSalvar, "Salvar Bem / Equipamento.");
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 367);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxRespLoc);
            this.tabPage1.Controls.Add(this.groupBoxDadosBem);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(640, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Novo Bem / Equipamento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxRespLoc
            // 
            this.groupBoxRespLoc.Controls.Add(this.label4);
            this.groupBoxRespLoc.Controls.Add(this.cbSala);
            this.groupBoxRespLoc.Controls.Add(this.cbResponsavel);
            this.groupBoxRespLoc.Controls.Add(this.label5);
            this.groupBoxRespLoc.Controls.Add(this.label6);
            this.groupBoxRespLoc.Location = new System.Drawing.Point(9, 196);
            this.groupBoxRespLoc.Name = "groupBoxRespLoc";
            this.groupBoxRespLoc.Size = new System.Drawing.Size(621, 131);
            this.groupBoxRespLoc.TabIndex = 1;
            this.groupBoxRespLoc.TabStop = false;
            this.groupBoxRespLoc.Text = "Responsável e Localização do Bem / Equipamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Anexo - Descrição do Local - Número do Local";
            // 
            // cbSala
            // 
            this.cbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(13, 90);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(602, 22);
            this.cbSala.TabIndex = 4;
            // 
            // cbResponsavel
            // 
            this.cbResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsavel.FormattingEnabled = true;
            this.cbResponsavel.Location = new System.Drawing.Point(13, 40);
            this.cbResponsavel.Name = "cbResponsavel";
            this.cbResponsavel.Size = new System.Drawing.Size(602, 22);
            this.cbResponsavel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 14);
            this.label5.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Responsável";
            // 
            // groupBoxDadosBem
            // 
            this.groupBoxDadosBem.Controls.Add(this.cbTipoBem);
            this.groupBoxDadosBem.Controls.Add(this.txtDescricao);
            this.groupBoxDadosBem.Controls.Add(this.label3);
            this.groupBoxDadosBem.Controls.Add(this.label1);
            this.groupBoxDadosBem.Controls.Add(this.txtNumPatrimonio);
            this.groupBoxDadosBem.Controls.Add(this.label2);
            this.groupBoxDadosBem.Location = new System.Drawing.Point(9, 6);
            this.groupBoxDadosBem.Name = "groupBoxDadosBem";
            this.groupBoxDadosBem.Size = new System.Drawing.Size(621, 181);
            this.groupBoxDadosBem.TabIndex = 0;
            this.groupBoxDadosBem.TabStop = false;
            this.groupBoxDadosBem.Text = "Dados do Bem / Equipamento";
            // 
            // cbTipoBem
            // 
            this.cbTipoBem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoBem.FormattingEnabled = true;
            this.cbTipoBem.Location = new System.Drawing.Point(270, 43);
            this.cbTipoBem.Name = "cbTipoBem";
            this.cbTipoBem.Size = new System.Drawing.Size(345, 22);
            this.cbTipoBem.TabIndex = 4;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(13, 92);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(602, 74);
            this.txtDescricao.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número Patrimonial";
            // 
            // txtNumPatrimonio
            // 
            this.txtNumPatrimonio.Location = new System.Drawing.Point(13, 43);
            this.txtNumPatrimonio.Name = "txtNumPatrimonio";
            this.txtNumPatrimonio.Size = new System.Drawing.Size(251, 22);
            this.txtNumPatrimonio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de Bem";
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(555, 385);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(105, 25);
            this.btFechar.TabIndex = 5;
            this.btFechar.Text = "Cancelar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btFechar, "Cancelar Cadastro / Edição do Bem / Equipamento.");
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // frmNovoBem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 419);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btFechar);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(684, 453);
            this.MinimumSize = new System.Drawing.Size(684, 453);
            this.Name = "frmNovoBem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Bem / Equipamento";
            this.Shown += new System.EventHandler(this.frmNovoBem_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxRespLoc.ResumeLayout(false);
            this.groupBoxRespLoc.PerformLayout();
            this.groupBoxDadosBem.ResumeLayout(false);
            this.groupBoxDadosBem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNumPatrimonio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.GroupBox groupBoxDadosBem;
        private System.Windows.Forms.GroupBox groupBoxRespLoc;
        private System.Windows.Forms.ComboBox cbResponsavel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSala;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbTipoBem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}