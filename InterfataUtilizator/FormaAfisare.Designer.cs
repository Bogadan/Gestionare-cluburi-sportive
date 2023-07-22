namespace InterfataUtilizator
{
    partial class FormaAfisare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaAfisare));
            this.dataGridMasini = new System.Windows.Forms.DataGridView();
            this.groupBoxEditare = new System.Windows.Forms.GroupBox();
            this.lblIdMasina = new System.Windows.Forms.Label();
            this.btnActualizeaza = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.txtClub = new System.Windows.Forms.TextBox();
            this.btnAfiseazaFormaAdaugare = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logoApp = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasini)).BeginInit();
            this.groupBoxEditare.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoApp)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridMasini
            // 
            this.dataGridMasini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMasini.Location = new System.Drawing.Point(270, 291);
            this.dataGridMasini.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridMasini.Name = "dataGridMasini";
            this.dataGridMasini.RowHeadersWidth = 51;
            this.dataGridMasini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMasini.Size = new System.Drawing.Size(15, 16);
            this.dataGridMasini.TabIndex = 0;
            this.dataGridMasini.Visible = false;
            this.dataGridMasini.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMasini_CellContentClick);
            // 
            // groupBoxEditare
            // 
            this.groupBoxEditare.Controls.Add(this.lblIdMasina);
            this.groupBoxEditare.Controls.Add(this.btnActualizeaza);
            this.groupBoxEditare.Controls.Add(this.label2);
            this.groupBoxEditare.Controls.Add(this.label1);
            this.groupBoxEditare.Controls.Add(this.txtManager);
            this.groupBoxEditare.Controls.Add(this.txtClub);
            this.groupBoxEditare.Location = new System.Drawing.Point(264, 236);
            this.groupBoxEditare.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxEditare.Name = "groupBoxEditare";
            this.groupBoxEditare.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxEditare.Size = new System.Drawing.Size(36, 22);
            this.groupBoxEditare.TabIndex = 1;
            this.groupBoxEditare.TabStop = false;
            this.groupBoxEditare.Text = "Editare informatii catalog";
            this.groupBoxEditare.Visible = false;
            // 
            // lblIdMasina
            // 
            this.lblIdMasina.AutoSize = true;
            this.lblIdMasina.Location = new System.Drawing.Point(575, 85);
            this.lblIdMasina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdMasina.Name = "lblIdMasina";
            this.lblIdMasina.Size = new System.Drawing.Size(0, 17);
            this.lblIdMasina.TabIndex = 9;
            this.lblIdMasina.Visible = false;
            // 
            // btnActualizeaza
            // 
            this.btnActualizeaza.Location = new System.Drawing.Point(395, 62);
            this.btnActualizeaza.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizeaza.Name = "btnActualizeaza";
            this.btnActualizeaza.Size = new System.Drawing.Size(100, 28);
            this.btnActualizeaza.TabIndex = 8;
            this.btnActualizeaza.Text = "Actualizeaza";
            this.btnActualizeaza.UseVisualStyleBackColor = true;
            this.btnActualizeaza.Click += new System.EventHandler(this.btnActualizeaza_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Manager";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nume Club";
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(151, 70);
            this.txtManager.Margin = new System.Windows.Forms.Padding(4);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(219, 22);
            this.txtManager.TabIndex = 2;
            // 
            // txtClub
            // 
            this.txtClub.Location = new System.Drawing.Point(151, 28);
            this.txtClub.Margin = new System.Windows.Forms.Padding(4);
            this.txtClub.Name = "txtClub";
            this.txtClub.Size = new System.Drawing.Size(219, 22);
            this.txtClub.TabIndex = 0;
            // 
            // btnAfiseazaFormaAdaugare
            // 
            this.btnAfiseazaFormaAdaugare.BackColor = System.Drawing.Color.Transparent;
            this.btnAfiseazaFormaAdaugare.FlatAppearance.BorderSize = 0;
            this.btnAfiseazaFormaAdaugare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAfiseazaFormaAdaugare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfiseazaFormaAdaugare.Image = ((System.Drawing.Image)(resources.GetObject("btnAfiseazaFormaAdaugare.Image")));
            this.btnAfiseazaFormaAdaugare.Location = new System.Drawing.Point(332, 301);
            this.btnAfiseazaFormaAdaugare.Margin = new System.Windows.Forms.Padding(4);
            this.btnAfiseazaFormaAdaugare.Name = "btnAfiseazaFormaAdaugare";
            this.btnAfiseazaFormaAdaugare.Size = new System.Drawing.Size(179, 164);
            this.btnAfiseazaFormaAdaugare.TabIndex = 2;
            this.btnAfiseazaFormaAdaugare.UseVisualStyleBackColor = false;
            this.btnAfiseazaFormaAdaugare.Click += new System.EventHandler(this.btnAfiseazaFormaAdaugare_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(332, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 153);
            this.button1.TabIndex = 4;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(332, 150);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 155);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(164)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dataGridMasini);
            this.panel1.Controls.Add(this.groupBoxEditare);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.logoApp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 463);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 368);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 98);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "s.l. dr. ing. Gîză-Belciug Felicia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Coordonator:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Niculică Bogdan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Realizator:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Proiect Baze de Date";
            // 
            // logoApp
            // 
            this.logoApp.Image = ((System.Drawing.Image)(resources.GetObject("logoApp.Image")));
            this.logoApp.Location = new System.Drawing.Point(30, 12);
            this.logoApp.Name = "logoApp";
            this.logoApp.Size = new System.Drawing.Size(270, 176);
            this.logoApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoApp.TabIndex = 7;
            this.logoApp.TabStop = false;
            // 
            // FormaAfisare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 463);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAfiseazaFormaAdaugare);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormaAfisare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Meniu principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaAfisare_FormClosed);
            this.Load += new System.EventHandler(this.FormaAfisare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasini)).EndInit();
            this.groupBoxEditare.ResumeLayout(false);
            this.groupBoxEditare.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridMasini;
        private System.Windows.Forms.GroupBox groupBoxEditare;
        private System.Windows.Forms.Button btnActualizeaza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.TextBox txtClub;
        private System.Windows.Forms.Label lblIdMasina;
        private System.Windows.Forms.Button btnAfiseazaFormaAdaugare;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox logoApp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

