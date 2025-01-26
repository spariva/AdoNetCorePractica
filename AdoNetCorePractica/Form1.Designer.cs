namespace AdoNetCorePractica
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cmbHospitales = new ComboBox();
            label2 = new Label();
            txtSumaSalarial = new TextBox();
            label3 = new Label();
            txtMediaSalarial = new TextBox();
            txtPersonas = new TextBox();
            label4 = new Label();
            label5 = new Label();
            lstEmpleadosHospital = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 19);
            label1.Name = "label1";
            label1.Size = new Size(109, 30);
            label1.TabIndex = 0;
            label1.Text = "Hospitales";
            // 
            // cmbHospitales
            // 
            cmbHospitales.FormattingEnabled = true;
            cmbHospitales.Location = new Point(30, 53);
            cmbHospitales.Name = "cmbHospitales";
            cmbHospitales.Size = new Size(228, 38);
            cmbHospitales.TabIndex = 1;
            cmbHospitales.SelectedIndexChanged += cmbHospitales_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 195);
            label2.Name = "label2";
            label2.Size = new Size(135, 30);
            label2.TabIndex = 2;
            label2.Text = "Suma salarial";
            // 
            // txtSumaSalarial
            // 
            txtSumaSalarial.Location = new Point(35, 229);
            txtSumaSalarial.Name = "txtSumaSalarial";
            txtSumaSalarial.Size = new Size(194, 35);
            txtSumaSalarial.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 275);
            label3.Name = "label3";
            label3.Size = new Size(141, 30);
            label3.TabIndex = 4;
            label3.Text = "Media salarial";
            // 
            // txtMediaSalarial
            // 
            txtMediaSalarial.Location = new Point(35, 308);
            txtMediaSalarial.Name = "txtMediaSalarial";
            txtMediaSalarial.Size = new Size(194, 35);
            txtMediaSalarial.TabIndex = 5;
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(35, 385);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(194, 35);
            txtPersonas.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 352);
            label4.Name = "label4";
            label4.Size = new Size(95, 30);
            label4.TabIndex = 6;
            label4.Text = "Personas";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(306, 9);
            label5.Name = "label5";
            label5.Size = new Size(196, 30);
            label5.TabIndex = 8;
            label5.Text = "Empleados Hospital";
            // 
            // lstEmpleadosHospital
            // 
            lstEmpleadosHospital.FormattingEnabled = true;
            lstEmpleadosHospital.Location = new Point(306, 50);
            lstEmpleadosHospital.Name = "lstEmpleadosHospital";
            lstEmpleadosHospital.Size = new Size(416, 364);
            lstEmpleadosHospital.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 432);
            Controls.Add(lstEmpleadosHospital);
            Controls.Add(label5);
            Controls.Add(txtPersonas);
            Controls.Add(label4);
            Controls.Add(txtMediaSalarial);
            Controls.Add(label3);
            Controls.Add(txtSumaSalarial);
            Controls.Add(label2);
            Controls.Add(cmbHospitales);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbHospitales;
        private Label label2;
        private TextBox txtSumaSalarial;
        private Label label3;
        private TextBox txtMediaSalarial;
        private TextBox txtPersonas;
        private Label label4;
        private Label label5;
        private ListBox lstEmpleadosHospital;
    }
}
