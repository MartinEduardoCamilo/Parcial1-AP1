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
            this.CriteriotextBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Consultabutton1 = new System.Windows.Forms.Button();
            this.ConsultadataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView1)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(103, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta";
            // 
            // DesdedateTimePicker1
            // 
            this.DesdedateTimePicker1.CustomFormat = "dd\\MM\\yyyy";
            this.DesdedateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdedateTimePicker1.Location = new System.Drawing.Point(16, 29);
            this.DesdedateTimePicker1.Name = "DesdedateTimePicker1";
            this.DesdedateTimePicker1.Size = new System.Drawing.Size(79, 20);
            this.DesdedateTimePicker1.TabIndex = 2;
            // 
            // HastadateTimePicker1
            // 
            this.HastadateTimePicker1.CustomFormat = "dd\\MM\\yyyy";
            this.HastadateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastadateTimePicker1.Location = new System.Drawing.Point(106, 29);
            this.HastadateTimePicker1.Name = "HastadateTimePicker1";
            this.HastadateTimePicker1.Size = new System.Drawing.Size(81, 20);
            this.HastadateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtro";
            // 
            // FiltrocomboBox1
            // 
            this.FiltrocomboBox1.FormattingEnabled = true;
            this.FiltrocomboBox1.Items.AddRange(new object[] {
            "Todos",
            "ID",
            "Nombre"});
            this.FiltrocomboBox1.Location = new System.Drawing.Point(193, 28);
            this.FiltrocomboBox1.Name = "FiltrocomboBox1";
            this.FiltrocomboBox1.Size = new System.Drawing.Size(77, 21);
            this.FiltrocomboBox1.TabIndex = 5;
            // 
            // CriteriotextBox1
            // 
            this.CriteriotextBox1.Location = new System.Drawing.Point(276, 29);
            this.CriteriotextBox1.Name = "CriteriotextBox1";
            this.CriteriotextBox1.Size = new System.Drawing.Size(431, 20);
            this.CriteriotextBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Criterio";
            // 
            // Consultabutton1
            // 
            this.Consultabutton1.Location = new System.Drawing.Point(713, 27);
            this.Consultabutton1.Name = "Consultabutton1";
            this.Consultabutton1.Size = new System.Drawing.Size(75, 23);
            this.Consultabutton1.TabIndex = 8;
            this.Consultabutton1.Text = "Consultar";
            this.Consultabutton1.UseVisualStyleBackColor = true;
            this.Consultabutton1.Click += new System.EventHandler(this.Consultabutton1_Click);
            // 
            // ConsultadataGridView1
            // 
            this.ConsultadataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultadataGridView1.Location = new System.Drawing.Point(16, 55);
            this.ConsultadataGridView1.Name = "ConsultadataGridView1";
            this.ConsultadataGridView1.Size = new System.Drawing.Size(772, 383);
            this.ConsultadataGridView1.TabIndex = 9;
            // 
            // cEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConsultadataGridView1);
            this.Controls.Add(this.Consultabutton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CriteriotextBox1);
            this.Controls.Add(this.FiltrocomboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HastadateTimePicker1);
            this.Controls.Add(this.DesdedateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "cEvaluacion";
            this.Text = "cEvaluacion";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox CriteriotextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Consultabutton1;
        private System.Windows.Forms.DataGridView ConsultadataGridView1;
    }
}