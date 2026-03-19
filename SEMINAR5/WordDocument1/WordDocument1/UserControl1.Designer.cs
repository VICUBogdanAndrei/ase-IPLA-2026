namespace WordDocument1
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbProduse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numCantitate = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.buttonPDF = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProduse
            // 
            this.cmbProduse.FormattingEnabled = true;
            this.cmbProduse.Location = new System.Drawing.Point(31, 31);
            this.cmbProduse.Name = "cmbProduse";
            this.cmbProduse.Size = new System.Drawing.Size(171, 21);
            this.cmbProduse.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantitate";
            // 
            // numCantitate
            // 
            this.numCantitate.Location = new System.Drawing.Point(31, 90);
            this.numCantitate.Name = "numCantitate";
            this.numCantitate.Size = new System.Drawing.Size(120, 20);
            this.numCantitate.TabIndex = 3;
            this.numCantitate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Adauga Produs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(28, 218);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 5;
            this.lblClient.Text = "Client -";
            // 
            // buttonPDF
            // 
            this.buttonPDF.Location = new System.Drawing.Point(31, 324);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(120, 23);
            this.buttonPDF.TabIndex = 6;
            this.buttonPDF.Text = "Salveaza PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.buttonPDF_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(34, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Sterge Ultima Linie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numCantitate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProduse);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(359, 456);
            ((System.ComponentModel.ISupportInitialize)(this.numCantitate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProduse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCantitate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.Button button2;
    }
}
