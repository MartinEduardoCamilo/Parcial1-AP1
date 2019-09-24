namespace Parcial1_AP1.UI.Consultas
{
    partial class cEvaluacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DesdedateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.HastadateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FiltrocomboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CriteriotextBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta";
            // 
            // DesdedateTimePicker1
            // 
            this.DesdedateTimePicker1.CustomFormat = "dd\\MM\\yyyy";
            this.DesdedateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdedateTimePicker1.Location = new System.Drawing.Point(16, 30);
            this.DesdedateTimePicker1.Name = "DesdedateTimePicker1";
            this.DesdedateTimePicker1.Size = new System.Drawing.Size(84, 20);
            this.DesdedateTimePicker1.TabIndex = 2;
            // 
            // HastadateTimePicker1
            // 
            this.HastadateTimePicker1.CustomFormat = "dd\\MM\\yyyy";
            this.HastadateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastadateTimePicker1.Location = new System.Drawing.Point(108, 30);
            this.HastadateTimePicker1.Name = "HastadateTimePicker1";
            this.HastadateTimePicker1.Size = new System.Drawing.Size(84, 20);
            this.HastadateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtro";
            // 
            // FiltrocomboBox1
            // 
            this.FiltrocomboBox1.FormattingEnabled = true;
            this.FiltrocomboBox1.Items.AddRange(new object[] {
            "Todo",
            "ID",
            "Nombre"});
            this.FiltrocomboBox1.Location = new System.Drawing.Point(198, 29);
            this.FiltrocomboBox1.Name = "FiltrocomboBox1";
            this.FiltrocomboBox1.Size = new System.Drawing.Size(99, 21);
            this.FiltrocomboBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Criterio";
            // 
            // CriteriotextBox1
            // 
            this.CriteriotextBox1.Location = new System.Drawing.Point(303, 30);
            this.CriteriotextBox1.Name = "CriteriotextBox1";
            this.CriteriotextBox1.Size = new System.Drawing.Size(365, 20);
            this.CriteriotextBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 21);
            this.button1.TabIndex = 8;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 388);
            this.dataGridView1.TabIndex = 9;
            // 
            // cRegistrodeEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CriteriotextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FiltrocomboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HastadateTimePicker1);
            this.Controls.Add(this.DesdedateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "cRegistrodeEvaluacion";
            this.Text = "Consulta de Evaluacion";
            this.Load += new System.EventHandler(this.CRegistrodeEvaluacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DesdedateTimePicker1;
        private System.Windows.Forms.DateTimePicker HastadateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FiltrocomboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CriteriotextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}