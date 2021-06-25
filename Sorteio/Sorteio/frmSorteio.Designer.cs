namespace Sorteio
{
    partial class frmSorteio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSorteio));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelResultado = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSortearNovamente = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelNroSorteado = new System.Windows.Forms.Label();
            this.labelNroSorteadoMais100 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSortearNovamente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(205)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 115);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(148, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 111);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sorte Grande";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(205)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 418);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(835, 44);
            this.panel2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(139, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(498, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "2018 - Desenvolvido por: Fernando Roberto Proença";
            // 
            // labelResultado
            // 
            this.labelResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResultado.AutoSize = true;
            this.labelResultado.BackColor = System.Drawing.Color.Transparent;
            this.labelResultado.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(116)))), ((int)(((byte)(205)))));
            this.labelResultado.Location = new System.Drawing.Point(235, 369);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(201, 37);
            this.labelResultado.TabIndex = 1;
            this.labelResultado.Text = "Sorteando...";
            this.labelResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSortearNovamente
            // 
            this.btnSortearNovamente.BackColor = System.Drawing.Color.Transparent;
            this.btnSortearNovamente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortearNovamente.Image = global::Sorteio.Properties.Resources.refresh;
            this.btnSortearNovamente.Location = new System.Drawing.Point(52, 212);
            this.btnSortearNovamente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSortearNovamente.Name = "btnSortearNovamente";
            this.btnSortearNovamente.Size = new System.Drawing.Size(100, 100);
            this.btnSortearNovamente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSortearNovamente.TabIndex = 13;
            this.btnSortearNovamente.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSortearNovamente, "Clique aqui para sortear novamente.");
            this.btnSortearNovamente.Click += new System.EventHandler(this.btnSortearNovamente_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Transparent;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Image = global::Sorteio.Properties.Resources.home;
            this.btnVoltar.Location = new System.Drawing.Point(679, 212);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 100);
            this.btnVoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnVoltar, "Clique aqui para voltar para a tela inicial.");
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sorteio.Properties.Resources.sorte_grande;
            this.pictureBox2.Location = new System.Drawing.Point(27, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Sorteio.Properties.Resources.bola;
            this.panel3.Controls.Add(this.labelNroSorteado);
            this.panel3.Controls.Add(this.labelNroSorteadoMais100);
            this.panel3.Location = new System.Drawing.Point(282, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 230);
            this.panel3.TabIndex = 0;
            // 
            // labelNroSorteado
            // 
            this.labelNroSorteado.AutoSize = true;
            this.labelNroSorteado.BackColor = System.Drawing.Color.Transparent;
            this.labelNroSorteado.Font = new System.Drawing.Font("Arial", 86.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNroSorteado.Location = new System.Drawing.Point(22, 48);
            this.labelNroSorteado.Name = "labelNroSorteado";
            this.labelNroSorteado.Size = new System.Drawing.Size(185, 133);
            this.labelNroSorteado.TabIndex = 1;
            this.labelNroSorteado.Text = "49";
            this.labelNroSorteado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNroSorteadoMais100
            // 
            this.labelNroSorteadoMais100.AutoSize = true;
            this.labelNroSorteadoMais100.BackColor = System.Drawing.Color.Transparent;
            this.labelNroSorteadoMais100.Font = new System.Drawing.Font("Arial", 78F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNroSorteadoMais100.Location = new System.Drawing.Point(3, 56);
            this.labelNroSorteadoMais100.Name = "labelNroSorteadoMais100";
            this.labelNroSorteadoMais100.Size = new System.Drawing.Size(224, 120);
            this.labelNroSorteadoMais100.TabIndex = 1;
            this.labelNroSorteadoMais100.Text = "345";
            this.labelNroSorteadoMais100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSorteio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.ControlBox = false;
            this.Controls.Add(this.btnSortearNovamente);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "frmSorteio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorte Grande - Tela do Sorteio";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSorteio_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSortearNovamente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoltar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelNroSorteado;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelNroSorteadoMais100;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.PictureBox btnVoltar;
        private System.Windows.Forms.PictureBox btnSortearNovamente;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
    }
}

