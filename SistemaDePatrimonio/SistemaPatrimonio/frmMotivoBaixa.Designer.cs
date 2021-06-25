namespace SistemaPatrimonio
{
    partial class frmMotivoBaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMotivoBaixa));
            this.btBaixar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMotivoBaixa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBaixar
            // 
            this.btBaixar.Image = ((System.Drawing.Image)(resources.GetObject("btBaixar.Image")));
            this.btBaixar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBaixar.Location = new System.Drawing.Point(12, 172);
            this.btBaixar.Name = "btBaixar";
            this.btBaixar.Size = new System.Drawing.Size(112, 25);
            this.btBaixar.TabIndex = 1;
            this.btBaixar.Text = "Baixar Bem";
            this.btBaixar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btBaixar, "Clique aqui para Baixar o Bem / Equipamento.");
            this.btBaixar.UseVisualStyleBackColor = true;
            this.btBaixar.Click += new System.EventHandler(this.btBaixar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 154);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMotivoBaixa);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 127);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Motivo para a Baixa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMotivoBaixa
            // 
            this.txtMotivoBaixa.Location = new System.Drawing.Point(9, 33);
            this.txtMotivoBaixa.Multiline = true;
            this.txtMotivoBaixa.Name = "txtMotivoBaixa";
            this.txtMotivoBaixa.Size = new System.Drawing.Size(447, 74);
            this.txtMotivoBaixa.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite o Motivo para a Baixa do Bem / Equipamento";
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.Location = new System.Drawing.Point(378, 172);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(105, 25);
            this.btFechar.TabIndex = 2;
            this.btFechar.Text = "Cancelar";
            this.btFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btFechar, "Clique aqui para Cancelar a Baixa do Bem / Equipamento.");
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // frmMotivoBaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 205);
            this.Controls.Add(this.btBaixar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btFechar);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(508, 239);
            this.MinimumSize = new System.Drawing.Size(508, 239);
            this.Name = "frmMotivoBaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motivo para a Baixa do Bem / Equipamento";
            this.Shown += new System.EventHandler(this.frmMotivoBaixa_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBaixar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFechar;
        public System.Windows.Forms.TextBox txtMotivoBaixa;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}