
namespace DRtail
{
    partial class frmDatosFiscales
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxUso = new System.Windows.Forms.ComboBox();
            this.cmbxMetodo = new System.Windows.Forms.ComboBox();
            this.cmbxForma = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uso CFDI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Metodo de Pago:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forma de Pago:";
            // 
            // cmbxUso
            // 
            this.cmbxUso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxUso.FormattingEnabled = true;
            this.cmbxUso.Location = new System.Drawing.Point(187, 44);
            this.cmbxUso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbxUso.Name = "cmbxUso";
            this.cmbxUso.Size = new System.Drawing.Size(282, 27);
            this.cmbxUso.TabIndex = 3;
            // 
            // cmbxMetodo
            // 
            this.cmbxMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMetodo.FormattingEnabled = true;
            this.cmbxMetodo.Location = new System.Drawing.Point(187, 121);
            this.cmbxMetodo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbxMetodo.Name = "cmbxMetodo";
            this.cmbxMetodo.Size = new System.Drawing.Size(282, 27);
            this.cmbxMetodo.TabIndex = 4;
            // 
            // cmbxForma
            // 
            this.cmbxForma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxForma.FormattingEnabled = true;
            this.cmbxForma.Location = new System.Drawing.Point(187, 197);
            this.cmbxForma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbxForma.Name = "cmbxForma";
            this.cmbxForma.Size = new System.Drawing.Size(282, 27);
            this.cmbxForma.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(356, 270);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(113, 41);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmDatosFiscales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 352);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbxForma);
            this.Controls.Add(this.cmbxMetodo);
            this.Controls.Add(this.cmbxUso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmDatosFiscales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Fiscales";
            this.Load += new System.EventHandler(this.frmDatosFiscales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxUso;
        private System.Windows.Forms.ComboBox cmbxMetodo;
        private System.Windows.Forms.ComboBox cmbxForma;
        private System.Windows.Forms.Button btnAceptar;
    }
}